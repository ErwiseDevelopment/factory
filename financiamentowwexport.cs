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
   public class financiamentowwexport : GXProcedure
   {
      public financiamentowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public financiamentowwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "FinanciamentoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV36GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "FINANCIAMENTOVALOR") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV21FinanciamentoValor1 = NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, ".");
               if ( ! (Convert.ToDecimal(0)==AV21FinanciamentoValor1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV21FinanciamentoValor1);
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CLIENTEDOCUMENTO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV22ClienteDocumento1 = AV36GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ClienteDocumento1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ClienteDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV23IntermediadorClienteDocumento1 = AV36GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23IntermediadorClienteDocumento1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23IntermediadorClienteDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV24DynamicFiltersEnabled2 = true;
               AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV36GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "FINANCIAMENTOVALOR") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV27FinanciamentoValor2 = NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, ".");
                  if ( ! (Convert.ToDecimal(0)==AV27FinanciamentoValor2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV27FinanciamentoValor2);
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CLIENTEDOCUMENTO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV28ClienteDocumento2 = AV36GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ClienteDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ClienteDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV29IntermediadorClienteDocumento2 = AV36GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29IntermediadorClienteDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV26DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV26DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29IntermediadorClienteDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV30DynamicFiltersEnabled3 = true;
                  AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(3));
                  AV31DynamicFiltersSelector3 = AV36GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "FINANCIAMENTOVALOR") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV33FinanciamentoValor3 = NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, ".");
                     if ( ! (Convert.ToDecimal(0)==AV33FinanciamentoValor3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Valor", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV33FinanciamentoValor3);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "CLIENTEDOCUMENTO") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV34ClienteDocumento3 = AV36GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34ClienteDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34ClienteDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV31DynamicFiltersSelector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 )
                  {
                     AV32DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV35IntermediadorClienteDocumento3 = AV36GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35IntermediadorClienteDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV32DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV32DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cliente Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35IntermediadorClienteDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFClienteRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cliente") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV42TFClienteRazaoSocial_Sel)) ? "(Vazio)" : AV42TFClienteRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFClienteRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cliente") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFClienteRazaoSocial, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFClienteDocumento_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cliente CPF") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV44TFClienteDocumento_Sel)) ? "(Vazio)" : AV44TFClienteDocumento_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFClienteDocumento)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cliente CPF") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFClienteDocumento, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV45TFFinanciamentoValor) && (Convert.ToDecimal(0)==AV46TFFinanciamentoValor_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Valor") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV45TFFinanciamentoValor);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV46TFFinanciamentoValor_To);
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFIntermediadorClienteRazaoSocial_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Intermediador") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFIntermediadorClienteRazaoSocial_Sel)) ? "(Vazio)" : AV48TFIntermediadorClienteRazaoSocial_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFIntermediadorClienteRazaoSocial)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Intermediador") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFIntermediadorClienteRazaoSocial, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFIntermediadorClienteDocumento_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Intermediador CPF") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFIntermediadorClienteDocumento_Sel)) ? "(Vazio)" : AV50TFIntermediadorClienteDocumento_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFIntermediadorClienteDocumento)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Intermediador CPF") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFIntermediadorClienteDocumento, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Cliente";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Cliente CPF";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Valor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Intermediador";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Intermediador CPF";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV52Financiamentowwds_1_filterfulltext = AV18FilterFullText;
         AV53Financiamentowwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV54Financiamentowwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV55Financiamentowwds_4_financiamentovalor1 = AV21FinanciamentoValor1;
         AV56Financiamentowwds_5_clientedocumento1 = AV22ClienteDocumento1;
         AV57Financiamentowwds_6_intermediadorclientedocumento1 = AV23IntermediadorClienteDocumento1;
         AV58Financiamentowwds_7_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV59Financiamentowwds_8_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV60Financiamentowwds_9_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV61Financiamentowwds_10_financiamentovalor2 = AV27FinanciamentoValor2;
         AV62Financiamentowwds_11_clientedocumento2 = AV28ClienteDocumento2;
         AV63Financiamentowwds_12_intermediadorclientedocumento2 = AV29IntermediadorClienteDocumento2;
         AV64Financiamentowwds_13_dynamicfiltersenabled3 = AV30DynamicFiltersEnabled3;
         AV65Financiamentowwds_14_dynamicfiltersselector3 = AV31DynamicFiltersSelector3;
         AV66Financiamentowwds_15_dynamicfiltersoperator3 = AV32DynamicFiltersOperator3;
         AV67Financiamentowwds_16_financiamentovalor3 = AV33FinanciamentoValor3;
         AV68Financiamentowwds_17_clientedocumento3 = AV34ClienteDocumento3;
         AV69Financiamentowwds_18_intermediadorclientedocumento3 = AV35IntermediadorClienteDocumento3;
         AV70Financiamentowwds_19_tfclienterazaosocial = AV41TFClienteRazaoSocial;
         AV71Financiamentowwds_20_tfclienterazaosocial_sel = AV42TFClienteRazaoSocial_Sel;
         AV72Financiamentowwds_21_tfclientedocumento = AV43TFClienteDocumento;
         AV73Financiamentowwds_22_tfclientedocumento_sel = AV44TFClienteDocumento_Sel;
         AV74Financiamentowwds_23_tffinanciamentovalor = AV45TFFinanciamentoValor;
         AV75Financiamentowwds_24_tffinanciamentovalor_to = AV46TFFinanciamentoValor_To;
         AV76Financiamentowwds_25_tfintermediadorclienterazaosocial = AV47TFIntermediadorClienteRazaoSocial;
         AV77Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = AV48TFIntermediadorClienteRazaoSocial_Sel;
         AV78Financiamentowwds_27_tfintermediadorclientedocumento = AV49TFIntermediadorClienteDocumento;
         AV79Financiamentowwds_28_tfintermediadorclientedocumento_sel = AV50TFIntermediadorClienteDocumento_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV52Financiamentowwds_1_filterfulltext ,
                                              AV53Financiamentowwds_2_dynamicfiltersselector1 ,
                                              AV54Financiamentowwds_3_dynamicfiltersoperator1 ,
                                              AV55Financiamentowwds_4_financiamentovalor1 ,
                                              AV56Financiamentowwds_5_clientedocumento1 ,
                                              AV57Financiamentowwds_6_intermediadorclientedocumento1 ,
                                              AV58Financiamentowwds_7_dynamicfiltersenabled2 ,
                                              AV59Financiamentowwds_8_dynamicfiltersselector2 ,
                                              AV60Financiamentowwds_9_dynamicfiltersoperator2 ,
                                              AV61Financiamentowwds_10_financiamentovalor2 ,
                                              AV62Financiamentowwds_11_clientedocumento2 ,
                                              AV63Financiamentowwds_12_intermediadorclientedocumento2 ,
                                              AV64Financiamentowwds_13_dynamicfiltersenabled3 ,
                                              AV65Financiamentowwds_14_dynamicfiltersselector3 ,
                                              AV66Financiamentowwds_15_dynamicfiltersoperator3 ,
                                              AV67Financiamentowwds_16_financiamentovalor3 ,
                                              AV68Financiamentowwds_17_clientedocumento3 ,
                                              AV69Financiamentowwds_18_intermediadorclientedocumento3 ,
                                              AV71Financiamentowwds_20_tfclienterazaosocial_sel ,
                                              AV70Financiamentowwds_19_tfclienterazaosocial ,
                                              AV73Financiamentowwds_22_tfclientedocumento_sel ,
                                              AV72Financiamentowwds_21_tfclientedocumento ,
                                              AV74Financiamentowwds_23_tffinanciamentovalor ,
                                              AV75Financiamentowwds_24_tffinanciamentovalor_to ,
                                              AV77Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                              AV76Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                              AV79Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                              AV78Financiamentowwds_27_tfintermediadorclientedocumento ,
                                              A170ClienteRazaoSocial ,
                                              A169ClienteDocumento ,
                                              A224FinanciamentoValor ,
                                              A221IntermediadorClienteRazaoSocial ,
                                              A222IntermediadorClienteDocumento ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Financiamentowwds_1_filterfulltext), "%", "");
         lV52Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Financiamentowwds_1_filterfulltext), "%", "");
         lV52Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Financiamentowwds_1_filterfulltext), "%", "");
         lV52Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Financiamentowwds_1_filterfulltext), "%", "");
         lV52Financiamentowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Financiamentowwds_1_filterfulltext), "%", "");
         lV56Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV56Financiamentowwds_5_clientedocumento1), "%", "");
         lV56Financiamentowwds_5_clientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV56Financiamentowwds_5_clientedocumento1), "%", "");
         lV57Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV57Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
         lV57Financiamentowwds_6_intermediadorclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV57Financiamentowwds_6_intermediadorclientedocumento1), "%", "");
         lV62Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_11_clientedocumento2), "%", "");
         lV62Financiamentowwds_11_clientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV62Financiamentowwds_11_clientedocumento2), "%", "");
         lV63Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV63Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
         lV63Financiamentowwds_12_intermediadorclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV63Financiamentowwds_12_intermediadorclientedocumento2), "%", "");
         lV68Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV68Financiamentowwds_17_clientedocumento3), "%", "");
         lV68Financiamentowwds_17_clientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV68Financiamentowwds_17_clientedocumento3), "%", "");
         lV69Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV69Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
         lV69Financiamentowwds_18_intermediadorclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV69Financiamentowwds_18_intermediadorclientedocumento3), "%", "");
         lV70Financiamentowwds_19_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV70Financiamentowwds_19_tfclienterazaosocial), "%", "");
         lV72Financiamentowwds_21_tfclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV72Financiamentowwds_21_tfclientedocumento), "%", "");
         lV76Financiamentowwds_25_tfintermediadorclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV76Financiamentowwds_25_tfintermediadorclienterazaosocial), "%", "");
         lV78Financiamentowwds_27_tfintermediadorclientedocumento = StringUtil.Concat( StringUtil.RTrim( AV78Financiamentowwds_27_tfintermediadorclientedocumento), "%", "");
         /* Using cursor P00752 */
         pr_default.execute(0, new Object[] {lV52Financiamentowwds_1_filterfulltext, lV52Financiamentowwds_1_filterfulltext, lV52Financiamentowwds_1_filterfulltext, lV52Financiamentowwds_1_filterfulltext, lV52Financiamentowwds_1_filterfulltext, AV55Financiamentowwds_4_financiamentovalor1, AV55Financiamentowwds_4_financiamentovalor1, AV55Financiamentowwds_4_financiamentovalor1, lV56Financiamentowwds_5_clientedocumento1, lV56Financiamentowwds_5_clientedocumento1, lV57Financiamentowwds_6_intermediadorclientedocumento1, lV57Financiamentowwds_6_intermediadorclientedocumento1, AV61Financiamentowwds_10_financiamentovalor2, AV61Financiamentowwds_10_financiamentovalor2, AV61Financiamentowwds_10_financiamentovalor2, lV62Financiamentowwds_11_clientedocumento2, lV62Financiamentowwds_11_clientedocumento2, lV63Financiamentowwds_12_intermediadorclientedocumento2, lV63Financiamentowwds_12_intermediadorclientedocumento2, AV67Financiamentowwds_16_financiamentovalor3, AV67Financiamentowwds_16_financiamentovalor3, AV67Financiamentowwds_16_financiamentovalor3, lV68Financiamentowwds_17_clientedocumento3, lV68Financiamentowwds_17_clientedocumento3, lV69Financiamentowwds_18_intermediadorclientedocumento3, lV69Financiamentowwds_18_intermediadorclientedocumento3, lV70Financiamentowwds_19_tfclienterazaosocial, AV71Financiamentowwds_20_tfclienterazaosocial_sel, lV72Financiamentowwds_21_tfclientedocumento, AV73Financiamentowwds_22_tfclientedocumento_sel, AV74Financiamentowwds_23_tffinanciamentovalor, AV75Financiamentowwds_24_tffinanciamentovalor_to, lV76Financiamentowwds_25_tfintermediadorclienterazaosocial, AV77Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, lV78Financiamentowwds_27_tfintermediadorclientedocumento, AV79Financiamentowwds_28_tfintermediadorclientedocumento_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A168ClienteId = P00752_A168ClienteId[0];
            n168ClienteId = P00752_n168ClienteId[0];
            A220IntermediadorClienteId = P00752_A220IntermediadorClienteId[0];
            n220IntermediadorClienteId = P00752_n220IntermediadorClienteId[0];
            A224FinanciamentoValor = P00752_A224FinanciamentoValor[0];
            n224FinanciamentoValor = P00752_n224FinanciamentoValor[0];
            A222IntermediadorClienteDocumento = P00752_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = P00752_n222IntermediadorClienteDocumento[0];
            A221IntermediadorClienteRazaoSocial = P00752_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = P00752_n221IntermediadorClienteRazaoSocial[0];
            A169ClienteDocumento = P00752_A169ClienteDocumento[0];
            n169ClienteDocumento = P00752_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = P00752_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00752_n170ClienteRazaoSocial[0];
            A223FinanciamentoId = P00752_A223FinanciamentoId[0];
            A169ClienteDocumento = P00752_A169ClienteDocumento[0];
            n169ClienteDocumento = P00752_n169ClienteDocumento[0];
            A170ClienteRazaoSocial = P00752_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00752_n170ClienteRazaoSocial[0];
            A222IntermediadorClienteDocumento = P00752_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = P00752_n222IntermediadorClienteDocumento[0];
            A221IntermediadorClienteRazaoSocial = P00752_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = P00752_n221IntermediadorClienteRazaoSocial[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A170ClienteRazaoSocial, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A169ClienteDocumento, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = (double)(A224FinanciamentoValor);
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A221IntermediadorClienteRazaoSocial, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A222IntermediadorClienteDocumento, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char1;
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
         AV37Session.Set("WWPExportFilePath", AV11Filename);
         AV37Session.Set("WWPExportFileName", "FinanciamentoWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV37Session.Get("FinanciamentoWWGridState"), "") == 0 )
         {
            AV39GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "FinanciamentoWWGridState"), null, "", "");
         }
         else
         {
            AV39GridState.FromXml(AV37Session.Get("FinanciamentoWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV39GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV39GridState.gxTpr_Ordereddsc;
         AV80GXV1 = 1;
         while ( AV80GXV1 <= AV39GridState.gxTpr_Filtervalues.Count )
         {
            AV40GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV39GridState.gxTpr_Filtervalues.Item(AV80GXV1));
            if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV41TFClienteRazaoSocial = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV42TFClienteRazaoSocial_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV43TFClienteDocumento = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV44TFClienteDocumento_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFFINANCIAMENTOVALOR") == 0 )
            {
               AV45TFFinanciamentoValor = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, ".");
               AV46TFFinanciamentoValor_To = NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTERAZAOSOCIAL") == 0 )
            {
               AV47TFIntermediadorClienteRazaoSocial = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV48TFIntermediadorClienteRazaoSocial_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTEDOCUMENTO") == 0 )
            {
               AV49TFIntermediadorClienteDocumento = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFINTERMEDIADORCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV50TFIntermediadorClienteDocumento_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            AV80GXV1 = (int)(AV80GXV1+1);
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
         AV39GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV36GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV22ClienteDocumento1 = "";
         AV23IntermediadorClienteDocumento1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV28ClienteDocumento2 = "";
         AV29IntermediadorClienteDocumento2 = "";
         AV31DynamicFiltersSelector3 = "";
         AV34ClienteDocumento3 = "";
         AV35IntermediadorClienteDocumento3 = "";
         AV42TFClienteRazaoSocial_Sel = "";
         AV41TFClienteRazaoSocial = "";
         AV44TFClienteDocumento_Sel = "";
         AV43TFClienteDocumento = "";
         AV48TFIntermediadorClienteRazaoSocial_Sel = "";
         AV47TFIntermediadorClienteRazaoSocial = "";
         AV50TFIntermediadorClienteDocumento_Sel = "";
         AV49TFIntermediadorClienteDocumento = "";
         AV52Financiamentowwds_1_filterfulltext = "";
         AV53Financiamentowwds_2_dynamicfiltersselector1 = "";
         AV56Financiamentowwds_5_clientedocumento1 = "";
         AV57Financiamentowwds_6_intermediadorclientedocumento1 = "";
         AV59Financiamentowwds_8_dynamicfiltersselector2 = "";
         AV62Financiamentowwds_11_clientedocumento2 = "";
         AV63Financiamentowwds_12_intermediadorclientedocumento2 = "";
         AV65Financiamentowwds_14_dynamicfiltersselector3 = "";
         AV68Financiamentowwds_17_clientedocumento3 = "";
         AV69Financiamentowwds_18_intermediadorclientedocumento3 = "";
         AV70Financiamentowwds_19_tfclienterazaosocial = "";
         AV71Financiamentowwds_20_tfclienterazaosocial_sel = "";
         AV72Financiamentowwds_21_tfclientedocumento = "";
         AV73Financiamentowwds_22_tfclientedocumento_sel = "";
         AV76Financiamentowwds_25_tfintermediadorclienterazaosocial = "";
         AV77Financiamentowwds_26_tfintermediadorclienterazaosocial_sel = "";
         AV78Financiamentowwds_27_tfintermediadorclientedocumento = "";
         AV79Financiamentowwds_28_tfintermediadorclientedocumento_sel = "";
         lV52Financiamentowwds_1_filterfulltext = "";
         lV56Financiamentowwds_5_clientedocumento1 = "";
         lV57Financiamentowwds_6_intermediadorclientedocumento1 = "";
         lV62Financiamentowwds_11_clientedocumento2 = "";
         lV63Financiamentowwds_12_intermediadorclientedocumento2 = "";
         lV68Financiamentowwds_17_clientedocumento3 = "";
         lV69Financiamentowwds_18_intermediadorclientedocumento3 = "";
         lV70Financiamentowwds_19_tfclienterazaosocial = "";
         lV72Financiamentowwds_21_tfclientedocumento = "";
         lV76Financiamentowwds_25_tfintermediadorclienterazaosocial = "";
         lV78Financiamentowwds_27_tfintermediadorclientedocumento = "";
         A170ClienteRazaoSocial = "";
         A169ClienteDocumento = "";
         A221IntermediadorClienteRazaoSocial = "";
         A222IntermediadorClienteDocumento = "";
         P00752_A168ClienteId = new int[1] ;
         P00752_n168ClienteId = new bool[] {false} ;
         P00752_A220IntermediadorClienteId = new int[1] ;
         P00752_n220IntermediadorClienteId = new bool[] {false} ;
         P00752_A224FinanciamentoValor = new decimal[1] ;
         P00752_n224FinanciamentoValor = new bool[] {false} ;
         P00752_A222IntermediadorClienteDocumento = new string[] {""} ;
         P00752_n222IntermediadorClienteDocumento = new bool[] {false} ;
         P00752_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         P00752_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         P00752_A169ClienteDocumento = new string[] {""} ;
         P00752_n169ClienteDocumento = new bool[] {false} ;
         P00752_A170ClienteRazaoSocial = new string[] {""} ;
         P00752_n170ClienteRazaoSocial = new bool[] {false} ;
         P00752_A223FinanciamentoId = new int[1] ;
         GXt_char1 = "";
         AV37Session = context.GetSession();
         AV40GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.financiamentowwexport__default(),
            new Object[][] {
                new Object[] {
               P00752_A168ClienteId, P00752_n168ClienteId, P00752_A220IntermediadorClienteId, P00752_n220IntermediadorClienteId, P00752_A224FinanciamentoValor, P00752_n224FinanciamentoValor, P00752_A222IntermediadorClienteDocumento, P00752_n222IntermediadorClienteDocumento, P00752_A221IntermediadorClienteRazaoSocial, P00752_n221IntermediadorClienteRazaoSocial,
               P00752_A169ClienteDocumento, P00752_n169ClienteDocumento, P00752_A170ClienteRazaoSocial, P00752_n170ClienteRazaoSocial, P00752_A223FinanciamentoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV32DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV54Financiamentowwds_3_dynamicfiltersoperator1 ;
      private short AV60Financiamentowwds_9_dynamicfiltersoperator2 ;
      private short AV66Financiamentowwds_15_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A168ClienteId ;
      private int A220IntermediadorClienteId ;
      private int A223FinanciamentoId ;
      private int AV80GXV1 ;
      private decimal AV21FinanciamentoValor1 ;
      private decimal AV27FinanciamentoValor2 ;
      private decimal AV33FinanciamentoValor3 ;
      private decimal AV45TFFinanciamentoValor ;
      private decimal AV46TFFinanciamentoValor_To ;
      private decimal AV55Financiamentowwds_4_financiamentovalor1 ;
      private decimal AV61Financiamentowwds_10_financiamentovalor2 ;
      private decimal AV67Financiamentowwds_16_financiamentovalor3 ;
      private decimal AV74Financiamentowwds_23_tffinanciamentovalor ;
      private decimal AV75Financiamentowwds_24_tffinanciamentovalor_to ;
      private decimal A224FinanciamentoValor ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV30DynamicFiltersEnabled3 ;
      private bool AV58Financiamentowwds_7_dynamicfiltersenabled2 ;
      private bool AV64Financiamentowwds_13_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n168ClienteId ;
      private bool n220IntermediadorClienteId ;
      private bool n224FinanciamentoValor ;
      private bool n222IntermediadorClienteDocumento ;
      private bool n221IntermediadorClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool n170ClienteRazaoSocial ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV22ClienteDocumento1 ;
      private string AV23IntermediadorClienteDocumento1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV28ClienteDocumento2 ;
      private string AV29IntermediadorClienteDocumento2 ;
      private string AV31DynamicFiltersSelector3 ;
      private string AV34ClienteDocumento3 ;
      private string AV35IntermediadorClienteDocumento3 ;
      private string AV42TFClienteRazaoSocial_Sel ;
      private string AV41TFClienteRazaoSocial ;
      private string AV44TFClienteDocumento_Sel ;
      private string AV43TFClienteDocumento ;
      private string AV48TFIntermediadorClienteRazaoSocial_Sel ;
      private string AV47TFIntermediadorClienteRazaoSocial ;
      private string AV50TFIntermediadorClienteDocumento_Sel ;
      private string AV49TFIntermediadorClienteDocumento ;
      private string AV52Financiamentowwds_1_filterfulltext ;
      private string AV53Financiamentowwds_2_dynamicfiltersselector1 ;
      private string AV56Financiamentowwds_5_clientedocumento1 ;
      private string AV57Financiamentowwds_6_intermediadorclientedocumento1 ;
      private string AV59Financiamentowwds_8_dynamicfiltersselector2 ;
      private string AV62Financiamentowwds_11_clientedocumento2 ;
      private string AV63Financiamentowwds_12_intermediadorclientedocumento2 ;
      private string AV65Financiamentowwds_14_dynamicfiltersselector3 ;
      private string AV68Financiamentowwds_17_clientedocumento3 ;
      private string AV69Financiamentowwds_18_intermediadorclientedocumento3 ;
      private string AV70Financiamentowwds_19_tfclienterazaosocial ;
      private string AV71Financiamentowwds_20_tfclienterazaosocial_sel ;
      private string AV72Financiamentowwds_21_tfclientedocumento ;
      private string AV73Financiamentowwds_22_tfclientedocumento_sel ;
      private string AV76Financiamentowwds_25_tfintermediadorclienterazaosocial ;
      private string AV77Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ;
      private string AV78Financiamentowwds_27_tfintermediadorclientedocumento ;
      private string AV79Financiamentowwds_28_tfintermediadorclientedocumento_sel ;
      private string lV52Financiamentowwds_1_filterfulltext ;
      private string lV56Financiamentowwds_5_clientedocumento1 ;
      private string lV57Financiamentowwds_6_intermediadorclientedocumento1 ;
      private string lV62Financiamentowwds_11_clientedocumento2 ;
      private string lV63Financiamentowwds_12_intermediadorclientedocumento2 ;
      private string lV68Financiamentowwds_17_clientedocumento3 ;
      private string lV69Financiamentowwds_18_intermediadorclientedocumento3 ;
      private string lV70Financiamentowwds_19_tfclienterazaosocial ;
      private string lV72Financiamentowwds_21_tfclientedocumento ;
      private string lV76Financiamentowwds_25_tfintermediadorclienterazaosocial ;
      private string lV78Financiamentowwds_27_tfintermediadorclientedocumento ;
      private string A170ClienteRazaoSocial ;
      private string A169ClienteDocumento ;
      private string A221IntermediadorClienteRazaoSocial ;
      private string A222IntermediadorClienteDocumento ;
      private IGxSession AV37Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV39GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV36GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private int[] P00752_A168ClienteId ;
      private bool[] P00752_n168ClienteId ;
      private int[] P00752_A220IntermediadorClienteId ;
      private bool[] P00752_n220IntermediadorClienteId ;
      private decimal[] P00752_A224FinanciamentoValor ;
      private bool[] P00752_n224FinanciamentoValor ;
      private string[] P00752_A222IntermediadorClienteDocumento ;
      private bool[] P00752_n222IntermediadorClienteDocumento ;
      private string[] P00752_A221IntermediadorClienteRazaoSocial ;
      private bool[] P00752_n221IntermediadorClienteRazaoSocial ;
      private string[] P00752_A169ClienteDocumento ;
      private bool[] P00752_n169ClienteDocumento ;
      private string[] P00752_A170ClienteRazaoSocial ;
      private bool[] P00752_n170ClienteRazaoSocial ;
      private int[] P00752_A223FinanciamentoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV40GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class financiamentowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00752( IGxContext context ,
                                             string AV52Financiamentowwds_1_filterfulltext ,
                                             string AV53Financiamentowwds_2_dynamicfiltersselector1 ,
                                             short AV54Financiamentowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV55Financiamentowwds_4_financiamentovalor1 ,
                                             string AV56Financiamentowwds_5_clientedocumento1 ,
                                             string AV57Financiamentowwds_6_intermediadorclientedocumento1 ,
                                             bool AV58Financiamentowwds_7_dynamicfiltersenabled2 ,
                                             string AV59Financiamentowwds_8_dynamicfiltersselector2 ,
                                             short AV60Financiamentowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV61Financiamentowwds_10_financiamentovalor2 ,
                                             string AV62Financiamentowwds_11_clientedocumento2 ,
                                             string AV63Financiamentowwds_12_intermediadorclientedocumento2 ,
                                             bool AV64Financiamentowwds_13_dynamicfiltersenabled3 ,
                                             string AV65Financiamentowwds_14_dynamicfiltersselector3 ,
                                             short AV66Financiamentowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV67Financiamentowwds_16_financiamentovalor3 ,
                                             string AV68Financiamentowwds_17_clientedocumento3 ,
                                             string AV69Financiamentowwds_18_intermediadorclientedocumento3 ,
                                             string AV71Financiamentowwds_20_tfclienterazaosocial_sel ,
                                             string AV70Financiamentowwds_19_tfclienterazaosocial ,
                                             string AV73Financiamentowwds_22_tfclientedocumento_sel ,
                                             string AV72Financiamentowwds_21_tfclientedocumento ,
                                             decimal AV74Financiamentowwds_23_tffinanciamentovalor ,
                                             decimal AV75Financiamentowwds_24_tffinanciamentovalor_to ,
                                             string AV77Financiamentowwds_26_tfintermediadorclienterazaosocial_sel ,
                                             string AV76Financiamentowwds_25_tfintermediadorclienterazaosocial ,
                                             string AV79Financiamentowwds_28_tfintermediadorclientedocumento_sel ,
                                             string AV78Financiamentowwds_27_tfintermediadorclientedocumento ,
                                             string A170ClienteRazaoSocial ,
                                             string A169ClienteDocumento ,
                                             decimal A224FinanciamentoValor ,
                                             string A221IntermediadorClienteRazaoSocial ,
                                             string A222IntermediadorClienteDocumento ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[36];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ClienteId, T1.IntermediadorClienteId AS IntermediadorClienteId, T1.FinanciamentoValor, T3.ClienteDocumento AS IntermediadorClienteDocumento, T3.ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, T2.ClienteDocumento, T2.ClienteRazaoSocial, T1.FinanciamentoId FROM ((Financiamento T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.IntermediadorClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Financiamentowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV52Financiamentowwds_1_filterfulltext) or ( T2.ClienteDocumento like '%' || :lV52Financiamentowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.FinanciamentoValor,'999999999999990.99'), 2) like '%' || :lV52Financiamentowwds_1_filterfulltext) or ( T3.ClienteRazaoSocial like '%' || :lV52Financiamentowwds_1_filterfulltext) or ( T3.ClienteDocumento like '%' || :lV52Financiamentowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV54Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV55Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV55Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV54Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV55Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV55Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Financiamentowwds_2_dynamicfiltersselector1, "FINANCIAMENTOVALOR") == 0 ) && ( AV54Financiamentowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV55Financiamentowwds_4_financiamentovalor1) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV55Financiamentowwds_4_financiamentovalor1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV54Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV56Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Financiamentowwds_2_dynamicfiltersselector1, "CLIENTEDOCUMENTO") == 0 ) && ( AV54Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Financiamentowwds_5_clientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV56Financiamentowwds_5_clientedocumento1)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV54Financiamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV57Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Financiamentowwds_2_dynamicfiltersselector1, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV54Financiamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Financiamentowwds_6_intermediadorclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV57Financiamentowwds_6_intermediadorclientedocumento1)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV58Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV60Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV61Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV61Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV58Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV60Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV61Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV61Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV58Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Financiamentowwds_8_dynamicfiltersselector2, "FINANCIAMENTOVALOR") == 0 ) && ( AV60Financiamentowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV61Financiamentowwds_10_financiamentovalor2) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV61Financiamentowwds_10_financiamentovalor2)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV58Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV60Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV62Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV58Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Financiamentowwds_8_dynamicfiltersselector2, "CLIENTEDOCUMENTO") == 0 ) && ( AV60Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Financiamentowwds_11_clientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV62Financiamentowwds_11_clientedocumento2)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV58Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV60Financiamentowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV63Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV58Financiamentowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Financiamentowwds_8_dynamicfiltersselector2, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV60Financiamentowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Financiamentowwds_12_intermediadorclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV63Financiamentowwds_12_intermediadorclientedocumento2)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV64Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV66Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV67Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor < :AV67Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV64Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV66Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV67Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor = :AV67Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( AV64Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Financiamentowwds_14_dynamicfiltersselector3, "FINANCIAMENTOVALOR") == 0 ) && ( AV66Financiamentowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV67Financiamentowwds_16_financiamentovalor3) ) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor > :AV67Financiamentowwds_16_financiamentovalor3)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( AV64Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV66Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV68Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV64Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Financiamentowwds_14_dynamicfiltersselector3, "CLIENTEDOCUMENTO") == 0 ) && ( AV66Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Financiamentowwds_17_clientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like '%' || :lV68Financiamentowwds_17_clientedocumento3)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV64Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV66Financiamentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV69Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( AV64Financiamentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Financiamentowwds_14_dynamicfiltersselector3, "INTERMEDIADORCLIENTEDOCUMENTO") == 0 ) && ( AV66Financiamentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Financiamentowwds_18_intermediadorclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV69Financiamentowwds_18_intermediadorclientedocumento3)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Financiamentowwds_20_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Financiamentowwds_19_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV70Financiamentowwds_19_tfclienterazaosocial)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Financiamentowwds_20_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV71Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV71Financiamentowwds_20_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( StringUtil.StrCmp(AV71Financiamentowwds_20_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Financiamentowwds_22_tfclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Financiamentowwds_21_tfclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento like :lV72Financiamentowwds_21_tfclientedocumento)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Financiamentowwds_22_tfclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV73Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento = ( :AV73Financiamentowwds_22_tfclientedocumento_sel))");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( StringUtil.StrCmp(AV73Financiamentowwds_22_tfclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ClienteDocumento))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV74Financiamentowwds_23_tffinanciamentovalor) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor >= :AV74Financiamentowwds_23_tffinanciamentovalor)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV75Financiamentowwds_24_tffinanciamentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.FinanciamentoValor <= :AV75Financiamentowwds_24_tffinanciamentovalor_to)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Financiamentowwds_25_tfintermediadorclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV76Financiamentowwds_25_tfintermediadorclienterazaosocial)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Financiamentowwds_26_tfintermediadorclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV77Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV77Financiamentowwds_26_tfintermediadorclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( StringUtil.StrCmp(AV77Financiamentowwds_26_tfintermediadorclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Financiamentowwds_27_tfintermediadorclientedocumento)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV78Financiamentowwds_27_tfintermediadorclientedocumento)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Financiamentowwds_28_tfintermediadorclientedocumento_sel)) && ! ( StringUtil.StrCmp(AV79Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento = ( :AV79Financiamentowwds_28_tfintermediadorclientedocumento_sel))");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( StringUtil.StrCmp(AV79Financiamentowwds_28_tfintermediadorclientedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T3.ClienteDocumento))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.FinanciamentoValor";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.FinanciamentoValor DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.ClienteRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.ClienteRazaoSocial DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.ClienteDocumento";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.ClienteDocumento DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteRazaoSocial";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteRazaoSocial DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.ClienteDocumento";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.ClienteDocumento DESC";
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
                     return conditional_P00752(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (decimal)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (decimal)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] );
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
          Object[] prmP00752;
          prmP00752 = new Object[] {
          new ParDef("lV52Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Financiamentowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV55Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("AV55Financiamentowwds_4_financiamentovalor1",GXType.Number,18,2) ,
          new ParDef("lV56Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV56Financiamentowwds_5_clientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV57Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV57Financiamentowwds_6_intermediadorclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("AV61Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV61Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("AV61Financiamentowwds_10_financiamentovalor2",GXType.Number,18,2) ,
          new ParDef("lV62Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV62Financiamentowwds_11_clientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV63Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV63Financiamentowwds_12_intermediadorclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("AV67Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV67Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("AV67Financiamentowwds_16_financiamentovalor3",GXType.Number,18,2) ,
          new ParDef("lV68Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV68Financiamentowwds_17_clientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV69Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV69Financiamentowwds_18_intermediadorclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV70Financiamentowwds_19_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV71Financiamentowwds_20_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV72Financiamentowwds_21_tfclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV73Financiamentowwds_22_tfclientedocumento_sel",GXType.VarChar,20,0) ,
          new ParDef("AV74Financiamentowwds_23_tffinanciamentovalor",GXType.Number,18,2) ,
          new ParDef("AV75Financiamentowwds_24_tffinanciamentovalor_to",GXType.Number,18,2) ,
          new ParDef("lV76Financiamentowwds_25_tfintermediadorclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV77Financiamentowwds_26_tfintermediadorclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV78Financiamentowwds_27_tfintermediadorclientedocumento",GXType.VarChar,20,0) ,
          new ParDef("AV79Financiamentowwds_28_tfintermediadorclientedocumento_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00752", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00752,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((int[]) buf[14])[0] = rslt.getInt(8);
                return;
       }
    }

 }

}
