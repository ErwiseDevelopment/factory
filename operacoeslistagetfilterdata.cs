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
   public class operacoeslistagetfilterdata : GXProcedure
   {
      public operacoeslistagetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacoeslistagetfilterdata( IGxContext context )
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
         this.AV42DDOName = aP0_DDOName;
         this.AV43SearchTxtParms = aP1_SearchTxtParms;
         this.AV44SearchTxtTo = aP2_SearchTxtTo;
         this.AV45OptionsJson = "" ;
         this.AV46OptionsDescJson = "" ;
         this.AV47OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV45OptionsJson;
         aP4_OptionsDescJson=this.AV46OptionsDescJson;
         aP5_OptionIndexesJson=this.AV47OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV47OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV42DDOName = aP0_DDOName;
         this.AV43SearchTxtParms = aP1_SearchTxtParms;
         this.AV44SearchTxtTo = aP2_SearchTxtTo;
         this.AV45OptionsJson = "" ;
         this.AV46OptionsDescJson = "" ;
         this.AV47OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV45OptionsJson;
         aP4_OptionsDescJson=this.AV46OptionsDescJson;
         aP5_OptionIndexesJson=this.AV47OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV32Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29MaxItems = 10;
         AV28PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV43SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV43SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV26SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV43SearchTxtParms)) ? "" : StringUtil.Substring( AV43SearchTxtParms, 3, -1));
         AV27SkipItems = (short)(AV28PageIndex*AV29MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV42DDOName), "DDO_CLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTERAZAOSOCIALOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV42DDOName), "DDO_CONTRATONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADCONTRATONOMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV45OptionsJson = AV32Options.ToJSonString(false);
         AV46OptionsDescJson = AV34OptionsDesc.ToJSonString(false);
         AV47OptionIndexesJson = AV35OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get("OperacoesListaGridState"), "") == 0 )
         {
            AV39GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "OperacoesListaGridState"), null, "", "");
         }
         else
         {
            AV39GridState.FromXml(AV37Session.Get("OperacoesListaGridState"), null, "", "");
         }
         AV69GXV1 = 1;
         while ( AV69GXV1 <= AV39GridState.gxTpr_Filtervalues.Count )
         {
            AV40GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV39GridState.gxTpr_Filtervalues.Item(AV69GXV1));
            if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV48FilterFullText = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFOPERACOESID") == 0 )
            {
               AV67TFOperacoesId = (int)(Math.Round(NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV68TFOperacoesId_To = (int)(Math.Round(NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV10TFClienteRazaoSocial = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV11TFClienteRazaoSocial_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFOPERACOESDATA") == 0 )
            {
               AV12TFOperacoesData = context.localUtil.CToD( AV40GridStateFilterValue.gxTpr_Value, 4);
               AV13TFOperacoesData_To = context.localUtil.CToD( AV40GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFOPERACOESSTATUS_SEL") == 0 )
            {
               AV14TFOperacoesStatus_SelsJson = AV40GridStateFilterValue.gxTpr_Value;
               AV15TFOperacoesStatus_Sels.FromJSonString(AV14TFOperacoesStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFOPERACOESTAXAEFETIVA") == 0 )
            {
               AV16TFOperacoesTaxaEfetiva = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, ".");
               AV17TFOperacoesTaxaEfetiva_To = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFOPERACOESTAXAMORA") == 0 )
            {
               AV18TFOperacoesTaxaMora = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, ".");
               AV19TFOperacoesTaxaMora_To = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV20TFContratoNome = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV21TFContratoNome_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFOPERACOESCREATEDAT") == 0 )
            {
               AV22TFOperacoesCreatedAt = context.localUtil.CToT( AV40GridStateFilterValue.gxTpr_Value, 4);
               AV23TFOperacoesCreatedAt_To = context.localUtil.CToT( AV40GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFOPERACOESUPDATEAT") == 0 )
            {
               AV24TFOperacoesUpdateAt = context.localUtil.CToT( AV40GridStateFilterValue.gxTpr_Value, 4);
               AV25TFOperacoesUpdateAt_To = context.localUtil.CToT( AV40GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTEID") == 0 )
            {
               AV66ClienteId = (int)(Math.Round(NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV69GXV1 = (int)(AV69GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV10TFClienteRazaoSocial = AV26SearchTxt;
         AV11TFClienteRazaoSocial_Sel = "";
         AV71Operacoeslistads_1_filterfulltext = AV48FilterFullText;
         AV72Operacoeslistads_2_tfoperacoesid = AV67TFOperacoesId;
         AV73Operacoeslistads_3_tfoperacoesid_to = AV68TFOperacoesId_To;
         AV74Operacoeslistads_4_tfclienterazaosocial = AV10TFClienteRazaoSocial;
         AV75Operacoeslistads_5_tfclienterazaosocial_sel = AV11TFClienteRazaoSocial_Sel;
         AV76Operacoeslistads_6_tfoperacoesdata = AV12TFOperacoesData;
         AV77Operacoeslistads_7_tfoperacoesdata_to = AV13TFOperacoesData_To;
         AV78Operacoeslistads_8_tfoperacoesstatus_sels = AV15TFOperacoesStatus_Sels;
         AV79Operacoeslistads_9_tfoperacoestaxaefetiva = AV16TFOperacoesTaxaEfetiva;
         AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to = AV17TFOperacoesTaxaEfetiva_To;
         AV81Operacoeslistads_11_tfoperacoestaxamora = AV18TFOperacoesTaxaMora;
         AV82Operacoeslistads_12_tfoperacoestaxamora_to = AV19TFOperacoesTaxaMora_To;
         AV83Operacoeslistads_13_tfcontratonome = AV20TFContratoNome;
         AV84Operacoeslistads_14_tfcontratonome_sel = AV21TFContratoNome_Sel;
         AV85Operacoeslistads_15_tfoperacoescreatedat = AV22TFOperacoesCreatedAt;
         AV86Operacoeslistads_16_tfoperacoescreatedat_to = AV23TFOperacoesCreatedAt_To;
         AV87Operacoeslistads_17_tfoperacoesupdateat = AV24TFOperacoesUpdateAt;
         AV88Operacoeslistads_18_tfoperacoesupdateat_to = AV25TFOperacoesUpdateAt_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1012OperacoesStatus ,
                                              AV78Operacoeslistads_8_tfoperacoesstatus_sels ,
                                              AV71Operacoeslistads_1_filterfulltext ,
                                              AV72Operacoeslistads_2_tfoperacoesid ,
                                              AV73Operacoeslistads_3_tfoperacoesid_to ,
                                              AV75Operacoeslistads_5_tfclienterazaosocial_sel ,
                                              AV74Operacoeslistads_4_tfclienterazaosocial ,
                                              AV76Operacoeslistads_6_tfoperacoesdata ,
                                              AV77Operacoeslistads_7_tfoperacoesdata_to ,
                                              AV78Operacoeslistads_8_tfoperacoesstatus_sels.Count ,
                                              AV79Operacoeslistads_9_tfoperacoestaxaefetiva ,
                                              AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to ,
                                              AV81Operacoeslistads_11_tfoperacoestaxamora ,
                                              AV82Operacoeslistads_12_tfoperacoestaxamora_to ,
                                              AV84Operacoeslistads_14_tfcontratonome_sel ,
                                              AV83Operacoeslistads_13_tfcontratonome ,
                                              AV85Operacoeslistads_15_tfoperacoescreatedat ,
                                              AV86Operacoeslistads_16_tfoperacoescreatedat_to ,
                                              AV87Operacoeslistads_17_tfoperacoesupdateat ,
                                              AV88Operacoeslistads_18_tfoperacoesupdateat_to ,
                                              A1010OperacoesId ,
                                              A170ClienteRazaoSocial ,
                                              A1015OperacoesTaxaEfetiva ,
                                              A1016OperacoesTaxaMora ,
                                              A228ContratoNome ,
                                              A1011OperacoesData ,
                                              A1017OperacoesCreatedAt ,
                                              A1018OperacoesUpdateAt ,
                                              A168ClienteId ,
                                              AV66ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV74Operacoeslistads_4_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV74Operacoeslistads_4_tfclienterazaosocial), "%", "");
         lV83Operacoeslistads_13_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV83Operacoeslistads_13_tfcontratonome), "%", "");
         /* Using cursor P00F62 */
         pr_default.execute(0, new Object[] {AV66ClienteId, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, AV72Operacoeslistads_2_tfoperacoesid, AV73Operacoeslistads_3_tfoperacoesid_to, lV74Operacoeslistads_4_tfclienterazaosocial, AV75Operacoeslistads_5_tfclienterazaosocial_sel, AV76Operacoeslistads_6_tfoperacoesdata, AV77Operacoeslistads_7_tfoperacoesdata_to, AV79Operacoeslistads_9_tfoperacoestaxaefetiva, AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to, AV81Operacoeslistads_11_tfoperacoestaxamora, AV82Operacoeslistads_12_tfoperacoestaxamora_to, lV83Operacoeslistads_13_tfcontratonome, AV84Operacoeslistads_14_tfcontratonome_sel, AV85Operacoeslistads_15_tfoperacoescreatedat, AV86Operacoeslistads_16_tfoperacoescreatedat_to, AV87Operacoeslistads_17_tfoperacoesupdateat, AV88Operacoeslistads_18_tfoperacoesupdateat_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKF62 = false;
            A227ContratoId = P00F62_A227ContratoId[0];
            n227ContratoId = P00F62_n227ContratoId[0];
            A168ClienteId = P00F62_A168ClienteId[0];
            n168ClienteId = P00F62_n168ClienteId[0];
            A170ClienteRazaoSocial = P00F62_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00F62_n170ClienteRazaoSocial[0];
            A1018OperacoesUpdateAt = P00F62_A1018OperacoesUpdateAt[0];
            n1018OperacoesUpdateAt = P00F62_n1018OperacoesUpdateAt[0];
            A1017OperacoesCreatedAt = P00F62_A1017OperacoesCreatedAt[0];
            n1017OperacoesCreatedAt = P00F62_n1017OperacoesCreatedAt[0];
            A1016OperacoesTaxaMora = P00F62_A1016OperacoesTaxaMora[0];
            n1016OperacoesTaxaMora = P00F62_n1016OperacoesTaxaMora[0];
            A1015OperacoesTaxaEfetiva = P00F62_A1015OperacoesTaxaEfetiva[0];
            n1015OperacoesTaxaEfetiva = P00F62_n1015OperacoesTaxaEfetiva[0];
            A1011OperacoesData = P00F62_A1011OperacoesData[0];
            n1011OperacoesData = P00F62_n1011OperacoesData[0];
            A1010OperacoesId = P00F62_A1010OperacoesId[0];
            A228ContratoNome = P00F62_A228ContratoNome[0];
            n228ContratoNome = P00F62_n228ContratoNome[0];
            A1012OperacoesStatus = P00F62_A1012OperacoesStatus[0];
            n1012OperacoesStatus = P00F62_n1012OperacoesStatus[0];
            A228ContratoNome = P00F62_A228ContratoNome[0];
            n228ContratoNome = P00F62_n228ContratoNome[0];
            A170ClienteRazaoSocial = P00F62_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00F62_n170ClienteRazaoSocial[0];
            AV36count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00F62_A170ClienteRazaoSocial[0], A170ClienteRazaoSocial) == 0 ) )
            {
               BRKF62 = false;
               A168ClienteId = P00F62_A168ClienteId[0];
               n168ClienteId = P00F62_n168ClienteId[0];
               A1010OperacoesId = P00F62_A1010OperacoesId[0];
               AV36count = (long)(AV36count+1);
               BRKF62 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV27SkipItems) )
            {
               AV31Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ClienteRazaoSocial)) ? "<#Empty#>" : A170ClienteRazaoSocial);
               AV33OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")));
               AV32Options.Add(AV31Option, 0);
               AV34OptionsDesc.Add(AV33OptionDesc, 0);
               AV35OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV36count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV32Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV27SkipItems = (short)(AV27SkipItems-1);
            }
            if ( ! BRKF62 )
            {
               BRKF62 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCONTRATONOMEOPTIONS' Routine */
         returnInSub = false;
         AV20TFContratoNome = AV26SearchTxt;
         AV21TFContratoNome_Sel = "";
         AV71Operacoeslistads_1_filterfulltext = AV48FilterFullText;
         AV72Operacoeslistads_2_tfoperacoesid = AV67TFOperacoesId;
         AV73Operacoeslistads_3_tfoperacoesid_to = AV68TFOperacoesId_To;
         AV74Operacoeslistads_4_tfclienterazaosocial = AV10TFClienteRazaoSocial;
         AV75Operacoeslistads_5_tfclienterazaosocial_sel = AV11TFClienteRazaoSocial_Sel;
         AV76Operacoeslistads_6_tfoperacoesdata = AV12TFOperacoesData;
         AV77Operacoeslistads_7_tfoperacoesdata_to = AV13TFOperacoesData_To;
         AV78Operacoeslistads_8_tfoperacoesstatus_sels = AV15TFOperacoesStatus_Sels;
         AV79Operacoeslistads_9_tfoperacoestaxaefetiva = AV16TFOperacoesTaxaEfetiva;
         AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to = AV17TFOperacoesTaxaEfetiva_To;
         AV81Operacoeslistads_11_tfoperacoestaxamora = AV18TFOperacoesTaxaMora;
         AV82Operacoeslistads_12_tfoperacoestaxamora_to = AV19TFOperacoesTaxaMora_To;
         AV83Operacoeslistads_13_tfcontratonome = AV20TFContratoNome;
         AV84Operacoeslistads_14_tfcontratonome_sel = AV21TFContratoNome_Sel;
         AV85Operacoeslistads_15_tfoperacoescreatedat = AV22TFOperacoesCreatedAt;
         AV86Operacoeslistads_16_tfoperacoescreatedat_to = AV23TFOperacoesCreatedAt_To;
         AV87Operacoeslistads_17_tfoperacoesupdateat = AV24TFOperacoesUpdateAt;
         AV88Operacoeslistads_18_tfoperacoesupdateat_to = AV25TFOperacoesUpdateAt_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1012OperacoesStatus ,
                                              AV78Operacoeslistads_8_tfoperacoesstatus_sels ,
                                              AV71Operacoeslistads_1_filterfulltext ,
                                              AV72Operacoeslistads_2_tfoperacoesid ,
                                              AV73Operacoeslistads_3_tfoperacoesid_to ,
                                              AV75Operacoeslistads_5_tfclienterazaosocial_sel ,
                                              AV74Operacoeslistads_4_tfclienterazaosocial ,
                                              AV76Operacoeslistads_6_tfoperacoesdata ,
                                              AV77Operacoeslistads_7_tfoperacoesdata_to ,
                                              AV78Operacoeslistads_8_tfoperacoesstatus_sels.Count ,
                                              AV79Operacoeslistads_9_tfoperacoestaxaefetiva ,
                                              AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to ,
                                              AV81Operacoeslistads_11_tfoperacoestaxamora ,
                                              AV82Operacoeslistads_12_tfoperacoestaxamora_to ,
                                              AV84Operacoeslistads_14_tfcontratonome_sel ,
                                              AV83Operacoeslistads_13_tfcontratonome ,
                                              AV85Operacoeslistads_15_tfoperacoescreatedat ,
                                              AV86Operacoeslistads_16_tfoperacoescreatedat_to ,
                                              AV87Operacoeslistads_17_tfoperacoesupdateat ,
                                              AV88Operacoeslistads_18_tfoperacoesupdateat_to ,
                                              A1010OperacoesId ,
                                              A170ClienteRazaoSocial ,
                                              A1015OperacoesTaxaEfetiva ,
                                              A1016OperacoesTaxaMora ,
                                              A228ContratoNome ,
                                              A1011OperacoesData ,
                                              A1017OperacoesCreatedAt ,
                                              A1018OperacoesUpdateAt ,
                                              A168ClienteId ,
                                              AV66ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV71Operacoeslistads_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext), "%", "");
         lV74Operacoeslistads_4_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV74Operacoeslistads_4_tfclienterazaosocial), "%", "");
         lV83Operacoeslistads_13_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV83Operacoeslistads_13_tfcontratonome), "%", "");
         /* Using cursor P00F63 */
         pr_default.execute(1, new Object[] {AV66ClienteId, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, lV71Operacoeslistads_1_filterfulltext, AV72Operacoeslistads_2_tfoperacoesid, AV73Operacoeslistads_3_tfoperacoesid_to, lV74Operacoeslistads_4_tfclienterazaosocial, AV75Operacoeslistads_5_tfclienterazaosocial_sel, AV76Operacoeslistads_6_tfoperacoesdata, AV77Operacoeslistads_7_tfoperacoesdata_to, AV79Operacoeslistads_9_tfoperacoestaxaefetiva, AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to, AV81Operacoeslistads_11_tfoperacoestaxamora, AV82Operacoeslistads_12_tfoperacoestaxamora_to, lV83Operacoeslistads_13_tfcontratonome, AV84Operacoeslistads_14_tfcontratonome_sel, AV85Operacoeslistads_15_tfoperacoescreatedat, AV86Operacoeslistads_16_tfoperacoescreatedat_to, AV87Operacoeslistads_17_tfoperacoesupdateat, AV88Operacoeslistads_18_tfoperacoesupdateat_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKF64 = false;
            A227ContratoId = P00F63_A227ContratoId[0];
            n227ContratoId = P00F63_n227ContratoId[0];
            A168ClienteId = P00F63_A168ClienteId[0];
            n168ClienteId = P00F63_n168ClienteId[0];
            A1018OperacoesUpdateAt = P00F63_A1018OperacoesUpdateAt[0];
            n1018OperacoesUpdateAt = P00F63_n1018OperacoesUpdateAt[0];
            A1017OperacoesCreatedAt = P00F63_A1017OperacoesCreatedAt[0];
            n1017OperacoesCreatedAt = P00F63_n1017OperacoesCreatedAt[0];
            A1016OperacoesTaxaMora = P00F63_A1016OperacoesTaxaMora[0];
            n1016OperacoesTaxaMora = P00F63_n1016OperacoesTaxaMora[0];
            A1015OperacoesTaxaEfetiva = P00F63_A1015OperacoesTaxaEfetiva[0];
            n1015OperacoesTaxaEfetiva = P00F63_n1015OperacoesTaxaEfetiva[0];
            A1011OperacoesData = P00F63_A1011OperacoesData[0];
            n1011OperacoesData = P00F63_n1011OperacoesData[0];
            A1010OperacoesId = P00F63_A1010OperacoesId[0];
            A228ContratoNome = P00F63_A228ContratoNome[0];
            n228ContratoNome = P00F63_n228ContratoNome[0];
            A1012OperacoesStatus = P00F63_A1012OperacoesStatus[0];
            n1012OperacoesStatus = P00F63_n1012OperacoesStatus[0];
            A170ClienteRazaoSocial = P00F63_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00F63_n170ClienteRazaoSocial[0];
            A228ContratoNome = P00F63_A228ContratoNome[0];
            n228ContratoNome = P00F63_n228ContratoNome[0];
            A170ClienteRazaoSocial = P00F63_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00F63_n170ClienteRazaoSocial[0];
            AV36count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00F63_A227ContratoId[0] == A227ContratoId ) )
            {
               BRKF64 = false;
               A1010OperacoesId = P00F63_A1010OperacoesId[0];
               AV36count = (long)(AV36count+1);
               BRKF64 = true;
               pr_default.readNext(1);
            }
            AV31Option = (String.IsNullOrEmpty(StringUtil.RTrim( A228ContratoNome)) ? "<#Empty#>" : A228ContratoNome);
            AV30InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV31Option, "<#Empty#>") != 0 ) && ( AV30InsertIndex <= AV32Options.Count ) && ( ( StringUtil.StrCmp(((string)AV32Options.Item(AV30InsertIndex)), AV31Option) < 0 ) || ( StringUtil.StrCmp(((string)AV32Options.Item(AV30InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV30InsertIndex = (int)(AV30InsertIndex+1);
            }
            AV32Options.Add(AV31Option, AV30InsertIndex);
            AV35OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV36count), "Z,ZZZ,ZZZ,ZZ9")), AV30InsertIndex);
            if ( AV32Options.Count == AV27SkipItems + 11 )
            {
               AV32Options.RemoveItem(AV32Options.Count);
               AV35OptionIndexes.RemoveItem(AV35OptionIndexes.Count);
            }
            if ( ! BRKF64 )
            {
               BRKF64 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV27SkipItems > 0 )
         {
            AV32Options.RemoveItem(1);
            AV35OptionIndexes.RemoveItem(1);
            AV27SkipItems = (short)(AV27SkipItems-1);
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
         AV45OptionsJson = "";
         AV46OptionsDescJson = "";
         AV47OptionIndexesJson = "";
         AV32Options = new GxSimpleCollection<string>();
         AV34OptionsDesc = new GxSimpleCollection<string>();
         AV35OptionIndexes = new GxSimpleCollection<string>();
         AV26SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37Session = context.GetSession();
         AV39GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV40GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV48FilterFullText = "";
         AV10TFClienteRazaoSocial = "";
         AV11TFClienteRazaoSocial_Sel = "";
         AV12TFOperacoesData = DateTime.MinValue;
         AV13TFOperacoesData_To = DateTime.MinValue;
         AV14TFOperacoesStatus_SelsJson = "";
         AV15TFOperacoesStatus_Sels = new GxSimpleCollection<string>();
         AV20TFContratoNome = "";
         AV21TFContratoNome_Sel = "";
         AV22TFOperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         AV23TFOperacoesCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV24TFOperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         AV25TFOperacoesUpdateAt_To = (DateTime)(DateTime.MinValue);
         AV71Operacoeslistads_1_filterfulltext = "";
         AV74Operacoeslistads_4_tfclienterazaosocial = "";
         AV75Operacoeslistads_5_tfclienterazaosocial_sel = "";
         AV76Operacoeslistads_6_tfoperacoesdata = DateTime.MinValue;
         AV77Operacoeslistads_7_tfoperacoesdata_to = DateTime.MinValue;
         AV78Operacoeslistads_8_tfoperacoesstatus_sels = new GxSimpleCollection<string>();
         AV83Operacoeslistads_13_tfcontratonome = "";
         AV84Operacoeslistads_14_tfcontratonome_sel = "";
         AV85Operacoeslistads_15_tfoperacoescreatedat = (DateTime)(DateTime.MinValue);
         AV86Operacoeslistads_16_tfoperacoescreatedat_to = (DateTime)(DateTime.MinValue);
         AV87Operacoeslistads_17_tfoperacoesupdateat = (DateTime)(DateTime.MinValue);
         AV88Operacoeslistads_18_tfoperacoesupdateat_to = (DateTime)(DateTime.MinValue);
         lV71Operacoeslistads_1_filterfulltext = "";
         lV74Operacoeslistads_4_tfclienterazaosocial = "";
         lV83Operacoeslistads_13_tfcontratonome = "";
         A1012OperacoesStatus = "";
         A170ClienteRazaoSocial = "";
         A228ContratoNome = "";
         A1011OperacoesData = DateTime.MinValue;
         A1017OperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         A1018OperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         P00F62_A227ContratoId = new int[1] ;
         P00F62_n227ContratoId = new bool[] {false} ;
         P00F62_A168ClienteId = new int[1] ;
         P00F62_n168ClienteId = new bool[] {false} ;
         P00F62_A170ClienteRazaoSocial = new string[] {""} ;
         P00F62_n170ClienteRazaoSocial = new bool[] {false} ;
         P00F62_A1018OperacoesUpdateAt = new DateTime[] {DateTime.MinValue} ;
         P00F62_n1018OperacoesUpdateAt = new bool[] {false} ;
         P00F62_A1017OperacoesCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00F62_n1017OperacoesCreatedAt = new bool[] {false} ;
         P00F62_A1016OperacoesTaxaMora = new decimal[1] ;
         P00F62_n1016OperacoesTaxaMora = new bool[] {false} ;
         P00F62_A1015OperacoesTaxaEfetiva = new decimal[1] ;
         P00F62_n1015OperacoesTaxaEfetiva = new bool[] {false} ;
         P00F62_A1011OperacoesData = new DateTime[] {DateTime.MinValue} ;
         P00F62_n1011OperacoesData = new bool[] {false} ;
         P00F62_A1010OperacoesId = new int[1] ;
         P00F62_A228ContratoNome = new string[] {""} ;
         P00F62_n228ContratoNome = new bool[] {false} ;
         P00F62_A1012OperacoesStatus = new string[] {""} ;
         P00F62_n1012OperacoesStatus = new bool[] {false} ;
         AV31Option = "";
         AV33OptionDesc = "";
         P00F63_A227ContratoId = new int[1] ;
         P00F63_n227ContratoId = new bool[] {false} ;
         P00F63_A168ClienteId = new int[1] ;
         P00F63_n168ClienteId = new bool[] {false} ;
         P00F63_A1018OperacoesUpdateAt = new DateTime[] {DateTime.MinValue} ;
         P00F63_n1018OperacoesUpdateAt = new bool[] {false} ;
         P00F63_A1017OperacoesCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00F63_n1017OperacoesCreatedAt = new bool[] {false} ;
         P00F63_A1016OperacoesTaxaMora = new decimal[1] ;
         P00F63_n1016OperacoesTaxaMora = new bool[] {false} ;
         P00F63_A1015OperacoesTaxaEfetiva = new decimal[1] ;
         P00F63_n1015OperacoesTaxaEfetiva = new bool[] {false} ;
         P00F63_A1011OperacoesData = new DateTime[] {DateTime.MinValue} ;
         P00F63_n1011OperacoesData = new bool[] {false} ;
         P00F63_A1010OperacoesId = new int[1] ;
         P00F63_A228ContratoNome = new string[] {""} ;
         P00F63_n228ContratoNome = new bool[] {false} ;
         P00F63_A1012OperacoesStatus = new string[] {""} ;
         P00F63_n1012OperacoesStatus = new bool[] {false} ;
         P00F63_A170ClienteRazaoSocial = new string[] {""} ;
         P00F63_n170ClienteRazaoSocial = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacoeslistagetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00F62_A227ContratoId, P00F62_n227ContratoId, P00F62_A168ClienteId, P00F62_n168ClienteId, P00F62_A170ClienteRazaoSocial, P00F62_n170ClienteRazaoSocial, P00F62_A1018OperacoesUpdateAt, P00F62_n1018OperacoesUpdateAt, P00F62_A1017OperacoesCreatedAt, P00F62_n1017OperacoesCreatedAt,
               P00F62_A1016OperacoesTaxaMora, P00F62_n1016OperacoesTaxaMora, P00F62_A1015OperacoesTaxaEfetiva, P00F62_n1015OperacoesTaxaEfetiva, P00F62_A1011OperacoesData, P00F62_n1011OperacoesData, P00F62_A1010OperacoesId, P00F62_A228ContratoNome, P00F62_n228ContratoNome, P00F62_A1012OperacoesStatus,
               P00F62_n1012OperacoesStatus
               }
               , new Object[] {
               P00F63_A227ContratoId, P00F63_n227ContratoId, P00F63_A168ClienteId, P00F63_n168ClienteId, P00F63_A1018OperacoesUpdateAt, P00F63_n1018OperacoesUpdateAt, P00F63_A1017OperacoesCreatedAt, P00F63_n1017OperacoesCreatedAt, P00F63_A1016OperacoesTaxaMora, P00F63_n1016OperacoesTaxaMora,
               P00F63_A1015OperacoesTaxaEfetiva, P00F63_n1015OperacoesTaxaEfetiva, P00F63_A1011OperacoesData, P00F63_n1011OperacoesData, P00F63_A1010OperacoesId, P00F63_A228ContratoNome, P00F63_n228ContratoNome, P00F63_A1012OperacoesStatus, P00F63_n1012OperacoesStatus, P00F63_A170ClienteRazaoSocial,
               P00F63_n170ClienteRazaoSocial
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV29MaxItems ;
      private short AV28PageIndex ;
      private short AV27SkipItems ;
      private int AV69GXV1 ;
      private int AV67TFOperacoesId ;
      private int AV68TFOperacoesId_To ;
      private int AV66ClienteId ;
      private int AV72Operacoeslistads_2_tfoperacoesid ;
      private int AV73Operacoeslistads_3_tfoperacoesid_to ;
      private int AV78Operacoeslistads_8_tfoperacoesstatus_sels_Count ;
      private int A1010OperacoesId ;
      private int A168ClienteId ;
      private int A227ContratoId ;
      private int AV30InsertIndex ;
      private long AV36count ;
      private decimal AV16TFOperacoesTaxaEfetiva ;
      private decimal AV17TFOperacoesTaxaEfetiva_To ;
      private decimal AV18TFOperacoesTaxaMora ;
      private decimal AV19TFOperacoesTaxaMora_To ;
      private decimal AV79Operacoeslistads_9_tfoperacoestaxaefetiva ;
      private decimal AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to ;
      private decimal AV81Operacoeslistads_11_tfoperacoestaxamora ;
      private decimal AV82Operacoeslistads_12_tfoperacoestaxamora_to ;
      private decimal A1015OperacoesTaxaEfetiva ;
      private decimal A1016OperacoesTaxaMora ;
      private DateTime AV22TFOperacoesCreatedAt ;
      private DateTime AV23TFOperacoesCreatedAt_To ;
      private DateTime AV24TFOperacoesUpdateAt ;
      private DateTime AV25TFOperacoesUpdateAt_To ;
      private DateTime AV85Operacoeslistads_15_tfoperacoescreatedat ;
      private DateTime AV86Operacoeslistads_16_tfoperacoescreatedat_to ;
      private DateTime AV87Operacoeslistads_17_tfoperacoesupdateat ;
      private DateTime AV88Operacoeslistads_18_tfoperacoesupdateat_to ;
      private DateTime A1017OperacoesCreatedAt ;
      private DateTime A1018OperacoesUpdateAt ;
      private DateTime AV12TFOperacoesData ;
      private DateTime AV13TFOperacoesData_To ;
      private DateTime AV76Operacoeslistads_6_tfoperacoesdata ;
      private DateTime AV77Operacoeslistads_7_tfoperacoesdata_to ;
      private DateTime A1011OperacoesData ;
      private bool returnInSub ;
      private bool BRKF62 ;
      private bool n227ContratoId ;
      private bool n168ClienteId ;
      private bool n170ClienteRazaoSocial ;
      private bool n1018OperacoesUpdateAt ;
      private bool n1017OperacoesCreatedAt ;
      private bool n1016OperacoesTaxaMora ;
      private bool n1015OperacoesTaxaEfetiva ;
      private bool n1011OperacoesData ;
      private bool n228ContratoNome ;
      private bool n1012OperacoesStatus ;
      private bool BRKF64 ;
      private string AV45OptionsJson ;
      private string AV46OptionsDescJson ;
      private string AV47OptionIndexesJson ;
      private string AV14TFOperacoesStatus_SelsJson ;
      private string AV42DDOName ;
      private string AV43SearchTxtParms ;
      private string AV44SearchTxtTo ;
      private string AV26SearchTxt ;
      private string AV48FilterFullText ;
      private string AV10TFClienteRazaoSocial ;
      private string AV11TFClienteRazaoSocial_Sel ;
      private string AV20TFContratoNome ;
      private string AV21TFContratoNome_Sel ;
      private string AV71Operacoeslistads_1_filterfulltext ;
      private string AV74Operacoeslistads_4_tfclienterazaosocial ;
      private string AV75Operacoeslistads_5_tfclienterazaosocial_sel ;
      private string AV83Operacoeslistads_13_tfcontratonome ;
      private string AV84Operacoeslistads_14_tfcontratonome_sel ;
      private string lV71Operacoeslistads_1_filterfulltext ;
      private string lV74Operacoeslistads_4_tfclienterazaosocial ;
      private string lV83Operacoeslistads_13_tfcontratonome ;
      private string A1012OperacoesStatus ;
      private string A170ClienteRazaoSocial ;
      private string A228ContratoNome ;
      private string AV31Option ;
      private string AV33OptionDesc ;
      private IGxSession AV37Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV32Options ;
      private GxSimpleCollection<string> AV34OptionsDesc ;
      private GxSimpleCollection<string> AV35OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV39GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV40GridStateFilterValue ;
      private GxSimpleCollection<string> AV15TFOperacoesStatus_Sels ;
      private GxSimpleCollection<string> AV78Operacoeslistads_8_tfoperacoesstatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00F62_A227ContratoId ;
      private bool[] P00F62_n227ContratoId ;
      private int[] P00F62_A168ClienteId ;
      private bool[] P00F62_n168ClienteId ;
      private string[] P00F62_A170ClienteRazaoSocial ;
      private bool[] P00F62_n170ClienteRazaoSocial ;
      private DateTime[] P00F62_A1018OperacoesUpdateAt ;
      private bool[] P00F62_n1018OperacoesUpdateAt ;
      private DateTime[] P00F62_A1017OperacoesCreatedAt ;
      private bool[] P00F62_n1017OperacoesCreatedAt ;
      private decimal[] P00F62_A1016OperacoesTaxaMora ;
      private bool[] P00F62_n1016OperacoesTaxaMora ;
      private decimal[] P00F62_A1015OperacoesTaxaEfetiva ;
      private bool[] P00F62_n1015OperacoesTaxaEfetiva ;
      private DateTime[] P00F62_A1011OperacoesData ;
      private bool[] P00F62_n1011OperacoesData ;
      private int[] P00F62_A1010OperacoesId ;
      private string[] P00F62_A228ContratoNome ;
      private bool[] P00F62_n228ContratoNome ;
      private string[] P00F62_A1012OperacoesStatus ;
      private bool[] P00F62_n1012OperacoesStatus ;
      private int[] P00F63_A227ContratoId ;
      private bool[] P00F63_n227ContratoId ;
      private int[] P00F63_A168ClienteId ;
      private bool[] P00F63_n168ClienteId ;
      private DateTime[] P00F63_A1018OperacoesUpdateAt ;
      private bool[] P00F63_n1018OperacoesUpdateAt ;
      private DateTime[] P00F63_A1017OperacoesCreatedAt ;
      private bool[] P00F63_n1017OperacoesCreatedAt ;
      private decimal[] P00F63_A1016OperacoesTaxaMora ;
      private bool[] P00F63_n1016OperacoesTaxaMora ;
      private decimal[] P00F63_A1015OperacoesTaxaEfetiva ;
      private bool[] P00F63_n1015OperacoesTaxaEfetiva ;
      private DateTime[] P00F63_A1011OperacoesData ;
      private bool[] P00F63_n1011OperacoesData ;
      private int[] P00F63_A1010OperacoesId ;
      private string[] P00F63_A228ContratoNome ;
      private bool[] P00F63_n228ContratoNome ;
      private string[] P00F63_A1012OperacoesStatus ;
      private bool[] P00F63_n1012OperacoesStatus ;
      private string[] P00F63_A170ClienteRazaoSocial ;
      private bool[] P00F63_n170ClienteRazaoSocial ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class operacoeslistagetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00F62( IGxContext context ,
                                             string A1012OperacoesStatus ,
                                             GxSimpleCollection<string> AV78Operacoeslistads_8_tfoperacoesstatus_sels ,
                                             string AV71Operacoeslistads_1_filterfulltext ,
                                             int AV72Operacoeslistads_2_tfoperacoesid ,
                                             int AV73Operacoeslistads_3_tfoperacoesid_to ,
                                             string AV75Operacoeslistads_5_tfclienterazaosocial_sel ,
                                             string AV74Operacoeslistads_4_tfclienterazaosocial ,
                                             DateTime AV76Operacoeslistads_6_tfoperacoesdata ,
                                             DateTime AV77Operacoeslistads_7_tfoperacoesdata_to ,
                                             int AV78Operacoeslistads_8_tfoperacoesstatus_sels_Count ,
                                             decimal AV79Operacoeslistads_9_tfoperacoestaxaefetiva ,
                                             decimal AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to ,
                                             decimal AV81Operacoeslistads_11_tfoperacoestaxamora ,
                                             decimal AV82Operacoeslistads_12_tfoperacoestaxamora_to ,
                                             string AV84Operacoeslistads_14_tfcontratonome_sel ,
                                             string AV83Operacoeslistads_13_tfcontratonome ,
                                             DateTime AV85Operacoeslistads_15_tfoperacoescreatedat ,
                                             DateTime AV86Operacoeslistads_16_tfoperacoescreatedat_to ,
                                             DateTime AV87Operacoeslistads_17_tfoperacoesupdateat ,
                                             DateTime AV88Operacoeslistads_18_tfoperacoesupdateat_to ,
                                             int A1010OperacoesId ,
                                             string A170ClienteRazaoSocial ,
                                             decimal A1015OperacoesTaxaEfetiva ,
                                             decimal A1016OperacoesTaxaMora ,
                                             string A228ContratoNome ,
                                             DateTime A1011OperacoesData ,
                                             DateTime A1017OperacoesCreatedAt ,
                                             DateTime A1018OperacoesUpdateAt ,
                                             int A168ClienteId ,
                                             int AV66ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[26];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ClienteId, T3.ClienteRazaoSocial, T1.OperacoesUpdateAt, T1.OperacoesCreatedAt, T1.OperacoesTaxaMora, T1.OperacoesTaxaEfetiva, T1.OperacoesData, T1.OperacoesId, T2.ContratoNome, T1.OperacoesStatus FROM ((Operacoes T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV66ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.OperacoesId,'999999999'), 2) like '%' || :lV71Operacoeslistads_1_filterfulltext) or ( T3.ClienteRazaoSocial like '%' || :lV71Operacoeslistads_1_filterfulltext) or ( 'pendente' like '%' || LOWER(:lV71Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'PENDENTE')) or ( 'aprovada' like '%' || LOWER(:lV71Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'APROVADA')) or ( 'recusada' like '%' || LOWER(:lV71Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'RECUSADA')) or ( 'liquidada' like '%' || LOWER(:lV71Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'LIQUIDADA')) or ( SUBSTR(TO_CHAR(T1.OperacoesTaxaEfetiva,'99999999990.9999'), 2) like '%' || :lV71Operacoeslistads_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTaxaMora,'99999999990.9999'), 2) like '%' || :lV71Operacoeslistads_1_filterfulltext) or ( T2.ContratoNome like '%' || :lV71Operacoeslistads_1_filterfulltext))");
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
         }
         if ( ! (0==AV72Operacoeslistads_2_tfoperacoesid) )
         {
            AddWhere(sWhereString, "(T1.OperacoesId >= :AV72Operacoeslistads_2_tfoperacoesid)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (0==AV73Operacoeslistads_3_tfoperacoesid_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesId <= :AV73Operacoeslistads_3_tfoperacoesid_to)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Operacoeslistads_5_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Operacoeslistads_4_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV74Operacoeslistads_4_tfclienterazaosocial)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Operacoeslistads_5_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV75Operacoeslistads_5_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV75Operacoeslistads_5_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV75Operacoeslistads_5_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( ! (DateTime.MinValue==AV76Operacoeslistads_6_tfoperacoesdata) )
         {
            AddWhere(sWhereString, "(T1.OperacoesData >= :AV76Operacoeslistads_6_tfoperacoesdata)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Operacoeslistads_7_tfoperacoesdata_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesData <= :AV77Operacoeslistads_7_tfoperacoesdata_to)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV78Operacoeslistads_8_tfoperacoesstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Operacoeslistads_8_tfoperacoesstatus_sels, "T1.OperacoesStatus IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV79Operacoeslistads_9_tfoperacoestaxaefetiva) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaEfetiva >= :AV79Operacoeslistads_9_tfoperacoestaxaefetiva)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaEfetiva <= :AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV81Operacoeslistads_11_tfoperacoestaxamora) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaMora >= :AV81Operacoeslistads_11_tfoperacoestaxamora)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Operacoeslistads_12_tfoperacoestaxamora_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaMora <= :AV82Operacoeslistads_12_tfoperacoestaxamora_to)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Operacoeslistads_14_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Operacoeslistads_13_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV83Operacoeslistads_13_tfcontratonome)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Operacoeslistads_14_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV84Operacoeslistads_14_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV84Operacoeslistads_14_tfcontratonome_sel))");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( StringUtil.StrCmp(AV84Operacoeslistads_14_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV85Operacoeslistads_15_tfoperacoescreatedat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesCreatedAt >= :AV85Operacoeslistads_15_tfoperacoescreatedat)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV86Operacoeslistads_16_tfoperacoescreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesCreatedAt <= :AV86Operacoeslistads_16_tfoperacoescreatedat_to)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV87Operacoeslistads_17_tfoperacoesupdateat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesUpdateAt >= :AV87Operacoeslistads_17_tfoperacoesupdateat)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Operacoeslistads_18_tfoperacoesupdateat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesUpdateAt <= :AV88Operacoeslistads_18_tfoperacoesupdateat_to)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.ClienteRazaoSocial";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00F63( IGxContext context ,
                                             string A1012OperacoesStatus ,
                                             GxSimpleCollection<string> AV78Operacoeslistads_8_tfoperacoesstatus_sels ,
                                             string AV71Operacoeslistads_1_filterfulltext ,
                                             int AV72Operacoeslistads_2_tfoperacoesid ,
                                             int AV73Operacoeslistads_3_tfoperacoesid_to ,
                                             string AV75Operacoeslistads_5_tfclienterazaosocial_sel ,
                                             string AV74Operacoeslistads_4_tfclienterazaosocial ,
                                             DateTime AV76Operacoeslistads_6_tfoperacoesdata ,
                                             DateTime AV77Operacoeslistads_7_tfoperacoesdata_to ,
                                             int AV78Operacoeslistads_8_tfoperacoesstatus_sels_Count ,
                                             decimal AV79Operacoeslistads_9_tfoperacoestaxaefetiva ,
                                             decimal AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to ,
                                             decimal AV81Operacoeslistads_11_tfoperacoestaxamora ,
                                             decimal AV82Operacoeslistads_12_tfoperacoestaxamora_to ,
                                             string AV84Operacoeslistads_14_tfcontratonome_sel ,
                                             string AV83Operacoeslistads_13_tfcontratonome ,
                                             DateTime AV85Operacoeslistads_15_tfoperacoescreatedat ,
                                             DateTime AV86Operacoeslistads_16_tfoperacoescreatedat_to ,
                                             DateTime AV87Operacoeslistads_17_tfoperacoesupdateat ,
                                             DateTime AV88Operacoeslistads_18_tfoperacoesupdateat_to ,
                                             int A1010OperacoesId ,
                                             string A170ClienteRazaoSocial ,
                                             decimal A1015OperacoesTaxaEfetiva ,
                                             decimal A1016OperacoesTaxaMora ,
                                             string A228ContratoNome ,
                                             DateTime A1011OperacoesData ,
                                             DateTime A1017OperacoesCreatedAt ,
                                             DateTime A1018OperacoesUpdateAt ,
                                             int A168ClienteId ,
                                             int AV66ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[26];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ContratoId, T1.ClienteId, T1.OperacoesUpdateAt, T1.OperacoesCreatedAt, T1.OperacoesTaxaMora, T1.OperacoesTaxaEfetiva, T1.OperacoesData, T1.OperacoesId, T2.ContratoNome, T1.OperacoesStatus, T3.ClienteRazaoSocial FROM ((Operacoes T1 LEFT JOIN Contrato T2 ON T2.ContratoId = T1.ContratoId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV66ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Operacoeslistads_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.OperacoesId,'999999999'), 2) like '%' || :lV71Operacoeslistads_1_filterfulltext) or ( T3.ClienteRazaoSocial like '%' || :lV71Operacoeslistads_1_filterfulltext) or ( 'pendente' like '%' || LOWER(:lV71Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'PENDENTE')) or ( 'aprovada' like '%' || LOWER(:lV71Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'APROVADA')) or ( 'recusada' like '%' || LOWER(:lV71Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'RECUSADA')) or ( 'liquidada' like '%' || LOWER(:lV71Operacoeslistads_1_filterfulltext) and T1.OperacoesStatus = ( 'LIQUIDADA')) or ( SUBSTR(TO_CHAR(T1.OperacoesTaxaEfetiva,'99999999990.9999'), 2) like '%' || :lV71Operacoeslistads_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.OperacoesTaxaMora,'99999999990.9999'), 2) like '%' || :lV71Operacoeslistads_1_filterfulltext) or ( T2.ContratoNome like '%' || :lV71Operacoeslistads_1_filterfulltext))");
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
         }
         if ( ! (0==AV72Operacoeslistads_2_tfoperacoesid) )
         {
            AddWhere(sWhereString, "(T1.OperacoesId >= :AV72Operacoeslistads_2_tfoperacoesid)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (0==AV73Operacoeslistads_3_tfoperacoesid_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesId <= :AV73Operacoeslistads_3_tfoperacoesid_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Operacoeslistads_5_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Operacoeslistads_4_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV74Operacoeslistads_4_tfclienterazaosocial)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Operacoeslistads_5_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV75Operacoeslistads_5_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV75Operacoeslistads_5_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV75Operacoeslistads_5_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( ! (DateTime.MinValue==AV76Operacoeslistads_6_tfoperacoesdata) )
         {
            AddWhere(sWhereString, "(T1.OperacoesData >= :AV76Operacoeslistads_6_tfoperacoesdata)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Operacoeslistads_7_tfoperacoesdata_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesData <= :AV77Operacoeslistads_7_tfoperacoesdata_to)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV78Operacoeslistads_8_tfoperacoesstatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV78Operacoeslistads_8_tfoperacoesstatus_sels, "T1.OperacoesStatus IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV79Operacoeslistads_9_tfoperacoestaxaefetiva) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaEfetiva >= :AV79Operacoeslistads_9_tfoperacoestaxaefetiva)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaEfetiva <= :AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV81Operacoeslistads_11_tfoperacoestaxamora) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaMora >= :AV81Operacoeslistads_11_tfoperacoestaxamora)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Operacoeslistads_12_tfoperacoestaxamora_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesTaxaMora <= :AV82Operacoeslistads_12_tfoperacoestaxamora_to)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Operacoeslistads_14_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Operacoeslistads_13_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome like :lV83Operacoeslistads_13_tfcontratonome)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Operacoeslistads_14_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV84Operacoeslistads_14_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ContratoNome = ( :AV84Operacoeslistads_14_tfcontratonome_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV84Operacoeslistads_14_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T2.ContratoNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV85Operacoeslistads_15_tfoperacoescreatedat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesCreatedAt >= :AV85Operacoeslistads_15_tfoperacoescreatedat)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV86Operacoeslistads_16_tfoperacoescreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesCreatedAt <= :AV86Operacoeslistads_16_tfoperacoescreatedat_to)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV87Operacoeslistads_17_tfoperacoesupdateat) )
         {
            AddWhere(sWhereString, "(T1.OperacoesUpdateAt >= :AV87Operacoeslistads_17_tfoperacoesupdateat)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Operacoeslistads_18_tfoperacoesupdateat_to) )
         {
            AddWhere(sWhereString, "(T1.OperacoesUpdateAt <= :AV88Operacoeslistads_18_tfoperacoesupdateat_to)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ContratoId";
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
                     return conditional_P00F62(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] );
               case 1 :
                     return conditional_P00F63(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] );
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
          Object[] prmP00F62;
          prmP00F62 = new Object[] {
          new ParDef("AV66ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV72Operacoeslistads_2_tfoperacoesid",GXType.Int32,9,0) ,
          new ParDef("AV73Operacoeslistads_3_tfoperacoesid_to",GXType.Int32,9,0) ,
          new ParDef("lV74Operacoeslistads_4_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV75Operacoeslistads_5_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV76Operacoeslistads_6_tfoperacoesdata",GXType.Date,8,0) ,
          new ParDef("AV77Operacoeslistads_7_tfoperacoesdata_to",GXType.Date,8,0) ,
          new ParDef("AV79Operacoeslistads_9_tfoperacoestaxaefetiva",GXType.Number,16,4) ,
          new ParDef("AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to",GXType.Number,16,4) ,
          new ParDef("AV81Operacoeslistads_11_tfoperacoestaxamora",GXType.Number,16,4) ,
          new ParDef("AV82Operacoeslistads_12_tfoperacoestaxamora_to",GXType.Number,16,4) ,
          new ParDef("lV83Operacoeslistads_13_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV84Operacoeslistads_14_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV85Operacoeslistads_15_tfoperacoescreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV86Operacoeslistads_16_tfoperacoescreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV87Operacoeslistads_17_tfoperacoesupdateat",GXType.DateTime,8,5) ,
          new ParDef("AV88Operacoeslistads_18_tfoperacoesupdateat_to",GXType.DateTime,8,5)
          };
          Object[] prmP00F63;
          prmP00F63 = new Object[] {
          new ParDef("AV66ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Operacoeslistads_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV72Operacoeslistads_2_tfoperacoesid",GXType.Int32,9,0) ,
          new ParDef("AV73Operacoeslistads_3_tfoperacoesid_to",GXType.Int32,9,0) ,
          new ParDef("lV74Operacoeslistads_4_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV75Operacoeslistads_5_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV76Operacoeslistads_6_tfoperacoesdata",GXType.Date,8,0) ,
          new ParDef("AV77Operacoeslistads_7_tfoperacoesdata_to",GXType.Date,8,0) ,
          new ParDef("AV79Operacoeslistads_9_tfoperacoestaxaefetiva",GXType.Number,16,4) ,
          new ParDef("AV80Operacoeslistads_10_tfoperacoestaxaefetiva_to",GXType.Number,16,4) ,
          new ParDef("AV81Operacoeslistads_11_tfoperacoestaxamora",GXType.Number,16,4) ,
          new ParDef("AV82Operacoeslistads_12_tfoperacoestaxamora_to",GXType.Number,16,4) ,
          new ParDef("lV83Operacoeslistads_13_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV84Operacoeslistads_14_tfcontratonome_sel",GXType.VarChar,125,0) ,
          new ParDef("AV85Operacoeslistads_15_tfoperacoescreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV86Operacoeslistads_16_tfoperacoescreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV87Operacoeslistads_17_tfoperacoesupdateat",GXType.DateTime,8,5) ,
          new ParDef("AV88Operacoeslistads_18_tfoperacoesupdateat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00F62", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F62,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F63", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F63,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}
