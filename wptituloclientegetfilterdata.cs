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
   public class wptituloclientegetfilterdata : GXProcedure
   {
      public wptituloclientegetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wptituloclientegetfilterdata( IGxContext context )
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
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV44OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26MaxItems = 10;
         AV25PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV40SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV23SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? "" : StringUtil.Substring( AV40SearchTxtParms, 3, -1));
         AV24SkipItems = (short)(AV25PageIndex*AV26MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_CLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTERAZAOSOCIALOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_CLIENTENOMEFANTASIA") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTENOMEFANTASIAOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_CLIENTEDOCUMENTO") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTEDOCUMENTOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_TIPOCLIENTEDESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPOCLIENTEDESCRICAOOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV42OptionsJson = AV29Options.ToJSonString(false);
         AV43OptionsDescJson = AV31OptionsDesc.ToJSonString(false);
         AV44OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get("WpTituloCLienteGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpTituloCLienteGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("WpTituloCLienteGridState"), null, "", "");
         }
         AV93GXV1 = 1;
         while ( AV93GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV93GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV10TFClienteRazaoSocial = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV11TFClienteRazaoSocial_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCLIENTENOMEFANTASIA") == 0 )
            {
               AV12TFClienteNomeFantasia = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCLIENTENOMEFANTASIA_SEL") == 0 )
            {
               AV13TFClienteNomeFantasia_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCLIENTETIPOPESSOA_SEL") == 0 )
            {
               AV14TFClienteTipoPessoa_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV15TFClienteTipoPessoa_Sels.FromJSonString(AV14TFClienteTipoPessoa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV16TFClienteDocumento = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV17TFClienteDocumento_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO") == 0 )
            {
               AV18TFTipoClienteDescricao = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFTIPOCLIENTEDESCRICAO_SEL") == 0 )
            {
               AV19TFTipoClienteDescricao_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCLIENTESTATUS_SEL") == 0 )
            {
               AV20TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCLIENTEQTDTITULOS_F") == 0 )
            {
               AV66TFClienteQtdTitulos_F = (int)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV67TFClienteQtdTitulos_F_To = (int)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCLIENTEVALORAPAGAR_F") == 0 )
            {
               AV68TFClienteValorAPagar_F = NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, ".");
               AV69TFClienteValorAPagar_F_To = NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCLIENTEVALORARECEBER_F") == 0 )
            {
               AV70TFClienteValorAReceber_F = NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, ".");
               AV71TFClienteValorAReceber_F_To = NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV93GXV1 = (int)(AV93GXV1+1);
         }
         if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(1));
            AV46DynamicFiltersSelector1 = AV38GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV48ClienteDocumento1 = AV38GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV49TipoClienteDescricao1 = AV38GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV72ClienteConvenioDescricao1 = AV38GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV73ClienteNacionalidadeNome1 = AV38GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV74ClienteProfissaoNome1 = AV38GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV50SecUserName1 = AV38GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "MUNICIPIONOME") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV51MunicipioNome1 = AV38GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "BANCOCODIGO") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV75BancoCodigo1 = (int)(Math.Round(NumberUtil.Val( AV38GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV76ResponsavelNacionalidadeNome1 = AV38GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV77ResponsavelProfissaoNome1 = AV38GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV78ResponsavelMunicipioNome1 = AV38GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV52DynamicFiltersEnabled2 = true;
               AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(2));
               AV53DynamicFiltersSelector2 = AV38GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV55ClienteDocumento2 = AV38GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV56TipoClienteDescricao2 = AV38GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV79ClienteConvenioDescricao2 = AV38GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV80ClienteNacionalidadeNome2 = AV38GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV81ClienteProfissaoNome2 = AV38GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV57SecUserName2 = AV38GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV58MunicipioNome2 = AV38GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV82BancoCodigo2 = (int)(Math.Round(NumberUtil.Val( AV38GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV83ResponsavelNacionalidadeNome2 = AV38GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV84ResponsavelProfissaoNome2 = AV38GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV85ResponsavelMunicipioNome2 = AV38GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV59DynamicFiltersEnabled3 = true;
                  AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(3));
                  AV60DynamicFiltersSelector3 = AV38GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV60DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
                  {
                     AV61DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV62ClienteDocumento3 = AV38GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV60DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
                  {
                     AV61DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV63TipoClienteDescricao3 = AV38GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV60DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
                  {
                     AV61DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV86ClienteConvenioDescricao3 = AV38GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV60DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
                  {
                     AV61DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV87ClienteNacionalidadeNome3 = AV38GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV60DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
                  {
                     AV61DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV88ClienteProfissaoNome3 = AV38GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV60DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV61DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV64SecUserName3 = AV38GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV60DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
                  {
                     AV61DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV65MunicipioNome3 = AV38GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV60DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
                  {
                     AV61DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV89BancoCodigo3 = (int)(Math.Round(NumberUtil.Val( AV38GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV60DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
                  {
                     AV61DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV90ResponsavelNacionalidadeNome3 = AV38GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV60DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
                  {
                     AV61DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV91ResponsavelProfissaoNome3 = AV38GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV60DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
                  {
                     AV61DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV92ResponsavelMunicipioNome3 = AV38GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV10TFClienteRazaoSocial = AV23SearchTxt;
         AV11TFClienteRazaoSocial_Sel = "";
         AV95Wptituloclienteds_1_filterfulltext = AV45FilterFullText;
         AV96Wptituloclienteds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV97Wptituloclienteds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV98Wptituloclienteds_4_clientedocumento1 = AV48ClienteDocumento1;
         AV99Wptituloclienteds_5_tipoclientedescricao1 = AV49TipoClienteDescricao1;
         AV100Wptituloclienteds_6_clienteconveniodescricao1 = AV72ClienteConvenioDescricao1;
         AV101Wptituloclienteds_7_clientenacionalidadenome1 = AV73ClienteNacionalidadeNome1;
         AV102Wptituloclienteds_8_clienteprofissaonome1 = AV74ClienteProfissaoNome1;
         AV103Wptituloclienteds_9_secusername1 = AV50SecUserName1;
         AV104Wptituloclienteds_10_municipionome1 = AV51MunicipioNome1;
         AV105Wptituloclienteds_11_bancocodigo1 = AV75BancoCodigo1;
         AV106Wptituloclienteds_12_responsavelnacionalidadenome1 = AV76ResponsavelNacionalidadeNome1;
         AV107Wptituloclienteds_13_responsavelprofissaonome1 = AV77ResponsavelProfissaoNome1;
         AV108Wptituloclienteds_14_responsavelmunicipionome1 = AV78ResponsavelMunicipioNome1;
         AV109Wptituloclienteds_15_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV110Wptituloclienteds_16_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV111Wptituloclienteds_17_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV112Wptituloclienteds_18_clientedocumento2 = AV55ClienteDocumento2;
         AV113Wptituloclienteds_19_tipoclientedescricao2 = AV56TipoClienteDescricao2;
         AV114Wptituloclienteds_20_clienteconveniodescricao2 = AV79ClienteConvenioDescricao2;
         AV115Wptituloclienteds_21_clientenacionalidadenome2 = AV80ClienteNacionalidadeNome2;
         AV116Wptituloclienteds_22_clienteprofissaonome2 = AV81ClienteProfissaoNome2;
         AV117Wptituloclienteds_23_secusername2 = AV57SecUserName2;
         AV118Wptituloclienteds_24_municipionome2 = AV58MunicipioNome2;
         AV119Wptituloclienteds_25_bancocodigo2 = AV82BancoCodigo2;
         AV120Wptituloclienteds_26_responsavelnacionalidadenome2 = AV83ResponsavelNacionalidadeNome2;
         AV121Wptituloclienteds_27_responsavelprofissaonome2 = AV84ResponsavelProfissaoNome2;
         AV122Wptituloclienteds_28_responsavelmunicipionome2 = AV85ResponsavelMunicipioNome2;
         AV123Wptituloclienteds_29_dynamicfiltersenabled3 = AV59DynamicFiltersEnabled3;
         AV124Wptituloclienteds_30_dynamicfiltersselector3 = AV60DynamicFiltersSelector3;
         AV125Wptituloclienteds_31_dynamicfiltersoperator3 = AV61DynamicFiltersOperator3;
         AV126Wptituloclienteds_32_clientedocumento3 = AV62ClienteDocumento3;
         AV127Wptituloclienteds_33_tipoclientedescricao3 = AV63TipoClienteDescricao3;
         AV128Wptituloclienteds_34_clienteconveniodescricao3 = AV86ClienteConvenioDescricao3;
         AV129Wptituloclienteds_35_clientenacionalidadenome3 = AV87ClienteNacionalidadeNome3;
         AV130Wptituloclienteds_36_clienteprofissaonome3 = AV88ClienteProfissaoNome3;
         AV131Wptituloclienteds_37_secusername3 = AV64SecUserName3;
         AV132Wptituloclienteds_38_municipionome3 = AV65MunicipioNome3;
         AV133Wptituloclienteds_39_bancocodigo3 = AV89BancoCodigo3;
         AV134Wptituloclienteds_40_responsavelnacionalidadenome3 = AV90ResponsavelNacionalidadeNome3;
         AV135Wptituloclienteds_41_responsavelprofissaonome3 = AV91ResponsavelProfissaoNome3;
         AV136Wptituloclienteds_42_responsavelmunicipionome3 = AV92ResponsavelMunicipioNome3;
         AV137Wptituloclienteds_43_tfclienterazaosocial = AV10TFClienteRazaoSocial;
         AV138Wptituloclienteds_44_tfclienterazaosocial_sel = AV11TFClienteRazaoSocial_Sel;
         AV139Wptituloclienteds_45_tfclientenomefantasia = AV12TFClienteNomeFantasia;
         AV140Wptituloclienteds_46_tfclientenomefantasia_sel = AV13TFClienteNomeFantasia_Sel;
         AV141Wptituloclienteds_47_tfclientetipopessoa_sels = AV15TFClienteTipoPessoa_Sels;
         AV142Wptituloclienteds_48_tfclientedocumento = AV16TFClienteDocumento;
         AV143Wptituloclienteds_49_tfclientedocumento_sel = AV17TFClienteDocumento_Sel;
         AV144Wptituloclienteds_50_tftipoclientedescricao = AV18TFTipoClienteDescricao;
         AV145Wptituloclienteds_51_tftipoclientedescricao_sel = AV19TFTipoClienteDescricao_Sel;
         AV146Wptituloclienteds_52_tfclientestatus_sel = AV20TFClienteStatus_Sel;
         AV147Wptituloclienteds_53_tfclienteqtdtitulos_f = AV66TFClienteQtdTitulos_F;
         AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to = AV67TFClienteQtdTitulos_F_To;
         AV149Wptituloclienteds_55_tfclientevalorapagar_f = AV68TFClienteValorAPagar_F;
         AV150Wptituloclienteds_56_tfclientevalorapagar_f_to = AV69TFClienteValorAPagar_F_To;
         AV151Wptituloclienteds_57_tfclientevalorareceber_f = AV70TFClienteValorAReceber_F;
         AV152Wptituloclienteds_58_tfclientevalorareceber_f_to = AV71TFClienteValorAReceber_F_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A172ClienteTipoPessoa ,
                                              AV141Wptituloclienteds_47_tfclientetipopessoa_sels ,
                                              AV96Wptituloclienteds_2_dynamicfiltersselector1 ,
                                              AV97Wptituloclienteds_3_dynamicfiltersoperator1 ,
                                              AV98Wptituloclienteds_4_clientedocumento1 ,
                                              AV99Wptituloclienteds_5_tipoclientedescricao1 ,
                                              AV100Wptituloclienteds_6_clienteconveniodescricao1 ,
                                              AV101Wptituloclienteds_7_clientenacionalidadenome1 ,
                                              AV102Wptituloclienteds_8_clienteprofissaonome1 ,
                                              AV103Wptituloclienteds_9_secusername1 ,
                                              AV104Wptituloclienteds_10_municipionome1 ,
                                              AV105Wptituloclienteds_11_bancocodigo1 ,
                                              AV106Wptituloclienteds_12_responsavelnacionalidadenome1 ,
                                              AV107Wptituloclienteds_13_responsavelprofissaonome1 ,
                                              AV108Wptituloclienteds_14_responsavelmunicipionome1 ,
                                              AV109Wptituloclienteds_15_dynamicfiltersenabled2 ,
                                              AV110Wptituloclienteds_16_dynamicfiltersselector2 ,
                                              AV111Wptituloclienteds_17_dynamicfiltersoperator2 ,
                                              AV112Wptituloclienteds_18_clientedocumento2 ,
                                              AV113Wptituloclienteds_19_tipoclientedescricao2 ,
                                              AV114Wptituloclienteds_20_clienteconveniodescricao2 ,
                                              AV115Wptituloclienteds_21_clientenacionalidadenome2 ,
                                              AV116Wptituloclienteds_22_clienteprofissaonome2 ,
                                              AV117Wptituloclienteds_23_secusername2 ,
                                              AV118Wptituloclienteds_24_municipionome2 ,
                                              AV119Wptituloclienteds_25_bancocodigo2 ,
                                              AV120Wptituloclienteds_26_responsavelnacionalidadenome2 ,
                                              AV121Wptituloclienteds_27_responsavelprofissaonome2 ,
                                              AV122Wptituloclienteds_28_responsavelmunicipionome2 ,
                                              AV123Wptituloclienteds_29_dynamicfiltersenabled3 ,
                                              AV124Wptituloclienteds_30_dynamicfiltersselector3 ,
                                              AV125Wptituloclienteds_31_dynamicfiltersoperator3 ,
                                              AV126Wptituloclienteds_32_clientedocumento3 ,
                                              AV127Wptituloclienteds_33_tipoclientedescricao3 ,
                                              AV128Wptituloclienteds_34_clienteconveniodescricao3 ,
                                              AV129Wptituloclienteds_35_clientenacionalidadenome3 ,
                                              AV130Wptituloclienteds_36_clienteprofissaonome3 ,
                                              AV131Wptituloclienteds_37_secusername3 ,
                                              AV132Wptituloclienteds_38_municipionome3 ,
                                              AV133Wptituloclienteds_39_bancocodigo3 ,
                                              AV134Wptituloclienteds_40_responsavelnacionalidadenome3 ,
                                              AV135Wptituloclienteds_41_responsavelprofissaonome3 ,
                                              AV136Wptituloclienteds_42_responsavelmunicipionome3 ,
                                              AV138Wptituloclienteds_44_tfclienterazaosocial_sel ,
                                              AV137Wptituloclienteds_43_tfclienterazaosocial ,
                                              AV140Wptituloclienteds_46_tfclientenomefantasia_sel ,
                                              AV139Wptituloclienteds_45_tfclientenomefantasia ,
                                              AV141Wptituloclienteds_47_tfclientetipopessoa_sels.Count ,
                                              AV143Wptituloclienteds_49_tfclientedocumento_sel ,
                                              AV142Wptituloclienteds_48_tfclientedocumento ,
                                              AV145Wptituloclienteds_51_tftipoclientedescricao_sel ,
                                              AV144Wptituloclienteds_50_tftipoclientedescricao ,
                                              AV146Wptituloclienteds_52_tfclientestatus_sel ,
                                              AV149Wptituloclienteds_55_tfclientevalorapagar_f ,
                                              AV150Wptituloclienteds_56_tfclientevalorapagar_f_to ,
                                              AV151Wptituloclienteds_57_tfclientevalorareceber_f ,
                                              AV152Wptituloclienteds_58_tfclientevalorareceber_f_to ,
                                              A169ClienteDocumento ,
                                              A193TipoClienteDescricao ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A141SecUserName ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome ,
                                              A170ClienteRazaoSocial ,
                                              A171ClienteNomeFantasia ,
                                              A174ClienteStatus ,
                                              A310ClienteValorAPagar_F ,
                                              A311ClienteValorAReceber_F ,
                                              AV95Wptituloclienteds_1_filterfulltext ,
                                              A309ClienteQtdTitulos_F ,
                                              AV147Wptituloclienteds_53_tfclienteqtdtitulos_f ,
                                              AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV98Wptituloclienteds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1), "%", "");
         lV98Wptituloclienteds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1), "%", "");
         lV99Wptituloclienteds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1), "%", "");
         lV99Wptituloclienteds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1), "%", "");
         lV100Wptituloclienteds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1), "%", "");
         lV100Wptituloclienteds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1), "%", "");
         lV101Wptituloclienteds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1), "%", "");
         lV101Wptituloclienteds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1), "%", "");
         lV102Wptituloclienteds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1), "%", "");
         lV102Wptituloclienteds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1), "%", "");
         lV103Wptituloclienteds_9_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1), "%", "");
         lV103Wptituloclienteds_9_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1), "%", "");
         lV104Wptituloclienteds_10_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1), "%", "");
         lV104Wptituloclienteds_10_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1), "%", "");
         lV106Wptituloclienteds_12_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1), "%", "");
         lV106Wptituloclienteds_12_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1), "%", "");
         lV107Wptituloclienteds_13_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1), "%", "");
         lV107Wptituloclienteds_13_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1), "%", "");
         lV108Wptituloclienteds_14_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1), "%", "");
         lV108Wptituloclienteds_14_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1), "%", "");
         lV112Wptituloclienteds_18_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2), "%", "");
         lV112Wptituloclienteds_18_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2), "%", "");
         lV113Wptituloclienteds_19_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2), "%", "");
         lV113Wptituloclienteds_19_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2), "%", "");
         lV114Wptituloclienteds_20_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2), "%", "");
         lV114Wptituloclienteds_20_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2), "%", "");
         lV115Wptituloclienteds_21_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2), "%", "");
         lV115Wptituloclienteds_21_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2), "%", "");
         lV116Wptituloclienteds_22_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2), "%", "");
         lV116Wptituloclienteds_22_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2), "%", "");
         lV117Wptituloclienteds_23_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2), "%", "");
         lV117Wptituloclienteds_23_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2), "%", "");
         lV118Wptituloclienteds_24_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2), "%", "");
         lV118Wptituloclienteds_24_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2), "%", "");
         lV120Wptituloclienteds_26_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2), "%", "");
         lV120Wptituloclienteds_26_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2), "%", "");
         lV121Wptituloclienteds_27_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2), "%", "");
         lV121Wptituloclienteds_27_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2), "%", "");
         lV122Wptituloclienteds_28_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2), "%", "");
         lV122Wptituloclienteds_28_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2), "%", "");
         lV126Wptituloclienteds_32_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3), "%", "");
         lV126Wptituloclienteds_32_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3), "%", "");
         lV127Wptituloclienteds_33_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3), "%", "");
         lV127Wptituloclienteds_33_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3), "%", "");
         lV128Wptituloclienteds_34_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3), "%", "");
         lV128Wptituloclienteds_34_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3), "%", "");
         lV129Wptituloclienteds_35_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3), "%", "");
         lV129Wptituloclienteds_35_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3), "%", "");
         lV130Wptituloclienteds_36_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3), "%", "");
         lV130Wptituloclienteds_36_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3), "%", "");
         lV131Wptituloclienteds_37_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3), "%", "");
         lV131Wptituloclienteds_37_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3), "%", "");
         lV132Wptituloclienteds_38_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3), "%", "");
         lV132Wptituloclienteds_38_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3), "%", "");
         lV134Wptituloclienteds_40_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3), "%", "");
         lV134Wptituloclienteds_40_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3), "%", "");
         lV135Wptituloclienteds_41_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3), "%", "");
         lV135Wptituloclienteds_41_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3), "%", "");
         lV136Wptituloclienteds_42_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3), "%", "");
         lV136Wptituloclienteds_42_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3), "%", "");
         lV137Wptituloclienteds_43_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV137Wptituloclienteds_43_tfclienterazaosocial), "%", "");
         lV139Wptituloclienteds_45_tfclientenomefantasia = StringUtil.Concat( StringUtil.RTrim( AV139Wptituloclienteds_45_tfclientenomefantasia), "%", "");
         lV142Wptituloclienteds_48_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV142Wptituloclienteds_48_tfclientedocumento), "%", "");
         lV144Wptituloclienteds_50_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV144Wptituloclienteds_50_tftipoclientedescricao), "%", "");
         /* Using cursor P008A8 */
         pr_default.execute(0, new Object[] {AV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, AV147Wptituloclienteds_53_tfclienteqtdtitulos_f, AV147Wptituloclienteds_53_tfclienteqtdtitulos_f, AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to, AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to, lV98Wptituloclienteds_4_clientedocumento1, lV98Wptituloclienteds_4_clientedocumento1, lV99Wptituloclienteds_5_tipoclientedescricao1, lV99Wptituloclienteds_5_tipoclientedescricao1, lV100Wptituloclienteds_6_clienteconveniodescricao1, lV100Wptituloclienteds_6_clienteconveniodescricao1, lV101Wptituloclienteds_7_clientenacionalidadenome1, lV101Wptituloclienteds_7_clientenacionalidadenome1, lV102Wptituloclienteds_8_clienteprofissaonome1, lV102Wptituloclienteds_8_clienteprofissaonome1, lV103Wptituloclienteds_9_secusername1, lV103Wptituloclienteds_9_secusername1, lV104Wptituloclienteds_10_municipionome1, lV104Wptituloclienteds_10_municipionome1, AV105Wptituloclienteds_11_bancocodigo1, AV105Wptituloclienteds_11_bancocodigo1, AV105Wptituloclienteds_11_bancocodigo1, lV106Wptituloclienteds_12_responsavelnacionalidadenome1, lV106Wptituloclienteds_12_responsavelnacionalidadenome1, lV107Wptituloclienteds_13_responsavelprofissaonome1, lV107Wptituloclienteds_13_responsavelprofissaonome1, lV108Wptituloclienteds_14_responsavelmunicipionome1, lV108Wptituloclienteds_14_responsavelmunicipionome1, lV112Wptituloclienteds_18_clientedocumento2, lV112Wptituloclienteds_18_clientedocumento2, lV113Wptituloclienteds_19_tipoclientedescricao2, lV113Wptituloclienteds_19_tipoclientedescricao2, lV114Wptituloclienteds_20_clienteconveniodescricao2, lV114Wptituloclienteds_20_clienteconveniodescricao2, lV115Wptituloclienteds_21_clientenacionalidadenome2, lV115Wptituloclienteds_21_clientenacionalidadenome2, lV116Wptituloclienteds_22_clienteprofissaonome2, lV116Wptituloclienteds_22_clienteprofissaonome2, lV117Wptituloclienteds_23_secusername2, lV117Wptituloclienteds_23_secusername2, lV118Wptituloclienteds_24_municipionome2, lV118Wptituloclienteds_24_municipionome2, AV119Wptituloclienteds_25_bancocodigo2, AV119Wptituloclienteds_25_bancocodigo2, AV119Wptituloclienteds_25_bancocodigo2, lV120Wptituloclienteds_26_responsavelnacionalidadenome2, lV120Wptituloclienteds_26_responsavelnacionalidadenome2, lV121Wptituloclienteds_27_responsavelprofissaonome2, lV121Wptituloclienteds_27_responsavelprofissaonome2, lV122Wptituloclienteds_28_responsavelmunicipionome2, lV122Wptituloclienteds_28_responsavelmunicipionome2, lV126Wptituloclienteds_32_clientedocumento3, lV126Wptituloclienteds_32_clientedocumento3, lV127Wptituloclienteds_33_tipoclientedescricao3, lV127Wptituloclienteds_33_tipoclientedescricao3, lV128Wptituloclienteds_34_clienteconveniodescricao3, lV128Wptituloclienteds_34_clienteconveniodescricao3, lV129Wptituloclienteds_35_clientenacionalidadenome3, lV129Wptituloclienteds_35_clientenacionalidadenome3, lV130Wptituloclienteds_36_clienteprofissaonome3, lV130Wptituloclienteds_36_clienteprofissaonome3, lV131Wptituloclienteds_37_secusername3, lV131Wptituloclienteds_37_secusername3, lV132Wptituloclienteds_38_municipionome3, lV132Wptituloclienteds_38_municipionome3, AV133Wptituloclienteds_39_bancocodigo3, AV133Wptituloclienteds_39_bancocodigo3, AV133Wptituloclienteds_39_bancocodigo3, lV134Wptituloclienteds_40_responsavelnacionalidadenome3, lV134Wptituloclienteds_40_responsavelnacionalidadenome3, lV135Wptituloclienteds_41_responsavelprofissaonome3, lV135Wptituloclienteds_41_responsavelprofissaonome3, lV136Wptituloclienteds_42_responsavelmunicipionome3, lV136Wptituloclienteds_42_responsavelmunicipionome3, lV137Wptituloclienteds_43_tfclienterazaosocial, AV138Wptituloclienteds_44_tfclienterazaosocial_sel, lV139Wptituloclienteds_45_tfclientenomefantasia, AV140Wptituloclienteds_46_tfclientenomefantasia_sel, lV142Wptituloclienteds_48_tfclientedocumento, AV143Wptituloclienteds_49_tfclientedocumento_sel, lV144Wptituloclienteds_50_tftipoclientedescricao, AV145Wptituloclienteds_51_tftipoclientedescricao_sel, AV149Wptituloclienteds_55_tfclientevalorapagar_f, AV150Wptituloclienteds_56_tfclientevalorapagar_f_to, AV151Wptituloclienteds_57_tfclientevalorareceber_f, AV152Wptituloclienteds_58_tfclientevalorareceber_f_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8A2 = false;
            A192TipoClienteId = P008A8_A192TipoClienteId[0];
            n192TipoClienteId = P008A8_n192TipoClienteId[0];
            A186MunicipioCodigo = P008A8_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P008A8_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P008A8_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P008A8_n444ResponsavelMunicipio[0];
            A402BancoId = P008A8_A402BancoId[0];
            n402BancoId = P008A8_n402BancoId[0];
            A457EspecialidadeId = P008A8_A457EspecialidadeId[0];
            n457EspecialidadeId = P008A8_n457EspecialidadeId[0];
            A597EspecialidadeCreatedBy = P008A8_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = P008A8_n597EspecialidadeCreatedBy[0];
            A437ResponsavelNacionalidade = P008A8_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P008A8_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P008A8_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P008A8_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P008A8_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P008A8_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P008A8_A487ClienteProfissao[0];
            n487ClienteProfissao = P008A8_n487ClienteProfissao[0];
            A489ClienteConvenio = P008A8_A489ClienteConvenio[0];
            n489ClienteConvenio = P008A8_n489ClienteConvenio[0];
            A168ClienteId = P008A8_A168ClienteId[0];
            n168ClienteId = P008A8_n168ClienteId[0];
            A170ClienteRazaoSocial = P008A8_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P008A8_n170ClienteRazaoSocial[0];
            A445ResponsavelMunicipioNome = P008A8_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P008A8_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P008A8_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P008A8_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P008A8_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P008A8_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P008A8_A404BancoCodigo[0];
            n404BancoCodigo = P008A8_n404BancoCodigo[0];
            A187MunicipioNome = P008A8_A187MunicipioNome[0];
            n187MunicipioNome = P008A8_n187MunicipioNome[0];
            A141SecUserName = P008A8_A141SecUserName[0];
            n141SecUserName = P008A8_n141SecUserName[0];
            A488ClienteProfissaoNome = P008A8_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P008A8_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P008A8_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P008A8_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P008A8_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P008A8_n490ClienteConvenioDescricao[0];
            A174ClienteStatus = P008A8_A174ClienteStatus[0];
            n174ClienteStatus = P008A8_n174ClienteStatus[0];
            A193TipoClienteDescricao = P008A8_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P008A8_n193TipoClienteDescricao[0];
            A169ClienteDocumento = P008A8_A169ClienteDocumento[0];
            n169ClienteDocumento = P008A8_n169ClienteDocumento[0];
            A172ClienteTipoPessoa = P008A8_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = P008A8_n172ClienteTipoPessoa[0];
            A171ClienteNomeFantasia = P008A8_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = P008A8_n171ClienteNomeFantasia[0];
            A311ClienteValorAReceber_F = P008A8_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = P008A8_n311ClienteValorAReceber_F[0];
            A310ClienteValorAPagar_F = P008A8_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = P008A8_n310ClienteValorAPagar_F[0];
            A309ClienteQtdTitulos_F = P008A8_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = P008A8_n309ClienteQtdTitulos_F[0];
            A193TipoClienteDescricao = P008A8_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P008A8_n193TipoClienteDescricao[0];
            A187MunicipioNome = P008A8_A187MunicipioNome[0];
            n187MunicipioNome = P008A8_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P008A8_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P008A8_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P008A8_A404BancoCodigo[0];
            n404BancoCodigo = P008A8_n404BancoCodigo[0];
            A597EspecialidadeCreatedBy = P008A8_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = P008A8_n597EspecialidadeCreatedBy[0];
            A141SecUserName = P008A8_A141SecUserName[0];
            n141SecUserName = P008A8_n141SecUserName[0];
            A438ResponsavelNacionalidadeNome = P008A8_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P008A8_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P008A8_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P008A8_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P008A8_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P008A8_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P008A8_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P008A8_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P008A8_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P008A8_n490ClienteConvenioDescricao[0];
            A311ClienteValorAReceber_F = P008A8_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = P008A8_n311ClienteValorAReceber_F[0];
            A310ClienteValorAPagar_F = P008A8_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = P008A8_n310ClienteValorAPagar_F[0];
            A309ClienteQtdTitulos_F = P008A8_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = P008A8_n309ClienteQtdTitulos_F[0];
            AV33count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P008A8_A170ClienteRazaoSocial[0], A170ClienteRazaoSocial) == 0 ) )
            {
               BRK8A2 = false;
               A168ClienteId = P008A8_A168ClienteId[0];
               n168ClienteId = P008A8_n168ClienteId[0];
               AV33count = (long)(AV33count+1);
               BRK8A2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ClienteRazaoSocial)) ? "<#Empty#>" : A170ClienteRazaoSocial);
               AV30OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")));
               AV29Options.Add(AV28Option, 0);
               AV31OptionsDesc.Add(AV30OptionDesc, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK8A2 )
            {
               BRK8A2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCLIENTENOMEFANTASIAOPTIONS' Routine */
         returnInSub = false;
         AV12TFClienteNomeFantasia = AV23SearchTxt;
         AV13TFClienteNomeFantasia_Sel = "";
         AV95Wptituloclienteds_1_filterfulltext = AV45FilterFullText;
         AV96Wptituloclienteds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV97Wptituloclienteds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV98Wptituloclienteds_4_clientedocumento1 = AV48ClienteDocumento1;
         AV99Wptituloclienteds_5_tipoclientedescricao1 = AV49TipoClienteDescricao1;
         AV100Wptituloclienteds_6_clienteconveniodescricao1 = AV72ClienteConvenioDescricao1;
         AV101Wptituloclienteds_7_clientenacionalidadenome1 = AV73ClienteNacionalidadeNome1;
         AV102Wptituloclienteds_8_clienteprofissaonome1 = AV74ClienteProfissaoNome1;
         AV103Wptituloclienteds_9_secusername1 = AV50SecUserName1;
         AV104Wptituloclienteds_10_municipionome1 = AV51MunicipioNome1;
         AV105Wptituloclienteds_11_bancocodigo1 = AV75BancoCodigo1;
         AV106Wptituloclienteds_12_responsavelnacionalidadenome1 = AV76ResponsavelNacionalidadeNome1;
         AV107Wptituloclienteds_13_responsavelprofissaonome1 = AV77ResponsavelProfissaoNome1;
         AV108Wptituloclienteds_14_responsavelmunicipionome1 = AV78ResponsavelMunicipioNome1;
         AV109Wptituloclienteds_15_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV110Wptituloclienteds_16_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV111Wptituloclienteds_17_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV112Wptituloclienteds_18_clientedocumento2 = AV55ClienteDocumento2;
         AV113Wptituloclienteds_19_tipoclientedescricao2 = AV56TipoClienteDescricao2;
         AV114Wptituloclienteds_20_clienteconveniodescricao2 = AV79ClienteConvenioDescricao2;
         AV115Wptituloclienteds_21_clientenacionalidadenome2 = AV80ClienteNacionalidadeNome2;
         AV116Wptituloclienteds_22_clienteprofissaonome2 = AV81ClienteProfissaoNome2;
         AV117Wptituloclienteds_23_secusername2 = AV57SecUserName2;
         AV118Wptituloclienteds_24_municipionome2 = AV58MunicipioNome2;
         AV119Wptituloclienteds_25_bancocodigo2 = AV82BancoCodigo2;
         AV120Wptituloclienteds_26_responsavelnacionalidadenome2 = AV83ResponsavelNacionalidadeNome2;
         AV121Wptituloclienteds_27_responsavelprofissaonome2 = AV84ResponsavelProfissaoNome2;
         AV122Wptituloclienteds_28_responsavelmunicipionome2 = AV85ResponsavelMunicipioNome2;
         AV123Wptituloclienteds_29_dynamicfiltersenabled3 = AV59DynamicFiltersEnabled3;
         AV124Wptituloclienteds_30_dynamicfiltersselector3 = AV60DynamicFiltersSelector3;
         AV125Wptituloclienteds_31_dynamicfiltersoperator3 = AV61DynamicFiltersOperator3;
         AV126Wptituloclienteds_32_clientedocumento3 = AV62ClienteDocumento3;
         AV127Wptituloclienteds_33_tipoclientedescricao3 = AV63TipoClienteDescricao3;
         AV128Wptituloclienteds_34_clienteconveniodescricao3 = AV86ClienteConvenioDescricao3;
         AV129Wptituloclienteds_35_clientenacionalidadenome3 = AV87ClienteNacionalidadeNome3;
         AV130Wptituloclienteds_36_clienteprofissaonome3 = AV88ClienteProfissaoNome3;
         AV131Wptituloclienteds_37_secusername3 = AV64SecUserName3;
         AV132Wptituloclienteds_38_municipionome3 = AV65MunicipioNome3;
         AV133Wptituloclienteds_39_bancocodigo3 = AV89BancoCodigo3;
         AV134Wptituloclienteds_40_responsavelnacionalidadenome3 = AV90ResponsavelNacionalidadeNome3;
         AV135Wptituloclienteds_41_responsavelprofissaonome3 = AV91ResponsavelProfissaoNome3;
         AV136Wptituloclienteds_42_responsavelmunicipionome3 = AV92ResponsavelMunicipioNome3;
         AV137Wptituloclienteds_43_tfclienterazaosocial = AV10TFClienteRazaoSocial;
         AV138Wptituloclienteds_44_tfclienterazaosocial_sel = AV11TFClienteRazaoSocial_Sel;
         AV139Wptituloclienteds_45_tfclientenomefantasia = AV12TFClienteNomeFantasia;
         AV140Wptituloclienteds_46_tfclientenomefantasia_sel = AV13TFClienteNomeFantasia_Sel;
         AV141Wptituloclienteds_47_tfclientetipopessoa_sels = AV15TFClienteTipoPessoa_Sels;
         AV142Wptituloclienteds_48_tfclientedocumento = AV16TFClienteDocumento;
         AV143Wptituloclienteds_49_tfclientedocumento_sel = AV17TFClienteDocumento_Sel;
         AV144Wptituloclienteds_50_tftipoclientedescricao = AV18TFTipoClienteDescricao;
         AV145Wptituloclienteds_51_tftipoclientedescricao_sel = AV19TFTipoClienteDescricao_Sel;
         AV146Wptituloclienteds_52_tfclientestatus_sel = AV20TFClienteStatus_Sel;
         AV147Wptituloclienteds_53_tfclienteqtdtitulos_f = AV66TFClienteQtdTitulos_F;
         AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to = AV67TFClienteQtdTitulos_F_To;
         AV149Wptituloclienteds_55_tfclientevalorapagar_f = AV68TFClienteValorAPagar_F;
         AV150Wptituloclienteds_56_tfclientevalorapagar_f_to = AV69TFClienteValorAPagar_F_To;
         AV151Wptituloclienteds_57_tfclientevalorareceber_f = AV70TFClienteValorAReceber_F;
         AV152Wptituloclienteds_58_tfclientevalorareceber_f_to = AV71TFClienteValorAReceber_F_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A172ClienteTipoPessoa ,
                                              AV141Wptituloclienteds_47_tfclientetipopessoa_sels ,
                                              AV96Wptituloclienteds_2_dynamicfiltersselector1 ,
                                              AV97Wptituloclienteds_3_dynamicfiltersoperator1 ,
                                              AV98Wptituloclienteds_4_clientedocumento1 ,
                                              AV99Wptituloclienteds_5_tipoclientedescricao1 ,
                                              AV100Wptituloclienteds_6_clienteconveniodescricao1 ,
                                              AV101Wptituloclienteds_7_clientenacionalidadenome1 ,
                                              AV102Wptituloclienteds_8_clienteprofissaonome1 ,
                                              AV103Wptituloclienteds_9_secusername1 ,
                                              AV104Wptituloclienteds_10_municipionome1 ,
                                              AV105Wptituloclienteds_11_bancocodigo1 ,
                                              AV106Wptituloclienteds_12_responsavelnacionalidadenome1 ,
                                              AV107Wptituloclienteds_13_responsavelprofissaonome1 ,
                                              AV108Wptituloclienteds_14_responsavelmunicipionome1 ,
                                              AV109Wptituloclienteds_15_dynamicfiltersenabled2 ,
                                              AV110Wptituloclienteds_16_dynamicfiltersselector2 ,
                                              AV111Wptituloclienteds_17_dynamicfiltersoperator2 ,
                                              AV112Wptituloclienteds_18_clientedocumento2 ,
                                              AV113Wptituloclienteds_19_tipoclientedescricao2 ,
                                              AV114Wptituloclienteds_20_clienteconveniodescricao2 ,
                                              AV115Wptituloclienteds_21_clientenacionalidadenome2 ,
                                              AV116Wptituloclienteds_22_clienteprofissaonome2 ,
                                              AV117Wptituloclienteds_23_secusername2 ,
                                              AV118Wptituloclienteds_24_municipionome2 ,
                                              AV119Wptituloclienteds_25_bancocodigo2 ,
                                              AV120Wptituloclienteds_26_responsavelnacionalidadenome2 ,
                                              AV121Wptituloclienteds_27_responsavelprofissaonome2 ,
                                              AV122Wptituloclienteds_28_responsavelmunicipionome2 ,
                                              AV123Wptituloclienteds_29_dynamicfiltersenabled3 ,
                                              AV124Wptituloclienteds_30_dynamicfiltersselector3 ,
                                              AV125Wptituloclienteds_31_dynamicfiltersoperator3 ,
                                              AV126Wptituloclienteds_32_clientedocumento3 ,
                                              AV127Wptituloclienteds_33_tipoclientedescricao3 ,
                                              AV128Wptituloclienteds_34_clienteconveniodescricao3 ,
                                              AV129Wptituloclienteds_35_clientenacionalidadenome3 ,
                                              AV130Wptituloclienteds_36_clienteprofissaonome3 ,
                                              AV131Wptituloclienteds_37_secusername3 ,
                                              AV132Wptituloclienteds_38_municipionome3 ,
                                              AV133Wptituloclienteds_39_bancocodigo3 ,
                                              AV134Wptituloclienteds_40_responsavelnacionalidadenome3 ,
                                              AV135Wptituloclienteds_41_responsavelprofissaonome3 ,
                                              AV136Wptituloclienteds_42_responsavelmunicipionome3 ,
                                              AV138Wptituloclienteds_44_tfclienterazaosocial_sel ,
                                              AV137Wptituloclienteds_43_tfclienterazaosocial ,
                                              AV140Wptituloclienteds_46_tfclientenomefantasia_sel ,
                                              AV139Wptituloclienteds_45_tfclientenomefantasia ,
                                              AV141Wptituloclienteds_47_tfclientetipopessoa_sels.Count ,
                                              AV143Wptituloclienteds_49_tfclientedocumento_sel ,
                                              AV142Wptituloclienteds_48_tfclientedocumento ,
                                              AV145Wptituloclienteds_51_tftipoclientedescricao_sel ,
                                              AV144Wptituloclienteds_50_tftipoclientedescricao ,
                                              AV146Wptituloclienteds_52_tfclientestatus_sel ,
                                              AV149Wptituloclienteds_55_tfclientevalorapagar_f ,
                                              AV150Wptituloclienteds_56_tfclientevalorapagar_f_to ,
                                              AV151Wptituloclienteds_57_tfclientevalorareceber_f ,
                                              AV152Wptituloclienteds_58_tfclientevalorareceber_f_to ,
                                              A169ClienteDocumento ,
                                              A193TipoClienteDescricao ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A141SecUserName ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome ,
                                              A170ClienteRazaoSocial ,
                                              A171ClienteNomeFantasia ,
                                              A174ClienteStatus ,
                                              A310ClienteValorAPagar_F ,
                                              A311ClienteValorAReceber_F ,
                                              AV95Wptituloclienteds_1_filterfulltext ,
                                              A309ClienteQtdTitulos_F ,
                                              AV147Wptituloclienteds_53_tfclienteqtdtitulos_f ,
                                              AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV98Wptituloclienteds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1), "%", "");
         lV98Wptituloclienteds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1), "%", "");
         lV99Wptituloclienteds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1), "%", "");
         lV99Wptituloclienteds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1), "%", "");
         lV100Wptituloclienteds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1), "%", "");
         lV100Wptituloclienteds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1), "%", "");
         lV101Wptituloclienteds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1), "%", "");
         lV101Wptituloclienteds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1), "%", "");
         lV102Wptituloclienteds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1), "%", "");
         lV102Wptituloclienteds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1), "%", "");
         lV103Wptituloclienteds_9_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1), "%", "");
         lV103Wptituloclienteds_9_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1), "%", "");
         lV104Wptituloclienteds_10_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1), "%", "");
         lV104Wptituloclienteds_10_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1), "%", "");
         lV106Wptituloclienteds_12_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1), "%", "");
         lV106Wptituloclienteds_12_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1), "%", "");
         lV107Wptituloclienteds_13_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1), "%", "");
         lV107Wptituloclienteds_13_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1), "%", "");
         lV108Wptituloclienteds_14_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1), "%", "");
         lV108Wptituloclienteds_14_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1), "%", "");
         lV112Wptituloclienteds_18_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2), "%", "");
         lV112Wptituloclienteds_18_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2), "%", "");
         lV113Wptituloclienteds_19_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2), "%", "");
         lV113Wptituloclienteds_19_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2), "%", "");
         lV114Wptituloclienteds_20_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2), "%", "");
         lV114Wptituloclienteds_20_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2), "%", "");
         lV115Wptituloclienteds_21_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2), "%", "");
         lV115Wptituloclienteds_21_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2), "%", "");
         lV116Wptituloclienteds_22_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2), "%", "");
         lV116Wptituloclienteds_22_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2), "%", "");
         lV117Wptituloclienteds_23_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2), "%", "");
         lV117Wptituloclienteds_23_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2), "%", "");
         lV118Wptituloclienteds_24_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2), "%", "");
         lV118Wptituloclienteds_24_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2), "%", "");
         lV120Wptituloclienteds_26_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2), "%", "");
         lV120Wptituloclienteds_26_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2), "%", "");
         lV121Wptituloclienteds_27_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2), "%", "");
         lV121Wptituloclienteds_27_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2), "%", "");
         lV122Wptituloclienteds_28_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2), "%", "");
         lV122Wptituloclienteds_28_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2), "%", "");
         lV126Wptituloclienteds_32_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3), "%", "");
         lV126Wptituloclienteds_32_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3), "%", "");
         lV127Wptituloclienteds_33_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3), "%", "");
         lV127Wptituloclienteds_33_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3), "%", "");
         lV128Wptituloclienteds_34_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3), "%", "");
         lV128Wptituloclienteds_34_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3), "%", "");
         lV129Wptituloclienteds_35_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3), "%", "");
         lV129Wptituloclienteds_35_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3), "%", "");
         lV130Wptituloclienteds_36_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3), "%", "");
         lV130Wptituloclienteds_36_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3), "%", "");
         lV131Wptituloclienteds_37_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3), "%", "");
         lV131Wptituloclienteds_37_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3), "%", "");
         lV132Wptituloclienteds_38_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3), "%", "");
         lV132Wptituloclienteds_38_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3), "%", "");
         lV134Wptituloclienteds_40_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3), "%", "");
         lV134Wptituloclienteds_40_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3), "%", "");
         lV135Wptituloclienteds_41_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3), "%", "");
         lV135Wptituloclienteds_41_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3), "%", "");
         lV136Wptituloclienteds_42_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3), "%", "");
         lV136Wptituloclienteds_42_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3), "%", "");
         lV137Wptituloclienteds_43_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV137Wptituloclienteds_43_tfclienterazaosocial), "%", "");
         lV139Wptituloclienteds_45_tfclientenomefantasia = StringUtil.Concat( StringUtil.RTrim( AV139Wptituloclienteds_45_tfclientenomefantasia), "%", "");
         lV142Wptituloclienteds_48_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV142Wptituloclienteds_48_tfclientedocumento), "%", "");
         lV144Wptituloclienteds_50_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV144Wptituloclienteds_50_tftipoclientedescricao), "%", "");
         /* Using cursor P008A15 */
         pr_default.execute(1, new Object[] {AV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, AV147Wptituloclienteds_53_tfclienteqtdtitulos_f, AV147Wptituloclienteds_53_tfclienteqtdtitulos_f, AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to, AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to, lV98Wptituloclienteds_4_clientedocumento1, lV98Wptituloclienteds_4_clientedocumento1, lV99Wptituloclienteds_5_tipoclientedescricao1, lV99Wptituloclienteds_5_tipoclientedescricao1, lV100Wptituloclienteds_6_clienteconveniodescricao1, lV100Wptituloclienteds_6_clienteconveniodescricao1, lV101Wptituloclienteds_7_clientenacionalidadenome1, lV101Wptituloclienteds_7_clientenacionalidadenome1, lV102Wptituloclienteds_8_clienteprofissaonome1, lV102Wptituloclienteds_8_clienteprofissaonome1, lV103Wptituloclienteds_9_secusername1, lV103Wptituloclienteds_9_secusername1, lV104Wptituloclienteds_10_municipionome1, lV104Wptituloclienteds_10_municipionome1, AV105Wptituloclienteds_11_bancocodigo1, AV105Wptituloclienteds_11_bancocodigo1, AV105Wptituloclienteds_11_bancocodigo1, lV106Wptituloclienteds_12_responsavelnacionalidadenome1, lV106Wptituloclienteds_12_responsavelnacionalidadenome1, lV107Wptituloclienteds_13_responsavelprofissaonome1, lV107Wptituloclienteds_13_responsavelprofissaonome1, lV108Wptituloclienteds_14_responsavelmunicipionome1, lV108Wptituloclienteds_14_responsavelmunicipionome1, lV112Wptituloclienteds_18_clientedocumento2, lV112Wptituloclienteds_18_clientedocumento2, lV113Wptituloclienteds_19_tipoclientedescricao2, lV113Wptituloclienteds_19_tipoclientedescricao2, lV114Wptituloclienteds_20_clienteconveniodescricao2, lV114Wptituloclienteds_20_clienteconveniodescricao2, lV115Wptituloclienteds_21_clientenacionalidadenome2, lV115Wptituloclienteds_21_clientenacionalidadenome2, lV116Wptituloclienteds_22_clienteprofissaonome2, lV116Wptituloclienteds_22_clienteprofissaonome2, lV117Wptituloclienteds_23_secusername2, lV117Wptituloclienteds_23_secusername2, lV118Wptituloclienteds_24_municipionome2, lV118Wptituloclienteds_24_municipionome2, AV119Wptituloclienteds_25_bancocodigo2, AV119Wptituloclienteds_25_bancocodigo2, AV119Wptituloclienteds_25_bancocodigo2, lV120Wptituloclienteds_26_responsavelnacionalidadenome2, lV120Wptituloclienteds_26_responsavelnacionalidadenome2, lV121Wptituloclienteds_27_responsavelprofissaonome2, lV121Wptituloclienteds_27_responsavelprofissaonome2, lV122Wptituloclienteds_28_responsavelmunicipionome2, lV122Wptituloclienteds_28_responsavelmunicipionome2, lV126Wptituloclienteds_32_clientedocumento3, lV126Wptituloclienteds_32_clientedocumento3, lV127Wptituloclienteds_33_tipoclientedescricao3, lV127Wptituloclienteds_33_tipoclientedescricao3, lV128Wptituloclienteds_34_clienteconveniodescricao3, lV128Wptituloclienteds_34_clienteconveniodescricao3, lV129Wptituloclienteds_35_clientenacionalidadenome3, lV129Wptituloclienteds_35_clientenacionalidadenome3, lV130Wptituloclienteds_36_clienteprofissaonome3, lV130Wptituloclienteds_36_clienteprofissaonome3, lV131Wptituloclienteds_37_secusername3, lV131Wptituloclienteds_37_secusername3, lV132Wptituloclienteds_38_municipionome3, lV132Wptituloclienteds_38_municipionome3, AV133Wptituloclienteds_39_bancocodigo3, AV133Wptituloclienteds_39_bancocodigo3, AV133Wptituloclienteds_39_bancocodigo3, lV134Wptituloclienteds_40_responsavelnacionalidadenome3, lV134Wptituloclienteds_40_responsavelnacionalidadenome3, lV135Wptituloclienteds_41_responsavelprofissaonome3, lV135Wptituloclienteds_41_responsavelprofissaonome3, lV136Wptituloclienteds_42_responsavelmunicipionome3, lV136Wptituloclienteds_42_responsavelmunicipionome3, lV137Wptituloclienteds_43_tfclienterazaosocial, AV138Wptituloclienteds_44_tfclienterazaosocial_sel, lV139Wptituloclienteds_45_tfclientenomefantasia, AV140Wptituloclienteds_46_tfclientenomefantasia_sel, lV142Wptituloclienteds_48_tfclientedocumento, AV143Wptituloclienteds_49_tfclientedocumento_sel, lV144Wptituloclienteds_50_tftipoclientedescricao, AV145Wptituloclienteds_51_tftipoclientedescricao_sel, AV149Wptituloclienteds_55_tfclientevalorapagar_f, AV150Wptituloclienteds_56_tfclientevalorapagar_f_to, AV151Wptituloclienteds_57_tfclientevalorareceber_f, AV152Wptituloclienteds_58_tfclientevalorareceber_f_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK8A4 = false;
            A192TipoClienteId = P008A15_A192TipoClienteId[0];
            n192TipoClienteId = P008A15_n192TipoClienteId[0];
            A186MunicipioCodigo = P008A15_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P008A15_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P008A15_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P008A15_n444ResponsavelMunicipio[0];
            A402BancoId = P008A15_A402BancoId[0];
            n402BancoId = P008A15_n402BancoId[0];
            A457EspecialidadeId = P008A15_A457EspecialidadeId[0];
            n457EspecialidadeId = P008A15_n457EspecialidadeId[0];
            A597EspecialidadeCreatedBy = P008A15_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = P008A15_n597EspecialidadeCreatedBy[0];
            A437ResponsavelNacionalidade = P008A15_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P008A15_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P008A15_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P008A15_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P008A15_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P008A15_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P008A15_A487ClienteProfissao[0];
            n487ClienteProfissao = P008A15_n487ClienteProfissao[0];
            A489ClienteConvenio = P008A15_A489ClienteConvenio[0];
            n489ClienteConvenio = P008A15_n489ClienteConvenio[0];
            A168ClienteId = P008A15_A168ClienteId[0];
            n168ClienteId = P008A15_n168ClienteId[0];
            A171ClienteNomeFantasia = P008A15_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = P008A15_n171ClienteNomeFantasia[0];
            A445ResponsavelMunicipioNome = P008A15_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P008A15_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P008A15_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P008A15_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P008A15_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P008A15_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P008A15_A404BancoCodigo[0];
            n404BancoCodigo = P008A15_n404BancoCodigo[0];
            A187MunicipioNome = P008A15_A187MunicipioNome[0];
            n187MunicipioNome = P008A15_n187MunicipioNome[0];
            A141SecUserName = P008A15_A141SecUserName[0];
            n141SecUserName = P008A15_n141SecUserName[0];
            A488ClienteProfissaoNome = P008A15_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P008A15_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P008A15_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P008A15_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P008A15_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P008A15_n490ClienteConvenioDescricao[0];
            A174ClienteStatus = P008A15_A174ClienteStatus[0];
            n174ClienteStatus = P008A15_n174ClienteStatus[0];
            A193TipoClienteDescricao = P008A15_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P008A15_n193TipoClienteDescricao[0];
            A169ClienteDocumento = P008A15_A169ClienteDocumento[0];
            n169ClienteDocumento = P008A15_n169ClienteDocumento[0];
            A172ClienteTipoPessoa = P008A15_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = P008A15_n172ClienteTipoPessoa[0];
            A170ClienteRazaoSocial = P008A15_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P008A15_n170ClienteRazaoSocial[0];
            A311ClienteValorAReceber_F = P008A15_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = P008A15_n311ClienteValorAReceber_F[0];
            A310ClienteValorAPagar_F = P008A15_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = P008A15_n310ClienteValorAPagar_F[0];
            A309ClienteQtdTitulos_F = P008A15_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = P008A15_n309ClienteQtdTitulos_F[0];
            A193TipoClienteDescricao = P008A15_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P008A15_n193TipoClienteDescricao[0];
            A187MunicipioNome = P008A15_A187MunicipioNome[0];
            n187MunicipioNome = P008A15_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P008A15_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P008A15_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P008A15_A404BancoCodigo[0];
            n404BancoCodigo = P008A15_n404BancoCodigo[0];
            A597EspecialidadeCreatedBy = P008A15_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = P008A15_n597EspecialidadeCreatedBy[0];
            A141SecUserName = P008A15_A141SecUserName[0];
            n141SecUserName = P008A15_n141SecUserName[0];
            A438ResponsavelNacionalidadeNome = P008A15_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P008A15_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P008A15_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P008A15_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P008A15_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P008A15_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P008A15_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P008A15_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P008A15_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P008A15_n490ClienteConvenioDescricao[0];
            A311ClienteValorAReceber_F = P008A15_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = P008A15_n311ClienteValorAReceber_F[0];
            A310ClienteValorAPagar_F = P008A15_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = P008A15_n310ClienteValorAPagar_F[0];
            A309ClienteQtdTitulos_F = P008A15_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = P008A15_n309ClienteQtdTitulos_F[0];
            AV33count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P008A15_A171ClienteNomeFantasia[0], A171ClienteNomeFantasia) == 0 ) )
            {
               BRK8A4 = false;
               A168ClienteId = P008A15_A168ClienteId[0];
               n168ClienteId = P008A15_n168ClienteId[0];
               AV33count = (long)(AV33count+1);
               BRK8A4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A171ClienteNomeFantasia)) ? "<#Empty#>" : A171ClienteNomeFantasia);
               AV30OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A171ClienteNomeFantasia, "@!")));
               AV29Options.Add(AV28Option, 0);
               AV31OptionsDesc.Add(AV30OptionDesc, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK8A4 )
            {
               BRK8A4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCLIENTEDOCUMENTOOPTIONS' Routine */
         returnInSub = false;
         AV16TFClienteDocumento = AV23SearchTxt;
         AV17TFClienteDocumento_Sel = "";
         AV95Wptituloclienteds_1_filterfulltext = AV45FilterFullText;
         AV96Wptituloclienteds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV97Wptituloclienteds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV98Wptituloclienteds_4_clientedocumento1 = AV48ClienteDocumento1;
         AV99Wptituloclienteds_5_tipoclientedescricao1 = AV49TipoClienteDescricao1;
         AV100Wptituloclienteds_6_clienteconveniodescricao1 = AV72ClienteConvenioDescricao1;
         AV101Wptituloclienteds_7_clientenacionalidadenome1 = AV73ClienteNacionalidadeNome1;
         AV102Wptituloclienteds_8_clienteprofissaonome1 = AV74ClienteProfissaoNome1;
         AV103Wptituloclienteds_9_secusername1 = AV50SecUserName1;
         AV104Wptituloclienteds_10_municipionome1 = AV51MunicipioNome1;
         AV105Wptituloclienteds_11_bancocodigo1 = AV75BancoCodigo1;
         AV106Wptituloclienteds_12_responsavelnacionalidadenome1 = AV76ResponsavelNacionalidadeNome1;
         AV107Wptituloclienteds_13_responsavelprofissaonome1 = AV77ResponsavelProfissaoNome1;
         AV108Wptituloclienteds_14_responsavelmunicipionome1 = AV78ResponsavelMunicipioNome1;
         AV109Wptituloclienteds_15_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV110Wptituloclienteds_16_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV111Wptituloclienteds_17_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV112Wptituloclienteds_18_clientedocumento2 = AV55ClienteDocumento2;
         AV113Wptituloclienteds_19_tipoclientedescricao2 = AV56TipoClienteDescricao2;
         AV114Wptituloclienteds_20_clienteconveniodescricao2 = AV79ClienteConvenioDescricao2;
         AV115Wptituloclienteds_21_clientenacionalidadenome2 = AV80ClienteNacionalidadeNome2;
         AV116Wptituloclienteds_22_clienteprofissaonome2 = AV81ClienteProfissaoNome2;
         AV117Wptituloclienteds_23_secusername2 = AV57SecUserName2;
         AV118Wptituloclienteds_24_municipionome2 = AV58MunicipioNome2;
         AV119Wptituloclienteds_25_bancocodigo2 = AV82BancoCodigo2;
         AV120Wptituloclienteds_26_responsavelnacionalidadenome2 = AV83ResponsavelNacionalidadeNome2;
         AV121Wptituloclienteds_27_responsavelprofissaonome2 = AV84ResponsavelProfissaoNome2;
         AV122Wptituloclienteds_28_responsavelmunicipionome2 = AV85ResponsavelMunicipioNome2;
         AV123Wptituloclienteds_29_dynamicfiltersenabled3 = AV59DynamicFiltersEnabled3;
         AV124Wptituloclienteds_30_dynamicfiltersselector3 = AV60DynamicFiltersSelector3;
         AV125Wptituloclienteds_31_dynamicfiltersoperator3 = AV61DynamicFiltersOperator3;
         AV126Wptituloclienteds_32_clientedocumento3 = AV62ClienteDocumento3;
         AV127Wptituloclienteds_33_tipoclientedescricao3 = AV63TipoClienteDescricao3;
         AV128Wptituloclienteds_34_clienteconveniodescricao3 = AV86ClienteConvenioDescricao3;
         AV129Wptituloclienteds_35_clientenacionalidadenome3 = AV87ClienteNacionalidadeNome3;
         AV130Wptituloclienteds_36_clienteprofissaonome3 = AV88ClienteProfissaoNome3;
         AV131Wptituloclienteds_37_secusername3 = AV64SecUserName3;
         AV132Wptituloclienteds_38_municipionome3 = AV65MunicipioNome3;
         AV133Wptituloclienteds_39_bancocodigo3 = AV89BancoCodigo3;
         AV134Wptituloclienteds_40_responsavelnacionalidadenome3 = AV90ResponsavelNacionalidadeNome3;
         AV135Wptituloclienteds_41_responsavelprofissaonome3 = AV91ResponsavelProfissaoNome3;
         AV136Wptituloclienteds_42_responsavelmunicipionome3 = AV92ResponsavelMunicipioNome3;
         AV137Wptituloclienteds_43_tfclienterazaosocial = AV10TFClienteRazaoSocial;
         AV138Wptituloclienteds_44_tfclienterazaosocial_sel = AV11TFClienteRazaoSocial_Sel;
         AV139Wptituloclienteds_45_tfclientenomefantasia = AV12TFClienteNomeFantasia;
         AV140Wptituloclienteds_46_tfclientenomefantasia_sel = AV13TFClienteNomeFantasia_Sel;
         AV141Wptituloclienteds_47_tfclientetipopessoa_sels = AV15TFClienteTipoPessoa_Sels;
         AV142Wptituloclienteds_48_tfclientedocumento = AV16TFClienteDocumento;
         AV143Wptituloclienteds_49_tfclientedocumento_sel = AV17TFClienteDocumento_Sel;
         AV144Wptituloclienteds_50_tftipoclientedescricao = AV18TFTipoClienteDescricao;
         AV145Wptituloclienteds_51_tftipoclientedescricao_sel = AV19TFTipoClienteDescricao_Sel;
         AV146Wptituloclienteds_52_tfclientestatus_sel = AV20TFClienteStatus_Sel;
         AV147Wptituloclienteds_53_tfclienteqtdtitulos_f = AV66TFClienteQtdTitulos_F;
         AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to = AV67TFClienteQtdTitulos_F_To;
         AV149Wptituloclienteds_55_tfclientevalorapagar_f = AV68TFClienteValorAPagar_F;
         AV150Wptituloclienteds_56_tfclientevalorapagar_f_to = AV69TFClienteValorAPagar_F_To;
         AV151Wptituloclienteds_57_tfclientevalorareceber_f = AV70TFClienteValorAReceber_F;
         AV152Wptituloclienteds_58_tfclientevalorareceber_f_to = AV71TFClienteValorAReceber_F_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A172ClienteTipoPessoa ,
                                              AV141Wptituloclienteds_47_tfclientetipopessoa_sels ,
                                              AV96Wptituloclienteds_2_dynamicfiltersselector1 ,
                                              AV97Wptituloclienteds_3_dynamicfiltersoperator1 ,
                                              AV98Wptituloclienteds_4_clientedocumento1 ,
                                              AV99Wptituloclienteds_5_tipoclientedescricao1 ,
                                              AV100Wptituloclienteds_6_clienteconveniodescricao1 ,
                                              AV101Wptituloclienteds_7_clientenacionalidadenome1 ,
                                              AV102Wptituloclienteds_8_clienteprofissaonome1 ,
                                              AV103Wptituloclienteds_9_secusername1 ,
                                              AV104Wptituloclienteds_10_municipionome1 ,
                                              AV105Wptituloclienteds_11_bancocodigo1 ,
                                              AV106Wptituloclienteds_12_responsavelnacionalidadenome1 ,
                                              AV107Wptituloclienteds_13_responsavelprofissaonome1 ,
                                              AV108Wptituloclienteds_14_responsavelmunicipionome1 ,
                                              AV109Wptituloclienteds_15_dynamicfiltersenabled2 ,
                                              AV110Wptituloclienteds_16_dynamicfiltersselector2 ,
                                              AV111Wptituloclienteds_17_dynamicfiltersoperator2 ,
                                              AV112Wptituloclienteds_18_clientedocumento2 ,
                                              AV113Wptituloclienteds_19_tipoclientedescricao2 ,
                                              AV114Wptituloclienteds_20_clienteconveniodescricao2 ,
                                              AV115Wptituloclienteds_21_clientenacionalidadenome2 ,
                                              AV116Wptituloclienteds_22_clienteprofissaonome2 ,
                                              AV117Wptituloclienteds_23_secusername2 ,
                                              AV118Wptituloclienteds_24_municipionome2 ,
                                              AV119Wptituloclienteds_25_bancocodigo2 ,
                                              AV120Wptituloclienteds_26_responsavelnacionalidadenome2 ,
                                              AV121Wptituloclienteds_27_responsavelprofissaonome2 ,
                                              AV122Wptituloclienteds_28_responsavelmunicipionome2 ,
                                              AV123Wptituloclienteds_29_dynamicfiltersenabled3 ,
                                              AV124Wptituloclienteds_30_dynamicfiltersselector3 ,
                                              AV125Wptituloclienteds_31_dynamicfiltersoperator3 ,
                                              AV126Wptituloclienteds_32_clientedocumento3 ,
                                              AV127Wptituloclienteds_33_tipoclientedescricao3 ,
                                              AV128Wptituloclienteds_34_clienteconveniodescricao3 ,
                                              AV129Wptituloclienteds_35_clientenacionalidadenome3 ,
                                              AV130Wptituloclienteds_36_clienteprofissaonome3 ,
                                              AV131Wptituloclienteds_37_secusername3 ,
                                              AV132Wptituloclienteds_38_municipionome3 ,
                                              AV133Wptituloclienteds_39_bancocodigo3 ,
                                              AV134Wptituloclienteds_40_responsavelnacionalidadenome3 ,
                                              AV135Wptituloclienteds_41_responsavelprofissaonome3 ,
                                              AV136Wptituloclienteds_42_responsavelmunicipionome3 ,
                                              AV138Wptituloclienteds_44_tfclienterazaosocial_sel ,
                                              AV137Wptituloclienteds_43_tfclienterazaosocial ,
                                              AV140Wptituloclienteds_46_tfclientenomefantasia_sel ,
                                              AV139Wptituloclienteds_45_tfclientenomefantasia ,
                                              AV141Wptituloclienteds_47_tfclientetipopessoa_sels.Count ,
                                              AV143Wptituloclienteds_49_tfclientedocumento_sel ,
                                              AV142Wptituloclienteds_48_tfclientedocumento ,
                                              AV145Wptituloclienteds_51_tftipoclientedescricao_sel ,
                                              AV144Wptituloclienteds_50_tftipoclientedescricao ,
                                              AV146Wptituloclienteds_52_tfclientestatus_sel ,
                                              AV149Wptituloclienteds_55_tfclientevalorapagar_f ,
                                              AV150Wptituloclienteds_56_tfclientevalorapagar_f_to ,
                                              AV151Wptituloclienteds_57_tfclientevalorareceber_f ,
                                              AV152Wptituloclienteds_58_tfclientevalorareceber_f_to ,
                                              A169ClienteDocumento ,
                                              A193TipoClienteDescricao ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A141SecUserName ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome ,
                                              A170ClienteRazaoSocial ,
                                              A171ClienteNomeFantasia ,
                                              A174ClienteStatus ,
                                              A310ClienteValorAPagar_F ,
                                              A311ClienteValorAReceber_F ,
                                              AV95Wptituloclienteds_1_filterfulltext ,
                                              A309ClienteQtdTitulos_F ,
                                              AV147Wptituloclienteds_53_tfclienteqtdtitulos_f ,
                                              AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV98Wptituloclienteds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1), "%", "");
         lV98Wptituloclienteds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1), "%", "");
         lV99Wptituloclienteds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1), "%", "");
         lV99Wptituloclienteds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1), "%", "");
         lV100Wptituloclienteds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1), "%", "");
         lV100Wptituloclienteds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1), "%", "");
         lV101Wptituloclienteds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1), "%", "");
         lV101Wptituloclienteds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1), "%", "");
         lV102Wptituloclienteds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1), "%", "");
         lV102Wptituloclienteds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1), "%", "");
         lV103Wptituloclienteds_9_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1), "%", "");
         lV103Wptituloclienteds_9_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1), "%", "");
         lV104Wptituloclienteds_10_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1), "%", "");
         lV104Wptituloclienteds_10_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1), "%", "");
         lV106Wptituloclienteds_12_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1), "%", "");
         lV106Wptituloclienteds_12_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1), "%", "");
         lV107Wptituloclienteds_13_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1), "%", "");
         lV107Wptituloclienteds_13_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1), "%", "");
         lV108Wptituloclienteds_14_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1), "%", "");
         lV108Wptituloclienteds_14_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1), "%", "");
         lV112Wptituloclienteds_18_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2), "%", "");
         lV112Wptituloclienteds_18_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2), "%", "");
         lV113Wptituloclienteds_19_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2), "%", "");
         lV113Wptituloclienteds_19_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2), "%", "");
         lV114Wptituloclienteds_20_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2), "%", "");
         lV114Wptituloclienteds_20_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2), "%", "");
         lV115Wptituloclienteds_21_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2), "%", "");
         lV115Wptituloclienteds_21_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2), "%", "");
         lV116Wptituloclienteds_22_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2), "%", "");
         lV116Wptituloclienteds_22_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2), "%", "");
         lV117Wptituloclienteds_23_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2), "%", "");
         lV117Wptituloclienteds_23_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2), "%", "");
         lV118Wptituloclienteds_24_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2), "%", "");
         lV118Wptituloclienteds_24_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2), "%", "");
         lV120Wptituloclienteds_26_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2), "%", "");
         lV120Wptituloclienteds_26_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2), "%", "");
         lV121Wptituloclienteds_27_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2), "%", "");
         lV121Wptituloclienteds_27_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2), "%", "");
         lV122Wptituloclienteds_28_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2), "%", "");
         lV122Wptituloclienteds_28_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2), "%", "");
         lV126Wptituloclienteds_32_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3), "%", "");
         lV126Wptituloclienteds_32_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3), "%", "");
         lV127Wptituloclienteds_33_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3), "%", "");
         lV127Wptituloclienteds_33_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3), "%", "");
         lV128Wptituloclienteds_34_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3), "%", "");
         lV128Wptituloclienteds_34_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3), "%", "");
         lV129Wptituloclienteds_35_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3), "%", "");
         lV129Wptituloclienteds_35_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3), "%", "");
         lV130Wptituloclienteds_36_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3), "%", "");
         lV130Wptituloclienteds_36_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3), "%", "");
         lV131Wptituloclienteds_37_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3), "%", "");
         lV131Wptituloclienteds_37_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3), "%", "");
         lV132Wptituloclienteds_38_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3), "%", "");
         lV132Wptituloclienteds_38_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3), "%", "");
         lV134Wptituloclienteds_40_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3), "%", "");
         lV134Wptituloclienteds_40_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3), "%", "");
         lV135Wptituloclienteds_41_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3), "%", "");
         lV135Wptituloclienteds_41_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3), "%", "");
         lV136Wptituloclienteds_42_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3), "%", "");
         lV136Wptituloclienteds_42_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3), "%", "");
         lV137Wptituloclienteds_43_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV137Wptituloclienteds_43_tfclienterazaosocial), "%", "");
         lV139Wptituloclienteds_45_tfclientenomefantasia = StringUtil.Concat( StringUtil.RTrim( AV139Wptituloclienteds_45_tfclientenomefantasia), "%", "");
         lV142Wptituloclienteds_48_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV142Wptituloclienteds_48_tfclientedocumento), "%", "");
         lV144Wptituloclienteds_50_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV144Wptituloclienteds_50_tftipoclientedescricao), "%", "");
         /* Using cursor P008A22 */
         pr_default.execute(2, new Object[] {AV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, AV147Wptituloclienteds_53_tfclienteqtdtitulos_f, AV147Wptituloclienteds_53_tfclienteqtdtitulos_f, AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to, AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to, lV98Wptituloclienteds_4_clientedocumento1, lV98Wptituloclienteds_4_clientedocumento1, lV99Wptituloclienteds_5_tipoclientedescricao1, lV99Wptituloclienteds_5_tipoclientedescricao1, lV100Wptituloclienteds_6_clienteconveniodescricao1, lV100Wptituloclienteds_6_clienteconveniodescricao1, lV101Wptituloclienteds_7_clientenacionalidadenome1, lV101Wptituloclienteds_7_clientenacionalidadenome1, lV102Wptituloclienteds_8_clienteprofissaonome1, lV102Wptituloclienteds_8_clienteprofissaonome1, lV103Wptituloclienteds_9_secusername1, lV103Wptituloclienteds_9_secusername1, lV104Wptituloclienteds_10_municipionome1, lV104Wptituloclienteds_10_municipionome1, AV105Wptituloclienteds_11_bancocodigo1, AV105Wptituloclienteds_11_bancocodigo1, AV105Wptituloclienteds_11_bancocodigo1, lV106Wptituloclienteds_12_responsavelnacionalidadenome1, lV106Wptituloclienteds_12_responsavelnacionalidadenome1, lV107Wptituloclienteds_13_responsavelprofissaonome1, lV107Wptituloclienteds_13_responsavelprofissaonome1, lV108Wptituloclienteds_14_responsavelmunicipionome1, lV108Wptituloclienteds_14_responsavelmunicipionome1, lV112Wptituloclienteds_18_clientedocumento2, lV112Wptituloclienteds_18_clientedocumento2, lV113Wptituloclienteds_19_tipoclientedescricao2, lV113Wptituloclienteds_19_tipoclientedescricao2, lV114Wptituloclienteds_20_clienteconveniodescricao2, lV114Wptituloclienteds_20_clienteconveniodescricao2, lV115Wptituloclienteds_21_clientenacionalidadenome2, lV115Wptituloclienteds_21_clientenacionalidadenome2, lV116Wptituloclienteds_22_clienteprofissaonome2, lV116Wptituloclienteds_22_clienteprofissaonome2, lV117Wptituloclienteds_23_secusername2, lV117Wptituloclienteds_23_secusername2, lV118Wptituloclienteds_24_municipionome2, lV118Wptituloclienteds_24_municipionome2, AV119Wptituloclienteds_25_bancocodigo2, AV119Wptituloclienteds_25_bancocodigo2, AV119Wptituloclienteds_25_bancocodigo2, lV120Wptituloclienteds_26_responsavelnacionalidadenome2, lV120Wptituloclienteds_26_responsavelnacionalidadenome2, lV121Wptituloclienteds_27_responsavelprofissaonome2, lV121Wptituloclienteds_27_responsavelprofissaonome2, lV122Wptituloclienteds_28_responsavelmunicipionome2, lV122Wptituloclienteds_28_responsavelmunicipionome2, lV126Wptituloclienteds_32_clientedocumento3, lV126Wptituloclienteds_32_clientedocumento3, lV127Wptituloclienteds_33_tipoclientedescricao3, lV127Wptituloclienteds_33_tipoclientedescricao3, lV128Wptituloclienteds_34_clienteconveniodescricao3, lV128Wptituloclienteds_34_clienteconveniodescricao3, lV129Wptituloclienteds_35_clientenacionalidadenome3, lV129Wptituloclienteds_35_clientenacionalidadenome3, lV130Wptituloclienteds_36_clienteprofissaonome3, lV130Wptituloclienteds_36_clienteprofissaonome3, lV131Wptituloclienteds_37_secusername3, lV131Wptituloclienteds_37_secusername3, lV132Wptituloclienteds_38_municipionome3, lV132Wptituloclienteds_38_municipionome3, AV133Wptituloclienteds_39_bancocodigo3, AV133Wptituloclienteds_39_bancocodigo3, AV133Wptituloclienteds_39_bancocodigo3, lV134Wptituloclienteds_40_responsavelnacionalidadenome3, lV134Wptituloclienteds_40_responsavelnacionalidadenome3, lV135Wptituloclienteds_41_responsavelprofissaonome3, lV135Wptituloclienteds_41_responsavelprofissaonome3, lV136Wptituloclienteds_42_responsavelmunicipionome3, lV136Wptituloclienteds_42_responsavelmunicipionome3, lV137Wptituloclienteds_43_tfclienterazaosocial, AV138Wptituloclienteds_44_tfclienterazaosocial_sel, lV139Wptituloclienteds_45_tfclientenomefantasia, AV140Wptituloclienteds_46_tfclientenomefantasia_sel, lV142Wptituloclienteds_48_tfclientedocumento, AV143Wptituloclienteds_49_tfclientedocumento_sel, lV144Wptituloclienteds_50_tftipoclientedescricao, AV145Wptituloclienteds_51_tftipoclientedescricao_sel, AV149Wptituloclienteds_55_tfclientevalorapagar_f, AV150Wptituloclienteds_56_tfclientevalorapagar_f_to, AV151Wptituloclienteds_57_tfclientevalorareceber_f, AV152Wptituloclienteds_58_tfclientevalorareceber_f_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK8A6 = false;
            A192TipoClienteId = P008A22_A192TipoClienteId[0];
            n192TipoClienteId = P008A22_n192TipoClienteId[0];
            A186MunicipioCodigo = P008A22_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P008A22_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P008A22_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P008A22_n444ResponsavelMunicipio[0];
            A402BancoId = P008A22_A402BancoId[0];
            n402BancoId = P008A22_n402BancoId[0];
            A457EspecialidadeId = P008A22_A457EspecialidadeId[0];
            n457EspecialidadeId = P008A22_n457EspecialidadeId[0];
            A597EspecialidadeCreatedBy = P008A22_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = P008A22_n597EspecialidadeCreatedBy[0];
            A437ResponsavelNacionalidade = P008A22_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P008A22_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P008A22_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P008A22_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P008A22_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P008A22_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P008A22_A487ClienteProfissao[0];
            n487ClienteProfissao = P008A22_n487ClienteProfissao[0];
            A489ClienteConvenio = P008A22_A489ClienteConvenio[0];
            n489ClienteConvenio = P008A22_n489ClienteConvenio[0];
            A168ClienteId = P008A22_A168ClienteId[0];
            n168ClienteId = P008A22_n168ClienteId[0];
            A169ClienteDocumento = P008A22_A169ClienteDocumento[0];
            n169ClienteDocumento = P008A22_n169ClienteDocumento[0];
            A445ResponsavelMunicipioNome = P008A22_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P008A22_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P008A22_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P008A22_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P008A22_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P008A22_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P008A22_A404BancoCodigo[0];
            n404BancoCodigo = P008A22_n404BancoCodigo[0];
            A187MunicipioNome = P008A22_A187MunicipioNome[0];
            n187MunicipioNome = P008A22_n187MunicipioNome[0];
            A141SecUserName = P008A22_A141SecUserName[0];
            n141SecUserName = P008A22_n141SecUserName[0];
            A488ClienteProfissaoNome = P008A22_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P008A22_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P008A22_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P008A22_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P008A22_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P008A22_n490ClienteConvenioDescricao[0];
            A174ClienteStatus = P008A22_A174ClienteStatus[0];
            n174ClienteStatus = P008A22_n174ClienteStatus[0];
            A193TipoClienteDescricao = P008A22_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P008A22_n193TipoClienteDescricao[0];
            A172ClienteTipoPessoa = P008A22_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = P008A22_n172ClienteTipoPessoa[0];
            A171ClienteNomeFantasia = P008A22_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = P008A22_n171ClienteNomeFantasia[0];
            A170ClienteRazaoSocial = P008A22_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P008A22_n170ClienteRazaoSocial[0];
            A311ClienteValorAReceber_F = P008A22_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = P008A22_n311ClienteValorAReceber_F[0];
            A310ClienteValorAPagar_F = P008A22_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = P008A22_n310ClienteValorAPagar_F[0];
            A309ClienteQtdTitulos_F = P008A22_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = P008A22_n309ClienteQtdTitulos_F[0];
            A193TipoClienteDescricao = P008A22_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P008A22_n193TipoClienteDescricao[0];
            A187MunicipioNome = P008A22_A187MunicipioNome[0];
            n187MunicipioNome = P008A22_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P008A22_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P008A22_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P008A22_A404BancoCodigo[0];
            n404BancoCodigo = P008A22_n404BancoCodigo[0];
            A597EspecialidadeCreatedBy = P008A22_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = P008A22_n597EspecialidadeCreatedBy[0];
            A141SecUserName = P008A22_A141SecUserName[0];
            n141SecUserName = P008A22_n141SecUserName[0];
            A438ResponsavelNacionalidadeNome = P008A22_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P008A22_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P008A22_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P008A22_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P008A22_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P008A22_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P008A22_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P008A22_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P008A22_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P008A22_n490ClienteConvenioDescricao[0];
            A311ClienteValorAReceber_F = P008A22_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = P008A22_n311ClienteValorAReceber_F[0];
            A310ClienteValorAPagar_F = P008A22_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = P008A22_n310ClienteValorAPagar_F[0];
            A309ClienteQtdTitulos_F = P008A22_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = P008A22_n309ClienteQtdTitulos_F[0];
            AV33count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P008A22_A169ClienteDocumento[0], A169ClienteDocumento) == 0 ) )
            {
               BRK8A6 = false;
               A168ClienteId = P008A22_A168ClienteId[0];
               n168ClienteId = P008A22_n168ClienteId[0];
               AV33count = (long)(AV33count+1);
               BRK8A6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV24SkipItems) )
            {
               AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A169ClienteDocumento)) ? "<#Empty#>" : A169ClienteDocumento);
               AV29Options.Add(AV28Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV29Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV24SkipItems = (short)(AV24SkipItems-1);
            }
            if ( ! BRK8A6 )
            {
               BRK8A6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADTIPOCLIENTEDESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV18TFTipoClienteDescricao = AV23SearchTxt;
         AV19TFTipoClienteDescricao_Sel = "";
         AV95Wptituloclienteds_1_filterfulltext = AV45FilterFullText;
         AV96Wptituloclienteds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV97Wptituloclienteds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV98Wptituloclienteds_4_clientedocumento1 = AV48ClienteDocumento1;
         AV99Wptituloclienteds_5_tipoclientedescricao1 = AV49TipoClienteDescricao1;
         AV100Wptituloclienteds_6_clienteconveniodescricao1 = AV72ClienteConvenioDescricao1;
         AV101Wptituloclienteds_7_clientenacionalidadenome1 = AV73ClienteNacionalidadeNome1;
         AV102Wptituloclienteds_8_clienteprofissaonome1 = AV74ClienteProfissaoNome1;
         AV103Wptituloclienteds_9_secusername1 = AV50SecUserName1;
         AV104Wptituloclienteds_10_municipionome1 = AV51MunicipioNome1;
         AV105Wptituloclienteds_11_bancocodigo1 = AV75BancoCodigo1;
         AV106Wptituloclienteds_12_responsavelnacionalidadenome1 = AV76ResponsavelNacionalidadeNome1;
         AV107Wptituloclienteds_13_responsavelprofissaonome1 = AV77ResponsavelProfissaoNome1;
         AV108Wptituloclienteds_14_responsavelmunicipionome1 = AV78ResponsavelMunicipioNome1;
         AV109Wptituloclienteds_15_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV110Wptituloclienteds_16_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV111Wptituloclienteds_17_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV112Wptituloclienteds_18_clientedocumento2 = AV55ClienteDocumento2;
         AV113Wptituloclienteds_19_tipoclientedescricao2 = AV56TipoClienteDescricao2;
         AV114Wptituloclienteds_20_clienteconveniodescricao2 = AV79ClienteConvenioDescricao2;
         AV115Wptituloclienteds_21_clientenacionalidadenome2 = AV80ClienteNacionalidadeNome2;
         AV116Wptituloclienteds_22_clienteprofissaonome2 = AV81ClienteProfissaoNome2;
         AV117Wptituloclienteds_23_secusername2 = AV57SecUserName2;
         AV118Wptituloclienteds_24_municipionome2 = AV58MunicipioNome2;
         AV119Wptituloclienteds_25_bancocodigo2 = AV82BancoCodigo2;
         AV120Wptituloclienteds_26_responsavelnacionalidadenome2 = AV83ResponsavelNacionalidadeNome2;
         AV121Wptituloclienteds_27_responsavelprofissaonome2 = AV84ResponsavelProfissaoNome2;
         AV122Wptituloclienteds_28_responsavelmunicipionome2 = AV85ResponsavelMunicipioNome2;
         AV123Wptituloclienteds_29_dynamicfiltersenabled3 = AV59DynamicFiltersEnabled3;
         AV124Wptituloclienteds_30_dynamicfiltersselector3 = AV60DynamicFiltersSelector3;
         AV125Wptituloclienteds_31_dynamicfiltersoperator3 = AV61DynamicFiltersOperator3;
         AV126Wptituloclienteds_32_clientedocumento3 = AV62ClienteDocumento3;
         AV127Wptituloclienteds_33_tipoclientedescricao3 = AV63TipoClienteDescricao3;
         AV128Wptituloclienteds_34_clienteconveniodescricao3 = AV86ClienteConvenioDescricao3;
         AV129Wptituloclienteds_35_clientenacionalidadenome3 = AV87ClienteNacionalidadeNome3;
         AV130Wptituloclienteds_36_clienteprofissaonome3 = AV88ClienteProfissaoNome3;
         AV131Wptituloclienteds_37_secusername3 = AV64SecUserName3;
         AV132Wptituloclienteds_38_municipionome3 = AV65MunicipioNome3;
         AV133Wptituloclienteds_39_bancocodigo3 = AV89BancoCodigo3;
         AV134Wptituloclienteds_40_responsavelnacionalidadenome3 = AV90ResponsavelNacionalidadeNome3;
         AV135Wptituloclienteds_41_responsavelprofissaonome3 = AV91ResponsavelProfissaoNome3;
         AV136Wptituloclienteds_42_responsavelmunicipionome3 = AV92ResponsavelMunicipioNome3;
         AV137Wptituloclienteds_43_tfclienterazaosocial = AV10TFClienteRazaoSocial;
         AV138Wptituloclienteds_44_tfclienterazaosocial_sel = AV11TFClienteRazaoSocial_Sel;
         AV139Wptituloclienteds_45_tfclientenomefantasia = AV12TFClienteNomeFantasia;
         AV140Wptituloclienteds_46_tfclientenomefantasia_sel = AV13TFClienteNomeFantasia_Sel;
         AV141Wptituloclienteds_47_tfclientetipopessoa_sels = AV15TFClienteTipoPessoa_Sels;
         AV142Wptituloclienteds_48_tfclientedocumento = AV16TFClienteDocumento;
         AV143Wptituloclienteds_49_tfclientedocumento_sel = AV17TFClienteDocumento_Sel;
         AV144Wptituloclienteds_50_tftipoclientedescricao = AV18TFTipoClienteDescricao;
         AV145Wptituloclienteds_51_tftipoclientedescricao_sel = AV19TFTipoClienteDescricao_Sel;
         AV146Wptituloclienteds_52_tfclientestatus_sel = AV20TFClienteStatus_Sel;
         AV147Wptituloclienteds_53_tfclienteqtdtitulos_f = AV66TFClienteQtdTitulos_F;
         AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to = AV67TFClienteQtdTitulos_F_To;
         AV149Wptituloclienteds_55_tfclientevalorapagar_f = AV68TFClienteValorAPagar_F;
         AV150Wptituloclienteds_56_tfclientevalorapagar_f_to = AV69TFClienteValorAPagar_F_To;
         AV151Wptituloclienteds_57_tfclientevalorareceber_f = AV70TFClienteValorAReceber_F;
         AV152Wptituloclienteds_58_tfclientevalorareceber_f_to = AV71TFClienteValorAReceber_F_To;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A172ClienteTipoPessoa ,
                                              AV141Wptituloclienteds_47_tfclientetipopessoa_sels ,
                                              AV96Wptituloclienteds_2_dynamicfiltersselector1 ,
                                              AV97Wptituloclienteds_3_dynamicfiltersoperator1 ,
                                              AV98Wptituloclienteds_4_clientedocumento1 ,
                                              AV99Wptituloclienteds_5_tipoclientedescricao1 ,
                                              AV100Wptituloclienteds_6_clienteconveniodescricao1 ,
                                              AV101Wptituloclienteds_7_clientenacionalidadenome1 ,
                                              AV102Wptituloclienteds_8_clienteprofissaonome1 ,
                                              AV103Wptituloclienteds_9_secusername1 ,
                                              AV104Wptituloclienteds_10_municipionome1 ,
                                              AV105Wptituloclienteds_11_bancocodigo1 ,
                                              AV106Wptituloclienteds_12_responsavelnacionalidadenome1 ,
                                              AV107Wptituloclienteds_13_responsavelprofissaonome1 ,
                                              AV108Wptituloclienteds_14_responsavelmunicipionome1 ,
                                              AV109Wptituloclienteds_15_dynamicfiltersenabled2 ,
                                              AV110Wptituloclienteds_16_dynamicfiltersselector2 ,
                                              AV111Wptituloclienteds_17_dynamicfiltersoperator2 ,
                                              AV112Wptituloclienteds_18_clientedocumento2 ,
                                              AV113Wptituloclienteds_19_tipoclientedescricao2 ,
                                              AV114Wptituloclienteds_20_clienteconveniodescricao2 ,
                                              AV115Wptituloclienteds_21_clientenacionalidadenome2 ,
                                              AV116Wptituloclienteds_22_clienteprofissaonome2 ,
                                              AV117Wptituloclienteds_23_secusername2 ,
                                              AV118Wptituloclienteds_24_municipionome2 ,
                                              AV119Wptituloclienteds_25_bancocodigo2 ,
                                              AV120Wptituloclienteds_26_responsavelnacionalidadenome2 ,
                                              AV121Wptituloclienteds_27_responsavelprofissaonome2 ,
                                              AV122Wptituloclienteds_28_responsavelmunicipionome2 ,
                                              AV123Wptituloclienteds_29_dynamicfiltersenabled3 ,
                                              AV124Wptituloclienteds_30_dynamicfiltersselector3 ,
                                              AV125Wptituloclienteds_31_dynamicfiltersoperator3 ,
                                              AV126Wptituloclienteds_32_clientedocumento3 ,
                                              AV127Wptituloclienteds_33_tipoclientedescricao3 ,
                                              AV128Wptituloclienteds_34_clienteconveniodescricao3 ,
                                              AV129Wptituloclienteds_35_clientenacionalidadenome3 ,
                                              AV130Wptituloclienteds_36_clienteprofissaonome3 ,
                                              AV131Wptituloclienteds_37_secusername3 ,
                                              AV132Wptituloclienteds_38_municipionome3 ,
                                              AV133Wptituloclienteds_39_bancocodigo3 ,
                                              AV134Wptituloclienteds_40_responsavelnacionalidadenome3 ,
                                              AV135Wptituloclienteds_41_responsavelprofissaonome3 ,
                                              AV136Wptituloclienteds_42_responsavelmunicipionome3 ,
                                              AV138Wptituloclienteds_44_tfclienterazaosocial_sel ,
                                              AV137Wptituloclienteds_43_tfclienterazaosocial ,
                                              AV140Wptituloclienteds_46_tfclientenomefantasia_sel ,
                                              AV139Wptituloclienteds_45_tfclientenomefantasia ,
                                              AV141Wptituloclienteds_47_tfclientetipopessoa_sels.Count ,
                                              AV143Wptituloclienteds_49_tfclientedocumento_sel ,
                                              AV142Wptituloclienteds_48_tfclientedocumento ,
                                              AV145Wptituloclienteds_51_tftipoclientedescricao_sel ,
                                              AV144Wptituloclienteds_50_tftipoclientedescricao ,
                                              AV146Wptituloclienteds_52_tfclientestatus_sel ,
                                              AV149Wptituloclienteds_55_tfclientevalorapagar_f ,
                                              AV150Wptituloclienteds_56_tfclientevalorapagar_f_to ,
                                              AV151Wptituloclienteds_57_tfclientevalorareceber_f ,
                                              AV152Wptituloclienteds_58_tfclientevalorareceber_f_to ,
                                              A169ClienteDocumento ,
                                              A193TipoClienteDescricao ,
                                              A490ClienteConvenioDescricao ,
                                              A485ClienteNacionalidadeNome ,
                                              A488ClienteProfissaoNome ,
                                              A141SecUserName ,
                                              A187MunicipioNome ,
                                              A404BancoCodigo ,
                                              A438ResponsavelNacionalidadeNome ,
                                              A443ResponsavelProfissaoNome ,
                                              A445ResponsavelMunicipioNome ,
                                              A170ClienteRazaoSocial ,
                                              A171ClienteNomeFantasia ,
                                              A174ClienteStatus ,
                                              A310ClienteValorAPagar_F ,
                                              A311ClienteValorAReceber_F ,
                                              AV95Wptituloclienteds_1_filterfulltext ,
                                              A309ClienteQtdTitulos_F ,
                                              AV147Wptituloclienteds_53_tfclienteqtdtitulos_f ,
                                              AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV95Wptituloclienteds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV95Wptituloclienteds_1_filterfulltext), "%", "");
         lV98Wptituloclienteds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1), "%", "");
         lV98Wptituloclienteds_4_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1), "%", "");
         lV99Wptituloclienteds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1), "%", "");
         lV99Wptituloclienteds_5_tipoclientedescricao1 = StringUtil.Concat( StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1), "%", "");
         lV100Wptituloclienteds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1), "%", "");
         lV100Wptituloclienteds_6_clienteconveniodescricao1 = StringUtil.Concat( StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1), "%", "");
         lV101Wptituloclienteds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1), "%", "");
         lV101Wptituloclienteds_7_clientenacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1), "%", "");
         lV102Wptituloclienteds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1), "%", "");
         lV102Wptituloclienteds_8_clienteprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1), "%", "");
         lV103Wptituloclienteds_9_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1), "%", "");
         lV103Wptituloclienteds_9_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1), "%", "");
         lV104Wptituloclienteds_10_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1), "%", "");
         lV104Wptituloclienteds_10_municipionome1 = StringUtil.Concat( StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1), "%", "");
         lV106Wptituloclienteds_12_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1), "%", "");
         lV106Wptituloclienteds_12_responsavelnacionalidadenome1 = StringUtil.Concat( StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1), "%", "");
         lV107Wptituloclienteds_13_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1), "%", "");
         lV107Wptituloclienteds_13_responsavelprofissaonome1 = StringUtil.Concat( StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1), "%", "");
         lV108Wptituloclienteds_14_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1), "%", "");
         lV108Wptituloclienteds_14_responsavelmunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1), "%", "");
         lV112Wptituloclienteds_18_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2), "%", "");
         lV112Wptituloclienteds_18_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2), "%", "");
         lV113Wptituloclienteds_19_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2), "%", "");
         lV113Wptituloclienteds_19_tipoclientedescricao2 = StringUtil.Concat( StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2), "%", "");
         lV114Wptituloclienteds_20_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2), "%", "");
         lV114Wptituloclienteds_20_clienteconveniodescricao2 = StringUtil.Concat( StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2), "%", "");
         lV115Wptituloclienteds_21_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2), "%", "");
         lV115Wptituloclienteds_21_clientenacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2), "%", "");
         lV116Wptituloclienteds_22_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2), "%", "");
         lV116Wptituloclienteds_22_clienteprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2), "%", "");
         lV117Wptituloclienteds_23_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2), "%", "");
         lV117Wptituloclienteds_23_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2), "%", "");
         lV118Wptituloclienteds_24_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2), "%", "");
         lV118Wptituloclienteds_24_municipionome2 = StringUtil.Concat( StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2), "%", "");
         lV120Wptituloclienteds_26_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2), "%", "");
         lV120Wptituloclienteds_26_responsavelnacionalidadenome2 = StringUtil.Concat( StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2), "%", "");
         lV121Wptituloclienteds_27_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2), "%", "");
         lV121Wptituloclienteds_27_responsavelprofissaonome2 = StringUtil.Concat( StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2), "%", "");
         lV122Wptituloclienteds_28_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2), "%", "");
         lV122Wptituloclienteds_28_responsavelmunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2), "%", "");
         lV126Wptituloclienteds_32_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3), "%", "");
         lV126Wptituloclienteds_32_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3), "%", "");
         lV127Wptituloclienteds_33_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3), "%", "");
         lV127Wptituloclienteds_33_tipoclientedescricao3 = StringUtil.Concat( StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3), "%", "");
         lV128Wptituloclienteds_34_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3), "%", "");
         lV128Wptituloclienteds_34_clienteconveniodescricao3 = StringUtil.Concat( StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3), "%", "");
         lV129Wptituloclienteds_35_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3), "%", "");
         lV129Wptituloclienteds_35_clientenacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3), "%", "");
         lV130Wptituloclienteds_36_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3), "%", "");
         lV130Wptituloclienteds_36_clienteprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3), "%", "");
         lV131Wptituloclienteds_37_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3), "%", "");
         lV131Wptituloclienteds_37_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3), "%", "");
         lV132Wptituloclienteds_38_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3), "%", "");
         lV132Wptituloclienteds_38_municipionome3 = StringUtil.Concat( StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3), "%", "");
         lV134Wptituloclienteds_40_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3), "%", "");
         lV134Wptituloclienteds_40_responsavelnacionalidadenome3 = StringUtil.Concat( StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3), "%", "");
         lV135Wptituloclienteds_41_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3), "%", "");
         lV135Wptituloclienteds_41_responsavelprofissaonome3 = StringUtil.Concat( StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3), "%", "");
         lV136Wptituloclienteds_42_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3), "%", "");
         lV136Wptituloclienteds_42_responsavelmunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3), "%", "");
         lV137Wptituloclienteds_43_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV137Wptituloclienteds_43_tfclienterazaosocial), "%", "");
         lV139Wptituloclienteds_45_tfclientenomefantasia = StringUtil.Concat( StringUtil.RTrim( AV139Wptituloclienteds_45_tfclientenomefantasia), "%", "");
         lV142Wptituloclienteds_48_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV142Wptituloclienteds_48_tfclientedocumento), "%", "");
         lV144Wptituloclienteds_50_tftipoclientedescricao = StringUtil.Concat( StringUtil.RTrim( AV144Wptituloclienteds_50_tftipoclientedescricao), "%", "");
         /* Using cursor P008A29 */
         pr_default.execute(3, new Object[] {AV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, lV95Wptituloclienteds_1_filterfulltext, AV147Wptituloclienteds_53_tfclienteqtdtitulos_f, AV147Wptituloclienteds_53_tfclienteqtdtitulos_f, AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to, AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to, lV98Wptituloclienteds_4_clientedocumento1, lV98Wptituloclienteds_4_clientedocumento1, lV99Wptituloclienteds_5_tipoclientedescricao1, lV99Wptituloclienteds_5_tipoclientedescricao1, lV100Wptituloclienteds_6_clienteconveniodescricao1, lV100Wptituloclienteds_6_clienteconveniodescricao1, lV101Wptituloclienteds_7_clientenacionalidadenome1, lV101Wptituloclienteds_7_clientenacionalidadenome1, lV102Wptituloclienteds_8_clienteprofissaonome1, lV102Wptituloclienteds_8_clienteprofissaonome1, lV103Wptituloclienteds_9_secusername1, lV103Wptituloclienteds_9_secusername1, lV104Wptituloclienteds_10_municipionome1, lV104Wptituloclienteds_10_municipionome1, AV105Wptituloclienteds_11_bancocodigo1, AV105Wptituloclienteds_11_bancocodigo1, AV105Wptituloclienteds_11_bancocodigo1, lV106Wptituloclienteds_12_responsavelnacionalidadenome1, lV106Wptituloclienteds_12_responsavelnacionalidadenome1, lV107Wptituloclienteds_13_responsavelprofissaonome1, lV107Wptituloclienteds_13_responsavelprofissaonome1, lV108Wptituloclienteds_14_responsavelmunicipionome1, lV108Wptituloclienteds_14_responsavelmunicipionome1, lV112Wptituloclienteds_18_clientedocumento2, lV112Wptituloclienteds_18_clientedocumento2, lV113Wptituloclienteds_19_tipoclientedescricao2, lV113Wptituloclienteds_19_tipoclientedescricao2, lV114Wptituloclienteds_20_clienteconveniodescricao2, lV114Wptituloclienteds_20_clienteconveniodescricao2, lV115Wptituloclienteds_21_clientenacionalidadenome2, lV115Wptituloclienteds_21_clientenacionalidadenome2, lV116Wptituloclienteds_22_clienteprofissaonome2, lV116Wptituloclienteds_22_clienteprofissaonome2, lV117Wptituloclienteds_23_secusername2, lV117Wptituloclienteds_23_secusername2, lV118Wptituloclienteds_24_municipionome2, lV118Wptituloclienteds_24_municipionome2, AV119Wptituloclienteds_25_bancocodigo2, AV119Wptituloclienteds_25_bancocodigo2, AV119Wptituloclienteds_25_bancocodigo2, lV120Wptituloclienteds_26_responsavelnacionalidadenome2, lV120Wptituloclienteds_26_responsavelnacionalidadenome2, lV121Wptituloclienteds_27_responsavelprofissaonome2, lV121Wptituloclienteds_27_responsavelprofissaonome2, lV122Wptituloclienteds_28_responsavelmunicipionome2, lV122Wptituloclienteds_28_responsavelmunicipionome2, lV126Wptituloclienteds_32_clientedocumento3, lV126Wptituloclienteds_32_clientedocumento3, lV127Wptituloclienteds_33_tipoclientedescricao3, lV127Wptituloclienteds_33_tipoclientedescricao3, lV128Wptituloclienteds_34_clienteconveniodescricao3, lV128Wptituloclienteds_34_clienteconveniodescricao3, lV129Wptituloclienteds_35_clientenacionalidadenome3, lV129Wptituloclienteds_35_clientenacionalidadenome3, lV130Wptituloclienteds_36_clienteprofissaonome3, lV130Wptituloclienteds_36_clienteprofissaonome3, lV131Wptituloclienteds_37_secusername3, lV131Wptituloclienteds_37_secusername3, lV132Wptituloclienteds_38_municipionome3, lV132Wptituloclienteds_38_municipionome3, AV133Wptituloclienteds_39_bancocodigo3, AV133Wptituloclienteds_39_bancocodigo3, AV133Wptituloclienteds_39_bancocodigo3, lV134Wptituloclienteds_40_responsavelnacionalidadenome3, lV134Wptituloclienteds_40_responsavelnacionalidadenome3, lV135Wptituloclienteds_41_responsavelprofissaonome3, lV135Wptituloclienteds_41_responsavelprofissaonome3, lV136Wptituloclienteds_42_responsavelmunicipionome3, lV136Wptituloclienteds_42_responsavelmunicipionome3, lV137Wptituloclienteds_43_tfclienterazaosocial, AV138Wptituloclienteds_44_tfclienterazaosocial_sel, lV139Wptituloclienteds_45_tfclientenomefantasia, AV140Wptituloclienteds_46_tfclientenomefantasia_sel, lV142Wptituloclienteds_48_tfclientedocumento, AV143Wptituloclienteds_49_tfclientedocumento_sel, lV144Wptituloclienteds_50_tftipoclientedescricao, AV145Wptituloclienteds_51_tftipoclientedescricao_sel, AV149Wptituloclienteds_55_tfclientevalorapagar_f, AV150Wptituloclienteds_56_tfclientevalorapagar_f_to, AV151Wptituloclienteds_57_tfclientevalorareceber_f, AV152Wptituloclienteds_58_tfclientevalorareceber_f_to});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK8A8 = false;
            A186MunicipioCodigo = P008A29_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P008A29_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P008A29_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P008A29_n444ResponsavelMunicipio[0];
            A402BancoId = P008A29_A402BancoId[0];
            n402BancoId = P008A29_n402BancoId[0];
            A457EspecialidadeId = P008A29_A457EspecialidadeId[0];
            n457EspecialidadeId = P008A29_n457EspecialidadeId[0];
            A597EspecialidadeCreatedBy = P008A29_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = P008A29_n597EspecialidadeCreatedBy[0];
            A437ResponsavelNacionalidade = P008A29_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P008A29_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P008A29_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P008A29_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P008A29_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P008A29_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P008A29_A487ClienteProfissao[0];
            n487ClienteProfissao = P008A29_n487ClienteProfissao[0];
            A489ClienteConvenio = P008A29_A489ClienteConvenio[0];
            n489ClienteConvenio = P008A29_n489ClienteConvenio[0];
            A168ClienteId = P008A29_A168ClienteId[0];
            n168ClienteId = P008A29_n168ClienteId[0];
            A192TipoClienteId = P008A29_A192TipoClienteId[0];
            n192TipoClienteId = P008A29_n192TipoClienteId[0];
            A445ResponsavelMunicipioNome = P008A29_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P008A29_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P008A29_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P008A29_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P008A29_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P008A29_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P008A29_A404BancoCodigo[0];
            n404BancoCodigo = P008A29_n404BancoCodigo[0];
            A187MunicipioNome = P008A29_A187MunicipioNome[0];
            n187MunicipioNome = P008A29_n187MunicipioNome[0];
            A141SecUserName = P008A29_A141SecUserName[0];
            n141SecUserName = P008A29_n141SecUserName[0];
            A488ClienteProfissaoNome = P008A29_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P008A29_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P008A29_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P008A29_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P008A29_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P008A29_n490ClienteConvenioDescricao[0];
            A174ClienteStatus = P008A29_A174ClienteStatus[0];
            n174ClienteStatus = P008A29_n174ClienteStatus[0];
            A193TipoClienteDescricao = P008A29_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P008A29_n193TipoClienteDescricao[0];
            A169ClienteDocumento = P008A29_A169ClienteDocumento[0];
            n169ClienteDocumento = P008A29_n169ClienteDocumento[0];
            A172ClienteTipoPessoa = P008A29_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = P008A29_n172ClienteTipoPessoa[0];
            A171ClienteNomeFantasia = P008A29_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = P008A29_n171ClienteNomeFantasia[0];
            A170ClienteRazaoSocial = P008A29_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P008A29_n170ClienteRazaoSocial[0];
            A311ClienteValorAReceber_F = P008A29_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = P008A29_n311ClienteValorAReceber_F[0];
            A310ClienteValorAPagar_F = P008A29_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = P008A29_n310ClienteValorAPagar_F[0];
            A309ClienteQtdTitulos_F = P008A29_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = P008A29_n309ClienteQtdTitulos_F[0];
            A187MunicipioNome = P008A29_A187MunicipioNome[0];
            n187MunicipioNome = P008A29_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P008A29_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P008A29_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P008A29_A404BancoCodigo[0];
            n404BancoCodigo = P008A29_n404BancoCodigo[0];
            A597EspecialidadeCreatedBy = P008A29_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = P008A29_n597EspecialidadeCreatedBy[0];
            A141SecUserName = P008A29_A141SecUserName[0];
            n141SecUserName = P008A29_n141SecUserName[0];
            A438ResponsavelNacionalidadeNome = P008A29_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P008A29_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P008A29_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P008A29_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P008A29_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P008A29_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P008A29_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P008A29_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P008A29_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P008A29_n490ClienteConvenioDescricao[0];
            A311ClienteValorAReceber_F = P008A29_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = P008A29_n311ClienteValorAReceber_F[0];
            A310ClienteValorAPagar_F = P008A29_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = P008A29_n310ClienteValorAPagar_F[0];
            A309ClienteQtdTitulos_F = P008A29_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = P008A29_n309ClienteQtdTitulos_F[0];
            A193TipoClienteDescricao = P008A29_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P008A29_n193TipoClienteDescricao[0];
            AV33count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( P008A29_A192TipoClienteId[0] == A192TipoClienteId ) )
            {
               BRK8A8 = false;
               A168ClienteId = P008A29_A168ClienteId[0];
               n168ClienteId = P008A29_n168ClienteId[0];
               AV33count = (long)(AV33count+1);
               BRK8A8 = true;
               pr_default.readNext(3);
            }
            AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A193TipoClienteDescricao)) ? "<#Empty#>" : A193TipoClienteDescricao);
            AV30OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A193TipoClienteDescricao, "@!")));
            AV27InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV28Option, "<#Empty#>") != 0 ) && ( AV27InsertIndex <= AV29Options.Count ) && ( ( StringUtil.StrCmp(((string)AV31OptionsDesc.Item(AV27InsertIndex)), AV30OptionDesc) < 0 ) || ( StringUtil.StrCmp(((string)AV29Options.Item(AV27InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV27InsertIndex = (int)(AV27InsertIndex+1);
            }
            AV29Options.Add(AV28Option, AV27InsertIndex);
            AV31OptionsDesc.Add(AV30OptionDesc, AV27InsertIndex);
            AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), AV27InsertIndex);
            if ( AV29Options.Count == AV24SkipItems + 11 )
            {
               AV29Options.RemoveItem(AV29Options.Count);
               AV31OptionsDesc.RemoveItem(AV31OptionsDesc.Count);
               AV32OptionIndexes.RemoveItem(AV32OptionIndexes.Count);
            }
            if ( ! BRK8A8 )
            {
               BRK8A8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
         while ( AV24SkipItems > 0 )
         {
            AV29Options.RemoveItem(1);
            AV31OptionsDesc.RemoveItem(1);
            AV32OptionIndexes.RemoveItem(1);
            AV24SkipItems = (short)(AV24SkipItems-1);
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
         AV42OptionsJson = "";
         AV43OptionsDescJson = "";
         AV44OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV31OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV23SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Session = context.GetSession();
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45FilterFullText = "";
         AV10TFClienteRazaoSocial = "";
         AV11TFClienteRazaoSocial_Sel = "";
         AV12TFClienteNomeFantasia = "";
         AV13TFClienteNomeFantasia_Sel = "";
         AV14TFClienteTipoPessoa_SelsJson = "";
         AV15TFClienteTipoPessoa_Sels = new GxSimpleCollection<string>();
         AV16TFClienteDocumento = "";
         AV17TFClienteDocumento_Sel = "";
         AV18TFTipoClienteDescricao = "";
         AV19TFTipoClienteDescricao_Sel = "";
         AV38GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV46DynamicFiltersSelector1 = "";
         AV48ClienteDocumento1 = "";
         AV49TipoClienteDescricao1 = "";
         AV72ClienteConvenioDescricao1 = "";
         AV73ClienteNacionalidadeNome1 = "";
         AV74ClienteProfissaoNome1 = "";
         AV50SecUserName1 = "";
         AV51MunicipioNome1 = "";
         AV76ResponsavelNacionalidadeNome1 = "";
         AV77ResponsavelProfissaoNome1 = "";
         AV78ResponsavelMunicipioNome1 = "";
         AV53DynamicFiltersSelector2 = "";
         AV55ClienteDocumento2 = "";
         AV56TipoClienteDescricao2 = "";
         AV79ClienteConvenioDescricao2 = "";
         AV80ClienteNacionalidadeNome2 = "";
         AV81ClienteProfissaoNome2 = "";
         AV57SecUserName2 = "";
         AV58MunicipioNome2 = "";
         AV83ResponsavelNacionalidadeNome2 = "";
         AV84ResponsavelProfissaoNome2 = "";
         AV85ResponsavelMunicipioNome2 = "";
         AV60DynamicFiltersSelector3 = "";
         AV62ClienteDocumento3 = "";
         AV63TipoClienteDescricao3 = "";
         AV86ClienteConvenioDescricao3 = "";
         AV87ClienteNacionalidadeNome3 = "";
         AV88ClienteProfissaoNome3 = "";
         AV64SecUserName3 = "";
         AV65MunicipioNome3 = "";
         AV90ResponsavelNacionalidadeNome3 = "";
         AV91ResponsavelProfissaoNome3 = "";
         AV92ResponsavelMunicipioNome3 = "";
         AV95Wptituloclienteds_1_filterfulltext = "";
         AV96Wptituloclienteds_2_dynamicfiltersselector1 = "";
         AV98Wptituloclienteds_4_clientedocumento1 = "";
         AV99Wptituloclienteds_5_tipoclientedescricao1 = "";
         AV100Wptituloclienteds_6_clienteconveniodescricao1 = "";
         AV101Wptituloclienteds_7_clientenacionalidadenome1 = "";
         AV102Wptituloclienteds_8_clienteprofissaonome1 = "";
         AV103Wptituloclienteds_9_secusername1 = "";
         AV104Wptituloclienteds_10_municipionome1 = "";
         AV106Wptituloclienteds_12_responsavelnacionalidadenome1 = "";
         AV107Wptituloclienteds_13_responsavelprofissaonome1 = "";
         AV108Wptituloclienteds_14_responsavelmunicipionome1 = "";
         AV110Wptituloclienteds_16_dynamicfiltersselector2 = "";
         AV112Wptituloclienteds_18_clientedocumento2 = "";
         AV113Wptituloclienteds_19_tipoclientedescricao2 = "";
         AV114Wptituloclienteds_20_clienteconveniodescricao2 = "";
         AV115Wptituloclienteds_21_clientenacionalidadenome2 = "";
         AV116Wptituloclienteds_22_clienteprofissaonome2 = "";
         AV117Wptituloclienteds_23_secusername2 = "";
         AV118Wptituloclienteds_24_municipionome2 = "";
         AV120Wptituloclienteds_26_responsavelnacionalidadenome2 = "";
         AV121Wptituloclienteds_27_responsavelprofissaonome2 = "";
         AV122Wptituloclienteds_28_responsavelmunicipionome2 = "";
         AV124Wptituloclienteds_30_dynamicfiltersselector3 = "";
         AV126Wptituloclienteds_32_clientedocumento3 = "";
         AV127Wptituloclienteds_33_tipoclientedescricao3 = "";
         AV128Wptituloclienteds_34_clienteconveniodescricao3 = "";
         AV129Wptituloclienteds_35_clientenacionalidadenome3 = "";
         AV130Wptituloclienteds_36_clienteprofissaonome3 = "";
         AV131Wptituloclienteds_37_secusername3 = "";
         AV132Wptituloclienteds_38_municipionome3 = "";
         AV134Wptituloclienteds_40_responsavelnacionalidadenome3 = "";
         AV135Wptituloclienteds_41_responsavelprofissaonome3 = "";
         AV136Wptituloclienteds_42_responsavelmunicipionome3 = "";
         AV137Wptituloclienteds_43_tfclienterazaosocial = "";
         AV138Wptituloclienteds_44_tfclienterazaosocial_sel = "";
         AV139Wptituloclienteds_45_tfclientenomefantasia = "";
         AV140Wptituloclienteds_46_tfclientenomefantasia_sel = "";
         AV141Wptituloclienteds_47_tfclientetipopessoa_sels = new GxSimpleCollection<string>();
         AV142Wptituloclienteds_48_tfclientedocumento = "";
         AV143Wptituloclienteds_49_tfclientedocumento_sel = "";
         AV144Wptituloclienteds_50_tftipoclientedescricao = "";
         AV145Wptituloclienteds_51_tftipoclientedescricao_sel = "";
         lV95Wptituloclienteds_1_filterfulltext = "";
         lV98Wptituloclienteds_4_clientedocumento1 = "";
         lV99Wptituloclienteds_5_tipoclientedescricao1 = "";
         lV100Wptituloclienteds_6_clienteconveniodescricao1 = "";
         lV101Wptituloclienteds_7_clientenacionalidadenome1 = "";
         lV102Wptituloclienteds_8_clienteprofissaonome1 = "";
         lV103Wptituloclienteds_9_secusername1 = "";
         lV104Wptituloclienteds_10_municipionome1 = "";
         lV106Wptituloclienteds_12_responsavelnacionalidadenome1 = "";
         lV107Wptituloclienteds_13_responsavelprofissaonome1 = "";
         lV108Wptituloclienteds_14_responsavelmunicipionome1 = "";
         lV112Wptituloclienteds_18_clientedocumento2 = "";
         lV113Wptituloclienteds_19_tipoclientedescricao2 = "";
         lV114Wptituloclienteds_20_clienteconveniodescricao2 = "";
         lV115Wptituloclienteds_21_clientenacionalidadenome2 = "";
         lV116Wptituloclienteds_22_clienteprofissaonome2 = "";
         lV117Wptituloclienteds_23_secusername2 = "";
         lV118Wptituloclienteds_24_municipionome2 = "";
         lV120Wptituloclienteds_26_responsavelnacionalidadenome2 = "";
         lV121Wptituloclienteds_27_responsavelprofissaonome2 = "";
         lV122Wptituloclienteds_28_responsavelmunicipionome2 = "";
         lV126Wptituloclienteds_32_clientedocumento3 = "";
         lV127Wptituloclienteds_33_tipoclientedescricao3 = "";
         lV128Wptituloclienteds_34_clienteconveniodescricao3 = "";
         lV129Wptituloclienteds_35_clientenacionalidadenome3 = "";
         lV130Wptituloclienteds_36_clienteprofissaonome3 = "";
         lV131Wptituloclienteds_37_secusername3 = "";
         lV132Wptituloclienteds_38_municipionome3 = "";
         lV134Wptituloclienteds_40_responsavelnacionalidadenome3 = "";
         lV135Wptituloclienteds_41_responsavelprofissaonome3 = "";
         lV136Wptituloclienteds_42_responsavelmunicipionome3 = "";
         lV137Wptituloclienteds_43_tfclienterazaosocial = "";
         lV139Wptituloclienteds_45_tfclientenomefantasia = "";
         lV142Wptituloclienteds_48_tfclientedocumento = "";
         lV144Wptituloclienteds_50_tftipoclientedescricao = "";
         A172ClienteTipoPessoa = "";
         A169ClienteDocumento = "";
         A193TipoClienteDescricao = "";
         A490ClienteConvenioDescricao = "";
         A485ClienteNacionalidadeNome = "";
         A488ClienteProfissaoNome = "";
         A141SecUserName = "";
         A187MunicipioNome = "";
         A438ResponsavelNacionalidadeNome = "";
         A443ResponsavelProfissaoNome = "";
         A445ResponsavelMunicipioNome = "";
         A170ClienteRazaoSocial = "";
         A171ClienteNomeFantasia = "";
         P008A8_A192TipoClienteId = new short[1] ;
         P008A8_n192TipoClienteId = new bool[] {false} ;
         P008A8_A186MunicipioCodigo = new string[] {""} ;
         P008A8_n186MunicipioCodigo = new bool[] {false} ;
         P008A8_A444ResponsavelMunicipio = new string[] {""} ;
         P008A8_n444ResponsavelMunicipio = new bool[] {false} ;
         P008A8_A402BancoId = new int[1] ;
         P008A8_n402BancoId = new bool[] {false} ;
         P008A8_A457EspecialidadeId = new int[1] ;
         P008A8_n457EspecialidadeId = new bool[] {false} ;
         P008A8_A597EspecialidadeCreatedBy = new short[1] ;
         P008A8_n597EspecialidadeCreatedBy = new bool[] {false} ;
         P008A8_A437ResponsavelNacionalidade = new int[1] ;
         P008A8_n437ResponsavelNacionalidade = new bool[] {false} ;
         P008A8_A484ClienteNacionalidade = new int[1] ;
         P008A8_n484ClienteNacionalidade = new bool[] {false} ;
         P008A8_A442ResponsavelProfissao = new int[1] ;
         P008A8_n442ResponsavelProfissao = new bool[] {false} ;
         P008A8_A487ClienteProfissao = new int[1] ;
         P008A8_n487ClienteProfissao = new bool[] {false} ;
         P008A8_A489ClienteConvenio = new int[1] ;
         P008A8_n489ClienteConvenio = new bool[] {false} ;
         P008A8_A168ClienteId = new int[1] ;
         P008A8_n168ClienteId = new bool[] {false} ;
         P008A8_A170ClienteRazaoSocial = new string[] {""} ;
         P008A8_n170ClienteRazaoSocial = new bool[] {false} ;
         P008A8_A445ResponsavelMunicipioNome = new string[] {""} ;
         P008A8_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P008A8_A443ResponsavelProfissaoNome = new string[] {""} ;
         P008A8_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P008A8_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P008A8_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P008A8_A404BancoCodigo = new int[1] ;
         P008A8_n404BancoCodigo = new bool[] {false} ;
         P008A8_A187MunicipioNome = new string[] {""} ;
         P008A8_n187MunicipioNome = new bool[] {false} ;
         P008A8_A141SecUserName = new string[] {""} ;
         P008A8_n141SecUserName = new bool[] {false} ;
         P008A8_A488ClienteProfissaoNome = new string[] {""} ;
         P008A8_n488ClienteProfissaoNome = new bool[] {false} ;
         P008A8_A485ClienteNacionalidadeNome = new string[] {""} ;
         P008A8_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P008A8_A490ClienteConvenioDescricao = new string[] {""} ;
         P008A8_n490ClienteConvenioDescricao = new bool[] {false} ;
         P008A8_A174ClienteStatus = new bool[] {false} ;
         P008A8_n174ClienteStatus = new bool[] {false} ;
         P008A8_A193TipoClienteDescricao = new string[] {""} ;
         P008A8_n193TipoClienteDescricao = new bool[] {false} ;
         P008A8_A169ClienteDocumento = new string[] {""} ;
         P008A8_n169ClienteDocumento = new bool[] {false} ;
         P008A8_A172ClienteTipoPessoa = new string[] {""} ;
         P008A8_n172ClienteTipoPessoa = new bool[] {false} ;
         P008A8_A171ClienteNomeFantasia = new string[] {""} ;
         P008A8_n171ClienteNomeFantasia = new bool[] {false} ;
         P008A8_A311ClienteValorAReceber_F = new decimal[1] ;
         P008A8_n311ClienteValorAReceber_F = new bool[] {false} ;
         P008A8_A310ClienteValorAPagar_F = new decimal[1] ;
         P008A8_n310ClienteValorAPagar_F = new bool[] {false} ;
         P008A8_A309ClienteQtdTitulos_F = new int[1] ;
         P008A8_n309ClienteQtdTitulos_F = new bool[] {false} ;
         A186MunicipioCodigo = "";
         A444ResponsavelMunicipio = "";
         AV28Option = "";
         AV30OptionDesc = "";
         P008A15_A192TipoClienteId = new short[1] ;
         P008A15_n192TipoClienteId = new bool[] {false} ;
         P008A15_A186MunicipioCodigo = new string[] {""} ;
         P008A15_n186MunicipioCodigo = new bool[] {false} ;
         P008A15_A444ResponsavelMunicipio = new string[] {""} ;
         P008A15_n444ResponsavelMunicipio = new bool[] {false} ;
         P008A15_A402BancoId = new int[1] ;
         P008A15_n402BancoId = new bool[] {false} ;
         P008A15_A457EspecialidadeId = new int[1] ;
         P008A15_n457EspecialidadeId = new bool[] {false} ;
         P008A15_A597EspecialidadeCreatedBy = new short[1] ;
         P008A15_n597EspecialidadeCreatedBy = new bool[] {false} ;
         P008A15_A437ResponsavelNacionalidade = new int[1] ;
         P008A15_n437ResponsavelNacionalidade = new bool[] {false} ;
         P008A15_A484ClienteNacionalidade = new int[1] ;
         P008A15_n484ClienteNacionalidade = new bool[] {false} ;
         P008A15_A442ResponsavelProfissao = new int[1] ;
         P008A15_n442ResponsavelProfissao = new bool[] {false} ;
         P008A15_A487ClienteProfissao = new int[1] ;
         P008A15_n487ClienteProfissao = new bool[] {false} ;
         P008A15_A489ClienteConvenio = new int[1] ;
         P008A15_n489ClienteConvenio = new bool[] {false} ;
         P008A15_A168ClienteId = new int[1] ;
         P008A15_n168ClienteId = new bool[] {false} ;
         P008A15_A171ClienteNomeFantasia = new string[] {""} ;
         P008A15_n171ClienteNomeFantasia = new bool[] {false} ;
         P008A15_A445ResponsavelMunicipioNome = new string[] {""} ;
         P008A15_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P008A15_A443ResponsavelProfissaoNome = new string[] {""} ;
         P008A15_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P008A15_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P008A15_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P008A15_A404BancoCodigo = new int[1] ;
         P008A15_n404BancoCodigo = new bool[] {false} ;
         P008A15_A187MunicipioNome = new string[] {""} ;
         P008A15_n187MunicipioNome = new bool[] {false} ;
         P008A15_A141SecUserName = new string[] {""} ;
         P008A15_n141SecUserName = new bool[] {false} ;
         P008A15_A488ClienteProfissaoNome = new string[] {""} ;
         P008A15_n488ClienteProfissaoNome = new bool[] {false} ;
         P008A15_A485ClienteNacionalidadeNome = new string[] {""} ;
         P008A15_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P008A15_A490ClienteConvenioDescricao = new string[] {""} ;
         P008A15_n490ClienteConvenioDescricao = new bool[] {false} ;
         P008A15_A174ClienteStatus = new bool[] {false} ;
         P008A15_n174ClienteStatus = new bool[] {false} ;
         P008A15_A193TipoClienteDescricao = new string[] {""} ;
         P008A15_n193TipoClienteDescricao = new bool[] {false} ;
         P008A15_A169ClienteDocumento = new string[] {""} ;
         P008A15_n169ClienteDocumento = new bool[] {false} ;
         P008A15_A172ClienteTipoPessoa = new string[] {""} ;
         P008A15_n172ClienteTipoPessoa = new bool[] {false} ;
         P008A15_A170ClienteRazaoSocial = new string[] {""} ;
         P008A15_n170ClienteRazaoSocial = new bool[] {false} ;
         P008A15_A311ClienteValorAReceber_F = new decimal[1] ;
         P008A15_n311ClienteValorAReceber_F = new bool[] {false} ;
         P008A15_A310ClienteValorAPagar_F = new decimal[1] ;
         P008A15_n310ClienteValorAPagar_F = new bool[] {false} ;
         P008A15_A309ClienteQtdTitulos_F = new int[1] ;
         P008A15_n309ClienteQtdTitulos_F = new bool[] {false} ;
         P008A22_A192TipoClienteId = new short[1] ;
         P008A22_n192TipoClienteId = new bool[] {false} ;
         P008A22_A186MunicipioCodigo = new string[] {""} ;
         P008A22_n186MunicipioCodigo = new bool[] {false} ;
         P008A22_A444ResponsavelMunicipio = new string[] {""} ;
         P008A22_n444ResponsavelMunicipio = new bool[] {false} ;
         P008A22_A402BancoId = new int[1] ;
         P008A22_n402BancoId = new bool[] {false} ;
         P008A22_A457EspecialidadeId = new int[1] ;
         P008A22_n457EspecialidadeId = new bool[] {false} ;
         P008A22_A597EspecialidadeCreatedBy = new short[1] ;
         P008A22_n597EspecialidadeCreatedBy = new bool[] {false} ;
         P008A22_A437ResponsavelNacionalidade = new int[1] ;
         P008A22_n437ResponsavelNacionalidade = new bool[] {false} ;
         P008A22_A484ClienteNacionalidade = new int[1] ;
         P008A22_n484ClienteNacionalidade = new bool[] {false} ;
         P008A22_A442ResponsavelProfissao = new int[1] ;
         P008A22_n442ResponsavelProfissao = new bool[] {false} ;
         P008A22_A487ClienteProfissao = new int[1] ;
         P008A22_n487ClienteProfissao = new bool[] {false} ;
         P008A22_A489ClienteConvenio = new int[1] ;
         P008A22_n489ClienteConvenio = new bool[] {false} ;
         P008A22_A168ClienteId = new int[1] ;
         P008A22_n168ClienteId = new bool[] {false} ;
         P008A22_A169ClienteDocumento = new string[] {""} ;
         P008A22_n169ClienteDocumento = new bool[] {false} ;
         P008A22_A445ResponsavelMunicipioNome = new string[] {""} ;
         P008A22_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P008A22_A443ResponsavelProfissaoNome = new string[] {""} ;
         P008A22_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P008A22_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P008A22_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P008A22_A404BancoCodigo = new int[1] ;
         P008A22_n404BancoCodigo = new bool[] {false} ;
         P008A22_A187MunicipioNome = new string[] {""} ;
         P008A22_n187MunicipioNome = new bool[] {false} ;
         P008A22_A141SecUserName = new string[] {""} ;
         P008A22_n141SecUserName = new bool[] {false} ;
         P008A22_A488ClienteProfissaoNome = new string[] {""} ;
         P008A22_n488ClienteProfissaoNome = new bool[] {false} ;
         P008A22_A485ClienteNacionalidadeNome = new string[] {""} ;
         P008A22_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P008A22_A490ClienteConvenioDescricao = new string[] {""} ;
         P008A22_n490ClienteConvenioDescricao = new bool[] {false} ;
         P008A22_A174ClienteStatus = new bool[] {false} ;
         P008A22_n174ClienteStatus = new bool[] {false} ;
         P008A22_A193TipoClienteDescricao = new string[] {""} ;
         P008A22_n193TipoClienteDescricao = new bool[] {false} ;
         P008A22_A172ClienteTipoPessoa = new string[] {""} ;
         P008A22_n172ClienteTipoPessoa = new bool[] {false} ;
         P008A22_A171ClienteNomeFantasia = new string[] {""} ;
         P008A22_n171ClienteNomeFantasia = new bool[] {false} ;
         P008A22_A170ClienteRazaoSocial = new string[] {""} ;
         P008A22_n170ClienteRazaoSocial = new bool[] {false} ;
         P008A22_A311ClienteValorAReceber_F = new decimal[1] ;
         P008A22_n311ClienteValorAReceber_F = new bool[] {false} ;
         P008A22_A310ClienteValorAPagar_F = new decimal[1] ;
         P008A22_n310ClienteValorAPagar_F = new bool[] {false} ;
         P008A22_A309ClienteQtdTitulos_F = new int[1] ;
         P008A22_n309ClienteQtdTitulos_F = new bool[] {false} ;
         P008A29_A186MunicipioCodigo = new string[] {""} ;
         P008A29_n186MunicipioCodigo = new bool[] {false} ;
         P008A29_A444ResponsavelMunicipio = new string[] {""} ;
         P008A29_n444ResponsavelMunicipio = new bool[] {false} ;
         P008A29_A402BancoId = new int[1] ;
         P008A29_n402BancoId = new bool[] {false} ;
         P008A29_A457EspecialidadeId = new int[1] ;
         P008A29_n457EspecialidadeId = new bool[] {false} ;
         P008A29_A597EspecialidadeCreatedBy = new short[1] ;
         P008A29_n597EspecialidadeCreatedBy = new bool[] {false} ;
         P008A29_A437ResponsavelNacionalidade = new int[1] ;
         P008A29_n437ResponsavelNacionalidade = new bool[] {false} ;
         P008A29_A484ClienteNacionalidade = new int[1] ;
         P008A29_n484ClienteNacionalidade = new bool[] {false} ;
         P008A29_A442ResponsavelProfissao = new int[1] ;
         P008A29_n442ResponsavelProfissao = new bool[] {false} ;
         P008A29_A487ClienteProfissao = new int[1] ;
         P008A29_n487ClienteProfissao = new bool[] {false} ;
         P008A29_A489ClienteConvenio = new int[1] ;
         P008A29_n489ClienteConvenio = new bool[] {false} ;
         P008A29_A168ClienteId = new int[1] ;
         P008A29_n168ClienteId = new bool[] {false} ;
         P008A29_A192TipoClienteId = new short[1] ;
         P008A29_n192TipoClienteId = new bool[] {false} ;
         P008A29_A445ResponsavelMunicipioNome = new string[] {""} ;
         P008A29_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P008A29_A443ResponsavelProfissaoNome = new string[] {""} ;
         P008A29_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P008A29_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P008A29_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P008A29_A404BancoCodigo = new int[1] ;
         P008A29_n404BancoCodigo = new bool[] {false} ;
         P008A29_A187MunicipioNome = new string[] {""} ;
         P008A29_n187MunicipioNome = new bool[] {false} ;
         P008A29_A141SecUserName = new string[] {""} ;
         P008A29_n141SecUserName = new bool[] {false} ;
         P008A29_A488ClienteProfissaoNome = new string[] {""} ;
         P008A29_n488ClienteProfissaoNome = new bool[] {false} ;
         P008A29_A485ClienteNacionalidadeNome = new string[] {""} ;
         P008A29_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P008A29_A490ClienteConvenioDescricao = new string[] {""} ;
         P008A29_n490ClienteConvenioDescricao = new bool[] {false} ;
         P008A29_A174ClienteStatus = new bool[] {false} ;
         P008A29_n174ClienteStatus = new bool[] {false} ;
         P008A29_A193TipoClienteDescricao = new string[] {""} ;
         P008A29_n193TipoClienteDescricao = new bool[] {false} ;
         P008A29_A169ClienteDocumento = new string[] {""} ;
         P008A29_n169ClienteDocumento = new bool[] {false} ;
         P008A29_A172ClienteTipoPessoa = new string[] {""} ;
         P008A29_n172ClienteTipoPessoa = new bool[] {false} ;
         P008A29_A171ClienteNomeFantasia = new string[] {""} ;
         P008A29_n171ClienteNomeFantasia = new bool[] {false} ;
         P008A29_A170ClienteRazaoSocial = new string[] {""} ;
         P008A29_n170ClienteRazaoSocial = new bool[] {false} ;
         P008A29_A311ClienteValorAReceber_F = new decimal[1] ;
         P008A29_n311ClienteValorAReceber_F = new bool[] {false} ;
         P008A29_A310ClienteValorAPagar_F = new decimal[1] ;
         P008A29_n310ClienteValorAPagar_F = new bool[] {false} ;
         P008A29_A309ClienteQtdTitulos_F = new int[1] ;
         P008A29_n309ClienteQtdTitulos_F = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wptituloclientegetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P008A8_A192TipoClienteId, P008A8_n192TipoClienteId, P008A8_A186MunicipioCodigo, P008A8_n186MunicipioCodigo, P008A8_A444ResponsavelMunicipio, P008A8_n444ResponsavelMunicipio, P008A8_A402BancoId, P008A8_n402BancoId, P008A8_A457EspecialidadeId, P008A8_n457EspecialidadeId,
               P008A8_A597EspecialidadeCreatedBy, P008A8_n597EspecialidadeCreatedBy, P008A8_A437ResponsavelNacionalidade, P008A8_n437ResponsavelNacionalidade, P008A8_A484ClienteNacionalidade, P008A8_n484ClienteNacionalidade, P008A8_A442ResponsavelProfissao, P008A8_n442ResponsavelProfissao, P008A8_A487ClienteProfissao, P008A8_n487ClienteProfissao,
               P008A8_A489ClienteConvenio, P008A8_n489ClienteConvenio, P008A8_A168ClienteId, P008A8_A170ClienteRazaoSocial, P008A8_n170ClienteRazaoSocial, P008A8_A445ResponsavelMunicipioNome, P008A8_n445ResponsavelMunicipioNome, P008A8_A443ResponsavelProfissaoNome, P008A8_n443ResponsavelProfissaoNome, P008A8_A438ResponsavelNacionalidadeNome,
               P008A8_n438ResponsavelNacionalidadeNome, P008A8_A404BancoCodigo, P008A8_n404BancoCodigo, P008A8_A187MunicipioNome, P008A8_n187MunicipioNome, P008A8_A141SecUserName, P008A8_n141SecUserName, P008A8_A488ClienteProfissaoNome, P008A8_n488ClienteProfissaoNome, P008A8_A485ClienteNacionalidadeNome,
               P008A8_n485ClienteNacionalidadeNome, P008A8_A490ClienteConvenioDescricao, P008A8_n490ClienteConvenioDescricao, P008A8_A174ClienteStatus, P008A8_n174ClienteStatus, P008A8_A193TipoClienteDescricao, P008A8_n193TipoClienteDescricao, P008A8_A169ClienteDocumento, P008A8_n169ClienteDocumento, P008A8_A172ClienteTipoPessoa,
               P008A8_n172ClienteTipoPessoa, P008A8_A171ClienteNomeFantasia, P008A8_n171ClienteNomeFantasia, P008A8_A311ClienteValorAReceber_F, P008A8_n311ClienteValorAReceber_F, P008A8_A310ClienteValorAPagar_F, P008A8_n310ClienteValorAPagar_F, P008A8_A309ClienteQtdTitulos_F, P008A8_n309ClienteQtdTitulos_F
               }
               , new Object[] {
               P008A15_A192TipoClienteId, P008A15_n192TipoClienteId, P008A15_A186MunicipioCodigo, P008A15_n186MunicipioCodigo, P008A15_A444ResponsavelMunicipio, P008A15_n444ResponsavelMunicipio, P008A15_A402BancoId, P008A15_n402BancoId, P008A15_A457EspecialidadeId, P008A15_n457EspecialidadeId,
               P008A15_A597EspecialidadeCreatedBy, P008A15_n597EspecialidadeCreatedBy, P008A15_A437ResponsavelNacionalidade, P008A15_n437ResponsavelNacionalidade, P008A15_A484ClienteNacionalidade, P008A15_n484ClienteNacionalidade, P008A15_A442ResponsavelProfissao, P008A15_n442ResponsavelProfissao, P008A15_A487ClienteProfissao, P008A15_n487ClienteProfissao,
               P008A15_A489ClienteConvenio, P008A15_n489ClienteConvenio, P008A15_A168ClienteId, P008A15_A171ClienteNomeFantasia, P008A15_n171ClienteNomeFantasia, P008A15_A445ResponsavelMunicipioNome, P008A15_n445ResponsavelMunicipioNome, P008A15_A443ResponsavelProfissaoNome, P008A15_n443ResponsavelProfissaoNome, P008A15_A438ResponsavelNacionalidadeNome,
               P008A15_n438ResponsavelNacionalidadeNome, P008A15_A404BancoCodigo, P008A15_n404BancoCodigo, P008A15_A187MunicipioNome, P008A15_n187MunicipioNome, P008A15_A141SecUserName, P008A15_n141SecUserName, P008A15_A488ClienteProfissaoNome, P008A15_n488ClienteProfissaoNome, P008A15_A485ClienteNacionalidadeNome,
               P008A15_n485ClienteNacionalidadeNome, P008A15_A490ClienteConvenioDescricao, P008A15_n490ClienteConvenioDescricao, P008A15_A174ClienteStatus, P008A15_n174ClienteStatus, P008A15_A193TipoClienteDescricao, P008A15_n193TipoClienteDescricao, P008A15_A169ClienteDocumento, P008A15_n169ClienteDocumento, P008A15_A172ClienteTipoPessoa,
               P008A15_n172ClienteTipoPessoa, P008A15_A170ClienteRazaoSocial, P008A15_n170ClienteRazaoSocial, P008A15_A311ClienteValorAReceber_F, P008A15_n311ClienteValorAReceber_F, P008A15_A310ClienteValorAPagar_F, P008A15_n310ClienteValorAPagar_F, P008A15_A309ClienteQtdTitulos_F, P008A15_n309ClienteQtdTitulos_F
               }
               , new Object[] {
               P008A22_A192TipoClienteId, P008A22_n192TipoClienteId, P008A22_A186MunicipioCodigo, P008A22_n186MunicipioCodigo, P008A22_A444ResponsavelMunicipio, P008A22_n444ResponsavelMunicipio, P008A22_A402BancoId, P008A22_n402BancoId, P008A22_A457EspecialidadeId, P008A22_n457EspecialidadeId,
               P008A22_A597EspecialidadeCreatedBy, P008A22_n597EspecialidadeCreatedBy, P008A22_A437ResponsavelNacionalidade, P008A22_n437ResponsavelNacionalidade, P008A22_A484ClienteNacionalidade, P008A22_n484ClienteNacionalidade, P008A22_A442ResponsavelProfissao, P008A22_n442ResponsavelProfissao, P008A22_A487ClienteProfissao, P008A22_n487ClienteProfissao,
               P008A22_A489ClienteConvenio, P008A22_n489ClienteConvenio, P008A22_A168ClienteId, P008A22_A169ClienteDocumento, P008A22_n169ClienteDocumento, P008A22_A445ResponsavelMunicipioNome, P008A22_n445ResponsavelMunicipioNome, P008A22_A443ResponsavelProfissaoNome, P008A22_n443ResponsavelProfissaoNome, P008A22_A438ResponsavelNacionalidadeNome,
               P008A22_n438ResponsavelNacionalidadeNome, P008A22_A404BancoCodigo, P008A22_n404BancoCodigo, P008A22_A187MunicipioNome, P008A22_n187MunicipioNome, P008A22_A141SecUserName, P008A22_n141SecUserName, P008A22_A488ClienteProfissaoNome, P008A22_n488ClienteProfissaoNome, P008A22_A485ClienteNacionalidadeNome,
               P008A22_n485ClienteNacionalidadeNome, P008A22_A490ClienteConvenioDescricao, P008A22_n490ClienteConvenioDescricao, P008A22_A174ClienteStatus, P008A22_n174ClienteStatus, P008A22_A193TipoClienteDescricao, P008A22_n193TipoClienteDescricao, P008A22_A172ClienteTipoPessoa, P008A22_n172ClienteTipoPessoa, P008A22_A171ClienteNomeFantasia,
               P008A22_n171ClienteNomeFantasia, P008A22_A170ClienteRazaoSocial, P008A22_n170ClienteRazaoSocial, P008A22_A311ClienteValorAReceber_F, P008A22_n311ClienteValorAReceber_F, P008A22_A310ClienteValorAPagar_F, P008A22_n310ClienteValorAPagar_F, P008A22_A309ClienteQtdTitulos_F, P008A22_n309ClienteQtdTitulos_F
               }
               , new Object[] {
               P008A29_A186MunicipioCodigo, P008A29_n186MunicipioCodigo, P008A29_A444ResponsavelMunicipio, P008A29_n444ResponsavelMunicipio, P008A29_A402BancoId, P008A29_n402BancoId, P008A29_A457EspecialidadeId, P008A29_n457EspecialidadeId, P008A29_A597EspecialidadeCreatedBy, P008A29_n597EspecialidadeCreatedBy,
               P008A29_A437ResponsavelNacionalidade, P008A29_n437ResponsavelNacionalidade, P008A29_A484ClienteNacionalidade, P008A29_n484ClienteNacionalidade, P008A29_A442ResponsavelProfissao, P008A29_n442ResponsavelProfissao, P008A29_A487ClienteProfissao, P008A29_n487ClienteProfissao, P008A29_A489ClienteConvenio, P008A29_n489ClienteConvenio,
               P008A29_A168ClienteId, P008A29_A192TipoClienteId, P008A29_n192TipoClienteId, P008A29_A445ResponsavelMunicipioNome, P008A29_n445ResponsavelMunicipioNome, P008A29_A443ResponsavelProfissaoNome, P008A29_n443ResponsavelProfissaoNome, P008A29_A438ResponsavelNacionalidadeNome, P008A29_n438ResponsavelNacionalidadeNome, P008A29_A404BancoCodigo,
               P008A29_n404BancoCodigo, P008A29_A187MunicipioNome, P008A29_n187MunicipioNome, P008A29_A141SecUserName, P008A29_n141SecUserName, P008A29_A488ClienteProfissaoNome, P008A29_n488ClienteProfissaoNome, P008A29_A485ClienteNacionalidadeNome, P008A29_n485ClienteNacionalidadeNome, P008A29_A490ClienteConvenioDescricao,
               P008A29_n490ClienteConvenioDescricao, P008A29_A174ClienteStatus, P008A29_n174ClienteStatus, P008A29_A193TipoClienteDescricao, P008A29_n193TipoClienteDescricao, P008A29_A169ClienteDocumento, P008A29_n169ClienteDocumento, P008A29_A172ClienteTipoPessoa, P008A29_n172ClienteTipoPessoa, P008A29_A171ClienteNomeFantasia,
               P008A29_n171ClienteNomeFantasia, P008A29_A170ClienteRazaoSocial, P008A29_n170ClienteRazaoSocial, P008A29_A311ClienteValorAReceber_F, P008A29_n311ClienteValorAReceber_F, P008A29_A310ClienteValorAPagar_F, P008A29_n310ClienteValorAPagar_F, P008A29_A309ClienteQtdTitulos_F, P008A29_n309ClienteQtdTitulos_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26MaxItems ;
      private short AV25PageIndex ;
      private short AV24SkipItems ;
      private short AV20TFClienteStatus_Sel ;
      private short AV47DynamicFiltersOperator1 ;
      private short AV54DynamicFiltersOperator2 ;
      private short AV61DynamicFiltersOperator3 ;
      private short AV97Wptituloclienteds_3_dynamicfiltersoperator1 ;
      private short AV111Wptituloclienteds_17_dynamicfiltersoperator2 ;
      private short AV125Wptituloclienteds_31_dynamicfiltersoperator3 ;
      private short AV146Wptituloclienteds_52_tfclientestatus_sel ;
      private short A192TipoClienteId ;
      private short A597EspecialidadeCreatedBy ;
      private int AV93GXV1 ;
      private int AV66TFClienteQtdTitulos_F ;
      private int AV67TFClienteQtdTitulos_F_To ;
      private int AV75BancoCodigo1 ;
      private int AV82BancoCodigo2 ;
      private int AV89BancoCodigo3 ;
      private int AV105Wptituloclienteds_11_bancocodigo1 ;
      private int AV119Wptituloclienteds_25_bancocodigo2 ;
      private int AV133Wptituloclienteds_39_bancocodigo3 ;
      private int AV147Wptituloclienteds_53_tfclienteqtdtitulos_f ;
      private int AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to ;
      private int AV141Wptituloclienteds_47_tfclientetipopessoa_sels_Count ;
      private int A404BancoCodigo ;
      private int A309ClienteQtdTitulos_F ;
      private int A402BancoId ;
      private int A457EspecialidadeId ;
      private int A437ResponsavelNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int A442ResponsavelProfissao ;
      private int A487ClienteProfissao ;
      private int A489ClienteConvenio ;
      private int A168ClienteId ;
      private int AV27InsertIndex ;
      private long AV33count ;
      private decimal AV68TFClienteValorAPagar_F ;
      private decimal AV69TFClienteValorAPagar_F_To ;
      private decimal AV70TFClienteValorAReceber_F ;
      private decimal AV71TFClienteValorAReceber_F_To ;
      private decimal AV149Wptituloclienteds_55_tfclientevalorapagar_f ;
      private decimal AV150Wptituloclienteds_56_tfclientevalorapagar_f_to ;
      private decimal AV151Wptituloclienteds_57_tfclientevalorareceber_f ;
      private decimal AV152Wptituloclienteds_58_tfclientevalorareceber_f_to ;
      private decimal A310ClienteValorAPagar_F ;
      private decimal A311ClienteValorAReceber_F ;
      private bool returnInSub ;
      private bool AV52DynamicFiltersEnabled2 ;
      private bool AV59DynamicFiltersEnabled3 ;
      private bool AV109Wptituloclienteds_15_dynamicfiltersenabled2 ;
      private bool AV123Wptituloclienteds_29_dynamicfiltersenabled3 ;
      private bool A174ClienteStatus ;
      private bool BRK8A2 ;
      private bool n192TipoClienteId ;
      private bool n186MunicipioCodigo ;
      private bool n444ResponsavelMunicipio ;
      private bool n402BancoId ;
      private bool n457EspecialidadeId ;
      private bool n597EspecialidadeCreatedBy ;
      private bool n437ResponsavelNacionalidade ;
      private bool n484ClienteNacionalidade ;
      private bool n442ResponsavelProfissao ;
      private bool n487ClienteProfissao ;
      private bool n489ClienteConvenio ;
      private bool n168ClienteId ;
      private bool n170ClienteRazaoSocial ;
      private bool n445ResponsavelMunicipioNome ;
      private bool n443ResponsavelProfissaoNome ;
      private bool n438ResponsavelNacionalidadeNome ;
      private bool n404BancoCodigo ;
      private bool n187MunicipioNome ;
      private bool n141SecUserName ;
      private bool n488ClienteProfissaoNome ;
      private bool n485ClienteNacionalidadeNome ;
      private bool n490ClienteConvenioDescricao ;
      private bool n174ClienteStatus ;
      private bool n193TipoClienteDescricao ;
      private bool n169ClienteDocumento ;
      private bool n172ClienteTipoPessoa ;
      private bool n171ClienteNomeFantasia ;
      private bool n311ClienteValorAReceber_F ;
      private bool n310ClienteValorAPagar_F ;
      private bool n309ClienteQtdTitulos_F ;
      private bool BRK8A4 ;
      private bool BRK8A6 ;
      private bool BRK8A8 ;
      private string AV42OptionsJson ;
      private string AV43OptionsDescJson ;
      private string AV44OptionIndexesJson ;
      private string AV14TFClienteTipoPessoa_SelsJson ;
      private string AV39DDOName ;
      private string AV40SearchTxtParms ;
      private string AV41SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV45FilterFullText ;
      private string AV10TFClienteRazaoSocial ;
      private string AV11TFClienteRazaoSocial_Sel ;
      private string AV12TFClienteNomeFantasia ;
      private string AV13TFClienteNomeFantasia_Sel ;
      private string AV16TFClienteDocumento ;
      private string AV17TFClienteDocumento_Sel ;
      private string AV18TFTipoClienteDescricao ;
      private string AV19TFTipoClienteDescricao_Sel ;
      private string AV46DynamicFiltersSelector1 ;
      private string AV48ClienteDocumento1 ;
      private string AV49TipoClienteDescricao1 ;
      private string AV72ClienteConvenioDescricao1 ;
      private string AV73ClienteNacionalidadeNome1 ;
      private string AV74ClienteProfissaoNome1 ;
      private string AV50SecUserName1 ;
      private string AV51MunicipioNome1 ;
      private string AV76ResponsavelNacionalidadeNome1 ;
      private string AV77ResponsavelProfissaoNome1 ;
      private string AV78ResponsavelMunicipioNome1 ;
      private string AV53DynamicFiltersSelector2 ;
      private string AV55ClienteDocumento2 ;
      private string AV56TipoClienteDescricao2 ;
      private string AV79ClienteConvenioDescricao2 ;
      private string AV80ClienteNacionalidadeNome2 ;
      private string AV81ClienteProfissaoNome2 ;
      private string AV57SecUserName2 ;
      private string AV58MunicipioNome2 ;
      private string AV83ResponsavelNacionalidadeNome2 ;
      private string AV84ResponsavelProfissaoNome2 ;
      private string AV85ResponsavelMunicipioNome2 ;
      private string AV60DynamicFiltersSelector3 ;
      private string AV62ClienteDocumento3 ;
      private string AV63TipoClienteDescricao3 ;
      private string AV86ClienteConvenioDescricao3 ;
      private string AV87ClienteNacionalidadeNome3 ;
      private string AV88ClienteProfissaoNome3 ;
      private string AV64SecUserName3 ;
      private string AV65MunicipioNome3 ;
      private string AV90ResponsavelNacionalidadeNome3 ;
      private string AV91ResponsavelProfissaoNome3 ;
      private string AV92ResponsavelMunicipioNome3 ;
      private string AV95Wptituloclienteds_1_filterfulltext ;
      private string AV96Wptituloclienteds_2_dynamicfiltersselector1 ;
      private string AV98Wptituloclienteds_4_clientedocumento1 ;
      private string AV99Wptituloclienteds_5_tipoclientedescricao1 ;
      private string AV100Wptituloclienteds_6_clienteconveniodescricao1 ;
      private string AV101Wptituloclienteds_7_clientenacionalidadenome1 ;
      private string AV102Wptituloclienteds_8_clienteprofissaonome1 ;
      private string AV103Wptituloclienteds_9_secusername1 ;
      private string AV104Wptituloclienteds_10_municipionome1 ;
      private string AV106Wptituloclienteds_12_responsavelnacionalidadenome1 ;
      private string AV107Wptituloclienteds_13_responsavelprofissaonome1 ;
      private string AV108Wptituloclienteds_14_responsavelmunicipionome1 ;
      private string AV110Wptituloclienteds_16_dynamicfiltersselector2 ;
      private string AV112Wptituloclienteds_18_clientedocumento2 ;
      private string AV113Wptituloclienteds_19_tipoclientedescricao2 ;
      private string AV114Wptituloclienteds_20_clienteconveniodescricao2 ;
      private string AV115Wptituloclienteds_21_clientenacionalidadenome2 ;
      private string AV116Wptituloclienteds_22_clienteprofissaonome2 ;
      private string AV117Wptituloclienteds_23_secusername2 ;
      private string AV118Wptituloclienteds_24_municipionome2 ;
      private string AV120Wptituloclienteds_26_responsavelnacionalidadenome2 ;
      private string AV121Wptituloclienteds_27_responsavelprofissaonome2 ;
      private string AV122Wptituloclienteds_28_responsavelmunicipionome2 ;
      private string AV124Wptituloclienteds_30_dynamicfiltersselector3 ;
      private string AV126Wptituloclienteds_32_clientedocumento3 ;
      private string AV127Wptituloclienteds_33_tipoclientedescricao3 ;
      private string AV128Wptituloclienteds_34_clienteconveniodescricao3 ;
      private string AV129Wptituloclienteds_35_clientenacionalidadenome3 ;
      private string AV130Wptituloclienteds_36_clienteprofissaonome3 ;
      private string AV131Wptituloclienteds_37_secusername3 ;
      private string AV132Wptituloclienteds_38_municipionome3 ;
      private string AV134Wptituloclienteds_40_responsavelnacionalidadenome3 ;
      private string AV135Wptituloclienteds_41_responsavelprofissaonome3 ;
      private string AV136Wptituloclienteds_42_responsavelmunicipionome3 ;
      private string AV137Wptituloclienteds_43_tfclienterazaosocial ;
      private string AV138Wptituloclienteds_44_tfclienterazaosocial_sel ;
      private string AV139Wptituloclienteds_45_tfclientenomefantasia ;
      private string AV140Wptituloclienteds_46_tfclientenomefantasia_sel ;
      private string AV142Wptituloclienteds_48_tfclientedocumento ;
      private string AV143Wptituloclienteds_49_tfclientedocumento_sel ;
      private string AV144Wptituloclienteds_50_tftipoclientedescricao ;
      private string AV145Wptituloclienteds_51_tftipoclientedescricao_sel ;
      private string lV95Wptituloclienteds_1_filterfulltext ;
      private string lV98Wptituloclienteds_4_clientedocumento1 ;
      private string lV99Wptituloclienteds_5_tipoclientedescricao1 ;
      private string lV100Wptituloclienteds_6_clienteconveniodescricao1 ;
      private string lV101Wptituloclienteds_7_clientenacionalidadenome1 ;
      private string lV102Wptituloclienteds_8_clienteprofissaonome1 ;
      private string lV103Wptituloclienteds_9_secusername1 ;
      private string lV104Wptituloclienteds_10_municipionome1 ;
      private string lV106Wptituloclienteds_12_responsavelnacionalidadenome1 ;
      private string lV107Wptituloclienteds_13_responsavelprofissaonome1 ;
      private string lV108Wptituloclienteds_14_responsavelmunicipionome1 ;
      private string lV112Wptituloclienteds_18_clientedocumento2 ;
      private string lV113Wptituloclienteds_19_tipoclientedescricao2 ;
      private string lV114Wptituloclienteds_20_clienteconveniodescricao2 ;
      private string lV115Wptituloclienteds_21_clientenacionalidadenome2 ;
      private string lV116Wptituloclienteds_22_clienteprofissaonome2 ;
      private string lV117Wptituloclienteds_23_secusername2 ;
      private string lV118Wptituloclienteds_24_municipionome2 ;
      private string lV120Wptituloclienteds_26_responsavelnacionalidadenome2 ;
      private string lV121Wptituloclienteds_27_responsavelprofissaonome2 ;
      private string lV122Wptituloclienteds_28_responsavelmunicipionome2 ;
      private string lV126Wptituloclienteds_32_clientedocumento3 ;
      private string lV127Wptituloclienteds_33_tipoclientedescricao3 ;
      private string lV128Wptituloclienteds_34_clienteconveniodescricao3 ;
      private string lV129Wptituloclienteds_35_clientenacionalidadenome3 ;
      private string lV130Wptituloclienteds_36_clienteprofissaonome3 ;
      private string lV131Wptituloclienteds_37_secusername3 ;
      private string lV132Wptituloclienteds_38_municipionome3 ;
      private string lV134Wptituloclienteds_40_responsavelnacionalidadenome3 ;
      private string lV135Wptituloclienteds_41_responsavelprofissaonome3 ;
      private string lV136Wptituloclienteds_42_responsavelmunicipionome3 ;
      private string lV137Wptituloclienteds_43_tfclienterazaosocial ;
      private string lV139Wptituloclienteds_45_tfclientenomefantasia ;
      private string lV142Wptituloclienteds_48_tfclientedocumento ;
      private string lV144Wptituloclienteds_50_tftipoclientedescricao ;
      private string A172ClienteTipoPessoa ;
      private string A169ClienteDocumento ;
      private string A193TipoClienteDescricao ;
      private string A490ClienteConvenioDescricao ;
      private string A485ClienteNacionalidadeNome ;
      private string A488ClienteProfissaoNome ;
      private string A141SecUserName ;
      private string A187MunicipioNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string A443ResponsavelProfissaoNome ;
      private string A445ResponsavelMunicipioNome ;
      private string A170ClienteRazaoSocial ;
      private string A171ClienteNomeFantasia ;
      private string A186MunicipioCodigo ;
      private string A444ResponsavelMunicipio ;
      private string AV28Option ;
      private string AV30OptionDesc ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV31OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private GxSimpleCollection<string> AV15TFClienteTipoPessoa_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV38GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV141Wptituloclienteds_47_tfclientetipopessoa_sels ;
      private IDataStoreProvider pr_default ;
      private short[] P008A8_A192TipoClienteId ;
      private bool[] P008A8_n192TipoClienteId ;
      private string[] P008A8_A186MunicipioCodigo ;
      private bool[] P008A8_n186MunicipioCodigo ;
      private string[] P008A8_A444ResponsavelMunicipio ;
      private bool[] P008A8_n444ResponsavelMunicipio ;
      private int[] P008A8_A402BancoId ;
      private bool[] P008A8_n402BancoId ;
      private int[] P008A8_A457EspecialidadeId ;
      private bool[] P008A8_n457EspecialidadeId ;
      private short[] P008A8_A597EspecialidadeCreatedBy ;
      private bool[] P008A8_n597EspecialidadeCreatedBy ;
      private int[] P008A8_A437ResponsavelNacionalidade ;
      private bool[] P008A8_n437ResponsavelNacionalidade ;
      private int[] P008A8_A484ClienteNacionalidade ;
      private bool[] P008A8_n484ClienteNacionalidade ;
      private int[] P008A8_A442ResponsavelProfissao ;
      private bool[] P008A8_n442ResponsavelProfissao ;
      private int[] P008A8_A487ClienteProfissao ;
      private bool[] P008A8_n487ClienteProfissao ;
      private int[] P008A8_A489ClienteConvenio ;
      private bool[] P008A8_n489ClienteConvenio ;
      private int[] P008A8_A168ClienteId ;
      private bool[] P008A8_n168ClienteId ;
      private string[] P008A8_A170ClienteRazaoSocial ;
      private bool[] P008A8_n170ClienteRazaoSocial ;
      private string[] P008A8_A445ResponsavelMunicipioNome ;
      private bool[] P008A8_n445ResponsavelMunicipioNome ;
      private string[] P008A8_A443ResponsavelProfissaoNome ;
      private bool[] P008A8_n443ResponsavelProfissaoNome ;
      private string[] P008A8_A438ResponsavelNacionalidadeNome ;
      private bool[] P008A8_n438ResponsavelNacionalidadeNome ;
      private int[] P008A8_A404BancoCodigo ;
      private bool[] P008A8_n404BancoCodigo ;
      private string[] P008A8_A187MunicipioNome ;
      private bool[] P008A8_n187MunicipioNome ;
      private string[] P008A8_A141SecUserName ;
      private bool[] P008A8_n141SecUserName ;
      private string[] P008A8_A488ClienteProfissaoNome ;
      private bool[] P008A8_n488ClienteProfissaoNome ;
      private string[] P008A8_A485ClienteNacionalidadeNome ;
      private bool[] P008A8_n485ClienteNacionalidadeNome ;
      private string[] P008A8_A490ClienteConvenioDescricao ;
      private bool[] P008A8_n490ClienteConvenioDescricao ;
      private bool[] P008A8_A174ClienteStatus ;
      private bool[] P008A8_n174ClienteStatus ;
      private string[] P008A8_A193TipoClienteDescricao ;
      private bool[] P008A8_n193TipoClienteDescricao ;
      private string[] P008A8_A169ClienteDocumento ;
      private bool[] P008A8_n169ClienteDocumento ;
      private string[] P008A8_A172ClienteTipoPessoa ;
      private bool[] P008A8_n172ClienteTipoPessoa ;
      private string[] P008A8_A171ClienteNomeFantasia ;
      private bool[] P008A8_n171ClienteNomeFantasia ;
      private decimal[] P008A8_A311ClienteValorAReceber_F ;
      private bool[] P008A8_n311ClienteValorAReceber_F ;
      private decimal[] P008A8_A310ClienteValorAPagar_F ;
      private bool[] P008A8_n310ClienteValorAPagar_F ;
      private int[] P008A8_A309ClienteQtdTitulos_F ;
      private bool[] P008A8_n309ClienteQtdTitulos_F ;
      private short[] P008A15_A192TipoClienteId ;
      private bool[] P008A15_n192TipoClienteId ;
      private string[] P008A15_A186MunicipioCodigo ;
      private bool[] P008A15_n186MunicipioCodigo ;
      private string[] P008A15_A444ResponsavelMunicipio ;
      private bool[] P008A15_n444ResponsavelMunicipio ;
      private int[] P008A15_A402BancoId ;
      private bool[] P008A15_n402BancoId ;
      private int[] P008A15_A457EspecialidadeId ;
      private bool[] P008A15_n457EspecialidadeId ;
      private short[] P008A15_A597EspecialidadeCreatedBy ;
      private bool[] P008A15_n597EspecialidadeCreatedBy ;
      private int[] P008A15_A437ResponsavelNacionalidade ;
      private bool[] P008A15_n437ResponsavelNacionalidade ;
      private int[] P008A15_A484ClienteNacionalidade ;
      private bool[] P008A15_n484ClienteNacionalidade ;
      private int[] P008A15_A442ResponsavelProfissao ;
      private bool[] P008A15_n442ResponsavelProfissao ;
      private int[] P008A15_A487ClienteProfissao ;
      private bool[] P008A15_n487ClienteProfissao ;
      private int[] P008A15_A489ClienteConvenio ;
      private bool[] P008A15_n489ClienteConvenio ;
      private int[] P008A15_A168ClienteId ;
      private bool[] P008A15_n168ClienteId ;
      private string[] P008A15_A171ClienteNomeFantasia ;
      private bool[] P008A15_n171ClienteNomeFantasia ;
      private string[] P008A15_A445ResponsavelMunicipioNome ;
      private bool[] P008A15_n445ResponsavelMunicipioNome ;
      private string[] P008A15_A443ResponsavelProfissaoNome ;
      private bool[] P008A15_n443ResponsavelProfissaoNome ;
      private string[] P008A15_A438ResponsavelNacionalidadeNome ;
      private bool[] P008A15_n438ResponsavelNacionalidadeNome ;
      private int[] P008A15_A404BancoCodigo ;
      private bool[] P008A15_n404BancoCodigo ;
      private string[] P008A15_A187MunicipioNome ;
      private bool[] P008A15_n187MunicipioNome ;
      private string[] P008A15_A141SecUserName ;
      private bool[] P008A15_n141SecUserName ;
      private string[] P008A15_A488ClienteProfissaoNome ;
      private bool[] P008A15_n488ClienteProfissaoNome ;
      private string[] P008A15_A485ClienteNacionalidadeNome ;
      private bool[] P008A15_n485ClienteNacionalidadeNome ;
      private string[] P008A15_A490ClienteConvenioDescricao ;
      private bool[] P008A15_n490ClienteConvenioDescricao ;
      private bool[] P008A15_A174ClienteStatus ;
      private bool[] P008A15_n174ClienteStatus ;
      private string[] P008A15_A193TipoClienteDescricao ;
      private bool[] P008A15_n193TipoClienteDescricao ;
      private string[] P008A15_A169ClienteDocumento ;
      private bool[] P008A15_n169ClienteDocumento ;
      private string[] P008A15_A172ClienteTipoPessoa ;
      private bool[] P008A15_n172ClienteTipoPessoa ;
      private string[] P008A15_A170ClienteRazaoSocial ;
      private bool[] P008A15_n170ClienteRazaoSocial ;
      private decimal[] P008A15_A311ClienteValorAReceber_F ;
      private bool[] P008A15_n311ClienteValorAReceber_F ;
      private decimal[] P008A15_A310ClienteValorAPagar_F ;
      private bool[] P008A15_n310ClienteValorAPagar_F ;
      private int[] P008A15_A309ClienteQtdTitulos_F ;
      private bool[] P008A15_n309ClienteQtdTitulos_F ;
      private short[] P008A22_A192TipoClienteId ;
      private bool[] P008A22_n192TipoClienteId ;
      private string[] P008A22_A186MunicipioCodigo ;
      private bool[] P008A22_n186MunicipioCodigo ;
      private string[] P008A22_A444ResponsavelMunicipio ;
      private bool[] P008A22_n444ResponsavelMunicipio ;
      private int[] P008A22_A402BancoId ;
      private bool[] P008A22_n402BancoId ;
      private int[] P008A22_A457EspecialidadeId ;
      private bool[] P008A22_n457EspecialidadeId ;
      private short[] P008A22_A597EspecialidadeCreatedBy ;
      private bool[] P008A22_n597EspecialidadeCreatedBy ;
      private int[] P008A22_A437ResponsavelNacionalidade ;
      private bool[] P008A22_n437ResponsavelNacionalidade ;
      private int[] P008A22_A484ClienteNacionalidade ;
      private bool[] P008A22_n484ClienteNacionalidade ;
      private int[] P008A22_A442ResponsavelProfissao ;
      private bool[] P008A22_n442ResponsavelProfissao ;
      private int[] P008A22_A487ClienteProfissao ;
      private bool[] P008A22_n487ClienteProfissao ;
      private int[] P008A22_A489ClienteConvenio ;
      private bool[] P008A22_n489ClienteConvenio ;
      private int[] P008A22_A168ClienteId ;
      private bool[] P008A22_n168ClienteId ;
      private string[] P008A22_A169ClienteDocumento ;
      private bool[] P008A22_n169ClienteDocumento ;
      private string[] P008A22_A445ResponsavelMunicipioNome ;
      private bool[] P008A22_n445ResponsavelMunicipioNome ;
      private string[] P008A22_A443ResponsavelProfissaoNome ;
      private bool[] P008A22_n443ResponsavelProfissaoNome ;
      private string[] P008A22_A438ResponsavelNacionalidadeNome ;
      private bool[] P008A22_n438ResponsavelNacionalidadeNome ;
      private int[] P008A22_A404BancoCodigo ;
      private bool[] P008A22_n404BancoCodigo ;
      private string[] P008A22_A187MunicipioNome ;
      private bool[] P008A22_n187MunicipioNome ;
      private string[] P008A22_A141SecUserName ;
      private bool[] P008A22_n141SecUserName ;
      private string[] P008A22_A488ClienteProfissaoNome ;
      private bool[] P008A22_n488ClienteProfissaoNome ;
      private string[] P008A22_A485ClienteNacionalidadeNome ;
      private bool[] P008A22_n485ClienteNacionalidadeNome ;
      private string[] P008A22_A490ClienteConvenioDescricao ;
      private bool[] P008A22_n490ClienteConvenioDescricao ;
      private bool[] P008A22_A174ClienteStatus ;
      private bool[] P008A22_n174ClienteStatus ;
      private string[] P008A22_A193TipoClienteDescricao ;
      private bool[] P008A22_n193TipoClienteDescricao ;
      private string[] P008A22_A172ClienteTipoPessoa ;
      private bool[] P008A22_n172ClienteTipoPessoa ;
      private string[] P008A22_A171ClienteNomeFantasia ;
      private bool[] P008A22_n171ClienteNomeFantasia ;
      private string[] P008A22_A170ClienteRazaoSocial ;
      private bool[] P008A22_n170ClienteRazaoSocial ;
      private decimal[] P008A22_A311ClienteValorAReceber_F ;
      private bool[] P008A22_n311ClienteValorAReceber_F ;
      private decimal[] P008A22_A310ClienteValorAPagar_F ;
      private bool[] P008A22_n310ClienteValorAPagar_F ;
      private int[] P008A22_A309ClienteQtdTitulos_F ;
      private bool[] P008A22_n309ClienteQtdTitulos_F ;
      private string[] P008A29_A186MunicipioCodigo ;
      private bool[] P008A29_n186MunicipioCodigo ;
      private string[] P008A29_A444ResponsavelMunicipio ;
      private bool[] P008A29_n444ResponsavelMunicipio ;
      private int[] P008A29_A402BancoId ;
      private bool[] P008A29_n402BancoId ;
      private int[] P008A29_A457EspecialidadeId ;
      private bool[] P008A29_n457EspecialidadeId ;
      private short[] P008A29_A597EspecialidadeCreatedBy ;
      private bool[] P008A29_n597EspecialidadeCreatedBy ;
      private int[] P008A29_A437ResponsavelNacionalidade ;
      private bool[] P008A29_n437ResponsavelNacionalidade ;
      private int[] P008A29_A484ClienteNacionalidade ;
      private bool[] P008A29_n484ClienteNacionalidade ;
      private int[] P008A29_A442ResponsavelProfissao ;
      private bool[] P008A29_n442ResponsavelProfissao ;
      private int[] P008A29_A487ClienteProfissao ;
      private bool[] P008A29_n487ClienteProfissao ;
      private int[] P008A29_A489ClienteConvenio ;
      private bool[] P008A29_n489ClienteConvenio ;
      private int[] P008A29_A168ClienteId ;
      private bool[] P008A29_n168ClienteId ;
      private short[] P008A29_A192TipoClienteId ;
      private bool[] P008A29_n192TipoClienteId ;
      private string[] P008A29_A445ResponsavelMunicipioNome ;
      private bool[] P008A29_n445ResponsavelMunicipioNome ;
      private string[] P008A29_A443ResponsavelProfissaoNome ;
      private bool[] P008A29_n443ResponsavelProfissaoNome ;
      private string[] P008A29_A438ResponsavelNacionalidadeNome ;
      private bool[] P008A29_n438ResponsavelNacionalidadeNome ;
      private int[] P008A29_A404BancoCodigo ;
      private bool[] P008A29_n404BancoCodigo ;
      private string[] P008A29_A187MunicipioNome ;
      private bool[] P008A29_n187MunicipioNome ;
      private string[] P008A29_A141SecUserName ;
      private bool[] P008A29_n141SecUserName ;
      private string[] P008A29_A488ClienteProfissaoNome ;
      private bool[] P008A29_n488ClienteProfissaoNome ;
      private string[] P008A29_A485ClienteNacionalidadeNome ;
      private bool[] P008A29_n485ClienteNacionalidadeNome ;
      private string[] P008A29_A490ClienteConvenioDescricao ;
      private bool[] P008A29_n490ClienteConvenioDescricao ;
      private bool[] P008A29_A174ClienteStatus ;
      private bool[] P008A29_n174ClienteStatus ;
      private string[] P008A29_A193TipoClienteDescricao ;
      private bool[] P008A29_n193TipoClienteDescricao ;
      private string[] P008A29_A169ClienteDocumento ;
      private bool[] P008A29_n169ClienteDocumento ;
      private string[] P008A29_A172ClienteTipoPessoa ;
      private bool[] P008A29_n172ClienteTipoPessoa ;
      private string[] P008A29_A171ClienteNomeFantasia ;
      private bool[] P008A29_n171ClienteNomeFantasia ;
      private string[] P008A29_A170ClienteRazaoSocial ;
      private bool[] P008A29_n170ClienteRazaoSocial ;
      private decimal[] P008A29_A311ClienteValorAReceber_F ;
      private bool[] P008A29_n311ClienteValorAReceber_F ;
      private decimal[] P008A29_A310ClienteValorAPagar_F ;
      private bool[] P008A29_n310ClienteValorAPagar_F ;
      private int[] P008A29_A309ClienteQtdTitulos_F ;
      private bool[] P008A29_n309ClienteQtdTitulos_F ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wptituloclientegetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008A8( IGxContext context ,
                                             string A172ClienteTipoPessoa ,
                                             GxSimpleCollection<string> AV141Wptituloclienteds_47_tfclientetipopessoa_sels ,
                                             string AV96Wptituloclienteds_2_dynamicfiltersselector1 ,
                                             short AV97Wptituloclienteds_3_dynamicfiltersoperator1 ,
                                             string AV98Wptituloclienteds_4_clientedocumento1 ,
                                             string AV99Wptituloclienteds_5_tipoclientedescricao1 ,
                                             string AV100Wptituloclienteds_6_clienteconveniodescricao1 ,
                                             string AV101Wptituloclienteds_7_clientenacionalidadenome1 ,
                                             string AV102Wptituloclienteds_8_clienteprofissaonome1 ,
                                             string AV103Wptituloclienteds_9_secusername1 ,
                                             string AV104Wptituloclienteds_10_municipionome1 ,
                                             int AV105Wptituloclienteds_11_bancocodigo1 ,
                                             string AV106Wptituloclienteds_12_responsavelnacionalidadenome1 ,
                                             string AV107Wptituloclienteds_13_responsavelprofissaonome1 ,
                                             string AV108Wptituloclienteds_14_responsavelmunicipionome1 ,
                                             bool AV109Wptituloclienteds_15_dynamicfiltersenabled2 ,
                                             string AV110Wptituloclienteds_16_dynamicfiltersselector2 ,
                                             short AV111Wptituloclienteds_17_dynamicfiltersoperator2 ,
                                             string AV112Wptituloclienteds_18_clientedocumento2 ,
                                             string AV113Wptituloclienteds_19_tipoclientedescricao2 ,
                                             string AV114Wptituloclienteds_20_clienteconveniodescricao2 ,
                                             string AV115Wptituloclienteds_21_clientenacionalidadenome2 ,
                                             string AV116Wptituloclienteds_22_clienteprofissaonome2 ,
                                             string AV117Wptituloclienteds_23_secusername2 ,
                                             string AV118Wptituloclienteds_24_municipionome2 ,
                                             int AV119Wptituloclienteds_25_bancocodigo2 ,
                                             string AV120Wptituloclienteds_26_responsavelnacionalidadenome2 ,
                                             string AV121Wptituloclienteds_27_responsavelprofissaonome2 ,
                                             string AV122Wptituloclienteds_28_responsavelmunicipionome2 ,
                                             bool AV123Wptituloclienteds_29_dynamicfiltersenabled3 ,
                                             string AV124Wptituloclienteds_30_dynamicfiltersselector3 ,
                                             short AV125Wptituloclienteds_31_dynamicfiltersoperator3 ,
                                             string AV126Wptituloclienteds_32_clientedocumento3 ,
                                             string AV127Wptituloclienteds_33_tipoclientedescricao3 ,
                                             string AV128Wptituloclienteds_34_clienteconveniodescricao3 ,
                                             string AV129Wptituloclienteds_35_clientenacionalidadenome3 ,
                                             string AV130Wptituloclienteds_36_clienteprofissaonome3 ,
                                             string AV131Wptituloclienteds_37_secusername3 ,
                                             string AV132Wptituloclienteds_38_municipionome3 ,
                                             int AV133Wptituloclienteds_39_bancocodigo3 ,
                                             string AV134Wptituloclienteds_40_responsavelnacionalidadenome3 ,
                                             string AV135Wptituloclienteds_41_responsavelprofissaonome3 ,
                                             string AV136Wptituloclienteds_42_responsavelmunicipionome3 ,
                                             string AV138Wptituloclienteds_44_tfclienterazaosocial_sel ,
                                             string AV137Wptituloclienteds_43_tfclienterazaosocial ,
                                             string AV140Wptituloclienteds_46_tfclientenomefantasia_sel ,
                                             string AV139Wptituloclienteds_45_tfclientenomefantasia ,
                                             int AV141Wptituloclienteds_47_tfclientetipopessoa_sels_Count ,
                                             string AV143Wptituloclienteds_49_tfclientedocumento_sel ,
                                             string AV142Wptituloclienteds_48_tfclientedocumento ,
                                             string AV145Wptituloclienteds_51_tftipoclientedescricao_sel ,
                                             string AV144Wptituloclienteds_50_tftipoclientedescricao ,
                                             short AV146Wptituloclienteds_52_tfclientestatus_sel ,
                                             decimal AV149Wptituloclienteds_55_tfclientevalorapagar_f ,
                                             decimal AV150Wptituloclienteds_56_tfclientevalorapagar_f_to ,
                                             decimal AV151Wptituloclienteds_57_tfclientevalorareceber_f ,
                                             decimal AV152Wptituloclienteds_58_tfclientevalorareceber_f_to ,
                                             string A169ClienteDocumento ,
                                             string A193TipoClienteDescricao ,
                                             string A490ClienteConvenioDescricao ,
                                             string A485ClienteNacionalidadeNome ,
                                             string A488ClienteProfissaoNome ,
                                             string A141SecUserName ,
                                             string A187MunicipioNome ,
                                             int A404BancoCodigo ,
                                             string A438ResponsavelNacionalidadeNome ,
                                             string A443ResponsavelProfissaoNome ,
                                             string A445ResponsavelMunicipioNome ,
                                             string A170ClienteRazaoSocial ,
                                             string A171ClienteNomeFantasia ,
                                             bool A174ClienteStatus ,
                                             decimal A310ClienteValorAPagar_F ,
                                             decimal A311ClienteValorAReceber_F ,
                                             string AV95Wptituloclienteds_1_filterfulltext ,
                                             int A309ClienteQtdTitulos_F ,
                                             int AV147Wptituloclienteds_53_tfclienteqtdtitulos_f ,
                                             int AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[97];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.TipoClienteId, T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.EspecialidadeId, T6.EspecialidadeCreatedBy AS EspecialidadeCreatedBy, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.ClienteId, T1.ClienteRazaoSocial, T4.MunicipioNome AS ResponsavelMunicipioNome, T10.ProfissaoNome AS ResponsavelProfissaoNome, T8.NacionalidadeNome AS ResponsavelNacionalidadeNome, T5.BancoCodigo, T3.MunicipioNome, T7.SecUserName, T11.ProfissaoNome AS ClienteProfissaoNome, T9.NacionalidadeNome AS ClienteNacionalidadeNome, T12.ConvenioDescricao AS ClienteConvenioDescricao, T1.ClienteStatus, T2.TipoClienteDescricao, T1.ClienteDocumento, T1.ClienteTipoPessoa, T1.ClienteNomeFantasia, COALESCE( T13.ClienteValorAReceber_F, 0) AS ClienteValorAReceber_F, COALESCE( T14.ClienteValorAPagar_F, 0) AS ClienteValorAPagar_F, COALESCE( T15.ClienteQtdTitulos_F, 0) AS ClienteQtdTitulos_F FROM ((((((((((((((Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T5 ON T5.BancoId = T1.BancoId) LEFT JOIN Especialidade T6 ON T6.EspecialidadeId = T1.EspecialidadeId) LEFT JOIN SecUser T7 ON T7.SecUserId = T6.EspecialidadeCreatedBy) LEFT JOIN Nacionalidade T8 ON T8.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T9 ON T9.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T10 ON T10.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T11 ON T11.ProfissaoId = T1.ClienteProfissao)";
         scmdbuf += " LEFT JOIN Convenio T12 ON T12.ConvenioId = T1.ClienteConvenio) LEFT JOIN LATERAL (SELECT SUM(COALESCE( T19.TituloSaldoCredito_F, 0)) AS ClienteValorAReceber_F, T18.ClienteId FROM (((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T20.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T20.TituloValor, 0) - COALESCE( T20.TituloDesconto, 0)) - COALESCE( T21.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoCredito_F, T20.TituloId FROM (Titulo T20 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T20.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T21 ON T21.TituloId = T20.TituloId) ) T19 ON T19.TituloId = T16.TituloId) WHERE T1.ClienteId = T18.ClienteId GROUP BY T18.ClienteId ) T13 ON T13.ClienteId = T1.ClienteId) LEFT JOIN LATERAL (SELECT SUM(CASE  WHEN COALESCE( T16.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE( T16.TituloValor, 0) - COALESCE( T16.TituloDesconto, 0)) - COALESCE( T19.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAPagar_F, T18.ClienteId FROM (((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T16.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T19 ON T19.TituloId = T16.TituloId) WHERE T1.ClienteId = T18.ClienteId GROUP BY T18.ClienteId ) T14 ON T14.ClienteId = T1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteQtdTitulos_F, T18.ClienteId";
         scmdbuf += " FROM ((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) WHERE (T1.ClienteId = T18.ClienteId) AND (Not T16.TituloDeleted) GROUP BY T18.ClienteId ) T15 ON T15.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV95Wptituloclienteds_1_filterfulltext))=0) or ( ( T1.ClienteRazaoSocial like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( T1.ClienteNomeFantasia like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( 'física' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'JURIDICA')) or ( T1.ClienteDocumento like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( T2.TipoClienteDescricao like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteStatus = FALSE) or ( SUBSTR(TO_CHAR(COALESCE( T15.ClienteQtdTitulos_F, 0),'999999999'), 2) like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T14.ClienteValorAPagar_F, 0),'999999999999990.99'), 2) like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T13.ClienteValorAReceber_F, 0),'999999999999990.99'), 2) like '%' || :lV95Wptituloclienteds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV147Wptituloclienteds_53_tfclienteqtdtitulos_f = 0) or ( COALESCE( T15.ClienteQtdTitulos_F, 0) >= :AV147Wptituloclienteds_53_tfclienteqtdtitulos_f))");
         AddWhere(sWhereString, "((:AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to = 0) or ( COALESCE( T15.ClienteQtdTitulos_F, 0) <= :AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to))");
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV98Wptituloclienteds_4_clientedocumento1)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV98Wptituloclienteds_4_clientedocumento1)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV99Wptituloclienteds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV99Wptituloclienteds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like :lV100Wptituloclienteds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like '%' || :lV100Wptituloclienteds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like :lV101Wptituloclienteds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like '%' || :lV101Wptituloclienteds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like :lV102Wptituloclienteds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like '%' || :lV102Wptituloclienteds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV103Wptituloclienteds_9_secusername1)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV103Wptituloclienteds_9_secusername1)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV104Wptituloclienteds_10_municipionome1)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV104Wptituloclienteds_10_municipionome1)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV105Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV105Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV105Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV105Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV105Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV105Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV106Wptituloclienteds_12_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV106Wptituloclienteds_12_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV107Wptituloclienteds_13_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int1[35] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV107Wptituloclienteds_13_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int1[36] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV108Wptituloclienteds_14_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int1[37] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV108Wptituloclienteds_14_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int1[38] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV112Wptituloclienteds_18_clientedocumento2)");
         }
         else
         {
            GXv_int1[39] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV112Wptituloclienteds_18_clientedocumento2)");
         }
         else
         {
            GXv_int1[40] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV113Wptituloclienteds_19_tipoclientedescricao2)");
         }
         else
         {
            GXv_int1[41] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV113Wptituloclienteds_19_tipoclientedescricao2)");
         }
         else
         {
            GXv_int1[42] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like :lV114Wptituloclienteds_20_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int1[43] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like '%' || :lV114Wptituloclienteds_20_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int1[44] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like :lV115Wptituloclienteds_21_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int1[45] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like '%' || :lV115Wptituloclienteds_21_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int1[46] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like :lV116Wptituloclienteds_22_clienteprofissaonome2)");
         }
         else
         {
            GXv_int1[47] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like '%' || :lV116Wptituloclienteds_22_clienteprofissaonome2)");
         }
         else
         {
            GXv_int1[48] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV117Wptituloclienteds_23_secusername2)");
         }
         else
         {
            GXv_int1[49] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV117Wptituloclienteds_23_secusername2)");
         }
         else
         {
            GXv_int1[50] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV118Wptituloclienteds_24_municipionome2)");
         }
         else
         {
            GXv_int1[51] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV118Wptituloclienteds_24_municipionome2)");
         }
         else
         {
            GXv_int1[52] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV119Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV119Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int1[53] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV119Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV119Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int1[54] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV119Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV119Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int1[55] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV120Wptituloclienteds_26_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int1[56] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV120Wptituloclienteds_26_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int1[57] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV121Wptituloclienteds_27_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int1[58] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV121Wptituloclienteds_27_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int1[59] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV122Wptituloclienteds_28_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int1[60] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV122Wptituloclienteds_28_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int1[61] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV126Wptituloclienteds_32_clientedocumento3)");
         }
         else
         {
            GXv_int1[62] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV126Wptituloclienteds_32_clientedocumento3)");
         }
         else
         {
            GXv_int1[63] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV127Wptituloclienteds_33_tipoclientedescricao3)");
         }
         else
         {
            GXv_int1[64] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV127Wptituloclienteds_33_tipoclientedescricao3)");
         }
         else
         {
            GXv_int1[65] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like :lV128Wptituloclienteds_34_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int1[66] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like '%' || :lV128Wptituloclienteds_34_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int1[67] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like :lV129Wptituloclienteds_35_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int1[68] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like '%' || :lV129Wptituloclienteds_35_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int1[69] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like :lV130Wptituloclienteds_36_clienteprofissaonome3)");
         }
         else
         {
            GXv_int1[70] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like '%' || :lV130Wptituloclienteds_36_clienteprofissaonome3)");
         }
         else
         {
            GXv_int1[71] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV131Wptituloclienteds_37_secusername3)");
         }
         else
         {
            GXv_int1[72] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV131Wptituloclienteds_37_secusername3)");
         }
         else
         {
            GXv_int1[73] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV132Wptituloclienteds_38_municipionome3)");
         }
         else
         {
            GXv_int1[74] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV132Wptituloclienteds_38_municipionome3)");
         }
         else
         {
            GXv_int1[75] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV133Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV133Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int1[76] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV133Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV133Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int1[77] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV133Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV133Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int1[78] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV134Wptituloclienteds_40_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int1[79] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV134Wptituloclienteds_40_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int1[80] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV135Wptituloclienteds_41_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int1[81] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV135Wptituloclienteds_41_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int1[82] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV136Wptituloclienteds_42_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int1[83] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV136Wptituloclienteds_42_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int1[84] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV138Wptituloclienteds_44_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Wptituloclienteds_43_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV137Wptituloclienteds_43_tfclienterazaosocial)");
         }
         else
         {
            GXv_int1[85] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Wptituloclienteds_44_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV138Wptituloclienteds_44_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV138Wptituloclienteds_44_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int1[86] = 1;
         }
         if ( StringUtil.StrCmp(AV138Wptituloclienteds_44_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Wptituloclienteds_46_tfclientenomefantasia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Wptituloclienteds_45_tfclientenomefantasia)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia like :lV139Wptituloclienteds_45_tfclientenomefantasia)");
         }
         else
         {
            GXv_int1[87] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Wptituloclienteds_46_tfclientenomefantasia_sel)) && ! ( StringUtil.StrCmp(AV140Wptituloclienteds_46_tfclientenomefantasia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia = ( :AV140Wptituloclienteds_46_tfclientenomefantasia_sel))");
         }
         else
         {
            GXv_int1[88] = 1;
         }
         if ( StringUtil.StrCmp(AV140Wptituloclienteds_46_tfclientenomefantasia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia IS NULL or (char_length(trim(trailing ' ' from T1.ClienteNomeFantasia))=0))");
         }
         if ( AV141Wptituloclienteds_47_tfclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV141Wptituloclienteds_47_tfclientetipopessoa_sels, "T1.ClienteTipoPessoa IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Wptituloclienteds_49_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Wptituloclienteds_48_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV142Wptituloclienteds_48_tfclientedocumento)");
         }
         else
         {
            GXv_int1[89] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Wptituloclienteds_49_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV143Wptituloclienteds_49_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV143Wptituloclienteds_49_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int1[90] = 1;
         }
         if ( StringUtil.StrCmp(AV143Wptituloclienteds_49_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV145Wptituloclienteds_51_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Wptituloclienteds_50_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV144Wptituloclienteds_50_tftipoclientedescricao)");
         }
         else
         {
            GXv_int1[91] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Wptituloclienteds_51_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV145Wptituloclienteds_51_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao = ( :AV145Wptituloclienteds_51_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int1[92] = 1;
         }
         if ( StringUtil.StrCmp(AV145Wptituloclienteds_51_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from T2.TipoClienteDescricao))=0))");
         }
         if ( AV146Wptituloclienteds_52_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV146Wptituloclienteds_52_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV149Wptituloclienteds_55_tfclientevalorapagar_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T14.ClienteValorAPagar_F, 0) >= :AV149Wptituloclienteds_55_tfclientevalorapagar_f)");
         }
         else
         {
            GXv_int1[93] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV150Wptituloclienteds_56_tfclientevalorapagar_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T14.ClienteValorAPagar_F, 0) <= :AV150Wptituloclienteds_56_tfclientevalorapagar_f_to)");
         }
         else
         {
            GXv_int1[94] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV151Wptituloclienteds_57_tfclientevalorareceber_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T13.ClienteValorAReceber_F, 0) >= :AV151Wptituloclienteds_57_tfclientevalorareceber_f)");
         }
         else
         {
            GXv_int1[95] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV152Wptituloclienteds_58_tfclientevalorareceber_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T13.ClienteValorAReceber_F, 0) <= :AV152Wptituloclienteds_58_tfclientevalorareceber_f_to)");
         }
         else
         {
            GXv_int1[96] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteRazaoSocial";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008A15( IGxContext context ,
                                              string A172ClienteTipoPessoa ,
                                              GxSimpleCollection<string> AV141Wptituloclienteds_47_tfclientetipopessoa_sels ,
                                              string AV96Wptituloclienteds_2_dynamicfiltersselector1 ,
                                              short AV97Wptituloclienteds_3_dynamicfiltersoperator1 ,
                                              string AV98Wptituloclienteds_4_clientedocumento1 ,
                                              string AV99Wptituloclienteds_5_tipoclientedescricao1 ,
                                              string AV100Wptituloclienteds_6_clienteconveniodescricao1 ,
                                              string AV101Wptituloclienteds_7_clientenacionalidadenome1 ,
                                              string AV102Wptituloclienteds_8_clienteprofissaonome1 ,
                                              string AV103Wptituloclienteds_9_secusername1 ,
                                              string AV104Wptituloclienteds_10_municipionome1 ,
                                              int AV105Wptituloclienteds_11_bancocodigo1 ,
                                              string AV106Wptituloclienteds_12_responsavelnacionalidadenome1 ,
                                              string AV107Wptituloclienteds_13_responsavelprofissaonome1 ,
                                              string AV108Wptituloclienteds_14_responsavelmunicipionome1 ,
                                              bool AV109Wptituloclienteds_15_dynamicfiltersenabled2 ,
                                              string AV110Wptituloclienteds_16_dynamicfiltersselector2 ,
                                              short AV111Wptituloclienteds_17_dynamicfiltersoperator2 ,
                                              string AV112Wptituloclienteds_18_clientedocumento2 ,
                                              string AV113Wptituloclienteds_19_tipoclientedescricao2 ,
                                              string AV114Wptituloclienteds_20_clienteconveniodescricao2 ,
                                              string AV115Wptituloclienteds_21_clientenacionalidadenome2 ,
                                              string AV116Wptituloclienteds_22_clienteprofissaonome2 ,
                                              string AV117Wptituloclienteds_23_secusername2 ,
                                              string AV118Wptituloclienteds_24_municipionome2 ,
                                              int AV119Wptituloclienteds_25_bancocodigo2 ,
                                              string AV120Wptituloclienteds_26_responsavelnacionalidadenome2 ,
                                              string AV121Wptituloclienteds_27_responsavelprofissaonome2 ,
                                              string AV122Wptituloclienteds_28_responsavelmunicipionome2 ,
                                              bool AV123Wptituloclienteds_29_dynamicfiltersenabled3 ,
                                              string AV124Wptituloclienteds_30_dynamicfiltersselector3 ,
                                              short AV125Wptituloclienteds_31_dynamicfiltersoperator3 ,
                                              string AV126Wptituloclienteds_32_clientedocumento3 ,
                                              string AV127Wptituloclienteds_33_tipoclientedescricao3 ,
                                              string AV128Wptituloclienteds_34_clienteconveniodescricao3 ,
                                              string AV129Wptituloclienteds_35_clientenacionalidadenome3 ,
                                              string AV130Wptituloclienteds_36_clienteprofissaonome3 ,
                                              string AV131Wptituloclienteds_37_secusername3 ,
                                              string AV132Wptituloclienteds_38_municipionome3 ,
                                              int AV133Wptituloclienteds_39_bancocodigo3 ,
                                              string AV134Wptituloclienteds_40_responsavelnacionalidadenome3 ,
                                              string AV135Wptituloclienteds_41_responsavelprofissaonome3 ,
                                              string AV136Wptituloclienteds_42_responsavelmunicipionome3 ,
                                              string AV138Wptituloclienteds_44_tfclienterazaosocial_sel ,
                                              string AV137Wptituloclienteds_43_tfclienterazaosocial ,
                                              string AV140Wptituloclienteds_46_tfclientenomefantasia_sel ,
                                              string AV139Wptituloclienteds_45_tfclientenomefantasia ,
                                              int AV141Wptituloclienteds_47_tfclientetipopessoa_sels_Count ,
                                              string AV143Wptituloclienteds_49_tfclientedocumento_sel ,
                                              string AV142Wptituloclienteds_48_tfclientedocumento ,
                                              string AV145Wptituloclienteds_51_tftipoclientedescricao_sel ,
                                              string AV144Wptituloclienteds_50_tftipoclientedescricao ,
                                              short AV146Wptituloclienteds_52_tfclientestatus_sel ,
                                              decimal AV149Wptituloclienteds_55_tfclientevalorapagar_f ,
                                              decimal AV150Wptituloclienteds_56_tfclientevalorapagar_f_to ,
                                              decimal AV151Wptituloclienteds_57_tfclientevalorareceber_f ,
                                              decimal AV152Wptituloclienteds_58_tfclientevalorareceber_f_to ,
                                              string A169ClienteDocumento ,
                                              string A193TipoClienteDescricao ,
                                              string A490ClienteConvenioDescricao ,
                                              string A485ClienteNacionalidadeNome ,
                                              string A488ClienteProfissaoNome ,
                                              string A141SecUserName ,
                                              string A187MunicipioNome ,
                                              int A404BancoCodigo ,
                                              string A438ResponsavelNacionalidadeNome ,
                                              string A443ResponsavelProfissaoNome ,
                                              string A445ResponsavelMunicipioNome ,
                                              string A170ClienteRazaoSocial ,
                                              string A171ClienteNomeFantasia ,
                                              bool A174ClienteStatus ,
                                              decimal A310ClienteValorAPagar_F ,
                                              decimal A311ClienteValorAReceber_F ,
                                              string AV95Wptituloclienteds_1_filterfulltext ,
                                              int A309ClienteQtdTitulos_F ,
                                              int AV147Wptituloclienteds_53_tfclienteqtdtitulos_f ,
                                              int AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[97];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.TipoClienteId, T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.EspecialidadeId, T6.EspecialidadeCreatedBy AS EspecialidadeCreatedBy, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.ClienteId, T1.ClienteNomeFantasia, T4.MunicipioNome AS ResponsavelMunicipioNome, T10.ProfissaoNome AS ResponsavelProfissaoNome, T8.NacionalidadeNome AS ResponsavelNacionalidadeNome, T5.BancoCodigo, T3.MunicipioNome, T7.SecUserName, T11.ProfissaoNome AS ClienteProfissaoNome, T9.NacionalidadeNome AS ClienteNacionalidadeNome, T12.ConvenioDescricao AS ClienteConvenioDescricao, T1.ClienteStatus, T2.TipoClienteDescricao, T1.ClienteDocumento, T1.ClienteTipoPessoa, T1.ClienteRazaoSocial, COALESCE( T13.ClienteValorAReceber_F, 0) AS ClienteValorAReceber_F, COALESCE( T14.ClienteValorAPagar_F, 0) AS ClienteValorAPagar_F, COALESCE( T15.ClienteQtdTitulos_F, 0) AS ClienteQtdTitulos_F FROM ((((((((((((((Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T5 ON T5.BancoId = T1.BancoId) LEFT JOIN Especialidade T6 ON T6.EspecialidadeId = T1.EspecialidadeId) LEFT JOIN SecUser T7 ON T7.SecUserId = T6.EspecialidadeCreatedBy) LEFT JOIN Nacionalidade T8 ON T8.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T9 ON T9.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T10 ON T10.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T11 ON T11.ProfissaoId = T1.ClienteProfissao)";
         scmdbuf += " LEFT JOIN Convenio T12 ON T12.ConvenioId = T1.ClienteConvenio) LEFT JOIN LATERAL (SELECT SUM(COALESCE( T19.TituloSaldoCredito_F, 0)) AS ClienteValorAReceber_F, T18.ClienteId FROM (((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T20.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T20.TituloValor, 0) - COALESCE( T20.TituloDesconto, 0)) - COALESCE( T21.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoCredito_F, T20.TituloId FROM (Titulo T20 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T20.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T21 ON T21.TituloId = T20.TituloId) ) T19 ON T19.TituloId = T16.TituloId) WHERE T1.ClienteId = T18.ClienteId GROUP BY T18.ClienteId ) T13 ON T13.ClienteId = T1.ClienteId) LEFT JOIN LATERAL (SELECT SUM(CASE  WHEN COALESCE( T16.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE( T16.TituloValor, 0) - COALESCE( T16.TituloDesconto, 0)) - COALESCE( T19.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAPagar_F, T18.ClienteId FROM (((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T16.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T19 ON T19.TituloId = T16.TituloId) WHERE T1.ClienteId = T18.ClienteId GROUP BY T18.ClienteId ) T14 ON T14.ClienteId = T1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteQtdTitulos_F, T18.ClienteId";
         scmdbuf += " FROM ((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) WHERE (T1.ClienteId = T18.ClienteId) AND (Not T16.TituloDeleted) GROUP BY T18.ClienteId ) T15 ON T15.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV95Wptituloclienteds_1_filterfulltext))=0) or ( ( T1.ClienteRazaoSocial like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( T1.ClienteNomeFantasia like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( 'física' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'JURIDICA')) or ( T1.ClienteDocumento like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( T2.TipoClienteDescricao like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteStatus = FALSE) or ( SUBSTR(TO_CHAR(COALESCE( T15.ClienteQtdTitulos_F, 0),'999999999'), 2) like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T14.ClienteValorAPagar_F, 0),'999999999999990.99'), 2) like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T13.ClienteValorAReceber_F, 0),'999999999999990.99'), 2) like '%' || :lV95Wptituloclienteds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV147Wptituloclienteds_53_tfclienteqtdtitulos_f = 0) or ( COALESCE( T15.ClienteQtdTitulos_F, 0) >= :AV147Wptituloclienteds_53_tfclienteqtdtitulos_f))");
         AddWhere(sWhereString, "((:AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to = 0) or ( COALESCE( T15.ClienteQtdTitulos_F, 0) <= :AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to))");
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV98Wptituloclienteds_4_clientedocumento1)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV98Wptituloclienteds_4_clientedocumento1)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV99Wptituloclienteds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV99Wptituloclienteds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like :lV100Wptituloclienteds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like '%' || :lV100Wptituloclienteds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like :lV101Wptituloclienteds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like '%' || :lV101Wptituloclienteds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like :lV102Wptituloclienteds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like '%' || :lV102Wptituloclienteds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV103Wptituloclienteds_9_secusername1)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV103Wptituloclienteds_9_secusername1)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV104Wptituloclienteds_10_municipionome1)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV104Wptituloclienteds_10_municipionome1)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV105Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV105Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV105Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV105Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV105Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV105Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV106Wptituloclienteds_12_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV106Wptituloclienteds_12_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV107Wptituloclienteds_13_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV107Wptituloclienteds_13_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV108Wptituloclienteds_14_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV108Wptituloclienteds_14_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV112Wptituloclienteds_18_clientedocumento2)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV112Wptituloclienteds_18_clientedocumento2)");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV113Wptituloclienteds_19_tipoclientedescricao2)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV113Wptituloclienteds_19_tipoclientedescricao2)");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like :lV114Wptituloclienteds_20_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like '%' || :lV114Wptituloclienteds_20_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like :lV115Wptituloclienteds_21_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like '%' || :lV115Wptituloclienteds_21_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like :lV116Wptituloclienteds_22_clienteprofissaonome2)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like '%' || :lV116Wptituloclienteds_22_clienteprofissaonome2)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV117Wptituloclienteds_23_secusername2)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV117Wptituloclienteds_23_secusername2)");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV118Wptituloclienteds_24_municipionome2)");
         }
         else
         {
            GXv_int3[51] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV118Wptituloclienteds_24_municipionome2)");
         }
         else
         {
            GXv_int3[52] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV119Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV119Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int3[53] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV119Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV119Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV119Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV119Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int3[55] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV120Wptituloclienteds_26_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int3[56] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV120Wptituloclienteds_26_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int3[57] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV121Wptituloclienteds_27_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int3[58] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV121Wptituloclienteds_27_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int3[59] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV122Wptituloclienteds_28_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int3[60] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV122Wptituloclienteds_28_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int3[61] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV126Wptituloclienteds_32_clientedocumento3)");
         }
         else
         {
            GXv_int3[62] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV126Wptituloclienteds_32_clientedocumento3)");
         }
         else
         {
            GXv_int3[63] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV127Wptituloclienteds_33_tipoclientedescricao3)");
         }
         else
         {
            GXv_int3[64] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV127Wptituloclienteds_33_tipoclientedescricao3)");
         }
         else
         {
            GXv_int3[65] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like :lV128Wptituloclienteds_34_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int3[66] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like '%' || :lV128Wptituloclienteds_34_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int3[67] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like :lV129Wptituloclienteds_35_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int3[68] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like '%' || :lV129Wptituloclienteds_35_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int3[69] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like :lV130Wptituloclienteds_36_clienteprofissaonome3)");
         }
         else
         {
            GXv_int3[70] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like '%' || :lV130Wptituloclienteds_36_clienteprofissaonome3)");
         }
         else
         {
            GXv_int3[71] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV131Wptituloclienteds_37_secusername3)");
         }
         else
         {
            GXv_int3[72] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV131Wptituloclienteds_37_secusername3)");
         }
         else
         {
            GXv_int3[73] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV132Wptituloclienteds_38_municipionome3)");
         }
         else
         {
            GXv_int3[74] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV132Wptituloclienteds_38_municipionome3)");
         }
         else
         {
            GXv_int3[75] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV133Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV133Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int3[76] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV133Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV133Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int3[77] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV133Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV133Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int3[78] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV134Wptituloclienteds_40_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int3[79] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV134Wptituloclienteds_40_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int3[80] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV135Wptituloclienteds_41_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int3[81] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV135Wptituloclienteds_41_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int3[82] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV136Wptituloclienteds_42_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int3[83] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV136Wptituloclienteds_42_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int3[84] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV138Wptituloclienteds_44_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Wptituloclienteds_43_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV137Wptituloclienteds_43_tfclienterazaosocial)");
         }
         else
         {
            GXv_int3[85] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Wptituloclienteds_44_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV138Wptituloclienteds_44_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV138Wptituloclienteds_44_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[86] = 1;
         }
         if ( StringUtil.StrCmp(AV138Wptituloclienteds_44_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Wptituloclienteds_46_tfclientenomefantasia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Wptituloclienteds_45_tfclientenomefantasia)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia like :lV139Wptituloclienteds_45_tfclientenomefantasia)");
         }
         else
         {
            GXv_int3[87] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Wptituloclienteds_46_tfclientenomefantasia_sel)) && ! ( StringUtil.StrCmp(AV140Wptituloclienteds_46_tfclientenomefantasia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia = ( :AV140Wptituloclienteds_46_tfclientenomefantasia_sel))");
         }
         else
         {
            GXv_int3[88] = 1;
         }
         if ( StringUtil.StrCmp(AV140Wptituloclienteds_46_tfclientenomefantasia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia IS NULL or (char_length(trim(trailing ' ' from T1.ClienteNomeFantasia))=0))");
         }
         if ( AV141Wptituloclienteds_47_tfclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV141Wptituloclienteds_47_tfclientetipopessoa_sels, "T1.ClienteTipoPessoa IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Wptituloclienteds_49_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Wptituloclienteds_48_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV142Wptituloclienteds_48_tfclientedocumento)");
         }
         else
         {
            GXv_int3[89] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Wptituloclienteds_49_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV143Wptituloclienteds_49_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV143Wptituloclienteds_49_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int3[90] = 1;
         }
         if ( StringUtil.StrCmp(AV143Wptituloclienteds_49_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV145Wptituloclienteds_51_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Wptituloclienteds_50_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV144Wptituloclienteds_50_tftipoclientedescricao)");
         }
         else
         {
            GXv_int3[91] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Wptituloclienteds_51_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV145Wptituloclienteds_51_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao = ( :AV145Wptituloclienteds_51_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int3[92] = 1;
         }
         if ( StringUtil.StrCmp(AV145Wptituloclienteds_51_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from T2.TipoClienteDescricao))=0))");
         }
         if ( AV146Wptituloclienteds_52_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV146Wptituloclienteds_52_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV149Wptituloclienteds_55_tfclientevalorapagar_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T14.ClienteValorAPagar_F, 0) >= :AV149Wptituloclienteds_55_tfclientevalorapagar_f)");
         }
         else
         {
            GXv_int3[93] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV150Wptituloclienteds_56_tfclientevalorapagar_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T14.ClienteValorAPagar_F, 0) <= :AV150Wptituloclienteds_56_tfclientevalorapagar_f_to)");
         }
         else
         {
            GXv_int3[94] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV151Wptituloclienteds_57_tfclientevalorareceber_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T13.ClienteValorAReceber_F, 0) >= :AV151Wptituloclienteds_57_tfclientevalorareceber_f)");
         }
         else
         {
            GXv_int3[95] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV152Wptituloclienteds_58_tfclientevalorareceber_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T13.ClienteValorAReceber_F, 0) <= :AV152Wptituloclienteds_58_tfclientevalorareceber_f_to)");
         }
         else
         {
            GXv_int3[96] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteNomeFantasia";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P008A22( IGxContext context ,
                                              string A172ClienteTipoPessoa ,
                                              GxSimpleCollection<string> AV141Wptituloclienteds_47_tfclientetipopessoa_sels ,
                                              string AV96Wptituloclienteds_2_dynamicfiltersselector1 ,
                                              short AV97Wptituloclienteds_3_dynamicfiltersoperator1 ,
                                              string AV98Wptituloclienteds_4_clientedocumento1 ,
                                              string AV99Wptituloclienteds_5_tipoclientedescricao1 ,
                                              string AV100Wptituloclienteds_6_clienteconveniodescricao1 ,
                                              string AV101Wptituloclienteds_7_clientenacionalidadenome1 ,
                                              string AV102Wptituloclienteds_8_clienteprofissaonome1 ,
                                              string AV103Wptituloclienteds_9_secusername1 ,
                                              string AV104Wptituloclienteds_10_municipionome1 ,
                                              int AV105Wptituloclienteds_11_bancocodigo1 ,
                                              string AV106Wptituloclienteds_12_responsavelnacionalidadenome1 ,
                                              string AV107Wptituloclienteds_13_responsavelprofissaonome1 ,
                                              string AV108Wptituloclienteds_14_responsavelmunicipionome1 ,
                                              bool AV109Wptituloclienteds_15_dynamicfiltersenabled2 ,
                                              string AV110Wptituloclienteds_16_dynamicfiltersselector2 ,
                                              short AV111Wptituloclienteds_17_dynamicfiltersoperator2 ,
                                              string AV112Wptituloclienteds_18_clientedocumento2 ,
                                              string AV113Wptituloclienteds_19_tipoclientedescricao2 ,
                                              string AV114Wptituloclienteds_20_clienteconveniodescricao2 ,
                                              string AV115Wptituloclienteds_21_clientenacionalidadenome2 ,
                                              string AV116Wptituloclienteds_22_clienteprofissaonome2 ,
                                              string AV117Wptituloclienteds_23_secusername2 ,
                                              string AV118Wptituloclienteds_24_municipionome2 ,
                                              int AV119Wptituloclienteds_25_bancocodigo2 ,
                                              string AV120Wptituloclienteds_26_responsavelnacionalidadenome2 ,
                                              string AV121Wptituloclienteds_27_responsavelprofissaonome2 ,
                                              string AV122Wptituloclienteds_28_responsavelmunicipionome2 ,
                                              bool AV123Wptituloclienteds_29_dynamicfiltersenabled3 ,
                                              string AV124Wptituloclienteds_30_dynamicfiltersselector3 ,
                                              short AV125Wptituloclienteds_31_dynamicfiltersoperator3 ,
                                              string AV126Wptituloclienteds_32_clientedocumento3 ,
                                              string AV127Wptituloclienteds_33_tipoclientedescricao3 ,
                                              string AV128Wptituloclienteds_34_clienteconveniodescricao3 ,
                                              string AV129Wptituloclienteds_35_clientenacionalidadenome3 ,
                                              string AV130Wptituloclienteds_36_clienteprofissaonome3 ,
                                              string AV131Wptituloclienteds_37_secusername3 ,
                                              string AV132Wptituloclienteds_38_municipionome3 ,
                                              int AV133Wptituloclienteds_39_bancocodigo3 ,
                                              string AV134Wptituloclienteds_40_responsavelnacionalidadenome3 ,
                                              string AV135Wptituloclienteds_41_responsavelprofissaonome3 ,
                                              string AV136Wptituloclienteds_42_responsavelmunicipionome3 ,
                                              string AV138Wptituloclienteds_44_tfclienterazaosocial_sel ,
                                              string AV137Wptituloclienteds_43_tfclienterazaosocial ,
                                              string AV140Wptituloclienteds_46_tfclientenomefantasia_sel ,
                                              string AV139Wptituloclienteds_45_tfclientenomefantasia ,
                                              int AV141Wptituloclienteds_47_tfclientetipopessoa_sels_Count ,
                                              string AV143Wptituloclienteds_49_tfclientedocumento_sel ,
                                              string AV142Wptituloclienteds_48_tfclientedocumento ,
                                              string AV145Wptituloclienteds_51_tftipoclientedescricao_sel ,
                                              string AV144Wptituloclienteds_50_tftipoclientedescricao ,
                                              short AV146Wptituloclienteds_52_tfclientestatus_sel ,
                                              decimal AV149Wptituloclienteds_55_tfclientevalorapagar_f ,
                                              decimal AV150Wptituloclienteds_56_tfclientevalorapagar_f_to ,
                                              decimal AV151Wptituloclienteds_57_tfclientevalorareceber_f ,
                                              decimal AV152Wptituloclienteds_58_tfclientevalorareceber_f_to ,
                                              string A169ClienteDocumento ,
                                              string A193TipoClienteDescricao ,
                                              string A490ClienteConvenioDescricao ,
                                              string A485ClienteNacionalidadeNome ,
                                              string A488ClienteProfissaoNome ,
                                              string A141SecUserName ,
                                              string A187MunicipioNome ,
                                              int A404BancoCodigo ,
                                              string A438ResponsavelNacionalidadeNome ,
                                              string A443ResponsavelProfissaoNome ,
                                              string A445ResponsavelMunicipioNome ,
                                              string A170ClienteRazaoSocial ,
                                              string A171ClienteNomeFantasia ,
                                              bool A174ClienteStatus ,
                                              decimal A310ClienteValorAPagar_F ,
                                              decimal A311ClienteValorAReceber_F ,
                                              string AV95Wptituloclienteds_1_filterfulltext ,
                                              int A309ClienteQtdTitulos_F ,
                                              int AV147Wptituloclienteds_53_tfclienteqtdtitulos_f ,
                                              int AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[97];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.TipoClienteId, T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.EspecialidadeId, T6.EspecialidadeCreatedBy AS EspecialidadeCreatedBy, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.ClienteId, T1.ClienteDocumento, T4.MunicipioNome AS ResponsavelMunicipioNome, T10.ProfissaoNome AS ResponsavelProfissaoNome, T8.NacionalidadeNome AS ResponsavelNacionalidadeNome, T5.BancoCodigo, T3.MunicipioNome, T7.SecUserName, T11.ProfissaoNome AS ClienteProfissaoNome, T9.NacionalidadeNome AS ClienteNacionalidadeNome, T12.ConvenioDescricao AS ClienteConvenioDescricao, T1.ClienteStatus, T2.TipoClienteDescricao, T1.ClienteTipoPessoa, T1.ClienteNomeFantasia, T1.ClienteRazaoSocial, COALESCE( T13.ClienteValorAReceber_F, 0) AS ClienteValorAReceber_F, COALESCE( T14.ClienteValorAPagar_F, 0) AS ClienteValorAPagar_F, COALESCE( T15.ClienteQtdTitulos_F, 0) AS ClienteQtdTitulos_F FROM ((((((((((((((Cliente T1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = T1.TipoClienteId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T4 ON T4.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T5 ON T5.BancoId = T1.BancoId) LEFT JOIN Especialidade T6 ON T6.EspecialidadeId = T1.EspecialidadeId) LEFT JOIN SecUser T7 ON T7.SecUserId = T6.EspecialidadeCreatedBy) LEFT JOIN Nacionalidade T8 ON T8.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T9 ON T9.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T10 ON T10.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T11 ON T11.ProfissaoId = T1.ClienteProfissao)";
         scmdbuf += " LEFT JOIN Convenio T12 ON T12.ConvenioId = T1.ClienteConvenio) LEFT JOIN LATERAL (SELECT SUM(COALESCE( T19.TituloSaldoCredito_F, 0)) AS ClienteValorAReceber_F, T18.ClienteId FROM (((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T20.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T20.TituloValor, 0) - COALESCE( T20.TituloDesconto, 0)) - COALESCE( T21.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoCredito_F, T20.TituloId FROM (Titulo T20 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T20.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T21 ON T21.TituloId = T20.TituloId) ) T19 ON T19.TituloId = T16.TituloId) WHERE T1.ClienteId = T18.ClienteId GROUP BY T18.ClienteId ) T13 ON T13.ClienteId = T1.ClienteId) LEFT JOIN LATERAL (SELECT SUM(CASE  WHEN COALESCE( T16.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE( T16.TituloValor, 0) - COALESCE( T16.TituloDesconto, 0)) - COALESCE( T19.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAPagar_F, T18.ClienteId FROM (((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T16.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T19 ON T19.TituloId = T16.TituloId) WHERE T1.ClienteId = T18.ClienteId GROUP BY T18.ClienteId ) T14 ON T14.ClienteId = T1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteQtdTitulos_F, T18.ClienteId";
         scmdbuf += " FROM ((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) WHERE (T1.ClienteId = T18.ClienteId) AND (Not T16.TituloDeleted) GROUP BY T18.ClienteId ) T15 ON T15.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV95Wptituloclienteds_1_filterfulltext))=0) or ( ( T1.ClienteRazaoSocial like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( T1.ClienteNomeFantasia like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( 'física' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'JURIDICA')) or ( T1.ClienteDocumento like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( T2.TipoClienteDescricao like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteStatus = FALSE) or ( SUBSTR(TO_CHAR(COALESCE( T15.ClienteQtdTitulos_F, 0),'999999999'), 2) like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T14.ClienteValorAPagar_F, 0),'999999999999990.99'), 2) like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T13.ClienteValorAReceber_F, 0),'999999999999990.99'), 2) like '%' || :lV95Wptituloclienteds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV147Wptituloclienteds_53_tfclienteqtdtitulos_f = 0) or ( COALESCE( T15.ClienteQtdTitulos_F, 0) >= :AV147Wptituloclienteds_53_tfclienteqtdtitulos_f))");
         AddWhere(sWhereString, "((:AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to = 0) or ( COALESCE( T15.ClienteQtdTitulos_F, 0) <= :AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to))");
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV98Wptituloclienteds_4_clientedocumento1)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV98Wptituloclienteds_4_clientedocumento1)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV99Wptituloclienteds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV99Wptituloclienteds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like :lV100Wptituloclienteds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like '%' || :lV100Wptituloclienteds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like :lV101Wptituloclienteds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like '%' || :lV101Wptituloclienteds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like :lV102Wptituloclienteds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like '%' || :lV102Wptituloclienteds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV103Wptituloclienteds_9_secusername1)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV103Wptituloclienteds_9_secusername1)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV104Wptituloclienteds_10_municipionome1)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV104Wptituloclienteds_10_municipionome1)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV105Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV105Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV105Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV105Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV105Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV105Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV106Wptituloclienteds_12_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV106Wptituloclienteds_12_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV107Wptituloclienteds_13_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV107Wptituloclienteds_13_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int5[36] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV108Wptituloclienteds_14_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int5[37] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV108Wptituloclienteds_14_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int5[38] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV112Wptituloclienteds_18_clientedocumento2)");
         }
         else
         {
            GXv_int5[39] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV112Wptituloclienteds_18_clientedocumento2)");
         }
         else
         {
            GXv_int5[40] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV113Wptituloclienteds_19_tipoclientedescricao2)");
         }
         else
         {
            GXv_int5[41] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV113Wptituloclienteds_19_tipoclientedescricao2)");
         }
         else
         {
            GXv_int5[42] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like :lV114Wptituloclienteds_20_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int5[43] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like '%' || :lV114Wptituloclienteds_20_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int5[44] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like :lV115Wptituloclienteds_21_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int5[45] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like '%' || :lV115Wptituloclienteds_21_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int5[46] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like :lV116Wptituloclienteds_22_clienteprofissaonome2)");
         }
         else
         {
            GXv_int5[47] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like '%' || :lV116Wptituloclienteds_22_clienteprofissaonome2)");
         }
         else
         {
            GXv_int5[48] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV117Wptituloclienteds_23_secusername2)");
         }
         else
         {
            GXv_int5[49] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV117Wptituloclienteds_23_secusername2)");
         }
         else
         {
            GXv_int5[50] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV118Wptituloclienteds_24_municipionome2)");
         }
         else
         {
            GXv_int5[51] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV118Wptituloclienteds_24_municipionome2)");
         }
         else
         {
            GXv_int5[52] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV119Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV119Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int5[53] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV119Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV119Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int5[54] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV119Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV119Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int5[55] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV120Wptituloclienteds_26_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int5[56] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV120Wptituloclienteds_26_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int5[57] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV121Wptituloclienteds_27_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int5[58] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV121Wptituloclienteds_27_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int5[59] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV122Wptituloclienteds_28_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int5[60] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV122Wptituloclienteds_28_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int5[61] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV126Wptituloclienteds_32_clientedocumento3)");
         }
         else
         {
            GXv_int5[62] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV126Wptituloclienteds_32_clientedocumento3)");
         }
         else
         {
            GXv_int5[63] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV127Wptituloclienteds_33_tipoclientedescricao3)");
         }
         else
         {
            GXv_int5[64] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like '%' || :lV127Wptituloclienteds_33_tipoclientedescricao3)");
         }
         else
         {
            GXv_int5[65] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like :lV128Wptituloclienteds_34_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int5[66] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T12.ConvenioDescricao like '%' || :lV128Wptituloclienteds_34_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int5[67] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like :lV129Wptituloclienteds_35_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int5[68] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T9.NacionalidadeNome like '%' || :lV129Wptituloclienteds_35_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int5[69] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like :lV130Wptituloclienteds_36_clienteprofissaonome3)");
         }
         else
         {
            GXv_int5[70] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T11.ProfissaoNome like '%' || :lV130Wptituloclienteds_36_clienteprofissaonome3)");
         }
         else
         {
            GXv_int5[71] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like :lV131Wptituloclienteds_37_secusername3)");
         }
         else
         {
            GXv_int5[72] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T7.SecUserName like '%' || :lV131Wptituloclienteds_37_secusername3)");
         }
         else
         {
            GXv_int5[73] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV132Wptituloclienteds_38_municipionome3)");
         }
         else
         {
            GXv_int5[74] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV132Wptituloclienteds_38_municipionome3)");
         }
         else
         {
            GXv_int5[75] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV133Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo < :AV133Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int5[76] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV133Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo = :AV133Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int5[77] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV133Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T5.BancoCodigo > :AV133Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int5[78] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV134Wptituloclienteds_40_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int5[79] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV134Wptituloclienteds_40_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int5[80] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV135Wptituloclienteds_41_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int5[81] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV135Wptituloclienteds_41_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int5[82] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like :lV136Wptituloclienteds_42_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int5[83] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T4.MunicipioNome like '%' || :lV136Wptituloclienteds_42_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int5[84] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV138Wptituloclienteds_44_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Wptituloclienteds_43_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV137Wptituloclienteds_43_tfclienterazaosocial)");
         }
         else
         {
            GXv_int5[85] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Wptituloclienteds_44_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV138Wptituloclienteds_44_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV138Wptituloclienteds_44_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int5[86] = 1;
         }
         if ( StringUtil.StrCmp(AV138Wptituloclienteds_44_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Wptituloclienteds_46_tfclientenomefantasia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Wptituloclienteds_45_tfclientenomefantasia)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia like :lV139Wptituloclienteds_45_tfclientenomefantasia)");
         }
         else
         {
            GXv_int5[87] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Wptituloclienteds_46_tfclientenomefantasia_sel)) && ! ( StringUtil.StrCmp(AV140Wptituloclienteds_46_tfclientenomefantasia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia = ( :AV140Wptituloclienteds_46_tfclientenomefantasia_sel))");
         }
         else
         {
            GXv_int5[88] = 1;
         }
         if ( StringUtil.StrCmp(AV140Wptituloclienteds_46_tfclientenomefantasia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia IS NULL or (char_length(trim(trailing ' ' from T1.ClienteNomeFantasia))=0))");
         }
         if ( AV141Wptituloclienteds_47_tfclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV141Wptituloclienteds_47_tfclientetipopessoa_sels, "T1.ClienteTipoPessoa IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Wptituloclienteds_49_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Wptituloclienteds_48_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV142Wptituloclienteds_48_tfclientedocumento)");
         }
         else
         {
            GXv_int5[89] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Wptituloclienteds_49_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV143Wptituloclienteds_49_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV143Wptituloclienteds_49_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int5[90] = 1;
         }
         if ( StringUtil.StrCmp(AV143Wptituloclienteds_49_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV145Wptituloclienteds_51_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Wptituloclienteds_50_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao like :lV144Wptituloclienteds_50_tftipoclientedescricao)");
         }
         else
         {
            GXv_int5[91] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Wptituloclienteds_51_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV145Wptituloclienteds_51_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao = ( :AV145Wptituloclienteds_51_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int5[92] = 1;
         }
         if ( StringUtil.StrCmp(AV145Wptituloclienteds_51_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from T2.TipoClienteDescricao))=0))");
         }
         if ( AV146Wptituloclienteds_52_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV146Wptituloclienteds_52_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV149Wptituloclienteds_55_tfclientevalorapagar_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T14.ClienteValorAPagar_F, 0) >= :AV149Wptituloclienteds_55_tfclientevalorapagar_f)");
         }
         else
         {
            GXv_int5[93] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV150Wptituloclienteds_56_tfclientevalorapagar_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T14.ClienteValorAPagar_F, 0) <= :AV150Wptituloclienteds_56_tfclientevalorapagar_f_to)");
         }
         else
         {
            GXv_int5[94] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV151Wptituloclienteds_57_tfclientevalorareceber_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T13.ClienteValorAReceber_F, 0) >= :AV151Wptituloclienteds_57_tfclientevalorareceber_f)");
         }
         else
         {
            GXv_int5[95] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV152Wptituloclienteds_58_tfclientevalorareceber_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T13.ClienteValorAReceber_F, 0) <= :AV152Wptituloclienteds_58_tfclientevalorareceber_f_to)");
         }
         else
         {
            GXv_int5[96] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteDocumento";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P008A29( IGxContext context ,
                                              string A172ClienteTipoPessoa ,
                                              GxSimpleCollection<string> AV141Wptituloclienteds_47_tfclientetipopessoa_sels ,
                                              string AV96Wptituloclienteds_2_dynamicfiltersselector1 ,
                                              short AV97Wptituloclienteds_3_dynamicfiltersoperator1 ,
                                              string AV98Wptituloclienteds_4_clientedocumento1 ,
                                              string AV99Wptituloclienteds_5_tipoclientedescricao1 ,
                                              string AV100Wptituloclienteds_6_clienteconveniodescricao1 ,
                                              string AV101Wptituloclienteds_7_clientenacionalidadenome1 ,
                                              string AV102Wptituloclienteds_8_clienteprofissaonome1 ,
                                              string AV103Wptituloclienteds_9_secusername1 ,
                                              string AV104Wptituloclienteds_10_municipionome1 ,
                                              int AV105Wptituloclienteds_11_bancocodigo1 ,
                                              string AV106Wptituloclienteds_12_responsavelnacionalidadenome1 ,
                                              string AV107Wptituloclienteds_13_responsavelprofissaonome1 ,
                                              string AV108Wptituloclienteds_14_responsavelmunicipionome1 ,
                                              bool AV109Wptituloclienteds_15_dynamicfiltersenabled2 ,
                                              string AV110Wptituloclienteds_16_dynamicfiltersselector2 ,
                                              short AV111Wptituloclienteds_17_dynamicfiltersoperator2 ,
                                              string AV112Wptituloclienteds_18_clientedocumento2 ,
                                              string AV113Wptituloclienteds_19_tipoclientedescricao2 ,
                                              string AV114Wptituloclienteds_20_clienteconveniodescricao2 ,
                                              string AV115Wptituloclienteds_21_clientenacionalidadenome2 ,
                                              string AV116Wptituloclienteds_22_clienteprofissaonome2 ,
                                              string AV117Wptituloclienteds_23_secusername2 ,
                                              string AV118Wptituloclienteds_24_municipionome2 ,
                                              int AV119Wptituloclienteds_25_bancocodigo2 ,
                                              string AV120Wptituloclienteds_26_responsavelnacionalidadenome2 ,
                                              string AV121Wptituloclienteds_27_responsavelprofissaonome2 ,
                                              string AV122Wptituloclienteds_28_responsavelmunicipionome2 ,
                                              bool AV123Wptituloclienteds_29_dynamicfiltersenabled3 ,
                                              string AV124Wptituloclienteds_30_dynamicfiltersselector3 ,
                                              short AV125Wptituloclienteds_31_dynamicfiltersoperator3 ,
                                              string AV126Wptituloclienteds_32_clientedocumento3 ,
                                              string AV127Wptituloclienteds_33_tipoclientedescricao3 ,
                                              string AV128Wptituloclienteds_34_clienteconveniodescricao3 ,
                                              string AV129Wptituloclienteds_35_clientenacionalidadenome3 ,
                                              string AV130Wptituloclienteds_36_clienteprofissaonome3 ,
                                              string AV131Wptituloclienteds_37_secusername3 ,
                                              string AV132Wptituloclienteds_38_municipionome3 ,
                                              int AV133Wptituloclienteds_39_bancocodigo3 ,
                                              string AV134Wptituloclienteds_40_responsavelnacionalidadenome3 ,
                                              string AV135Wptituloclienteds_41_responsavelprofissaonome3 ,
                                              string AV136Wptituloclienteds_42_responsavelmunicipionome3 ,
                                              string AV138Wptituloclienteds_44_tfclienterazaosocial_sel ,
                                              string AV137Wptituloclienteds_43_tfclienterazaosocial ,
                                              string AV140Wptituloclienteds_46_tfclientenomefantasia_sel ,
                                              string AV139Wptituloclienteds_45_tfclientenomefantasia ,
                                              int AV141Wptituloclienteds_47_tfclientetipopessoa_sels_Count ,
                                              string AV143Wptituloclienteds_49_tfclientedocumento_sel ,
                                              string AV142Wptituloclienteds_48_tfclientedocumento ,
                                              string AV145Wptituloclienteds_51_tftipoclientedescricao_sel ,
                                              string AV144Wptituloclienteds_50_tftipoclientedescricao ,
                                              short AV146Wptituloclienteds_52_tfclientestatus_sel ,
                                              decimal AV149Wptituloclienteds_55_tfclientevalorapagar_f ,
                                              decimal AV150Wptituloclienteds_56_tfclientevalorapagar_f_to ,
                                              decimal AV151Wptituloclienteds_57_tfclientevalorareceber_f ,
                                              decimal AV152Wptituloclienteds_58_tfclientevalorareceber_f_to ,
                                              string A169ClienteDocumento ,
                                              string A193TipoClienteDescricao ,
                                              string A490ClienteConvenioDescricao ,
                                              string A485ClienteNacionalidadeNome ,
                                              string A488ClienteProfissaoNome ,
                                              string A141SecUserName ,
                                              string A187MunicipioNome ,
                                              int A404BancoCodigo ,
                                              string A438ResponsavelNacionalidadeNome ,
                                              string A443ResponsavelProfissaoNome ,
                                              string A445ResponsavelMunicipioNome ,
                                              string A170ClienteRazaoSocial ,
                                              string A171ClienteNomeFantasia ,
                                              bool A174ClienteStatus ,
                                              decimal A310ClienteValorAPagar_F ,
                                              decimal A311ClienteValorAReceber_F ,
                                              string AV95Wptituloclienteds_1_filterfulltext ,
                                              int A309ClienteQtdTitulos_F ,
                                              int AV147Wptituloclienteds_53_tfclienteqtdtitulos_f ,
                                              int AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[97];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.EspecialidadeId, T5.EspecialidadeCreatedBy AS EspecialidadeCreatedBy, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.ClienteId, T1.TipoClienteId, T3.MunicipioNome AS ResponsavelMunicipioNome, T9.ProfissaoNome AS ResponsavelProfissaoNome, T7.NacionalidadeNome AS ResponsavelNacionalidadeNome, T4.BancoCodigo, T2.MunicipioNome, T6.SecUserName, T10.ProfissaoNome AS ClienteProfissaoNome, T8.NacionalidadeNome AS ClienteNacionalidadeNome, T11.ConvenioDescricao AS ClienteConvenioDescricao, T1.ClienteStatus, T15.TipoClienteDescricao, T1.ClienteDocumento, T1.ClienteTipoPessoa, T1.ClienteNomeFantasia, T1.ClienteRazaoSocial, COALESCE( T12.ClienteValorAReceber_F, 0) AS ClienteValorAReceber_F, COALESCE( T13.ClienteValorAPagar_F, 0) AS ClienteValorAPagar_F, COALESCE( T14.ClienteQtdTitulos_F, 0) AS ClienteQtdTitulos_F FROM ((((((((((((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = T1.BancoId) LEFT JOIN Especialidade T5 ON T5.EspecialidadeId = T1.EspecialidadeId) LEFT JOIN SecUser T6 ON T6.SecUserId = T5.EspecialidadeCreatedBy) LEFT JOIN Nacionalidade T7 ON T7.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T8 ON T8.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T9 ON T9.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T10 ON T10.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T11 ON T11.ConvenioId = T1.ClienteConvenio)";
         scmdbuf += " LEFT JOIN LATERAL (SELECT SUM(COALESCE( T19.TituloSaldoCredito_F, 0)) AS ClienteValorAReceber_F, T18.ClienteId FROM (((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T20.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T20.TituloValor, 0) - COALESCE( T20.TituloDesconto, 0)) - COALESCE( T21.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoCredito_F, T20.TituloId FROM (Titulo T20 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T20.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T21 ON T21.TituloId = T20.TituloId) ) T19 ON T19.TituloId = T16.TituloId) WHERE T1.ClienteId = T18.ClienteId GROUP BY T18.ClienteId ) T12 ON T12.ClienteId = T1.ClienteId) LEFT JOIN LATERAL (SELECT SUM(CASE  WHEN COALESCE( T16.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE( T16.TituloValor, 0) - COALESCE( T16.TituloDesconto, 0)) - COALESCE( T19.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAPagar_F, T18.ClienteId FROM (((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T16.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T19 ON T19.TituloId = T16.TituloId) WHERE T1.ClienteId = T18.ClienteId GROUP BY T18.ClienteId ) T13 ON T13.ClienteId = T1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteQtdTitulos_F, T18.ClienteId FROM ((Titulo T16 LEFT JOIN NotaFiscalParcelamento T17 ON T17.NotaFiscalParcelamentoID";
         scmdbuf += " = T16.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T18 ON T18.NotaFiscalId = T17.NotaFiscalId) WHERE (T1.ClienteId = T18.ClienteId) AND (Not T16.TituloDeleted) GROUP BY T18.ClienteId ) T14 ON T14.ClienteId = T1.ClienteId) LEFT JOIN TipoCliente T15 ON T15.TipoClienteId = T1.TipoClienteId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV95Wptituloclienteds_1_filterfulltext))=0) or ( ( T1.ClienteRazaoSocial like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( T1.ClienteNomeFantasia like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( 'física' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'FISICA')) or ( 'jurídica' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteTipoPessoa = ( 'JURIDICA')) or ( T1.ClienteDocumento like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( T15.TipoClienteDescricao like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV95Wptituloclienteds_1_filterfulltext) and T1.ClienteStatus = FALSE) or ( SUBSTR(TO_CHAR(COALESCE( T14.ClienteQtdTitulos_F, 0),'999999999'), 2) like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T13.ClienteValorAPagar_F, 0),'999999999999990.99'), 2) like '%' || :lV95Wptituloclienteds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T12.ClienteValorAReceber_F, 0),'999999999999990.99'), 2) like '%' || :lV95Wptituloclienteds_1_filterfulltext)))");
         AddWhere(sWhereString, "((:AV147Wptituloclienteds_53_tfclienteqtdtitulos_f = 0) or ( COALESCE( T14.ClienteQtdTitulos_F, 0) >= :AV147Wptituloclienteds_53_tfclienteqtdtitulos_f))");
         AddWhere(sWhereString, "((:AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to = 0) or ( COALESCE( T14.ClienteQtdTitulos_F, 0) <= :AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to))");
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV98Wptituloclienteds_4_clientedocumento1)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Wptituloclienteds_4_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV98Wptituloclienteds_4_clientedocumento1)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T15.TipoClienteDescricao like :lV99Wptituloclienteds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Wptituloclienteds_5_tipoclientedescricao1)) ) )
         {
            AddWhere(sWhereString, "(T15.TipoClienteDescricao like '%' || :lV99Wptituloclienteds_5_tipoclientedescricao1)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T11.ConvenioDescricao like :lV100Wptituloclienteds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Wptituloclienteds_6_clienteconveniodescricao1)) ) )
         {
            AddWhere(sWhereString, "(T11.ConvenioDescricao like '%' || :lV100Wptituloclienteds_6_clienteconveniodescricao1)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV101Wptituloclienteds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Wptituloclienteds_7_clientenacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV101Wptituloclienteds_7_clientenacionalidadenome1)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV102Wptituloclienteds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Wptituloclienteds_8_clienteprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV102Wptituloclienteds_8_clienteprofissaonome1)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like :lV103Wptituloclienteds_9_secusername1)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Wptituloclienteds_9_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like '%' || :lV103Wptituloclienteds_9_secusername1)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV104Wptituloclienteds_10_municipionome1)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "MUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Wptituloclienteds_10_municipionome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV104Wptituloclienteds_10_municipionome1)");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV105Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV105Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV105Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV105Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "BANCOCODIGO") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV105Wptituloclienteds_11_bancocodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV105Wptituloclienteds_11_bancocodigo1)");
         }
         else
         {
            GXv_int7[32] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV106Wptituloclienteds_12_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int7[33] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Wptituloclienteds_12_responsavelnacionalidadenome1)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV106Wptituloclienteds_12_responsavelnacionalidadenome1)");
         }
         else
         {
            GXv_int7[34] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV107Wptituloclienteds_13_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int7[35] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Wptituloclienteds_13_responsavelprofissaonome1)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV107Wptituloclienteds_13_responsavelprofissaonome1)");
         }
         else
         {
            GXv_int7[36] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV108Wptituloclienteds_14_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int7[37] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Wptituloclienteds_2_dynamicfiltersselector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV97Wptituloclienteds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Wptituloclienteds_14_responsavelmunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV108Wptituloclienteds_14_responsavelmunicipionome1)");
         }
         else
         {
            GXv_int7[38] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV112Wptituloclienteds_18_clientedocumento2)");
         }
         else
         {
            GXv_int7[39] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Wptituloclienteds_18_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV112Wptituloclienteds_18_clientedocumento2)");
         }
         else
         {
            GXv_int7[40] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T15.TipoClienteDescricao like :lV113Wptituloclienteds_19_tipoclientedescricao2)");
         }
         else
         {
            GXv_int7[41] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Wptituloclienteds_19_tipoclientedescricao2)) ) )
         {
            AddWhere(sWhereString, "(T15.TipoClienteDescricao like '%' || :lV113Wptituloclienteds_19_tipoclientedescricao2)");
         }
         else
         {
            GXv_int7[42] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T11.ConvenioDescricao like :lV114Wptituloclienteds_20_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int7[43] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Wptituloclienteds_20_clienteconveniodescricao2)) ) )
         {
            AddWhere(sWhereString, "(T11.ConvenioDescricao like '%' || :lV114Wptituloclienteds_20_clienteconveniodescricao2)");
         }
         else
         {
            GXv_int7[44] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV115Wptituloclienteds_21_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int7[45] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Wptituloclienteds_21_clientenacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV115Wptituloclienteds_21_clientenacionalidadenome2)");
         }
         else
         {
            GXv_int7[46] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV116Wptituloclienteds_22_clienteprofissaonome2)");
         }
         else
         {
            GXv_int7[47] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Wptituloclienteds_22_clienteprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV116Wptituloclienteds_22_clienteprofissaonome2)");
         }
         else
         {
            GXv_int7[48] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like :lV117Wptituloclienteds_23_secusername2)");
         }
         else
         {
            GXv_int7[49] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Wptituloclienteds_23_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like '%' || :lV117Wptituloclienteds_23_secusername2)");
         }
         else
         {
            GXv_int7[50] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV118Wptituloclienteds_24_municipionome2)");
         }
         else
         {
            GXv_int7[51] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "MUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Wptituloclienteds_24_municipionome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV118Wptituloclienteds_24_municipionome2)");
         }
         else
         {
            GXv_int7[52] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV119Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV119Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int7[53] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV119Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV119Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int7[54] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "BANCOCODIGO") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV119Wptituloclienteds_25_bancocodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV119Wptituloclienteds_25_bancocodigo2)");
         }
         else
         {
            GXv_int7[55] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV120Wptituloclienteds_26_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int7[56] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Wptituloclienteds_26_responsavelnacionalidadenome2)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV120Wptituloclienteds_26_responsavelnacionalidadenome2)");
         }
         else
         {
            GXv_int7[57] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV121Wptituloclienteds_27_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int7[58] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Wptituloclienteds_27_responsavelprofissaonome2)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV121Wptituloclienteds_27_responsavelprofissaonome2)");
         }
         else
         {
            GXv_int7[59] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV122Wptituloclienteds_28_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int7[60] = 1;
         }
         if ( AV109Wptituloclienteds_15_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV110Wptituloclienteds_16_dynamicfiltersselector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV111Wptituloclienteds_17_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Wptituloclienteds_28_responsavelmunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV122Wptituloclienteds_28_responsavelmunicipionome2)");
         }
         else
         {
            GXv_int7[61] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV126Wptituloclienteds_32_clientedocumento3)");
         }
         else
         {
            GXv_int7[62] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Wptituloclienteds_32_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV126Wptituloclienteds_32_clientedocumento3)");
         }
         else
         {
            GXv_int7[63] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T15.TipoClienteDescricao like :lV127Wptituloclienteds_33_tipoclientedescricao3)");
         }
         else
         {
            GXv_int7[64] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Wptituloclienteds_33_tipoclientedescricao3)) ) )
         {
            AddWhere(sWhereString, "(T15.TipoClienteDescricao like '%' || :lV127Wptituloclienteds_33_tipoclientedescricao3)");
         }
         else
         {
            GXv_int7[65] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T11.ConvenioDescricao like :lV128Wptituloclienteds_34_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int7[66] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Wptituloclienteds_34_clienteconveniodescricao3)) ) )
         {
            AddWhere(sWhereString, "(T11.ConvenioDescricao like '%' || :lV128Wptituloclienteds_34_clienteconveniodescricao3)");
         }
         else
         {
            GXv_int7[67] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like :lV129Wptituloclienteds_35_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int7[68] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Wptituloclienteds_35_clientenacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T8.NacionalidadeNome like '%' || :lV129Wptituloclienteds_35_clientenacionalidadenome3)");
         }
         else
         {
            GXv_int7[69] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like :lV130Wptituloclienteds_36_clienteprofissaonome3)");
         }
         else
         {
            GXv_int7[70] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Wptituloclienteds_36_clienteprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T10.ProfissaoNome like '%' || :lV130Wptituloclienteds_36_clienteprofissaonome3)");
         }
         else
         {
            GXv_int7[71] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like :lV131Wptituloclienteds_37_secusername3)");
         }
         else
         {
            GXv_int7[72] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Wptituloclienteds_37_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T6.SecUserName like '%' || :lV131Wptituloclienteds_37_secusername3)");
         }
         else
         {
            GXv_int7[73] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV132Wptituloclienteds_38_municipionome3)");
         }
         else
         {
            GXv_int7[74] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "MUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Wptituloclienteds_38_municipionome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV132Wptituloclienteds_38_municipionome3)");
         }
         else
         {
            GXv_int7[75] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV133Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV133Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int7[76] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV133Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV133Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int7[77] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "BANCOCODIGO") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV133Wptituloclienteds_39_bancocodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV133Wptituloclienteds_39_bancocodigo3)");
         }
         else
         {
            GXv_int7[78] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like :lV134Wptituloclienteds_40_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int7[79] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Wptituloclienteds_40_responsavelnacionalidadenome3)) ) )
         {
            AddWhere(sWhereString, "(T7.NacionalidadeNome like '%' || :lV134Wptituloclienteds_40_responsavelnacionalidadenome3)");
         }
         else
         {
            GXv_int7[80] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like :lV135Wptituloclienteds_41_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int7[81] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Wptituloclienteds_41_responsavelprofissaonome3)) ) )
         {
            AddWhere(sWhereString, "(T9.ProfissaoNome like '%' || :lV135Wptituloclienteds_41_responsavelprofissaonome3)");
         }
         else
         {
            GXv_int7[82] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV136Wptituloclienteds_42_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int7[83] = 1;
         }
         if ( AV123Wptituloclienteds_29_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV124Wptituloclienteds_30_dynamicfiltersselector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV125Wptituloclienteds_31_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Wptituloclienteds_42_responsavelmunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV136Wptituloclienteds_42_responsavelmunicipionome3)");
         }
         else
         {
            GXv_int7[84] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV138Wptituloclienteds_44_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Wptituloclienteds_43_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV137Wptituloclienteds_43_tfclienterazaosocial)");
         }
         else
         {
            GXv_int7[85] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Wptituloclienteds_44_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV138Wptituloclienteds_44_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV138Wptituloclienteds_44_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int7[86] = 1;
         }
         if ( StringUtil.StrCmp(AV138Wptituloclienteds_44_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Wptituloclienteds_46_tfclientenomefantasia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Wptituloclienteds_45_tfclientenomefantasia)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia like :lV139Wptituloclienteds_45_tfclientenomefantasia)");
         }
         else
         {
            GXv_int7[87] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Wptituloclienteds_46_tfclientenomefantasia_sel)) && ! ( StringUtil.StrCmp(AV140Wptituloclienteds_46_tfclientenomefantasia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia = ( :AV140Wptituloclienteds_46_tfclientenomefantasia_sel))");
         }
         else
         {
            GXv_int7[88] = 1;
         }
         if ( StringUtil.StrCmp(AV140Wptituloclienteds_46_tfclientenomefantasia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia IS NULL or (char_length(trim(trailing ' ' from T1.ClienteNomeFantasia))=0))");
         }
         if ( AV141Wptituloclienteds_47_tfclientetipopessoa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV141Wptituloclienteds_47_tfclientetipopessoa_sels, "T1.ClienteTipoPessoa IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Wptituloclienteds_49_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Wptituloclienteds_48_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV142Wptituloclienteds_48_tfclientedocumento)");
         }
         else
         {
            GXv_int7[89] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Wptituloclienteds_49_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV143Wptituloclienteds_49_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV143Wptituloclienteds_49_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int7[90] = 1;
         }
         if ( StringUtil.StrCmp(AV143Wptituloclienteds_49_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV145Wptituloclienteds_51_tftipoclientedescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Wptituloclienteds_50_tftipoclientedescricao)) ) )
         {
            AddWhere(sWhereString, "(T15.TipoClienteDescricao like :lV144Wptituloclienteds_50_tftipoclientedescricao)");
         }
         else
         {
            GXv_int7[91] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Wptituloclienteds_51_tftipoclientedescricao_sel)) && ! ( StringUtil.StrCmp(AV145Wptituloclienteds_51_tftipoclientedescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T15.TipoClienteDescricao = ( :AV145Wptituloclienteds_51_tftipoclientedescricao_sel))");
         }
         else
         {
            GXv_int7[92] = 1;
         }
         if ( StringUtil.StrCmp(AV145Wptituloclienteds_51_tftipoclientedescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T15.TipoClienteDescricao IS NULL or (char_length(trim(trailing ' ' from T15.TipoClienteDescricao))=0))");
         }
         if ( AV146Wptituloclienteds_52_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV146Wptituloclienteds_52_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         if ( ! (Convert.ToDecimal(0)==AV149Wptituloclienteds_55_tfclientevalorapagar_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T13.ClienteValorAPagar_F, 0) >= :AV149Wptituloclienteds_55_tfclientevalorapagar_f)");
         }
         else
         {
            GXv_int7[93] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV150Wptituloclienteds_56_tfclientevalorapagar_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T13.ClienteValorAPagar_F, 0) <= :AV150Wptituloclienteds_56_tfclientevalorapagar_f_to)");
         }
         else
         {
            GXv_int7[94] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV151Wptituloclienteds_57_tfclientevalorareceber_f) )
         {
            AddWhere(sWhereString, "(COALESCE( T12.ClienteValorAReceber_F, 0) >= :AV151Wptituloclienteds_57_tfclientevalorareceber_f)");
         }
         else
         {
            GXv_int7[95] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV152Wptituloclienteds_58_tfclientevalorareceber_f_to) )
         {
            AddWhere(sWhereString, "(COALESCE( T12.ClienteValorAReceber_F, 0) <= :AV152Wptituloclienteds_58_tfclientevalorareceber_f_to)");
         }
         else
         {
            GXv_int7[96] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TipoClienteId";
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
                     return conditional_P008A8(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (short)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (decimal)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (int)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (bool)dynConstraints[70] , (decimal)dynConstraints[71] , (decimal)dynConstraints[72] , (string)dynConstraints[73] , (int)dynConstraints[74] , (int)dynConstraints[75] , (int)dynConstraints[76] );
               case 1 :
                     return conditional_P008A15(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (short)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (decimal)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (int)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (bool)dynConstraints[70] , (decimal)dynConstraints[71] , (decimal)dynConstraints[72] , (string)dynConstraints[73] , (int)dynConstraints[74] , (int)dynConstraints[75] , (int)dynConstraints[76] );
               case 2 :
                     return conditional_P008A22(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (short)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (decimal)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (int)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (bool)dynConstraints[70] , (decimal)dynConstraints[71] , (decimal)dynConstraints[72] , (string)dynConstraints[73] , (int)dynConstraints[74] , (int)dynConstraints[75] , (int)dynConstraints[76] );
               case 3 :
                     return conditional_P008A29(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (int)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (short)dynConstraints[52] , (decimal)dynConstraints[53] , (decimal)dynConstraints[54] , (decimal)dynConstraints[55] , (decimal)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (int)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (bool)dynConstraints[70] , (decimal)dynConstraints[71] , (decimal)dynConstraints[72] , (string)dynConstraints[73] , (int)dynConstraints[74] , (int)dynConstraints[75] , (int)dynConstraints[76] );
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
          Object[] prmP008A8;
          prmP008A8 = new Object[] {
          new ParDef("AV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV147Wptituloclienteds_53_tfclienteqtdtitulos_f",GXType.Int32,9,0) ,
          new ParDef("AV147Wptituloclienteds_53_tfclienteqtdtitulos_f",GXType.Int32,9,0) ,
          new ParDef("AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to",GXType.Int32,9,0) ,
          new ParDef("AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to",GXType.Int32,9,0) ,
          new ParDef("lV98Wptituloclienteds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV98Wptituloclienteds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV99Wptituloclienteds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV99Wptituloclienteds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV100Wptituloclienteds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV100Wptituloclienteds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV101Wptituloclienteds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV101Wptituloclienteds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV102Wptituloclienteds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV102Wptituloclienteds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV103Wptituloclienteds_9_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV103Wptituloclienteds_9_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV104Wptituloclienteds_10_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV104Wptituloclienteds_10_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV105Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV105Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV105Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV106Wptituloclienteds_12_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV106Wptituloclienteds_12_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV107Wptituloclienteds_13_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV107Wptituloclienteds_13_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV108Wptituloclienteds_14_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV108Wptituloclienteds_14_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV112Wptituloclienteds_18_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV112Wptituloclienteds_18_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV113Wptituloclienteds_19_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV113Wptituloclienteds_19_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV114Wptituloclienteds_20_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV114Wptituloclienteds_20_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV115Wptituloclienteds_21_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV115Wptituloclienteds_21_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV116Wptituloclienteds_22_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV116Wptituloclienteds_22_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV117Wptituloclienteds_23_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV117Wptituloclienteds_23_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV118Wptituloclienteds_24_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV118Wptituloclienteds_24_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV119Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV119Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV119Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV120Wptituloclienteds_26_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV120Wptituloclienteds_26_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV121Wptituloclienteds_27_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV121Wptituloclienteds_27_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV122Wptituloclienteds_28_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV122Wptituloclienteds_28_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV126Wptituloclienteds_32_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV126Wptituloclienteds_32_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV127Wptituloclienteds_33_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV127Wptituloclienteds_33_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV128Wptituloclienteds_34_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV128Wptituloclienteds_34_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV129Wptituloclienteds_35_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV129Wptituloclienteds_35_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV130Wptituloclienteds_36_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV130Wptituloclienteds_36_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV131Wptituloclienteds_37_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV131Wptituloclienteds_37_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV132Wptituloclienteds_38_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV132Wptituloclienteds_38_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV133Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV133Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV133Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV134Wptituloclienteds_40_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV134Wptituloclienteds_40_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV135Wptituloclienteds_41_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV135Wptituloclienteds_41_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV136Wptituloclienteds_42_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV136Wptituloclienteds_42_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV137Wptituloclienteds_43_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV138Wptituloclienteds_44_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV139Wptituloclienteds_45_tfclientenomefantasia",GXType.VarChar,150,0) ,
          new ParDef("AV140Wptituloclienteds_46_tfclientenomefantasia_sel",GXType.VarChar,150,0) ,
          new ParDef("lV142Wptituloclienteds_48_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV143Wptituloclienteds_49_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("lV144Wptituloclienteds_50_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV145Wptituloclienteds_51_tftipoclientedescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV149Wptituloclienteds_55_tfclientevalorapagar_f",GXType.Number,18,2) ,
          new ParDef("AV150Wptituloclienteds_56_tfclientevalorapagar_f_to",GXType.Number,18,2) ,
          new ParDef("AV151Wptituloclienteds_57_tfclientevalorareceber_f",GXType.Number,18,2) ,
          new ParDef("AV152Wptituloclienteds_58_tfclientevalorareceber_f_to",GXType.Number,18,2)
          };
          Object[] prmP008A15;
          prmP008A15 = new Object[] {
          new ParDef("AV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV147Wptituloclienteds_53_tfclienteqtdtitulos_f",GXType.Int32,9,0) ,
          new ParDef("AV147Wptituloclienteds_53_tfclienteqtdtitulos_f",GXType.Int32,9,0) ,
          new ParDef("AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to",GXType.Int32,9,0) ,
          new ParDef("AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to",GXType.Int32,9,0) ,
          new ParDef("lV98Wptituloclienteds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV98Wptituloclienteds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV99Wptituloclienteds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV99Wptituloclienteds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV100Wptituloclienteds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV100Wptituloclienteds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV101Wptituloclienteds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV101Wptituloclienteds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV102Wptituloclienteds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV102Wptituloclienteds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV103Wptituloclienteds_9_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV103Wptituloclienteds_9_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV104Wptituloclienteds_10_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV104Wptituloclienteds_10_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV105Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV105Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV105Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV106Wptituloclienteds_12_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV106Wptituloclienteds_12_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV107Wptituloclienteds_13_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV107Wptituloclienteds_13_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV108Wptituloclienteds_14_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV108Wptituloclienteds_14_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV112Wptituloclienteds_18_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV112Wptituloclienteds_18_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV113Wptituloclienteds_19_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV113Wptituloclienteds_19_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV114Wptituloclienteds_20_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV114Wptituloclienteds_20_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV115Wptituloclienteds_21_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV115Wptituloclienteds_21_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV116Wptituloclienteds_22_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV116Wptituloclienteds_22_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV117Wptituloclienteds_23_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV117Wptituloclienteds_23_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV118Wptituloclienteds_24_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV118Wptituloclienteds_24_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV119Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV119Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV119Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV120Wptituloclienteds_26_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV120Wptituloclienteds_26_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV121Wptituloclienteds_27_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV121Wptituloclienteds_27_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV122Wptituloclienteds_28_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV122Wptituloclienteds_28_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV126Wptituloclienteds_32_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV126Wptituloclienteds_32_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV127Wptituloclienteds_33_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV127Wptituloclienteds_33_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV128Wptituloclienteds_34_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV128Wptituloclienteds_34_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV129Wptituloclienteds_35_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV129Wptituloclienteds_35_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV130Wptituloclienteds_36_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV130Wptituloclienteds_36_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV131Wptituloclienteds_37_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV131Wptituloclienteds_37_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV132Wptituloclienteds_38_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV132Wptituloclienteds_38_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV133Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV133Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV133Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV134Wptituloclienteds_40_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV134Wptituloclienteds_40_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV135Wptituloclienteds_41_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV135Wptituloclienteds_41_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV136Wptituloclienteds_42_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV136Wptituloclienteds_42_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV137Wptituloclienteds_43_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV138Wptituloclienteds_44_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV139Wptituloclienteds_45_tfclientenomefantasia",GXType.VarChar,150,0) ,
          new ParDef("AV140Wptituloclienteds_46_tfclientenomefantasia_sel",GXType.VarChar,150,0) ,
          new ParDef("lV142Wptituloclienteds_48_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV143Wptituloclienteds_49_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("lV144Wptituloclienteds_50_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV145Wptituloclienteds_51_tftipoclientedescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV149Wptituloclienteds_55_tfclientevalorapagar_f",GXType.Number,18,2) ,
          new ParDef("AV150Wptituloclienteds_56_tfclientevalorapagar_f_to",GXType.Number,18,2) ,
          new ParDef("AV151Wptituloclienteds_57_tfclientevalorareceber_f",GXType.Number,18,2) ,
          new ParDef("AV152Wptituloclienteds_58_tfclientevalorareceber_f_to",GXType.Number,18,2)
          };
          Object[] prmP008A22;
          prmP008A22 = new Object[] {
          new ParDef("AV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV147Wptituloclienteds_53_tfclienteqtdtitulos_f",GXType.Int32,9,0) ,
          new ParDef("AV147Wptituloclienteds_53_tfclienteqtdtitulos_f",GXType.Int32,9,0) ,
          new ParDef("AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to",GXType.Int32,9,0) ,
          new ParDef("AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to",GXType.Int32,9,0) ,
          new ParDef("lV98Wptituloclienteds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV98Wptituloclienteds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV99Wptituloclienteds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV99Wptituloclienteds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV100Wptituloclienteds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV100Wptituloclienteds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV101Wptituloclienteds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV101Wptituloclienteds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV102Wptituloclienteds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV102Wptituloclienteds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV103Wptituloclienteds_9_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV103Wptituloclienteds_9_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV104Wptituloclienteds_10_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV104Wptituloclienteds_10_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV105Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV105Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV105Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV106Wptituloclienteds_12_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV106Wptituloclienteds_12_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV107Wptituloclienteds_13_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV107Wptituloclienteds_13_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV108Wptituloclienteds_14_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV108Wptituloclienteds_14_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV112Wptituloclienteds_18_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV112Wptituloclienteds_18_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV113Wptituloclienteds_19_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV113Wptituloclienteds_19_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV114Wptituloclienteds_20_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV114Wptituloclienteds_20_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV115Wptituloclienteds_21_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV115Wptituloclienteds_21_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV116Wptituloclienteds_22_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV116Wptituloclienteds_22_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV117Wptituloclienteds_23_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV117Wptituloclienteds_23_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV118Wptituloclienteds_24_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV118Wptituloclienteds_24_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV119Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV119Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV119Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV120Wptituloclienteds_26_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV120Wptituloclienteds_26_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV121Wptituloclienteds_27_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV121Wptituloclienteds_27_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV122Wptituloclienteds_28_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV122Wptituloclienteds_28_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV126Wptituloclienteds_32_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV126Wptituloclienteds_32_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV127Wptituloclienteds_33_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV127Wptituloclienteds_33_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV128Wptituloclienteds_34_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV128Wptituloclienteds_34_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV129Wptituloclienteds_35_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV129Wptituloclienteds_35_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV130Wptituloclienteds_36_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV130Wptituloclienteds_36_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV131Wptituloclienteds_37_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV131Wptituloclienteds_37_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV132Wptituloclienteds_38_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV132Wptituloclienteds_38_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV133Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV133Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV133Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV134Wptituloclienteds_40_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV134Wptituloclienteds_40_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV135Wptituloclienteds_41_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV135Wptituloclienteds_41_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV136Wptituloclienteds_42_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV136Wptituloclienteds_42_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV137Wptituloclienteds_43_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV138Wptituloclienteds_44_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV139Wptituloclienteds_45_tfclientenomefantasia",GXType.VarChar,150,0) ,
          new ParDef("AV140Wptituloclienteds_46_tfclientenomefantasia_sel",GXType.VarChar,150,0) ,
          new ParDef("lV142Wptituloclienteds_48_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV143Wptituloclienteds_49_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("lV144Wptituloclienteds_50_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV145Wptituloclienteds_51_tftipoclientedescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV149Wptituloclienteds_55_tfclientevalorapagar_f",GXType.Number,18,2) ,
          new ParDef("AV150Wptituloclienteds_56_tfclientevalorapagar_f_to",GXType.Number,18,2) ,
          new ParDef("AV151Wptituloclienteds_57_tfclientevalorareceber_f",GXType.Number,18,2) ,
          new ParDef("AV152Wptituloclienteds_58_tfclientevalorareceber_f_to",GXType.Number,18,2)
          };
          Object[] prmP008A29;
          prmP008A29 = new Object[] {
          new ParDef("AV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV95Wptituloclienteds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV147Wptituloclienteds_53_tfclienteqtdtitulos_f",GXType.Int32,9,0) ,
          new ParDef("AV147Wptituloclienteds_53_tfclienteqtdtitulos_f",GXType.Int32,9,0) ,
          new ParDef("AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to",GXType.Int32,9,0) ,
          new ParDef("AV148Wptituloclienteds_54_tfclienteqtdtitulos_f_to",GXType.Int32,9,0) ,
          new ParDef("lV98Wptituloclienteds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV98Wptituloclienteds_4_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV99Wptituloclienteds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV99Wptituloclienteds_5_tipoclientedescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV100Wptituloclienteds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV100Wptituloclienteds_6_clienteconveniodescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV101Wptituloclienteds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV101Wptituloclienteds_7_clientenacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV102Wptituloclienteds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV102Wptituloclienteds_8_clienteprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV103Wptituloclienteds_9_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV103Wptituloclienteds_9_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV104Wptituloclienteds_10_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV104Wptituloclienteds_10_municipionome1",GXType.VarChar,150,0) ,
          new ParDef("AV105Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV105Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("AV105Wptituloclienteds_11_bancocodigo1",GXType.Int32,9,0) ,
          new ParDef("lV106Wptituloclienteds_12_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV106Wptituloclienteds_12_responsavelnacionalidadenome1",GXType.VarChar,100,0) ,
          new ParDef("lV107Wptituloclienteds_13_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV107Wptituloclienteds_13_responsavelprofissaonome1",GXType.VarChar,90,0) ,
          new ParDef("lV108Wptituloclienteds_14_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV108Wptituloclienteds_14_responsavelmunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV112Wptituloclienteds_18_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV112Wptituloclienteds_18_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV113Wptituloclienteds_19_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV113Wptituloclienteds_19_tipoclientedescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV114Wptituloclienteds_20_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV114Wptituloclienteds_20_clienteconveniodescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV115Wptituloclienteds_21_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV115Wptituloclienteds_21_clientenacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV116Wptituloclienteds_22_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV116Wptituloclienteds_22_clienteprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV117Wptituloclienteds_23_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV117Wptituloclienteds_23_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV118Wptituloclienteds_24_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV118Wptituloclienteds_24_municipionome2",GXType.VarChar,150,0) ,
          new ParDef("AV119Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV119Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("AV119Wptituloclienteds_25_bancocodigo2",GXType.Int32,9,0) ,
          new ParDef("lV120Wptituloclienteds_26_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV120Wptituloclienteds_26_responsavelnacionalidadenome2",GXType.VarChar,100,0) ,
          new ParDef("lV121Wptituloclienteds_27_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV121Wptituloclienteds_27_responsavelprofissaonome2",GXType.VarChar,90,0) ,
          new ParDef("lV122Wptituloclienteds_28_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV122Wptituloclienteds_28_responsavelmunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV126Wptituloclienteds_32_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV126Wptituloclienteds_32_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV127Wptituloclienteds_33_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV127Wptituloclienteds_33_tipoclientedescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV128Wptituloclienteds_34_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV128Wptituloclienteds_34_clienteconveniodescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV129Wptituloclienteds_35_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV129Wptituloclienteds_35_clientenacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV130Wptituloclienteds_36_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV130Wptituloclienteds_36_clienteprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV131Wptituloclienteds_37_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV131Wptituloclienteds_37_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV132Wptituloclienteds_38_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV132Wptituloclienteds_38_municipionome3",GXType.VarChar,150,0) ,
          new ParDef("AV133Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV133Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("AV133Wptituloclienteds_39_bancocodigo3",GXType.Int32,9,0) ,
          new ParDef("lV134Wptituloclienteds_40_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV134Wptituloclienteds_40_responsavelnacionalidadenome3",GXType.VarChar,100,0) ,
          new ParDef("lV135Wptituloclienteds_41_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV135Wptituloclienteds_41_responsavelprofissaonome3",GXType.VarChar,90,0) ,
          new ParDef("lV136Wptituloclienteds_42_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV136Wptituloclienteds_42_responsavelmunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV137Wptituloclienteds_43_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV138Wptituloclienteds_44_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV139Wptituloclienteds_45_tfclientenomefantasia",GXType.VarChar,150,0) ,
          new ParDef("AV140Wptituloclienteds_46_tfclientenomefantasia_sel",GXType.VarChar,150,0) ,
          new ParDef("lV142Wptituloclienteds_48_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV143Wptituloclienteds_49_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("lV144Wptituloclienteds_50_tftipoclientedescricao",GXType.VarChar,150,0) ,
          new ParDef("AV145Wptituloclienteds_51_tftipoclientedescricao_sel",GXType.VarChar,150,0) ,
          new ParDef("AV149Wptituloclienteds_55_tfclientevalorapagar_f",GXType.Number,18,2) ,
          new ParDef("AV150Wptituloclienteds_56_tfclientevalorapagar_f_to",GXType.Number,18,2) ,
          new ParDef("AV151Wptituloclienteds_57_tfclientevalorareceber_f",GXType.Number,18,2) ,
          new ParDef("AV152Wptituloclienteds_58_tfclientevalorareceber_f_to",GXType.Number,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P008A8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008A15", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008A22", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A22,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008A29", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008A29,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[10])[0] = rslt.getShort(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
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
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((int[]) buf[57])[0] = rslt.getInt(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
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
                ((short[]) buf[10])[0] = rslt.getShort(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
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
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((int[]) buf[57])[0] = rslt.getInt(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
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
                ((short[]) buf[10])[0] = rslt.getShort(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
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
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((int[]) buf[57])[0] = rslt.getInt(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
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
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((bool[]) buf[41])[0] = rslt.getBool(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((int[]) buf[57])[0] = rslt.getInt(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                return;
       }
    }

 }

}
