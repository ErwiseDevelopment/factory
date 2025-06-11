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
   public class winvoicesexport : GXProcedure
   {
      public winvoicesexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public winvoicesexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "WInvoicesExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV19DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "NOTAFISCALUF") == 0 )
            {
               AV20NotaFiscalUF1 = (short)(Math.Round(NumberUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV20NotaFiscalUF1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fiscal UF";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  if ( ! (0==AV20NotaFiscalUF1) )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmufcod.getDescription(context,AV20NotaFiscalUF1);
                  }
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "NOTAFISCALUF") == 0 )
               {
                  AV23NotaFiscalUF2 = (short)(Math.Round(NumberUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV23NotaFiscalUF2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fiscal UF";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     if ( ! (0==AV23NotaFiscalUF2) )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmufcod.getDescription(context,AV23NotaFiscalUF2);
                     }
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV24DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV25DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "NOTAFISCALUF") == 0 )
                  {
                     AV26NotaFiscalUF3 = (short)(Math.Round(NumberUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV26NotaFiscalUF3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fiscal UF";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        if ( ! (0==AV26NotaFiscalUF3) )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmufcod.getDescription(context,AV26NotaFiscalUF3);
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFNotaFiscalNumero_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Número") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV63TFNotaFiscalNumero_Sel)) ? "(Vazio)" : AV63TFNotaFiscalNumero_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFNotaFiscalNumero)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Número") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62TFNotaFiscalNumero, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Fiscal Id";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Número";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV130Winvoicesds_1_filterfulltext = AV18FilterFullText;
         AV131Winvoicesds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV132Winvoicesds_3_notafiscaluf1 = AV20NotaFiscalUF1;
         AV133Winvoicesds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV134Winvoicesds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV135Winvoicesds_6_notafiscaluf2 = AV23NotaFiscalUF2;
         AV136Winvoicesds_7_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV137Winvoicesds_8_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV138Winvoicesds_9_notafiscaluf3 = AV26NotaFiscalUF3;
         AV139Winvoicesds_10_tfnotafiscalnumero = AV62TFNotaFiscalNumero;
         AV140Winvoicesds_11_tfnotafiscalnumero_sel = AV63TFNotaFiscalNumero_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV130Winvoicesds_1_filterfulltext ,
                                              AV131Winvoicesds_2_dynamicfiltersselector1 ,
                                              AV132Winvoicesds_3_notafiscaluf1 ,
                                              AV133Winvoicesds_4_dynamicfiltersenabled2 ,
                                              AV134Winvoicesds_5_dynamicfiltersselector2 ,
                                              AV135Winvoicesds_6_notafiscaluf2 ,
                                              AV136Winvoicesds_7_dynamicfiltersenabled3 ,
                                              AV137Winvoicesds_8_dynamicfiltersselector3 ,
                                              AV138Winvoicesds_9_notafiscaluf3 ,
                                              AV140Winvoicesds_11_tfnotafiscalnumero_sel ,
                                              AV139Winvoicesds_10_tfnotafiscalnumero ,
                                              A799NotaFiscalNumero ,
                                              A795NotaFiscalUF ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV130Winvoicesds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV130Winvoicesds_1_filterfulltext), "%", "");
         lV139Winvoicesds_10_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV139Winvoicesds_10_tfnotafiscalnumero), "%", "");
         /* Using cursor P00DN2 */
         pr_default.execute(0, new Object[] {lV130Winvoicesds_1_filterfulltext, AV132Winvoicesds_3_notafiscaluf1, AV135Winvoicesds_6_notafiscaluf2, AV138Winvoicesds_9_notafiscaluf3, lV139Winvoicesds_10_tfnotafiscalnumero, AV140Winvoicesds_11_tfnotafiscalnumero_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A795NotaFiscalUF = P00DN2_A795NotaFiscalUF[0];
            n795NotaFiscalUF = P00DN2_n795NotaFiscalUF[0];
            A799NotaFiscalNumero = P00DN2_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00DN2_n799NotaFiscalNumero[0];
            A794NotaFiscalId = P00DN2_A794NotaFiscalId[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = A794NotaFiscalId.ToString();
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A799NotaFiscalNumero, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
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
         AV28Session.Set("WWPExportFilePath", AV11Filename);
         AV28Session.Set("WWPExportFileName", "WInvoicesExport.xlsx");
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
         if ( StringUtil.StrCmp(AV28Session.Get("WInvoicesGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WInvoicesGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("WInvoicesGridState"), null, "", "");
         }
         AV16OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV141GXV1 = 1;
         while ( AV141GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV141GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO") == 0 )
            {
               AV62TFNotaFiscalNumero = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO_SEL") == 0 )
            {
               AV63TFNotaFiscalNumero_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV141GXV1 = (int)(AV141GXV1+1);
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
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV25DynamicFiltersSelector3 = "";
         AV63TFNotaFiscalNumero_Sel = "";
         AV62TFNotaFiscalNumero = "";
         AV130Winvoicesds_1_filterfulltext = "";
         AV131Winvoicesds_2_dynamicfiltersselector1 = "";
         AV134Winvoicesds_5_dynamicfiltersselector2 = "";
         AV137Winvoicesds_8_dynamicfiltersselector3 = "";
         AV139Winvoicesds_10_tfnotafiscalnumero = "";
         AV140Winvoicesds_11_tfnotafiscalnumero_sel = "";
         lV130Winvoicesds_1_filterfulltext = "";
         lV139Winvoicesds_10_tfnotafiscalnumero = "";
         A799NotaFiscalNumero = "";
         P00DN2_A795NotaFiscalUF = new short[1] ;
         P00DN2_n795NotaFiscalUF = new bool[] {false} ;
         P00DN2_A799NotaFiscalNumero = new string[] {""} ;
         P00DN2_n799NotaFiscalNumero = new bool[] {false} ;
         P00DN2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         A794NotaFiscalId = Guid.Empty;
         GXt_char1 = "";
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.winvoicesexport__default(),
            new Object[][] {
                new Object[] {
               P00DN2_A795NotaFiscalUF, P00DN2_n795NotaFiscalUF, P00DN2_A799NotaFiscalNumero, P00DN2_n799NotaFiscalNumero, P00DN2_A794NotaFiscalId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20NotaFiscalUF1 ;
      private short AV23NotaFiscalUF2 ;
      private short AV26NotaFiscalUF3 ;
      private short GXt_int2 ;
      private short AV132Winvoicesds_3_notafiscaluf1 ;
      private short AV135Winvoicesds_6_notafiscaluf2 ;
      private short AV138Winvoicesds_9_notafiscaluf3 ;
      private short A795NotaFiscalUF ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV141GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV24DynamicFiltersEnabled3 ;
      private bool AV133Winvoicesds_4_dynamicfiltersenabled2 ;
      private bool AV136Winvoicesds_7_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n795NotaFiscalUF ;
      private bool n799NotaFiscalNumero ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV25DynamicFiltersSelector3 ;
      private string AV63TFNotaFiscalNumero_Sel ;
      private string AV62TFNotaFiscalNumero ;
      private string AV130Winvoicesds_1_filterfulltext ;
      private string AV131Winvoicesds_2_dynamicfiltersselector1 ;
      private string AV134Winvoicesds_5_dynamicfiltersselector2 ;
      private string AV137Winvoicesds_8_dynamicfiltersselector3 ;
      private string AV139Winvoicesds_10_tfnotafiscalnumero ;
      private string AV140Winvoicesds_11_tfnotafiscalnumero_sel ;
      private string lV130Winvoicesds_1_filterfulltext ;
      private string lV139Winvoicesds_10_tfnotafiscalnumero ;
      private string A799NotaFiscalNumero ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV28Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P00DN2_A795NotaFiscalUF ;
      private bool[] P00DN2_n795NotaFiscalUF ;
      private string[] P00DN2_A799NotaFiscalNumero ;
      private bool[] P00DN2_n799NotaFiscalNumero ;
      private Guid[] P00DN2_A794NotaFiscalId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class winvoicesexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DN2( IGxContext context ,
                                             string AV130Winvoicesds_1_filterfulltext ,
                                             string AV131Winvoicesds_2_dynamicfiltersselector1 ,
                                             short AV132Winvoicesds_3_notafiscaluf1 ,
                                             bool AV133Winvoicesds_4_dynamicfiltersenabled2 ,
                                             string AV134Winvoicesds_5_dynamicfiltersselector2 ,
                                             short AV135Winvoicesds_6_notafiscaluf2 ,
                                             bool AV136Winvoicesds_7_dynamicfiltersenabled3 ,
                                             string AV137Winvoicesds_8_dynamicfiltersselector3 ,
                                             short AV138Winvoicesds_9_notafiscaluf3 ,
                                             string AV140Winvoicesds_11_tfnotafiscalnumero_sel ,
                                             string AV139Winvoicesds_10_tfnotafiscalnumero ,
                                             string A799NotaFiscalNumero ,
                                             short A795NotaFiscalUF ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT NotaFiscalUF, NotaFiscalNumero, NotaFiscalId FROM NotaFiscal";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Winvoicesds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( NotaFiscalNumero like '%' || :lV130Winvoicesds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV131Winvoicesds_2_dynamicfiltersselector1, "NOTAFISCALUF") == 0 ) && ( ! (0==AV132Winvoicesds_3_notafiscaluf1) ) )
         {
            AddWhere(sWhereString, "(NotaFiscalUF = :AV132Winvoicesds_3_notafiscaluf1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV133Winvoicesds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Winvoicesds_5_dynamicfiltersselector2, "NOTAFISCALUF") == 0 ) && ( ! (0==AV135Winvoicesds_6_notafiscaluf2) ) )
         {
            AddWhere(sWhereString, "(NotaFiscalUF = :AV135Winvoicesds_6_notafiscaluf2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV136Winvoicesds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV137Winvoicesds_8_dynamicfiltersselector3, "NOTAFISCALUF") == 0 ) && ( ! (0==AV138Winvoicesds_9_notafiscaluf3) ) )
         {
            AddWhere(sWhereString, "(NotaFiscalUF = :AV138Winvoicesds_9_notafiscaluf3)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Winvoicesds_11_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Winvoicesds_10_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(NotaFiscalNumero like :lV139Winvoicesds_10_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Winvoicesds_11_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV140Winvoicesds_11_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(NotaFiscalNumero = ( :AV140Winvoicesds_11_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV140Winvoicesds_11_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY NotaFiscalUF";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY NotaFiscalId";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY NotaFiscalId DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY NotaFiscalNumero";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY NotaFiscalNumero DESC";
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
                     return conditional_P00DN2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmP00DN2;
          prmP00DN2 = new Object[] {
          new ParDef("lV130Winvoicesds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV132Winvoicesds_3_notafiscaluf1",GXType.Int16,4,0) ,
          new ParDef("AV135Winvoicesds_6_notafiscaluf2",GXType.Int16,4,0) ,
          new ParDef("AV138Winvoicesds_9_notafiscaluf3",GXType.Int16,4,0) ,
          new ParDef("lV139Winvoicesds_10_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV140Winvoicesds_11_tfnotafiscalnumero_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DN2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DN2,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[4])[0] = rslt.getGuid(3);
                return;
       }
    }

 }

}
