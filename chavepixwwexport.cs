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
   public class chavepixwwexport : GXProcedure
   {
      public chavepixwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public chavepixwwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "ChavePIXWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV39GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CHAVEPIXTIPO") == 0 )
            {
               AV21ChavePIXTipo1 = AV39GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ChavePIXTipo1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ChavePIXTipo1)) )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmpixtipo.getDescription(context,AV21ChavePIXTipo1);
                  }
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV22ContaBancariaNumero1 = (long)(Math.Round(NumberUtil.Val( AV39GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV22ContaBancariaNumero1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", ">", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV22ContaBancariaNumero1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CHAVEPIXCREATEDBYNAME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV23ChavePIXCreatedByName1 = AV39GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ChavePIXCreatedByName1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "por", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "por", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV23ChavePIXCreatedByName1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CHAVEPIXUPDATEDBYNAME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV24ChavePIXUpdatedByName1 = AV39GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ChavePIXUpdatedByName1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "por", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "por", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24ChavePIXUpdatedByName1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV25DynamicFiltersEnabled2 = true;
               AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(2));
               AV26DynamicFiltersSelector2 = AV39GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "CHAVEPIXTIPO") == 0 )
               {
                  AV28ChavePIXTipo2 = AV39GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ChavePIXTipo2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ChavePIXTipo2)) )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmpixtipo.getDescription(context,AV28ChavePIXTipo2);
                     }
                  }
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV29ContaBancariaNumero2 = (long)(Math.Round(NumberUtil.Val( AV39GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV29ContaBancariaNumero2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV29ContaBancariaNumero2;
                  }
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "CHAVEPIXCREATEDBYNAME") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV30ChavePIXCreatedByName2 = AV39GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30ChavePIXCreatedByName2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "por", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "por", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30ChavePIXCreatedByName2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector2, "CHAVEPIXUPDATEDBYNAME") == 0 )
               {
                  AV27DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV31ChavePIXUpdatedByName2 = AV39GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ChavePIXUpdatedByName2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV27DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "por", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV27DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "por", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV31ChavePIXUpdatedByName2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV32DynamicFiltersEnabled3 = true;
                  AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(3));
                  AV33DynamicFiltersSelector3 = AV39GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "CHAVEPIXTIPO") == 0 )
                  {
                     AV35ChavePIXTipo3 = AV39GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35ChavePIXTipo3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35ChavePIXTipo3)) )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmpixtipo.getDescription(context,AV35ChavePIXTipo3);
                        }
                     }
                  }
                  else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV36ContaBancariaNumero3 = (long)(Math.Round(NumberUtil.Val( AV39GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV36ContaBancariaNumero3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV34DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV36ContaBancariaNumero3;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "CHAVEPIXCREATEDBYNAME") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV37ChavePIXCreatedByName3 = AV39GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37ChavePIXCreatedByName3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV34DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "por", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "por", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37ChavePIXCreatedByName3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV33DynamicFiltersSelector3, "CHAVEPIXUPDATEDBYNAME") == 0 )
                  {
                     AV34DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV38ChavePIXUpdatedByName3 = AV39GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38ChavePIXUpdatedByName3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV34DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "por", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV34DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "por", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38ChavePIXUpdatedByName3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFAgenciaBancoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Banco") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV60TFAgenciaBancoNome_Sel)) ? "(Vazio)" : AV60TFAgenciaBancoNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV59TFAgenciaBancoNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Banco") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV59TFAgenciaBancoNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV57TFAgenciaNumero) && (0==AV58TFAgenciaNumero_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Agência") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV57TFAgenciaNumero;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV58TFAgenciaNumero_To;
         }
         if ( ! ( (0==AV55TFContaBancariaNumero) && (0==AV56TFContaBancariaNumero_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Conta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV55TFContaBancariaNumero;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV56TFContaBancariaNumero_To;
         }
         if ( ! ( ( AV48TFChavePIXTipo_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo") ;
            AV13CellRow = GXt_int2;
            AV73i = 1;
            AV75GXV1 = 1;
            while ( AV75GXV1 <= AV48TFChavePIXTipo_Sels.Count )
            {
               AV47TFChavePIXTipo_Sel = ((string)AV48TFChavePIXTipo_Sels.Item(AV75GXV1));
               if ( AV73i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmpixtipo.getDescription(context,AV47TFChavePIXTipo_Sel);
               AV73i = (long)(AV73i+1);
               AV75GXV1 = (int)(AV75GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFChavePIXConteudo_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Chave") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFChavePIXConteudo_Sel)) ? "(Vazio)" : AV50TFChavePIXConteudo_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFChavePIXConteudo)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Chave") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFChavePIXConteudo, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV51TFChavePIXStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV51TFChavePIXStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV51TFChavePIXStatus_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV52TFChavePIXPrincipal_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Principal") ;
            AV13CellRow = GXt_int2;
            if ( AV52TFChavePIXPrincipal_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV52TFChavePIXPrincipal_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (DateTime.MinValue==AV61TFChavePIXCreatedAt) && (DateTime.MinValue==AV62TFChavePIXCreatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Criado em") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV61TFChavePIXCreatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV62TFChavePIXCreatedAt_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV66TFChavePIXCreatedByName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Criado por") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV66TFChavePIXCreatedByName_Sel)) ? "(Vazio)" : AV66TFChavePIXCreatedByName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV65TFChavePIXCreatedByName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Criado por") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV65TFChavePIXCreatedByName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV67TFChavePIXUpdatedAt) && (DateTime.MinValue==AV68TFChavePIXUpdatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Atualizado em") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV67TFChavePIXUpdatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV68TFChavePIXUpdatedAt_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV72TFChavePIXUpdatedByName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Atualizado por") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV72TFChavePIXUpdatedByName_Sel)) ? "(Vazio)" : AV72TFChavePIXUpdatedByName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV71TFChavePIXUpdatedByName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Atualizado por") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV71TFChavePIXUpdatedByName, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Banco";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Agência";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Conta";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Tipo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Chave";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Status";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Principal";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Criado em";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "Criado por";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Text = "Atualizado em";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Text = "Atualizado por";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV77Chavepixwwds_1_filterfulltext = AV18FilterFullText;
         AV78Chavepixwwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV79Chavepixwwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV80Chavepixwwds_4_chavepixtipo1 = AV21ChavePIXTipo1;
         AV81Chavepixwwds_5_contabancarianumero1 = AV22ContaBancariaNumero1;
         AV82Chavepixwwds_6_chavepixcreatedbyname1 = AV23ChavePIXCreatedByName1;
         AV83Chavepixwwds_7_chavepixupdatedbyname1 = AV24ChavePIXUpdatedByName1;
         AV84Chavepixwwds_8_dynamicfiltersenabled2 = AV25DynamicFiltersEnabled2;
         AV85Chavepixwwds_9_dynamicfiltersselector2 = AV26DynamicFiltersSelector2;
         AV86Chavepixwwds_10_dynamicfiltersoperator2 = AV27DynamicFiltersOperator2;
         AV87Chavepixwwds_11_chavepixtipo2 = AV28ChavePIXTipo2;
         AV88Chavepixwwds_12_contabancarianumero2 = AV29ContaBancariaNumero2;
         AV89Chavepixwwds_13_chavepixcreatedbyname2 = AV30ChavePIXCreatedByName2;
         AV90Chavepixwwds_14_chavepixupdatedbyname2 = AV31ChavePIXUpdatedByName2;
         AV91Chavepixwwds_15_dynamicfiltersenabled3 = AV32DynamicFiltersEnabled3;
         AV92Chavepixwwds_16_dynamicfiltersselector3 = AV33DynamicFiltersSelector3;
         AV93Chavepixwwds_17_dynamicfiltersoperator3 = AV34DynamicFiltersOperator3;
         AV94Chavepixwwds_18_chavepixtipo3 = AV35ChavePIXTipo3;
         AV95Chavepixwwds_19_contabancarianumero3 = AV36ContaBancariaNumero3;
         AV96Chavepixwwds_20_chavepixcreatedbyname3 = AV37ChavePIXCreatedByName3;
         AV97Chavepixwwds_21_chavepixupdatedbyname3 = AV38ChavePIXUpdatedByName3;
         AV98Chavepixwwds_22_tfagenciabanconome = AV59TFAgenciaBancoNome;
         AV99Chavepixwwds_23_tfagenciabanconome_sel = AV60TFAgenciaBancoNome_Sel;
         AV100Chavepixwwds_24_tfagencianumero = AV57TFAgenciaNumero;
         AV101Chavepixwwds_25_tfagencianumero_to = AV58TFAgenciaNumero_To;
         AV102Chavepixwwds_26_tfcontabancarianumero = AV55TFContaBancariaNumero;
         AV103Chavepixwwds_27_tfcontabancarianumero_to = AV56TFContaBancariaNumero_To;
         AV104Chavepixwwds_28_tfchavepixtipo_sels = AV48TFChavePIXTipo_Sels;
         AV105Chavepixwwds_29_tfchavepixconteudo = AV49TFChavePIXConteudo;
         AV106Chavepixwwds_30_tfchavepixconteudo_sel = AV50TFChavePIXConteudo_Sel;
         AV107Chavepixwwds_31_tfchavepixstatus_sel = AV51TFChavePIXStatus_Sel;
         AV108Chavepixwwds_32_tfchavepixprincipal_sel = AV52TFChavePIXPrincipal_Sel;
         AV109Chavepixwwds_33_tfchavepixcreatedat = AV61TFChavePIXCreatedAt;
         AV110Chavepixwwds_34_tfchavepixcreatedat_to = AV62TFChavePIXCreatedAt_To;
         AV111Chavepixwwds_35_tfchavepixcreatedbyname = AV65TFChavePIXCreatedByName;
         AV112Chavepixwwds_36_tfchavepixcreatedbyname_sel = AV66TFChavePIXCreatedByName_Sel;
         AV113Chavepixwwds_37_tfchavepixupdatedat = AV67TFChavePIXUpdatedAt;
         AV114Chavepixwwds_38_tfchavepixupdatedat_to = AV68TFChavePIXUpdatedAt_To;
         AV115Chavepixwwds_39_tfchavepixupdatedbyname = AV71TFChavePIXUpdatedByName;
         AV116Chavepixwwds_40_tfchavepixupdatedbyname_sel = AV72TFChavePIXUpdatedByName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A962ChavePIXTipo ,
                                              AV104Chavepixwwds_28_tfchavepixtipo_sels ,
                                              AV77Chavepixwwds_1_filterfulltext ,
                                              AV78Chavepixwwds_2_dynamicfiltersselector1 ,
                                              AV80Chavepixwwds_4_chavepixtipo1 ,
                                              AV79Chavepixwwds_3_dynamicfiltersoperator1 ,
                                              AV81Chavepixwwds_5_contabancarianumero1 ,
                                              AV82Chavepixwwds_6_chavepixcreatedbyname1 ,
                                              AV83Chavepixwwds_7_chavepixupdatedbyname1 ,
                                              AV84Chavepixwwds_8_dynamicfiltersenabled2 ,
                                              AV85Chavepixwwds_9_dynamicfiltersselector2 ,
                                              AV87Chavepixwwds_11_chavepixtipo2 ,
                                              AV86Chavepixwwds_10_dynamicfiltersoperator2 ,
                                              AV88Chavepixwwds_12_contabancarianumero2 ,
                                              AV89Chavepixwwds_13_chavepixcreatedbyname2 ,
                                              AV90Chavepixwwds_14_chavepixupdatedbyname2 ,
                                              AV91Chavepixwwds_15_dynamicfiltersenabled3 ,
                                              AV92Chavepixwwds_16_dynamicfiltersselector3 ,
                                              AV94Chavepixwwds_18_chavepixtipo3 ,
                                              AV93Chavepixwwds_17_dynamicfiltersoperator3 ,
                                              AV95Chavepixwwds_19_contabancarianumero3 ,
                                              AV96Chavepixwwds_20_chavepixcreatedbyname3 ,
                                              AV97Chavepixwwds_21_chavepixupdatedbyname3 ,
                                              AV99Chavepixwwds_23_tfagenciabanconome_sel ,
                                              AV98Chavepixwwds_22_tfagenciabanconome ,
                                              AV100Chavepixwwds_24_tfagencianumero ,
                                              AV101Chavepixwwds_25_tfagencianumero_to ,
                                              AV102Chavepixwwds_26_tfcontabancarianumero ,
                                              AV103Chavepixwwds_27_tfcontabancarianumero_to ,
                                              AV104Chavepixwwds_28_tfchavepixtipo_sels.Count ,
                                              AV106Chavepixwwds_30_tfchavepixconteudo_sel ,
                                              AV105Chavepixwwds_29_tfchavepixconteudo ,
                                              AV107Chavepixwwds_31_tfchavepixstatus_sel ,
                                              AV108Chavepixwwds_32_tfchavepixprincipal_sel ,
                                              AV109Chavepixwwds_33_tfchavepixcreatedat ,
                                              AV110Chavepixwwds_34_tfchavepixcreatedat_to ,
                                              AV112Chavepixwwds_36_tfchavepixcreatedbyname_sel ,
                                              AV111Chavepixwwds_35_tfchavepixcreatedbyname ,
                                              AV113Chavepixwwds_37_tfchavepixupdatedat ,
                                              AV114Chavepixwwds_38_tfchavepixupdatedat_to ,
                                              AV116Chavepixwwds_40_tfchavepixupdatedbyname_sel ,
                                              AV115Chavepixwwds_39_tfchavepixupdatedbyname ,
                                              AV74ContaBancariaId ,
                                              A969AgenciaBancoNome ,
                                              A939AgenciaNumero ,
                                              A952ContaBancariaNumero ,
                                              A963ChavePIXConteudo ,
                                              A964ChavePIXStatus ,
                                              A965ChavePIXPrincipal ,
                                              A958ChavePIXCreatedByName ,
                                              A960ChavePIXUpdatedByName ,
                                              A966ChavePIXCreatedAt ,
                                              A967ChavePIXUpdatedAt ,
                                              A951ContaBancariaId ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV77Chavepixwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext), "%", "");
         lV82Chavepixwwds_6_chavepixcreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV82Chavepixwwds_6_chavepixcreatedbyname1), "%", "");
         lV82Chavepixwwds_6_chavepixcreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV82Chavepixwwds_6_chavepixcreatedbyname1), "%", "");
         lV83Chavepixwwds_7_chavepixupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV83Chavepixwwds_7_chavepixupdatedbyname1), "%", "");
         lV83Chavepixwwds_7_chavepixupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV83Chavepixwwds_7_chavepixupdatedbyname1), "%", "");
         lV89Chavepixwwds_13_chavepixcreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV89Chavepixwwds_13_chavepixcreatedbyname2), "%", "");
         lV89Chavepixwwds_13_chavepixcreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV89Chavepixwwds_13_chavepixcreatedbyname2), "%", "");
         lV90Chavepixwwds_14_chavepixupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV90Chavepixwwds_14_chavepixupdatedbyname2), "%", "");
         lV90Chavepixwwds_14_chavepixupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV90Chavepixwwds_14_chavepixupdatedbyname2), "%", "");
         lV96Chavepixwwds_20_chavepixcreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV96Chavepixwwds_20_chavepixcreatedbyname3), "%", "");
         lV96Chavepixwwds_20_chavepixcreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV96Chavepixwwds_20_chavepixcreatedbyname3), "%", "");
         lV97Chavepixwwds_21_chavepixupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV97Chavepixwwds_21_chavepixupdatedbyname3), "%", "");
         lV97Chavepixwwds_21_chavepixupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV97Chavepixwwds_21_chavepixupdatedbyname3), "%", "");
         lV98Chavepixwwds_22_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV98Chavepixwwds_22_tfagenciabanconome), "%", "");
         lV105Chavepixwwds_29_tfchavepixconteudo = StringUtil.Concat( StringUtil.RTrim( AV105Chavepixwwds_29_tfchavepixconteudo), "%", "");
         lV111Chavepixwwds_35_tfchavepixcreatedbyname = StringUtil.Concat( StringUtil.RTrim( AV111Chavepixwwds_35_tfchavepixcreatedbyname), "%", "");
         lV115Chavepixwwds_39_tfchavepixupdatedbyname = StringUtil.Concat( StringUtil.RTrim( AV115Chavepixwwds_39_tfchavepixupdatedbyname), "%", "");
         /* Using cursor P00ER2 */
         pr_default.execute(0, new Object[] {lV77Chavepixwwds_1_filterfulltext, lV77Chavepixwwds_1_filterfulltext, lV77Chavepixwwds_1_filterfulltext, lV77Chavepixwwds_1_filterfulltext, lV77Chavepixwwds_1_filterfulltext, lV77Chavepixwwds_1_filterfulltext, lV77Chavepixwwds_1_filterfulltext, lV77Chavepixwwds_1_filterfulltext, lV77Chavepixwwds_1_filterfulltext, lV77Chavepixwwds_1_filterfulltext, lV77Chavepixwwds_1_filterfulltext, lV77Chavepixwwds_1_filterfulltext, lV77Chavepixwwds_1_filterfulltext, lV77Chavepixwwds_1_filterfulltext, lV77Chavepixwwds_1_filterfulltext, AV80Chavepixwwds_4_chavepixtipo1, AV81Chavepixwwds_5_contabancarianumero1, AV81Chavepixwwds_5_contabancarianumero1, AV81Chavepixwwds_5_contabancarianumero1, lV82Chavepixwwds_6_chavepixcreatedbyname1, lV82Chavepixwwds_6_chavepixcreatedbyname1, lV83Chavepixwwds_7_chavepixupdatedbyname1, lV83Chavepixwwds_7_chavepixupdatedbyname1, AV87Chavepixwwds_11_chavepixtipo2, AV88Chavepixwwds_12_contabancarianumero2, AV88Chavepixwwds_12_contabancarianumero2, AV88Chavepixwwds_12_contabancarianumero2, lV89Chavepixwwds_13_chavepixcreatedbyname2, lV89Chavepixwwds_13_chavepixcreatedbyname2, lV90Chavepixwwds_14_chavepixupdatedbyname2, lV90Chavepixwwds_14_chavepixupdatedbyname2, AV94Chavepixwwds_18_chavepixtipo3, AV95Chavepixwwds_19_contabancarianumero3, AV95Chavepixwwds_19_contabancarianumero3, AV95Chavepixwwds_19_contabancarianumero3, lV96Chavepixwwds_20_chavepixcreatedbyname3, lV96Chavepixwwds_20_chavepixcreatedbyname3, lV97Chavepixwwds_21_chavepixupdatedbyname3, lV97Chavepixwwds_21_chavepixupdatedbyname3, lV98Chavepixwwds_22_tfagenciabanconome, AV99Chavepixwwds_23_tfagenciabanconome_sel, AV100Chavepixwwds_24_tfagencianumero, AV101Chavepixwwds_25_tfagencianumero_to, AV102Chavepixwwds_26_tfcontabancarianumero, AV103Chavepixwwds_27_tfcontabancarianumero_to, lV105Chavepixwwds_29_tfchavepixconteudo, AV106Chavepixwwds_30_tfchavepixconteudo_sel, AV109Chavepixwwds_33_tfchavepixcreatedat, AV110Chavepixwwds_34_tfchavepixcreatedat_to, lV111Chavepixwwds_35_tfchavepixcreatedbyname, AV112Chavepixwwds_36_tfchavepixcreatedbyname_sel, AV113Chavepixwwds_37_tfchavepixupdatedat, AV114Chavepixwwds_38_tfchavepixupdatedat_to, lV115Chavepixwwds_39_tfchavepixupdatedbyname, AV116Chavepixwwds_40_tfchavepixupdatedbyname_sel, AV74ContaBancariaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A938AgenciaId = P00ER2_A938AgenciaId[0];
            n938AgenciaId = P00ER2_n938AgenciaId[0];
            A968AgenciaBancoId = P00ER2_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00ER2_n968AgenciaBancoId[0];
            A957ChavePIXCreatedBy = P00ER2_A957ChavePIXCreatedBy[0];
            n957ChavePIXCreatedBy = P00ER2_n957ChavePIXCreatedBy[0];
            A959ChavePIXUpdatedBy = P00ER2_A959ChavePIXUpdatedBy[0];
            n959ChavePIXUpdatedBy = P00ER2_n959ChavePIXUpdatedBy[0];
            A951ContaBancariaId = P00ER2_A951ContaBancariaId[0];
            n951ContaBancariaId = P00ER2_n951ContaBancariaId[0];
            A967ChavePIXUpdatedAt = P00ER2_A967ChavePIXUpdatedAt[0];
            n967ChavePIXUpdatedAt = P00ER2_n967ChavePIXUpdatedAt[0];
            A966ChavePIXCreatedAt = P00ER2_A966ChavePIXCreatedAt[0];
            n966ChavePIXCreatedAt = P00ER2_n966ChavePIXCreatedAt[0];
            A963ChavePIXConteudo = P00ER2_A963ChavePIXConteudo[0];
            n963ChavePIXConteudo = P00ER2_n963ChavePIXConteudo[0];
            A939AgenciaNumero = P00ER2_A939AgenciaNumero[0];
            n939AgenciaNumero = P00ER2_n939AgenciaNumero[0];
            A969AgenciaBancoNome = P00ER2_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00ER2_n969AgenciaBancoNome[0];
            A960ChavePIXUpdatedByName = P00ER2_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = P00ER2_n960ChavePIXUpdatedByName[0];
            A958ChavePIXCreatedByName = P00ER2_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = P00ER2_n958ChavePIXCreatedByName[0];
            A952ContaBancariaNumero = P00ER2_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00ER2_n952ContaBancariaNumero[0];
            A965ChavePIXPrincipal = P00ER2_A965ChavePIXPrincipal[0];
            n965ChavePIXPrincipal = P00ER2_n965ChavePIXPrincipal[0];
            A964ChavePIXStatus = P00ER2_A964ChavePIXStatus[0];
            n964ChavePIXStatus = P00ER2_n964ChavePIXStatus[0];
            A962ChavePIXTipo = P00ER2_A962ChavePIXTipo[0];
            n962ChavePIXTipo = P00ER2_n962ChavePIXTipo[0];
            A961ChavePIXId = P00ER2_A961ChavePIXId[0];
            A958ChavePIXCreatedByName = P00ER2_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = P00ER2_n958ChavePIXCreatedByName[0];
            A960ChavePIXUpdatedByName = P00ER2_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = P00ER2_n960ChavePIXUpdatedByName[0];
            A938AgenciaId = P00ER2_A938AgenciaId[0];
            n938AgenciaId = P00ER2_n938AgenciaId[0];
            A952ContaBancariaNumero = P00ER2_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00ER2_n952ContaBancariaNumero[0];
            A968AgenciaBancoId = P00ER2_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00ER2_n968AgenciaBancoId[0];
            A939AgenciaNumero = P00ER2_A939AgenciaNumero[0];
            n939AgenciaNumero = P00ER2_n939AgenciaNumero[0];
            A969AgenciaBancoNome = P00ER2_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00ER2_n969AgenciaBancoNome[0];
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
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = A952ContaBancariaNumero;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = gxdomaindmpixtipo.getDescription(context,A962ChavePIXTipo);
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A963ChavePIXConteudo, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A964ChavePIXStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A964ChavePIXStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Inativo";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A964ChavePIXStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A964ChavePIXStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A965ChavePIXPrincipal)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Sim";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A965ChavePIXPrincipal)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Não";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A965ChavePIXPrincipal)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = GXUtil.RGB( 60, 141, 188);
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A965ChavePIXPrincipal)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = GXUtil.RGB( 128, 128, 128);
            }
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Date = A966ChavePIXCreatedAt;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A958ChavePIXCreatedByName, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Date = A967ChavePIXUpdatedAt;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A960ChavePIXUpdatedByName, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Text = GXt_char1;
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
         AV40Session.Set("WWPExportFilePath", AV11Filename);
         AV40Session.Set("WWPExportFileName", "ChavePIXWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV40Session.Get("ChavePIXWWGridState"), "") == 0 )
         {
            AV42GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ChavePIXWWGridState"), null, "", "");
         }
         else
         {
            AV42GridState.FromXml(AV40Session.Get("ChavePIXWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV42GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV42GridState.gxTpr_Ordereddsc;
         AV117GXV2 = 1;
         while ( AV117GXV2 <= AV42GridState.gxTpr_Filtervalues.Count )
         {
            AV43GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV42GridState.gxTpr_Filtervalues.Item(AV117GXV2));
            if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME") == 0 )
            {
               AV59TFAgenciaBancoNome = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME_SEL") == 0 )
            {
               AV60TFAgenciaBancoNome_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFAGENCIANUMERO") == 0 )
            {
               AV57TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV58TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIANUMERO") == 0 )
            {
               AV55TFContaBancariaNumero = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV56TFContaBancariaNumero_To = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXTIPO_SEL") == 0 )
            {
               AV46TFChavePIXTipo_SelsJson = AV43GridStateFilterValue.gxTpr_Value;
               AV48TFChavePIXTipo_Sels.FromJSonString(AV46TFChavePIXTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCONTEUDO") == 0 )
            {
               AV49TFChavePIXConteudo = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCONTEUDO_SEL") == 0 )
            {
               AV50TFChavePIXConteudo_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXSTATUS_SEL") == 0 )
            {
               AV51TFChavePIXStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXPRINCIPAL_SEL") == 0 )
            {
               AV52TFChavePIXPrincipal_Sel = (short)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCREATEDAT") == 0 )
            {
               AV61TFChavePIXCreatedAt = context.localUtil.CToT( AV43GridStateFilterValue.gxTpr_Value, 4);
               AV62TFChavePIXCreatedAt_To = context.localUtil.CToT( AV43GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCREATEDBYNAME") == 0 )
            {
               AV65TFChavePIXCreatedByName = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXCREATEDBYNAME_SEL") == 0 )
            {
               AV66TFChavePIXCreatedByName_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXUPDATEDAT") == 0 )
            {
               AV67TFChavePIXUpdatedAt = context.localUtil.CToT( AV43GridStateFilterValue.gxTpr_Value, 4);
               AV68TFChavePIXUpdatedAt_To = context.localUtil.CToT( AV43GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXUPDATEDBYNAME") == 0 )
            {
               AV71TFChavePIXUpdatedByName = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFCHAVEPIXUPDATEDBYNAME_SEL") == 0 )
            {
               AV72TFChavePIXUpdatedByName_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "PARM_&CONTABANCARIAID") == 0 )
            {
               AV74ContaBancariaId = (int)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV117GXV2 = (int)(AV117GXV2+1);
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
         AV42GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV39GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV21ChavePIXTipo1 = "";
         AV23ChavePIXCreatedByName1 = "";
         AV24ChavePIXUpdatedByName1 = "";
         AV26DynamicFiltersSelector2 = "";
         AV28ChavePIXTipo2 = "";
         AV30ChavePIXCreatedByName2 = "";
         AV31ChavePIXUpdatedByName2 = "";
         AV33DynamicFiltersSelector3 = "";
         AV35ChavePIXTipo3 = "";
         AV37ChavePIXCreatedByName3 = "";
         AV38ChavePIXUpdatedByName3 = "";
         AV60TFAgenciaBancoNome_Sel = "";
         AV59TFAgenciaBancoNome = "";
         AV48TFChavePIXTipo_Sels = new GxSimpleCollection<string>();
         AV47TFChavePIXTipo_Sel = "";
         AV50TFChavePIXConteudo_Sel = "";
         AV49TFChavePIXConteudo = "";
         AV61TFChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         AV62TFChavePIXCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV66TFChavePIXCreatedByName_Sel = "";
         AV65TFChavePIXCreatedByName = "";
         AV67TFChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         AV68TFChavePIXUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV72TFChavePIXUpdatedByName_Sel = "";
         AV71TFChavePIXUpdatedByName = "";
         AV77Chavepixwwds_1_filterfulltext = "";
         AV78Chavepixwwds_2_dynamicfiltersselector1 = "";
         AV80Chavepixwwds_4_chavepixtipo1 = "";
         AV82Chavepixwwds_6_chavepixcreatedbyname1 = "";
         AV83Chavepixwwds_7_chavepixupdatedbyname1 = "";
         AV85Chavepixwwds_9_dynamicfiltersselector2 = "";
         AV87Chavepixwwds_11_chavepixtipo2 = "";
         AV89Chavepixwwds_13_chavepixcreatedbyname2 = "";
         AV90Chavepixwwds_14_chavepixupdatedbyname2 = "";
         AV92Chavepixwwds_16_dynamicfiltersselector3 = "";
         AV94Chavepixwwds_18_chavepixtipo3 = "";
         AV96Chavepixwwds_20_chavepixcreatedbyname3 = "";
         AV97Chavepixwwds_21_chavepixupdatedbyname3 = "";
         AV98Chavepixwwds_22_tfagenciabanconome = "";
         AV99Chavepixwwds_23_tfagenciabanconome_sel = "";
         AV104Chavepixwwds_28_tfchavepixtipo_sels = new GxSimpleCollection<string>();
         AV105Chavepixwwds_29_tfchavepixconteudo = "";
         AV106Chavepixwwds_30_tfchavepixconteudo_sel = "";
         AV109Chavepixwwds_33_tfchavepixcreatedat = (DateTime)(DateTime.MinValue);
         AV110Chavepixwwds_34_tfchavepixcreatedat_to = (DateTime)(DateTime.MinValue);
         AV111Chavepixwwds_35_tfchavepixcreatedbyname = "";
         AV112Chavepixwwds_36_tfchavepixcreatedbyname_sel = "";
         AV113Chavepixwwds_37_tfchavepixupdatedat = (DateTime)(DateTime.MinValue);
         AV114Chavepixwwds_38_tfchavepixupdatedat_to = (DateTime)(DateTime.MinValue);
         AV115Chavepixwwds_39_tfchavepixupdatedbyname = "";
         AV116Chavepixwwds_40_tfchavepixupdatedbyname_sel = "";
         lV77Chavepixwwds_1_filterfulltext = "";
         lV82Chavepixwwds_6_chavepixcreatedbyname1 = "";
         lV83Chavepixwwds_7_chavepixupdatedbyname1 = "";
         lV89Chavepixwwds_13_chavepixcreatedbyname2 = "";
         lV90Chavepixwwds_14_chavepixupdatedbyname2 = "";
         lV96Chavepixwwds_20_chavepixcreatedbyname3 = "";
         lV97Chavepixwwds_21_chavepixupdatedbyname3 = "";
         lV98Chavepixwwds_22_tfagenciabanconome = "";
         lV105Chavepixwwds_29_tfchavepixconteudo = "";
         lV111Chavepixwwds_35_tfchavepixcreatedbyname = "";
         lV115Chavepixwwds_39_tfchavepixupdatedbyname = "";
         A962ChavePIXTipo = "";
         A969AgenciaBancoNome = "";
         A963ChavePIXConteudo = "";
         A958ChavePIXCreatedByName = "";
         A960ChavePIXUpdatedByName = "";
         A966ChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         A967ChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         P00ER2_A938AgenciaId = new int[1] ;
         P00ER2_n938AgenciaId = new bool[] {false} ;
         P00ER2_A968AgenciaBancoId = new int[1] ;
         P00ER2_n968AgenciaBancoId = new bool[] {false} ;
         P00ER2_A957ChavePIXCreatedBy = new short[1] ;
         P00ER2_n957ChavePIXCreatedBy = new bool[] {false} ;
         P00ER2_A959ChavePIXUpdatedBy = new short[1] ;
         P00ER2_n959ChavePIXUpdatedBy = new bool[] {false} ;
         P00ER2_A951ContaBancariaId = new int[1] ;
         P00ER2_n951ContaBancariaId = new bool[] {false} ;
         P00ER2_A967ChavePIXUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         P00ER2_n967ChavePIXUpdatedAt = new bool[] {false} ;
         P00ER2_A966ChavePIXCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00ER2_n966ChavePIXCreatedAt = new bool[] {false} ;
         P00ER2_A963ChavePIXConteudo = new string[] {""} ;
         P00ER2_n963ChavePIXConteudo = new bool[] {false} ;
         P00ER2_A939AgenciaNumero = new int[1] ;
         P00ER2_n939AgenciaNumero = new bool[] {false} ;
         P00ER2_A969AgenciaBancoNome = new string[] {""} ;
         P00ER2_n969AgenciaBancoNome = new bool[] {false} ;
         P00ER2_A960ChavePIXUpdatedByName = new string[] {""} ;
         P00ER2_n960ChavePIXUpdatedByName = new bool[] {false} ;
         P00ER2_A958ChavePIXCreatedByName = new string[] {""} ;
         P00ER2_n958ChavePIXCreatedByName = new bool[] {false} ;
         P00ER2_A952ContaBancariaNumero = new long[1] ;
         P00ER2_n952ContaBancariaNumero = new bool[] {false} ;
         P00ER2_A965ChavePIXPrincipal = new bool[] {false} ;
         P00ER2_n965ChavePIXPrincipal = new bool[] {false} ;
         P00ER2_A964ChavePIXStatus = new bool[] {false} ;
         P00ER2_n964ChavePIXStatus = new bool[] {false} ;
         P00ER2_A962ChavePIXTipo = new string[] {""} ;
         P00ER2_n962ChavePIXTipo = new bool[] {false} ;
         P00ER2_A961ChavePIXId = new int[1] ;
         GXt_char1 = "";
         AV40Session = context.GetSession();
         AV43GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46TFChavePIXTipo_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.chavepixwwexport__default(),
            new Object[][] {
                new Object[] {
               P00ER2_A938AgenciaId, P00ER2_n938AgenciaId, P00ER2_A968AgenciaBancoId, P00ER2_n968AgenciaBancoId, P00ER2_A957ChavePIXCreatedBy, P00ER2_n957ChavePIXCreatedBy, P00ER2_A959ChavePIXUpdatedBy, P00ER2_n959ChavePIXUpdatedBy, P00ER2_A951ContaBancariaId, P00ER2_n951ContaBancariaId,
               P00ER2_A967ChavePIXUpdatedAt, P00ER2_n967ChavePIXUpdatedAt, P00ER2_A966ChavePIXCreatedAt, P00ER2_n966ChavePIXCreatedAt, P00ER2_A963ChavePIXConteudo, P00ER2_n963ChavePIXConteudo, P00ER2_A939AgenciaNumero, P00ER2_n939AgenciaNumero, P00ER2_A969AgenciaBancoNome, P00ER2_n969AgenciaBancoNome,
               P00ER2_A960ChavePIXUpdatedByName, P00ER2_n960ChavePIXUpdatedByName, P00ER2_A958ChavePIXCreatedByName, P00ER2_n958ChavePIXCreatedByName, P00ER2_A952ContaBancariaNumero, P00ER2_n952ContaBancariaNumero, P00ER2_A965ChavePIXPrincipal, P00ER2_n965ChavePIXPrincipal, P00ER2_A964ChavePIXStatus, P00ER2_n964ChavePIXStatus,
               P00ER2_A962ChavePIXTipo, P00ER2_n962ChavePIXTipo, P00ER2_A961ChavePIXId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV27DynamicFiltersOperator2 ;
      private short AV34DynamicFiltersOperator3 ;
      private short AV51TFChavePIXStatus_Sel ;
      private short AV52TFChavePIXPrincipal_Sel ;
      private short GXt_int2 ;
      private short AV79Chavepixwwds_3_dynamicfiltersoperator1 ;
      private short AV86Chavepixwwds_10_dynamicfiltersoperator2 ;
      private short AV93Chavepixwwds_17_dynamicfiltersoperator3 ;
      private short AV107Chavepixwwds_31_tfchavepixstatus_sel ;
      private short AV108Chavepixwwds_32_tfchavepixprincipal_sel ;
      private short AV16OrderedBy ;
      private short A957ChavePIXCreatedBy ;
      private short A959ChavePIXUpdatedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV57TFAgenciaNumero ;
      private int AV58TFAgenciaNumero_To ;
      private int AV75GXV1 ;
      private int AV100Chavepixwwds_24_tfagencianumero ;
      private int AV101Chavepixwwds_25_tfagencianumero_to ;
      private int AV104Chavepixwwds_28_tfchavepixtipo_sels_Count ;
      private int AV74ContaBancariaId ;
      private int A939AgenciaNumero ;
      private int A951ContaBancariaId ;
      private int A938AgenciaId ;
      private int A968AgenciaBancoId ;
      private int A961ChavePIXId ;
      private int AV117GXV2 ;
      private long AV22ContaBancariaNumero1 ;
      private long AV29ContaBancariaNumero2 ;
      private long AV36ContaBancariaNumero3 ;
      private long AV55TFContaBancariaNumero ;
      private long AV56TFContaBancariaNumero_To ;
      private long AV73i ;
      private long AV81Chavepixwwds_5_contabancarianumero1 ;
      private long AV88Chavepixwwds_12_contabancarianumero2 ;
      private long AV95Chavepixwwds_19_contabancarianumero3 ;
      private long AV102Chavepixwwds_26_tfcontabancarianumero ;
      private long AV103Chavepixwwds_27_tfcontabancarianumero_to ;
      private long A952ContaBancariaNumero ;
      private string GXt_char1 ;
      private DateTime AV61TFChavePIXCreatedAt ;
      private DateTime AV62TFChavePIXCreatedAt_To ;
      private DateTime AV67TFChavePIXUpdatedAt ;
      private DateTime AV68TFChavePIXUpdatedAt_To ;
      private DateTime AV109Chavepixwwds_33_tfchavepixcreatedat ;
      private DateTime AV110Chavepixwwds_34_tfchavepixcreatedat_to ;
      private DateTime AV113Chavepixwwds_37_tfchavepixupdatedat ;
      private DateTime AV114Chavepixwwds_38_tfchavepixupdatedat_to ;
      private DateTime A966ChavePIXCreatedAt ;
      private DateTime A967ChavePIXUpdatedAt ;
      private bool returnInSub ;
      private bool AV25DynamicFiltersEnabled2 ;
      private bool AV32DynamicFiltersEnabled3 ;
      private bool AV84Chavepixwwds_8_dynamicfiltersenabled2 ;
      private bool AV91Chavepixwwds_15_dynamicfiltersenabled3 ;
      private bool A964ChavePIXStatus ;
      private bool A965ChavePIXPrincipal ;
      private bool AV17OrderedDsc ;
      private bool n938AgenciaId ;
      private bool n968AgenciaBancoId ;
      private bool n957ChavePIXCreatedBy ;
      private bool n959ChavePIXUpdatedBy ;
      private bool n951ContaBancariaId ;
      private bool n967ChavePIXUpdatedAt ;
      private bool n966ChavePIXCreatedAt ;
      private bool n963ChavePIXConteudo ;
      private bool n939AgenciaNumero ;
      private bool n969AgenciaBancoNome ;
      private bool n960ChavePIXUpdatedByName ;
      private bool n958ChavePIXCreatedByName ;
      private bool n952ContaBancariaNumero ;
      private bool n965ChavePIXPrincipal ;
      private bool n964ChavePIXStatus ;
      private bool n962ChavePIXTipo ;
      private string AV46TFChavePIXTipo_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21ChavePIXTipo1 ;
      private string AV23ChavePIXCreatedByName1 ;
      private string AV24ChavePIXUpdatedByName1 ;
      private string AV26DynamicFiltersSelector2 ;
      private string AV28ChavePIXTipo2 ;
      private string AV30ChavePIXCreatedByName2 ;
      private string AV31ChavePIXUpdatedByName2 ;
      private string AV33DynamicFiltersSelector3 ;
      private string AV35ChavePIXTipo3 ;
      private string AV37ChavePIXCreatedByName3 ;
      private string AV38ChavePIXUpdatedByName3 ;
      private string AV60TFAgenciaBancoNome_Sel ;
      private string AV59TFAgenciaBancoNome ;
      private string AV47TFChavePIXTipo_Sel ;
      private string AV50TFChavePIXConteudo_Sel ;
      private string AV49TFChavePIXConteudo ;
      private string AV66TFChavePIXCreatedByName_Sel ;
      private string AV65TFChavePIXCreatedByName ;
      private string AV72TFChavePIXUpdatedByName_Sel ;
      private string AV71TFChavePIXUpdatedByName ;
      private string AV77Chavepixwwds_1_filterfulltext ;
      private string AV78Chavepixwwds_2_dynamicfiltersselector1 ;
      private string AV80Chavepixwwds_4_chavepixtipo1 ;
      private string AV82Chavepixwwds_6_chavepixcreatedbyname1 ;
      private string AV83Chavepixwwds_7_chavepixupdatedbyname1 ;
      private string AV85Chavepixwwds_9_dynamicfiltersselector2 ;
      private string AV87Chavepixwwds_11_chavepixtipo2 ;
      private string AV89Chavepixwwds_13_chavepixcreatedbyname2 ;
      private string AV90Chavepixwwds_14_chavepixupdatedbyname2 ;
      private string AV92Chavepixwwds_16_dynamicfiltersselector3 ;
      private string AV94Chavepixwwds_18_chavepixtipo3 ;
      private string AV96Chavepixwwds_20_chavepixcreatedbyname3 ;
      private string AV97Chavepixwwds_21_chavepixupdatedbyname3 ;
      private string AV98Chavepixwwds_22_tfagenciabanconome ;
      private string AV99Chavepixwwds_23_tfagenciabanconome_sel ;
      private string AV105Chavepixwwds_29_tfchavepixconteudo ;
      private string AV106Chavepixwwds_30_tfchavepixconteudo_sel ;
      private string AV111Chavepixwwds_35_tfchavepixcreatedbyname ;
      private string AV112Chavepixwwds_36_tfchavepixcreatedbyname_sel ;
      private string AV115Chavepixwwds_39_tfchavepixupdatedbyname ;
      private string AV116Chavepixwwds_40_tfchavepixupdatedbyname_sel ;
      private string lV77Chavepixwwds_1_filterfulltext ;
      private string lV82Chavepixwwds_6_chavepixcreatedbyname1 ;
      private string lV83Chavepixwwds_7_chavepixupdatedbyname1 ;
      private string lV89Chavepixwwds_13_chavepixcreatedbyname2 ;
      private string lV90Chavepixwwds_14_chavepixupdatedbyname2 ;
      private string lV96Chavepixwwds_20_chavepixcreatedbyname3 ;
      private string lV97Chavepixwwds_21_chavepixupdatedbyname3 ;
      private string lV98Chavepixwwds_22_tfagenciabanconome ;
      private string lV105Chavepixwwds_29_tfchavepixconteudo ;
      private string lV111Chavepixwwds_35_tfchavepixcreatedbyname ;
      private string lV115Chavepixwwds_39_tfchavepixupdatedbyname ;
      private string A962ChavePIXTipo ;
      private string A969AgenciaBancoNome ;
      private string A963ChavePIXConteudo ;
      private string A958ChavePIXCreatedByName ;
      private string A960ChavePIXUpdatedByName ;
      private IGxSession AV40Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV42GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV39GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV48TFChavePIXTipo_Sels ;
      private GxSimpleCollection<string> AV104Chavepixwwds_28_tfchavepixtipo_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00ER2_A938AgenciaId ;
      private bool[] P00ER2_n938AgenciaId ;
      private int[] P00ER2_A968AgenciaBancoId ;
      private bool[] P00ER2_n968AgenciaBancoId ;
      private short[] P00ER2_A957ChavePIXCreatedBy ;
      private bool[] P00ER2_n957ChavePIXCreatedBy ;
      private short[] P00ER2_A959ChavePIXUpdatedBy ;
      private bool[] P00ER2_n959ChavePIXUpdatedBy ;
      private int[] P00ER2_A951ContaBancariaId ;
      private bool[] P00ER2_n951ContaBancariaId ;
      private DateTime[] P00ER2_A967ChavePIXUpdatedAt ;
      private bool[] P00ER2_n967ChavePIXUpdatedAt ;
      private DateTime[] P00ER2_A966ChavePIXCreatedAt ;
      private bool[] P00ER2_n966ChavePIXCreatedAt ;
      private string[] P00ER2_A963ChavePIXConteudo ;
      private bool[] P00ER2_n963ChavePIXConteudo ;
      private int[] P00ER2_A939AgenciaNumero ;
      private bool[] P00ER2_n939AgenciaNumero ;
      private string[] P00ER2_A969AgenciaBancoNome ;
      private bool[] P00ER2_n969AgenciaBancoNome ;
      private string[] P00ER2_A960ChavePIXUpdatedByName ;
      private bool[] P00ER2_n960ChavePIXUpdatedByName ;
      private string[] P00ER2_A958ChavePIXCreatedByName ;
      private bool[] P00ER2_n958ChavePIXCreatedByName ;
      private long[] P00ER2_A952ContaBancariaNumero ;
      private bool[] P00ER2_n952ContaBancariaNumero ;
      private bool[] P00ER2_A965ChavePIXPrincipal ;
      private bool[] P00ER2_n965ChavePIXPrincipal ;
      private bool[] P00ER2_A964ChavePIXStatus ;
      private bool[] P00ER2_n964ChavePIXStatus ;
      private string[] P00ER2_A962ChavePIXTipo ;
      private bool[] P00ER2_n962ChavePIXTipo ;
      private int[] P00ER2_A961ChavePIXId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV43GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class chavepixwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00ER2( IGxContext context ,
                                             string A962ChavePIXTipo ,
                                             GxSimpleCollection<string> AV104Chavepixwwds_28_tfchavepixtipo_sels ,
                                             string AV77Chavepixwwds_1_filterfulltext ,
                                             string AV78Chavepixwwds_2_dynamicfiltersselector1 ,
                                             string AV80Chavepixwwds_4_chavepixtipo1 ,
                                             short AV79Chavepixwwds_3_dynamicfiltersoperator1 ,
                                             long AV81Chavepixwwds_5_contabancarianumero1 ,
                                             string AV82Chavepixwwds_6_chavepixcreatedbyname1 ,
                                             string AV83Chavepixwwds_7_chavepixupdatedbyname1 ,
                                             bool AV84Chavepixwwds_8_dynamicfiltersenabled2 ,
                                             string AV85Chavepixwwds_9_dynamicfiltersselector2 ,
                                             string AV87Chavepixwwds_11_chavepixtipo2 ,
                                             short AV86Chavepixwwds_10_dynamicfiltersoperator2 ,
                                             long AV88Chavepixwwds_12_contabancarianumero2 ,
                                             string AV89Chavepixwwds_13_chavepixcreatedbyname2 ,
                                             string AV90Chavepixwwds_14_chavepixupdatedbyname2 ,
                                             bool AV91Chavepixwwds_15_dynamicfiltersenabled3 ,
                                             string AV92Chavepixwwds_16_dynamicfiltersselector3 ,
                                             string AV94Chavepixwwds_18_chavepixtipo3 ,
                                             short AV93Chavepixwwds_17_dynamicfiltersoperator3 ,
                                             long AV95Chavepixwwds_19_contabancarianumero3 ,
                                             string AV96Chavepixwwds_20_chavepixcreatedbyname3 ,
                                             string AV97Chavepixwwds_21_chavepixupdatedbyname3 ,
                                             string AV99Chavepixwwds_23_tfagenciabanconome_sel ,
                                             string AV98Chavepixwwds_22_tfagenciabanconome ,
                                             int AV100Chavepixwwds_24_tfagencianumero ,
                                             int AV101Chavepixwwds_25_tfagencianumero_to ,
                                             long AV102Chavepixwwds_26_tfcontabancarianumero ,
                                             long AV103Chavepixwwds_27_tfcontabancarianumero_to ,
                                             int AV104Chavepixwwds_28_tfchavepixtipo_sels_Count ,
                                             string AV106Chavepixwwds_30_tfchavepixconteudo_sel ,
                                             string AV105Chavepixwwds_29_tfchavepixconteudo ,
                                             short AV107Chavepixwwds_31_tfchavepixstatus_sel ,
                                             short AV108Chavepixwwds_32_tfchavepixprincipal_sel ,
                                             DateTime AV109Chavepixwwds_33_tfchavepixcreatedat ,
                                             DateTime AV110Chavepixwwds_34_tfchavepixcreatedat_to ,
                                             string AV112Chavepixwwds_36_tfchavepixcreatedbyname_sel ,
                                             string AV111Chavepixwwds_35_tfchavepixcreatedbyname ,
                                             DateTime AV113Chavepixwwds_37_tfchavepixupdatedat ,
                                             DateTime AV114Chavepixwwds_38_tfchavepixupdatedat_to ,
                                             string AV116Chavepixwwds_40_tfchavepixupdatedbyname_sel ,
                                             string AV115Chavepixwwds_39_tfchavepixupdatedbyname ,
                                             int AV74ContaBancariaId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             long A952ContaBancariaNumero ,
                                             string A963ChavePIXConteudo ,
                                             bool A964ChavePIXStatus ,
                                             bool A965ChavePIXPrincipal ,
                                             string A958ChavePIXCreatedByName ,
                                             string A960ChavePIXUpdatedByName ,
                                             DateTime A966ChavePIXCreatedAt ,
                                             DateTime A967ChavePIXUpdatedAt ,
                                             int A951ContaBancariaId ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[56];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T4.AgenciaId, T5.AgenciaBancoId AS AgenciaBancoId, T1.ChavePIXCreatedBy AS ChavePIXCreatedBy, T1.ChavePIXUpdatedBy AS ChavePIXUpdatedBy, T1.ContaBancariaId, T1.ChavePIXUpdatedAt, T1.ChavePIXCreatedAt, T1.ChavePIXConteudo, T5.AgenciaNumero, T6.BancoNome AS AgenciaBancoNome, T3.SecUserName AS ChavePIXUpdatedByName, T2.SecUserName AS ChavePIXCreatedByName, T4.ContaBancariaNumero, T1.ChavePIXPrincipal, T1.ChavePIXStatus, T1.ChavePIXTipo, T1.ChavePIXId FROM (((((ChavePIX T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.ChavePIXCreatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.ChavePIXUpdatedBy) LEFT JOIN ContaBancaria T4 ON T4.ContaBancariaId = T1.ContaBancariaId) LEFT JOIN Agencia T5 ON T5.AgenciaId = T4.AgenciaId) LEFT JOIN Banco T6 ON T6.BancoId = T5.AgenciaBancoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Chavepixwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T6.BancoNome) like '%' || LOWER(:lV77Chavepixwwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T5.AgenciaNumero,'999999999'), 2) like '%' || :lV77Chavepixwwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T4.ContaBancariaNumero,'999999999999999999'), 2) like '%' || :lV77Chavepixwwds_1_filterfulltext) or ( 'cpf' like '%' || LOWER(:lV77Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'CPF')) or ( 'cnpj' like '%' || LOWER(:lV77Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'CNPJ')) or ( 'telefone' like '%' || LOWER(:lV77Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'Telefone')) or ( 'e-mail' like '%' || LOWER(:lV77Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'Email')) or ( 'chave aleatória' like '%' || LOWER(:lV77Chavepixwwds_1_filterfulltext) and T1.ChavePIXTipo = ( 'ChaveAleatoria')) or ( LOWER(T1.ChavePIXConteudo) like '%' || LOWER(:lV77Chavepixwwds_1_filterfulltext)) or ( 'ativo' like '%' || LOWER(:lV77Chavepixwwds_1_filterfulltext) and T1.ChavePIXStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV77Chavepixwwds_1_filterfulltext) and T1.ChavePIXStatus = FALSE) or ( 'sim' like '%' || LOWER(:lV77Chavepixwwds_1_filterfulltext) and T1.ChavePIXPrincipal = TRUE) or ( 'não' like '%' || LOWER(:lV77Chavepixwwds_1_filterfulltext) and T1.ChavePIXPrincipal = FALSE) or ( LOWER(T2.SecUserName) like '%' || LOWER(:lV77Chavepixwwds_1_filterfulltext)) or ( LOWER(T3.SecUserName) like '%' || LOWER(:lV77Chavepixwwds_1_filterfulltext)))");
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
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
            GXv_int3[9] = 1;
            GXv_int3[10] = 1;
            GXv_int3[11] = 1;
            GXv_int3[12] = 1;
            GXv_int3[13] = 1;
            GXv_int3[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Chavepixwwds_4_chavepixtipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV80Chavepixwwds_4_chavepixtipo1))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV79Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV81Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV81Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV79Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV81Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV81Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Chavepixwwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV79Chavepixwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV81Chavepixwwds_5_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV81Chavepixwwds_5_contabancarianumero1)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV79Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Chavepixwwds_6_chavepixcreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV82Chavepixwwds_6_chavepixcreatedbyname1)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV79Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Chavepixwwds_6_chavepixcreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV82Chavepixwwds_6_chavepixcreatedbyname1)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV79Chavepixwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Chavepixwwds_7_chavepixupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV83Chavepixwwds_7_chavepixupdatedbyname1)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Chavepixwwds_2_dynamicfiltersselector1, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV79Chavepixwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Chavepixwwds_7_chavepixupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV83Chavepixwwds_7_chavepixupdatedbyname1)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV84Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Chavepixwwds_11_chavepixtipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV87Chavepixwwds_11_chavepixtipo2))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV84Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV88Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV88Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( AV84Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV88Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV88Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( AV84Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Chavepixwwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV86Chavepixwwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV88Chavepixwwds_12_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV88Chavepixwwds_12_contabancarianumero2)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( AV84Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Chavepixwwds_13_chavepixcreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV89Chavepixwwds_13_chavepixcreatedbyname2)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV84Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Chavepixwwds_13_chavepixcreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV89Chavepixwwds_13_chavepixcreatedbyname2)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( AV84Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Chavepixwwds_14_chavepixupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV90Chavepixwwds_14_chavepixupdatedbyname2)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( AV84Chavepixwwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Chavepixwwds_9_dynamicfiltersselector2, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV86Chavepixwwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Chavepixwwds_14_chavepixupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV90Chavepixwwds_14_chavepixupdatedbyname2)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( AV91Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Chavepixwwds_18_chavepixtipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXTipo = ( :AV94Chavepixwwds_18_chavepixtipo3))");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( AV91Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV95Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero < :AV95Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( AV91Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV95Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero = :AV95Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( AV91Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Chavepixwwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV93Chavepixwwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV95Chavepixwwds_19_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero > :AV95Chavepixwwds_19_contabancarianumero3)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( AV91Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Chavepixwwds_20_chavepixcreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV96Chavepixwwds_20_chavepixcreatedbyname3)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( AV91Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXCREATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Chavepixwwds_20_chavepixcreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV96Chavepixwwds_20_chavepixcreatedbyname3)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( AV91Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Chavepixwwds_21_chavepixupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV97Chavepixwwds_21_chavepixupdatedbyname3)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( AV91Chavepixwwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV92Chavepixwwds_16_dynamicfiltersselector3, "CHAVEPIXUPDATEDBYNAME") == 0 ) && ( AV93Chavepixwwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Chavepixwwds_21_chavepixupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV97Chavepixwwds_21_chavepixupdatedbyname3)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Chavepixwwds_23_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Chavepixwwds_22_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T6.BancoNome like :lV98Chavepixwwds_22_tfagenciabanconome)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Chavepixwwds_23_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV99Chavepixwwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T6.BancoNome = ( :AV99Chavepixwwds_23_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( StringUtil.StrCmp(AV99Chavepixwwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T6.BancoNome IS NULL or (char_length(trim(trailing ' ' from T6.BancoNome))=0))");
         }
         if ( ! (0==AV100Chavepixwwds_24_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T5.AgenciaNumero >= :AV100Chavepixwwds_24_tfagencianumero)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( ! (0==AV101Chavepixwwds_25_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T5.AgenciaNumero <= :AV101Chavepixwwds_25_tfagencianumero_to)");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( ! (0==AV102Chavepixwwds_26_tfcontabancarianumero) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero >= :AV102Chavepixwwds_26_tfcontabancarianumero)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( ! (0==AV103Chavepixwwds_27_tfcontabancarianumero_to) )
         {
            AddWhere(sWhereString, "(T4.ContaBancariaNumero <= :AV103Chavepixwwds_27_tfcontabancarianumero_to)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( AV104Chavepixwwds_28_tfchavepixtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV104Chavepixwwds_28_tfchavepixtipo_sels, "T1.ChavePIXTipo IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Chavepixwwds_30_tfchavepixconteudo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Chavepixwwds_29_tfchavepixconteudo)) ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo like :lV105Chavepixwwds_29_tfchavepixconteudo)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Chavepixwwds_30_tfchavepixconteudo_sel)) && ! ( StringUtil.StrCmp(AV106Chavepixwwds_30_tfchavepixconteudo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo = ( :AV106Chavepixwwds_30_tfchavepixconteudo_sel))");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( StringUtil.StrCmp(AV106Chavepixwwds_30_tfchavepixconteudo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXConteudo IS NULL or (char_length(trim(trailing ' ' from T1.ChavePIXConteudo))=0))");
         }
         if ( AV107Chavepixwwds_31_tfchavepixstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXStatus = TRUE)");
         }
         if ( AV107Chavepixwwds_31_tfchavepixstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXStatus = FALSE)");
         }
         if ( AV108Chavepixwwds_32_tfchavepixprincipal_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXPrincipal = TRUE)");
         }
         if ( AV108Chavepixwwds_32_tfchavepixprincipal_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ChavePIXPrincipal = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV109Chavepixwwds_33_tfchavepixcreatedat) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXCreatedAt >= :AV109Chavepixwwds_33_tfchavepixcreatedat)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( ! (DateTime.MinValue==AV110Chavepixwwds_34_tfchavepixcreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXCreatedAt <= :AV110Chavepixwwds_34_tfchavepixcreatedat_to)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Chavepixwwds_36_tfchavepixcreatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Chavepixwwds_35_tfchavepixcreatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV111Chavepixwwds_35_tfchavepixcreatedbyname)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Chavepixwwds_36_tfchavepixcreatedbyname_sel)) && ! ( StringUtil.StrCmp(AV112Chavepixwwds_36_tfchavepixcreatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV112Chavepixwwds_36_tfchavepixcreatedbyname_sel))");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( StringUtil.StrCmp(AV112Chavepixwwds_36_tfchavepixcreatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV113Chavepixwwds_37_tfchavepixupdatedat) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXUpdatedAt >= :AV113Chavepixwwds_37_tfchavepixupdatedat)");
         }
         else
         {
            GXv_int3[51] = 1;
         }
         if ( ! (DateTime.MinValue==AV114Chavepixwwds_38_tfchavepixupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ChavePIXUpdatedAt <= :AV114Chavepixwwds_38_tfchavepixupdatedat_to)");
         }
         else
         {
            GXv_int3[52] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Chavepixwwds_40_tfchavepixupdatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Chavepixwwds_39_tfchavepixupdatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV115Chavepixwwds_39_tfchavepixupdatedbyname)");
         }
         else
         {
            GXv_int3[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Chavepixwwds_40_tfchavepixupdatedbyname_sel)) && ! ( StringUtil.StrCmp(AV116Chavepixwwds_40_tfchavepixupdatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV116Chavepixwwds_40_tfchavepixupdatedbyname_sel))");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( StringUtil.StrCmp(AV116Chavepixwwds_40_tfchavepixupdatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( ! (0==AV74ContaBancariaId) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaId = :AV74ContaBancariaId)");
         }
         else
         {
            GXv_int3[55] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ChavePIXTipo";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ChavePIXTipo DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T6.BancoNome";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T6.BancoNome DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.AgenciaNumero";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.AgenciaNumero DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.ContaBancariaNumero";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.ContaBancariaNumero DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ChavePIXConteudo";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ChavePIXConteudo DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ChavePIXStatus";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ChavePIXStatus DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ChavePIXPrincipal";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ChavePIXPrincipal DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ChavePIXCreatedAt";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ChavePIXCreatedAt DESC";
         }
         else if ( ( AV16OrderedBy == 9 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.SecUserName";
         }
         else if ( ( AV16OrderedBy == 9 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.SecUserName DESC";
         }
         else if ( ( AV16OrderedBy == 10 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ChavePIXUpdatedAt";
         }
         else if ( ( AV16OrderedBy == 10 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ChavePIXUpdatedAt DESC";
         }
         else if ( ( AV16OrderedBy == 11 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.SecUserName";
         }
         else if ( ( AV16OrderedBy == 11 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.SecUserName DESC";
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
                     return conditional_P00ER2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (DateTime)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (int)dynConstraints[42] , (string)dynConstraints[43] , (int)dynConstraints[44] , (long)dynConstraints[45] , (string)dynConstraints[46] , (bool)dynConstraints[47] , (bool)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (bool)dynConstraints[55] );
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
          Object[] prmP00ER2;
          prmP00ER2 = new Object[] {
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV77Chavepixwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV80Chavepixwwds_4_chavepixtipo1",GXType.VarChar,40,0) ,
          new ParDef("AV81Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV81Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV81Chavepixwwds_5_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("lV82Chavepixwwds_6_chavepixcreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV82Chavepixwwds_6_chavepixcreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV83Chavepixwwds_7_chavepixupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV83Chavepixwwds_7_chavepixupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("AV87Chavepixwwds_11_chavepixtipo2",GXType.VarChar,40,0) ,
          new ParDef("AV88Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV88Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV88Chavepixwwds_12_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("lV89Chavepixwwds_13_chavepixcreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV89Chavepixwwds_13_chavepixcreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV90Chavepixwwds_14_chavepixupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV90Chavepixwwds_14_chavepixupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("AV94Chavepixwwds_18_chavepixtipo3",GXType.VarChar,40,0) ,
          new ParDef("AV95Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV95Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV95Chavepixwwds_19_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("lV96Chavepixwwds_20_chavepixcreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV96Chavepixwwds_20_chavepixcreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV97Chavepixwwds_21_chavepixupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV97Chavepixwwds_21_chavepixupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV98Chavepixwwds_22_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV99Chavepixwwds_23_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV100Chavepixwwds_24_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV101Chavepixwwds_25_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV102Chavepixwwds_26_tfcontabancarianumero",GXType.Int64,18,0) ,
          new ParDef("AV103Chavepixwwds_27_tfcontabancarianumero_to",GXType.Int64,18,0) ,
          new ParDef("lV105Chavepixwwds_29_tfchavepixconteudo",GXType.VarChar,100,0) ,
          new ParDef("AV106Chavepixwwds_30_tfchavepixconteudo_sel",GXType.VarChar,100,0) ,
          new ParDef("AV109Chavepixwwds_33_tfchavepixcreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV110Chavepixwwds_34_tfchavepixcreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV111Chavepixwwds_35_tfchavepixcreatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV112Chavepixwwds_36_tfchavepixcreatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV113Chavepixwwds_37_tfchavepixupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV114Chavepixwwds_38_tfchavepixupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV115Chavepixwwds_39_tfchavepixupdatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV116Chavepixwwds_40_tfchavepixupdatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV74ContaBancariaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00ER2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ER2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((long[]) buf[24])[0] = rslt.getLong(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((bool[]) buf[26])[0] = rslt.getBool(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((bool[]) buf[28])[0] = rslt.getBool(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((string[]) buf[30])[0] = rslt.getVarchar(16);
                ((bool[]) buf[31])[0] = rslt.wasNull(16);
                ((int[]) buf[32])[0] = rslt.getInt(17);
                return;
       }
    }

 }

}
