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
namespace GeneXus.Programs.costumer {
   public class wpclientesgetfilterdata : GXProcedure
   {
      public wpclientesgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpclientesgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_CLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTERAZAOSOCIALOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_RESPONSAVELNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESPONSAVELNOMEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_RESPONSAVELEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADRESPONSAVELEMAILOPTIONS' */
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
         if ( StringUtil.StrCmp(AV33Session.Get("Costumer.WpClientesGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Costumer.WpClientesGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Costumer.WpClientesGridState"), null, "", "");
         }
         AV83GXV1 = 1;
         while ( AV83GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV83GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV44FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV10TFClienteRazaoSocial = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV11TFClienteRazaoSocial_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME") == 0 )
            {
               AV12TFResponsavelNome = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME_SEL") == 0 )
            {
               AV13TFResponsavelNome_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL") == 0 )
            {
               AV14TFResponsavelEmail = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL_SEL") == 0 )
            {
               AV15TFResponsavelEmail_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIENTECREATEDAT") == 0 )
            {
               AV16TFClienteCreatedAt = context.localUtil.CToT( AV36GridStateFilterValue.gxTpr_Value, 4);
               AV17TFClienteCreatedAt_To = context.localUtil.CToT( AV36GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIENTESITUACAO_SEL") == 0 )
            {
               AV18TFClienteSituacao_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV19TFClienteSituacao_Sels.FromJSonString(AV18TFClienteSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCLIENTECOUNTNOTAS_F") == 0 )
            {
               AV20TFClienteCountNotas_F = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV21TFClienteCountNotas_F_To = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV83GXV1 = (int)(AV83GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV45DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV47ClienteDocumento1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV48TipoClienteDescricao1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV49ClienteConvenioDescricao1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV50ClienteNacionalidadeNome1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV51ClienteProfissaoNome1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "MUNICIPIONOME") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV52MunicipioNome1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "BANCOCODIGO") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV53BancoCodigo1 = (int)(Math.Round(NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV54ResponsavelNacionalidadeNome1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV55ResponsavelProfissaoNome1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV56ResponsavelMunicipioNome1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV57DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV58DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
               {
                  AV59DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV60ClienteDocumento2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  AV59DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV61TipoClienteDescricao2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
               {
                  AV59DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV62ClienteConvenioDescricao2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
               {
                  AV59DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV63ClienteNacionalidadeNome2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
               {
                  AV59DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV64ClienteProfissaoNome2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
               {
                  AV59DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV65MunicipioNome2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
               {
                  AV59DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV66BancoCodigo2 = (int)(Math.Round(NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
               {
                  AV59DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV67ResponsavelNacionalidadeNome2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
               {
                  AV59DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV68ResponsavelProfissaoNome2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
               {
                  AV59DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV69ResponsavelMunicipioNome2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV70DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV71DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV71DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
                  {
                     AV72DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV73ClienteDocumento3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
                  {
                     AV72DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV74TipoClienteDescricao3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
                  {
                     AV72DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV75ClienteConvenioDescricao3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
                  {
                     AV72DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV76ClienteNacionalidadeNome3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
                  {
                     AV72DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV77ClienteProfissaoNome3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
                  {
                     AV72DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV78MunicipioNome3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
                  {
                     AV72DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV79BancoCodigo3 = (int)(Math.Round(NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
                  {
                     AV72DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV80ResponsavelNacionalidadeNome3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
                  {
                     AV72DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV81ResponsavelProfissaoNome3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV71DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
                  {
                     AV72DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV82ResponsavelMunicipioNome3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV10TFClienteRazaoSocial = AV22SearchTxt;
         AV11TFClienteRazaoSocial_Sel = "";
         AV85Costumer_wpclientesds_1_filterfulltext = AV44FilterFullText;
         AV86Costumer_wpclientesds_2_dynamicfiltersselector1 = AV45DynamicFiltersSelector1;
         AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 = AV46DynamicFiltersOperator1;
         AV88Costumer_wpclientesds_4_clientedocumento1 = AV47ClienteDocumento1;
         AV89Costumer_wpclientesds_5_tipoclientedescricao1 = AV48TipoClienteDescricao1;
         AV90Costumer_wpclientesds_6_clienteconveniodescricao1 = AV49ClienteConvenioDescricao1;
         AV91Costumer_wpclientesds_7_clientenacionalidadenome1 = AV50ClienteNacionalidadeNome1;
         AV92Costumer_wpclientesds_8_clienteprofissaonome1 = AV51ClienteProfissaoNome1;
         AV93Costumer_wpclientesds_9_municipionome1 = AV52MunicipioNome1;
         AV94Costumer_wpclientesds_10_bancocodigo1 = AV53BancoCodigo1;
         AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = AV54ResponsavelNacionalidadeNome1;
         AV96Costumer_wpclientesds_12_responsavelprofissaonome1 = AV55ResponsavelProfissaoNome1;
         AV97Costumer_wpclientesds_13_responsavelmunicipionome1 = AV56ResponsavelMunicipioNome1;
         AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV99Costumer_wpclientesds_15_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV101Costumer_wpclientesds_17_clientedocumento2 = AV60ClienteDocumento2;
         AV102Costumer_wpclientesds_18_tipoclientedescricao2 = AV61TipoClienteDescricao2;
         AV103Costumer_wpclientesds_19_clienteconveniodescricao2 = AV62ClienteConvenioDescricao2;
         AV104Costumer_wpclientesds_20_clientenacionalidadenome2 = AV63ClienteNacionalidadeNome2;
         AV105Costumer_wpclientesds_21_clienteprofissaonome2 = AV64ClienteProfissaoNome2;
         AV106Costumer_wpclientesds_22_municipionome2 = AV65MunicipioNome2;
         AV107Costumer_wpclientesds_23_bancocodigo2 = AV66BancoCodigo2;
         AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = AV67ResponsavelNacionalidadeNome2;
         AV109Costumer_wpclientesds_25_responsavelprofissaonome2 = AV68ResponsavelProfissaoNome2;
         AV110Costumer_wpclientesds_26_responsavelmunicipionome2 = AV69ResponsavelMunicipioNome2;
         AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 = AV70DynamicFiltersEnabled3;
         AV112Costumer_wpclientesds_28_dynamicfiltersselector3 = AV71DynamicFiltersSelector3;
         AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 = AV72DynamicFiltersOperator3;
         AV114Costumer_wpclientesds_30_clientedocumento3 = AV73ClienteDocumento3;
         AV115Costumer_wpclientesds_31_tipoclientedescricao3 = AV74TipoClienteDescricao3;
         AV116Costumer_wpclientesds_32_clienteconveniodescricao3 = AV75ClienteConvenioDescricao3;
         AV117Costumer_wpclientesds_33_clientenacionalidadenome3 = AV76ClienteNacionalidadeNome3;
         AV118Costumer_wpclientesds_34_clienteprofissaonome3 = AV77ClienteProfissaoNome3;
         AV119Costumer_wpclientesds_35_municipionome3 = AV78MunicipioNome3;
         AV120Costumer_wpclientesds_36_bancocodigo3 = AV79BancoCodigo3;
         AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = AV80ResponsavelNacionalidadeNome3;
         AV122Costumer_wpclientesds_38_responsavelprofissaonome3 = AV81ResponsavelProfissaoNome3;
         AV123Costumer_wpclientesds_39_responsavelmunicipionome3 = AV82ResponsavelMunicipioNome3;
         AV124Costumer_wpclientesds_40_tfclienterazaosocial = AV10TFClienteRazaoSocial;
         AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel = AV11TFClienteRazaoSocial_Sel;
         AV126Costumer_wpclientesds_42_tfresponsavelnome = AV12TFResponsavelNome;
         AV127Costumer_wpclientesds_43_tfresponsavelnome_sel = AV13TFResponsavelNome_Sel;
         AV128Costumer_wpclientesds_44_tfresponsavelemail = AV14TFResponsavelEmail;
         AV129Costumer_wpclientesds_45_tfresponsavelemail_sel = AV15TFResponsavelEmail_Sel;
         AV130Costumer_wpclientesds_46_tfclientecreatedat = AV16TFClienteCreatedAt;
         AV131Costumer_wpclientesds_47_tfclientecreatedat_to = AV17TFClienteCreatedAt_To;
         AV132Costumer_wpclientesds_48_tfclientesituacao_sels = AV19TFClienteSituacao_Sels;
         AV133Costumer_wpclientesds_49_tfclientecountnotas_f = AV20TFClienteCountNotas_F;
         AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = AV21TFClienteCountNotas_F_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A884ClienteSituacao ,
                                              AV132Costumer_wpclientesds_48_tfclientesituacao_sels ,
                                              AV86Costumer_wpclientesds_2_dynamicfiltersselector1 ,
                                              AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 ,
                                              AV88Costumer_wpclientesds_4_clientedocumento1 ,
                                              AV89Costumer_wpclientesds_5_tipoclientedescricao1 ,
                                              AV90Costumer_wpclientesds_6_clienteconveniodescricao1 ,
                                              AV91Costumer_wpclientesds_7_clientenacionalidadenome1 ,
                                              AV92Costumer_wpclientesds_8_clienteprofissaonome1 ,
                                              AV93Costumer_wpclientesds_9_municipionome1 ,
                                              AV94Costumer_wpclientesds_10_bancocodigo1 ,
                                              AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 ,
                                              AV96Costumer_wpclientesds_12_responsavelprofissaonome1 ,
                                              AV97Costumer_wpclientesds_13_responsavelmunicipionome1 ,
                                              AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 ,
                                              AV99Costumer_wpclientesds_15_dynamicfiltersselector2 ,
                                              AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 ,
                                              AV101Costumer_wpclientesds_17_clientedocumento2 ,
                                              AV102Costumer_wpclientesds_18_tipoclientedescricao2 ,
                                              AV103Costumer_wpclientesds_19_clienteconveniodescricao2 ,
                                              AV104Costumer_wpclientesds_20_clientenacionalidadenome2 ,
                                              AV105Costumer_wpclientesds_21_clienteprofissaonome2 ,
                                              AV106Costumer_wpclientesds_22_municipionome2 ,
                                              AV107Costumer_wpclientesds_23_bancocodigo2 ,
                                              AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 ,
                                              AV109Costumer_wpclientesds_25_responsavelprofissaonome2 ,
                                              AV110Costumer_wpclientesds_26_responsavelmunicipionome2 ,
                                              AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 ,
                                              AV112Costumer_wpclientesds_28_dynamicfiltersselector3 ,
                                              AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 ,
                                              AV114Costumer_wpclientesds_30_clientedocumento3 ,
                                              AV115Costumer_wpclientesds_31_tipoclientedescricao3 ,
                                              AV116Costumer_wpclientesds_32_clienteconveniodescricao3 ,
                                              AV117Costumer_wpclientesds_33_clientenacionalidadenome3 ,
                                              AV118Costumer_wpclientesds_34_clienteprofissaonome3 ,
                                              AV119Costumer_wpclientesds_35_municipionome3 ,
                                              AV120Costumer_wpclientesds_36_bancocodigo3 ,
                                              AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 ,
                                              AV122Costumer_wpclientesds_38_responsavelprofissaonome3 ,
                                              AV123Costumer_wpclientesds_39_responsavelmunicipionome3 ,
                                              AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel ,
                                              AV124Costumer_wpclientesds_40_tfclienterazaosocial ,
                                              AV127Costumer_wpclientesds_43_tfresponsavelnome_sel ,
                                              AV126Costumer_wpclientesds_42_tfresponsavelnome ,
                                              AV129Costumer_wpclientesds_45_tfresponsavelemail_sel ,
                                              AV128Costumer_wpclientesds_44_tfresponsavelemail ,
                                              AV130Costumer_wpclientesds_46_tfclientecreatedat ,
                                              AV131Costumer_wpclientesds_47_tfclientecreatedat_to ,
                                              AV132Costumer_wpclientesds_48_tfclientesituacao_sels.Count ,
                                              A169ClienteDocumento ,
                                              A193TipoClienteDescricao ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome ,
                                              A170ClienteRazaoSocial ,
                                              A436ResponsavelNome ,
                                              A456ResponsavelEmail ,
                                              A175ClienteCreatedAt ,
                                              AV85Costumer_wpclientesds_1_filterfulltext ,
                                              A886ClienteCountNotas_F ,
                                              AV133Costumer_wpclientesds_49_tfclientecountnotas_f ,
                                              AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to ,
                                              A793TipoClientePortalPjPf } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV88Costumer_wpclientesds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1), "%", "");
         lV88Costumer_wpclientesds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1), "%", "");
         lV89Costumer_wpclientesds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1), "%", "");
         lV89Costumer_wpclientesds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1), "%", "");
         lV90Costumer_wpclientesds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1), "%", "");
         lV90Costumer_wpclientesds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1), "%", "");
         lV91Costumer_wpclientesds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1), "%", "");
         lV91Costumer_wpclientesds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1), "%", "");
         lV92Costumer_wpclientesds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1), "%", "");
         lV92Costumer_wpclientesds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1), "%", "");
         lV93Costumer_wpclientesds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1), "%", "");
         lV93Costumer_wpclientesds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1), "%", "");
         lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1), "%", "");
         lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1), "%", "");
         lV96Costumer_wpclientesds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1), "%", "");
         lV96Costumer_wpclientesds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1), "%", "");
         lV97Costumer_wpclientesds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1), "%", "");
         lV97Costumer_wpclientesds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1), "%", "");
         lV101Costumer_wpclientesds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2), "%", "");
         lV101Costumer_wpclientesds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2), "%", "");
         lV102Costumer_wpclientesds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2), "%", "");
         lV102Costumer_wpclientesds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2), "%", "");
         lV103Costumer_wpclientesds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2), "%", "");
         lV103Costumer_wpclientesds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2), "%", "");
         lV104Costumer_wpclientesds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2), "%", "");
         lV104Costumer_wpclientesds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2), "%", "");
         lV105Costumer_wpclientesds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2), "%", "");
         lV105Costumer_wpclientesds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2), "%", "");
         lV106Costumer_wpclientesds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2), "%", "");
         lV106Costumer_wpclientesds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2), "%", "");
         lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2), "%", "");
         lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2), "%", "");
         lV109Costumer_wpclientesds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2), "%", "");
         lV109Costumer_wpclientesds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2), "%", "");
         lV110Costumer_wpclientesds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2), "%", "");
         lV110Costumer_wpclientesds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2), "%", "");
         lV114Costumer_wpclientesds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3), "%", "");
         lV114Costumer_wpclientesds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3), "%", "");
         lV115Costumer_wpclientesds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3), "%", "");
         lV115Costumer_wpclientesds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3), "%", "");
         lV116Costumer_wpclientesds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3), "%", "");
         lV116Costumer_wpclientesds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3), "%", "");
         lV117Costumer_wpclientesds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3), "%", "");
         lV117Costumer_wpclientesds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3), "%", "");
         lV118Costumer_wpclientesds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3), "%", "");
         lV118Costumer_wpclientesds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3), "%", "");
         lV119Costumer_wpclientesds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3), "%", "");
         lV119Costumer_wpclientesds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3), "%", "");
         lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3), "%", "");
         lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3), "%", "");
         lV122Costumer_wpclientesds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3), "%", "");
         lV122Costumer_wpclientesds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3), "%", "");
         lV123Costumer_wpclientesds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3), "%", "");
         lV123Costumer_wpclientesds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3), "%", "");
         lV124Costumer_wpclientesds_40_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV124Costumer_wpclientesds_40_tfclienterazaosocial), "%", "");
         lV126Costumer_wpclientesds_42_tfresponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV126Costumer_wpclientesds_42_tfresponsavelnome), "%", "");
         lV128Costumer_wpclientesds_44_tfresponsavelemail = StringUtil.Concat( StringUtil.RTrim( AV128Costumer_wpclientesds_44_tfresponsavelemail), "%", "");
         /* Using cursor P00E43 */
         pr_default.execute(0, new Object[] {AV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, AV133Costumer_wpclientesds_49_tfclientecountnotas_f, AV133Costumer_wpclientesds_49_tfclientecountnotas_f, AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to, AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to, lV88Costumer_wpclientesds_4_clientedocumento1, lV88Costumer_wpclientesds_4_clientedocumento1, lV89Costumer_wpclientesds_5_tipoclientedescricao1, lV89Costumer_wpclientesds_5_tipoclientedescricao1, lV90Costumer_wpclientesds_6_clienteconveniodescricao1, lV90Costumer_wpclientesds_6_clienteconveniodescricao1, lV91Costumer_wpclientesds_7_clientenacionalidadenome1, lV91Costumer_wpclientesds_7_clientenacionalidadenome1, lV92Costumer_wpclientesds_8_clienteprofissaonome1, lV92Costumer_wpclientesds_8_clienteprofissaonome1, lV93Costumer_wpclientesds_9_municipionome1, lV93Costumer_wpclientesds_9_municipionome1, AV94Costumer_wpclientesds_10_bancocodigo1, AV94Costumer_wpclientesds_10_bancocodigo1, AV94Costumer_wpclientesds_10_bancocodigo1, lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1, lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1, lV96Costumer_wpclientesds_12_responsavelprofissaonome1, lV96Costumer_wpclientesds_12_responsavelprofissaonome1, lV97Costumer_wpclientesds_13_responsavelmunicipionome1, lV97Costumer_wpclientesds_13_responsavelmunicipionome1, lV101Costumer_wpclientesds_17_clientedocumento2, lV101Costumer_wpclientesds_17_clientedocumento2, lV102Costumer_wpclientesds_18_tipoclientedescricao2, lV102Costumer_wpclientesds_18_tipoclientedescricao2, lV103Costumer_wpclientesds_19_clienteconveniodescricao2, lV103Costumer_wpclientesds_19_clienteconveniodescricao2, lV104Costumer_wpclientesds_20_clientenacionalidadenome2, lV104Costumer_wpclientesds_20_clientenacionalidadenome2, lV105Costumer_wpclientesds_21_clienteprofissaonome2, lV105Costumer_wpclientesds_21_clienteprofissaonome2, lV106Costumer_wpclientesds_22_municipionome2, lV106Costumer_wpclientesds_22_municipionome2, AV107Costumer_wpclientesds_23_bancocodigo2, AV107Costumer_wpclientesds_23_bancocodigo2, AV107Costumer_wpclientesds_23_bancocodigo2, lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2, lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2, lV109Costumer_wpclientesds_25_responsavelprofissaonome2, lV109Costumer_wpclientesds_25_responsavelprofissaonome2, lV110Costumer_wpclientesds_26_responsavelmunicipionome2, lV110Costumer_wpclientesds_26_responsavelmunicipionome2, lV114Costumer_wpclientesds_30_clientedocumento3, lV114Costumer_wpclientesds_30_clientedocumento3, lV115Costumer_wpclientesds_31_tipoclientedescricao3, lV115Costumer_wpclientesds_31_tipoclientedescricao3, lV116Costumer_wpclientesds_32_clienteconveniodescricao3, lV116Costumer_wpclientesds_32_clienteconveniodescricao3, lV117Costumer_wpclientesds_33_clientenacionalidadenome3, lV117Costumer_wpclientesds_33_clientenacionalidadenome3, lV118Costumer_wpclientesds_34_clienteprofissaonome3, lV118Costumer_wpclientesds_34_clienteprofissaonome3, lV119Costumer_wpclientesds_35_municipionome3, lV119Costumer_wpclientesds_35_municipionome3, AV120Costumer_wpclientesds_36_bancocodigo3, AV120Costumer_wpclientesds_36_bancocodigo3, AV120Costumer_wpclientesds_36_bancocodigo3, lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3, lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3, lV122Costumer_wpclientesds_38_responsavelprofissaonome3, lV122Costumer_wpclientesds_38_responsavelprofissaonome3, lV123Costumer_wpclientesds_39_responsavelmunicipionome3, lV123Costumer_wpclientesds_39_responsavelmunicipionome3, lV124Costumer_wpclientesds_40_tfclienterazaosocial, AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, lV126Costumer_wpclientesds_42_tfresponsavelnome, AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, lV128Costumer_wpclientesds_44_tfresponsavelemail, AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, AV130Costumer_wpclientesds_46_tfclientecreatedat, AV131Costumer_wpclientesds_47_tfclientecreatedat_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKE42 = false;
            A192TipoClienteId = P00E43_A192TipoClienteId[0];
            n192TipoClienteId = P00E43_n192TipoClienteId[0];
            A186MunicipioCodigo = P00E43_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00E43_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00E43_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00E43_n444ResponsavelMunicipio[0];
            A402BancoId = P00E43_A402BancoId[0];
            n402BancoId = P00E43_n402BancoId[0];
            A437ResponsavelNacionalidade = P00E43_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00E43_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00E43_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00E43_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00E43_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00E43_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00E43_A487ClienteProfissao[0];
            n487ClienteProfissao = P00E43_n487ClienteProfissao[0];
            A489ClienteConvenio = P00E43_A489ClienteConvenio[0];
            n489ClienteConvenio = P00E43_n489ClienteConvenio[0];
            A168ClienteId = P00E43_A168ClienteId[0];
            n168ClienteId = P00E43_n168ClienteId[0];
            A170ClienteRazaoSocial = P00E43_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00E43_n170ClienteRazaoSocial[0];
            A793TipoClientePortalPjPf = P00E43_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = P00E43_n793TipoClientePortalPjPf[0];
            A175ClienteCreatedAt = P00E43_A175ClienteCreatedAt[0];
            n175ClienteCreatedAt = P00E43_n175ClienteCreatedAt[0];
            A445ResponsavelMunicipioNome = P00E43_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00E43_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00E43_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00E43_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00E43_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00E43_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00E43_A404BancoCodigo[0];
            n404BancoCodigo = P00E43_n404BancoCodigo[0];
            A187MunicipioNome = P00E43_A187MunicipioNome[0];
            n187MunicipioNome = P00E43_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00E43_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00E43_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00E43_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00E43_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00E43_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00E43_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00E43_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00E43_n193TipoClienteDescricao[0];
            A169ClienteDocumento = P00E43_A169ClienteDocumento[0];
            n169ClienteDocumento = P00E43_n169ClienteDocumento[0];
            A884ClienteSituacao = P00E43_A884ClienteSituacao[0];
            n884ClienteSituacao = P00E43_n884ClienteSituacao[0];
            A456ResponsavelEmail = P00E43_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00E43_n456ResponsavelEmail[0];
            A436ResponsavelNome = P00E43_A436ResponsavelNome[0];
            n436ResponsavelNome = P00E43_n436ResponsavelNome[0];
            A886ClienteCountNotas_F = P00E43_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = P00E43_n886ClienteCountNotas_F[0];
            A793TipoClientePortalPjPf = P00E43_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = P00E43_n793TipoClientePortalPjPf[0];
            A193TipoClienteDescricao = P00E43_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00E43_n193TipoClienteDescricao[0];
            A187MunicipioNome = P00E43_A187MunicipioNome[0];
            n187MunicipioNome = P00E43_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00E43_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00E43_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00E43_A404BancoCodigo[0];
            n404BancoCodigo = P00E43_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00E43_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00E43_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00E43_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00E43_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00E43_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00E43_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00E43_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00E43_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00E43_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00E43_n490ClienteConvenioDescricao[0];
            A886ClienteCountNotas_F = P00E43_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = P00E43_n886ClienteCountNotas_F[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00E43_A170ClienteRazaoSocial[0], A170ClienteRazaoSocial) == 0 ) )
            {
               BRKE42 = false;
               A168ClienteId = P00E43_A168ClienteId[0];
               n168ClienteId = P00E43_n168ClienteId[0];
               AV32count = (long)(AV32count+1);
               BRKE42 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV23SkipItems) )
            {
               AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ClienteRazaoSocial)) ? "<#Empty#>" : A170ClienteRazaoSocial);
               AV29OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")));
               AV28Options.Add(AV27Option, 0);
               AV30OptionsDesc.Add(AV29OptionDesc, 0);
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
            if ( ! BRKE42 )
            {
               BRKE42 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRESPONSAVELNOMEOPTIONS' Routine */
         returnInSub = false;
         AV12TFResponsavelNome = AV22SearchTxt;
         AV13TFResponsavelNome_Sel = "";
         AV85Costumer_wpclientesds_1_filterfulltext = AV44FilterFullText;
         AV86Costumer_wpclientesds_2_dynamicfiltersselector1 = AV45DynamicFiltersSelector1;
         AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 = AV46DynamicFiltersOperator1;
         AV88Costumer_wpclientesds_4_clientedocumento1 = AV47ClienteDocumento1;
         AV89Costumer_wpclientesds_5_tipoclientedescricao1 = AV48TipoClienteDescricao1;
         AV90Costumer_wpclientesds_6_clienteconveniodescricao1 = AV49ClienteConvenioDescricao1;
         AV91Costumer_wpclientesds_7_clientenacionalidadenome1 = AV50ClienteNacionalidadeNome1;
         AV92Costumer_wpclientesds_8_clienteprofissaonome1 = AV51ClienteProfissaoNome1;
         AV93Costumer_wpclientesds_9_municipionome1 = AV52MunicipioNome1;
         AV94Costumer_wpclientesds_10_bancocodigo1 = AV53BancoCodigo1;
         AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = AV54ResponsavelNacionalidadeNome1;
         AV96Costumer_wpclientesds_12_responsavelprofissaonome1 = AV55ResponsavelProfissaoNome1;
         AV97Costumer_wpclientesds_13_responsavelmunicipionome1 = AV56ResponsavelMunicipioNome1;
         AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV99Costumer_wpclientesds_15_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV101Costumer_wpclientesds_17_clientedocumento2 = AV60ClienteDocumento2;
         AV102Costumer_wpclientesds_18_tipoclientedescricao2 = AV61TipoClienteDescricao2;
         AV103Costumer_wpclientesds_19_clienteconveniodescricao2 = AV62ClienteConvenioDescricao2;
         AV104Costumer_wpclientesds_20_clientenacionalidadenome2 = AV63ClienteNacionalidadeNome2;
         AV105Costumer_wpclientesds_21_clienteprofissaonome2 = AV64ClienteProfissaoNome2;
         AV106Costumer_wpclientesds_22_municipionome2 = AV65MunicipioNome2;
         AV107Costumer_wpclientesds_23_bancocodigo2 = AV66BancoCodigo2;
         AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = AV67ResponsavelNacionalidadeNome2;
         AV109Costumer_wpclientesds_25_responsavelprofissaonome2 = AV68ResponsavelProfissaoNome2;
         AV110Costumer_wpclientesds_26_responsavelmunicipionome2 = AV69ResponsavelMunicipioNome2;
         AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 = AV70DynamicFiltersEnabled3;
         AV112Costumer_wpclientesds_28_dynamicfiltersselector3 = AV71DynamicFiltersSelector3;
         AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 = AV72DynamicFiltersOperator3;
         AV114Costumer_wpclientesds_30_clientedocumento3 = AV73ClienteDocumento3;
         AV115Costumer_wpclientesds_31_tipoclientedescricao3 = AV74TipoClienteDescricao3;
         AV116Costumer_wpclientesds_32_clienteconveniodescricao3 = AV75ClienteConvenioDescricao3;
         AV117Costumer_wpclientesds_33_clientenacionalidadenome3 = AV76ClienteNacionalidadeNome3;
         AV118Costumer_wpclientesds_34_clienteprofissaonome3 = AV77ClienteProfissaoNome3;
         AV119Costumer_wpclientesds_35_municipionome3 = AV78MunicipioNome3;
         AV120Costumer_wpclientesds_36_bancocodigo3 = AV79BancoCodigo3;
         AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = AV80ResponsavelNacionalidadeNome3;
         AV122Costumer_wpclientesds_38_responsavelprofissaonome3 = AV81ResponsavelProfissaoNome3;
         AV123Costumer_wpclientesds_39_responsavelmunicipionome3 = AV82ResponsavelMunicipioNome3;
         AV124Costumer_wpclientesds_40_tfclienterazaosocial = AV10TFClienteRazaoSocial;
         AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel = AV11TFClienteRazaoSocial_Sel;
         AV126Costumer_wpclientesds_42_tfresponsavelnome = AV12TFResponsavelNome;
         AV127Costumer_wpclientesds_43_tfresponsavelnome_sel = AV13TFResponsavelNome_Sel;
         AV128Costumer_wpclientesds_44_tfresponsavelemail = AV14TFResponsavelEmail;
         AV129Costumer_wpclientesds_45_tfresponsavelemail_sel = AV15TFResponsavelEmail_Sel;
         AV130Costumer_wpclientesds_46_tfclientecreatedat = AV16TFClienteCreatedAt;
         AV131Costumer_wpclientesds_47_tfclientecreatedat_to = AV17TFClienteCreatedAt_To;
         AV132Costumer_wpclientesds_48_tfclientesituacao_sels = AV19TFClienteSituacao_Sels;
         AV133Costumer_wpclientesds_49_tfclientecountnotas_f = AV20TFClienteCountNotas_F;
         AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = AV21TFClienteCountNotas_F_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A884ClienteSituacao ,
                                              AV132Costumer_wpclientesds_48_tfclientesituacao_sels ,
                                              AV86Costumer_wpclientesds_2_dynamicfiltersselector1 ,
                                              AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 ,
                                              AV88Costumer_wpclientesds_4_clientedocumento1 ,
                                              AV89Costumer_wpclientesds_5_tipoclientedescricao1 ,
                                              AV90Costumer_wpclientesds_6_clienteconveniodescricao1 ,
                                              AV91Costumer_wpclientesds_7_clientenacionalidadenome1 ,
                                              AV92Costumer_wpclientesds_8_clienteprofissaonome1 ,
                                              AV93Costumer_wpclientesds_9_municipionome1 ,
                                              AV94Costumer_wpclientesds_10_bancocodigo1 ,
                                              AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 ,
                                              AV96Costumer_wpclientesds_12_responsavelprofissaonome1 ,
                                              AV97Costumer_wpclientesds_13_responsavelmunicipionome1 ,
                                              AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 ,
                                              AV99Costumer_wpclientesds_15_dynamicfiltersselector2 ,
                                              AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 ,
                                              AV101Costumer_wpclientesds_17_clientedocumento2 ,
                                              AV102Costumer_wpclientesds_18_tipoclientedescricao2 ,
                                              AV103Costumer_wpclientesds_19_clienteconveniodescricao2 ,
                                              AV104Costumer_wpclientesds_20_clientenacionalidadenome2 ,
                                              AV105Costumer_wpclientesds_21_clienteprofissaonome2 ,
                                              AV106Costumer_wpclientesds_22_municipionome2 ,
                                              AV107Costumer_wpclientesds_23_bancocodigo2 ,
                                              AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 ,
                                              AV109Costumer_wpclientesds_25_responsavelprofissaonome2 ,
                                              AV110Costumer_wpclientesds_26_responsavelmunicipionome2 ,
                                              AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 ,
                                              AV112Costumer_wpclientesds_28_dynamicfiltersselector3 ,
                                              AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 ,
                                              AV114Costumer_wpclientesds_30_clientedocumento3 ,
                                              AV115Costumer_wpclientesds_31_tipoclientedescricao3 ,
                                              AV116Costumer_wpclientesds_32_clienteconveniodescricao3 ,
                                              AV117Costumer_wpclientesds_33_clientenacionalidadenome3 ,
                                              AV118Costumer_wpclientesds_34_clienteprofissaonome3 ,
                                              AV119Costumer_wpclientesds_35_municipionome3 ,
                                              AV120Costumer_wpclientesds_36_bancocodigo3 ,
                                              AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 ,
                                              AV122Costumer_wpclientesds_38_responsavelprofissaonome3 ,
                                              AV123Costumer_wpclientesds_39_responsavelmunicipionome3 ,
                                              AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel ,
                                              AV124Costumer_wpclientesds_40_tfclienterazaosocial ,
                                              AV127Costumer_wpclientesds_43_tfresponsavelnome_sel ,
                                              AV126Costumer_wpclientesds_42_tfresponsavelnome ,
                                              AV129Costumer_wpclientesds_45_tfresponsavelemail_sel ,
                                              AV128Costumer_wpclientesds_44_tfresponsavelemail ,
                                              AV130Costumer_wpclientesds_46_tfclientecreatedat ,
                                              AV131Costumer_wpclientesds_47_tfclientecreatedat_to ,
                                              AV132Costumer_wpclientesds_48_tfclientesituacao_sels.Count ,
                                              A169ClienteDocumento ,
                                              A193TipoClienteDescricao ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome ,
                                              A170ClienteRazaoSocial ,
                                              A436ResponsavelNome ,
                                              A456ResponsavelEmail ,
                                              A175ClienteCreatedAt ,
                                              AV85Costumer_wpclientesds_1_filterfulltext ,
                                              A886ClienteCountNotas_F ,
                                              AV133Costumer_wpclientesds_49_tfclientecountnotas_f ,
                                              AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to ,
                                              A793TipoClientePortalPjPf } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV88Costumer_wpclientesds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1), "%", "");
         lV88Costumer_wpclientesds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1), "%", "");
         lV89Costumer_wpclientesds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1), "%", "");
         lV89Costumer_wpclientesds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1), "%", "");
         lV90Costumer_wpclientesds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1), "%", "");
         lV90Costumer_wpclientesds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1), "%", "");
         lV91Costumer_wpclientesds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1), "%", "");
         lV91Costumer_wpclientesds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1), "%", "");
         lV92Costumer_wpclientesds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1), "%", "");
         lV92Costumer_wpclientesds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1), "%", "");
         lV93Costumer_wpclientesds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1), "%", "");
         lV93Costumer_wpclientesds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1), "%", "");
         lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1), "%", "");
         lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1), "%", "");
         lV96Costumer_wpclientesds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1), "%", "");
         lV96Costumer_wpclientesds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1), "%", "");
         lV97Costumer_wpclientesds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1), "%", "");
         lV97Costumer_wpclientesds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1), "%", "");
         lV101Costumer_wpclientesds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2), "%", "");
         lV101Costumer_wpclientesds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2), "%", "");
         lV102Costumer_wpclientesds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2), "%", "");
         lV102Costumer_wpclientesds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2), "%", "");
         lV103Costumer_wpclientesds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2), "%", "");
         lV103Costumer_wpclientesds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2), "%", "");
         lV104Costumer_wpclientesds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2), "%", "");
         lV104Costumer_wpclientesds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2), "%", "");
         lV105Costumer_wpclientesds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2), "%", "");
         lV105Costumer_wpclientesds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2), "%", "");
         lV106Costumer_wpclientesds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2), "%", "");
         lV106Costumer_wpclientesds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2), "%", "");
         lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2), "%", "");
         lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2), "%", "");
         lV109Costumer_wpclientesds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2), "%", "");
         lV109Costumer_wpclientesds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2), "%", "");
         lV110Costumer_wpclientesds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2), "%", "");
         lV110Costumer_wpclientesds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2), "%", "");
         lV114Costumer_wpclientesds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3), "%", "");
         lV114Costumer_wpclientesds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3), "%", "");
         lV115Costumer_wpclientesds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3), "%", "");
         lV115Costumer_wpclientesds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3), "%", "");
         lV116Costumer_wpclientesds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3), "%", "");
         lV116Costumer_wpclientesds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3), "%", "");
         lV117Costumer_wpclientesds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3), "%", "");
         lV117Costumer_wpclientesds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3), "%", "");
         lV118Costumer_wpclientesds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3), "%", "");
         lV118Costumer_wpclientesds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3), "%", "");
         lV119Costumer_wpclientesds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3), "%", "");
         lV119Costumer_wpclientesds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3), "%", "");
         lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3), "%", "");
         lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3), "%", "");
         lV122Costumer_wpclientesds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3), "%", "");
         lV122Costumer_wpclientesds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3), "%", "");
         lV123Costumer_wpclientesds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3), "%", "");
         lV123Costumer_wpclientesds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3), "%", "");
         lV124Costumer_wpclientesds_40_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV124Costumer_wpclientesds_40_tfclienterazaosocial), "%", "");
         lV126Costumer_wpclientesds_42_tfresponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV126Costumer_wpclientesds_42_tfresponsavelnome), "%", "");
         lV128Costumer_wpclientesds_44_tfresponsavelemail = StringUtil.Concat( StringUtil.RTrim( AV128Costumer_wpclientesds_44_tfresponsavelemail), "%", "");
         /* Using cursor P00E45 */
         pr_default.execute(1, new Object[] {AV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, AV133Costumer_wpclientesds_49_tfclientecountnotas_f, AV133Costumer_wpclientesds_49_tfclientecountnotas_f, AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to, AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to, lV88Costumer_wpclientesds_4_clientedocumento1, lV88Costumer_wpclientesds_4_clientedocumento1, lV89Costumer_wpclientesds_5_tipoclientedescricao1, lV89Costumer_wpclientesds_5_tipoclientedescricao1, lV90Costumer_wpclientesds_6_clienteconveniodescricao1, lV90Costumer_wpclientesds_6_clienteconveniodescricao1, lV91Costumer_wpclientesds_7_clientenacionalidadenome1, lV91Costumer_wpclientesds_7_clientenacionalidadenome1, lV92Costumer_wpclientesds_8_clienteprofissaonome1, lV92Costumer_wpclientesds_8_clienteprofissaonome1, lV93Costumer_wpclientesds_9_municipionome1, lV93Costumer_wpclientesds_9_municipionome1, AV94Costumer_wpclientesds_10_bancocodigo1, AV94Costumer_wpclientesds_10_bancocodigo1, AV94Costumer_wpclientesds_10_bancocodigo1, lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1, lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1, lV96Costumer_wpclientesds_12_responsavelprofissaonome1, lV96Costumer_wpclientesds_12_responsavelprofissaonome1, lV97Costumer_wpclientesds_13_responsavelmunicipionome1, lV97Costumer_wpclientesds_13_responsavelmunicipionome1, lV101Costumer_wpclientesds_17_clientedocumento2, lV101Costumer_wpclientesds_17_clientedocumento2, lV102Costumer_wpclientesds_18_tipoclientedescricao2, lV102Costumer_wpclientesds_18_tipoclientedescricao2, lV103Costumer_wpclientesds_19_clienteconveniodescricao2, lV103Costumer_wpclientesds_19_clienteconveniodescricao2, lV104Costumer_wpclientesds_20_clientenacionalidadenome2, lV104Costumer_wpclientesds_20_clientenacionalidadenome2, lV105Costumer_wpclientesds_21_clienteprofissaonome2, lV105Costumer_wpclientesds_21_clienteprofissaonome2, lV106Costumer_wpclientesds_22_municipionome2, lV106Costumer_wpclientesds_22_municipionome2, AV107Costumer_wpclientesds_23_bancocodigo2, AV107Costumer_wpclientesds_23_bancocodigo2, AV107Costumer_wpclientesds_23_bancocodigo2, lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2, lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2, lV109Costumer_wpclientesds_25_responsavelprofissaonome2, lV109Costumer_wpclientesds_25_responsavelprofissaonome2, lV110Costumer_wpclientesds_26_responsavelmunicipionome2, lV110Costumer_wpclientesds_26_responsavelmunicipionome2, lV114Costumer_wpclientesds_30_clientedocumento3, lV114Costumer_wpclientesds_30_clientedocumento3, lV115Costumer_wpclientesds_31_tipoclientedescricao3, lV115Costumer_wpclientesds_31_tipoclientedescricao3, lV116Costumer_wpclientesds_32_clienteconveniodescricao3, lV116Costumer_wpclientesds_32_clienteconveniodescricao3, lV117Costumer_wpclientesds_33_clientenacionalidadenome3, lV117Costumer_wpclientesds_33_clientenacionalidadenome3, lV118Costumer_wpclientesds_34_clienteprofissaonome3, lV118Costumer_wpclientesds_34_clienteprofissaonome3, lV119Costumer_wpclientesds_35_municipionome3, lV119Costumer_wpclientesds_35_municipionome3, AV120Costumer_wpclientesds_36_bancocodigo3, AV120Costumer_wpclientesds_36_bancocodigo3, AV120Costumer_wpclientesds_36_bancocodigo3, lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3, lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3, lV122Costumer_wpclientesds_38_responsavelprofissaonome3, lV122Costumer_wpclientesds_38_responsavelprofissaonome3, lV123Costumer_wpclientesds_39_responsavelmunicipionome3, lV123Costumer_wpclientesds_39_responsavelmunicipionome3, lV124Costumer_wpclientesds_40_tfclienterazaosocial, AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, lV126Costumer_wpclientesds_42_tfresponsavelnome, AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, lV128Costumer_wpclientesds_44_tfresponsavelemail, AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, AV130Costumer_wpclientesds_46_tfclientecreatedat, AV131Costumer_wpclientesds_47_tfclientecreatedat_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKE44 = false;
            A192TipoClienteId = P00E45_A192TipoClienteId[0];
            n192TipoClienteId = P00E45_n192TipoClienteId[0];
            A186MunicipioCodigo = P00E45_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00E45_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00E45_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00E45_n444ResponsavelMunicipio[0];
            A402BancoId = P00E45_A402BancoId[0];
            n402BancoId = P00E45_n402BancoId[0];
            A437ResponsavelNacionalidade = P00E45_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00E45_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00E45_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00E45_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00E45_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00E45_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00E45_A487ClienteProfissao[0];
            n487ClienteProfissao = P00E45_n487ClienteProfissao[0];
            A489ClienteConvenio = P00E45_A489ClienteConvenio[0];
            n489ClienteConvenio = P00E45_n489ClienteConvenio[0];
            A168ClienteId = P00E45_A168ClienteId[0];
            n168ClienteId = P00E45_n168ClienteId[0];
            A436ResponsavelNome = P00E45_A436ResponsavelNome[0];
            n436ResponsavelNome = P00E45_n436ResponsavelNome[0];
            A793TipoClientePortalPjPf = P00E45_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = P00E45_n793TipoClientePortalPjPf[0];
            A175ClienteCreatedAt = P00E45_A175ClienteCreatedAt[0];
            n175ClienteCreatedAt = P00E45_n175ClienteCreatedAt[0];
            A445ResponsavelMunicipioNome = P00E45_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00E45_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00E45_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00E45_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00E45_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00E45_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00E45_A404BancoCodigo[0];
            n404BancoCodigo = P00E45_n404BancoCodigo[0];
            A187MunicipioNome = P00E45_A187MunicipioNome[0];
            n187MunicipioNome = P00E45_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00E45_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00E45_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00E45_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00E45_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00E45_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00E45_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00E45_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00E45_n193TipoClienteDescricao[0];
            A169ClienteDocumento = P00E45_A169ClienteDocumento[0];
            n169ClienteDocumento = P00E45_n169ClienteDocumento[0];
            A884ClienteSituacao = P00E45_A884ClienteSituacao[0];
            n884ClienteSituacao = P00E45_n884ClienteSituacao[0];
            A456ResponsavelEmail = P00E45_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00E45_n456ResponsavelEmail[0];
            A170ClienteRazaoSocial = P00E45_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00E45_n170ClienteRazaoSocial[0];
            A886ClienteCountNotas_F = P00E45_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = P00E45_n886ClienteCountNotas_F[0];
            A793TipoClientePortalPjPf = P00E45_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = P00E45_n793TipoClientePortalPjPf[0];
            A193TipoClienteDescricao = P00E45_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00E45_n193TipoClienteDescricao[0];
            A187MunicipioNome = P00E45_A187MunicipioNome[0];
            n187MunicipioNome = P00E45_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00E45_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00E45_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00E45_A404BancoCodigo[0];
            n404BancoCodigo = P00E45_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00E45_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00E45_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00E45_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00E45_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00E45_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00E45_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00E45_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00E45_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00E45_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00E45_n490ClienteConvenioDescricao[0];
            A886ClienteCountNotas_F = P00E45_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = P00E45_n886ClienteCountNotas_F[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00E45_A436ResponsavelNome[0], A436ResponsavelNome) == 0 ) )
            {
               BRKE44 = false;
               A168ClienteId = P00E45_A168ClienteId[0];
               n168ClienteId = P00E45_n168ClienteId[0];
               AV32count = (long)(AV32count+1);
               BRKE44 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV23SkipItems) )
            {
               AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A436ResponsavelNome)) ? "<#Empty#>" : A436ResponsavelNome);
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
            if ( ! BRKE44 )
            {
               BRKE44 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADRESPONSAVELEMAILOPTIONS' Routine */
         returnInSub = false;
         AV14TFResponsavelEmail = AV22SearchTxt;
         AV15TFResponsavelEmail_Sel = "";
         AV85Costumer_wpclientesds_1_filterfulltext = AV44FilterFullText;
         AV86Costumer_wpclientesds_2_dynamicfiltersselector1 = AV45DynamicFiltersSelector1;
         AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 = AV46DynamicFiltersOperator1;
         AV88Costumer_wpclientesds_4_clientedocumento1 = AV47ClienteDocumento1;
         AV89Costumer_wpclientesds_5_tipoclientedescricao1 = AV48TipoClienteDescricao1;
         AV90Costumer_wpclientesds_6_clienteconveniodescricao1 = AV49ClienteConvenioDescricao1;
         AV91Costumer_wpclientesds_7_clientenacionalidadenome1 = AV50ClienteNacionalidadeNome1;
         AV92Costumer_wpclientesds_8_clienteprofissaonome1 = AV51ClienteProfissaoNome1;
         AV93Costumer_wpclientesds_9_municipionome1 = AV52MunicipioNome1;
         AV94Costumer_wpclientesds_10_bancocodigo1 = AV53BancoCodigo1;
         AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = AV54ResponsavelNacionalidadeNome1;
         AV96Costumer_wpclientesds_12_responsavelprofissaonome1 = AV55ResponsavelProfissaoNome1;
         AV97Costumer_wpclientesds_13_responsavelmunicipionome1 = AV56ResponsavelMunicipioNome1;
         AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV99Costumer_wpclientesds_15_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV101Costumer_wpclientesds_17_clientedocumento2 = AV60ClienteDocumento2;
         AV102Costumer_wpclientesds_18_tipoclientedescricao2 = AV61TipoClienteDescricao2;
         AV103Costumer_wpclientesds_19_clienteconveniodescricao2 = AV62ClienteConvenioDescricao2;
         AV104Costumer_wpclientesds_20_clientenacionalidadenome2 = AV63ClienteNacionalidadeNome2;
         AV105Costumer_wpclientesds_21_clienteprofissaonome2 = AV64ClienteProfissaoNome2;
         AV106Costumer_wpclientesds_22_municipionome2 = AV65MunicipioNome2;
         AV107Costumer_wpclientesds_23_bancocodigo2 = AV66BancoCodigo2;
         AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = AV67ResponsavelNacionalidadeNome2;
         AV109Costumer_wpclientesds_25_responsavelprofissaonome2 = AV68ResponsavelProfissaoNome2;
         AV110Costumer_wpclientesds_26_responsavelmunicipionome2 = AV69ResponsavelMunicipioNome2;
         AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 = AV70DynamicFiltersEnabled3;
         AV112Costumer_wpclientesds_28_dynamicfiltersselector3 = AV71DynamicFiltersSelector3;
         AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 = AV72DynamicFiltersOperator3;
         AV114Costumer_wpclientesds_30_clientedocumento3 = AV73ClienteDocumento3;
         AV115Costumer_wpclientesds_31_tipoclientedescricao3 = AV74TipoClienteDescricao3;
         AV116Costumer_wpclientesds_32_clienteconveniodescricao3 = AV75ClienteConvenioDescricao3;
         AV117Costumer_wpclientesds_33_clientenacionalidadenome3 = AV76ClienteNacionalidadeNome3;
         AV118Costumer_wpclientesds_34_clienteprofissaonome3 = AV77ClienteProfissaoNome3;
         AV119Costumer_wpclientesds_35_municipionome3 = AV78MunicipioNome3;
         AV120Costumer_wpclientesds_36_bancocodigo3 = AV79BancoCodigo3;
         AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = AV80ResponsavelNacionalidadeNome3;
         AV122Costumer_wpclientesds_38_responsavelprofissaonome3 = AV81ResponsavelProfissaoNome3;
         AV123Costumer_wpclientesds_39_responsavelmunicipionome3 = AV82ResponsavelMunicipioNome3;
         AV124Costumer_wpclientesds_40_tfclienterazaosocial = AV10TFClienteRazaoSocial;
         AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel = AV11TFClienteRazaoSocial_Sel;
         AV126Costumer_wpclientesds_42_tfresponsavelnome = AV12TFResponsavelNome;
         AV127Costumer_wpclientesds_43_tfresponsavelnome_sel = AV13TFResponsavelNome_Sel;
         AV128Costumer_wpclientesds_44_tfresponsavelemail = AV14TFResponsavelEmail;
         AV129Costumer_wpclientesds_45_tfresponsavelemail_sel = AV15TFResponsavelEmail_Sel;
         AV130Costumer_wpclientesds_46_tfclientecreatedat = AV16TFClienteCreatedAt;
         AV131Costumer_wpclientesds_47_tfclientecreatedat_to = AV17TFClienteCreatedAt_To;
         AV132Costumer_wpclientesds_48_tfclientesituacao_sels = AV19TFClienteSituacao_Sels;
         AV133Costumer_wpclientesds_49_tfclientecountnotas_f = AV20TFClienteCountNotas_F;
         AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = AV21TFClienteCountNotas_F_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A884ClienteSituacao ,
                                              AV132Costumer_wpclientesds_48_tfclientesituacao_sels ,
                                              AV86Costumer_wpclientesds_2_dynamicfiltersselector1 ,
                                              AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 ,
                                              AV88Costumer_wpclientesds_4_clientedocumento1 ,
                                              AV89Costumer_wpclientesds_5_tipoclientedescricao1 ,
                                              AV90Costumer_wpclientesds_6_clienteconveniodescricao1 ,
                                              AV91Costumer_wpclientesds_7_clientenacionalidadenome1 ,
                                              AV92Costumer_wpclientesds_8_clienteprofissaonome1 ,
                                              AV93Costumer_wpclientesds_9_municipionome1 ,
                                              AV94Costumer_wpclientesds_10_bancocodigo1 ,
                                              AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 ,
                                              AV96Costumer_wpclientesds_12_responsavelprofissaonome1 ,
                                              AV97Costumer_wpclientesds_13_responsavelmunicipionome1 ,
                                              AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 ,
                                              AV99Costumer_wpclientesds_15_dynamicfiltersselector2 ,
                                              AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 ,
                                              AV101Costumer_wpclientesds_17_clientedocumento2 ,
                                              AV102Costumer_wpclientesds_18_tipoclientedescricao2 ,
                                              AV103Costumer_wpclientesds_19_clienteconveniodescricao2 ,
                                              AV104Costumer_wpclientesds_20_clientenacionalidadenome2 ,
                                              AV105Costumer_wpclientesds_21_clienteprofissaonome2 ,
                                              AV106Costumer_wpclientesds_22_municipionome2 ,
                                              AV107Costumer_wpclientesds_23_bancocodigo2 ,
                                              AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 ,
                                              AV109Costumer_wpclientesds_25_responsavelprofissaonome2 ,
                                              AV110Costumer_wpclientesds_26_responsavelmunicipionome2 ,
                                              AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 ,
                                              AV112Costumer_wpclientesds_28_dynamicfiltersselector3 ,
                                              AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 ,
                                              AV114Costumer_wpclientesds_30_clientedocumento3 ,
                                              AV115Costumer_wpclientesds_31_tipoclientedescricao3 ,
                                              AV116Costumer_wpclientesds_32_clienteconveniodescricao3 ,
                                              AV117Costumer_wpclientesds_33_clientenacionalidadenome3 ,
                                              AV118Costumer_wpclientesds_34_clienteprofissaonome3 ,
                                              AV119Costumer_wpclientesds_35_municipionome3 ,
                                              AV120Costumer_wpclientesds_36_bancocodigo3 ,
                                              AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 ,
                                              AV122Costumer_wpclientesds_38_responsavelprofissaonome3 ,
                                              AV123Costumer_wpclientesds_39_responsavelmunicipionome3 ,
                                              AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel ,
                                              AV124Costumer_wpclientesds_40_tfclienterazaosocial ,
                                              AV127Costumer_wpclientesds_43_tfresponsavelnome_sel ,
                                              AV126Costumer_wpclientesds_42_tfresponsavelnome ,
                                              AV129Costumer_wpclientesds_45_tfresponsavelemail_sel ,
                                              AV128Costumer_wpclientesds_44_tfresponsavelemail ,
                                              AV130Costumer_wpclientesds_46_tfclientecreatedat ,
                                              AV131Costumer_wpclientesds_47_tfclientecreatedat_to ,
                                              AV132Costumer_wpclientesds_48_tfclientesituacao_sels.Count ,
                                              A169ClienteDocumento ,
                                              A193TipoClienteDescricao ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome ,
                                              A170ClienteRazaoSocial ,
                                              A436ResponsavelNome ,
                                              A456ResponsavelEmail ,
                                              A175ClienteCreatedAt ,
                                              AV85Costumer_wpclientesds_1_filterfulltext ,
                                              A886ClienteCountNotas_F ,
                                              AV133Costumer_wpclientesds_49_tfclientecountnotas_f ,
                                              AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to ,
                                              A793TipoClientePortalPjPf } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV85Costumer_wpclientesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV85Costumer_wpclientesds_1_filterfulltext), "%", "");
         lV88Costumer_wpclientesds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1), "%", "");
         lV88Costumer_wpclientesds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1), "%", "");
         lV89Costumer_wpclientesds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1), "%", "");
         lV89Costumer_wpclientesds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1), "%", "");
         lV90Costumer_wpclientesds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1), "%", "");
         lV90Costumer_wpclientesds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1), "%", "");
         lV91Costumer_wpclientesds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1), "%", "");
         lV91Costumer_wpclientesds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1), "%", "");
         lV92Costumer_wpclientesds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1), "%", "");
         lV92Costumer_wpclientesds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1), "%", "");
         lV93Costumer_wpclientesds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1), "%", "");
         lV93Costumer_wpclientesds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1), "%", "");
         lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1), "%", "");
         lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1), "%", "");
         lV96Costumer_wpclientesds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1), "%", "");
         lV96Costumer_wpclientesds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1), "%", "");
         lV97Costumer_wpclientesds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1), "%", "");
         lV97Costumer_wpclientesds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1), "%", "");
         lV101Costumer_wpclientesds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2), "%", "");
         lV101Costumer_wpclientesds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2), "%", "");
         lV102Costumer_wpclientesds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2), "%", "");
         lV102Costumer_wpclientesds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2), "%", "");
         lV103Costumer_wpclientesds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2), "%", "");
         lV103Costumer_wpclientesds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2), "%", "");
         lV104Costumer_wpclientesds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2), "%", "");
         lV104Costumer_wpclientesds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2), "%", "");
         lV105Costumer_wpclientesds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2), "%", "");
         lV105Costumer_wpclientesds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2), "%", "");
         lV106Costumer_wpclientesds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2), "%", "");
         lV106Costumer_wpclientesds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2), "%", "");
         lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2), "%", "");
         lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2), "%", "");
         lV109Costumer_wpclientesds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2), "%", "");
         lV109Costumer_wpclientesds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2), "%", "");
         lV110Costumer_wpclientesds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2), "%", "");
         lV110Costumer_wpclientesds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2), "%", "");
         lV114Costumer_wpclientesds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3), "%", "");
         lV114Costumer_wpclientesds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3), "%", "");
         lV115Costumer_wpclientesds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3), "%", "");
         lV115Costumer_wpclientesds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3), "%", "");
         lV116Costumer_wpclientesds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3), "%", "");
         lV116Costumer_wpclientesds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3), "%", "");
         lV117Costumer_wpclientesds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3), "%", "");
         lV117Costumer_wpclientesds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3), "%", "");
         lV118Costumer_wpclientesds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3), "%", "");
         lV118Costumer_wpclientesds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3), "%", "");
         lV119Costumer_wpclientesds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3), "%", "");
         lV119Costumer_wpclientesds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3), "%", "");
         lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3), "%", "");
         lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3), "%", "");
         lV122Costumer_wpclientesds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3), "%", "");
         lV122Costumer_wpclientesds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3), "%", "");
         lV123Costumer_wpclientesds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3), "%", "");
         lV123Costumer_wpclientesds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3), "%", "");
         lV124Costumer_wpclientesds_40_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV124Costumer_wpclientesds_40_tfclienterazaosocial), "%", "");
         lV126Costumer_wpclientesds_42_tfresponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV126Costumer_wpclientesds_42_tfresponsavelnome), "%", "");
         lV128Costumer_wpclientesds_44_tfresponsavelemail = StringUtil.Concat( StringUtil.RTrim( AV128Costumer_wpclientesds_44_tfresponsavelemail), "%", "");
         /* Using cursor P00E47 */
         pr_default.execute(2, new Object[] {AV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, lV85Costumer_wpclientesds_1_filterfulltext, AV133Costumer_wpclientesds_49_tfclientecountnotas_f, AV133Costumer_wpclientesds_49_tfclientecountnotas_f, AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to, AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to, lV88Costumer_wpclientesds_4_clientedocumento1, lV88Costumer_wpclientesds_4_clientedocumento1, lV89Costumer_wpclientesds_5_tipoclientedescricao1, lV89Costumer_wpclientesds_5_tipoclientedescricao1, lV90Costumer_wpclientesds_6_clienteconveniodescricao1, lV90Costumer_wpclientesds_6_clienteconveniodescricao1, lV91Costumer_wpclientesds_7_clientenacionalidadenome1, lV91Costumer_wpclientesds_7_clientenacionalidadenome1, lV92Costumer_wpclientesds_8_clienteprofissaonome1, lV92Costumer_wpclientesds_8_clienteprofissaonome1, lV93Costumer_wpclientesds_9_municipionome1, lV93Costumer_wpclientesds_9_municipionome1, AV94Costumer_wpclientesds_10_bancocodigo1, AV94Costumer_wpclientesds_10_bancocodigo1, AV94Costumer_wpclientesds_10_bancocodigo1, lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1, lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1, lV96Costumer_wpclientesds_12_responsavelprofissaonome1, lV96Costumer_wpclientesds_12_responsavelprofissaonome1, lV97Costumer_wpclientesds_13_responsavelmunicipionome1, lV97Costumer_wpclientesds_13_responsavelmunicipionome1, lV101Costumer_wpclientesds_17_clientedocumento2, lV101Costumer_wpclientesds_17_clientedocumento2, lV102Costumer_wpclientesds_18_tipoclientedescricao2, lV102Costumer_wpclientesds_18_tipoclientedescricao2, lV103Costumer_wpclientesds_19_clienteconveniodescricao2, lV103Costumer_wpclientesds_19_clienteconveniodescricao2, lV104Costumer_wpclientesds_20_clientenacionalidadenome2, lV104Costumer_wpclientesds_20_clientenacionalidadenome2, lV105Costumer_wpclientesds_21_clienteprofissaonome2, lV105Costumer_wpclientesds_21_clienteprofissaonome2, lV106Costumer_wpclientesds_22_municipionome2, lV106Costumer_wpclientesds_22_municipionome2, AV107Costumer_wpclientesds_23_bancocodigo2, AV107Costumer_wpclientesds_23_bancocodigo2, AV107Costumer_wpclientesds_23_bancocodigo2, lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2, lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2, lV109Costumer_wpclientesds_25_responsavelprofissaonome2, lV109Costumer_wpclientesds_25_responsavelprofissaonome2, lV110Costumer_wpclientesds_26_responsavelmunicipionome2, lV110Costumer_wpclientesds_26_responsavelmunicipionome2, lV114Costumer_wpclientesds_30_clientedocumento3, lV114Costumer_wpclientesds_30_clientedocumento3, lV115Costumer_wpclientesds_31_tipoclientedescricao3, lV115Costumer_wpclientesds_31_tipoclientedescricao3, lV116Costumer_wpclientesds_32_clienteconveniodescricao3, lV116Costumer_wpclientesds_32_clienteconveniodescricao3, lV117Costumer_wpclientesds_33_clientenacionalidadenome3, lV117Costumer_wpclientesds_33_clientenacionalidadenome3, lV118Costumer_wpclientesds_34_clienteprofissaonome3, lV118Costumer_wpclientesds_34_clienteprofissaonome3, lV119Costumer_wpclientesds_35_municipionome3, lV119Costumer_wpclientesds_35_municipionome3, AV120Costumer_wpclientesds_36_bancocodigo3, AV120Costumer_wpclientesds_36_bancocodigo3, AV120Costumer_wpclientesds_36_bancocodigo3, lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3, lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3, lV122Costumer_wpclientesds_38_responsavelprofissaonome3, lV122Costumer_wpclientesds_38_responsavelprofissaonome3, lV123Costumer_wpclientesds_39_responsavelmunicipionome3, lV123Costumer_wpclientesds_39_responsavelmunicipionome3, lV124Costumer_wpclientesds_40_tfclienterazaosocial, AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, lV126Costumer_wpclientesds_42_tfresponsavelnome, AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, lV128Costumer_wpclientesds_44_tfresponsavelemail, AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, AV130Costumer_wpclientesds_46_tfclientecreatedat, AV131Costumer_wpclientesds_47_tfclientecreatedat_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKE46 = false;
            A192TipoClienteId = P00E47_A192TipoClienteId[0];
            n192TipoClienteId = P00E47_n192TipoClienteId[0];
            A186MunicipioCodigo = P00E47_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00E47_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00E47_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00E47_n444ResponsavelMunicipio[0];
            A402BancoId = P00E47_A402BancoId[0];
            n402BancoId = P00E47_n402BancoId[0];
            A437ResponsavelNacionalidade = P00E47_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00E47_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00E47_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00E47_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00E47_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00E47_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00E47_A487ClienteProfissao[0];
            n487ClienteProfissao = P00E47_n487ClienteProfissao[0];
            A489ClienteConvenio = P00E47_A489ClienteConvenio[0];
            n489ClienteConvenio = P00E47_n489ClienteConvenio[0];
            A168ClienteId = P00E47_A168ClienteId[0];
            n168ClienteId = P00E47_n168ClienteId[0];
            A456ResponsavelEmail = P00E47_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00E47_n456ResponsavelEmail[0];
            A793TipoClientePortalPjPf = P00E47_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = P00E47_n793TipoClientePortalPjPf[0];
            A175ClienteCreatedAt = P00E47_A175ClienteCreatedAt[0];
            n175ClienteCreatedAt = P00E47_n175ClienteCreatedAt[0];
            A445ResponsavelMunicipioNome = P00E47_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00E47_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00E47_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00E47_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00E47_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00E47_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00E47_A404BancoCodigo[0];
            n404BancoCodigo = P00E47_n404BancoCodigo[0];
            A187MunicipioNome = P00E47_A187MunicipioNome[0];
            n187MunicipioNome = P00E47_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00E47_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00E47_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00E47_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00E47_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00E47_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00E47_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00E47_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00E47_n193TipoClienteDescricao[0];
            A169ClienteDocumento = P00E47_A169ClienteDocumento[0];
            n169ClienteDocumento = P00E47_n169ClienteDocumento[0];
            A884ClienteSituacao = P00E47_A884ClienteSituacao[0];
            n884ClienteSituacao = P00E47_n884ClienteSituacao[0];
            A436ResponsavelNome = P00E47_A436ResponsavelNome[0];
            n436ResponsavelNome = P00E47_n436ResponsavelNome[0];
            A170ClienteRazaoSocial = P00E47_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00E47_n170ClienteRazaoSocial[0];
            A886ClienteCountNotas_F = P00E47_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = P00E47_n886ClienteCountNotas_F[0];
            A793TipoClientePortalPjPf = P00E47_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = P00E47_n793TipoClientePortalPjPf[0];
            A193TipoClienteDescricao = P00E47_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00E47_n193TipoClienteDescricao[0];
            A187MunicipioNome = P00E47_A187MunicipioNome[0];
            n187MunicipioNome = P00E47_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00E47_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00E47_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00E47_A404BancoCodigo[0];
            n404BancoCodigo = P00E47_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00E47_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00E47_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00E47_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00E47_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00E47_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00E47_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00E47_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00E47_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00E47_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00E47_n490ClienteConvenioDescricao[0];
            A886ClienteCountNotas_F = P00E47_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = P00E47_n886ClienteCountNotas_F[0];
            AV32count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00E47_A456ResponsavelEmail[0], A456ResponsavelEmail) == 0 ) )
            {
               BRKE46 = false;
               A168ClienteId = P00E47_A168ClienteId[0];
               n168ClienteId = P00E47_n168ClienteId[0];
               AV32count = (long)(AV32count+1);
               BRKE46 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV23SkipItems) )
            {
               AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A456ResponsavelEmail)) ? "<#Empty#>" : A456ResponsavelEmail);
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
            if ( ! BRKE46 )
            {
               BRKE46 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV10TFClienteRazaoSocial = "";
         AV11TFClienteRazaoSocial_Sel = "";
         AV12TFResponsavelNome = "";
         AV13TFResponsavelNome_Sel = "";
         AV14TFResponsavelEmail = "";
         AV15TFResponsavelEmail_Sel = "";
         AV16TFClienteCreatedAt = (DateTime)(DateTime.MinValue);
         AV17TFClienteCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV18TFClienteSituacao_SelsJson = "";
         AV19TFClienteSituacao_Sels = new GxSimpleCollection<string>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV45DynamicFiltersSelector1 = "";
         AV47ClienteDocumento1 = "";
         AV48TipoClienteDescricao1 = "";
         AV49ClienteConvenioDescricao1 = "";
         AV50ClienteNacionalidadeNome1 = "";
         AV51ClienteProfissaoNome1 = "";
         AV52MunicipioNome1 = "";
         AV54ResponsavelNacionalidadeNome1 = "";
         AV55ResponsavelProfissaoNome1 = "";
         AV56ResponsavelMunicipioNome1 = "";
         AV58DynamicFiltersSelector2 = "";
         AV60ClienteDocumento2 = "";
         AV61TipoClienteDescricao2 = "";
         AV62ClienteConvenioDescricao2 = "";
         AV63ClienteNacionalidadeNome2 = "";
         AV64ClienteProfissaoNome2 = "";
         AV65MunicipioNome2 = "";
         AV67ResponsavelNacionalidadeNome2 = "";
         AV68ResponsavelProfissaoNome2 = "";
         AV69ResponsavelMunicipioNome2 = "";
         AV71DynamicFiltersSelector3 = "";
         AV73ClienteDocumento3 = "";
         AV74TipoClienteDescricao3 = "";
         AV75ClienteConvenioDescricao3 = "";
         AV76ClienteNacionalidadeNome3 = "";
         AV77ClienteProfissaoNome3 = "";
         AV78MunicipioNome3 = "";
         AV80ResponsavelNacionalidadeNome3 = "";
         AV81ResponsavelProfissaoNome3 = "";
         AV82ResponsavelMunicipioNome3 = "";
         AV85Costumer_wpclientesds_1_filterfulltext = "";
         AV86Costumer_wpclientesds_2_dynamicfiltersselector1 = "";
         AV88Costumer_wpclientesds_4_clientedocumento1 = "";
         AV89Costumer_wpclientesds_5_tipoclientedescricao1 = "";
         AV90Costumer_wpclientesds_6_clienteconveniodescricao1 = "";
         AV91Costumer_wpclientesds_7_clientenacionalidadenome1 = "";
         AV92Costumer_wpclientesds_8_clienteprofissaonome1 = "";
         AV93Costumer_wpclientesds_9_municipionome1 = "";
         AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = "";
         AV96Costumer_wpclientesds_12_responsavelprofissaonome1 = "";
         AV97Costumer_wpclientesds_13_responsavelmunicipionome1 = "";
         AV99Costumer_wpclientesds_15_dynamicfiltersselector2 = "";
         AV101Costumer_wpclientesds_17_clientedocumento2 = "";
         AV102Costumer_wpclientesds_18_tipoclientedescricao2 = "";
         AV103Costumer_wpclientesds_19_clienteconveniodescricao2 = "";
         AV104Costumer_wpclientesds_20_clientenacionalidadenome2 = "";
         AV105Costumer_wpclientesds_21_clienteprofissaonome2 = "";
         AV106Costumer_wpclientesds_22_municipionome2 = "";
         AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = "";
         AV109Costumer_wpclientesds_25_responsavelprofissaonome2 = "";
         AV110Costumer_wpclientesds_26_responsavelmunicipionome2 = "";
         AV112Costumer_wpclientesds_28_dynamicfiltersselector3 = "";
         AV114Costumer_wpclientesds_30_clientedocumento3 = "";
         AV115Costumer_wpclientesds_31_tipoclientedescricao3 = "";
         AV116Costumer_wpclientesds_32_clienteconveniodescricao3 = "";
         AV117Costumer_wpclientesds_33_clientenacionalidadenome3 = "";
         AV118Costumer_wpclientesds_34_clienteprofissaonome3 = "";
         AV119Costumer_wpclientesds_35_municipionome3 = "";
         AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = "";
         AV122Costumer_wpclientesds_38_responsavelprofissaonome3 = "";
         AV123Costumer_wpclientesds_39_responsavelmunicipionome3 = "";
         AV124Costumer_wpclientesds_40_tfclienterazaosocial = "";
         AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel = "";
         AV126Costumer_wpclientesds_42_tfresponsavelnome = "";
         AV127Costumer_wpclientesds_43_tfresponsavelnome_sel = "";
         AV128Costumer_wpclientesds_44_tfresponsavelemail = "";
         AV129Costumer_wpclientesds_45_tfresponsavelemail_sel = "";
         AV130Costumer_wpclientesds_46_tfclientecreatedat = (DateTime)(DateTime.MinValue);
         AV131Costumer_wpclientesds_47_tfclientecreatedat_to = (DateTime)(DateTime.MinValue);
         AV132Costumer_wpclientesds_48_tfclientesituacao_sels = new GxSimpleCollection<string>();
         lV85Costumer_wpclientesds_1_filterfulltext = "";
         lV88Costumer_wpclientesds_4_clientedocumento1 = "";
         lV89Costumer_wpclientesds_5_tipoclientedescricao1 = "";
         lV90Costumer_wpclientesds_6_clienteconveniodescricao1 = "";
         lV91Costumer_wpclientesds_7_clientenacionalidadenome1 = "";
         lV92Costumer_wpclientesds_8_clienteprofissaonome1 = "";
         lV93Costumer_wpclientesds_9_municipionome1 = "";
         lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 = "";
         lV96Costumer_wpclientesds_12_responsavelprofissaonome1 = "";
         lV97Costumer_wpclientesds_13_responsavelmunicipionome1 = "";
         lV101Costumer_wpclientesds_17_clientedocumento2 = "";
         lV102Costumer_wpclientesds_18_tipoclientedescricao2 = "";
         lV103Costumer_wpclientesds_19_clienteconveniodescricao2 = "";
         lV104Costumer_wpclientesds_20_clientenacionalidadenome2 = "";
         lV105Costumer_wpclientesds_21_clienteprofissaonome2 = "";
         lV106Costumer_wpclientesds_22_municipionome2 = "";
         lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 = "";
         lV109Costumer_wpclientesds_25_responsavelprofissaonome2 = "";
         lV110Costumer_wpclientesds_26_responsavelmunicipionome2 = "";
         lV114Costumer_wpclientesds_30_clientedocumento3 = "";
         lV115Costumer_wpclientesds_31_tipoclientedescricao3 = "";
         lV116Costumer_wpclientesds_32_clienteconveniodescricao3 = "";
         lV117Costumer_wpclientesds_33_clientenacionalidadenome3 = "";
         lV118Costumer_wpclientesds_34_clienteprofissaonome3 = "";
         lV119Costumer_wpclientesds_35_municipionome3 = "";
         lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 = "";
         lV122Costumer_wpclientesds_38_responsavelprofissaonome3 = "";
         lV123Costumer_wpclientesds_39_responsavelmunicipionome3 = "";
         lV124Costumer_wpclientesds_40_tfclienterazaosocial = "";
         lV126Costumer_wpclientesds_42_tfresponsavelnome = "";
         lV128Costumer_wpclientesds_44_tfresponsavelemail = "";
         A884ClienteSituacao = "";
         A169ClienteDocumento = "";
         A193TipoClienteDescricao = "";
         A490ClienteConvenioDescricao = "";
         A485ClienteNacionalidadeNome = "";
         A488ClienteProfissaoNome = "";
         A187MunicipioNome = "";
         A438ResponsavelNacionalidadeNome = "";
         A443ResponsavelProfissaoNome = "";
         A445ResponsavelMunicipioNome = "";
         A170ClienteRazaoSocial = "";
         A436ResponsavelNome = "";
         A456ResponsavelEmail = "";
         A175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         P00E43_A192TipoClienteId = new short[1] ;
         P00E43_n192TipoClienteId = new bool[] {false} ;
         P00E43_A186MunicipioCodigo = new string[] {""} ;
         P00E43_n186MunicipioCodigo = new bool[] {false} ;
         P00E43_A444ResponsavelMunicipio = new string[] {""} ;
         P00E43_n444ResponsavelMunicipio = new bool[] {false} ;
         P00E43_A402BancoId = new int[1] ;
         P00E43_n402BancoId = new bool[] {false} ;
         P00E43_A437ResponsavelNacionalidade = new int[1] ;
         P00E43_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00E43_A484ClienteNacionalidade = new int[1] ;
         P00E43_n484ClienteNacionalidade = new bool[] {false} ;
         P00E43_A442ResponsavelProfissao = new int[1] ;
         P00E43_n442ResponsavelProfissao = new bool[] {false} ;
         P00E43_A487ClienteProfissao = new int[1] ;
         P00E43_n487ClienteProfissao = new bool[] {false} ;
         P00E43_A489ClienteConvenio = new int[1] ;
         P00E43_n489ClienteConvenio = new bool[] {false} ;
         P00E43_A168ClienteId = new int[1] ;
         P00E43_n168ClienteId = new bool[] {false} ;
         P00E43_A170ClienteRazaoSocial = new string[] {""} ;
         P00E43_n170ClienteRazaoSocial = new bool[] {false} ;
         P00E43_A793TipoClientePortalPjPf = new bool[] {false} ;
         P00E43_n793TipoClientePortalPjPf = new bool[] {false} ;
         P00E43_A175ClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00E43_n175ClienteCreatedAt = new bool[] {false} ;
         P00E43_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00E43_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00E43_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00E43_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00E43_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00E43_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00E43_A404BancoCodigo = new int[1] ;
         P00E43_n404BancoCodigo = new bool[] {false} ;
         P00E43_A187MunicipioNome = new string[] {""} ;
         P00E43_n187MunicipioNome = new bool[] {false} ;
         P00E43_A488ClienteProfissaoNome = new string[] {""} ;
         P00E43_n488ClienteProfissaoNome = new bool[] {false} ;
         P00E43_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00E43_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00E43_A490ClienteConvenioDescricao = new string[] {""} ;
         P00E43_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00E43_A193TipoClienteDescricao = new string[] {""} ;
         P00E43_n193TipoClienteDescricao = new bool[] {false} ;
         P00E43_A169ClienteDocumento = new string[] {""} ;
         P00E43_n169ClienteDocumento = new bool[] {false} ;
         P00E43_A884ClienteSituacao = new string[] {""} ;
         P00E43_n884ClienteSituacao = new bool[] {false} ;
         P00E43_A456ResponsavelEmail = new string[] {""} ;
         P00E43_n456ResponsavelEmail = new bool[] {false} ;
         P00E43_A436ResponsavelNome = new string[] {""} ;
         P00E43_n436ResponsavelNome = new bool[] {false} ;
         P00E43_A886ClienteCountNotas_F = new short[1] ;
         P00E43_n886ClienteCountNotas_F = new bool[] {false} ;
         A186MunicipioCodigo = "";
         A444ResponsavelMunicipio = "";
         AV27Option = "";
         AV29OptionDesc = "";
         P00E45_A192TipoClienteId = new short[1] ;
         P00E45_n192TipoClienteId = new bool[] {false} ;
         P00E45_A186MunicipioCodigo = new string[] {""} ;
         P00E45_n186MunicipioCodigo = new bool[] {false} ;
         P00E45_A444ResponsavelMunicipio = new string[] {""} ;
         P00E45_n444ResponsavelMunicipio = new bool[] {false} ;
         P00E45_A402BancoId = new int[1] ;
         P00E45_n402BancoId = new bool[] {false} ;
         P00E45_A437ResponsavelNacionalidade = new int[1] ;
         P00E45_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00E45_A484ClienteNacionalidade = new int[1] ;
         P00E45_n484ClienteNacionalidade = new bool[] {false} ;
         P00E45_A442ResponsavelProfissao = new int[1] ;
         P00E45_n442ResponsavelProfissao = new bool[] {false} ;
         P00E45_A487ClienteProfissao = new int[1] ;
         P00E45_n487ClienteProfissao = new bool[] {false} ;
         P00E45_A489ClienteConvenio = new int[1] ;
         P00E45_n489ClienteConvenio = new bool[] {false} ;
         P00E45_A168ClienteId = new int[1] ;
         P00E45_n168ClienteId = new bool[] {false} ;
         P00E45_A436ResponsavelNome = new string[] {""} ;
         P00E45_n436ResponsavelNome = new bool[] {false} ;
         P00E45_A793TipoClientePortalPjPf = new bool[] {false} ;
         P00E45_n793TipoClientePortalPjPf = new bool[] {false} ;
         P00E45_A175ClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00E45_n175ClienteCreatedAt = new bool[] {false} ;
         P00E45_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00E45_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00E45_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00E45_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00E45_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00E45_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00E45_A404BancoCodigo = new int[1] ;
         P00E45_n404BancoCodigo = new bool[] {false} ;
         P00E45_A187MunicipioNome = new string[] {""} ;
         P00E45_n187MunicipioNome = new bool[] {false} ;
         P00E45_A488ClienteProfissaoNome = new string[] {""} ;
         P00E45_n488ClienteProfissaoNome = new bool[] {false} ;
         P00E45_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00E45_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00E45_A490ClienteConvenioDescricao = new string[] {""} ;
         P00E45_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00E45_A193TipoClienteDescricao = new string[] {""} ;
         P00E45_n193TipoClienteDescricao = new bool[] {false} ;
         P00E45_A169ClienteDocumento = new string[] {""} ;
         P00E45_n169ClienteDocumento = new bool[] {false} ;
         P00E45_A884ClienteSituacao = new string[] {""} ;
         P00E45_n884ClienteSituacao = new bool[] {false} ;
         P00E45_A456ResponsavelEmail = new string[] {""} ;
         P00E45_n456ResponsavelEmail = new bool[] {false} ;
         P00E45_A170ClienteRazaoSocial = new string[] {""} ;
         P00E45_n170ClienteRazaoSocial = new bool[] {false} ;
         P00E45_A886ClienteCountNotas_F = new short[1] ;
         P00E45_n886ClienteCountNotas_F = new bool[] {false} ;
         P00E47_A192TipoClienteId = new short[1] ;
         P00E47_n192TipoClienteId = new bool[] {false} ;
         P00E47_A186MunicipioCodigo = new string[] {""} ;
         P00E47_n186MunicipioCodigo = new bool[] {false} ;
         P00E47_A444ResponsavelMunicipio = new string[] {""} ;
         P00E47_n444ResponsavelMunicipio = new bool[] {false} ;
         P00E47_A402BancoId = new int[1] ;
         P00E47_n402BancoId = new bool[] {false} ;
         P00E47_A437ResponsavelNacionalidade = new int[1] ;
         P00E47_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00E47_A484ClienteNacionalidade = new int[1] ;
         P00E47_n484ClienteNacionalidade = new bool[] {false} ;
         P00E47_A442ResponsavelProfissao = new int[1] ;
         P00E47_n442ResponsavelProfissao = new bool[] {false} ;
         P00E47_A487ClienteProfissao = new int[1] ;
         P00E47_n487ClienteProfissao = new bool[] {false} ;
         P00E47_A489ClienteConvenio = new int[1] ;
         P00E47_n489ClienteConvenio = new bool[] {false} ;
         P00E47_A168ClienteId = new int[1] ;
         P00E47_n168ClienteId = new bool[] {false} ;
         P00E47_A456ResponsavelEmail = new string[] {""} ;
         P00E47_n456ResponsavelEmail = new bool[] {false} ;
         P00E47_A793TipoClientePortalPjPf = new bool[] {false} ;
         P00E47_n793TipoClientePortalPjPf = new bool[] {false} ;
         P00E47_A175ClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00E47_n175ClienteCreatedAt = new bool[] {false} ;
         P00E47_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00E47_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00E47_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00E47_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00E47_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00E47_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00E47_A404BancoCodigo = new int[1] ;
         P00E47_n404BancoCodigo = new bool[] {false} ;
         P00E47_A187MunicipioNome = new string[] {""} ;
         P00E47_n187MunicipioNome = new bool[] {false} ;
         P00E47_A488ClienteProfissaoNome = new string[] {""} ;
         P00E47_n488ClienteProfissaoNome = new bool[] {false} ;
         P00E47_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00E47_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00E47_A490ClienteConvenioDescricao = new string[] {""} ;
         P00E47_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00E47_A193TipoClienteDescricao = new string[] {""} ;
         P00E47_n193TipoClienteDescricao = new bool[] {false} ;
         P00E47_A169ClienteDocumento = new string[] {""} ;
         P00E47_n169ClienteDocumento = new bool[] {false} ;
         P00E47_A884ClienteSituacao = new string[] {""} ;
         P00E47_n884ClienteSituacao = new bool[] {false} ;
         P00E47_A436ResponsavelNome = new string[] {""} ;
         P00E47_n436ResponsavelNome = new bool[] {false} ;
         P00E47_A170ClienteRazaoSocial = new string[] {""} ;
         P00E47_n170ClienteRazaoSocial = new bool[] {false} ;
         P00E47_A886ClienteCountNotas_F = new short[1] ;
         P00E47_n886ClienteCountNotas_F = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costumer.wpclientesgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00E43_A192TipoClienteId, P00E43_n192TipoClienteId, P00E43_A186MunicipioCodigo, P00E43_n186MunicipioCodigo, P00E43_A444ResponsavelMunicipio, P00E43_n444ResponsavelMunicipio, P00E43_A402BancoId, P00E43_n402BancoId, P00E43_A437ResponsavelNacionalidade, P00E43_n437ResponsavelNacionalidade,
               P00E43_A484ClienteNacionalidade, P00E43_n484ClienteNacionalidade, P00E43_A442ResponsavelProfissao, P00E43_n442ResponsavelProfissao, P00E43_A487ClienteProfissao, P00E43_n487ClienteProfissao, P00E43_A489ClienteConvenio, P00E43_n489ClienteConvenio, P00E43_A168ClienteId, P00E43_A170ClienteRazaoSocial,
               P00E43_n170ClienteRazaoSocial, P00E43_A793TipoClientePortalPjPf, P00E43_n793TipoClientePortalPjPf, P00E43_A175ClienteCreatedAt, P00E43_n175ClienteCreatedAt, P00E43_A445ResponsavelMunicipioNome, P00E43_n445ResponsavelMunicipioNome, P00E43_A443ResponsavelProfissaoNome, P00E43_n443ResponsavelProfissaoNome, P00E43_A438ResponsavelNacionalidadeNome,
               P00E43_n438ResponsavelNacionalidadeNome, P00E43_A404BancoCodigo, P00E43_n404BancoCodigo, P00E43_A187MunicipioNome, P00E43_n187MunicipioNome, P00E43_A488ClienteProfissaoNome, P00E43_n488ClienteProfissaoNome, P00E43_A485ClienteNacionalidadeNome, P00E43_n485ClienteNacionalidadeNome, P00E43_A490ClienteConvenioDescricao,
               P00E43_n490ClienteConvenioDescricao, P00E43_A193TipoClienteDescricao, P00E43_n193TipoClienteDescricao, P00E43_A169ClienteDocumento, P00E43_n169ClienteDocumento, P00E43_A884ClienteSituacao, P00E43_n884ClienteSituacao, P00E43_A456ResponsavelEmail, P00E43_n456ResponsavelEmail, P00E43_A436ResponsavelNome,
               P00E43_n436ResponsavelNome, P00E43_A886ClienteCountNotas_F, P00E43_n886ClienteCountNotas_F
               }
               , new Object[] {
               P00E45_A192TipoClienteId, P00E45_n192TipoClienteId, P00E45_A186MunicipioCodigo, P00E45_n186MunicipioCodigo, P00E45_A444ResponsavelMunicipio, P00E45_n444ResponsavelMunicipio, P00E45_A402BancoId, P00E45_n402BancoId, P00E45_A437ResponsavelNacionalidade, P00E45_n437ResponsavelNacionalidade,
               P00E45_A484ClienteNacionalidade, P00E45_n484ClienteNacionalidade, P00E45_A442ResponsavelProfissao, P00E45_n442ResponsavelProfissao, P00E45_A487ClienteProfissao, P00E45_n487ClienteProfissao, P00E45_A489ClienteConvenio, P00E45_n489ClienteConvenio, P00E45_A168ClienteId, P00E45_A436ResponsavelNome,
               P00E45_n436ResponsavelNome, P00E45_A793TipoClientePortalPjPf, P00E45_n793TipoClientePortalPjPf, P00E45_A175ClienteCreatedAt, P00E45_n175ClienteCreatedAt, P00E45_A445ResponsavelMunicipioNome, P00E45_n445ResponsavelMunicipioNome, P00E45_A443ResponsavelProfissaoNome, P00E45_n443ResponsavelProfissaoNome, P00E45_A438ResponsavelNacionalidadeNome,
               P00E45_n438ResponsavelNacionalidadeNome, P00E45_A404BancoCodigo, P00E45_n404BancoCodigo, P00E45_A187MunicipioNome, P00E45_n187MunicipioNome, P00E45_A488ClienteProfissaoNome, P00E45_n488ClienteProfissaoNome, P00E45_A485ClienteNacionalidadeNome, P00E45_n485ClienteNacionalidadeNome, P00E45_A490ClienteConvenioDescricao,
               P00E45_n490ClienteConvenioDescricao, P00E45_A193TipoClienteDescricao, P00E45_n193TipoClienteDescricao, P00E45_A169ClienteDocumento, P00E45_n169ClienteDocumento, P00E45_A884ClienteSituacao, P00E45_n884ClienteSituacao, P00E45_A456ResponsavelEmail, P00E45_n456ResponsavelEmail, P00E45_A170ClienteRazaoSocial,
               P00E45_n170ClienteRazaoSocial, P00E45_A886ClienteCountNotas_F, P00E45_n886ClienteCountNotas_F
               }
               , new Object[] {
               P00E47_A192TipoClienteId, P00E47_n192TipoClienteId, P00E47_A186MunicipioCodigo, P00E47_n186MunicipioCodigo, P00E47_A444ResponsavelMunicipio, P00E47_n444ResponsavelMunicipio, P00E47_A402BancoId, P00E47_n402BancoId, P00E47_A437ResponsavelNacionalidade, P00E47_n437ResponsavelNacionalidade,
               P00E47_A484ClienteNacionalidade, P00E47_n484ClienteNacionalidade, P00E47_A442ResponsavelProfissao, P00E47_n442ResponsavelProfissao, P00E47_A487ClienteProfissao, P00E47_n487ClienteProfissao, P00E47_A489ClienteConvenio, P00E47_n489ClienteConvenio, P00E47_A168ClienteId, P00E47_A456ResponsavelEmail,
               P00E47_n456ResponsavelEmail, P00E47_A793TipoClientePortalPjPf, P00E47_n793TipoClientePortalPjPf, P00E47_A175ClienteCreatedAt, P00E47_n175ClienteCreatedAt, P00E47_A445ResponsavelMunicipioNome, P00E47_n445ResponsavelMunicipioNome, P00E47_A443ResponsavelProfissaoNome, P00E47_n443ResponsavelProfissaoNome, P00E47_A438ResponsavelNacionalidadeNome,
               P00E47_n438ResponsavelNacionalidadeNome, P00E47_A404BancoCodigo, P00E47_n404BancoCodigo, P00E47_A187MunicipioNome, P00E47_n187MunicipioNome, P00E47_A488ClienteProfissaoNome, P00E47_n488ClienteProfissaoNome, P00E47_A485ClienteNacionalidadeNome, P00E47_n485ClienteNacionalidadeNome, P00E47_A490ClienteConvenioDescricao,
               P00E47_n490ClienteConvenioDescricao, P00E47_A193TipoClienteDescricao, P00E47_n193TipoClienteDescricao, P00E47_A169ClienteDocumento, P00E47_n169ClienteDocumento, P00E47_A884ClienteSituacao, P00E47_n884ClienteSituacao, P00E47_A436ResponsavelNome, P00E47_n436ResponsavelNome, P00E47_A170ClienteRazaoSocial,
               P00E47_n170ClienteRazaoSocial, P00E47_A886ClienteCountNotas_F, P00E47_n886ClienteCountNotas_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV25MaxItems ;
      private short AV24PageIndex ;
      private short AV23SkipItems ;
      private short AV20TFClienteCountNotas_F ;
      private short AV21TFClienteCountNotas_F_To ;
      private short AV46DynamicFiltersOperator1 ;
      private short AV59DynamicFiltersOperator2 ;
      private short AV72DynamicFiltersOperator3 ;
      private short AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 ;
      private short AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 ;
      private short AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 ;
      private short AV133Costumer_wpclientesds_49_tfclientecountnotas_f ;
      private short AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to ;
      private short A886ClienteCountNotas_F ;
      private short A192TipoClienteId ;
      private int AV83GXV1 ;
      private int AV53BancoCodigo1 ;
      private int AV66BancoCodigo2 ;
      private int AV79BancoCodigo3 ;
      private int AV94Costumer_wpclientesds_10_bancocodigo1 ;
      private int AV107Costumer_wpclientesds_23_bancocodigo2 ;
      private int AV120Costumer_wpclientesds_36_bancocodigo3 ;
      private int AV132Costumer_wpclientesds_48_tfclientesituacao_sels_Count ;
      private int A404BancoCodigo ;
      private int A402BancoId ;
      private int A437ResponsavelNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int A442ResponsavelProfissao ;
      private int A487ClienteProfissao ;
      private int A489ClienteConvenio ;
      private int A168ClienteId ;
      private long AV32count ;
      private string A884ClienteSituacao ;
      private DateTime AV16TFClienteCreatedAt ;
      private DateTime AV17TFClienteCreatedAt_To ;
      private DateTime AV130Costumer_wpclientesds_46_tfclientecreatedat ;
      private DateTime AV131Costumer_wpclientesds_47_tfclientecreatedat_to ;
      private DateTime A175ClienteCreatedAt ;
      private bool returnInSub ;
      private bool AV57DynamicFiltersEnabled2 ;
      private bool AV70DynamicFiltersEnabled3 ;
      private bool AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 ;
      private bool AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 ;
      private bool A793TipoClientePortalPjPf ;
      private bool BRKE42 ;
      private bool n192TipoClienteId ;
      private bool n186MunicipioCodigo ;
      private bool n444ResponsavelMunicipio ;
      private bool n402BancoId ;
      private bool n437ResponsavelNacionalidade ;
      private bool n484ClienteNacionalidade ;
      private bool n442ResponsavelProfissao ;
      private bool n487ClienteProfissao ;
      private bool n489ClienteConvenio ;
      private bool n168ClienteId ;
      private bool n170ClienteRazaoSocial ;
      private bool n793TipoClientePortalPjPf ;
      private bool n175ClienteCreatedAt ;
      private bool n445ResponsavelMunicipioNome ;
      private bool n443ResponsavelProfissaoNome ;
      private bool n438ResponsavelNacionalidadeNome ;
      private bool n404BancoCodigo ;
      private bool n187MunicipioNome ;
      private bool n488ClienteProfissaoNome ;
      private bool n485ClienteNacionalidadeNome ;
      private bool n490ClienteConvenioDescricao ;
      private bool n193TipoClienteDescricao ;
      private bool n169ClienteDocumento ;
      private bool n884ClienteSituacao ;
      private bool n456ResponsavelEmail ;
      private bool n436ResponsavelNome ;
      private bool n886ClienteCountNotas_F ;
      private bool BRKE44 ;
      private bool BRKE46 ;
      private string AV41OptionsJson ;
      private string AV42OptionsDescJson ;
      private string AV43OptionIndexesJson ;
      private string AV18TFClienteSituacao_SelsJson ;
      private string AV38DDOName ;
      private string AV39SearchTxtParms ;
      private string AV40SearchTxtTo ;
      private string AV22SearchTxt ;
      private string AV44FilterFullText ;
      private string AV10TFClienteRazaoSocial ;
      private string AV11TFClienteRazaoSocial_Sel ;
      private string AV12TFResponsavelNome ;
      private string AV13TFResponsavelNome_Sel ;
      private string AV14TFResponsavelEmail ;
      private string AV15TFResponsavelEmail_Sel ;
      private string AV45DynamicFiltersSelector1 ;
      private string AV47ClienteDocumento1 ;
      private string AV48TipoClienteDescricao1 ;
      private string AV49ClienteConvenioDescricao1 ;
      private string AV50ClienteNacionalidadeNome1 ;
      private string AV51ClienteProfissaoNome1 ;
      private string AV52MunicipioNome1 ;
      private string AV54ResponsavelNacionalidadeNome1 ;
      private string AV55ResponsavelProfissaoNome1 ;
      private string AV56ResponsavelMunicipioNome1 ;
      private string AV58DynamicFiltersSelector2 ;
      private string AV60ClienteDocumento2 ;
      private string AV61TipoClienteDescricao2 ;
      private string AV62ClienteConvenioDescricao2 ;
      private string AV63ClienteNacionalidadeNome2 ;
      private string AV64ClienteProfissaoNome2 ;
      private string AV65MunicipioNome2 ;
      private string AV67ResponsavelNacionalidadeNome2 ;
      private string AV68ResponsavelProfissaoNome2 ;
      private string AV69ResponsavelMunicipioNome2 ;
      private string AV71DynamicFiltersSelector3 ;
      private string AV73ClienteDocumento3 ;
      private string AV74TipoClienteDescricao3 ;
      private string AV75ClienteConvenioDescricao3 ;
      private string AV76ClienteNacionalidadeNome3 ;
      private string AV77ClienteProfissaoNome3 ;
      private string AV78MunicipioNome3 ;
      private string AV80ResponsavelNacionalidadeNome3 ;
      private string AV81ResponsavelProfissaoNome3 ;
      private string AV82ResponsavelMunicipioNome3 ;
      private string AV85Costumer_wpclientesds_1_filterfulltext ;
      private string AV86Costumer_wpclientesds_2_dynamicfiltersselector1 ;
      private string AV88Costumer_wpclientesds_4_clientedocumento1 ;
      private string AV89Costumer_wpclientesds_5_tipoclientedescricao1 ;
      private string AV90Costumer_wpclientesds_6_clienteconveniodescricao1 ;
      private string AV91Costumer_wpclientesds_7_clientenacionalidadenome1 ;
      private string AV92Costumer_wpclientesds_8_clienteprofissaonome1 ;
      private string AV93Costumer_wpclientesds_9_municipionome1 ;
      private string AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 ;
      private string AV96Costumer_wpclientesds_12_responsavelprofissaonome1 ;
      private string AV97Costumer_wpclientesds_13_responsavelmunicipionome1 ;
      private string AV99Costumer_wpclientesds_15_dynamicfiltersselector2 ;
      private string AV101Costumer_wpclientesds_17_clientedocumento2 ;
      private string AV102Costumer_wpclientesds_18_tipoclientedescricao2 ;
      private string AV103Costumer_wpclientesds_19_clienteconveniodescricao2 ;
      private string AV104Costumer_wpclientesds_20_clientenacionalidadenome2 ;
      private string AV105Costumer_wpclientesds_21_clienteprofissaonome2 ;
      private string AV106Costumer_wpclientesds_22_municipionome2 ;
      private string AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 ;
      private string AV109Costumer_wpclientesds_25_responsavelprofissaonome2 ;
      private string AV110Costumer_wpclientesds_26_responsavelmunicipionome2 ;
      private string AV112Costumer_wpclientesds_28_dynamicfiltersselector3 ;
      private string AV114Costumer_wpclientesds_30_clientedocumento3 ;
      private string AV115Costumer_wpclientesds_31_tipoclientedescricao3 ;
      private string AV116Costumer_wpclientesds_32_clienteconveniodescricao3 ;
      private string AV117Costumer_wpclientesds_33_clientenacionalidadenome3 ;
      private string AV118Costumer_wpclientesds_34_clienteprofissaonome3 ;
      private string AV119Costumer_wpclientesds_35_municipionome3 ;
      private string AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 ;
      private string AV122Costumer_wpclientesds_38_responsavelprofissaonome3 ;
      private string AV123Costumer_wpclientesds_39_responsavelmunicipionome3 ;
      private string AV124Costumer_wpclientesds_40_tfclienterazaosocial ;
      private string AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel ;
      private string AV126Costumer_wpclientesds_42_tfresponsavelnome ;
      private string AV127Costumer_wpclientesds_43_tfresponsavelnome_sel ;
      private string AV128Costumer_wpclientesds_44_tfresponsavelemail ;
      private string AV129Costumer_wpclientesds_45_tfresponsavelemail_sel ;
      private string lV85Costumer_wpclientesds_1_filterfulltext ;
      private string lV88Costumer_wpclientesds_4_clientedocumento1 ;
      private string lV89Costumer_wpclientesds_5_tipoclientedescricao1 ;
      private string lV90Costumer_wpclientesds_6_clienteconveniodescricao1 ;
      private string lV91Costumer_wpclientesds_7_clientenacionalidadenome1 ;
      private string lV92Costumer_wpclientesds_8_clienteprofissaonome1 ;
      private string lV93Costumer_wpclientesds_9_municipionome1 ;
      private string lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 ;
      private string lV96Costumer_wpclientesds_12_responsavelprofissaonome1 ;
      private string lV97Costumer_wpclientesds_13_responsavelmunicipionome1 ;
      private string lV101Costumer_wpclientesds_17_clientedocumento2 ;
      private string lV102Costumer_wpclientesds_18_tipoclientedescricao2 ;
      private string lV103Costumer_wpclientesds_19_clienteconveniodescricao2 ;
      private string lV104Costumer_wpclientesds_20_clientenacionalidadenome2 ;
      private string lV105Costumer_wpclientesds_21_clienteprofissaonome2 ;
      private string lV106Costumer_wpclientesds_22_municipionome2 ;
      private string lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 ;
      private string lV109Costumer_wpclientesds_25_responsavelprofissaonome2 ;
      private string lV110Costumer_wpclientesds_26_responsavelmunicipionome2 ;
      private string lV114Costumer_wpclientesds_30_clientedocumento3 ;
      private string lV115Costumer_wpclientesds_31_tipoclientedescricao3 ;
      private string lV116Costumer_wpclientesds_32_clienteconveniodescricao3 ;
      private string lV117Costumer_wpclientesds_33_clientenacionalidadenome3 ;
      private string lV118Costumer_wpclientesds_34_clienteprofissaonome3 ;
      private string lV119Costumer_wpclientesds_35_municipionome3 ;
      private string lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 ;
      private string lV122Costumer_wpclientesds_38_responsavelprofissaonome3 ;
      private string lV123Costumer_wpclientesds_39_responsavelmunicipionome3 ;
      private string lV124Costumer_wpclientesds_40_tfclienterazaosocial ;
      private string lV126Costumer_wpclientesds_42_tfresponsavelnome ;
      private string lV128Costumer_wpclientesds_44_tfresponsavelemail ;
      private string A169ClienteDocumento ;
      private string A193TipoClienteDescricao ;
      private string A490ClienteConvenioDescricao ;
      private string A485ClienteNacionalidadeNome ;
      private string A488ClienteProfissaoNome ;
      private string A187MunicipioNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string A443ResponsavelProfissaoNome ;
      private string A445ResponsavelMunicipioNome ;
      private string A170ClienteRazaoSocial ;
      private string A436ResponsavelNome ;
      private string A456ResponsavelEmail ;
      private string A186MunicipioCodigo ;
      private string A444ResponsavelMunicipio ;
      private string AV27Option ;
      private string AV29OptionDesc ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV28Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV31OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GxSimpleCollection<string> AV19TFClienteSituacao_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV37GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV132Costumer_wpclientesds_48_tfclientesituacao_sels ;
      private IDataStoreProvider pr_default ;
      private short[] P00E43_A192TipoClienteId ;
      private bool[] P00E43_n192TipoClienteId ;
      private string[] P00E43_A186MunicipioCodigo ;
      private bool[] P00E43_n186MunicipioCodigo ;
      private string[] P00E43_A444ResponsavelMunicipio ;
      private bool[] P00E43_n444ResponsavelMunicipio ;
      private int[] P00E43_A402BancoId ;
      private bool[] P00E43_n402BancoId ;
      private int[] P00E43_A437ResponsavelNacionalidade ;
      private bool[] P00E43_n437ResponsavelNacionalidade ;
      private int[] P00E43_A484ClienteNacionalidade ;
      private bool[] P00E43_n484ClienteNacionalidade ;
      private int[] P00E43_A442ResponsavelProfissao ;
      private bool[] P00E43_n442ResponsavelProfissao ;
      private int[] P00E43_A487ClienteProfissao ;
      private bool[] P00E43_n487ClienteProfissao ;
      private int[] P00E43_A489ClienteConvenio ;
      private bool[] P00E43_n489ClienteConvenio ;
      private int[] P00E43_A168ClienteId ;
      private bool[] P00E43_n168ClienteId ;
      private string[] P00E43_A170ClienteRazaoSocial ;
      private bool[] P00E43_n170ClienteRazaoSocial ;
      private bool[] P00E43_A793TipoClientePortalPjPf ;
      private bool[] P00E43_n793TipoClientePortalPjPf ;
      private DateTime[] P00E43_A175ClienteCreatedAt ;
      private bool[] P00E43_n175ClienteCreatedAt ;
      private string[] P00E43_A445ResponsavelMunicipioNome ;
      private bool[] P00E43_n445ResponsavelMunicipioNome ;
      private string[] P00E43_A443ResponsavelProfissaoNome ;
      private bool[] P00E43_n443ResponsavelProfissaoNome ;
      private string[] P00E43_A438ResponsavelNacionalidadeNome ;
      private bool[] P00E43_n438ResponsavelNacionalidadeNome ;
      private int[] P00E43_A404BancoCodigo ;
      private bool[] P00E43_n404BancoCodigo ;
      private string[] P00E43_A187MunicipioNome ;
      private bool[] P00E43_n187MunicipioNome ;
      private string[] P00E43_A488ClienteProfissaoNome ;
      private bool[] P00E43_n488ClienteProfissaoNome ;
      private string[] P00E43_A485ClienteNacionalidadeNome ;
      private bool[] P00E43_n485ClienteNacionalidadeNome ;
      private string[] P00E43_A490ClienteConvenioDescricao ;
      private bool[] P00E43_n490ClienteConvenioDescricao ;
      private string[] P00E43_A193TipoClienteDescricao ;
      private bool[] P00E43_n193TipoClienteDescricao ;
      private string[] P00E43_A169ClienteDocumento ;
      private bool[] P00E43_n169ClienteDocumento ;
      private string[] P00E43_A884ClienteSituacao ;
      private bool[] P00E43_n884ClienteSituacao ;
      private string[] P00E43_A456ResponsavelEmail ;
      private bool[] P00E43_n456ResponsavelEmail ;
      private string[] P00E43_A436ResponsavelNome ;
      private bool[] P00E43_n436ResponsavelNome ;
      private short[] P00E43_A886ClienteCountNotas_F ;
      private bool[] P00E43_n886ClienteCountNotas_F ;
      private short[] P00E45_A192TipoClienteId ;
      private bool[] P00E45_n192TipoClienteId ;
      private string[] P00E45_A186MunicipioCodigo ;
      private bool[] P00E45_n186MunicipioCodigo ;
      private string[] P00E45_A444ResponsavelMunicipio ;
      private bool[] P00E45_n444ResponsavelMunicipio ;
      private int[] P00E45_A402BancoId ;
      private bool[] P00E45_n402BancoId ;
      private int[] P00E45_A437ResponsavelNacionalidade ;
      private bool[] P00E45_n437ResponsavelNacionalidade ;
      private int[] P00E45_A484ClienteNacionalidade ;
      private bool[] P00E45_n484ClienteNacionalidade ;
      private int[] P00E45_A442ResponsavelProfissao ;
      private bool[] P00E45_n442ResponsavelProfissao ;
      private int[] P00E45_A487ClienteProfissao ;
      private bool[] P00E45_n487ClienteProfissao ;
      private int[] P00E45_A489ClienteConvenio ;
      private bool[] P00E45_n489ClienteConvenio ;
      private int[] P00E45_A168ClienteId ;
      private bool[] P00E45_n168ClienteId ;
      private string[] P00E45_A436ResponsavelNome ;
      private bool[] P00E45_n436ResponsavelNome ;
      private bool[] P00E45_A793TipoClientePortalPjPf ;
      private bool[] P00E45_n793TipoClientePortalPjPf ;
      private DateTime[] P00E45_A175ClienteCreatedAt ;
      private bool[] P00E45_n175ClienteCreatedAt ;
      private string[] P00E45_A445ResponsavelMunicipioNome ;
      private bool[] P00E45_n445ResponsavelMunicipioNome ;
      private string[] P00E45_A443ResponsavelProfissaoNome ;
      private bool[] P00E45_n443ResponsavelProfissaoNome ;
      private string[] P00E45_A438ResponsavelNacionalidadeNome ;
      private bool[] P00E45_n438ResponsavelNacionalidadeNome ;
      private int[] P00E45_A404BancoCodigo ;
      private bool[] P00E45_n404BancoCodigo ;
      private string[] P00E45_A187MunicipioNome ;
      private bool[] P00E45_n187MunicipioNome ;
      private string[] P00E45_A488ClienteProfissaoNome ;
      private bool[] P00E45_n488ClienteProfissaoNome ;
      private string[] P00E45_A485ClienteNacionalidadeNome ;
      private bool[] P00E45_n485ClienteNacionalidadeNome ;
      private string[] P00E45_A490ClienteConvenioDescricao ;
      private bool[] P00E45_n490ClienteConvenioDescricao ;
      private string[] P00E45_A193TipoClienteDescricao ;
      private bool[] P00E45_n193TipoClienteDescricao ;
      private string[] P00E45_A169ClienteDocumento ;
      private bool[] P00E45_n169ClienteDocumento ;
      private string[] P00E45_A884ClienteSituacao ;
      private bool[] P00E45_n884ClienteSituacao ;
      private string[] P00E45_A456ResponsavelEmail ;
      private bool[] P00E45_n456ResponsavelEmail ;
      private string[] P00E45_A170ClienteRazaoSocial ;
      private bool[] P00E45_n170ClienteRazaoSocial ;
      private short[] P00E45_A886ClienteCountNotas_F ;
      private bool[] P00E45_n886ClienteCountNotas_F ;
      private short[] P00E47_A192TipoClienteId ;
      private bool[] P00E47_n192TipoClienteId ;
      private string[] P00E47_A186MunicipioCodigo ;
      private bool[] P00E47_n186MunicipioCodigo ;
      private string[] P00E47_A444ResponsavelMunicipio ;
      private bool[] P00E47_n444ResponsavelMunicipio ;
      private int[] P00E47_A402BancoId ;
      private bool[] P00E47_n402BancoId ;
      private int[] P00E47_A437ResponsavelNacionalidade ;
      private bool[] P00E47_n437ResponsavelNacionalidade ;
      private int[] P00E47_A484ClienteNacionalidade ;
      private bool[] P00E47_n484ClienteNacionalidade ;
      private int[] P00E47_A442ResponsavelProfissao ;
      private bool[] P00E47_n442ResponsavelProfissao ;
      private int[] P00E47_A487ClienteProfissao ;
      private bool[] P00E47_n487ClienteProfissao ;
      private int[] P00E47_A489ClienteConvenio ;
      private bool[] P00E47_n489ClienteConvenio ;
      private int[] P00E47_A168ClienteId ;
      private bool[] P00E47_n168ClienteId ;
      private string[] P00E47_A456ResponsavelEmail ;
      private bool[] P00E47_n456ResponsavelEmail ;
      private bool[] P00E47_A793TipoClientePortalPjPf ;
      private bool[] P00E47_n793TipoClientePortalPjPf ;
      private DateTime[] P00E47_A175ClienteCreatedAt ;
      private bool[] P00E47_n175ClienteCreatedAt ;
      private string[] P00E47_A445ResponsavelMunicipioNome ;
      private bool[] P00E47_n445ResponsavelMunicipioNome ;
      private string[] P00E47_A443ResponsavelProfissaoNome ;
      private bool[] P00E47_n443ResponsavelProfissaoNome ;
      private string[] P00E47_A438ResponsavelNacionalidadeNome ;
      private bool[] P00E47_n438ResponsavelNacionalidadeNome ;
      private int[] P00E47_A404BancoCodigo ;
      private bool[] P00E47_n404BancoCodigo ;
      private string[] P00E47_A187MunicipioNome ;
      private bool[] P00E47_n187MunicipioNome ;
      private string[] P00E47_A488ClienteProfissaoNome ;
      private bool[] P00E47_n488ClienteProfissaoNome ;
      private string[] P00E47_A485ClienteNacionalidadeNome ;
      private bool[] P00E47_n485ClienteNacionalidadeNome ;
      private string[] P00E47_A490ClienteConvenioDescricao ;
      private bool[] P00E47_n490ClienteConvenioDescricao ;
      private string[] P00E47_A193TipoClienteDescricao ;
      private bool[] P00E47_n193TipoClienteDescricao ;
      private string[] P00E47_A169ClienteDocumento ;
      private bool[] P00E47_n169ClienteDocumento ;
      private string[] P00E47_A884ClienteSituacao ;
      private bool[] P00E47_n884ClienteSituacao ;
      private string[] P00E47_A436ResponsavelNome ;
      private bool[] P00E47_n436ResponsavelNome ;
      private string[] P00E47_A170ClienteRazaoSocial ;
      private bool[] P00E47_n170ClienteRazaoSocial ;
      private short[] P00E47_A886ClienteCountNotas_F ;
      private bool[] P00E47_n886ClienteCountNotas_F ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wpclientesgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00E43( IGxContext context ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV132Costumer_wpclientesds_48_tfclientesituacao_sels ,
                                             string AV86Costumer_wpclientesds_2_dynamicfiltersselector1 ,
                                             short AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 ,
                                             string AV88Costumer_wpclientesds_4_clientedocumento1 ,
                                             string AV89Costumer_wpclientesds_5_tipoclientedescricao1 ,
                                             string AV90Costumer_wpclientesds_6_clienteconveniodescricao1 ,
                                             string AV91Costumer_wpclientesds_7_clientenacionalidadenome1 ,
                                             string AV92Costumer_wpclientesds_8_clienteprofissaonome1 ,
                                             string AV93Costumer_wpclientesds_9_municipionome1 ,
                                             int AV94Costumer_wpclientesds_10_bancocodigo1 ,
                                             string AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 ,
                                             string AV96Costumer_wpclientesds_12_responsavelprofissaonome1 ,
                                             string AV97Costumer_wpclientesds_13_responsavelmunicipionome1 ,
                                             bool AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 ,
                                             string AV99Costumer_wpclientesds_15_dynamicfiltersselector2 ,
                                             short AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 ,
                                             string AV101Costumer_wpclientesds_17_clientedocumento2 ,
                                             string AV102Costumer_wpclientesds_18_tipoclientedescricao2 ,
                                             string AV103Costumer_wpclientesds_19_clienteconveniodescricao2 ,
                                             string AV104Costumer_wpclientesds_20_clientenacionalidadenome2 ,
                                             string AV105Costumer_wpclientesds_21_clienteprofissaonome2 ,
                                             string AV106Costumer_wpclientesds_22_municipionome2 ,
                                             int AV107Costumer_wpclientesds_23_bancocodigo2 ,
                                             string AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 ,
                                             string AV109Costumer_wpclientesds_25_responsavelprofissaonome2 ,
                                             string AV110Costumer_wpclientesds_26_responsavelmunicipionome2 ,
                                             bool AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 ,
                                             string AV112Costumer_wpclientesds_28_dynamicfiltersselector3 ,
                                             short AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 ,
                                             string AV114Costumer_wpclientesds_30_clientedocumento3 ,
                                             string AV115Costumer_wpclientesds_31_tipoclientedescricao3 ,
                                             string AV116Costumer_wpclientesds_32_clienteconveniodescricao3 ,
                                             string AV117Costumer_wpclientesds_33_clientenacionalidadenome3 ,
                                             string AV118Costumer_wpclientesds_34_clienteprofissaonome3 ,
                                             string AV119Costumer_wpclientesds_35_municipionome3 ,
                                             int AV120Costumer_wpclientesds_36_bancocodigo3 ,
                                             string AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 ,
                                             string AV122Costumer_wpclientesds_38_responsavelprofissaonome3 ,
                                             string AV123Costumer_wpclientesds_39_responsavelmunicipionome3 ,
                                             string AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel ,
                                             string AV124Costumer_wpclientesds_40_tfclienterazaosocial ,
                                             string AV127Costumer_wpclientesds_43_tfresponsavelnome_sel ,
                                             string AV126Costumer_wpclientesds_42_tfresponsavelnome ,
                                             string AV129Costumer_wpclientesds_45_tfresponsavelemail_sel ,
                                             string AV128Costumer_wpclientesds_44_tfresponsavelemail ,
                                             DateTime AV130Costumer_wpclientesds_46_tfclientecreatedat ,
                                             DateTime AV131Costumer_wpclientesds_47_tfclientecreatedat_to ,
                                             int AV132Costumer_wpclientesds_48_tfclientesituacao_sels_Count ,
                                             string A169ClienteDocumento ,
                                             string A193TipoClienteDescricao ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome ,
                                             string A170ClienteRazaoSocial ,
                                             string A436ResponsavelNome ,
                                             string A456ResponsavelEmail ,
                                             DateTime A175ClienteCreatedAt ,
                                             string AV85Costumer_wpclientesds_1_filterfulltext ,
                                             short A886ClienteCountNotas_F ,
                                             short AV133Costumer_wpclientesds_49_tfclientecountnotas_f ,
                                             short AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to ,
                                             bool A793TipoClientePortalPjPf )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[83];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.TipoClienteId, T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.ClienteId, T1.ClienteRazaoSocial, T2.TipoClientePortalPjPf, T1.ClienteCreatedAt, T4.MunicipioNome AS ResponsavelMunicipioNome, T8.ProfissaoNome AS ResponsavelProfissaoNome, T6.NacionalidadeNome AS ResponsavelNacionalidadeNome, T5.BancoCodigo, T3.MunicipioNome, T9.ProfissaoNome AS ClienteProfissaoNome, T7.NacionalidadeNome AS ClienteNacionalidadeNome, T10.ConvenioDescricao AS ClienteConvenioDescricao, T2.TipoClienteDescricao, T1.ClienteDocumento, T1.ClienteSituacao, T1.ResponsavelEmail, T1.ResponsavelNome, COALESCE( T11.ClienteCountNotas_F, 0) AS ClienteCountNotas_F FROM ((((((((((Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T5 ON T5.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T7 ON T7.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T9 ON T9.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T10 ON T10.ConvenioId = T1.ClienteConvenio) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteCountNotas_F, ClienteId FROM NotaFiscal WHERE T1.ClienteId = ClienteId GROUP BY ClienteId ) T11 ON T11.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV85Costumer_wpclientesds_1_filterfulltext))=0) or ( ( T1.ClienteRazaoSocial like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( T1.ResponsavelNome like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( T1.ResponsavelEmail like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( 'aguardando análise' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'P')) or ( 'aprovado' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'A')) or ( 'rejeitado' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'R')) or ( SUBSTR(TO_CHAR(COALESCE( T11.ClienteCountNotas_F, 0),'9999'), 2) like '%' || :lV85Costumer_wpclientesds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV133Costumer_wpclientesds_49_tfclientecountnotas_f = 0) or ( COALESCE( T11.ClienteCountNotas_F, 0) >= :AV133Costumer_wpclientesds_49_tfclientecountnotas_f))");
         AddWhere(sWhereString, "((:AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = 0) or ( COALESCE( T11.ClienteCountNotas_F, 0) <= :AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to))");
         AddWhere(sWhereString, "(T2.TipoClientePortalPjPf)");
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV88Costumer_wpclientesds_4_clientedocumento1)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV88Costumer_wpclientesds_4_clientedocumento1)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV89Costumer_wpclientesds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV89Costumer_wpclientesds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV90Costumer_wpclientesds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV90Costumer_wpclientesds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV91Costumer_wpclientesds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV91Costumer_wpclientesds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV92Costumer_wpclientesds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV92Costumer_wpclientesds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV93Costumer_wpclientesds_9_municipionome1)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV93Costumer_wpclientesds_9_municipionome1)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV96Costumer_wpclientesds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV96Costumer_wpclientesds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV97Costumer_wpclientesds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV97Costumer_wpclientesds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV101Costumer_wpclientesds_17_clientedocumento2)");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV101Costumer_wpclientesds_17_clientedocumento2)");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV102Costumer_wpclientesds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int1[35] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV102Costumer_wpclientesds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int1[36] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV103Costumer_wpclientesds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int1[37] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV103Costumer_wpclientesds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int1[38] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV104Costumer_wpclientesds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int1[39] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV104Costumer_wpclientesds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int1[40] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV105Costumer_wpclientesds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int1[41] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV105Costumer_wpclientesds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int1[42] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV106Costumer_wpclientesds_22_municipionome2)");
         }
         else
         {
            GXv_int1[43] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV106Costumer_wpclientesds_22_municipionome2)");
         }
         else
         {
            GXv_int1[44] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int1[45] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int1[46] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int1[47] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int1[48] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int1[49] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV109Costumer_wpclientesds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int1[50] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV109Costumer_wpclientesds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int1[51] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV110Costumer_wpclientesds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int1[52] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV110Costumer_wpclientesds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int1[53] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV114Costumer_wpclientesds_30_clientedocumento3)");
         }
         else
         {
            GXv_int1[54] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV114Costumer_wpclientesds_30_clientedocumento3)");
         }
         else
         {
            GXv_int1[55] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV115Costumer_wpclientesds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int1[56] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV115Costumer_wpclientesds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int1[57] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV116Costumer_wpclientesds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int1[58] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV116Costumer_wpclientesds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int1[59] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV117Costumer_wpclientesds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int1[60] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV117Costumer_wpclientesds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int1[61] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV118Costumer_wpclientesds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int1[62] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV118Costumer_wpclientesds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int1[63] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV119Costumer_wpclientesds_35_municipionome3)");
         }
         else
         {
            GXv_int1[64] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV119Costumer_wpclientesds_35_municipionome3)");
         }
         else
         {
            GXv_int1[65] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int1[66] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int1[67] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int1[68] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int1[69] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int1[70] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV122Costumer_wpclientesds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int1[71] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV122Costumer_wpclientesds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int1[72] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV123Costumer_wpclientesds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int1[73] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV123Costumer_wpclientesds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int1[74] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Costumer_wpclientesds_40_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV124Costumer_wpclientesds_40_tfclienterazaosocial)");
         }
         else
         {
            GXv_int1[75] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int1[76] = 1;
         }
         if ( StringUtil.StrCmp(AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Costumer_wpclientesds_43_tfresponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Costumer_wpclientesds_42_tfresponsavelnome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV126Costumer_wpclientesds_42_tfresponsavelnome)");
         }
         else
         {
            GXv_int1[77] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Costumer_wpclientesds_43_tfresponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV127Costumer_wpclientesds_43_tfresponsavelnome_sel))");
         }
         else
         {
            GXv_int1[78] = 1;
         }
         if ( StringUtil.StrCmp(AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Costumer_wpclientesds_45_tfresponsavelemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Costumer_wpclientesds_44_tfresponsavelemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV128Costumer_wpclientesds_44_tfresponsavelemail)");
         }
         else
         {
            GXv_int1[79] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Costumer_wpclientesds_45_tfresponsavelemail_sel)) && ! ( StringUtil.StrCmp(AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV129Costumer_wpclientesds_45_tfresponsavelemail_sel))");
         }
         else
         {
            GXv_int1[80] = 1;
         }
         if ( StringUtil.StrCmp(AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( ! (DateTime.MinValue==AV130Costumer_wpclientesds_46_tfclientecreatedat) )
         {
            AddWhere(sWhereString, "(T1.ClienteCreatedAt >= :AV130Costumer_wpclientesds_46_tfclientecreatedat)");
         }
         else
         {
            GXv_int1[81] = 1;
         }
         if ( ! (DateTime.MinValue==AV131Costumer_wpclientesds_47_tfclientecreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ClienteCreatedAt <= :AV131Costumer_wpclientesds_47_tfclientecreatedat_to)");
         }
         else
         {
            GXv_int1[82] = 1;
         }
         if ( AV132Costumer_wpclientesds_48_tfclientesituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV132Costumer_wpclientesds_48_tfclientesituacao_sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteRazaoSocial";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00E45( IGxContext context ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV132Costumer_wpclientesds_48_tfclientesituacao_sels ,
                                             string AV86Costumer_wpclientesds_2_dynamicfiltersselector1 ,
                                             short AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 ,
                                             string AV88Costumer_wpclientesds_4_clientedocumento1 ,
                                             string AV89Costumer_wpclientesds_5_tipoclientedescricao1 ,
                                             string AV90Costumer_wpclientesds_6_clienteconveniodescricao1 ,
                                             string AV91Costumer_wpclientesds_7_clientenacionalidadenome1 ,
                                             string AV92Costumer_wpclientesds_8_clienteprofissaonome1 ,
                                             string AV93Costumer_wpclientesds_9_municipionome1 ,
                                             int AV94Costumer_wpclientesds_10_bancocodigo1 ,
                                             string AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 ,
                                             string AV96Costumer_wpclientesds_12_responsavelprofissaonome1 ,
                                             string AV97Costumer_wpclientesds_13_responsavelmunicipionome1 ,
                                             bool AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 ,
                                             string AV99Costumer_wpclientesds_15_dynamicfiltersselector2 ,
                                             short AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 ,
                                             string AV101Costumer_wpclientesds_17_clientedocumento2 ,
                                             string AV102Costumer_wpclientesds_18_tipoclientedescricao2 ,
                                             string AV103Costumer_wpclientesds_19_clienteconveniodescricao2 ,
                                             string AV104Costumer_wpclientesds_20_clientenacionalidadenome2 ,
                                             string AV105Costumer_wpclientesds_21_clienteprofissaonome2 ,
                                             string AV106Costumer_wpclientesds_22_municipionome2 ,
                                             int AV107Costumer_wpclientesds_23_bancocodigo2 ,
                                             string AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 ,
                                             string AV109Costumer_wpclientesds_25_responsavelprofissaonome2 ,
                                             string AV110Costumer_wpclientesds_26_responsavelmunicipionome2 ,
                                             bool AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 ,
                                             string AV112Costumer_wpclientesds_28_dynamicfiltersselector3 ,
                                             short AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 ,
                                             string AV114Costumer_wpclientesds_30_clientedocumento3 ,
                                             string AV115Costumer_wpclientesds_31_tipoclientedescricao3 ,
                                             string AV116Costumer_wpclientesds_32_clienteconveniodescricao3 ,
                                             string AV117Costumer_wpclientesds_33_clientenacionalidadenome3 ,
                                             string AV118Costumer_wpclientesds_34_clienteprofissaonome3 ,
                                             string AV119Costumer_wpclientesds_35_municipionome3 ,
                                             int AV120Costumer_wpclientesds_36_bancocodigo3 ,
                                             string AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 ,
                                             string AV122Costumer_wpclientesds_38_responsavelprofissaonome3 ,
                                             string AV123Costumer_wpclientesds_39_responsavelmunicipionome3 ,
                                             string AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel ,
                                             string AV124Costumer_wpclientesds_40_tfclienterazaosocial ,
                                             string AV127Costumer_wpclientesds_43_tfresponsavelnome_sel ,
                                             string AV126Costumer_wpclientesds_42_tfresponsavelnome ,
                                             string AV129Costumer_wpclientesds_45_tfresponsavelemail_sel ,
                                             string AV128Costumer_wpclientesds_44_tfresponsavelemail ,
                                             DateTime AV130Costumer_wpclientesds_46_tfclientecreatedat ,
                                             DateTime AV131Costumer_wpclientesds_47_tfclientecreatedat_to ,
                                             int AV132Costumer_wpclientesds_48_tfclientesituacao_sels_Count ,
                                             string A169ClienteDocumento ,
                                             string A193TipoClienteDescricao ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome ,
                                             string A170ClienteRazaoSocial ,
                                             string A436ResponsavelNome ,
                                             string A456ResponsavelEmail ,
                                             DateTime A175ClienteCreatedAt ,
                                             string AV85Costumer_wpclientesds_1_filterfulltext ,
                                             short A886ClienteCountNotas_F ,
                                             short AV133Costumer_wpclientesds_49_tfclientecountnotas_f ,
                                             short AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to ,
                                             bool A793TipoClientePortalPjPf )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[83];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.TipoClienteId, T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.ClienteId, T1.ResponsavelNome, T2.TipoClientePortalPjPf, T1.ClienteCreatedAt, T4.MunicipioNome AS ResponsavelMunicipioNome, T8.ProfissaoNome AS ResponsavelProfissaoNome, T6.NacionalidadeNome AS ResponsavelNacionalidadeNome, T5.BancoCodigo, T3.MunicipioNome, T9.ProfissaoNome AS ClienteProfissaoNome, T7.NacionalidadeNome AS ClienteNacionalidadeNome, T10.ConvenioDescricao AS ClienteConvenioDescricao, T2.TipoClienteDescricao, T1.ClienteDocumento, T1.ClienteSituacao, T1.ResponsavelEmail, T1.ClienteRazaoSocial, COALESCE( T11.ClienteCountNotas_F, 0) AS ClienteCountNotas_F FROM ((((((((((Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T5 ON T5.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T7 ON T7.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T9 ON T9.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T10 ON T10.ConvenioId = T1.ClienteConvenio) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteCountNotas_F, ClienteId FROM NotaFiscal WHERE T1.ClienteId = ClienteId GROUP BY ClienteId ) T11 ON T11.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV85Costumer_wpclientesds_1_filterfulltext))=0) or ( ( T1.ClienteRazaoSocial like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( T1.ResponsavelNome like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( T1.ResponsavelEmail like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( 'aguardando análise' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'P')) or ( 'aprovado' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'A')) or ( 'rejeitado' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'R')) or ( SUBSTR(TO_CHAR(COALESCE( T11.ClienteCountNotas_F, 0),'9999'), 2) like '%' || :lV85Costumer_wpclientesds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV133Costumer_wpclientesds_49_tfclientecountnotas_f = 0) or ( COALESCE( T11.ClienteCountNotas_F, 0) >= :AV133Costumer_wpclientesds_49_tfclientecountnotas_f))");
         AddWhere(sWhereString, "((:AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = 0) or ( COALESCE( T11.ClienteCountNotas_F, 0) <= :AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to))");
         AddWhere(sWhereString, "(T2.TipoClientePortalPjPf)");
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV88Costumer_wpclientesds_4_clientedocumento1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV88Costumer_wpclientesds_4_clientedocumento1)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV89Costumer_wpclientesds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV89Costumer_wpclientesds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV90Costumer_wpclientesds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV90Costumer_wpclientesds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV91Costumer_wpclientesds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV91Costumer_wpclientesds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV92Costumer_wpclientesds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV92Costumer_wpclientesds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV93Costumer_wpclientesds_9_municipionome1)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV93Costumer_wpclientesds_9_municipionome1)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV96Costumer_wpclientesds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV96Costumer_wpclientesds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV97Costumer_wpclientesds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV97Costumer_wpclientesds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV101Costumer_wpclientesds_17_clientedocumento2)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV101Costumer_wpclientesds_17_clientedocumento2)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV102Costumer_wpclientesds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV102Costumer_wpclientesds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV103Costumer_wpclientesds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV103Costumer_wpclientesds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV104Costumer_wpclientesds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV104Costumer_wpclientesds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV105Costumer_wpclientesds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV105Costumer_wpclientesds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV106Costumer_wpclientesds_22_municipionome2)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV106Costumer_wpclientesds_22_municipionome2)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV109Costumer_wpclientesds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV109Costumer_wpclientesds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int3[51] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV110Costumer_wpclientesds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int3[52] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV110Costumer_wpclientesds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int3[53] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV114Costumer_wpclientesds_30_clientedocumento3)");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV114Costumer_wpclientesds_30_clientedocumento3)");
         }
         else
         {
            GXv_int3[55] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV115Costumer_wpclientesds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int3[56] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV115Costumer_wpclientesds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int3[57] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV116Costumer_wpclientesds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int3[58] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV116Costumer_wpclientesds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int3[59] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV117Costumer_wpclientesds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int3[60] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV117Costumer_wpclientesds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int3[61] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV118Costumer_wpclientesds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int3[62] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV118Costumer_wpclientesds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int3[63] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV119Costumer_wpclientesds_35_municipionome3)");
         }
         else
         {
            GXv_int3[64] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV119Costumer_wpclientesds_35_municipionome3)");
         }
         else
         {
            GXv_int3[65] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int3[66] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int3[67] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int3[68] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int3[69] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int3[70] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV122Costumer_wpclientesds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int3[71] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV122Costumer_wpclientesds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int3[72] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV123Costumer_wpclientesds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int3[73] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV123Costumer_wpclientesds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int3[74] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Costumer_wpclientesds_40_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV124Costumer_wpclientesds_40_tfclienterazaosocial)");
         }
         else
         {
            GXv_int3[75] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[76] = 1;
         }
         if ( StringUtil.StrCmp(AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Costumer_wpclientesds_43_tfresponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Costumer_wpclientesds_42_tfresponsavelnome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV126Costumer_wpclientesds_42_tfresponsavelnome)");
         }
         else
         {
            GXv_int3[77] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Costumer_wpclientesds_43_tfresponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV127Costumer_wpclientesds_43_tfresponsavelnome_sel))");
         }
         else
         {
            GXv_int3[78] = 1;
         }
         if ( StringUtil.StrCmp(AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Costumer_wpclientesds_45_tfresponsavelemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Costumer_wpclientesds_44_tfresponsavelemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV128Costumer_wpclientesds_44_tfresponsavelemail)");
         }
         else
         {
            GXv_int3[79] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Costumer_wpclientesds_45_tfresponsavelemail_sel)) && ! ( StringUtil.StrCmp(AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV129Costumer_wpclientesds_45_tfresponsavelemail_sel))");
         }
         else
         {
            GXv_int3[80] = 1;
         }
         if ( StringUtil.StrCmp(AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( ! (DateTime.MinValue==AV130Costumer_wpclientesds_46_tfclientecreatedat) )
         {
            AddWhere(sWhereString, "(T1.ClienteCreatedAt >= :AV130Costumer_wpclientesds_46_tfclientecreatedat)");
         }
         else
         {
            GXv_int3[81] = 1;
         }
         if ( ! (DateTime.MinValue==AV131Costumer_wpclientesds_47_tfclientecreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ClienteCreatedAt <= :AV131Costumer_wpclientesds_47_tfclientecreatedat_to)");
         }
         else
         {
            GXv_int3[82] = 1;
         }
         if ( AV132Costumer_wpclientesds_48_tfclientesituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV132Costumer_wpclientesds_48_tfclientesituacao_sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResponsavelNome";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00E47( IGxContext context ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV132Costumer_wpclientesds_48_tfclientesituacao_sels ,
                                             string AV86Costumer_wpclientesds_2_dynamicfiltersselector1 ,
                                             short AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 ,
                                             string AV88Costumer_wpclientesds_4_clientedocumento1 ,
                                             string AV89Costumer_wpclientesds_5_tipoclientedescricao1 ,
                                             string AV90Costumer_wpclientesds_6_clienteconveniodescricao1 ,
                                             string AV91Costumer_wpclientesds_7_clientenacionalidadenome1 ,
                                             string AV92Costumer_wpclientesds_8_clienteprofissaonome1 ,
                                             string AV93Costumer_wpclientesds_9_municipionome1 ,
                                             int AV94Costumer_wpclientesds_10_bancocodigo1 ,
                                             string AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1 ,
                                             string AV96Costumer_wpclientesds_12_responsavelprofissaonome1 ,
                                             string AV97Costumer_wpclientesds_13_responsavelmunicipionome1 ,
                                             bool AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 ,
                                             string AV99Costumer_wpclientesds_15_dynamicfiltersselector2 ,
                                             short AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 ,
                                             string AV101Costumer_wpclientesds_17_clientedocumento2 ,
                                             string AV102Costumer_wpclientesds_18_tipoclientedescricao2 ,
                                             string AV103Costumer_wpclientesds_19_clienteconveniodescricao2 ,
                                             string AV104Costumer_wpclientesds_20_clientenacionalidadenome2 ,
                                             string AV105Costumer_wpclientesds_21_clienteprofissaonome2 ,
                                             string AV106Costumer_wpclientesds_22_municipionome2 ,
                                             int AV107Costumer_wpclientesds_23_bancocodigo2 ,
                                             string AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2 ,
                                             string AV109Costumer_wpclientesds_25_responsavelprofissaonome2 ,
                                             string AV110Costumer_wpclientesds_26_responsavelmunicipionome2 ,
                                             bool AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 ,
                                             string AV112Costumer_wpclientesds_28_dynamicfiltersselector3 ,
                                             short AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 ,
                                             string AV114Costumer_wpclientesds_30_clientedocumento3 ,
                                             string AV115Costumer_wpclientesds_31_tipoclientedescricao3 ,
                                             string AV116Costumer_wpclientesds_32_clienteconveniodescricao3 ,
                                             string AV117Costumer_wpclientesds_33_clientenacionalidadenome3 ,
                                             string AV118Costumer_wpclientesds_34_clienteprofissaonome3 ,
                                             string AV119Costumer_wpclientesds_35_municipionome3 ,
                                             int AV120Costumer_wpclientesds_36_bancocodigo3 ,
                                             string AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3 ,
                                             string AV122Costumer_wpclientesds_38_responsavelprofissaonome3 ,
                                             string AV123Costumer_wpclientesds_39_responsavelmunicipionome3 ,
                                             string AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel ,
                                             string AV124Costumer_wpclientesds_40_tfclienterazaosocial ,
                                             string AV127Costumer_wpclientesds_43_tfresponsavelnome_sel ,
                                             string AV126Costumer_wpclientesds_42_tfresponsavelnome ,
                                             string AV129Costumer_wpclientesds_45_tfresponsavelemail_sel ,
                                             string AV128Costumer_wpclientesds_44_tfresponsavelemail ,
                                             DateTime AV130Costumer_wpclientesds_46_tfclientecreatedat ,
                                             DateTime AV131Costumer_wpclientesds_47_tfclientecreatedat_to ,
                                             int AV132Costumer_wpclientesds_48_tfclientesituacao_sels_Count ,
                                             string A169ClienteDocumento ,
                                             string A193TipoClienteDescricao ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome ,
                                             string A170ClienteRazaoSocial ,
                                             string A436ResponsavelNome ,
                                             string A456ResponsavelEmail ,
                                             DateTime A175ClienteCreatedAt ,
                                             string AV85Costumer_wpclientesds_1_filterfulltext ,
                                             short A886ClienteCountNotas_F ,
                                             short AV133Costumer_wpclientesds_49_tfclientecountnotas_f ,
                                             short AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to ,
                                             bool A793TipoClientePortalPjPf )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[83];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.TipoClienteId, T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.ClienteId, T1.ResponsavelEmail, T2.TipoClientePortalPjPf, T1.ClienteCreatedAt, T4.MunicipioNome AS ResponsavelMunicipioNome, T8.ProfissaoNome AS ResponsavelProfissaoNome, T6.NacionalidadeNome AS ResponsavelNacionalidadeNome, T5.BancoCodigo, T3.MunicipioNome, T9.ProfissaoNome AS ClienteProfissaoNome, T7.NacionalidadeNome AS ClienteNacionalidadeNome, T10.ConvenioDescricao AS ClienteConvenioDescricao, T2.TipoClienteDescricao, T1.ClienteDocumento, T1.ClienteSituacao, T1.ResponsavelNome, T1.ClienteRazaoSocial, COALESCE( T11.ClienteCountNotas_F, 0) AS ClienteCountNotas_F FROM ((((((((((Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T5 ON T5.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T7 ON T7.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T9 ON T9.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T10 ON T10.ConvenioId = T1.ClienteConvenio) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteCountNotas_F, ClienteId FROM NotaFiscal WHERE T1.ClienteId = ClienteId GROUP BY ClienteId ) T11 ON T11.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV85Costumer_wpclientesds_1_filterfulltext))=0) or ( ( T1.ClienteRazaoSocial like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( T1.ResponsavelNome like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( T1.ResponsavelEmail like '%' || :lV85Costumer_wpclientesds_1_filterfulltext) or ( 'aguardando análise' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'P')) or ( 'aprovado' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'A')) or ( 'rejeitado' like '%' || LOWER(:lV85Costumer_wpclientesds_1_filterfulltext) and T1.ClienteSituacao = ( 'R')) or ( SUBSTR(TO_CHAR(COALESCE( T11.ClienteCountNotas_F, 0),'9999'), 2) like '%' || :lV85Costumer_wpclientesds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV133Costumer_wpclientesds_49_tfclientecountnotas_f = 0) or ( COALESCE( T11.ClienteCountNotas_F, 0) >= :AV133Costumer_wpclientesds_49_tfclientecountnotas_f))");
         AddWhere(sWhereString, "((:AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to = 0) or ( COALESCE( T11.ClienteCountNotas_F, 0) <= :AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to))");
         AddWhere(sWhereString, "(T2.TipoClientePortalPjPf)");
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV88Costumer_wpclientesds_4_clientedocumento1)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Costumer_wpclientesds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV88Costumer_wpclientesds_4_clientedocumento1)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV89Costumer_wpclientesds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Costumer_wpclientesds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV89Costumer_wpclientesds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV90Costumer_wpclientesds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Costumer_wpclientesds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV90Costumer_wpclientesds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV91Costumer_wpclientesds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Costumer_wpclientesds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV91Costumer_wpclientesds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV92Costumer_wpclientesds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Costumer_wpclientesds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV92Costumer_wpclientesds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV93Costumer_wpclientesds_9_municipionome1)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Costumer_wpclientesds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV93Costumer_wpclientesds_9_municipionome1)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV94Costumer_wpclientesds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV94Costumer_wpclientesds_10_bancocodigo1)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV96Costumer_wpclientesds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Costumer_wpclientesds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV96Costumer_wpclientesds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV97Costumer_wpclientesds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV86Costumer_wpclientesds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV87Costumer_wpclientesds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Costumer_wpclientesds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV97Costumer_wpclientesds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV101Costumer_wpclientesds_17_clientedocumento2)");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Costumer_wpclientesds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV101Costumer_wpclientesds_17_clientedocumento2)");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV102Costumer_wpclientesds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Costumer_wpclientesds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV102Costumer_wpclientesds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int5[36] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV103Costumer_wpclientesds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int5[37] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Costumer_wpclientesds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV103Costumer_wpclientesds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int5[38] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV104Costumer_wpclientesds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int5[39] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Costumer_wpclientesds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV104Costumer_wpclientesds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int5[40] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV105Costumer_wpclientesds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int5[41] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Costumer_wpclientesds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV105Costumer_wpclientesds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int5[42] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV106Costumer_wpclientesds_22_municipionome2)");
         }
         else
         {
            GXv_int5[43] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Costumer_wpclientesds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV106Costumer_wpclientesds_22_municipionome2)");
         }
         else
         {
            GXv_int5[44] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int5[45] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int5[46] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV107Costumer_wpclientesds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV107Costumer_wpclientesds_23_bancocodigo2)");
         }
         else
         {
            GXv_int5[47] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int5[48] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int5[49] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV109Costumer_wpclientesds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int5[50] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Costumer_wpclientesds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV109Costumer_wpclientesds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int5[51] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV110Costumer_wpclientesds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int5[52] = 1;
         }
         if ( AV98Costumer_wpclientesds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV99Costumer_wpclientesds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV100Costumer_wpclientesds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Costumer_wpclientesds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV110Costumer_wpclientesds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int5[53] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV114Costumer_wpclientesds_30_clientedocumento3)");
         }
         else
         {
            GXv_int5[54] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Costumer_wpclientesds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV114Costumer_wpclientesds_30_clientedocumento3)");
         }
         else
         {
            GXv_int5[55] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV115Costumer_wpclientesds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int5[56] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Costumer_wpclientesds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV115Costumer_wpclientesds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int5[57] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV116Costumer_wpclientesds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int5[58] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Costumer_wpclientesds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV116Costumer_wpclientesds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int5[59] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV117Costumer_wpclientesds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int5[60] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Costumer_wpclientesds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV117Costumer_wpclientesds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int5[61] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV118Costumer_wpclientesds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int5[62] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Costumer_wpclientesds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV118Costumer_wpclientesds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int5[63] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV119Costumer_wpclientesds_35_municipionome3)");
         }
         else
         {
            GXv_int5[64] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Costumer_wpclientesds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV119Costumer_wpclientesds_35_municipionome3)");
         }
         else
         {
            GXv_int5[65] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int5[66] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int5[67] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV120Costumer_wpclientesds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV120Costumer_wpclientesds_36_bancocodigo3)");
         }
         else
         {
            GXv_int5[68] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int5[69] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int5[70] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV122Costumer_wpclientesds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int5[71] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Costumer_wpclientesds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV122Costumer_wpclientesds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int5[72] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV123Costumer_wpclientesds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int5[73] = 1;
         }
         if ( AV111Costumer_wpclientesds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV112Costumer_wpclientesds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV113Costumer_wpclientesds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Costumer_wpclientesds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV123Costumer_wpclientesds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int5[74] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Costumer_wpclientesds_40_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV124Costumer_wpclientesds_40_tfclienterazaosocial)");
         }
         else
         {
            GXv_int5[75] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int5[76] = 1;
         }
         if ( StringUtil.StrCmp(AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Costumer_wpclientesds_43_tfresponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Costumer_wpclientesds_42_tfresponsavelnome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV126Costumer_wpclientesds_42_tfresponsavelnome)");
         }
         else
         {
            GXv_int5[77] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Costumer_wpclientesds_43_tfresponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV127Costumer_wpclientesds_43_tfresponsavelnome_sel))");
         }
         else
         {
            GXv_int5[78] = 1;
         }
         if ( StringUtil.StrCmp(AV127Costumer_wpclientesds_43_tfresponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV129Costumer_wpclientesds_45_tfresponsavelemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Costumer_wpclientesds_44_tfresponsavelemail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV128Costumer_wpclientesds_44_tfresponsavelemail)");
         }
         else
         {
            GXv_int5[79] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Costumer_wpclientesds_45_tfresponsavelemail_sel)) && ! ( StringUtil.StrCmp(AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV129Costumer_wpclientesds_45_tfresponsavelemail_sel))");
         }
         else
         {
            GXv_int5[80] = 1;
         }
         if ( StringUtil.StrCmp(AV129Costumer_wpclientesds_45_tfresponsavelemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( ! (DateTime.MinValue==AV130Costumer_wpclientesds_46_tfclientecreatedat) )
         {
            AddWhere(sWhereString, "(T1.ClienteCreatedAt >= :AV130Costumer_wpclientesds_46_tfclientecreatedat)");
         }
         else
         {
            GXv_int5[81] = 1;
         }
         if ( ! (DateTime.MinValue==AV131Costumer_wpclientesds_47_tfclientecreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ClienteCreatedAt <= :AV131Costumer_wpclientesds_47_tfclientecreatedat_to)");
         }
         else
         {
            GXv_int5[82] = 1;
         }
         if ( AV132Costumer_wpclientesds_48_tfclientesituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV132Costumer_wpclientesds_48_tfclientesituacao_sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResponsavelEmail";
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
                     return conditional_P00E43(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (DateTime)dynConstraints[46] , (DateTime)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (int)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (DateTime)dynConstraints[62] , (string)dynConstraints[63] , (short)dynConstraints[64] , (short)dynConstraints[65] , (short)dynConstraints[66] , (bool)dynConstraints[67] );
               case 1 :
                     return conditional_P00E45(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (DateTime)dynConstraints[46] , (DateTime)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (int)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (DateTime)dynConstraints[62] , (string)dynConstraints[63] , (short)dynConstraints[64] , (short)dynConstraints[65] , (short)dynConstraints[66] , (bool)dynConstraints[67] );
               case 2 :
                     return conditional_P00E47(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (DateTime)dynConstraints[46] , (DateTime)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (int)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (DateTime)dynConstraints[62] , (string)dynConstraints[63] , (short)dynConstraints[64] , (short)dynConstraints[65] , (short)dynConstraints[66] , (bool)dynConstraints[67] );
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
          Object[] prmP00E43;
          prmP00E43 = new Object[] {
          new ParDef("AV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV133Costumer_wpclientesds_49_tfclientecountnotas_f",GXType.Int16,4,0) ,
          new ParDef("AV133Costumer_wpclientesds_49_tfclientecountnotas_f",GXType.Int16,4,0) ,
          new ParDef("AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to",GXType.Int16,4,0) ,
          new ParDef("AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to",GXType.Int16,4,0) ,
          new ParDef("lV88Costumer_wpclientesds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV88Costumer_wpclientesds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV89Costumer_wpclientesds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV89Costumer_wpclientesds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV90Costumer_wpclientesds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV90Costumer_wpclientesds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV91Costumer_wpclientesds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV91Costumer_wpclientesds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV92Costumer_wpclientesds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV92Costumer_wpclientesds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV93Costumer_wpclientesds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV93Costumer_wpclientesds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV96Costumer_wpclientesds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV96Costumer_wpclientesds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV97Costumer_wpclientesds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV97Costumer_wpclientesds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV101Costumer_wpclientesds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV101Costumer_wpclientesds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV102Costumer_wpclientesds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV102Costumer_wpclientesds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV103Costumer_wpclientesds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV103Costumer_wpclientesds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV104Costumer_wpclientesds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV104Costumer_wpclientesds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV105Costumer_wpclientesds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV105Costumer_wpclientesds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV106Costumer_wpclientesds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV106Costumer_wpclientesds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV109Costumer_wpclientesds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV109Costumer_wpclientesds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV110Costumer_wpclientesds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV110Costumer_wpclientesds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV114Costumer_wpclientesds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV114Costumer_wpclientesds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV115Costumer_wpclientesds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV115Costumer_wpclientesds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV116Costumer_wpclientesds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV116Costumer_wpclientesds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV117Costumer_wpclientesds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV117Costumer_wpclientesds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV118Costumer_wpclientesds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV118Costumer_wpclientesds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV119Costumer_wpclientesds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV119Costumer_wpclientesds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV122Costumer_wpclientesds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV122Costumer_wpclientesds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV123Costumer_wpclientesds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV123Costumer_wpclientesds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV124Costumer_wpclientesds_40_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV126Costumer_wpclientesds_42_tfresponsavelnome",GXType.VarChar,90,0) ,
          new ParDef("AV127Costumer_wpclientesds_43_tfresponsavelnome_sel",GXType.VarChar,90,0) ,
          new ParDef("lV128Costumer_wpclientesds_44_tfresponsavelemail",GXType.VarChar,100,0) ,
          new ParDef("AV129Costumer_wpclientesds_45_tfresponsavelemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV130Costumer_wpclientesds_46_tfclientecreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV131Costumer_wpclientesds_47_tfclientecreatedat_to",GXType.DateTime,8,5)
          };
          Object[] prmP00E45;
          prmP00E45 = new Object[] {
          new ParDef("AV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV133Costumer_wpclientesds_49_tfclientecountnotas_f",GXType.Int16,4,0) ,
          new ParDef("AV133Costumer_wpclientesds_49_tfclientecountnotas_f",GXType.Int16,4,0) ,
          new ParDef("AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to",GXType.Int16,4,0) ,
          new ParDef("AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to",GXType.Int16,4,0) ,
          new ParDef("lV88Costumer_wpclientesds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV88Costumer_wpclientesds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV89Costumer_wpclientesds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV89Costumer_wpclientesds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV90Costumer_wpclientesds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV90Costumer_wpclientesds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV91Costumer_wpclientesds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV91Costumer_wpclientesds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV92Costumer_wpclientesds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV92Costumer_wpclientesds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV93Costumer_wpclientesds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV93Costumer_wpclientesds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV96Costumer_wpclientesds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV96Costumer_wpclientesds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV97Costumer_wpclientesds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV97Costumer_wpclientesds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV101Costumer_wpclientesds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV101Costumer_wpclientesds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV102Costumer_wpclientesds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV102Costumer_wpclientesds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV103Costumer_wpclientesds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV103Costumer_wpclientesds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV104Costumer_wpclientesds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV104Costumer_wpclientesds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV105Costumer_wpclientesds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV105Costumer_wpclientesds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV106Costumer_wpclientesds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV106Costumer_wpclientesds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV109Costumer_wpclientesds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV109Costumer_wpclientesds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV110Costumer_wpclientesds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV110Costumer_wpclientesds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV114Costumer_wpclientesds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV114Costumer_wpclientesds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV115Costumer_wpclientesds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV115Costumer_wpclientesds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV116Costumer_wpclientesds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV116Costumer_wpclientesds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV117Costumer_wpclientesds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV117Costumer_wpclientesds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV118Costumer_wpclientesds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV118Costumer_wpclientesds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV119Costumer_wpclientesds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV119Costumer_wpclientesds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV122Costumer_wpclientesds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV122Costumer_wpclientesds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV123Costumer_wpclientesds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV123Costumer_wpclientesds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV124Costumer_wpclientesds_40_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV126Costumer_wpclientesds_42_tfresponsavelnome",GXType.VarChar,90,0) ,
          new ParDef("AV127Costumer_wpclientesds_43_tfresponsavelnome_sel",GXType.VarChar,90,0) ,
          new ParDef("lV128Costumer_wpclientesds_44_tfresponsavelemail",GXType.VarChar,100,0) ,
          new ParDef("AV129Costumer_wpclientesds_45_tfresponsavelemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV130Costumer_wpclientesds_46_tfclientecreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV131Costumer_wpclientesds_47_tfclientecreatedat_to",GXType.DateTime,8,5)
          };
          Object[] prmP00E47;
          prmP00E47 = new Object[] {
          new ParDef("AV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV85Costumer_wpclientesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV133Costumer_wpclientesds_49_tfclientecountnotas_f",GXType.Int16,4,0) ,
          new ParDef("AV133Costumer_wpclientesds_49_tfclientecountnotas_f",GXType.Int16,4,0) ,
          new ParDef("AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to",GXType.Int16,4,0) ,
          new ParDef("AV134Costumer_wpclientesds_50_tfclientecountnotas_f_to",GXType.Int16,4,0) ,
          new ParDef("lV88Costumer_wpclientesds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV88Costumer_wpclientesds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV89Costumer_wpclientesds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV89Costumer_wpclientesds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV90Costumer_wpclientesds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV90Costumer_wpclientesds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV91Costumer_wpclientesds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV91Costumer_wpclientesds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV92Costumer_wpclientesds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV92Costumer_wpclientesds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV93Costumer_wpclientesds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV93Costumer_wpclientesds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV94Costumer_wpclientesds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV95Costumer_wpclientesds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV96Costumer_wpclientesds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV96Costumer_wpclientesds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV97Costumer_wpclientesds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV97Costumer_wpclientesds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV101Costumer_wpclientesds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV101Costumer_wpclientesds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV102Costumer_wpclientesds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV102Costumer_wpclientesds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV103Costumer_wpclientesds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV103Costumer_wpclientesds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV104Costumer_wpclientesds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV104Costumer_wpclientesds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV105Costumer_wpclientesds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV105Costumer_wpclientesds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV106Costumer_wpclientesds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV106Costumer_wpclientesds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV107Costumer_wpclientesds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV108Costumer_wpclientesds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV109Costumer_wpclientesds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV109Costumer_wpclientesds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV110Costumer_wpclientesds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV110Costumer_wpclientesds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV114Costumer_wpclientesds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV114Costumer_wpclientesds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV115Costumer_wpclientesds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV115Costumer_wpclientesds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV116Costumer_wpclientesds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV116Costumer_wpclientesds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV117Costumer_wpclientesds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV117Costumer_wpclientesds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV118Costumer_wpclientesds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV118Costumer_wpclientesds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV119Costumer_wpclientesds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV119Costumer_wpclientesds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV120Costumer_wpclientesds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV121Costumer_wpclientesds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV122Costumer_wpclientesds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV122Costumer_wpclientesds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV123Costumer_wpclientesds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV123Costumer_wpclientesds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV124Costumer_wpclientesds_40_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV125Costumer_wpclientesds_41_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV126Costumer_wpclientesds_42_tfresponsavelnome",GXType.VarChar,90,0) ,
          new ParDef("AV127Costumer_wpclientesds_43_tfresponsavelnome_sel",GXType.VarChar,90,0) ,
          new ParDef("lV128Costumer_wpclientesds_44_tfresponsavelemail",GXType.VarChar,100,0) ,
          new ParDef("AV129Costumer_wpclientesds_45_tfresponsavelemail_sel",GXType.VarChar,100,0) ,
          new ParDef("AV130Costumer_wpclientesds_46_tfclientecreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV131Costumer_wpclientesds_47_tfclientecreatedat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00E43", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E43,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E45", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E45,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E47", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E47,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((bool[]) buf[21])[0] = rslt.getBool(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getString(24, 1);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((short[]) buf[51])[0] = rslt.getShort(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((bool[]) buf[21])[0] = rslt.getBool(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getString(24, 1);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((short[]) buf[51])[0] = rslt.getShort(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((bool[]) buf[21])[0] = rslt.getBool(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((int[]) buf[31])[0] = rslt.getInt(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getString(24, 1);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((short[]) buf[51])[0] = rslt.getShort(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                return;
       }
    }

 }

}
