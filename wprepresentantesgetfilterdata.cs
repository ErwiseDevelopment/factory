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
   public class wprepresentantesgetfilterdata : GXProcedure
   {
      public wprepresentantesgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wprepresentantesgetfilterdata( IGxContext context )
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
         this.AV43DDOName = aP0_DDOName;
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
         this.AV45SearchTxtTo = aP2_SearchTxtTo;
         this.AV46OptionsJson = "" ;
         this.AV47OptionsDescJson = "" ;
         this.AV48OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV48OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV43DDOName = aP0_DDOName;
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
         this.AV45SearchTxtTo = aP2_SearchTxtTo;
         this.AV46OptionsJson = "" ;
         this.AV47OptionsDescJson = "" ;
         this.AV48OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV33Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30MaxItems = 10;
         AV29PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV44SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV27SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? "" : StringUtil.Substring( AV44SearchTxtParms, 3, -1));
         AV28SkipItems = (short)(AV29PageIndex*AV30MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_RESPONSAVELNOME") == 0 )
         {
            /* Execute user subroutine: 'LOADRESPONSAVELNOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_RESPONSAVELCPF") == 0 )
         {
            /* Execute user subroutine: 'LOADRESPONSAVELCPFOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_RESPONSAVELCELULAR_F") == 0 )
         {
            /* Execute user subroutine: 'LOADRESPONSAVELCELULAR_FOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_RESPONSAVELEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADRESPONSAVELEMAILOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_CLIENTEDOCUMENTO") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTEDOCUMENTOOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_CLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTERAZAOSOCIALOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV46OptionsJson = AV33Options.ToJSonString(false);
         AV47OptionsDescJson = AV35OptionsDesc.ToJSonString(false);
         AV48OptionIndexesJson = AV36OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get("WpRepresentantesGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WpRepresentantesGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("WpRepresentantesGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV49FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TIPOCLIENTEID") == 0 )
            {
               AV50TipoClienteId = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME") == 0 )
            {
               AV10TFResponsavelNome = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELNOME_SEL") == 0 )
            {
               AV11TFResponsavelNome_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCPF") == 0 )
            {
               AV12TFResponsavelCPF = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCPF_SEL") == 0 )
            {
               AV13TFResponsavelCPF_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCELULAR_F") == 0 )
            {
               AV14TFResponsavelCelular_F = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCELULAR_F_SEL") == 0 )
            {
               AV15TFResponsavelCelular_F_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL") == 0 )
            {
               AV16TFResponsavelEmail = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELEMAIL_SEL") == 0 )
            {
               AV17TFResponsavelEmail_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFRESPONSAVELCARGO_SEL") == 0 )
            {
               AV18TFResponsavelCargo_SelsJson = AV41GridStateFilterValue.gxTpr_Value;
               AV19TFResponsavelCargo_Sels.FromJSonString(AV18TFResponsavelCargo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV20TFClienteDocumento = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV21TFClienteDocumento_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV22TFClienteRazaoSocial = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV23TFClienteRazaoSocial_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCLIENTESITUACAO_SEL") == 0 )
            {
               AV24TFClienteSituacao_SelsJson = AV41GridStateFilterValue.gxTpr_Value;
               AV25TFClienteSituacao_Sels.FromJSonString(AV24TFClienteSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCLIENTESTATUS_SEL") == 0 )
            {
               AV26TFClienteStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADRESPONSAVELNOMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFResponsavelNome = AV27SearchTxt;
         AV11TFResponsavelNome_Sel = "";
         AV53Wprepresentantesds_1_filterfulltext = AV49FilterFullText;
         AV54Wprepresentantesds_2_tipoclienteid = AV50TipoClienteId;
         AV55Wprepresentantesds_3_tfresponsavelnome = AV10TFResponsavelNome;
         AV56Wprepresentantesds_4_tfresponsavelnome_sel = AV11TFResponsavelNome_Sel;
         AV57Wprepresentantesds_5_tfresponsavelcpf = AV12TFResponsavelCPF;
         AV58Wprepresentantesds_6_tfresponsavelcpf_sel = AV13TFResponsavelCPF_Sel;
         AV59Wprepresentantesds_7_tfresponsavelcelular_f = AV14TFResponsavelCelular_F;
         AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel = AV15TFResponsavelCelular_F_Sel;
         AV61Wprepresentantesds_9_tfresponsavelemail = AV16TFResponsavelEmail;
         AV62Wprepresentantesds_10_tfresponsavelemail_sel = AV17TFResponsavelEmail_Sel;
         AV63Wprepresentantesds_11_tfresponsavelcargo_sels = AV19TFResponsavelCargo_Sels;
         AV64Wprepresentantesds_12_tfclientedocumento = AV20TFClienteDocumento;
         AV65Wprepresentantesds_13_tfclientedocumento_sel = AV21TFClienteDocumento_Sel;
         AV66Wprepresentantesds_14_tfclienterazaosocial = AV22TFClienteRazaoSocial;
         AV67Wprepresentantesds_15_tfclienterazaosocial_sel = AV23TFClienteRazaoSocial_Sel;
         AV68Wprepresentantesds_16_tfclientesituacao_sels = AV25TFClienteSituacao_Sels;
         AV69Wprepresentantesds_17_tfclientestatus_sel = AV26TFClienteStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV63Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                              A884ClienteSituacao ,
                                              AV68Wprepresentantesds_16_tfclientesituacao_sels ,
                                              AV56Wprepresentantesds_4_tfresponsavelnome_sel ,
                                              AV55Wprepresentantesds_3_tfresponsavelnome ,
                                              AV58Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                              AV57Wprepresentantesds_5_tfresponsavelcpf ,
                                              AV62Wprepresentantesds_10_tfresponsavelemail_sel ,
                                              AV61Wprepresentantesds_9_tfresponsavelemail ,
                                              AV63Wprepresentantesds_11_tfresponsavelcargo_sels.Count ,
                                              AV65Wprepresentantesds_13_tfclientedocumento_sel ,
                                              AV64Wprepresentantesds_12_tfclientedocumento ,
                                              AV67Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                              AV66Wprepresentantesds_14_tfclienterazaosocial ,
                                              AV68Wprepresentantesds_16_tfclientesituacao_sels.Count ,
                                              AV69Wprepresentantesds_17_tfclientestatus_sel ,
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A169ClienteDocumento ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV53Wprepresentantesds_1_filterfulltext ,
                                              A577ResponsavelCelular_F ,
                                              AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                              AV59Wprepresentantesds_7_tfresponsavelcelular_f ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Wprepresentantesds_3_tfresponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV55Wprepresentantesds_3_tfresponsavelnome), "%", "");
         lV57Wprepresentantesds_5_tfresponsavelcpf = StringUtil.Concat( StringUtil.RTrim( AV57Wprepresentantesds_5_tfresponsavelcpf), "%", "");
         lV61Wprepresentantesds_9_tfresponsavelemail = StringUtil.Concat( StringUtil.RTrim( AV61Wprepresentantesds_9_tfresponsavelemail), "%", "");
         lV64Wprepresentantesds_12_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV64Wprepresentantesds_12_tfclientedocumento), "%", "");
         lV66Wprepresentantesds_14_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV66Wprepresentantesds_14_tfclienterazaosocial), "%", "");
         /* Using cursor P00E02 */
         pr_default.execute(0, new Object[] {lV55Wprepresentantesds_3_tfresponsavelnome, AV56Wprepresentantesds_4_tfresponsavelnome_sel, lV57Wprepresentantesds_5_tfresponsavelcpf, AV58Wprepresentantesds_6_tfresponsavelcpf_sel, lV61Wprepresentantesds_9_tfresponsavelemail, AV62Wprepresentantesds_10_tfresponsavelemail_sel, lV64Wprepresentantesds_12_tfclientedocumento, AV65Wprepresentantesds_13_tfclientedocumento_sel, lV66Wprepresentantesds_14_tfclienterazaosocial, AV67Wprepresentantesds_15_tfclienterazaosocial_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKE02 = false;
            A192TipoClienteId = P00E02_A192TipoClienteId[0];
            n192TipoClienteId = P00E02_n192TipoClienteId[0];
            A436ResponsavelNome = P00E02_A436ResponsavelNome[0];
            n436ResponsavelNome = P00E02_n436ResponsavelNome[0];
            A174ClienteStatus = P00E02_A174ClienteStatus[0];
            n174ClienteStatus = P00E02_n174ClienteStatus[0];
            A884ClienteSituacao = P00E02_A884ClienteSituacao[0];
            n884ClienteSituacao = P00E02_n884ClienteSituacao[0];
            A170ClienteRazaoSocial = P00E02_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00E02_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = P00E02_A169ClienteDocumento[0];
            n169ClienteDocumento = P00E02_n169ClienteDocumento[0];
            A885ResponsavelCargo = P00E02_A885ResponsavelCargo[0];
            n885ResponsavelCargo = P00E02_n885ResponsavelCargo[0];
            A456ResponsavelEmail = P00E02_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00E02_n456ResponsavelEmail[0];
            A447ResponsavelCPF = P00E02_A447ResponsavelCPF[0];
            n447ResponsavelCPF = P00E02_n447ResponsavelCPF[0];
            A455ResponsavelNumero = P00E02_A455ResponsavelNumero[0];
            n455ResponsavelNumero = P00E02_n455ResponsavelNumero[0];
            A454ResponsavelDDD = P00E02_A454ResponsavelDDD[0];
            n454ResponsavelDDD = P00E02_n454ResponsavelDDD[0];
            A168ClienteId = P00E02_A168ClienteId[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wprepresentantesds_1_filterfulltext)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) || ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) ||
            ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) || ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) || ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) ||
            ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) || ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) ||
            ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) || ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wprepresentantesds_7_tfresponsavelcelular_f)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV59Wprepresentantesds_7_tfresponsavelcelular_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ! ( StringUtil.StrCmp(AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                     {
                        AV37count = 0;
                        while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00E02_A436ResponsavelNome[0], A436ResponsavelNome) == 0 ) )
                        {
                           BRKE02 = false;
                           A168ClienteId = P00E02_A168ClienteId[0];
                           AV37count = (long)(AV37count+1);
                           BRKE02 = true;
                           pr_default.readNext(0);
                        }
                        if ( (0==AV28SkipItems) )
                        {
                           AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A436ResponsavelNome)) ? "<#Empty#>" : A436ResponsavelNome);
                           AV33Options.Add(AV32Option, 0);
                           AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV33Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV28SkipItems = (short)(AV28SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRKE02 )
            {
               BRKE02 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRESPONSAVELCPFOPTIONS' Routine */
         returnInSub = false;
         AV12TFResponsavelCPF = AV27SearchTxt;
         AV13TFResponsavelCPF_Sel = "";
         AV53Wprepresentantesds_1_filterfulltext = AV49FilterFullText;
         AV54Wprepresentantesds_2_tipoclienteid = AV50TipoClienteId;
         AV55Wprepresentantesds_3_tfresponsavelnome = AV10TFResponsavelNome;
         AV56Wprepresentantesds_4_tfresponsavelnome_sel = AV11TFResponsavelNome_Sel;
         AV57Wprepresentantesds_5_tfresponsavelcpf = AV12TFResponsavelCPF;
         AV58Wprepresentantesds_6_tfresponsavelcpf_sel = AV13TFResponsavelCPF_Sel;
         AV59Wprepresentantesds_7_tfresponsavelcelular_f = AV14TFResponsavelCelular_F;
         AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel = AV15TFResponsavelCelular_F_Sel;
         AV61Wprepresentantesds_9_tfresponsavelemail = AV16TFResponsavelEmail;
         AV62Wprepresentantesds_10_tfresponsavelemail_sel = AV17TFResponsavelEmail_Sel;
         AV63Wprepresentantesds_11_tfresponsavelcargo_sels = AV19TFResponsavelCargo_Sels;
         AV64Wprepresentantesds_12_tfclientedocumento = AV20TFClienteDocumento;
         AV65Wprepresentantesds_13_tfclientedocumento_sel = AV21TFClienteDocumento_Sel;
         AV66Wprepresentantesds_14_tfclienterazaosocial = AV22TFClienteRazaoSocial;
         AV67Wprepresentantesds_15_tfclienterazaosocial_sel = AV23TFClienteRazaoSocial_Sel;
         AV68Wprepresentantesds_16_tfclientesituacao_sels = AV25TFClienteSituacao_Sels;
         AV69Wprepresentantesds_17_tfclientestatus_sel = AV26TFClienteStatus_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV63Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                              A884ClienteSituacao ,
                                              AV68Wprepresentantesds_16_tfclientesituacao_sels ,
                                              AV56Wprepresentantesds_4_tfresponsavelnome_sel ,
                                              AV55Wprepresentantesds_3_tfresponsavelnome ,
                                              AV58Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                              AV57Wprepresentantesds_5_tfresponsavelcpf ,
                                              AV62Wprepresentantesds_10_tfresponsavelemail_sel ,
                                              AV61Wprepresentantesds_9_tfresponsavelemail ,
                                              AV63Wprepresentantesds_11_tfresponsavelcargo_sels.Count ,
                                              AV65Wprepresentantesds_13_tfclientedocumento_sel ,
                                              AV64Wprepresentantesds_12_tfclientedocumento ,
                                              AV67Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                              AV66Wprepresentantesds_14_tfclienterazaosocial ,
                                              AV68Wprepresentantesds_16_tfclientesituacao_sels.Count ,
                                              AV69Wprepresentantesds_17_tfclientestatus_sel ,
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A169ClienteDocumento ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV53Wprepresentantesds_1_filterfulltext ,
                                              A577ResponsavelCelular_F ,
                                              AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                              AV59Wprepresentantesds_7_tfresponsavelcelular_f ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Wprepresentantesds_3_tfresponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV55Wprepresentantesds_3_tfresponsavelnome), "%", "");
         lV57Wprepresentantesds_5_tfresponsavelcpf = StringUtil.Concat( StringUtil.RTrim( AV57Wprepresentantesds_5_tfresponsavelcpf), "%", "");
         lV61Wprepresentantesds_9_tfresponsavelemail = StringUtil.Concat( StringUtil.RTrim( AV61Wprepresentantesds_9_tfresponsavelemail), "%", "");
         lV64Wprepresentantesds_12_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV64Wprepresentantesds_12_tfclientedocumento), "%", "");
         lV66Wprepresentantesds_14_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV66Wprepresentantesds_14_tfclienterazaosocial), "%", "");
         /* Using cursor P00E03 */
         pr_default.execute(1, new Object[] {lV55Wprepresentantesds_3_tfresponsavelnome, AV56Wprepresentantesds_4_tfresponsavelnome_sel, lV57Wprepresentantesds_5_tfresponsavelcpf, AV58Wprepresentantesds_6_tfresponsavelcpf_sel, lV61Wprepresentantesds_9_tfresponsavelemail, AV62Wprepresentantesds_10_tfresponsavelemail_sel, lV64Wprepresentantesds_12_tfclientedocumento, AV65Wprepresentantesds_13_tfclientedocumento_sel, lV66Wprepresentantesds_14_tfclienterazaosocial, AV67Wprepresentantesds_15_tfclienterazaosocial_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKE04 = false;
            A192TipoClienteId = P00E03_A192TipoClienteId[0];
            n192TipoClienteId = P00E03_n192TipoClienteId[0];
            A447ResponsavelCPF = P00E03_A447ResponsavelCPF[0];
            n447ResponsavelCPF = P00E03_n447ResponsavelCPF[0];
            A174ClienteStatus = P00E03_A174ClienteStatus[0];
            n174ClienteStatus = P00E03_n174ClienteStatus[0];
            A884ClienteSituacao = P00E03_A884ClienteSituacao[0];
            n884ClienteSituacao = P00E03_n884ClienteSituacao[0];
            A170ClienteRazaoSocial = P00E03_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00E03_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = P00E03_A169ClienteDocumento[0];
            n169ClienteDocumento = P00E03_n169ClienteDocumento[0];
            A885ResponsavelCargo = P00E03_A885ResponsavelCargo[0];
            n885ResponsavelCargo = P00E03_n885ResponsavelCargo[0];
            A456ResponsavelEmail = P00E03_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00E03_n456ResponsavelEmail[0];
            A436ResponsavelNome = P00E03_A436ResponsavelNome[0];
            n436ResponsavelNome = P00E03_n436ResponsavelNome[0];
            A455ResponsavelNumero = P00E03_A455ResponsavelNumero[0];
            n455ResponsavelNumero = P00E03_n455ResponsavelNumero[0];
            A454ResponsavelDDD = P00E03_A454ResponsavelDDD[0];
            n454ResponsavelDDD = P00E03_n454ResponsavelDDD[0];
            A168ClienteId = P00E03_A168ClienteId[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wprepresentantesds_1_filterfulltext)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) || ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) ||
            ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) || ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) || ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) ||
            ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) || ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) ||
            ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) || ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wprepresentantesds_7_tfresponsavelcelular_f)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV59Wprepresentantesds_7_tfresponsavelcelular_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ! ( StringUtil.StrCmp(AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                     {
                        AV37count = 0;
                        while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00E03_A447ResponsavelCPF[0], A447ResponsavelCPF) == 0 ) )
                        {
                           BRKE04 = false;
                           A168ClienteId = P00E03_A168ClienteId[0];
                           AV37count = (long)(AV37count+1);
                           BRKE04 = true;
                           pr_default.readNext(1);
                        }
                        if ( (0==AV28SkipItems) )
                        {
                           AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A447ResponsavelCPF)) ? "<#Empty#>" : A447ResponsavelCPF);
                           AV33Options.Add(AV32Option, 0);
                           AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV33Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV28SkipItems = (short)(AV28SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRKE04 )
            {
               BRKE04 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADRESPONSAVELCELULAR_FOPTIONS' Routine */
         returnInSub = false;
         AV14TFResponsavelCelular_F = AV27SearchTxt;
         AV15TFResponsavelCelular_F_Sel = "";
         AV53Wprepresentantesds_1_filterfulltext = AV49FilterFullText;
         AV54Wprepresentantesds_2_tipoclienteid = AV50TipoClienteId;
         AV55Wprepresentantesds_3_tfresponsavelnome = AV10TFResponsavelNome;
         AV56Wprepresentantesds_4_tfresponsavelnome_sel = AV11TFResponsavelNome_Sel;
         AV57Wprepresentantesds_5_tfresponsavelcpf = AV12TFResponsavelCPF;
         AV58Wprepresentantesds_6_tfresponsavelcpf_sel = AV13TFResponsavelCPF_Sel;
         AV59Wprepresentantesds_7_tfresponsavelcelular_f = AV14TFResponsavelCelular_F;
         AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel = AV15TFResponsavelCelular_F_Sel;
         AV61Wprepresentantesds_9_tfresponsavelemail = AV16TFResponsavelEmail;
         AV62Wprepresentantesds_10_tfresponsavelemail_sel = AV17TFResponsavelEmail_Sel;
         AV63Wprepresentantesds_11_tfresponsavelcargo_sels = AV19TFResponsavelCargo_Sels;
         AV64Wprepresentantesds_12_tfclientedocumento = AV20TFClienteDocumento;
         AV65Wprepresentantesds_13_tfclientedocumento_sel = AV21TFClienteDocumento_Sel;
         AV66Wprepresentantesds_14_tfclienterazaosocial = AV22TFClienteRazaoSocial;
         AV67Wprepresentantesds_15_tfclienterazaosocial_sel = AV23TFClienteRazaoSocial_Sel;
         AV68Wprepresentantesds_16_tfclientesituacao_sels = AV25TFClienteSituacao_Sels;
         AV69Wprepresentantesds_17_tfclientestatus_sel = AV26TFClienteStatus_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV63Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                              A884ClienteSituacao ,
                                              AV68Wprepresentantesds_16_tfclientesituacao_sels ,
                                              AV56Wprepresentantesds_4_tfresponsavelnome_sel ,
                                              AV55Wprepresentantesds_3_tfresponsavelnome ,
                                              AV58Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                              AV57Wprepresentantesds_5_tfresponsavelcpf ,
                                              AV62Wprepresentantesds_10_tfresponsavelemail_sel ,
                                              AV61Wprepresentantesds_9_tfresponsavelemail ,
                                              AV63Wprepresentantesds_11_tfresponsavelcargo_sels.Count ,
                                              AV65Wprepresentantesds_13_tfclientedocumento_sel ,
                                              AV64Wprepresentantesds_12_tfclientedocumento ,
                                              AV67Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                              AV66Wprepresentantesds_14_tfclienterazaosocial ,
                                              AV68Wprepresentantesds_16_tfclientesituacao_sels.Count ,
                                              AV69Wprepresentantesds_17_tfclientestatus_sel ,
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A169ClienteDocumento ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV53Wprepresentantesds_1_filterfulltext ,
                                              A577ResponsavelCelular_F ,
                                              AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                              AV59Wprepresentantesds_7_tfresponsavelcelular_f ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Wprepresentantesds_3_tfresponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV55Wprepresentantesds_3_tfresponsavelnome), "%", "");
         lV57Wprepresentantesds_5_tfresponsavelcpf = StringUtil.Concat( StringUtil.RTrim( AV57Wprepresentantesds_5_tfresponsavelcpf), "%", "");
         lV61Wprepresentantesds_9_tfresponsavelemail = StringUtil.Concat( StringUtil.RTrim( AV61Wprepresentantesds_9_tfresponsavelemail), "%", "");
         lV64Wprepresentantesds_12_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV64Wprepresentantesds_12_tfclientedocumento), "%", "");
         lV66Wprepresentantesds_14_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV66Wprepresentantesds_14_tfclienterazaosocial), "%", "");
         /* Using cursor P00E04 */
         pr_default.execute(2, new Object[] {lV55Wprepresentantesds_3_tfresponsavelnome, AV56Wprepresentantesds_4_tfresponsavelnome_sel, lV57Wprepresentantesds_5_tfresponsavelcpf, AV58Wprepresentantesds_6_tfresponsavelcpf_sel, lV61Wprepresentantesds_9_tfresponsavelemail, AV62Wprepresentantesds_10_tfresponsavelemail_sel, lV64Wprepresentantesds_12_tfclientedocumento, AV65Wprepresentantesds_13_tfclientedocumento_sel, lV66Wprepresentantesds_14_tfclienterazaosocial, AV67Wprepresentantesds_15_tfclienterazaosocial_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A192TipoClienteId = P00E04_A192TipoClienteId[0];
            n192TipoClienteId = P00E04_n192TipoClienteId[0];
            A174ClienteStatus = P00E04_A174ClienteStatus[0];
            n174ClienteStatus = P00E04_n174ClienteStatus[0];
            A884ClienteSituacao = P00E04_A884ClienteSituacao[0];
            n884ClienteSituacao = P00E04_n884ClienteSituacao[0];
            A170ClienteRazaoSocial = P00E04_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00E04_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = P00E04_A169ClienteDocumento[0];
            n169ClienteDocumento = P00E04_n169ClienteDocumento[0];
            A885ResponsavelCargo = P00E04_A885ResponsavelCargo[0];
            n885ResponsavelCargo = P00E04_n885ResponsavelCargo[0];
            A456ResponsavelEmail = P00E04_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00E04_n456ResponsavelEmail[0];
            A447ResponsavelCPF = P00E04_A447ResponsavelCPF[0];
            n447ResponsavelCPF = P00E04_n447ResponsavelCPF[0];
            A436ResponsavelNome = P00E04_A436ResponsavelNome[0];
            n436ResponsavelNome = P00E04_n436ResponsavelNome[0];
            A455ResponsavelNumero = P00E04_A455ResponsavelNumero[0];
            n455ResponsavelNumero = P00E04_n455ResponsavelNumero[0];
            A454ResponsavelDDD = P00E04_A454ResponsavelDDD[0];
            n454ResponsavelDDD = P00E04_n454ResponsavelDDD[0];
            A168ClienteId = P00E04_A168ClienteId[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wprepresentantesds_1_filterfulltext)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) || ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) ||
            ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) || ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) || ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) ||
            ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) || ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) ||
            ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) || ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wprepresentantesds_7_tfresponsavelcelular_f)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV59Wprepresentantesds_7_tfresponsavelcelular_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ! ( StringUtil.StrCmp(AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                     {
                        AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ? "<#Empty#>" : A577ResponsavelCelular_F);
                        AV31InsertIndex = 1;
                        while ( ( StringUtil.StrCmp(AV32Option, "<#Empty#>") != 0 ) && ( AV31InsertIndex <= AV33Options.Count ) && ( ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), AV32Option) < 0 ) || ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), "<#Empty#>") == 0 ) ) )
                        {
                           AV31InsertIndex = (int)(AV31InsertIndex+1);
                        }
                        if ( ( AV31InsertIndex <= AV33Options.Count ) && ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), AV32Option) == 0 ) )
                        {
                           AV37count = (long)(Math.Round(NumberUtil.Val( ((string)AV36OptionIndexes.Item(AV31InsertIndex)), "."), 18, MidpointRounding.ToEven));
                           AV37count = (long)(AV37count+1);
                           AV36OptionIndexes.RemoveItem(AV31InsertIndex);
                           AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), AV31InsertIndex);
                        }
                        else
                        {
                           AV33Options.Add(AV32Option, AV31InsertIndex);
                           AV36OptionIndexes.Add("1", AV31InsertIndex);
                        }
                        if ( AV33Options.Count == AV28SkipItems + 11 )
                        {
                           AV33Options.RemoveItem(AV33Options.Count);
                           AV36OptionIndexes.RemoveItem(AV36OptionIndexes.Count);
                        }
                     }
                  }
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         while ( AV28SkipItems > 0 )
         {
            AV33Options.RemoveItem(1);
            AV36OptionIndexes.RemoveItem(1);
            AV28SkipItems = (short)(AV28SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADRESPONSAVELEMAILOPTIONS' Routine */
         returnInSub = false;
         AV16TFResponsavelEmail = AV27SearchTxt;
         AV17TFResponsavelEmail_Sel = "";
         AV53Wprepresentantesds_1_filterfulltext = AV49FilterFullText;
         AV54Wprepresentantesds_2_tipoclienteid = AV50TipoClienteId;
         AV55Wprepresentantesds_3_tfresponsavelnome = AV10TFResponsavelNome;
         AV56Wprepresentantesds_4_tfresponsavelnome_sel = AV11TFResponsavelNome_Sel;
         AV57Wprepresentantesds_5_tfresponsavelcpf = AV12TFResponsavelCPF;
         AV58Wprepresentantesds_6_tfresponsavelcpf_sel = AV13TFResponsavelCPF_Sel;
         AV59Wprepresentantesds_7_tfresponsavelcelular_f = AV14TFResponsavelCelular_F;
         AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel = AV15TFResponsavelCelular_F_Sel;
         AV61Wprepresentantesds_9_tfresponsavelemail = AV16TFResponsavelEmail;
         AV62Wprepresentantesds_10_tfresponsavelemail_sel = AV17TFResponsavelEmail_Sel;
         AV63Wprepresentantesds_11_tfresponsavelcargo_sels = AV19TFResponsavelCargo_Sels;
         AV64Wprepresentantesds_12_tfclientedocumento = AV20TFClienteDocumento;
         AV65Wprepresentantesds_13_tfclientedocumento_sel = AV21TFClienteDocumento_Sel;
         AV66Wprepresentantesds_14_tfclienterazaosocial = AV22TFClienteRazaoSocial;
         AV67Wprepresentantesds_15_tfclienterazaosocial_sel = AV23TFClienteRazaoSocial_Sel;
         AV68Wprepresentantesds_16_tfclientesituacao_sels = AV25TFClienteSituacao_Sels;
         AV69Wprepresentantesds_17_tfclientestatus_sel = AV26TFClienteStatus_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV63Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                              A884ClienteSituacao ,
                                              AV68Wprepresentantesds_16_tfclientesituacao_sels ,
                                              AV56Wprepresentantesds_4_tfresponsavelnome_sel ,
                                              AV55Wprepresentantesds_3_tfresponsavelnome ,
                                              AV58Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                              AV57Wprepresentantesds_5_tfresponsavelcpf ,
                                              AV62Wprepresentantesds_10_tfresponsavelemail_sel ,
                                              AV61Wprepresentantesds_9_tfresponsavelemail ,
                                              AV63Wprepresentantesds_11_tfresponsavelcargo_sels.Count ,
                                              AV65Wprepresentantesds_13_tfclientedocumento_sel ,
                                              AV64Wprepresentantesds_12_tfclientedocumento ,
                                              AV67Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                              AV66Wprepresentantesds_14_tfclienterazaosocial ,
                                              AV68Wprepresentantesds_16_tfclientesituacao_sels.Count ,
                                              AV69Wprepresentantesds_17_tfclientestatus_sel ,
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A169ClienteDocumento ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV53Wprepresentantesds_1_filterfulltext ,
                                              A577ResponsavelCelular_F ,
                                              AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                              AV59Wprepresentantesds_7_tfresponsavelcelular_f ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Wprepresentantesds_3_tfresponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV55Wprepresentantesds_3_tfresponsavelnome), "%", "");
         lV57Wprepresentantesds_5_tfresponsavelcpf = StringUtil.Concat( StringUtil.RTrim( AV57Wprepresentantesds_5_tfresponsavelcpf), "%", "");
         lV61Wprepresentantesds_9_tfresponsavelemail = StringUtil.Concat( StringUtil.RTrim( AV61Wprepresentantesds_9_tfresponsavelemail), "%", "");
         lV64Wprepresentantesds_12_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV64Wprepresentantesds_12_tfclientedocumento), "%", "");
         lV66Wprepresentantesds_14_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV66Wprepresentantesds_14_tfclienterazaosocial), "%", "");
         /* Using cursor P00E05 */
         pr_default.execute(3, new Object[] {lV55Wprepresentantesds_3_tfresponsavelnome, AV56Wprepresentantesds_4_tfresponsavelnome_sel, lV57Wprepresentantesds_5_tfresponsavelcpf, AV58Wprepresentantesds_6_tfresponsavelcpf_sel, lV61Wprepresentantesds_9_tfresponsavelemail, AV62Wprepresentantesds_10_tfresponsavelemail_sel, lV64Wprepresentantesds_12_tfclientedocumento, AV65Wprepresentantesds_13_tfclientedocumento_sel, lV66Wprepresentantesds_14_tfclienterazaosocial, AV67Wprepresentantesds_15_tfclienterazaosocial_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKE07 = false;
            A192TipoClienteId = P00E05_A192TipoClienteId[0];
            n192TipoClienteId = P00E05_n192TipoClienteId[0];
            A456ResponsavelEmail = P00E05_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00E05_n456ResponsavelEmail[0];
            A174ClienteStatus = P00E05_A174ClienteStatus[0];
            n174ClienteStatus = P00E05_n174ClienteStatus[0];
            A884ClienteSituacao = P00E05_A884ClienteSituacao[0];
            n884ClienteSituacao = P00E05_n884ClienteSituacao[0];
            A170ClienteRazaoSocial = P00E05_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00E05_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = P00E05_A169ClienteDocumento[0];
            n169ClienteDocumento = P00E05_n169ClienteDocumento[0];
            A885ResponsavelCargo = P00E05_A885ResponsavelCargo[0];
            n885ResponsavelCargo = P00E05_n885ResponsavelCargo[0];
            A447ResponsavelCPF = P00E05_A447ResponsavelCPF[0];
            n447ResponsavelCPF = P00E05_n447ResponsavelCPF[0];
            A436ResponsavelNome = P00E05_A436ResponsavelNome[0];
            n436ResponsavelNome = P00E05_n436ResponsavelNome[0];
            A455ResponsavelNumero = P00E05_A455ResponsavelNumero[0];
            n455ResponsavelNumero = P00E05_n455ResponsavelNumero[0];
            A454ResponsavelDDD = P00E05_A454ResponsavelDDD[0];
            n454ResponsavelDDD = P00E05_n454ResponsavelDDD[0];
            A168ClienteId = P00E05_A168ClienteId[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wprepresentantesds_1_filterfulltext)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) || ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) ||
            ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) || ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) || ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) ||
            ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) || ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) ||
            ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) || ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wprepresentantesds_7_tfresponsavelcelular_f)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV59Wprepresentantesds_7_tfresponsavelcelular_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ! ( StringUtil.StrCmp(AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                     {
                        AV37count = 0;
                        while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00E05_A456ResponsavelEmail[0], A456ResponsavelEmail) == 0 ) )
                        {
                           BRKE07 = false;
                           A168ClienteId = P00E05_A168ClienteId[0];
                           AV37count = (long)(AV37count+1);
                           BRKE07 = true;
                           pr_default.readNext(3);
                        }
                        if ( (0==AV28SkipItems) )
                        {
                           AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A456ResponsavelEmail)) ? "<#Empty#>" : A456ResponsavelEmail);
                           AV33Options.Add(AV32Option, 0);
                           AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV33Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV28SkipItems = (short)(AV28SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRKE07 )
            {
               BRKE07 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADCLIENTEDOCUMENTOOPTIONS' Routine */
         returnInSub = false;
         AV20TFClienteDocumento = AV27SearchTxt;
         AV21TFClienteDocumento_Sel = "";
         AV53Wprepresentantesds_1_filterfulltext = AV49FilterFullText;
         AV54Wprepresentantesds_2_tipoclienteid = AV50TipoClienteId;
         AV55Wprepresentantesds_3_tfresponsavelnome = AV10TFResponsavelNome;
         AV56Wprepresentantesds_4_tfresponsavelnome_sel = AV11TFResponsavelNome_Sel;
         AV57Wprepresentantesds_5_tfresponsavelcpf = AV12TFResponsavelCPF;
         AV58Wprepresentantesds_6_tfresponsavelcpf_sel = AV13TFResponsavelCPF_Sel;
         AV59Wprepresentantesds_7_tfresponsavelcelular_f = AV14TFResponsavelCelular_F;
         AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel = AV15TFResponsavelCelular_F_Sel;
         AV61Wprepresentantesds_9_tfresponsavelemail = AV16TFResponsavelEmail;
         AV62Wprepresentantesds_10_tfresponsavelemail_sel = AV17TFResponsavelEmail_Sel;
         AV63Wprepresentantesds_11_tfresponsavelcargo_sels = AV19TFResponsavelCargo_Sels;
         AV64Wprepresentantesds_12_tfclientedocumento = AV20TFClienteDocumento;
         AV65Wprepresentantesds_13_tfclientedocumento_sel = AV21TFClienteDocumento_Sel;
         AV66Wprepresentantesds_14_tfclienterazaosocial = AV22TFClienteRazaoSocial;
         AV67Wprepresentantesds_15_tfclienterazaosocial_sel = AV23TFClienteRazaoSocial_Sel;
         AV68Wprepresentantesds_16_tfclientesituacao_sels = AV25TFClienteSituacao_Sels;
         AV69Wprepresentantesds_17_tfclientestatus_sel = AV26TFClienteStatus_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV63Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                              A884ClienteSituacao ,
                                              AV68Wprepresentantesds_16_tfclientesituacao_sels ,
                                              AV56Wprepresentantesds_4_tfresponsavelnome_sel ,
                                              AV55Wprepresentantesds_3_tfresponsavelnome ,
                                              AV58Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                              AV57Wprepresentantesds_5_tfresponsavelcpf ,
                                              AV62Wprepresentantesds_10_tfresponsavelemail_sel ,
                                              AV61Wprepresentantesds_9_tfresponsavelemail ,
                                              AV63Wprepresentantesds_11_tfresponsavelcargo_sels.Count ,
                                              AV65Wprepresentantesds_13_tfclientedocumento_sel ,
                                              AV64Wprepresentantesds_12_tfclientedocumento ,
                                              AV67Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                              AV66Wprepresentantesds_14_tfclienterazaosocial ,
                                              AV68Wprepresentantesds_16_tfclientesituacao_sels.Count ,
                                              AV69Wprepresentantesds_17_tfclientestatus_sel ,
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A169ClienteDocumento ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV53Wprepresentantesds_1_filterfulltext ,
                                              A577ResponsavelCelular_F ,
                                              AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                              AV59Wprepresentantesds_7_tfresponsavelcelular_f ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Wprepresentantesds_3_tfresponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV55Wprepresentantesds_3_tfresponsavelnome), "%", "");
         lV57Wprepresentantesds_5_tfresponsavelcpf = StringUtil.Concat( StringUtil.RTrim( AV57Wprepresentantesds_5_tfresponsavelcpf), "%", "");
         lV61Wprepresentantesds_9_tfresponsavelemail = StringUtil.Concat( StringUtil.RTrim( AV61Wprepresentantesds_9_tfresponsavelemail), "%", "");
         lV64Wprepresentantesds_12_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV64Wprepresentantesds_12_tfclientedocumento), "%", "");
         lV66Wprepresentantesds_14_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV66Wprepresentantesds_14_tfclienterazaosocial), "%", "");
         /* Using cursor P00E06 */
         pr_default.execute(4, new Object[] {lV55Wprepresentantesds_3_tfresponsavelnome, AV56Wprepresentantesds_4_tfresponsavelnome_sel, lV57Wprepresentantesds_5_tfresponsavelcpf, AV58Wprepresentantesds_6_tfresponsavelcpf_sel, lV61Wprepresentantesds_9_tfresponsavelemail, AV62Wprepresentantesds_10_tfresponsavelemail_sel, lV64Wprepresentantesds_12_tfclientedocumento, AV65Wprepresentantesds_13_tfclientedocumento_sel, lV66Wprepresentantesds_14_tfclienterazaosocial, AV67Wprepresentantesds_15_tfclienterazaosocial_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKE09 = false;
            A169ClienteDocumento = P00E06_A169ClienteDocumento[0];
            n169ClienteDocumento = P00E06_n169ClienteDocumento[0];
            A192TipoClienteId = P00E06_A192TipoClienteId[0];
            n192TipoClienteId = P00E06_n192TipoClienteId[0];
            A174ClienteStatus = P00E06_A174ClienteStatus[0];
            n174ClienteStatus = P00E06_n174ClienteStatus[0];
            A884ClienteSituacao = P00E06_A884ClienteSituacao[0];
            n884ClienteSituacao = P00E06_n884ClienteSituacao[0];
            A170ClienteRazaoSocial = P00E06_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00E06_n170ClienteRazaoSocial[0];
            A885ResponsavelCargo = P00E06_A885ResponsavelCargo[0];
            n885ResponsavelCargo = P00E06_n885ResponsavelCargo[0];
            A456ResponsavelEmail = P00E06_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00E06_n456ResponsavelEmail[0];
            A447ResponsavelCPF = P00E06_A447ResponsavelCPF[0];
            n447ResponsavelCPF = P00E06_n447ResponsavelCPF[0];
            A436ResponsavelNome = P00E06_A436ResponsavelNome[0];
            n436ResponsavelNome = P00E06_n436ResponsavelNome[0];
            A455ResponsavelNumero = P00E06_A455ResponsavelNumero[0];
            n455ResponsavelNumero = P00E06_n455ResponsavelNumero[0];
            A454ResponsavelDDD = P00E06_A454ResponsavelDDD[0];
            n454ResponsavelDDD = P00E06_n454ResponsavelDDD[0];
            A168ClienteId = P00E06_A168ClienteId[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wprepresentantesds_1_filterfulltext)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) || ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) ||
            ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) || ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) || ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) ||
            ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) || ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) ||
            ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) || ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wprepresentantesds_7_tfresponsavelcelular_f)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV59Wprepresentantesds_7_tfresponsavelcelular_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ! ( StringUtil.StrCmp(AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                     {
                        AV37count = 0;
                        while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00E06_A169ClienteDocumento[0], A169ClienteDocumento) == 0 ) )
                        {
                           BRKE09 = false;
                           A168ClienteId = P00E06_A168ClienteId[0];
                           AV37count = (long)(AV37count+1);
                           BRKE09 = true;
                           pr_default.readNext(4);
                        }
                        if ( (0==AV28SkipItems) )
                        {
                           AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A169ClienteDocumento)) ? "<#Empty#>" : A169ClienteDocumento);
                           AV33Options.Add(AV32Option, 0);
                           AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV33Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV28SkipItems = (short)(AV28SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRKE09 )
            {
               BRKE09 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV22TFClienteRazaoSocial = AV27SearchTxt;
         AV23TFClienteRazaoSocial_Sel = "";
         AV53Wprepresentantesds_1_filterfulltext = AV49FilterFullText;
         AV54Wprepresentantesds_2_tipoclienteid = AV50TipoClienteId;
         AV55Wprepresentantesds_3_tfresponsavelnome = AV10TFResponsavelNome;
         AV56Wprepresentantesds_4_tfresponsavelnome_sel = AV11TFResponsavelNome_Sel;
         AV57Wprepresentantesds_5_tfresponsavelcpf = AV12TFResponsavelCPF;
         AV58Wprepresentantesds_6_tfresponsavelcpf_sel = AV13TFResponsavelCPF_Sel;
         AV59Wprepresentantesds_7_tfresponsavelcelular_f = AV14TFResponsavelCelular_F;
         AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel = AV15TFResponsavelCelular_F_Sel;
         AV61Wprepresentantesds_9_tfresponsavelemail = AV16TFResponsavelEmail;
         AV62Wprepresentantesds_10_tfresponsavelemail_sel = AV17TFResponsavelEmail_Sel;
         AV63Wprepresentantesds_11_tfresponsavelcargo_sels = AV19TFResponsavelCargo_Sels;
         AV64Wprepresentantesds_12_tfclientedocumento = AV20TFClienteDocumento;
         AV65Wprepresentantesds_13_tfclientedocumento_sel = AV21TFClienteDocumento_Sel;
         AV66Wprepresentantesds_14_tfclienterazaosocial = AV22TFClienteRazaoSocial;
         AV67Wprepresentantesds_15_tfclienterazaosocial_sel = AV23TFClienteRazaoSocial_Sel;
         AV68Wprepresentantesds_16_tfclientesituacao_sels = AV25TFClienteSituacao_Sels;
         AV69Wprepresentantesds_17_tfclientestatus_sel = AV26TFClienteStatus_Sel;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A885ResponsavelCargo ,
                                              AV63Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                              A884ClienteSituacao ,
                                              AV68Wprepresentantesds_16_tfclientesituacao_sels ,
                                              AV56Wprepresentantesds_4_tfresponsavelnome_sel ,
                                              AV55Wprepresentantesds_3_tfresponsavelnome ,
                                              AV58Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                              AV57Wprepresentantesds_5_tfresponsavelcpf ,
                                              AV62Wprepresentantesds_10_tfresponsavelemail_sel ,
                                              AV61Wprepresentantesds_9_tfresponsavelemail ,
                                              AV63Wprepresentantesds_11_tfresponsavelcargo_sels.Count ,
                                              AV65Wprepresentantesds_13_tfclientedocumento_sel ,
                                              AV64Wprepresentantesds_12_tfclientedocumento ,
                                              AV67Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                              AV66Wprepresentantesds_14_tfclienterazaosocial ,
                                              AV68Wprepresentantesds_16_tfclientesituacao_sels.Count ,
                                              AV69Wprepresentantesds_17_tfclientestatus_sel ,
                                              A436ResponsavelNome ,
                                              A447ResponsavelCPF ,
                                              A456ResponsavelEmail ,
                                              A169ClienteDocumento ,
                                              A170ClienteRazaoSocial ,
                                              A174ClienteStatus ,
                                              AV53Wprepresentantesds_1_filterfulltext ,
                                              A577ResponsavelCelular_F ,
                                              AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                              AV59Wprepresentantesds_7_tfresponsavelcelular_f ,
                                              A192TipoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Wprepresentantesds_3_tfresponsavelnome = StringUtil.Concat( StringUtil.RTrim( AV55Wprepresentantesds_3_tfresponsavelnome), "%", "");
         lV57Wprepresentantesds_5_tfresponsavelcpf = StringUtil.Concat( StringUtil.RTrim( AV57Wprepresentantesds_5_tfresponsavelcpf), "%", "");
         lV61Wprepresentantesds_9_tfresponsavelemail = StringUtil.Concat( StringUtil.RTrim( AV61Wprepresentantesds_9_tfresponsavelemail), "%", "");
         lV64Wprepresentantesds_12_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV64Wprepresentantesds_12_tfclientedocumento), "%", "");
         lV66Wprepresentantesds_14_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV66Wprepresentantesds_14_tfclienterazaosocial), "%", "");
         /* Using cursor P00E07 */
         pr_default.execute(5, new Object[] {lV55Wprepresentantesds_3_tfresponsavelnome, AV56Wprepresentantesds_4_tfresponsavelnome_sel, lV57Wprepresentantesds_5_tfresponsavelcpf, AV58Wprepresentantesds_6_tfresponsavelcpf_sel, lV61Wprepresentantesds_9_tfresponsavelemail, AV62Wprepresentantesds_10_tfresponsavelemail_sel, lV64Wprepresentantesds_12_tfclientedocumento, AV65Wprepresentantesds_13_tfclientedocumento_sel, lV66Wprepresentantesds_14_tfclienterazaosocial, AV67Wprepresentantesds_15_tfclienterazaosocial_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKE011 = false;
            A192TipoClienteId = P00E07_A192TipoClienteId[0];
            n192TipoClienteId = P00E07_n192TipoClienteId[0];
            A170ClienteRazaoSocial = P00E07_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00E07_n170ClienteRazaoSocial[0];
            A174ClienteStatus = P00E07_A174ClienteStatus[0];
            n174ClienteStatus = P00E07_n174ClienteStatus[0];
            A884ClienteSituacao = P00E07_A884ClienteSituacao[0];
            n884ClienteSituacao = P00E07_n884ClienteSituacao[0];
            A169ClienteDocumento = P00E07_A169ClienteDocumento[0];
            n169ClienteDocumento = P00E07_n169ClienteDocumento[0];
            A885ResponsavelCargo = P00E07_A885ResponsavelCargo[0];
            n885ResponsavelCargo = P00E07_n885ResponsavelCargo[0];
            A456ResponsavelEmail = P00E07_A456ResponsavelEmail[0];
            n456ResponsavelEmail = P00E07_n456ResponsavelEmail[0];
            A447ResponsavelCPF = P00E07_A447ResponsavelCPF[0];
            n447ResponsavelCPF = P00E07_n447ResponsavelCPF[0];
            A436ResponsavelNome = P00E07_A436ResponsavelNome[0];
            n436ResponsavelNome = P00E07_n436ResponsavelNome[0];
            A455ResponsavelNumero = P00E07_A455ResponsavelNumero[0];
            n455ResponsavelNumero = P00E07_n455ResponsavelNumero[0];
            A454ResponsavelDDD = P00E07_A454ResponsavelDDD[0];
            n454ResponsavelDDD = P00E07_n454ResponsavelDDD[0];
            A168ClienteId = P00E07_A168ClienteId[0];
            GXt_char1 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char1) ;
            A577ResponsavelCelular_F = GXt_char1;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Wprepresentantesds_1_filterfulltext)) || ( ( StringUtil.Like( A436ResponsavelNome , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A447ResponsavelCPF , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A456ResponsavelEmail , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "diretor" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "DIRETOR") == 0 ) ) || ( StringUtil.Like( "gerente" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "GERENTE") == 0 ) ) ||
            ( StringUtil.Like( "coordenador" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "COORDENADOR") == 0 ) ) || ( StringUtil.Like( "supervisor" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "SUPERVISOR") == 0 ) ) || ( StringUtil.Like( "analista" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ANALISTA") == 0 ) ) ||
            ( StringUtil.Like( "assistente" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "ASSISTENTE") == 0 ) ) || ( StringUtil.Like( "estagiario" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A885ResponsavelCargo, "ESTAGIARIO") == 0 ) ) || ( StringUtil.Like( "outro" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A885ResponsavelCargo, "OUTRO") == 0 ) ) || ( StringUtil.Like( A169ClienteDocumento , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 101 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( A170ClienteRazaoSocial , StringUtil.PadR( "%" + AV53Wprepresentantesds_1_filterfulltext , 150 , "%"),  ' ' ) ) || ( StringUtil.Like( "aguardando análise" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "P") == 0 ) ) ||
            ( StringUtil.Like( "aprovado" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "A") == 0 ) ) || ( StringUtil.Like( "rejeitado" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A884ClienteSituacao, "R") == 0 ) ) ||
            ( StringUtil.Like( "ativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A174ClienteStatus ) ) || ( StringUtil.Like( "inativo" , StringUtil.PadR( "%" + StringUtil.Lower( AV53Wprepresentantesds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A174ClienteStatus ) )
            )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Wprepresentantesds_7_tfresponsavelcelular_f)) ) ) || ( StringUtil.Like( A577ResponsavelCelular_F , StringUtil.PadR( AV59Wprepresentantesds_7_tfresponsavelcelular_f , 40 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel)) && ! ( StringUtil.StrCmp(AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A577ResponsavelCelular_F, AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A577ResponsavelCelular_F)) ) )
                     {
                        AV37count = 0;
                        while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00E07_A170ClienteRazaoSocial[0], A170ClienteRazaoSocial) == 0 ) )
                        {
                           BRKE011 = false;
                           A168ClienteId = P00E07_A168ClienteId[0];
                           AV37count = (long)(AV37count+1);
                           BRKE011 = true;
                           pr_default.readNext(5);
                        }
                        if ( (0==AV28SkipItems) )
                        {
                           AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ClienteRazaoSocial)) ? "<#Empty#>" : A170ClienteRazaoSocial);
                           AV34OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")));
                           AV33Options.Add(AV32Option, 0);
                           AV35OptionsDesc.Add(AV34OptionDesc, 0);
                           AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                           if ( AV33Options.Count == 10 )
                           {
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                        else
                        {
                           AV28SkipItems = (short)(AV28SkipItems-1);
                        }
                     }
                  }
               }
            }
            if ( ! BRKE011 )
            {
               BRKE011 = true;
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
         AV46OptionsJson = "";
         AV47OptionsDescJson = "";
         AV48OptionIndexesJson = "";
         AV33Options = new GxSimpleCollection<string>();
         AV35OptionsDesc = new GxSimpleCollection<string>();
         AV36OptionIndexes = new GxSimpleCollection<string>();
         AV27SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV38Session = context.GetSession();
         AV40GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV41GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV49FilterFullText = "";
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
         AV24TFClienteSituacao_SelsJson = "";
         AV25TFClienteSituacao_Sels = new GxSimpleCollection<string>();
         AV53Wprepresentantesds_1_filterfulltext = "";
         AV55Wprepresentantesds_3_tfresponsavelnome = "";
         AV56Wprepresentantesds_4_tfresponsavelnome_sel = "";
         AV57Wprepresentantesds_5_tfresponsavelcpf = "";
         AV58Wprepresentantesds_6_tfresponsavelcpf_sel = "";
         AV59Wprepresentantesds_7_tfresponsavelcelular_f = "";
         AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel = "";
         AV61Wprepresentantesds_9_tfresponsavelemail = "";
         AV62Wprepresentantesds_10_tfresponsavelemail_sel = "";
         AV63Wprepresentantesds_11_tfresponsavelcargo_sels = new GxSimpleCollection<string>();
         AV64Wprepresentantesds_12_tfclientedocumento = "";
         AV65Wprepresentantesds_13_tfclientedocumento_sel = "";
         AV66Wprepresentantesds_14_tfclienterazaosocial = "";
         AV67Wprepresentantesds_15_tfclienterazaosocial_sel = "";
         AV68Wprepresentantesds_16_tfclientesituacao_sels = new GxSimpleCollection<string>();
         lV53Wprepresentantesds_1_filterfulltext = "";
         lV55Wprepresentantesds_3_tfresponsavelnome = "";
         lV57Wprepresentantesds_5_tfresponsavelcpf = "";
         lV61Wprepresentantesds_9_tfresponsavelemail = "";
         lV64Wprepresentantesds_12_tfclientedocumento = "";
         lV66Wprepresentantesds_14_tfclienterazaosocial = "";
         A885ResponsavelCargo = "";
         A884ClienteSituacao = "";
         A436ResponsavelNome = "";
         A447ResponsavelCPF = "";
         A456ResponsavelEmail = "";
         A169ClienteDocumento = "";
         A170ClienteRazaoSocial = "";
         A577ResponsavelCelular_F = "";
         P00E02_A192TipoClienteId = new short[1] ;
         P00E02_n192TipoClienteId = new bool[] {false} ;
         P00E02_A436ResponsavelNome = new string[] {""} ;
         P00E02_n436ResponsavelNome = new bool[] {false} ;
         P00E02_A174ClienteStatus = new bool[] {false} ;
         P00E02_n174ClienteStatus = new bool[] {false} ;
         P00E02_A884ClienteSituacao = new string[] {""} ;
         P00E02_n884ClienteSituacao = new bool[] {false} ;
         P00E02_A170ClienteRazaoSocial = new string[] {""} ;
         P00E02_n170ClienteRazaoSocial = new bool[] {false} ;
         P00E02_A169ClienteDocumento = new string[] {""} ;
         P00E02_n169ClienteDocumento = new bool[] {false} ;
         P00E02_A885ResponsavelCargo = new string[] {""} ;
         P00E02_n885ResponsavelCargo = new bool[] {false} ;
         P00E02_A456ResponsavelEmail = new string[] {""} ;
         P00E02_n456ResponsavelEmail = new bool[] {false} ;
         P00E02_A447ResponsavelCPF = new string[] {""} ;
         P00E02_n447ResponsavelCPF = new bool[] {false} ;
         P00E02_A455ResponsavelNumero = new int[1] ;
         P00E02_n455ResponsavelNumero = new bool[] {false} ;
         P00E02_A454ResponsavelDDD = new short[1] ;
         P00E02_n454ResponsavelDDD = new bool[] {false} ;
         P00E02_A168ClienteId = new int[1] ;
         AV32Option = "";
         P00E03_A192TipoClienteId = new short[1] ;
         P00E03_n192TipoClienteId = new bool[] {false} ;
         P00E03_A447ResponsavelCPF = new string[] {""} ;
         P00E03_n447ResponsavelCPF = new bool[] {false} ;
         P00E03_A174ClienteStatus = new bool[] {false} ;
         P00E03_n174ClienteStatus = new bool[] {false} ;
         P00E03_A884ClienteSituacao = new string[] {""} ;
         P00E03_n884ClienteSituacao = new bool[] {false} ;
         P00E03_A170ClienteRazaoSocial = new string[] {""} ;
         P00E03_n170ClienteRazaoSocial = new bool[] {false} ;
         P00E03_A169ClienteDocumento = new string[] {""} ;
         P00E03_n169ClienteDocumento = new bool[] {false} ;
         P00E03_A885ResponsavelCargo = new string[] {""} ;
         P00E03_n885ResponsavelCargo = new bool[] {false} ;
         P00E03_A456ResponsavelEmail = new string[] {""} ;
         P00E03_n456ResponsavelEmail = new bool[] {false} ;
         P00E03_A436ResponsavelNome = new string[] {""} ;
         P00E03_n436ResponsavelNome = new bool[] {false} ;
         P00E03_A455ResponsavelNumero = new int[1] ;
         P00E03_n455ResponsavelNumero = new bool[] {false} ;
         P00E03_A454ResponsavelDDD = new short[1] ;
         P00E03_n454ResponsavelDDD = new bool[] {false} ;
         P00E03_A168ClienteId = new int[1] ;
         P00E04_A192TipoClienteId = new short[1] ;
         P00E04_n192TipoClienteId = new bool[] {false} ;
         P00E04_A174ClienteStatus = new bool[] {false} ;
         P00E04_n174ClienteStatus = new bool[] {false} ;
         P00E04_A884ClienteSituacao = new string[] {""} ;
         P00E04_n884ClienteSituacao = new bool[] {false} ;
         P00E04_A170ClienteRazaoSocial = new string[] {""} ;
         P00E04_n170ClienteRazaoSocial = new bool[] {false} ;
         P00E04_A169ClienteDocumento = new string[] {""} ;
         P00E04_n169ClienteDocumento = new bool[] {false} ;
         P00E04_A885ResponsavelCargo = new string[] {""} ;
         P00E04_n885ResponsavelCargo = new bool[] {false} ;
         P00E04_A456ResponsavelEmail = new string[] {""} ;
         P00E04_n456ResponsavelEmail = new bool[] {false} ;
         P00E04_A447ResponsavelCPF = new string[] {""} ;
         P00E04_n447ResponsavelCPF = new bool[] {false} ;
         P00E04_A436ResponsavelNome = new string[] {""} ;
         P00E04_n436ResponsavelNome = new bool[] {false} ;
         P00E04_A455ResponsavelNumero = new int[1] ;
         P00E04_n455ResponsavelNumero = new bool[] {false} ;
         P00E04_A454ResponsavelDDD = new short[1] ;
         P00E04_n454ResponsavelDDD = new bool[] {false} ;
         P00E04_A168ClienteId = new int[1] ;
         P00E05_A192TipoClienteId = new short[1] ;
         P00E05_n192TipoClienteId = new bool[] {false} ;
         P00E05_A456ResponsavelEmail = new string[] {""} ;
         P00E05_n456ResponsavelEmail = new bool[] {false} ;
         P00E05_A174ClienteStatus = new bool[] {false} ;
         P00E05_n174ClienteStatus = new bool[] {false} ;
         P00E05_A884ClienteSituacao = new string[] {""} ;
         P00E05_n884ClienteSituacao = new bool[] {false} ;
         P00E05_A170ClienteRazaoSocial = new string[] {""} ;
         P00E05_n170ClienteRazaoSocial = new bool[] {false} ;
         P00E05_A169ClienteDocumento = new string[] {""} ;
         P00E05_n169ClienteDocumento = new bool[] {false} ;
         P00E05_A885ResponsavelCargo = new string[] {""} ;
         P00E05_n885ResponsavelCargo = new bool[] {false} ;
         P00E05_A447ResponsavelCPF = new string[] {""} ;
         P00E05_n447ResponsavelCPF = new bool[] {false} ;
         P00E05_A436ResponsavelNome = new string[] {""} ;
         P00E05_n436ResponsavelNome = new bool[] {false} ;
         P00E05_A455ResponsavelNumero = new int[1] ;
         P00E05_n455ResponsavelNumero = new bool[] {false} ;
         P00E05_A454ResponsavelDDD = new short[1] ;
         P00E05_n454ResponsavelDDD = new bool[] {false} ;
         P00E05_A168ClienteId = new int[1] ;
         P00E06_A169ClienteDocumento = new string[] {""} ;
         P00E06_n169ClienteDocumento = new bool[] {false} ;
         P00E06_A192TipoClienteId = new short[1] ;
         P00E06_n192TipoClienteId = new bool[] {false} ;
         P00E06_A174ClienteStatus = new bool[] {false} ;
         P00E06_n174ClienteStatus = new bool[] {false} ;
         P00E06_A884ClienteSituacao = new string[] {""} ;
         P00E06_n884ClienteSituacao = new bool[] {false} ;
         P00E06_A170ClienteRazaoSocial = new string[] {""} ;
         P00E06_n170ClienteRazaoSocial = new bool[] {false} ;
         P00E06_A885ResponsavelCargo = new string[] {""} ;
         P00E06_n885ResponsavelCargo = new bool[] {false} ;
         P00E06_A456ResponsavelEmail = new string[] {""} ;
         P00E06_n456ResponsavelEmail = new bool[] {false} ;
         P00E06_A447ResponsavelCPF = new string[] {""} ;
         P00E06_n447ResponsavelCPF = new bool[] {false} ;
         P00E06_A436ResponsavelNome = new string[] {""} ;
         P00E06_n436ResponsavelNome = new bool[] {false} ;
         P00E06_A455ResponsavelNumero = new int[1] ;
         P00E06_n455ResponsavelNumero = new bool[] {false} ;
         P00E06_A454ResponsavelDDD = new short[1] ;
         P00E06_n454ResponsavelDDD = new bool[] {false} ;
         P00E06_A168ClienteId = new int[1] ;
         P00E07_A192TipoClienteId = new short[1] ;
         P00E07_n192TipoClienteId = new bool[] {false} ;
         P00E07_A170ClienteRazaoSocial = new string[] {""} ;
         P00E07_n170ClienteRazaoSocial = new bool[] {false} ;
         P00E07_A174ClienteStatus = new bool[] {false} ;
         P00E07_n174ClienteStatus = new bool[] {false} ;
         P00E07_A884ClienteSituacao = new string[] {""} ;
         P00E07_n884ClienteSituacao = new bool[] {false} ;
         P00E07_A169ClienteDocumento = new string[] {""} ;
         P00E07_n169ClienteDocumento = new bool[] {false} ;
         P00E07_A885ResponsavelCargo = new string[] {""} ;
         P00E07_n885ResponsavelCargo = new bool[] {false} ;
         P00E07_A456ResponsavelEmail = new string[] {""} ;
         P00E07_n456ResponsavelEmail = new bool[] {false} ;
         P00E07_A447ResponsavelCPF = new string[] {""} ;
         P00E07_n447ResponsavelCPF = new bool[] {false} ;
         P00E07_A436ResponsavelNome = new string[] {""} ;
         P00E07_n436ResponsavelNome = new bool[] {false} ;
         P00E07_A455ResponsavelNumero = new int[1] ;
         P00E07_n455ResponsavelNumero = new bool[] {false} ;
         P00E07_A454ResponsavelDDD = new short[1] ;
         P00E07_n454ResponsavelDDD = new bool[] {false} ;
         P00E07_A168ClienteId = new int[1] ;
         GXt_char1 = "";
         AV34OptionDesc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wprepresentantesgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00E02_A192TipoClienteId, P00E02_n192TipoClienteId, P00E02_A436ResponsavelNome, P00E02_n436ResponsavelNome, P00E02_A174ClienteStatus, P00E02_n174ClienteStatus, P00E02_A884ClienteSituacao, P00E02_n884ClienteSituacao, P00E02_A170ClienteRazaoSocial, P00E02_n170ClienteRazaoSocial,
               P00E02_A169ClienteDocumento, P00E02_n169ClienteDocumento, P00E02_A885ResponsavelCargo, P00E02_n885ResponsavelCargo, P00E02_A456ResponsavelEmail, P00E02_n456ResponsavelEmail, P00E02_A447ResponsavelCPF, P00E02_n447ResponsavelCPF, P00E02_A455ResponsavelNumero, P00E02_n455ResponsavelNumero,
               P00E02_A454ResponsavelDDD, P00E02_n454ResponsavelDDD, P00E02_A168ClienteId
               }
               , new Object[] {
               P00E03_A192TipoClienteId, P00E03_n192TipoClienteId, P00E03_A447ResponsavelCPF, P00E03_n447ResponsavelCPF, P00E03_A174ClienteStatus, P00E03_n174ClienteStatus, P00E03_A884ClienteSituacao, P00E03_n884ClienteSituacao, P00E03_A170ClienteRazaoSocial, P00E03_n170ClienteRazaoSocial,
               P00E03_A169ClienteDocumento, P00E03_n169ClienteDocumento, P00E03_A885ResponsavelCargo, P00E03_n885ResponsavelCargo, P00E03_A456ResponsavelEmail, P00E03_n456ResponsavelEmail, P00E03_A436ResponsavelNome, P00E03_n436ResponsavelNome, P00E03_A455ResponsavelNumero, P00E03_n455ResponsavelNumero,
               P00E03_A454ResponsavelDDD, P00E03_n454ResponsavelDDD, P00E03_A168ClienteId
               }
               , new Object[] {
               P00E04_A192TipoClienteId, P00E04_n192TipoClienteId, P00E04_A174ClienteStatus, P00E04_n174ClienteStatus, P00E04_A884ClienteSituacao, P00E04_n884ClienteSituacao, P00E04_A170ClienteRazaoSocial, P00E04_n170ClienteRazaoSocial, P00E04_A169ClienteDocumento, P00E04_n169ClienteDocumento,
               P00E04_A885ResponsavelCargo, P00E04_n885ResponsavelCargo, P00E04_A456ResponsavelEmail, P00E04_n456ResponsavelEmail, P00E04_A447ResponsavelCPF, P00E04_n447ResponsavelCPF, P00E04_A436ResponsavelNome, P00E04_n436ResponsavelNome, P00E04_A455ResponsavelNumero, P00E04_n455ResponsavelNumero,
               P00E04_A454ResponsavelDDD, P00E04_n454ResponsavelDDD, P00E04_A168ClienteId
               }
               , new Object[] {
               P00E05_A192TipoClienteId, P00E05_n192TipoClienteId, P00E05_A456ResponsavelEmail, P00E05_n456ResponsavelEmail, P00E05_A174ClienteStatus, P00E05_n174ClienteStatus, P00E05_A884ClienteSituacao, P00E05_n884ClienteSituacao, P00E05_A170ClienteRazaoSocial, P00E05_n170ClienteRazaoSocial,
               P00E05_A169ClienteDocumento, P00E05_n169ClienteDocumento, P00E05_A885ResponsavelCargo, P00E05_n885ResponsavelCargo, P00E05_A447ResponsavelCPF, P00E05_n447ResponsavelCPF, P00E05_A436ResponsavelNome, P00E05_n436ResponsavelNome, P00E05_A455ResponsavelNumero, P00E05_n455ResponsavelNumero,
               P00E05_A454ResponsavelDDD, P00E05_n454ResponsavelDDD, P00E05_A168ClienteId
               }
               , new Object[] {
               P00E06_A169ClienteDocumento, P00E06_n169ClienteDocumento, P00E06_A192TipoClienteId, P00E06_n192TipoClienteId, P00E06_A174ClienteStatus, P00E06_n174ClienteStatus, P00E06_A884ClienteSituacao, P00E06_n884ClienteSituacao, P00E06_A170ClienteRazaoSocial, P00E06_n170ClienteRazaoSocial,
               P00E06_A885ResponsavelCargo, P00E06_n885ResponsavelCargo, P00E06_A456ResponsavelEmail, P00E06_n456ResponsavelEmail, P00E06_A447ResponsavelCPF, P00E06_n447ResponsavelCPF, P00E06_A436ResponsavelNome, P00E06_n436ResponsavelNome, P00E06_A455ResponsavelNumero, P00E06_n455ResponsavelNumero,
               P00E06_A454ResponsavelDDD, P00E06_n454ResponsavelDDD, P00E06_A168ClienteId
               }
               , new Object[] {
               P00E07_A192TipoClienteId, P00E07_n192TipoClienteId, P00E07_A170ClienteRazaoSocial, P00E07_n170ClienteRazaoSocial, P00E07_A174ClienteStatus, P00E07_n174ClienteStatus, P00E07_A884ClienteSituacao, P00E07_n884ClienteSituacao, P00E07_A169ClienteDocumento, P00E07_n169ClienteDocumento,
               P00E07_A885ResponsavelCargo, P00E07_n885ResponsavelCargo, P00E07_A456ResponsavelEmail, P00E07_n456ResponsavelEmail, P00E07_A447ResponsavelCPF, P00E07_n447ResponsavelCPF, P00E07_A436ResponsavelNome, P00E07_n436ResponsavelNome, P00E07_A455ResponsavelNumero, P00E07_n455ResponsavelNumero,
               P00E07_A454ResponsavelDDD, P00E07_n454ResponsavelDDD, P00E07_A168ClienteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV30MaxItems ;
      private short AV29PageIndex ;
      private short AV28SkipItems ;
      private short AV50TipoClienteId ;
      private short AV26TFClienteStatus_Sel ;
      private short AV54Wprepresentantesds_2_tipoclienteid ;
      private short AV69Wprepresentantesds_17_tfclientestatus_sel ;
      private short A192TipoClienteId ;
      private short A454ResponsavelDDD ;
      private int AV51GXV1 ;
      private int AV63Wprepresentantesds_11_tfresponsavelcargo_sels_Count ;
      private int AV68Wprepresentantesds_16_tfclientesituacao_sels_Count ;
      private int A455ResponsavelNumero ;
      private int A168ClienteId ;
      private int AV31InsertIndex ;
      private long AV37count ;
      private string A884ClienteSituacao ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool A174ClienteStatus ;
      private bool BRKE02 ;
      private bool n192TipoClienteId ;
      private bool n436ResponsavelNome ;
      private bool n174ClienteStatus ;
      private bool n884ClienteSituacao ;
      private bool n170ClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool n885ResponsavelCargo ;
      private bool n456ResponsavelEmail ;
      private bool n447ResponsavelCPF ;
      private bool n455ResponsavelNumero ;
      private bool n454ResponsavelDDD ;
      private bool BRKE04 ;
      private bool BRKE07 ;
      private bool BRKE09 ;
      private bool BRKE011 ;
      private string AV46OptionsJson ;
      private string AV47OptionsDescJson ;
      private string AV48OptionIndexesJson ;
      private string AV18TFResponsavelCargo_SelsJson ;
      private string AV24TFClienteSituacao_SelsJson ;
      private string AV43DDOName ;
      private string AV44SearchTxtParms ;
      private string AV45SearchTxtTo ;
      private string AV27SearchTxt ;
      private string AV49FilterFullText ;
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
      private string AV53Wprepresentantesds_1_filterfulltext ;
      private string AV55Wprepresentantesds_3_tfresponsavelnome ;
      private string AV56Wprepresentantesds_4_tfresponsavelnome_sel ;
      private string AV57Wprepresentantesds_5_tfresponsavelcpf ;
      private string AV58Wprepresentantesds_6_tfresponsavelcpf_sel ;
      private string AV59Wprepresentantesds_7_tfresponsavelcelular_f ;
      private string AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel ;
      private string AV61Wprepresentantesds_9_tfresponsavelemail ;
      private string AV62Wprepresentantesds_10_tfresponsavelemail_sel ;
      private string AV64Wprepresentantesds_12_tfclientedocumento ;
      private string AV65Wprepresentantesds_13_tfclientedocumento_sel ;
      private string AV66Wprepresentantesds_14_tfclienterazaosocial ;
      private string AV67Wprepresentantesds_15_tfclienterazaosocial_sel ;
      private string lV53Wprepresentantesds_1_filterfulltext ;
      private string lV55Wprepresentantesds_3_tfresponsavelnome ;
      private string lV57Wprepresentantesds_5_tfresponsavelcpf ;
      private string lV61Wprepresentantesds_9_tfresponsavelemail ;
      private string lV64Wprepresentantesds_12_tfclientedocumento ;
      private string lV66Wprepresentantesds_14_tfclienterazaosocial ;
      private string A885ResponsavelCargo ;
      private string A436ResponsavelNome ;
      private string A447ResponsavelCPF ;
      private string A456ResponsavelEmail ;
      private string A169ClienteDocumento ;
      private string A170ClienteRazaoSocial ;
      private string A577ResponsavelCelular_F ;
      private string AV32Option ;
      private string AV34OptionDesc ;
      private IGxSession AV38Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV33Options ;
      private GxSimpleCollection<string> AV35OptionsDesc ;
      private GxSimpleCollection<string> AV36OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
      private GxSimpleCollection<string> AV19TFResponsavelCargo_Sels ;
      private GxSimpleCollection<string> AV25TFClienteSituacao_Sels ;
      private GxSimpleCollection<string> AV63Wprepresentantesds_11_tfresponsavelcargo_sels ;
      private GxSimpleCollection<string> AV68Wprepresentantesds_16_tfclientesituacao_sels ;
      private IDataStoreProvider pr_default ;
      private short[] P00E02_A192TipoClienteId ;
      private bool[] P00E02_n192TipoClienteId ;
      private string[] P00E02_A436ResponsavelNome ;
      private bool[] P00E02_n436ResponsavelNome ;
      private bool[] P00E02_A174ClienteStatus ;
      private bool[] P00E02_n174ClienteStatus ;
      private string[] P00E02_A884ClienteSituacao ;
      private bool[] P00E02_n884ClienteSituacao ;
      private string[] P00E02_A170ClienteRazaoSocial ;
      private bool[] P00E02_n170ClienteRazaoSocial ;
      private string[] P00E02_A169ClienteDocumento ;
      private bool[] P00E02_n169ClienteDocumento ;
      private string[] P00E02_A885ResponsavelCargo ;
      private bool[] P00E02_n885ResponsavelCargo ;
      private string[] P00E02_A456ResponsavelEmail ;
      private bool[] P00E02_n456ResponsavelEmail ;
      private string[] P00E02_A447ResponsavelCPF ;
      private bool[] P00E02_n447ResponsavelCPF ;
      private int[] P00E02_A455ResponsavelNumero ;
      private bool[] P00E02_n455ResponsavelNumero ;
      private short[] P00E02_A454ResponsavelDDD ;
      private bool[] P00E02_n454ResponsavelDDD ;
      private int[] P00E02_A168ClienteId ;
      private short[] P00E03_A192TipoClienteId ;
      private bool[] P00E03_n192TipoClienteId ;
      private string[] P00E03_A447ResponsavelCPF ;
      private bool[] P00E03_n447ResponsavelCPF ;
      private bool[] P00E03_A174ClienteStatus ;
      private bool[] P00E03_n174ClienteStatus ;
      private string[] P00E03_A884ClienteSituacao ;
      private bool[] P00E03_n884ClienteSituacao ;
      private string[] P00E03_A170ClienteRazaoSocial ;
      private bool[] P00E03_n170ClienteRazaoSocial ;
      private string[] P00E03_A169ClienteDocumento ;
      private bool[] P00E03_n169ClienteDocumento ;
      private string[] P00E03_A885ResponsavelCargo ;
      private bool[] P00E03_n885ResponsavelCargo ;
      private string[] P00E03_A456ResponsavelEmail ;
      private bool[] P00E03_n456ResponsavelEmail ;
      private string[] P00E03_A436ResponsavelNome ;
      private bool[] P00E03_n436ResponsavelNome ;
      private int[] P00E03_A455ResponsavelNumero ;
      private bool[] P00E03_n455ResponsavelNumero ;
      private short[] P00E03_A454ResponsavelDDD ;
      private bool[] P00E03_n454ResponsavelDDD ;
      private int[] P00E03_A168ClienteId ;
      private short[] P00E04_A192TipoClienteId ;
      private bool[] P00E04_n192TipoClienteId ;
      private bool[] P00E04_A174ClienteStatus ;
      private bool[] P00E04_n174ClienteStatus ;
      private string[] P00E04_A884ClienteSituacao ;
      private bool[] P00E04_n884ClienteSituacao ;
      private string[] P00E04_A170ClienteRazaoSocial ;
      private bool[] P00E04_n170ClienteRazaoSocial ;
      private string[] P00E04_A169ClienteDocumento ;
      private bool[] P00E04_n169ClienteDocumento ;
      private string[] P00E04_A885ResponsavelCargo ;
      private bool[] P00E04_n885ResponsavelCargo ;
      private string[] P00E04_A456ResponsavelEmail ;
      private bool[] P00E04_n456ResponsavelEmail ;
      private string[] P00E04_A447ResponsavelCPF ;
      private bool[] P00E04_n447ResponsavelCPF ;
      private string[] P00E04_A436ResponsavelNome ;
      private bool[] P00E04_n436ResponsavelNome ;
      private int[] P00E04_A455ResponsavelNumero ;
      private bool[] P00E04_n455ResponsavelNumero ;
      private short[] P00E04_A454ResponsavelDDD ;
      private bool[] P00E04_n454ResponsavelDDD ;
      private int[] P00E04_A168ClienteId ;
      private short[] P00E05_A192TipoClienteId ;
      private bool[] P00E05_n192TipoClienteId ;
      private string[] P00E05_A456ResponsavelEmail ;
      private bool[] P00E05_n456ResponsavelEmail ;
      private bool[] P00E05_A174ClienteStatus ;
      private bool[] P00E05_n174ClienteStatus ;
      private string[] P00E05_A884ClienteSituacao ;
      private bool[] P00E05_n884ClienteSituacao ;
      private string[] P00E05_A170ClienteRazaoSocial ;
      private bool[] P00E05_n170ClienteRazaoSocial ;
      private string[] P00E05_A169ClienteDocumento ;
      private bool[] P00E05_n169ClienteDocumento ;
      private string[] P00E05_A885ResponsavelCargo ;
      private bool[] P00E05_n885ResponsavelCargo ;
      private string[] P00E05_A447ResponsavelCPF ;
      private bool[] P00E05_n447ResponsavelCPF ;
      private string[] P00E05_A436ResponsavelNome ;
      private bool[] P00E05_n436ResponsavelNome ;
      private int[] P00E05_A455ResponsavelNumero ;
      private bool[] P00E05_n455ResponsavelNumero ;
      private short[] P00E05_A454ResponsavelDDD ;
      private bool[] P00E05_n454ResponsavelDDD ;
      private int[] P00E05_A168ClienteId ;
      private string[] P00E06_A169ClienteDocumento ;
      private bool[] P00E06_n169ClienteDocumento ;
      private short[] P00E06_A192TipoClienteId ;
      private bool[] P00E06_n192TipoClienteId ;
      private bool[] P00E06_A174ClienteStatus ;
      private bool[] P00E06_n174ClienteStatus ;
      private string[] P00E06_A884ClienteSituacao ;
      private bool[] P00E06_n884ClienteSituacao ;
      private string[] P00E06_A170ClienteRazaoSocial ;
      private bool[] P00E06_n170ClienteRazaoSocial ;
      private string[] P00E06_A885ResponsavelCargo ;
      private bool[] P00E06_n885ResponsavelCargo ;
      private string[] P00E06_A456ResponsavelEmail ;
      private bool[] P00E06_n456ResponsavelEmail ;
      private string[] P00E06_A447ResponsavelCPF ;
      private bool[] P00E06_n447ResponsavelCPF ;
      private string[] P00E06_A436ResponsavelNome ;
      private bool[] P00E06_n436ResponsavelNome ;
      private int[] P00E06_A455ResponsavelNumero ;
      private bool[] P00E06_n455ResponsavelNumero ;
      private short[] P00E06_A454ResponsavelDDD ;
      private bool[] P00E06_n454ResponsavelDDD ;
      private int[] P00E06_A168ClienteId ;
      private short[] P00E07_A192TipoClienteId ;
      private bool[] P00E07_n192TipoClienteId ;
      private string[] P00E07_A170ClienteRazaoSocial ;
      private bool[] P00E07_n170ClienteRazaoSocial ;
      private bool[] P00E07_A174ClienteStatus ;
      private bool[] P00E07_n174ClienteStatus ;
      private string[] P00E07_A884ClienteSituacao ;
      private bool[] P00E07_n884ClienteSituacao ;
      private string[] P00E07_A169ClienteDocumento ;
      private bool[] P00E07_n169ClienteDocumento ;
      private string[] P00E07_A885ResponsavelCargo ;
      private bool[] P00E07_n885ResponsavelCargo ;
      private string[] P00E07_A456ResponsavelEmail ;
      private bool[] P00E07_n456ResponsavelEmail ;
      private string[] P00E07_A447ResponsavelCPF ;
      private bool[] P00E07_n447ResponsavelCPF ;
      private string[] P00E07_A436ResponsavelNome ;
      private bool[] P00E07_n436ResponsavelNome ;
      private int[] P00E07_A455ResponsavelNumero ;
      private bool[] P00E07_n455ResponsavelNumero ;
      private short[] P00E07_A454ResponsavelDDD ;
      private bool[] P00E07_n454ResponsavelDDD ;
      private int[] P00E07_A168ClienteId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wprepresentantesgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00E02( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV63Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV68Wprepresentantesds_16_tfclientesituacao_sels ,
                                             string AV56Wprepresentantesds_4_tfresponsavelnome_sel ,
                                             string AV55Wprepresentantesds_3_tfresponsavelnome ,
                                             string AV58Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                             string AV57Wprepresentantesds_5_tfresponsavelcpf ,
                                             string AV62Wprepresentantesds_10_tfresponsavelemail_sel ,
                                             string AV61Wprepresentantesds_9_tfresponsavelemail ,
                                             int AV63Wprepresentantesds_11_tfresponsavelcargo_sels_Count ,
                                             string AV65Wprepresentantesds_13_tfclientedocumento_sel ,
                                             string AV64Wprepresentantesds_12_tfclientedocumento ,
                                             string AV67Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                             string AV66Wprepresentantesds_14_tfclienterazaosocial ,
                                             int AV68Wprepresentantesds_16_tfclientesituacao_sels_Count ,
                                             short AV69Wprepresentantesds_17_tfclientestatus_sel ,
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A169ClienteDocumento ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             string AV53Wprepresentantesds_1_filterfulltext ,
                                             string A577ResponsavelCelular_F ,
                                             string AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                             string AV59Wprepresentantesds_7_tfresponsavelcelular_f ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT TipoClienteId, ResponsavelNome, ClienteStatus, ClienteSituacao, ClienteRazaoSocial, ClienteDocumento, ResponsavelCargo, ResponsavelEmail, ResponsavelCPF, ResponsavelNumero, ResponsavelDDD, ClienteId FROM Cliente";
         AddWhere(sWhereString, "(TipoClienteId = 4)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wprepresentantesds_4_tfresponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wprepresentantesds_3_tfresponsavelnome)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelNome like :lV55Wprepresentantesds_3_tfresponsavelnome)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wprepresentantesds_4_tfresponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV56Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelNome = ( :AV56Wprepresentantesds_4_tfresponsavelnome_sel))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( StringUtil.StrCmp(AV56Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Wprepresentantesds_6_tfresponsavelcpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wprepresentantesds_5_tfresponsavelcpf)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelCPF like :lV57Wprepresentantesds_5_tfresponsavelcpf)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wprepresentantesds_6_tfresponsavelcpf_sel)) && ! ( StringUtil.StrCmp(AV58Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelCPF = ( :AV58Wprepresentantesds_6_tfresponsavelcpf_sel))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV58Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Wprepresentantesds_10_tfresponsavelemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wprepresentantesds_9_tfresponsavelemail)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelEmail like :lV61Wprepresentantesds_9_tfresponsavelemail)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wprepresentantesds_10_tfresponsavelemail_sel)) && ! ( StringUtil.StrCmp(AV62Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelEmail = ( :AV62Wprepresentantesds_10_tfresponsavelemail_sel))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV62Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from ResponsavelEmail))=0))");
         }
         if ( AV63Wprepresentantesds_11_tfresponsavelcargo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Wprepresentantesds_11_tfresponsavelcargo_sels, "ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Wprepresentantesds_13_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wprepresentantesds_12_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(ClienteDocumento like :lV64Wprepresentantesds_12_tfclientedocumento)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wprepresentantesds_13_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV65Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ClienteDocumento = ( :AV65Wprepresentantesds_13_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV65Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wprepresentantesds_15_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wprepresentantesds_14_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial like :lV66Wprepresentantesds_14_tfclienterazaosocial)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wprepresentantesds_15_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV67Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial = ( :AV67Wprepresentantesds_15_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from ClienteRazaoSocial))=0))");
         }
         if ( AV68Wprepresentantesds_16_tfclientesituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Wprepresentantesds_16_tfclientesituacao_sels, "ClienteSituacao IN (", ")")+")");
         }
         if ( AV69Wprepresentantesds_17_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(ClienteStatus = TRUE)");
         }
         if ( AV69Wprepresentantesds_17_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ResponsavelNome";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00E03( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV63Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV68Wprepresentantesds_16_tfclientesituacao_sels ,
                                             string AV56Wprepresentantesds_4_tfresponsavelnome_sel ,
                                             string AV55Wprepresentantesds_3_tfresponsavelnome ,
                                             string AV58Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                             string AV57Wprepresentantesds_5_tfresponsavelcpf ,
                                             string AV62Wprepresentantesds_10_tfresponsavelemail_sel ,
                                             string AV61Wprepresentantesds_9_tfresponsavelemail ,
                                             int AV63Wprepresentantesds_11_tfresponsavelcargo_sels_Count ,
                                             string AV65Wprepresentantesds_13_tfclientedocumento_sel ,
                                             string AV64Wprepresentantesds_12_tfclientedocumento ,
                                             string AV67Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                             string AV66Wprepresentantesds_14_tfclienterazaosocial ,
                                             int AV68Wprepresentantesds_16_tfclientesituacao_sels_Count ,
                                             short AV69Wprepresentantesds_17_tfclientestatus_sel ,
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A169ClienteDocumento ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             string AV53Wprepresentantesds_1_filterfulltext ,
                                             string A577ResponsavelCelular_F ,
                                             string AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                             string AV59Wprepresentantesds_7_tfresponsavelcelular_f ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT TipoClienteId, ResponsavelCPF, ClienteStatus, ClienteSituacao, ClienteRazaoSocial, ClienteDocumento, ResponsavelCargo, ResponsavelEmail, ResponsavelNome, ResponsavelNumero, ResponsavelDDD, ClienteId FROM Cliente";
         AddWhere(sWhereString, "(TipoClienteId = 4)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wprepresentantesds_4_tfresponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wprepresentantesds_3_tfresponsavelnome)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelNome like :lV55Wprepresentantesds_3_tfresponsavelnome)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wprepresentantesds_4_tfresponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV56Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelNome = ( :AV56Wprepresentantesds_4_tfresponsavelnome_sel))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( StringUtil.StrCmp(AV56Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Wprepresentantesds_6_tfresponsavelcpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wprepresentantesds_5_tfresponsavelcpf)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelCPF like :lV57Wprepresentantesds_5_tfresponsavelcpf)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wprepresentantesds_6_tfresponsavelcpf_sel)) && ! ( StringUtil.StrCmp(AV58Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelCPF = ( :AV58Wprepresentantesds_6_tfresponsavelcpf_sel))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV58Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Wprepresentantesds_10_tfresponsavelemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wprepresentantesds_9_tfresponsavelemail)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelEmail like :lV61Wprepresentantesds_9_tfresponsavelemail)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wprepresentantesds_10_tfresponsavelemail_sel)) && ! ( StringUtil.StrCmp(AV62Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelEmail = ( :AV62Wprepresentantesds_10_tfresponsavelemail_sel))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV62Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from ResponsavelEmail))=0))");
         }
         if ( AV63Wprepresentantesds_11_tfresponsavelcargo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Wprepresentantesds_11_tfresponsavelcargo_sels, "ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Wprepresentantesds_13_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wprepresentantesds_12_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(ClienteDocumento like :lV64Wprepresentantesds_12_tfclientedocumento)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wprepresentantesds_13_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV65Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ClienteDocumento = ( :AV65Wprepresentantesds_13_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV65Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wprepresentantesds_15_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wprepresentantesds_14_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial like :lV66Wprepresentantesds_14_tfclienterazaosocial)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wprepresentantesds_15_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV67Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial = ( :AV67Wprepresentantesds_15_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from ClienteRazaoSocial))=0))");
         }
         if ( AV68Wprepresentantesds_16_tfclientesituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Wprepresentantesds_16_tfclientesituacao_sels, "ClienteSituacao IN (", ")")+")");
         }
         if ( AV69Wprepresentantesds_17_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(ClienteStatus = TRUE)");
         }
         if ( AV69Wprepresentantesds_17_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ResponsavelCPF";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00E04( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV63Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV68Wprepresentantesds_16_tfclientesituacao_sels ,
                                             string AV56Wprepresentantesds_4_tfresponsavelnome_sel ,
                                             string AV55Wprepresentantesds_3_tfresponsavelnome ,
                                             string AV58Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                             string AV57Wprepresentantesds_5_tfresponsavelcpf ,
                                             string AV62Wprepresentantesds_10_tfresponsavelemail_sel ,
                                             string AV61Wprepresentantesds_9_tfresponsavelemail ,
                                             int AV63Wprepresentantesds_11_tfresponsavelcargo_sels_Count ,
                                             string AV65Wprepresentantesds_13_tfclientedocumento_sel ,
                                             string AV64Wprepresentantesds_12_tfclientedocumento ,
                                             string AV67Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                             string AV66Wprepresentantesds_14_tfclienterazaosocial ,
                                             int AV68Wprepresentantesds_16_tfclientesituacao_sels_Count ,
                                             short AV69Wprepresentantesds_17_tfclientestatus_sel ,
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A169ClienteDocumento ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             string AV53Wprepresentantesds_1_filterfulltext ,
                                             string A577ResponsavelCelular_F ,
                                             string AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                             string AV59Wprepresentantesds_7_tfresponsavelcelular_f ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[10];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT TipoClienteId, ClienteStatus, ClienteSituacao, ClienteRazaoSocial, ClienteDocumento, ResponsavelCargo, ResponsavelEmail, ResponsavelCPF, ResponsavelNome, ResponsavelNumero, ResponsavelDDD, ClienteId FROM Cliente";
         AddWhere(sWhereString, "(TipoClienteId = 4)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wprepresentantesds_4_tfresponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wprepresentantesds_3_tfresponsavelnome)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelNome like :lV55Wprepresentantesds_3_tfresponsavelnome)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wprepresentantesds_4_tfresponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV56Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelNome = ( :AV56Wprepresentantesds_4_tfresponsavelnome_sel))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( StringUtil.StrCmp(AV56Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Wprepresentantesds_6_tfresponsavelcpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wprepresentantesds_5_tfresponsavelcpf)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelCPF like :lV57Wprepresentantesds_5_tfresponsavelcpf)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wprepresentantesds_6_tfresponsavelcpf_sel)) && ! ( StringUtil.StrCmp(AV58Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelCPF = ( :AV58Wprepresentantesds_6_tfresponsavelcpf_sel))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( StringUtil.StrCmp(AV58Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Wprepresentantesds_10_tfresponsavelemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wprepresentantesds_9_tfresponsavelemail)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelEmail like :lV61Wprepresentantesds_9_tfresponsavelemail)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wprepresentantesds_10_tfresponsavelemail_sel)) && ! ( StringUtil.StrCmp(AV62Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelEmail = ( :AV62Wprepresentantesds_10_tfresponsavelemail_sel))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( StringUtil.StrCmp(AV62Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from ResponsavelEmail))=0))");
         }
         if ( AV63Wprepresentantesds_11_tfresponsavelcargo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Wprepresentantesds_11_tfresponsavelcargo_sels, "ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Wprepresentantesds_13_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wprepresentantesds_12_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(ClienteDocumento like :lV64Wprepresentantesds_12_tfclientedocumento)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wprepresentantesds_13_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV65Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ClienteDocumento = ( :AV65Wprepresentantesds_13_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( StringUtil.StrCmp(AV65Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wprepresentantesds_15_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wprepresentantesds_14_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial like :lV66Wprepresentantesds_14_tfclienterazaosocial)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wprepresentantesds_15_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV67Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial = ( :AV67Wprepresentantesds_15_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from ClienteRazaoSocial))=0))");
         }
         if ( AV68Wprepresentantesds_16_tfclientesituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Wprepresentantesds_16_tfclientesituacao_sels, "ClienteSituacao IN (", ")")+")");
         }
         if ( AV69Wprepresentantesds_17_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(ClienteStatus = TRUE)");
         }
         if ( AV69Wprepresentantesds_17_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY TipoClienteId";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00E05( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV63Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV68Wprepresentantesds_16_tfclientesituacao_sels ,
                                             string AV56Wprepresentantesds_4_tfresponsavelnome_sel ,
                                             string AV55Wprepresentantesds_3_tfresponsavelnome ,
                                             string AV58Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                             string AV57Wprepresentantesds_5_tfresponsavelcpf ,
                                             string AV62Wprepresentantesds_10_tfresponsavelemail_sel ,
                                             string AV61Wprepresentantesds_9_tfresponsavelemail ,
                                             int AV63Wprepresentantesds_11_tfresponsavelcargo_sels_Count ,
                                             string AV65Wprepresentantesds_13_tfclientedocumento_sel ,
                                             string AV64Wprepresentantesds_12_tfclientedocumento ,
                                             string AV67Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                             string AV66Wprepresentantesds_14_tfclienterazaosocial ,
                                             int AV68Wprepresentantesds_16_tfclientesituacao_sels_Count ,
                                             short AV69Wprepresentantesds_17_tfclientestatus_sel ,
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A169ClienteDocumento ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             string AV53Wprepresentantesds_1_filterfulltext ,
                                             string A577ResponsavelCelular_F ,
                                             string AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                             string AV59Wprepresentantesds_7_tfresponsavelcelular_f ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[10];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT TipoClienteId, ResponsavelEmail, ClienteStatus, ClienteSituacao, ClienteRazaoSocial, ClienteDocumento, ResponsavelCargo, ResponsavelCPF, ResponsavelNome, ResponsavelNumero, ResponsavelDDD, ClienteId FROM Cliente";
         AddWhere(sWhereString, "(TipoClienteId = 4)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wprepresentantesds_4_tfresponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wprepresentantesds_3_tfresponsavelnome)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelNome like :lV55Wprepresentantesds_3_tfresponsavelnome)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wprepresentantesds_4_tfresponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV56Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelNome = ( :AV56Wprepresentantesds_4_tfresponsavelnome_sel))");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( StringUtil.StrCmp(AV56Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Wprepresentantesds_6_tfresponsavelcpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wprepresentantesds_5_tfresponsavelcpf)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelCPF like :lV57Wprepresentantesds_5_tfresponsavelcpf)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wprepresentantesds_6_tfresponsavelcpf_sel)) && ! ( StringUtil.StrCmp(AV58Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelCPF = ( :AV58Wprepresentantesds_6_tfresponsavelcpf_sel))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( StringUtil.StrCmp(AV58Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Wprepresentantesds_10_tfresponsavelemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wprepresentantesds_9_tfresponsavelemail)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelEmail like :lV61Wprepresentantesds_9_tfresponsavelemail)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wprepresentantesds_10_tfresponsavelemail_sel)) && ! ( StringUtil.StrCmp(AV62Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelEmail = ( :AV62Wprepresentantesds_10_tfresponsavelemail_sel))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( StringUtil.StrCmp(AV62Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from ResponsavelEmail))=0))");
         }
         if ( AV63Wprepresentantesds_11_tfresponsavelcargo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Wprepresentantesds_11_tfresponsavelcargo_sels, "ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Wprepresentantesds_13_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wprepresentantesds_12_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(ClienteDocumento like :lV64Wprepresentantesds_12_tfclientedocumento)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wprepresentantesds_13_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV65Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ClienteDocumento = ( :AV65Wprepresentantesds_13_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( StringUtil.StrCmp(AV65Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wprepresentantesds_15_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wprepresentantesds_14_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial like :lV66Wprepresentantesds_14_tfclienterazaosocial)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wprepresentantesds_15_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV67Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial = ( :AV67Wprepresentantesds_15_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from ClienteRazaoSocial))=0))");
         }
         if ( AV68Wprepresentantesds_16_tfclientesituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Wprepresentantesds_16_tfclientesituacao_sels, "ClienteSituacao IN (", ")")+")");
         }
         if ( AV69Wprepresentantesds_17_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(ClienteStatus = TRUE)");
         }
         if ( AV69Wprepresentantesds_17_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ResponsavelEmail";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00E06( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV63Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV68Wprepresentantesds_16_tfclientesituacao_sels ,
                                             string AV56Wprepresentantesds_4_tfresponsavelnome_sel ,
                                             string AV55Wprepresentantesds_3_tfresponsavelnome ,
                                             string AV58Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                             string AV57Wprepresentantesds_5_tfresponsavelcpf ,
                                             string AV62Wprepresentantesds_10_tfresponsavelemail_sel ,
                                             string AV61Wprepresentantesds_9_tfresponsavelemail ,
                                             int AV63Wprepresentantesds_11_tfresponsavelcargo_sels_Count ,
                                             string AV65Wprepresentantesds_13_tfclientedocumento_sel ,
                                             string AV64Wprepresentantesds_12_tfclientedocumento ,
                                             string AV67Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                             string AV66Wprepresentantesds_14_tfclienterazaosocial ,
                                             int AV68Wprepresentantesds_16_tfclientesituacao_sels_Count ,
                                             short AV69Wprepresentantesds_17_tfclientestatus_sel ,
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A169ClienteDocumento ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             string AV53Wprepresentantesds_1_filterfulltext ,
                                             string A577ResponsavelCelular_F ,
                                             string AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                             string AV59Wprepresentantesds_7_tfresponsavelcelular_f ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[10];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT ClienteDocumento, TipoClienteId, ClienteStatus, ClienteSituacao, ClienteRazaoSocial, ResponsavelCargo, ResponsavelEmail, ResponsavelCPF, ResponsavelNome, ResponsavelNumero, ResponsavelDDD, ClienteId FROM Cliente";
         AddWhere(sWhereString, "(TipoClienteId = 4)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wprepresentantesds_4_tfresponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wprepresentantesds_3_tfresponsavelnome)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelNome like :lV55Wprepresentantesds_3_tfresponsavelnome)");
         }
         else
         {
            GXv_int10[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wprepresentantesds_4_tfresponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV56Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelNome = ( :AV56Wprepresentantesds_4_tfresponsavelnome_sel))");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( StringUtil.StrCmp(AV56Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Wprepresentantesds_6_tfresponsavelcpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wprepresentantesds_5_tfresponsavelcpf)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelCPF like :lV57Wprepresentantesds_5_tfresponsavelcpf)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wprepresentantesds_6_tfresponsavelcpf_sel)) && ! ( StringUtil.StrCmp(AV58Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelCPF = ( :AV58Wprepresentantesds_6_tfresponsavelcpf_sel))");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( StringUtil.StrCmp(AV58Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Wprepresentantesds_10_tfresponsavelemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wprepresentantesds_9_tfresponsavelemail)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelEmail like :lV61Wprepresentantesds_9_tfresponsavelemail)");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wprepresentantesds_10_tfresponsavelemail_sel)) && ! ( StringUtil.StrCmp(AV62Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelEmail = ( :AV62Wprepresentantesds_10_tfresponsavelemail_sel))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( StringUtil.StrCmp(AV62Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from ResponsavelEmail))=0))");
         }
         if ( AV63Wprepresentantesds_11_tfresponsavelcargo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Wprepresentantesds_11_tfresponsavelcargo_sels, "ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Wprepresentantesds_13_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wprepresentantesds_12_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(ClienteDocumento like :lV64Wprepresentantesds_12_tfclientedocumento)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wprepresentantesds_13_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV65Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ClienteDocumento = ( :AV65Wprepresentantesds_13_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( StringUtil.StrCmp(AV65Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wprepresentantesds_15_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wprepresentantesds_14_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial like :lV66Wprepresentantesds_14_tfclienterazaosocial)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wprepresentantesds_15_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV67Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial = ( :AV67Wprepresentantesds_15_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from ClienteRazaoSocial))=0))");
         }
         if ( AV68Wprepresentantesds_16_tfclientesituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Wprepresentantesds_16_tfclientesituacao_sels, "ClienteSituacao IN (", ")")+")");
         }
         if ( AV69Wprepresentantesds_17_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(ClienteStatus = TRUE)");
         }
         if ( AV69Wprepresentantesds_17_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ClienteDocumento";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_P00E07( IGxContext context ,
                                             string A885ResponsavelCargo ,
                                             GxSimpleCollection<string> AV63Wprepresentantesds_11_tfresponsavelcargo_sels ,
                                             string A884ClienteSituacao ,
                                             GxSimpleCollection<string> AV68Wprepresentantesds_16_tfclientesituacao_sels ,
                                             string AV56Wprepresentantesds_4_tfresponsavelnome_sel ,
                                             string AV55Wprepresentantesds_3_tfresponsavelnome ,
                                             string AV58Wprepresentantesds_6_tfresponsavelcpf_sel ,
                                             string AV57Wprepresentantesds_5_tfresponsavelcpf ,
                                             string AV62Wprepresentantesds_10_tfresponsavelemail_sel ,
                                             string AV61Wprepresentantesds_9_tfresponsavelemail ,
                                             int AV63Wprepresentantesds_11_tfresponsavelcargo_sels_Count ,
                                             string AV65Wprepresentantesds_13_tfclientedocumento_sel ,
                                             string AV64Wprepresentantesds_12_tfclientedocumento ,
                                             string AV67Wprepresentantesds_15_tfclienterazaosocial_sel ,
                                             string AV66Wprepresentantesds_14_tfclienterazaosocial ,
                                             int AV68Wprepresentantesds_16_tfclientesituacao_sels_Count ,
                                             short AV69Wprepresentantesds_17_tfclientestatus_sel ,
                                             string A436ResponsavelNome ,
                                             string A447ResponsavelCPF ,
                                             string A456ResponsavelEmail ,
                                             string A169ClienteDocumento ,
                                             string A170ClienteRazaoSocial ,
                                             bool A174ClienteStatus ,
                                             string AV53Wprepresentantesds_1_filterfulltext ,
                                             string A577ResponsavelCelular_F ,
                                             string AV60Wprepresentantesds_8_tfresponsavelcelular_f_sel ,
                                             string AV59Wprepresentantesds_7_tfresponsavelcelular_f ,
                                             short A192TipoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[10];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT TipoClienteId, ClienteRazaoSocial, ClienteStatus, ClienteSituacao, ClienteDocumento, ResponsavelCargo, ResponsavelEmail, ResponsavelCPF, ResponsavelNome, ResponsavelNumero, ResponsavelDDD, ClienteId FROM Cliente";
         AddWhere(sWhereString, "(TipoClienteId = 4)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Wprepresentantesds_4_tfresponsavelnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Wprepresentantesds_3_tfresponsavelnome)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelNome like :lV55Wprepresentantesds_3_tfresponsavelnome)");
         }
         else
         {
            GXv_int12[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Wprepresentantesds_4_tfresponsavelnome_sel)) && ! ( StringUtil.StrCmp(AV56Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelNome = ( :AV56Wprepresentantesds_4_tfresponsavelnome_sel))");
         }
         else
         {
            GXv_int12[1] = 1;
         }
         if ( StringUtil.StrCmp(AV56Wprepresentantesds_4_tfresponsavelnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelNome IS NULL or (char_length(trim(trailing ' ' from ResponsavelNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Wprepresentantesds_6_tfresponsavelcpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wprepresentantesds_5_tfresponsavelcpf)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelCPF like :lV57Wprepresentantesds_5_tfresponsavelcpf)");
         }
         else
         {
            GXv_int12[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Wprepresentantesds_6_tfresponsavelcpf_sel)) && ! ( StringUtil.StrCmp(AV58Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelCPF = ( :AV58Wprepresentantesds_6_tfresponsavelcpf_sel))");
         }
         else
         {
            GXv_int12[3] = 1;
         }
         if ( StringUtil.StrCmp(AV58Wprepresentantesds_6_tfresponsavelcpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelCPF IS NULL or (char_length(trim(trailing ' ' from ResponsavelCPF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Wprepresentantesds_10_tfresponsavelemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wprepresentantesds_9_tfresponsavelemail)) ) )
         {
            AddWhere(sWhereString, "(ResponsavelEmail like :lV61Wprepresentantesds_9_tfresponsavelemail)");
         }
         else
         {
            GXv_int12[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Wprepresentantesds_10_tfresponsavelemail_sel)) && ! ( StringUtil.StrCmp(AV62Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ResponsavelEmail = ( :AV62Wprepresentantesds_10_tfresponsavelemail_sel))");
         }
         else
         {
            GXv_int12[5] = 1;
         }
         if ( StringUtil.StrCmp(AV62Wprepresentantesds_10_tfresponsavelemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ResponsavelEmail IS NULL or (char_length(trim(trailing ' ' from ResponsavelEmail))=0))");
         }
         if ( AV63Wprepresentantesds_11_tfresponsavelcargo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Wprepresentantesds_11_tfresponsavelcargo_sels, "ResponsavelCargo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Wprepresentantesds_13_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wprepresentantesds_12_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(ClienteDocumento like :lV64Wprepresentantesds_12_tfclientedocumento)");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wprepresentantesds_13_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV65Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ClienteDocumento = ( :AV65Wprepresentantesds_13_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( StringUtil.StrCmp(AV65Wprepresentantesds_13_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wprepresentantesds_15_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wprepresentantesds_14_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial like :lV66Wprepresentantesds_14_tfclienterazaosocial)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wprepresentantesds_15_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV67Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial = ( :AV67Wprepresentantesds_15_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wprepresentantesds_15_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from ClienteRazaoSocial))=0))");
         }
         if ( AV68Wprepresentantesds_16_tfclientesituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV68Wprepresentantesds_16_tfclientesituacao_sels, "ClienteSituacao IN (", ")")+")");
         }
         if ( AV69Wprepresentantesds_17_tfclientestatus_sel == 1 )
         {
            AddWhere(sWhereString, "(ClienteStatus = TRUE)");
         }
         if ( AV69Wprepresentantesds_17_tfclientestatus_sel == 2 )
         {
            AddWhere(sWhereString, "(ClienteStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ClienteRazaoSocial";
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
                     return conditional_P00E02(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] );
               case 1 :
                     return conditional_P00E03(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] );
               case 2 :
                     return conditional_P00E04(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] );
               case 3 :
                     return conditional_P00E05(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] );
               case 4 :
                     return conditional_P00E06(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] );
               case 5 :
                     return conditional_P00E07(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] );
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
          Object[] prmP00E02;
          prmP00E02 = new Object[] {
          new ParDef("lV55Wprepresentantesds_3_tfresponsavelnome",GXType.VarChar,90,0) ,
          new ParDef("AV56Wprepresentantesds_4_tfresponsavelnome_sel",GXType.VarChar,90,0) ,
          new ParDef("lV57Wprepresentantesds_5_tfresponsavelcpf",GXType.VarChar,14,0) ,
          new ParDef("AV58Wprepresentantesds_6_tfresponsavelcpf_sel",GXType.VarChar,14,0) ,
          new ParDef("lV61Wprepresentantesds_9_tfresponsavelemail",GXType.VarChar,100,0) ,
          new ParDef("AV62Wprepresentantesds_10_tfresponsavelemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Wprepresentantesds_12_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV65Wprepresentantesds_13_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("lV66Wprepresentantesds_14_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV67Wprepresentantesds_15_tfclienterazaosocial_sel",GXType.VarChar,150,0)
          };
          Object[] prmP00E03;
          prmP00E03 = new Object[] {
          new ParDef("lV55Wprepresentantesds_3_tfresponsavelnome",GXType.VarChar,90,0) ,
          new ParDef("AV56Wprepresentantesds_4_tfresponsavelnome_sel",GXType.VarChar,90,0) ,
          new ParDef("lV57Wprepresentantesds_5_tfresponsavelcpf",GXType.VarChar,14,0) ,
          new ParDef("AV58Wprepresentantesds_6_tfresponsavelcpf_sel",GXType.VarChar,14,0) ,
          new ParDef("lV61Wprepresentantesds_9_tfresponsavelemail",GXType.VarChar,100,0) ,
          new ParDef("AV62Wprepresentantesds_10_tfresponsavelemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Wprepresentantesds_12_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV65Wprepresentantesds_13_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("lV66Wprepresentantesds_14_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV67Wprepresentantesds_15_tfclienterazaosocial_sel",GXType.VarChar,150,0)
          };
          Object[] prmP00E04;
          prmP00E04 = new Object[] {
          new ParDef("lV55Wprepresentantesds_3_tfresponsavelnome",GXType.VarChar,90,0) ,
          new ParDef("AV56Wprepresentantesds_4_tfresponsavelnome_sel",GXType.VarChar,90,0) ,
          new ParDef("lV57Wprepresentantesds_5_tfresponsavelcpf",GXType.VarChar,14,0) ,
          new ParDef("AV58Wprepresentantesds_6_tfresponsavelcpf_sel",GXType.VarChar,14,0) ,
          new ParDef("lV61Wprepresentantesds_9_tfresponsavelemail",GXType.VarChar,100,0) ,
          new ParDef("AV62Wprepresentantesds_10_tfresponsavelemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Wprepresentantesds_12_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV65Wprepresentantesds_13_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("lV66Wprepresentantesds_14_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV67Wprepresentantesds_15_tfclienterazaosocial_sel",GXType.VarChar,150,0)
          };
          Object[] prmP00E05;
          prmP00E05 = new Object[] {
          new ParDef("lV55Wprepresentantesds_3_tfresponsavelnome",GXType.VarChar,90,0) ,
          new ParDef("AV56Wprepresentantesds_4_tfresponsavelnome_sel",GXType.VarChar,90,0) ,
          new ParDef("lV57Wprepresentantesds_5_tfresponsavelcpf",GXType.VarChar,14,0) ,
          new ParDef("AV58Wprepresentantesds_6_tfresponsavelcpf_sel",GXType.VarChar,14,0) ,
          new ParDef("lV61Wprepresentantesds_9_tfresponsavelemail",GXType.VarChar,100,0) ,
          new ParDef("AV62Wprepresentantesds_10_tfresponsavelemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Wprepresentantesds_12_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV65Wprepresentantesds_13_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("lV66Wprepresentantesds_14_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV67Wprepresentantesds_15_tfclienterazaosocial_sel",GXType.VarChar,150,0)
          };
          Object[] prmP00E06;
          prmP00E06 = new Object[] {
          new ParDef("lV55Wprepresentantesds_3_tfresponsavelnome",GXType.VarChar,90,0) ,
          new ParDef("AV56Wprepresentantesds_4_tfresponsavelnome_sel",GXType.VarChar,90,0) ,
          new ParDef("lV57Wprepresentantesds_5_tfresponsavelcpf",GXType.VarChar,14,0) ,
          new ParDef("AV58Wprepresentantesds_6_tfresponsavelcpf_sel",GXType.VarChar,14,0) ,
          new ParDef("lV61Wprepresentantesds_9_tfresponsavelemail",GXType.VarChar,100,0) ,
          new ParDef("AV62Wprepresentantesds_10_tfresponsavelemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Wprepresentantesds_12_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV65Wprepresentantesds_13_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("lV66Wprepresentantesds_14_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV67Wprepresentantesds_15_tfclienterazaosocial_sel",GXType.VarChar,150,0)
          };
          Object[] prmP00E07;
          prmP00E07 = new Object[] {
          new ParDef("lV55Wprepresentantesds_3_tfresponsavelnome",GXType.VarChar,90,0) ,
          new ParDef("AV56Wprepresentantesds_4_tfresponsavelnome_sel",GXType.VarChar,90,0) ,
          new ParDef("lV57Wprepresentantesds_5_tfresponsavelcpf",GXType.VarChar,14,0) ,
          new ParDef("AV58Wprepresentantesds_6_tfresponsavelcpf_sel",GXType.VarChar,14,0) ,
          new ParDef("lV61Wprepresentantesds_9_tfresponsavelemail",GXType.VarChar,100,0) ,
          new ParDef("AV62Wprepresentantesds_10_tfresponsavelemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Wprepresentantesds_12_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV65Wprepresentantesds_13_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("lV66Wprepresentantesds_14_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV67Wprepresentantesds_15_tfclienterazaosocial_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00E02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E02,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E03", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E03,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E04", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E04,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E05", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E05,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E06", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E06,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E07", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E07,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 1);
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
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((short[]) buf[20])[0] = rslt.getShort(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 1);
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
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((short[]) buf[20])[0] = rslt.getShort(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 1);
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
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((short[]) buf[20])[0] = rslt.getShort(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 1);
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
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((short[]) buf[20])[0] = rslt.getShort(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 1);
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
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((short[]) buf[20])[0] = rslt.getShort(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 1);
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
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((short[]) buf[20])[0] = rslt.getShort(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
       }
    }

 }

}
