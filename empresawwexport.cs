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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class empresawwexport : GXProcedure
   {
      public empresawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public empresawwexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV11Filename = "" ;
         this.AV12ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV12ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV11Filename = "" ;
         this.AV12ErrorMessage = "" ;
         SubmitImpl();
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13CellRow = 1;
         AV14FirstColumn = 1;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S191 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFILTERS' */
         S131 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S141 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S151 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S181 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV15Random = (int)(NumberUtil.Random( )*10000);
         GXt_char1 = AV11Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV11Filename = GXt_char1 + "EmpresaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
         AV10ExcelDocument.Open(AV11Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV18FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Filtro principal") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV18FilterFullText, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "EMPRESANOMEFANTASIA") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21EmpresaNomeFantasia1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21EmpresaNomeFantasia1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome fantasia", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome fantasia", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21EmpresaNomeFantasia1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "EMPRESANOMEFANTASIA") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25EmpresaNomeFantasia2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25EmpresaNomeFantasia2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome fantasia", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome fantasia", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25EmpresaNomeFantasia2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "EMPRESANOMEFANTASIA") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29EmpresaNomeFantasia3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29EmpresaNomeFantasia3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome fantasia", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome fantasia", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29EmpresaNomeFantasia3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFEmpresaNomeFantasia_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome fantasia") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV47TFEmpresaNomeFantasia_Sel)) ? "(Vazio)" : AV47TFEmpresaNomeFantasia_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFEmpresaNomeFantasia)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome fantasia") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TFEmpresaNomeFantasia, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFEmpresaRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Razão social") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV49TFEmpresaRazaoSocial_Sel)) ? "(Vazio)" : AV49TFEmpresaRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFEmpresaRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Razão social") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48TFEmpresaRazaoSocial, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFEmpresaCNPJ_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "CNPJ") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV51TFEmpresaCNPJ_Sel)) ? "(Vazio)" : AV51TFEmpresaCNPJ_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFEmpresaCNPJ)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "CNPJ") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV50TFEmpresaCNPJ, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV53TFEmpresaSede_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Sede") ;
            AV13CellRow = GXt_int2;
            if ( AV53TFEmpresaSede_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV53TFEmpresaSede_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Nome fantasia";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Razão social";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "CNPJ";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Sede";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV55Empresawwds_1_filterfulltext = AV18FilterFullText;
         AV56Empresawwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV57Empresawwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV58Empresawwds_4_empresanomefantasia1 = AV21EmpresaNomeFantasia1;
         AV59Empresawwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV60Empresawwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV61Empresawwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV62Empresawwds_8_empresanomefantasia2 = AV25EmpresaNomeFantasia2;
         AV63Empresawwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV64Empresawwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV65Empresawwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV66Empresawwds_12_empresanomefantasia3 = AV29EmpresaNomeFantasia3;
         AV67Empresawwds_13_tfempresanomefantasia = AV46TFEmpresaNomeFantasia;
         AV68Empresawwds_14_tfempresanomefantasia_sel = AV47TFEmpresaNomeFantasia_Sel;
         AV69Empresawwds_15_tfempresarazaosocial = AV48TFEmpresaRazaoSocial;
         AV70Empresawwds_16_tfempresarazaosocial_sel = AV49TFEmpresaRazaoSocial_Sel;
         AV71Empresawwds_17_tfempresacnpj = AV50TFEmpresaCNPJ;
         AV72Empresawwds_18_tfempresacnpj_sel = AV51TFEmpresaCNPJ_Sel;
         AV73Empresawwds_19_tfempresasede_sel = AV53TFEmpresaSede_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV55Empresawwds_1_filterfulltext ,
                                              AV56Empresawwds_2_dynamicfiltersselector1 ,
                                              AV57Empresawwds_3_dynamicfiltersoperator1 ,
                                              AV58Empresawwds_4_empresanomefantasia1 ,
                                              AV59Empresawwds_5_dynamicfiltersenabled2 ,
                                              AV60Empresawwds_6_dynamicfiltersselector2 ,
                                              AV61Empresawwds_7_dynamicfiltersoperator2 ,
                                              AV62Empresawwds_8_empresanomefantasia2 ,
                                              AV63Empresawwds_9_dynamicfiltersenabled3 ,
                                              AV64Empresawwds_10_dynamicfiltersselector3 ,
                                              AV65Empresawwds_11_dynamicfiltersoperator3 ,
                                              AV66Empresawwds_12_empresanomefantasia3 ,
                                              AV68Empresawwds_14_tfempresanomefantasia_sel ,
                                              AV67Empresawwds_13_tfempresanomefantasia ,
                                              AV70Empresawwds_16_tfempresarazaosocial_sel ,
                                              AV69Empresawwds_15_tfempresarazaosocial ,
                                              AV72Empresawwds_18_tfempresacnpj_sel ,
                                              AV71Empresawwds_17_tfempresacnpj ,
                                              AV73Empresawwds_19_tfempresasede_sel ,
                                              A250EmpresaNomeFantasia ,
                                              A251EmpresaRazaoSocial ,
                                              A252EmpresaCNPJ ,
                                              A253EmpresaSede ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV55Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Empresawwds_1_filterfulltext), "%", "");
         lV55Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Empresawwds_1_filterfulltext), "%", "");
         lV55Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Empresawwds_1_filterfulltext), "%", "");
         lV55Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Empresawwds_1_filterfulltext), "%", "");
         lV55Empresawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Empresawwds_1_filterfulltext), "%", "");
         lV58Empresawwds_4_empresanomefantasia1 = StringUtil.Concat( StringUtil.RTrim( AV58Empresawwds_4_empresanomefantasia1), "%", "");
         lV58Empresawwds_4_empresanomefantasia1 = StringUtil.Concat( StringUtil.RTrim( AV58Empresawwds_4_empresanomefantasia1), "%", "");
         lV62Empresawwds_8_empresanomefantasia2 = StringUtil.Concat( StringUtil.RTrim( AV62Empresawwds_8_empresanomefantasia2), "%", "");
         lV62Empresawwds_8_empresanomefantasia2 = StringUtil.Concat( StringUtil.RTrim( AV62Empresawwds_8_empresanomefantasia2), "%", "");
         lV66Empresawwds_12_empresanomefantasia3 = StringUtil.Concat( StringUtil.RTrim( AV66Empresawwds_12_empresanomefantasia3), "%", "");
         lV66Empresawwds_12_empresanomefantasia3 = StringUtil.Concat( StringUtil.RTrim( AV66Empresawwds_12_empresanomefantasia3), "%", "");
         lV67Empresawwds_13_tfempresanomefantasia = StringUtil.Concat( StringUtil.RTrim( AV67Empresawwds_13_tfempresanomefantasia), "%", "");
         lV69Empresawwds_15_tfempresarazaosocial = StringUtil.Concat( StringUtil.RTrim( AV69Empresawwds_15_tfempresarazaosocial), "%", "");
         lV71Empresawwds_17_tfempresacnpj = StringUtil.Concat( StringUtil.RTrim( AV71Empresawwds_17_tfempresacnpj), "%", "");
         /* Using cursor P007G2 */
         pr_default.execute(0, new Object[] {lV55Empresawwds_1_filterfulltext, lV55Empresawwds_1_filterfulltext, lV55Empresawwds_1_filterfulltext, lV55Empresawwds_1_filterfulltext, lV55Empresawwds_1_filterfulltext, lV58Empresawwds_4_empresanomefantasia1, lV58Empresawwds_4_empresanomefantasia1, lV62Empresawwds_8_empresanomefantasia2, lV62Empresawwds_8_empresanomefantasia2, lV66Empresawwds_12_empresanomefantasia3, lV66Empresawwds_12_empresanomefantasia3, lV67Empresawwds_13_tfempresanomefantasia, AV68Empresawwds_14_tfempresanomefantasia_sel, lV69Empresawwds_15_tfempresarazaosocial, AV70Empresawwds_16_tfempresarazaosocial_sel, lV71Empresawwds_17_tfempresacnpj, AV72Empresawwds_18_tfempresacnpj_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A253EmpresaSede = P007G2_A253EmpresaSede[0];
            n253EmpresaSede = P007G2_n253EmpresaSede[0];
            A252EmpresaCNPJ = P007G2_A252EmpresaCNPJ[0];
            n252EmpresaCNPJ = P007G2_n252EmpresaCNPJ[0];
            A251EmpresaRazaoSocial = P007G2_A251EmpresaRazaoSocial[0];
            n251EmpresaRazaoSocial = P007G2_n251EmpresaRazaoSocial[0];
            A250EmpresaNomeFantasia = P007G2_A250EmpresaNomeFantasia[0];
            n250EmpresaNomeFantasia = P007G2_n250EmpresaNomeFantasia[0];
            A249EmpresaId = P007G2_A249EmpresaId[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A250EmpresaNomeFantasia, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A251EmpresaRazaoSocial, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A252EmpresaCNPJ, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A253EmpresaSede)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Sim";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A253EmpresaSede)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Não";
            }
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S181( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV10ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Close();
         AV31Session.Set("WWPExportFilePath", AV11Filename);
         AV31Session.Set("WWPExportFileName", "EmpresaWWExport.xlsx");
         AV11Filename = formatLink("wwpbaseobjects.wwp_downloadreport") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV10ExcelDocument.ErrCode != 0 )
         {
            AV11Filename = "";
            AV12ErrorMessage = AV10ExcelDocument.ErrDescription;
            AV10ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S191( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get("EmpresaWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "EmpresaWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("EmpresaWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV74GXV1 = 1;
         while ( AV74GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV74GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFEMPRESANOMEFANTASIA") == 0 )
            {
               AV46TFEmpresaNomeFantasia = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFEMPRESANOMEFANTASIA_SEL") == 0 )
            {
               AV47TFEmpresaNomeFantasia_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFEMPRESARAZAOSOCIAL") == 0 )
            {
               AV48TFEmpresaRazaoSocial = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFEMPRESARAZAOSOCIAL_SEL") == 0 )
            {
               AV49TFEmpresaRazaoSocial_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFEMPRESACNPJ") == 0 )
            {
               AV50TFEmpresaCNPJ = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFEMPRESACNPJ_SEL") == 0 )
            {
               AV51TFEmpresaCNPJ_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFEMPRESASEDE_SEL") == 0 )
            {
               AV53TFEmpresaSede_Sel = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV74GXV1 = (int)(AV74GXV1+1);
         }
      }

      protected void S162( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S172( )
      {
         /* 'AFTERWRITELINE' Routine */
         returnInSub = false;
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
         AV11Filename = "";
         AV12ErrorMessage = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10ExcelDocument = new ExcelDocumentI();
         AV18FilterFullText = "";
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV21EmpresaNomeFantasia1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25EmpresaNomeFantasia2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29EmpresaNomeFantasia3 = "";
         AV47TFEmpresaNomeFantasia_Sel = "";
         AV46TFEmpresaNomeFantasia = "";
         AV49TFEmpresaRazaoSocial_Sel = "";
         AV48TFEmpresaRazaoSocial = "";
         AV51TFEmpresaCNPJ_Sel = "";
         AV50TFEmpresaCNPJ = "";
         AV55Empresawwds_1_filterfulltext = "";
         AV56Empresawwds_2_dynamicfiltersselector1 = "";
         AV58Empresawwds_4_empresanomefantasia1 = "";
         AV60Empresawwds_6_dynamicfiltersselector2 = "";
         AV62Empresawwds_8_empresanomefantasia2 = "";
         AV64Empresawwds_10_dynamicfiltersselector3 = "";
         AV66Empresawwds_12_empresanomefantasia3 = "";
         AV67Empresawwds_13_tfempresanomefantasia = "";
         AV68Empresawwds_14_tfempresanomefantasia_sel = "";
         AV69Empresawwds_15_tfempresarazaosocial = "";
         AV70Empresawwds_16_tfempresarazaosocial_sel = "";
         AV71Empresawwds_17_tfempresacnpj = "";
         AV72Empresawwds_18_tfempresacnpj_sel = "";
         lV55Empresawwds_1_filterfulltext = "";
         lV58Empresawwds_4_empresanomefantasia1 = "";
         lV62Empresawwds_8_empresanomefantasia2 = "";
         lV66Empresawwds_12_empresanomefantasia3 = "";
         lV67Empresawwds_13_tfempresanomefantasia = "";
         lV69Empresawwds_15_tfempresarazaosocial = "";
         lV71Empresawwds_17_tfempresacnpj = "";
         A250EmpresaNomeFantasia = "";
         A251EmpresaRazaoSocial = "";
         A252EmpresaCNPJ = "";
         P007G2_A253EmpresaSede = new bool[] {false} ;
         P007G2_n253EmpresaSede = new bool[] {false} ;
         P007G2_A252EmpresaCNPJ = new string[] {""} ;
         P007G2_n252EmpresaCNPJ = new bool[] {false} ;
         P007G2_A251EmpresaRazaoSocial = new string[] {""} ;
         P007G2_n251EmpresaRazaoSocial = new bool[] {false} ;
         P007G2_A250EmpresaNomeFantasia = new string[] {""} ;
         P007G2_n250EmpresaNomeFantasia = new bool[] {false} ;
         P007G2_A249EmpresaId = new int[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.empresawwexport__default(),
            new Object[][] {
                new Object[] {
               P007G2_A253EmpresaSede, P007G2_n253EmpresaSede, P007G2_A252EmpresaCNPJ, P007G2_n252EmpresaCNPJ, P007G2_A251EmpresaRazaoSocial, P007G2_n251EmpresaRazaoSocial, P007G2_A250EmpresaNomeFantasia, P007G2_n250EmpresaNomeFantasia, P007G2_A249EmpresaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV53TFEmpresaSede_Sel ;
      private short GXt_int2 ;
      private short AV57Empresawwds_3_dynamicfiltersoperator1 ;
      private short AV61Empresawwds_7_dynamicfiltersoperator2 ;
      private short AV65Empresawwds_11_dynamicfiltersoperator3 ;
      private short AV73Empresawwds_19_tfempresasede_sel ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A249EmpresaId ;
      private int AV74GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV59Empresawwds_5_dynamicfiltersenabled2 ;
      private bool AV63Empresawwds_9_dynamicfiltersenabled3 ;
      private bool A253EmpresaSede ;
      private bool AV17OrderedDsc ;
      private bool n253EmpresaSede ;
      private bool n252EmpresaCNPJ ;
      private bool n251EmpresaRazaoSocial ;
      private bool n250EmpresaNomeFantasia ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21EmpresaNomeFantasia1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25EmpresaNomeFantasia2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29EmpresaNomeFantasia3 ;
      private string AV47TFEmpresaNomeFantasia_Sel ;
      private string AV46TFEmpresaNomeFantasia ;
      private string AV49TFEmpresaRazaoSocial_Sel ;
      private string AV48TFEmpresaRazaoSocial ;
      private string AV51TFEmpresaCNPJ_Sel ;
      private string AV50TFEmpresaCNPJ ;
      private string AV55Empresawwds_1_filterfulltext ;
      private string AV56Empresawwds_2_dynamicfiltersselector1 ;
      private string AV58Empresawwds_4_empresanomefantasia1 ;
      private string AV60Empresawwds_6_dynamicfiltersselector2 ;
      private string AV62Empresawwds_8_empresanomefantasia2 ;
      private string AV64Empresawwds_10_dynamicfiltersselector3 ;
      private string AV66Empresawwds_12_empresanomefantasia3 ;
      private string AV67Empresawwds_13_tfempresanomefantasia ;
      private string AV68Empresawwds_14_tfempresanomefantasia_sel ;
      private string AV69Empresawwds_15_tfempresarazaosocial ;
      private string AV70Empresawwds_16_tfempresarazaosocial_sel ;
      private string AV71Empresawwds_17_tfempresacnpj ;
      private string AV72Empresawwds_18_tfempresacnpj_sel ;
      private string lV55Empresawwds_1_filterfulltext ;
      private string lV58Empresawwds_4_empresanomefantasia1 ;
      private string lV62Empresawwds_8_empresanomefantasia2 ;
      private string lV66Empresawwds_12_empresanomefantasia3 ;
      private string lV67Empresawwds_13_tfempresanomefantasia ;
      private string lV69Empresawwds_15_tfempresarazaosocial ;
      private string lV71Empresawwds_17_tfempresacnpj ;
      private string A250EmpresaNomeFantasia ;
      private string A251EmpresaRazaoSocial ;
      private string A252EmpresaCNPJ ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private bool[] P007G2_A253EmpresaSede ;
      private bool[] P007G2_n253EmpresaSede ;
      private string[] P007G2_A252EmpresaCNPJ ;
      private bool[] P007G2_n252EmpresaCNPJ ;
      private string[] P007G2_A251EmpresaRazaoSocial ;
      private bool[] P007G2_n251EmpresaRazaoSocial ;
      private string[] P007G2_A250EmpresaNomeFantasia ;
      private bool[] P007G2_n250EmpresaNomeFantasia ;
      private int[] P007G2_A249EmpresaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class empresawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007G2( IGxContext context ,
                                             string AV55Empresawwds_1_filterfulltext ,
                                             string AV56Empresawwds_2_dynamicfiltersselector1 ,
                                             short AV57Empresawwds_3_dynamicfiltersoperator1 ,
                                             string AV58Empresawwds_4_empresanomefantasia1 ,
                                             bool AV59Empresawwds_5_dynamicfiltersenabled2 ,
                                             string AV60Empresawwds_6_dynamicfiltersselector2 ,
                                             short AV61Empresawwds_7_dynamicfiltersoperator2 ,
                                             string AV62Empresawwds_8_empresanomefantasia2 ,
                                             bool AV63Empresawwds_9_dynamicfiltersenabled3 ,
                                             string AV64Empresawwds_10_dynamicfiltersselector3 ,
                                             short AV65Empresawwds_11_dynamicfiltersoperator3 ,
                                             string AV66Empresawwds_12_empresanomefantasia3 ,
                                             string AV68Empresawwds_14_tfempresanomefantasia_sel ,
                                             string AV67Empresawwds_13_tfempresanomefantasia ,
                                             string AV70Empresawwds_16_tfempresarazaosocial_sel ,
                                             string AV69Empresawwds_15_tfempresarazaosocial ,
                                             string AV72Empresawwds_18_tfempresacnpj_sel ,
                                             string AV71Empresawwds_17_tfempresacnpj ,
                                             short AV73Empresawwds_19_tfempresasede_sel ,
                                             string A250EmpresaNomeFantasia ,
                                             string A251EmpresaRazaoSocial ,
                                             string A252EmpresaCNPJ ,
                                             bool A253EmpresaSede ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT EmpresaSede, EmpresaCNPJ, EmpresaRazaoSocial, EmpresaNomeFantasia, EmpresaId FROM Empresa";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Empresawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( EmpresaNomeFantasia like '%' || :lV55Empresawwds_1_filterfulltext) or ( EmpresaRazaoSocial like '%' || :lV55Empresawwds_1_filterfulltext) or ( EmpresaCNPJ like '%' || :lV55Empresawwds_1_filterfulltext) or ( 'sim' like '%' || LOWER(:lV55Empresawwds_1_filterfulltext) and EmpresaSede = TRUE) or ( 'não' like '%' || LOWER(:lV55Empresawwds_1_filterfulltext) and EmpresaSede = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Empresawwds_2_dynamicfiltersselector1, "EMPRESANOMEFANTASIA") == 0 ) && ( AV57Empresawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Empresawwds_4_empresanomefantasia1)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV58Empresawwds_4_empresanomefantasia1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Empresawwds_2_dynamicfiltersselector1, "EMPRESANOMEFANTASIA") == 0 ) && ( AV57Empresawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Empresawwds_4_empresanomefantasia1)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV58Empresawwds_4_empresanomefantasia1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV59Empresawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Empresawwds_6_dynamicfiltersselector2, "EMPRESANOMEFANTASIA") == 0 ) && ( AV61Empresawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Empresawwds_8_empresanomefantasia2)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV62Empresawwds_8_empresanomefantasia2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV59Empresawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Empresawwds_6_dynamicfiltersselector2, "EMPRESANOMEFANTASIA") == 0 ) && ( AV61Empresawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Empresawwds_8_empresanomefantasia2)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV62Empresawwds_8_empresanomefantasia2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV63Empresawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Empresawwds_10_dynamicfiltersselector3, "EMPRESANOMEFANTASIA") == 0 ) && ( AV65Empresawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Empresawwds_12_empresanomefantasia3)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV66Empresawwds_12_empresanomefantasia3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV63Empresawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Empresawwds_10_dynamicfiltersselector3, "EMPRESANOMEFANTASIA") == 0 ) && ( AV65Empresawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Empresawwds_12_empresanomefantasia3)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like '%' || :lV66Empresawwds_12_empresanomefantasia3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Empresawwds_14_tfempresanomefantasia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Empresawwds_13_tfempresanomefantasia)) ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia like :lV67Empresawwds_13_tfempresanomefantasia)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Empresawwds_14_tfempresanomefantasia_sel)) && ! ( StringUtil.StrCmp(AV68Empresawwds_14_tfempresanomefantasia_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia = ( :AV68Empresawwds_14_tfempresanomefantasia_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV68Empresawwds_14_tfempresanomefantasia_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaNomeFantasia IS NULL or (char_length(trim(trailing ' ' from EmpresaNomeFantasia))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Empresawwds_16_tfempresarazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Empresawwds_15_tfempresarazaosocial)) ) )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial like :lV69Empresawwds_15_tfempresarazaosocial)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Empresawwds_16_tfempresarazaosocial_sel)) && ! ( StringUtil.StrCmp(AV70Empresawwds_16_tfempresarazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial = ( :AV70Empresawwds_16_tfempresarazaosocial_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV70Empresawwds_16_tfempresarazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaRazaoSocial IS NULL or (char_length(trim(trailing ' ' from EmpresaRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Empresawwds_18_tfempresacnpj_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Empresawwds_17_tfempresacnpj)) ) )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ like :lV71Empresawwds_17_tfempresacnpj)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Empresawwds_18_tfempresacnpj_sel)) && ! ( StringUtil.StrCmp(AV72Empresawwds_18_tfempresacnpj_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ = ( :AV72Empresawwds_18_tfempresacnpj_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV72Empresawwds_18_tfempresacnpj_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(EmpresaCNPJ IS NULL or (char_length(trim(trailing ' ' from EmpresaCNPJ))=0))");
         }
         if ( AV73Empresawwds_19_tfempresasede_sel == 1 )
         {
            AddWhere(sWhereString, "(EmpresaSede = TRUE)");
         }
         if ( AV73Empresawwds_19_tfempresasede_sel == 2 )
         {
            AddWhere(sWhereString, "(EmpresaSede = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY EmpresaNomeFantasia";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmpresaNomeFantasia DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY EmpresaRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmpresaRazaoSocial DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY EmpresaCNPJ";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmpresaCNPJ DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY EmpresaSede";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY EmpresaSede DESC";
         }
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
                     return conditional_P007G2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007G2;
          prmP007G2 = new Object[] {
          new ParDef("lV55Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Empresawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Empresawwds_4_empresanomefantasia1",GXType.VarChar,150,0) ,
          new ParDef("lV58Empresawwds_4_empresanomefantasia1",GXType.VarChar,150,0) ,
          new ParDef("lV62Empresawwds_8_empresanomefantasia2",GXType.VarChar,150,0) ,
          new ParDef("lV62Empresawwds_8_empresanomefantasia2",GXType.VarChar,150,0) ,
          new ParDef("lV66Empresawwds_12_empresanomefantasia3",GXType.VarChar,150,0) ,
          new ParDef("lV66Empresawwds_12_empresanomefantasia3",GXType.VarChar,150,0) ,
          new ParDef("lV67Empresawwds_13_tfempresanomefantasia",GXType.VarChar,150,0) ,
          new ParDef("AV68Empresawwds_14_tfempresanomefantasia_sel",GXType.VarChar,150,0) ,
          new ParDef("lV69Empresawwds_15_tfempresarazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV70Empresawwds_16_tfempresarazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV71Empresawwds_17_tfempresacnpj",GXType.VarChar,14,0) ,
          new ParDef("AV72Empresawwds_18_tfempresacnpj_sel",GXType.VarChar,14,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007G2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
