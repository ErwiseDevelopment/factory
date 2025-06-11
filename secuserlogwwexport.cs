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
   public class secuserlogwwexport : GXProcedure
   {
      public secuserlogwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserlogwwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "SecUserLogWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV33GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "SECUSERLOGDATETIME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV45SecUserLogDateTime1 = context.localUtil.CToT( AV33GridStateDynamicFilter.gxTpr_Value, 4);
               AV46SecUserLogDateTime_To1 = context.localUtil.CToT( AV33GridStateDynamicFilter.gxTpr_Valueto, 4);
               AV44PrintFilterValue = false;
               if ( ! (DateTime.MinValue==AV45SecUserLogDateTime1) || ! (DateTime.MinValue==AV46SecUserLogDateTime_To1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Date Time";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Passado";
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Date Time";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Hoje";
                  }
                  else if ( AV20DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Date Time";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "No futuro";
                  }
                  else if ( AV20DynamicFiltersOperator1 == 3 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Date Time", "Período", "", "", "", "", "", "", "");
                     AV44PrintFilterValue = true;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "até";
                  }
                  if ( AV44PrintFilterValue )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV45SecUserLogDateTime1;
                     if ( AV44PrintFilterValue )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Italic = 1;
                        AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV46SecUserLogDateTime_To1;
                     }
                  }
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV22SecUserName1 = AV33GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SecUserName1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22SecUserName1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERLOGDATETIME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV47SecUserLogDateTime2 = context.localUtil.CToT( AV33GridStateDynamicFilter.gxTpr_Value, 4);
                  AV48SecUserLogDateTime_To2 = context.localUtil.CToT( AV33GridStateDynamicFilter.gxTpr_Valueto, 4);
                  AV44PrintFilterValue = false;
                  if ( ! (DateTime.MinValue==AV47SecUserLogDateTime2) || ! (DateTime.MinValue==AV48SecUserLogDateTime_To2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Date Time";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Passado";
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Date Time";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Hoje";
                     }
                     else if ( AV25DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Date Time";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "No futuro";
                     }
                     else if ( AV25DynamicFiltersOperator2 == 3 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Date Time", "Período", "", "", "", "", "", "", "");
                        AV44PrintFilterValue = true;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "até";
                     }
                     if ( AV44PrintFilterValue )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV47SecUserLogDateTime2;
                        if ( AV44PrintFilterValue )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Italic = 1;
                           AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV48SecUserLogDateTime_To2;
                        }
                     }
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV27SecUserName2 = AV33GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27SecUserName2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27SecUserName2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV28DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(3));
                  AV29DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "SECUSERLOGDATETIME") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV49SecUserLogDateTime3 = context.localUtil.CToT( AV33GridStateDynamicFilter.gxTpr_Value, 4);
                     AV50SecUserLogDateTime_To3 = context.localUtil.CToT( AV33GridStateDynamicFilter.gxTpr_Valueto, 4);
                     AV44PrintFilterValue = false;
                     if ( ! (DateTime.MinValue==AV49SecUserLogDateTime3) || ! (DateTime.MinValue==AV50SecUserLogDateTime_To3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Date Time";
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Passado";
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Date Time";
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Hoje";
                        }
                        else if ( AV30DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Date Time";
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "No futuro";
                        }
                        else if ( AV30DynamicFiltersOperator3 == 3 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Date Time", "Período", "", "", "", "", "", "", "");
                           AV44PrintFilterValue = true;
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 3;
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "até";
                        }
                        if ( AV44PrintFilterValue )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                           AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV49SecUserLogDateTime3;
                           if ( AV44PrintFilterValue )
                           {
                              AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Italic = 1;
                              AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                              AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV50SecUserLogDateTime_To3;
                           }
                        }
                     }
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV32SecUserName3 = AV33GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32SecUserName3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV32SecUserName3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecUserName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Usuário") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecUserName_Sel)) ? "(Vazio)" : AV39TFSecUserName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecUserName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Usuário") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFSecUserName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecUserFullName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecUserFullName_Sel)) ? "(Vazio)" : AV41TFSecUserFullName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecUserFullName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFSecUserFullName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV42TFSecUserLogDateTime) && (DateTime.MinValue==AV43TFSecUserLogDateTime_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Data") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV42TFSecUserLogDateTime;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV43TFSecUserLogDateTime_To;
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Usuário";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Nome";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Data";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV52Secuserlogwwds_1_filterfulltext = AV18FilterFullText;
         AV53Secuserlogwwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV54Secuserlogwwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV55Secuserlogwwds_4_secuserlogdatetime1 = AV45SecUserLogDateTime1;
         AV56Secuserlogwwds_5_secuserlogdatetime_to1 = AV46SecUserLogDateTime_To1;
         AV57Secuserlogwwds_6_secusername1 = AV22SecUserName1;
         AV58Secuserlogwwds_7_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV59Secuserlogwwds_8_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV60Secuserlogwwds_9_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV61Secuserlogwwds_10_secuserlogdatetime2 = AV47SecUserLogDateTime2;
         AV62Secuserlogwwds_11_secuserlogdatetime_to2 = AV48SecUserLogDateTime_To2;
         AV63Secuserlogwwds_12_secusername2 = AV27SecUserName2;
         AV64Secuserlogwwds_13_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV65Secuserlogwwds_14_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV66Secuserlogwwds_15_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV67Secuserlogwwds_16_secuserlogdatetime3 = AV49SecUserLogDateTime3;
         AV68Secuserlogwwds_17_secuserlogdatetime_to3 = AV50SecUserLogDateTime_To3;
         AV69Secuserlogwwds_18_secusername3 = AV32SecUserName3;
         AV70Secuserlogwwds_19_tfsecusername = AV38TFSecUserName;
         AV71Secuserlogwwds_20_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV72Secuserlogwwds_21_tfsecuserfullname = AV40TFSecUserFullName;
         AV73Secuserlogwwds_22_tfsecuserfullname_sel = AV41TFSecUserFullName_Sel;
         AV74Secuserlogwwds_23_tfsecuserlogdatetime = AV42TFSecUserLogDateTime;
         AV75Secuserlogwwds_24_tfsecuserlogdatetime_to = AV43TFSecUserLogDateTime_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV52Secuserlogwwds_1_filterfulltext ,
                                              AV53Secuserlogwwds_2_dynamicfiltersselector1 ,
                                              AV54Secuserlogwwds_3_dynamicfiltersoperator1 ,
                                              AV55Secuserlogwwds_4_secuserlogdatetime1 ,
                                              AV56Secuserlogwwds_5_secuserlogdatetime_to1 ,
                                              AV57Secuserlogwwds_6_secusername1 ,
                                              AV58Secuserlogwwds_7_dynamicfiltersenabled2 ,
                                              AV59Secuserlogwwds_8_dynamicfiltersselector2 ,
                                              AV60Secuserlogwwds_9_dynamicfiltersoperator2 ,
                                              AV61Secuserlogwwds_10_secuserlogdatetime2 ,
                                              AV62Secuserlogwwds_11_secuserlogdatetime_to2 ,
                                              AV63Secuserlogwwds_12_secusername2 ,
                                              AV64Secuserlogwwds_13_dynamicfiltersenabled3 ,
                                              AV65Secuserlogwwds_14_dynamicfiltersselector3 ,
                                              AV66Secuserlogwwds_15_dynamicfiltersoperator3 ,
                                              AV67Secuserlogwwds_16_secuserlogdatetime3 ,
                                              AV68Secuserlogwwds_17_secuserlogdatetime_to3 ,
                                              AV69Secuserlogwwds_18_secusername3 ,
                                              AV71Secuserlogwwds_20_tfsecusername_sel ,
                                              AV70Secuserlogwwds_19_tfsecusername ,
                                              AV73Secuserlogwwds_22_tfsecuserfullname_sel ,
                                              AV72Secuserlogwwds_21_tfsecuserfullname ,
                                              AV74Secuserlogwwds_23_tfsecuserlogdatetime ,
                                              AV75Secuserlogwwds_24_tfsecuserlogdatetime_to ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A560SecUserLogDateTime ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Secuserlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Secuserlogwwds_1_filterfulltext), "%", "");
         lV52Secuserlogwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV52Secuserlogwwds_1_filterfulltext), "%", "");
         lV57Secuserlogwwds_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV57Secuserlogwwds_6_secusername1), "%", "");
         lV57Secuserlogwwds_6_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV57Secuserlogwwds_6_secusername1), "%", "");
         lV63Secuserlogwwds_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV63Secuserlogwwds_12_secusername2), "%", "");
         lV63Secuserlogwwds_12_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV63Secuserlogwwds_12_secusername2), "%", "");
         lV69Secuserlogwwds_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV69Secuserlogwwds_18_secusername3), "%", "");
         lV69Secuserlogwwds_18_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV69Secuserlogwwds_18_secusername3), "%", "");
         lV70Secuserlogwwds_19_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV70Secuserlogwwds_19_tfsecusername), "%", "");
         lV72Secuserlogwwds_21_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV72Secuserlogwwds_21_tfsecuserfullname), "%", "");
         /* Using cursor P00AZ2 */
         pr_default.execute(0, new Object[] {lV52Secuserlogwwds_1_filterfulltext, lV52Secuserlogwwds_1_filterfulltext, AV55Secuserlogwwds_4_secuserlogdatetime1, AV55Secuserlogwwds_4_secuserlogdatetime1, AV56Secuserlogwwds_5_secuserlogdatetime_to1, AV56Secuserlogwwds_5_secuserlogdatetime_to1, lV57Secuserlogwwds_6_secusername1, lV57Secuserlogwwds_6_secusername1, AV61Secuserlogwwds_10_secuserlogdatetime2, AV61Secuserlogwwds_10_secuserlogdatetime2, AV62Secuserlogwwds_11_secuserlogdatetime_to2, AV62Secuserlogwwds_11_secuserlogdatetime_to2, lV63Secuserlogwwds_12_secusername2, lV63Secuserlogwwds_12_secusername2, AV67Secuserlogwwds_16_secuserlogdatetime3, AV67Secuserlogwwds_16_secuserlogdatetime3, AV68Secuserlogwwds_17_secuserlogdatetime_to3, AV68Secuserlogwwds_17_secuserlogdatetime_to3, lV69Secuserlogwwds_18_secusername3, lV69Secuserlogwwds_18_secusername3, lV70Secuserlogwwds_19_tfsecusername, AV71Secuserlogwwds_20_tfsecusername_sel, lV72Secuserlogwwds_21_tfsecuserfullname, AV73Secuserlogwwds_22_tfsecuserfullname_sel, AV74Secuserlogwwds_23_tfsecuserlogdatetime, AV75Secuserlogwwds_24_tfsecuserlogdatetime_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133SecUserId = P00AZ2_A133SecUserId[0];
            n133SecUserId = P00AZ2_n133SecUserId[0];
            A560SecUserLogDateTime = P00AZ2_A560SecUserLogDateTime[0];
            n560SecUserLogDateTime = P00AZ2_n560SecUserLogDateTime[0];
            A143SecUserFullName = P00AZ2_A143SecUserFullName[0];
            n143SecUserFullName = P00AZ2_n143SecUserFullName[0];
            A141SecUserName = P00AZ2_A141SecUserName[0];
            n141SecUserName = P00AZ2_n141SecUserName[0];
            A559SecUserLogId = P00AZ2_A559SecUserLogId[0];
            A143SecUserFullName = P00AZ2_A143SecUserFullName[0];
            n143SecUserFullName = P00AZ2_n143SecUserFullName[0];
            A141SecUserName = P00AZ2_A141SecUserName[0];
            n141SecUserName = P00AZ2_n141SecUserName[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A141SecUserName, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A143SecUserFullName, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Date = A560SecUserLogDateTime;
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
         AV34Session.Set("WWPExportFilePath", AV11Filename);
         AV34Session.Set("WWPExportFileName", "SecUserLogWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV34Session.Get("SecUserLogWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SecUserLogWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("SecUserLogWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV36GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV36GridState.gxTpr_Ordereddsc;
         AV76GXV1 = 1;
         while ( AV76GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV76GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV38TFSecUserName = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV39TFSecUserName_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV40TFSecUserFullName = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV41TFSecUserFullName_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECUSERLOGDATETIME") == 0 )
            {
               AV42TFSecUserLogDateTime = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Value, 4);
               AV43TFSecUserLogDateTime_To = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Valueto, 4);
            }
            AV76GXV1 = (int)(AV76GXV1+1);
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
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV45SecUserLogDateTime1 = (DateTime)(DateTime.MinValue);
         AV46SecUserLogDateTime_To1 = (DateTime)(DateTime.MinValue);
         AV22SecUserName1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV47SecUserLogDateTime2 = (DateTime)(DateTime.MinValue);
         AV48SecUserLogDateTime_To2 = (DateTime)(DateTime.MinValue);
         AV27SecUserName2 = "";
         AV29DynamicFiltersSelector3 = "";
         AV49SecUserLogDateTime3 = (DateTime)(DateTime.MinValue);
         AV50SecUserLogDateTime_To3 = (DateTime)(DateTime.MinValue);
         AV32SecUserName3 = "";
         AV39TFSecUserName_Sel = "";
         AV38TFSecUserName = "";
         AV41TFSecUserFullName_Sel = "";
         AV40TFSecUserFullName = "";
         AV42TFSecUserLogDateTime = (DateTime)(DateTime.MinValue);
         AV43TFSecUserLogDateTime_To = (DateTime)(DateTime.MinValue);
         AV52Secuserlogwwds_1_filterfulltext = "";
         AV53Secuserlogwwds_2_dynamicfiltersselector1 = "";
         AV55Secuserlogwwds_4_secuserlogdatetime1 = (DateTime)(DateTime.MinValue);
         AV56Secuserlogwwds_5_secuserlogdatetime_to1 = (DateTime)(DateTime.MinValue);
         AV57Secuserlogwwds_6_secusername1 = "";
         AV59Secuserlogwwds_8_dynamicfiltersselector2 = "";
         AV61Secuserlogwwds_10_secuserlogdatetime2 = (DateTime)(DateTime.MinValue);
         AV62Secuserlogwwds_11_secuserlogdatetime_to2 = (DateTime)(DateTime.MinValue);
         AV63Secuserlogwwds_12_secusername2 = "";
         AV65Secuserlogwwds_14_dynamicfiltersselector3 = "";
         AV67Secuserlogwwds_16_secuserlogdatetime3 = (DateTime)(DateTime.MinValue);
         AV68Secuserlogwwds_17_secuserlogdatetime_to3 = (DateTime)(DateTime.MinValue);
         AV69Secuserlogwwds_18_secusername3 = "";
         AV70Secuserlogwwds_19_tfsecusername = "";
         AV71Secuserlogwwds_20_tfsecusername_sel = "";
         AV72Secuserlogwwds_21_tfsecuserfullname = "";
         AV73Secuserlogwwds_22_tfsecuserfullname_sel = "";
         AV74Secuserlogwwds_23_tfsecuserlogdatetime = (DateTime)(DateTime.MinValue);
         AV75Secuserlogwwds_24_tfsecuserlogdatetime_to = (DateTime)(DateTime.MinValue);
         lV52Secuserlogwwds_1_filterfulltext = "";
         lV57Secuserlogwwds_6_secusername1 = "";
         lV63Secuserlogwwds_12_secusername2 = "";
         lV69Secuserlogwwds_18_secusername3 = "";
         lV70Secuserlogwwds_19_tfsecusername = "";
         lV72Secuserlogwwds_21_tfsecuserfullname = "";
         A141SecUserName = "";
         A143SecUserFullName = "";
         A560SecUserLogDateTime = (DateTime)(DateTime.MinValue);
         P00AZ2_A133SecUserId = new short[1] ;
         P00AZ2_n133SecUserId = new bool[] {false} ;
         P00AZ2_A560SecUserLogDateTime = new DateTime[] {DateTime.MinValue} ;
         P00AZ2_n560SecUserLogDateTime = new bool[] {false} ;
         P00AZ2_A143SecUserFullName = new string[] {""} ;
         P00AZ2_n143SecUserFullName = new bool[] {false} ;
         P00AZ2_A141SecUserName = new string[] {""} ;
         P00AZ2_n141SecUserName = new bool[] {false} ;
         P00AZ2_A559SecUserLogId = new int[1] ;
         GXt_char1 = "";
         AV34Session = context.GetSession();
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secuserlogwwexport__default(),
            new Object[][] {
                new Object[] {
               P00AZ2_A133SecUserId, P00AZ2_n133SecUserId, P00AZ2_A560SecUserLogDateTime, P00AZ2_n560SecUserLogDateTime, P00AZ2_A143SecUserFullName, P00AZ2_n143SecUserFullName, P00AZ2_A141SecUserName, P00AZ2_n141SecUserName, P00AZ2_A559SecUserLogId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV30DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV54Secuserlogwwds_3_dynamicfiltersoperator1 ;
      private short AV60Secuserlogwwds_9_dynamicfiltersoperator2 ;
      private short AV66Secuserlogwwds_15_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private short A133SecUserId ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A559SecUserLogId ;
      private int AV76GXV1 ;
      private string GXt_char1 ;
      private DateTime AV45SecUserLogDateTime1 ;
      private DateTime AV46SecUserLogDateTime_To1 ;
      private DateTime AV47SecUserLogDateTime2 ;
      private DateTime AV48SecUserLogDateTime_To2 ;
      private DateTime AV49SecUserLogDateTime3 ;
      private DateTime AV50SecUserLogDateTime_To3 ;
      private DateTime AV42TFSecUserLogDateTime ;
      private DateTime AV43TFSecUserLogDateTime_To ;
      private DateTime AV55Secuserlogwwds_4_secuserlogdatetime1 ;
      private DateTime AV56Secuserlogwwds_5_secuserlogdatetime_to1 ;
      private DateTime AV61Secuserlogwwds_10_secuserlogdatetime2 ;
      private DateTime AV62Secuserlogwwds_11_secuserlogdatetime_to2 ;
      private DateTime AV67Secuserlogwwds_16_secuserlogdatetime3 ;
      private DateTime AV68Secuserlogwwds_17_secuserlogdatetime_to3 ;
      private DateTime AV74Secuserlogwwds_23_tfsecuserlogdatetime ;
      private DateTime AV75Secuserlogwwds_24_tfsecuserlogdatetime_to ;
      private DateTime A560SecUserLogDateTime ;
      private bool returnInSub ;
      private bool AV44PrintFilterValue ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV28DynamicFiltersEnabled3 ;
      private bool AV58Secuserlogwwds_7_dynamicfiltersenabled2 ;
      private bool AV64Secuserlogwwds_13_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n133SecUserId ;
      private bool n560SecUserLogDateTime ;
      private bool n143SecUserFullName ;
      private bool n141SecUserName ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV22SecUserName1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV27SecUserName2 ;
      private string AV29DynamicFiltersSelector3 ;
      private string AV32SecUserName3 ;
      private string AV39TFSecUserName_Sel ;
      private string AV38TFSecUserName ;
      private string AV41TFSecUserFullName_Sel ;
      private string AV40TFSecUserFullName ;
      private string AV52Secuserlogwwds_1_filterfulltext ;
      private string AV53Secuserlogwwds_2_dynamicfiltersselector1 ;
      private string AV57Secuserlogwwds_6_secusername1 ;
      private string AV59Secuserlogwwds_8_dynamicfiltersselector2 ;
      private string AV63Secuserlogwwds_12_secusername2 ;
      private string AV65Secuserlogwwds_14_dynamicfiltersselector3 ;
      private string AV69Secuserlogwwds_18_secusername3 ;
      private string AV70Secuserlogwwds_19_tfsecusername ;
      private string AV71Secuserlogwwds_20_tfsecusername_sel ;
      private string AV72Secuserlogwwds_21_tfsecuserfullname ;
      private string AV73Secuserlogwwds_22_tfsecuserfullname_sel ;
      private string lV52Secuserlogwwds_1_filterfulltext ;
      private string lV57Secuserlogwwds_6_secusername1 ;
      private string lV63Secuserlogwwds_12_secusername2 ;
      private string lV69Secuserlogwwds_18_secusername3 ;
      private string lV70Secuserlogwwds_19_tfsecusername ;
      private string lV72Secuserlogwwds_21_tfsecuserfullname ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private IGxSession AV34Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV33GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P00AZ2_A133SecUserId ;
      private bool[] P00AZ2_n133SecUserId ;
      private DateTime[] P00AZ2_A560SecUserLogDateTime ;
      private bool[] P00AZ2_n560SecUserLogDateTime ;
      private string[] P00AZ2_A143SecUserFullName ;
      private bool[] P00AZ2_n143SecUserFullName ;
      private string[] P00AZ2_A141SecUserName ;
      private bool[] P00AZ2_n141SecUserName ;
      private int[] P00AZ2_A559SecUserLogId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class secuserlogwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AZ2( IGxContext context ,
                                             string AV52Secuserlogwwds_1_filterfulltext ,
                                             string AV53Secuserlogwwds_2_dynamicfiltersselector1 ,
                                             short AV54Secuserlogwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV55Secuserlogwwds_4_secuserlogdatetime1 ,
                                             DateTime AV56Secuserlogwwds_5_secuserlogdatetime_to1 ,
                                             string AV57Secuserlogwwds_6_secusername1 ,
                                             bool AV58Secuserlogwwds_7_dynamicfiltersenabled2 ,
                                             string AV59Secuserlogwwds_8_dynamicfiltersselector2 ,
                                             short AV60Secuserlogwwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV61Secuserlogwwds_10_secuserlogdatetime2 ,
                                             DateTime AV62Secuserlogwwds_11_secuserlogdatetime_to2 ,
                                             string AV63Secuserlogwwds_12_secusername2 ,
                                             bool AV64Secuserlogwwds_13_dynamicfiltersenabled3 ,
                                             string AV65Secuserlogwwds_14_dynamicfiltersselector3 ,
                                             short AV66Secuserlogwwds_15_dynamicfiltersoperator3 ,
                                             DateTime AV67Secuserlogwwds_16_secuserlogdatetime3 ,
                                             DateTime AV68Secuserlogwwds_17_secuserlogdatetime_to3 ,
                                             string AV69Secuserlogwwds_18_secusername3 ,
                                             string AV71Secuserlogwwds_20_tfsecusername_sel ,
                                             string AV70Secuserlogwwds_19_tfsecusername ,
                                             string AV73Secuserlogwwds_22_tfsecuserfullname_sel ,
                                             string AV72Secuserlogwwds_21_tfsecuserfullname ,
                                             DateTime AV74Secuserlogwwds_23_tfsecuserlogdatetime ,
                                             DateTime AV75Secuserlogwwds_24_tfsecuserlogdatetime_to ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             DateTime A560SecUserLogDateTime ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[26];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecUserId, T1.SecUserLogDateTime, T2.SecUserFullName, T2.SecUserName, T1.SecUserLogId FROM (SecUserLog T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Secuserlogwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecUserName like '%' || :lV52Secuserlogwwds_1_filterfulltext) or ( T2.SecUserFullName like '%' || :lV52Secuserlogwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV54Secuserlogwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV55Secuserlogwwds_4_secuserlogdatetime1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV55Secuserlogwwds_4_secuserlogdatetime1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( ( AV54Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) || ( AV54Secuserlogwwds_3_dynamicfiltersoperator1 == 2 ) || ( AV54Secuserlogwwds_3_dynamicfiltersoperator1 == 3 ) ) && ( ! (DateTime.MinValue==AV55Secuserlogwwds_4_secuserlogdatetime1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV55Secuserlogwwds_4_secuserlogdatetime1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV54Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV56Secuserlogwwds_5_secuserlogdatetime_to1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV56Secuserlogwwds_5_secuserlogdatetime_to1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERLOGDATETIME") == 0 ) && ( AV54Secuserlogwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV56Secuserlogwwds_5_secuserlogdatetime_to1) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV56Secuserlogwwds_5_secuserlogdatetime_to1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV54Secuserlogwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Secuserlogwwds_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV57Secuserlogwwds_6_secusername1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Secuserlogwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV54Secuserlogwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Secuserlogwwds_6_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV57Secuserlogwwds_6_secusername1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV58Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV60Secuserlogwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV61Secuserlogwwds_10_secuserlogdatetime2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV61Secuserlogwwds_10_secuserlogdatetime2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV58Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( ( AV60Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) || ( AV60Secuserlogwwds_9_dynamicfiltersoperator2 == 2 ) || ( AV60Secuserlogwwds_9_dynamicfiltersoperator2 == 3 ) ) && ( ! (DateTime.MinValue==AV61Secuserlogwwds_10_secuserlogdatetime2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV61Secuserlogwwds_10_secuserlogdatetime2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV58Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV60Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV62Secuserlogwwds_11_secuserlogdatetime_to2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV62Secuserlogwwds_11_secuserlogdatetime_to2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV58Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERLOGDATETIME") == 0 ) && ( AV60Secuserlogwwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV62Secuserlogwwds_11_secuserlogdatetime_to2) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV62Secuserlogwwds_11_secuserlogdatetime_to2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV58Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV60Secuserlogwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Secuserlogwwds_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV63Secuserlogwwds_12_secusername2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV58Secuserlogwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Secuserlogwwds_8_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV60Secuserlogwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Secuserlogwwds_12_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV63Secuserlogwwds_12_secusername2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV64Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV66Secuserlogwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV67Secuserlogwwds_16_secuserlogdatetime3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV67Secuserlogwwds_16_secuserlogdatetime3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV64Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( ( AV66Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) || ( AV66Secuserlogwwds_15_dynamicfiltersoperator3 == 2 ) || ( AV66Secuserlogwwds_15_dynamicfiltersoperator3 == 3 ) ) && ( ! (DateTime.MinValue==AV67Secuserlogwwds_16_secuserlogdatetime3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV67Secuserlogwwds_16_secuserlogdatetime3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV64Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV66Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV68Secuserlogwwds_17_secuserlogdatetime_to3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime < :AV68Secuserlogwwds_17_secuserlogdatetime_to3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV64Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERLOGDATETIME") == 0 ) && ( AV66Secuserlogwwds_15_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV68Secuserlogwwds_17_secuserlogdatetime_to3) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV68Secuserlogwwds_17_secuserlogdatetime_to3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV64Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV66Secuserlogwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Secuserlogwwds_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV69Secuserlogwwds_18_secusername3)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV64Secuserlogwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Secuserlogwwds_14_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV66Secuserlogwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Secuserlogwwds_18_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV69Secuserlogwwds_18_secusername3)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Secuserlogwwds_20_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Secuserlogwwds_19_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV70Secuserlogwwds_19_tfsecusername)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Secuserlogwwds_20_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV71Secuserlogwwds_20_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV71Secuserlogwwds_20_tfsecusername_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV71Secuserlogwwds_20_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Secuserlogwwds_22_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Secuserlogwwds_21_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName like :lV72Secuserlogwwds_21_tfsecuserfullname)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Secuserlogwwds_22_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV73Secuserlogwwds_22_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName = ( :AV73Secuserlogwwds_22_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV73Secuserlogwwds_22_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserFullName))=0))");
         }
         if ( ! (DateTime.MinValue==AV74Secuserlogwwds_23_tfsecuserlogdatetime) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime >= :AV74Secuserlogwwds_23_tfsecuserlogdatetime)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV75Secuserlogwwds_24_tfsecuserlogdatetime_to) )
         {
            AddWhere(sWhereString, "(T1.SecUserLogDateTime <= :AV75Secuserlogwwds_24_tfsecuserlogdatetime_to)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecUserLogDateTime";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecUserLogDateTime DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.SecUserName";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.SecUserName DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.SecUserFullName";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.SecUserFullName DESC";
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
                     return conditional_P00AZ2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
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
          Object[] prmP00AZ2;
          prmP00AZ2 = new Object[] {
          new ParDef("lV52Secuserlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV52Secuserlogwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV55Secuserlogwwds_4_secuserlogdatetime1",GXType.DateTime,10,5) ,
          new ParDef("AV55Secuserlogwwds_4_secuserlogdatetime1",GXType.DateTime,10,5) ,
          new ParDef("AV56Secuserlogwwds_5_secuserlogdatetime_to1",GXType.DateTime,10,5) ,
          new ParDef("AV56Secuserlogwwds_5_secuserlogdatetime_to1",GXType.DateTime,10,5) ,
          new ParDef("lV57Secuserlogwwds_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV57Secuserlogwwds_6_secusername1",GXType.VarChar,100,0) ,
          new ParDef("AV61Secuserlogwwds_10_secuserlogdatetime2",GXType.DateTime,10,5) ,
          new ParDef("AV61Secuserlogwwds_10_secuserlogdatetime2",GXType.DateTime,10,5) ,
          new ParDef("AV62Secuserlogwwds_11_secuserlogdatetime_to2",GXType.DateTime,10,5) ,
          new ParDef("AV62Secuserlogwwds_11_secuserlogdatetime_to2",GXType.DateTime,10,5) ,
          new ParDef("lV63Secuserlogwwds_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV63Secuserlogwwds_12_secusername2",GXType.VarChar,100,0) ,
          new ParDef("AV67Secuserlogwwds_16_secuserlogdatetime3",GXType.DateTime,10,5) ,
          new ParDef("AV67Secuserlogwwds_16_secuserlogdatetime3",GXType.DateTime,10,5) ,
          new ParDef("AV68Secuserlogwwds_17_secuserlogdatetime_to3",GXType.DateTime,10,5) ,
          new ParDef("AV68Secuserlogwwds_17_secuserlogdatetime_to3",GXType.DateTime,10,5) ,
          new ParDef("lV69Secuserlogwwds_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV69Secuserlogwwds_18_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV70Secuserlogwwds_19_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV71Secuserlogwwds_20_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV72Secuserlogwwds_21_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV73Secuserlogwwds_22_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("AV74Secuserlogwwds_23_tfsecuserlogdatetime",GXType.DateTime,10,5) ,
          new ParDef("AV75Secuserlogwwds_24_tfsecuserlogdatetime_to",GXType.DateTime,10,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00AZ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AZ2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
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
