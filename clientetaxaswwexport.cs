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
   public class clientetaxaswwexport : GXProcedure
   {
      public clientetaxaswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientetaxaswwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "ClienteTaxasWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "CLIENTETAXASTIPO") == 0 )
            {
               AV20ClienteTaxasTipo1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ClienteTaxasTipo1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ClienteTaxasTipo1)) )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmclientetiporisco.getDescription(context,AV20ClienteTaxasTipo1);
                  }
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CLIENTETAXASTIPO") == 0 )
               {
                  AV23ClienteTaxasTipo2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ClienteTaxasTipo2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ClienteTaxasTipo2)) )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmclientetiporisco.getDescription(context,AV23ClienteTaxasTipo2);
                     }
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV24DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV25DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV25DynamicFiltersSelector3, "CLIENTETAXASTIPO") == 0 )
                  {
                     AV26ClienteTaxasTipo3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ClienteTaxasTipo3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Tipo";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ClienteTaxasTipo3)) )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmclientetiporisco.getDescription(context,AV26ClienteTaxasTipo3);
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( ( AV34TFClienteTaxasTipo_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo") ;
            AV13CellRow = GXt_int2;
            AV50i = 1;
            AV51GXV1 = 1;
            while ( AV51GXV1 <= AV34TFClienteTaxasTipo_Sels.Count )
            {
               AV33TFClienteTaxasTipo_Sel = ((string)AV34TFClienteTaxasTipo_Sels.Item(AV51GXV1));
               if ( AV50i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmclientetiporisco.getDescription(context,AV33TFClienteTaxasTipo_Sel);
               AV50i = (long)(AV50i+1);
               AV51GXV1 = (int)(AV51GXV1+1);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV35TFClienteTaxasEfetiva) && (Convert.ToDecimal(0)==AV36TFClienteTaxasEfetiva_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Taxa Efetiva") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV35TFClienteTaxasEfetiva);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV36TFClienteTaxasEfetiva_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV37TFClienteTaxasMora) && (Convert.ToDecimal(0)==AV38TFClienteTaxasMora_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Juros Mora") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV37TFClienteTaxasMora);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV38TFClienteTaxasMora_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV39TFClienteTaxasFator) && (Convert.ToDecimal(0)==AV40TFClienteTaxasFator_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Fator") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV39TFClienteTaxasFator);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV40TFClienteTaxasFator_To);
         }
         if ( ! ( ( AV43TFClienteTaxasTipoTarifa_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo da Tarifa") ;
            AV13CellRow = GXt_int2;
            AV50i = 1;
            AV52GXV2 = 1;
            while ( AV52GXV2 <= AV43TFClienteTaxasTipoTarifa_Sels.Count )
            {
               AV42TFClienteTaxasTipoTarifa_Sel = ((string)AV43TFClienteTaxasTipoTarifa_Sels.Item(AV52GXV2));
               if ( AV50i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV42TFClienteTaxasTipoTarifa_Sel), "P") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Percentual";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV42TFClienteTaxasTipoTarifa_Sel), "V") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Valor";
               }
               AV50i = (long)(AV50i+1);
               AV52GXV2 = (int)(AV52GXV2+1);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV44TFClienteTaxasTarifa) && (Convert.ToDecimal(0)==AV45TFClienteTaxasTarifa_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tarifa") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV44TFClienteTaxasTarifa);
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV45TFClienteTaxasTarifa_To);
         }
         if ( ! ( (DateTime.MinValue==AV46TFClienteTaxasCreatedAt) && (DateTime.MinValue==AV47TFClienteTaxasCreatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Criado em") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV46TFClienteTaxasCreatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV47TFClienteTaxasCreatedAt_To;
         }
         if ( ! ( (DateTime.MinValue==AV48TFClienteTaxasUpdatedAt) && (DateTime.MinValue==AV49TFClienteTaxasUpdatedAt_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Atualizado em") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV48TFClienteTaxasUpdatedAt;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV49TFClienteTaxasUpdatedAt_To;
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Tipo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Taxa Efetiva";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Juros Mora";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Fator";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Tipo da Tarifa";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Tarifa";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Criado em";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Atualizado em";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV54Clientetaxaswwds_1_filterfulltext = AV18FilterFullText;
         AV55Clientetaxaswwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV56Clientetaxaswwds_3_clientetaxastipo1 = AV20ClienteTaxasTipo1;
         AV57Clientetaxaswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV58Clientetaxaswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV59Clientetaxaswwds_6_clientetaxastipo2 = AV23ClienteTaxasTipo2;
         AV60Clientetaxaswwds_7_dynamicfiltersenabled3 = AV24DynamicFiltersEnabled3;
         AV61Clientetaxaswwds_8_dynamicfiltersselector3 = AV25DynamicFiltersSelector3;
         AV62Clientetaxaswwds_9_clientetaxastipo3 = AV26ClienteTaxasTipo3;
         AV63Clientetaxaswwds_10_tfclientetaxastipo_sels = AV34TFClienteTaxasTipo_Sels;
         AV64Clientetaxaswwds_11_tfclientetaxasefetiva = AV35TFClienteTaxasEfetiva;
         AV65Clientetaxaswwds_12_tfclientetaxasefetiva_to = AV36TFClienteTaxasEfetiva_To;
         AV66Clientetaxaswwds_13_tfclientetaxasmora = AV37TFClienteTaxasMora;
         AV67Clientetaxaswwds_14_tfclientetaxasmora_to = AV38TFClienteTaxasMora_To;
         AV68Clientetaxaswwds_15_tfclientetaxasfator = AV39TFClienteTaxasFator;
         AV69Clientetaxaswwds_16_tfclientetaxasfator_to = AV40TFClienteTaxasFator_To;
         AV70Clientetaxaswwds_17_tfclientetaxastipotarifa_sels = AV43TFClienteTaxasTipoTarifa_Sels;
         AV71Clientetaxaswwds_18_tfclientetaxastarifa = AV44TFClienteTaxasTarifa;
         AV72Clientetaxaswwds_19_tfclientetaxastarifa_to = AV45TFClienteTaxasTarifa_To;
         AV73Clientetaxaswwds_20_tfclientetaxascreatedat = AV46TFClienteTaxasCreatedAt;
         AV74Clientetaxaswwds_21_tfclientetaxascreatedat_to = AV47TFClienteTaxasCreatedAt_To;
         AV75Clientetaxaswwds_22_tfclientetaxasupdatedat = AV48TFClienteTaxasUpdatedAt;
         AV76Clientetaxaswwds_23_tfclientetaxasupdatedat_to = AV49TFClienteTaxasUpdatedAt_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1009ClienteTaxasTipo ,
                                              AV63Clientetaxaswwds_10_tfclientetaxastipo_sels ,
                                              A1043ClienteTaxasTipoTarifa ,
                                              AV70Clientetaxaswwds_17_tfclientetaxastipotarifa_sels ,
                                              AV54Clientetaxaswwds_1_filterfulltext ,
                                              AV55Clientetaxaswwds_2_dynamicfiltersselector1 ,
                                              AV56Clientetaxaswwds_3_clientetaxastipo1 ,
                                              AV57Clientetaxaswwds_4_dynamicfiltersenabled2 ,
                                              AV58Clientetaxaswwds_5_dynamicfiltersselector2 ,
                                              AV59Clientetaxaswwds_6_clientetaxastipo2 ,
                                              AV60Clientetaxaswwds_7_dynamicfiltersenabled3 ,
                                              AV61Clientetaxaswwds_8_dynamicfiltersselector3 ,
                                              AV62Clientetaxaswwds_9_clientetaxastipo3 ,
                                              AV63Clientetaxaswwds_10_tfclientetaxastipo_sels.Count ,
                                              AV64Clientetaxaswwds_11_tfclientetaxasefetiva ,
                                              AV65Clientetaxaswwds_12_tfclientetaxasefetiva_to ,
                                              AV66Clientetaxaswwds_13_tfclientetaxasmora ,
                                              AV67Clientetaxaswwds_14_tfclientetaxasmora_to ,
                                              AV68Clientetaxaswwds_15_tfclientetaxasfator ,
                                              AV69Clientetaxaswwds_16_tfclientetaxasfator_to ,
                                              AV70Clientetaxaswwds_17_tfclientetaxastipotarifa_sels.Count ,
                                              AV71Clientetaxaswwds_18_tfclientetaxastarifa ,
                                              AV72Clientetaxaswwds_19_tfclientetaxastarifa_to ,
                                              AV73Clientetaxaswwds_20_tfclientetaxascreatedat ,
                                              AV74Clientetaxaswwds_21_tfclientetaxascreatedat_to ,
                                              AV75Clientetaxaswwds_22_tfclientetaxasupdatedat ,
                                              AV76Clientetaxaswwds_23_tfclientetaxasupdatedat_to ,
                                              A1040ClienteTaxasEfetiva ,
                                              A1041ClienteTaxasMora ,
                                              A1042ClienteTaxasFator ,
                                              A1044ClienteTaxasTarifa ,
                                              A1045ClienteTaxasCreatedAt ,
                                              A1046ClienteTaxasUpdatedAt ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV54Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Clientetaxaswwds_1_filterfulltext), "%", "");
         lV54Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Clientetaxaswwds_1_filterfulltext), "%", "");
         lV54Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Clientetaxaswwds_1_filterfulltext), "%", "");
         lV54Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Clientetaxaswwds_1_filterfulltext), "%", "");
         lV54Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Clientetaxaswwds_1_filterfulltext), "%", "");
         lV54Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Clientetaxaswwds_1_filterfulltext), "%", "");
         lV54Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Clientetaxaswwds_1_filterfulltext), "%", "");
         lV54Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Clientetaxaswwds_1_filterfulltext), "%", "");
         lV54Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Clientetaxaswwds_1_filterfulltext), "%", "");
         lV54Clientetaxaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Clientetaxaswwds_1_filterfulltext), "%", "");
         /* Using cursor P00FA2 */
         pr_default.execute(0, new Object[] {lV54Clientetaxaswwds_1_filterfulltext, lV54Clientetaxaswwds_1_filterfulltext, lV54Clientetaxaswwds_1_filterfulltext, lV54Clientetaxaswwds_1_filterfulltext, lV54Clientetaxaswwds_1_filterfulltext, lV54Clientetaxaswwds_1_filterfulltext, lV54Clientetaxaswwds_1_filterfulltext, lV54Clientetaxaswwds_1_filterfulltext, lV54Clientetaxaswwds_1_filterfulltext, lV54Clientetaxaswwds_1_filterfulltext, AV56Clientetaxaswwds_3_clientetaxastipo1, AV59Clientetaxaswwds_6_clientetaxastipo2, AV62Clientetaxaswwds_9_clientetaxastipo3, AV64Clientetaxaswwds_11_tfclientetaxasefetiva, AV65Clientetaxaswwds_12_tfclientetaxasefetiva_to, AV66Clientetaxaswwds_13_tfclientetaxasmora, AV67Clientetaxaswwds_14_tfclientetaxasmora_to, AV68Clientetaxaswwds_15_tfclientetaxasfator, AV69Clientetaxaswwds_16_tfclientetaxasfator_to, AV71Clientetaxaswwds_18_tfclientetaxastarifa, AV72Clientetaxaswwds_19_tfclientetaxastarifa_to, AV73Clientetaxaswwds_20_tfclientetaxascreatedat, AV74Clientetaxaswwds_21_tfclientetaxascreatedat_to, AV75Clientetaxaswwds_22_tfclientetaxasupdatedat, AV76Clientetaxaswwds_23_tfclientetaxasupdatedat_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1046ClienteTaxasUpdatedAt = P00FA2_A1046ClienteTaxasUpdatedAt[0];
            n1046ClienteTaxasUpdatedAt = P00FA2_n1046ClienteTaxasUpdatedAt[0];
            A1045ClienteTaxasCreatedAt = P00FA2_A1045ClienteTaxasCreatedAt[0];
            n1045ClienteTaxasCreatedAt = P00FA2_n1045ClienteTaxasCreatedAt[0];
            A1044ClienteTaxasTarifa = P00FA2_A1044ClienteTaxasTarifa[0];
            n1044ClienteTaxasTarifa = P00FA2_n1044ClienteTaxasTarifa[0];
            A1042ClienteTaxasFator = P00FA2_A1042ClienteTaxasFator[0];
            n1042ClienteTaxasFator = P00FA2_n1042ClienteTaxasFator[0];
            A1041ClienteTaxasMora = P00FA2_A1041ClienteTaxasMora[0];
            n1041ClienteTaxasMora = P00FA2_n1041ClienteTaxasMora[0];
            A1040ClienteTaxasEfetiva = P00FA2_A1040ClienteTaxasEfetiva[0];
            n1040ClienteTaxasEfetiva = P00FA2_n1040ClienteTaxasEfetiva[0];
            A1043ClienteTaxasTipoTarifa = P00FA2_A1043ClienteTaxasTipoTarifa[0];
            n1043ClienteTaxasTipoTarifa = P00FA2_n1043ClienteTaxasTipoTarifa[0];
            A1009ClienteTaxasTipo = P00FA2_A1009ClienteTaxasTipo[0];
            n1009ClienteTaxasTipo = P00FA2_n1009ClienteTaxasTipo[0];
            A1008ClienteTaxasId = P00FA2_A1008ClienteTaxasId[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = gxdomaindmclientetiporisco.getDescription(context,A1009ClienteTaxasTipo);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(A1040ClienteTaxasEfetiva);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = (double)(A1041ClienteTaxasMora);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(A1042ClienteTaxasFator);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( A1043ClienteTaxasTipoTarifa), "P") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Percentual";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A1043ClienteTaxasTipoTarifa), "V") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Valor";
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Number = (double)(A1044ClienteTaxasTarifa);
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Date = A1045ClienteTaxasCreatedAt;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Date = A1046ClienteTaxasUpdatedAt;
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
         AV28Session.Set("WWPExportFileName", "ClienteTaxasWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV28Session.Get("ClienteTaxasWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ClienteTaxasWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("ClienteTaxasWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV77GXV3 = 1;
         while ( AV77GXV3 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV77GXV3));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASTIPO_SEL") == 0 )
            {
               AV32TFClienteTaxasTipo_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV34TFClienteTaxasTipo_Sels.FromJSonString(AV32TFClienteTaxasTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASEFETIVA") == 0 )
            {
               AV35TFClienteTaxasEfetiva = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, ".");
               AV36TFClienteTaxasEfetiva_To = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASMORA") == 0 )
            {
               AV37TFClienteTaxasMora = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, ".");
               AV38TFClienteTaxasMora_To = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASFATOR") == 0 )
            {
               AV39TFClienteTaxasFator = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, ".");
               AV40TFClienteTaxasFator_To = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASTIPOTARIFA_SEL") == 0 )
            {
               AV41TFClienteTaxasTipoTarifa_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV43TFClienteTaxasTipoTarifa_Sels.FromJSonString(AV41TFClienteTaxasTipoTarifa_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASTARIFA") == 0 )
            {
               AV44TFClienteTaxasTarifa = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, ".");
               AV45TFClienteTaxasTarifa_To = NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASCREATEDAT") == 0 )
            {
               AV46TFClienteTaxasCreatedAt = context.localUtil.CToT( AV31GridStateFilterValue.gxTpr_Value, 4);
               AV47TFClienteTaxasCreatedAt_To = context.localUtil.CToT( AV31GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCLIENTETAXASUPDATEDAT") == 0 )
            {
               AV48TFClienteTaxasUpdatedAt = context.localUtil.CToT( AV31GridStateFilterValue.gxTpr_Value, 4);
               AV49TFClienteTaxasUpdatedAt_To = context.localUtil.CToT( AV31GridStateFilterValue.gxTpr_Valueto, 4);
            }
            AV77GXV3 = (int)(AV77GXV3+1);
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
         GXt_char1 = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV19DynamicFiltersSelector1 = "";
         AV20ClienteTaxasTipo1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV23ClienteTaxasTipo2 = "";
         AV25DynamicFiltersSelector3 = "";
         AV26ClienteTaxasTipo3 = "";
         AV34TFClienteTaxasTipo_Sels = new GxSimpleCollection<string>();
         AV33TFClienteTaxasTipo_Sel = "";
         AV43TFClienteTaxasTipoTarifa_Sels = new GxSimpleCollection<string>();
         AV42TFClienteTaxasTipoTarifa_Sel = "";
         AV46TFClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         AV47TFClienteTaxasCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV48TFClienteTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         AV49TFClienteTaxasUpdatedAt_To = (DateTime)(DateTime.MinValue);
         AV54Clientetaxaswwds_1_filterfulltext = "";
         AV55Clientetaxaswwds_2_dynamicfiltersselector1 = "";
         AV56Clientetaxaswwds_3_clientetaxastipo1 = "";
         AV58Clientetaxaswwds_5_dynamicfiltersselector2 = "";
         AV59Clientetaxaswwds_6_clientetaxastipo2 = "";
         AV61Clientetaxaswwds_8_dynamicfiltersselector3 = "";
         AV62Clientetaxaswwds_9_clientetaxastipo3 = "";
         AV63Clientetaxaswwds_10_tfclientetaxastipo_sels = new GxSimpleCollection<string>();
         AV70Clientetaxaswwds_17_tfclientetaxastipotarifa_sels = new GxSimpleCollection<string>();
         AV73Clientetaxaswwds_20_tfclientetaxascreatedat = (DateTime)(DateTime.MinValue);
         AV74Clientetaxaswwds_21_tfclientetaxascreatedat_to = (DateTime)(DateTime.MinValue);
         AV75Clientetaxaswwds_22_tfclientetaxasupdatedat = (DateTime)(DateTime.MinValue);
         AV76Clientetaxaswwds_23_tfclientetaxasupdatedat_to = (DateTime)(DateTime.MinValue);
         lV54Clientetaxaswwds_1_filterfulltext = "";
         A1009ClienteTaxasTipo = "";
         A1043ClienteTaxasTipoTarifa = "";
         A1045ClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         A1046ClienteTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         P00FA2_A1046ClienteTaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         P00FA2_n1046ClienteTaxasUpdatedAt = new bool[] {false} ;
         P00FA2_A1045ClienteTaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00FA2_n1045ClienteTaxasCreatedAt = new bool[] {false} ;
         P00FA2_A1044ClienteTaxasTarifa = new decimal[1] ;
         P00FA2_n1044ClienteTaxasTarifa = new bool[] {false} ;
         P00FA2_A1042ClienteTaxasFator = new decimal[1] ;
         P00FA2_n1042ClienteTaxasFator = new bool[] {false} ;
         P00FA2_A1041ClienteTaxasMora = new decimal[1] ;
         P00FA2_n1041ClienteTaxasMora = new bool[] {false} ;
         P00FA2_A1040ClienteTaxasEfetiva = new decimal[1] ;
         P00FA2_n1040ClienteTaxasEfetiva = new bool[] {false} ;
         P00FA2_A1043ClienteTaxasTipoTarifa = new string[] {""} ;
         P00FA2_n1043ClienteTaxasTipoTarifa = new bool[] {false} ;
         P00FA2_A1009ClienteTaxasTipo = new string[] {""} ;
         P00FA2_n1009ClienteTaxasTipo = new bool[] {false} ;
         P00FA2_A1008ClienteTaxasId = new int[1] ;
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV32TFClienteTaxasTipo_SelsJson = "";
         AV41TFClienteTaxasTipoTarifa_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientetaxaswwexport__default(),
            new Object[][] {
                new Object[] {
               P00FA2_A1046ClienteTaxasUpdatedAt, P00FA2_n1046ClienteTaxasUpdatedAt, P00FA2_A1045ClienteTaxasCreatedAt, P00FA2_n1045ClienteTaxasCreatedAt, P00FA2_A1044ClienteTaxasTarifa, P00FA2_n1044ClienteTaxasTarifa, P00FA2_A1042ClienteTaxasFator, P00FA2_n1042ClienteTaxasFator, P00FA2_A1041ClienteTaxasMora, P00FA2_n1041ClienteTaxasMora,
               P00FA2_A1040ClienteTaxasEfetiva, P00FA2_n1040ClienteTaxasEfetiva, P00FA2_A1043ClienteTaxasTipoTarifa, P00FA2_n1043ClienteTaxasTipoTarifa, P00FA2_A1009ClienteTaxasTipo, P00FA2_n1009ClienteTaxasTipo, P00FA2_A1008ClienteTaxasId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXt_int2 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV51GXV1 ;
      private int AV52GXV2 ;
      private int AV63Clientetaxaswwds_10_tfclientetaxastipo_sels_Count ;
      private int AV70Clientetaxaswwds_17_tfclientetaxastipotarifa_sels_Count ;
      private int A1008ClienteTaxasId ;
      private int AV77GXV3 ;
      private long AV50i ;
      private decimal AV35TFClienteTaxasEfetiva ;
      private decimal AV36TFClienteTaxasEfetiva_To ;
      private decimal AV37TFClienteTaxasMora ;
      private decimal AV38TFClienteTaxasMora_To ;
      private decimal AV39TFClienteTaxasFator ;
      private decimal AV40TFClienteTaxasFator_To ;
      private decimal AV44TFClienteTaxasTarifa ;
      private decimal AV45TFClienteTaxasTarifa_To ;
      private decimal AV64Clientetaxaswwds_11_tfclientetaxasefetiva ;
      private decimal AV65Clientetaxaswwds_12_tfclientetaxasefetiva_to ;
      private decimal AV66Clientetaxaswwds_13_tfclientetaxasmora ;
      private decimal AV67Clientetaxaswwds_14_tfclientetaxasmora_to ;
      private decimal AV68Clientetaxaswwds_15_tfclientetaxasfator ;
      private decimal AV69Clientetaxaswwds_16_tfclientetaxasfator_to ;
      private decimal AV71Clientetaxaswwds_18_tfclientetaxastarifa ;
      private decimal AV72Clientetaxaswwds_19_tfclientetaxastarifa_to ;
      private decimal A1040ClienteTaxasEfetiva ;
      private decimal A1041ClienteTaxasMora ;
      private decimal A1042ClienteTaxasFator ;
      private decimal A1044ClienteTaxasTarifa ;
      private string GXt_char1 ;
      private DateTime AV46TFClienteTaxasCreatedAt ;
      private DateTime AV47TFClienteTaxasCreatedAt_To ;
      private DateTime AV48TFClienteTaxasUpdatedAt ;
      private DateTime AV49TFClienteTaxasUpdatedAt_To ;
      private DateTime AV73Clientetaxaswwds_20_tfclientetaxascreatedat ;
      private DateTime AV74Clientetaxaswwds_21_tfclientetaxascreatedat_to ;
      private DateTime AV75Clientetaxaswwds_22_tfclientetaxasupdatedat ;
      private DateTime AV76Clientetaxaswwds_23_tfclientetaxasupdatedat_to ;
      private DateTime A1045ClienteTaxasCreatedAt ;
      private DateTime A1046ClienteTaxasUpdatedAt ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV24DynamicFiltersEnabled3 ;
      private bool AV57Clientetaxaswwds_4_dynamicfiltersenabled2 ;
      private bool AV60Clientetaxaswwds_7_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n1046ClienteTaxasUpdatedAt ;
      private bool n1045ClienteTaxasCreatedAt ;
      private bool n1044ClienteTaxasTarifa ;
      private bool n1042ClienteTaxasFator ;
      private bool n1041ClienteTaxasMora ;
      private bool n1040ClienteTaxasEfetiva ;
      private bool n1043ClienteTaxasTipoTarifa ;
      private bool n1009ClienteTaxasTipo ;
      private string AV32TFClienteTaxasTipo_SelsJson ;
      private string AV41TFClienteTaxasTipoTarifa_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV20ClienteTaxasTipo1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV23ClienteTaxasTipo2 ;
      private string AV25DynamicFiltersSelector3 ;
      private string AV26ClienteTaxasTipo3 ;
      private string AV33TFClienteTaxasTipo_Sel ;
      private string AV42TFClienteTaxasTipoTarifa_Sel ;
      private string AV54Clientetaxaswwds_1_filterfulltext ;
      private string AV55Clientetaxaswwds_2_dynamicfiltersselector1 ;
      private string AV56Clientetaxaswwds_3_clientetaxastipo1 ;
      private string AV58Clientetaxaswwds_5_dynamicfiltersselector2 ;
      private string AV59Clientetaxaswwds_6_clientetaxastipo2 ;
      private string AV61Clientetaxaswwds_8_dynamicfiltersselector3 ;
      private string AV62Clientetaxaswwds_9_clientetaxastipo3 ;
      private string lV54Clientetaxaswwds_1_filterfulltext ;
      private string A1009ClienteTaxasTipo ;
      private string A1043ClienteTaxasTipoTarifa ;
      private IGxSession AV28Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV34TFClienteTaxasTipo_Sels ;
      private GxSimpleCollection<string> AV43TFClienteTaxasTipoTarifa_Sels ;
      private GxSimpleCollection<string> AV63Clientetaxaswwds_10_tfclientetaxastipo_sels ;
      private GxSimpleCollection<string> AV70Clientetaxaswwds_17_tfclientetaxastipotarifa_sels ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00FA2_A1046ClienteTaxasUpdatedAt ;
      private bool[] P00FA2_n1046ClienteTaxasUpdatedAt ;
      private DateTime[] P00FA2_A1045ClienteTaxasCreatedAt ;
      private bool[] P00FA2_n1045ClienteTaxasCreatedAt ;
      private decimal[] P00FA2_A1044ClienteTaxasTarifa ;
      private bool[] P00FA2_n1044ClienteTaxasTarifa ;
      private decimal[] P00FA2_A1042ClienteTaxasFator ;
      private bool[] P00FA2_n1042ClienteTaxasFator ;
      private decimal[] P00FA2_A1041ClienteTaxasMora ;
      private bool[] P00FA2_n1041ClienteTaxasMora ;
      private decimal[] P00FA2_A1040ClienteTaxasEfetiva ;
      private bool[] P00FA2_n1040ClienteTaxasEfetiva ;
      private string[] P00FA2_A1043ClienteTaxasTipoTarifa ;
      private bool[] P00FA2_n1043ClienteTaxasTipoTarifa ;
      private string[] P00FA2_A1009ClienteTaxasTipo ;
      private bool[] P00FA2_n1009ClienteTaxasTipo ;
      private int[] P00FA2_A1008ClienteTaxasId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class clientetaxaswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FA2( IGxContext context ,
                                             string A1009ClienteTaxasTipo ,
                                             GxSimpleCollection<string> AV63Clientetaxaswwds_10_tfclientetaxastipo_sels ,
                                             string A1043ClienteTaxasTipoTarifa ,
                                             GxSimpleCollection<string> AV70Clientetaxaswwds_17_tfclientetaxastipotarifa_sels ,
                                             string AV54Clientetaxaswwds_1_filterfulltext ,
                                             string AV55Clientetaxaswwds_2_dynamicfiltersselector1 ,
                                             string AV56Clientetaxaswwds_3_clientetaxastipo1 ,
                                             bool AV57Clientetaxaswwds_4_dynamicfiltersenabled2 ,
                                             string AV58Clientetaxaswwds_5_dynamicfiltersselector2 ,
                                             string AV59Clientetaxaswwds_6_clientetaxastipo2 ,
                                             bool AV60Clientetaxaswwds_7_dynamicfiltersenabled3 ,
                                             string AV61Clientetaxaswwds_8_dynamicfiltersselector3 ,
                                             string AV62Clientetaxaswwds_9_clientetaxastipo3 ,
                                             int AV63Clientetaxaswwds_10_tfclientetaxastipo_sels_Count ,
                                             decimal AV64Clientetaxaswwds_11_tfclientetaxasefetiva ,
                                             decimal AV65Clientetaxaswwds_12_tfclientetaxasefetiva_to ,
                                             decimal AV66Clientetaxaswwds_13_tfclientetaxasmora ,
                                             decimal AV67Clientetaxaswwds_14_tfclientetaxasmora_to ,
                                             decimal AV68Clientetaxaswwds_15_tfclientetaxasfator ,
                                             decimal AV69Clientetaxaswwds_16_tfclientetaxasfator_to ,
                                             int AV70Clientetaxaswwds_17_tfclientetaxastipotarifa_sels_Count ,
                                             decimal AV71Clientetaxaswwds_18_tfclientetaxastarifa ,
                                             decimal AV72Clientetaxaswwds_19_tfclientetaxastarifa_to ,
                                             DateTime AV73Clientetaxaswwds_20_tfclientetaxascreatedat ,
                                             DateTime AV74Clientetaxaswwds_21_tfclientetaxascreatedat_to ,
                                             DateTime AV75Clientetaxaswwds_22_tfclientetaxasupdatedat ,
                                             DateTime AV76Clientetaxaswwds_23_tfclientetaxasupdatedat_to ,
                                             decimal A1040ClienteTaxasEfetiva ,
                                             decimal A1041ClienteTaxasMora ,
                                             decimal A1042ClienteTaxasFator ,
                                             decimal A1044ClienteTaxasTarifa ,
                                             DateTime A1045ClienteTaxasCreatedAt ,
                                             DateTime A1046ClienteTaxasUpdatedAt ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[25];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT ClienteTaxasUpdatedAt, ClienteTaxasCreatedAt, ClienteTaxasTarifa, ClienteTaxasFator, ClienteTaxasMora, ClienteTaxasEfetiva, ClienteTaxasTipoTarifa, ClienteTaxasTipo, ClienteTaxasId FROM ClienteTaxas";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Clientetaxaswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( 'sem risco' like '%' || LOWER(:lV54Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipo = ( 'SEM_RISCO')) or ( 'risco baixo' like '%' || LOWER(:lV54Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipo = ( 'BAIXO')) or ( 'risco alto' like '%' || LOWER(:lV54Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipo = ( 'ALTO')) or ( 'cliente premium' like '%' || LOWER(:lV54Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipo = ( 'PREMIUM')) or ( SUBSTR(TO_CHAR(ClienteTaxasEfetiva,'99999999990.9999'), 2) like '%' || :lV54Clientetaxaswwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(ClienteTaxasMora,'99999999990.9999'), 2) like '%' || :lV54Clientetaxaswwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(ClienteTaxasFator,'99999999990.9999'), 2) like '%' || :lV54Clientetaxaswwds_1_filterfulltext) or ( 'percentual' like '%' || LOWER(:lV54Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipoTarifa = ( 'P')) or ( 'valor' like '%' || LOWER(:lV54Clientetaxaswwds_1_filterfulltext) and ClienteTaxasTipoTarifa = ( 'V')) or ( SUBSTR(TO_CHAR(ClienteTaxasTarifa,'999999999990.99'), 2) like '%' || :lV54Clientetaxaswwds_1_filterfulltext))");
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
         }
         if ( ( StringUtil.StrCmp(AV55Clientetaxaswwds_2_dynamicfiltersselector1, "CLIENTETAXASTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Clientetaxaswwds_3_clientetaxastipo1)) ) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTipo = ( :AV56Clientetaxaswwds_3_clientetaxastipo1))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV57Clientetaxaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Clientetaxaswwds_5_dynamicfiltersselector2, "CLIENTETAXASTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Clientetaxaswwds_6_clientetaxastipo2)) ) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTipo = ( :AV59Clientetaxaswwds_6_clientetaxastipo2))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV60Clientetaxaswwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Clientetaxaswwds_8_dynamicfiltersselector3, "CLIENTETAXASTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Clientetaxaswwds_9_clientetaxastipo3)) ) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTipo = ( :AV62Clientetaxaswwds_9_clientetaxastipo3))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV63Clientetaxaswwds_10_tfclientetaxastipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV63Clientetaxaswwds_10_tfclientetaxastipo_sels, "ClienteTaxasTipo IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV64Clientetaxaswwds_11_tfclientetaxasefetiva) )
         {
            AddWhere(sWhereString, "(ClienteTaxasEfetiva >= :AV64Clientetaxaswwds_11_tfclientetaxasefetiva)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV65Clientetaxaswwds_12_tfclientetaxasefetiva_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasEfetiva <= :AV65Clientetaxaswwds_12_tfclientetaxasefetiva_to)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV66Clientetaxaswwds_13_tfclientetaxasmora) )
         {
            AddWhere(sWhereString, "(ClienteTaxasMora >= :AV66Clientetaxaswwds_13_tfclientetaxasmora)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV67Clientetaxaswwds_14_tfclientetaxasmora_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasMora <= :AV67Clientetaxaswwds_14_tfclientetaxasmora_to)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV68Clientetaxaswwds_15_tfclientetaxasfator) )
         {
            AddWhere(sWhereString, "(ClienteTaxasFator >= :AV68Clientetaxaswwds_15_tfclientetaxasfator)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV69Clientetaxaswwds_16_tfclientetaxasfator_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasFator <= :AV69Clientetaxaswwds_16_tfclientetaxasfator_to)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV70Clientetaxaswwds_17_tfclientetaxastipotarifa_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV70Clientetaxaswwds_17_tfclientetaxastipotarifa_sels, "ClienteTaxasTipoTarifa IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV71Clientetaxaswwds_18_tfclientetaxastarifa) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTarifa >= :AV71Clientetaxaswwds_18_tfclientetaxastarifa)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV72Clientetaxaswwds_19_tfclientetaxastarifa_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasTarifa <= :AV72Clientetaxaswwds_19_tfclientetaxastarifa_to)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV73Clientetaxaswwds_20_tfclientetaxascreatedat) )
         {
            AddWhere(sWhereString, "(ClienteTaxasCreatedAt >= :AV73Clientetaxaswwds_20_tfclientetaxascreatedat)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV74Clientetaxaswwds_21_tfclientetaxascreatedat_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasCreatedAt <= :AV74Clientetaxaswwds_21_tfclientetaxascreatedat_to)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV75Clientetaxaswwds_22_tfclientetaxasupdatedat) )
         {
            AddWhere(sWhereString, "(ClienteTaxasUpdatedAt >= :AV75Clientetaxaswwds_22_tfclientetaxasupdatedat)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Clientetaxaswwds_23_tfclientetaxasupdatedat_to) )
         {
            AddWhere(sWhereString, "(ClienteTaxasUpdatedAt <= :AV76Clientetaxaswwds_23_tfclientetaxasupdatedat_to)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ClienteTaxasTipo";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ClienteTaxasTipo DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ClienteTaxasEfetiva";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ClienteTaxasEfetiva DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ClienteTaxasMora";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ClienteTaxasMora DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ClienteTaxasFator";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ClienteTaxasFator DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ClienteTaxasTipoTarifa";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ClienteTaxasTipoTarifa DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ClienteTaxasTarifa";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ClienteTaxasTarifa DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ClienteTaxasCreatedAt";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ClienteTaxasCreatedAt DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ClienteTaxasUpdatedAt";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ClienteTaxasUpdatedAt DESC";
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
                     return conditional_P00FA2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (int)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (decimal)dynConstraints[29] , (decimal)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] );
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
          Object[] prmP00FA2;
          prmP00FA2 = new Object[] {
          new ParDef("lV54Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Clientetaxaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV56Clientetaxaswwds_3_clientetaxastipo1",GXType.VarChar,40,0) ,
          new ParDef("AV59Clientetaxaswwds_6_clientetaxastipo2",GXType.VarChar,40,0) ,
          new ParDef("AV62Clientetaxaswwds_9_clientetaxastipo3",GXType.VarChar,40,0) ,
          new ParDef("AV64Clientetaxaswwds_11_tfclientetaxasefetiva",GXType.Number,16,4) ,
          new ParDef("AV65Clientetaxaswwds_12_tfclientetaxasefetiva_to",GXType.Number,16,4) ,
          new ParDef("AV66Clientetaxaswwds_13_tfclientetaxasmora",GXType.Number,16,4) ,
          new ParDef("AV67Clientetaxaswwds_14_tfclientetaxasmora_to",GXType.Number,16,4) ,
          new ParDef("AV68Clientetaxaswwds_15_tfclientetaxasfator",GXType.Number,16,4) ,
          new ParDef("AV69Clientetaxaswwds_16_tfclientetaxasfator_to",GXType.Number,16,4) ,
          new ParDef("AV71Clientetaxaswwds_18_tfclientetaxastarifa",GXType.Number,15,2) ,
          new ParDef("AV72Clientetaxaswwds_19_tfclientetaxastarifa_to",GXType.Number,15,2) ,
          new ParDef("AV73Clientetaxaswwds_20_tfclientetaxascreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV74Clientetaxaswwds_21_tfclientetaxascreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("AV75Clientetaxaswwds_22_tfclientetaxasupdatedat",GXType.DateTime,8,5) ,
          new ParDef("AV76Clientetaxaswwds_23_tfclientetaxasupdatedat_to",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00FA2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FA2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((int[]) buf[16])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
