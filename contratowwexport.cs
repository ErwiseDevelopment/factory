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
   public class contratowwexport : GXProcedure
   {
      public contratowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contratowwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "ContratoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Filtro principal") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV17FilterFullText, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV29GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CONTRATONOME") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20ContratoNome1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ContratoNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20ContratoNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CONTRATOCLIENTEDOCUMENTO") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV43ContratoClienteDocumento1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43ContratoClienteDocumento1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43ContratoClienteDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONTRATONOME") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24ContratoNome2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ContratoNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24ContratoNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONTRATOCLIENTEDOCUMENTO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV44ContratoClienteDocumento2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44ContratoClienteDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44ContratoClienteDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONTRATONOME") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28ContratoNome3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ContratoNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Contrato", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ContratoNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONTRATOCLIENTEDOCUMENTO") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV45ContratoClienteDocumento3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45ContratoClienteDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45ContratoClienteDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFContratoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Contrato") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV35TFContratoNome_Sel)) ? "(Vazio)" : AV35TFContratoNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFContratoNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Contrato") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34TFContratoNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV39TFContratoSituacao_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Situação") ;
            AV13CellRow = GXt_int2;
            AV40i = 1;
            AV46GXV1 = 1;
            while ( AV46GXV1 <= AV39TFContratoSituacao_Sels.Count )
            {
               AV38TFContratoSituacao_Sel = ((string)AV39TFContratoSituacao_Sels.Item(AV46GXV1));
               if ( AV40i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmcontratosituacao.getDescription(context,AV38TFContratoSituacao_Sel);
               AV40i = (long)(AV40i+1);
               AV46GXV1 = (int)(AV46GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Contrato";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Situação";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV48Contratowwds_1_contratoclienteid = AV42ContratoClienteId;
         AV49Contratowwds_2_filterfulltext = AV17FilterFullText;
         AV50Contratowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV51Contratowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV52Contratowwds_5_contratonome1 = AV20ContratoNome1;
         AV53Contratowwds_6_contratoclientedocumento1 = AV43ContratoClienteDocumento1;
         AV54Contratowwds_7_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV55Contratowwds_8_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV56Contratowwds_9_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV57Contratowwds_10_contratonome2 = AV24ContratoNome2;
         AV58Contratowwds_11_contratoclientedocumento2 = AV44ContratoClienteDocumento2;
         AV59Contratowwds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV60Contratowwds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV61Contratowwds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV62Contratowwds_15_contratonome3 = AV28ContratoNome3;
         AV63Contratowwds_16_contratoclientedocumento3 = AV45ContratoClienteDocumento3;
         AV64Contratowwds_17_tfcontratonome = AV34TFContratoNome;
         AV65Contratowwds_18_tfcontratonome_sel = AV35TFContratoNome_Sel;
         AV66Contratowwds_19_tfcontratosituacao_sels = AV39TFContratoSituacao_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A471ContratoSituacao ,
                                              AV66Contratowwds_19_tfcontratosituacao_sels ,
                                              AV49Contratowwds_2_filterfulltext ,
                                              AV50Contratowwds_3_dynamicfiltersselector1 ,
                                              AV51Contratowwds_4_dynamicfiltersoperator1 ,
                                              AV52Contratowwds_5_contratonome1 ,
                                              AV53Contratowwds_6_contratoclientedocumento1 ,
                                              AV54Contratowwds_7_dynamicfiltersenabled2 ,
                                              AV55Contratowwds_8_dynamicfiltersselector2 ,
                                              AV56Contratowwds_9_dynamicfiltersoperator2 ,
                                              AV57Contratowwds_10_contratonome2 ,
                                              AV58Contratowwds_11_contratoclientedocumento2 ,
                                              AV59Contratowwds_12_dynamicfiltersenabled3 ,
                                              AV60Contratowwds_13_dynamicfiltersselector3 ,
                                              AV61Contratowwds_14_dynamicfiltersoperator3 ,
                                              AV62Contratowwds_15_contratonome3 ,
                                              AV63Contratowwds_16_contratoclientedocumento3 ,
                                              AV65Contratowwds_18_tfcontratonome_sel ,
                                              AV64Contratowwds_17_tfcontratonome ,
                                              AV66Contratowwds_19_tfcontratosituacao_sels.Count ,
                                              A228ContratoNome ,
                                              A475ContratoClienteDocumento ,
                                              AV36OrderedBy ,
                                              AV16OrderedDsc ,
                                              AV48Contratowwds_1_contratoclienteid ,
                                              A473ContratoClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV49Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Contratowwds_2_filterfulltext), "%", "");
         lV49Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Contratowwds_2_filterfulltext), "%", "");
         lV49Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Contratowwds_2_filterfulltext), "%", "");
         lV49Contratowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Contratowwds_2_filterfulltext), "%", "");
         lV52Contratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV52Contratowwds_5_contratonome1), "%", "");
         lV52Contratowwds_5_contratonome1 = StringUtil.Concat( StringUtil.RTrim( AV52Contratowwds_5_contratonome1), "%", "");
         lV53Contratowwds_6_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV53Contratowwds_6_contratoclientedocumento1), "%", "");
         lV53Contratowwds_6_contratoclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV53Contratowwds_6_contratoclientedocumento1), "%", "");
         lV57Contratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV57Contratowwds_10_contratonome2), "%", "");
         lV57Contratowwds_10_contratonome2 = StringUtil.Concat( StringUtil.RTrim( AV57Contratowwds_10_contratonome2), "%", "");
         lV58Contratowwds_11_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV58Contratowwds_11_contratoclientedocumento2), "%", "");
         lV58Contratowwds_11_contratoclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV58Contratowwds_11_contratoclientedocumento2), "%", "");
         lV62Contratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV62Contratowwds_15_contratonome3), "%", "");
         lV62Contratowwds_15_contratonome3 = StringUtil.Concat( StringUtil.RTrim( AV62Contratowwds_15_contratonome3), "%", "");
         lV63Contratowwds_16_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV63Contratowwds_16_contratoclientedocumento3), "%", "");
         lV63Contratowwds_16_contratoclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV63Contratowwds_16_contratoclientedocumento3), "%", "");
         lV64Contratowwds_17_tfcontratonome = StringUtil.Concat( StringUtil.RTrim( AV64Contratowwds_17_tfcontratonome), "%", "");
         /* Using cursor P00792 */
         pr_default.execute(0, new Object[] {AV48Contratowwds_1_contratoclienteid, lV49Contratowwds_2_filterfulltext, lV49Contratowwds_2_filterfulltext, lV49Contratowwds_2_filterfulltext, lV49Contratowwds_2_filterfulltext, lV52Contratowwds_5_contratonome1, lV52Contratowwds_5_contratonome1, lV53Contratowwds_6_contratoclientedocumento1, lV53Contratowwds_6_contratoclientedocumento1, lV57Contratowwds_10_contratonome2, lV57Contratowwds_10_contratonome2, lV58Contratowwds_11_contratoclientedocumento2, lV58Contratowwds_11_contratoclientedocumento2, lV62Contratowwds_15_contratonome3, lV62Contratowwds_15_contratonome3, lV63Contratowwds_16_contratoclientedocumento3, lV63Contratowwds_16_contratoclientedocumento3, lV64Contratowwds_17_tfcontratonome, AV65Contratowwds_18_tfcontratonome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A475ContratoClienteDocumento = P00792_A475ContratoClienteDocumento[0];
            n475ContratoClienteDocumento = P00792_n475ContratoClienteDocumento[0];
            A471ContratoSituacao = P00792_A471ContratoSituacao[0];
            n471ContratoSituacao = P00792_n471ContratoSituacao[0];
            A228ContratoNome = P00792_A228ContratoNome[0];
            n228ContratoNome = P00792_n228ContratoNome[0];
            A473ContratoClienteId = P00792_A473ContratoClienteId[0];
            n473ContratoClienteId = P00792_n473ContratoClienteId[0];
            A227ContratoId = P00792_A227ContratoId[0];
            A475ContratoClienteDocumento = P00792_A475ContratoClienteDocumento[0];
            n475ContratoClienteDocumento = P00792_n475ContratoClienteDocumento[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A228ContratoNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmcontratosituacao.getDescription(context,A471ContratoSituacao);
            if ( StringUtil.StrCmp(A471ContratoSituacao, "EmElaboracao") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 0, 192, 239);
            }
            else if ( StringUtil.StrCmp(A471ContratoSituacao, "ColetandoAssinatura") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 60, 141, 188);
            }
            else if ( StringUtil.StrCmp(A471ContratoSituacao, "Assinado") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
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
         AV30Session.Set("WWPExportFilePath", AV11Filename);
         AV30Session.Set("WWPExportFileName", "ContratoWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV30Session.Get("ContratoWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ContratoWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("ContratoWWGridState"), null, "", "");
         }
         AV36OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV16OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV67GXV2 = 1;
         while ( AV67GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV67GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME") == 0 )
            {
               AV34TFContratoNome = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONTRATONOME_SEL") == 0 )
            {
               AV35TFContratoNome_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONTRATOSITUACAO_SEL") == 0 )
            {
               AV37TFContratoSituacao_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV39TFContratoSituacao_Sels.FromJSonString(AV37TFContratoSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "PARM_&CONTRATOCLIENTEID") == 0 )
            {
               AV42ContratoClienteId = (int)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV67GXV2 = (int)(AV67GXV2+1);
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
         AV17FilterFullText = "";
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV20ContratoNome1 = "";
         AV43ContratoClienteDocumento1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24ContratoNome2 = "";
         AV44ContratoClienteDocumento2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28ContratoNome3 = "";
         AV45ContratoClienteDocumento3 = "";
         AV35TFContratoNome_Sel = "";
         AV34TFContratoNome = "";
         AV39TFContratoSituacao_Sels = new GxSimpleCollection<string>();
         AV38TFContratoSituacao_Sel = "";
         AV49Contratowwds_2_filterfulltext = "";
         AV50Contratowwds_3_dynamicfiltersselector1 = "";
         AV52Contratowwds_5_contratonome1 = "";
         AV53Contratowwds_6_contratoclientedocumento1 = "";
         AV55Contratowwds_8_dynamicfiltersselector2 = "";
         AV57Contratowwds_10_contratonome2 = "";
         AV58Contratowwds_11_contratoclientedocumento2 = "";
         AV60Contratowwds_13_dynamicfiltersselector3 = "";
         AV62Contratowwds_15_contratonome3 = "";
         AV63Contratowwds_16_contratoclientedocumento3 = "";
         AV64Contratowwds_17_tfcontratonome = "";
         AV65Contratowwds_18_tfcontratonome_sel = "";
         AV66Contratowwds_19_tfcontratosituacao_sels = new GxSimpleCollection<string>();
         lV49Contratowwds_2_filterfulltext = "";
         lV52Contratowwds_5_contratonome1 = "";
         lV53Contratowwds_6_contratoclientedocumento1 = "";
         lV57Contratowwds_10_contratonome2 = "";
         lV58Contratowwds_11_contratoclientedocumento2 = "";
         lV62Contratowwds_15_contratonome3 = "";
         lV63Contratowwds_16_contratoclientedocumento3 = "";
         lV64Contratowwds_17_tfcontratonome = "";
         A471ContratoSituacao = "";
         A228ContratoNome = "";
         A475ContratoClienteDocumento = "";
         P00792_A475ContratoClienteDocumento = new string[] {""} ;
         P00792_n475ContratoClienteDocumento = new bool[] {false} ;
         P00792_A471ContratoSituacao = new string[] {""} ;
         P00792_n471ContratoSituacao = new bool[] {false} ;
         P00792_A228ContratoNome = new string[] {""} ;
         P00792_n228ContratoNome = new bool[] {false} ;
         P00792_A473ContratoClienteId = new int[1] ;
         P00792_n473ContratoClienteId = new bool[] {false} ;
         P00792_A227ContratoId = new int[1] ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV37TFContratoSituacao_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contratowwexport__default(),
            new Object[][] {
                new Object[] {
               P00792_A475ContratoClienteDocumento, P00792_n475ContratoClienteDocumento, P00792_A471ContratoSituacao, P00792_n471ContratoSituacao, P00792_A228ContratoNome, P00792_n228ContratoNome, P00792_A473ContratoClienteId, P00792_n473ContratoClienteId, P00792_A227ContratoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV51Contratowwds_4_dynamicfiltersoperator1 ;
      private short AV56Contratowwds_9_dynamicfiltersoperator2 ;
      private short AV61Contratowwds_14_dynamicfiltersoperator3 ;
      private short AV36OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV46GXV1 ;
      private int AV48Contratowwds_1_contratoclienteid ;
      private int AV42ContratoClienteId ;
      private int AV66Contratowwds_19_tfcontratosituacao_sels_Count ;
      private int A473ContratoClienteId ;
      private int A227ContratoId ;
      private int AV67GXV2 ;
      private long AV40i ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV54Contratowwds_7_dynamicfiltersenabled2 ;
      private bool AV59Contratowwds_12_dynamicfiltersenabled3 ;
      private bool AV16OrderedDsc ;
      private bool n475ContratoClienteDocumento ;
      private bool n471ContratoSituacao ;
      private bool n228ContratoNome ;
      private bool n473ContratoClienteId ;
      private string AV37TFContratoSituacao_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20ContratoNome1 ;
      private string AV43ContratoClienteDocumento1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24ContratoNome2 ;
      private string AV44ContratoClienteDocumento2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28ContratoNome3 ;
      private string AV45ContratoClienteDocumento3 ;
      private string AV35TFContratoNome_Sel ;
      private string AV34TFContratoNome ;
      private string AV38TFContratoSituacao_Sel ;
      private string AV49Contratowwds_2_filterfulltext ;
      private string AV50Contratowwds_3_dynamicfiltersselector1 ;
      private string AV52Contratowwds_5_contratonome1 ;
      private string AV53Contratowwds_6_contratoclientedocumento1 ;
      private string AV55Contratowwds_8_dynamicfiltersselector2 ;
      private string AV57Contratowwds_10_contratonome2 ;
      private string AV58Contratowwds_11_contratoclientedocumento2 ;
      private string AV60Contratowwds_13_dynamicfiltersselector3 ;
      private string AV62Contratowwds_15_contratonome3 ;
      private string AV63Contratowwds_16_contratoclientedocumento3 ;
      private string AV64Contratowwds_17_tfcontratonome ;
      private string AV65Contratowwds_18_tfcontratonome_sel ;
      private string lV49Contratowwds_2_filterfulltext ;
      private string lV52Contratowwds_5_contratonome1 ;
      private string lV53Contratowwds_6_contratoclientedocumento1 ;
      private string lV57Contratowwds_10_contratonome2 ;
      private string lV58Contratowwds_11_contratoclientedocumento2 ;
      private string lV62Contratowwds_15_contratonome3 ;
      private string lV63Contratowwds_16_contratoclientedocumento3 ;
      private string lV64Contratowwds_17_tfcontratonome ;
      private string A471ContratoSituacao ;
      private string A228ContratoNome ;
      private string A475ContratoClienteDocumento ;
      private IGxSession AV30Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV39TFContratoSituacao_Sels ;
      private GxSimpleCollection<string> AV66Contratowwds_19_tfcontratosituacao_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00792_A475ContratoClienteDocumento ;
      private bool[] P00792_n475ContratoClienteDocumento ;
      private string[] P00792_A471ContratoSituacao ;
      private bool[] P00792_n471ContratoSituacao ;
      private string[] P00792_A228ContratoNome ;
      private bool[] P00792_n228ContratoNome ;
      private int[] P00792_A473ContratoClienteId ;
      private bool[] P00792_n473ContratoClienteId ;
      private int[] P00792_A227ContratoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class contratowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00792( IGxContext context ,
                                             string A471ContratoSituacao ,
                                             GxSimpleCollection<string> AV66Contratowwds_19_tfcontratosituacao_sels ,
                                             string AV49Contratowwds_2_filterfulltext ,
                                             string AV50Contratowwds_3_dynamicfiltersselector1 ,
                                             short AV51Contratowwds_4_dynamicfiltersoperator1 ,
                                             string AV52Contratowwds_5_contratonome1 ,
                                             string AV53Contratowwds_6_contratoclientedocumento1 ,
                                             bool AV54Contratowwds_7_dynamicfiltersenabled2 ,
                                             string AV55Contratowwds_8_dynamicfiltersselector2 ,
                                             short AV56Contratowwds_9_dynamicfiltersoperator2 ,
                                             string AV57Contratowwds_10_contratonome2 ,
                                             string AV58Contratowwds_11_contratoclientedocumento2 ,
                                             bool AV59Contratowwds_12_dynamicfiltersenabled3 ,
                                             string AV60Contratowwds_13_dynamicfiltersselector3 ,
                                             short AV61Contratowwds_14_dynamicfiltersoperator3 ,
                                             string AV62Contratowwds_15_contratonome3 ,
                                             string AV63Contratowwds_16_contratoclientedocumento3 ,
                                             string AV65Contratowwds_18_tfcontratonome_sel ,
                                             string AV64Contratowwds_17_tfcontratonome ,
                                             int AV66Contratowwds_19_tfcontratosituacao_sels_Count ,
                                             string A228ContratoNome ,
                                             string A475ContratoClienteDocumento ,
                                             short AV36OrderedBy ,
                                             bool AV16OrderedDsc ,
                                             int AV48Contratowwds_1_contratoclienteid ,
                                             int A473ContratoClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[19];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.ClienteDocumento AS ContratoClienteDocumento, T1.ContratoSituacao, T1.ContratoNome, T1.ContratoClienteId AS ContratoClienteId, T1.ContratoId FROM (Contrato T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ContratoClienteId)";
         AddWhere(sWhereString, "(T1.ContratoClienteId = :AV48Contratowwds_1_contratoclienteid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Contratowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.ContratoNome like '%' || :lV49Contratowwds_2_filterfulltext) or ( 'em elaboração' like '%' || LOWER(:lV49Contratowwds_2_filterfulltext) and T1.ContratoSituacao = ( 'EmElaboracao')) or ( 'coletando assinaturas' like '%' || LOWER(:lV49Contratowwds_2_filterfulltext) and T1.ContratoSituacao = ( 'ColetandoAssinatura')) or ( 'assinado' like '%' || LOWER(:lV49Contratowwds_2_filterfulltext) and T1.ContratoSituacao = ( 'Assinado')))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Contratowwds_3_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV51Contratowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Contratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV52Contratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Contratowwds_3_dynamicfiltersselector1, "CONTRATONOME") == 0 ) && ( AV51Contratowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Contratowwds_5_contratonome1)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV52Contratowwds_5_contratonome1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Contratowwds_3_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV51Contratowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Contratowwds_6_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV53Contratowwds_6_contratoclientedocumento1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Contratowwds_3_dynamicfiltersselector1, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV51Contratowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Contratowwds_6_contratoclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV53Contratowwds_6_contratoclientedocumento1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV54Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Contratowwds_8_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV56Contratowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Contratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV57Contratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV54Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Contratowwds_8_dynamicfiltersselector2, "CONTRATONOME") == 0 ) && ( AV56Contratowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Contratowwds_10_contratonome2)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV57Contratowwds_10_contratonome2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV54Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Contratowwds_8_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV56Contratowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contratowwds_11_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV58Contratowwds_11_contratoclientedocumento2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV54Contratowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Contratowwds_8_dynamicfiltersselector2, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV56Contratowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contratowwds_11_contratoclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV58Contratowwds_11_contratoclientedocumento2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV59Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Contratowwds_13_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV61Contratowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV62Contratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV59Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Contratowwds_13_dynamicfiltersselector3, "CONTRATONOME") == 0 ) && ( AV61Contratowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Contratowwds_15_contratonome3)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like '%' || :lV62Contratowwds_15_contratonome3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV59Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Contratowwds_13_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV61Contratowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contratowwds_16_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV63Contratowwds_16_contratoclientedocumento3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV59Contratowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Contratowwds_13_dynamicfiltersselector3, "CONTRATOCLIENTEDOCUMENTO") == 0 ) && ( AV61Contratowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contratowwds_16_contratoclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV63Contratowwds_16_contratoclientedocumento3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Contratowwds_18_tfcontratonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contratowwds_17_tfcontratonome)) ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome like :lV64Contratowwds_17_tfcontratonome)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contratowwds_18_tfcontratonome_sel)) && ! ( StringUtil.StrCmp(AV65Contratowwds_18_tfcontratonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ContratoNome = ( :AV65Contratowwds_18_tfcontratonome_sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV65Contratowwds_18_tfcontratonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ContratoNome IS NULL or (char_length(trim(trailing ' ' from T1.ContratoNome))=0))");
         }
         if ( AV66Contratowwds_19_tfcontratosituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV66Contratowwds_19_tfcontratosituacao_sels, "T1.ContratoSituacao IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV36OrderedBy == 1 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ContratoClienteId, T1.ContratoNome";
         }
         else if ( ( AV36OrderedBy == 1 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ContratoClienteId DESC, T1.ContratoNome DESC";
         }
         else if ( ( AV36OrderedBy == 2 ) && ! AV16OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ContratoClienteId, T1.ContratoSituacao";
         }
         else if ( ( AV36OrderedBy == 2 ) && ( AV16OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ContratoClienteId DESC, T1.ContratoSituacao DESC";
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
                     return conditional_P00792(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] );
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
          Object[] prmP00792;
          prmP00792 = new Object[] {
          new ParDef("AV48Contratowwds_1_contratoclienteid",GXType.Int32,9,0) ,
          new ParDef("lV49Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV49Contratowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Contratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV52Contratowwds_5_contratonome1",GXType.VarChar,125,0) ,
          new ParDef("lV53Contratowwds_6_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV53Contratowwds_6_contratoclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV57Contratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV57Contratowwds_10_contratonome2",GXType.VarChar,125,0) ,
          new ParDef("lV58Contratowwds_11_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV58Contratowwds_11_contratoclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV62Contratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV62Contratowwds_15_contratonome3",GXType.VarChar,125,0) ,
          new ParDef("lV63Contratowwds_16_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV63Contratowwds_16_contratoclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV64Contratowwds_17_tfcontratonome",GXType.VarChar,125,0) ,
          new ParDef("AV65Contratowwds_18_tfcontratonome_sel",GXType.VarChar,125,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00792", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00792,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
