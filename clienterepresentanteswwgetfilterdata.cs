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
   public class clienterepresentanteswwgetfilterdata : GXProcedure
   {
      public clienterepresentanteswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clienterepresentanteswwgetfilterdata( IGxContext context )
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
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV50OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV35Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32MaxItems = 10;
         AV31PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV46SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV29SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? "" : StringUtil.Substring( AV46SearchTxtParms, 3, -1));
         AV30SkipItems = (short)(AV31PageIndex*AV32MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_RESPONSAVELNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESPONSAVELNOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_RESPONSAVELCPF") == 0 )
         {
            /* Execute user subroutine: 'LOADRESPONSAVELCPFOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_RESPONSAVELCELULAR_F") == 0 )
         {
            /* Execute user subroutine: 'LOADRESPONSAVELCELULAR_FOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_RESPONSAVELEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADRESPONSAVELEMAILOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_CLIENTEDOCUMENTO") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTEDOCUMENTOOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_CLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTERAZAOSOCIALOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV48OptionsJson = AV35Options.ToJSonString(false);
         AV49OptionsDescJson = AV37OptionsDesc.ToJSonString(false);
         AV50OptionIndexesJson = AV38OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get("ClienteRepresentantesWWGridState"), "") == 0 )
         {
            AV42GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ClienteRepresentantesWWGridState"), null, "", "");
         }
         else
         {
            AV42GridState.FromXml(AV40Session.Get("ClienteRepresentantesWWGridState"), null, "", "");
         }
         AV91GXV1 = 1;
         while ( AV91GXV1 <= AV42GridState.gxTpr_Filtervalues.Count )
         {
            AV43GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV42GridState.gxTpr_Filtervalues.Item(AV91GXV1));
            if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV51FilterFullText = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TIPOCLIENTEID") == 0 )
            {
               AV90TipoClienteId = (short)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME") == 0 )
            {
               AV10TFResponsavelNome = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME_SEL") == 0 )
            {
               AV11TFResponsavelNome_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCPF") == 0 )
            {
               AV12TFResponsavelCPF = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCPF_SEL") == 0 )
            {
               AV13TFResponsavelCPF_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCELULAR_F") == 0 )
            {
               AV14TFResponsavelCelular_F = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCELULAR_F_SEL") == 0 )
            {
               AV15TFResponsavelCelular_F_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL") == 0 )
            {
               AV16TFResponsavelEmail = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL_SEL") == 0 )
            {
               AV17TFResponsavelEmail_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCARGO_SEL") == 0 )
            {
               AV18TFResponsavelCargo_SelsJson = AV43GridStateFilterValue.gxTpr_Value;
               AV19TFResponsavelCargo_Sels.FromJSonString(AV18TFResponsavelCargo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV20TFClienteDocumento = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV21TFClienteDocumento_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV22TFClienteRazaoSocial = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV23TFClienteRazaoSocial_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCLIENTESITUACAO_SEL") == 0 )
            {
               AV27TFClienteSituacao_SelsJson = AV43GridStateFilterValue.gxTpr_Value;
               AV28TFClienteSituacao_Sels.FromJSonString(AV27TFClienteSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCLIENTESTATUS_SEL") == 0 )
            {
               AV26TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV91GXV1 = (int)(AV91GXV1+1);
         }
         if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV44GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(1));
            AV52DynamicFiltersSelector1 = AV44GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
            {
               AV53DynamicFiltersOperator1 = AV44GridStateDynamicFilter.gxTpr_Operator;
               AV54ClienteDocumento1 = AV44GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 )
            {
               AV53DynamicFiltersOperator1 = AV44GridStateDynamicFilter.gxTpr_Operator;
               AV55TipoClienteDescricao1 = AV44GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 )
            {
               AV53DynamicFiltersOperator1 = AV44GridStateDynamicFilter.gxTpr_Operator;
               AV56ClienteConvenioDescricao1 = AV44GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 )
            {
               AV53DynamicFiltersOperator1 = AV44GridStateDynamicFilter.gxTpr_Operator;
               AV57ClienteNacionalidadeNome1 = AV44GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 )
            {
               AV53DynamicFiltersOperator1 = AV44GridStateDynamicFilter.gxTpr_Operator;
               AV58ClienteProfissaoNome1 = AV44GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "MUNICIPIONOME") == 0 )
            {
               AV53DynamicFiltersOperator1 = AV44GridStateDynamicFilter.gxTpr_Operator;
               AV59MunicipioNome1 = AV44GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 )
            {
               AV53DynamicFiltersOperator1 = AV44GridStateDynamicFilter.gxTpr_Operator;
               AV60BancoCodigo1 = (int)(Math.Round(NumberUtil.Val( AV44GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 )
            {
               AV53DynamicFiltersOperator1 = AV44GridStateDynamicFilter.gxTpr_Operator;
               AV61ResponsavelNacionalidadeNome1 = AV44GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 )
            {
               AV53DynamicFiltersOperator1 = AV44GridStateDynamicFilter.gxTpr_Operator;
               AV62ResponsavelProfissaoNome1 = AV44GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 )
            {
               AV53DynamicFiltersOperator1 = AV44GridStateDynamicFilter.gxTpr_Operator;
               AV63ResponsavelMunicipioNome1 = AV44GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV64DynamicFiltersEnabled2 = true;
               AV44GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(2));
               AV65DynamicFiltersSelector2 = AV44GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
               {
                  AV66DynamicFiltersOperator2 = AV44GridStateDynamicFilter.gxTpr_Operator;
                  AV67ClienteDocumento2 = AV44GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 )
               {
                  AV66DynamicFiltersOperator2 = AV44GridStateDynamicFilter.gxTpr_Operator;
                  AV68TipoClienteDescricao2 = AV44GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 )
               {
                  AV66DynamicFiltersOperator2 = AV44GridStateDynamicFilter.gxTpr_Operator;
                  AV69ClienteConvenioDescricao2 = AV44GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 )
               {
                  AV66DynamicFiltersOperator2 = AV44GridStateDynamicFilter.gxTpr_Operator;
                  AV70ClienteNacionalidadeNome2 = AV44GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 )
               {
                  AV66DynamicFiltersOperator2 = AV44GridStateDynamicFilter.gxTpr_Operator;
                  AV71ClienteProfissaoNome2 = AV44GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "MUNICIPIONOME") == 0 )
               {
                  AV66DynamicFiltersOperator2 = AV44GridStateDynamicFilter.gxTpr_Operator;
                  AV72MunicipioNome2 = AV44GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 )
               {
                  AV66DynamicFiltersOperator2 = AV44GridStateDynamicFilter.gxTpr_Operator;
                  AV73BancoCodigo2 = (int)(Math.Round(NumberUtil.Val( AV44GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 )
               {
                  AV66DynamicFiltersOperator2 = AV44GridStateDynamicFilter.gxTpr_Operator;
                  AV74ResponsavelNacionalidadeNome2 = AV44GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 )
               {
                  AV66DynamicFiltersOperator2 = AV44GridStateDynamicFilter.gxTpr_Operator;
                  AV75ResponsavelProfissaoNome2 = AV44GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 )
               {
                  AV66DynamicFiltersOperator2 = AV44GridStateDynamicFilter.gxTpr_Operator;
                  AV76ResponsavelMunicipioNome2 = AV44GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV77DynamicFiltersEnabled3 = true;
                  AV44GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(3));
                  AV78DynamicFiltersSelector3 = AV44GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
                  {
                     AV79DynamicFiltersOperator3 = AV44GridStateDynamicFilter.gxTpr_Operator;
                     AV80ClienteDocumento3 = AV44GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 )
                  {
                     AV79DynamicFiltersOperator3 = AV44GridStateDynamicFilter.gxTpr_Operator;
                     AV81TipoClienteDescricao3 = AV44GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 )
                  {
                     AV79DynamicFiltersOperator3 = AV44GridStateDynamicFilter.gxTpr_Operator;
                     AV82ClienteConvenioDescricao3 = AV44GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 )
                  {
                     AV79DynamicFiltersOperator3 = AV44GridStateDynamicFilter.gxTpr_Operator;
                     AV83ClienteNacionalidadeNome3 = AV44GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 )
                  {
                     AV79DynamicFiltersOperator3 = AV44GridStateDynamicFilter.gxTpr_Operator;
                     AV84ClienteProfissaoNome3 = AV44GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "MUNICIPIONOME") == 0 )
                  {
                     AV79DynamicFiltersOperator3 = AV44GridStateDynamicFilter.gxTpr_Operator;
                     AV85MunicipioNome3 = AV44GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 )
                  {
                     AV79DynamicFiltersOperator3 = AV44GridStateDynamicFilter.gxTpr_Operator;
                     AV86BancoCodigo3 = (int)(Math.Round(NumberUtil.Val( AV44GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 )
                  {
                     AV79DynamicFiltersOperator3 = AV44GridStateDynamicFilter.gxTpr_Operator;
                     AV87ResponsavelNacionalidadeNome3 = AV44GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 )
                  {
                     AV79DynamicFiltersOperator3 = AV44GridStateDynamicFilter.gxTpr_Operator;
                     AV88ResponsavelProfissaoNome3 = AV44GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 )
                  {
                     AV79DynamicFiltersOperator3 = AV44GridStateDynamicFilter.gxTpr_Operator;
                     AV89ResponsavelMunicipioNome3 = AV44GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADRESPONSAVELNOMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFResponsavelNome = AV29SearchTxt;
         AV11TFResponsavelNome_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV19TFResponsavelCargo_Sels ,
                                              A884ClienteSituacao ,
                                              AV28TFClienteSituacao_Sels ,
                                              AV52DynamicFiltersSelector1 ,
                                              AV53DynamicFiltersOperator1 ,
                                              AV54ClienteDocumento1 ,
                                              AV55TipoClienteDescricao1 ,
                                              AV56ClienteConvenioDescricao1 ,
                                              AV57ClienteNacionalidadeNome1 ,
                                              AV58ClienteProfissaoNome1 ,
                                              AV59MunicipioNome1 ,
                                              AV60BancoCodigo1 ,
                                              AV61ResponsavelNacionalidadeNome1 ,
                                              AV62ResponsavelProfissaoNome1 ,
                                              AV63ResponsavelMunicipioNome1 ,
                                              AV64DynamicFiltersEnabled2 ,
                                              AV65DynamicFiltersSelector2 ,
                                              AV66DynamicFiltersOperator2 ,
                                              AV67ClienteDocumento2 ,
                                              AV68TipoClienteDescricao2 ,
                                              AV69ClienteConvenioDescricao2 ,
                                              AV70ClienteNacionalidadeNome2 ,
                                              AV71ClienteProfissaoNome2 ,
                                              AV72MunicipioNome2 ,
                                              AV73BancoCodigo2 ,
                                              AV74ResponsavelNacionalidadeNome2 ,
                                              AV75ResponsavelProfissaoNome2 ,
                                              AV76ResponsavelMunicipioNome2 ,
                                              AV77DynamicFiltersEnabled3 ,
                                              AV78DynamicFiltersSelector3 ,
                                              AV79DynamicFiltersOperator3 ,
                                              AV80ClienteDocumento3 ,
                                              AV81TipoClienteDescricao3 ,
                                              AV82ClienteConvenioDescricao3 ,
                                              AV83ClienteNacionalidadeNome3 ,
                                              AV84ClienteProfissaoNome3 ,
                                              AV85MunicipioNome3 ,
                                              AV86BancoCodigo3 ,
                                              AV87ResponsavelNacionalidadeNome3 ,
                                              AV88ResponsavelProfissaoNome3 ,
                                              AV89ResponsavelMunicipioNome3 ,
                                              AV11TFResponsavelNome_Sel ,
                                              AV10TFResponsavelNome ,
                                              AV13TFResponsavelCPF_Sel ,
                                              AV12TFResponsavelCPF ,
                                              AV17TFResponsavelEmail_Sel ,
                                              AV16TFResponsavelEmail ,
                                              AV19TFResponsavelCargo_Sels.Count ,
                                              AV21TFClienteDocumento_Sel ,
                                              AV20TFClienteDocumento ,
                                              AV23TFClienteRazaoSocial_Sel ,
                                              AV22TFClienteRazaoSocial ,
                                              AV28TFClienteSituacao_Sels.Count ,
                                              AV26TFClienteStatus_Sel ,
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
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV51FilterFullText ,
                                              A577ResponsavelCelular_F ,
                                              AV15TFResponsavelCelular_F_Sel ,
                                              AV14TFResponsavelCelular_F ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV54ClienteDocumento1), "%", "");
         lV54ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV54ClienteDocumento1), "%", "");
         lV55TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV55TipoClienteDescricao1), "%", "");
         lV55TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV55TipoClienteDescricao1), "%", "");
         lV56ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV56ClienteConvenioDescricao1), "%", "");
         lV56ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV56ClienteConvenioDescricao1), "%", "");
         lV57ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV57ClienteNacionalidadeNome1), "%", "");
         lV57ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV57ClienteNacionalidadeNome1), "%", "");
         lV58ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV58ClienteProfissaoNome1), "%", "");
         lV58ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV58ClienteProfissaoNome1), "%", "");
         lV59MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV59MunicipioNome1), "%", "");
         lV59MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV59MunicipioNome1), "%", "");
         lV61ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1), "%", "");
         lV61ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1), "%", "");
         lV62ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV62ResponsavelProfissaoNome1), "%", "");
         lV62ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV62ResponsavelProfissaoNome1), "%", "");
         lV63ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV63ResponsavelMunicipioNome1), "%", "");
         lV63ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV63ResponsavelMunicipioNome1), "%", "");
         lV67ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV67ClienteDocumento2), "%", "");
         lV67ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV67ClienteDocumento2), "%", "");
         lV68TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV68TipoClienteDescricao2), "%", "");
         lV68TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV68TipoClienteDescricao2), "%", "");
         lV69ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV69ClienteConvenioDescricao2), "%", "");
         lV69ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV69ClienteConvenioDescricao2), "%", "");
         lV70ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV70ClienteNacionalidadeNome2), "%", "");
         lV70ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV70ClienteNacionalidadeNome2), "%", "");
         lV71ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV71ClienteProfissaoNome2), "%", "");
         lV71ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV71ClienteProfissaoNome2), "%", "");
         lV72MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV72MunicipioNome2), "%", "");
         lV72MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV72MunicipioNome2), "%", "");
         lV74ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2), "%", "");
         lV74ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2), "%", "");
         lV75ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV75ResponsavelProfissaoNome2), "%", "");
         lV75ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV75ResponsavelProfissaoNome2), "%", "");
         lV76ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV76ResponsavelMunicipioNome2), "%", "");
         lV76ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV76ResponsavelMunicipioNome2), "%", "");
         lV80ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV80ClienteDocumento3), "%", "");
         lV80ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV80ClienteDocumento3), "%", "");
         lV81TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81TipoClienteDescricao3), "%", "");
         lV81TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81TipoClienteDescricao3), "%", "");
         lV82ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV82ClienteConvenioDescricao3), "%", "");
         lV82ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV82ClienteConvenioDescricao3), "%", "");
         lV83ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV83ClienteNacionalidadeNome3), "%", "");
         lV83ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV83ClienteNacionalidadeNome3), "%", "");
         lV84ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV84ClienteProfissaoNome3), "%", "");
         lV84ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV84ClienteProfissaoNome3), "%", "");
         lV85MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV85MunicipioNome3), "%", "");
         lV85MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV85MunicipioNome3), "%", "");
         lV87ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3), "%", "");
         lV87ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3), "%", "");
         lV88ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV88ResponsavelProfissaoNome3), "%", "");
         lV88ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV88ResponsavelProfissaoNome3), "%", "");
         lV89ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV89ResponsavelMunicipioNome3), "%", "");
         lV89ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV89ResponsavelMunicipioNome3), "%", "");
         lV10TFResponsavelNome = StringUtil.Concat( StringUtil.RTrim( AV10TFResponsavelNome), "%", "");
         lV12TFResponsavelCPF = StringUtil.Concat( StringUtil.RTrim( AV12TFResponsavelCPF), "%", "");
         lV16TFResponsavelEmail = StringUtil.Concat( StringUtil.RTrim( AV16TFResponsavelEmail), "%", "");
         lV20TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV20TFClienteDocumento), "%", "");
         lV22TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV22TFClienteRazaoSocial), "%", "");
         /* Using cursor P00DW2 */
         pr_default.execute(0, new Object[] {lV54ClienteDocumento1, lV54ClienteDocumento1, lV55TipoClienteDescricao1, lV55TipoClienteDescricao1, lV56ClienteConvenioDescricao1, lV56ClienteConvenioDescricao1, lV57ClienteNacionalidadeNome1, lV57ClienteNacionalidadeNome1, lV58ClienteProfissaoNome1, lV58ClienteProfissaoNome1, lV59MunicipioNome1, lV59MunicipioNome1, AV60BancoCodigo1, AV60BancoCodigo1, AV60BancoCodigo1, lV61ResponsavelNacionalidadeNome1, lV61ResponsavelNacionalidadeNome1, lV62ResponsavelProfissaoNome1, lV62ResponsavelProfissaoNome1, lV63ResponsavelMunicipioNome1, lV63ResponsavelMunicipioNome1, lV67ClienteDocumento2, lV67ClienteDocumento2, lV68TipoClienteDescricao2, lV68TipoClienteDescricao2, lV69ClienteConvenioDescricao2, lV69ClienteConvenioDescricao2, lV70ClienteNacionalidadeNome2, lV70ClienteNacionalidadeNome2, lV71ClienteProfissaoNome2, lV71ClienteProfissaoNome2, lV72MunicipioNome2, lV72MunicipioNome2, AV73BancoCodigo2, AV73BancoCodigo2, AV73BancoCodigo2, lV74ResponsavelNacionalidadeNome2, lV74ResponsavelNacionalidadeNome2, lV75ResponsavelProfissaoNome2, lV75ResponsavelProfissaoNome2, lV76ResponsavelMunicipioNome2, lV76ResponsavelMunicipioNome2, lV80ClienteDocumento3, lV80ClienteDocumento3, lV81TipoClienteDescricao3, lV81TipoClienteDescricao3, lV82ClienteConvenioDescricao3, lV82ClienteConvenioDescricao3, lV83ClienteNacionalidadeNome3, lV83ClienteNacionalidadeNome3, lV84ClienteProfissaoNome3, lV84ClienteProfissaoNome3, lV85MunicipioNome3, lV85MunicipioNome3, AV86BancoCodigo3, AV86BancoCodigo3, AV86BancoCodigo3, lV87ResponsavelNacionalidadeNome3, lV87ResponsavelNacionalidadeNome3, lV88ResponsavelProfissaoNome3, lV88ResponsavelProfissaoNome3, lV89ResponsavelMunicipioNome3, lV89ResponsavelMunicipioNome3, lV10TFResponsavelNome, AV11TFResponsavelNome_Sel, lV12TFResponsavelCPF, AV13TFResponsavelCPF_Sel, lV16TFResponsavelEmail, AV17TFResponsavelEmail_Sel, lV20TFClienteDocumento, AV21TFClienteDocumento_Sel, lV22TFClienteRazaoSocial, AV23TFClienteRazaoSocial_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKDW2 = false;
            A186MunicipioCodigo = P00DW2_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00DW2_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00DW2_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00DW2_n444ResponsavelMunicipio[0];
            A402BancoId = P00DW2_A402BancoId[0];
            n402BancoId = P00DW2_n402BancoId[0];
            A437ResponsavelNacionalidade = P00DW2_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00DW2_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00DW2_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00DW2_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00DW2_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00DW2_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00DW2_A487ClienteProfissao[0];
            n487ClienteProfissao = P00DW2_n487ClienteProfissao[0];
            A489ClienteConvenio = P00DW2_A489ClienteConvenio[0];
            n489ClienteConvenio = P00DW2_n489ClienteConvenio[0];
            A192TipoClienteId = P00DW2_A192TipoClienteId[0];
            n192TipoClienteId = P00DW2_n192TipoClienteId[0];
            A436ResponsavelNome = P00DW2_A436ResponsavelNome[0];
            n436ResponsavelNome = P00DW2_n436ResponsavelNome[0];
            A445ResponsavelMunicipioNome = P00DW2_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DW2_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00DW2_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DW2_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00DW2_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DW2_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00DW2_A404BancoCodigo[0];
            n404BancoCodigo = P00DW2_n404BancoCodigo[0];
            A187MunicipioNome = P00DW2_A187MunicipioNome[0];
            n187MunicipioNome = P00DW2_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00DW2_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DW2_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00DW2_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DW2_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00DW2_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DW2_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DW2_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DW2_n193TipoClienteDescricao[0];
            A174ClienteStatus = P00DW2_A174ClienteStatus[0];
            n174ClienteStatus = P00DW2_n174ClienteStatus[0];
            A884ClienteSituacao = P00DW2_A884ClienteSituacao[0];
            n884ClienteSituacao = P00DW2_n884ClienteSituacao[0];
            A170ClienteRazaoSocial = P00DW2_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00DW2_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = P00DW2_A169ClienteDocumento[0];
            n169ClienteDocumento = P00DW2_n169ClienteDocumento[0];
            A885ResponsavelCargo = P00DW2_A885ResponsavelCargo[0];
            n885ResponsavelCargo = P00DW2_n885ResponsavelCargo[0];
            A456ResponsavelEmail = P00DW2_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00DW2_n456ResponsavelEmail[0];
            A447ResponsavelCPF = P00DW2_A447ResponsavelCPF[0];
            n447ResponsavelCPF = P00DW2_n447ResponsavelCPF[0];
            A455ResponsavelNumero = P00DW2_A455ResponsavelNumero[0];
            n455ResponsavelNumero = P00DW2_n455ResponsavelNumero[0];
            A454ResponsavelDDD = P00DW2_A454ResponsavelDDD[0];
            n454ResponsavelDDD = P00DW2_n454ResponsavelDDD[0];
            A168ClienteId = P00DW2_A168ClienteId[0];
            A187MunicipioNome = P00DW2_A187MunicipioNome[0];
            n187MunicipioNome = P00DW2_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00DW2_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DW2_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00DW2_A404BancoCodigo[0];
            n404BancoCodigo = P00DW2_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00DW2_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DW2_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00DW2_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DW2_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00DW2_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DW2_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00DW2_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DW2_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00DW2_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DW2_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DW2_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DW2_n193TipoClienteDescricao[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51FilterFullText)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) ||
            ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) || ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) ||
            ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) ||
            ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV51FilterFullText , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) ||
            ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) || ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) ||
            ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFResponsavelCelular_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFResponsavelCelular_F)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV14TFResponsavelCelular_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFResponsavelCelular_F_Sel)) && ! ( StringUtil.StrCmp(AV15TFResponsavelCelular_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV15TFResponsavelCelular_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV15TFResponsavelCelular_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                     {
                        AV39count = 0;
                        while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00DW2_A436ResponsavelNome[0], A436ResponsavelNome) == 0 ) )
                        {
                           BRKDW2 = false;
                           A168ClienteId = P00DW2_A168ClienteId[0];
                           AV39count = (long)(AV39count+1);
                           BRKDW2 = true;
                           pr_default.readNext(0);
                        }
                        if ( (0==AV30SkipItems) )
                        {
                           AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A436ResponsavelNome)) ? "<#Empty#>" : A436ResponsavelNome);
                           AV35Options.Add(AV34Option, 0);
                           AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV35Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV30SkipItems = (short)(AV30SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRKDW2 )
            {
               BRKDW2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRESPONSAVELCPFOPTIONS' Routine */
         returnInSub = false;
         AV12TFResponsavelCPF = AV29SearchTxt;
         AV13TFResponsavelCPF_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV19TFResponsavelCargo_Sels ,
                                              A884ClienteSituacao ,
                                              AV28TFClienteSituacao_Sels ,
                                              AV52DynamicFiltersSelector1 ,
                                              AV53DynamicFiltersOperator1 ,
                                              AV54ClienteDocumento1 ,
                                              AV55TipoClienteDescricao1 ,
                                              AV56ClienteConvenioDescricao1 ,
                                              AV57ClienteNacionalidadeNome1 ,
                                              AV58ClienteProfissaoNome1 ,
                                              AV59MunicipioNome1 ,
                                              AV60BancoCodigo1 ,
                                              AV61ResponsavelNacionalidadeNome1 ,
                                              AV62ResponsavelProfissaoNome1 ,
                                              AV63ResponsavelMunicipioNome1 ,
                                              AV64DynamicFiltersEnabled2 ,
                                              AV65DynamicFiltersSelector2 ,
                                              AV66DynamicFiltersOperator2 ,
                                              AV67ClienteDocumento2 ,
                                              AV68TipoClienteDescricao2 ,
                                              AV69ClienteConvenioDescricao2 ,
                                              AV70ClienteNacionalidadeNome2 ,
                                              AV71ClienteProfissaoNome2 ,
                                              AV72MunicipioNome2 ,
                                              AV73BancoCodigo2 ,
                                              AV74ResponsavelNacionalidadeNome2 ,
                                              AV75ResponsavelProfissaoNome2 ,
                                              AV76ResponsavelMunicipioNome2 ,
                                              AV77DynamicFiltersEnabled3 ,
                                              AV78DynamicFiltersSelector3 ,
                                              AV79DynamicFiltersOperator3 ,
                                              AV80ClienteDocumento3 ,
                                              AV81TipoClienteDescricao3 ,
                                              AV82ClienteConvenioDescricao3 ,
                                              AV83ClienteNacionalidadeNome3 ,
                                              AV84ClienteProfissaoNome3 ,
                                              AV85MunicipioNome3 ,
                                              AV86BancoCodigo3 ,
                                              AV87ResponsavelNacionalidadeNome3 ,
                                              AV88ResponsavelProfissaoNome3 ,
                                              AV89ResponsavelMunicipioNome3 ,
                                              AV11TFResponsavelNome_Sel ,
                                              AV10TFResponsavelNome ,
                                              AV13TFResponsavelCPF_Sel ,
                                              AV12TFResponsavelCPF ,
                                              AV17TFResponsavelEmail_Sel ,
                                              AV16TFResponsavelEmail ,
                                              AV19TFResponsavelCargo_Sels.Count ,
                                              AV21TFClienteDocumento_Sel ,
                                              AV20TFClienteDocumento ,
                                              AV23TFClienteRazaoSocial_Sel ,
                                              AV22TFClienteRazaoSocial ,
                                              AV28TFClienteSituacao_Sels.Count ,
                                              AV26TFClienteStatus_Sel ,
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
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV51FilterFullText ,
                                              A577ResponsavelCelular_F ,
                                              AV15TFResponsavelCelular_F_Sel ,
                                              AV14TFResponsavelCelular_F ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV54ClienteDocumento1), "%", "");
         lV54ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV54ClienteDocumento1), "%", "");
         lV55TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV55TipoClienteDescricao1), "%", "");
         lV55TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV55TipoClienteDescricao1), "%", "");
         lV56ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV56ClienteConvenioDescricao1), "%", "");
         lV56ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV56ClienteConvenioDescricao1), "%", "");
         lV57ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV57ClienteNacionalidadeNome1), "%", "");
         lV57ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV57ClienteNacionalidadeNome1), "%", "");
         lV58ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV58ClienteProfissaoNome1), "%", "");
         lV58ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV58ClienteProfissaoNome1), "%", "");
         lV59MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV59MunicipioNome1), "%", "");
         lV59MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV59MunicipioNome1), "%", "");
         lV61ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1), "%", "");
         lV61ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1), "%", "");
         lV62ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV62ResponsavelProfissaoNome1), "%", "");
         lV62ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV62ResponsavelProfissaoNome1), "%", "");
         lV63ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV63ResponsavelMunicipioNome1), "%", "");
         lV63ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV63ResponsavelMunicipioNome1), "%", "");
         lV67ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV67ClienteDocumento2), "%", "");
         lV67ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV67ClienteDocumento2), "%", "");
         lV68TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV68TipoClienteDescricao2), "%", "");
         lV68TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV68TipoClienteDescricao2), "%", "");
         lV69ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV69ClienteConvenioDescricao2), "%", "");
         lV69ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV69ClienteConvenioDescricao2), "%", "");
         lV70ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV70ClienteNacionalidadeNome2), "%", "");
         lV70ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV70ClienteNacionalidadeNome2), "%", "");
         lV71ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV71ClienteProfissaoNome2), "%", "");
         lV71ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV71ClienteProfissaoNome2), "%", "");
         lV72MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV72MunicipioNome2), "%", "");
         lV72MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV72MunicipioNome2), "%", "");
         lV74ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2), "%", "");
         lV74ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2), "%", "");
         lV75ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV75ResponsavelProfissaoNome2), "%", "");
         lV75ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV75ResponsavelProfissaoNome2), "%", "");
         lV76ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV76ResponsavelMunicipioNome2), "%", "");
         lV76ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV76ResponsavelMunicipioNome2), "%", "");
         lV80ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV80ClienteDocumento3), "%", "");
         lV80ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV80ClienteDocumento3), "%", "");
         lV81TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81TipoClienteDescricao3), "%", "");
         lV81TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81TipoClienteDescricao3), "%", "");
         lV82ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV82ClienteConvenioDescricao3), "%", "");
         lV82ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV82ClienteConvenioDescricao3), "%", "");
         lV83ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV83ClienteNacionalidadeNome3), "%", "");
         lV83ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV83ClienteNacionalidadeNome3), "%", "");
         lV84ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV84ClienteProfissaoNome3), "%", "");
         lV84ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV84ClienteProfissaoNome3), "%", "");
         lV85MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV85MunicipioNome3), "%", "");
         lV85MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV85MunicipioNome3), "%", "");
         lV87ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3), "%", "");
         lV87ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3), "%", "");
         lV88ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV88ResponsavelProfissaoNome3), "%", "");
         lV88ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV88ResponsavelProfissaoNome3), "%", "");
         lV89ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV89ResponsavelMunicipioNome3), "%", "");
         lV89ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV89ResponsavelMunicipioNome3), "%", "");
         lV10TFResponsavelNome = StringUtil.Concat( StringUtil.RTrim( AV10TFResponsavelNome), "%", "");
         lV12TFResponsavelCPF = StringUtil.Concat( StringUtil.RTrim( AV12TFResponsavelCPF), "%", "");
         lV16TFResponsavelEmail = StringUtil.Concat( StringUtil.RTrim( AV16TFResponsavelEmail), "%", "");
         lV20TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV20TFClienteDocumento), "%", "");
         lV22TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV22TFClienteRazaoSocial), "%", "");
         /* Using cursor P00DW3 */
         pr_default.execute(1, new Object[] {lV54ClienteDocumento1, lV54ClienteDocumento1, lV55TipoClienteDescricao1, lV55TipoClienteDescricao1, lV56ClienteConvenioDescricao1, lV56ClienteConvenioDescricao1, lV57ClienteNacionalidadeNome1, lV57ClienteNacionalidadeNome1, lV58ClienteProfissaoNome1, lV58ClienteProfissaoNome1, lV59MunicipioNome1, lV59MunicipioNome1, AV60BancoCodigo1, AV60BancoCodigo1, AV60BancoCodigo1, lV61ResponsavelNacionalidadeNome1, lV61ResponsavelNacionalidadeNome1, lV62ResponsavelProfissaoNome1, lV62ResponsavelProfissaoNome1, lV63ResponsavelMunicipioNome1, lV63ResponsavelMunicipioNome1, lV67ClienteDocumento2, lV67ClienteDocumento2, lV68TipoClienteDescricao2, lV68TipoClienteDescricao2, lV69ClienteConvenioDescricao2, lV69ClienteConvenioDescricao2, lV70ClienteNacionalidadeNome2, lV70ClienteNacionalidadeNome2, lV71ClienteProfissaoNome2, lV71ClienteProfissaoNome2, lV72MunicipioNome2, lV72MunicipioNome2, AV73BancoCodigo2, AV73BancoCodigo2, AV73BancoCodigo2, lV74ResponsavelNacionalidadeNome2, lV74ResponsavelNacionalidadeNome2, lV75ResponsavelProfissaoNome2, lV75ResponsavelProfissaoNome2, lV76ResponsavelMunicipioNome2, lV76ResponsavelMunicipioNome2, lV80ClienteDocumento3, lV80ClienteDocumento3, lV81TipoClienteDescricao3, lV81TipoClienteDescricao3, lV82ClienteConvenioDescricao3, lV82ClienteConvenioDescricao3, lV83ClienteNacionalidadeNome3, lV83ClienteNacionalidadeNome3, lV84ClienteProfissaoNome3, lV84ClienteProfissaoNome3, lV85MunicipioNome3, lV85MunicipioNome3, AV86BancoCodigo3, AV86BancoCodigo3, AV86BancoCodigo3, lV87ResponsavelNacionalidadeNome3, lV87ResponsavelNacionalidadeNome3, lV88ResponsavelProfissaoNome3, lV88ResponsavelProfissaoNome3, lV89ResponsavelMunicipioNome3, lV89ResponsavelMunicipioNome3, lV10TFResponsavelNome, AV11TFResponsavelNome_Sel, lV12TFResponsavelCPF, AV13TFResponsavelCPF_Sel, lV16TFResponsavelEmail, AV17TFResponsavelEmail_Sel, lV20TFClienteDocumento, AV21TFClienteDocumento_Sel, lV22TFClienteRazaoSocial, AV23TFClienteRazaoSocial_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKDW4 = false;
            A186MunicipioCodigo = P00DW3_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00DW3_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00DW3_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00DW3_n444ResponsavelMunicipio[0];
            A402BancoId = P00DW3_A402BancoId[0];
            n402BancoId = P00DW3_n402BancoId[0];
            A437ResponsavelNacionalidade = P00DW3_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00DW3_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00DW3_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00DW3_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00DW3_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00DW3_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00DW3_A487ClienteProfissao[0];
            n487ClienteProfissao = P00DW3_n487ClienteProfissao[0];
            A489ClienteConvenio = P00DW3_A489ClienteConvenio[0];
            n489ClienteConvenio = P00DW3_n489ClienteConvenio[0];
            A192TipoClienteId = P00DW3_A192TipoClienteId[0];
            n192TipoClienteId = P00DW3_n192TipoClienteId[0];
            A447ResponsavelCPF = P00DW3_A447ResponsavelCPF[0];
            n447ResponsavelCPF = P00DW3_n447ResponsavelCPF[0];
            A445ResponsavelMunicipioNome = P00DW3_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DW3_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00DW3_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DW3_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00DW3_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DW3_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00DW3_A404BancoCodigo[0];
            n404BancoCodigo = P00DW3_n404BancoCodigo[0];
            A187MunicipioNome = P00DW3_A187MunicipioNome[0];
            n187MunicipioNome = P00DW3_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00DW3_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DW3_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00DW3_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DW3_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00DW3_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DW3_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DW3_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DW3_n193TipoClienteDescricao[0];
            A174ClienteStatus = P00DW3_A174ClienteStatus[0];
            n174ClienteStatus = P00DW3_n174ClienteStatus[0];
            A884ClienteSituacao = P00DW3_A884ClienteSituacao[0];
            n884ClienteSituacao = P00DW3_n884ClienteSituacao[0];
            A170ClienteRazaoSocial = P00DW3_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00DW3_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = P00DW3_A169ClienteDocumento[0];
            n169ClienteDocumento = P00DW3_n169ClienteDocumento[0];
            A885ResponsavelCargo = P00DW3_A885ResponsavelCargo[0];
            n885ResponsavelCargo = P00DW3_n885ResponsavelCargo[0];
            A456ResponsavelEmail = P00DW3_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00DW3_n456ResponsavelEmail[0];
            A436ResponsavelNome = P00DW3_A436ResponsavelNome[0];
            n436ResponsavelNome = P00DW3_n436ResponsavelNome[0];
            A455ResponsavelNumero = P00DW3_A455ResponsavelNumero[0];
            n455ResponsavelNumero = P00DW3_n455ResponsavelNumero[0];
            A454ResponsavelDDD = P00DW3_A454ResponsavelDDD[0];
            n454ResponsavelDDD = P00DW3_n454ResponsavelDDD[0];
            A168ClienteId = P00DW3_A168ClienteId[0];
            A187MunicipioNome = P00DW3_A187MunicipioNome[0];
            n187MunicipioNome = P00DW3_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00DW3_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DW3_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00DW3_A404BancoCodigo[0];
            n404BancoCodigo = P00DW3_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00DW3_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DW3_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00DW3_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DW3_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00DW3_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DW3_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00DW3_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DW3_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00DW3_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DW3_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DW3_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DW3_n193TipoClienteDescricao[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51FilterFullText)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) ||
            ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) || ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) ||
            ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) ||
            ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV51FilterFullText , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) ||
            ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) || ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) ||
            ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFResponsavelCelular_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFResponsavelCelular_F)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV14TFResponsavelCelular_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFResponsavelCelular_F_Sel)) && ! ( StringUtil.StrCmp(AV15TFResponsavelCelular_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV15TFResponsavelCelular_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV15TFResponsavelCelular_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                     {
                        AV39count = 0;
                        while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00DW3_A447ResponsavelCPF[0], A447ResponsavelCPF) == 0 ) )
                        {
                           BRKDW4 = false;
                           A168ClienteId = P00DW3_A168ClienteId[0];
                           AV39count = (long)(AV39count+1);
                           BRKDW4 = true;
                           pr_default.readNext(1);
                        }
                        if ( (0==AV30SkipItems) )
                        {
                           AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A447ResponsavelCPF)) ? "<#Empty#>" : A447ResponsavelCPF);
                           AV35Options.Add(AV34Option, 0);
                           AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV35Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV30SkipItems = (short)(AV30SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRKDW4 )
            {
               BRKDW4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADRESPONSAVELCELULAR_FOPTIONS' Routine */
         returnInSub = false;
         AV14TFResponsavelCelular_F = AV29SearchTxt;
         AV15TFResponsavelCelular_F_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV19TFResponsavelCargo_Sels ,
                                              A884ClienteSituacao ,
                                              AV28TFClienteSituacao_Sels ,
                                              AV52DynamicFiltersSelector1 ,
                                              AV53DynamicFiltersOperator1 ,
                                              AV54ClienteDocumento1 ,
                                              AV55TipoClienteDescricao1 ,
                                              AV56ClienteConvenioDescricao1 ,
                                              AV57ClienteNacionalidadeNome1 ,
                                              AV58ClienteProfissaoNome1 ,
                                              AV59MunicipioNome1 ,
                                              AV60BancoCodigo1 ,
                                              AV61ResponsavelNacionalidadeNome1 ,
                                              AV62ResponsavelProfissaoNome1 ,
                                              AV63ResponsavelMunicipioNome1 ,
                                              AV64DynamicFiltersEnabled2 ,
                                              AV65DynamicFiltersSelector2 ,
                                              AV66DynamicFiltersOperator2 ,
                                              AV67ClienteDocumento2 ,
                                              AV68TipoClienteDescricao2 ,
                                              AV69ClienteConvenioDescricao2 ,
                                              AV70ClienteNacionalidadeNome2 ,
                                              AV71ClienteProfissaoNome2 ,
                                              AV72MunicipioNome2 ,
                                              AV73BancoCodigo2 ,
                                              AV74ResponsavelNacionalidadeNome2 ,
                                              AV75ResponsavelProfissaoNome2 ,
                                              AV76ResponsavelMunicipioNome2 ,
                                              AV77DynamicFiltersEnabled3 ,
                                              AV78DynamicFiltersSelector3 ,
                                              AV79DynamicFiltersOperator3 ,
                                              AV80ClienteDocumento3 ,
                                              AV81TipoClienteDescricao3 ,
                                              AV82ClienteConvenioDescricao3 ,
                                              AV83ClienteNacionalidadeNome3 ,
                                              AV84ClienteProfissaoNome3 ,
                                              AV85MunicipioNome3 ,
                                              AV86BancoCodigo3 ,
                                              AV87ResponsavelNacionalidadeNome3 ,
                                              AV88ResponsavelProfissaoNome3 ,
                                              AV89ResponsavelMunicipioNome3 ,
                                              AV11TFResponsavelNome_Sel ,
                                              AV10TFResponsavelNome ,
                                              AV13TFResponsavelCPF_Sel ,
                                              AV12TFResponsavelCPF ,
                                              AV17TFResponsavelEmail_Sel ,
                                              AV16TFResponsavelEmail ,
                                              AV19TFResponsavelCargo_Sels.Count ,
                                              AV21TFClienteDocumento_Sel ,
                                              AV20TFClienteDocumento ,
                                              AV23TFClienteRazaoSocial_Sel ,
                                              AV22TFClienteRazaoSocial ,
                                              AV28TFClienteSituacao_Sels.Count ,
                                              AV26TFClienteStatus_Sel ,
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
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV51FilterFullText ,
                                              A577ResponsavelCelular_F ,
                                              AV15TFResponsavelCelular_F_Sel ,
                                              AV14TFResponsavelCelular_F ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV54ClienteDocumento1), "%", "");
         lV54ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV54ClienteDocumento1), "%", "");
         lV55TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV55TipoClienteDescricao1), "%", "");
         lV55TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV55TipoClienteDescricao1), "%", "");
         lV56ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV56ClienteConvenioDescricao1), "%", "");
         lV56ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV56ClienteConvenioDescricao1), "%", "");
         lV57ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV57ClienteNacionalidadeNome1), "%", "");
         lV57ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV57ClienteNacionalidadeNome1), "%", "");
         lV58ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV58ClienteProfissaoNome1), "%", "");
         lV58ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV58ClienteProfissaoNome1), "%", "");
         lV59MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV59MunicipioNome1), "%", "");
         lV59MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV59MunicipioNome1), "%", "");
         lV61ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1), "%", "");
         lV61ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1), "%", "");
         lV62ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV62ResponsavelProfissaoNome1), "%", "");
         lV62ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV62ResponsavelProfissaoNome1), "%", "");
         lV63ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV63ResponsavelMunicipioNome1), "%", "");
         lV63ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV63ResponsavelMunicipioNome1), "%", "");
         lV67ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV67ClienteDocumento2), "%", "");
         lV67ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV67ClienteDocumento2), "%", "");
         lV68TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV68TipoClienteDescricao2), "%", "");
         lV68TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV68TipoClienteDescricao2), "%", "");
         lV69ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV69ClienteConvenioDescricao2), "%", "");
         lV69ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV69ClienteConvenioDescricao2), "%", "");
         lV70ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV70ClienteNacionalidadeNome2), "%", "");
         lV70ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV70ClienteNacionalidadeNome2), "%", "");
         lV71ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV71ClienteProfissaoNome2), "%", "");
         lV71ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV71ClienteProfissaoNome2), "%", "");
         lV72MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV72MunicipioNome2), "%", "");
         lV72MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV72MunicipioNome2), "%", "");
         lV74ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2), "%", "");
         lV74ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2), "%", "");
         lV75ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV75ResponsavelProfissaoNome2), "%", "");
         lV75ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV75ResponsavelProfissaoNome2), "%", "");
         lV76ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV76ResponsavelMunicipioNome2), "%", "");
         lV76ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV76ResponsavelMunicipioNome2), "%", "");
         lV80ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV80ClienteDocumento3), "%", "");
         lV80ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV80ClienteDocumento3), "%", "");
         lV81TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81TipoClienteDescricao3), "%", "");
         lV81TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81TipoClienteDescricao3), "%", "");
         lV82ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV82ClienteConvenioDescricao3), "%", "");
         lV82ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV82ClienteConvenioDescricao3), "%", "");
         lV83ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV83ClienteNacionalidadeNome3), "%", "");
         lV83ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV83ClienteNacionalidadeNome3), "%", "");
         lV84ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV84ClienteProfissaoNome3), "%", "");
         lV84ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV84ClienteProfissaoNome3), "%", "");
         lV85MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV85MunicipioNome3), "%", "");
         lV85MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV85MunicipioNome3), "%", "");
         lV87ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3), "%", "");
         lV87ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3), "%", "");
         lV88ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV88ResponsavelProfissaoNome3), "%", "");
         lV88ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV88ResponsavelProfissaoNome3), "%", "");
         lV89ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV89ResponsavelMunicipioNome3), "%", "");
         lV89ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV89ResponsavelMunicipioNome3), "%", "");
         lV10TFResponsavelNome = StringUtil.Concat( StringUtil.RTrim( AV10TFResponsavelNome), "%", "");
         lV12TFResponsavelCPF = StringUtil.Concat( StringUtil.RTrim( AV12TFResponsavelCPF), "%", "");
         lV16TFResponsavelEmail = StringUtil.Concat( StringUtil.RTrim( AV16TFResponsavelEmail), "%", "");
         lV20TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV20TFClienteDocumento), "%", "");
         lV22TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV22TFClienteRazaoSocial), "%", "");
         /* Using cursor P00DW4 */
         pr_default.execute(2, new Object[] {lV54ClienteDocumento1, lV54ClienteDocumento1, lV55TipoClienteDescricao1, lV55TipoClienteDescricao1, lV56ClienteConvenioDescricao1, lV56ClienteConvenioDescricao1, lV57ClienteNacionalidadeNome1, lV57ClienteNacionalidadeNome1, lV58ClienteProfissaoNome1, lV58ClienteProfissaoNome1, lV59MunicipioNome1, lV59MunicipioNome1, AV60BancoCodigo1, AV60BancoCodigo1, AV60BancoCodigo1, lV61ResponsavelNacionalidadeNome1, lV61ResponsavelNacionalidadeNome1, lV62ResponsavelProfissaoNome1, lV62ResponsavelProfissaoNome1, lV63ResponsavelMunicipioNome1, lV63ResponsavelMunicipioNome1, lV67ClienteDocumento2, lV67ClienteDocumento2, lV68TipoClienteDescricao2, lV68TipoClienteDescricao2, lV69ClienteConvenioDescricao2, lV69ClienteConvenioDescricao2, lV70ClienteNacionalidadeNome2, lV70ClienteNacionalidadeNome2, lV71ClienteProfissaoNome2, lV71ClienteProfissaoNome2, lV72MunicipioNome2, lV72MunicipioNome2, AV73BancoCodigo2, AV73BancoCodigo2, AV73BancoCodigo2, lV74ResponsavelNacionalidadeNome2, lV74ResponsavelNacionalidadeNome2, lV75ResponsavelProfissaoNome2, lV75ResponsavelProfissaoNome2, lV76ResponsavelMunicipioNome2, lV76ResponsavelMunicipioNome2, lV80ClienteDocumento3, lV80ClienteDocumento3, lV81TipoClienteDescricao3, lV81TipoClienteDescricao3, lV82ClienteConvenioDescricao3, lV82ClienteConvenioDescricao3, lV83ClienteNacionalidadeNome3, lV83ClienteNacionalidadeNome3, lV84ClienteProfissaoNome3, lV84ClienteProfissaoNome3, lV85MunicipioNome3, lV85MunicipioNome3, AV86BancoCodigo3, AV86BancoCodigo3, AV86BancoCodigo3, lV87ResponsavelNacionalidadeNome3, lV87ResponsavelNacionalidadeNome3, lV88ResponsavelProfissaoNome3, lV88ResponsavelProfissaoNome3, lV89ResponsavelMunicipioNome3, lV89ResponsavelMunicipioNome3, lV10TFResponsavelNome, AV11TFResponsavelNome_Sel, lV12TFResponsavelCPF, AV13TFResponsavelCPF_Sel, lV16TFResponsavelEmail, AV17TFResponsavelEmail_Sel, lV20TFClienteDocumento, AV21TFClienteDocumento_Sel, lV22TFClienteRazaoSocial, AV23TFClienteRazaoSocial_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A186MunicipioCodigo = P00DW4_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00DW4_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00DW4_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00DW4_n444ResponsavelMunicipio[0];
            A402BancoId = P00DW4_A402BancoId[0];
            n402BancoId = P00DW4_n402BancoId[0];
            A437ResponsavelNacionalidade = P00DW4_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00DW4_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00DW4_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00DW4_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00DW4_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00DW4_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00DW4_A487ClienteProfissao[0];
            n487ClienteProfissao = P00DW4_n487ClienteProfissao[0];
            A489ClienteConvenio = P00DW4_A489ClienteConvenio[0];
            n489ClienteConvenio = P00DW4_n489ClienteConvenio[0];
            A445ResponsavelMunicipioNome = P00DW4_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DW4_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00DW4_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DW4_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00DW4_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DW4_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00DW4_A404BancoCodigo[0];
            n404BancoCodigo = P00DW4_n404BancoCodigo[0];
            A187MunicipioNome = P00DW4_A187MunicipioNome[0];
            n187MunicipioNome = P00DW4_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00DW4_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DW4_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00DW4_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DW4_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00DW4_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DW4_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DW4_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DW4_n193TipoClienteDescricao[0];
            A192TipoClienteId = P00DW4_A192TipoClienteId[0];
            n192TipoClienteId = P00DW4_n192TipoClienteId[0];
            A174ClienteStatus = P00DW4_A174ClienteStatus[0];
            n174ClienteStatus = P00DW4_n174ClienteStatus[0];
            A884ClienteSituacao = P00DW4_A884ClienteSituacao[0];
            n884ClienteSituacao = P00DW4_n884ClienteSituacao[0];
            A170ClienteRazaoSocial = P00DW4_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00DW4_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = P00DW4_A169ClienteDocumento[0];
            n169ClienteDocumento = P00DW4_n169ClienteDocumento[0];
            A885ResponsavelCargo = P00DW4_A885ResponsavelCargo[0];
            n885ResponsavelCargo = P00DW4_n885ResponsavelCargo[0];
            A456ResponsavelEmail = P00DW4_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00DW4_n456ResponsavelEmail[0];
            A447ResponsavelCPF = P00DW4_A447ResponsavelCPF[0];
            n447ResponsavelCPF = P00DW4_n447ResponsavelCPF[0];
            A436ResponsavelNome = P00DW4_A436ResponsavelNome[0];
            n436ResponsavelNome = P00DW4_n436ResponsavelNome[0];
            A455ResponsavelNumero = P00DW4_A455ResponsavelNumero[0];
            n455ResponsavelNumero = P00DW4_n455ResponsavelNumero[0];
            A454ResponsavelDDD = P00DW4_A454ResponsavelDDD[0];
            n454ResponsavelDDD = P00DW4_n454ResponsavelDDD[0];
            A168ClienteId = P00DW4_A168ClienteId[0];
            A187MunicipioNome = P00DW4_A187MunicipioNome[0];
            n187MunicipioNome = P00DW4_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00DW4_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DW4_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00DW4_A404BancoCodigo[0];
            n404BancoCodigo = P00DW4_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00DW4_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DW4_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00DW4_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DW4_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00DW4_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DW4_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00DW4_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DW4_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00DW4_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DW4_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DW4_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DW4_n193TipoClienteDescricao[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51FilterFullText)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) ||
            ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) || ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) ||
            ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) ||
            ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV51FilterFullText , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) ||
            ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) || ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) ||
            ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFResponsavelCelular_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFResponsavelCelular_F)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV14TFResponsavelCelular_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFResponsavelCelular_F_Sel)) && ! ( StringUtil.StrCmp(AV15TFResponsavelCelular_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV15TFResponsavelCelular_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV15TFResponsavelCelular_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                     {
                        AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ? "<#Empty#>" : A577ResponsavelCelular_F);
                        AV33InsertIndex = 1;
                        while ( ( StringUtil.StrCmp(AV34Option, "<#Empty#>") != 0 ) && ( AV33InsertIndex <= AV35Options.Count ) && ( ( StringUtil.StrCmp(((string)AV35Options.Item(AV33InsertIndex)), AV34Option) < 0 ) || ( StringUtil.StrCmp(((string)AV35Options.Item(AV33InsertIndex)), "<#Empty#>") == 0 ) ) )
                        {
                           AV33InsertIndex = (int)(AV33InsertIndex+1);
                        }
                        if ( ( AV33InsertIndex <= AV35Options.Count ) && ( StringUtil.StrCmp(((string)AV35Options.Item(AV33InsertIndex)), AV34Option) == 0 ) )
                        {
                           AV39count = (long)(Math.Round(NumberUtil.Val( ((string)AV38OptionIndexes.Item(AV33InsertIndex)), "."), 18, MidpointRounding.ToEven));
                           AV39count = (long)(AV39count+1);
                           AV38OptionIndexes.RemoveItem(AV33InsertIndex);
                           AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), AV33InsertIndex);
                        }
                        else
                        {
                           AV35Options.Add(AV34Option, AV33InsertIndex);
                           AV38OptionIndexes.Add("1", AV33InsertIndex);
                        }
                        if ( AV35Options.Count == AV30SkipItems + 11 )
                        {
                           AV35Options.RemoveItem(AV35Options.Count);
                           AV38OptionIndexes.RemoveItem(AV38OptionIndexes.Count);
                        }
                     }
                  }
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         while ( AV30SkipItems > 0 )
         {
            AV35Options.RemoveItem(1);
            AV38OptionIndexes.RemoveItem(1);
            AV30SkipItems = (short)(AV30SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADRESPONSAVELEMAILOPTIONS' Routine */
         returnInSub = false;
         AV16TFResponsavelEmail = AV29SearchTxt;
         AV17TFResponsavelEmail_Sel = "";
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV19TFResponsavelCargo_Sels ,
                                              A884ClienteSituacao ,
                                              AV28TFClienteSituacao_Sels ,
                                              AV52DynamicFiltersSelector1 ,
                                              AV53DynamicFiltersOperator1 ,
                                              AV54ClienteDocumento1 ,
                                              AV55TipoClienteDescricao1 ,
                                              AV56ClienteConvenioDescricao1 ,
                                              AV57ClienteNacionalidadeNome1 ,
                                              AV58ClienteProfissaoNome1 ,
                                              AV59MunicipioNome1 ,
                                              AV60BancoCodigo1 ,
                                              AV61ResponsavelNacionalidadeNome1 ,
                                              AV62ResponsavelProfissaoNome1 ,
                                              AV63ResponsavelMunicipioNome1 ,
                                              AV64DynamicFiltersEnabled2 ,
                                              AV65DynamicFiltersSelector2 ,
                                              AV66DynamicFiltersOperator2 ,
                                              AV67ClienteDocumento2 ,
                                              AV68TipoClienteDescricao2 ,
                                              AV69ClienteConvenioDescricao2 ,
                                              AV70ClienteNacionalidadeNome2 ,
                                              AV71ClienteProfissaoNome2 ,
                                              AV72MunicipioNome2 ,
                                              AV73BancoCodigo2 ,
                                              AV74ResponsavelNacionalidadeNome2 ,
                                              AV75ResponsavelProfissaoNome2 ,
                                              AV76ResponsavelMunicipioNome2 ,
                                              AV77DynamicFiltersEnabled3 ,
                                              AV78DynamicFiltersSelector3 ,
                                              AV79DynamicFiltersOperator3 ,
                                              AV80ClienteDocumento3 ,
                                              AV81TipoClienteDescricao3 ,
                                              AV82ClienteConvenioDescricao3 ,
                                              AV83ClienteNacionalidadeNome3 ,
                                              AV84ClienteProfissaoNome3 ,
                                              AV85MunicipioNome3 ,
                                              AV86BancoCodigo3 ,
                                              AV87ResponsavelNacionalidadeNome3 ,
                                              AV88ResponsavelProfissaoNome3 ,
                                              AV89ResponsavelMunicipioNome3 ,
                                              AV11TFResponsavelNome_Sel ,
                                              AV10TFResponsavelNome ,
                                              AV13TFResponsavelCPF_Sel ,
                                              AV12TFResponsavelCPF ,
                                              AV17TFResponsavelEmail_Sel ,
                                              AV16TFResponsavelEmail ,
                                              AV19TFResponsavelCargo_Sels.Count ,
                                              AV21TFClienteDocumento_Sel ,
                                              AV20TFClienteDocumento ,
                                              AV23TFClienteRazaoSocial_Sel ,
                                              AV22TFClienteRazaoSocial ,
                                              AV28TFClienteSituacao_Sels.Count ,
                                              AV26TFClienteStatus_Sel ,
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
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV51FilterFullText ,
                                              A577ResponsavelCelular_F ,
                                              AV15TFResponsavelCelular_F_Sel ,
                                              AV14TFResponsavelCelular_F ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV54ClienteDocumento1), "%", "");
         lV54ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV54ClienteDocumento1), "%", "");
         lV55TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV55TipoClienteDescricao1), "%", "");
         lV55TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV55TipoClienteDescricao1), "%", "");
         lV56ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV56ClienteConvenioDescricao1), "%", "");
         lV56ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV56ClienteConvenioDescricao1), "%", "");
         lV57ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV57ClienteNacionalidadeNome1), "%", "");
         lV57ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV57ClienteNacionalidadeNome1), "%", "");
         lV58ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV58ClienteProfissaoNome1), "%", "");
         lV58ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV58ClienteProfissaoNome1), "%", "");
         lV59MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV59MunicipioNome1), "%", "");
         lV59MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV59MunicipioNome1), "%", "");
         lV61ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1), "%", "");
         lV61ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1), "%", "");
         lV62ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV62ResponsavelProfissaoNome1), "%", "");
         lV62ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV62ResponsavelProfissaoNome1), "%", "");
         lV63ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV63ResponsavelMunicipioNome1), "%", "");
         lV63ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV63ResponsavelMunicipioNome1), "%", "");
         lV67ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV67ClienteDocumento2), "%", "");
         lV67ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV67ClienteDocumento2), "%", "");
         lV68TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV68TipoClienteDescricao2), "%", "");
         lV68TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV68TipoClienteDescricao2), "%", "");
         lV69ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV69ClienteConvenioDescricao2), "%", "");
         lV69ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV69ClienteConvenioDescricao2), "%", "");
         lV70ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV70ClienteNacionalidadeNome2), "%", "");
         lV70ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV70ClienteNacionalidadeNome2), "%", "");
         lV71ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV71ClienteProfissaoNome2), "%", "");
         lV71ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV71ClienteProfissaoNome2), "%", "");
         lV72MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV72MunicipioNome2), "%", "");
         lV72MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV72MunicipioNome2), "%", "");
         lV74ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2), "%", "");
         lV74ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2), "%", "");
         lV75ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV75ResponsavelProfissaoNome2), "%", "");
         lV75ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV75ResponsavelProfissaoNome2), "%", "");
         lV76ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV76ResponsavelMunicipioNome2), "%", "");
         lV76ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV76ResponsavelMunicipioNome2), "%", "");
         lV80ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV80ClienteDocumento3), "%", "");
         lV80ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV80ClienteDocumento3), "%", "");
         lV81TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81TipoClienteDescricao3), "%", "");
         lV81TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81TipoClienteDescricao3), "%", "");
         lV82ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV82ClienteConvenioDescricao3), "%", "");
         lV82ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV82ClienteConvenioDescricao3), "%", "");
         lV83ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV83ClienteNacionalidadeNome3), "%", "");
         lV83ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV83ClienteNacionalidadeNome3), "%", "");
         lV84ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV84ClienteProfissaoNome3), "%", "");
         lV84ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV84ClienteProfissaoNome3), "%", "");
         lV85MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV85MunicipioNome3), "%", "");
         lV85MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV85MunicipioNome3), "%", "");
         lV87ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3), "%", "");
         lV87ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3), "%", "");
         lV88ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV88ResponsavelProfissaoNome3), "%", "");
         lV88ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV88ResponsavelProfissaoNome3), "%", "");
         lV89ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV89ResponsavelMunicipioNome3), "%", "");
         lV89ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV89ResponsavelMunicipioNome3), "%", "");
         lV10TFResponsavelNome = StringUtil.Concat( StringUtil.RTrim( AV10TFResponsavelNome), "%", "");
         lV12TFResponsavelCPF = StringUtil.Concat( StringUtil.RTrim( AV12TFResponsavelCPF), "%", "");
         lV16TFResponsavelEmail = StringUtil.Concat( StringUtil.RTrim( AV16TFResponsavelEmail), "%", "");
         lV20TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV20TFClienteDocumento), "%", "");
         lV22TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV22TFClienteRazaoSocial), "%", "");
         /* Using cursor P00DW5 */
         pr_default.execute(3, new Object[] {lV54ClienteDocumento1, lV54ClienteDocumento1, lV55TipoClienteDescricao1, lV55TipoClienteDescricao1, lV56ClienteConvenioDescricao1, lV56ClienteConvenioDescricao1, lV57ClienteNacionalidadeNome1, lV57ClienteNacionalidadeNome1, lV58ClienteProfissaoNome1, lV58ClienteProfissaoNome1, lV59MunicipioNome1, lV59MunicipioNome1, AV60BancoCodigo1, AV60BancoCodigo1, AV60BancoCodigo1, lV61ResponsavelNacionalidadeNome1, lV61ResponsavelNacionalidadeNome1, lV62ResponsavelProfissaoNome1, lV62ResponsavelProfissaoNome1, lV63ResponsavelMunicipioNome1, lV63ResponsavelMunicipioNome1, lV67ClienteDocumento2, lV67ClienteDocumento2, lV68TipoClienteDescricao2, lV68TipoClienteDescricao2, lV69ClienteConvenioDescricao2, lV69ClienteConvenioDescricao2, lV70ClienteNacionalidadeNome2, lV70ClienteNacionalidadeNome2, lV71ClienteProfissaoNome2, lV71ClienteProfissaoNome2, lV72MunicipioNome2, lV72MunicipioNome2, AV73BancoCodigo2, AV73BancoCodigo2, AV73BancoCodigo2, lV74ResponsavelNacionalidadeNome2, lV74ResponsavelNacionalidadeNome2, lV75ResponsavelProfissaoNome2, lV75ResponsavelProfissaoNome2, lV76ResponsavelMunicipioNome2, lV76ResponsavelMunicipioNome2, lV80ClienteDocumento3, lV80ClienteDocumento3, lV81TipoClienteDescricao3, lV81TipoClienteDescricao3, lV82ClienteConvenioDescricao3, lV82ClienteConvenioDescricao3, lV83ClienteNacionalidadeNome3, lV83ClienteNacionalidadeNome3, lV84ClienteProfissaoNome3, lV84ClienteProfissaoNome3, lV85MunicipioNome3, lV85MunicipioNome3, AV86BancoCodigo3, AV86BancoCodigo3, AV86BancoCodigo3, lV87ResponsavelNacionalidadeNome3, lV87ResponsavelNacionalidadeNome3, lV88ResponsavelProfissaoNome3, lV88ResponsavelProfissaoNome3, lV89ResponsavelMunicipioNome3, lV89ResponsavelMunicipioNome3, lV10TFResponsavelNome, AV11TFResponsavelNome_Sel, lV12TFResponsavelCPF, AV13TFResponsavelCPF_Sel, lV16TFResponsavelEmail, AV17TFResponsavelEmail_Sel, lV20TFClienteDocumento, AV21TFClienteDocumento_Sel, lV22TFClienteRazaoSocial, AV23TFClienteRazaoSocial_Sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKDW7 = false;
            A186MunicipioCodigo = P00DW5_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00DW5_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00DW5_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00DW5_n444ResponsavelMunicipio[0];
            A402BancoId = P00DW5_A402BancoId[0];
            n402BancoId = P00DW5_n402BancoId[0];
            A437ResponsavelNacionalidade = P00DW5_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00DW5_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00DW5_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00DW5_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00DW5_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00DW5_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00DW5_A487ClienteProfissao[0];
            n487ClienteProfissao = P00DW5_n487ClienteProfissao[0];
            A489ClienteConvenio = P00DW5_A489ClienteConvenio[0];
            n489ClienteConvenio = P00DW5_n489ClienteConvenio[0];
            A192TipoClienteId = P00DW5_A192TipoClienteId[0];
            n192TipoClienteId = P00DW5_n192TipoClienteId[0];
            A456ResponsavelEmail = P00DW5_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00DW5_n456ResponsavelEmail[0];
            A445ResponsavelMunicipioNome = P00DW5_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DW5_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00DW5_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DW5_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00DW5_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DW5_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00DW5_A404BancoCodigo[0];
            n404BancoCodigo = P00DW5_n404BancoCodigo[0];
            A187MunicipioNome = P00DW5_A187MunicipioNome[0];
            n187MunicipioNome = P00DW5_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00DW5_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DW5_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00DW5_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DW5_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00DW5_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DW5_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DW5_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DW5_n193TipoClienteDescricao[0];
            A174ClienteStatus = P00DW5_A174ClienteStatus[0];
            n174ClienteStatus = P00DW5_n174ClienteStatus[0];
            A884ClienteSituacao = P00DW5_A884ClienteSituacao[0];
            n884ClienteSituacao = P00DW5_n884ClienteSituacao[0];
            A170ClienteRazaoSocial = P00DW5_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00DW5_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = P00DW5_A169ClienteDocumento[0];
            n169ClienteDocumento = P00DW5_n169ClienteDocumento[0];
            A885ResponsavelCargo = P00DW5_A885ResponsavelCargo[0];
            n885ResponsavelCargo = P00DW5_n885ResponsavelCargo[0];
            A447ResponsavelCPF = P00DW5_A447ResponsavelCPF[0];
            n447ResponsavelCPF = P00DW5_n447ResponsavelCPF[0];
            A436ResponsavelNome = P00DW5_A436ResponsavelNome[0];
            n436ResponsavelNome = P00DW5_n436ResponsavelNome[0];
            A455ResponsavelNumero = P00DW5_A455ResponsavelNumero[0];
            n455ResponsavelNumero = P00DW5_n455ResponsavelNumero[0];
            A454ResponsavelDDD = P00DW5_A454ResponsavelDDD[0];
            n454ResponsavelDDD = P00DW5_n454ResponsavelDDD[0];
            A168ClienteId = P00DW5_A168ClienteId[0];
            A187MunicipioNome = P00DW5_A187MunicipioNome[0];
            n187MunicipioNome = P00DW5_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00DW5_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DW5_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00DW5_A404BancoCodigo[0];
            n404BancoCodigo = P00DW5_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00DW5_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DW5_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00DW5_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DW5_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00DW5_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DW5_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00DW5_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DW5_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00DW5_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DW5_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DW5_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DW5_n193TipoClienteDescricao[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51FilterFullText)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) ||
            ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) || ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) ||
            ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) ||
            ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV51FilterFullText , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) ||
            ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) || ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) ||
            ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFResponsavelCelular_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFResponsavelCelular_F)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV14TFResponsavelCelular_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFResponsavelCelular_F_Sel)) && ! ( StringUtil.StrCmp(AV15TFResponsavelCelular_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV15TFResponsavelCelular_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV15TFResponsavelCelular_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                     {
                        AV39count = 0;
                        while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00DW5_A456ResponsavelEmail[0], A456ResponsavelEmail) == 0 ) )
                        {
                           BRKDW7 = false;
                           A168ClienteId = P00DW5_A168ClienteId[0];
                           AV39count = (long)(AV39count+1);
                           BRKDW7 = true;
                           pr_default.readNext(3);
                        }
                        if ( (0==AV30SkipItems) )
                        {
                           AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A456ResponsavelEmail)) ? "<#Empty#>" : A456ResponsavelEmail);
                           AV35Options.Add(AV34Option, 0);
                           AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV35Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV30SkipItems = (short)(AV30SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRKDW7 )
            {
               BRKDW7 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADCLIENTEDOCUMENTOOPTIONS' Routine */
         returnInSub = false;
         AV20TFClienteDocumento = AV29SearchTxt;
         AV21TFClienteDocumento_Sel = "";
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV19TFResponsavelCargo_Sels ,
                                              A884ClienteSituacao ,
                                              AV28TFClienteSituacao_Sels ,
                                              AV52DynamicFiltersSelector1 ,
                                              AV53DynamicFiltersOperator1 ,
                                              AV54ClienteDocumento1 ,
                                              AV55TipoClienteDescricao1 ,
                                              AV56ClienteConvenioDescricao1 ,
                                              AV57ClienteNacionalidadeNome1 ,
                                              AV58ClienteProfissaoNome1 ,
                                              AV59MunicipioNome1 ,
                                              AV60BancoCodigo1 ,
                                              AV61ResponsavelNacionalidadeNome1 ,
                                              AV62ResponsavelProfissaoNome1 ,
                                              AV63ResponsavelMunicipioNome1 ,
                                              AV64DynamicFiltersEnabled2 ,
                                              AV65DynamicFiltersSelector2 ,
                                              AV66DynamicFiltersOperator2 ,
                                              AV67ClienteDocumento2 ,
                                              AV68TipoClienteDescricao2 ,
                                              AV69ClienteConvenioDescricao2 ,
                                              AV70ClienteNacionalidadeNome2 ,
                                              AV71ClienteProfissaoNome2 ,
                                              AV72MunicipioNome2 ,
                                              AV73BancoCodigo2 ,
                                              AV74ResponsavelNacionalidadeNome2 ,
                                              AV75ResponsavelProfissaoNome2 ,
                                              AV76ResponsavelMunicipioNome2 ,
                                              AV77DynamicFiltersEnabled3 ,
                                              AV78DynamicFiltersSelector3 ,
                                              AV79DynamicFiltersOperator3 ,
                                              AV80ClienteDocumento3 ,
                                              AV81TipoClienteDescricao3 ,
                                              AV82ClienteConvenioDescricao3 ,
                                              AV83ClienteNacionalidadeNome3 ,
                                              AV84ClienteProfissaoNome3 ,
                                              AV85MunicipioNome3 ,
                                              AV86BancoCodigo3 ,
                                              AV87ResponsavelNacionalidadeNome3 ,
                                              AV88ResponsavelProfissaoNome3 ,
                                              AV89ResponsavelMunicipioNome3 ,
                                              AV11TFResponsavelNome_Sel ,
                                              AV10TFResponsavelNome ,
                                              AV13TFResponsavelCPF_Sel ,
                                              AV12TFResponsavelCPF ,
                                              AV17TFResponsavelEmail_Sel ,
                                              AV16TFResponsavelEmail ,
                                              AV19TFResponsavelCargo_Sels.Count ,
                                              AV21TFClienteDocumento_Sel ,
                                              AV20TFClienteDocumento ,
                                              AV23TFClienteRazaoSocial_Sel ,
                                              AV22TFClienteRazaoSocial ,
                                              AV28TFClienteSituacao_Sels.Count ,
                                              AV26TFClienteStatus_Sel ,
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
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV51FilterFullText ,
                                              A577ResponsavelCelular_F ,
                                              AV15TFResponsavelCelular_F_Sel ,
                                              AV14TFResponsavelCelular_F ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV54ClienteDocumento1), "%", "");
         lV54ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV54ClienteDocumento1), "%", "");
         lV55TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV55TipoClienteDescricao1), "%", "");
         lV55TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV55TipoClienteDescricao1), "%", "");
         lV56ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV56ClienteConvenioDescricao1), "%", "");
         lV56ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV56ClienteConvenioDescricao1), "%", "");
         lV57ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV57ClienteNacionalidadeNome1), "%", "");
         lV57ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV57ClienteNacionalidadeNome1), "%", "");
         lV58ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV58ClienteProfissaoNome1), "%", "");
         lV58ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV58ClienteProfissaoNome1), "%", "");
         lV59MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV59MunicipioNome1), "%", "");
         lV59MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV59MunicipioNome1), "%", "");
         lV61ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1), "%", "");
         lV61ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1), "%", "");
         lV62ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV62ResponsavelProfissaoNome1), "%", "");
         lV62ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV62ResponsavelProfissaoNome1), "%", "");
         lV63ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV63ResponsavelMunicipioNome1), "%", "");
         lV63ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV63ResponsavelMunicipioNome1), "%", "");
         lV67ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV67ClienteDocumento2), "%", "");
         lV67ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV67ClienteDocumento2), "%", "");
         lV68TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV68TipoClienteDescricao2), "%", "");
         lV68TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV68TipoClienteDescricao2), "%", "");
         lV69ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV69ClienteConvenioDescricao2), "%", "");
         lV69ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV69ClienteConvenioDescricao2), "%", "");
         lV70ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV70ClienteNacionalidadeNome2), "%", "");
         lV70ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV70ClienteNacionalidadeNome2), "%", "");
         lV71ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV71ClienteProfissaoNome2), "%", "");
         lV71ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV71ClienteProfissaoNome2), "%", "");
         lV72MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV72MunicipioNome2), "%", "");
         lV72MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV72MunicipioNome2), "%", "");
         lV74ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2), "%", "");
         lV74ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2), "%", "");
         lV75ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV75ResponsavelProfissaoNome2), "%", "");
         lV75ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV75ResponsavelProfissaoNome2), "%", "");
         lV76ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV76ResponsavelMunicipioNome2), "%", "");
         lV76ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV76ResponsavelMunicipioNome2), "%", "");
         lV80ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV80ClienteDocumento3), "%", "");
         lV80ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV80ClienteDocumento3), "%", "");
         lV81TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81TipoClienteDescricao3), "%", "");
         lV81TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81TipoClienteDescricao3), "%", "");
         lV82ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV82ClienteConvenioDescricao3), "%", "");
         lV82ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV82ClienteConvenioDescricao3), "%", "");
         lV83ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV83ClienteNacionalidadeNome3), "%", "");
         lV83ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV83ClienteNacionalidadeNome3), "%", "");
         lV84ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV84ClienteProfissaoNome3), "%", "");
         lV84ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV84ClienteProfissaoNome3), "%", "");
         lV85MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV85MunicipioNome3), "%", "");
         lV85MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV85MunicipioNome3), "%", "");
         lV87ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3), "%", "");
         lV87ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3), "%", "");
         lV88ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV88ResponsavelProfissaoNome3), "%", "");
         lV88ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV88ResponsavelProfissaoNome3), "%", "");
         lV89ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV89ResponsavelMunicipioNome3), "%", "");
         lV89ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV89ResponsavelMunicipioNome3), "%", "");
         lV10TFResponsavelNome = StringUtil.Concat( StringUtil.RTrim( AV10TFResponsavelNome), "%", "");
         lV12TFResponsavelCPF = StringUtil.Concat( StringUtil.RTrim( AV12TFResponsavelCPF), "%", "");
         lV16TFResponsavelEmail = StringUtil.Concat( StringUtil.RTrim( AV16TFResponsavelEmail), "%", "");
         lV20TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV20TFClienteDocumento), "%", "");
         lV22TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV22TFClienteRazaoSocial), "%", "");
         /* Using cursor P00DW6 */
         pr_default.execute(4, new Object[] {lV54ClienteDocumento1, lV54ClienteDocumento1, lV55TipoClienteDescricao1, lV55TipoClienteDescricao1, lV56ClienteConvenioDescricao1, lV56ClienteConvenioDescricao1, lV57ClienteNacionalidadeNome1, lV57ClienteNacionalidadeNome1, lV58ClienteProfissaoNome1, lV58ClienteProfissaoNome1, lV59MunicipioNome1, lV59MunicipioNome1, AV60BancoCodigo1, AV60BancoCodigo1, AV60BancoCodigo1, lV61ResponsavelNacionalidadeNome1, lV61ResponsavelNacionalidadeNome1, lV62ResponsavelProfissaoNome1, lV62ResponsavelProfissaoNome1, lV63ResponsavelMunicipioNome1, lV63ResponsavelMunicipioNome1, lV67ClienteDocumento2, lV67ClienteDocumento2, lV68TipoClienteDescricao2, lV68TipoClienteDescricao2, lV69ClienteConvenioDescricao2, lV69ClienteConvenioDescricao2, lV70ClienteNacionalidadeNome2, lV70ClienteNacionalidadeNome2, lV71ClienteProfissaoNome2, lV71ClienteProfissaoNome2, lV72MunicipioNome2, lV72MunicipioNome2, AV73BancoCodigo2, AV73BancoCodigo2, AV73BancoCodigo2, lV74ResponsavelNacionalidadeNome2, lV74ResponsavelNacionalidadeNome2, lV75ResponsavelProfissaoNome2, lV75ResponsavelProfissaoNome2, lV76ResponsavelMunicipioNome2, lV76ResponsavelMunicipioNome2, lV80ClienteDocumento3, lV80ClienteDocumento3, lV81TipoClienteDescricao3, lV81TipoClienteDescricao3, lV82ClienteConvenioDescricao3, lV82ClienteConvenioDescricao3, lV83ClienteNacionalidadeNome3, lV83ClienteNacionalidadeNome3, lV84ClienteProfissaoNome3, lV84ClienteProfissaoNome3, lV85MunicipioNome3, lV85MunicipioNome3, AV86BancoCodigo3, AV86BancoCodigo3, AV86BancoCodigo3, lV87ResponsavelNacionalidadeNome3, lV87ResponsavelNacionalidadeNome3, lV88ResponsavelProfissaoNome3, lV88ResponsavelProfissaoNome3, lV89ResponsavelMunicipioNome3, lV89ResponsavelMunicipioNome3, lV10TFResponsavelNome, AV11TFResponsavelNome_Sel, lV12TFResponsavelCPF, AV13TFResponsavelCPF_Sel, lV16TFResponsavelEmail, AV17TFResponsavelEmail_Sel, lV20TFClienteDocumento, AV21TFClienteDocumento_Sel, lV22TFClienteRazaoSocial, AV23TFClienteRazaoSocial_Sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKDW9 = false;
            A186MunicipioCodigo = P00DW6_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00DW6_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00DW6_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00DW6_n444ResponsavelMunicipio[0];
            A402BancoId = P00DW6_A402BancoId[0];
            n402BancoId = P00DW6_n402BancoId[0];
            A437ResponsavelNacionalidade = P00DW6_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00DW6_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00DW6_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00DW6_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00DW6_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00DW6_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00DW6_A487ClienteProfissao[0];
            n487ClienteProfissao = P00DW6_n487ClienteProfissao[0];
            A489ClienteConvenio = P00DW6_A489ClienteConvenio[0];
            n489ClienteConvenio = P00DW6_n489ClienteConvenio[0];
            A169ClienteDocumento = P00DW6_A169ClienteDocumento[0];
            n169ClienteDocumento = P00DW6_n169ClienteDocumento[0];
            A445ResponsavelMunicipioNome = P00DW6_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DW6_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00DW6_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DW6_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00DW6_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DW6_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00DW6_A404BancoCodigo[0];
            n404BancoCodigo = P00DW6_n404BancoCodigo[0];
            A187MunicipioNome = P00DW6_A187MunicipioNome[0];
            n187MunicipioNome = P00DW6_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00DW6_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DW6_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00DW6_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DW6_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00DW6_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DW6_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DW6_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DW6_n193TipoClienteDescricao[0];
            A192TipoClienteId = P00DW6_A192TipoClienteId[0];
            n192TipoClienteId = P00DW6_n192TipoClienteId[0];
            A174ClienteStatus = P00DW6_A174ClienteStatus[0];
            n174ClienteStatus = P00DW6_n174ClienteStatus[0];
            A884ClienteSituacao = P00DW6_A884ClienteSituacao[0];
            n884ClienteSituacao = P00DW6_n884ClienteSituacao[0];
            A170ClienteRazaoSocial = P00DW6_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00DW6_n170ClienteRazaoSocial[0];
            A885ResponsavelCargo = P00DW6_A885ResponsavelCargo[0];
            n885ResponsavelCargo = P00DW6_n885ResponsavelCargo[0];
            A456ResponsavelEmail = P00DW6_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00DW6_n456ResponsavelEmail[0];
            A447ResponsavelCPF = P00DW6_A447ResponsavelCPF[0];
            n447ResponsavelCPF = P00DW6_n447ResponsavelCPF[0];
            A436ResponsavelNome = P00DW6_A436ResponsavelNome[0];
            n436ResponsavelNome = P00DW6_n436ResponsavelNome[0];
            A455ResponsavelNumero = P00DW6_A455ResponsavelNumero[0];
            n455ResponsavelNumero = P00DW6_n455ResponsavelNumero[0];
            A454ResponsavelDDD = P00DW6_A454ResponsavelDDD[0];
            n454ResponsavelDDD = P00DW6_n454ResponsavelDDD[0];
            A168ClienteId = P00DW6_A168ClienteId[0];
            A187MunicipioNome = P00DW6_A187MunicipioNome[0];
            n187MunicipioNome = P00DW6_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00DW6_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DW6_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00DW6_A404BancoCodigo[0];
            n404BancoCodigo = P00DW6_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00DW6_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DW6_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00DW6_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DW6_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00DW6_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DW6_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00DW6_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DW6_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00DW6_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DW6_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DW6_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DW6_n193TipoClienteDescricao[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51FilterFullText)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) ||
            ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) || ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) ||
            ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) ||
            ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV51FilterFullText , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) ||
            ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) || ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) ||
            ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFResponsavelCelular_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFResponsavelCelular_F)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV14TFResponsavelCelular_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFResponsavelCelular_F_Sel)) && ! ( StringUtil.StrCmp(AV15TFResponsavelCelular_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV15TFResponsavelCelular_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV15TFResponsavelCelular_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                     {
                        AV39count = 0;
                        while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00DW6_A169ClienteDocumento[0], A169ClienteDocumento) == 0 ) )
                        {
                           BRKDW9 = false;
                           A168ClienteId = P00DW6_A168ClienteId[0];
                           AV39count = (long)(AV39count+1);
                           BRKDW9 = true;
                           pr_default.readNext(4);
                        }
                        if ( (0==AV30SkipItems) )
                        {
                           AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A169ClienteDocumento)) ? "<#Empty#>" : A169ClienteDocumento);
                           AV35Options.Add(AV34Option, 0);
                           AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV35Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV30SkipItems = (short)(AV30SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRKDW9 )
            {
               BRKDW9 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV22TFClienteRazaoSocial = AV29SearchTxt;
         AV23TFClienteRazaoSocial_Sel = "";
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV19TFResponsavelCargo_Sels ,
                                              A884ClienteSituacao ,
                                              AV28TFClienteSituacao_Sels ,
                                              AV52DynamicFiltersSelector1 ,
                                              AV53DynamicFiltersOperator1 ,
                                              AV54ClienteDocumento1 ,
                                              AV55TipoClienteDescricao1 ,
                                              AV56ClienteConvenioDescricao1 ,
                                              AV57ClienteNacionalidadeNome1 ,
                                              AV58ClienteProfissaoNome1 ,
                                              AV59MunicipioNome1 ,
                                              AV60BancoCodigo1 ,
                                              AV61ResponsavelNacionalidadeNome1 ,
                                              AV62ResponsavelProfissaoNome1 ,
                                              AV63ResponsavelMunicipioNome1 ,
                                              AV64DynamicFiltersEnabled2 ,
                                              AV65DynamicFiltersSelector2 ,
                                              AV66DynamicFiltersOperator2 ,
                                              AV67ClienteDocumento2 ,
                                              AV68TipoClienteDescricao2 ,
                                              AV69ClienteConvenioDescricao2 ,
                                              AV70ClienteNacionalidadeNome2 ,
                                              AV71ClienteProfissaoNome2 ,
                                              AV72MunicipioNome2 ,
                                              AV73BancoCodigo2 ,
                                              AV74ResponsavelNacionalidadeNome2 ,
                                              AV75ResponsavelProfissaoNome2 ,
                                              AV76ResponsavelMunicipioNome2 ,
                                              AV77DynamicFiltersEnabled3 ,
                                              AV78DynamicFiltersSelector3 ,
                                              AV79DynamicFiltersOperator3 ,
                                              AV80ClienteDocumento3 ,
                                              AV81TipoClienteDescricao3 ,
                                              AV82ClienteConvenioDescricao3 ,
                                              AV83ClienteNacionalidadeNome3 ,
                                              AV84ClienteProfissaoNome3 ,
                                              AV85MunicipioNome3 ,
                                              AV86BancoCodigo3 ,
                                              AV87ResponsavelNacionalidadeNome3 ,
                                              AV88ResponsavelProfissaoNome3 ,
                                              AV89ResponsavelMunicipioNome3 ,
                                              AV11TFResponsavelNome_Sel ,
                                              AV10TFResponsavelNome ,
                                              AV13TFResponsavelCPF_Sel ,
                                              AV12TFResponsavelCPF ,
                                              AV17TFResponsavelEmail_Sel ,
                                              AV16TFResponsavelEmail ,
                                              AV19TFResponsavelCargo_Sels.Count ,
                                              AV21TFClienteDocumento_Sel ,
                                              AV20TFClienteDocumento ,
                                              AV23TFClienteRazaoSocial_Sel ,
                                              AV22TFClienteRazaoSocial ,
                                              AV28TFClienteSituacao_Sels.Count ,
                                              AV26TFClienteStatus_Sel ,
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
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV51FilterFullText ,
                                              A577ResponsavelCelular_F ,
                                              AV15TFResponsavelCelular_F_Sel ,
                                              AV14TFResponsavelCelular_F ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV54ClienteDocumento1), "%", "");
         lV54ClienteDocumento1 = StringUtil.Concat( StringUtil.RTrim( AV54ClienteDocumento1), "%", "");
         lV55TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV55TipoClienteDescricao1), "%", "");
         lV55TipoClienteDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV55TipoClienteDescricao1), "%", "");
         lV56ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV56ClienteConvenioDescricao1), "%", "");
         lV56ClienteConvenioDescricao1 = StringUtil.Concat( StringUtil.RTrim( AV56ClienteConvenioDescricao1), "%", "");
         lV57ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV57ClienteNacionalidadeNome1), "%", "");
         lV57ClienteNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV57ClienteNacionalidadeNome1), "%", "");
         lV58ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV58ClienteProfissaoNome1), "%", "");
         lV58ClienteProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV58ClienteProfissaoNome1), "%", "");
         lV59MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV59MunicipioNome1), "%", "");
         lV59MunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV59MunicipioNome1), "%", "");
         lV61ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1), "%", "");
         lV61ResponsavelNacionalidadeNome1 = StringUtil.Concat( StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1), "%", "");
         lV62ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV62ResponsavelProfissaoNome1), "%", "");
         lV62ResponsavelProfissaoNome1 = StringUtil.Concat( StringUtil.RTrim( AV62ResponsavelProfissaoNome1), "%", "");
         lV63ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV63ResponsavelMunicipioNome1), "%", "");
         lV63ResponsavelMunicipioNome1 = StringUtil.Concat( StringUtil.RTrim( AV63ResponsavelMunicipioNome1), "%", "");
         lV67ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV67ClienteDocumento2), "%", "");
         lV67ClienteDocumento2 = StringUtil.Concat( StringUtil.RTrim( AV67ClienteDocumento2), "%", "");
         lV68TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV68TipoClienteDescricao2), "%", "");
         lV68TipoClienteDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV68TipoClienteDescricao2), "%", "");
         lV69ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV69ClienteConvenioDescricao2), "%", "");
         lV69ClienteConvenioDescricao2 = StringUtil.Concat( StringUtil.RTrim( AV69ClienteConvenioDescricao2), "%", "");
         lV70ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV70ClienteNacionalidadeNome2), "%", "");
         lV70ClienteNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV70ClienteNacionalidadeNome2), "%", "");
         lV71ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV71ClienteProfissaoNome2), "%", "");
         lV71ClienteProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV71ClienteProfissaoNome2), "%", "");
         lV72MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV72MunicipioNome2), "%", "");
         lV72MunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV72MunicipioNome2), "%", "");
         lV74ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2), "%", "");
         lV74ResponsavelNacionalidadeNome2 = StringUtil.Concat( StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2), "%", "");
         lV75ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV75ResponsavelProfissaoNome2), "%", "");
         lV75ResponsavelProfissaoNome2 = StringUtil.Concat( StringUtil.RTrim( AV75ResponsavelProfissaoNome2), "%", "");
         lV76ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV76ResponsavelMunicipioNome2), "%", "");
         lV76ResponsavelMunicipioNome2 = StringUtil.Concat( StringUtil.RTrim( AV76ResponsavelMunicipioNome2), "%", "");
         lV80ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV80ClienteDocumento3), "%", "");
         lV80ClienteDocumento3 = StringUtil.Concat( StringUtil.RTrim( AV80ClienteDocumento3), "%", "");
         lV81TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81TipoClienteDescricao3), "%", "");
         lV81TipoClienteDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV81TipoClienteDescricao3), "%", "");
         lV82ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV82ClienteConvenioDescricao3), "%", "");
         lV82ClienteConvenioDescricao3 = StringUtil.Concat( StringUtil.RTrim( AV82ClienteConvenioDescricao3), "%", "");
         lV83ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV83ClienteNacionalidadeNome3), "%", "");
         lV83ClienteNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV83ClienteNacionalidadeNome3), "%", "");
         lV84ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV84ClienteProfissaoNome3), "%", "");
         lV84ClienteProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV84ClienteProfissaoNome3), "%", "");
         lV85MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV85MunicipioNome3), "%", "");
         lV85MunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV85MunicipioNome3), "%", "");
         lV87ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3), "%", "");
         lV87ResponsavelNacionalidadeNome3 = StringUtil.Concat( StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3), "%", "");
         lV88ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV88ResponsavelProfissaoNome3), "%", "");
         lV88ResponsavelProfissaoNome3 = StringUtil.Concat( StringUtil.RTrim( AV88ResponsavelProfissaoNome3), "%", "");
         lV89ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV89ResponsavelMunicipioNome3), "%", "");
         lV89ResponsavelMunicipioNome3 = StringUtil.Concat( StringUtil.RTrim( AV89ResponsavelMunicipioNome3), "%", "");
         lV10TFResponsavelNome = StringUtil.Concat( StringUtil.RTrim( AV10TFResponsavelNome), "%", "");
         lV12TFResponsavelCPF = StringUtil.Concat( StringUtil.RTrim( AV12TFResponsavelCPF), "%", "");
         lV16TFResponsavelEmail = StringUtil.Concat( StringUtil.RTrim( AV16TFResponsavelEmail), "%", "");
         lV20TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV20TFClienteDocumento), "%", "");
         lV22TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV22TFClienteRazaoSocial), "%", "");
         /* Using cursor P00DW7 */
         pr_default.execute(5, new Object[] {lV54ClienteDocumento1, lV54ClienteDocumento1, lV55TipoClienteDescricao1, lV55TipoClienteDescricao1, lV56ClienteConvenioDescricao1, lV56ClienteConvenioDescricao1, lV57ClienteNacionalidadeNome1, lV57ClienteNacionalidadeNome1, lV58ClienteProfissaoNome1, lV58ClienteProfissaoNome1, lV59MunicipioNome1, lV59MunicipioNome1, AV60BancoCodigo1, AV60BancoCodigo1, AV60BancoCodigo1, lV61ResponsavelNacionalidadeNome1, lV61ResponsavelNacionalidadeNome1, lV62ResponsavelProfissaoNome1, lV62ResponsavelProfissaoNome1, lV63ResponsavelMunicipioNome1, lV63ResponsavelMunicipioNome1, lV67ClienteDocumento2, lV67ClienteDocumento2, lV68TipoClienteDescricao2, lV68TipoClienteDescricao2, lV69ClienteConvenioDescricao2, lV69ClienteConvenioDescricao2, lV70ClienteNacionalidadeNome2, lV70ClienteNacionalidadeNome2, lV71ClienteProfissaoNome2, lV71ClienteProfissaoNome2, lV72MunicipioNome2, lV72MunicipioNome2, AV73BancoCodigo2, AV73BancoCodigo2, AV73BancoCodigo2, lV74ResponsavelNacionalidadeNome2, lV74ResponsavelNacionalidadeNome2, lV75ResponsavelProfissaoNome2, lV75ResponsavelProfissaoNome2, lV76ResponsavelMunicipioNome2, lV76ResponsavelMunicipioNome2, lV80ClienteDocumento3, lV80ClienteDocumento3, lV81TipoClienteDescricao3, lV81TipoClienteDescricao3, lV82ClienteConvenioDescricao3, lV82ClienteConvenioDescricao3, lV83ClienteNacionalidadeNome3, lV83ClienteNacionalidadeNome3, lV84ClienteProfissaoNome3, lV84ClienteProfissaoNome3, lV85MunicipioNome3, lV85MunicipioNome3, AV86BancoCodigo3, AV86BancoCodigo3, AV86BancoCodigo3, lV87ResponsavelNacionalidadeNome3, lV87ResponsavelNacionalidadeNome3, lV88ResponsavelProfissaoNome3, lV88ResponsavelProfissaoNome3, lV89ResponsavelMunicipioNome3, lV89ResponsavelMunicipioNome3, lV10TFResponsavelNome, AV11TFResponsavelNome_Sel, lV12TFResponsavelCPF, AV13TFResponsavelCPF_Sel, lV16TFResponsavelEmail, AV17TFResponsavelEmail_Sel, lV20TFClienteDocumento, AV21TFClienteDocumento_Sel, lV22TFClienteRazaoSocial, AV23TFClienteRazaoSocial_Sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKDW11 = false;
            A186MunicipioCodigo = P00DW7_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00DW7_n186MunicipioCodigo[0];
            A444ResponsavelMunicipio = P00DW7_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = P00DW7_n444ResponsavelMunicipio[0];
            A402BancoId = P00DW7_A402BancoId[0];
            n402BancoId = P00DW7_n402BancoId[0];
            A437ResponsavelNacionalidade = P00DW7_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = P00DW7_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = P00DW7_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = P00DW7_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = P00DW7_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = P00DW7_n442ResponsavelProfissao[0];
            A487ClienteProfissao = P00DW7_A487ClienteProfissao[0];
            n487ClienteProfissao = P00DW7_n487ClienteProfissao[0];
            A489ClienteConvenio = P00DW7_A489ClienteConvenio[0];
            n489ClienteConvenio = P00DW7_n489ClienteConvenio[0];
            A192TipoClienteId = P00DW7_A192TipoClienteId[0];
            n192TipoClienteId = P00DW7_n192TipoClienteId[0];
            A170ClienteRazaoSocial = P00DW7_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00DW7_n170ClienteRazaoSocial[0];
            A445ResponsavelMunicipioNome = P00DW7_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DW7_n445ResponsavelMunicipioNome[0];
            A443ResponsavelProfissaoNome = P00DW7_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DW7_n443ResponsavelProfissaoNome[0];
            A438ResponsavelNacionalidadeNome = P00DW7_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DW7_n438ResponsavelNacionalidadeNome[0];
            A404BancoCodigo = P00DW7_A404BancoCodigo[0];
            n404BancoCodigo = P00DW7_n404BancoCodigo[0];
            A187MunicipioNome = P00DW7_A187MunicipioNome[0];
            n187MunicipioNome = P00DW7_n187MunicipioNome[0];
            A488ClienteProfissaoNome = P00DW7_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DW7_n488ClienteProfissaoNome[0];
            A485ClienteNacionalidadeNome = P00DW7_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DW7_n485ClienteNacionalidadeNome[0];
            A490ClienteConvenioDescricao = P00DW7_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DW7_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DW7_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DW7_n193TipoClienteDescricao[0];
            A174ClienteStatus = P00DW7_A174ClienteStatus[0];
            n174ClienteStatus = P00DW7_n174ClienteStatus[0];
            A884ClienteSituacao = P00DW7_A884ClienteSituacao[0];
            n884ClienteSituacao = P00DW7_n884ClienteSituacao[0];
            A169ClienteDocumento = P00DW7_A169ClienteDocumento[0];
            n169ClienteDocumento = P00DW7_n169ClienteDocumento[0];
            A885ResponsavelCargo = P00DW7_A885ResponsavelCargo[0];
            n885ResponsavelCargo = P00DW7_n885ResponsavelCargo[0];
            A456ResponsavelEmail = P00DW7_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00DW7_n456ResponsavelEmail[0];
            A447ResponsavelCPF = P00DW7_A447ResponsavelCPF[0];
            n447ResponsavelCPF = P00DW7_n447ResponsavelCPF[0];
            A436ResponsavelNome = P00DW7_A436ResponsavelNome[0];
            n436ResponsavelNome = P00DW7_n436ResponsavelNome[0];
            A455ResponsavelNumero = P00DW7_A455ResponsavelNumero[0];
            n455ResponsavelNumero = P00DW7_n455ResponsavelNumero[0];
            A454ResponsavelDDD = P00DW7_A454ResponsavelDDD[0];
            n454ResponsavelDDD = P00DW7_n454ResponsavelDDD[0];
            A168ClienteId = P00DW7_A168ClienteId[0];
            A187MunicipioNome = P00DW7_A187MunicipioNome[0];
            n187MunicipioNome = P00DW7_n187MunicipioNome[0];
            A445ResponsavelMunicipioNome = P00DW7_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = P00DW7_n445ResponsavelMunicipioNome[0];
            A404BancoCodigo = P00DW7_A404BancoCodigo[0];
            n404BancoCodigo = P00DW7_n404BancoCodigo[0];
            A438ResponsavelNacionalidadeNome = P00DW7_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = P00DW7_n438ResponsavelNacionalidadeNome[0];
            A485ClienteNacionalidadeNome = P00DW7_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = P00DW7_n485ClienteNacionalidadeNome[0];
            A443ResponsavelProfissaoNome = P00DW7_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = P00DW7_n443ResponsavelProfissaoNome[0];
            A488ClienteProfissaoNome = P00DW7_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = P00DW7_n488ClienteProfissaoNome[0];
            A490ClienteConvenioDescricao = P00DW7_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = P00DW7_n490ClienteConvenioDescricao[0];
            A193TipoClienteDescricao = P00DW7_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = P00DW7_n193TipoClienteDescricao[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51FilterFullText)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) ||
            ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) || ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) ||
            ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) ||
            ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV51FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV51FilterFullText , 150 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) || ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) ||
            ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) || ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) ||
            ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV51FilterFullText) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFResponsavelCelular_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFResponsavelCelular_F)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV14TFResponsavelCelular_F , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFResponsavelCelular_F_Sel)) && ! ( StringUtil.StrCmp(AV15TFResponsavelCelular_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV15TFResponsavelCelular_F_Sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV15TFResponsavelCelular_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                     {
                        AV39count = 0;
                        while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00DW7_A170ClienteRazaoSocial[0], A170ClienteRazaoSocial) == 0 ) )
                        {
                           BRKDW11 = false;
                           A168ClienteId = P00DW7_A168ClienteId[0];
                           AV39count = (long)(AV39count+1);
                           BRKDW11 = true;
                           pr_default.readNext(5);
                        }
                        if ( (0==AV30SkipItems) )
                        {
                           AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ClienteRazaoSocial)) ? "<#Empty#>" : A170ClienteRazaoSocial);
                           AV36OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")));
                           AV35Options.Add(AV34Option, 0);
                           AV37OptionsDesc.Add(AV36OptionDesc, 0);
                           AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV35Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV30SkipItems = (short)(AV30SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRKDW11 )
            {
               BRKDW11 = true;
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
         AV48OptionsJson = "";
         AV49OptionsDescJson = "";
         AV50OptionIndexesJson = "";
         AV35Options = new GxSimpleCollection<string>();
         AV37OptionsDesc = new GxSimpleCollection<string>();
         AV38OptionIndexes = new GxSimpleCollection<string>();
         AV29SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV42GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV43GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51FilterFullText = "";
         AV10TFResponsavelNome = "";
         AV11TFResponsavelNome_Sel = "";
         AV12TFResponsavelCPF = "";
         AV13TFResponsavelCPF_Sel = "";
         AV14TFResponsavelCelular_F = "";
         AV15TFResponsavelCelular_F_Sel = "";
         AV16TFResponsavelEmail = "";
         AV17TFResponsavelEmail_Sel = "";
         AV18TFResponsavelCargo_SelsJson = "";
         AV19TFResponsavelCargo_Sels = new GxSimpleCollection<string>();
         AV20TFClienteDocumento = "";
         AV21TFClienteDocumento_Sel = "";
         AV22TFClienteRazaoSocial = "";
         AV23TFClienteRazaoSocial_Sel = "";
         AV27TFClienteSituacao_SelsJson = "";
         AV28TFClienteSituacao_Sels = new GxSimpleCollection<string>();
         AV44GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV52DynamicFiltersSelector1 = "";
         AV54ClienteDocumento1 = "";
         AV55TipoClienteDescricao1 = "";
         AV56ClienteConvenioDescricao1 = "";
         AV57ClienteNacionalidadeNome1 = "";
         AV58ClienteProfissaoNome1 = "";
         AV59MunicipioNome1 = "";
         AV61ResponsavelNacionalidadeNome1 = "";
         AV62ResponsavelProfissaoNome1 = "";
         AV63ResponsavelMunicipioNome1 = "";
         AV65DynamicFiltersSelector2 = "";
         AV67ClienteDocumento2 = "";
         AV68TipoClienteDescricao2 = "";
         AV69ClienteConvenioDescricao2 = "";
         AV70ClienteNacionalidadeNome2 = "";
         AV71ClienteProfissaoNome2 = "";
         AV72MunicipioNome2 = "";
         AV74ResponsavelNacionalidadeNome2 = "";
         AV75ResponsavelProfissaoNome2 = "";
         AV76ResponsavelMunicipioNome2 = "";
         AV78DynamicFiltersSelector3 = "";
         AV80ClienteDocumento3 = "";
         AV81TipoClienteDescricao3 = "";
         AV82ClienteConvenioDescricao3 = "";
         AV83ClienteNacionalidadeNome3 = "";
         AV84ClienteProfissaoNome3 = "";
         AV85MunicipioNome3 = "";
         AV87ResponsavelNacionalidadeNome3 = "";
         AV88ResponsavelProfissaoNome3 = "";
         AV89ResponsavelMunicipioNome3 = "";
         lV51FilterFullText = "";
         lV54ClienteDocumento1 = "";
         lV55TipoClienteDescricao1 = "";
         lV56ClienteConvenioDescricao1 = "";
         lV57ClienteNacionalidadeNome1 = "";
         lV58ClienteProfissaoNome1 = "";
         lV59MunicipioNome1 = "";
         lV61ResponsavelNacionalidadeNome1 = "";
         lV62ResponsavelProfissaoNome1 = "";
         lV63ResponsavelMunicipioNome1 = "";
         lV67ClienteDocumento2 = "";
         lV68TipoClienteDescricao2 = "";
         lV69ClienteConvenioDescricao2 = "";
         lV70ClienteNacionalidadeNome2 = "";
         lV71ClienteProfissaoNome2 = "";
         lV72MunicipioNome2 = "";
         lV74ResponsavelNacionalidadeNome2 = "";
         lV75ResponsavelProfissaoNome2 = "";
         lV76ResponsavelMunicipioNome2 = "";
         lV80ClienteDocumento3 = "";
         lV81TipoClienteDescricao3 = "";
         lV82ClienteConvenioDescricao3 = "";
         lV83ClienteNacionalidadeNome3 = "";
         lV84ClienteProfissaoNome3 = "";
         lV85MunicipioNome3 = "";
         lV87ResponsavelNacionalidadeNome3 = "";
         lV88ResponsavelProfissaoNome3 = "";
         lV89ResponsavelMunicipioNome3 = "";
         lV10TFResponsavelNome = "";
         lV12TFResponsavelCPF = "";
         lV16TFResponsavelEmail = "";
         lV20TFClienteDocumento = "";
         lV22TFClienteRazaoSocial = "";
         A885ResponsavelCargo = "";
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
         A436ResponsavelNome = "";
         A447ResponsavelCPF = "";
         A456ResponsavelEmail = "";
         A170ClienteRazaoSocial = "";
         A577ResponsavelCelular_F = "";
         P00DW2_A186MunicipioCodigo = new string[] {""} ;
         P00DW2_n186MunicipioCodigo = new bool[] {false} ;
         P00DW2_A444ResponsavelMunicipio = new string[] {""} ;
         P00DW2_n444ResponsavelMunicipio = new bool[] {false} ;
         P00DW2_A402BancoId = new int[1] ;
         P00DW2_n402BancoId = new bool[] {false} ;
         P00DW2_A437ResponsavelNacionalidade = new int[1] ;
         P00DW2_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00DW2_A484ClienteNacionalidade = new int[1] ;
         P00DW2_n484ClienteNacionalidade = new bool[] {false} ;
         P00DW2_A442ResponsavelProfissao = new int[1] ;
         P00DW2_n442ResponsavelProfissao = new bool[] {false} ;
         P00DW2_A487ClienteProfissao = new int[1] ;
         P00DW2_n487ClienteProfissao = new bool[] {false} ;
         P00DW2_A489ClienteConvenio = new int[1] ;
         P00DW2_n489ClienteConvenio = new bool[] {false} ;
         P00DW2_A192TipoClienteId = new short[1] ;
         P00DW2_n192TipoClienteId = new bool[] {false} ;
         P00DW2_A436ResponsavelNome = new string[] {""} ;
         P00DW2_n436ResponsavelNome = new bool[] {false} ;
         P00DW2_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00DW2_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00DW2_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00DW2_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00DW2_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00DW2_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00DW2_A404BancoCodigo = new int[1] ;
         P00DW2_n404BancoCodigo = new bool[] {false} ;
         P00DW2_A187MunicipioNome = new string[] {""} ;
         P00DW2_n187MunicipioNome = new bool[] {false} ;
         P00DW2_A488ClienteProfissaoNome = new string[] {""} ;
         P00DW2_n488ClienteProfissaoNome = new bool[] {false} ;
         P00DW2_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00DW2_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00DW2_A490ClienteConvenioDescricao = new string[] {""} ;
         P00DW2_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00DW2_A193TipoClienteDescricao = new string[] {""} ;
         P00DW2_n193TipoClienteDescricao = new bool[] {false} ;
         P00DW2_A174ClienteStatus = new bool[] {false} ;
         P00DW2_n174ClienteStatus = new bool[] {false} ;
         P00DW2_A884ClienteSituacao = new string[] {""} ;
         P00DW2_n884ClienteSituacao = new bool[] {false} ;
         P00DW2_A170ClienteRazaoSocial = new string[] {""} ;
         P00DW2_n170ClienteRazaoSocial = new bool[] {false} ;
         P00DW2_A169ClienteDocumento = new string[] {""} ;
         P00DW2_n169ClienteDocumento = new bool[] {false} ;
         P00DW2_A885ResponsavelCargo = new string[] {""} ;
         P00DW2_n885ResponsavelCargo = new bool[] {false} ;
         P00DW2_A456ResponsavelEmail = new string[] {""} ;
         P00DW2_n456ResponsavelEmail = new bool[] {false} ;
         P00DW2_A447ResponsavelCPF = new string[] {""} ;
         P00DW2_n447ResponsavelCPF = new bool[] {false} ;
         P00DW2_A455ResponsavelNumero = new int[1] ;
         P00DW2_n455ResponsavelNumero = new bool[] {false} ;
         P00DW2_A454ResponsavelDDD = new short[1] ;
         P00DW2_n454ResponsavelDDD = new bool[] {false} ;
         P00DW2_A168ClienteId = new int[1] ;
         A186MunicipioCodigo = "";
         A444ResponsavelMunicipio = "";
         AV34Option = "";
         P00DW3_A186MunicipioCodigo = new string[] {""} ;
         P00DW3_n186MunicipioCodigo = new bool[] {false} ;
         P00DW3_A444ResponsavelMunicipio = new string[] {""} ;
         P00DW3_n444ResponsavelMunicipio = new bool[] {false} ;
         P00DW3_A402BancoId = new int[1] ;
         P00DW3_n402BancoId = new bool[] {false} ;
         P00DW3_A437ResponsavelNacionalidade = new int[1] ;
         P00DW3_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00DW3_A484ClienteNacionalidade = new int[1] ;
         P00DW3_n484ClienteNacionalidade = new bool[] {false} ;
         P00DW3_A442ResponsavelProfissao = new int[1] ;
         P00DW3_n442ResponsavelProfissao = new bool[] {false} ;
         P00DW3_A487ClienteProfissao = new int[1] ;
         P00DW3_n487ClienteProfissao = new bool[] {false} ;
         P00DW3_A489ClienteConvenio = new int[1] ;
         P00DW3_n489ClienteConvenio = new bool[] {false} ;
         P00DW3_A192TipoClienteId = new short[1] ;
         P00DW3_n192TipoClienteId = new bool[] {false} ;
         P00DW3_A447ResponsavelCPF = new string[] {""} ;
         P00DW3_n447ResponsavelCPF = new bool[] {false} ;
         P00DW3_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00DW3_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00DW3_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00DW3_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00DW3_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00DW3_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00DW3_A404BancoCodigo = new int[1] ;
         P00DW3_n404BancoCodigo = new bool[] {false} ;
         P00DW3_A187MunicipioNome = new string[] {""} ;
         P00DW3_n187MunicipioNome = new bool[] {false} ;
         P00DW3_A488ClienteProfissaoNome = new string[] {""} ;
         P00DW3_n488ClienteProfissaoNome = new bool[] {false} ;
         P00DW3_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00DW3_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00DW3_A490ClienteConvenioDescricao = new string[] {""} ;
         P00DW3_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00DW3_A193TipoClienteDescricao = new string[] {""} ;
         P00DW3_n193TipoClienteDescricao = new bool[] {false} ;
         P00DW3_A174ClienteStatus = new bool[] {false} ;
         P00DW3_n174ClienteStatus = new bool[] {false} ;
         P00DW3_A884ClienteSituacao = new string[] {""} ;
         P00DW3_n884ClienteSituacao = new bool[] {false} ;
         P00DW3_A170ClienteRazaoSocial = new string[] {""} ;
         P00DW3_n170ClienteRazaoSocial = new bool[] {false} ;
         P00DW3_A169ClienteDocumento = new string[] {""} ;
         P00DW3_n169ClienteDocumento = new bool[] {false} ;
         P00DW3_A885ResponsavelCargo = new string[] {""} ;
         P00DW3_n885ResponsavelCargo = new bool[] {false} ;
         P00DW3_A456ResponsavelEmail = new string[] {""} ;
         P00DW3_n456ResponsavelEmail = new bool[] {false} ;
         P00DW3_A436ResponsavelNome = new string[] {""} ;
         P00DW3_n436ResponsavelNome = new bool[] {false} ;
         P00DW3_A455ResponsavelNumero = new int[1] ;
         P00DW3_n455ResponsavelNumero = new bool[] {false} ;
         P00DW3_A454ResponsavelDDD = new short[1] ;
         P00DW3_n454ResponsavelDDD = new bool[] {false} ;
         P00DW3_A168ClienteId = new int[1] ;
         P00DW4_A186MunicipioCodigo = new string[] {""} ;
         P00DW4_n186MunicipioCodigo = new bool[] {false} ;
         P00DW4_A444ResponsavelMunicipio = new string[] {""} ;
         P00DW4_n444ResponsavelMunicipio = new bool[] {false} ;
         P00DW4_A402BancoId = new int[1] ;
         P00DW4_n402BancoId = new bool[] {false} ;
         P00DW4_A437ResponsavelNacionalidade = new int[1] ;
         P00DW4_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00DW4_A484ClienteNacionalidade = new int[1] ;
         P00DW4_n484ClienteNacionalidade = new bool[] {false} ;
         P00DW4_A442ResponsavelProfissao = new int[1] ;
         P00DW4_n442ResponsavelProfissao = new bool[] {false} ;
         P00DW4_A487ClienteProfissao = new int[1] ;
         P00DW4_n487ClienteProfissao = new bool[] {false} ;
         P00DW4_A489ClienteConvenio = new int[1] ;
         P00DW4_n489ClienteConvenio = new bool[] {false} ;
         P00DW4_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00DW4_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00DW4_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00DW4_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00DW4_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00DW4_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00DW4_A404BancoCodigo = new int[1] ;
         P00DW4_n404BancoCodigo = new bool[] {false} ;
         P00DW4_A187MunicipioNome = new string[] {""} ;
         P00DW4_n187MunicipioNome = new bool[] {false} ;
         P00DW4_A488ClienteProfissaoNome = new string[] {""} ;
         P00DW4_n488ClienteProfissaoNome = new bool[] {false} ;
         P00DW4_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00DW4_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00DW4_A490ClienteConvenioDescricao = new string[] {""} ;
         P00DW4_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00DW4_A193TipoClienteDescricao = new string[] {""} ;
         P00DW4_n193TipoClienteDescricao = new bool[] {false} ;
         P00DW4_A192TipoClienteId = new short[1] ;
         P00DW4_n192TipoClienteId = new bool[] {false} ;
         P00DW4_A174ClienteStatus = new bool[] {false} ;
         P00DW4_n174ClienteStatus = new bool[] {false} ;
         P00DW4_A884ClienteSituacao = new string[] {""} ;
         P00DW4_n884ClienteSituacao = new bool[] {false} ;
         P00DW4_A170ClienteRazaoSocial = new string[] {""} ;
         P00DW4_n170ClienteRazaoSocial = new bool[] {false} ;
         P00DW4_A169ClienteDocumento = new string[] {""} ;
         P00DW4_n169ClienteDocumento = new bool[] {false} ;
         P00DW4_A885ResponsavelCargo = new string[] {""} ;
         P00DW4_n885ResponsavelCargo = new bool[] {false} ;
         P00DW4_A456ResponsavelEmail = new string[] {""} ;
         P00DW4_n456ResponsavelEmail = new bool[] {false} ;
         P00DW4_A447ResponsavelCPF = new string[] {""} ;
         P00DW4_n447ResponsavelCPF = new bool[] {false} ;
         P00DW4_A436ResponsavelNome = new string[] {""} ;
         P00DW4_n436ResponsavelNome = new bool[] {false} ;
         P00DW4_A455ResponsavelNumero = new int[1] ;
         P00DW4_n455ResponsavelNumero = new bool[] {false} ;
         P00DW4_A454ResponsavelDDD = new short[1] ;
         P00DW4_n454ResponsavelDDD = new bool[] {false} ;
         P00DW4_A168ClienteId = new int[1] ;
         P00DW5_A186MunicipioCodigo = new string[] {""} ;
         P00DW5_n186MunicipioCodigo = new bool[] {false} ;
         P00DW5_A444ResponsavelMunicipio = new string[] {""} ;
         P00DW5_n444ResponsavelMunicipio = new bool[] {false} ;
         P00DW5_A402BancoId = new int[1] ;
         P00DW5_n402BancoId = new bool[] {false} ;
         P00DW5_A437ResponsavelNacionalidade = new int[1] ;
         P00DW5_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00DW5_A484ClienteNacionalidade = new int[1] ;
         P00DW5_n484ClienteNacionalidade = new bool[] {false} ;
         P00DW5_A442ResponsavelProfissao = new int[1] ;
         P00DW5_n442ResponsavelProfissao = new bool[] {false} ;
         P00DW5_A487ClienteProfissao = new int[1] ;
         P00DW5_n487ClienteProfissao = new bool[] {false} ;
         P00DW5_A489ClienteConvenio = new int[1] ;
         P00DW5_n489ClienteConvenio = new bool[] {false} ;
         P00DW5_A192TipoClienteId = new short[1] ;
         P00DW5_n192TipoClienteId = new bool[] {false} ;
         P00DW5_A456ResponsavelEmail = new string[] {""} ;
         P00DW5_n456ResponsavelEmail = new bool[] {false} ;
         P00DW5_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00DW5_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00DW5_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00DW5_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00DW5_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00DW5_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00DW5_A404BancoCodigo = new int[1] ;
         P00DW5_n404BancoCodigo = new bool[] {false} ;
         P00DW5_A187MunicipioNome = new string[] {""} ;
         P00DW5_n187MunicipioNome = new bool[] {false} ;
         P00DW5_A488ClienteProfissaoNome = new string[] {""} ;
         P00DW5_n488ClienteProfissaoNome = new bool[] {false} ;
         P00DW5_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00DW5_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00DW5_A490ClienteConvenioDescricao = new string[] {""} ;
         P00DW5_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00DW5_A193TipoClienteDescricao = new string[] {""} ;
         P00DW5_n193TipoClienteDescricao = new bool[] {false} ;
         P00DW5_A174ClienteStatus = new bool[] {false} ;
         P00DW5_n174ClienteStatus = new bool[] {false} ;
         P00DW5_A884ClienteSituacao = new string[] {""} ;
         P00DW5_n884ClienteSituacao = new bool[] {false} ;
         P00DW5_A170ClienteRazaoSocial = new string[] {""} ;
         P00DW5_n170ClienteRazaoSocial = new bool[] {false} ;
         P00DW5_A169ClienteDocumento = new string[] {""} ;
         P00DW5_n169ClienteDocumento = new bool[] {false} ;
         P00DW5_A885ResponsavelCargo = new string[] {""} ;
         P00DW5_n885ResponsavelCargo = new bool[] {false} ;
         P00DW5_A447ResponsavelCPF = new string[] {""} ;
         P00DW5_n447ResponsavelCPF = new bool[] {false} ;
         P00DW5_A436ResponsavelNome = new string[] {""} ;
         P00DW5_n436ResponsavelNome = new bool[] {false} ;
         P00DW5_A455ResponsavelNumero = new int[1] ;
         P00DW5_n455ResponsavelNumero = new bool[] {false} ;
         P00DW5_A454ResponsavelDDD = new short[1] ;
         P00DW5_n454ResponsavelDDD = new bool[] {false} ;
         P00DW5_A168ClienteId = new int[1] ;
         P00DW6_A186MunicipioCodigo = new string[] {""} ;
         P00DW6_n186MunicipioCodigo = new bool[] {false} ;
         P00DW6_A444ResponsavelMunicipio = new string[] {""} ;
         P00DW6_n444ResponsavelMunicipio = new bool[] {false} ;
         P00DW6_A402BancoId = new int[1] ;
         P00DW6_n402BancoId = new bool[] {false} ;
         P00DW6_A437ResponsavelNacionalidade = new int[1] ;
         P00DW6_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00DW6_A484ClienteNacionalidade = new int[1] ;
         P00DW6_n484ClienteNacionalidade = new bool[] {false} ;
         P00DW6_A442ResponsavelProfissao = new int[1] ;
         P00DW6_n442ResponsavelProfissao = new bool[] {false} ;
         P00DW6_A487ClienteProfissao = new int[1] ;
         P00DW6_n487ClienteProfissao = new bool[] {false} ;
         P00DW6_A489ClienteConvenio = new int[1] ;
         P00DW6_n489ClienteConvenio = new bool[] {false} ;
         P00DW6_A169ClienteDocumento = new string[] {""} ;
         P00DW6_n169ClienteDocumento = new bool[] {false} ;
         P00DW6_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00DW6_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00DW6_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00DW6_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00DW6_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00DW6_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00DW6_A404BancoCodigo = new int[1] ;
         P00DW6_n404BancoCodigo = new bool[] {false} ;
         P00DW6_A187MunicipioNome = new string[] {""} ;
         P00DW6_n187MunicipioNome = new bool[] {false} ;
         P00DW6_A488ClienteProfissaoNome = new string[] {""} ;
         P00DW6_n488ClienteProfissaoNome = new bool[] {false} ;
         P00DW6_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00DW6_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00DW6_A490ClienteConvenioDescricao = new string[] {""} ;
         P00DW6_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00DW6_A193TipoClienteDescricao = new string[] {""} ;
         P00DW6_n193TipoClienteDescricao = new bool[] {false} ;
         P00DW6_A192TipoClienteId = new short[1] ;
         P00DW6_n192TipoClienteId = new bool[] {false} ;
         P00DW6_A174ClienteStatus = new bool[] {false} ;
         P00DW6_n174ClienteStatus = new bool[] {false} ;
         P00DW6_A884ClienteSituacao = new string[] {""} ;
         P00DW6_n884ClienteSituacao = new bool[] {false} ;
         P00DW6_A170ClienteRazaoSocial = new string[] {""} ;
         P00DW6_n170ClienteRazaoSocial = new bool[] {false} ;
         P00DW6_A885ResponsavelCargo = new string[] {""} ;
         P00DW6_n885ResponsavelCargo = new bool[] {false} ;
         P00DW6_A456ResponsavelEmail = new string[] {""} ;
         P00DW6_n456ResponsavelEmail = new bool[] {false} ;
         P00DW6_A447ResponsavelCPF = new string[] {""} ;
         P00DW6_n447ResponsavelCPF = new bool[] {false} ;
         P00DW6_A436ResponsavelNome = new string[] {""} ;
         P00DW6_n436ResponsavelNome = new bool[] {false} ;
         P00DW6_A455ResponsavelNumero = new int[1] ;
         P00DW6_n455ResponsavelNumero = new bool[] {false} ;
         P00DW6_A454ResponsavelDDD = new short[1] ;
         P00DW6_n454ResponsavelDDD = new bool[] {false} ;
         P00DW6_A168ClienteId = new int[1] ;
         P00DW7_A186MunicipioCodigo = new string[] {""} ;
         P00DW7_n186MunicipioCodigo = new bool[] {false} ;
         P00DW7_A444ResponsavelMunicipio = new string[] {""} ;
         P00DW7_n444ResponsavelMunicipio = new bool[] {false} ;
         P00DW7_A402BancoId = new int[1] ;
         P00DW7_n402BancoId = new bool[] {false} ;
         P00DW7_A437ResponsavelNacionalidade = new int[1] ;
         P00DW7_n437ResponsavelNacionalidade = new bool[] {false} ;
         P00DW7_A484ClienteNacionalidade = new int[1] ;
         P00DW7_n484ClienteNacionalidade = new bool[] {false} ;
         P00DW7_A442ResponsavelProfissao = new int[1] ;
         P00DW7_n442ResponsavelProfissao = new bool[] {false} ;
         P00DW7_A487ClienteProfissao = new int[1] ;
         P00DW7_n487ClienteProfissao = new bool[] {false} ;
         P00DW7_A489ClienteConvenio = new int[1] ;
         P00DW7_n489ClienteConvenio = new bool[] {false} ;
         P00DW7_A192TipoClienteId = new short[1] ;
         P00DW7_n192TipoClienteId = new bool[] {false} ;
         P00DW7_A170ClienteRazaoSocial = new string[] {""} ;
         P00DW7_n170ClienteRazaoSocial = new bool[] {false} ;
         P00DW7_A445ResponsavelMunicipioNome = new string[] {""} ;
         P00DW7_n445ResponsavelMunicipioNome = new bool[] {false} ;
         P00DW7_A443ResponsavelProfissaoNome = new string[] {""} ;
         P00DW7_n443ResponsavelProfissaoNome = new bool[] {false} ;
         P00DW7_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         P00DW7_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         P00DW7_A404BancoCodigo = new int[1] ;
         P00DW7_n404BancoCodigo = new bool[] {false} ;
         P00DW7_A187MunicipioNome = new string[] {""} ;
         P00DW7_n187MunicipioNome = new bool[] {false} ;
         P00DW7_A488ClienteProfissaoNome = new string[] {""} ;
         P00DW7_n488ClienteProfissaoNome = new bool[] {false} ;
         P00DW7_A485ClienteNacionalidadeNome = new string[] {""} ;
         P00DW7_n485ClienteNacionalidadeNome = new bool[] {false} ;
         P00DW7_A490ClienteConvenioDescricao = new string[] {""} ;
         P00DW7_n490ClienteConvenioDescricao = new bool[] {false} ;
         P00DW7_A193TipoClienteDescricao = new string[] {""} ;
         P00DW7_n193TipoClienteDescricao = new bool[] {false} ;
         P00DW7_A174ClienteStatus = new bool[] {false} ;
         P00DW7_n174ClienteStatus = new bool[] {false} ;
         P00DW7_A884ClienteSituacao = new string[] {""} ;
         P00DW7_n884ClienteSituacao = new bool[] {false} ;
         P00DW7_A169ClienteDocumento = new string[] {""} ;
         P00DW7_n169ClienteDocumento = new bool[] {false} ;
         P00DW7_A885ResponsavelCargo = new string[] {""} ;
         P00DW7_n885ResponsavelCargo = new bool[] {false} ;
         P00DW7_A456ResponsavelEmail = new string[] {""} ;
         P00DW7_n456ResponsavelEmail = new bool[] {false} ;
         P00DW7_A447ResponsavelCPF = new string[] {""} ;
         P00DW7_n447ResponsavelCPF = new bool[] {false} ;
         P00DW7_A436ResponsavelNome = new string[] {""} ;
         P00DW7_n436ResponsavelNome = new bool[] {false} ;
         P00DW7_A455ResponsavelNumero = new int[1] ;
         P00DW7_n455ResponsavelNumero = new bool[] {false} ;
         P00DW7_A454ResponsavelDDD = new short[1] ;
         P00DW7_n454ResponsavelDDD = new bool[] {false} ;
         P00DW7_A168ClienteId = new int[1] ;
         GXt_char1 = "";
         AV36OptionDesc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clienterepresentanteswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00DW2_A186MunicipioCodigo, P00DW2_n186MunicipioCodigo, P00DW2_A444ResponsavelMunicipio, P00DW2_n444ResponsavelMunicipio, P00DW2_A402BancoId, P00DW2_n402BancoId, P00DW2_A437ResponsavelNacionalidade, P00DW2_n437ResponsavelNacionalidade, P00DW2_A484ClienteNacionalidade, P00DW2_n484ClienteNacionalidade,
               P00DW2_A442ResponsavelProfissao, P00DW2_n442ResponsavelProfissao, P00DW2_A487ClienteProfissao, P00DW2_n487ClienteProfissao, P00DW2_A489ClienteConvenio, P00DW2_n489ClienteConvenio, P00DW2_A192TipoClienteId, P00DW2_n192TipoClienteId, P00DW2_A436ResponsavelNome, P00DW2_n436ResponsavelNome,
               P00DW2_A445ResponsavelMunicipioNome, P00DW2_n445ResponsavelMunicipioNome, P00DW2_A443ResponsavelProfissaoNome, P00DW2_n443ResponsavelProfissaoNome, P00DW2_A438ResponsavelNacionalidadeNome, P00DW2_n438ResponsavelNacionalidadeNome, P00DW2_A404BancoCodigo, P00DW2_n404BancoCodigo, P00DW2_A187MunicipioNome, P00DW2_n187MunicipioNome,
               P00DW2_A488ClienteProfissaoNome, P00DW2_n488ClienteProfissaoNome, P00DW2_A485ClienteNacionalidadeNome, P00DW2_n485ClienteNacionalidadeNome, P00DW2_A490ClienteConvenioDescricao, P00DW2_n490ClienteConvenioDescricao, P00DW2_A193TipoClienteDescricao, P00DW2_n193TipoClienteDescricao, P00DW2_A174ClienteStatus, P00DW2_n174ClienteStatus,
               P00DW2_A884ClienteSituacao, P00DW2_n884ClienteSituacao, P00DW2_A170ClienteRazaoSocial, P00DW2_n170ClienteRazaoSocial, P00DW2_A169ClienteDocumento, P00DW2_n169ClienteDocumento, P00DW2_A885ResponsavelCargo, P00DW2_n885ResponsavelCargo, P00DW2_A456ResponsavelEmail, P00DW2_n456ResponsavelEmail,
               P00DW2_A447ResponsavelCPF, P00DW2_n447ResponsavelCPF, P00DW2_A455ResponsavelNumero, P00DW2_n455ResponsavelNumero, P00DW2_A454ResponsavelDDD, P00DW2_n454ResponsavelDDD, P00DW2_A168ClienteId
               }
               , new Object[] {
               P00DW3_A186MunicipioCodigo, P00DW3_n186MunicipioCodigo, P00DW3_A444ResponsavelMunicipio, P00DW3_n444ResponsavelMunicipio, P00DW3_A402BancoId, P00DW3_n402BancoId, P00DW3_A437ResponsavelNacionalidade, P00DW3_n437ResponsavelNacionalidade, P00DW3_A484ClienteNacionalidade, P00DW3_n484ClienteNacionalidade,
               P00DW3_A442ResponsavelProfissao, P00DW3_n442ResponsavelProfissao, P00DW3_A487ClienteProfissao, P00DW3_n487ClienteProfissao, P00DW3_A489ClienteConvenio, P00DW3_n489ClienteConvenio, P00DW3_A192TipoClienteId, P00DW3_n192TipoClienteId, P00DW3_A447ResponsavelCPF, P00DW3_n447ResponsavelCPF,
               P00DW3_A445ResponsavelMunicipioNome, P00DW3_n445ResponsavelMunicipioNome, P00DW3_A443ResponsavelProfissaoNome, P00DW3_n443ResponsavelProfissaoNome, P00DW3_A438ResponsavelNacionalidadeNome, P00DW3_n438ResponsavelNacionalidadeNome, P00DW3_A404BancoCodigo, P00DW3_n404BancoCodigo, P00DW3_A187MunicipioNome, P00DW3_n187MunicipioNome,
               P00DW3_A488ClienteProfissaoNome, P00DW3_n488ClienteProfissaoNome, P00DW3_A485ClienteNacionalidadeNome, P00DW3_n485ClienteNacionalidadeNome, P00DW3_A490ClienteConvenioDescricao, P00DW3_n490ClienteConvenioDescricao, P00DW3_A193TipoClienteDescricao, P00DW3_n193TipoClienteDescricao, P00DW3_A174ClienteStatus, P00DW3_n174ClienteStatus,
               P00DW3_A884ClienteSituacao, P00DW3_n884ClienteSituacao, P00DW3_A170ClienteRazaoSocial, P00DW3_n170ClienteRazaoSocial, P00DW3_A169ClienteDocumento, P00DW3_n169ClienteDocumento, P00DW3_A885ResponsavelCargo, P00DW3_n885ResponsavelCargo, P00DW3_A456ResponsavelEmail, P00DW3_n456ResponsavelEmail,
               P00DW3_A436ResponsavelNome, P00DW3_n436ResponsavelNome, P00DW3_A455ResponsavelNumero, P00DW3_n455ResponsavelNumero, P00DW3_A454ResponsavelDDD, P00DW3_n454ResponsavelDDD, P00DW3_A168ClienteId
               }
               , new Object[] {
               P00DW4_A186MunicipioCodigo, P00DW4_n186MunicipioCodigo, P00DW4_A444ResponsavelMunicipio, P00DW4_n444ResponsavelMunicipio, P00DW4_A402BancoId, P00DW4_n402BancoId, P00DW4_A437ResponsavelNacionalidade, P00DW4_n437ResponsavelNacionalidade, P00DW4_A484ClienteNacionalidade, P00DW4_n484ClienteNacionalidade,
               P00DW4_A442ResponsavelProfissao, P00DW4_n442ResponsavelProfissao, P00DW4_A487ClienteProfissao, P00DW4_n487ClienteProfissao, P00DW4_A489ClienteConvenio, P00DW4_n489ClienteConvenio, P00DW4_A445ResponsavelMunicipioNome, P00DW4_n445ResponsavelMunicipioNome, P00DW4_A443ResponsavelProfissaoNome, P00DW4_n443ResponsavelProfissaoNome,
               P00DW4_A438ResponsavelNacionalidadeNome, P00DW4_n438ResponsavelNacionalidadeNome, P00DW4_A404BancoCodigo, P00DW4_n404BancoCodigo, P00DW4_A187MunicipioNome, P00DW4_n187MunicipioNome, P00DW4_A488ClienteProfissaoNome, P00DW4_n488ClienteProfissaoNome, P00DW4_A485ClienteNacionalidadeNome, P00DW4_n485ClienteNacionalidadeNome,
               P00DW4_A490ClienteConvenioDescricao, P00DW4_n490ClienteConvenioDescricao, P00DW4_A193TipoClienteDescricao, P00DW4_n193TipoClienteDescricao, P00DW4_A192TipoClienteId, P00DW4_n192TipoClienteId, P00DW4_A174ClienteStatus, P00DW4_n174ClienteStatus, P00DW4_A884ClienteSituacao, P00DW4_n884ClienteSituacao,
               P00DW4_A170ClienteRazaoSocial, P00DW4_n170ClienteRazaoSocial, P00DW4_A169ClienteDocumento, P00DW4_n169ClienteDocumento, P00DW4_A885ResponsavelCargo, P00DW4_n885ResponsavelCargo, P00DW4_A456ResponsavelEmail, P00DW4_n456ResponsavelEmail, P00DW4_A447ResponsavelCPF, P00DW4_n447ResponsavelCPF,
               P00DW4_A436ResponsavelNome, P00DW4_n436ResponsavelNome, P00DW4_A455ResponsavelNumero, P00DW4_n455ResponsavelNumero, P00DW4_A454ResponsavelDDD, P00DW4_n454ResponsavelDDD, P00DW4_A168ClienteId
               }
               , new Object[] {
               P00DW5_A186MunicipioCodigo, P00DW5_n186MunicipioCodigo, P00DW5_A444ResponsavelMunicipio, P00DW5_n444ResponsavelMunicipio, P00DW5_A402BancoId, P00DW5_n402BancoId, P00DW5_A437ResponsavelNacionalidade, P00DW5_n437ResponsavelNacionalidade, P00DW5_A484ClienteNacionalidade, P00DW5_n484ClienteNacionalidade,
               P00DW5_A442ResponsavelProfissao, P00DW5_n442ResponsavelProfissao, P00DW5_A487ClienteProfissao, P00DW5_n487ClienteProfissao, P00DW5_A489ClienteConvenio, P00DW5_n489ClienteConvenio, P00DW5_A192TipoClienteId, P00DW5_n192TipoClienteId, P00DW5_A456ResponsavelEmail, P00DW5_n456ResponsavelEmail,
               P00DW5_A445ResponsavelMunicipioNome, P00DW5_n445ResponsavelMunicipioNome, P00DW5_A443ResponsavelProfissaoNome, P00DW5_n443ResponsavelProfissaoNome, P00DW5_A438ResponsavelNacionalidadeNome, P00DW5_n438ResponsavelNacionalidadeNome, P00DW5_A404BancoCodigo, P00DW5_n404BancoCodigo, P00DW5_A187MunicipioNome, P00DW5_n187MunicipioNome,
               P00DW5_A488ClienteProfissaoNome, P00DW5_n488ClienteProfissaoNome, P00DW5_A485ClienteNacionalidadeNome, P00DW5_n485ClienteNacionalidadeNome, P00DW5_A490ClienteConvenioDescricao, P00DW5_n490ClienteConvenioDescricao, P00DW5_A193TipoClienteDescricao, P00DW5_n193TipoClienteDescricao, P00DW5_A174ClienteStatus, P00DW5_n174ClienteStatus,
               P00DW5_A884ClienteSituacao, P00DW5_n884ClienteSituacao, P00DW5_A170ClienteRazaoSocial, P00DW5_n170ClienteRazaoSocial, P00DW5_A169ClienteDocumento, P00DW5_n169ClienteDocumento, P00DW5_A885ResponsavelCargo, P00DW5_n885ResponsavelCargo, P00DW5_A447ResponsavelCPF, P00DW5_n447ResponsavelCPF,
               P00DW5_A436ResponsavelNome, P00DW5_n436ResponsavelNome, P00DW5_A455ResponsavelNumero, P00DW5_n455ResponsavelNumero, P00DW5_A454ResponsavelDDD, P00DW5_n454ResponsavelDDD, P00DW5_A168ClienteId
               }
               , new Object[] {
               P00DW6_A186MunicipioCodigo, P00DW6_n186MunicipioCodigo, P00DW6_A444ResponsavelMunicipio, P00DW6_n444ResponsavelMunicipio, P00DW6_A402BancoId, P00DW6_n402BancoId, P00DW6_A437ResponsavelNacionalidade, P00DW6_n437ResponsavelNacionalidade, P00DW6_A484ClienteNacionalidade, P00DW6_n484ClienteNacionalidade,
               P00DW6_A442ResponsavelProfissao, P00DW6_n442ResponsavelProfissao, P00DW6_A487ClienteProfissao, P00DW6_n487ClienteProfissao, P00DW6_A489ClienteConvenio, P00DW6_n489ClienteConvenio, P00DW6_A169ClienteDocumento, P00DW6_n169ClienteDocumento, P00DW6_A445ResponsavelMunicipioNome, P00DW6_n445ResponsavelMunicipioNome,
               P00DW6_A443ResponsavelProfissaoNome, P00DW6_n443ResponsavelProfissaoNome, P00DW6_A438ResponsavelNacionalidadeNome, P00DW6_n438ResponsavelNacionalidadeNome, P00DW6_A404BancoCodigo, P00DW6_n404BancoCodigo, P00DW6_A187MunicipioNome, P00DW6_n187MunicipioNome, P00DW6_A488ClienteProfissaoNome, P00DW6_n488ClienteProfissaoNome,
               P00DW6_A485ClienteNacionalidadeNome, P00DW6_n485ClienteNacionalidadeNome, P00DW6_A490ClienteConvenioDescricao, P00DW6_n490ClienteConvenioDescricao, P00DW6_A193TipoClienteDescricao, P00DW6_n193TipoClienteDescricao, P00DW6_A192TipoClienteId, P00DW6_n192TipoClienteId, P00DW6_A174ClienteStatus, P00DW6_n174ClienteStatus,
               P00DW6_A884ClienteSituacao, P00DW6_n884ClienteSituacao, P00DW6_A170ClienteRazaoSocial, P00DW6_n170ClienteRazaoSocial, P00DW6_A885ResponsavelCargo, P00DW6_n885ResponsavelCargo, P00DW6_A456ResponsavelEmail, P00DW6_n456ResponsavelEmail, P00DW6_A447ResponsavelCPF, P00DW6_n447ResponsavelCPF,
               P00DW6_A436ResponsavelNome, P00DW6_n436ResponsavelNome, P00DW6_A455ResponsavelNumero, P00DW6_n455ResponsavelNumero, P00DW6_A454ResponsavelDDD, P00DW6_n454ResponsavelDDD, P00DW6_A168ClienteId
               }
               , new Object[] {
               P00DW7_A186MunicipioCodigo, P00DW7_n186MunicipioCodigo, P00DW7_A444ResponsavelMunicipio, P00DW7_n444ResponsavelMunicipio, P00DW7_A402BancoId, P00DW7_n402BancoId, P00DW7_A437ResponsavelNacionalidade, P00DW7_n437ResponsavelNacionalidade, P00DW7_A484ClienteNacionalidade, P00DW7_n484ClienteNacionalidade,
               P00DW7_A442ResponsavelProfissao, P00DW7_n442ResponsavelProfissao, P00DW7_A487ClienteProfissao, P00DW7_n487ClienteProfissao, P00DW7_A489ClienteConvenio, P00DW7_n489ClienteConvenio, P00DW7_A192TipoClienteId, P00DW7_n192TipoClienteId, P00DW7_A170ClienteRazaoSocial, P00DW7_n170ClienteRazaoSocial,
               P00DW7_A445ResponsavelMunicipioNome, P00DW7_n445ResponsavelMunicipioNome, P00DW7_A443ResponsavelProfissaoNome, P00DW7_n443ResponsavelProfissaoNome, P00DW7_A438ResponsavelNacionalidadeNome, P00DW7_n438ResponsavelNacionalidadeNome, P00DW7_A404BancoCodigo, P00DW7_n404BancoCodigo, P00DW7_A187MunicipioNome, P00DW7_n187MunicipioNome,
               P00DW7_A488ClienteProfissaoNome, P00DW7_n488ClienteProfissaoNome, P00DW7_A485ClienteNacionalidadeNome, P00DW7_n485ClienteNacionalidadeNome, P00DW7_A490ClienteConvenioDescricao, P00DW7_n490ClienteConvenioDescricao, P00DW7_A193TipoClienteDescricao, P00DW7_n193TipoClienteDescricao, P00DW7_A174ClienteStatus, P00DW7_n174ClienteStatus,
               P00DW7_A884ClienteSituacao, P00DW7_n884ClienteSituacao, P00DW7_A169ClienteDocumento, P00DW7_n169ClienteDocumento, P00DW7_A885ResponsavelCargo, P00DW7_n885ResponsavelCargo, P00DW7_A456ResponsavelEmail, P00DW7_n456ResponsavelEmail, P00DW7_A447ResponsavelCPF, P00DW7_n447ResponsavelCPF,
               P00DW7_A436ResponsavelNome, P00DW7_n436ResponsavelNome, P00DW7_A455ResponsavelNumero, P00DW7_n455ResponsavelNumero, P00DW7_A454ResponsavelDDD, P00DW7_n454ResponsavelDDD, P00DW7_A168ClienteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV32MaxItems ;
      private short AV31PageIndex ;
      private short AV30SkipItems ;
      private short AV90TipoClienteId ;
      private short AV26TFClienteStatus_Sel ;
      private short AV53DynamicFiltersOperator1 ;
      private short AV66DynamicFiltersOperator2 ;
      private short AV79DynamicFiltersOperator3 ;
      private short A192TipoClienteId ;
      private short A454ResponsavelDDD ;
      private int AV91GXV1 ;
      private int AV60BancoCodigo1 ;
      private int AV73BancoCodigo2 ;
      private int AV86BancoCodigo3 ;
      private int AV19TFResponsavelCargo_Sels_Count ;
      private int AV28TFClienteSituacao_Sels_Count ;
      private int A404BancoCodigo ;
      private int A402BancoId ;
      private int A437ResponsavelNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int A442ResponsavelProfissao ;
      private int A487ClienteProfissao ;
      private int A489ClienteConvenio ;
      private int A455ResponsavelNumero ;
      private int A168ClienteId ;
      private int AV33InsertIndex ;
      private long AV39count ;
      private string A884ClienteSituacao ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV64DynamicFiltersEnabled2 ;
      private bool AV77DynamicFiltersEnabled3 ;
      private bool A174ClienteStatus ;
      private bool BRKDW2 ;
      private bool n186MunicipioCodigo ;
      private bool n444ResponsavelMunicipio ;
      private bool n402BancoId ;
      private bool n437ResponsavelNacionalidade ;
      private bool n484ClienteNacionalidade ;
      private bool n442ResponsavelProfissao ;
      private bool n487ClienteProfissao ;
      private bool n489ClienteConvenio ;
      private bool n192TipoClienteId ;
      private bool n436ResponsavelNome ;
      private bool n445ResponsavelMunicipioNome ;
      private bool n443ResponsavelProfissaoNome ;
      private bool n438ResponsavelNacionalidadeNome ;
      private bool n404BancoCodigo ;
      private bool n187MunicipioNome ;
      private bool n488ClienteProfissaoNome ;
      private bool n485ClienteNacionalidadeNome ;
      private bool n490ClienteConvenioDescricao ;
      private bool n193TipoClienteDescricao ;
      private bool n174ClienteStatus ;
      private bool n884ClienteSituacao ;
      private bool n170ClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool n885ResponsavelCargo ;
      private bool n456ResponsavelEmail ;
      private bool n447ResponsavelCPF ;
      private bool n455ResponsavelNumero ;
      private bool n454ResponsavelDDD ;
      private bool BRKDW4 ;
      private bool BRKDW7 ;
      private bool BRKDW9 ;
      private bool BRKDW11 ;
      private string AV48OptionsJson ;
      private string AV49OptionsDescJson ;
      private string AV50OptionIndexesJson ;
      private string AV18TFResponsavelCargo_SelsJson ;
      private string AV27TFClienteSituacao_SelsJson ;
      private string AV45DDOName ;
      private string AV46SearchTxtParms ;
      private string AV47SearchTxtTo ;
      private string AV29SearchTxt ;
      private string AV51FilterFullText ;
      private string AV10TFResponsavelNome ;
      private string AV11TFResponsavelNome_Sel ;
      private string AV12TFResponsavelCPF ;
      private string AV13TFResponsavelCPF_Sel ;
      private string AV14TFResponsavelCelular_F ;
      private string AV15TFResponsavelCelular_F_Sel ;
      private string AV16TFResponsavelEmail ;
      private string AV17TFResponsavelEmail_Sel ;
      private string AV20TFClienteDocumento ;
      private string AV21TFClienteDocumento_Sel ;
      private string AV22TFClienteRazaoSocial ;
      private string AV23TFClienteRazaoSocial_Sel ;
      private string AV52DynamicFiltersSelector1 ;
      private string AV54ClienteDocumento1 ;
      private string AV55TipoClienteDescricao1 ;
      private string AV56ClienteConvenioDescricao1 ;
      private string AV57ClienteNacionalidadeNome1 ;
      private string AV58ClienteProfissaoNome1 ;
      private string AV59MunicipioNome1 ;
      private string AV61ResponsavelNacionalidadeNome1 ;
      private string AV62ResponsavelProfissaoNome1 ;
      private string AV63ResponsavelMunicipioNome1 ;
      private string AV65DynamicFiltersSelector2 ;
      private string AV67ClienteDocumento2 ;
      private string AV68TipoClienteDescricao2 ;
      private string AV69ClienteConvenioDescricao2 ;
      private string AV70ClienteNacionalidadeNome2 ;
      private string AV71ClienteProfissaoNome2 ;
      private string AV72MunicipioNome2 ;
      private string AV74ResponsavelNacionalidadeNome2 ;
      private string AV75ResponsavelProfissaoNome2 ;
      private string AV76ResponsavelMunicipioNome2 ;
      private string AV78DynamicFiltersSelector3 ;
      private string AV80ClienteDocumento3 ;
      private string AV81TipoClienteDescricao3 ;
      private string AV82ClienteConvenioDescricao3 ;
      private string AV83ClienteNacionalidadeNome3 ;
      private string AV84ClienteProfissaoNome3 ;
      private string AV85MunicipioNome3 ;
      private string AV87ResponsavelNacionalidadeNome3 ;
      private string AV88ResponsavelProfissaoNome3 ;
      private string AV89ResponsavelMunicipioNome3 ;
      private string lV51FilterFullText ;
      private string lV54ClienteDocumento1 ;
      private string lV55TipoClienteDescricao1 ;
      private string lV56ClienteConvenioDescricao1 ;
      private string lV57ClienteNacionalidadeNome1 ;
      private string lV58ClienteProfissaoNome1 ;
      private string lV59MunicipioNome1 ;
      private string lV61ResponsavelNacionalidadeNome1 ;
      private string lV62ResponsavelProfissaoNome1 ;
      private string lV63ResponsavelMunicipioNome1 ;
      private string lV67ClienteDocumento2 ;
      private string lV68TipoClienteDescricao2 ;
      private string lV69ClienteConvenioDescricao2 ;
      private string lV70ClienteNacionalidadeNome2 ;
      private string lV71ClienteProfissaoNome2 ;
      private string lV72MunicipioNome2 ;
      private string lV74ResponsavelNacionalidadeNome2 ;
      private string lV75ResponsavelProfissaoNome2 ;
      private string lV76ResponsavelMunicipioNome2 ;
      private string lV80ClienteDocumento3 ;
      private string lV81TipoClienteDescricao3 ;
      private string lV82ClienteConvenioDescricao3 ;
      private string lV83ClienteNacionalidadeNome3 ;
      private string lV84ClienteProfissaoNome3 ;
      private string lV85MunicipioNome3 ;
      private string lV87ResponsavelNacionalidadeNome3 ;
      private string lV88ResponsavelProfissaoNome3 ;
      private string lV89ResponsavelMunicipioNome3 ;
      private string lV10TFResponsavelNome ;
      private string lV12TFResponsavelCPF ;
      private string lV16TFResponsavelEmail ;
      private string lV20TFClienteDocumento ;
      private string lV22TFClienteRazaoSocial ;
      private string A885ResponsavelCargo ;
      private string A169ClienteDocumento ;
      private string A193TipoClienteDescricao ;
      private string A490ClienteConvenioDescricao ;
      private string A485ClienteNacionalidadeNome ;
      private string A488ClienteProfissaoNome ;
      private string A187MunicipioNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string A443ResponsavelProfissaoNome ;
      private string A445ResponsavelMunicipioNome ;
      private string A436ResponsavelNome ;
      private string A447ResponsavelCPF ;
      private string A456ResponsavelEmail ;
      private string A170ClienteRazaoSocial ;
      private string A577ResponsavelCelular_F ;
      private string A186MunicipioCodigo ;
      private string A444ResponsavelMunicipio ;
      private string AV34Option ;
      private string AV36OptionDesc ;
      private IGxSession AV40Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV35Options ;
      private GxSimpleCollection<string> AV37OptionsDesc ;
      private GxSimpleCollection<string> AV38OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV42GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV43GridStateFilterValue ;
      private GxSimpleCollection<string> AV19TFResponsavelCargo_Sels ;
      private GxSimpleCollection<string> AV28TFClienteSituacao_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV44GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00DW2_A186MunicipioCodigo ;
      private bool[] P00DW2_n186MunicipioCodigo ;
      private string[] P00DW2_A444ResponsavelMunicipio ;
      private bool[] P00DW2_n444ResponsavelMunicipio ;
      private int[] P00DW2_A402BancoId ;
      private bool[] P00DW2_n402BancoId ;
      private int[] P00DW2_A437ResponsavelNacionalidade ;
      private bool[] P00DW2_n437ResponsavelNacionalidade ;
      private int[] P00DW2_A484ClienteNacionalidade ;
      private bool[] P00DW2_n484ClienteNacionalidade ;
      private int[] P00DW2_A442ResponsavelProfissao ;
      private bool[] P00DW2_n442ResponsavelProfissao ;
      private int[] P00DW2_A487ClienteProfissao ;
      private bool[] P00DW2_n487ClienteProfissao ;
      private int[] P00DW2_A489ClienteConvenio ;
      private bool[] P00DW2_n489ClienteConvenio ;
      private short[] P00DW2_A192TipoClienteId ;
      private bool[] P00DW2_n192TipoClienteId ;
      private string[] P00DW2_A436ResponsavelNome ;
      private bool[] P00DW2_n436ResponsavelNome ;
      private string[] P00DW2_A445ResponsavelMunicipioNome ;
      private bool[] P00DW2_n445ResponsavelMunicipioNome ;
      private string[] P00DW2_A443ResponsavelProfissaoNome ;
      private bool[] P00DW2_n443ResponsavelProfissaoNome ;
      private string[] P00DW2_A438ResponsavelNacionalidadeNome ;
      private bool[] P00DW2_n438ResponsavelNacionalidadeNome ;
      private int[] P00DW2_A404BancoCodigo ;
      private bool[] P00DW2_n404BancoCodigo ;
      private string[] P00DW2_A187MunicipioNome ;
      private bool[] P00DW2_n187MunicipioNome ;
      private string[] P00DW2_A488ClienteProfissaoNome ;
      private bool[] P00DW2_n488ClienteProfissaoNome ;
      private string[] P00DW2_A485ClienteNacionalidadeNome ;
      private bool[] P00DW2_n485ClienteNacionalidadeNome ;
      private string[] P00DW2_A490ClienteConvenioDescricao ;
      private bool[] P00DW2_n490ClienteConvenioDescricao ;
      private string[] P00DW2_A193TipoClienteDescricao ;
      private bool[] P00DW2_n193TipoClienteDescricao ;
      private bool[] P00DW2_A174ClienteStatus ;
      private bool[] P00DW2_n174ClienteStatus ;
      private string[] P00DW2_A884ClienteSituacao ;
      private bool[] P00DW2_n884ClienteSituacao ;
      private string[] P00DW2_A170ClienteRazaoSocial ;
      private bool[] P00DW2_n170ClienteRazaoSocial ;
      private string[] P00DW2_A169ClienteDocumento ;
      private bool[] P00DW2_n169ClienteDocumento ;
      private string[] P00DW2_A885ResponsavelCargo ;
      private bool[] P00DW2_n885ResponsavelCargo ;
      private string[] P00DW2_A456ResponsavelEmail ;
      private bool[] P00DW2_n456ResponsavelEmail ;
      private string[] P00DW2_A447ResponsavelCPF ;
      private bool[] P00DW2_n447ResponsavelCPF ;
      private int[] P00DW2_A455ResponsavelNumero ;
      private bool[] P00DW2_n455ResponsavelNumero ;
      private short[] P00DW2_A454ResponsavelDDD ;
      private bool[] P00DW2_n454ResponsavelDDD ;
      private int[] P00DW2_A168ClienteId ;
      private string[] P00DW3_A186MunicipioCodigo ;
      private bool[] P00DW3_n186MunicipioCodigo ;
      private string[] P00DW3_A444ResponsavelMunicipio ;
      private bool[] P00DW3_n444ResponsavelMunicipio ;
      private int[] P00DW3_A402BancoId ;
      private bool[] P00DW3_n402BancoId ;
      private int[] P00DW3_A437ResponsavelNacionalidade ;
      private bool[] P00DW3_n437ResponsavelNacionalidade ;
      private int[] P00DW3_A484ClienteNacionalidade ;
      private bool[] P00DW3_n484ClienteNacionalidade ;
      private int[] P00DW3_A442ResponsavelProfissao ;
      private bool[] P00DW3_n442ResponsavelProfissao ;
      private int[] P00DW3_A487ClienteProfissao ;
      private bool[] P00DW3_n487ClienteProfissao ;
      private int[] P00DW3_A489ClienteConvenio ;
      private bool[] P00DW3_n489ClienteConvenio ;
      private short[] P00DW3_A192TipoClienteId ;
      private bool[] P00DW3_n192TipoClienteId ;
      private string[] P00DW3_A447ResponsavelCPF ;
      private bool[] P00DW3_n447ResponsavelCPF ;
      private string[] P00DW3_A445ResponsavelMunicipioNome ;
      private bool[] P00DW3_n445ResponsavelMunicipioNome ;
      private string[] P00DW3_A443ResponsavelProfissaoNome ;
      private bool[] P00DW3_n443ResponsavelProfissaoNome ;
      private string[] P00DW3_A438ResponsavelNacionalidadeNome ;
      private bool[] P00DW3_n438ResponsavelNacionalidadeNome ;
      private int[] P00DW3_A404BancoCodigo ;
      private bool[] P00DW3_n404BancoCodigo ;
      private string[] P00DW3_A187MunicipioNome ;
      private bool[] P00DW3_n187MunicipioNome ;
      private string[] P00DW3_A488ClienteProfissaoNome ;
      private bool[] P00DW3_n488ClienteProfissaoNome ;
      private string[] P00DW3_A485ClienteNacionalidadeNome ;
      private bool[] P00DW3_n485ClienteNacionalidadeNome ;
      private string[] P00DW3_A490ClienteConvenioDescricao ;
      private bool[] P00DW3_n490ClienteConvenioDescricao ;
      private string[] P00DW3_A193TipoClienteDescricao ;
      private bool[] P00DW3_n193TipoClienteDescricao ;
      private bool[] P00DW3_A174ClienteStatus ;
      private bool[] P00DW3_n174ClienteStatus ;
      private string[] P00DW3_A884ClienteSituacao ;
      private bool[] P00DW3_n884ClienteSituacao ;
      private string[] P00DW3_A170ClienteRazaoSocial ;
      private bool[] P00DW3_n170ClienteRazaoSocial ;
      private string[] P00DW3_A169ClienteDocumento ;
      private bool[] P00DW3_n169ClienteDocumento ;
      private string[] P00DW3_A885ResponsavelCargo ;
      private bool[] P00DW3_n885ResponsavelCargo ;
      private string[] P00DW3_A456ResponsavelEmail ;
      private bool[] P00DW3_n456ResponsavelEmail ;
      private string[] P00DW3_A436ResponsavelNome ;
      private bool[] P00DW3_n436ResponsavelNome ;
      private int[] P00DW3_A455ResponsavelNumero ;
      private bool[] P00DW3_n455ResponsavelNumero ;
      private short[] P00DW3_A454ResponsavelDDD ;
      private bool[] P00DW3_n454ResponsavelDDD ;
      private int[] P00DW3_A168ClienteId ;
      private string[] P00DW4_A186MunicipioCodigo ;
      private bool[] P00DW4_n186MunicipioCodigo ;
      private string[] P00DW4_A444ResponsavelMunicipio ;
      private bool[] P00DW4_n444ResponsavelMunicipio ;
      private int[] P00DW4_A402BancoId ;
      private bool[] P00DW4_n402BancoId ;
      private int[] P00DW4_A437ResponsavelNacionalidade ;
      private bool[] P00DW4_n437ResponsavelNacionalidade ;
      private int[] P00DW4_A484ClienteNacionalidade ;
      private bool[] P00DW4_n484ClienteNacionalidade ;
      private int[] P00DW4_A442ResponsavelProfissao ;
      private bool[] P00DW4_n442ResponsavelProfissao ;
      private int[] P00DW4_A487ClienteProfissao ;
      private bool[] P00DW4_n487ClienteProfissao ;
      private int[] P00DW4_A489ClienteConvenio ;
      private bool[] P00DW4_n489ClienteConvenio ;
      private string[] P00DW4_A445ResponsavelMunicipioNome ;
      private bool[] P00DW4_n445ResponsavelMunicipioNome ;
      private string[] P00DW4_A443ResponsavelProfissaoNome ;
      private bool[] P00DW4_n443ResponsavelProfissaoNome ;
      private string[] P00DW4_A438ResponsavelNacionalidadeNome ;
      private bool[] P00DW4_n438ResponsavelNacionalidadeNome ;
      private int[] P00DW4_A404BancoCodigo ;
      private bool[] P00DW4_n404BancoCodigo ;
      private string[] P00DW4_A187MunicipioNome ;
      private bool[] P00DW4_n187MunicipioNome ;
      private string[] P00DW4_A488ClienteProfissaoNome ;
      private bool[] P00DW4_n488ClienteProfissaoNome ;
      private string[] P00DW4_A485ClienteNacionalidadeNome ;
      private bool[] P00DW4_n485ClienteNacionalidadeNome ;
      private string[] P00DW4_A490ClienteConvenioDescricao ;
      private bool[] P00DW4_n490ClienteConvenioDescricao ;
      private string[] P00DW4_A193TipoClienteDescricao ;
      private bool[] P00DW4_n193TipoClienteDescricao ;
      private short[] P00DW4_A192TipoClienteId ;
      private bool[] P00DW4_n192TipoClienteId ;
      private bool[] P00DW4_A174ClienteStatus ;
      private bool[] P00DW4_n174ClienteStatus ;
      private string[] P00DW4_A884ClienteSituacao ;
      private bool[] P00DW4_n884ClienteSituacao ;
      private string[] P00DW4_A170ClienteRazaoSocial ;
      private bool[] P00DW4_n170ClienteRazaoSocial ;
      private string[] P00DW4_A169ClienteDocumento ;
      private bool[] P00DW4_n169ClienteDocumento ;
      private string[] P00DW4_A885ResponsavelCargo ;
      private bool[] P00DW4_n885ResponsavelCargo ;
      private string[] P00DW4_A456ResponsavelEmail ;
      private bool[] P00DW4_n456ResponsavelEmail ;
      private string[] P00DW4_A447ResponsavelCPF ;
      private bool[] P00DW4_n447ResponsavelCPF ;
      private string[] P00DW4_A436ResponsavelNome ;
      private bool[] P00DW4_n436ResponsavelNome ;
      private int[] P00DW4_A455ResponsavelNumero ;
      private bool[] P00DW4_n455ResponsavelNumero ;
      private short[] P00DW4_A454ResponsavelDDD ;
      private bool[] P00DW4_n454ResponsavelDDD ;
      private int[] P00DW4_A168ClienteId ;
      private string[] P00DW5_A186MunicipioCodigo ;
      private bool[] P00DW5_n186MunicipioCodigo ;
      private string[] P00DW5_A444ResponsavelMunicipio ;
      private bool[] P00DW5_n444ResponsavelMunicipio ;
      private int[] P00DW5_A402BancoId ;
      private bool[] P00DW5_n402BancoId ;
      private int[] P00DW5_A437ResponsavelNacionalidade ;
      private bool[] P00DW5_n437ResponsavelNacionalidade ;
      private int[] P00DW5_A484ClienteNacionalidade ;
      private bool[] P00DW5_n484ClienteNacionalidade ;
      private int[] P00DW5_A442ResponsavelProfissao ;
      private bool[] P00DW5_n442ResponsavelProfissao ;
      private int[] P00DW5_A487ClienteProfissao ;
      private bool[] P00DW5_n487ClienteProfissao ;
      private int[] P00DW5_A489ClienteConvenio ;
      private bool[] P00DW5_n489ClienteConvenio ;
      private short[] P00DW5_A192TipoClienteId ;
      private bool[] P00DW5_n192TipoClienteId ;
      private string[] P00DW5_A456ResponsavelEmail ;
      private bool[] P00DW5_n456ResponsavelEmail ;
      private string[] P00DW5_A445ResponsavelMunicipioNome ;
      private bool[] P00DW5_n445ResponsavelMunicipioNome ;
      private string[] P00DW5_A443ResponsavelProfissaoNome ;
      private bool[] P00DW5_n443ResponsavelProfissaoNome ;
      private string[] P00DW5_A438ResponsavelNacionalidadeNome ;
      private bool[] P00DW5_n438ResponsavelNacionalidadeNome ;
      private int[] P00DW5_A404BancoCodigo ;
      private bool[] P00DW5_n404BancoCodigo ;
      private string[] P00DW5_A187MunicipioNome ;
      private bool[] P00DW5_n187MunicipioNome ;
      private string[] P00DW5_A488ClienteProfissaoNome ;
      private bool[] P00DW5_n488ClienteProfissaoNome ;
      private string[] P00DW5_A485ClienteNacionalidadeNome ;
      private bool[] P00DW5_n485ClienteNacionalidadeNome ;
      private string[] P00DW5_A490ClienteConvenioDescricao ;
      private bool[] P00DW5_n490ClienteConvenioDescricao ;
      private string[] P00DW5_A193TipoClienteDescricao ;
      private bool[] P00DW5_n193TipoClienteDescricao ;
      private bool[] P00DW5_A174ClienteStatus ;
      private bool[] P00DW5_n174ClienteStatus ;
      private string[] P00DW5_A884ClienteSituacao ;
      private bool[] P00DW5_n884ClienteSituacao ;
      private string[] P00DW5_A170ClienteRazaoSocial ;
      private bool[] P00DW5_n170ClienteRazaoSocial ;
      private string[] P00DW5_A169ClienteDocumento ;
      private bool[] P00DW5_n169ClienteDocumento ;
      private string[] P00DW5_A885ResponsavelCargo ;
      private bool[] P00DW5_n885ResponsavelCargo ;
      private string[] P00DW5_A447ResponsavelCPF ;
      private bool[] P00DW5_n447ResponsavelCPF ;
      private string[] P00DW5_A436ResponsavelNome ;
      private bool[] P00DW5_n436ResponsavelNome ;
      private int[] P00DW5_A455ResponsavelNumero ;
      private bool[] P00DW5_n455ResponsavelNumero ;
      private short[] P00DW5_A454ResponsavelDDD ;
      private bool[] P00DW5_n454ResponsavelDDD ;
      private int[] P00DW5_A168ClienteId ;
      private string[] P00DW6_A186MunicipioCodigo ;
      private bool[] P00DW6_n186MunicipioCodigo ;
      private string[] P00DW6_A444ResponsavelMunicipio ;
      private bool[] P00DW6_n444ResponsavelMunicipio ;
      private int[] P00DW6_A402BancoId ;
      private bool[] P00DW6_n402BancoId ;
      private int[] P00DW6_A437ResponsavelNacionalidade ;
      private bool[] P00DW6_n437ResponsavelNacionalidade ;
      private int[] P00DW6_A484ClienteNacionalidade ;
      private bool[] P00DW6_n484ClienteNacionalidade ;
      private int[] P00DW6_A442ResponsavelProfissao ;
      private bool[] P00DW6_n442ResponsavelProfissao ;
      private int[] P00DW6_A487ClienteProfissao ;
      private bool[] P00DW6_n487ClienteProfissao ;
      private int[] P00DW6_A489ClienteConvenio ;
      private bool[] P00DW6_n489ClienteConvenio ;
      private string[] P00DW6_A169ClienteDocumento ;
      private bool[] P00DW6_n169ClienteDocumento ;
      private string[] P00DW6_A445ResponsavelMunicipioNome ;
      private bool[] P00DW6_n445ResponsavelMunicipioNome ;
      private string[] P00DW6_A443ResponsavelProfissaoNome ;
      private bool[] P00DW6_n443ResponsavelProfissaoNome ;
      private string[] P00DW6_A438ResponsavelNacionalidadeNome ;
      private bool[] P00DW6_n438ResponsavelNacionalidadeNome ;
      private int[] P00DW6_A404BancoCodigo ;
      private bool[] P00DW6_n404BancoCodigo ;
      private string[] P00DW6_A187MunicipioNome ;
      private bool[] P00DW6_n187MunicipioNome ;
      private string[] P00DW6_A488ClienteProfissaoNome ;
      private bool[] P00DW6_n488ClienteProfissaoNome ;
      private string[] P00DW6_A485ClienteNacionalidadeNome ;
      private bool[] P00DW6_n485ClienteNacionalidadeNome ;
      private string[] P00DW6_A490ClienteConvenioDescricao ;
      private bool[] P00DW6_n490ClienteConvenioDescricao ;
      private string[] P00DW6_A193TipoClienteDescricao ;
      private bool[] P00DW6_n193TipoClienteDescricao ;
      private short[] P00DW6_A192TipoClienteId ;
      private bool[] P00DW6_n192TipoClienteId ;
      private bool[] P00DW6_A174ClienteStatus ;
      private bool[] P00DW6_n174ClienteStatus ;
      private string[] P00DW6_A884ClienteSituacao ;
      private bool[] P00DW6_n884ClienteSituacao ;
      private string[] P00DW6_A170ClienteRazaoSocial ;
      private bool[] P00DW6_n170ClienteRazaoSocial ;
      private string[] P00DW6_A885ResponsavelCargo ;
      private bool[] P00DW6_n885ResponsavelCargo ;
      private string[] P00DW6_A456ResponsavelEmail ;
      private bool[] P00DW6_n456ResponsavelEmail ;
      private string[] P00DW6_A447ResponsavelCPF ;
      private bool[] P00DW6_n447ResponsavelCPF ;
      private string[] P00DW6_A436ResponsavelNome ;
      private bool[] P00DW6_n436ResponsavelNome ;
      private int[] P00DW6_A455ResponsavelNumero ;
      private bool[] P00DW6_n455ResponsavelNumero ;
      private short[] P00DW6_A454ResponsavelDDD ;
      private bool[] P00DW6_n454ResponsavelDDD ;
      private int[] P00DW6_A168ClienteId ;
      private string[] P00DW7_A186MunicipioCodigo ;
      private bool[] P00DW7_n186MunicipioCodigo ;
      private string[] P00DW7_A444ResponsavelMunicipio ;
      private bool[] P00DW7_n444ResponsavelMunicipio ;
      private int[] P00DW7_A402BancoId ;
      private bool[] P00DW7_n402BancoId ;
      private int[] P00DW7_A437ResponsavelNacionalidade ;
      private bool[] P00DW7_n437ResponsavelNacionalidade ;
      private int[] P00DW7_A484ClienteNacionalidade ;
      private bool[] P00DW7_n484ClienteNacionalidade ;
      private int[] P00DW7_A442ResponsavelProfissao ;
      private bool[] P00DW7_n442ResponsavelProfissao ;
      private int[] P00DW7_A487ClienteProfissao ;
      private bool[] P00DW7_n487ClienteProfissao ;
      private int[] P00DW7_A489ClienteConvenio ;
      private bool[] P00DW7_n489ClienteConvenio ;
      private short[] P00DW7_A192TipoClienteId ;
      private bool[] P00DW7_n192TipoClienteId ;
      private string[] P00DW7_A170ClienteRazaoSocial ;
      private bool[] P00DW7_n170ClienteRazaoSocial ;
      private string[] P00DW7_A445ResponsavelMunicipioNome ;
      private bool[] P00DW7_n445ResponsavelMunicipioNome ;
      private string[] P00DW7_A443ResponsavelProfissaoNome ;
      private bool[] P00DW7_n443ResponsavelProfissaoNome ;
      private string[] P00DW7_A438ResponsavelNacionalidadeNome ;
      private bool[] P00DW7_n438ResponsavelNacionalidadeNome ;
      private int[] P00DW7_A404BancoCodigo ;
      private bool[] P00DW7_n404BancoCodigo ;
      private string[] P00DW7_A187MunicipioNome ;
      private bool[] P00DW7_n187MunicipioNome ;
      private string[] P00DW7_A488ClienteProfissaoNome ;
      private bool[] P00DW7_n488ClienteProfissaoNome ;
      private string[] P00DW7_A485ClienteNacionalidadeNome ;
      private bool[] P00DW7_n485ClienteNacionalidadeNome ;
      private string[] P00DW7_A490ClienteConvenioDescricao ;
      private bool[] P00DW7_n490ClienteConvenioDescricao ;
      private string[] P00DW7_A193TipoClienteDescricao ;
      private bool[] P00DW7_n193TipoClienteDescricao ;
      private bool[] P00DW7_A174ClienteStatus ;
      private bool[] P00DW7_n174ClienteStatus ;
      private string[] P00DW7_A884ClienteSituacao ;
      private bool[] P00DW7_n884ClienteSituacao ;
      private string[] P00DW7_A169ClienteDocumento ;
      private bool[] P00DW7_n169ClienteDocumento ;
      private string[] P00DW7_A885ResponsavelCargo ;
      private bool[] P00DW7_n885ResponsavelCargo ;
      private string[] P00DW7_A456ResponsavelEmail ;
      private bool[] P00DW7_n456ResponsavelEmail ;
      private string[] P00DW7_A447ResponsavelCPF ;
      private bool[] P00DW7_n447ResponsavelCPF ;
      private string[] P00DW7_A436ResponsavelNome ;
      private bool[] P00DW7_n436ResponsavelNome ;
      private int[] P00DW7_A455ResponsavelNumero ;
      private bool[] P00DW7_n455ResponsavelNumero ;
      private short[] P00DW7_A454ResponsavelDDD ;
      private bool[] P00DW7_n454ResponsavelDDD ;
      private int[] P00DW7_A168ClienteId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class clienterepresentanteswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DW2( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV19TFResponsavelCargo_Sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV28TFClienteSituacao_Sels ,
                                             string AV52DynamicFiltersSelector1 ,
                                             short AV53DynamicFiltersOperator1 ,
                                             string AV54ClienteDocumento1 ,
                                             string AV55TipoClienteDescricao1 ,
                                             string AV56ClienteConvenioDescricao1 ,
                                             string AV57ClienteNacionalidadeNome1 ,
                                             string AV58ClienteProfissaoNome1 ,
                                             string AV59MunicipioNome1 ,
                                             int AV60BancoCodigo1 ,
                                             string AV61ResponsavelNacionalidadeNome1 ,
                                             string AV62ResponsavelProfissaoNome1 ,
                                             string AV63ResponsavelMunicipioNome1 ,
                                             bool AV64DynamicFiltersEnabled2 ,
                                             string AV65DynamicFiltersSelector2 ,
                                             short AV66DynamicFiltersOperator2 ,
                                             string AV67ClienteDocumento2 ,
                                             string AV68TipoClienteDescricao2 ,
                                             string AV69ClienteConvenioDescricao2 ,
                                             string AV70ClienteNacionalidadeNome2 ,
                                             string AV71ClienteProfissaoNome2 ,
                                             string AV72MunicipioNome2 ,
                                             int AV73BancoCodigo2 ,
                                             string AV74ResponsavelNacionalidadeNome2 ,
                                             string AV75ResponsavelProfissaoNome2 ,
                                             string AV76ResponsavelMunicipioNome2 ,
                                             bool AV77DynamicFiltersEnabled3 ,
                                             string AV78DynamicFiltersSelector3 ,
                                             short AV79DynamicFiltersOperator3 ,
                                             string AV80ClienteDocumento3 ,
                                             string AV81TipoClienteDescricao3 ,
                                             string AV82ClienteConvenioDescricao3 ,
                                             string AV83ClienteNacionalidadeNome3 ,
                                             string AV84ClienteProfissaoNome3 ,
                                             string AV85MunicipioNome3 ,
                                             int AV86BancoCodigo3 ,
                                             string AV87ResponsavelNacionalidadeNome3 ,
                                             string AV88ResponsavelProfissaoNome3 ,
                                             string AV89ResponsavelMunicipioNome3 ,
                                             string AV11TFResponsavelNome_Sel ,
                                             string AV10TFResponsavelNome ,
                                             string AV13TFResponsavelCPF_Sel ,
                                             string AV12TFResponsavelCPF ,
                                             string AV17TFResponsavelEmail_Sel ,
                                             string AV16TFResponsavelEmail ,
                                             int AV19TFResponsavelCargo_Sels_Count ,
                                             string AV21TFClienteDocumento_Sel ,
                                             string AV20TFClienteDocumento ,
                                             string AV23TFClienteRazaoSocial_Sel ,
                                             string AV22TFClienteRazaoSocial ,
                                             int AV28TFClienteSituacao_Sels_Count ,
                                             short AV26TFClienteStatus_Sel ,
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
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             string AV51FilterFullText ,
                                             string A577ResponsavelCelular_F ,
                                             string AV15TFResponsavelCelular_F_Sel ,
                                             string AV14TFResponsavelCelular_F ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[73];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.TipoClienteId, T1.ResponsavelNome, T3.MunicipioNome AS ResponsavelMunicipioNome, T7.ProfissaoNome AS ResponsavelProfissaoNome, T5.NacionalidadeNome AS ResponsavelNacionalidadeNome, T4.BancoCodigo, T2.MunicipioNome, T8.ProfissaoNome AS ClienteProfissaoNome, T6.NacionalidadeNome AS ClienteNacionalidadeNome, T9.ConvenioDescricao AS ClienteConvenioDescricao, T10.TipoClienteDescricao, T1.ClienteStatus, T1.ClienteSituacao, T1.ClienteRazaoSocial, T1.ClienteDocumento, T1.ResponsavelCargo, T1.ResponsavelEmail, T1.ResponsavelCPF, T1.ResponsavelNumero, T1.ResponsavelDDD, T1.ClienteId FROM (((((((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T5 ON T5.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T7 ON T7.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T9 ON T9.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T10 ON T10.TipoClienteId = T1.TipoClienteId)";
         AddWhere(sWhereString, "(T1.TipoClienteId = 4)");
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV54ClienteDocumento1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV54ClienteDocumento1)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV55TipoClienteDescricao1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV55TipoClienteDescricao1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV56ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV56ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV57ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV57ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV58ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV58ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV59MunicipioNome1)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV59MunicipioNome1)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 2 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV61ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV61ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV62ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV62ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV63ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV63ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV67ClienteDocumento2)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV67ClienteDocumento2)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV68TipoClienteDescricao2)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV68TipoClienteDescricao2)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV69ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV69ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV70ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV70ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV71ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV71ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV72MunicipioNome2)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV72MunicipioNome2)");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 2 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV74ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int2[36] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV74ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int2[37] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV75ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int2[38] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV75ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int2[39] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV76ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int2[40] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV76ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int2[41] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV80ClienteDocumento3)");
         }
         else
         {
            GXv_int2[42] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV80ClienteDocumento3)");
         }
         else
         {
            GXv_int2[43] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV81TipoClienteDescricao3)");
         }
         else
         {
            GXv_int2[44] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV81TipoClienteDescricao3)");
         }
         else
         {
            GXv_int2[45] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV82ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int2[46] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV82ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int2[47] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV83ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int2[48] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV83ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int2[49] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV84ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int2[50] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV84ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int2[51] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV85MunicipioNome3)");
         }
         else
         {
            GXv_int2[52] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV85MunicipioNome3)");
         }
         else
         {
            GXv_int2[53] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int2[54] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int2[55] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 2 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int2[56] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV87ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int2[57] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV87ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int2[58] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV88ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int2[59] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV88ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int2[60] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV89ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int2[61] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV89ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int2[62] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFResponsavelNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFResponsavelNome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV10TFResponsavelNome)");
         }
         else
         {
            GXv_int2[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFResponsavelNome_Sel)) && ! ( StringUtil.StrCmp(AV11TFResponsavelNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV11TFResponsavelNome_Sel))");
         }
         else
         {
            GXv_int2[64] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFResponsavelNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFResponsavelCPF_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFResponsavelCPF)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF like :lV12TFResponsavelCPF)");
         }
         else
         {
            GXv_int2[65] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFResponsavelCPF_Sel)) && ! ( StringUtil.StrCmp(AV13TFResponsavelCPF_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF = ( :AV13TFResponsavelCPF_Sel))");
         }
         else
         {
            GXv_int2[66] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFResponsavelCPF_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFResponsavelEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFResponsavelEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV16TFResponsavelEmail)");
         }
         else
         {
            GXv_int2[67] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFResponsavelEmail_Sel)) && ! ( StringUtil.StrCmp(AV17TFResponsavelEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV17TFResponsavelEmail_Sel))");
         }
         else
         {
            GXv_int2[68] = 1;
         }
         if ( StringUtil.StrCmp(AV17TFResponsavelEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( AV19TFResponsavelCargo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV19TFResponsavelCargo_Sels, "T1.ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV20TFClienteDocumento)");
         }
         else
         {
            GXv_int2[69] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV21TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV21TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int2[70] = 1;
         }
         if ( StringUtil.StrCmp(AV21TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV22TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int2[71] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV23TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV23TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int2[72] = 1;
         }
         if ( StringUtil.StrCmp(AV23TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( AV28TFClienteSituacao_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV28TFClienteSituacao_Sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         if ( AV26TFClienteStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV26TFClienteStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResponsavelNome";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00DW3( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV19TFResponsavelCargo_Sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV28TFClienteSituacao_Sels ,
                                             string AV52DynamicFiltersSelector1 ,
                                             short AV53DynamicFiltersOperator1 ,
                                             string AV54ClienteDocumento1 ,
                                             string AV55TipoClienteDescricao1 ,
                                             string AV56ClienteConvenioDescricao1 ,
                                             string AV57ClienteNacionalidadeNome1 ,
                                             string AV58ClienteProfissaoNome1 ,
                                             string AV59MunicipioNome1 ,
                                             int AV60BancoCodigo1 ,
                                             string AV61ResponsavelNacionalidadeNome1 ,
                                             string AV62ResponsavelProfissaoNome1 ,
                                             string AV63ResponsavelMunicipioNome1 ,
                                             bool AV64DynamicFiltersEnabled2 ,
                                             string AV65DynamicFiltersSelector2 ,
                                             short AV66DynamicFiltersOperator2 ,
                                             string AV67ClienteDocumento2 ,
                                             string AV68TipoClienteDescricao2 ,
                                             string AV69ClienteConvenioDescricao2 ,
                                             string AV70ClienteNacionalidadeNome2 ,
                                             string AV71ClienteProfissaoNome2 ,
                                             string AV72MunicipioNome2 ,
                                             int AV73BancoCodigo2 ,
                                             string AV74ResponsavelNacionalidadeNome2 ,
                                             string AV75ResponsavelProfissaoNome2 ,
                                             string AV76ResponsavelMunicipioNome2 ,
                                             bool AV77DynamicFiltersEnabled3 ,
                                             string AV78DynamicFiltersSelector3 ,
                                             short AV79DynamicFiltersOperator3 ,
                                             string AV80ClienteDocumento3 ,
                                             string AV81TipoClienteDescricao3 ,
                                             string AV82ClienteConvenioDescricao3 ,
                                             string AV83ClienteNacionalidadeNome3 ,
                                             string AV84ClienteProfissaoNome3 ,
                                             string AV85MunicipioNome3 ,
                                             int AV86BancoCodigo3 ,
                                             string AV87ResponsavelNacionalidadeNome3 ,
                                             string AV88ResponsavelProfissaoNome3 ,
                                             string AV89ResponsavelMunicipioNome3 ,
                                             string AV11TFResponsavelNome_Sel ,
                                             string AV10TFResponsavelNome ,
                                             string AV13TFResponsavelCPF_Sel ,
                                             string AV12TFResponsavelCPF ,
                                             string AV17TFResponsavelEmail_Sel ,
                                             string AV16TFResponsavelEmail ,
                                             int AV19TFResponsavelCargo_Sels_Count ,
                                             string AV21TFClienteDocumento_Sel ,
                                             string AV20TFClienteDocumento ,
                                             string AV23TFClienteRazaoSocial_Sel ,
                                             string AV22TFClienteRazaoSocial ,
                                             int AV28TFClienteSituacao_Sels_Count ,
                                             short AV26TFClienteStatus_Sel ,
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
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             string AV51FilterFullText ,
                                             string A577ResponsavelCelular_F ,
                                             string AV15TFResponsavelCelular_F_Sel ,
                                             string AV14TFResponsavelCelular_F ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[73];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.TipoClienteId, T1.ResponsavelCPF, T3.MunicipioNome AS ResponsavelMunicipioNome, T7.ProfissaoNome AS ResponsavelProfissaoNome, T5.NacionalidadeNome AS ResponsavelNacionalidadeNome, T4.BancoCodigo, T2.MunicipioNome, T8.ProfissaoNome AS ClienteProfissaoNome, T6.NacionalidadeNome AS ClienteNacionalidadeNome, T9.ConvenioDescricao AS ClienteConvenioDescricao, T10.TipoClienteDescricao, T1.ClienteStatus, T1.ClienteSituacao, T1.ClienteRazaoSocial, T1.ClienteDocumento, T1.ResponsavelCargo, T1.ResponsavelEmail, T1.ResponsavelNome, T1.ResponsavelNumero, T1.ResponsavelDDD, T1.ClienteId FROM (((((((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T5 ON T5.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T7 ON T7.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T9 ON T9.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T10 ON T10.TipoClienteId = T1.TipoClienteId)";
         AddWhere(sWhereString, "(T1.TipoClienteId = 4)");
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV54ClienteDocumento1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV54ClienteDocumento1)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV55TipoClienteDescricao1)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV55TipoClienteDescricao1)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV56ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV56ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV57ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV57ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV58ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV58ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV59MunicipioNome1)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV59MunicipioNome1)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 2 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV61ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV61ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV62ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV62ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV63ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV63ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV67ClienteDocumento2)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV67ClienteDocumento2)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV68TipoClienteDescricao2)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV68TipoClienteDescricao2)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV69ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV69ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV70ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV70ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV71ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV71ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV72MunicipioNome2)");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV72MunicipioNome2)");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int4[34] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 2 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int4[35] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV74ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int4[36] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV74ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int4[37] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV75ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int4[38] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV75ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int4[39] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV76ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int4[40] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV76ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int4[41] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV80ClienteDocumento3)");
         }
         else
         {
            GXv_int4[42] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV80ClienteDocumento3)");
         }
         else
         {
            GXv_int4[43] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV81TipoClienteDescricao3)");
         }
         else
         {
            GXv_int4[44] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV81TipoClienteDescricao3)");
         }
         else
         {
            GXv_int4[45] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV82ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int4[46] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV82ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int4[47] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV83ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int4[48] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV83ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int4[49] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV84ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int4[50] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV84ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int4[51] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV85MunicipioNome3)");
         }
         else
         {
            GXv_int4[52] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV85MunicipioNome3)");
         }
         else
         {
            GXv_int4[53] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int4[54] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int4[55] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 2 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int4[56] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV87ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int4[57] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV87ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int4[58] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV88ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int4[59] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV88ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int4[60] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV89ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int4[61] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV89ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int4[62] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFResponsavelNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFResponsavelNome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV10TFResponsavelNome)");
         }
         else
         {
            GXv_int4[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFResponsavelNome_Sel)) && ! ( StringUtil.StrCmp(AV11TFResponsavelNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV11TFResponsavelNome_Sel))");
         }
         else
         {
            GXv_int4[64] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFResponsavelNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFResponsavelCPF_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFResponsavelCPF)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF like :lV12TFResponsavelCPF)");
         }
         else
         {
            GXv_int4[65] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFResponsavelCPF_Sel)) && ! ( StringUtil.StrCmp(AV13TFResponsavelCPF_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF = ( :AV13TFResponsavelCPF_Sel))");
         }
         else
         {
            GXv_int4[66] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFResponsavelCPF_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFResponsavelEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFResponsavelEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV16TFResponsavelEmail)");
         }
         else
         {
            GXv_int4[67] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFResponsavelEmail_Sel)) && ! ( StringUtil.StrCmp(AV17TFResponsavelEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV17TFResponsavelEmail_Sel))");
         }
         else
         {
            GXv_int4[68] = 1;
         }
         if ( StringUtil.StrCmp(AV17TFResponsavelEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( AV19TFResponsavelCargo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV19TFResponsavelCargo_Sels, "T1.ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV20TFClienteDocumento)");
         }
         else
         {
            GXv_int4[69] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV21TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV21TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int4[70] = 1;
         }
         if ( StringUtil.StrCmp(AV21TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV22TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int4[71] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV23TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV23TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int4[72] = 1;
         }
         if ( StringUtil.StrCmp(AV23TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( AV28TFClienteSituacao_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV28TFClienteSituacao_Sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         if ( AV26TFClienteStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV26TFClienteStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResponsavelCPF";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00DW4( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV19TFResponsavelCargo_Sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV28TFClienteSituacao_Sels ,
                                             string AV52DynamicFiltersSelector1 ,
                                             short AV53DynamicFiltersOperator1 ,
                                             string AV54ClienteDocumento1 ,
                                             string AV55TipoClienteDescricao1 ,
                                             string AV56ClienteConvenioDescricao1 ,
                                             string AV57ClienteNacionalidadeNome1 ,
                                             string AV58ClienteProfissaoNome1 ,
                                             string AV59MunicipioNome1 ,
                                             int AV60BancoCodigo1 ,
                                             string AV61ResponsavelNacionalidadeNome1 ,
                                             string AV62ResponsavelProfissaoNome1 ,
                                             string AV63ResponsavelMunicipioNome1 ,
                                             bool AV64DynamicFiltersEnabled2 ,
                                             string AV65DynamicFiltersSelector2 ,
                                             short AV66DynamicFiltersOperator2 ,
                                             string AV67ClienteDocumento2 ,
                                             string AV68TipoClienteDescricao2 ,
                                             string AV69ClienteConvenioDescricao2 ,
                                             string AV70ClienteNacionalidadeNome2 ,
                                             string AV71ClienteProfissaoNome2 ,
                                             string AV72MunicipioNome2 ,
                                             int AV73BancoCodigo2 ,
                                             string AV74ResponsavelNacionalidadeNome2 ,
                                             string AV75ResponsavelProfissaoNome2 ,
                                             string AV76ResponsavelMunicipioNome2 ,
                                             bool AV77DynamicFiltersEnabled3 ,
                                             string AV78DynamicFiltersSelector3 ,
                                             short AV79DynamicFiltersOperator3 ,
                                             string AV80ClienteDocumento3 ,
                                             string AV81TipoClienteDescricao3 ,
                                             string AV82ClienteConvenioDescricao3 ,
                                             string AV83ClienteNacionalidadeNome3 ,
                                             string AV84ClienteProfissaoNome3 ,
                                             string AV85MunicipioNome3 ,
                                             int AV86BancoCodigo3 ,
                                             string AV87ResponsavelNacionalidadeNome3 ,
                                             string AV88ResponsavelProfissaoNome3 ,
                                             string AV89ResponsavelMunicipioNome3 ,
                                             string AV11TFResponsavelNome_Sel ,
                                             string AV10TFResponsavelNome ,
                                             string AV13TFResponsavelCPF_Sel ,
                                             string AV12TFResponsavelCPF ,
                                             string AV17TFResponsavelEmail_Sel ,
                                             string AV16TFResponsavelEmail ,
                                             int AV19TFResponsavelCargo_Sels_Count ,
                                             string AV21TFClienteDocumento_Sel ,
                                             string AV20TFClienteDocumento ,
                                             string AV23TFClienteRazaoSocial_Sel ,
                                             string AV22TFClienteRazaoSocial ,
                                             int AV28TFClienteSituacao_Sels_Count ,
                                             short AV26TFClienteStatus_Sel ,
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
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             string AV51FilterFullText ,
                                             string A577ResponsavelCelular_F ,
                                             string AV15TFResponsavelCelular_F_Sel ,
                                             string AV14TFResponsavelCelular_F ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[73];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T3.MunicipioNome AS ResponsavelMunicipioNome, T7.ProfissaoNome AS ResponsavelProfissaoNome, T5.NacionalidadeNome AS ResponsavelNacionalidadeNome, T4.BancoCodigo, T2.MunicipioNome, T8.ProfissaoNome AS ClienteProfissaoNome, T6.NacionalidadeNome AS ClienteNacionalidadeNome, T9.ConvenioDescricao AS ClienteConvenioDescricao, T10.TipoClienteDescricao, T1.TipoClienteId, T1.ClienteStatus, T1.ClienteSituacao, T1.ClienteRazaoSocial, T1.ClienteDocumento, T1.ResponsavelCargo, T1.ResponsavelEmail, T1.ResponsavelCPF, T1.ResponsavelNome, T1.ResponsavelNumero, T1.ResponsavelDDD, T1.ClienteId FROM (((((((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T5 ON T5.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T7 ON T7.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T9 ON T9.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T10 ON T10.TipoClienteId = T1.TipoClienteId)";
         AddWhere(sWhereString, "(T1.TipoClienteId = 4)");
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV54ClienteDocumento1)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV54ClienteDocumento1)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV55TipoClienteDescricao1)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV55TipoClienteDescricao1)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV56ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV56ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV57ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV57ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV58ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV58ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV59MunicipioNome1)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV59MunicipioNome1)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 2 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV61ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV61ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV62ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV62ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV63ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV63ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV67ClienteDocumento2)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV67ClienteDocumento2)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV68TipoClienteDescricao2)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV68TipoClienteDescricao2)");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV69ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV69ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int6[26] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV70ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int6[27] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV70ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int6[28] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV71ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int6[29] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV71ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int6[30] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV72MunicipioNome2)");
         }
         else
         {
            GXv_int6[31] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV72MunicipioNome2)");
         }
         else
         {
            GXv_int6[32] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int6[33] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int6[34] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 2 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int6[35] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV74ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int6[36] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV74ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int6[37] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV75ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int6[38] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV75ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int6[39] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV76ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int6[40] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV76ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int6[41] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV80ClienteDocumento3)");
         }
         else
         {
            GXv_int6[42] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV80ClienteDocumento3)");
         }
         else
         {
            GXv_int6[43] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV81TipoClienteDescricao3)");
         }
         else
         {
            GXv_int6[44] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV81TipoClienteDescricao3)");
         }
         else
         {
            GXv_int6[45] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV82ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int6[46] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV82ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int6[47] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV83ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int6[48] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV83ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int6[49] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV84ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int6[50] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV84ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int6[51] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV85MunicipioNome3)");
         }
         else
         {
            GXv_int6[52] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV85MunicipioNome3)");
         }
         else
         {
            GXv_int6[53] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int6[54] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int6[55] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 2 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int6[56] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV87ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int6[57] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV87ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int6[58] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV88ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int6[59] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV88ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int6[60] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV89ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int6[61] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV89ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int6[62] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFResponsavelNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFResponsavelNome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV10TFResponsavelNome)");
         }
         else
         {
            GXv_int6[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFResponsavelNome_Sel)) && ! ( StringUtil.StrCmp(AV11TFResponsavelNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV11TFResponsavelNome_Sel))");
         }
         else
         {
            GXv_int6[64] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFResponsavelNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFResponsavelCPF_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFResponsavelCPF)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF like :lV12TFResponsavelCPF)");
         }
         else
         {
            GXv_int6[65] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFResponsavelCPF_Sel)) && ! ( StringUtil.StrCmp(AV13TFResponsavelCPF_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF = ( :AV13TFResponsavelCPF_Sel))");
         }
         else
         {
            GXv_int6[66] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFResponsavelCPF_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFResponsavelEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFResponsavelEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV16TFResponsavelEmail)");
         }
         else
         {
            GXv_int6[67] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFResponsavelEmail_Sel)) && ! ( StringUtil.StrCmp(AV17TFResponsavelEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV17TFResponsavelEmail_Sel))");
         }
         else
         {
            GXv_int6[68] = 1;
         }
         if ( StringUtil.StrCmp(AV17TFResponsavelEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( AV19TFResponsavelCargo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV19TFResponsavelCargo_Sels, "T1.ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV20TFClienteDocumento)");
         }
         else
         {
            GXv_int6[69] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV21TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV21TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int6[70] = 1;
         }
         if ( StringUtil.StrCmp(AV21TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV22TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int6[71] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV23TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV23TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int6[72] = 1;
         }
         if ( StringUtil.StrCmp(AV23TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( AV28TFClienteSituacao_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV28TFClienteSituacao_Sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         if ( AV26TFClienteStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV26TFClienteStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.TipoClienteId";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00DW5( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV19TFResponsavelCargo_Sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV28TFClienteSituacao_Sels ,
                                             string AV52DynamicFiltersSelector1 ,
                                             short AV53DynamicFiltersOperator1 ,
                                             string AV54ClienteDocumento1 ,
                                             string AV55TipoClienteDescricao1 ,
                                             string AV56ClienteConvenioDescricao1 ,
                                             string AV57ClienteNacionalidadeNome1 ,
                                             string AV58ClienteProfissaoNome1 ,
                                             string AV59MunicipioNome1 ,
                                             int AV60BancoCodigo1 ,
                                             string AV61ResponsavelNacionalidadeNome1 ,
                                             string AV62ResponsavelProfissaoNome1 ,
                                             string AV63ResponsavelMunicipioNome1 ,
                                             bool AV64DynamicFiltersEnabled2 ,
                                             string AV65DynamicFiltersSelector2 ,
                                             short AV66DynamicFiltersOperator2 ,
                                             string AV67ClienteDocumento2 ,
                                             string AV68TipoClienteDescricao2 ,
                                             string AV69ClienteConvenioDescricao2 ,
                                             string AV70ClienteNacionalidadeNome2 ,
                                             string AV71ClienteProfissaoNome2 ,
                                             string AV72MunicipioNome2 ,
                                             int AV73BancoCodigo2 ,
                                             string AV74ResponsavelNacionalidadeNome2 ,
                                             string AV75ResponsavelProfissaoNome2 ,
                                             string AV76ResponsavelMunicipioNome2 ,
                                             bool AV77DynamicFiltersEnabled3 ,
                                             string AV78DynamicFiltersSelector3 ,
                                             short AV79DynamicFiltersOperator3 ,
                                             string AV80ClienteDocumento3 ,
                                             string AV81TipoClienteDescricao3 ,
                                             string AV82ClienteConvenioDescricao3 ,
                                             string AV83ClienteNacionalidadeNome3 ,
                                             string AV84ClienteProfissaoNome3 ,
                                             string AV85MunicipioNome3 ,
                                             int AV86BancoCodigo3 ,
                                             string AV87ResponsavelNacionalidadeNome3 ,
                                             string AV88ResponsavelProfissaoNome3 ,
                                             string AV89ResponsavelMunicipioNome3 ,
                                             string AV11TFResponsavelNome_Sel ,
                                             string AV10TFResponsavelNome ,
                                             string AV13TFResponsavelCPF_Sel ,
                                             string AV12TFResponsavelCPF ,
                                             string AV17TFResponsavelEmail_Sel ,
                                             string AV16TFResponsavelEmail ,
                                             int AV19TFResponsavelCargo_Sels_Count ,
                                             string AV21TFClienteDocumento_Sel ,
                                             string AV20TFClienteDocumento ,
                                             string AV23TFClienteRazaoSocial_Sel ,
                                             string AV22TFClienteRazaoSocial ,
                                             int AV28TFClienteSituacao_Sels_Count ,
                                             short AV26TFClienteStatus_Sel ,
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
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             string AV51FilterFullText ,
                                             string A577ResponsavelCelular_F ,
                                             string AV15TFResponsavelCelular_F_Sel ,
                                             string AV14TFResponsavelCelular_F ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[73];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.TipoClienteId, T1.ResponsavelEmail, T3.MunicipioNome AS ResponsavelMunicipioNome, T7.ProfissaoNome AS ResponsavelProfissaoNome, T5.NacionalidadeNome AS ResponsavelNacionalidadeNome, T4.BancoCodigo, T2.MunicipioNome, T8.ProfissaoNome AS ClienteProfissaoNome, T6.NacionalidadeNome AS ClienteNacionalidadeNome, T9.ConvenioDescricao AS ClienteConvenioDescricao, T10.TipoClienteDescricao, T1.ClienteStatus, T1.ClienteSituacao, T1.ClienteRazaoSocial, T1.ClienteDocumento, T1.ResponsavelCargo, T1.ResponsavelCPF, T1.ResponsavelNome, T1.ResponsavelNumero, T1.ResponsavelDDD, T1.ClienteId FROM (((((((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T5 ON T5.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T7 ON T7.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T9 ON T9.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T10 ON T10.TipoClienteId = T1.TipoClienteId)";
         AddWhere(sWhereString, "(T1.TipoClienteId = 4)");
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV54ClienteDocumento1)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV54ClienteDocumento1)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV55TipoClienteDescricao1)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV55TipoClienteDescricao1)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV56ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV56ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV57ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV57ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV58ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV58ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV59MunicipioNome1)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV59MunicipioNome1)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 2 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV61ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV61ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV62ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV62ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV63ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV63ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV67ClienteDocumento2)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV67ClienteDocumento2)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV68TipoClienteDescricao2)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV68TipoClienteDescricao2)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV69ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV69ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV70ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV70ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV71ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV71ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV72MunicipioNome2)");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV72MunicipioNome2)");
         }
         else
         {
            GXv_int8[32] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int8[33] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int8[34] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 2 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int8[35] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV74ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int8[36] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV74ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int8[37] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV75ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int8[38] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV75ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int8[39] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV76ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int8[40] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV76ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int8[41] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV80ClienteDocumento3)");
         }
         else
         {
            GXv_int8[42] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV80ClienteDocumento3)");
         }
         else
         {
            GXv_int8[43] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV81TipoClienteDescricao3)");
         }
         else
         {
            GXv_int8[44] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV81TipoClienteDescricao3)");
         }
         else
         {
            GXv_int8[45] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV82ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int8[46] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV82ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int8[47] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV83ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int8[48] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV83ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int8[49] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV84ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int8[50] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV84ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int8[51] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV85MunicipioNome3)");
         }
         else
         {
            GXv_int8[52] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV85MunicipioNome3)");
         }
         else
         {
            GXv_int8[53] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int8[54] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int8[55] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 2 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int8[56] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV87ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int8[57] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV87ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int8[58] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV88ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int8[59] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV88ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int8[60] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV89ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int8[61] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV89ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int8[62] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFResponsavelNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFResponsavelNome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV10TFResponsavelNome)");
         }
         else
         {
            GXv_int8[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFResponsavelNome_Sel)) && ! ( StringUtil.StrCmp(AV11TFResponsavelNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV11TFResponsavelNome_Sel))");
         }
         else
         {
            GXv_int8[64] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFResponsavelNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFResponsavelCPF_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFResponsavelCPF)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF like :lV12TFResponsavelCPF)");
         }
         else
         {
            GXv_int8[65] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFResponsavelCPF_Sel)) && ! ( StringUtil.StrCmp(AV13TFResponsavelCPF_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF = ( :AV13TFResponsavelCPF_Sel))");
         }
         else
         {
            GXv_int8[66] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFResponsavelCPF_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFResponsavelEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFResponsavelEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV16TFResponsavelEmail)");
         }
         else
         {
            GXv_int8[67] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFResponsavelEmail_Sel)) && ! ( StringUtil.StrCmp(AV17TFResponsavelEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV17TFResponsavelEmail_Sel))");
         }
         else
         {
            GXv_int8[68] = 1;
         }
         if ( StringUtil.StrCmp(AV17TFResponsavelEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( AV19TFResponsavelCargo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV19TFResponsavelCargo_Sels, "T1.ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV20TFClienteDocumento)");
         }
         else
         {
            GXv_int8[69] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV21TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV21TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int8[70] = 1;
         }
         if ( StringUtil.StrCmp(AV21TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV22TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int8[71] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV23TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV23TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int8[72] = 1;
         }
         if ( StringUtil.StrCmp(AV23TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( AV28TFClienteSituacao_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV28TFClienteSituacao_Sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         if ( AV26TFClienteStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV26TFClienteStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ResponsavelEmail";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00DW6( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV19TFResponsavelCargo_Sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV28TFClienteSituacao_Sels ,
                                             string AV52DynamicFiltersSelector1 ,
                                             short AV53DynamicFiltersOperator1 ,
                                             string AV54ClienteDocumento1 ,
                                             string AV55TipoClienteDescricao1 ,
                                             string AV56ClienteConvenioDescricao1 ,
                                             string AV57ClienteNacionalidadeNome1 ,
                                             string AV58ClienteProfissaoNome1 ,
                                             string AV59MunicipioNome1 ,
                                             int AV60BancoCodigo1 ,
                                             string AV61ResponsavelNacionalidadeNome1 ,
                                             string AV62ResponsavelProfissaoNome1 ,
                                             string AV63ResponsavelMunicipioNome1 ,
                                             bool AV64DynamicFiltersEnabled2 ,
                                             string AV65DynamicFiltersSelector2 ,
                                             short AV66DynamicFiltersOperator2 ,
                                             string AV67ClienteDocumento2 ,
                                             string AV68TipoClienteDescricao2 ,
                                             string AV69ClienteConvenioDescricao2 ,
                                             string AV70ClienteNacionalidadeNome2 ,
                                             string AV71ClienteProfissaoNome2 ,
                                             string AV72MunicipioNome2 ,
                                             int AV73BancoCodigo2 ,
                                             string AV74ResponsavelNacionalidadeNome2 ,
                                             string AV75ResponsavelProfissaoNome2 ,
                                             string AV76ResponsavelMunicipioNome2 ,
                                             bool AV77DynamicFiltersEnabled3 ,
                                             string AV78DynamicFiltersSelector3 ,
                                             short AV79DynamicFiltersOperator3 ,
                                             string AV80ClienteDocumento3 ,
                                             string AV81TipoClienteDescricao3 ,
                                             string AV82ClienteConvenioDescricao3 ,
                                             string AV83ClienteNacionalidadeNome3 ,
                                             string AV84ClienteProfissaoNome3 ,
                                             string AV85MunicipioNome3 ,
                                             int AV86BancoCodigo3 ,
                                             string AV87ResponsavelNacionalidadeNome3 ,
                                             string AV88ResponsavelProfissaoNome3 ,
                                             string AV89ResponsavelMunicipioNome3 ,
                                             string AV11TFResponsavelNome_Sel ,
                                             string AV10TFResponsavelNome ,
                                             string AV13TFResponsavelCPF_Sel ,
                                             string AV12TFResponsavelCPF ,
                                             string AV17TFResponsavelEmail_Sel ,
                                             string AV16TFResponsavelEmail ,
                                             int AV19TFResponsavelCargo_Sels_Count ,
                                             string AV21TFClienteDocumento_Sel ,
                                             string AV20TFClienteDocumento ,
                                             string AV23TFClienteRazaoSocial_Sel ,
                                             string AV22TFClienteRazaoSocial ,
                                             int AV28TFClienteSituacao_Sels_Count ,
                                             short AV26TFClienteStatus_Sel ,
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
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             string AV51FilterFullText ,
                                             string A577ResponsavelCelular_F ,
                                             string AV15TFResponsavelCelular_F_Sel ,
                                             string AV14TFResponsavelCelular_F ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[73];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.ClienteDocumento, T3.MunicipioNome AS ResponsavelMunicipioNome, T7.ProfissaoNome AS ResponsavelProfissaoNome, T5.NacionalidadeNome AS ResponsavelNacionalidadeNome, T4.BancoCodigo, T2.MunicipioNome, T8.ProfissaoNome AS ClienteProfissaoNome, T6.NacionalidadeNome AS ClienteNacionalidadeNome, T9.ConvenioDescricao AS ClienteConvenioDescricao, T10.TipoClienteDescricao, T1.TipoClienteId, T1.ClienteStatus, T1.ClienteSituacao, T1.ClienteRazaoSocial, T1.ResponsavelCargo, T1.ResponsavelEmail, T1.ResponsavelCPF, T1.ResponsavelNome, T1.ResponsavelNumero, T1.ResponsavelDDD, T1.ClienteId FROM (((((((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T5 ON T5.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T7 ON T7.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T9 ON T9.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T10 ON T10.TipoClienteId = T1.TipoClienteId)";
         AddWhere(sWhereString, "(T1.TipoClienteId = 4)");
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV54ClienteDocumento1)");
         }
         else
         {
            GXv_int10[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV54ClienteDocumento1)");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV55TipoClienteDescricao1)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV55TipoClienteDescricao1)");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV56ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV56ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV57ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV57ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV58ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV58ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV59MunicipioNome1)");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV59MunicipioNome1)");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 2 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV61ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV61ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV62ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV62ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV63ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV63ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV67ClienteDocumento2)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV67ClienteDocumento2)");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV68TipoClienteDescricao2)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV68TipoClienteDescricao2)");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV69ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV69ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV70ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV70ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV71ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV71ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV72MunicipioNome2)");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV72MunicipioNome2)");
         }
         else
         {
            GXv_int10[32] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int10[33] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int10[34] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 2 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int10[35] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV74ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int10[36] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV74ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int10[37] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV75ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int10[38] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV75ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int10[39] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV76ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int10[40] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV76ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int10[41] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV80ClienteDocumento3)");
         }
         else
         {
            GXv_int10[42] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV80ClienteDocumento3)");
         }
         else
         {
            GXv_int10[43] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV81TipoClienteDescricao3)");
         }
         else
         {
            GXv_int10[44] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV81TipoClienteDescricao3)");
         }
         else
         {
            GXv_int10[45] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV82ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int10[46] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV82ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int10[47] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV83ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int10[48] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV83ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int10[49] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV84ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int10[50] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV84ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int10[51] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV85MunicipioNome3)");
         }
         else
         {
            GXv_int10[52] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV85MunicipioNome3)");
         }
         else
         {
            GXv_int10[53] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int10[54] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int10[55] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 2 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int10[56] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV87ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int10[57] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV87ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int10[58] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV88ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int10[59] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV88ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int10[60] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV89ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int10[61] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV89ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int10[62] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFResponsavelNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFResponsavelNome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV10TFResponsavelNome)");
         }
         else
         {
            GXv_int10[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFResponsavelNome_Sel)) && ! ( StringUtil.StrCmp(AV11TFResponsavelNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV11TFResponsavelNome_Sel))");
         }
         else
         {
            GXv_int10[64] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFResponsavelNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFResponsavelCPF_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFResponsavelCPF)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF like :lV12TFResponsavelCPF)");
         }
         else
         {
            GXv_int10[65] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFResponsavelCPF_Sel)) && ! ( StringUtil.StrCmp(AV13TFResponsavelCPF_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF = ( :AV13TFResponsavelCPF_Sel))");
         }
         else
         {
            GXv_int10[66] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFResponsavelCPF_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFResponsavelEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFResponsavelEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV16TFResponsavelEmail)");
         }
         else
         {
            GXv_int10[67] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFResponsavelEmail_Sel)) && ! ( StringUtil.StrCmp(AV17TFResponsavelEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV17TFResponsavelEmail_Sel))");
         }
         else
         {
            GXv_int10[68] = 1;
         }
         if ( StringUtil.StrCmp(AV17TFResponsavelEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( AV19TFResponsavelCargo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV19TFResponsavelCargo_Sels, "T1.ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV20TFClienteDocumento)");
         }
         else
         {
            GXv_int10[69] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV21TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV21TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int10[70] = 1;
         }
         if ( StringUtil.StrCmp(AV21TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV22TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int10[71] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV23TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV23TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int10[72] = 1;
         }
         if ( StringUtil.StrCmp(AV23TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( AV28TFClienteSituacao_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV28TFClienteSituacao_Sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         if ( AV26TFClienteStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV26TFClienteStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteDocumento";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_P00DW7( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV19TFResponsavelCargo_Sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV28TFClienteSituacao_Sels ,
                                             string AV52DynamicFiltersSelector1 ,
                                             short AV53DynamicFiltersOperator1 ,
                                             string AV54ClienteDocumento1 ,
                                             string AV55TipoClienteDescricao1 ,
                                             string AV56ClienteConvenioDescricao1 ,
                                             string AV57ClienteNacionalidadeNome1 ,
                                             string AV58ClienteProfissaoNome1 ,
                                             string AV59MunicipioNome1 ,
                                             int AV60BancoCodigo1 ,
                                             string AV61ResponsavelNacionalidadeNome1 ,
                                             string AV62ResponsavelProfissaoNome1 ,
                                             string AV63ResponsavelMunicipioNome1 ,
                                             bool AV64DynamicFiltersEnabled2 ,
                                             string AV65DynamicFiltersSelector2 ,
                                             short AV66DynamicFiltersOperator2 ,
                                             string AV67ClienteDocumento2 ,
                                             string AV68TipoClienteDescricao2 ,
                                             string AV69ClienteConvenioDescricao2 ,
                                             string AV70ClienteNacionalidadeNome2 ,
                                             string AV71ClienteProfissaoNome2 ,
                                             string AV72MunicipioNome2 ,
                                             int AV73BancoCodigo2 ,
                                             string AV74ResponsavelNacionalidadeNome2 ,
                                             string AV75ResponsavelProfissaoNome2 ,
                                             string AV76ResponsavelMunicipioNome2 ,
                                             bool AV77DynamicFiltersEnabled3 ,
                                             string AV78DynamicFiltersSelector3 ,
                                             short AV79DynamicFiltersOperator3 ,
                                             string AV80ClienteDocumento3 ,
                                             string AV81TipoClienteDescricao3 ,
                                             string AV82ClienteConvenioDescricao3 ,
                                             string AV83ClienteNacionalidadeNome3 ,
                                             string AV84ClienteProfissaoNome3 ,
                                             string AV85MunicipioNome3 ,
                                             int AV86BancoCodigo3 ,
                                             string AV87ResponsavelNacionalidadeNome3 ,
                                             string AV88ResponsavelProfissaoNome3 ,
                                             string AV89ResponsavelMunicipioNome3 ,
                                             string AV11TFResponsavelNome_Sel ,
                                             string AV10TFResponsavelNome ,
                                             string AV13TFResponsavelCPF_Sel ,
                                             string AV12TFResponsavelCPF ,
                                             string AV17TFResponsavelEmail_Sel ,
                                             string AV16TFResponsavelEmail ,
                                             int AV19TFResponsavelCargo_Sels_Count ,
                                             string AV21TFClienteDocumento_Sel ,
                                             string AV20TFClienteDocumento ,
                                             string AV23TFClienteRazaoSocial_Sel ,
                                             string AV22TFClienteRazaoSocial ,
                                             int AV28TFClienteSituacao_Sels_Count ,
                                             short AV26TFClienteStatus_Sel ,
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
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             string AV51FilterFullText ,
                                             string A577ResponsavelCelular_F ,
                                             string AV15TFResponsavelCelular_F_Sel ,
                                             string AV14TFResponsavelCelular_F ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[73];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T1.MunicipioCodigo, T1.ResponsavelMunicipio AS ResponsavelMunicipio, T1.BancoId, T1.ResponsavelNacionalidade AS ResponsavelNacionalidade, T1.ClienteNacionalidade AS ClienteNacionalidade, T1.ResponsavelProfissao AS ResponsavelProfissao, T1.ClienteProfissao AS ClienteProfissao, T1.ClienteConvenio AS ClienteConvenio, T1.TipoClienteId, T1.ClienteRazaoSocial, T3.MunicipioNome AS ResponsavelMunicipioNome, T7.ProfissaoNome AS ResponsavelProfissaoNome, T5.NacionalidadeNome AS ResponsavelNacionalidadeNome, T4.BancoCodigo, T2.MunicipioNome, T8.ProfissaoNome AS ClienteProfissaoNome, T6.NacionalidadeNome AS ClienteNacionalidadeNome, T9.ConvenioDescricao AS ClienteConvenioDescricao, T10.TipoClienteDescricao, T1.ClienteStatus, T1.ClienteSituacao, T1.ClienteDocumento, T1.ResponsavelCargo, T1.ResponsavelEmail, T1.ResponsavelCPF, T1.ResponsavelNome, T1.ResponsavelNumero, T1.ResponsavelDDD, T1.ClienteId FROM (((((((((Cliente T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.MunicipioCodigo) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = T1.BancoId) LEFT JOIN Nacionalidade T5 ON T5.NacionalidadeId = T1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = T1.ClienteNacionalidade) LEFT JOIN Profissao T7 ON T7.ProfissaoId = T1.ResponsavelProfissao) LEFT JOIN Profissao T8 ON T8.ProfissaoId = T1.ClienteProfissao) LEFT JOIN Convenio T9 ON T9.ConvenioId = T1.ClienteConvenio) LEFT JOIN TipoCliente T10 ON T10.TipoClienteId = T1.TipoClienteId)";
         AddWhere(sWhereString, "(T1.TipoClienteId = 4)");
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV54ClienteDocumento1)");
         }
         else
         {
            GXv_int12[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54ClienteDocumento1)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV54ClienteDocumento1)");
         }
         else
         {
            GXv_int12[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV55TipoClienteDescricao1)");
         }
         else
         {
            GXv_int12[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TipoClienteDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV55TipoClienteDescricao1)");
         }
         else
         {
            GXv_int12[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV56ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int12[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56ClienteConvenioDescricao1)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV56ClienteConvenioDescricao1)");
         }
         else
         {
            GXv_int12[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV57ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57ClienteNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV57ClienteNacionalidadeNome1)");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV58ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "CLIENTEPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58ClienteProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV58ClienteProfissaoNome1)");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV59MunicipioNome1)");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "MUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59MunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV59MunicipioNome1)");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "BANCOCODIGO") == 0 ) && ( AV53DynamicFiltersOperator1 == 2 ) && ( ! (0==AV60BancoCodigo1) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV60BancoCodigo1)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV61ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61ResponsavelNacionalidadeNome1)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV61ResponsavelNacionalidadeNome1)");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV62ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62ResponsavelProfissaoNome1)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV62ResponsavelProfissaoNome1)");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV63ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV53DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63ResponsavelMunicipioNome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV63ResponsavelMunicipioNome1)");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV67ClienteDocumento2)");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67ClienteDocumento2)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV67ClienteDocumento2)");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV68TipoClienteDescricao2)");
         }
         else
         {
            GXv_int12[23] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TipoClienteDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV68TipoClienteDescricao2)");
         }
         else
         {
            GXv_int12[24] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV69ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int12[25] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69ClienteConvenioDescricao2)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV69ClienteConvenioDescricao2)");
         }
         else
         {
            GXv_int12[26] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV70ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int12[27] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70ClienteNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV70ClienteNacionalidadeNome2)");
         }
         else
         {
            GXv_int12[28] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV71ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int12[29] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "CLIENTEPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71ClienteProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV71ClienteProfissaoNome2)");
         }
         else
         {
            GXv_int12[30] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV72MunicipioNome2)");
         }
         else
         {
            GXv_int12[31] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "MUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72MunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV72MunicipioNome2)");
         }
         else
         {
            GXv_int12[32] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int12[33] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int12[34] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "BANCOCODIGO") == 0 ) && ( AV66DynamicFiltersOperator2 == 2 ) && ( ! (0==AV73BancoCodigo2) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV73BancoCodigo2)");
         }
         else
         {
            GXv_int12[35] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV74ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int12[36] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ResponsavelNacionalidadeNome2)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV74ResponsavelNacionalidadeNome2)");
         }
         else
         {
            GXv_int12[37] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV75ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int12[38] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ResponsavelProfissaoNome2)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV75ResponsavelProfissaoNome2)");
         }
         else
         {
            GXv_int12[39] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV76ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int12[40] = 1;
         }
         if ( AV64DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV65DynamicFiltersSelector2, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV66DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76ResponsavelMunicipioNome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV76ResponsavelMunicipioNome2)");
         }
         else
         {
            GXv_int12[41] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV80ClienteDocumento3)");
         }
         else
         {
            GXv_int12[42] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80ClienteDocumento3)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like '%' || :lV80ClienteDocumento3)");
         }
         else
         {
            GXv_int12[43] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like :lV81TipoClienteDescricao3)");
         }
         else
         {
            GXv_int12[44] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "TIPOCLIENTEDESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TipoClienteDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T10.TipoClienteDescricao like '%' || :lV81TipoClienteDescricao3)");
         }
         else
         {
            GXv_int12[45] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like :lV82ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int12[46] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTECONVENIODESCRICAO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82ClienteConvenioDescricao3)) ) )
         {
            AddWhere(sWhereString, "(T9.ConvenioDescricao like '%' || :lV82ClienteConvenioDescricao3)");
         }
         else
         {
            GXv_int12[47] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like :lV83ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int12[48] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTENACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ClienteNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T6.NacionalidadeNome like '%' || :lV83ClienteNacionalidadeNome3)");
         }
         else
         {
            GXv_int12[49] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like :lV84ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int12[50] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "CLIENTEPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84ClienteProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T8.ProfissaoNome like '%' || :lV84ClienteProfissaoNome3)");
         }
         else
         {
            GXv_int12[51] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV85MunicipioNome3)");
         }
         else
         {
            GXv_int12[52] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "MUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85MunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV85MunicipioNome3)");
         }
         else
         {
            GXv_int12[53] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo < :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int12[54] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo = :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int12[55] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "BANCOCODIGO") == 0 ) && ( AV79DynamicFiltersOperator3 == 2 ) && ( ! (0==AV86BancoCodigo3) ) )
         {
            AddWhere(sWhereString, "(T4.BancoCodigo > :AV86BancoCodigo3)");
         }
         else
         {
            GXv_int12[56] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like :lV87ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int12[57] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELNACIONALIDADENOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87ResponsavelNacionalidadeNome3)) ) )
         {
            AddWhere(sWhereString, "(T5.NacionalidadeNome like '%' || :lV87ResponsavelNacionalidadeNome3)");
         }
         else
         {
            GXv_int12[58] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like :lV88ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int12[59] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELPROFISSAONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88ResponsavelProfissaoNome3)) ) )
         {
            AddWhere(sWhereString, "(T7.ProfissaoNome like '%' || :lV88ResponsavelProfissaoNome3)");
         }
         else
         {
            GXv_int12[60] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV89ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int12[61] = 1;
         }
         if ( AV77DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV78DynamicFiltersSelector3, "RESPONSAVELMUNICIPIONOME") == 0 ) && ( AV79DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89ResponsavelMunicipioNome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV89ResponsavelMunicipioNome3)");
         }
         else
         {
            GXv_int12[62] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFResponsavelNome_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFResponsavelNome)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome like :lV10TFResponsavelNome)");
         }
         else
         {
            GXv_int12[63] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFResponsavelNome_Sel)) && ! ( StringUtil.StrCmp(AV11TFResponsavelNome_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome = ( :AV11TFResponsavelNome_Sel))");
         }
         else
         {
            GXv_int12[64] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFResponsavelNome_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFResponsavelCPF_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFResponsavelCPF)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF like :lV12TFResponsavelCPF)");
         }
         else
         {
            GXv_int12[65] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFResponsavelCPF_Sel)) && ! ( StringUtil.StrCmp(AV13TFResponsavelCPF_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF = ( :AV13TFResponsavelCPF_Sel))");
         }
         else
         {
            GXv_int12[66] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFResponsavelCPF_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFResponsavelEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFResponsavelEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail like :lV16TFResponsavelEmail)");
         }
         else
         {
            GXv_int12[67] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFResponsavelEmail_Sel)) && ! ( StringUtil.StrCmp(AV17TFResponsavelEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail = ( :AV17TFResponsavelEmail_Sel))");
         }
         else
         {
            GXv_int12[68] = 1;
         }
         if ( StringUtil.StrCmp(AV17TFResponsavelEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from T1.ResponsavelEmail))=0))");
         }
         if ( AV19TFResponsavelCargo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV19TFResponsavelCargo_Sels, "T1.ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV20TFClienteDocumento)");
         }
         else
         {
            GXv_int12[69] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV21TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV21TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int12[70] = 1;
         }
         if ( StringUtil.StrCmp(AV21TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV22TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int12[71] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV23TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV23TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int12[72] = 1;
         }
         if ( StringUtil.StrCmp(AV23TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( AV28TFClienteSituacao_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV28TFClienteSituacao_Sels, "T1.ClienteSituacao IN (", ")")+")");
         }
         if ( AV26TFClienteStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = TRUE)");
         }
         if ( AV26TFClienteStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteRazaoSocial";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00DW2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (int)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (int)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (bool)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (short)dynConstraints[74] );
               case 1 :
                     return conditional_P00DW3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (int)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (int)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (bool)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (short)dynConstraints[74] );
               case 2 :
                     return conditional_P00DW4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (int)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (int)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (bool)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (short)dynConstraints[74] );
               case 3 :
                     return conditional_P00DW5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (int)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (int)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (bool)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (short)dynConstraints[74] );
               case 4 :
                     return conditional_P00DW6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (int)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (int)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (bool)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (short)dynConstraints[74] );
               case 5 :
                     return conditional_P00DW7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (bool)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (int)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (int)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (string)dynConstraints[57] , (string)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (int)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (bool)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (short)dynConstraints[74] );
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
          Object[] prmP00DW2;
          prmP00DW2 = new Object[] {
          new ParDef("lV54ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV54ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV55TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV55TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV56ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV56ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV57ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV57ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV58ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV58ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV59MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV59MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("lV61ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV61ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV62ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV62ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV63ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV63ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV67ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV67ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV68TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV68TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV69ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV69ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV70ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV70ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV71ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV71ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV72MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV72MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("lV74ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV74ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV75ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV75ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV76ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV76ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV80ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV80ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV81TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV81TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV82ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV82ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV83ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV83ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV84ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV84ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV85MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV85MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("lV87ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV87ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV88ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV88ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV89ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV89ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV10TFResponsavelNome",GXType.VarChar,90,0) ,
          new ParDef("AV11TFResponsavelNome_Sel",GXType.VarChar,90,0) ,
          new ParDef("lV12TFResponsavelCPF",GXType.VarChar,14,0) ,
          new ParDef("AV13TFResponsavelCPF_Sel",GXType.VarChar,14,0) ,
          new ParDef("lV16TFResponsavelEmail",GXType.VarChar,100,0) ,
          new ParDef("AV17TFResponsavelEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV20TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV21TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV22TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV23TFClienteRazaoSocial_Sel",GXType.VarChar,150,0)
          };
          Object[] prmP00DW3;
          prmP00DW3 = new Object[] {
          new ParDef("lV54ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV54ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV55TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV55TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV56ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV56ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV57ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV57ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV58ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV58ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV59MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV59MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("lV61ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV61ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV62ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV62ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV63ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV63ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV67ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV67ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV68TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV68TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV69ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV69ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV70ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV70ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV71ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV71ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV72MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV72MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("lV74ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV74ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV75ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV75ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV76ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV76ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV80ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV80ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV81TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV81TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV82ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV82ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV83ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV83ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV84ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV84ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV85MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV85MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("lV87ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV87ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV88ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV88ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV89ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV89ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV10TFResponsavelNome",GXType.VarChar,90,0) ,
          new ParDef("AV11TFResponsavelNome_Sel",GXType.VarChar,90,0) ,
          new ParDef("lV12TFResponsavelCPF",GXType.VarChar,14,0) ,
          new ParDef("AV13TFResponsavelCPF_Sel",GXType.VarChar,14,0) ,
          new ParDef("lV16TFResponsavelEmail",GXType.VarChar,100,0) ,
          new ParDef("AV17TFResponsavelEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV20TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV21TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV22TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV23TFClienteRazaoSocial_Sel",GXType.VarChar,150,0)
          };
          Object[] prmP00DW4;
          prmP00DW4 = new Object[] {
          new ParDef("lV54ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV54ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV55TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV55TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV56ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV56ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV57ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV57ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV58ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV58ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV59MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV59MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("lV61ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV61ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV62ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV62ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV63ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV63ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV67ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV67ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV68TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV68TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV69ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV69ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV70ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV70ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV71ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV71ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV72MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV72MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("lV74ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV74ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV75ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV75ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV76ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV76ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV80ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV80ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV81TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV81TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV82ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV82ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV83ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV83ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV84ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV84ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV85MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV85MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("lV87ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV87ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV88ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV88ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV89ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV89ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV10TFResponsavelNome",GXType.VarChar,90,0) ,
          new ParDef("AV11TFResponsavelNome_Sel",GXType.VarChar,90,0) ,
          new ParDef("lV12TFResponsavelCPF",GXType.VarChar,14,0) ,
          new ParDef("AV13TFResponsavelCPF_Sel",GXType.VarChar,14,0) ,
          new ParDef("lV16TFResponsavelEmail",GXType.VarChar,100,0) ,
          new ParDef("AV17TFResponsavelEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV20TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV21TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV22TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV23TFClienteRazaoSocial_Sel",GXType.VarChar,150,0)
          };
          Object[] prmP00DW5;
          prmP00DW5 = new Object[] {
          new ParDef("lV54ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV54ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV55TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV55TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV56ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV56ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV57ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV57ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV58ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV58ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV59MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV59MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("lV61ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV61ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV62ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV62ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV63ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV63ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV67ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV67ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV68TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV68TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV69ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV69ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV70ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV70ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV71ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV71ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV72MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV72MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("lV74ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV74ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV75ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV75ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV76ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV76ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV80ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV80ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV81TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV81TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV82ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV82ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV83ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV83ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV84ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV84ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV85MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV85MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("lV87ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV87ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV88ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV88ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV89ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV89ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV10TFResponsavelNome",GXType.VarChar,90,0) ,
          new ParDef("AV11TFResponsavelNome_Sel",GXType.VarChar,90,0) ,
          new ParDef("lV12TFResponsavelCPF",GXType.VarChar,14,0) ,
          new ParDef("AV13TFResponsavelCPF_Sel",GXType.VarChar,14,0) ,
          new ParDef("lV16TFResponsavelEmail",GXType.VarChar,100,0) ,
          new ParDef("AV17TFResponsavelEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV20TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV21TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV22TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV23TFClienteRazaoSocial_Sel",GXType.VarChar,150,0)
          };
          Object[] prmP00DW6;
          prmP00DW6 = new Object[] {
          new ParDef("lV54ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV54ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV55TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV55TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV56ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV56ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV57ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV57ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV58ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV58ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV59MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV59MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("lV61ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV61ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV62ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV62ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV63ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV63ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV67ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV67ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV68TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV68TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV69ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV69ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV70ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV70ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV71ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV71ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV72MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV72MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("lV74ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV74ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV75ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV75ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV76ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV76ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV80ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV80ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV81TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV81TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV82ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV82ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV83ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV83ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV84ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV84ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV85MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV85MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("lV87ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV87ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV88ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV88ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV89ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV89ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV10TFResponsavelNome",GXType.VarChar,90,0) ,
          new ParDef("AV11TFResponsavelNome_Sel",GXType.VarChar,90,0) ,
          new ParDef("lV12TFResponsavelCPF",GXType.VarChar,14,0) ,
          new ParDef("AV13TFResponsavelCPF_Sel",GXType.VarChar,14,0) ,
          new ParDef("lV16TFResponsavelEmail",GXType.VarChar,100,0) ,
          new ParDef("AV17TFResponsavelEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV20TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV21TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV22TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV23TFClienteRazaoSocial_Sel",GXType.VarChar,150,0)
          };
          Object[] prmP00DW7;
          prmP00DW7 = new Object[] {
          new ParDef("lV54ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV54ClienteDocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV55TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV55TipoClienteDescricao1",GXType.VarChar,150,0) ,
          new ParDef("lV56ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV56ClienteConvenioDescricao1",GXType.VarChar,40,0) ,
          new ParDef("lV57ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV57ClienteNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV58ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV58ClienteProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV59MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV59MunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("AV60BancoCodigo1",GXType.Int32,9,0) ,
          new ParDef("lV61ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV61ResponsavelNacionalidadeNome1",GXType.VarChar,100,0) ,
          new ParDef("lV62ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV62ResponsavelProfissaoNome1",GXType.VarChar,90,0) ,
          new ParDef("lV63ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV63ResponsavelMunicipioNome1",GXType.VarChar,150,0) ,
          new ParDef("lV67ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV67ClienteDocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV68TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV68TipoClienteDescricao2",GXType.VarChar,150,0) ,
          new ParDef("lV69ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV69ClienteConvenioDescricao2",GXType.VarChar,40,0) ,
          new ParDef("lV70ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV70ClienteNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV71ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV71ClienteProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV72MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV72MunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("AV73BancoCodigo2",GXType.Int32,9,0) ,
          new ParDef("lV74ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV74ResponsavelNacionalidadeNome2",GXType.VarChar,100,0) ,
          new ParDef("lV75ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV75ResponsavelProfissaoNome2",GXType.VarChar,90,0) ,
          new ParDef("lV76ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV76ResponsavelMunicipioNome2",GXType.VarChar,150,0) ,
          new ParDef("lV80ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV80ClienteDocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV81TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV81TipoClienteDescricao3",GXType.VarChar,150,0) ,
          new ParDef("lV82ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV82ClienteConvenioDescricao3",GXType.VarChar,40,0) ,
          new ParDef("lV83ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV83ClienteNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV84ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV84ClienteProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV85MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV85MunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("AV86BancoCodigo3",GXType.Int32,9,0) ,
          new ParDef("lV87ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV87ResponsavelNacionalidadeNome3",GXType.VarChar,100,0) ,
          new ParDef("lV88ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV88ResponsavelProfissaoNome3",GXType.VarChar,90,0) ,
          new ParDef("lV89ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV89ResponsavelMunicipioNome3",GXType.VarChar,150,0) ,
          new ParDef("lV10TFResponsavelNome",GXType.VarChar,90,0) ,
          new ParDef("AV11TFResponsavelNome_Sel",GXType.VarChar,90,0) ,
          new ParDef("lV12TFResponsavelCPF",GXType.VarChar,14,0) ,
          new ParDef("AV13TFResponsavelCPF_Sel",GXType.VarChar,14,0) ,
          new ParDef("lV16TFResponsavelEmail",GXType.VarChar,100,0) ,
          new ParDef("AV17TFResponsavelEmail_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV20TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV21TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV22TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV23TFClienteRazaoSocial_Sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DW2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DW2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DW3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DW3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DW4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DW4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DW5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DW5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DW6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DW6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DW7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DW7,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[38])[0] = rslt.getBool(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((string[]) buf[40])[0] = rslt.getString(21, 1);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getVarchar(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((string[]) buf[48])[0] = rslt.getVarchar(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((string[]) buf[50])[0] = rslt.getVarchar(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((int[]) buf[52])[0] = rslt.getInt(27);
                ((bool[]) buf[53])[0] = rslt.wasNull(27);
                ((short[]) buf[54])[0] = rslt.getShort(28);
                ((bool[]) buf[55])[0] = rslt.wasNull(28);
                ((int[]) buf[56])[0] = rslt.getInt(29);
                return;
             case 1 :
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
                ((bool[]) buf[38])[0] = rslt.getBool(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((string[]) buf[40])[0] = rslt.getString(21, 1);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getVarchar(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((string[]) buf[48])[0] = rslt.getVarchar(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((string[]) buf[50])[0] = rslt.getVarchar(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((int[]) buf[52])[0] = rslt.getInt(27);
                ((bool[]) buf[53])[0] = rslt.wasNull(27);
                ((short[]) buf[54])[0] = rslt.getShort(28);
                ((bool[]) buf[55])[0] = rslt.wasNull(28);
                ((int[]) buf[56])[0] = rslt.getInt(29);
                return;
             case 2 :
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
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((short[]) buf[34])[0] = rslt.getShort(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((bool[]) buf[36])[0] = rslt.getBool(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((string[]) buf[38])[0] = rslt.getString(20, 1);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((string[]) buf[40])[0] = rslt.getVarchar(21);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getVarchar(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((string[]) buf[48])[0] = rslt.getVarchar(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((string[]) buf[50])[0] = rslt.getVarchar(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((int[]) buf[52])[0] = rslt.getInt(27);
                ((bool[]) buf[53])[0] = rslt.wasNull(27);
                ((short[]) buf[54])[0] = rslt.getShort(28);
                ((bool[]) buf[55])[0] = rslt.wasNull(28);
                ((int[]) buf[56])[0] = rslt.getInt(29);
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
                ((bool[]) buf[38])[0] = rslt.getBool(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((string[]) buf[40])[0] = rslt.getString(21, 1);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getVarchar(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((string[]) buf[48])[0] = rslt.getVarchar(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((string[]) buf[50])[0] = rslt.getVarchar(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((int[]) buf[52])[0] = rslt.getInt(27);
                ((bool[]) buf[53])[0] = rslt.wasNull(27);
                ((short[]) buf[54])[0] = rslt.getShort(28);
                ((bool[]) buf[55])[0] = rslt.wasNull(28);
                ((int[]) buf[56])[0] = rslt.getInt(29);
                return;
             case 4 :
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
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((int[]) buf[24])[0] = rslt.getInt(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((string[]) buf[28])[0] = rslt.getVarchar(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((string[]) buf[32])[0] = rslt.getVarchar(17);
                ((bool[]) buf[33])[0] = rslt.wasNull(17);
                ((string[]) buf[34])[0] = rslt.getVarchar(18);
                ((bool[]) buf[35])[0] = rslt.wasNull(18);
                ((short[]) buf[36])[0] = rslt.getShort(19);
                ((bool[]) buf[37])[0] = rslt.wasNull(19);
                ((bool[]) buf[38])[0] = rslt.getBool(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((string[]) buf[40])[0] = rslt.getString(21, 1);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getVarchar(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((string[]) buf[48])[0] = rslt.getVarchar(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((string[]) buf[50])[0] = rslt.getVarchar(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((int[]) buf[52])[0] = rslt.getInt(27);
                ((bool[]) buf[53])[0] = rslt.wasNull(27);
                ((short[]) buf[54])[0] = rslt.getShort(28);
                ((bool[]) buf[55])[0] = rslt.wasNull(28);
                ((int[]) buf[56])[0] = rslt.getInt(29);
                return;
             case 5 :
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
                ((bool[]) buf[38])[0] = rslt.getBool(20);
                ((bool[]) buf[39])[0] = rslt.wasNull(20);
                ((string[]) buf[40])[0] = rslt.getString(21, 1);
                ((bool[]) buf[41])[0] = rslt.wasNull(21);
                ((string[]) buf[42])[0] = rslt.getVarchar(22);
                ((bool[]) buf[43])[0] = rslt.wasNull(22);
                ((string[]) buf[44])[0] = rslt.getVarchar(23);
                ((bool[]) buf[45])[0] = rslt.wasNull(23);
                ((string[]) buf[46])[0] = rslt.getVarchar(24);
                ((bool[]) buf[47])[0] = rslt.wasNull(24);
                ((string[]) buf[48])[0] = rslt.getVarchar(25);
                ((bool[]) buf[49])[0] = rslt.wasNull(25);
                ((string[]) buf[50])[0] = rslt.getVarchar(26);
                ((bool[]) buf[51])[0] = rslt.wasNull(26);
                ((int[]) buf[52])[0] = rslt.getInt(27);
                ((bool[]) buf[53])[0] = rslt.wasNull(27);
                ((short[]) buf[54])[0] = rslt.getShort(28);
                ((bool[]) buf[55])[0] = rslt.wasNull(28);
                ((int[]) buf[56])[0] = rslt.getInt(29);
                return;
       }
    }

 }

}
