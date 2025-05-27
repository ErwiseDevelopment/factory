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
   public class clientewwgetfilterdata : GXProcedure
   {
      public clientewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientewwgetfilterdata( IGxContext context )
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
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV46OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28MaxItems = 10;
         AV27PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV42SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV25SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? "" : StringUtil.Substring( AV42SearchTxtParms, 3, -1));
         AV26SkipItems = (short)(AV27PageIndex*AV28MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_TIPOCLIENTEDESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPOCLIENTEDESCRICAOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_CLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTERAZAOSOCIALOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_CLIENTEDOCUMENTO") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTEDOCUMENTOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV44OptionsJson = AV31Options.ToJSonString(false);
         AV45OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV46OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("ClienteWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ClienteWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("ClienteWWGridState"), null, "", "");
         }
         AV97GXV1 = 1;
         while ( AV97GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV97GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO") == 0 )
            {
               AV65TFTipoClienteDescricao = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO_SEL") == 0 )
            {
               AV66TFTipoClienteDescricao_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV12TFClienteRazaoSocial = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV13TFClienteRazaoSocial_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV16TFClienteDocumento = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV17TFClienteDocumento_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCLIENTETIPOPESSOA_SEL") == 0 )
            {
               AV18TFClienteTipoPessoa_SelsJson = AV39GridStateFilterValue.gxTpr_Value;
               AV19TFClienteTipoPessoa_Sels.FromJSonString(AV18TFClienteTipoPessoa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCLIENTESTATUS_SEL") == 0 )
            {
               AV20TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV97GXV1 = (int)(AV97GXV1+1);
         }
         if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(1));
            AV48DynamicFiltersSelector1 = AV40GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV50ClienteDocumento1 = AV40GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV59TipoClienteDescricao1 = AV40GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV76ClienteConvenioDescricao1 = AV40GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV77ClienteNacionalidadeNome1 = AV40GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV78ClienteProfissaoNome1 = AV40GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "MUNICIPIONOME") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV73MunicipioNome1 = AV40GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "BANCOCODIGO") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV79BancoCodigo1 = (int)(Math.Round(NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV80ResponsavelNacionalidadeNome1 = AV40GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV81ResponsavelProfissaoNome1 = AV40GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV82ResponsavelMunicipioNome1 = AV40GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV51DynamicFiltersEnabled2 = true;
               AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(2));
               AV52DynamicFiltersSelector2 = AV40GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV54ClienteDocumento2 = AV40GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV61TipoClienteDescricao2 = AV40GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV83ClienteConvenioDescricao2 = AV40GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV84ClienteNacionalidadeNome2 = AV40GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV85ClienteProfissaoNome2 = AV40GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV74MunicipioNome2 = AV40GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV86BancoCodigo2 = (int)(Math.Round(NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV87ResponsavelNacionalidadeNome2 = AV40GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV88ResponsavelProfissaoNome2 = AV40GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV89ResponsavelMunicipioNome2 = AV40GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV55DynamicFiltersEnabled3 = true;
                  AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(3));
                  AV56DynamicFiltersSelector3 = AV40GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV58ClienteDocumento3 = AV40GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV63TipoClienteDescricao3 = AV40GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV90ClienteConvenioDescricao3 = AV40GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV91ClienteNacionalidadeNome3 = AV40GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV92ClienteProfissaoNome3 = AV40GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV75MunicipioNome3 = AV40GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV93BancoCodigo3 = (int)(Math.Round(NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV94ResponsavelNacionalidadeNome3 = AV40GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV95ResponsavelProfissaoNome3 = AV40GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV96ResponsavelMunicipioNome3 = AV40GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTIPOCLIENTEDESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV65TFTipoClienteDescricao = AV25SearchTxt;
         AV66TFTipoClienteDescricao_Sel = "";
         AV99Clientewwds_1_filterfulltext = AV47FilterFullText;
         AV100Clientewwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV101Clientewwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV102Clientewwds_4_clientedocumento1 = AV50ClienteDocumento1;
         AV103Clientewwds_5_tipoclientedescricao1 = AV59TipoClienteDescricao1;
         AV104Clientewwds_6_clienteconveniodescricao1 = AV76ClienteConvenioDescricao1;
         AV105Clientewwds_7_clientenacionalidadenome1 = AV77ClienteNacionalidadeNome1;
         AV106Clientewwds_8_clienteprofissaonome1 = AV78ClienteProfissaoNome1;
         AV107Clientewwds_9_municipionome1 = AV73MunicipioNome1;
         AV108Clientewwds_10_bancocodigo1 = AV79BancoCodigo1;
         AV109Clientewwds_11_responsavelnacionalidadenome1 = AV80ResponsavelNacionalidadeNome1;
         AV110Clientewwds_12_responsavelprofissaonome1 = AV81ResponsavelProfissaoNome1;
         AV111Clientewwds_13_responsavelmunicipionome1 = AV82ResponsavelMunicipioNome1;
         AV112Clientewwds_14_dynamicfiltersenabled2 = AV51DynamicFiltersEnabled2;
         AV113Clientewwds_15_dynamicfiltersselector2 = AV52DynamicFiltersSelector2;
         AV114Clientewwds_16_dynamicfiltersoperator2 = AV53DynamicFiltersOperator2;
         AV115Clientewwds_17_clientedocumento2 = AV54ClienteDocumento2;
         AV116Clientewwds_18_tipoclientedescricao2 = AV61TipoClienteDescricao2;
         AV117Clientewwds_19_clienteconveniodescricao2 = AV83ClienteConvenioDescricao2;
         AV118Clientewwds_20_clientenacionalidadenome2 = AV84ClienteNacionalidadeNome2;
         AV119Clientewwds_21_clienteprofissaonome2 = AV85ClienteProfissaoNome2;
         AV120Clientewwds_22_municipionome2 = AV74MunicipioNome2;
         AV121Clientewwds_23_bancocodigo2 = AV86BancoCodigo2;
         AV122Clientewwds_24_responsavelnacionalidadenome2 = AV87ResponsavelNacionalidadeNome2;
         AV123Clientewwds_25_responsavelprofissaonome2 = AV88ResponsavelProfissaoNome2;
         AV124Clientewwds_26_responsavelmunicipionome2 = AV89ResponsavelMunicipioNome2;
         AV125Clientewwds_27_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV126Clientewwds_28_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV127Clientewwds_29_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV128Clientewwds_30_clientedocumento3 = AV58ClienteDocumento3;
         AV129Clientewwds_31_tipoclientedescricao3 = AV63TipoClienteDescricao3;
         AV130Clientewwds_32_clienteconveniodescricao3 = AV90ClienteConvenioDescricao3;
         AV131Clientewwds_33_clientenacionalidadenome3 = AV91ClienteNacionalidadeNome3;
         AV132Clientewwds_34_clienteprofissaonome3 = AV92ClienteProfissaoNome3;
         AV133Clientewwds_35_municipionome3 = AV75MunicipioNome3;
         AV134Clientewwds_36_bancocodigo3 = AV93BancoCodigo3;
         AV135Clientewwds_37_responsavelnacionalidadenome3 = AV94ResponsavelNacionalidadeNome3;
         AV136Clientewwds_38_responsavelprofissaonome3 = AV95ResponsavelProfissaoNome3;
         AV137Clientewwds_39_responsavelmunicipionome3 = AV96ResponsavelMunicipioNome3;
         AV138Clientewwds_40_tftipoclientedescricao = AV65TFTipoClienteDescricao;
         AV139Clientewwds_41_tftipoclientedescricao_sel = AV66TFTipoClienteDescricao_Sel;
         AV140Clientewwds_42_tfclienterazaosocial = AV12TFClienteRazaoSocial;
         AV141Clientewwds_43_tfclienterazaosocial_sel = AV13TFClienteRazaoSocial_Sel;
         AV142Clientewwds_44_tfclientedocumento = AV16TFClienteDocumento;
         AV143Clientewwds_45_tfclientedocumento_sel = AV17TFClienteDocumento_Sel;
         AV144Clientewwds_46_tfclientetipopessoa_sels = AV19TFClienteTipoPessoa_Sels;
         AV145Clientewwds_47_tfclientestatus_sel = AV20TFClienteStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A172ClienteTipoPessoa ,
                                              AV144Clientewwds_46_tfclientetipopessoa_sels ,
                                              AV99Clientewwds_1_filterfulltext ,
                                              AV100Clientewwds_2_dynamicfiltersselector1 ,
                                              AV101Clientewwds_3_dynamicfiltersoperator1 ,
                                              AV102Clientewwds_4_clientedocumento1 ,
                                              AV103Clientewwds_5_tipoclientedescricao1 ,
                                              AV104Clientewwds_6_clienteconveniodescricao1 ,
                                              AV105Clientewwds_7_clientenacionalidadenome1 ,
                                              AV106Clientewwds_8_clienteprofissaonome1 ,
                                              AV107Clientewwds_9_municipionome1 ,
                                              AV108Clientewwds_10_bancocodigo1 ,
                                              AV109Clientewwds_11_responsavelnacionalidadenome1 ,
                                              AV110Clientewwds_12_responsavelprofissaonome1 ,
                                              AV111Clientewwds_13_responsavelmunicipionome1 ,
                                              AV112Clientewwds_14_dynamicfiltersenabled2 ,
                                              AV113Clientewwds_15_dynamicfiltersselector2 ,
                                              AV114Clientewwds_16_dynamicfiltersoperator2 ,
                                              AV115Clientewwds_17_clientedocumento2 ,
                                              AV116Clientewwds_18_tipoclientedescricao2 ,
                                              AV117Clientewwds_19_clienteconveniodescricao2 ,
                                              AV118Clientewwds_20_clientenacionalidadenome2 ,
                                              AV119Clientewwds_21_clienteprofissaonome2 ,
                                              AV120Clientewwds_22_municipionome2 ,
                                              AV121Clientewwds_23_bancocodigo2 ,
                                              AV122Clientewwds_24_responsavelnacionalidadenome2 ,
                                              AV123Clientewwds_25_responsavelprofissaonome2 ,
                                              AV124Clientewwds_26_responsavelmunicipionome2 ,
                                              AV125Clientewwds_27_dynamicfiltersenabled3 ,
                                              AV126Clientewwds_28_dynamicfiltersselector3 ,
                                              AV127Clientewwds_29_dynamicfiltersoperator3 ,
                                              AV128Clientewwds_30_clientedocumento3 ,
                                              AV129Clientewwds_31_tipoclientedescricao3 ,
                                              AV130Clientewwds_32_clienteconveniodescricao3 ,
                                              AV131Clientewwds_33_clientenacionalidadenome3 ,
                                              AV132Clientewwds_34_clienteprofissaonome3 ,
                                              AV133Clientewwds_35_municipionome3 ,
                                              AV134Clientewwds_36_bancocodigo3 ,
                                              AV135Clientewwds_37_responsavelnacionalidadenome3 ,
                                              AV136Clientewwds_38_responsavelprofissaonome3 ,
                                              AV137Clientewwds_39_responsavelmunicipionome3 ,
                                              AV139Clientewwds_41_tftipoclientedescricao_sel ,
                                              AV138Clientewwds_40_tftipoclientedescricao ,
                                              AV141Clientewwds_43_tfclienterazaosocial_sel ,
                                              AV140Clientewwds_42_tfclienterazaosocial ,
                                              AV143Clientewwds_45_tfclientedocumento_sel ,
                                              AV142Clientewwds_44_tfclientedocumento ,
                                              AV144Clientewwds_46_tfclientetipopessoa_sels.Count ,
                                              AV145Clientewwds_47_tfclientestatus_sel ,
                                              A193TipoClienteDescricao ,
                                              A170ClienteRazaoSocial ,
                                              A169ClienteDocumento ,
                                              A174ClienteStatus ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV102Clientewwds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV102Clientewwds_4_clientedocumento1), "%", "");
         lV102Clientewwds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV102Clientewwds_4_clientedocumento1), "%", "");
         lV103Clientewwds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV103Clientewwds_5_tipoclientedescricao1), "%", "");
         lV103Clientewwds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV103Clientewwds_5_tipoclientedescricao1), "%", "");
         lV104Clientewwds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV104Clientewwds_6_clienteconveniodescricao1), "%", "");
         lV104Clientewwds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV104Clientewwds_6_clienteconveniodescricao1), "%", "");
         lV105Clientewwds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV105Clientewwds_7_clientenacionalidadenome1), "%", "");
         lV105Clientewwds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV105Clientewwds_7_clientenacionalidadenome1), "%", "");
         lV106Clientewwds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV106Clientewwds_8_clienteprofissaonome1), "%", "");
         lV106Clientewwds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV106Clientewwds_8_clienteprofissaonome1), "%", "");
         lV107Clientewwds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV107Clientewwds_9_municipionome1), "%", "");
         lV107Clientewwds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV107Clientewwds_9_municipionome1), "%", "");
         lV109Clientewwds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV109Clientewwds_11_responsavelnacionalidadenome1), "%", "");
         lV109Clientewwds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV109Clientewwds_11_responsavelnacionalidadenome1), "%", "");
         lV110Clientewwds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV110Clientewwds_12_responsavelprofissaonome1), "%", "");
         lV110Clientewwds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV110Clientewwds_12_responsavelprofissaonome1), "%", "");
         lV111Clientewwds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV111Clientewwds_13_responsavelmunicipionome1), "%", "");
         lV111Clientewwds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV111Clientewwds_13_responsavelmunicipionome1), "%", "");
         lV115Clientewwds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV115Clientewwds_17_clientedocumento2), "%", "");
         lV115Clientewwds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV115Clientewwds_17_clientedocumento2), "%", "");
         lV116Clientewwds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_18_tipoclientedescricao2), "%", "");
         lV116Clientewwds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_18_tipoclientedescricao2), "%", "");
         lV117Clientewwds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV117Clientewwds_19_clienteconveniodescricao2), "%", "");
         lV117Clientewwds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV117Clientewwds_19_clienteconveniodescricao2), "%", "");
         lV118Clientewwds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV118Clientewwds_20_clientenacionalidadenome2), "%", "");
         lV118Clientewwds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV118Clientewwds_20_clientenacionalidadenome2), "%", "");
         lV119Clientewwds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV119Clientewwds_21_clienteprofissaonome2), "%", "");
         lV119Clientewwds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV119Clientewwds_21_clienteprofissaonome2), "%", "");
         lV120Clientewwds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV120Clientewwds_22_municipionome2), "%", "");
         lV120Clientewwds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV120Clientewwds_22_municipionome2), "%", "");
         lV122Clientewwds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV122Clientewwds_24_responsavelnacionalidadenome2), "%", "");
         lV122Clientewwds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV122Clientewwds_24_responsavelnacionalidadenome2), "%", "");
         lV123Clientewwds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV123Clientewwds_25_responsavelprofissaonome2), "%", "");
         lV123Clientewwds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV123Clientewwds_25_responsavelprofissaonome2), "%", "");
         lV124Clientewwds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV124Clientewwds_26_responsavelmunicipionome2), "%", "");
         lV124Clientewwds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV124Clientewwds_26_responsavelmunicipionome2), "%", "");
         lV128Clientewwds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV128Clientewwds_30_clientedocumento3), "%", "");
         lV128Clientewwds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV128Clientewwds_30_clientedocumento3), "%", "");
         lV129Clientewwds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV129Clientewwds_31_tipoclientedescricao3), "%", "");
         lV129Clientewwds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV129Clientewwds_31_tipoclientedescricao3), "%", "");
         lV130Clientewwds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV130Clientewwds_32_clienteconveniodescricao3), "%", "");
         lV130Clientewwds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV130Clientewwds_32_clienteconveniodescricao3), "%", "");
         lV131Clientewwds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV131Clientewwds_33_clientenacionalidadenome3), "%", "");
         lV131Clientewwds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV131Clientewwds_33_clientenacionalidadenome3), "%", "");
         lV132Clientewwds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV132Clientewwds_34_clienteprofissaonome3), "%", "");
         lV132Clientewwds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV132Clientewwds_34_clienteprofissaonome3), "%", "");
         lV133Clientewwds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV133Clientewwds_35_municipionome3), "%", "");
         lV133Clientewwds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV133Clientewwds_35_municipionome3), "%", "");
         lV135Clientewwds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV135Clientewwds_37_responsavelnacionalidadenome3), "%", "");
         lV135Clientewwds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV135Clientewwds_37_responsavelnacionalidadenome3), "%", "");
         lV136Clientewwds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV136Clientewwds_38_responsavelprofissaonome3), "%", "");
         lV136Clientewwds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV136Clientewwds_38_responsavelprofissaonome3), "%", "");
         lV137Clientewwds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV137Clientewwds_39_responsavelmunicipionome3), "%", "");
         lV137Clientewwds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV137Clientewwds_39_responsavelmunicipionome3), "%", "");
         lV138Clientewwds_40_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV138Clientewwds_40_tftipoclientedescricao), "%", "");
         lV140Clientewwds_42_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV140Clientewwds_42_tfclienterazaosocial), "%", "");
         lV142Clientewwds_44_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV142Clientewwds_44_tfclientedocumento), "%", "");
         /* Using cursor P00682 */
         pr_default.execute(0, new Object[] {lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV102Clientewwds_4_clientedocumento1, lV102Clientewwds_4_clientedocumento1, lV103Clientewwds_5_tipoclientedescricao1, lV103Clientewwds_5_tipoclientedescricao1, lV104Clientewwds_6_clienteconveniodescricao1, lV104Clientewwds_6_clienteconveniodescricao1, lV105Clientewwds_7_clientenacionalidadenome1, lV105Clientewwds_7_clientenacionalidadenome1, lV106Clientewwds_8_clienteprofissaonome1, lV106Clientewwds_8_clienteprofissaonome1, lV107Clientewwds_9_municipionome1, lV107Clientewwds_9_municipionome1, AV108Clientewwds_10_bancocodigo1, AV108Clientewwds_10_bancocodigo1, AV108Clientewwds_10_bancocodigo1, lV109Clientewwds_11_responsavelnacionalidadenome1, lV109Clientewwds_11_responsavelnacionalidadenome1, lV110Clientewwds_12_responsavelprofissaonome1, lV110Clientewwds_12_responsavelprofissaonome1, lV111Clientewwds_13_responsavelmunicipionome1, lV111Clientewwds_13_responsavelmunicipionome1, lV115Clientewwds_17_clientedocumento2, lV115Clientewwds_17_clientedocumento2, lV116Clientewwds_18_tipoclientedescricao2, lV116Clientewwds_18_tipoclientedescricao2, lV117Clientewwds_19_clienteconveniodescricao2, lV117Clientewwds_19_clienteconveniodescricao2, lV118Clientewwds_20_clientenacionalidadenome2, lV118Clientewwds_20_clientenacionalidadenome2, lV119Clientewwds_21_clienteprofissaonome2, lV119Clientewwds_21_clienteprofissaonome2, lV120Clientewwds_22_municipionome2, lV120Clientewwds_22_municipionome2, AV121Clientewwds_23_bancocodigo2, AV121Clientewwds_23_bancocodigo2, AV121Clientewwds_23_bancocodigo2, lV122Clientewwds_24_responsavelnacionalidadenome2, lV122Clientewwds_24_responsavelnacionalidadenome2, lV123Clientewwds_25_responsavelprofissaonome2, lV123Clientewwds_25_responsavelprofissaonome2, lV124Clientewwds_26_responsavelmunicipionome2, lV124Clientewwds_26_responsavelmunicipionome2, lV128Clientewwds_30_clientedocumento3, lV128Clientewwds_30_clientedocumento3, lV129Clientewwds_31_tipoclientedescricao3, lV129Clientewwds_31_tipoclientedescricao3, lV130Clientewwds_32_clienteconveniodescricao3, lV130Clientewwds_32_clienteconveniodescricao3, lV131Clientewwds_33_clientenacionalidadenome3, lV131Clientewwds_33_clientenacionalidadenome3, lV132Clientewwds_34_clienteprofissaonome3, lV132Clientewwds_34_clienteprofissaonome3, lV133Clientewwds_35_municipionome3, lV133Clientewwds_35_municipionome3, AV134Clientewwds_36_bancocodigo3, AV134Clientewwds_36_bancocodigo3, AV134Clientewwds_36_bancocodigo3, lV135Clientewwds_37_responsavelnacionalidadenome3, lV135Clientewwds_37_responsavelnacionalidadenome3, lV136Clientewwds_38_responsavelprofissaonome3, lV136Clientewwds_38_responsavelprofissaonome3, lV137Clientewwds_39_responsavelmunicipionome3, lV137Clientewwds_39_responsavelmunicipionome3, lV138Clientewwds_40_tftipoclientedescricao, AV139Clientewwds_41_tftipoclientedescricao_sel, lV140Clientewwds_42_tfclienterazaosocial, AV141Clientewwds_43_tfclienterazaosocial_sel, lV142Clientewwds_44_tfclientedocumento, AV143Clientewwds_45_tfclientedocumento_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK682 = false;
            A186MunicipioCodigo = P00682_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00682_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00682_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00682_n444ResponsavelMunicipio[0];
            A402BancoId = P00682_A402BancoId[0];
            n402BancoId = P00682_n402BancoId[0];
            A437ResponsavelNacionalidade = P00682_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00682_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00682_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00682_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00682_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00682_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00682_A487ClienteProfissao[0];
            n487ClienteProfissao = P00682_n487ClienteProfissao[0];
            A489ClienteConvenio = P00682_A489ClienteConvenio[0];
            n489ClienteConvenio = P00682_n489ClienteConvenio[0];
            A192TipoClienteId = P00682_A192TipoClienteId[0];
            n192TipoClienteId = P00682_n192TipoClienteId[0];
            A170ClienteRazaoSocial = P00682_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00682_n170ClienteRazaoSocial[0];
            A445ResponsavelMunicipioNome = P00682_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00682_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00682_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00682_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00682_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00682_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00682_A404BancoCodigo[0];
            n404BancoCodigo = P00682_n404BancoCodigo[0];
            A187MunicipioNome = P00682_A187MunicipioNome[0];
            n187MunicipioNome = P00682_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00682_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00682_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00682_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00682_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00682_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00682_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00682_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00682_n193TipoClienteDescricao[0];
            A169ClienteDocumento = P00682_A169ClienteDocumento[0];
            n169ClienteDocumento = P00682_n169ClienteDocumento[0];
            A174ClienteStatus = P00682_A174ClienteStatus[0];
            n174ClienteStatus = P00682_n174ClienteStatus[0];
            A172ClienteTipoPessoa = P00682_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = P00682_n172ClienteTipoPessoa[0];
            A168ClienteId = P00682_A168ClienteId[0];
            A187MunicipioNome = P00682_A187MunicipioNome[0];
            n187MunicipioNome = P00682_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00682_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00682_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00682_A404BancoCodigo[0];
            n404BancoCodigo = P00682_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00682_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00682_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00682_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00682_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00682_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00682_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00682_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00682_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00682_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00682_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00682_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00682_n193TipoClienteDescricao[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00682_A192TipoClienteId[0] == A192TipoClienteId ) )
            {
               BRK682 = false;
               A168ClienteId = P00682_A168ClienteId[0];
               AV35count = (long)(AV35count+1);
               BRK682 = true;
               pr_default.readNext(0);
            }
            AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A193TipoClienteDescricao)) ? "<#Empty#>" : A193TipoClienteDescricao);
            AV32OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A193TipoClienteDescricao, "@!")));
            AV29InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV30Option, "<#Empty#>") != 0 ) && ( AV29InsertIndex <= AV31Options.Count ) && ( ( StringUtil.StrCmp(((string)AV33OptionsDesc.Item(AV29InsertIndex)), AV32OptionDesc) < 0 ) || ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV29InsertIndex = (int)(AV29InsertIndex+1);
            }
            AV31Options.Add(AV30Option, AV29InsertIndex);
            AV33OptionsDesc.Add(AV32OptionDesc, AV29InsertIndex);
            AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), AV29InsertIndex);
            if ( AV31Options.Count == AV26SkipItems + 11 )
            {
               AV31Options.RemoveItem(AV31Options.Count);
               AV33OptionsDesc.RemoveItem(AV33OptionsDesc.Count);
               AV34OptionIndexes.RemoveItem(AV34OptionIndexes.Count);
            }
            if ( ! BRK682 )
            {
               BRK682 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV26SkipItems > 0 )
         {
            AV31Options.RemoveItem(1);
            AV33OptionsDesc.RemoveItem(1);
            AV34OptionIndexes.RemoveItem(1);
            AV26SkipItems = (short)(AV26SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV12TFClienteRazaoSocial = AV25SearchTxt;
         AV13TFClienteRazaoSocial_Sel = "";
         AV99Clientewwds_1_filterfulltext = AV47FilterFullText;
         AV100Clientewwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV101Clientewwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV102Clientewwds_4_clientedocumento1 = AV50ClienteDocumento1;
         AV103Clientewwds_5_tipoclientedescricao1 = AV59TipoClienteDescricao1;
         AV104Clientewwds_6_clienteconveniodescricao1 = AV76ClienteConvenioDescricao1;
         AV105Clientewwds_7_clientenacionalidadenome1 = AV77ClienteNacionalidadeNome1;
         AV106Clientewwds_8_clienteprofissaonome1 = AV78ClienteProfissaoNome1;
         AV107Clientewwds_9_municipionome1 = AV73MunicipioNome1;
         AV108Clientewwds_10_bancocodigo1 = AV79BancoCodigo1;
         AV109Clientewwds_11_responsavelnacionalidadenome1 = AV80ResponsavelNacionalidadeNome1;
         AV110Clientewwds_12_responsavelprofissaonome1 = AV81ResponsavelProfissaoNome1;
         AV111Clientewwds_13_responsavelmunicipionome1 = AV82ResponsavelMunicipioNome1;
         AV112Clientewwds_14_dynamicfiltersenabled2 = AV51DynamicFiltersEnabled2;
         AV113Clientewwds_15_dynamicfiltersselector2 = AV52DynamicFiltersSelector2;
         AV114Clientewwds_16_dynamicfiltersoperator2 = AV53DynamicFiltersOperator2;
         AV115Clientewwds_17_clientedocumento2 = AV54ClienteDocumento2;
         AV116Clientewwds_18_tipoclientedescricao2 = AV61TipoClienteDescricao2;
         AV117Clientewwds_19_clienteconveniodescricao2 = AV83ClienteConvenioDescricao2;
         AV118Clientewwds_20_clientenacionalidadenome2 = AV84ClienteNacionalidadeNome2;
         AV119Clientewwds_21_clienteprofissaonome2 = AV85ClienteProfissaoNome2;
         AV120Clientewwds_22_municipionome2 = AV74MunicipioNome2;
         AV121Clientewwds_23_bancocodigo2 = AV86BancoCodigo2;
         AV122Clientewwds_24_responsavelnacionalidadenome2 = AV87ResponsavelNacionalidadeNome2;
         AV123Clientewwds_25_responsavelprofissaonome2 = AV88ResponsavelProfissaoNome2;
         AV124Clientewwds_26_responsavelmunicipionome2 = AV89ResponsavelMunicipioNome2;
         AV125Clientewwds_27_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV126Clientewwds_28_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV127Clientewwds_29_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV128Clientewwds_30_clientedocumento3 = AV58ClienteDocumento3;
         AV129Clientewwds_31_tipoclientedescricao3 = AV63TipoClienteDescricao3;
         AV130Clientewwds_32_clienteconveniodescricao3 = AV90ClienteConvenioDescricao3;
         AV131Clientewwds_33_clientenacionalidadenome3 = AV91ClienteNacionalidadeNome3;
         AV132Clientewwds_34_clienteprofissaonome3 = AV92ClienteProfissaoNome3;
         AV133Clientewwds_35_municipionome3 = AV75MunicipioNome3;
         AV134Clientewwds_36_bancocodigo3 = AV93BancoCodigo3;
         AV135Clientewwds_37_responsavelnacionalidadenome3 = AV94ResponsavelNacionalidadeNome3;
         AV136Clientewwds_38_responsavelprofissaonome3 = AV95ResponsavelProfissaoNome3;
         AV137Clientewwds_39_responsavelmunicipionome3 = AV96ResponsavelMunicipioNome3;
         AV138Clientewwds_40_tftipoclientedescricao = AV65TFTipoClienteDescricao;
         AV139Clientewwds_41_tftipoclientedescricao_sel = AV66TFTipoClienteDescricao_Sel;
         AV140Clientewwds_42_tfclienterazaosocial = AV12TFClienteRazaoSocial;
         AV141Clientewwds_43_tfclienterazaosocial_sel = AV13TFClienteRazaoSocial_Sel;
         AV142Clientewwds_44_tfclientedocumento = AV16TFClienteDocumento;
         AV143Clientewwds_45_tfclientedocumento_sel = AV17TFClienteDocumento_Sel;
         AV144Clientewwds_46_tfclientetipopessoa_sels = AV19TFClienteTipoPessoa_Sels;
         AV145Clientewwds_47_tfclientestatus_sel = AV20TFClienteStatus_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A172ClienteTipoPessoa ,
                                              AV144Clientewwds_46_tfclientetipopessoa_sels ,
                                              AV99Clientewwds_1_filterfulltext ,
                                              AV100Clientewwds_2_dynamicfiltersselector1 ,
                                              AV101Clientewwds_3_dynamicfiltersoperator1 ,
                                              AV102Clientewwds_4_clientedocumento1 ,
                                              AV103Clientewwds_5_tipoclientedescricao1 ,
                                              AV104Clientewwds_6_clienteconveniodescricao1 ,
                                              AV105Clientewwds_7_clientenacionalidadenome1 ,
                                              AV106Clientewwds_8_clienteprofissaonome1 ,
                                              AV107Clientewwds_9_municipionome1 ,
                                              AV108Clientewwds_10_bancocodigo1 ,
                                              AV109Clientewwds_11_responsavelnacionalidadenome1 ,
                                              AV110Clientewwds_12_responsavelprofissaonome1 ,
                                              AV111Clientewwds_13_responsavelmunicipionome1 ,
                                              AV112Clientewwds_14_dynamicfiltersenabled2 ,
                                              AV113Clientewwds_15_dynamicfiltersselector2 ,
                                              AV114Clientewwds_16_dynamicfiltersoperator2 ,
                                              AV115Clientewwds_17_clientedocumento2 ,
                                              AV116Clientewwds_18_tipoclientedescricao2 ,
                                              AV117Clientewwds_19_clienteconveniodescricao2 ,
                                              AV118Clientewwds_20_clientenacionalidadenome2 ,
                                              AV119Clientewwds_21_clienteprofissaonome2 ,
                                              AV120Clientewwds_22_municipionome2 ,
                                              AV121Clientewwds_23_bancocodigo2 ,
                                              AV122Clientewwds_24_responsavelnacionalidadenome2 ,
                                              AV123Clientewwds_25_responsavelprofissaonome2 ,
                                              AV124Clientewwds_26_responsavelmunicipionome2 ,
                                              AV125Clientewwds_27_dynamicfiltersenabled3 ,
                                              AV126Clientewwds_28_dynamicfiltersselector3 ,
                                              AV127Clientewwds_29_dynamicfiltersoperator3 ,
                                              AV128Clientewwds_30_clientedocumento3 ,
                                              AV129Clientewwds_31_tipoclientedescricao3 ,
                                              AV130Clientewwds_32_clienteconveniodescricao3 ,
                                              AV131Clientewwds_33_clientenacionalidadenome3 ,
                                              AV132Clientewwds_34_clienteprofissaonome3 ,
                                              AV133Clientewwds_35_municipionome3 ,
                                              AV134Clientewwds_36_bancocodigo3 ,
                                              AV135Clientewwds_37_responsavelnacionalidadenome3 ,
                                              AV136Clientewwds_38_responsavelprofissaonome3 ,
                                              AV137Clientewwds_39_responsavelmunicipionome3 ,
                                              AV139Clientewwds_41_tftipoclientedescricao_sel ,
                                              AV138Clientewwds_40_tftipoclientedescricao ,
                                              AV141Clientewwds_43_tfclienterazaosocial_sel ,
                                              AV140Clientewwds_42_tfclienterazaosocial ,
                                              AV143Clientewwds_45_tfclientedocumento_sel ,
                                              AV142Clientewwds_44_tfclientedocumento ,
                                              AV144Clientewwds_46_tfclientetipopessoa_sels.Count ,
                                              AV145Clientewwds_47_tfclientestatus_sel ,
                                              A193TipoClienteDescricao ,
                                              A170ClienteRazaoSocial ,
                                              A169ClienteDocumento ,
                                              A174ClienteStatus ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV102Clientewwds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV102Clientewwds_4_clientedocumento1), "%", "");
         lV102Clientewwds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV102Clientewwds_4_clientedocumento1), "%", "");
         lV103Clientewwds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV103Clientewwds_5_tipoclientedescricao1), "%", "");
         lV103Clientewwds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV103Clientewwds_5_tipoclientedescricao1), "%", "");
         lV104Clientewwds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV104Clientewwds_6_clienteconveniodescricao1), "%", "");
         lV104Clientewwds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV104Clientewwds_6_clienteconveniodescricao1), "%", "");
         lV105Clientewwds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV105Clientewwds_7_clientenacionalidadenome1), "%", "");
         lV105Clientewwds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV105Clientewwds_7_clientenacionalidadenome1), "%", "");
         lV106Clientewwds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV106Clientewwds_8_clienteprofissaonome1), "%", "");
         lV106Clientewwds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV106Clientewwds_8_clienteprofissaonome1), "%", "");
         lV107Clientewwds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV107Clientewwds_9_municipionome1), "%", "");
         lV107Clientewwds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV107Clientewwds_9_municipionome1), "%", "");
         lV109Clientewwds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV109Clientewwds_11_responsavelnacionalidadenome1), "%", "");
         lV109Clientewwds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV109Clientewwds_11_responsavelnacionalidadenome1), "%", "");
         lV110Clientewwds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV110Clientewwds_12_responsavelprofissaonome1), "%", "");
         lV110Clientewwds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV110Clientewwds_12_responsavelprofissaonome1), "%", "");
         lV111Clientewwds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV111Clientewwds_13_responsavelmunicipionome1), "%", "");
         lV111Clientewwds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV111Clientewwds_13_responsavelmunicipionome1), "%", "");
         lV115Clientewwds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV115Clientewwds_17_clientedocumento2), "%", "");
         lV115Clientewwds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV115Clientewwds_17_clientedocumento2), "%", "");
         lV116Clientewwds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_18_tipoclientedescricao2), "%", "");
         lV116Clientewwds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_18_tipoclientedescricao2), "%", "");
         lV117Clientewwds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV117Clientewwds_19_clienteconveniodescricao2), "%", "");
         lV117Clientewwds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV117Clientewwds_19_clienteconveniodescricao2), "%", "");
         lV118Clientewwds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV118Clientewwds_20_clientenacionalidadenome2), "%", "");
         lV118Clientewwds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV118Clientewwds_20_clientenacionalidadenome2), "%", "");
         lV119Clientewwds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV119Clientewwds_21_clienteprofissaonome2), "%", "");
         lV119Clientewwds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV119Clientewwds_21_clienteprofissaonome2), "%", "");
         lV120Clientewwds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV120Clientewwds_22_municipionome2), "%", "");
         lV120Clientewwds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV120Clientewwds_22_municipionome2), "%", "");
         lV122Clientewwds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV122Clientewwds_24_responsavelnacionalidadenome2), "%", "");
         lV122Clientewwds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV122Clientewwds_24_responsavelnacionalidadenome2), "%", "");
         lV123Clientewwds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV123Clientewwds_25_responsavelprofissaonome2), "%", "");
         lV123Clientewwds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV123Clientewwds_25_responsavelprofissaonome2), "%", "");
         lV124Clientewwds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV124Clientewwds_26_responsavelmunicipionome2), "%", "");
         lV124Clientewwds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV124Clientewwds_26_responsavelmunicipionome2), "%", "");
         lV128Clientewwds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV128Clientewwds_30_clientedocumento3), "%", "");
         lV128Clientewwds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV128Clientewwds_30_clientedocumento3), "%", "");
         lV129Clientewwds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV129Clientewwds_31_tipoclientedescricao3), "%", "");
         lV129Clientewwds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV129Clientewwds_31_tipoclientedescricao3), "%", "");
         lV130Clientewwds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV130Clientewwds_32_clienteconveniodescricao3), "%", "");
         lV130Clientewwds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV130Clientewwds_32_clienteconveniodescricao3), "%", "");
         lV131Clientewwds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV131Clientewwds_33_clientenacionalidadenome3), "%", "");
         lV131Clientewwds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV131Clientewwds_33_clientenacionalidadenome3), "%", "");
         lV132Clientewwds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV132Clientewwds_34_clienteprofissaonome3), "%", "");
         lV132Clientewwds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV132Clientewwds_34_clienteprofissaonome3), "%", "");
         lV133Clientewwds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV133Clientewwds_35_municipionome3), "%", "");
         lV133Clientewwds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV133Clientewwds_35_municipionome3), "%", "");
         lV135Clientewwds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV135Clientewwds_37_responsavelnacionalidadenome3), "%", "");
         lV135Clientewwds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV135Clientewwds_37_responsavelnacionalidadenome3), "%", "");
         lV136Clientewwds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV136Clientewwds_38_responsavelprofissaonome3), "%", "");
         lV136Clientewwds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV136Clientewwds_38_responsavelprofissaonome3), "%", "");
         lV137Clientewwds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV137Clientewwds_39_responsavelmunicipionome3), "%", "");
         lV137Clientewwds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV137Clientewwds_39_responsavelmunicipionome3), "%", "");
         lV138Clientewwds_40_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV138Clientewwds_40_tftipoclientedescricao), "%", "");
         lV140Clientewwds_42_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV140Clientewwds_42_tfclienterazaosocial), "%", "");
         lV142Clientewwds_44_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV142Clientewwds_44_tfclientedocumento), "%", "");
         /* Using cursor P00683 */
         pr_default.execute(1, new Object[] {lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV102Clientewwds_4_clientedocumento1, lV102Clientewwds_4_clientedocumento1, lV103Clientewwds_5_tipoclientedescricao1, lV103Clientewwds_5_tipoclientedescricao1, lV104Clientewwds_6_clienteconveniodescricao1, lV104Clientewwds_6_clienteconveniodescricao1, lV105Clientewwds_7_clientenacionalidadenome1, lV105Clientewwds_7_clientenacionalidadenome1, lV106Clientewwds_8_clienteprofissaonome1, lV106Clientewwds_8_clienteprofissaonome1, lV107Clientewwds_9_municipionome1, lV107Clientewwds_9_municipionome1, AV108Clientewwds_10_bancocodigo1, AV108Clientewwds_10_bancocodigo1, AV108Clientewwds_10_bancocodigo1, lV109Clientewwds_11_responsavelnacionalidadenome1, lV109Clientewwds_11_responsavelnacionalidadenome1, lV110Clientewwds_12_responsavelprofissaonome1, lV110Clientewwds_12_responsavelprofissaonome1, lV111Clientewwds_13_responsavelmunicipionome1, lV111Clientewwds_13_responsavelmunicipionome1, lV115Clientewwds_17_clientedocumento2, lV115Clientewwds_17_clientedocumento2, lV116Clientewwds_18_tipoclientedescricao2, lV116Clientewwds_18_tipoclientedescricao2, lV117Clientewwds_19_clienteconveniodescricao2, lV117Clientewwds_19_clienteconveniodescricao2, lV118Clientewwds_20_clientenacionalidadenome2, lV118Clientewwds_20_clientenacionalidadenome2, lV119Clientewwds_21_clienteprofissaonome2, lV119Clientewwds_21_clienteprofissaonome2, lV120Clientewwds_22_municipionome2, lV120Clientewwds_22_municipionome2, AV121Clientewwds_23_bancocodigo2, AV121Clientewwds_23_bancocodigo2, AV121Clientewwds_23_bancocodigo2, lV122Clientewwds_24_responsavelnacionalidadenome2, lV122Clientewwds_24_responsavelnacionalidadenome2, lV123Clientewwds_25_responsavelprofissaonome2, lV123Clientewwds_25_responsavelprofissaonome2, lV124Clientewwds_26_responsavelmunicipionome2, lV124Clientewwds_26_responsavelmunicipionome2, lV128Clientewwds_30_clientedocumento3, lV128Clientewwds_30_clientedocumento3, lV129Clientewwds_31_tipoclientedescricao3, lV129Clientewwds_31_tipoclientedescricao3, lV130Clientewwds_32_clienteconveniodescricao3, lV130Clientewwds_32_clienteconveniodescricao3, lV131Clientewwds_33_clientenacionalidadenome3, lV131Clientewwds_33_clientenacionalidadenome3, lV132Clientewwds_34_clienteprofissaonome3, lV132Clientewwds_34_clienteprofissaonome3, lV133Clientewwds_35_municipionome3, lV133Clientewwds_35_municipionome3, AV134Clientewwds_36_bancocodigo3, AV134Clientewwds_36_bancocodigo3, AV134Clientewwds_36_bancocodigo3, lV135Clientewwds_37_responsavelnacionalidadenome3, lV135Clientewwds_37_responsavelnacionalidadenome3, lV136Clientewwds_38_responsavelprofissaonome3, lV136Clientewwds_38_responsavelprofissaonome3, lV137Clientewwds_39_responsavelmunicipionome3, lV137Clientewwds_39_responsavelmunicipionome3, lV138Clientewwds_40_tftipoclientedescricao, AV139Clientewwds_41_tftipoclientedescricao_sel, lV140Clientewwds_42_tfclienterazaosocial, AV141Clientewwds_43_tfclienterazaosocial_sel, lV142Clientewwds_44_tfclientedocumento, AV143Clientewwds_45_tfclientedocumento_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK684 = false;
            A192TipoClienteId = P00683_A192TipoClienteId[0];
            n192TipoClienteId = P00683_n192TipoClienteId[0];
            A186MunicipioCodigo = P00683_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00683_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00683_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00683_n444ResponsavelMunicipio[0];
            A402BancoId = P00683_A402BancoId[0];
            n402BancoId = P00683_n402BancoId[0];
            A437ResponsavelNacionalidade = P00683_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00683_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00683_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00683_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00683_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00683_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00683_A487ClienteProfissao[0];
            n487ClienteProfissao = P00683_n487ClienteProfissao[0];
            A489ClienteConvenio = P00683_A489ClienteConvenio[0];
            n489ClienteConvenio = P00683_n489ClienteConvenio[0];
            A170ClienteRazaoSocial = P00683_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00683_n170ClienteRazaoSocial[0];
            A445ResponsavelMunicipioNome = P00683_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00683_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00683_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00683_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00683_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00683_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00683_A404BancoCodigo[0];
            n404BancoCodigo = P00683_n404BancoCodigo[0];
            A187MunicipioNome = P00683_A187MunicipioNome[0];
            n187MunicipioNome = P00683_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00683_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00683_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00683_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00683_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00683_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00683_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00683_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00683_n193TipoClienteDescricao[0];
            A169ClienteDocumento = P00683_A169ClienteDocumento[0];
            n169ClienteDocumento = P00683_n169ClienteDocumento[0];
            A174ClienteStatus = P00683_A174ClienteStatus[0];
            n174ClienteStatus = P00683_n174ClienteStatus[0];
            A172ClienteTipoPessoa = P00683_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = P00683_n172ClienteTipoPessoa[0];
            A168ClienteId = P00683_A168ClienteId[0];
            A193TipoClienteDescricao = P00683_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00683_n193TipoClienteDescricao[0];
            A187MunicipioNome = P00683_A187MunicipioNome[0];
            n187MunicipioNome = P00683_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00683_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00683_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00683_A404BancoCodigo[0];
            n404BancoCodigo = P00683_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00683_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00683_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00683_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00683_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00683_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00683_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00683_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00683_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00683_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00683_n490ClienteConvenioDescricao[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00683_A170ClienteRazaoSocial[0], A170ClienteRazaoSocial) == 0 ) )
            {
               BRK684 = false;
               A168ClienteId = P00683_A168ClienteId[0];
               AV35count = (long)(AV35count+1);
               BRK684 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ClienteRazaoSocial)) ? "<#Empty#>" : A170ClienteRazaoSocial);
               AV32OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")));
               AV31Options.Add(AV30Option, 0);
               AV33OptionsDesc.Add(AV32OptionDesc, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK684 )
            {
               BRK684 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCLIENTEDOCUMENTOOPTIONS' Routine */
         returnInSub = false;
         AV16TFClienteDocumento = AV25SearchTxt;
         AV17TFClienteDocumento_Sel = "";
         AV99Clientewwds_1_filterfulltext = AV47FilterFullText;
         AV100Clientewwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV101Clientewwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV102Clientewwds_4_clientedocumento1 = AV50ClienteDocumento1;
         AV103Clientewwds_5_tipoclientedescricao1 = AV59TipoClienteDescricao1;
         AV104Clientewwds_6_clienteconveniodescricao1 = AV76ClienteConvenioDescricao1;
         AV105Clientewwds_7_clientenacionalidadenome1 = AV77ClienteNacionalidadeNome1;
         AV106Clientewwds_8_clienteprofissaonome1 = AV78ClienteProfissaoNome1;
         AV107Clientewwds_9_municipionome1 = AV73MunicipioNome1;
         AV108Clientewwds_10_bancocodigo1 = AV79BancoCodigo1;
         AV109Clientewwds_11_responsavelnacionalidadenome1 = AV80ResponsavelNacionalidadeNome1;
         AV110Clientewwds_12_responsavelprofissaonome1 = AV81ResponsavelProfissaoNome1;
         AV111Clientewwds_13_responsavelmunicipionome1 = AV82ResponsavelMunicipioNome1;
         AV112Clientewwds_14_dynamicfiltersenabled2 = AV51DynamicFiltersEnabled2;
         AV113Clientewwds_15_dynamicfiltersselector2 = AV52DynamicFiltersSelector2;
         AV114Clientewwds_16_dynamicfiltersoperator2 = AV53DynamicFiltersOperator2;
         AV115Clientewwds_17_clientedocumento2 = AV54ClienteDocumento2;
         AV116Clientewwds_18_tipoclientedescricao2 = AV61TipoClienteDescricao2;
         AV117Clientewwds_19_clienteconveniodescricao2 = AV83ClienteConvenioDescricao2;
         AV118Clientewwds_20_clientenacionalidadenome2 = AV84ClienteNacionalidadeNome2;
         AV119Clientewwds_21_clienteprofissaonome2 = AV85ClienteProfissaoNome2;
         AV120Clientewwds_22_municipionome2 = AV74MunicipioNome2;
         AV121Clientewwds_23_bancocodigo2 = AV86BancoCodigo2;
         AV122Clientewwds_24_responsavelnacionalidadenome2 = AV87ResponsavelNacionalidadeNome2;
         AV123Clientewwds_25_responsavelprofissaonome2 = AV88ResponsavelProfissaoNome2;
         AV124Clientewwds_26_responsavelmunicipionome2 = AV89ResponsavelMunicipioNome2;
         AV125Clientewwds_27_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV126Clientewwds_28_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV127Clientewwds_29_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV128Clientewwds_30_clientedocumento3 = AV58ClienteDocumento3;
         AV129Clientewwds_31_tipoclientedescricao3 = AV63TipoClienteDescricao3;
         AV130Clientewwds_32_clienteconveniodescricao3 = AV90ClienteConvenioDescricao3;
         AV131Clientewwds_33_clientenacionalidadenome3 = AV91ClienteNacionalidadeNome3;
         AV132Clientewwds_34_clienteprofissaonome3 = AV92ClienteProfissaoNome3;
         AV133Clientewwds_35_municipionome3 = AV75MunicipioNome3;
         AV134Clientewwds_36_bancocodigo3 = AV93BancoCodigo3;
         AV135Clientewwds_37_responsavelnacionalidadenome3 = AV94ResponsavelNacionalidadeNome3;
         AV136Clientewwds_38_responsavelprofissaonome3 = AV95ResponsavelProfissaoNome3;
         AV137Clientewwds_39_responsavelmunicipionome3 = AV96ResponsavelMunicipioNome3;
         AV138Clientewwds_40_tftipoclientedescricao = AV65TFTipoClienteDescricao;
         AV139Clientewwds_41_tftipoclientedescricao_sel = AV66TFTipoClienteDescricao_Sel;
         AV140Clientewwds_42_tfclienterazaosocial = AV12TFClienteRazaoSocial;
         AV141Clientewwds_43_tfclienterazaosocial_sel = AV13TFClienteRazaoSocial_Sel;
         AV142Clientewwds_44_tfclientedocumento = AV16TFClienteDocumento;
         AV143Clientewwds_45_tfclientedocumento_sel = AV17TFClienteDocumento_Sel;
         AV144Clientewwds_46_tfclientetipopessoa_sels = AV19TFClienteTipoPessoa_Sels;
         AV145Clientewwds_47_tfclientestatus_sel = AV20TFClienteStatus_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A172ClienteTipoPessoa ,
                                              AV144Clientewwds_46_tfclientetipopessoa_sels ,
                                              AV99Clientewwds_1_filterfulltext ,
                                              AV100Clientewwds_2_dynamicfiltersselector1 ,
                                              AV101Clientewwds_3_dynamicfiltersoperator1 ,
                                              AV102Clientewwds_4_clientedocumento1 ,
                                              AV103Clientewwds_5_tipoclientedescricao1 ,
                                              AV104Clientewwds_6_clienteconveniodescricao1 ,
                                              AV105Clientewwds_7_clientenacionalidadenome1 ,
                                              AV106Clientewwds_8_clienteprofissaonome1 ,
                                              AV107Clientewwds_9_municipionome1 ,
                                              AV108Clientewwds_10_bancocodigo1 ,
                                              AV109Clientewwds_11_responsavelnacionalidadenome1 ,
                                              AV110Clientewwds_12_responsavelprofissaonome1 ,
                                              AV111Clientewwds_13_responsavelmunicipionome1 ,
                                              AV112Clientewwds_14_dynamicfiltersenabled2 ,
                                              AV113Clientewwds_15_dynamicfiltersselector2 ,
                                              AV114Clientewwds_16_dynamicfiltersoperator2 ,
                                              AV115Clientewwds_17_clientedocumento2 ,
                                              AV116Clientewwds_18_tipoclientedescricao2 ,
                                              AV117Clientewwds_19_clienteconveniodescricao2 ,
                                              AV118Clientewwds_20_clientenacionalidadenome2 ,
                                              AV119Clientewwds_21_clienteprofissaonome2 ,
                                              AV120Clientewwds_22_municipionome2 ,
                                              AV121Clientewwds_23_bancocodigo2 ,
                                              AV122Clientewwds_24_responsavelnacionalidadenome2 ,
                                              AV123Clientewwds_25_responsavelprofissaonome2 ,
                                              AV124Clientewwds_26_responsavelmunicipionome2 ,
                                              AV125Clientewwds_27_dynamicfiltersenabled3 ,
                                              AV126Clientewwds_28_dynamicfiltersselector3 ,
                                              AV127Clientewwds_29_dynamicfiltersoperator3 ,
                                              AV128Clientewwds_30_clientedocumento3 ,
                                              AV129Clientewwds_31_tipoclientedescricao3 ,
                                              AV130Clientewwds_32_clienteconveniodescricao3 ,
                                              AV131Clientewwds_33_clientenacionalidadenome3 ,
                                              AV132Clientewwds_34_clienteprofissaonome3 ,
                                              AV133Clientewwds_35_municipionome3 ,
                                              AV134Clientewwds_36_bancocodigo3 ,
                                              AV135Clientewwds_37_responsavelnacionalidadenome3 ,
                                              AV136Clientewwds_38_responsavelprofissaonome3 ,
                                              AV137Clientewwds_39_responsavelmunicipionome3 ,
                                              AV139Clientewwds_41_tftipoclientedescricao_sel ,
                                              AV138Clientewwds_40_tftipoclientedescricao ,
                                              AV141Clientewwds_43_tfclienterazaosocial_sel ,
                                              AV140Clientewwds_42_tfclienterazaosocial ,
                                              AV143Clientewwds_45_tfclientedocumento_sel ,
                                              AV142Clientewwds_44_tfclientedocumento ,
                                              AV144Clientewwds_46_tfclientetipopessoa_sels.Count ,
                                              AV145Clientewwds_47_tfclientestatus_sel ,
                                              A193TipoClienteDescricao ,
                                              A170ClienteRazaoSocial ,
                                              A169ClienteDocumento ,
                                              A174ClienteStatus ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV99Clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV99Clientewwds_1_filterfulltext), "%", "");
         lV102Clientewwds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV102Clientewwds_4_clientedocumento1), "%", "");
         lV102Clientewwds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV102Clientewwds_4_clientedocumento1), "%", "");
         lV103Clientewwds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV103Clientewwds_5_tipoclientedescricao1), "%", "");
         lV103Clientewwds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV103Clientewwds_5_tipoclientedescricao1), "%", "");
         lV104Clientewwds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV104Clientewwds_6_clienteconveniodescricao1), "%", "");
         lV104Clientewwds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV104Clientewwds_6_clienteconveniodescricao1), "%", "");
         lV105Clientewwds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV105Clientewwds_7_clientenacionalidadenome1), "%", "");
         lV105Clientewwds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV105Clientewwds_7_clientenacionalidadenome1), "%", "");
         lV106Clientewwds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV106Clientewwds_8_clienteprofissaonome1), "%", "");
         lV106Clientewwds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV106Clientewwds_8_clienteprofissaonome1), "%", "");
         lV107Clientewwds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV107Clientewwds_9_municipionome1), "%", "");
         lV107Clientewwds_9_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV107Clientewwds_9_municipionome1), "%", "");
         lV109Clientewwds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV109Clientewwds_11_responsavelnacionalidadenome1), "%", "");
         lV109Clientewwds_11_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV109Clientewwds_11_responsavelnacionalidadenome1), "%", "");
         lV110Clientewwds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV110Clientewwds_12_responsavelprofissaonome1), "%", "");
         lV110Clientewwds_12_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV110Clientewwds_12_responsavelprofissaonome1), "%", "");
         lV111Clientewwds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV111Clientewwds_13_responsavelmunicipionome1), "%", "");
         lV111Clientewwds_13_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV111Clientewwds_13_responsavelmunicipionome1), "%", "");
         lV115Clientewwds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV115Clientewwds_17_clientedocumento2), "%", "");
         lV115Clientewwds_17_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV115Clientewwds_17_clientedocumento2), "%", "");
         lV116Clientewwds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_18_tipoclientedescricao2), "%", "");
         lV116Clientewwds_18_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV116Clientewwds_18_tipoclientedescricao2), "%", "");
         lV117Clientewwds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV117Clientewwds_19_clienteconveniodescricao2), "%", "");
         lV117Clientewwds_19_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV117Clientewwds_19_clienteconveniodescricao2), "%", "");
         lV118Clientewwds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV118Clientewwds_20_clientenacionalidadenome2), "%", "");
         lV118Clientewwds_20_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV118Clientewwds_20_clientenacionalidadenome2), "%", "");
         lV119Clientewwds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV119Clientewwds_21_clienteprofissaonome2), "%", "");
         lV119Clientewwds_21_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV119Clientewwds_21_clienteprofissaonome2), "%", "");
         lV120Clientewwds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV120Clientewwds_22_municipionome2), "%", "");
         lV120Clientewwds_22_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV120Clientewwds_22_municipionome2), "%", "");
         lV122Clientewwds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV122Clientewwds_24_responsavelnacionalidadenome2), "%", "");
         lV122Clientewwds_24_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV122Clientewwds_24_responsavelnacionalidadenome2), "%", "");
         lV123Clientewwds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV123Clientewwds_25_responsavelprofissaonome2), "%", "");
         lV123Clientewwds_25_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV123Clientewwds_25_responsavelprofissaonome2), "%", "");
         lV124Clientewwds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV124Clientewwds_26_responsavelmunicipionome2), "%", "");
         lV124Clientewwds_26_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV124Clientewwds_26_responsavelmunicipionome2), "%", "");
         lV128Clientewwds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV128Clientewwds_30_clientedocumento3), "%", "");
         lV128Clientewwds_30_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV128Clientewwds_30_clientedocumento3), "%", "");
         lV129Clientewwds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV129Clientewwds_31_tipoclientedescricao3), "%", "");
         lV129Clientewwds_31_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV129Clientewwds_31_tipoclientedescricao3), "%", "");
         lV130Clientewwds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV130Clientewwds_32_clienteconveniodescricao3), "%", "");
         lV130Clientewwds_32_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV130Clientewwds_32_clienteconveniodescricao3), "%", "");
         lV131Clientewwds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV131Clientewwds_33_clientenacionalidadenome3), "%", "");
         lV131Clientewwds_33_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV131Clientewwds_33_clientenacionalidadenome3), "%", "");
         lV132Clientewwds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV132Clientewwds_34_clienteprofissaonome3), "%", "");
         lV132Clientewwds_34_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV132Clientewwds_34_clienteprofissaonome3), "%", "");
         lV133Clientewwds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV133Clientewwds_35_municipionome3), "%", "");
         lV133Clientewwds_35_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV133Clientewwds_35_municipionome3), "%", "");
         lV135Clientewwds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV135Clientewwds_37_responsavelnacionalidadenome3), "%", "");
         lV135Clientewwds_37_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV135Clientewwds_37_responsavelnacionalidadenome3), "%", "");
         lV136Clientewwds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV136Clientewwds_38_responsavelprofissaonome3), "%", "");
         lV136Clientewwds_38_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV136Clientewwds_38_responsavelprofissaonome3), "%", "");
         lV137Clientewwds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV137Clientewwds_39_responsavelmunicipionome3), "%", "");
         lV137Clientewwds_39_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV137Clientewwds_39_responsavelmunicipionome3), "%", "");
         lV138Clientewwds_40_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV138Clientewwds_40_tftipoclientedescricao), "%", "");
         lV140Clientewwds_42_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV140Clientewwds_42_tfclienterazaosocial), "%", "");
         lV142Clientewwds_44_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV142Clientewwds_44_tfclientedocumento), "%", "");
         /* Using cursor P00684 */
         pr_default.execute(2, new Object[] {lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV99Clientewwds_1_filterfulltext, lV102Clientewwds_4_clientedocumento1, lV102Clientewwds_4_clientedocumento1, lV103Clientewwds_5_tipoclientedescricao1, lV103Clientewwds_5_tipoclientedescricao1, lV104Clientewwds_6_clienteconveniodescricao1, lV104Clientewwds_6_clienteconveniodescricao1, lV105Clientewwds_7_clientenacionalidadenome1, lV105Clientewwds_7_clientenacionalidadenome1, lV106Clientewwds_8_clienteprofissaonome1, lV106Clientewwds_8_clienteprofissaonome1, lV107Clientewwds_9_municipionome1, lV107Clientewwds_9_municipionome1, AV108Clientewwds_10_bancocodigo1, AV108Clientewwds_10_bancocodigo1, AV108Clientewwds_10_bancocodigo1, lV109Clientewwds_11_responsavelnacionalidadenome1, lV109Clientewwds_11_responsavelnacionalidadenome1, lV110Clientewwds_12_responsavelprofissaonome1, lV110Clientewwds_12_responsavelprofissaonome1, lV111Clientewwds_13_responsavelmunicipionome1, lV111Clientewwds_13_responsavelmunicipionome1, lV115Clientewwds_17_clientedocumento2, lV115Clientewwds_17_clientedocumento2, lV116Clientewwds_18_tipoclientedescricao2, lV116Clientewwds_18_tipoclientedescricao2, lV117Clientewwds_19_clienteconveniodescricao2, lV117Clientewwds_19_clienteconveniodescricao2, lV118Clientewwds_20_clientenacionalidadenome2, lV118Clientewwds_20_clientenacionalidadenome2, lV119Clientewwds_21_clienteprofissaonome2, lV119Clientewwds_21_clienteprofissaonome2, lV120Clientewwds_22_municipionome2, lV120Clientewwds_22_municipionome2, AV121Clientewwds_23_bancocodigo2, AV121Clientewwds_23_bancocodigo2, AV121Clientewwds_23_bancocodigo2, lV122Clientewwds_24_responsavelnacionalidadenome2, lV122Clientewwds_24_responsavelnacionalidadenome2, lV123Clientewwds_25_responsavelprofissaonome2, lV123Clientewwds_25_responsavelprofissaonome2, lV124Clientewwds_26_responsavelmunicipionome2, lV124Clientewwds_26_responsavelmunicipionome2, lV128Clientewwds_30_clientedocumento3, lV128Clientewwds_30_clientedocumento3, lV129Clientewwds_31_tipoclientedescricao3, lV129Clientewwds_31_tipoclientedescricao3, lV130Clientewwds_32_clienteconveniodescricao3, lV130Clientewwds_32_clienteconveniodescricao3, lV131Clientewwds_33_clientenacionalidadenome3, lV131Clientewwds_33_clientenacionalidadenome3, lV132Clientewwds_34_clienteprofissaonome3, lV132Clientewwds_34_clienteprofissaonome3, lV133Clientewwds_35_municipionome3, lV133Clientewwds_35_municipionome3, AV134Clientewwds_36_bancocodigo3, AV134Clientewwds_36_bancocodigo3, AV134Clientewwds_36_bancocodigo3, lV135Clientewwds_37_responsavelnacionalidadenome3, lV135Clientewwds_37_responsavelnacionalidadenome3, lV136Clientewwds_38_responsavelprofissaonome3, lV136Clientewwds_38_responsavelprofissaonome3, lV137Clientewwds_39_responsavelmunicipionome3, lV137Clientewwds_39_responsavelmunicipionome3, lV138Clientewwds_40_tftipoclientedescricao, AV139Clientewwds_41_tftipoclientedescricao_sel, lV140Clientewwds_42_tfclienterazaosocial, AV141Clientewwds_43_tfclienterazaosocial_sel, lV142Clientewwds_44_tfclientedocumento, AV143Clientewwds_45_tfclientedocumento_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK686 = false;
            A192TipoClienteId = P00684_A192TipoClienteId[0];
            n192TipoClienteId = P00684_n192TipoClienteId[0];
            A186MunicipioCodigo = P00684_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00684_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00684_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00684_n444ResponsavelMunicipio[0];
            A402BancoId = P00684_A402BancoId[0];
            n402BancoId = P00684_n402BancoId[0];
            A437ResponsavelNacionalidade = P00684_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00684_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00684_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00684_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00684_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00684_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00684_A487ClienteProfissao[0];
            n487ClienteProfissao = P00684_n487ClienteProfissao[0];
            A489ClienteConvenio = P00684_A489ClienteConvenio[0];
            n489ClienteConvenio = P00684_n489ClienteConvenio[0];
            A169ClienteDocumento = P00684_A169ClienteDocumento[0];
            n169ClienteDocumento = P00684_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = P00684_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00684_n170ClienteRazaoSocial[0];
            A445ResponsavelMunicipioNome = P00684_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00684_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00684_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00684_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00684_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00684_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00684_A404BancoCodigo[0];
            n404BancoCodigo = P00684_n404BancoCodigo[0];
            A187MunicipioNome = P00684_A187MunicipioNome[0];
            n187MunicipioNome = P00684_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00684_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00684_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00684_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00684_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00684_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00684_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00684_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00684_n193TipoClienteDescricao[0];
            A174ClienteStatus = P00684_A174ClienteStatus[0];
            n174ClienteStatus = P00684_n174ClienteStatus[0];
            A172ClienteTipoPessoa = P00684_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = P00684_n172ClienteTipoPessoa[0];
            A168ClienteId = P00684_A168ClienteId[0];
            A193TipoClienteDescricao = P00684_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00684_n193TipoClienteDescricao[0];
            A187MunicipioNome = P00684_A187MunicipioNome[0];
            n187MunicipioNome = P00684_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00684_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00684_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00684_A404BancoCodigo[0];
            n404BancoCodigo = P00684_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00684_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00684_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00684_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00684_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00684_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00684_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00684_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00684_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00684_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00684_n490ClienteConvenioDescricao[0];
            AV35count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00684_A169ClienteDocumento[0], A169ClienteDocumento) == 0 ) )
            {
               BRK686 = false;
               A168ClienteId = P00684_A168ClienteId[0];
               AV35count = (long)(AV35count+1);
               BRK686 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A169ClienteDocumento)) ? "<#Empty#>" : A169ClienteDocumento);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK686 )
            {
               BRK686 = true;
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
         AV44OptionsJson = "";
         AV45OptionsDescJson = "";
         AV46OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV33OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV25SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV36Session = context.GetSession();
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47FilterFullText = "";
         AV65TFTipoClienteDescricao = "";
         AV66TFTipoClienteDescricao_Sel = "";
         AV12TFClienteRazaoSocial = "";
         AV13TFClienteRazaoSocial_Sel = "";
         AV16TFClienteDocumento = "";
         AV17TFClienteDocumento_Sel = "";
         AV18TFClienteTipoPessoa_SelsJson = "";
         AV19TFClienteTipoPessoa_Sels = new GxSimpleCollection<string>();
         AV40GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV48DynamicFiltersSelector1 = "";
         AV50ClienteDocumento1 = "";
         AV59TipoClienteDescricao1 = "";
         AV76ClienteConvenioDescricao1 = "";
         AV77ClienteNacionalidadeNome1 = "";
         AV78ClienteProfissaoNome1 = "";
         AV73MunicipioNome1 = "";
         AV80ResponsavelNacionalidadeNome1 = "";
         AV81ResponsavelProfissaoNome1 = "";
         AV82ResponsavelMunicipioNome1 = "";
         AV52DynamicFiltersSelector2 = "";
         AV54ClienteDocumento2 = "";
         AV61TipoClienteDescricao2 = "";
         AV83ClienteConvenioDescricao2 = "";
         AV84ClienteNacionalidadeNome2 = "";
         AV85ClienteProfissaoNome2 = "";
         AV74MunicipioNome2 = "";
         AV87ResponsavelNacionalidadeNome2 = "";
         AV88ResponsavelProfissaoNome2 = "";
         AV89ResponsavelMunicipioNome2 = "";
         AV56DynamicFiltersSelector3 = "";
         AV58ClienteDocumento3 = "";
         AV63TipoClienteDescricao3 = "";
         AV90ClienteConvenioDescricao3 = "";
         AV91ClienteNacionalidadeNome3 = "";
         AV92ClienteProfissaoNome3 = "";
         AV75MunicipioNome3 = "";
         AV94ResponsavelNacionalidadeNome3 = "";
         AV95ResponsavelProfissaoNome3 = "";
         AV96ResponsavelMunicipioNome3 = "";
         AV99Clientewwds_1_filterfulltext = "";
         AV100Clientewwds_2_dynamicfiltersselector1 = "";
         AV102Clientewwds_4_clientedocumento1 = "";
         AV103Clientewwds_5_tipoclientedescricao1 = "";
         AV104Clientewwds_6_clienteconveniodescricao1 = "";
         AV105Clientewwds_7_clientenacionalidadenome1 = "";
         AV106Clientewwds_8_clienteprofissaonome1 = "";
         AV107Clientewwds_9_municipionome1 = "";
         AV109Clientewwds_11_responsavelnacionalidadenome1 = "";
         AV110Clientewwds_12_responsavelprofissaonome1 = "";
         AV111Clientewwds_13_responsavelmunicipionome1 = "";
         AV113Clientewwds_15_dynamicfiltersselector2 = "";
         AV115Clientewwds_17_clientedocumento2 = "";
         AV116Clientewwds_18_tipoclientedescricao2 = "";
         AV117Clientewwds_19_clienteconveniodescricao2 = "";
         AV118Clientewwds_20_clientenacionalidadenome2 = "";
         AV119Clientewwds_21_clienteprofissaonome2 = "";
         AV120Clientewwds_22_municipionome2 = "";
         AV122Clientewwds_24_responsavelnacionalidadenome2 = "";
         AV123Clientewwds_25_responsavelprofissaonome2 = "";
         AV124Clientewwds_26_responsavelmunicipionome2 = "";
         AV126Clientewwds_28_dynamicfiltersselector3 = "";
         AV128Clientewwds_30_clientedocumento3 = "";
         AV129Clientewwds_31_tipoclientedescricao3 = "";
         AV130Clientewwds_32_clienteconveniodescricao3 = "";
         AV131Clientewwds_33_clientenacionalidadenome3 = "";
         AV132Clientewwds_34_clienteprofissaonome3 = "";
         AV133Clientewwds_35_municipionome3 = "";
         AV135Clientewwds_37_responsavelnacionalidadenome3 = "";
         AV136Clientewwds_38_responsavelprofissaonome3 = "";
         AV137Clientewwds_39_responsavelmunicipionome3 = "";
         AV138Clientewwds_40_tftipoclientedescricao = "";
         AV139Clientewwds_41_tftipoclientedescricao_sel = "";
         AV140Clientewwds_42_tfclienterazaosocial = "";
         AV141Clientewwds_43_tfclienterazaosocial_sel = "";
         AV142Clientewwds_44_tfclientedocumento = "";
         AV143Clientewwds_45_tfclientedocumento_sel = "";
         AV144Clientewwds_46_tfclientetipopessoa_sels = new GxSimpleCollection<string>();
         lV99Clientewwds_1_filterfulltext = "";
         lV102Clientewwds_4_clientedocumento1 = "";
         lV103Clientewwds_5_tipoclientedescricao1 = "";
         lV104Clientewwds_6_clienteconveniodescricao1 = "";
         lV105Clientewwds_7_clientenacionalidadenome1 = "";
         lV106Clientewwds_8_clienteprofissaonome1 = "";
         lV107Clientewwds_9_municipionome1 = "";
         lV109Clientewwds_11_responsavelnacionalidadenome1 = "";
         lV110Clientewwds_12_responsavelprofissaonome1 = "";
         lV111Clientewwds_13_responsavelmunicipionome1 = "";
         lV115Clientewwds_17_clientedocumento2 = "";
         lV116Clientewwds_18_tipoclientedescricao2 = "";
         lV117Clientewwds_19_clienteconveniodescricao2 = "";
         lV118Clientewwds_20_clientenacionalidadenome2 = "";
         lV119Clientewwds_21_clienteprofissaonome2 = "";
         lV120Clientewwds_22_municipionome2 = "";
         lV122Clientewwds_24_responsavelnacionalidadenome2 = "";
         lV123Clientewwds_25_responsavelprofissaonome2 = "";
         lV124Clientewwds_26_responsavelmunicipionome2 = "";
         lV128Clientewwds_30_clientedocumento3 = "";
         lV129Clientewwds_31_tipoclientedescricao3 = "";
         lV130Clientewwds_32_clienteconveniodescricao3 = "";
         lV131Clientewwds_33_clientenacionalidadenome3 = "";
         lV132Clientewwds_34_clienteprofissaonome3 = "";
         lV133Clientewwds_35_municipionome3 = "";
         lV135Clientewwds_37_responsavelnacionalidadenome3 = "";
         lV136Clientewwds_38_responsavelprofissaonome3 = "";
         lV137Clientewwds_39_responsavelmunicipionome3 = "";
         lV138Clientewwds_40_tftipoclientedescricao = "";
         lV140Clientewwds_42_tfclienterazaosocial = "";
         lV142Clientewwds_44_tfclientedocumento = "";
         A172ClienteTipoPessoa = "";
         A193TipoClienteDescricao = "";
         A170ClienteRazaoSocial = "";
         A169ClienteDocumento = "";
         A490ClienteConvenioDescricao = "";
         A485ClienteNacionalidadeNome = "";
         A488ClienteProfissaoNome = "";
         A187MunicipioNome = "";
         A438ResponsavelNacionalidadeNome = "";
         A443ResponsavelProfissaoNome = "";
         A445ResponsavelMunicipioNome = "";
         P00682_A186MunicipioCodigo = new string[] {""} ;
         P00682_n186MunicipioCodigo = new bool[] {false} ;
         P00682_A444ResponsavelMunicipio = new string[] {""} ;
         P00682_n444ResponsavelMunicipio = new bool[] {false} ;
         P00682_A402BancoId = new int[1] ;
         P00682_n402BancoId = new bool[] {false} ;
         P00682_A437ResponsavelNacionalidade = new int[1] ;
         P00682_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00682_A484ClienteNacionalidade = new int[1] ;
         P00682_n484ClienteNacionalidade = new bool[] {false} ;
         P00682_A442ResponsavelProfissao = new int[1] ;
         P00682_n442ResponsavelProfissao = new bool[] {false} ;
         P00682_A487ClienteProfissao = new int[1] ;
         P00682_n487ClienteProfissao = new bool[] {false} ;
         P00682_A489ClienteConvenio = new int[1] ;
         P00682_n489ClienteConvenio = new bool[] {false} ;
         P00682_A192TipoClienteId = new short[1] ;
         P00682_n192TipoClienteId = new bool[] {false} ;
         P00682_A170ClienteRazaoSocial = new string[] {""} ;
         P00682_n170ClienteRazaoSocial = new bool[] {false} ;
         P00682_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00682_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00682_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00682_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00682_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00682_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00682_A404BancoCodigo = new int[1] ;
         P00682_n404BancoCodigo = new bool[] {false} ;
         P00682_A187MunicipioNome = new string[] {""} ;
         P00682_n187MunicipioNome = new bool[] {false} ;
         P00682_A488ClienteProfissaoNome = new string[] {""} ;
         P00682_n488ClienteProfissaoNome = new bool[] {false} ;
         P00682_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00682_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00682_A490ClienteConvenioDescricao = new string[] {""} ;
         P00682_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00682_A193TipoClienteDescricao = new string[] {""} ;
         P00682_n193TipoClienteDescricao = new bool[] {false} ;
         P00682_A169ClienteDocumento = new string[] {""} ;
         P00682_n169ClienteDocumento = new bool[] {false} ;
         P00682_A174ClienteStatus = new bool[] {false} ;
         P00682_n174ClienteStatus = new bool[] {false} ;
         P00682_A172ClienteTipoPessoa = new string[] {""} ;
         P00682_n172ClienteTipoPessoa = new bool[] {false} ;
         P00682_A168ClienteId = new int[1] ;
         A186MunicipioCodigo = "";
         A444ResponsavelMunicipio = "";
         AV30Option = "";
         AV32OptionDesc = "";
         P00683_A192TipoClienteId = new short[1] ;
         P00683_n192TipoClienteId = new bool[] {false} ;
         P00683_A186MunicipioCodigo = new string[] {""} ;
         P00683_n186MunicipioCodigo = new bool[] {false} ;
         P00683_A444ResponsavelMunicipio = new string[] {""} ;
         P00683_n444ResponsavelMunicipio = new bool[] {false} ;
         P00683_A402BancoId = new int[1] ;
         P00683_n402BancoId = new bool[] {false} ;
         P00683_A437ResponsavelNacionalidade = new int[1] ;
         P00683_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00683_A484ClienteNacionalidade = new int[1] ;
         P00683_n484ClienteNacionalidade = new bool[] {false} ;
         P00683_A442ResponsavelProfissao = new int[1] ;
         P00683_n442ResponsavelProfissao = new bool[] {false} ;
         P00683_A487ClienteProfissao = new int[1] ;
         P00683_n487ClienteProfissao = new bool[] {false} ;
         P00683_A489ClienteConvenio = new int[1] ;
         P00683_n489ClienteConvenio = new bool[] {false} ;
         P00683_A170ClienteRazaoSocial = new string[] {""} ;
         P00683_n170ClienteRazaoSocial = new bool[] {false} ;
         P00683_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00683_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00683_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00683_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00683_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00683_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00683_A404BancoCodigo = new int[1] ;
         P00683_n404BancoCodigo = new bool[] {false} ;
         P00683_A187MunicipioNome = new string[] {""} ;
         P00683_n187MunicipioNome = new bool[] {false} ;
         P00683_A488ClienteProfissaoNome = new string[] {""} ;
         P00683_n488ClienteProfissaoNome = new bool[] {false} ;
         P00683_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00683_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00683_A490ClienteConvenioDescricao = new string[] {""} ;
         P00683_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00683_A193TipoClienteDescricao = new string[] {""} ;
         P00683_n193TipoClienteDescricao = new bool[] {false} ;
         P00683_A169ClienteDocumento = new string[] {""} ;
         P00683_n169ClienteDocumento = new bool[] {false} ;
         P00683_A174ClienteStatus = new bool[] {false} ;
         P00683_n174ClienteStatus = new bool[] {false} ;
         P00683_A172ClienteTipoPessoa = new string[] {""} ;
         P00683_n172ClienteTipoPessoa = new bool[] {false} ;
         P00683_A168ClienteId = new int[1] ;
         P00684_A192TipoClienteId = new short[1] ;
         P00684_n192TipoClienteId = new bool[] {false} ;
         P00684_A186MunicipioCodigo = new string[] {""} ;
         P00684_n186MunicipioCodigo = new bool[] {false} ;
         P00684_A444ResponsavelMunicipio = new string[] {""} ;
         P00684_n444ResponsavelMunicipio = new bool[] {false} ;
         P00684_A402BancoId = new int[1] ;
         P00684_n402BancoId = new bool[] {false} ;
         P00684_A437ResponsavelNacionalidade = new int[1] ;
         P00684_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00684_A484ClienteNacionalidade = new int[1] ;
         P00684_n484ClienteNacionalidade = new bool[] {false} ;
         P00684_A442ResponsavelProfissao = new int[1] ;
         P00684_n442ResponsavelProfissao = new bool[] {false} ;
         P00684_A487ClienteProfissao = new int[1] ;
         P00684_n487ClienteProfissao = new bool[] {false} ;
         P00684_A489ClienteConvenio = new int[1] ;
         P00684_n489ClienteConvenio = new bool[] {false} ;
         P00684_A169ClienteDocumento = new string[] {""} ;
         P00684_n169ClienteDocumento = new bool[] {false} ;
         P00684_A170ClienteRazaoSocial = new string[] {""} ;
         P00684_n170ClienteRazaoSocial = new bool[] {false} ;
         P00684_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00684_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00684_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00684_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00684_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00684_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00684_A404BancoCodigo = new int[1] ;
         P00684_n404BancoCodigo = new bool[] {false} ;
         P00684_A187MunicipioNome = new string[] {""} ;
         P00684_n187MunicipioNome = new bool[] {false} ;
         P00684_A488ClienteProfissaoNome = new string[] {""} ;
         P00684_n488ClienteProfissaoNome = new bool[] {false} ;
         P00684_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00684_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00684_A490ClienteConvenioDescricao = new string[] {""} ;
         P00684_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00684_A193TipoClienteDescricao = new string[] {""} ;
         P00684_n193TipoClienteDescricao = new bool[] {false} ;
         P00684_A174ClienteStatus = new bool[] {false} ;
         P00684_n174ClienteStatus = new bool[] {false} ;
         P00684_A172ClienteTipoPessoa = new string[] {""} ;
         P00684_n172ClienteTipoPessoa = new bool[] {false} ;
         P00684_A168ClienteId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00682_A186MunicipioCodigo, P00682_n186MunicipioCodigo, P00682_A444ResponsavelMunicipio, P00682_n444ResponsavelMunicipio, P00682_A402BancoId, P00682_n402BancoId, P00682_A437ResponsavelNacionalidade, P00682_n437ResponsavelNacionalidade, P00682_A484ClienteNacionalidade, P00682_n484ClienteNacionalidade,
               P00682_A442ResponsavelProfissao, P00682_n442ResponsavelProfissao, P00682_A487ClienteProfissao, P00682_n487ClienteProfissao, P00682_A489ClienteConvenio, P00682_n489ClienteConvenio, P00682_A192TipoClienteId, P00682_n192TipoClienteId, P00682_A170ClienteRazaoSocial, P00682_n170ClienteRazaoSocial,
               P00682_A445ResponsavelMunicipioNome, P00682_n445ResponsavelMunicipioNome, P00682_A443ResponsavelProfissaoNome, P00682_n443ResponsavelProfissaoNome, P00682_A438ResponsavelNacionalidadeNome, P00682_n438ResponsavelNacionalidadeNome, P00682_A404BancoCodigo, P00682_n404BancoCodigo, P00682_A187MunicipioNome, P00682_n187MunicipioNome,
               P00682_A488ClienteProfissaoNome, P00682_n488ClienteProfissaoNome, P00682_A485ClienteNacionalidadeNome, P00682_n485ClienteNacionalidadeNome, P00682_A490ClienteConvenioDescricao, P00682_n490ClienteConvenioDescricao, P00682_A193TipoClienteDescricao, P00682_n193TipoClienteDescricao, P00682_A169ClienteDocumento, P00682_n169ClienteDocumento,
               P00682_A174ClienteStatus, P00682_n174ClienteStatus, P00682_A172ClienteTipoPessoa, P00682_n172ClienteTipoPessoa, P00682_A168ClienteId
               }
               , new Object[] {
               P00683_A192TipoClienteId, P00683_n192TipoClienteId, P00683_A186MunicipioCodigo, P00683_n186MunicipioCodigo, P00683_A444ResponsavelMunicipio, P00683_n444ResponsavelMunicipio, P00683_A402BancoId, P00683_n402BancoId, P00683_A437ResponsavelNacionalidade, P00683_n437ResponsavelNacionalidade,
               P00683_A484ClienteNacionalidade, P00683_n484ClienteNacionalidade, P00683_A442ResponsavelProfissao, P00683_n442ResponsavelProfissao, P00683_A487ClienteProfissao, P00683_n487ClienteProfissao, P00683_A489ClienteConvenio, P00683_n489ClienteConvenio, P00683_A170ClienteRazaoSocial, P00683_n170ClienteRazaoSocial,
               P00683_A445ResponsavelMunicipioNome, P00683_n445ResponsavelMunicipioNome, P00683_A443ResponsavelProfissaoNome, P00683_n443ResponsavelProfissaoNome, P00683_A438ResponsavelNacionalidadeNome, P00683_n438ResponsavelNacionalidadeNome, P00683_A404BancoCodigo, P00683_n404BancoCodigo, P00683_A187MunicipioNome, P00683_n187MunicipioNome,
               P00683_A488ClienteProfissaoNome, P00683_n488ClienteProfissaoNome, P00683_A485ClienteNacionalidadeNome, P00683_n485ClienteNacionalidadeNome, P00683_A490ClienteConvenioDescricao, P00683_n490ClienteConvenioDescricao, P00683_A193TipoClienteDescricao, P00683_n193TipoClienteDescricao, P00683_A169ClienteDocumento, P00683_n169ClienteDocumento,
               P00683_A174ClienteStatus, P00683_n174ClienteStatus, P00683_A172ClienteTipoPessoa, P00683_n172ClienteTipoPessoa, P00683_A168ClienteId
               }
               , new Object[] {
               P00684_A192TipoClienteId, P00684_n192TipoClienteId, P00684_A186MunicipioCodigo, P00684_n186MunicipioCodigo, P00684_A444ResponsavelMunicipio, P00684_n444ResponsavelMunicipio, P00684_A402BancoId, P00684_n402BancoId, P00684_A437ResponsavelNacionalidade, P00684_n437ResponsavelNacionalidade,
               P00684_A484ClienteNacionalidade, P00684_n484ClienteNacionalidade, P00684_A442ResponsavelProfissao, P00684_n442ResponsavelProfissao, P00684_A487ClienteProfissao, P00684_n487ClienteProfissao, P00684_A489ClienteConvenio, P00684_n489ClienteConvenio, P00684_A169ClienteDocumento, P00684_n169ClienteDocumento,
               P00684_A170ClienteRazaoSocial, P00684_n170ClienteRazaoSocial, P00684_A445ResponsavelMunicipioNome, P00684_n445ResponsavelMunicipioNome, P00684_A443ResponsavelProfissaoNome, P00684_n443ResponsavelProfissaoNome, P00684_A438ResponsavelNacionalidadeNome, P00684_n438ResponsavelNacionalidadeNome, P00684_A404BancoCodigo, P00684_n404BancoCodigo,
               P00684_A187MunicipioNome, P00684_n187MunicipioNome, P00684_A488ClienteProfissaoNome, P00684_n488ClienteProfissaoNome, P00684_A485ClienteNacionalidadeNome, P00684_n485ClienteNacionalidadeNome, P00684_A490ClienteConvenioDescricao, P00684_n490ClienteConvenioDescricao, P00684_A193TipoClienteDescricao, P00684_n193TipoClienteDescricao,
               P00684_A174ClienteStatus, P00684_n174ClienteStatus, P00684_A172ClienteTipoPessoa, P00684_n172ClienteTipoPessoa, P00684_A168ClienteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short AV20TFClienteStatus_Sel ;
      private short AV49DynamicFiltersOperator1 ;
      private short AV53DynamicFiltersOperator2 ;
      private short AV57DynamicFiltersOperator3 ;
      private short AV101Clientewwds_3_dynamicfiltersoperator1 ;
      private short AV114Clientewwds_16_dynamicfiltersoperator2 ;
      private short AV127Clientewwds_29_dynamicfiltersoperator3 ;
      private short AV145Clientewwds_47_tfclientestatus_sel ;
      private short A192TipoClienteId ;
      private int AV97GXV1 ;
      private int AV79BancoCodigo1 ;
      private int AV86BancoCodigo2 ;
      private int AV93BancoCodigo3 ;
      private int AV108Clientewwds_10_bancocodigo1 ;
      private int AV121Clientewwds_23_bancocodigo2 ;
      private int AV134Clientewwds_36_bancocodigo3 ;
      private int AV144Clientewwds_46_tfclientetipopessoa_sels_Count ;
      private int A404BancoCodigo ;
      private int A402BancoId ;
      private int A437ResponsavelNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int A442ResponsavelProfissao ;
      private int A487ClienteProfissao ;
      private int A489ClienteConvenio ;
      private int A168ClienteId ;
      private int AV29InsertIndex ;
      private long AV35count ;
      private bool returnInSub ;
      private bool AV51DynamicFiltersEnabled2 ;
      private bool AV55DynamicFiltersEnabled3 ;
      private bool AV112Clientewwds_14_dynamicfiltersenabled2 ;
      private bool AV125Clientewwds_27_dynamicfiltersenabled3 ;
      private bool A174ClienteStatus ;
      private bool BRK682 ;
      private bool n186MunicipioCodigo ;
      private bool n444ResponsavelMunicipio ;
      private bool n402BancoId ;
      private bool n437ResponsavelNacionalidade ;
      private bool n484ClienteNacionalidade ;
      private bool n442ResponsavelProfissao ;
      private bool n487ClienteProfissao ;
      private bool n489ClienteConvenio ;
      private bool n192TipoClienteId ;
      private bool n170ClienteRazaoSocial ;
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
      private bool n174ClienteStatus ;
      private bool n172ClienteTipoPessoa ;
      private bool BRK684 ;
      private bool BRK686 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV18TFClienteTipoPessoa_SelsJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV65TFTipoClienteDescricao ;
      private string AV66TFTipoClienteDescricao_Sel ;
      private string AV12TFClienteRazaoSocial ;
      private string AV13TFClienteRazaoSocial_Sel ;
      private string AV16TFClienteDocumento ;
      private string AV17TFClienteDocumento_Sel ;
      private string AV48DynamicFiltersSelector1 ;
      private string AV50ClienteDocumento1 ;
      private string AV59TipoClienteDescricao1 ;
      private string AV76ClienteConvenioDescricao1 ;
      private string AV77ClienteNacionalidadeNome1 ;
      private string AV78ClienteProfissaoNome1 ;
      private string AV73MunicipioNome1 ;
      private string AV80ResponsavelNacionalidadeNome1 ;
      private string AV81ResponsavelProfissaoNome1 ;
      private string AV82ResponsavelMunicipioNome1 ;
      private string AV52DynamicFiltersSelector2 ;
      private string AV54ClienteDocumento2 ;
      private string AV61TipoClienteDescricao2 ;
      private string AV83ClienteConvenioDescricao2 ;
      private string AV84ClienteNacionalidadeNome2 ;
      private string AV85ClienteProfissaoNome2 ;
      private string AV74MunicipioNome2 ;
      private string AV87ResponsavelNacionalidadeNome2 ;
      private string AV88ResponsavelProfissaoNome2 ;
      private string AV89ResponsavelMunicipioNome2 ;
      private string AV56DynamicFiltersSelector3 ;
      private string AV58ClienteDocumento3 ;
      private string AV63TipoClienteDescricao3 ;
      private string AV90ClienteConvenioDescricao3 ;
      private string AV91ClienteNacionalidadeNome3 ;
      private string AV92ClienteProfissaoNome3 ;
      private string AV75MunicipioNome3 ;
      private string AV94ResponsavelNacionalidadeNome3 ;
      private string AV95ResponsavelProfissaoNome3 ;
      private string AV96ResponsavelMunicipioNome3 ;
      private string AV99Clientewwds_1_filterfulltext ;
      private string AV100Clientewwds_2_dynamicfiltersselector1 ;
      private string AV102Clientewwds_4_clientedocumento1 ;
      private string AV103Clientewwds_5_tipoclientedescricao1 ;
      private string AV104Clientewwds_6_clienteconveniodescricao1 ;
      private string AV105Clientewwds_7_clientenacionalidadenome1 ;
      private string AV106Clientewwds_8_clienteprofissaonome1 ;
      private string AV107Clientewwds_9_municipionome1 ;
      private string AV109Clientewwds_11_responsavelnacionalidadenome1 ;
      private string AV110Clientewwds_12_responsavelprofissaonome1 ;
      private string AV111Clientewwds_13_responsavelmunicipionome1 ;
      private string AV113Clientewwds_15_dynamicfiltersselector2 ;
      private string AV115Clientewwds_17_clientedocumento2 ;
      private string AV116Clientewwds_18_tipoclientedescricao2 ;
      private string AV117Clientewwds_19_clienteconveniodescricao2 ;
      private string AV118Clientewwds_20_clientenacionalidadenome2 ;
      private string AV119Clientewwds_21_clienteprofissaonome2 ;
      private string AV120Clientewwds_22_municipionome2 ;
      private string AV122Clientewwds_24_responsavelnacionalidadenome2 ;
      private string AV123Clientewwds_25_responsavelprofissaonome2 ;
      private string AV124Clientewwds_26_responsavelmunicipionome2 ;
      private string AV126Clientewwds_28_dynamicfiltersselector3 ;
      private string AV128Clientewwds_30_clientedocumento3 ;
      private string AV129Clientewwds_31_tipoclientedescricao3 ;
      private string AV130Clientewwds_32_clienteconveniodescricao3 ;
      private string AV131Clientewwds_33_clientenacionalidadenome3 ;
      private string AV132Clientewwds_34_clienteprofissaonome3 ;
      private string AV133Clientewwds_35_municipionome3 ;
      private string AV135Clientewwds_37_responsavelnacionalidadenome3 ;
      private string AV136Clientewwds_38_responsavelprofissaonome3 ;
      private string AV137Clientewwds_39_responsavelmunicipionome3 ;
      private string AV138Clientewwds_40_tftipoclientedescricao ;
      private string AV139Clientewwds_41_tftipoclientedescricao_sel ;
      private string AV140Clientewwds_42_tfclienterazaosocial ;
      private string AV141Clientewwds_43_tfclienterazaosocial_sel ;
      private string AV142Clientewwds_44_tfclientedocumento ;
      private string AV143Clientewwds_45_tfclientedocumento_sel ;
      private string lV99Clientewwds_1_filterfulltext ;
      private string lV102Clientewwds_4_clientedocumento1 ;
      private string lV103Clientewwds_5_tipoclientedescricao1 ;
      private string lV104Clientewwds_6_clienteconveniodescricao1 ;
      private string lV105Clientewwds_7_clientenacionalidadenome1 ;
      private string lV106Clientewwds_8_clienteprofissaonome1 ;
      private string lV107Clientewwds_9_municipionome1 ;
      private string lV109Clientewwds_11_responsavelnacionalidadenome1 ;
      private string lV110Clientewwds_12_responsavelprofissaonome1 ;
      private string lV111Clientewwds_13_responsavelmunicipionome1 ;
      private string lV115Clientewwds_17_clientedocumento2 ;
      private string lV116Clientewwds_18_tipoclientedescricao2 ;
      private string lV117Clientewwds_19_clienteconveniodescricao2 ;
      private string lV118Clientewwds_20_clientenacionalidadenome2 ;
      private string lV119Clientewwds_21_clienteprofissaonome2 ;
      private string lV120Clientewwds_22_municipionome2 ;
      private string lV122Clientewwds_24_responsavelnacionalidadenome2 ;
      private string lV123Clientewwds_25_responsavelprofissaonome2 ;
      private string lV124Clientewwds_26_responsavelmunicipionome2 ;
      private string lV128Clientewwds_30_clientedocumento3 ;
      private string lV129Clientewwds_31_tipoclientedescricao3 ;
      private string lV130Clientewwds_32_clienteconveniodescricao3 ;
      private string lV131Clientewwds_33_clientenacionalidadenome3 ;
      private string lV132Clientewwds_34_clienteprofissaonome3 ;
      private string lV133Clientewwds_35_municipionome3 ;
      private string lV135Clientewwds_37_responsavelnacionalidadenome3 ;
      private string lV136Clientewwds_38_responsavelprofissaonome3 ;
      private string lV137Clientewwds_39_responsavelmunicipionome3 ;
      private string lV138Clientewwds_40_tftipoclientedescricao ;
      private string lV140Clientewwds_42_tfclienterazaosocial ;
      private string lV142Clientewwds_44_tfclientedocumento ;
      private string A172ClienteTipoPessoa ;
      private string A193TipoClienteDescricao ;
      private string A170ClienteRazaoSocial ;
      private string A169ClienteDocumento ;
      private string A490ClienteConvenioDescricao ;
      private string A485ClienteNacionalidadeNome ;
      private string A488ClienteProfissaoNome ;
      private string A187MunicipioNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string A443ResponsavelProfissaoNome ;
      private string A445ResponsavelMunicipioNome ;
      private string A186MunicipioCodigo ;
      private string A444ResponsavelMunicipio ;
      private string AV30Option ;
      private string AV32OptionDesc ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GxSimpleCollection<string> AV19TFClienteTipoPessoa_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV40GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV144Clientewwds_46_tfclientetipopessoa_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00682_A186MunicipioCodigo ;
      private bool[] P00682_n186MunicipioCodigo ;
      private string[] P00682_A444ResponsavelMunicipio ;
      private bool[] P00682_n444ResponsavelMunicipio ;
      private int[] P00682_A402BancoId ;
      private bool[] P00682_n402BancoId ;
      private int[] P00682_A437ResponsavelNacionalidade ;
      private bool[] P00682_n437ResponsavelNacionalidade ;
      private int[] P00682_A484ClienteNacionalidade ;
      private bool[] P00682_n484ClienteNacionalidade ;
      private int[] P00682_A442ResponsavelProfissao ;
      private bool[] P00682_n442ResponsavelProfissao ;
      private int[] P00682_A487ClienteProfissao ;
      private bool[] P00682_n487ClienteProfissao ;
      private int[] P00682_A489ClienteConvenio ;
      private bool[] P00682_n489ClienteConvenio ;
      private short[] P00682_A192TipoClienteId ;
      private bool[] P00682_n192TipoClienteId ;
      private string[] P00682_A170ClienteRazaoSocial ;
      private bool[] P00682_n170ClienteRazaoSocial ;
      private string[] P00682_A445ResponsavelMunicipioNome ;
      private bool[] P00682_n445ResponsavelMunicipioNome ;
      private string[] P00682_A443ResponsavelProfissaoNome ;
      private bool[] P00682_n443ResponsavelProfissaoNome ;
      private string[] P00682_A438ResponsavelNacionalidadeNome ;
      private bool[] P00682_n438ResponsavelNacionalidadeNome ;
      private int[] P00682_A404BancoCodigo ;
      private bool[] P00682_n404BancoCodigo ;
      private string[] P00682_A187MunicipioNome ;
      private bool[] P00682_n187MunicipioNome ;
      private string[] P00682_A488ClienteProfissaoNome ;
      private bool[] P00682_n488ClienteProfissaoNome ;
      private string[] P00682_A485ClienteNacionalidadeNome ;
      private bool[] P00682_n485ClienteNacionalidadeNome ;
      private string[] P00682_A490ClienteConvenioDescricao ;
      private bool[] P00682_n490ClienteConvenioDescricao ;
      private string[] P00682_A193TipoClienteDescricao ;
      private bool[] P00682_n193TipoClienteDescricao ;
      private string[] P00682_A169ClienteDocumento ;
      private bool[] P00682_n169ClienteDocumento ;
      private bool[] P00682_A174ClienteStatus ;
      private bool[] P00682_n174ClienteStatus ;
      private string[] P00682_A172ClienteTipoPessoa ;
      private bool[] P00682_n172ClienteTipoPessoa ;
      private int[] P00682_A168ClienteId ;
      private short[] P00683_A192TipoClienteId ;
      private bool[] P00683_n192TipoClienteId ;
      private string[] P00683_A186MunicipioCodigo ;
      private bool[] P00683_n186MunicipioCodigo ;
      private string[] P00683_A444ResponsavelMunicipio ;
      private bool[] P00683_n444ResponsavelMunicipio ;
      private int[] P00683_A402BancoId ;
      private bool[] P00683_n402BancoId ;
      private int[] P00683_A437ResponsavelNacionalidade ;
      private bool[] P00683_n437ResponsavelNacionalidade ;
      private int[] P00683_A484ClienteNacionalidade ;
      private bool[] P00683_n484ClienteNacionalidade ;
      private int[] P00683_A442ResponsavelProfissao ;
      private bool[] P00683_n442ResponsavelProfissao ;
      private int[] P00683_A487ClienteProfissao ;
      private bool[] P00683_n487ClienteProfissao ;
      private int[] P00683_A489ClienteConvenio ;
      private bool[] P00683_n489ClienteConvenio ;
      private string[] P00683_A170ClienteRazaoSocial ;
      private bool[] P00683_n170ClienteRazaoSocial ;
      private string[] P00683_A445ResponsavelMunicipioNome ;
      private bool[] P00683_n445ResponsavelMunicipioNome ;
      private string[] P00683_A443ResponsavelProfissaoNome ;
      private bool[] P00683_n443ResponsavelProfissaoNome ;
      private string[] P00683_A438ResponsavelNacionalidadeNome ;
      private bool[] P00683_n438ResponsavelNacionalidadeNome ;
      private int[] P00683_A404BancoCodigo ;
      private bool[] P00683_n404BancoCodigo ;
      private string[] P00683_A187MunicipioNome ;
      private bool[] P00683_n187MunicipioNome ;
      private string[] P00683_A488ClienteProfissaoNome ;
      private bool[] P00683_n488ClienteProfissaoNome ;
      private string[] P00683_A485ClienteNacionalidadeNome ;
      private bool[] P00683_n485ClienteNacionalidadeNome ;
      private string[] P00683_A490ClienteConvenioDescricao ;
      private bool[] P00683_n490ClienteConvenioDescricao ;
      private string[] P00683_A193TipoClienteDescricao ;
      private bool[] P00683_n193TipoClienteDescricao ;
      private string[] P00683_A169ClienteDocumento ;
      private bool[] P00683_n169ClienteDocumento ;
      private bool[] P00683_A174ClienteStatus ;
      private bool[] P00683_n174ClienteStatus ;
      private string[] P00683_A172ClienteTipoPessoa ;
      private bool[] P00683_n172ClienteTipoPessoa ;
      private int[] P00683_A168ClienteId ;
      private short[] P00684_A192TipoClienteId ;
      private bool[] P00684_n192TipoClienteId ;
      private string[] P00684_A186MunicipioCodigo ;
      private bool[] P00684_n186MunicipioCodigo ;
      private string[] P00684_A444ResponsavelMunicipio ;
      private bool[] P00684_n444ResponsavelMunicipio ;
      private int[] P00684_A402BancoId ;
      private bool[] P00684_n402BancoId ;
      private int[] P00684_A437ResponsavelNacionalidade ;
      private bool[] P00684_n437ResponsavelNacionalidade ;
      private int[] P00684_A484ClienteNacionalidade ;
      private bool[] P00684_n484ClienteNacionalidade ;
      private int[] P00684_A442ResponsavelProfissao ;
      private bool[] P00684_n442ResponsavelProfissao ;
      private int[] P00684_A487ClienteProfissao ;
      private bool[] P00684_n487ClienteProfissao ;
      private int[] P00684_A489ClienteConvenio ;
      private bool[] P00684_n489ClienteConvenio ;
      private string[] P00684_A169ClienteDocumento ;
      private bool[] P00684_n169ClienteDocumento ;
      private string[] P00684_A170ClienteRazaoSocial ;
      private bool[] P00684_n170ClienteRazaoSocial ;
      private string[] P00684_A445ResponsavelMunicipioNome ;
      private bool[] P00684_n445ResponsavelMunicipioNome ;
      private string[] P00684_A443ResponsavelProfissaoNome ;
      private bool[] P00684_n443ResponsavelProfissaoNome ;
      private string[] P00684_A438ResponsavelNacionalidadeNome ;
      private bool[] P00684_n438ResponsavelNacionalidadeNome ;
      private int[] P00684_A404BancoCodigo ;
      private bool[] P00684_n404BancoCodigo ;
      private string[] P00684_A187MunicipioNome ;
      private bool[] P00684_n187MunicipioNome ;
      private string[] P00684_A488ClienteProfissaoNome ;
      private bool[] P00684_n488ClienteProfissaoNome ;
      private string[] P00684_A485ClienteNacionalidadeNome ;
      private bool[] P00684_n485ClienteNacionalidadeNome ;
      private string[] P00684_A490ClienteConvenioDescricao ;
      private bool[] P00684_n490ClienteConvenioDescricao ;
      private string[] P00684_A193TipoClienteDescricao ;
      private bool[] P00684_n193TipoClienteDescricao ;
      private bool[] P00684_A174ClienteStatus ;
      private bool[] P00684_n174ClienteStatus ;
      private string[] P00684_A172ClienteTipoPessoa ;
      private bool[] P00684_n172ClienteTipoPessoa ;
      private int[] P00684_A168ClienteId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class clientewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00682( IGxContext context ,
                                             string A172ClienteTipoPessoa ,
                                             GxSimpleCollection<string> AV144Clientewwds_46_tfclientetipopessoa_sels ,
                                             string AV99Clientewwds_1_filterfulltext ,
                                             string AV100Clientewwds_2_dynamicfiltersselector1 ,
                                             short AV101Clientewwds_3_dynamicfiltersoperator1 ,
                                             string AV102Clientewwds_4_clientedocumento1 ,
                                             string AV103Clientewwds_5_tipoclientedescricao1 ,
                                             string AV104Clientewwds_6_clienteconveniodescricao1 ,
                                             string AV105Clientewwds_7_clientenacionalidadenome1 ,
                                             string AV106Clientewwds_8_clienteprofissaonome1 ,
                                             string AV107Clientewwds_9_municipionome1 ,
                                             int AV108Clientewwds_10_bancocodigo1 ,
                                             string AV109Clientewwds_11_responsavelnacionalidadenome1 ,
                                             string AV110Clientewwds_12_responsavelprofissaonome1 ,
                                             string AV111Clientewwds_13_responsavelmunicipionome1 ,
                                             bool AV112Clientewwds_14_dynamicfiltersenabled2 ,
                                             string AV113Clientewwds_15_dynamicfiltersselector2 ,
                                             short AV114Clientewwds_16_dynamicfiltersoperator2 ,
                                             string AV115Clientewwds_17_clientedocumento2 ,
                                             string AV116Clientewwds_18_tipoclientedescricao2 ,
                                             string AV117Clientewwds_19_clienteconveniodescricao2 ,
                                             string AV118Clientewwds_20_clientenacionalidadenome2 ,
                                             string AV119Clientewwds_21_clienteprofissaonome2 ,
                                             string AV120Clientewwds_22_municipionome2 ,
                                             int AV121Clientewwds_23_bancocodigo2 ,
                                             string AV122Clientewwds_24_responsavelnacionalidadenome2 ,
                                             string AV123Clientewwds_25_responsavelprofissaonome2 ,
                                             string AV124Clientewwds_26_responsavelmunicipionome2 ,
                                             bool AV125Clientewwds_27_dynamicfiltersenabled3 ,
                                             string AV126Clientewwds_28_dynamicfiltersselector3 ,
                                             short AV127Clientewwds_29_dynamicfiltersoperator3 ,
                                             string AV128Clientewwds_30_clientedocumento3 ,
                                             string AV129Clientewwds_31_tipoclientedescricao3 ,
                                             string AV130Clientewwds_32_clienteconveniodescricao3 ,
                                             string AV131Clientewwds_33_clientenacionalidadenome3 ,
                                             string AV132Clientewwds_34_clienteprofissaonome3 ,
                                             string AV133Clientewwds_35_municipionome3 ,
                                             int AV134Clientewwds_36_bancocodigo3 ,
                                             string AV135Clientewwds_37_responsavelnacionalidadenome3 ,
                                             string AV136Clientewwds_38_responsavelprofissaonome3 ,
                                             string AV137Clientewwds_39_responsavelmunicipionome3 ,
                                             string AV139Clientewwds_41_tftipoclientedescricao_sel ,
                                             string AV138Clientewwds_40_tftipoclientedescricao ,
                                             string AV141Clientewwds_43_tfclienterazaosocial_sel ,
                                             string AV140Clientewwds_42_tfclienterazaosocial ,
                                             string AV143Clientewwds_45_tfclientedocumento_sel ,
                                             string AV142Clientewwds_44_tfclientedocumento ,
                                             int AV144Clientewwds_46_tfclientetipopessoa_sels_Count ,
                                             short AV145Clientewwds_47_tfclientestatus_sel ,
                                             string A193TipoClienteDescricao ,
                                             string A170ClienteRazaoSocial ,
                                             string A169ClienteDocumento ,
                                             bool A174ClienteStatus ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[76];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.TipoClienteId, T1.ClienteRazaoSocial, T3.MunicipioNome AS ResponsavelMunicipioNome, T7.ProfissaoNome AS ResponsavelProfissaoNome, T5.NacionalidadeNome AS ResponsavelNacionalidadeNome, T4.BancoCodigo, T2.MunicipioNome, T8.ProfissaoNome AS ClienteProfissaoNome, T6.NacionalidadeNome AS ClienteNacionalidadeNome, T9.ConvenioDescricao AS ClienteConvenioDescricao, T10.TipoClienteDescricao, T1.ClienteDocumento, T1.ClienteStatus, T1.ClienteTipoPessoa, T1.ClienteId FROM (((((((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T5 ON T5.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T7 ON T7.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T9 ON T9.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T10 ON T10.TipoClienteId = T1.TipoClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Clientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T10.TipoClienteDescricao) like '%' || LOWER(:lV99Clientewwds_1_filterfulltext)) or ( LOWER(T1.ClienteRazaoSocial) like '%' || LOWER(:lV99Clientewwds_1_filterfulltext)) or ( LOWER(T1.ClienteDocumento) like '%' || LOWER(:lV99Clientewwds_1_filterfulltext)) or ( 'física' like '%' || LOWER(:lV99Clientewwds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV99Clientewwds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'JURIDICA')) or ( 'ativo' like '%' || LOWER(:lV99Clientewwds_1_filterfulltext) and T1.ClienteStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV99Clientewwds_1_filterfulltext) and T1.ClienteStatus = FALSE))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Clientewwds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV102Clientewwds_4_clientedocumento1)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Clientewwds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV102Clientewwds_4_clientedocumento1)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Clientewwds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV103Clientewwds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Clientewwds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV103Clientewwds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Clientewwds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV104Clientewwds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Clientewwds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV104Clientewwds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Clientewwds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV105Clientewwds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Clientewwds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV105Clientewwds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Clientewwds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV106Clientewwds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Clientewwds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV106Clientewwds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Clientewwds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV107Clientewwds_9_municipionome1)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Clientewwds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV107Clientewwds_9_municipionome1)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV108Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV108Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV108Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV108Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV108Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV108Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Clientewwds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV109Clientewwds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Clientewwds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV109Clientewwds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Clientewwds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV110Clientewwds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Clientewwds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV110Clientewwds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Clientewwds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV111Clientewwds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Clientewwds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV111Clientewwds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Clientewwds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV115Clientewwds_17_clientedocumento2)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Clientewwds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV115Clientewwds_17_clientedocumento2)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Clientewwds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV116Clientewwds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Clientewwds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV116Clientewwds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Clientewwds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV117Clientewwds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Clientewwds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV117Clientewwds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Clientewwds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV118Clientewwds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Clientewwds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV118Clientewwds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int1[35] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Clientewwds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV119Clientewwds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int1[36] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Clientewwds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV119Clientewwds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int1[37] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Clientewwds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV120Clientewwds_22_municipionome2)");
         }
         else
         {
            GXv_int1[38] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Clientewwds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV120Clientewwds_22_municipionome2)");
         }
         else
         {
            GXv_int1[39] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV121Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV121Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int1[40] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV121Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV121Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int1[41] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV121Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV121Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int1[42] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Clientewwds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV122Clientewwds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int1[43] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Clientewwds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV122Clientewwds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int1[44] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Clientewwds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV123Clientewwds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int1[45] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Clientewwds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV123Clientewwds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int1[46] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Clientewwds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV124Clientewwds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int1[47] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Clientewwds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV124Clientewwds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int1[48] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Clientewwds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV128Clientewwds_30_clientedocumento3)");
         }
         else
         {
            GXv_int1[49] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Clientewwds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV128Clientewwds_30_clientedocumento3)");
         }
         else
         {
            GXv_int1[50] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Clientewwds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV129Clientewwds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int1[51] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Clientewwds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV129Clientewwds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int1[52] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Clientewwds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV130Clientewwds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int1[53] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Clientewwds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV130Clientewwds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int1[54] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Clientewwds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV131Clientewwds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int1[55] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Clientewwds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV131Clientewwds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int1[56] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Clientewwds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV132Clientewwds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int1[57] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Clientewwds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV132Clientewwds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int1[58] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Clientewwds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV133Clientewwds_35_municipionome3)");
         }
         else
         {
            GXv_int1[59] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Clientewwds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV133Clientewwds_35_municipionome3)");
         }
         else
         {
            GXv_int1[60] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV134Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV134Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int1[61] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV134Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV134Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int1[62] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV134Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV134Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int1[63] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Clientewwds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV135Clientewwds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int1[64] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Clientewwds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV135Clientewwds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int1[65] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Clientewwds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV136Clientewwds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int1[66] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Clientewwds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV136Clientewwds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int1[67] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Clientewwds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV137Clientewwds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int1[68] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Clientewwds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV137Clientewwds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int1[69] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV139Clientewwds_41_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Clientewwds_40_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV138Clientewwds_40_tftipoclientedescricao)");
         }
         else
         {
            GXv_int1[70] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Clientewwds_41_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV139Clientewwds_41_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao = ( :AV139Clientewwds_41_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int1[71] = 1;
         }
         if ( StringUtil.StrCmp(AV139Clientewwds_41_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from T10.TipoClienteDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Clientewwds_43_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Clientewwds_42_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV140Clientewwds_42_tfclienterazaosocial)");
         }
         else
         {
            GXv_int1[72] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Clientewwds_43_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV141Clientewwds_43_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV141Clientewwds_43_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int1[73] = 1;
         }
         if ( StringUtil.StrCmp(AV141Clientewwds_43_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Clientewwds_45_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Clientewwds_44_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV142Clientewwds_44_tfclientedocumento)");
         }
         else
         {
            GXv_int1[74] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Clientewwds_45_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV143Clientewwds_45_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV143Clientewwds_45_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int1[75] = 1;
         }
         if ( StringUtil.StrCmp(AV143Clientewwds_45_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( AV144Clientewwds_46_tfclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV144Clientewwds_46_tfclientetipopessoa_sels, "T1.ClienteTipoPessoa IN (", ")")+")");
         }
         if ( AV145Clientewwds_47_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV145Clientewwds_47_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TipoClienteId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00683( IGxContext context ,
                                             string A172ClienteTipoPessoa ,
                                             GxSimpleCollection<string> AV144Clientewwds_46_tfclientetipopessoa_sels ,
                                             string AV99Clientewwds_1_filterfulltext ,
                                             string AV100Clientewwds_2_dynamicfiltersselector1 ,
                                             short AV101Clientewwds_3_dynamicfiltersoperator1 ,
                                             string AV102Clientewwds_4_clientedocumento1 ,
                                             string AV103Clientewwds_5_tipoclientedescricao1 ,
                                             string AV104Clientewwds_6_clienteconveniodescricao1 ,
                                             string AV105Clientewwds_7_clientenacionalidadenome1 ,
                                             string AV106Clientewwds_8_clienteprofissaonome1 ,
                                             string AV107Clientewwds_9_municipionome1 ,
                                             int AV108Clientewwds_10_bancocodigo1 ,
                                             string AV109Clientewwds_11_responsavelnacionalidadenome1 ,
                                             string AV110Clientewwds_12_responsavelprofissaonome1 ,
                                             string AV111Clientewwds_13_responsavelmunicipionome1 ,
                                             bool AV112Clientewwds_14_dynamicfiltersenabled2 ,
                                             string AV113Clientewwds_15_dynamicfiltersselector2 ,
                                             short AV114Clientewwds_16_dynamicfiltersoperator2 ,
                                             string AV115Clientewwds_17_clientedocumento2 ,
                                             string AV116Clientewwds_18_tipoclientedescricao2 ,
                                             string AV117Clientewwds_19_clienteconveniodescricao2 ,
                                             string AV118Clientewwds_20_clientenacionalidadenome2 ,
                                             string AV119Clientewwds_21_clienteprofissaonome2 ,
                                             string AV120Clientewwds_22_municipionome2 ,
                                             int AV121Clientewwds_23_bancocodigo2 ,
                                             string AV122Clientewwds_24_responsavelnacionalidadenome2 ,
                                             string AV123Clientewwds_25_responsavelprofissaonome2 ,
                                             string AV124Clientewwds_26_responsavelmunicipionome2 ,
                                             bool AV125Clientewwds_27_dynamicfiltersenabled3 ,
                                             string AV126Clientewwds_28_dynamicfiltersselector3 ,
                                             short AV127Clientewwds_29_dynamicfiltersoperator3 ,
                                             string AV128Clientewwds_30_clientedocumento3 ,
                                             string AV129Clientewwds_31_tipoclientedescricao3 ,
                                             string AV130Clientewwds_32_clienteconveniodescricao3 ,
                                             string AV131Clientewwds_33_clientenacionalidadenome3 ,
                                             string AV132Clientewwds_34_clienteprofissaonome3 ,
                                             string AV133Clientewwds_35_municipionome3 ,
                                             int AV134Clientewwds_36_bancocodigo3 ,
                                             string AV135Clientewwds_37_responsavelnacionalidadenome3 ,
                                             string AV136Clientewwds_38_responsavelprofissaonome3 ,
                                             string AV137Clientewwds_39_responsavelmunicipionome3 ,
                                             string AV139Clientewwds_41_tftipoclientedescricao_sel ,
                                             string AV138Clientewwds_40_tftipoclientedescricao ,
                                             string AV141Clientewwds_43_tfclienterazaosocial_sel ,
                                             string AV140Clientewwds_42_tfclienterazaosocial ,
                                             string AV143Clientewwds_45_tfclientedocumento_sel ,
                                             string AV142Clientewwds_44_tfclientedocumento ,
                                             int AV144Clientewwds_46_tfclientetipopessoa_sels_Count ,
                                             short AV145Clientewwds_47_tfclientestatus_sel ,
                                             string A193TipoClienteDescricao ,
                                             string A170ClienteRazaoSocial ,
                                             string A169ClienteDocumento ,
                                             bool A174ClienteStatus ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[76];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.TipoClienteId, T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.ClienteRazaoSocial, T4.MunicipioNome AS ResponsavelMunicipioNome, T8.ProfissaoNome AS ResponsavelProfissaoNome, T6.NacionalidadeNome AS ResponsavelNacionalidadeNome, T5.BancoCodigo, T3.MunicipioNome, T9.ProfissaoNome AS ClienteProfissaoNome, T7.NacionalidadeNome AS ClienteNacionalidadeNome, T10.ConvenioDescricao AS ClienteConvenioDescricao, T2.TipoClienteDescricao, T1.ClienteDocumento, T1.ClienteStatus, T1.ClienteTipoPessoa, T1.ClienteId FROM (((((((((Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T5 ON T5.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T7 ON T7.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T9 ON T9.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T10 ON T10.ConvenioId = T1.ClienteConvenio)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Clientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.TipoClienteDescricao) like '%' || LOWER(:lV99Clientewwds_1_filterfulltext)) or ( LOWER(T1.ClienteRazaoSocial) like '%' || LOWER(:lV99Clientewwds_1_filterfulltext)) or ( LOWER(T1.ClienteDocumento) like '%' || LOWER(:lV99Clientewwds_1_filterfulltext)) or ( 'física' like '%' || LOWER(:lV99Clientewwds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV99Clientewwds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'JURIDICA')) or ( 'ativo' like '%' || LOWER(:lV99Clientewwds_1_filterfulltext) and T1.ClienteStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV99Clientewwds_1_filterfulltext) and T1.ClienteStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Clientewwds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV102Clientewwds_4_clientedocumento1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Clientewwds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV102Clientewwds_4_clientedocumento1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Clientewwds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV103Clientewwds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Clientewwds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV103Clientewwds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Clientewwds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV104Clientewwds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Clientewwds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV104Clientewwds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Clientewwds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV105Clientewwds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Clientewwds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV105Clientewwds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Clientewwds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV106Clientewwds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Clientewwds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV106Clientewwds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Clientewwds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV107Clientewwds_9_municipionome1)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Clientewwds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV107Clientewwds_9_municipionome1)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV108Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV108Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV108Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV108Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV108Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV108Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Clientewwds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV109Clientewwds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Clientewwds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV109Clientewwds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Clientewwds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV110Clientewwds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Clientewwds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV110Clientewwds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Clientewwds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV111Clientewwds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Clientewwds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV111Clientewwds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Clientewwds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV115Clientewwds_17_clientedocumento2)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Clientewwds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV115Clientewwds_17_clientedocumento2)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Clientewwds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV116Clientewwds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Clientewwds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV116Clientewwds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Clientewwds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV117Clientewwds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Clientewwds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV117Clientewwds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Clientewwds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV118Clientewwds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Clientewwds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV118Clientewwds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Clientewwds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV119Clientewwds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Clientewwds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV119Clientewwds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Clientewwds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV120Clientewwds_22_municipionome2)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Clientewwds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV120Clientewwds_22_municipionome2)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV121Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV121Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV121Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV121Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV121Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV121Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Clientewwds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV122Clientewwds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Clientewwds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV122Clientewwds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Clientewwds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV123Clientewwds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Clientewwds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV123Clientewwds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Clientewwds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV124Clientewwds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Clientewwds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV124Clientewwds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Clientewwds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV128Clientewwds_30_clientedocumento3)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Clientewwds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV128Clientewwds_30_clientedocumento3)");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Clientewwds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV129Clientewwds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int3[51] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Clientewwds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV129Clientewwds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int3[52] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Clientewwds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV130Clientewwds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int3[53] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Clientewwds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV130Clientewwds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Clientewwds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV131Clientewwds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int3[55] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Clientewwds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV131Clientewwds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int3[56] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Clientewwds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV132Clientewwds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int3[57] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Clientewwds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV132Clientewwds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int3[58] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Clientewwds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV133Clientewwds_35_municipionome3)");
         }
         else
         {
            GXv_int3[59] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Clientewwds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV133Clientewwds_35_municipionome3)");
         }
         else
         {
            GXv_int3[60] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV134Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV134Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int3[61] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV134Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV134Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int3[62] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV134Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV134Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int3[63] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Clientewwds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV135Clientewwds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int3[64] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Clientewwds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV135Clientewwds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int3[65] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Clientewwds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV136Clientewwds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int3[66] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Clientewwds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV136Clientewwds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int3[67] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Clientewwds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV137Clientewwds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int3[68] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Clientewwds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV137Clientewwds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int3[69] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV139Clientewwds_41_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Clientewwds_40_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV138Clientewwds_40_tftipoclientedescricao)");
         }
         else
         {
            GXv_int3[70] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Clientewwds_41_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV139Clientewwds_41_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao = ( :AV139Clientewwds_41_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int3[71] = 1;
         }
         if ( StringUtil.StrCmp(AV139Clientewwds_41_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from T2.TipoClienteDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Clientewwds_43_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Clientewwds_42_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV140Clientewwds_42_tfclienterazaosocial)");
         }
         else
         {
            GXv_int3[72] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Clientewwds_43_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV141Clientewwds_43_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV141Clientewwds_43_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[73] = 1;
         }
         if ( StringUtil.StrCmp(AV141Clientewwds_43_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Clientewwds_45_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Clientewwds_44_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV142Clientewwds_44_tfclientedocumento)");
         }
         else
         {
            GXv_int3[74] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Clientewwds_45_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV143Clientewwds_45_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV143Clientewwds_45_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int3[75] = 1;
         }
         if ( StringUtil.StrCmp(AV143Clientewwds_45_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( AV144Clientewwds_46_tfclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV144Clientewwds_46_tfclientetipopessoa_sels, "T1.ClienteTipoPessoa IN (", ")")+")");
         }
         if ( AV145Clientewwds_47_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV145Clientewwds_47_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteRazaoSocial";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00684( IGxContext context ,
                                             string A172ClienteTipoPessoa ,
                                             GxSimpleCollection<string> AV144Clientewwds_46_tfclientetipopessoa_sels ,
                                             string AV99Clientewwds_1_filterfulltext ,
                                             string AV100Clientewwds_2_dynamicfiltersselector1 ,
                                             short AV101Clientewwds_3_dynamicfiltersoperator1 ,
                                             string AV102Clientewwds_4_clientedocumento1 ,
                                             string AV103Clientewwds_5_tipoclientedescricao1 ,
                                             string AV104Clientewwds_6_clienteconveniodescricao1 ,
                                             string AV105Clientewwds_7_clientenacionalidadenome1 ,
                                             string AV106Clientewwds_8_clienteprofissaonome1 ,
                                             string AV107Clientewwds_9_municipionome1 ,
                                             int AV108Clientewwds_10_bancocodigo1 ,
                                             string AV109Clientewwds_11_responsavelnacionalidadenome1 ,
                                             string AV110Clientewwds_12_responsavelprofissaonome1 ,
                                             string AV111Clientewwds_13_responsavelmunicipionome1 ,
                                             bool AV112Clientewwds_14_dynamicfiltersenabled2 ,
                                             string AV113Clientewwds_15_dynamicfiltersselector2 ,
                                             short AV114Clientewwds_16_dynamicfiltersoperator2 ,
                                             string AV115Clientewwds_17_clientedocumento2 ,
                                             string AV116Clientewwds_18_tipoclientedescricao2 ,
                                             string AV117Clientewwds_19_clienteconveniodescricao2 ,
                                             string AV118Clientewwds_20_clientenacionalidadenome2 ,
                                             string AV119Clientewwds_21_clienteprofissaonome2 ,
                                             string AV120Clientewwds_22_municipionome2 ,
                                             int AV121Clientewwds_23_bancocodigo2 ,
                                             string AV122Clientewwds_24_responsavelnacionalidadenome2 ,
                                             string AV123Clientewwds_25_responsavelprofissaonome2 ,
                                             string AV124Clientewwds_26_responsavelmunicipionome2 ,
                                             bool AV125Clientewwds_27_dynamicfiltersenabled3 ,
                                             string AV126Clientewwds_28_dynamicfiltersselector3 ,
                                             short AV127Clientewwds_29_dynamicfiltersoperator3 ,
                                             string AV128Clientewwds_30_clientedocumento3 ,
                                             string AV129Clientewwds_31_tipoclientedescricao3 ,
                                             string AV130Clientewwds_32_clienteconveniodescricao3 ,
                                             string AV131Clientewwds_33_clientenacionalidadenome3 ,
                                             string AV132Clientewwds_34_clienteprofissaonome3 ,
                                             string AV133Clientewwds_35_municipionome3 ,
                                             int AV134Clientewwds_36_bancocodigo3 ,
                                             string AV135Clientewwds_37_responsavelnacionalidadenome3 ,
                                             string AV136Clientewwds_38_responsavelprofissaonome3 ,
                                             string AV137Clientewwds_39_responsavelmunicipionome3 ,
                                             string AV139Clientewwds_41_tftipoclientedescricao_sel ,
                                             string AV138Clientewwds_40_tftipoclientedescricao ,
                                             string AV141Clientewwds_43_tfclienterazaosocial_sel ,
                                             string AV140Clientewwds_42_tfclienterazaosocial ,
                                             string AV143Clientewwds_45_tfclientedocumento_sel ,
                                             string AV142Clientewwds_44_tfclientedocumento ,
                                             int AV144Clientewwds_46_tfclientetipopessoa_sels_Count ,
                                             short AV145Clientewwds_47_tfclientestatus_sel ,
                                             string A193TipoClienteDescricao ,
                                             string A170ClienteRazaoSocial ,
                                             string A169ClienteDocumento ,
                                             bool A174ClienteStatus ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[76];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.TipoClienteId, T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.ClienteDocumento, T1.ClienteRazaoSocial, T4.MunicipioNome AS ResponsavelMunicipioNome, T8.ProfissaoNome AS ResponsavelProfissaoNome, T6.NacionalidadeNome AS ResponsavelNacionalidadeNome, T5.BancoCodigo, T3.MunicipioNome, T9.ProfissaoNome AS ClienteProfissaoNome, T7.NacionalidadeNome AS ClienteNacionalidadeNome, T10.ConvenioDescricao AS ClienteConvenioDescricao, T2.TipoClienteDescricao, T1.ClienteStatus, T1.ClienteTipoPessoa, T1.ClienteId FROM (((((((((Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T5 ON T5.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T7 ON T7.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T9 ON T9.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T10 ON T10.ConvenioId = T1.ClienteConvenio)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Clientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.TipoClienteDescricao) like '%' || LOWER(:lV99Clientewwds_1_filterfulltext)) or ( LOWER(T1.ClienteRazaoSocial) like '%' || LOWER(:lV99Clientewwds_1_filterfulltext)) or ( LOWER(T1.ClienteDocumento) like '%' || LOWER(:lV99Clientewwds_1_filterfulltext)) or ( 'física' like '%' || LOWER(:lV99Clientewwds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV99Clientewwds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'JURIDICA')) or ( 'ativo' like '%' || LOWER(:lV99Clientewwds_1_filterfulltext) and T1.ClienteStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV99Clientewwds_1_filterfulltext) and T1.ClienteStatus = FALSE))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Clientewwds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV102Clientewwds_4_clientedocumento1)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Clientewwds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV102Clientewwds_4_clientedocumento1)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Clientewwds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV103Clientewwds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Clientewwds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV103Clientewwds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Clientewwds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV104Clientewwds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Clientewwds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV104Clientewwds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Clientewwds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV105Clientewwds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Clientewwds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV105Clientewwds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Clientewwds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV106Clientewwds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Clientewwds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV106Clientewwds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Clientewwds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV107Clientewwds_9_municipionome1)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Clientewwds_9_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV107Clientewwds_9_municipionome1)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV108Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV108Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV108Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV108Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV108Clientewwds_10_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV108Clientewwds_10_bancocodigo1)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Clientewwds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV109Clientewwds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Clientewwds_11_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV109Clientewwds_11_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Clientewwds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV110Clientewwds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Clientewwds_12_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV110Clientewwds_12_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Clientewwds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV111Clientewwds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV100Clientewwds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV101Clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Clientewwds_13_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV111Clientewwds_13_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Clientewwds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV115Clientewwds_17_clientedocumento2)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Clientewwds_17_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV115Clientewwds_17_clientedocumento2)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Clientewwds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV116Clientewwds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Clientewwds_18_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV116Clientewwds_18_tipoclientedescricao2)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Clientewwds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV117Clientewwds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Clientewwds_19_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV117Clientewwds_19_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Clientewwds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV118Clientewwds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Clientewwds_20_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV118Clientewwds_20_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Clientewwds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV119Clientewwds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int5[36] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Clientewwds_21_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV119Clientewwds_21_clienteprofissaonome2)");
         }
         else
         {
            GXv_int5[37] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Clientewwds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV120Clientewwds_22_municipionome2)");
         }
         else
         {
            GXv_int5[38] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Clientewwds_22_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV120Clientewwds_22_municipionome2)");
         }
         else
         {
            GXv_int5[39] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV121Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV121Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int5[40] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV121Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV121Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int5[41] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV121Clientewwds_23_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV121Clientewwds_23_bancocodigo2)");
         }
         else
         {
            GXv_int5[42] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Clientewwds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV122Clientewwds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int5[43] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Clientewwds_24_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV122Clientewwds_24_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int5[44] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Clientewwds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV123Clientewwds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int5[45] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Clientewwds_25_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV123Clientewwds_25_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int5[46] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Clientewwds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV124Clientewwds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int5[47] = 1;
         }
         if ( AV112Clientewwds_14_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV113Clientewwds_15_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV114Clientewwds_16_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Clientewwds_26_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV124Clientewwds_26_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int5[48] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Clientewwds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV128Clientewwds_30_clientedocumento3)");
         }
         else
         {
            GXv_int5[49] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Clientewwds_30_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV128Clientewwds_30_clientedocumento3)");
         }
         else
         {
            GXv_int5[50] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Clientewwds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV129Clientewwds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int5[51] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Clientewwds_31_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV129Clientewwds_31_tipoclientedescricao3)");
         }
         else
         {
            GXv_int5[52] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Clientewwds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like :lV130Clientewwds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int5[53] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Clientewwds_32_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.ConvenioDescricao like '%' || :lV130Clientewwds_32_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int5[54] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Clientewwds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV131Clientewwds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int5[55] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Clientewwds_33_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV131Clientewwds_33_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int5[56] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Clientewwds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV132Clientewwds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int5[57] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Clientewwds_34_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV132Clientewwds_34_clienteprofissaonome3)");
         }
         else
         {
            GXv_int5[58] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Clientewwds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV133Clientewwds_35_municipionome3)");
         }
         else
         {
            GXv_int5[59] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Clientewwds_35_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV133Clientewwds_35_municipionome3)");
         }
         else
         {
            GXv_int5[60] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV134Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV134Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int5[61] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV134Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV134Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int5[62] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV134Clientewwds_36_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV134Clientewwds_36_bancocodigo3)");
         }
         else
         {
            GXv_int5[63] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Clientewwds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV135Clientewwds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int5[64] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Clientewwds_37_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV135Clientewwds_37_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int5[65] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Clientewwds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV136Clientewwds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int5[66] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Clientewwds_38_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV136Clientewwds_38_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int5[67] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Clientewwds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV137Clientewwds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int5[68] = 1;
         }
         if ( AV125Clientewwds_27_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Clientewwds_28_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV127Clientewwds_29_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Clientewwds_39_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV137Clientewwds_39_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int5[69] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV139Clientewwds_41_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Clientewwds_40_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV138Clientewwds_40_tftipoclientedescricao)");
         }
         else
         {
            GXv_int5[70] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Clientewwds_41_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV139Clientewwds_41_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao = ( :AV139Clientewwds_41_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int5[71] = 1;
         }
         if ( StringUtil.StrCmp(AV139Clientewwds_41_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from T2.TipoClienteDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV141Clientewwds_43_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Clientewwds_42_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV140Clientewwds_42_tfclienterazaosocial)");
         }
         else
         {
            GXv_int5[72] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Clientewwds_43_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV141Clientewwds_43_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV141Clientewwds_43_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int5[73] = 1;
         }
         if ( StringUtil.StrCmp(AV141Clientewwds_43_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Clientewwds_45_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Clientewwds_44_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV142Clientewwds_44_tfclientedocumento)");
         }
         else
         {
            GXv_int5[74] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Clientewwds_45_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV143Clientewwds_45_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV143Clientewwds_45_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int5[75] = 1;
         }
         if ( StringUtil.StrCmp(AV143Clientewwds_45_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( AV144Clientewwds_46_tfclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV144Clientewwds_46_tfclientetipopessoa_sels, "T1.ClienteTipoPessoa IN (", ")")+")");
         }
         if ( AV145Clientewwds_47_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV145Clientewwds_47_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteDocumento";
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
                     return conditional_P00682(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (short)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (bool)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (int)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] );
               case 1 :
                     return conditional_P00683(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (short)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (bool)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (int)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] );
               case 2 :
                     return conditional_P00684(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] , (short)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (int)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (short)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (bool)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (int)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] );
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
          Object[] prmP00682;
          prmP00682 = new Object[] {
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV102Clientewwds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV102Clientewwds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV103Clientewwds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV103Clientewwds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV104Clientewwds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV104Clientewwds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV105Clientewwds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV105Clientewwds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV106Clientewwds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV106Clientewwds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV107Clientewwds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV107Clientewwds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV108Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV108Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV108Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV109Clientewwds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV109Clientewwds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV110Clientewwds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV110Clientewwds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV111Clientewwds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV111Clientewwds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV115Clientewwds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV115Clientewwds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV116Clientewwds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV116Clientewwds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV117Clientewwds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV117Clientewwds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV118Clientewwds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV118Clientewwds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV119Clientewwds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV119Clientewwds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV120Clientewwds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV120Clientewwds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV121Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV121Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV121Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV122Clientewwds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV122Clientewwds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV123Clientewwds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV123Clientewwds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV124Clientewwds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV124Clientewwds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV128Clientewwds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV128Clientewwds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV129Clientewwds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV129Clientewwds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV130Clientewwds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV130Clientewwds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV131Clientewwds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV131Clientewwds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV132Clientewwds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV132Clientewwds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV133Clientewwds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV133Clientewwds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV134Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV134Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV134Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV135Clientewwds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV135Clientewwds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV136Clientewwds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV136Clientewwds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV137Clientewwds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV137Clientewwds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV138Clientewwds_40_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV139Clientewwds_41_tftipoclientedescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV140Clientewwds_42_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV141Clientewwds_43_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV142Clientewwds_44_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV143Clientewwds_45_tfclientedocumento_sel",GXType.VarChar,20,0)
          };
          Object[] prmP00683;
          prmP00683 = new Object[] {
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV102Clientewwds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV102Clientewwds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV103Clientewwds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV103Clientewwds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV104Clientewwds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV104Clientewwds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV105Clientewwds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV105Clientewwds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV106Clientewwds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV106Clientewwds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV107Clientewwds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV107Clientewwds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV108Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV108Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV108Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV109Clientewwds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV109Clientewwds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV110Clientewwds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV110Clientewwds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV111Clientewwds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV111Clientewwds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV115Clientewwds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV115Clientewwds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV116Clientewwds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV116Clientewwds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV117Clientewwds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV117Clientewwds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV118Clientewwds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV118Clientewwds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV119Clientewwds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV119Clientewwds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV120Clientewwds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV120Clientewwds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV121Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV121Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV121Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV122Clientewwds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV122Clientewwds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV123Clientewwds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV123Clientewwds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV124Clientewwds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV124Clientewwds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV128Clientewwds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV128Clientewwds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV129Clientewwds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV129Clientewwds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV130Clientewwds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV130Clientewwds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV131Clientewwds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV131Clientewwds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV132Clientewwds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV132Clientewwds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV133Clientewwds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV133Clientewwds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV134Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV134Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV134Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV135Clientewwds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV135Clientewwds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV136Clientewwds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV136Clientewwds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV137Clientewwds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV137Clientewwds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV138Clientewwds_40_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV139Clientewwds_41_tftipoclientedescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV140Clientewwds_42_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV141Clientewwds_43_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV142Clientewwds_44_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV143Clientewwds_45_tfclientedocumento_sel",GXType.VarChar,20,0)
          };
          Object[] prmP00684;
          prmP00684 = new Object[] {
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV99Clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV102Clientewwds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV102Clientewwds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV103Clientewwds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV103Clientewwds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV104Clientewwds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV104Clientewwds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV105Clientewwds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV105Clientewwds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV106Clientewwds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV106Clientewwds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV107Clientewwds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV107Clientewwds_9_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV108Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV108Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV108Clientewwds_10_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV109Clientewwds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV109Clientewwds_11_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV110Clientewwds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV110Clientewwds_12_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV111Clientewwds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV111Clientewwds_13_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV115Clientewwds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV115Clientewwds_17_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV116Clientewwds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV116Clientewwds_18_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV117Clientewwds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV117Clientewwds_19_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV118Clientewwds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV118Clientewwds_20_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV119Clientewwds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV119Clientewwds_21_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV120Clientewwds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV120Clientewwds_22_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV121Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV121Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV121Clientewwds_23_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV122Clientewwds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV122Clientewwds_24_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV123Clientewwds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV123Clientewwds_25_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV124Clientewwds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV124Clientewwds_26_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV128Clientewwds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV128Clientewwds_30_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV129Clientewwds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV129Clientewwds_31_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV130Clientewwds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV130Clientewwds_32_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV131Clientewwds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV131Clientewwds_33_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV132Clientewwds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV132Clientewwds_34_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV133Clientewwds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV133Clientewwds_35_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV134Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV134Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV134Clientewwds_36_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV135Clientewwds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV135Clientewwds_37_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV136Clientewwds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV136Clientewwds_38_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV137Clientewwds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV137Clientewwds_39_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV138Clientewwds_40_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV139Clientewwds_41_tftipoclientedescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("lV140Clientewwds_42_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV141Clientewwds_43_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV142Clientewwds_44_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV143Clientewwds_45_tfclientedocumento_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00682", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00682,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00683", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00683,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00684", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00684,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[4])[0] = rslt.getInt(3);
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
                ((short[]) buf[16])[0] = rslt.getShort(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((string[]) buf[36])[0] = rslt.getVarchar(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getVarchar(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((bool[]) buf[40])[0] = rslt.getBool(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((int[]) buf[44])[0] = rslt.getInt(23);
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((int[]) buf[26])[0] = rslt.getInt(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((string[]) buf[36])[0] = rslt.getVarchar(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getVarchar(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((bool[]) buf[40])[0] = rslt.getBool(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((int[]) buf[44])[0] = rslt.getInt(23);
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
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((string[]) buf[36])[0] = rslt.getVarchar(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getVarchar(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((bool[]) buf[40])[0] = rslt.getBool(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((int[]) buf[44])[0] = rslt.getInt(23);
                return;
       }
    }

 }

}
