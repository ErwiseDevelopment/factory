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
   public class contabancariawwexport : GXProcedure
   {
      public contabancariawwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contabancariawwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "ContaBancariaWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV40GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CONTABANCARIANUMERO") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV22ContaBancariaNumero1 = (long)(Math.Round(NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV22ContaBancariaNumero1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", ">", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV22ContaBancariaNumero1;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "AGENCIANUMERO") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV23AgenciaNumero1 = (int)(Math.Round(NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV23AgenciaNumero1) )
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
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV23AgenciaNumero1;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CONTABANCARIACREATEDBYNAME") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV24ContaBancariaCreatedByName1 = AV40GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ContaBancariaCreatedByName1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Criado por", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Criado por", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24ContaBancariaCreatedByName1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "CONTABANCARIAUPDATEDBYNAME") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV25ContaBancariaUpdatedByName1 = AV40GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ContaBancariaUpdatedByName1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "By Name", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "By Name", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25ContaBancariaUpdatedByName1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV26DynamicFiltersEnabled2 = true;
               AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(2));
               AV27DynamicFiltersSelector2 = AV40GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "CONTABANCARIANUMERO") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV29ContaBancariaNumero2 = (long)(Math.Round(NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV29ContaBancariaNumero2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV29ContaBancariaNumero2;
                  }
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "AGENCIANUMERO") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV30AgenciaNumero2 = (int)(Math.Round(NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV30AgenciaNumero2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", ">", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV30AgenciaNumero2;
                  }
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "CONTABANCARIACREATEDBYNAME") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV31ContaBancariaCreatedByName2 = AV40GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31ContaBancariaCreatedByName2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Criado por", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Criado por", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV31ContaBancariaCreatedByName2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector2, "CONTABANCARIAUPDATEDBYNAME") == 0 )
               {
                  AV28DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV32ContaBancariaUpdatedByName2 = AV40GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32ContaBancariaUpdatedByName2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV28DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "By Name", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV28DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "By Name", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV32ContaBancariaUpdatedByName2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV33DynamicFiltersEnabled3 = true;
                  AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(3));
                  AV34DynamicFiltersSelector3 = AV40GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV34DynamicFiltersSelector3, "CONTABANCARIANUMERO") == 0 )
                  {
                     AV35DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV36ContaBancariaNumero3 = (long)(Math.Round(NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV36ContaBancariaNumero3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV35DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Número", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV36ContaBancariaNumero3;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV34DynamicFiltersSelector3, "AGENCIANUMERO") == 0 )
                  {
                     AV35DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV37AgenciaNumero3 = (int)(Math.Round(NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV37AgenciaNumero3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV35DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Agência", ">", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV37AgenciaNumero3;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV34DynamicFiltersSelector3, "CONTABANCARIACREATEDBYNAME") == 0 )
                  {
                     AV35DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV38ContaBancariaCreatedByName3 = AV40GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38ContaBancariaCreatedByName3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV35DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Criado por", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Criado por", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38ContaBancariaCreatedByName3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV34DynamicFiltersSelector3, "CONTABANCARIAUPDATEDBYNAME") == 0 )
                  {
                     AV35DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV39ContaBancariaUpdatedByName3 = AV40GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39ContaBancariaUpdatedByName3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV35DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "By Name", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV35DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "By Name", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39ContaBancariaUpdatedByName3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFAgenciaBancoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Banco") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV63TFAgenciaBancoNome_Sel)) ? "(Vazio)" : AV63TFAgenciaBancoNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFAgenciaBancoNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Banco") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62TFAgenciaBancoNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV47TFAgenciaNumero) && (0==AV48TFAgenciaNumero_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Agência") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV47TFAgenciaNumero;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV48TFAgenciaNumero_To;
         }
         if ( ! ( (0==AV49TFContaBancariaNumero) && (0==AV50TFContaBancariaNumero_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Conta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV49TFContaBancariaNumero;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV50TFContaBancariaNumero_To;
         }
         if ( ! ( (0==AV65TFContaBancariaDigito) && (0==AV66TFContaBancariaDigito_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Dígito") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV65TFContaBancariaDigito;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV66TFContaBancariaDigito_To;
         }
         if ( ! ( (0==AV51TFContaBancariaCarteira) && (0==AV52TFContaBancariaCarteira_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Carteira") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV51TFContaBancariaCarteira;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV52TFContaBancariaCarteira_To;
         }
         if ( ! ( (0==AV53TFContaBancariaStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV53TFContaBancariaStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV53TFContaBancariaStatus_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (DateTime.MinValue==AV54TFContaBancariaCreatedAt) && (DateTime.MinValue==AV55TFContaBancariaCreatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Criado em") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV54TFContaBancariaCreatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV55TFContaBancariaCreatedAt_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFContaBancariaCreatedByName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Criado por") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV57TFContaBancariaCreatedByName_Sel)) ? "(Vazio)" : AV57TFContaBancariaCreatedByName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFContaBancariaCreatedByName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Criado por") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFContaBancariaCreatedByName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV58TFContaBancariaUpdatedAt) && (DateTime.MinValue==AV59TFContaBancariaUpdatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Atualizado em") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV58TFContaBancariaUpdatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV59TFContaBancariaUpdatedAt_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV61TFContaBancariaUpdatedByName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Atualizado por") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV61TFContaBancariaUpdatedByName_Sel)) ? "(Vazio)" : AV61TFContaBancariaUpdatedByName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV60TFContaBancariaUpdatedByName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Atualizado por") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV60TFContaBancariaUpdatedByName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV64TFContaBancariaRegistraBoletos_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Usa para registro de boletos?") ;
            AV13CellRow = GXt_int2;
            if ( AV64TFContaBancariaRegistraBoletos_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV64TFContaBancariaRegistraBoletos_Sel == 2 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Banco";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Agência";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Conta";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Dígito";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Carteira";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Status";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Criado em";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Criado por";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "Atualizado em";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Text = "Atualizado por";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Text = "Usa para registro de boletos?";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV68Contabancariawwds_1_filterfulltext = AV19FilterFullText;
         AV69Contabancariawwds_2_dynamicfiltersselector1 = AV20DynamicFiltersSelector1;
         AV70Contabancariawwds_3_dynamicfiltersoperator1 = AV21DynamicFiltersOperator1;
         AV71Contabancariawwds_4_contabancarianumero1 = AV22ContaBancariaNumero1;
         AV72Contabancariawwds_5_agencianumero1 = AV23AgenciaNumero1;
         AV73Contabancariawwds_6_contabancariacreatedbyname1 = AV24ContaBancariaCreatedByName1;
         AV74Contabancariawwds_7_contabancariaupdatedbyname1 = AV25ContaBancariaUpdatedByName1;
         AV75Contabancariawwds_8_dynamicfiltersenabled2 = AV26DynamicFiltersEnabled2;
         AV76Contabancariawwds_9_dynamicfiltersselector2 = AV27DynamicFiltersSelector2;
         AV77Contabancariawwds_10_dynamicfiltersoperator2 = AV28DynamicFiltersOperator2;
         AV78Contabancariawwds_11_contabancarianumero2 = AV29ContaBancariaNumero2;
         AV79Contabancariawwds_12_agencianumero2 = AV30AgenciaNumero2;
         AV80Contabancariawwds_13_contabancariacreatedbyname2 = AV31ContaBancariaCreatedByName2;
         AV81Contabancariawwds_14_contabancariaupdatedbyname2 = AV32ContaBancariaUpdatedByName2;
         AV82Contabancariawwds_15_dynamicfiltersenabled3 = AV33DynamicFiltersEnabled3;
         AV83Contabancariawwds_16_dynamicfiltersselector3 = AV34DynamicFiltersSelector3;
         AV84Contabancariawwds_17_dynamicfiltersoperator3 = AV35DynamicFiltersOperator3;
         AV85Contabancariawwds_18_contabancarianumero3 = AV36ContaBancariaNumero3;
         AV86Contabancariawwds_19_agencianumero3 = AV37AgenciaNumero3;
         AV87Contabancariawwds_20_contabancariacreatedbyname3 = AV38ContaBancariaCreatedByName3;
         AV88Contabancariawwds_21_contabancariaupdatedbyname3 = AV39ContaBancariaUpdatedByName3;
         AV89Contabancariawwds_22_tfagenciabanconome = AV62TFAgenciaBancoNome;
         AV90Contabancariawwds_23_tfagenciabanconome_sel = AV63TFAgenciaBancoNome_Sel;
         AV91Contabancariawwds_24_tfagencianumero = AV47TFAgenciaNumero;
         AV92Contabancariawwds_25_tfagencianumero_to = AV48TFAgenciaNumero_To;
         AV93Contabancariawwds_26_tfcontabancarianumero = AV49TFContaBancariaNumero;
         AV94Contabancariawwds_27_tfcontabancarianumero_to = AV50TFContaBancariaNumero_To;
         AV95Contabancariawwds_28_tfcontabancariadigito = AV65TFContaBancariaDigito;
         AV96Contabancariawwds_29_tfcontabancariadigito_to = AV66TFContaBancariaDigito_To;
         AV97Contabancariawwds_30_tfcontabancariacarteira = AV51TFContaBancariaCarteira;
         AV98Contabancariawwds_31_tfcontabancariacarteira_to = AV52TFContaBancariaCarteira_To;
         AV99Contabancariawwds_32_tfcontabancariastatus_sel = AV53TFContaBancariaStatus_Sel;
         AV100Contabancariawwds_33_tfcontabancariacreatedat = AV54TFContaBancariaCreatedAt;
         AV101Contabancariawwds_34_tfcontabancariacreatedat_to = AV55TFContaBancariaCreatedAt_To;
         AV102Contabancariawwds_35_tfcontabancariacreatedbyname = AV56TFContaBancariaCreatedByName;
         AV103Contabancariawwds_36_tfcontabancariacreatedbyname_sel = AV57TFContaBancariaCreatedByName_Sel;
         AV104Contabancariawwds_37_tfcontabancariaupdatedat = AV58TFContaBancariaUpdatedAt;
         AV105Contabancariawwds_38_tfcontabancariaupdatedat_to = AV59TFContaBancariaUpdatedAt_To;
         AV106Contabancariawwds_39_tfcontabancariaupdatedbyname = AV60TFContaBancariaUpdatedByName;
         AV107Contabancariawwds_40_tfcontabancariaupdatedbyname_sel = AV61TFContaBancariaUpdatedByName_Sel;
         AV108Contabancariawwds_41_tfcontabancariaregistraboletos_sel = AV64TFContaBancariaRegistraBoletos_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV68Contabancariawwds_1_filterfulltext ,
                                              AV69Contabancariawwds_2_dynamicfiltersselector1 ,
                                              AV70Contabancariawwds_3_dynamicfiltersoperator1 ,
                                              AV71Contabancariawwds_4_contabancarianumero1 ,
                                              AV72Contabancariawwds_5_agencianumero1 ,
                                              AV73Contabancariawwds_6_contabancariacreatedbyname1 ,
                                              AV74Contabancariawwds_7_contabancariaupdatedbyname1 ,
                                              AV75Contabancariawwds_8_dynamicfiltersenabled2 ,
                                              AV76Contabancariawwds_9_dynamicfiltersselector2 ,
                                              AV77Contabancariawwds_10_dynamicfiltersoperator2 ,
                                              AV78Contabancariawwds_11_contabancarianumero2 ,
                                              AV79Contabancariawwds_12_agencianumero2 ,
                                              AV80Contabancariawwds_13_contabancariacreatedbyname2 ,
                                              AV81Contabancariawwds_14_contabancariaupdatedbyname2 ,
                                              AV82Contabancariawwds_15_dynamicfiltersenabled3 ,
                                              AV83Contabancariawwds_16_dynamicfiltersselector3 ,
                                              AV84Contabancariawwds_17_dynamicfiltersoperator3 ,
                                              AV85Contabancariawwds_18_contabancarianumero3 ,
                                              AV86Contabancariawwds_19_agencianumero3 ,
                                              AV87Contabancariawwds_20_contabancariacreatedbyname3 ,
                                              AV88Contabancariawwds_21_contabancariaupdatedbyname3 ,
                                              AV90Contabancariawwds_23_tfagenciabanconome_sel ,
                                              AV89Contabancariawwds_22_tfagenciabanconome ,
                                              AV91Contabancariawwds_24_tfagencianumero ,
                                              AV92Contabancariawwds_25_tfagencianumero_to ,
                                              AV93Contabancariawwds_26_tfcontabancarianumero ,
                                              AV94Contabancariawwds_27_tfcontabancarianumero_to ,
                                              AV95Contabancariawwds_28_tfcontabancariadigito ,
                                              AV96Contabancariawwds_29_tfcontabancariadigito_to ,
                                              AV97Contabancariawwds_30_tfcontabancariacarteira ,
                                              AV98Contabancariawwds_31_tfcontabancariacarteira_to ,
                                              AV99Contabancariawwds_32_tfcontabancariastatus_sel ,
                                              AV100Contabancariawwds_33_tfcontabancariacreatedat ,
                                              AV101Contabancariawwds_34_tfcontabancariacreatedat_to ,
                                              AV103Contabancariawwds_36_tfcontabancariacreatedbyname_sel ,
                                              AV102Contabancariawwds_35_tfcontabancariacreatedbyname ,
                                              AV104Contabancariawwds_37_tfcontabancariaupdatedat ,
                                              AV105Contabancariawwds_38_tfcontabancariaupdatedat_to ,
                                              AV107Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ,
                                              AV106Contabancariawwds_39_tfcontabancariaupdatedbyname ,
                                              AV108Contabancariawwds_41_tfcontabancariaregistraboletos_sel ,
                                              AV16AgenciaId ,
                                              A969AgenciaBancoNome ,
                                              A939AgenciaNumero ,
                                              A952ContaBancariaNumero ,
                                              A975ContaBancariaDigito ,
                                              A953ContaBancariaCarteira ,
                                              A956ContaBancariaStatus ,
                                              A948ContaBancariaCreatedByName ,
                                              A950ContaBancariaUpdatedByName ,
                                              A973ContaBancariaRegistraBoletos ,
                                              A954ContaBancariaCreatedAt ,
                                              A955ContaBancariaUpdatedAt ,
                                              A938AgenciaId ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV68Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Contabancariawwds_1_filterfulltext), "%", "");
         lV68Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Contabancariawwds_1_filterfulltext), "%", "");
         lV68Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Contabancariawwds_1_filterfulltext), "%", "");
         lV68Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Contabancariawwds_1_filterfulltext), "%", "");
         lV68Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Contabancariawwds_1_filterfulltext), "%", "");
         lV68Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Contabancariawwds_1_filterfulltext), "%", "");
         lV68Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Contabancariawwds_1_filterfulltext), "%", "");
         lV68Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Contabancariawwds_1_filterfulltext), "%", "");
         lV68Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Contabancariawwds_1_filterfulltext), "%", "");
         lV68Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Contabancariawwds_1_filterfulltext), "%", "");
         lV68Contabancariawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Contabancariawwds_1_filterfulltext), "%", "");
         lV73Contabancariawwds_6_contabancariacreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV73Contabancariawwds_6_contabancariacreatedbyname1), "%", "");
         lV73Contabancariawwds_6_contabancariacreatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV73Contabancariawwds_6_contabancariacreatedbyname1), "%", "");
         lV74Contabancariawwds_7_contabancariaupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV74Contabancariawwds_7_contabancariaupdatedbyname1), "%", "");
         lV74Contabancariawwds_7_contabancariaupdatedbyname1 = StringUtil.Concat( StringUtil.RTrim( AV74Contabancariawwds_7_contabancariaupdatedbyname1), "%", "");
         lV80Contabancariawwds_13_contabancariacreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV80Contabancariawwds_13_contabancariacreatedbyname2), "%", "");
         lV80Contabancariawwds_13_contabancariacreatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV80Contabancariawwds_13_contabancariacreatedbyname2), "%", "");
         lV81Contabancariawwds_14_contabancariaupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV81Contabancariawwds_14_contabancariaupdatedbyname2), "%", "");
         lV81Contabancariawwds_14_contabancariaupdatedbyname2 = StringUtil.Concat( StringUtil.RTrim( AV81Contabancariawwds_14_contabancariaupdatedbyname2), "%", "");
         lV87Contabancariawwds_20_contabancariacreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV87Contabancariawwds_20_contabancariacreatedbyname3), "%", "");
         lV87Contabancariawwds_20_contabancariacreatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV87Contabancariawwds_20_contabancariacreatedbyname3), "%", "");
         lV88Contabancariawwds_21_contabancariaupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV88Contabancariawwds_21_contabancariaupdatedbyname3), "%", "");
         lV88Contabancariawwds_21_contabancariaupdatedbyname3 = StringUtil.Concat( StringUtil.RTrim( AV88Contabancariawwds_21_contabancariaupdatedbyname3), "%", "");
         lV89Contabancariawwds_22_tfagenciabanconome = StringUtil.Concat( StringUtil.RTrim( AV89Contabancariawwds_22_tfagenciabanconome), "%", "");
         lV102Contabancariawwds_35_tfcontabancariacreatedbyname = StringUtil.Concat( StringUtil.RTrim( AV102Contabancariawwds_35_tfcontabancariacreatedbyname), "%", "");
         lV106Contabancariawwds_39_tfcontabancariaupdatedbyname = StringUtil.Concat( StringUtil.RTrim( AV106Contabancariawwds_39_tfcontabancariaupdatedbyname), "%", "");
         /* Using cursor P00EM2 */
         pr_default.execute(0, new Object[] {lV68Contabancariawwds_1_filterfulltext, lV68Contabancariawwds_1_filterfulltext, lV68Contabancariawwds_1_filterfulltext, lV68Contabancariawwds_1_filterfulltext, lV68Contabancariawwds_1_filterfulltext, lV68Contabancariawwds_1_filterfulltext, lV68Contabancariawwds_1_filterfulltext, lV68Contabancariawwds_1_filterfulltext, lV68Contabancariawwds_1_filterfulltext, lV68Contabancariawwds_1_filterfulltext, lV68Contabancariawwds_1_filterfulltext, AV71Contabancariawwds_4_contabancarianumero1, AV71Contabancariawwds_4_contabancarianumero1, AV71Contabancariawwds_4_contabancarianumero1, AV72Contabancariawwds_5_agencianumero1, AV72Contabancariawwds_5_agencianumero1, AV72Contabancariawwds_5_agencianumero1, lV73Contabancariawwds_6_contabancariacreatedbyname1, lV73Contabancariawwds_6_contabancariacreatedbyname1, lV74Contabancariawwds_7_contabancariaupdatedbyname1, lV74Contabancariawwds_7_contabancariaupdatedbyname1, AV78Contabancariawwds_11_contabancarianumero2, AV78Contabancariawwds_11_contabancarianumero2, AV78Contabancariawwds_11_contabancarianumero2, AV79Contabancariawwds_12_agencianumero2, AV79Contabancariawwds_12_agencianumero2, AV79Contabancariawwds_12_agencianumero2, lV80Contabancariawwds_13_contabancariacreatedbyname2, lV80Contabancariawwds_13_contabancariacreatedbyname2, lV81Contabancariawwds_14_contabancariaupdatedbyname2, lV81Contabancariawwds_14_contabancariaupdatedbyname2, AV85Contabancariawwds_18_contabancarianumero3, AV85Contabancariawwds_18_contabancarianumero3, AV85Contabancariawwds_18_contabancarianumero3, AV86Contabancariawwds_19_agencianumero3, AV86Contabancariawwds_19_agencianumero3, AV86Contabancariawwds_19_agencianumero3, lV87Contabancariawwds_20_contabancariacreatedbyname3, lV87Contabancariawwds_20_contabancariacreatedbyname3, lV88Contabancariawwds_21_contabancariaupdatedbyname3, lV88Contabancariawwds_21_contabancariaupdatedbyname3, lV89Contabancariawwds_22_tfagenciabanconome, AV90Contabancariawwds_23_tfagenciabanconome_sel, AV91Contabancariawwds_24_tfagencianumero, AV92Contabancariawwds_25_tfagencianumero_to, AV93Contabancariawwds_26_tfcontabancarianumero, AV94Contabancariawwds_27_tfcontabancarianumero_to, AV95Contabancariawwds_28_tfcontabancariadigito, AV96Contabancariawwds_29_tfcontabancariadigito_to, AV97Contabancariawwds_30_tfcontabancariacarteira, AV98Contabancariawwds_31_tfcontabancariacarteira_to, AV100Contabancariawwds_33_tfcontabancariacreatedat, AV101Contabancariawwds_34_tfcontabancariacreatedat_to, lV102Contabancariawwds_35_tfcontabancariacreatedbyname, AV103Contabancariawwds_36_tfcontabancariacreatedbyname_sel, AV104Contabancariawwds_37_tfcontabancariaupdatedat, AV105Contabancariawwds_38_tfcontabancariaupdatedat_to, lV106Contabancariawwds_39_tfcontabancariaupdatedbyname, AV107Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, AV16AgenciaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A968AgenciaBancoId = P00EM2_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EM2_n968AgenciaBancoId[0];
            A947ContaBancariaCreatedBy = P00EM2_A947ContaBancariaCreatedBy[0];
            n947ContaBancariaCreatedBy = P00EM2_n947ContaBancariaCreatedBy[0];
            A949ContaBancariaUpdatedBy = P00EM2_A949ContaBancariaUpdatedBy[0];
            n949ContaBancariaUpdatedBy = P00EM2_n949ContaBancariaUpdatedBy[0];
            A938AgenciaId = P00EM2_A938AgenciaId[0];
            n938AgenciaId = P00EM2_n938AgenciaId[0];
            A955ContaBancariaUpdatedAt = P00EM2_A955ContaBancariaUpdatedAt[0];
            n955ContaBancariaUpdatedAt = P00EM2_n955ContaBancariaUpdatedAt[0];
            A954ContaBancariaCreatedAt = P00EM2_A954ContaBancariaCreatedAt[0];
            n954ContaBancariaCreatedAt = P00EM2_n954ContaBancariaCreatedAt[0];
            A953ContaBancariaCarteira = P00EM2_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = P00EM2_n953ContaBancariaCarteira[0];
            A975ContaBancariaDigito = P00EM2_A975ContaBancariaDigito[0];
            n975ContaBancariaDigito = P00EM2_n975ContaBancariaDigito[0];
            A969AgenciaBancoNome = P00EM2_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EM2_n969AgenciaBancoNome[0];
            A950ContaBancariaUpdatedByName = P00EM2_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = P00EM2_n950ContaBancariaUpdatedByName[0];
            A948ContaBancariaCreatedByName = P00EM2_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = P00EM2_n948ContaBancariaCreatedByName[0];
            A939AgenciaNumero = P00EM2_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EM2_n939AgenciaNumero[0];
            A952ContaBancariaNumero = P00EM2_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = P00EM2_n952ContaBancariaNumero[0];
            A973ContaBancariaRegistraBoletos = P00EM2_A973ContaBancariaRegistraBoletos[0];
            n973ContaBancariaRegistraBoletos = P00EM2_n973ContaBancariaRegistraBoletos[0];
            A956ContaBancariaStatus = P00EM2_A956ContaBancariaStatus[0];
            n956ContaBancariaStatus = P00EM2_n956ContaBancariaStatus[0];
            A951ContaBancariaId = P00EM2_A951ContaBancariaId[0];
            A948ContaBancariaCreatedByName = P00EM2_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = P00EM2_n948ContaBancariaCreatedByName[0];
            A950ContaBancariaUpdatedByName = P00EM2_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = P00EM2_n950ContaBancariaUpdatedByName[0];
            A968AgenciaBancoId = P00EM2_A968AgenciaBancoId[0];
            n968AgenciaBancoId = P00EM2_n968AgenciaBancoId[0];
            A939AgenciaNumero = P00EM2_A939AgenciaNumero[0];
            n939AgenciaNumero = P00EM2_n939AgenciaNumero[0];
            A969AgenciaBancoNome = P00EM2_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = P00EM2_n969AgenciaBancoNome[0];
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
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = A975ContaBancariaDigito;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = A953ContaBancariaCarteira;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A956ContaBancariaStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A956ContaBancariaStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Inativo";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A956ContaBancariaStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A956ContaBancariaStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Date = A954ContaBancariaCreatedAt;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A948ContaBancariaCreatedByName, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Date = A955ContaBancariaUpdatedAt;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A950ContaBancariaUpdatedByName, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A973ContaBancariaRegistraBoletos)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Text = "Não";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A973ContaBancariaRegistraBoletos)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Text = "Sim";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A973ContaBancariaRegistraBoletos)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+10, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
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
         AV41Session.Set("WWPExportFilePath", AV11Filename);
         AV41Session.Set("WWPExportFileName", "ContaBancariaWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV41Session.Get("ContaBancariaWWGridState"), "") == 0 )
         {
            AV43GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ContaBancariaWWGridState"), null, "", "");
         }
         else
         {
            AV43GridState.FromXml(AV41Session.Get("ContaBancariaWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV43GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV43GridState.gxTpr_Ordereddsc;
         AV109GXV1 = 1;
         while ( AV109GXV1 <= AV43GridState.gxTpr_Filtervalues.Count )
         {
            AV44GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV43GridState.gxTpr_Filtervalues.Item(AV109GXV1));
            if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME") == 0 )
            {
               AV62TFAgenciaBancoNome = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFAGENCIABANCONOME_SEL") == 0 )
            {
               AV63TFAgenciaBancoNome_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFAGENCIANUMERO") == 0 )
            {
               AV47TFAgenciaNumero = (int)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV48TFAgenciaNumero_To = (int)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIANUMERO") == 0 )
            {
               AV49TFContaBancariaNumero = (long)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV50TFContaBancariaNumero_To = (long)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIADIGITO") == 0 )
            {
               AV65TFContaBancariaDigito = (short)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV66TFContaBancariaDigito_To = (short)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIACARTEIRA") == 0 )
            {
               AV51TFContaBancariaCarteira = (long)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV52TFContaBancariaCarteira_To = (long)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIASTATUS_SEL") == 0 )
            {
               AV53TFContaBancariaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIACREATEDAT") == 0 )
            {
               AV54TFContaBancariaCreatedAt = context.localUtil.CToT( AV44GridStateFilterValue.gxTpr_Value, 4);
               AV55TFContaBancariaCreatedAt_To = context.localUtil.CToT( AV44GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIACREATEDBYNAME") == 0 )
            {
               AV56TFContaBancariaCreatedByName = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIACREATEDBYNAME_SEL") == 0 )
            {
               AV57TFContaBancariaCreatedByName_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIAUPDATEDAT") == 0 )
            {
               AV58TFContaBancariaUpdatedAt = context.localUtil.CToT( AV44GridStateFilterValue.gxTpr_Value, 4);
               AV59TFContaBancariaUpdatedAt_To = context.localUtil.CToT( AV44GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIAUPDATEDBYNAME") == 0 )
            {
               AV60TFContaBancariaUpdatedByName = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIAUPDATEDBYNAME_SEL") == 0 )
            {
               AV61TFContaBancariaUpdatedByName_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCONTABANCARIAREGISTRABOLETOS_SEL") == 0 )
            {
               AV64TFContaBancariaRegistraBoletos_Sel = (short)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "PARM_&AGENCIAID") == 0 )
            {
               AV16AgenciaId = (int)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV109GXV1 = (int)(AV109GXV1+1);
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
         AV43GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV40GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV24ContaBancariaCreatedByName1 = "";
         AV25ContaBancariaUpdatedByName1 = "";
         AV27DynamicFiltersSelector2 = "";
         AV31ContaBancariaCreatedByName2 = "";
         AV32ContaBancariaUpdatedByName2 = "";
         AV34DynamicFiltersSelector3 = "";
         AV38ContaBancariaCreatedByName3 = "";
         AV39ContaBancariaUpdatedByName3 = "";
         AV63TFAgenciaBancoNome_Sel = "";
         AV62TFAgenciaBancoNome = "";
         AV54TFContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         AV55TFContaBancariaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV57TFContaBancariaCreatedByName_Sel = "";
         AV56TFContaBancariaCreatedByName = "";
         AV58TFContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
         AV59TFContaBancariaUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV61TFContaBancariaUpdatedByName_Sel = "";
         AV60TFContaBancariaUpdatedByName = "";
         AV68Contabancariawwds_1_filterfulltext = "";
         AV69Contabancariawwds_2_dynamicfiltersselector1 = "";
         AV73Contabancariawwds_6_contabancariacreatedbyname1 = "";
         AV74Contabancariawwds_7_contabancariaupdatedbyname1 = "";
         AV76Contabancariawwds_9_dynamicfiltersselector2 = "";
         AV80Contabancariawwds_13_contabancariacreatedbyname2 = "";
         AV81Contabancariawwds_14_contabancariaupdatedbyname2 = "";
         AV83Contabancariawwds_16_dynamicfiltersselector3 = "";
         AV87Contabancariawwds_20_contabancariacreatedbyname3 = "";
         AV88Contabancariawwds_21_contabancariaupdatedbyname3 = "";
         AV89Contabancariawwds_22_tfagenciabanconome = "";
         AV90Contabancariawwds_23_tfagenciabanconome_sel = "";
         AV100Contabancariawwds_33_tfcontabancariacreatedat = (DateTime)(DateTime.MinValue);
         AV101Contabancariawwds_34_tfcontabancariacreatedat_to = (DateTime)(DateTime.MinValue);
         AV102Contabancariawwds_35_tfcontabancariacreatedbyname = "";
         AV103Contabancariawwds_36_tfcontabancariacreatedbyname_sel = "";
         AV104Contabancariawwds_37_tfcontabancariaupdatedat = (DateTime)(DateTime.MinValue);
         AV105Contabancariawwds_38_tfcontabancariaupdatedat_to = (DateTime)(DateTime.MinValue);
         AV106Contabancariawwds_39_tfcontabancariaupdatedbyname = "";
         AV107Contabancariawwds_40_tfcontabancariaupdatedbyname_sel = "";
         lV68Contabancariawwds_1_filterfulltext = "";
         lV73Contabancariawwds_6_contabancariacreatedbyname1 = "";
         lV74Contabancariawwds_7_contabancariaupdatedbyname1 = "";
         lV80Contabancariawwds_13_contabancariacreatedbyname2 = "";
         lV81Contabancariawwds_14_contabancariaupdatedbyname2 = "";
         lV87Contabancariawwds_20_contabancariacreatedbyname3 = "";
         lV88Contabancariawwds_21_contabancariaupdatedbyname3 = "";
         lV89Contabancariawwds_22_tfagenciabanconome = "";
         lV102Contabancariawwds_35_tfcontabancariacreatedbyname = "";
         lV106Contabancariawwds_39_tfcontabancariaupdatedbyname = "";
         A969AgenciaBancoNome = "";
         A948ContaBancariaCreatedByName = "";
         A950ContaBancariaUpdatedByName = "";
         A954ContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         A955ContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
         P00EM2_A968AgenciaBancoId = new int[1] ;
         P00EM2_n968AgenciaBancoId = new bool[] {false} ;
         P00EM2_A947ContaBancariaCreatedBy = new short[1] ;
         P00EM2_n947ContaBancariaCreatedBy = new bool[] {false} ;
         P00EM2_A949ContaBancariaUpdatedBy = new short[1] ;
         P00EM2_n949ContaBancariaUpdatedBy = new bool[] {false} ;
         P00EM2_A938AgenciaId = new int[1] ;
         P00EM2_n938AgenciaId = new bool[] {false} ;
         P00EM2_A955ContaBancariaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EM2_n955ContaBancariaUpdatedAt = new bool[] {false} ;
         P00EM2_A954ContaBancariaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00EM2_n954ContaBancariaCreatedAt = new bool[] {false} ;
         P00EM2_A953ContaBancariaCarteira = new long[1] ;
         P00EM2_n953ContaBancariaCarteira = new bool[] {false} ;
         P00EM2_A975ContaBancariaDigito = new short[1] ;
         P00EM2_n975ContaBancariaDigito = new bool[] {false} ;
         P00EM2_A969AgenciaBancoNome = new string[] {""} ;
         P00EM2_n969AgenciaBancoNome = new bool[] {false} ;
         P00EM2_A950ContaBancariaUpdatedByName = new string[] {""} ;
         P00EM2_n950ContaBancariaUpdatedByName = new bool[] {false} ;
         P00EM2_A948ContaBancariaCreatedByName = new string[] {""} ;
         P00EM2_n948ContaBancariaCreatedByName = new bool[] {false} ;
         P00EM2_A939AgenciaNumero = new int[1] ;
         P00EM2_n939AgenciaNumero = new bool[] {false} ;
         P00EM2_A952ContaBancariaNumero = new long[1] ;
         P00EM2_n952ContaBancariaNumero = new bool[] {false} ;
         P00EM2_A973ContaBancariaRegistraBoletos = new bool[] {false} ;
         P00EM2_n973ContaBancariaRegistraBoletos = new bool[] {false} ;
         P00EM2_A956ContaBancariaStatus = new bool[] {false} ;
         P00EM2_n956ContaBancariaStatus = new bool[] {false} ;
         P00EM2_A951ContaBancariaId = new int[1] ;
         GXt_char1 = "";
         AV41Session = context.GetSession();
         AV44GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabancariawwexport__default(),
            new Object[][] {
                new Object[] {
               P00EM2_A968AgenciaBancoId, P00EM2_n968AgenciaBancoId, P00EM2_A947ContaBancariaCreatedBy, P00EM2_n947ContaBancariaCreatedBy, P00EM2_A949ContaBancariaUpdatedBy, P00EM2_n949ContaBancariaUpdatedBy, P00EM2_A938AgenciaId, P00EM2_n938AgenciaId, P00EM2_A955ContaBancariaUpdatedAt, P00EM2_n955ContaBancariaUpdatedAt,
               P00EM2_A954ContaBancariaCreatedAt, P00EM2_n954ContaBancariaCreatedAt, P00EM2_A953ContaBancariaCarteira, P00EM2_n953ContaBancariaCarteira, P00EM2_A975ContaBancariaDigito, P00EM2_n975ContaBancariaDigito, P00EM2_A969AgenciaBancoNome, P00EM2_n969AgenciaBancoNome, P00EM2_A950ContaBancariaUpdatedByName, P00EM2_n950ContaBancariaUpdatedByName,
               P00EM2_A948ContaBancariaCreatedByName, P00EM2_n948ContaBancariaCreatedByName, P00EM2_A939AgenciaNumero, P00EM2_n939AgenciaNumero, P00EM2_A952ContaBancariaNumero, P00EM2_n952ContaBancariaNumero, P00EM2_A973ContaBancariaRegistraBoletos, P00EM2_n973ContaBancariaRegistraBoletos, P00EM2_A956ContaBancariaStatus, P00EM2_n956ContaBancariaStatus,
               P00EM2_A951ContaBancariaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV28DynamicFiltersOperator2 ;
      private short AV35DynamicFiltersOperator3 ;
      private short AV65TFContaBancariaDigito ;
      private short AV66TFContaBancariaDigito_To ;
      private short AV53TFContaBancariaStatus_Sel ;
      private short AV64TFContaBancariaRegistraBoletos_Sel ;
      private short GXt_int2 ;
      private short AV70Contabancariawwds_3_dynamicfiltersoperator1 ;
      private short AV77Contabancariawwds_10_dynamicfiltersoperator2 ;
      private short AV84Contabancariawwds_17_dynamicfiltersoperator3 ;
      private short AV95Contabancariawwds_28_tfcontabancariadigito ;
      private short AV96Contabancariawwds_29_tfcontabancariadigito_to ;
      private short AV99Contabancariawwds_32_tfcontabancariastatus_sel ;
      private short AV108Contabancariawwds_41_tfcontabancariaregistraboletos_sel ;
      private short A975ContaBancariaDigito ;
      private short AV17OrderedBy ;
      private short A947ContaBancariaCreatedBy ;
      private short A949ContaBancariaUpdatedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV23AgenciaNumero1 ;
      private int AV30AgenciaNumero2 ;
      private int AV37AgenciaNumero3 ;
      private int AV47TFAgenciaNumero ;
      private int AV48TFAgenciaNumero_To ;
      private int AV72Contabancariawwds_5_agencianumero1 ;
      private int AV79Contabancariawwds_12_agencianumero2 ;
      private int AV86Contabancariawwds_19_agencianumero3 ;
      private int AV91Contabancariawwds_24_tfagencianumero ;
      private int AV92Contabancariawwds_25_tfagencianumero_to ;
      private int AV16AgenciaId ;
      private int A939AgenciaNumero ;
      private int A938AgenciaId ;
      private int A968AgenciaBancoId ;
      private int A951ContaBancariaId ;
      private int AV109GXV1 ;
      private long AV22ContaBancariaNumero1 ;
      private long AV29ContaBancariaNumero2 ;
      private long AV36ContaBancariaNumero3 ;
      private long AV49TFContaBancariaNumero ;
      private long AV50TFContaBancariaNumero_To ;
      private long AV51TFContaBancariaCarteira ;
      private long AV52TFContaBancariaCarteira_To ;
      private long AV71Contabancariawwds_4_contabancarianumero1 ;
      private long AV78Contabancariawwds_11_contabancarianumero2 ;
      private long AV85Contabancariawwds_18_contabancarianumero3 ;
      private long AV93Contabancariawwds_26_tfcontabancarianumero ;
      private long AV94Contabancariawwds_27_tfcontabancarianumero_to ;
      private long AV97Contabancariawwds_30_tfcontabancariacarteira ;
      private long AV98Contabancariawwds_31_tfcontabancariacarteira_to ;
      private long A952ContaBancariaNumero ;
      private long A953ContaBancariaCarteira ;
      private string GXt_char1 ;
      private DateTime AV54TFContaBancariaCreatedAt ;
      private DateTime AV55TFContaBancariaCreatedAt_To ;
      private DateTime AV58TFContaBancariaUpdatedAt ;
      private DateTime AV59TFContaBancariaUpdatedAt_To ;
      private DateTime AV100Contabancariawwds_33_tfcontabancariacreatedat ;
      private DateTime AV101Contabancariawwds_34_tfcontabancariacreatedat_to ;
      private DateTime AV104Contabancariawwds_37_tfcontabancariaupdatedat ;
      private DateTime AV105Contabancariawwds_38_tfcontabancariaupdatedat_to ;
      private DateTime A954ContaBancariaCreatedAt ;
      private DateTime A955ContaBancariaUpdatedAt ;
      private bool returnInSub ;
      private bool AV26DynamicFiltersEnabled2 ;
      private bool AV33DynamicFiltersEnabled3 ;
      private bool AV75Contabancariawwds_8_dynamicfiltersenabled2 ;
      private bool AV82Contabancariawwds_15_dynamicfiltersenabled3 ;
      private bool A956ContaBancariaStatus ;
      private bool A973ContaBancariaRegistraBoletos ;
      private bool AV18OrderedDsc ;
      private bool n968AgenciaBancoId ;
      private bool n947ContaBancariaCreatedBy ;
      private bool n949ContaBancariaUpdatedBy ;
      private bool n938AgenciaId ;
      private bool n955ContaBancariaUpdatedAt ;
      private bool n954ContaBancariaCreatedAt ;
      private bool n953ContaBancariaCarteira ;
      private bool n975ContaBancariaDigito ;
      private bool n969AgenciaBancoNome ;
      private bool n950ContaBancariaUpdatedByName ;
      private bool n948ContaBancariaCreatedByName ;
      private bool n939AgenciaNumero ;
      private bool n952ContaBancariaNumero ;
      private bool n973ContaBancariaRegistraBoletos ;
      private bool n956ContaBancariaStatus ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV24ContaBancariaCreatedByName1 ;
      private string AV25ContaBancariaUpdatedByName1 ;
      private string AV27DynamicFiltersSelector2 ;
      private string AV31ContaBancariaCreatedByName2 ;
      private string AV32ContaBancariaUpdatedByName2 ;
      private string AV34DynamicFiltersSelector3 ;
      private string AV38ContaBancariaCreatedByName3 ;
      private string AV39ContaBancariaUpdatedByName3 ;
      private string AV63TFAgenciaBancoNome_Sel ;
      private string AV62TFAgenciaBancoNome ;
      private string AV57TFContaBancariaCreatedByName_Sel ;
      private string AV56TFContaBancariaCreatedByName ;
      private string AV61TFContaBancariaUpdatedByName_Sel ;
      private string AV60TFContaBancariaUpdatedByName ;
      private string AV68Contabancariawwds_1_filterfulltext ;
      private string AV69Contabancariawwds_2_dynamicfiltersselector1 ;
      private string AV73Contabancariawwds_6_contabancariacreatedbyname1 ;
      private string AV74Contabancariawwds_7_contabancariaupdatedbyname1 ;
      private string AV76Contabancariawwds_9_dynamicfiltersselector2 ;
      private string AV80Contabancariawwds_13_contabancariacreatedbyname2 ;
      private string AV81Contabancariawwds_14_contabancariaupdatedbyname2 ;
      private string AV83Contabancariawwds_16_dynamicfiltersselector3 ;
      private string AV87Contabancariawwds_20_contabancariacreatedbyname3 ;
      private string AV88Contabancariawwds_21_contabancariaupdatedbyname3 ;
      private string AV89Contabancariawwds_22_tfagenciabanconome ;
      private string AV90Contabancariawwds_23_tfagenciabanconome_sel ;
      private string AV102Contabancariawwds_35_tfcontabancariacreatedbyname ;
      private string AV103Contabancariawwds_36_tfcontabancariacreatedbyname_sel ;
      private string AV106Contabancariawwds_39_tfcontabancariaupdatedbyname ;
      private string AV107Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ;
      private string lV68Contabancariawwds_1_filterfulltext ;
      private string lV73Contabancariawwds_6_contabancariacreatedbyname1 ;
      private string lV74Contabancariawwds_7_contabancariaupdatedbyname1 ;
      private string lV80Contabancariawwds_13_contabancariacreatedbyname2 ;
      private string lV81Contabancariawwds_14_contabancariaupdatedbyname2 ;
      private string lV87Contabancariawwds_20_contabancariacreatedbyname3 ;
      private string lV88Contabancariawwds_21_contabancariaupdatedbyname3 ;
      private string lV89Contabancariawwds_22_tfagenciabanconome ;
      private string lV102Contabancariawwds_35_tfcontabancariacreatedbyname ;
      private string lV106Contabancariawwds_39_tfcontabancariaupdatedbyname ;
      private string A969AgenciaBancoNome ;
      private string A948ContaBancariaCreatedByName ;
      private string A950ContaBancariaUpdatedByName ;
      private IGxSession AV41Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV43GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV40GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private int[] P00EM2_A968AgenciaBancoId ;
      private bool[] P00EM2_n968AgenciaBancoId ;
      private short[] P00EM2_A947ContaBancariaCreatedBy ;
      private bool[] P00EM2_n947ContaBancariaCreatedBy ;
      private short[] P00EM2_A949ContaBancariaUpdatedBy ;
      private bool[] P00EM2_n949ContaBancariaUpdatedBy ;
      private int[] P00EM2_A938AgenciaId ;
      private bool[] P00EM2_n938AgenciaId ;
      private DateTime[] P00EM2_A955ContaBancariaUpdatedAt ;
      private bool[] P00EM2_n955ContaBancariaUpdatedAt ;
      private DateTime[] P00EM2_A954ContaBancariaCreatedAt ;
      private bool[] P00EM2_n954ContaBancariaCreatedAt ;
      private long[] P00EM2_A953ContaBancariaCarteira ;
      private bool[] P00EM2_n953ContaBancariaCarteira ;
      private short[] P00EM2_A975ContaBancariaDigito ;
      private bool[] P00EM2_n975ContaBancariaDigito ;
      private string[] P00EM2_A969AgenciaBancoNome ;
      private bool[] P00EM2_n969AgenciaBancoNome ;
      private string[] P00EM2_A950ContaBancariaUpdatedByName ;
      private bool[] P00EM2_n950ContaBancariaUpdatedByName ;
      private string[] P00EM2_A948ContaBancariaCreatedByName ;
      private bool[] P00EM2_n948ContaBancariaCreatedByName ;
      private int[] P00EM2_A939AgenciaNumero ;
      private bool[] P00EM2_n939AgenciaNumero ;
      private long[] P00EM2_A952ContaBancariaNumero ;
      private bool[] P00EM2_n952ContaBancariaNumero ;
      private bool[] P00EM2_A973ContaBancariaRegistraBoletos ;
      private bool[] P00EM2_n973ContaBancariaRegistraBoletos ;
      private bool[] P00EM2_A956ContaBancariaStatus ;
      private bool[] P00EM2_n956ContaBancariaStatus ;
      private int[] P00EM2_A951ContaBancariaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV44GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class contabancariawwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EM2( IGxContext context ,
                                             string AV68Contabancariawwds_1_filterfulltext ,
                                             string AV69Contabancariawwds_2_dynamicfiltersselector1 ,
                                             short AV70Contabancariawwds_3_dynamicfiltersoperator1 ,
                                             long AV71Contabancariawwds_4_contabancarianumero1 ,
                                             int AV72Contabancariawwds_5_agencianumero1 ,
                                             string AV73Contabancariawwds_6_contabancariacreatedbyname1 ,
                                             string AV74Contabancariawwds_7_contabancariaupdatedbyname1 ,
                                             bool AV75Contabancariawwds_8_dynamicfiltersenabled2 ,
                                             string AV76Contabancariawwds_9_dynamicfiltersselector2 ,
                                             short AV77Contabancariawwds_10_dynamicfiltersoperator2 ,
                                             long AV78Contabancariawwds_11_contabancarianumero2 ,
                                             int AV79Contabancariawwds_12_agencianumero2 ,
                                             string AV80Contabancariawwds_13_contabancariacreatedbyname2 ,
                                             string AV81Contabancariawwds_14_contabancariaupdatedbyname2 ,
                                             bool AV82Contabancariawwds_15_dynamicfiltersenabled3 ,
                                             string AV83Contabancariawwds_16_dynamicfiltersselector3 ,
                                             short AV84Contabancariawwds_17_dynamicfiltersoperator3 ,
                                             long AV85Contabancariawwds_18_contabancarianumero3 ,
                                             int AV86Contabancariawwds_19_agencianumero3 ,
                                             string AV87Contabancariawwds_20_contabancariacreatedbyname3 ,
                                             string AV88Contabancariawwds_21_contabancariaupdatedbyname3 ,
                                             string AV90Contabancariawwds_23_tfagenciabanconome_sel ,
                                             string AV89Contabancariawwds_22_tfagenciabanconome ,
                                             int AV91Contabancariawwds_24_tfagencianumero ,
                                             int AV92Contabancariawwds_25_tfagencianumero_to ,
                                             long AV93Contabancariawwds_26_tfcontabancarianumero ,
                                             long AV94Contabancariawwds_27_tfcontabancarianumero_to ,
                                             short AV95Contabancariawwds_28_tfcontabancariadigito ,
                                             short AV96Contabancariawwds_29_tfcontabancariadigito_to ,
                                             long AV97Contabancariawwds_30_tfcontabancariacarteira ,
                                             long AV98Contabancariawwds_31_tfcontabancariacarteira_to ,
                                             short AV99Contabancariawwds_32_tfcontabancariastatus_sel ,
                                             DateTime AV100Contabancariawwds_33_tfcontabancariacreatedat ,
                                             DateTime AV101Contabancariawwds_34_tfcontabancariacreatedat_to ,
                                             string AV103Contabancariawwds_36_tfcontabancariacreatedbyname_sel ,
                                             string AV102Contabancariawwds_35_tfcontabancariacreatedbyname ,
                                             DateTime AV104Contabancariawwds_37_tfcontabancariaupdatedat ,
                                             DateTime AV105Contabancariawwds_38_tfcontabancariaupdatedat_to ,
                                             string AV107Contabancariawwds_40_tfcontabancariaupdatedbyname_sel ,
                                             string AV106Contabancariawwds_39_tfcontabancariaupdatedbyname ,
                                             short AV108Contabancariawwds_41_tfcontabancariaregistraboletos_sel ,
                                             int AV16AgenciaId ,
                                             string A969AgenciaBancoNome ,
                                             int A939AgenciaNumero ,
                                             long A952ContaBancariaNumero ,
                                             short A975ContaBancariaDigito ,
                                             long A953ContaBancariaCarteira ,
                                             bool A956ContaBancariaStatus ,
                                             string A948ContaBancariaCreatedByName ,
                                             string A950ContaBancariaUpdatedByName ,
                                             bool A973ContaBancariaRegistraBoletos ,
                                             DateTime A954ContaBancariaCreatedAt ,
                                             DateTime A955ContaBancariaUpdatedAt ,
                                             int A938AgenciaId ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[60];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T4.AgenciaBancoId AS AgenciaBancoId, T1.ContaBancariaCreatedBy AS ContaBancariaCreatedBy, T1.ContaBancariaUpdatedBy AS ContaBancariaUpdatedBy, T1.AgenciaId, T1.ContaBancariaUpdatedAt, T1.ContaBancariaCreatedAt, T1.ContaBancariaCarteira, T1.ContaBancariaDigito, T5.BancoNome AS AgenciaBancoNome, T3.SecUserName AS ContaBancariaUpdatedByName, T2.SecUserName AS ContaBancariaCreatedByName, T4.AgenciaNumero, T1.ContaBancariaNumero, T1.ContaBancariaRegistraBoletos, T1.ContaBancariaStatus, T1.ContaBancariaId FROM ((((ContaBancaria T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.ContaBancariaCreatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = T1.ContaBancariaUpdatedBy) LEFT JOIN Agencia T4 ON T4.AgenciaId = T1.AgenciaId) LEFT JOIN Banco T5 ON T5.BancoId = T4.AgenciaBancoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabancariawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( LOWER(T5.BancoNome) like '%' || LOWER(:lV68Contabancariawwds_1_filterfulltext)) or ( SUBSTR(TO_CHAR(T4.AgenciaNumero,'999999999'), 2) like '%' || :lV68Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaNumero,'999999999999999999'), 2) like '%' || :lV68Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaDigito,'9999'), 2) like '%' || :lV68Contabancariawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.ContaBancariaCarteira,'9999999999'), 2) like '%' || :lV68Contabancariawwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV68Contabancariawwds_1_filterfulltext) and T1.ContaBancariaStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV68Contabancariawwds_1_filterfulltext) and T1.ContaBancariaStatus = FALSE) or ( LOWER(T2.SecUserName) like '%' || LOWER(:lV68Contabancariawwds_1_filterfulltext)) or ( LOWER(T3.SecUserName) like '%' || LOWER(:lV68Contabancariawwds_1_filterfulltext)) or ( 'não' like '%' || LOWER(:lV68Contabancariawwds_1_filterfulltext) and T1.ContaBancariaRegistraBoletos = FALSE) or ( 'sim' like '%' || LOWER(:lV68Contabancariawwds_1_filterfulltext) and T1.ContaBancariaRegistraBoletos = TRUE))");
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
         }
         if ( ( StringUtil.StrCmp(AV69Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV70Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV71Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV71Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV70Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV71Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV71Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIANUMERO") == 0 ) && ( AV70Contabancariawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV71Contabancariawwds_4_contabancarianumero1) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV71Contabancariawwds_4_contabancarianumero1)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV70Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV72Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV72Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV70Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV72Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV72Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Contabancariawwds_2_dynamicfiltersselector1, "AGENCIANUMERO") == 0 ) && ( AV70Contabancariawwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV72Contabancariawwds_5_agencianumero1) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV72Contabancariawwds_5_agencianumero1)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV70Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabancariawwds_6_contabancariacreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV73Contabancariawwds_6_contabancariacreatedbyname1)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV70Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabancariawwds_6_contabancariacreatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV73Contabancariawwds_6_contabancariacreatedbyname1)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV70Contabancariawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabancariawwds_7_contabancariaupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV74Contabancariawwds_7_contabancariaupdatedbyname1)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Contabancariawwds_2_dynamicfiltersselector1, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV70Contabancariawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabancariawwds_7_contabancariaupdatedbyname1)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV74Contabancariawwds_7_contabancariaupdatedbyname1)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( AV75Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV77Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV78Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV78Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( AV75Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV77Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV78Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV78Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV75Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIANUMERO") == 0 ) && ( AV77Contabancariawwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV78Contabancariawwds_11_contabancarianumero2) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV78Contabancariawwds_11_contabancarianumero2)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV75Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV77Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV79Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV79Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( AV75Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV77Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV79Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV79Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( AV75Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Contabancariawwds_9_dynamicfiltersselector2, "AGENCIANUMERO") == 0 ) && ( AV77Contabancariawwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV79Contabancariawwds_12_agencianumero2) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV79Contabancariawwds_12_agencianumero2)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( AV75Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV77Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabancariawwds_13_contabancariacreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV80Contabancariawwds_13_contabancariacreatedbyname2)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV75Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV77Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabancariawwds_13_contabancariacreatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV80Contabancariawwds_13_contabancariacreatedbyname2)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( AV75Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV77Contabancariawwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabancariawwds_14_contabancariaupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV81Contabancariawwds_14_contabancariaupdatedbyname2)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( AV75Contabancariawwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Contabancariawwds_9_dynamicfiltersselector2, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV77Contabancariawwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabancariawwds_14_contabancariaupdatedbyname2)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV81Contabancariawwds_14_contabancariaupdatedbyname2)");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( AV82Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV84Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV85Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero < :AV85Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( AV82Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV84Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV85Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero = :AV85Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( AV82Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIANUMERO") == 0 ) && ( AV84Contabancariawwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV85Contabancariawwds_18_contabancarianumero3) ) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero > :AV85Contabancariawwds_18_contabancarianumero3)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( AV82Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV84Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV86Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero < :AV86Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( AV82Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV84Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV86Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero = :AV86Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( AV82Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Contabancariawwds_16_dynamicfiltersselector3, "AGENCIANUMERO") == 0 ) && ( AV84Contabancariawwds_17_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV86Contabancariawwds_19_agencianumero3) ) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero > :AV86Contabancariawwds_19_agencianumero3)");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( AV82Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV84Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Contabancariawwds_20_contabancariacreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV87Contabancariawwds_20_contabancariacreatedbyname3)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( AV82Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIACREATEDBYNAME") == 0 ) && ( AV84Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Contabancariawwds_20_contabancariacreatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV87Contabancariawwds_20_contabancariacreatedbyname3)");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( AV82Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV84Contabancariawwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Contabancariawwds_21_contabancariaupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV88Contabancariawwds_21_contabancariaupdatedbyname3)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( AV82Contabancariawwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Contabancariawwds_16_dynamicfiltersselector3, "CONTABANCARIAUPDATEDBYNAME") == 0 ) && ( AV84Contabancariawwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Contabancariawwds_21_contabancariaupdatedbyname3)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like '%' || :lV88Contabancariawwds_21_contabancariaupdatedbyname3)");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Contabancariawwds_23_tfagenciabanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Contabancariawwds_22_tfagenciabanconome)) ) )
         {
            AddWhere(sWhereString, "(T5.BancoNome like :lV89Contabancariawwds_22_tfagenciabanconome)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Contabancariawwds_23_tfagenciabanconome_sel)) && ! ( StringUtil.StrCmp(AV90Contabancariawwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.BancoNome = ( :AV90Contabancariawwds_23_tfagenciabanconome_sel))");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( StringUtil.StrCmp(AV90Contabancariawwds_23_tfagenciabanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.BancoNome IS NULL or (char_length(trim(trailing ' ' from T5.BancoNome))=0))");
         }
         if ( ! (0==AV91Contabancariawwds_24_tfagencianumero) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero >= :AV91Contabancariawwds_24_tfagencianumero)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( ! (0==AV92Contabancariawwds_25_tfagencianumero_to) )
         {
            AddWhere(sWhereString, "(T4.AgenciaNumero <= :AV92Contabancariawwds_25_tfagencianumero_to)");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( ! (0==AV93Contabancariawwds_26_tfcontabancarianumero) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero >= :AV93Contabancariawwds_26_tfcontabancarianumero)");
         }
         else
         {
            GXv_int3[45] = 1;
         }
         if ( ! (0==AV94Contabancariawwds_27_tfcontabancarianumero_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaNumero <= :AV94Contabancariawwds_27_tfcontabancarianumero_to)");
         }
         else
         {
            GXv_int3[46] = 1;
         }
         if ( ! (0==AV95Contabancariawwds_28_tfcontabancariadigito) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaDigito >= :AV95Contabancariawwds_28_tfcontabancariadigito)");
         }
         else
         {
            GXv_int3[47] = 1;
         }
         if ( ! (0==AV96Contabancariawwds_29_tfcontabancariadigito_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaDigito <= :AV96Contabancariawwds_29_tfcontabancariadigito_to)");
         }
         else
         {
            GXv_int3[48] = 1;
         }
         if ( ! (0==AV97Contabancariawwds_30_tfcontabancariacarteira) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCarteira >= :AV97Contabancariawwds_30_tfcontabancariacarteira)");
         }
         else
         {
            GXv_int3[49] = 1;
         }
         if ( ! (0==AV98Contabancariawwds_31_tfcontabancariacarteira_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCarteira <= :AV98Contabancariawwds_31_tfcontabancariacarteira_to)");
         }
         else
         {
            GXv_int3[50] = 1;
         }
         if ( AV99Contabancariawwds_32_tfcontabancariastatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaStatus = TRUE)");
         }
         if ( AV99Contabancariawwds_32_tfcontabancariastatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaStatus = FALSE)");
         }
         if ( ! (DateTime.MinValue==AV100Contabancariawwds_33_tfcontabancariacreatedat) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCreatedAt >= :AV100Contabancariawwds_33_tfcontabancariacreatedat)");
         }
         else
         {
            GXv_int3[51] = 1;
         }
         if ( ! (DateTime.MinValue==AV101Contabancariawwds_34_tfcontabancariacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaCreatedAt <= :AV101Contabancariawwds_34_tfcontabancariacreatedat_to)");
         }
         else
         {
            GXv_int3[52] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Contabancariawwds_36_tfcontabancariacreatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Contabancariawwds_35_tfcontabancariacreatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV102Contabancariawwds_35_tfcontabancariacreatedbyname)");
         }
         else
         {
            GXv_int3[53] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Contabancariawwds_36_tfcontabancariacreatedbyname_sel)) && ! ( StringUtil.StrCmp(AV103Contabancariawwds_36_tfcontabancariacreatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV103Contabancariawwds_36_tfcontabancariacreatedbyname_sel))");
         }
         else
         {
            GXv_int3[54] = 1;
         }
         if ( StringUtil.StrCmp(AV103Contabancariawwds_36_tfcontabancariacreatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV104Contabancariawwds_37_tfcontabancariaupdatedat) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaUpdatedAt >= :AV104Contabancariawwds_37_tfcontabancariaupdatedat)");
         }
         else
         {
            GXv_int3[55] = 1;
         }
         if ( ! (DateTime.MinValue==AV105Contabancariawwds_38_tfcontabancariaupdatedat_to) )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaUpdatedAt <= :AV105Contabancariawwds_38_tfcontabancariaupdatedat_to)");
         }
         else
         {
            GXv_int3[56] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV107Contabancariawwds_40_tfcontabancariaupdatedbyname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Contabancariawwds_39_tfcontabancariaupdatedbyname)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV106Contabancariawwds_39_tfcontabancariaupdatedbyname)");
         }
         else
         {
            GXv_int3[57] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Contabancariawwds_40_tfcontabancariaupdatedbyname_sel)) && ! ( StringUtil.StrCmp(AV107Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV107Contabancariawwds_40_tfcontabancariaupdatedbyname_sel))");
         }
         else
         {
            GXv_int3[58] = 1;
         }
         if ( StringUtil.StrCmp(AV107Contabancariawwds_40_tfcontabancariaupdatedbyname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( AV108Contabancariawwds_41_tfcontabancariaregistraboletos_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaRegistraBoletos = TRUE)");
         }
         if ( AV108Contabancariawwds_41_tfcontabancariaregistraboletos_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.ContaBancariaRegistraBoletos = FALSE)");
         }
         if ( ! (0==AV16AgenciaId) )
         {
            AddWhere(sWhereString, "(T1.AgenciaId = :AV16AgenciaId)");
         }
         else
         {
            GXv_int3[59] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ContaBancariaNumero";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ContaBancariaNumero DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T5.BancoNome";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T5.BancoNome DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.AgenciaNumero";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.AgenciaNumero DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ContaBancariaDigito";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ContaBancariaDigito DESC";
         }
         else if ( ( AV17OrderedBy == 5 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ContaBancariaCarteira";
         }
         else if ( ( AV17OrderedBy == 5 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ContaBancariaCarteira DESC";
         }
         else if ( ( AV17OrderedBy == 6 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ContaBancariaStatus";
         }
         else if ( ( AV17OrderedBy == 6 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ContaBancariaStatus DESC";
         }
         else if ( ( AV17OrderedBy == 7 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ContaBancariaCreatedAt";
         }
         else if ( ( AV17OrderedBy == 7 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ContaBancariaCreatedAt DESC";
         }
         else if ( ( AV17OrderedBy == 8 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.SecUserName";
         }
         else if ( ( AV17OrderedBy == 8 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.SecUserName DESC";
         }
         else if ( ( AV17OrderedBy == 9 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ContaBancariaUpdatedAt";
         }
         else if ( ( AV17OrderedBy == 9 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ContaBancariaUpdatedAt DESC";
         }
         else if ( ( AV17OrderedBy == 10 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.SecUserName";
         }
         else if ( ( AV17OrderedBy == 10 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.SecUserName DESC";
         }
         else if ( ( AV17OrderedBy == 11 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.ContaBancariaRegistraBoletos";
         }
         else if ( ( AV17OrderedBy == 11 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.ContaBancariaRegistraBoletos DESC";
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
                     return conditional_P00EM2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (long)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (long)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (int)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (short)dynConstraints[27] , (short)dynConstraints[28] , (long)dynConstraints[29] , (long)dynConstraints[30] , (short)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (short)dynConstraints[40] , (int)dynConstraints[41] , (string)dynConstraints[42] , (int)dynConstraints[43] , (long)dynConstraints[44] , (short)dynConstraints[45] , (long)dynConstraints[46] , (bool)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (bool)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (int)dynConstraints[53] , (short)dynConstraints[54] , (bool)dynConstraints[55] );
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
          Object[] prmP00EM2;
          prmP00EM2 = new Object[] {
          new ParDef("lV68Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV68Contabancariawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV71Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV71Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV71Contabancariawwds_4_contabancarianumero1",GXType.Int64,18,0) ,
          new ParDef("AV72Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV72Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("AV72Contabancariawwds_5_agencianumero1",GXType.Int32,9,0) ,
          new ParDef("lV73Contabancariawwds_6_contabancariacreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV73Contabancariawwds_6_contabancariacreatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV74Contabancariawwds_7_contabancariaupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("lV74Contabancariawwds_7_contabancariaupdatedbyname1",GXType.VarChar,100,0) ,
          new ParDef("AV78Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV78Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV78Contabancariawwds_11_contabancarianumero2",GXType.Int64,18,0) ,
          new ParDef("AV79Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV79Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("AV79Contabancariawwds_12_agencianumero2",GXType.Int32,9,0) ,
          new ParDef("lV80Contabancariawwds_13_contabancariacreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV80Contabancariawwds_13_contabancariacreatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV81Contabancariawwds_14_contabancariaupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("lV81Contabancariawwds_14_contabancariaupdatedbyname2",GXType.VarChar,100,0) ,
          new ParDef("AV85Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV85Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV85Contabancariawwds_18_contabancarianumero3",GXType.Int64,18,0) ,
          new ParDef("AV86Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV86Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("AV86Contabancariawwds_19_agencianumero3",GXType.Int32,9,0) ,
          new ParDef("lV87Contabancariawwds_20_contabancariacreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV87Contabancariawwds_20_contabancariacreatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV88Contabancariawwds_21_contabancariaupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV88Contabancariawwds_21_contabancariaupdatedbyname3",GXType.VarChar,100,0) ,
          new ParDef("lV89Contabancariawwds_22_tfagenciabanconome",GXType.VarChar,150,0) ,
          new ParDef("AV90Contabancariawwds_23_tfagenciabanconome_sel",GXType.VarChar,150,0) ,
          new ParDef("AV91Contabancariawwds_24_tfagencianumero",GXType.Int32,9,0) ,
          new ParDef("AV92Contabancariawwds_25_tfagencianumero_to",GXType.Int32,9,0) ,
          new ParDef("AV93Contabancariawwds_26_tfcontabancarianumero",GXType.Int64,18,0) ,
          new ParDef("AV94Contabancariawwds_27_tfcontabancarianumero_to",GXType.Int64,18,0) ,
          new ParDef("AV95Contabancariawwds_28_tfcontabancariadigito",GXType.Int16,4,0) ,
          new ParDef("AV96Contabancariawwds_29_tfcontabancariadigito_to",GXType.Int16,4,0) ,
          new ParDef("AV97Contabancariawwds_30_tfcontabancariacarteira",GXType.Int64,10,0) ,
          new ParDef("AV98Contabancariawwds_31_tfcontabancariacarteira_to",GXType.Int64,10,0) ,
          new ParDef("AV100Contabancariawwds_33_tfcontabancariacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV101Contabancariawwds_34_tfcontabancariacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV102Contabancariawwds_35_tfcontabancariacreatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV103Contabancariawwds_36_tfcontabancariacreatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV104Contabancariawwds_37_tfcontabancariaupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV105Contabancariawwds_38_tfcontabancariaupdatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV106Contabancariawwds_39_tfcontabancariaupdatedbyname",GXType.VarChar,100,0) ,
          new ParDef("AV107Contabancariawwds_40_tfcontabancariaupdatedbyname_sel",GXType.VarChar,100,0) ,
          new ParDef("AV16AgenciaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EM2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EM2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((long[]) buf[12])[0] = rslt.getLong(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((short[]) buf[14])[0] = rslt.getShort(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((long[]) buf[24])[0] = rslt.getLong(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((bool[]) buf[26])[0] = rslt.getBool(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((bool[]) buf[28])[0] = rslt.getBool(15);
                ((bool[]) buf[29])[0] = rslt.wasNull(15);
                ((int[]) buf[30])[0] = rslt.getInt(16);
                return;
       }
    }

 }

}
