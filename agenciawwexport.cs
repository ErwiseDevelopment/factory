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
   public class agenciawwexport : GXProcedure
   {
      public agenciawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public agenciawwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "AgenciaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Filtro principal") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( AV40GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV40GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "AGENCIANUMERO") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV22AgenciaNumero1 = (int)(Math.Round(NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV22AgenciaNumero1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", ">", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV22AgenciaNumero1;
               }
            }
            if ( AV40GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV25DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV40GridState.gxTpr_Dynamicfilters.Item(2));
               AV26DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "AGENCIANUMERO") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV28AgenciaNumero2 = (int)(Math.Round(NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV28AgenciaNumero2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV28AgenciaNumero2;
                  }
               }
               if ( AV40GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV31DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV40GridState.gxTpr_Dynamicfilters.Item(3));
                  AV32DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "AGENCIANUMERO") == 0 )
                  {
                     AV33DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV34AgenciaNumero3 = (int)(Math.Round(NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV34AgenciaNumero3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV33DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV33DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV33DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34AgenciaNumero3;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV58TFAgenciaBancoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Banco") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV58TFAgenciaBancoNome_Sel)) ? "(Vazio)" : AV58TFAgenciaBancoNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFAgenciaBancoNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Banco") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFAgenciaBancoNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV44TFAgenciaNumero) && (0==AV45TFAgenciaNumero_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Número") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV44TFAgenciaNumero;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV45TFAgenciaNumero_To;
         }
         if ( ! ( (0==AV46TFAgenciaDigito) && (0==AV47TFAgenciaDigito_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Dígito") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV46TFAgenciaDigito;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV47TFAgenciaDigito_To;
         }
         if ( ! ( (0==AV48TFAgenciaStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV48TFAgenciaStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV48TFAgenciaStatus_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (DateTime.MinValue==AV51TFAgenciaCreatedAt) && (DateTime.MinValue==AV52TFAgenciaCreatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Criado em") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV51TFAgenciaCreatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV52TFAgenciaCreatedAt_To;
         }
         if ( ! ( (DateTime.MinValue==AV55TFAgenciaUpdatedAt) && (DateTime.MinValue==AV56TFAgenciaUpdatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Atualizado em") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV55TFAgenciaUpdatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV56TFAgenciaUpdatedAt_To;
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Banco";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Número";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Dígito";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Status";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Criado em";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Atualizado em";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV60Agenciawwds_1_filterfulltext = AV19FilterFullText;
         AV61Agenciawwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV62Agenciawwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV63Agenciawwds_4_agencianumero1 = AV22AgenciaNumero1;
         AV64Agenciawwds_5_dynamicfiltersenabled2 = AV25DynamicFiltersEnabled2;
         AV65Agenciawwds_6_dynamicfiltersselector2 = AV26DynamicFiltersSelector2;
         AV66Agenciawwds_7_dynamicfiltersoperator2 = AV27DynamicFiltersOperator2;
         AV67Agenciawwds_8_agencianumero2 = AV28AgenciaNumero2;
         AV68Agenciawwds_9_dynamicfiltersenabled3 = AV31DynamicFiltersEnabled3;
         AV69Agenciawwds_10_dynamicfiltersselector3 = AV32DynamicFiltersSelector3;
         AV70Agenciawwds_11_dynamicfiltersoperator3 = AV33DynamicFiltersOperator3;
         AV71Agenciawwds_12_agencianumero3 = AV34AgenciaNumero3;
         AV72Agenciawwds_13_tfagenciabanconome = AV57TFAgenciaBancoNome;
         AV73Agenciawwds_14_tfagenciabanconome_sel = AV58TFAgenciaBancoNome_Sel;
         AV74Agenciawwds_15_tfagencianumero = AV44TFAgenciaNumero;
         AV75Agenciawwds_16_tfagencianumero_to = AV45TFAgenciaNumero_To;
         AV76Agenciawwds_17_tfagenciadigito = AV46TFAgenciaDigito;
         AV77Agenciawwds_18_tfagenciadigito_to = AV47TFAgenciaDigito_To;
         AV78Agenciawwds_19_tfagenciastatus_sel = AV48TFAgenciaStatus_Sel;
         AV79Agenciawwds_20_tfagenciacreatedat = AV51TFAgenciaCreatedAt;
         AV80Agenciawwds_21_tfagenciacreatedat_to = AV52TFAgenciaCreatedAt_To;
         AV81Agenciawwds_22_tfagenciaupdatedat = AV55TFAgenciaUpdatedAt;
         AV82Agenciawwds_23_tfagenciaupdatedat_to = AV56TFAgenciaUpdatedAt_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV60Agenciawwds_1_filterfulltext ,
                                              AV61Agenciawwds_2_dynamicfiltersselector1 ,
                                              AV62Agenciawwds_3_dynamicfiltersoperator1 ,
                                              AV63Agenciawwds_4_agencianumero1 ,
                                              AV64Agenciawwds_5_dynamicfiltersenabled2 ,
                                              AV65Agenciawwds_6_dynamicfiltersselector2 ,
                                              AV66Agenciawwds_7_dynamicfiltersoperator2 ,
                                              AV67Agenciawwds_8_agencianumero2 ,
                                              AV68Agenciawwds_9_dynamicfiltersenabled3 ,
                                              AV69Agenciawwds_10_dynamicfiltersselector3 ,
                                              AV70Agenciawwds_11_dynamicfiltersoperator3 ,
                                              AV71Agenciawwds_12_agencianumero3 ,
                                              AV73Agenciawwds_14_tfagenciabanconome_sel ,
                                              AV72Agenciawwds_13_tfagenciabanconome ,
                                              AV74Agenciawwds_15_tfagencianumero ,
                                              AV75Agenciawwds_16_tfagencianumero_to ,
                                              AV76Agenciawwds_17_tfagenciadigito ,
                                              AV77Agenciawwds_18_tfagenciadigito_to ,
                                              AV78Agenciawwds_19_tfagenciastatus_sel ,
                                              AV79Agenciawwds_20_tfagenciacreatedat ,
                                              AV80Agenciawwds_21_tfagenciacreatedat_to ,
                                              AV81Agenciawwds_22_tfagenciaupdatedat ,
                                              AV82Agenciawwds_23_tfagenciaupdatedat_to ,
                                              AV16BancoId ,
                                              A969AgenciaBancoNome ,
                                              A939AgenciaNumero ,
                                              A945AgenciaDigito ,
                                              A940AgenciaStatus ,
                                              A941AgenciaCreatedAt ,
                                              A942AgenciaUpdatedAt ,
                                              A968AgenciaBancoId ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV60Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Agenciawwds_1_filterfulltext), "%", "");
         lV60Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Agenciawwds_1_filterfulltext), "%", "");
         lV60Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Agenciawwds_1_filterfulltext), "%", "");
         lV60Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Agenciawwds_1_filterfulltext), "%", "");
         lV60Agenciawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Agenciawwds_1_filterfulltext), "%", "");
         lV72Agenciawwds_13_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV72Agenciawwds_13_tfagenciabanconome), "%", "");
         /* Using cursor P00EJ2 */
         pr_default.execute(0, new Object[] {lV60Agenciawwds_1_filterfulltext, lV60Agenciawwds_1_filterfulltext, lV60Agenciawwds_1_filterfulltext, lV60Agenciawwds_1_filterfulltext, lV60Agenciawwds_1_filterfulltext, AV63Agenciawwds_4_agencianumero1, AV63Agenciawwds_4_agencianumero1, AV63Agenciawwds_4_agencianumero1, AV67Agenciawwds_8_agencianumero2, AV67Agenciawwds_8_agencianumero2, AV67Agenciawwds_8_agencianumero2, AV71Agenciawwds_12_agencianumero3, AV71Agenciawwds_12_agencianumero3, AV71Agenciawwds_12_agencianumero3, lV72Agenciawwds_13_tfagenciabanconome, AV73Agenciawwds_14_tfagenciabanconome_sel, AV74Agenciawwds_15_tfagencianumero, AV75Agenciawwds_16_tfagencianumero_to, AV76Agenciawwds_17_tfagenciadigito, AV77Agenciawwds_18_tfagenciadigito_to, AV79Agenciawwds_20_tfagenciacreatedat, AV80Agenciawwds_21_tfagenciacreatedat_to, AV81Agenciawwds_22_tfagenciaupdatedat, AV82Agenciawwds_23_tfagenciaupdatedat_to, AV16BancoId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A968AgenciaBancoId = P00EJ2_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EJ2_n968AgenciaBancoId[0];
            A942AgenciaUpdatedAt = P00EJ2_A942AgenciaUpdatedAt[0];
            n942AgenciaUpdatedAt = P00EJ2_n942AgenciaUpdatedAt[0];
            A941AgenciaCreatedAt = P00EJ2_A941AgenciaCreatedAt[0];
            n941AgenciaCreatedAt = P00EJ2_n941AgenciaCreatedAt[0];
            A945AgenciaDigito = P00EJ2_A945AgenciaDigito[0];
            n945AgenciaDigito = P00EJ2_n945AgenciaDigito[0];
            A969AgenciaBancoNome = P00EJ2_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EJ2_n969AgenciaBancoNome[0];
            A939AgenciaNumero = P00EJ2_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EJ2_n939AgenciaNumero[0];
            A940AgenciaStatus = P00EJ2_A940AgenciaStatus[0];
            n940AgenciaStatus = P00EJ2_n940AgenciaStatus[0];
            A938AgenciaId = P00EJ2_A938AgenciaId[0];
            A969AgenciaBancoNome = P00EJ2_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EJ2_n969AgenciaBancoNome[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A969AgenciaBancoNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = A939AgenciaNumero;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = A945AgenciaDigito;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A940AgenciaStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A940AgenciaStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Inativo";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A940AgenciaStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A940AgenciaStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Date = A941AgenciaCreatedAt;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Date = A942AgenciaUpdatedAt;
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
         AV38Session.Set("WWPExportFilePath", AV11Filename);
         AV38Session.Set("WWPExportFileName", "AgenciaWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV38Session.Get("AgenciaWWGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "AgenciaWWGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("AgenciaWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV40GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV40GridState.gxTpr_Ordereddsc;
         AV83GXV1 = 1;
         while ( AV83GXV1 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV83GXV1));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME") == 0 )
            {
               AV57TFAgenciaBancoNome = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME_SEL") == 0 )
            {
               AV58TFAgenciaBancoNome_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFAGENCIANUMERO") == 0 )
            {
               AV44TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV45TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFAGENCIADIGITO") == 0 )
            {
               AV46TFAgenciaDigito = (int)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV47TFAgenciaDigito_To = (int)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFAGENCIASTATUS_SEL") == 0 )
            {
               AV48TFAgenciaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFAGENCIACREATEDAT") == 0 )
            {
               AV51TFAgenciaCreatedAt = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, 4);
               AV52TFAgenciaCreatedAt_To = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFAGENCIAUPDATEDAT") == 0 )
            {
               AV55TFAgenciaUpdatedAt = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, 4);
               AV56TFAgenciaUpdatedAt_To = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "PARM_&BANCOID") == 0 )
            {
               AV16BancoId = (int)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV83GXV1 = (int)(AV83GXV1+1);
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
         AV19FilterFullText = "";
         AV40GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV26DynamicFiltersSelector2 = "";
         AV32DynamicFiltersSelector3 = "";
         AV58TFAgenciaBancoNome_Sel = "";
         AV57TFAgenciaBancoNome = "";
         AV51TFAgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         AV52TFAgenciaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV55TFAgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
         AV56TFAgenciaUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV60Agenciawwds_1_filterfulltext = "";
         AV61Agenciawwds_2_dynamicfiltersselector1 = "";
         AV65Agenciawwds_6_dynamicfiltersselector2 = "";
         AV69Agenciawwds_10_dynamicfiltersselector3 = "";
         AV72Agenciawwds_13_tfagenciabanconome = "";
         AV73Agenciawwds_14_tfagenciabanconome_sel = "";
         AV79Agenciawwds_20_tfagenciacreatedat = (DateTime)(DateTime.MinValue);
         AV80Agenciawwds_21_tfagenciacreatedat_to = (DateTime)(DateTime.MinValue);
         AV81Agenciawwds_22_tfagenciaupdatedat = (DateTime)(DateTime.MinValue);
         AV82Agenciawwds_23_tfagenciaupdatedat_to = (DateTime)(DateTime.MinValue);
         lV60Agenciawwds_1_filterfulltext = "";
         lV72Agenciawwds_13_tfagenciabanconome = "";
         A969AgenciaBancoNome = "";
         A941AgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         A942AgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
         P00EJ2_A968AgenciaBancoId = new int[1] ;
         P00EJ2_n968AgenciaBancoId = new bool[] {false} ;
         P00EJ2_A942AgenciaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EJ2_n942AgenciaUpdatedAt = new bool[] {false} ;
         P00EJ2_A941AgenciaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EJ2_n941AgenciaCreatedAt = new bool[] {false} ;
         P00EJ2_A945AgenciaDigito = new int[1] ;
         P00EJ2_n945AgenciaDigito = new bool[] {false} ;
         P00EJ2_A969AgenciaBancoNome = new string[] {""} ;
         P00EJ2_n969AgenciaBancoNome = new bool[] {false} ;
         P00EJ2_A939AgenciaNumero = new int[1] ;
         P00EJ2_n939AgenciaNumero = new bool[] {false} ;
         P00EJ2_A940AgenciaStatus = new bool[] {false} ;
         P00EJ2_n940AgenciaStatus = new bool[] {false} ;
         P00EJ2_A938AgenciaId = new int[1] ;
         GXt_char1 = "";
         AV38Session = context.GetSession();
         AV41GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.agenciawwexport__default(),
            new Object[][] {
                new Object[] {
               P00EJ2_A968AgenciaBancoId, P00EJ2_n968AgenciaBancoId, P00EJ2_A942AgenciaUpdatedAt, P00EJ2_n942AgenciaUpdatedAt, P00EJ2_A941AgenciaCreatedAt, P00EJ2_n941AgenciaCreatedAt, P00EJ2_A945AgenciaDigito, P00EJ2_n945AgenciaDigito, P00EJ2_A969AgenciaBancoNome, P00EJ2_n969AgenciaBancoNome,
               P00EJ2_A939AgenciaNumero, P00EJ2_n939AgenciaNumero, P00EJ2_A940AgenciaStatus, P00EJ2_n940AgenciaStatus, P00EJ2_A938AgenciaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV27DynamicFiltersOperator2 ;
      private short AV33DynamicFiltersOperator3 ;
      private short AV48TFAgenciaStatus_Sel ;
      private short GXt_int2 ;
      private short AV62Agenciawwds_3_dynamicfiltersoperator1 ;
      private short AV66Agenciawwds_7_dynamicfiltersoperator2 ;
      private short AV70Agenciawwds_11_dynamicfiltersoperator3 ;
      private short AV78Agenciawwds_19_tfagenciastatus_sel ;
      private short AV17OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV22AgenciaNumero1 ;
      private int AV28AgenciaNumero2 ;
      private int AV34AgenciaNumero3 ;
      private int AV44TFAgenciaNumero ;
      private int AV45TFAgenciaNumero_To ;
      private int AV46TFAgenciaDigito ;
      private int AV47TFAgenciaDigito_To ;
      private int AV63Agenciawwds_4_agencianumero1 ;
      private int AV67Agenciawwds_8_agencianumero2 ;
      private int AV71Agenciawwds_12_agencianumero3 ;
      private int AV74Agenciawwds_15_tfagencianumero ;
      private int AV75Agenciawwds_16_tfagencianumero_to ;
      private int AV76Agenciawwds_17_tfagenciadigito ;
      private int AV77Agenciawwds_18_tfagenciadigito_to ;
      private int AV16BancoId ;
      private int A939AgenciaNumero ;
      private int A945AgenciaDigito ;
      private int A968AgenciaBancoId ;
      private int A938AgenciaId ;
      private int AV83GXV1 ;
      private string GXt_char1 ;
      private DateTime AV51TFAgenciaCreatedAt ;
      private DateTime AV52TFAgenciaCreatedAt_To ;
      private DateTime AV55TFAgenciaUpdatedAt ;
      private DateTime AV56TFAgenciaUpdatedAt_To ;
      private DateTime AV79Agenciawwds_20_tfagenciacreatedat ;
      private DateTime AV80Agenciawwds_21_tfagenciacreatedat_to ;
      private DateTime AV81Agenciawwds_22_tfagenciaupdatedat ;
      private DateTime AV82Agenciawwds_23_tfagenciaupdatedat_to ;
      private DateTime A941AgenciaCreatedAt ;
      private DateTime A942AgenciaUpdatedAt ;
      private bool returnInSub ;
      private bool AV25DynamicFiltersEnabled2 ;
      private bool AV31DynamicFiltersEnabled3 ;
      private bool AV64Agenciawwds_5_dynamicfiltersenabled2 ;
      private bool AV68Agenciawwds_9_dynamicfiltersenabled3 ;
      private bool A940AgenciaStatus ;
      private bool AV18OrderedDsc ;
      private bool n968AgenciaBancoId ;
      private bool n942AgenciaUpdatedAt ;
      private bool n941AgenciaCreatedAt ;
      private bool n945AgenciaDigito ;
      private bool n969AgenciaBancoNome ;
      private bool n939AgenciaNumero ;
      private bool n940AgenciaStatus ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV26DynamicFiltersSelector2 ;
      private string AV32DynamicFiltersSelector3 ;
      private string AV58TFAgenciaBancoNome_Sel ;
      private string AV57TFAgenciaBancoNome ;
      private string AV60Agenciawwds_1_filterfulltext ;
      private string AV61Agenciawwds_2_dynamicfiltersselector1 ;
      private string AV65Agenciawwds_6_dynamicfiltersselector2 ;
      private string AV69Agenciawwds_10_dynamicfiltersselector3 ;
      private string AV72Agenciawwds_13_tfagenciabanconome ;
      private string AV73Agenciawwds_14_tfagenciabanconome_sel ;
      private string lV60Agenciawwds_1_filterfulltext ;
      private string lV72Agenciawwds_13_tfagenciabanconome ;
      private string A969AgenciaBancoNome ;
      private IGxSession AV38Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV37GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private int[] P00EJ2_A968AgenciaBancoId ;
      private bool[] P00EJ2_n968AgenciaBancoId ;
      private DateTime[] P00EJ2_A942AgenciaUpdatedAt ;
      private bool[] P00EJ2_n942AgenciaUpdatedAt ;
      private DateTime[] P00EJ2_A941AgenciaCreatedAt ;
      private bool[] P00EJ2_n941AgenciaCreatedAt ;
      private int[] P00EJ2_A945AgenciaDigito ;
      private bool[] P00EJ2_n945AgenciaDigito ;
      private string[] P00EJ2_A969AgenciaBancoNome ;
      private bool[] P00EJ2_n969AgenciaBancoNome ;
      private int[] P00EJ2_A939AgenciaNumero ;
      private bool[] P00EJ2_n939AgenciaNumero ;
      private bool[] P00EJ2_A940AgenciaStatus ;
      private bool[] P00EJ2_n940AgenciaStatus ;
      private int[] P00EJ2_A938AgenciaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class agenciawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EJ2( IGxContext context ,
                                             string AV60Agenciawwds_1_filterfulltext ,
                                             string AV61Agenciawwds_2_dynamicfiltersselector1 ,
                                             short AV62Agenciawwds_3_dynamicfiltersoperator1 ,
                                             int AV63Agenciawwds_4_agencianumero1 ,
                                             bool AV64Agenciawwds_5_dynamicfiltersenabled2 ,
                                             string AV65Agenciawwds_6_dynamicfiltersselector2 ,
                                             short AV66Agenciawwds_7_dynamicfiltersoperator2 ,
                                             int AV67Agenciawwds_8_agencianumero2 ,
                                             bool AV68Agenciawwds_9_dynamicfiltersenabled3 ,
                                             string AV69Agenciawwds_10_dynamicfiltersselector3 ,
                                             short AV70Agenciawwds_11_dynamicfiltersoperator3 ,
                                             int AV71Agenciawwds_12_agencianumero3 ,
                                             string AV73Agenciawwds_14_tfagenciabanconome_sel ,
                                             string AV72Agenciawwds_13_tfagenciabanconome ,
                                             int AV74Agenciawwds_15_tfagencianumero ,
                                             int AV75Agenciawwds_16_tfagencianumero_to ,
                                             int AV76Agenciawwds_17_tfagenciadigito ,
                                             int AV77Agenciawwds_18_tfagenciadigito_to ,
                                             short AV78Agenciawwds_19_tfagenciastatus_sel ,
                                             DateTime AV79Agenciawwds_20_tfagenciacreatedat ,
                                             DateTime AV80Agenciawwds_21_tfagenciacreatedat_to ,
                                             DateTime AV81Agenciawwds_22_tfagenciaupdatedat ,
                                             DateTime AV82Agenciawwds_23_tfagenciaupdatedat_to ,
                                             int AV16BancoId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             int A945AgenciaDigito ,
                                             bool A940AgenciaStatus ,
                                             DateTime A941AgenciaCreatedAt ,
                                             DateTime A942AgenciaUpdatedAt ,
                                             int A968AgenciaBancoId ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[25];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.AgenciaBancoId AS AgenciaBancoId, T1.AgenciaUpdatedAt, T1.AgenciaCreatedAt, T1.AgenciaDigito, T2.BancoNome AS AgenciaBancoNome, T1.AgenciaNumero, T1.AgenciaStatus, T1.AgenciaId FROM (Agencia T1 LEFT JOIN Banco T2 ON T2.BancoId = T1.AgenciaBancoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Agenciawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T2.BancoNome) like '%' || LOWER(:lV60Agenciawwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T1.AgenciaNumero,'999999999'), 2) like '%' || :lV60Agenciawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.AgenciaDigito,'999999999'), 2) like '%' || :lV60Agenciawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV60Agenciawwds_1_filterfulltext) and T1.AgenciaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV60Agenciawwds_1_filterfulltext) and T1.AgenciaStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Agenciawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV62Agenciawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV63Agenciawwds_4_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero < :AV63Agenciawwds_4_agencianumero1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Agenciawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV62Agenciawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV63Agenciawwds_4_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero = :AV63Agenciawwds_4_agencianumero1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Agenciawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV62Agenciawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV63Agenciawwds_4_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero > :AV63Agenciawwds_4_agencianumero1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV64Agenciawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Agenciawwds_6_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV66Agenciawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV67Agenciawwds_8_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero < :AV67Agenciawwds_8_agencianumero2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV64Agenciawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Agenciawwds_6_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV66Agenciawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV67Agenciawwds_8_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero = :AV67Agenciawwds_8_agencianumero2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV64Agenciawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Agenciawwds_6_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV66Agenciawwds_7_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV67Agenciawwds_8_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero > :AV67Agenciawwds_8_agencianumero2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV68Agenciawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Agenciawwds_10_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV70Agenciawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV71Agenciawwds_12_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero < :AV71Agenciawwds_12_agencianumero3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV68Agenciawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Agenciawwds_10_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV70Agenciawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV71Agenciawwds_12_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero = :AV71Agenciawwds_12_agencianumero3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV68Agenciawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Agenciawwds_10_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV70Agenciawwds_11_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV71Agenciawwds_12_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero > :AV71Agenciawwds_12_agencianumero3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Agenciawwds_14_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Agenciawwds_13_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T2.BancoNome like :lV72Agenciawwds_13_tfagenciabanconome)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Agenciawwds_14_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV73Agenciawwds_14_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.BancoNome = ( :AV73Agenciawwds_14_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV73Agenciawwds_14_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.BancoNome IS NULL or (char_length(trim(trailing ' ' from T2.BancoNome))=0))");
         }
         if ( ! (0==AV74Agenciawwds_15_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero >= :AV74Agenciawwds_15_tfagencianumero)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! (0==AV75Agenciawwds_16_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaNumero <= :AV75Agenciawwds_16_tfagencianumero_to)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (0==AV76Agenciawwds_17_tfagenciadigito) )
         {
            AddWhere(sWhereString, "(T1.AgenciaDigito >= :AV76Agenciawwds_17_tfagenciadigito)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! (0==AV77Agenciawwds_18_tfagenciadigito_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaDigito <= :AV77Agenciawwds_18_tfagenciadigito_to)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV78Agenciawwds_19_tfagenciastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.AgenciaStatus = TRUE)");
         }
         if ( AV78Agenciawwds_19_tfagenciastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.AgenciaStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV79Agenciawwds_20_tfagenciacreatedat) )
         {
            AddWhere(sWhereString, "(T1.AgenciaCreatedAt >= :AV79Agenciawwds_20_tfagenciacreatedat)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Agenciawwds_21_tfagenciacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaCreatedAt <= :AV80Agenciawwds_21_tfagenciacreatedat_to)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Agenciawwds_22_tfagenciaupdatedat) )
         {
            AddWhere(sWhereString, "(T1.AgenciaUpdatedAt >= :AV81Agenciawwds_22_tfagenciaupdatedat)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Agenciawwds_23_tfagenciaupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.AgenciaUpdatedAt <= :AV82Agenciawwds_23_tfagenciaupdatedat_to)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! (0==AV16BancoId) )
         {
            AddWhere(sWhereString, "(T1.AgenciaBancoId = :AV16BancoId)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AgenciaNumero";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AgenciaNumero DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.BancoNome";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.BancoNome DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AgenciaDigito";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AgenciaDigito DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AgenciaStatus";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AgenciaStatus DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AgenciaCreatedAt";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AgenciaCreatedAt DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AgenciaUpdatedAt";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AgenciaUpdatedAt DESC";
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
                     return conditional_P00EJ2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (int)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (int)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (short)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (bool)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (int)dynConstraints[30] , (short)dynConstraints[31] , (bool)dynConstraints[32] );
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
          Object[] prmP00EJ2;
          prmP00EJ2 = new Object[] {
          new ParDef("lV60Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Agenciawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV63Agenciawwds_4_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV63Agenciawwds_4_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV63Agenciawwds_4_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV67Agenciawwds_8_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV67Agenciawwds_8_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV67Agenciawwds_8_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV71Agenciawwds_12_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV71Agenciawwds_12_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV71Agenciawwds_12_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("lV72Agenciawwds_13_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV73Agenciawwds_14_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV74Agenciawwds_15_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV75Agenciawwds_16_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV76Agenciawwds_17_tfagenciadigito",GXType.Int32,9,0) ,
          new ParDef("AV77Agenciawwds_18_tfagenciadigito_to",GXType.Int32,9,0) ,
          new ParDef("AV79Agenciawwds_20_tfagenciacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV80Agenciawwds_21_tfagenciacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV81Agenciawwds_22_tfagenciaupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV82Agenciawwds_23_tfagenciaupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV16BancoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EJ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EJ2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((bool[]) buf[12])[0] = rslt.getBool(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                return;
       }
    }

 }

}
