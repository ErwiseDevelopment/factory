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
   public class serasaenderecoswwgetfilterdata : GXProcedure
   {
      public serasaenderecoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasaenderecoswwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_SERASAENDERECOSCEP") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAENDERECOSCEPOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_SERASAENDERECOSLOGR") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAENDERECOSLOGROPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_SERASAENDERECOSNUM") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAENDERECOSNUMOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_SERASAENDERECOSCOMPL") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAENDERECOSCOMPLOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_SERASAENDERECOSBAIRRO") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAENDERECOSBAIRROOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_SERASAENDERECOSCIDADE") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAENDERECOSCIDADEOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_SERASAENDERECOSESTADO") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAENDERECOSESTADOOPTIONS' */
            S181 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_SERASAENDERECOSTELDDD") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAENDERECOSTELDDDOPTIONS' */
            S191 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_SERASAENDERECOSTEL") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAENDERECOSTELOPTIONS' */
            S201 ();
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
         if ( StringUtil.StrCmp(AV39Session.Get("SerasaEnderecosWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SerasaEnderecosWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("SerasaEnderecosWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSCEP") == 0 )
            {
               AV10TFSerasaEnderecosCEP = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSCEP_SEL") == 0 )
            {
               AV11TFSerasaEnderecosCEP_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSLOGR") == 0 )
            {
               AV12TFSerasaEnderecosLogr = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSLOGR_SEL") == 0 )
            {
               AV13TFSerasaEnderecosLogr_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSNUM") == 0 )
            {
               AV14TFSerasaEnderecosNum = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSNUM_SEL") == 0 )
            {
               AV15TFSerasaEnderecosNum_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSCOMPL") == 0 )
            {
               AV16TFSerasaEnderecosCompl = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSCOMPL_SEL") == 0 )
            {
               AV17TFSerasaEnderecosCompl_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSBAIRRO") == 0 )
            {
               AV18TFSerasaEnderecosBairro = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSBAIRRO_SEL") == 0 )
            {
               AV19TFSerasaEnderecosBairro_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSCIDADE") == 0 )
            {
               AV20TFSerasaEnderecosCidade = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSCIDADE_SEL") == 0 )
            {
               AV21TFSerasaEnderecosCidade_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSESTADO") == 0 )
            {
               AV22TFSerasaEnderecosEstado = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSESTADO_SEL") == 0 )
            {
               AV23TFSerasaEnderecosEstado_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSTELDDD") == 0 )
            {
               AV24TFSerasaEnderecosTelDDD = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSTELDDD_SEL") == 0 )
            {
               AV25TFSerasaEnderecosTelDDD_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSTEL") == 0 )
            {
               AV26TFSerasaEnderecosTel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSTEL_SEL") == 0 )
            {
               AV27TFSerasaEnderecosTel_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "PARM_&SERASAID") == 0 )
            {
               AV50SerasaId = (int)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSERASAENDERECOSCEPOPTIONS' Routine */
         returnInSub = false;
         AV10TFSerasaEnderecosCEP = AV28SearchTxt;
         AV11TFSerasaEnderecosCEP_Sel = "";
         AV53Serasaenderecoswwds_1_serasaid = AV50SerasaId;
         AV54Serasaenderecoswwds_2_tfserasaenderecoscep = AV10TFSerasaEnderecosCEP;
         AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV11TFSerasaEnderecosCEP_Sel;
         AV56Serasaenderecoswwds_4_tfserasaenderecoslogr = AV12TFSerasaEnderecosLogr;
         AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV13TFSerasaEnderecosLogr_Sel;
         AV58Serasaenderecoswwds_6_tfserasaenderecosnum = AV14TFSerasaEnderecosNum;
         AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV15TFSerasaEnderecosNum_Sel;
         AV60Serasaenderecoswwds_8_tfserasaenderecoscompl = AV16TFSerasaEnderecosCompl;
         AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV17TFSerasaEnderecosCompl_Sel;
         AV62Serasaenderecoswwds_10_tfserasaenderecosbairro = AV18TFSerasaEnderecosBairro;
         AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV19TFSerasaEnderecosBairro_Sel;
         AV64Serasaenderecoswwds_12_tfserasaenderecoscidade = AV20TFSerasaEnderecosCidade;
         AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV21TFSerasaEnderecosCidade_Sel;
         AV66Serasaenderecoswwds_14_tfserasaenderecosestado = AV22TFSerasaEnderecosEstado;
         AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV23TFSerasaEnderecosEstado_Sel;
         AV68Serasaenderecoswwds_16_tfserasaenderecostelddd = AV24TFSerasaEnderecosTelDDD;
         AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV25TFSerasaEnderecosTelDDD_Sel;
         AV70Serasaenderecoswwds_18_tfserasaenderecostel = AV26TFSerasaEnderecosTel;
         AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV27TFSerasaEnderecosTel_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                              AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                              AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                              AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                              AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                              AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                              AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                              AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                              AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                              AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                              AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                              AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                              AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                              AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                              AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                              AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                              AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                              AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                              A723SerasaEnderecosCEP ,
                                              A717SerasaEnderecosLogr ,
                                              A718SerasaEnderecosNum ,
                                              A719SerasaEnderecosCompl ,
                                              A720SerasaEnderecosBairro ,
                                              A721SerasaEnderecosCidade ,
                                              A722SerasaEnderecosEstado ,
                                              A724SerasaEnderecosTelDDD ,
                                              A725SerasaEnderecosTel ,
                                              AV53Serasaenderecoswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Serasaenderecoswwds_2_tfserasaenderecoscep = StringUtil.Concat( StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep), "%", "");
         lV56Serasaenderecoswwds_4_tfserasaenderecoslogr = StringUtil.Concat( StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr), "%", "");
         lV58Serasaenderecoswwds_6_tfserasaenderecosnum = StringUtil.Concat( StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum), "%", "");
         lV60Serasaenderecoswwds_8_tfserasaenderecoscompl = StringUtil.Concat( StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl), "%", "");
         lV62Serasaenderecoswwds_10_tfserasaenderecosbairro = StringUtil.Concat( StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro), "%", "");
         lV64Serasaenderecoswwds_12_tfserasaenderecoscidade = StringUtil.Concat( StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade), "%", "");
         lV66Serasaenderecoswwds_14_tfserasaenderecosestado = StringUtil.Concat( StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado), "%", "");
         lV68Serasaenderecoswwds_16_tfserasaenderecostelddd = StringUtil.Concat( StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd), "%", "");
         lV70Serasaenderecoswwds_18_tfserasaenderecostel = StringUtil.Concat( StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel), "%", "");
         /* Using cursor P00D22 */
         pr_default.execute(0, new Object[] {AV53Serasaenderecoswwds_1_serasaid, lV54Serasaenderecoswwds_2_tfserasaenderecoscep, AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, lV56Serasaenderecoswwds_4_tfserasaenderecoslogr, AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, lV58Serasaenderecoswwds_6_tfserasaenderecosnum, AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, lV60Serasaenderecoswwds_8_tfserasaenderecoscompl, AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, lV62Serasaenderecoswwds_10_tfserasaenderecosbairro, AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, lV64Serasaenderecoswwds_12_tfserasaenderecoscidade, AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, lV66Serasaenderecoswwds_14_tfserasaenderecosestado, AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, lV68Serasaenderecoswwds_16_tfserasaenderecostelddd, AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, lV70Serasaenderecoswwds_18_tfserasaenderecostel, AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKD22 = false;
            A662SerasaId = P00D22_A662SerasaId[0];
            n662SerasaId = P00D22_n662SerasaId[0];
            A723SerasaEnderecosCEP = P00D22_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = P00D22_n723SerasaEnderecosCEP[0];
            A725SerasaEnderecosTel = P00D22_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = P00D22_n725SerasaEnderecosTel[0];
            A724SerasaEnderecosTelDDD = P00D22_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = P00D22_n724SerasaEnderecosTelDDD[0];
            A722SerasaEnderecosEstado = P00D22_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = P00D22_n722SerasaEnderecosEstado[0];
            A721SerasaEnderecosCidade = P00D22_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = P00D22_n721SerasaEnderecosCidade[0];
            A720SerasaEnderecosBairro = P00D22_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = P00D22_n720SerasaEnderecosBairro[0];
            A719SerasaEnderecosCompl = P00D22_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = P00D22_n719SerasaEnderecosCompl[0];
            A718SerasaEnderecosNum = P00D22_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = P00D22_n718SerasaEnderecosNum[0];
            A717SerasaEnderecosLogr = P00D22_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = P00D22_n717SerasaEnderecosLogr[0];
            A716SerasaEnderecosId = P00D22_A716SerasaEnderecosId[0];
            AV38count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00D22_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D22_A723SerasaEnderecosCEP[0], A723SerasaEnderecosCEP) == 0 ) )
            {
               BRKD22 = false;
               A716SerasaEnderecosId = P00D22_A716SerasaEnderecosId[0];
               AV38count = (long)(AV38count+1);
               BRKD22 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A723SerasaEnderecosCEP)) ? "<#Empty#>" : A723SerasaEnderecosCEP);
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
            if ( ! BRKD22 )
            {
               BRKD22 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSERASAENDERECOSLOGROPTIONS' Routine */
         returnInSub = false;
         AV12TFSerasaEnderecosLogr = AV28SearchTxt;
         AV13TFSerasaEnderecosLogr_Sel = "";
         AV53Serasaenderecoswwds_1_serasaid = AV50SerasaId;
         AV54Serasaenderecoswwds_2_tfserasaenderecoscep = AV10TFSerasaEnderecosCEP;
         AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV11TFSerasaEnderecosCEP_Sel;
         AV56Serasaenderecoswwds_4_tfserasaenderecoslogr = AV12TFSerasaEnderecosLogr;
         AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV13TFSerasaEnderecosLogr_Sel;
         AV58Serasaenderecoswwds_6_tfserasaenderecosnum = AV14TFSerasaEnderecosNum;
         AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV15TFSerasaEnderecosNum_Sel;
         AV60Serasaenderecoswwds_8_tfserasaenderecoscompl = AV16TFSerasaEnderecosCompl;
         AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV17TFSerasaEnderecosCompl_Sel;
         AV62Serasaenderecoswwds_10_tfserasaenderecosbairro = AV18TFSerasaEnderecosBairro;
         AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV19TFSerasaEnderecosBairro_Sel;
         AV64Serasaenderecoswwds_12_tfserasaenderecoscidade = AV20TFSerasaEnderecosCidade;
         AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV21TFSerasaEnderecosCidade_Sel;
         AV66Serasaenderecoswwds_14_tfserasaenderecosestado = AV22TFSerasaEnderecosEstado;
         AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV23TFSerasaEnderecosEstado_Sel;
         AV68Serasaenderecoswwds_16_tfserasaenderecostelddd = AV24TFSerasaEnderecosTelDDD;
         AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV25TFSerasaEnderecosTelDDD_Sel;
         AV70Serasaenderecoswwds_18_tfserasaenderecostel = AV26TFSerasaEnderecosTel;
         AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV27TFSerasaEnderecosTel_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                              AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                              AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                              AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                              AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                              AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                              AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                              AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                              AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                              AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                              AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                              AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                              AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                              AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                              AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                              AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                              AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                              AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                              A723SerasaEnderecosCEP ,
                                              A717SerasaEnderecosLogr ,
                                              A718SerasaEnderecosNum ,
                                              A719SerasaEnderecosCompl ,
                                              A720SerasaEnderecosBairro ,
                                              A721SerasaEnderecosCidade ,
                                              A722SerasaEnderecosEstado ,
                                              A724SerasaEnderecosTelDDD ,
                                              A725SerasaEnderecosTel ,
                                              AV53Serasaenderecoswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Serasaenderecoswwds_2_tfserasaenderecoscep = StringUtil.Concat( StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep), "%", "");
         lV56Serasaenderecoswwds_4_tfserasaenderecoslogr = StringUtil.Concat( StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr), "%", "");
         lV58Serasaenderecoswwds_6_tfserasaenderecosnum = StringUtil.Concat( StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum), "%", "");
         lV60Serasaenderecoswwds_8_tfserasaenderecoscompl = StringUtil.Concat( StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl), "%", "");
         lV62Serasaenderecoswwds_10_tfserasaenderecosbairro = StringUtil.Concat( StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro), "%", "");
         lV64Serasaenderecoswwds_12_tfserasaenderecoscidade = StringUtil.Concat( StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade), "%", "");
         lV66Serasaenderecoswwds_14_tfserasaenderecosestado = StringUtil.Concat( StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado), "%", "");
         lV68Serasaenderecoswwds_16_tfserasaenderecostelddd = StringUtil.Concat( StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd), "%", "");
         lV70Serasaenderecoswwds_18_tfserasaenderecostel = StringUtil.Concat( StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel), "%", "");
         /* Using cursor P00D23 */
         pr_default.execute(1, new Object[] {AV53Serasaenderecoswwds_1_serasaid, lV54Serasaenderecoswwds_2_tfserasaenderecoscep, AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, lV56Serasaenderecoswwds_4_tfserasaenderecoslogr, AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, lV58Serasaenderecoswwds_6_tfserasaenderecosnum, AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, lV60Serasaenderecoswwds_8_tfserasaenderecoscompl, AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, lV62Serasaenderecoswwds_10_tfserasaenderecosbairro, AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, lV64Serasaenderecoswwds_12_tfserasaenderecoscidade, AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, lV66Serasaenderecoswwds_14_tfserasaenderecosestado, AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, lV68Serasaenderecoswwds_16_tfserasaenderecostelddd, AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, lV70Serasaenderecoswwds_18_tfserasaenderecostel, AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKD24 = false;
            A662SerasaId = P00D23_A662SerasaId[0];
            n662SerasaId = P00D23_n662SerasaId[0];
            A717SerasaEnderecosLogr = P00D23_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = P00D23_n717SerasaEnderecosLogr[0];
            A725SerasaEnderecosTel = P00D23_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = P00D23_n725SerasaEnderecosTel[0];
            A724SerasaEnderecosTelDDD = P00D23_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = P00D23_n724SerasaEnderecosTelDDD[0];
            A722SerasaEnderecosEstado = P00D23_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = P00D23_n722SerasaEnderecosEstado[0];
            A721SerasaEnderecosCidade = P00D23_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = P00D23_n721SerasaEnderecosCidade[0];
            A720SerasaEnderecosBairro = P00D23_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = P00D23_n720SerasaEnderecosBairro[0];
            A719SerasaEnderecosCompl = P00D23_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = P00D23_n719SerasaEnderecosCompl[0];
            A718SerasaEnderecosNum = P00D23_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = P00D23_n718SerasaEnderecosNum[0];
            A723SerasaEnderecosCEP = P00D23_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = P00D23_n723SerasaEnderecosCEP[0];
            A716SerasaEnderecosId = P00D23_A716SerasaEnderecosId[0];
            AV38count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00D23_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D23_A717SerasaEnderecosLogr[0], A717SerasaEnderecosLogr) == 0 ) )
            {
               BRKD24 = false;
               A716SerasaEnderecosId = P00D23_A716SerasaEnderecosId[0];
               AV38count = (long)(AV38count+1);
               BRKD24 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A717SerasaEnderecosLogr)) ? "<#Empty#>" : A717SerasaEnderecosLogr);
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
            if ( ! BRKD24 )
            {
               BRKD24 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSERASAENDERECOSNUMOPTIONS' Routine */
         returnInSub = false;
         AV14TFSerasaEnderecosNum = AV28SearchTxt;
         AV15TFSerasaEnderecosNum_Sel = "";
         AV53Serasaenderecoswwds_1_serasaid = AV50SerasaId;
         AV54Serasaenderecoswwds_2_tfserasaenderecoscep = AV10TFSerasaEnderecosCEP;
         AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV11TFSerasaEnderecosCEP_Sel;
         AV56Serasaenderecoswwds_4_tfserasaenderecoslogr = AV12TFSerasaEnderecosLogr;
         AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV13TFSerasaEnderecosLogr_Sel;
         AV58Serasaenderecoswwds_6_tfserasaenderecosnum = AV14TFSerasaEnderecosNum;
         AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV15TFSerasaEnderecosNum_Sel;
         AV60Serasaenderecoswwds_8_tfserasaenderecoscompl = AV16TFSerasaEnderecosCompl;
         AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV17TFSerasaEnderecosCompl_Sel;
         AV62Serasaenderecoswwds_10_tfserasaenderecosbairro = AV18TFSerasaEnderecosBairro;
         AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV19TFSerasaEnderecosBairro_Sel;
         AV64Serasaenderecoswwds_12_tfserasaenderecoscidade = AV20TFSerasaEnderecosCidade;
         AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV21TFSerasaEnderecosCidade_Sel;
         AV66Serasaenderecoswwds_14_tfserasaenderecosestado = AV22TFSerasaEnderecosEstado;
         AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV23TFSerasaEnderecosEstado_Sel;
         AV68Serasaenderecoswwds_16_tfserasaenderecostelddd = AV24TFSerasaEnderecosTelDDD;
         AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV25TFSerasaEnderecosTelDDD_Sel;
         AV70Serasaenderecoswwds_18_tfserasaenderecostel = AV26TFSerasaEnderecosTel;
         AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV27TFSerasaEnderecosTel_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                              AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                              AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                              AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                              AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                              AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                              AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                              AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                              AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                              AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                              AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                              AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                              AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                              AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                              AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                              AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                              AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                              AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                              A723SerasaEnderecosCEP ,
                                              A717SerasaEnderecosLogr ,
                                              A718SerasaEnderecosNum ,
                                              A719SerasaEnderecosCompl ,
                                              A720SerasaEnderecosBairro ,
                                              A721SerasaEnderecosCidade ,
                                              A722SerasaEnderecosEstado ,
                                              A724SerasaEnderecosTelDDD ,
                                              A725SerasaEnderecosTel ,
                                              AV53Serasaenderecoswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Serasaenderecoswwds_2_tfserasaenderecoscep = StringUtil.Concat( StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep), "%", "");
         lV56Serasaenderecoswwds_4_tfserasaenderecoslogr = StringUtil.Concat( StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr), "%", "");
         lV58Serasaenderecoswwds_6_tfserasaenderecosnum = StringUtil.Concat( StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum), "%", "");
         lV60Serasaenderecoswwds_8_tfserasaenderecoscompl = StringUtil.Concat( StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl), "%", "");
         lV62Serasaenderecoswwds_10_tfserasaenderecosbairro = StringUtil.Concat( StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro), "%", "");
         lV64Serasaenderecoswwds_12_tfserasaenderecoscidade = StringUtil.Concat( StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade), "%", "");
         lV66Serasaenderecoswwds_14_tfserasaenderecosestado = StringUtil.Concat( StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado), "%", "");
         lV68Serasaenderecoswwds_16_tfserasaenderecostelddd = StringUtil.Concat( StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd), "%", "");
         lV70Serasaenderecoswwds_18_tfserasaenderecostel = StringUtil.Concat( StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel), "%", "");
         /* Using cursor P00D24 */
         pr_default.execute(2, new Object[] {AV53Serasaenderecoswwds_1_serasaid, lV54Serasaenderecoswwds_2_tfserasaenderecoscep, AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, lV56Serasaenderecoswwds_4_tfserasaenderecoslogr, AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, lV58Serasaenderecoswwds_6_tfserasaenderecosnum, AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, lV60Serasaenderecoswwds_8_tfserasaenderecoscompl, AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, lV62Serasaenderecoswwds_10_tfserasaenderecosbairro, AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, lV64Serasaenderecoswwds_12_tfserasaenderecoscidade, AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, lV66Serasaenderecoswwds_14_tfserasaenderecosestado, AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, lV68Serasaenderecoswwds_16_tfserasaenderecostelddd, AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, lV70Serasaenderecoswwds_18_tfserasaenderecostel, AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKD26 = false;
            A662SerasaId = P00D24_A662SerasaId[0];
            n662SerasaId = P00D24_n662SerasaId[0];
            A718SerasaEnderecosNum = P00D24_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = P00D24_n718SerasaEnderecosNum[0];
            A725SerasaEnderecosTel = P00D24_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = P00D24_n725SerasaEnderecosTel[0];
            A724SerasaEnderecosTelDDD = P00D24_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = P00D24_n724SerasaEnderecosTelDDD[0];
            A722SerasaEnderecosEstado = P00D24_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = P00D24_n722SerasaEnderecosEstado[0];
            A721SerasaEnderecosCidade = P00D24_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = P00D24_n721SerasaEnderecosCidade[0];
            A720SerasaEnderecosBairro = P00D24_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = P00D24_n720SerasaEnderecosBairro[0];
            A719SerasaEnderecosCompl = P00D24_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = P00D24_n719SerasaEnderecosCompl[0];
            A717SerasaEnderecosLogr = P00D24_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = P00D24_n717SerasaEnderecosLogr[0];
            A723SerasaEnderecosCEP = P00D24_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = P00D24_n723SerasaEnderecosCEP[0];
            A716SerasaEnderecosId = P00D24_A716SerasaEnderecosId[0];
            AV38count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00D24_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D24_A718SerasaEnderecosNum[0], A718SerasaEnderecosNum) == 0 ) )
            {
               BRKD26 = false;
               A716SerasaEnderecosId = P00D24_A716SerasaEnderecosId[0];
               AV38count = (long)(AV38count+1);
               BRKD26 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A718SerasaEnderecosNum)) ? "<#Empty#>" : A718SerasaEnderecosNum);
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
            if ( ! BRKD26 )
            {
               BRKD26 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSERASAENDERECOSCOMPLOPTIONS' Routine */
         returnInSub = false;
         AV16TFSerasaEnderecosCompl = AV28SearchTxt;
         AV17TFSerasaEnderecosCompl_Sel = "";
         AV53Serasaenderecoswwds_1_serasaid = AV50SerasaId;
         AV54Serasaenderecoswwds_2_tfserasaenderecoscep = AV10TFSerasaEnderecosCEP;
         AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV11TFSerasaEnderecosCEP_Sel;
         AV56Serasaenderecoswwds_4_tfserasaenderecoslogr = AV12TFSerasaEnderecosLogr;
         AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV13TFSerasaEnderecosLogr_Sel;
         AV58Serasaenderecoswwds_6_tfserasaenderecosnum = AV14TFSerasaEnderecosNum;
         AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV15TFSerasaEnderecosNum_Sel;
         AV60Serasaenderecoswwds_8_tfserasaenderecoscompl = AV16TFSerasaEnderecosCompl;
         AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV17TFSerasaEnderecosCompl_Sel;
         AV62Serasaenderecoswwds_10_tfserasaenderecosbairro = AV18TFSerasaEnderecosBairro;
         AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV19TFSerasaEnderecosBairro_Sel;
         AV64Serasaenderecoswwds_12_tfserasaenderecoscidade = AV20TFSerasaEnderecosCidade;
         AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV21TFSerasaEnderecosCidade_Sel;
         AV66Serasaenderecoswwds_14_tfserasaenderecosestado = AV22TFSerasaEnderecosEstado;
         AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV23TFSerasaEnderecosEstado_Sel;
         AV68Serasaenderecoswwds_16_tfserasaenderecostelddd = AV24TFSerasaEnderecosTelDDD;
         AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV25TFSerasaEnderecosTelDDD_Sel;
         AV70Serasaenderecoswwds_18_tfserasaenderecostel = AV26TFSerasaEnderecosTel;
         AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV27TFSerasaEnderecosTel_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                              AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                              AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                              AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                              AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                              AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                              AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                              AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                              AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                              AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                              AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                              AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                              AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                              AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                              AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                              AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                              AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                              AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                              A723SerasaEnderecosCEP ,
                                              A717SerasaEnderecosLogr ,
                                              A718SerasaEnderecosNum ,
                                              A719SerasaEnderecosCompl ,
                                              A720SerasaEnderecosBairro ,
                                              A721SerasaEnderecosCidade ,
                                              A722SerasaEnderecosEstado ,
                                              A724SerasaEnderecosTelDDD ,
                                              A725SerasaEnderecosTel ,
                                              AV53Serasaenderecoswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Serasaenderecoswwds_2_tfserasaenderecoscep = StringUtil.Concat( StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep), "%", "");
         lV56Serasaenderecoswwds_4_tfserasaenderecoslogr = StringUtil.Concat( StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr), "%", "");
         lV58Serasaenderecoswwds_6_tfserasaenderecosnum = StringUtil.Concat( StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum), "%", "");
         lV60Serasaenderecoswwds_8_tfserasaenderecoscompl = StringUtil.Concat( StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl), "%", "");
         lV62Serasaenderecoswwds_10_tfserasaenderecosbairro = StringUtil.Concat( StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro), "%", "");
         lV64Serasaenderecoswwds_12_tfserasaenderecoscidade = StringUtil.Concat( StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade), "%", "");
         lV66Serasaenderecoswwds_14_tfserasaenderecosestado = StringUtil.Concat( StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado), "%", "");
         lV68Serasaenderecoswwds_16_tfserasaenderecostelddd = StringUtil.Concat( StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd), "%", "");
         lV70Serasaenderecoswwds_18_tfserasaenderecostel = StringUtil.Concat( StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel), "%", "");
         /* Using cursor P00D25 */
         pr_default.execute(3, new Object[] {AV53Serasaenderecoswwds_1_serasaid, lV54Serasaenderecoswwds_2_tfserasaenderecoscep, AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, lV56Serasaenderecoswwds_4_tfserasaenderecoslogr, AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, lV58Serasaenderecoswwds_6_tfserasaenderecosnum, AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, lV60Serasaenderecoswwds_8_tfserasaenderecoscompl, AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, lV62Serasaenderecoswwds_10_tfserasaenderecosbairro, AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, lV64Serasaenderecoswwds_12_tfserasaenderecoscidade, AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, lV66Serasaenderecoswwds_14_tfserasaenderecosestado, AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, lV68Serasaenderecoswwds_16_tfserasaenderecostelddd, AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, lV70Serasaenderecoswwds_18_tfserasaenderecostel, AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKD28 = false;
            A662SerasaId = P00D25_A662SerasaId[0];
            n662SerasaId = P00D25_n662SerasaId[0];
            A719SerasaEnderecosCompl = P00D25_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = P00D25_n719SerasaEnderecosCompl[0];
            A725SerasaEnderecosTel = P00D25_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = P00D25_n725SerasaEnderecosTel[0];
            A724SerasaEnderecosTelDDD = P00D25_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = P00D25_n724SerasaEnderecosTelDDD[0];
            A722SerasaEnderecosEstado = P00D25_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = P00D25_n722SerasaEnderecosEstado[0];
            A721SerasaEnderecosCidade = P00D25_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = P00D25_n721SerasaEnderecosCidade[0];
            A720SerasaEnderecosBairro = P00D25_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = P00D25_n720SerasaEnderecosBairro[0];
            A718SerasaEnderecosNum = P00D25_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = P00D25_n718SerasaEnderecosNum[0];
            A717SerasaEnderecosLogr = P00D25_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = P00D25_n717SerasaEnderecosLogr[0];
            A723SerasaEnderecosCEP = P00D25_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = P00D25_n723SerasaEnderecosCEP[0];
            A716SerasaEnderecosId = P00D25_A716SerasaEnderecosId[0];
            AV38count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( P00D25_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D25_A719SerasaEnderecosCompl[0], A719SerasaEnderecosCompl) == 0 ) )
            {
               BRKD28 = false;
               A716SerasaEnderecosId = P00D25_A716SerasaEnderecosId[0];
               AV38count = (long)(AV38count+1);
               BRKD28 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A719SerasaEnderecosCompl)) ? "<#Empty#>" : A719SerasaEnderecosCompl);
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
            if ( ! BRKD28 )
            {
               BRKD28 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADSERASAENDERECOSBAIRROOPTIONS' Routine */
         returnInSub = false;
         AV18TFSerasaEnderecosBairro = AV28SearchTxt;
         AV19TFSerasaEnderecosBairro_Sel = "";
         AV53Serasaenderecoswwds_1_serasaid = AV50SerasaId;
         AV54Serasaenderecoswwds_2_tfserasaenderecoscep = AV10TFSerasaEnderecosCEP;
         AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV11TFSerasaEnderecosCEP_Sel;
         AV56Serasaenderecoswwds_4_tfserasaenderecoslogr = AV12TFSerasaEnderecosLogr;
         AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV13TFSerasaEnderecosLogr_Sel;
         AV58Serasaenderecoswwds_6_tfserasaenderecosnum = AV14TFSerasaEnderecosNum;
         AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV15TFSerasaEnderecosNum_Sel;
         AV60Serasaenderecoswwds_8_tfserasaenderecoscompl = AV16TFSerasaEnderecosCompl;
         AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV17TFSerasaEnderecosCompl_Sel;
         AV62Serasaenderecoswwds_10_tfserasaenderecosbairro = AV18TFSerasaEnderecosBairro;
         AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV19TFSerasaEnderecosBairro_Sel;
         AV64Serasaenderecoswwds_12_tfserasaenderecoscidade = AV20TFSerasaEnderecosCidade;
         AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV21TFSerasaEnderecosCidade_Sel;
         AV66Serasaenderecoswwds_14_tfserasaenderecosestado = AV22TFSerasaEnderecosEstado;
         AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV23TFSerasaEnderecosEstado_Sel;
         AV68Serasaenderecoswwds_16_tfserasaenderecostelddd = AV24TFSerasaEnderecosTelDDD;
         AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV25TFSerasaEnderecosTelDDD_Sel;
         AV70Serasaenderecoswwds_18_tfserasaenderecostel = AV26TFSerasaEnderecosTel;
         AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV27TFSerasaEnderecosTel_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                              AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                              AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                              AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                              AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                              AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                              AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                              AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                              AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                              AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                              AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                              AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                              AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                              AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                              AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                              AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                              AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                              AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                              A723SerasaEnderecosCEP ,
                                              A717SerasaEnderecosLogr ,
                                              A718SerasaEnderecosNum ,
                                              A719SerasaEnderecosCompl ,
                                              A720SerasaEnderecosBairro ,
                                              A721SerasaEnderecosCidade ,
                                              A722SerasaEnderecosEstado ,
                                              A724SerasaEnderecosTelDDD ,
                                              A725SerasaEnderecosTel ,
                                              AV53Serasaenderecoswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Serasaenderecoswwds_2_tfserasaenderecoscep = StringUtil.Concat( StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep), "%", "");
         lV56Serasaenderecoswwds_4_tfserasaenderecoslogr = StringUtil.Concat( StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr), "%", "");
         lV58Serasaenderecoswwds_6_tfserasaenderecosnum = StringUtil.Concat( StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum), "%", "");
         lV60Serasaenderecoswwds_8_tfserasaenderecoscompl = StringUtil.Concat( StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl), "%", "");
         lV62Serasaenderecoswwds_10_tfserasaenderecosbairro = StringUtil.Concat( StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro), "%", "");
         lV64Serasaenderecoswwds_12_tfserasaenderecoscidade = StringUtil.Concat( StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade), "%", "");
         lV66Serasaenderecoswwds_14_tfserasaenderecosestado = StringUtil.Concat( StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado), "%", "");
         lV68Serasaenderecoswwds_16_tfserasaenderecostelddd = StringUtil.Concat( StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd), "%", "");
         lV70Serasaenderecoswwds_18_tfserasaenderecostel = StringUtil.Concat( StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel), "%", "");
         /* Using cursor P00D26 */
         pr_default.execute(4, new Object[] {AV53Serasaenderecoswwds_1_serasaid, lV54Serasaenderecoswwds_2_tfserasaenderecoscep, AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, lV56Serasaenderecoswwds_4_tfserasaenderecoslogr, AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, lV58Serasaenderecoswwds_6_tfserasaenderecosnum, AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, lV60Serasaenderecoswwds_8_tfserasaenderecoscompl, AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, lV62Serasaenderecoswwds_10_tfserasaenderecosbairro, AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, lV64Serasaenderecoswwds_12_tfserasaenderecoscidade, AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, lV66Serasaenderecoswwds_14_tfserasaenderecosestado, AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, lV68Serasaenderecoswwds_16_tfserasaenderecostelddd, AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, lV70Serasaenderecoswwds_18_tfserasaenderecostel, AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKD210 = false;
            A662SerasaId = P00D26_A662SerasaId[0];
            n662SerasaId = P00D26_n662SerasaId[0];
            A720SerasaEnderecosBairro = P00D26_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = P00D26_n720SerasaEnderecosBairro[0];
            A725SerasaEnderecosTel = P00D26_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = P00D26_n725SerasaEnderecosTel[0];
            A724SerasaEnderecosTelDDD = P00D26_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = P00D26_n724SerasaEnderecosTelDDD[0];
            A722SerasaEnderecosEstado = P00D26_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = P00D26_n722SerasaEnderecosEstado[0];
            A721SerasaEnderecosCidade = P00D26_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = P00D26_n721SerasaEnderecosCidade[0];
            A719SerasaEnderecosCompl = P00D26_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = P00D26_n719SerasaEnderecosCompl[0];
            A718SerasaEnderecosNum = P00D26_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = P00D26_n718SerasaEnderecosNum[0];
            A717SerasaEnderecosLogr = P00D26_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = P00D26_n717SerasaEnderecosLogr[0];
            A723SerasaEnderecosCEP = P00D26_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = P00D26_n723SerasaEnderecosCEP[0];
            A716SerasaEnderecosId = P00D26_A716SerasaEnderecosId[0];
            AV38count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( P00D26_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D26_A720SerasaEnderecosBairro[0], A720SerasaEnderecosBairro) == 0 ) )
            {
               BRKD210 = false;
               A716SerasaEnderecosId = P00D26_A716SerasaEnderecosId[0];
               AV38count = (long)(AV38count+1);
               BRKD210 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A720SerasaEnderecosBairro)) ? "<#Empty#>" : A720SerasaEnderecosBairro);
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
            if ( ! BRKD210 )
            {
               BRKD210 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADSERASAENDERECOSCIDADEOPTIONS' Routine */
         returnInSub = false;
         AV20TFSerasaEnderecosCidade = AV28SearchTxt;
         AV21TFSerasaEnderecosCidade_Sel = "";
         AV53Serasaenderecoswwds_1_serasaid = AV50SerasaId;
         AV54Serasaenderecoswwds_2_tfserasaenderecoscep = AV10TFSerasaEnderecosCEP;
         AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV11TFSerasaEnderecosCEP_Sel;
         AV56Serasaenderecoswwds_4_tfserasaenderecoslogr = AV12TFSerasaEnderecosLogr;
         AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV13TFSerasaEnderecosLogr_Sel;
         AV58Serasaenderecoswwds_6_tfserasaenderecosnum = AV14TFSerasaEnderecosNum;
         AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV15TFSerasaEnderecosNum_Sel;
         AV60Serasaenderecoswwds_8_tfserasaenderecoscompl = AV16TFSerasaEnderecosCompl;
         AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV17TFSerasaEnderecosCompl_Sel;
         AV62Serasaenderecoswwds_10_tfserasaenderecosbairro = AV18TFSerasaEnderecosBairro;
         AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV19TFSerasaEnderecosBairro_Sel;
         AV64Serasaenderecoswwds_12_tfserasaenderecoscidade = AV20TFSerasaEnderecosCidade;
         AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV21TFSerasaEnderecosCidade_Sel;
         AV66Serasaenderecoswwds_14_tfserasaenderecosestado = AV22TFSerasaEnderecosEstado;
         AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV23TFSerasaEnderecosEstado_Sel;
         AV68Serasaenderecoswwds_16_tfserasaenderecostelddd = AV24TFSerasaEnderecosTelDDD;
         AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV25TFSerasaEnderecosTelDDD_Sel;
         AV70Serasaenderecoswwds_18_tfserasaenderecostel = AV26TFSerasaEnderecosTel;
         AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV27TFSerasaEnderecosTel_Sel;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                              AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                              AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                              AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                              AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                              AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                              AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                              AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                              AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                              AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                              AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                              AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                              AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                              AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                              AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                              AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                              AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                              AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                              A723SerasaEnderecosCEP ,
                                              A717SerasaEnderecosLogr ,
                                              A718SerasaEnderecosNum ,
                                              A719SerasaEnderecosCompl ,
                                              A720SerasaEnderecosBairro ,
                                              A721SerasaEnderecosCidade ,
                                              A722SerasaEnderecosEstado ,
                                              A724SerasaEnderecosTelDDD ,
                                              A725SerasaEnderecosTel ,
                                              AV53Serasaenderecoswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Serasaenderecoswwds_2_tfserasaenderecoscep = StringUtil.Concat( StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep), "%", "");
         lV56Serasaenderecoswwds_4_tfserasaenderecoslogr = StringUtil.Concat( StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr), "%", "");
         lV58Serasaenderecoswwds_6_tfserasaenderecosnum = StringUtil.Concat( StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum), "%", "");
         lV60Serasaenderecoswwds_8_tfserasaenderecoscompl = StringUtil.Concat( StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl), "%", "");
         lV62Serasaenderecoswwds_10_tfserasaenderecosbairro = StringUtil.Concat( StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro), "%", "");
         lV64Serasaenderecoswwds_12_tfserasaenderecoscidade = StringUtil.Concat( StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade), "%", "");
         lV66Serasaenderecoswwds_14_tfserasaenderecosestado = StringUtil.Concat( StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado), "%", "");
         lV68Serasaenderecoswwds_16_tfserasaenderecostelddd = StringUtil.Concat( StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd), "%", "");
         lV70Serasaenderecoswwds_18_tfserasaenderecostel = StringUtil.Concat( StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel), "%", "");
         /* Using cursor P00D27 */
         pr_default.execute(5, new Object[] {AV53Serasaenderecoswwds_1_serasaid, lV54Serasaenderecoswwds_2_tfserasaenderecoscep, AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, lV56Serasaenderecoswwds_4_tfserasaenderecoslogr, AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, lV58Serasaenderecoswwds_6_tfserasaenderecosnum, AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, lV60Serasaenderecoswwds_8_tfserasaenderecoscompl, AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, lV62Serasaenderecoswwds_10_tfserasaenderecosbairro, AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, lV64Serasaenderecoswwds_12_tfserasaenderecoscidade, AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, lV66Serasaenderecoswwds_14_tfserasaenderecosestado, AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, lV68Serasaenderecoswwds_16_tfserasaenderecostelddd, AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, lV70Serasaenderecoswwds_18_tfserasaenderecostel, AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKD212 = false;
            A662SerasaId = P00D27_A662SerasaId[0];
            n662SerasaId = P00D27_n662SerasaId[0];
            A721SerasaEnderecosCidade = P00D27_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = P00D27_n721SerasaEnderecosCidade[0];
            A725SerasaEnderecosTel = P00D27_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = P00D27_n725SerasaEnderecosTel[0];
            A724SerasaEnderecosTelDDD = P00D27_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = P00D27_n724SerasaEnderecosTelDDD[0];
            A722SerasaEnderecosEstado = P00D27_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = P00D27_n722SerasaEnderecosEstado[0];
            A720SerasaEnderecosBairro = P00D27_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = P00D27_n720SerasaEnderecosBairro[0];
            A719SerasaEnderecosCompl = P00D27_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = P00D27_n719SerasaEnderecosCompl[0];
            A718SerasaEnderecosNum = P00D27_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = P00D27_n718SerasaEnderecosNum[0];
            A717SerasaEnderecosLogr = P00D27_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = P00D27_n717SerasaEnderecosLogr[0];
            A723SerasaEnderecosCEP = P00D27_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = P00D27_n723SerasaEnderecosCEP[0];
            A716SerasaEnderecosId = P00D27_A716SerasaEnderecosId[0];
            AV38count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( P00D27_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D27_A721SerasaEnderecosCidade[0], A721SerasaEnderecosCidade) == 0 ) )
            {
               BRKD212 = false;
               A716SerasaEnderecosId = P00D27_A716SerasaEnderecosId[0];
               AV38count = (long)(AV38count+1);
               BRKD212 = true;
               pr_default.readNext(5);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A721SerasaEnderecosCidade)) ? "<#Empty#>" : A721SerasaEnderecosCidade);
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
            if ( ! BRKD212 )
            {
               BRKD212 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADSERASAENDERECOSESTADOOPTIONS' Routine */
         returnInSub = false;
         AV22TFSerasaEnderecosEstado = AV28SearchTxt;
         AV23TFSerasaEnderecosEstado_Sel = "";
         AV53Serasaenderecoswwds_1_serasaid = AV50SerasaId;
         AV54Serasaenderecoswwds_2_tfserasaenderecoscep = AV10TFSerasaEnderecosCEP;
         AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV11TFSerasaEnderecosCEP_Sel;
         AV56Serasaenderecoswwds_4_tfserasaenderecoslogr = AV12TFSerasaEnderecosLogr;
         AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV13TFSerasaEnderecosLogr_Sel;
         AV58Serasaenderecoswwds_6_tfserasaenderecosnum = AV14TFSerasaEnderecosNum;
         AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV15TFSerasaEnderecosNum_Sel;
         AV60Serasaenderecoswwds_8_tfserasaenderecoscompl = AV16TFSerasaEnderecosCompl;
         AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV17TFSerasaEnderecosCompl_Sel;
         AV62Serasaenderecoswwds_10_tfserasaenderecosbairro = AV18TFSerasaEnderecosBairro;
         AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV19TFSerasaEnderecosBairro_Sel;
         AV64Serasaenderecoswwds_12_tfserasaenderecoscidade = AV20TFSerasaEnderecosCidade;
         AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV21TFSerasaEnderecosCidade_Sel;
         AV66Serasaenderecoswwds_14_tfserasaenderecosestado = AV22TFSerasaEnderecosEstado;
         AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV23TFSerasaEnderecosEstado_Sel;
         AV68Serasaenderecoswwds_16_tfserasaenderecostelddd = AV24TFSerasaEnderecosTelDDD;
         AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV25TFSerasaEnderecosTelDDD_Sel;
         AV70Serasaenderecoswwds_18_tfserasaenderecostel = AV26TFSerasaEnderecosTel;
         AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV27TFSerasaEnderecosTel_Sel;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                              AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                              AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                              AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                              AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                              AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                              AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                              AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                              AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                              AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                              AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                              AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                              AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                              AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                              AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                              AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                              AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                              AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                              A723SerasaEnderecosCEP ,
                                              A717SerasaEnderecosLogr ,
                                              A718SerasaEnderecosNum ,
                                              A719SerasaEnderecosCompl ,
                                              A720SerasaEnderecosBairro ,
                                              A721SerasaEnderecosCidade ,
                                              A722SerasaEnderecosEstado ,
                                              A724SerasaEnderecosTelDDD ,
                                              A725SerasaEnderecosTel ,
                                              AV53Serasaenderecoswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Serasaenderecoswwds_2_tfserasaenderecoscep = StringUtil.Concat( StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep), "%", "");
         lV56Serasaenderecoswwds_4_tfserasaenderecoslogr = StringUtil.Concat( StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr), "%", "");
         lV58Serasaenderecoswwds_6_tfserasaenderecosnum = StringUtil.Concat( StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum), "%", "");
         lV60Serasaenderecoswwds_8_tfserasaenderecoscompl = StringUtil.Concat( StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl), "%", "");
         lV62Serasaenderecoswwds_10_tfserasaenderecosbairro = StringUtil.Concat( StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro), "%", "");
         lV64Serasaenderecoswwds_12_tfserasaenderecoscidade = StringUtil.Concat( StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade), "%", "");
         lV66Serasaenderecoswwds_14_tfserasaenderecosestado = StringUtil.Concat( StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado), "%", "");
         lV68Serasaenderecoswwds_16_tfserasaenderecostelddd = StringUtil.Concat( StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd), "%", "");
         lV70Serasaenderecoswwds_18_tfserasaenderecostel = StringUtil.Concat( StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel), "%", "");
         /* Using cursor P00D28 */
         pr_default.execute(6, new Object[] {AV53Serasaenderecoswwds_1_serasaid, lV54Serasaenderecoswwds_2_tfserasaenderecoscep, AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, lV56Serasaenderecoswwds_4_tfserasaenderecoslogr, AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, lV58Serasaenderecoswwds_6_tfserasaenderecosnum, AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, lV60Serasaenderecoswwds_8_tfserasaenderecoscompl, AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, lV62Serasaenderecoswwds_10_tfserasaenderecosbairro, AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, lV64Serasaenderecoswwds_12_tfserasaenderecoscidade, AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, lV66Serasaenderecoswwds_14_tfserasaenderecosestado, AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, lV68Serasaenderecoswwds_16_tfserasaenderecostelddd, AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, lV70Serasaenderecoswwds_18_tfserasaenderecostel, AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRKD214 = false;
            A662SerasaId = P00D28_A662SerasaId[0];
            n662SerasaId = P00D28_n662SerasaId[0];
            A722SerasaEnderecosEstado = P00D28_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = P00D28_n722SerasaEnderecosEstado[0];
            A725SerasaEnderecosTel = P00D28_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = P00D28_n725SerasaEnderecosTel[0];
            A724SerasaEnderecosTelDDD = P00D28_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = P00D28_n724SerasaEnderecosTelDDD[0];
            A721SerasaEnderecosCidade = P00D28_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = P00D28_n721SerasaEnderecosCidade[0];
            A720SerasaEnderecosBairro = P00D28_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = P00D28_n720SerasaEnderecosBairro[0];
            A719SerasaEnderecosCompl = P00D28_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = P00D28_n719SerasaEnderecosCompl[0];
            A718SerasaEnderecosNum = P00D28_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = P00D28_n718SerasaEnderecosNum[0];
            A717SerasaEnderecosLogr = P00D28_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = P00D28_n717SerasaEnderecosLogr[0];
            A723SerasaEnderecosCEP = P00D28_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = P00D28_n723SerasaEnderecosCEP[0];
            A716SerasaEnderecosId = P00D28_A716SerasaEnderecosId[0];
            AV38count = 0;
            while ( (pr_default.getStatus(6) != 101) && ( P00D28_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D28_A722SerasaEnderecosEstado[0], A722SerasaEnderecosEstado) == 0 ) )
            {
               BRKD214 = false;
               A716SerasaEnderecosId = P00D28_A716SerasaEnderecosId[0];
               AV38count = (long)(AV38count+1);
               BRKD214 = true;
               pr_default.readNext(6);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A722SerasaEnderecosEstado)) ? "<#Empty#>" : A722SerasaEnderecosEstado);
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
            if ( ! BRKD214 )
            {
               BRKD214 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
      }

      protected void S191( )
      {
         /* 'LOADSERASAENDERECOSTELDDDOPTIONS' Routine */
         returnInSub = false;
         AV24TFSerasaEnderecosTelDDD = AV28SearchTxt;
         AV25TFSerasaEnderecosTelDDD_Sel = "";
         AV53Serasaenderecoswwds_1_serasaid = AV50SerasaId;
         AV54Serasaenderecoswwds_2_tfserasaenderecoscep = AV10TFSerasaEnderecosCEP;
         AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV11TFSerasaEnderecosCEP_Sel;
         AV56Serasaenderecoswwds_4_tfserasaenderecoslogr = AV12TFSerasaEnderecosLogr;
         AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV13TFSerasaEnderecosLogr_Sel;
         AV58Serasaenderecoswwds_6_tfserasaenderecosnum = AV14TFSerasaEnderecosNum;
         AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV15TFSerasaEnderecosNum_Sel;
         AV60Serasaenderecoswwds_8_tfserasaenderecoscompl = AV16TFSerasaEnderecosCompl;
         AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV17TFSerasaEnderecosCompl_Sel;
         AV62Serasaenderecoswwds_10_tfserasaenderecosbairro = AV18TFSerasaEnderecosBairro;
         AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV19TFSerasaEnderecosBairro_Sel;
         AV64Serasaenderecoswwds_12_tfserasaenderecoscidade = AV20TFSerasaEnderecosCidade;
         AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV21TFSerasaEnderecosCidade_Sel;
         AV66Serasaenderecoswwds_14_tfserasaenderecosestado = AV22TFSerasaEnderecosEstado;
         AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV23TFSerasaEnderecosEstado_Sel;
         AV68Serasaenderecoswwds_16_tfserasaenderecostelddd = AV24TFSerasaEnderecosTelDDD;
         AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV25TFSerasaEnderecosTelDDD_Sel;
         AV70Serasaenderecoswwds_18_tfserasaenderecostel = AV26TFSerasaEnderecosTel;
         AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV27TFSerasaEnderecosTel_Sel;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                              AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                              AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                              AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                              AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                              AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                              AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                              AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                              AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                              AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                              AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                              AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                              AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                              AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                              AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                              AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                              AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                              AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                              A723SerasaEnderecosCEP ,
                                              A717SerasaEnderecosLogr ,
                                              A718SerasaEnderecosNum ,
                                              A719SerasaEnderecosCompl ,
                                              A720SerasaEnderecosBairro ,
                                              A721SerasaEnderecosCidade ,
                                              A722SerasaEnderecosEstado ,
                                              A724SerasaEnderecosTelDDD ,
                                              A725SerasaEnderecosTel ,
                                              AV53Serasaenderecoswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Serasaenderecoswwds_2_tfserasaenderecoscep = StringUtil.Concat( StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep), "%", "");
         lV56Serasaenderecoswwds_4_tfserasaenderecoslogr = StringUtil.Concat( StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr), "%", "");
         lV58Serasaenderecoswwds_6_tfserasaenderecosnum = StringUtil.Concat( StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum), "%", "");
         lV60Serasaenderecoswwds_8_tfserasaenderecoscompl = StringUtil.Concat( StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl), "%", "");
         lV62Serasaenderecoswwds_10_tfserasaenderecosbairro = StringUtil.Concat( StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro), "%", "");
         lV64Serasaenderecoswwds_12_tfserasaenderecoscidade = StringUtil.Concat( StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade), "%", "");
         lV66Serasaenderecoswwds_14_tfserasaenderecosestado = StringUtil.Concat( StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado), "%", "");
         lV68Serasaenderecoswwds_16_tfserasaenderecostelddd = StringUtil.Concat( StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd), "%", "");
         lV70Serasaenderecoswwds_18_tfserasaenderecostel = StringUtil.Concat( StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel), "%", "");
         /* Using cursor P00D29 */
         pr_default.execute(7, new Object[] {AV53Serasaenderecoswwds_1_serasaid, lV54Serasaenderecoswwds_2_tfserasaenderecoscep, AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, lV56Serasaenderecoswwds_4_tfserasaenderecoslogr, AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, lV58Serasaenderecoswwds_6_tfserasaenderecosnum, AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, lV60Serasaenderecoswwds_8_tfserasaenderecoscompl, AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, lV62Serasaenderecoswwds_10_tfserasaenderecosbairro, AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, lV64Serasaenderecoswwds_12_tfserasaenderecoscidade, AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, lV66Serasaenderecoswwds_14_tfserasaenderecosestado, AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, lV68Serasaenderecoswwds_16_tfserasaenderecostelddd, AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, lV70Serasaenderecoswwds_18_tfserasaenderecostel, AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel});
         while ( (pr_default.getStatus(7) != 101) )
         {
            BRKD216 = false;
            A662SerasaId = P00D29_A662SerasaId[0];
            n662SerasaId = P00D29_n662SerasaId[0];
            A724SerasaEnderecosTelDDD = P00D29_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = P00D29_n724SerasaEnderecosTelDDD[0];
            A725SerasaEnderecosTel = P00D29_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = P00D29_n725SerasaEnderecosTel[0];
            A722SerasaEnderecosEstado = P00D29_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = P00D29_n722SerasaEnderecosEstado[0];
            A721SerasaEnderecosCidade = P00D29_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = P00D29_n721SerasaEnderecosCidade[0];
            A720SerasaEnderecosBairro = P00D29_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = P00D29_n720SerasaEnderecosBairro[0];
            A719SerasaEnderecosCompl = P00D29_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = P00D29_n719SerasaEnderecosCompl[0];
            A718SerasaEnderecosNum = P00D29_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = P00D29_n718SerasaEnderecosNum[0];
            A717SerasaEnderecosLogr = P00D29_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = P00D29_n717SerasaEnderecosLogr[0];
            A723SerasaEnderecosCEP = P00D29_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = P00D29_n723SerasaEnderecosCEP[0];
            A716SerasaEnderecosId = P00D29_A716SerasaEnderecosId[0];
            AV38count = 0;
            while ( (pr_default.getStatus(7) != 101) && ( P00D29_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D29_A724SerasaEnderecosTelDDD[0], A724SerasaEnderecosTelDDD) == 0 ) )
            {
               BRKD216 = false;
               A716SerasaEnderecosId = P00D29_A716SerasaEnderecosId[0];
               AV38count = (long)(AV38count+1);
               BRKD216 = true;
               pr_default.readNext(7);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A724SerasaEnderecosTelDDD)) ? "<#Empty#>" : A724SerasaEnderecosTelDDD);
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
            if ( ! BRKD216 )
            {
               BRKD216 = true;
               pr_default.readNext(7);
            }
         }
         pr_default.close(7);
      }

      protected void S201( )
      {
         /* 'LOADSERASAENDERECOSTELOPTIONS' Routine */
         returnInSub = false;
         AV26TFSerasaEnderecosTel = AV28SearchTxt;
         AV27TFSerasaEnderecosTel_Sel = "";
         AV53Serasaenderecoswwds_1_serasaid = AV50SerasaId;
         AV54Serasaenderecoswwds_2_tfserasaenderecoscep = AV10TFSerasaEnderecosCEP;
         AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV11TFSerasaEnderecosCEP_Sel;
         AV56Serasaenderecoswwds_4_tfserasaenderecoslogr = AV12TFSerasaEnderecosLogr;
         AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV13TFSerasaEnderecosLogr_Sel;
         AV58Serasaenderecoswwds_6_tfserasaenderecosnum = AV14TFSerasaEnderecosNum;
         AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV15TFSerasaEnderecosNum_Sel;
         AV60Serasaenderecoswwds_8_tfserasaenderecoscompl = AV16TFSerasaEnderecosCompl;
         AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV17TFSerasaEnderecosCompl_Sel;
         AV62Serasaenderecoswwds_10_tfserasaenderecosbairro = AV18TFSerasaEnderecosBairro;
         AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV19TFSerasaEnderecosBairro_Sel;
         AV64Serasaenderecoswwds_12_tfserasaenderecoscidade = AV20TFSerasaEnderecosCidade;
         AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV21TFSerasaEnderecosCidade_Sel;
         AV66Serasaenderecoswwds_14_tfserasaenderecosestado = AV22TFSerasaEnderecosEstado;
         AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV23TFSerasaEnderecosEstado_Sel;
         AV68Serasaenderecoswwds_16_tfserasaenderecostelddd = AV24TFSerasaEnderecosTelDDD;
         AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV25TFSerasaEnderecosTelDDD_Sel;
         AV70Serasaenderecoswwds_18_tfserasaenderecostel = AV26TFSerasaEnderecosTel;
         AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV27TFSerasaEnderecosTel_Sel;
         pr_default.dynParam(8, new Object[]{ new Object[]{
                                              AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                              AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                              AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                              AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                              AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                              AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                              AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                              AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                              AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                              AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                              AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                              AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                              AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                              AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                              AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                              AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                              AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                              AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                              A723SerasaEnderecosCEP ,
                                              A717SerasaEnderecosLogr ,
                                              A718SerasaEnderecosNum ,
                                              A719SerasaEnderecosCompl ,
                                              A720SerasaEnderecosBairro ,
                                              A721SerasaEnderecosCidade ,
                                              A722SerasaEnderecosEstado ,
                                              A724SerasaEnderecosTelDDD ,
                                              A725SerasaEnderecosTel ,
                                              AV53Serasaenderecoswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Serasaenderecoswwds_2_tfserasaenderecoscep = StringUtil.Concat( StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep), "%", "");
         lV56Serasaenderecoswwds_4_tfserasaenderecoslogr = StringUtil.Concat( StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr), "%", "");
         lV58Serasaenderecoswwds_6_tfserasaenderecosnum = StringUtil.Concat( StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum), "%", "");
         lV60Serasaenderecoswwds_8_tfserasaenderecoscompl = StringUtil.Concat( StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl), "%", "");
         lV62Serasaenderecoswwds_10_tfserasaenderecosbairro = StringUtil.Concat( StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro), "%", "");
         lV64Serasaenderecoswwds_12_tfserasaenderecoscidade = StringUtil.Concat( StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade), "%", "");
         lV66Serasaenderecoswwds_14_tfserasaenderecosestado = StringUtil.Concat( StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado), "%", "");
         lV68Serasaenderecoswwds_16_tfserasaenderecostelddd = StringUtil.Concat( StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd), "%", "");
         lV70Serasaenderecoswwds_18_tfserasaenderecostel = StringUtil.Concat( StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel), "%", "");
         /* Using cursor P00D210 */
         pr_default.execute(8, new Object[] {AV53Serasaenderecoswwds_1_serasaid, lV54Serasaenderecoswwds_2_tfserasaenderecoscep, AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, lV56Serasaenderecoswwds_4_tfserasaenderecoslogr, AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, lV58Serasaenderecoswwds_6_tfserasaenderecosnum, AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, lV60Serasaenderecoswwds_8_tfserasaenderecoscompl, AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, lV62Serasaenderecoswwds_10_tfserasaenderecosbairro, AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, lV64Serasaenderecoswwds_12_tfserasaenderecoscidade, AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, lV66Serasaenderecoswwds_14_tfserasaenderecosestado, AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, lV68Serasaenderecoswwds_16_tfserasaenderecostelddd, AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, lV70Serasaenderecoswwds_18_tfserasaenderecostel, AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel});
         while ( (pr_default.getStatus(8) != 101) )
         {
            BRKD218 = false;
            A662SerasaId = P00D210_A662SerasaId[0];
            n662SerasaId = P00D210_n662SerasaId[0];
            A725SerasaEnderecosTel = P00D210_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = P00D210_n725SerasaEnderecosTel[0];
            A724SerasaEnderecosTelDDD = P00D210_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = P00D210_n724SerasaEnderecosTelDDD[0];
            A722SerasaEnderecosEstado = P00D210_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = P00D210_n722SerasaEnderecosEstado[0];
            A721SerasaEnderecosCidade = P00D210_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = P00D210_n721SerasaEnderecosCidade[0];
            A720SerasaEnderecosBairro = P00D210_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = P00D210_n720SerasaEnderecosBairro[0];
            A719SerasaEnderecosCompl = P00D210_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = P00D210_n719SerasaEnderecosCompl[0];
            A718SerasaEnderecosNum = P00D210_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = P00D210_n718SerasaEnderecosNum[0];
            A717SerasaEnderecosLogr = P00D210_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = P00D210_n717SerasaEnderecosLogr[0];
            A723SerasaEnderecosCEP = P00D210_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = P00D210_n723SerasaEnderecosCEP[0];
            A716SerasaEnderecosId = P00D210_A716SerasaEnderecosId[0];
            AV38count = 0;
            while ( (pr_default.getStatus(8) != 101) && ( P00D210_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D210_A725SerasaEnderecosTel[0], A725SerasaEnderecosTel) == 0 ) )
            {
               BRKD218 = false;
               A716SerasaEnderecosId = P00D210_A716SerasaEnderecosId[0];
               AV38count = (long)(AV38count+1);
               BRKD218 = true;
               pr_default.readNext(8);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A725SerasaEnderecosTel)) ? "<#Empty#>" : A725SerasaEnderecosTel);
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
            if ( ! BRKD218 )
            {
               BRKD218 = true;
               pr_default.readNext(8);
            }
         }
         pr_default.close(8);
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
         AV10TFSerasaEnderecosCEP = "";
         AV11TFSerasaEnderecosCEP_Sel = "";
         AV12TFSerasaEnderecosLogr = "";
         AV13TFSerasaEnderecosLogr_Sel = "";
         AV14TFSerasaEnderecosNum = "";
         AV15TFSerasaEnderecosNum_Sel = "";
         AV16TFSerasaEnderecosCompl = "";
         AV17TFSerasaEnderecosCompl_Sel = "";
         AV18TFSerasaEnderecosBairro = "";
         AV19TFSerasaEnderecosBairro_Sel = "";
         AV20TFSerasaEnderecosCidade = "";
         AV21TFSerasaEnderecosCidade_Sel = "";
         AV22TFSerasaEnderecosEstado = "";
         AV23TFSerasaEnderecosEstado_Sel = "";
         AV24TFSerasaEnderecosTelDDD = "";
         AV25TFSerasaEnderecosTelDDD_Sel = "";
         AV26TFSerasaEnderecosTel = "";
         AV27TFSerasaEnderecosTel_Sel = "";
         AV54Serasaenderecoswwds_2_tfserasaenderecoscep = "";
         AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel = "";
         AV56Serasaenderecoswwds_4_tfserasaenderecoslogr = "";
         AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = "";
         AV58Serasaenderecoswwds_6_tfserasaenderecosnum = "";
         AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel = "";
         AV60Serasaenderecoswwds_8_tfserasaenderecoscompl = "";
         AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = "";
         AV62Serasaenderecoswwds_10_tfserasaenderecosbairro = "";
         AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = "";
         AV64Serasaenderecoswwds_12_tfserasaenderecoscidade = "";
         AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = "";
         AV66Serasaenderecoswwds_14_tfserasaenderecosestado = "";
         AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel = "";
         AV68Serasaenderecoswwds_16_tfserasaenderecostelddd = "";
         AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = "";
         AV70Serasaenderecoswwds_18_tfserasaenderecostel = "";
         AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel = "";
         lV54Serasaenderecoswwds_2_tfserasaenderecoscep = "";
         lV56Serasaenderecoswwds_4_tfserasaenderecoslogr = "";
         lV58Serasaenderecoswwds_6_tfserasaenderecosnum = "";
         lV60Serasaenderecoswwds_8_tfserasaenderecoscompl = "";
         lV62Serasaenderecoswwds_10_tfserasaenderecosbairro = "";
         lV64Serasaenderecoswwds_12_tfserasaenderecoscidade = "";
         lV66Serasaenderecoswwds_14_tfserasaenderecosestado = "";
         lV68Serasaenderecoswwds_16_tfserasaenderecostelddd = "";
         lV70Serasaenderecoswwds_18_tfserasaenderecostel = "";
         A723SerasaEnderecosCEP = "";
         A717SerasaEnderecosLogr = "";
         A718SerasaEnderecosNum = "";
         A719SerasaEnderecosCompl = "";
         A720SerasaEnderecosBairro = "";
         A721SerasaEnderecosCidade = "";
         A722SerasaEnderecosEstado = "";
         A724SerasaEnderecosTelDDD = "";
         A725SerasaEnderecosTel = "";
         P00D22_A662SerasaId = new int[1] ;
         P00D22_n662SerasaId = new bool[] {false} ;
         P00D22_A723SerasaEnderecosCEP = new string[] {""} ;
         P00D22_n723SerasaEnderecosCEP = new bool[] {false} ;
         P00D22_A725SerasaEnderecosTel = new string[] {""} ;
         P00D22_n725SerasaEnderecosTel = new bool[] {false} ;
         P00D22_A724SerasaEnderecosTelDDD = new string[] {""} ;
         P00D22_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         P00D22_A722SerasaEnderecosEstado = new string[] {""} ;
         P00D22_n722SerasaEnderecosEstado = new bool[] {false} ;
         P00D22_A721SerasaEnderecosCidade = new string[] {""} ;
         P00D22_n721SerasaEnderecosCidade = new bool[] {false} ;
         P00D22_A720SerasaEnderecosBairro = new string[] {""} ;
         P00D22_n720SerasaEnderecosBairro = new bool[] {false} ;
         P00D22_A719SerasaEnderecosCompl = new string[] {""} ;
         P00D22_n719SerasaEnderecosCompl = new bool[] {false} ;
         P00D22_A718SerasaEnderecosNum = new string[] {""} ;
         P00D22_n718SerasaEnderecosNum = new bool[] {false} ;
         P00D22_A717SerasaEnderecosLogr = new string[] {""} ;
         P00D22_n717SerasaEnderecosLogr = new bool[] {false} ;
         P00D22_A716SerasaEnderecosId = new int[1] ;
         AV33Option = "";
         P00D23_A662SerasaId = new int[1] ;
         P00D23_n662SerasaId = new bool[] {false} ;
         P00D23_A717SerasaEnderecosLogr = new string[] {""} ;
         P00D23_n717SerasaEnderecosLogr = new bool[] {false} ;
         P00D23_A725SerasaEnderecosTel = new string[] {""} ;
         P00D23_n725SerasaEnderecosTel = new bool[] {false} ;
         P00D23_A724SerasaEnderecosTelDDD = new string[] {""} ;
         P00D23_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         P00D23_A722SerasaEnderecosEstado = new string[] {""} ;
         P00D23_n722SerasaEnderecosEstado = new bool[] {false} ;
         P00D23_A721SerasaEnderecosCidade = new string[] {""} ;
         P00D23_n721SerasaEnderecosCidade = new bool[] {false} ;
         P00D23_A720SerasaEnderecosBairro = new string[] {""} ;
         P00D23_n720SerasaEnderecosBairro = new bool[] {false} ;
         P00D23_A719SerasaEnderecosCompl = new string[] {""} ;
         P00D23_n719SerasaEnderecosCompl = new bool[] {false} ;
         P00D23_A718SerasaEnderecosNum = new string[] {""} ;
         P00D23_n718SerasaEnderecosNum = new bool[] {false} ;
         P00D23_A723SerasaEnderecosCEP = new string[] {""} ;
         P00D23_n723SerasaEnderecosCEP = new bool[] {false} ;
         P00D23_A716SerasaEnderecosId = new int[1] ;
         P00D24_A662SerasaId = new int[1] ;
         P00D24_n662SerasaId = new bool[] {false} ;
         P00D24_A718SerasaEnderecosNum = new string[] {""} ;
         P00D24_n718SerasaEnderecosNum = new bool[] {false} ;
         P00D24_A725SerasaEnderecosTel = new string[] {""} ;
         P00D24_n725SerasaEnderecosTel = new bool[] {false} ;
         P00D24_A724SerasaEnderecosTelDDD = new string[] {""} ;
         P00D24_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         P00D24_A722SerasaEnderecosEstado = new string[] {""} ;
         P00D24_n722SerasaEnderecosEstado = new bool[] {false} ;
         P00D24_A721SerasaEnderecosCidade = new string[] {""} ;
         P00D24_n721SerasaEnderecosCidade = new bool[] {false} ;
         P00D24_A720SerasaEnderecosBairro = new string[] {""} ;
         P00D24_n720SerasaEnderecosBairro = new bool[] {false} ;
         P00D24_A719SerasaEnderecosCompl = new string[] {""} ;
         P00D24_n719SerasaEnderecosCompl = new bool[] {false} ;
         P00D24_A717SerasaEnderecosLogr = new string[] {""} ;
         P00D24_n717SerasaEnderecosLogr = new bool[] {false} ;
         P00D24_A723SerasaEnderecosCEP = new string[] {""} ;
         P00D24_n723SerasaEnderecosCEP = new bool[] {false} ;
         P00D24_A716SerasaEnderecosId = new int[1] ;
         P00D25_A662SerasaId = new int[1] ;
         P00D25_n662SerasaId = new bool[] {false} ;
         P00D25_A719SerasaEnderecosCompl = new string[] {""} ;
         P00D25_n719SerasaEnderecosCompl = new bool[] {false} ;
         P00D25_A725SerasaEnderecosTel = new string[] {""} ;
         P00D25_n725SerasaEnderecosTel = new bool[] {false} ;
         P00D25_A724SerasaEnderecosTelDDD = new string[] {""} ;
         P00D25_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         P00D25_A722SerasaEnderecosEstado = new string[] {""} ;
         P00D25_n722SerasaEnderecosEstado = new bool[] {false} ;
         P00D25_A721SerasaEnderecosCidade = new string[] {""} ;
         P00D25_n721SerasaEnderecosCidade = new bool[] {false} ;
         P00D25_A720SerasaEnderecosBairro = new string[] {""} ;
         P00D25_n720SerasaEnderecosBairro = new bool[] {false} ;
         P00D25_A718SerasaEnderecosNum = new string[] {""} ;
         P00D25_n718SerasaEnderecosNum = new bool[] {false} ;
         P00D25_A717SerasaEnderecosLogr = new string[] {""} ;
         P00D25_n717SerasaEnderecosLogr = new bool[] {false} ;
         P00D25_A723SerasaEnderecosCEP = new string[] {""} ;
         P00D25_n723SerasaEnderecosCEP = new bool[] {false} ;
         P00D25_A716SerasaEnderecosId = new int[1] ;
         P00D26_A662SerasaId = new int[1] ;
         P00D26_n662SerasaId = new bool[] {false} ;
         P00D26_A720SerasaEnderecosBairro = new string[] {""} ;
         P00D26_n720SerasaEnderecosBairro = new bool[] {false} ;
         P00D26_A725SerasaEnderecosTel = new string[] {""} ;
         P00D26_n725SerasaEnderecosTel = new bool[] {false} ;
         P00D26_A724SerasaEnderecosTelDDD = new string[] {""} ;
         P00D26_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         P00D26_A722SerasaEnderecosEstado = new string[] {""} ;
         P00D26_n722SerasaEnderecosEstado = new bool[] {false} ;
         P00D26_A721SerasaEnderecosCidade = new string[] {""} ;
         P00D26_n721SerasaEnderecosCidade = new bool[] {false} ;
         P00D26_A719SerasaEnderecosCompl = new string[] {""} ;
         P00D26_n719SerasaEnderecosCompl = new bool[] {false} ;
         P00D26_A718SerasaEnderecosNum = new string[] {""} ;
         P00D26_n718SerasaEnderecosNum = new bool[] {false} ;
         P00D26_A717SerasaEnderecosLogr = new string[] {""} ;
         P00D26_n717SerasaEnderecosLogr = new bool[] {false} ;
         P00D26_A723SerasaEnderecosCEP = new string[] {""} ;
         P00D26_n723SerasaEnderecosCEP = new bool[] {false} ;
         P00D26_A716SerasaEnderecosId = new int[1] ;
         P00D27_A662SerasaId = new int[1] ;
         P00D27_n662SerasaId = new bool[] {false} ;
         P00D27_A721SerasaEnderecosCidade = new string[] {""} ;
         P00D27_n721SerasaEnderecosCidade = new bool[] {false} ;
         P00D27_A725SerasaEnderecosTel = new string[] {""} ;
         P00D27_n725SerasaEnderecosTel = new bool[] {false} ;
         P00D27_A724SerasaEnderecosTelDDD = new string[] {""} ;
         P00D27_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         P00D27_A722SerasaEnderecosEstado = new string[] {""} ;
         P00D27_n722SerasaEnderecosEstado = new bool[] {false} ;
         P00D27_A720SerasaEnderecosBairro = new string[] {""} ;
         P00D27_n720SerasaEnderecosBairro = new bool[] {false} ;
         P00D27_A719SerasaEnderecosCompl = new string[] {""} ;
         P00D27_n719SerasaEnderecosCompl = new bool[] {false} ;
         P00D27_A718SerasaEnderecosNum = new string[] {""} ;
         P00D27_n718SerasaEnderecosNum = new bool[] {false} ;
         P00D27_A717SerasaEnderecosLogr = new string[] {""} ;
         P00D27_n717SerasaEnderecosLogr = new bool[] {false} ;
         P00D27_A723SerasaEnderecosCEP = new string[] {""} ;
         P00D27_n723SerasaEnderecosCEP = new bool[] {false} ;
         P00D27_A716SerasaEnderecosId = new int[1] ;
         P00D28_A662SerasaId = new int[1] ;
         P00D28_n662SerasaId = new bool[] {false} ;
         P00D28_A722SerasaEnderecosEstado = new string[] {""} ;
         P00D28_n722SerasaEnderecosEstado = new bool[] {false} ;
         P00D28_A725SerasaEnderecosTel = new string[] {""} ;
         P00D28_n725SerasaEnderecosTel = new bool[] {false} ;
         P00D28_A724SerasaEnderecosTelDDD = new string[] {""} ;
         P00D28_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         P00D28_A721SerasaEnderecosCidade = new string[] {""} ;
         P00D28_n721SerasaEnderecosCidade = new bool[] {false} ;
         P00D28_A720SerasaEnderecosBairro = new string[] {""} ;
         P00D28_n720SerasaEnderecosBairro = new bool[] {false} ;
         P00D28_A719SerasaEnderecosCompl = new string[] {""} ;
         P00D28_n719SerasaEnderecosCompl = new bool[] {false} ;
         P00D28_A718SerasaEnderecosNum = new string[] {""} ;
         P00D28_n718SerasaEnderecosNum = new bool[] {false} ;
         P00D28_A717SerasaEnderecosLogr = new string[] {""} ;
         P00D28_n717SerasaEnderecosLogr = new bool[] {false} ;
         P00D28_A723SerasaEnderecosCEP = new string[] {""} ;
         P00D28_n723SerasaEnderecosCEP = new bool[] {false} ;
         P00D28_A716SerasaEnderecosId = new int[1] ;
         P00D29_A662SerasaId = new int[1] ;
         P00D29_n662SerasaId = new bool[] {false} ;
         P00D29_A724SerasaEnderecosTelDDD = new string[] {""} ;
         P00D29_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         P00D29_A725SerasaEnderecosTel = new string[] {""} ;
         P00D29_n725SerasaEnderecosTel = new bool[] {false} ;
         P00D29_A722SerasaEnderecosEstado = new string[] {""} ;
         P00D29_n722SerasaEnderecosEstado = new bool[] {false} ;
         P00D29_A721SerasaEnderecosCidade = new string[] {""} ;
         P00D29_n721SerasaEnderecosCidade = new bool[] {false} ;
         P00D29_A720SerasaEnderecosBairro = new string[] {""} ;
         P00D29_n720SerasaEnderecosBairro = new bool[] {false} ;
         P00D29_A719SerasaEnderecosCompl = new string[] {""} ;
         P00D29_n719SerasaEnderecosCompl = new bool[] {false} ;
         P00D29_A718SerasaEnderecosNum = new string[] {""} ;
         P00D29_n718SerasaEnderecosNum = new bool[] {false} ;
         P00D29_A717SerasaEnderecosLogr = new string[] {""} ;
         P00D29_n717SerasaEnderecosLogr = new bool[] {false} ;
         P00D29_A723SerasaEnderecosCEP = new string[] {""} ;
         P00D29_n723SerasaEnderecosCEP = new bool[] {false} ;
         P00D29_A716SerasaEnderecosId = new int[1] ;
         P00D210_A662SerasaId = new int[1] ;
         P00D210_n662SerasaId = new bool[] {false} ;
         P00D210_A725SerasaEnderecosTel = new string[] {""} ;
         P00D210_n725SerasaEnderecosTel = new bool[] {false} ;
         P00D210_A724SerasaEnderecosTelDDD = new string[] {""} ;
         P00D210_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         P00D210_A722SerasaEnderecosEstado = new string[] {""} ;
         P00D210_n722SerasaEnderecosEstado = new bool[] {false} ;
         P00D210_A721SerasaEnderecosCidade = new string[] {""} ;
         P00D210_n721SerasaEnderecosCidade = new bool[] {false} ;
         P00D210_A720SerasaEnderecosBairro = new string[] {""} ;
         P00D210_n720SerasaEnderecosBairro = new bool[] {false} ;
         P00D210_A719SerasaEnderecosCompl = new string[] {""} ;
         P00D210_n719SerasaEnderecosCompl = new bool[] {false} ;
         P00D210_A718SerasaEnderecosNum = new string[] {""} ;
         P00D210_n718SerasaEnderecosNum = new bool[] {false} ;
         P00D210_A717SerasaEnderecosLogr = new string[] {""} ;
         P00D210_n717SerasaEnderecosLogr = new bool[] {false} ;
         P00D210_A723SerasaEnderecosCEP = new string[] {""} ;
         P00D210_n723SerasaEnderecosCEP = new bool[] {false} ;
         P00D210_A716SerasaEnderecosId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaenderecoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00D22_A662SerasaId, P00D22_n662SerasaId, P00D22_A723SerasaEnderecosCEP, P00D22_n723SerasaEnderecosCEP, P00D22_A725SerasaEnderecosTel, P00D22_n725SerasaEnderecosTel, P00D22_A724SerasaEnderecosTelDDD, P00D22_n724SerasaEnderecosTelDDD, P00D22_A722SerasaEnderecosEstado, P00D22_n722SerasaEnderecosEstado,
               P00D22_A721SerasaEnderecosCidade, P00D22_n721SerasaEnderecosCidade, P00D22_A720SerasaEnderecosBairro, P00D22_n720SerasaEnderecosBairro, P00D22_A719SerasaEnderecosCompl, P00D22_n719SerasaEnderecosCompl, P00D22_A718SerasaEnderecosNum, P00D22_n718SerasaEnderecosNum, P00D22_A717SerasaEnderecosLogr, P00D22_n717SerasaEnderecosLogr,
               P00D22_A716SerasaEnderecosId
               }
               , new Object[] {
               P00D23_A662SerasaId, P00D23_n662SerasaId, P00D23_A717SerasaEnderecosLogr, P00D23_n717SerasaEnderecosLogr, P00D23_A725SerasaEnderecosTel, P00D23_n725SerasaEnderecosTel, P00D23_A724SerasaEnderecosTelDDD, P00D23_n724SerasaEnderecosTelDDD, P00D23_A722SerasaEnderecosEstado, P00D23_n722SerasaEnderecosEstado,
               P00D23_A721SerasaEnderecosCidade, P00D23_n721SerasaEnderecosCidade, P00D23_A720SerasaEnderecosBairro, P00D23_n720SerasaEnderecosBairro, P00D23_A719SerasaEnderecosCompl, P00D23_n719SerasaEnderecosCompl, P00D23_A718SerasaEnderecosNum, P00D23_n718SerasaEnderecosNum, P00D23_A723SerasaEnderecosCEP, P00D23_n723SerasaEnderecosCEP,
               P00D23_A716SerasaEnderecosId
               }
               , new Object[] {
               P00D24_A662SerasaId, P00D24_n662SerasaId, P00D24_A718SerasaEnderecosNum, P00D24_n718SerasaEnderecosNum, P00D24_A725SerasaEnderecosTel, P00D24_n725SerasaEnderecosTel, P00D24_A724SerasaEnderecosTelDDD, P00D24_n724SerasaEnderecosTelDDD, P00D24_A722SerasaEnderecosEstado, P00D24_n722SerasaEnderecosEstado,
               P00D24_A721SerasaEnderecosCidade, P00D24_n721SerasaEnderecosCidade, P00D24_A720SerasaEnderecosBairro, P00D24_n720SerasaEnderecosBairro, P00D24_A719SerasaEnderecosCompl, P00D24_n719SerasaEnderecosCompl, P00D24_A717SerasaEnderecosLogr, P00D24_n717SerasaEnderecosLogr, P00D24_A723SerasaEnderecosCEP, P00D24_n723SerasaEnderecosCEP,
               P00D24_A716SerasaEnderecosId
               }
               , new Object[] {
               P00D25_A662SerasaId, P00D25_n662SerasaId, P00D25_A719SerasaEnderecosCompl, P00D25_n719SerasaEnderecosCompl, P00D25_A725SerasaEnderecosTel, P00D25_n725SerasaEnderecosTel, P00D25_A724SerasaEnderecosTelDDD, P00D25_n724SerasaEnderecosTelDDD, P00D25_A722SerasaEnderecosEstado, P00D25_n722SerasaEnderecosEstado,
               P00D25_A721SerasaEnderecosCidade, P00D25_n721SerasaEnderecosCidade, P00D25_A720SerasaEnderecosBairro, P00D25_n720SerasaEnderecosBairro, P00D25_A718SerasaEnderecosNum, P00D25_n718SerasaEnderecosNum, P00D25_A717SerasaEnderecosLogr, P00D25_n717SerasaEnderecosLogr, P00D25_A723SerasaEnderecosCEP, P00D25_n723SerasaEnderecosCEP,
               P00D25_A716SerasaEnderecosId
               }
               , new Object[] {
               P00D26_A662SerasaId, P00D26_n662SerasaId, P00D26_A720SerasaEnderecosBairro, P00D26_n720SerasaEnderecosBairro, P00D26_A725SerasaEnderecosTel, P00D26_n725SerasaEnderecosTel, P00D26_A724SerasaEnderecosTelDDD, P00D26_n724SerasaEnderecosTelDDD, P00D26_A722SerasaEnderecosEstado, P00D26_n722SerasaEnderecosEstado,
               P00D26_A721SerasaEnderecosCidade, P00D26_n721SerasaEnderecosCidade, P00D26_A719SerasaEnderecosCompl, P00D26_n719SerasaEnderecosCompl, P00D26_A718SerasaEnderecosNum, P00D26_n718SerasaEnderecosNum, P00D26_A717SerasaEnderecosLogr, P00D26_n717SerasaEnderecosLogr, P00D26_A723SerasaEnderecosCEP, P00D26_n723SerasaEnderecosCEP,
               P00D26_A716SerasaEnderecosId
               }
               , new Object[] {
               P00D27_A662SerasaId, P00D27_n662SerasaId, P00D27_A721SerasaEnderecosCidade, P00D27_n721SerasaEnderecosCidade, P00D27_A725SerasaEnderecosTel, P00D27_n725SerasaEnderecosTel, P00D27_A724SerasaEnderecosTelDDD, P00D27_n724SerasaEnderecosTelDDD, P00D27_A722SerasaEnderecosEstado, P00D27_n722SerasaEnderecosEstado,
               P00D27_A720SerasaEnderecosBairro, P00D27_n720SerasaEnderecosBairro, P00D27_A719SerasaEnderecosCompl, P00D27_n719SerasaEnderecosCompl, P00D27_A718SerasaEnderecosNum, P00D27_n718SerasaEnderecosNum, P00D27_A717SerasaEnderecosLogr, P00D27_n717SerasaEnderecosLogr, P00D27_A723SerasaEnderecosCEP, P00D27_n723SerasaEnderecosCEP,
               P00D27_A716SerasaEnderecosId
               }
               , new Object[] {
               P00D28_A662SerasaId, P00D28_n662SerasaId, P00D28_A722SerasaEnderecosEstado, P00D28_n722SerasaEnderecosEstado, P00D28_A725SerasaEnderecosTel, P00D28_n725SerasaEnderecosTel, P00D28_A724SerasaEnderecosTelDDD, P00D28_n724SerasaEnderecosTelDDD, P00D28_A721SerasaEnderecosCidade, P00D28_n721SerasaEnderecosCidade,
               P00D28_A720SerasaEnderecosBairro, P00D28_n720SerasaEnderecosBairro, P00D28_A719SerasaEnderecosCompl, P00D28_n719SerasaEnderecosCompl, P00D28_A718SerasaEnderecosNum, P00D28_n718SerasaEnderecosNum, P00D28_A717SerasaEnderecosLogr, P00D28_n717SerasaEnderecosLogr, P00D28_A723SerasaEnderecosCEP, P00D28_n723SerasaEnderecosCEP,
               P00D28_A716SerasaEnderecosId
               }
               , new Object[] {
               P00D29_A662SerasaId, P00D29_n662SerasaId, P00D29_A724SerasaEnderecosTelDDD, P00D29_n724SerasaEnderecosTelDDD, P00D29_A725SerasaEnderecosTel, P00D29_n725SerasaEnderecosTel, P00D29_A722SerasaEnderecosEstado, P00D29_n722SerasaEnderecosEstado, P00D29_A721SerasaEnderecosCidade, P00D29_n721SerasaEnderecosCidade,
               P00D29_A720SerasaEnderecosBairro, P00D29_n720SerasaEnderecosBairro, P00D29_A719SerasaEnderecosCompl, P00D29_n719SerasaEnderecosCompl, P00D29_A718SerasaEnderecosNum, P00D29_n718SerasaEnderecosNum, P00D29_A717SerasaEnderecosLogr, P00D29_n717SerasaEnderecosLogr, P00D29_A723SerasaEnderecosCEP, P00D29_n723SerasaEnderecosCEP,
               P00D29_A716SerasaEnderecosId
               }
               , new Object[] {
               P00D210_A662SerasaId, P00D210_n662SerasaId, P00D210_A725SerasaEnderecosTel, P00D210_n725SerasaEnderecosTel, P00D210_A724SerasaEnderecosTelDDD, P00D210_n724SerasaEnderecosTelDDD, P00D210_A722SerasaEnderecosEstado, P00D210_n722SerasaEnderecosEstado, P00D210_A721SerasaEnderecosCidade, P00D210_n721SerasaEnderecosCidade,
               P00D210_A720SerasaEnderecosBairro, P00D210_n720SerasaEnderecosBairro, P00D210_A719SerasaEnderecosCompl, P00D210_n719SerasaEnderecosCompl, P00D210_A718SerasaEnderecosNum, P00D210_n718SerasaEnderecosNum, P00D210_A717SerasaEnderecosLogr, P00D210_n717SerasaEnderecosLogr, P00D210_A723SerasaEnderecosCEP, P00D210_n723SerasaEnderecosCEP,
               P00D210_A716SerasaEnderecosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV31MaxItems ;
      private short AV30PageIndex ;
      private short AV29SkipItems ;
      private int AV51GXV1 ;
      private int AV50SerasaId ;
      private int AV53Serasaenderecoswwds_1_serasaid ;
      private int A662SerasaId ;
      private int A716SerasaEnderecosId ;
      private long AV38count ;
      private bool returnInSub ;
      private bool BRKD22 ;
      private bool n662SerasaId ;
      private bool n723SerasaEnderecosCEP ;
      private bool n725SerasaEnderecosTel ;
      private bool n724SerasaEnderecosTelDDD ;
      private bool n722SerasaEnderecosEstado ;
      private bool n721SerasaEnderecosCidade ;
      private bool n720SerasaEnderecosBairro ;
      private bool n719SerasaEnderecosCompl ;
      private bool n718SerasaEnderecosNum ;
      private bool n717SerasaEnderecosLogr ;
      private bool BRKD24 ;
      private bool BRKD26 ;
      private bool BRKD28 ;
      private bool BRKD210 ;
      private bool BRKD212 ;
      private bool BRKD214 ;
      private bool BRKD216 ;
      private bool BRKD218 ;
      private string AV47OptionsJson ;
      private string AV48OptionsDescJson ;
      private string AV49OptionIndexesJson ;
      private string AV44DDOName ;
      private string AV45SearchTxtParms ;
      private string AV46SearchTxtTo ;
      private string AV28SearchTxt ;
      private string AV10TFSerasaEnderecosCEP ;
      private string AV11TFSerasaEnderecosCEP_Sel ;
      private string AV12TFSerasaEnderecosLogr ;
      private string AV13TFSerasaEnderecosLogr_Sel ;
      private string AV14TFSerasaEnderecosNum ;
      private string AV15TFSerasaEnderecosNum_Sel ;
      private string AV16TFSerasaEnderecosCompl ;
      private string AV17TFSerasaEnderecosCompl_Sel ;
      private string AV18TFSerasaEnderecosBairro ;
      private string AV19TFSerasaEnderecosBairro_Sel ;
      private string AV20TFSerasaEnderecosCidade ;
      private string AV21TFSerasaEnderecosCidade_Sel ;
      private string AV22TFSerasaEnderecosEstado ;
      private string AV23TFSerasaEnderecosEstado_Sel ;
      private string AV24TFSerasaEnderecosTelDDD ;
      private string AV25TFSerasaEnderecosTelDDD_Sel ;
      private string AV26TFSerasaEnderecosTel ;
      private string AV27TFSerasaEnderecosTel_Sel ;
      private string AV54Serasaenderecoswwds_2_tfserasaenderecoscep ;
      private string AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ;
      private string AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ;
      private string AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ;
      private string AV58Serasaenderecoswwds_6_tfserasaenderecosnum ;
      private string AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ;
      private string AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ;
      private string AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ;
      private string AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ;
      private string AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ;
      private string AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ;
      private string AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ;
      private string AV66Serasaenderecoswwds_14_tfserasaenderecosestado ;
      private string AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ;
      private string AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ;
      private string AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ;
      private string AV70Serasaenderecoswwds_18_tfserasaenderecostel ;
      private string AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ;
      private string lV54Serasaenderecoswwds_2_tfserasaenderecoscep ;
      private string lV56Serasaenderecoswwds_4_tfserasaenderecoslogr ;
      private string lV58Serasaenderecoswwds_6_tfserasaenderecosnum ;
      private string lV60Serasaenderecoswwds_8_tfserasaenderecoscompl ;
      private string lV62Serasaenderecoswwds_10_tfserasaenderecosbairro ;
      private string lV64Serasaenderecoswwds_12_tfserasaenderecoscidade ;
      private string lV66Serasaenderecoswwds_14_tfserasaenderecosestado ;
      private string lV68Serasaenderecoswwds_16_tfserasaenderecostelddd ;
      private string lV70Serasaenderecoswwds_18_tfserasaenderecostel ;
      private string A723SerasaEnderecosCEP ;
      private string A717SerasaEnderecosLogr ;
      private string A718SerasaEnderecosNum ;
      private string A719SerasaEnderecosCompl ;
      private string A720SerasaEnderecosBairro ;
      private string A721SerasaEnderecosCidade ;
      private string A722SerasaEnderecosEstado ;
      private string A724SerasaEnderecosTelDDD ;
      private string A725SerasaEnderecosTel ;
      private string AV33Option ;
      private IGxSession AV39Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV34Options ;
      private GxSimpleCollection<string> AV36OptionsDesc ;
      private GxSimpleCollection<string> AV37OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private int[] P00D22_A662SerasaId ;
      private bool[] P00D22_n662SerasaId ;
      private string[] P00D22_A723SerasaEnderecosCEP ;
      private bool[] P00D22_n723SerasaEnderecosCEP ;
      private string[] P00D22_A725SerasaEnderecosTel ;
      private bool[] P00D22_n725SerasaEnderecosTel ;
      private string[] P00D22_A724SerasaEnderecosTelDDD ;
      private bool[] P00D22_n724SerasaEnderecosTelDDD ;
      private string[] P00D22_A722SerasaEnderecosEstado ;
      private bool[] P00D22_n722SerasaEnderecosEstado ;
      private string[] P00D22_A721SerasaEnderecosCidade ;
      private bool[] P00D22_n721SerasaEnderecosCidade ;
      private string[] P00D22_A720SerasaEnderecosBairro ;
      private bool[] P00D22_n720SerasaEnderecosBairro ;
      private string[] P00D22_A719SerasaEnderecosCompl ;
      private bool[] P00D22_n719SerasaEnderecosCompl ;
      private string[] P00D22_A718SerasaEnderecosNum ;
      private bool[] P00D22_n718SerasaEnderecosNum ;
      private string[] P00D22_A717SerasaEnderecosLogr ;
      private bool[] P00D22_n717SerasaEnderecosLogr ;
      private int[] P00D22_A716SerasaEnderecosId ;
      private int[] P00D23_A662SerasaId ;
      private bool[] P00D23_n662SerasaId ;
      private string[] P00D23_A717SerasaEnderecosLogr ;
      private bool[] P00D23_n717SerasaEnderecosLogr ;
      private string[] P00D23_A725SerasaEnderecosTel ;
      private bool[] P00D23_n725SerasaEnderecosTel ;
      private string[] P00D23_A724SerasaEnderecosTelDDD ;
      private bool[] P00D23_n724SerasaEnderecosTelDDD ;
      private string[] P00D23_A722SerasaEnderecosEstado ;
      private bool[] P00D23_n722SerasaEnderecosEstado ;
      private string[] P00D23_A721SerasaEnderecosCidade ;
      private bool[] P00D23_n721SerasaEnderecosCidade ;
      private string[] P00D23_A720SerasaEnderecosBairro ;
      private bool[] P00D23_n720SerasaEnderecosBairro ;
      private string[] P00D23_A719SerasaEnderecosCompl ;
      private bool[] P00D23_n719SerasaEnderecosCompl ;
      private string[] P00D23_A718SerasaEnderecosNum ;
      private bool[] P00D23_n718SerasaEnderecosNum ;
      private string[] P00D23_A723SerasaEnderecosCEP ;
      private bool[] P00D23_n723SerasaEnderecosCEP ;
      private int[] P00D23_A716SerasaEnderecosId ;
      private int[] P00D24_A662SerasaId ;
      private bool[] P00D24_n662SerasaId ;
      private string[] P00D24_A718SerasaEnderecosNum ;
      private bool[] P00D24_n718SerasaEnderecosNum ;
      private string[] P00D24_A725SerasaEnderecosTel ;
      private bool[] P00D24_n725SerasaEnderecosTel ;
      private string[] P00D24_A724SerasaEnderecosTelDDD ;
      private bool[] P00D24_n724SerasaEnderecosTelDDD ;
      private string[] P00D24_A722SerasaEnderecosEstado ;
      private bool[] P00D24_n722SerasaEnderecosEstado ;
      private string[] P00D24_A721SerasaEnderecosCidade ;
      private bool[] P00D24_n721SerasaEnderecosCidade ;
      private string[] P00D24_A720SerasaEnderecosBairro ;
      private bool[] P00D24_n720SerasaEnderecosBairro ;
      private string[] P00D24_A719SerasaEnderecosCompl ;
      private bool[] P00D24_n719SerasaEnderecosCompl ;
      private string[] P00D24_A717SerasaEnderecosLogr ;
      private bool[] P00D24_n717SerasaEnderecosLogr ;
      private string[] P00D24_A723SerasaEnderecosCEP ;
      private bool[] P00D24_n723SerasaEnderecosCEP ;
      private int[] P00D24_A716SerasaEnderecosId ;
      private int[] P00D25_A662SerasaId ;
      private bool[] P00D25_n662SerasaId ;
      private string[] P00D25_A719SerasaEnderecosCompl ;
      private bool[] P00D25_n719SerasaEnderecosCompl ;
      private string[] P00D25_A725SerasaEnderecosTel ;
      private bool[] P00D25_n725SerasaEnderecosTel ;
      private string[] P00D25_A724SerasaEnderecosTelDDD ;
      private bool[] P00D25_n724SerasaEnderecosTelDDD ;
      private string[] P00D25_A722SerasaEnderecosEstado ;
      private bool[] P00D25_n722SerasaEnderecosEstado ;
      private string[] P00D25_A721SerasaEnderecosCidade ;
      private bool[] P00D25_n721SerasaEnderecosCidade ;
      private string[] P00D25_A720SerasaEnderecosBairro ;
      private bool[] P00D25_n720SerasaEnderecosBairro ;
      private string[] P00D25_A718SerasaEnderecosNum ;
      private bool[] P00D25_n718SerasaEnderecosNum ;
      private string[] P00D25_A717SerasaEnderecosLogr ;
      private bool[] P00D25_n717SerasaEnderecosLogr ;
      private string[] P00D25_A723SerasaEnderecosCEP ;
      private bool[] P00D25_n723SerasaEnderecosCEP ;
      private int[] P00D25_A716SerasaEnderecosId ;
      private int[] P00D26_A662SerasaId ;
      private bool[] P00D26_n662SerasaId ;
      private string[] P00D26_A720SerasaEnderecosBairro ;
      private bool[] P00D26_n720SerasaEnderecosBairro ;
      private string[] P00D26_A725SerasaEnderecosTel ;
      private bool[] P00D26_n725SerasaEnderecosTel ;
      private string[] P00D26_A724SerasaEnderecosTelDDD ;
      private bool[] P00D26_n724SerasaEnderecosTelDDD ;
      private string[] P00D26_A722SerasaEnderecosEstado ;
      private bool[] P00D26_n722SerasaEnderecosEstado ;
      private string[] P00D26_A721SerasaEnderecosCidade ;
      private bool[] P00D26_n721SerasaEnderecosCidade ;
      private string[] P00D26_A719SerasaEnderecosCompl ;
      private bool[] P00D26_n719SerasaEnderecosCompl ;
      private string[] P00D26_A718SerasaEnderecosNum ;
      private bool[] P00D26_n718SerasaEnderecosNum ;
      private string[] P00D26_A717SerasaEnderecosLogr ;
      private bool[] P00D26_n717SerasaEnderecosLogr ;
      private string[] P00D26_A723SerasaEnderecosCEP ;
      private bool[] P00D26_n723SerasaEnderecosCEP ;
      private int[] P00D26_A716SerasaEnderecosId ;
      private int[] P00D27_A662SerasaId ;
      private bool[] P00D27_n662SerasaId ;
      private string[] P00D27_A721SerasaEnderecosCidade ;
      private bool[] P00D27_n721SerasaEnderecosCidade ;
      private string[] P00D27_A725SerasaEnderecosTel ;
      private bool[] P00D27_n725SerasaEnderecosTel ;
      private string[] P00D27_A724SerasaEnderecosTelDDD ;
      private bool[] P00D27_n724SerasaEnderecosTelDDD ;
      private string[] P00D27_A722SerasaEnderecosEstado ;
      private bool[] P00D27_n722SerasaEnderecosEstado ;
      private string[] P00D27_A720SerasaEnderecosBairro ;
      private bool[] P00D27_n720SerasaEnderecosBairro ;
      private string[] P00D27_A719SerasaEnderecosCompl ;
      private bool[] P00D27_n719SerasaEnderecosCompl ;
      private string[] P00D27_A718SerasaEnderecosNum ;
      private bool[] P00D27_n718SerasaEnderecosNum ;
      private string[] P00D27_A717SerasaEnderecosLogr ;
      private bool[] P00D27_n717SerasaEnderecosLogr ;
      private string[] P00D27_A723SerasaEnderecosCEP ;
      private bool[] P00D27_n723SerasaEnderecosCEP ;
      private int[] P00D27_A716SerasaEnderecosId ;
      private int[] P00D28_A662SerasaId ;
      private bool[] P00D28_n662SerasaId ;
      private string[] P00D28_A722SerasaEnderecosEstado ;
      private bool[] P00D28_n722SerasaEnderecosEstado ;
      private string[] P00D28_A725SerasaEnderecosTel ;
      private bool[] P00D28_n725SerasaEnderecosTel ;
      private string[] P00D28_A724SerasaEnderecosTelDDD ;
      private bool[] P00D28_n724SerasaEnderecosTelDDD ;
      private string[] P00D28_A721SerasaEnderecosCidade ;
      private bool[] P00D28_n721SerasaEnderecosCidade ;
      private string[] P00D28_A720SerasaEnderecosBairro ;
      private bool[] P00D28_n720SerasaEnderecosBairro ;
      private string[] P00D28_A719SerasaEnderecosCompl ;
      private bool[] P00D28_n719SerasaEnderecosCompl ;
      private string[] P00D28_A718SerasaEnderecosNum ;
      private bool[] P00D28_n718SerasaEnderecosNum ;
      private string[] P00D28_A717SerasaEnderecosLogr ;
      private bool[] P00D28_n717SerasaEnderecosLogr ;
      private string[] P00D28_A723SerasaEnderecosCEP ;
      private bool[] P00D28_n723SerasaEnderecosCEP ;
      private int[] P00D28_A716SerasaEnderecosId ;
      private int[] P00D29_A662SerasaId ;
      private bool[] P00D29_n662SerasaId ;
      private string[] P00D29_A724SerasaEnderecosTelDDD ;
      private bool[] P00D29_n724SerasaEnderecosTelDDD ;
      private string[] P00D29_A725SerasaEnderecosTel ;
      private bool[] P00D29_n725SerasaEnderecosTel ;
      private string[] P00D29_A722SerasaEnderecosEstado ;
      private bool[] P00D29_n722SerasaEnderecosEstado ;
      private string[] P00D29_A721SerasaEnderecosCidade ;
      private bool[] P00D29_n721SerasaEnderecosCidade ;
      private string[] P00D29_A720SerasaEnderecosBairro ;
      private bool[] P00D29_n720SerasaEnderecosBairro ;
      private string[] P00D29_A719SerasaEnderecosCompl ;
      private bool[] P00D29_n719SerasaEnderecosCompl ;
      private string[] P00D29_A718SerasaEnderecosNum ;
      private bool[] P00D29_n718SerasaEnderecosNum ;
      private string[] P00D29_A717SerasaEnderecosLogr ;
      private bool[] P00D29_n717SerasaEnderecosLogr ;
      private string[] P00D29_A723SerasaEnderecosCEP ;
      private bool[] P00D29_n723SerasaEnderecosCEP ;
      private int[] P00D29_A716SerasaEnderecosId ;
      private int[] P00D210_A662SerasaId ;
      private bool[] P00D210_n662SerasaId ;
      private string[] P00D210_A725SerasaEnderecosTel ;
      private bool[] P00D210_n725SerasaEnderecosTel ;
      private string[] P00D210_A724SerasaEnderecosTelDDD ;
      private bool[] P00D210_n724SerasaEnderecosTelDDD ;
      private string[] P00D210_A722SerasaEnderecosEstado ;
      private bool[] P00D210_n722SerasaEnderecosEstado ;
      private string[] P00D210_A721SerasaEnderecosCidade ;
      private bool[] P00D210_n721SerasaEnderecosCidade ;
      private string[] P00D210_A720SerasaEnderecosBairro ;
      private bool[] P00D210_n720SerasaEnderecosBairro ;
      private string[] P00D210_A719SerasaEnderecosCompl ;
      private bool[] P00D210_n719SerasaEnderecosCompl ;
      private string[] P00D210_A718SerasaEnderecosNum ;
      private bool[] P00D210_n718SerasaEnderecosNum ;
      private string[] P00D210_A717SerasaEnderecosLogr ;
      private bool[] P00D210_n717SerasaEnderecosLogr ;
      private string[] P00D210_A723SerasaEnderecosCEP ;
      private bool[] P00D210_n723SerasaEnderecosCEP ;
      private int[] P00D210_A716SerasaEnderecosId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class serasaenderecoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00D22( IGxContext context ,
                                             string AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                             string AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                             string AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                             string AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                             string AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                             string AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                             string AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                             string AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                             string AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                             string AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                             string AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                             string AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                             string AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                             string AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                             string AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                             string AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                             string AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                             string AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                             string A723SerasaEnderecosCEP ,
                                             string A717SerasaEnderecosLogr ,
                                             string A718SerasaEnderecosNum ,
                                             string A719SerasaEnderecosCompl ,
                                             string A720SerasaEnderecosBairro ,
                                             string A721SerasaEnderecosCidade ,
                                             string A722SerasaEnderecosEstado ,
                                             string A724SerasaEnderecosTelDDD ,
                                             string A725SerasaEnderecosTel ,
                                             int AV53Serasaenderecoswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[19];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaEnderecosCEP, SerasaEnderecosTel, SerasaEnderecosTelDDD, SerasaEnderecosEstado, SerasaEnderecosCidade, SerasaEnderecosBairro, SerasaEnderecosCompl, SerasaEnderecosNum, SerasaEnderecosLogr, SerasaEnderecosId FROM SerasaEnderecos";
         AddWhere(sWhereString, "(SerasaId = :AV53Serasaenderecoswwds_1_serasaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP like :lV54Serasaenderecoswwds_2_tfserasaenderecoscep)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ! ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP = ( :AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCEP))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr like :lV56Serasaenderecoswwds_4_tfserasaenderecoslogr)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ! ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr = ( :AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosLogr))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum like :lV58Serasaenderecoswwds_6_tfserasaenderecosnum)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ! ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum = ( :AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl like :lV60Serasaenderecoswwds_8_tfserasaenderecoscompl)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ! ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl = ( :AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCompl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro like :lV62Serasaenderecoswwds_10_tfserasaenderecosbairro)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ! ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro = ( :AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosBairro))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade like :lV64Serasaenderecoswwds_12_tfserasaenderecoscidade)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ! ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade = ( :AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado like :lV66Serasaenderecoswwds_14_tfserasaenderecosestado)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ! ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado = ( :AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosEstado))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD like :lV68Serasaenderecoswwds_16_tfserasaenderecostelddd)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ! ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD = ( :AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTelDDD))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel like :lV70Serasaenderecoswwds_18_tfserasaenderecostel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ! ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel = ( :AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTel))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaEnderecosCEP";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00D23( IGxContext context ,
                                             string AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                             string AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                             string AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                             string AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                             string AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                             string AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                             string AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                             string AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                             string AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                             string AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                             string AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                             string AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                             string AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                             string AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                             string AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                             string AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                             string AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                             string AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                             string A723SerasaEnderecosCEP ,
                                             string A717SerasaEnderecosLogr ,
                                             string A718SerasaEnderecosNum ,
                                             string A719SerasaEnderecosCompl ,
                                             string A720SerasaEnderecosBairro ,
                                             string A721SerasaEnderecosCidade ,
                                             string A722SerasaEnderecosEstado ,
                                             string A724SerasaEnderecosTelDDD ,
                                             string A725SerasaEnderecosTel ,
                                             int AV53Serasaenderecoswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[19];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaEnderecosLogr, SerasaEnderecosTel, SerasaEnderecosTelDDD, SerasaEnderecosEstado, SerasaEnderecosCidade, SerasaEnderecosBairro, SerasaEnderecosCompl, SerasaEnderecosNum, SerasaEnderecosCEP, SerasaEnderecosId FROM SerasaEnderecos";
         AddWhere(sWhereString, "(SerasaId = :AV53Serasaenderecoswwds_1_serasaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP like :lV54Serasaenderecoswwds_2_tfserasaenderecoscep)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ! ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP = ( :AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel))");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCEP))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr like :lV56Serasaenderecoswwds_4_tfserasaenderecoslogr)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ! ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr = ( :AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosLogr))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum like :lV58Serasaenderecoswwds_6_tfserasaenderecosnum)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ! ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum = ( :AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl like :lV60Serasaenderecoswwds_8_tfserasaenderecoscompl)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ! ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl = ( :AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCompl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro like :lV62Serasaenderecoswwds_10_tfserasaenderecosbairro)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ! ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro = ( :AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosBairro))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade like :lV64Serasaenderecoswwds_12_tfserasaenderecoscidade)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ! ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade = ( :AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado like :lV66Serasaenderecoswwds_14_tfserasaenderecosestado)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ! ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado = ( :AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosEstado))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD like :lV68Serasaenderecoswwds_16_tfserasaenderecostelddd)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ! ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD = ( :AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTelDDD))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel like :lV70Serasaenderecoswwds_18_tfserasaenderecostel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ! ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel = ( :AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTel))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaEnderecosLogr";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00D24( IGxContext context ,
                                             string AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                             string AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                             string AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                             string AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                             string AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                             string AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                             string AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                             string AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                             string AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                             string AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                             string AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                             string AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                             string AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                             string AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                             string AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                             string AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                             string AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                             string AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                             string A723SerasaEnderecosCEP ,
                                             string A717SerasaEnderecosLogr ,
                                             string A718SerasaEnderecosNum ,
                                             string A719SerasaEnderecosCompl ,
                                             string A720SerasaEnderecosBairro ,
                                             string A721SerasaEnderecosCidade ,
                                             string A722SerasaEnderecosEstado ,
                                             string A724SerasaEnderecosTelDDD ,
                                             string A725SerasaEnderecosTel ,
                                             int AV53Serasaenderecoswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[19];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaEnderecosNum, SerasaEnderecosTel, SerasaEnderecosTelDDD, SerasaEnderecosEstado, SerasaEnderecosCidade, SerasaEnderecosBairro, SerasaEnderecosCompl, SerasaEnderecosLogr, SerasaEnderecosCEP, SerasaEnderecosId FROM SerasaEnderecos";
         AddWhere(sWhereString, "(SerasaId = :AV53Serasaenderecoswwds_1_serasaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP like :lV54Serasaenderecoswwds_2_tfserasaenderecoscep)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ! ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP = ( :AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel))");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCEP))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr like :lV56Serasaenderecoswwds_4_tfserasaenderecoslogr)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ! ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr = ( :AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosLogr))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum like :lV58Serasaenderecoswwds_6_tfserasaenderecosnum)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ! ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum = ( :AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl like :lV60Serasaenderecoswwds_8_tfserasaenderecoscompl)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ! ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl = ( :AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCompl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro like :lV62Serasaenderecoswwds_10_tfserasaenderecosbairro)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ! ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro = ( :AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosBairro))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade like :lV64Serasaenderecoswwds_12_tfserasaenderecoscidade)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ! ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade = ( :AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado like :lV66Serasaenderecoswwds_14_tfserasaenderecosestado)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ! ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado = ( :AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosEstado))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD like :lV68Serasaenderecoswwds_16_tfserasaenderecostelddd)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ! ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD = ( :AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTelDDD))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel like :lV70Serasaenderecoswwds_18_tfserasaenderecostel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ! ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel = ( :AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTel))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaEnderecosNum";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00D25( IGxContext context ,
                                             string AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                             string AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                             string AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                             string AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                             string AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                             string AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                             string AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                             string AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                             string AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                             string AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                             string AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                             string AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                             string AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                             string AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                             string AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                             string AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                             string AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                             string AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                             string A723SerasaEnderecosCEP ,
                                             string A717SerasaEnderecosLogr ,
                                             string A718SerasaEnderecosNum ,
                                             string A719SerasaEnderecosCompl ,
                                             string A720SerasaEnderecosBairro ,
                                             string A721SerasaEnderecosCidade ,
                                             string A722SerasaEnderecosEstado ,
                                             string A724SerasaEnderecosTelDDD ,
                                             string A725SerasaEnderecosTel ,
                                             int AV53Serasaenderecoswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[19];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaEnderecosCompl, SerasaEnderecosTel, SerasaEnderecosTelDDD, SerasaEnderecosEstado, SerasaEnderecosCidade, SerasaEnderecosBairro, SerasaEnderecosNum, SerasaEnderecosLogr, SerasaEnderecosCEP, SerasaEnderecosId FROM SerasaEnderecos";
         AddWhere(sWhereString, "(SerasaId = :AV53Serasaenderecoswwds_1_serasaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP like :lV54Serasaenderecoswwds_2_tfserasaenderecoscep)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ! ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP = ( :AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel))");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCEP))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr like :lV56Serasaenderecoswwds_4_tfserasaenderecoslogr)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ! ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr = ( :AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel))");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosLogr))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum like :lV58Serasaenderecoswwds_6_tfserasaenderecosnum)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ! ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum = ( :AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel))");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl like :lV60Serasaenderecoswwds_8_tfserasaenderecoscompl)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ! ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl = ( :AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCompl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro like :lV62Serasaenderecoswwds_10_tfserasaenderecosbairro)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ! ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro = ( :AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosBairro))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade like :lV64Serasaenderecoswwds_12_tfserasaenderecoscidade)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ! ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade = ( :AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado like :lV66Serasaenderecoswwds_14_tfserasaenderecosestado)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ! ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado = ( :AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosEstado))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD like :lV68Serasaenderecoswwds_16_tfserasaenderecostelddd)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ! ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD = ( :AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel))");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTelDDD))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel like :lV70Serasaenderecoswwds_18_tfserasaenderecostel)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ! ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel = ( :AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel))");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTel))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaEnderecosCompl";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00D26( IGxContext context ,
                                             string AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                             string AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                             string AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                             string AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                             string AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                             string AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                             string AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                             string AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                             string AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                             string AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                             string AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                             string AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                             string AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                             string AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                             string AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                             string AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                             string AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                             string AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                             string A723SerasaEnderecosCEP ,
                                             string A717SerasaEnderecosLogr ,
                                             string A718SerasaEnderecosNum ,
                                             string A719SerasaEnderecosCompl ,
                                             string A720SerasaEnderecosBairro ,
                                             string A721SerasaEnderecosCidade ,
                                             string A722SerasaEnderecosEstado ,
                                             string A724SerasaEnderecosTelDDD ,
                                             string A725SerasaEnderecosTel ,
                                             int AV53Serasaenderecoswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[19];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaEnderecosBairro, SerasaEnderecosTel, SerasaEnderecosTelDDD, SerasaEnderecosEstado, SerasaEnderecosCidade, SerasaEnderecosCompl, SerasaEnderecosNum, SerasaEnderecosLogr, SerasaEnderecosCEP, SerasaEnderecosId FROM SerasaEnderecos";
         AddWhere(sWhereString, "(SerasaId = :AV53Serasaenderecoswwds_1_serasaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP like :lV54Serasaenderecoswwds_2_tfserasaenderecoscep)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ! ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP = ( :AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel))");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCEP))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr like :lV56Serasaenderecoswwds_4_tfserasaenderecoslogr)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ! ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr = ( :AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel))");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosLogr))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum like :lV58Serasaenderecoswwds_6_tfserasaenderecosnum)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ! ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum = ( :AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel))");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl like :lV60Serasaenderecoswwds_8_tfserasaenderecoscompl)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ! ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl = ( :AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCompl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro like :lV62Serasaenderecoswwds_10_tfserasaenderecosbairro)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ! ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro = ( :AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosBairro))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade like :lV64Serasaenderecoswwds_12_tfserasaenderecoscidade)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ! ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade = ( :AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado like :lV66Serasaenderecoswwds_14_tfserasaenderecosestado)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ! ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado = ( :AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosEstado))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD like :lV68Serasaenderecoswwds_16_tfserasaenderecostelddd)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ! ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD = ( :AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel))");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTelDDD))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel like :lV70Serasaenderecoswwds_18_tfserasaenderecostel)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ! ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel = ( :AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel))");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTel))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaEnderecosBairro";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P00D27( IGxContext context ,
                                             string AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                             string AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                             string AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                             string AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                             string AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                             string AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                             string AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                             string AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                             string AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                             string AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                             string AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                             string AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                             string AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                             string AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                             string AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                             string AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                             string AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                             string AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                             string A723SerasaEnderecosCEP ,
                                             string A717SerasaEnderecosLogr ,
                                             string A718SerasaEnderecosNum ,
                                             string A719SerasaEnderecosCompl ,
                                             string A720SerasaEnderecosBairro ,
                                             string A721SerasaEnderecosCidade ,
                                             string A722SerasaEnderecosEstado ,
                                             string A724SerasaEnderecosTelDDD ,
                                             string A725SerasaEnderecosTel ,
                                             int AV53Serasaenderecoswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[19];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaEnderecosCidade, SerasaEnderecosTel, SerasaEnderecosTelDDD, SerasaEnderecosEstado, SerasaEnderecosBairro, SerasaEnderecosCompl, SerasaEnderecosNum, SerasaEnderecosLogr, SerasaEnderecosCEP, SerasaEnderecosId FROM SerasaEnderecos";
         AddWhere(sWhereString, "(SerasaId = :AV53Serasaenderecoswwds_1_serasaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP like :lV54Serasaenderecoswwds_2_tfserasaenderecoscep)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ! ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP = ( :AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel))");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCEP))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr like :lV56Serasaenderecoswwds_4_tfserasaenderecoslogr)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ! ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr = ( :AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel))");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosLogr))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum like :lV58Serasaenderecoswwds_6_tfserasaenderecosnum)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ! ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum = ( :AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel))");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl like :lV60Serasaenderecoswwds_8_tfserasaenderecoscompl)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ! ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl = ( :AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel))");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCompl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro like :lV62Serasaenderecoswwds_10_tfserasaenderecosbairro)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ! ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro = ( :AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel))");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosBairro))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade like :lV64Serasaenderecoswwds_12_tfserasaenderecoscidade)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ! ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade = ( :AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel))");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado like :lV66Serasaenderecoswwds_14_tfserasaenderecosestado)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ! ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado = ( :AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel))");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosEstado))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD like :lV68Serasaenderecoswwds_16_tfserasaenderecostelddd)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ! ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD = ( :AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel))");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTelDDD))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel like :lV70Serasaenderecoswwds_18_tfserasaenderecostel)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ! ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel = ( :AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel))");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTel))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaEnderecosCidade";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P00D28( IGxContext context ,
                                             string AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                             string AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                             string AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                             string AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                             string AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                             string AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                             string AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                             string AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                             string AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                             string AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                             string AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                             string AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                             string AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                             string AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                             string AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                             string AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                             string AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                             string AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                             string A723SerasaEnderecosCEP ,
                                             string A717SerasaEnderecosLogr ,
                                             string A718SerasaEnderecosNum ,
                                             string A719SerasaEnderecosCompl ,
                                             string A720SerasaEnderecosBairro ,
                                             string A721SerasaEnderecosCidade ,
                                             string A722SerasaEnderecosEstado ,
                                             string A724SerasaEnderecosTelDDD ,
                                             string A725SerasaEnderecosTel ,
                                             int AV53Serasaenderecoswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[19];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaEnderecosEstado, SerasaEnderecosTel, SerasaEnderecosTelDDD, SerasaEnderecosCidade, SerasaEnderecosBairro, SerasaEnderecosCompl, SerasaEnderecosNum, SerasaEnderecosLogr, SerasaEnderecosCEP, SerasaEnderecosId FROM SerasaEnderecos";
         AddWhere(sWhereString, "(SerasaId = :AV53Serasaenderecoswwds_1_serasaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP like :lV54Serasaenderecoswwds_2_tfserasaenderecoscep)");
         }
         else
         {
            GXv_int13[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ! ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP = ( :AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel))");
         }
         else
         {
            GXv_int13[2] = 1;
         }
         if ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCEP))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr like :lV56Serasaenderecoswwds_4_tfserasaenderecoslogr)");
         }
         else
         {
            GXv_int13[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ! ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr = ( :AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel))");
         }
         else
         {
            GXv_int13[4] = 1;
         }
         if ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosLogr))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum like :lV58Serasaenderecoswwds_6_tfserasaenderecosnum)");
         }
         else
         {
            GXv_int13[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ! ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum = ( :AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel))");
         }
         else
         {
            GXv_int13[6] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl like :lV60Serasaenderecoswwds_8_tfserasaenderecoscompl)");
         }
         else
         {
            GXv_int13[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ! ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl = ( :AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel))");
         }
         else
         {
            GXv_int13[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCompl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro like :lV62Serasaenderecoswwds_10_tfserasaenderecosbairro)");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ! ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro = ( :AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel))");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosBairro))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade like :lV64Serasaenderecoswwds_12_tfserasaenderecoscidade)");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ! ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade = ( :AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel))");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado like :lV66Serasaenderecoswwds_14_tfserasaenderecosestado)");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ! ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado = ( :AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel))");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosEstado))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD like :lV68Serasaenderecoswwds_16_tfserasaenderecostelddd)");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ! ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD = ( :AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel))");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTelDDD))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel like :lV70Serasaenderecoswwds_18_tfserasaenderecostel)");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ! ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel = ( :AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel))");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTel))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaEnderecosEstado";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      protected Object[] conditional_P00D29( IGxContext context ,
                                             string AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                             string AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                             string AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                             string AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                             string AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                             string AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                             string AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                             string AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                             string AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                             string AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                             string AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                             string AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                             string AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                             string AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                             string AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                             string AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                             string AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                             string AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                             string A723SerasaEnderecosCEP ,
                                             string A717SerasaEnderecosLogr ,
                                             string A718SerasaEnderecosNum ,
                                             string A719SerasaEnderecosCompl ,
                                             string A720SerasaEnderecosBairro ,
                                             string A721SerasaEnderecosCidade ,
                                             string A722SerasaEnderecosEstado ,
                                             string A724SerasaEnderecosTelDDD ,
                                             string A725SerasaEnderecosTel ,
                                             int AV53Serasaenderecoswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[19];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaEnderecosTelDDD, SerasaEnderecosTel, SerasaEnderecosEstado, SerasaEnderecosCidade, SerasaEnderecosBairro, SerasaEnderecosCompl, SerasaEnderecosNum, SerasaEnderecosLogr, SerasaEnderecosCEP, SerasaEnderecosId FROM SerasaEnderecos";
         AddWhere(sWhereString, "(SerasaId = :AV53Serasaenderecoswwds_1_serasaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP like :lV54Serasaenderecoswwds_2_tfserasaenderecoscep)");
         }
         else
         {
            GXv_int15[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ! ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP = ( :AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel))");
         }
         else
         {
            GXv_int15[2] = 1;
         }
         if ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCEP))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr like :lV56Serasaenderecoswwds_4_tfserasaenderecoslogr)");
         }
         else
         {
            GXv_int15[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ! ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr = ( :AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel))");
         }
         else
         {
            GXv_int15[4] = 1;
         }
         if ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosLogr))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum like :lV58Serasaenderecoswwds_6_tfserasaenderecosnum)");
         }
         else
         {
            GXv_int15[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ! ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum = ( :AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel))");
         }
         else
         {
            GXv_int15[6] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl like :lV60Serasaenderecoswwds_8_tfserasaenderecoscompl)");
         }
         else
         {
            GXv_int15[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ! ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl = ( :AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel))");
         }
         else
         {
            GXv_int15[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCompl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro like :lV62Serasaenderecoswwds_10_tfserasaenderecosbairro)");
         }
         else
         {
            GXv_int15[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ! ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro = ( :AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel))");
         }
         else
         {
            GXv_int15[10] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosBairro))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade like :lV64Serasaenderecoswwds_12_tfserasaenderecoscidade)");
         }
         else
         {
            GXv_int15[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ! ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade = ( :AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel))");
         }
         else
         {
            GXv_int15[12] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado like :lV66Serasaenderecoswwds_14_tfserasaenderecosestado)");
         }
         else
         {
            GXv_int15[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ! ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado = ( :AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel))");
         }
         else
         {
            GXv_int15[14] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosEstado))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD like :lV68Serasaenderecoswwds_16_tfserasaenderecostelddd)");
         }
         else
         {
            GXv_int15[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ! ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD = ( :AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel))");
         }
         else
         {
            GXv_int15[16] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTelDDD))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel like :lV70Serasaenderecoswwds_18_tfserasaenderecostel)");
         }
         else
         {
            GXv_int15[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ! ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel = ( :AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel))");
         }
         else
         {
            GXv_int15[18] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTel))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaEnderecosTelDDD";
         GXv_Object16[0] = scmdbuf;
         GXv_Object16[1] = GXv_int15;
         return GXv_Object16 ;
      }

      protected Object[] conditional_P00D210( IGxContext context ,
                                              string AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                              string AV54Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                              string AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                              string AV56Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                              string AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                              string AV58Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                              string AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                              string AV60Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                              string AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                              string AV62Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                              string AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                              string AV64Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                              string AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                              string AV66Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                              string AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                              string AV68Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                              string AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                              string AV70Serasaenderecoswwds_18_tfserasaenderecostel ,
                                              string A723SerasaEnderecosCEP ,
                                              string A717SerasaEnderecosLogr ,
                                              string A718SerasaEnderecosNum ,
                                              string A719SerasaEnderecosCompl ,
                                              string A720SerasaEnderecosBairro ,
                                              string A721SerasaEnderecosCidade ,
                                              string A722SerasaEnderecosEstado ,
                                              string A724SerasaEnderecosTelDDD ,
                                              string A725SerasaEnderecosTel ,
                                              int AV53Serasaenderecoswwds_1_serasaid ,
                                              int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int17 = new short[19];
         Object[] GXv_Object18 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaEnderecosTel, SerasaEnderecosTelDDD, SerasaEnderecosEstado, SerasaEnderecosCidade, SerasaEnderecosBairro, SerasaEnderecosCompl, SerasaEnderecosNum, SerasaEnderecosLogr, SerasaEnderecosCEP, SerasaEnderecosId FROM SerasaEnderecos";
         AddWhere(sWhereString, "(SerasaId = :AV53Serasaenderecoswwds_1_serasaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Serasaenderecoswwds_2_tfserasaenderecoscep)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP like :lV54Serasaenderecoswwds_2_tfserasaenderecoscep)");
         }
         else
         {
            GXv_int17[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ! ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP = ( :AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel))");
         }
         else
         {
            GXv_int17[2] = 1;
         }
         if ( StringUtil.StrCmp(AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCEP))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Serasaenderecoswwds_4_tfserasaenderecoslogr)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr like :lV56Serasaenderecoswwds_4_tfserasaenderecoslogr)");
         }
         else
         {
            GXv_int17[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ! ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr = ( :AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel))");
         }
         else
         {
            GXv_int17[4] = 1;
         }
         if ( StringUtil.StrCmp(AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosLogr))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaenderecoswwds_6_tfserasaenderecosnum)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum like :lV58Serasaenderecoswwds_6_tfserasaenderecosnum)");
         }
         else
         {
            GXv_int17[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ! ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum = ( :AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel))");
         }
         else
         {
            GXv_int17[6] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Serasaenderecoswwds_8_tfserasaenderecoscompl)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl like :lV60Serasaenderecoswwds_8_tfserasaenderecoscompl)");
         }
         else
         {
            GXv_int17[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ! ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl = ( :AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel))");
         }
         else
         {
            GXv_int17[8] = 1;
         }
         if ( StringUtil.StrCmp(AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCompl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaenderecoswwds_10_tfserasaenderecosbairro)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro like :lV62Serasaenderecoswwds_10_tfserasaenderecosbairro)");
         }
         else
         {
            GXv_int17[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ! ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro = ( :AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel))");
         }
         else
         {
            GXv_int17[10] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosBairro))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaenderecoswwds_12_tfserasaenderecoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade like :lV64Serasaenderecoswwds_12_tfserasaenderecoscidade)");
         }
         else
         {
            GXv_int17[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ! ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade = ( :AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel))");
         }
         else
         {
            GXv_int17[12] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaenderecoswwds_14_tfserasaenderecosestado)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado like :lV66Serasaenderecoswwds_14_tfserasaenderecosestado)");
         }
         else
         {
            GXv_int17[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ! ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado = ( :AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel))");
         }
         else
         {
            GXv_int17[14] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosEstado))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaenderecoswwds_16_tfserasaenderecostelddd)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD like :lV68Serasaenderecoswwds_16_tfserasaenderecostelddd)");
         }
         else
         {
            GXv_int17[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ! ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD = ( :AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel))");
         }
         else
         {
            GXv_int17[16] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTelDDD))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaenderecoswwds_18_tfserasaenderecostel)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel like :lV70Serasaenderecoswwds_18_tfserasaenderecostel)");
         }
         else
         {
            GXv_int17[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ! ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel = ( :AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel))");
         }
         else
         {
            GXv_int17[18] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTel))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaEnderecosTel";
         GXv_Object18[0] = scmdbuf;
         GXv_Object18[1] = GXv_int17;
         return GXv_Object18 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00D22(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
               case 1 :
                     return conditional_P00D23(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
               case 2 :
                     return conditional_P00D24(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
               case 3 :
                     return conditional_P00D25(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
               case 4 :
                     return conditional_P00D26(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
               case 5 :
                     return conditional_P00D27(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
               case 6 :
                     return conditional_P00D28(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
               case 7 :
                     return conditional_P00D29(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
               case 8 :
                     return conditional_P00D210(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] );
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
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00D22;
          prmP00D22 = new Object[] {
          new ParDef("AV53Serasaenderecoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("lV54Serasaenderecoswwds_2_tfserasaenderecoscep",GXType.VarChar,40,0) ,
          new ParDef("AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel",GXType.VarChar,40,0) ,
          new ParDef("lV56Serasaenderecoswwds_4_tfserasaenderecoslogr",GXType.VarChar,100,0) ,
          new ParDef("AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel",GXType.VarChar,100,0) ,
          new ParDef("lV58Serasaenderecoswwds_6_tfserasaenderecosnum",GXType.VarChar,40,0) ,
          new ParDef("AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel",GXType.VarChar,40,0) ,
          new ParDef("lV60Serasaenderecoswwds_8_tfserasaenderecoscompl",GXType.VarChar,50,0) ,
          new ParDef("AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel",GXType.VarChar,50,0) ,
          new ParDef("lV62Serasaenderecoswwds_10_tfserasaenderecosbairro",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaenderecoswwds_12_tfserasaenderecoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaenderecoswwds_14_tfserasaenderecosestado",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaenderecoswwds_16_tfserasaenderecostelddd",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaenderecoswwds_18_tfserasaenderecostel",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00D23;
          prmP00D23 = new Object[] {
          new ParDef("AV53Serasaenderecoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("lV54Serasaenderecoswwds_2_tfserasaenderecoscep",GXType.VarChar,40,0) ,
          new ParDef("AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel",GXType.VarChar,40,0) ,
          new ParDef("lV56Serasaenderecoswwds_4_tfserasaenderecoslogr",GXType.VarChar,100,0) ,
          new ParDef("AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel",GXType.VarChar,100,0) ,
          new ParDef("lV58Serasaenderecoswwds_6_tfserasaenderecosnum",GXType.VarChar,40,0) ,
          new ParDef("AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel",GXType.VarChar,40,0) ,
          new ParDef("lV60Serasaenderecoswwds_8_tfserasaenderecoscompl",GXType.VarChar,50,0) ,
          new ParDef("AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel",GXType.VarChar,50,0) ,
          new ParDef("lV62Serasaenderecoswwds_10_tfserasaenderecosbairro",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaenderecoswwds_12_tfserasaenderecoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaenderecoswwds_14_tfserasaenderecosestado",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaenderecoswwds_16_tfserasaenderecostelddd",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaenderecoswwds_18_tfserasaenderecostel",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00D24;
          prmP00D24 = new Object[] {
          new ParDef("AV53Serasaenderecoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("lV54Serasaenderecoswwds_2_tfserasaenderecoscep",GXType.VarChar,40,0) ,
          new ParDef("AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel",GXType.VarChar,40,0) ,
          new ParDef("lV56Serasaenderecoswwds_4_tfserasaenderecoslogr",GXType.VarChar,100,0) ,
          new ParDef("AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel",GXType.VarChar,100,0) ,
          new ParDef("lV58Serasaenderecoswwds_6_tfserasaenderecosnum",GXType.VarChar,40,0) ,
          new ParDef("AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel",GXType.VarChar,40,0) ,
          new ParDef("lV60Serasaenderecoswwds_8_tfserasaenderecoscompl",GXType.VarChar,50,0) ,
          new ParDef("AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel",GXType.VarChar,50,0) ,
          new ParDef("lV62Serasaenderecoswwds_10_tfserasaenderecosbairro",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaenderecoswwds_12_tfserasaenderecoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaenderecoswwds_14_tfserasaenderecosestado",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaenderecoswwds_16_tfserasaenderecostelddd",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaenderecoswwds_18_tfserasaenderecostel",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00D25;
          prmP00D25 = new Object[] {
          new ParDef("AV53Serasaenderecoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("lV54Serasaenderecoswwds_2_tfserasaenderecoscep",GXType.VarChar,40,0) ,
          new ParDef("AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel",GXType.VarChar,40,0) ,
          new ParDef("lV56Serasaenderecoswwds_4_tfserasaenderecoslogr",GXType.VarChar,100,0) ,
          new ParDef("AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel",GXType.VarChar,100,0) ,
          new ParDef("lV58Serasaenderecoswwds_6_tfserasaenderecosnum",GXType.VarChar,40,0) ,
          new ParDef("AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel",GXType.VarChar,40,0) ,
          new ParDef("lV60Serasaenderecoswwds_8_tfserasaenderecoscompl",GXType.VarChar,50,0) ,
          new ParDef("AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel",GXType.VarChar,50,0) ,
          new ParDef("lV62Serasaenderecoswwds_10_tfserasaenderecosbairro",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaenderecoswwds_12_tfserasaenderecoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaenderecoswwds_14_tfserasaenderecosestado",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaenderecoswwds_16_tfserasaenderecostelddd",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaenderecoswwds_18_tfserasaenderecostel",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00D26;
          prmP00D26 = new Object[] {
          new ParDef("AV53Serasaenderecoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("lV54Serasaenderecoswwds_2_tfserasaenderecoscep",GXType.VarChar,40,0) ,
          new ParDef("AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel",GXType.VarChar,40,0) ,
          new ParDef("lV56Serasaenderecoswwds_4_tfserasaenderecoslogr",GXType.VarChar,100,0) ,
          new ParDef("AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel",GXType.VarChar,100,0) ,
          new ParDef("lV58Serasaenderecoswwds_6_tfserasaenderecosnum",GXType.VarChar,40,0) ,
          new ParDef("AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel",GXType.VarChar,40,0) ,
          new ParDef("lV60Serasaenderecoswwds_8_tfserasaenderecoscompl",GXType.VarChar,50,0) ,
          new ParDef("AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel",GXType.VarChar,50,0) ,
          new ParDef("lV62Serasaenderecoswwds_10_tfserasaenderecosbairro",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaenderecoswwds_12_tfserasaenderecoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaenderecoswwds_14_tfserasaenderecosestado",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaenderecoswwds_16_tfserasaenderecostelddd",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaenderecoswwds_18_tfserasaenderecostel",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00D27;
          prmP00D27 = new Object[] {
          new ParDef("AV53Serasaenderecoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("lV54Serasaenderecoswwds_2_tfserasaenderecoscep",GXType.VarChar,40,0) ,
          new ParDef("AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel",GXType.VarChar,40,0) ,
          new ParDef("lV56Serasaenderecoswwds_4_tfserasaenderecoslogr",GXType.VarChar,100,0) ,
          new ParDef("AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel",GXType.VarChar,100,0) ,
          new ParDef("lV58Serasaenderecoswwds_6_tfserasaenderecosnum",GXType.VarChar,40,0) ,
          new ParDef("AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel",GXType.VarChar,40,0) ,
          new ParDef("lV60Serasaenderecoswwds_8_tfserasaenderecoscompl",GXType.VarChar,50,0) ,
          new ParDef("AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel",GXType.VarChar,50,0) ,
          new ParDef("lV62Serasaenderecoswwds_10_tfserasaenderecosbairro",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaenderecoswwds_12_tfserasaenderecoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaenderecoswwds_14_tfserasaenderecosestado",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaenderecoswwds_16_tfserasaenderecostelddd",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaenderecoswwds_18_tfserasaenderecostel",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00D28;
          prmP00D28 = new Object[] {
          new ParDef("AV53Serasaenderecoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("lV54Serasaenderecoswwds_2_tfserasaenderecoscep",GXType.VarChar,40,0) ,
          new ParDef("AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel",GXType.VarChar,40,0) ,
          new ParDef("lV56Serasaenderecoswwds_4_tfserasaenderecoslogr",GXType.VarChar,100,0) ,
          new ParDef("AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel",GXType.VarChar,100,0) ,
          new ParDef("lV58Serasaenderecoswwds_6_tfserasaenderecosnum",GXType.VarChar,40,0) ,
          new ParDef("AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel",GXType.VarChar,40,0) ,
          new ParDef("lV60Serasaenderecoswwds_8_tfserasaenderecoscompl",GXType.VarChar,50,0) ,
          new ParDef("AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel",GXType.VarChar,50,0) ,
          new ParDef("lV62Serasaenderecoswwds_10_tfserasaenderecosbairro",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaenderecoswwds_12_tfserasaenderecoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaenderecoswwds_14_tfserasaenderecosestado",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaenderecoswwds_16_tfserasaenderecostelddd",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaenderecoswwds_18_tfserasaenderecostel",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00D29;
          prmP00D29 = new Object[] {
          new ParDef("AV53Serasaenderecoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("lV54Serasaenderecoswwds_2_tfserasaenderecoscep",GXType.VarChar,40,0) ,
          new ParDef("AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel",GXType.VarChar,40,0) ,
          new ParDef("lV56Serasaenderecoswwds_4_tfserasaenderecoslogr",GXType.VarChar,100,0) ,
          new ParDef("AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel",GXType.VarChar,100,0) ,
          new ParDef("lV58Serasaenderecoswwds_6_tfserasaenderecosnum",GXType.VarChar,40,0) ,
          new ParDef("AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel",GXType.VarChar,40,0) ,
          new ParDef("lV60Serasaenderecoswwds_8_tfserasaenderecoscompl",GXType.VarChar,50,0) ,
          new ParDef("AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel",GXType.VarChar,50,0) ,
          new ParDef("lV62Serasaenderecoswwds_10_tfserasaenderecosbairro",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaenderecoswwds_12_tfserasaenderecoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaenderecoswwds_14_tfserasaenderecosestado",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaenderecoswwds_16_tfserasaenderecostelddd",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaenderecoswwds_18_tfserasaenderecostel",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00D210;
          prmP00D210 = new Object[] {
          new ParDef("AV53Serasaenderecoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("lV54Serasaenderecoswwds_2_tfserasaenderecoscep",GXType.VarChar,40,0) ,
          new ParDef("AV55Serasaenderecoswwds_3_tfserasaenderecoscep_sel",GXType.VarChar,40,0) ,
          new ParDef("lV56Serasaenderecoswwds_4_tfserasaenderecoslogr",GXType.VarChar,100,0) ,
          new ParDef("AV57Serasaenderecoswwds_5_tfserasaenderecoslogr_sel",GXType.VarChar,100,0) ,
          new ParDef("lV58Serasaenderecoswwds_6_tfserasaenderecosnum",GXType.VarChar,40,0) ,
          new ParDef("AV59Serasaenderecoswwds_7_tfserasaenderecosnum_sel",GXType.VarChar,40,0) ,
          new ParDef("lV60Serasaenderecoswwds_8_tfserasaenderecoscompl",GXType.VarChar,50,0) ,
          new ParDef("AV61Serasaenderecoswwds_9_tfserasaenderecoscompl_sel",GXType.VarChar,50,0) ,
          new ParDef("lV62Serasaenderecoswwds_10_tfserasaenderecosbairro",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaenderecoswwds_11_tfserasaenderecosbairro_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaenderecoswwds_12_tfserasaenderecoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaenderecoswwds_13_tfserasaenderecoscidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaenderecoswwds_14_tfserasaenderecosestado",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaenderecoswwds_15_tfserasaenderecosestado_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaenderecoswwds_16_tfserasaenderecostelddd",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaenderecoswwds_17_tfserasaenderecostelddd_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaenderecoswwds_18_tfserasaenderecostel",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaenderecoswwds_19_tfserasaenderecostel_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D22", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D22,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D23", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D23,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D24", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D24,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D25", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D25,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D26", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D26,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D27", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D27,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D28", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D28,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D29", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D29,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D210", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D210,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
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
                ((int[]) buf[20])[0] = rslt.getInt(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
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
                ((int[]) buf[20])[0] = rslt.getInt(11);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
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
                ((int[]) buf[20])[0] = rslt.getInt(11);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
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
                ((int[]) buf[20])[0] = rslt.getInt(11);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
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
                ((int[]) buf[20])[0] = rslt.getInt(11);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
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
                ((int[]) buf[20])[0] = rslt.getInt(11);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
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
                ((int[]) buf[20])[0] = rslt.getInt(11);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
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
                ((int[]) buf[20])[0] = rslt.getInt(11);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
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
                ((int[]) buf[20])[0] = rslt.getInt(11);
                return;
       }
    }

 }

}
