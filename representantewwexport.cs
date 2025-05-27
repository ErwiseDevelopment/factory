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
   public class representantewwexport : GXProcedure
   {
      public representantewwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public representantewwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "RepresentanteWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "REPRESENTANTENOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV21RepresentanteNome1 = AV33GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21RepresentanteNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21RepresentanteNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "REPRESENTANTEMUNICIPIONOME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV22RepresentanteMunicipioNome1 = AV33GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22RepresentanteMunicipioNome1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22RepresentanteMunicipioNome1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "REPRESENTANTENOME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV26RepresentanteNome2 = AV33GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26RepresentanteNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26RepresentanteNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "REPRESENTANTEMUNICIPIONOME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV27RepresentanteMunicipioNome2 = AV33GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27RepresentanteMunicipioNome2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27RepresentanteMunicipioNome2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV28DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(3));
                  AV29DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "REPRESENTANTENOME") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV31RepresentanteNome3 = AV33GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31RepresentanteNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV31RepresentanteNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "REPRESENTANTEMUNICIPIONOME") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV32RepresentanteMunicipioNome3 = AV33GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32RepresentanteMunicipioNome3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Municipio Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV32RepresentanteMunicipioNome3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFRepresentanteNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV39TFRepresentanteNome_Sel)) ? "(Vazio)" : AV39TFRepresentanteNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFRepresentanteNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFRepresentanteNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFRepresentanteRG_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "RG") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV41TFRepresentanteRG_Sel)) ? "(Vazio)" : AV41TFRepresentanteRG_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFRepresentanteRG)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "RG") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFRepresentanteRG, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFRepresentanteOrgaoExpedidor_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Órgão expedidor") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV43TFRepresentanteOrgaoExpedidor_Sel)) ? "(Vazio)" : AV43TFRepresentanteOrgaoExpedidor_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFRepresentanteOrgaoExpedidor)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Órgão expedidor") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFRepresentanteOrgaoExpedidor, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFRepresentanteRGUF_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "RG") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV45TFRepresentanteRGUF_Sel)) ? "(Vazio)" : AV45TFRepresentanteRGUF_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFRepresentanteRGUF)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "RG") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFRepresentanteRGUF, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFRepresentanteCPF_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "CPF") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV47TFRepresentanteCPF_Sel)) ? "(Vazio)" : AV47TFRepresentanteCPF_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFRepresentanteCPF)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "CPF") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TFRepresentanteCPF, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV50TFRepresentanteEstadoCivil_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado Civil") ;
            AV13CellRow = GXt_int2;
            AV60i = 1;
            AV64GXV1 = 1;
            while ( AV64GXV1 <= AV50TFRepresentanteEstadoCivil_Sels.Count )
            {
               AV49TFRepresentanteEstadoCivil_Sel = ((string)AV50TFRepresentanteEstadoCivil_Sels.Item(AV64GXV1));
               if ( AV60i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmestadocivil.getDescription(context,AV49TFRepresentanteEstadoCivil_Sel);
               AV60i = (long)(AV60i+1);
               AV64GXV1 = (int)(AV64GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFRepresentanteNacionalidade_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nacionalidade") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFRepresentanteNacionalidade_Sel)) ? "(Vazio)" : AV52TFRepresentanteNacionalidade_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFRepresentanteNacionalidade)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nacionalidade") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFRepresentanteNacionalidade, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV63TFRepresentanteProfissaoDescricao_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Profissão") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV63TFRepresentanteProfissaoDescricao_Sel)) ? "(Vazio)" : AV63TFRepresentanteProfissaoDescricao_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFRepresentanteProfissaoDescricao)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Profissão") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV62TFRepresentanteProfissaoDescricao, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFRepresentanteEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Email") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV56TFRepresentanteEmail_Sel)) ? "(Vazio)" : AV56TFRepresentanteEmail_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55TFRepresentanteEmail)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Email") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV55TFRepresentanteEmail, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV59TFRepresentanteTipo_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo") ;
            AV13CellRow = GXt_int2;
            AV60i = 1;
            AV65GXV2 = 1;
            while ( AV65GXV2 <= AV59TFRepresentanteTipo_Sels.Count )
            {
               AV58TFRepresentanteTipo_Sel = ((string)AV59TFRepresentanteTipo_Sels.Item(AV65GXV2));
               if ( AV60i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmtiporepresentante.getDescription(context,AV58TFRepresentanteTipo_Sel);
               AV60i = (long)(AV60i+1);
               AV65GXV2 = (int)(AV65GXV2+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Nome";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "RG";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Órgão expedidor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "RG";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "CPF";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Estado Civil";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Nacionalidade";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Profissão";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = "Email";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Text = "Tipo";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV67Representantewwds_1_filterfulltext = AV18FilterFullText;
         AV68Representantewwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV69Representantewwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV70Representantewwds_4_representantenome1 = AV21RepresentanteNome1;
         AV71Representantewwds_5_representantemunicipionome1 = AV22RepresentanteMunicipioNome1;
         AV72Representantewwds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV73Representantewwds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV74Representantewwds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV75Representantewwds_9_representantenome2 = AV26RepresentanteNome2;
         AV76Representantewwds_10_representantemunicipionome2 = AV27RepresentanteMunicipioNome2;
         AV77Representantewwds_11_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV78Representantewwds_12_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV79Representantewwds_13_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV80Representantewwds_14_representantenome3 = AV31RepresentanteNome3;
         AV81Representantewwds_15_representantemunicipionome3 = AV32RepresentanteMunicipioNome3;
         AV82Representantewwds_16_tfrepresentantenome = AV38TFRepresentanteNome;
         AV83Representantewwds_17_tfrepresentantenome_sel = AV39TFRepresentanteNome_Sel;
         AV84Representantewwds_18_tfrepresentanterg = AV40TFRepresentanteRG;
         AV85Representantewwds_19_tfrepresentanterg_sel = AV41TFRepresentanteRG_Sel;
         AV86Representantewwds_20_tfrepresentanteorgaoexpedidor = AV42TFRepresentanteOrgaoExpedidor;
         AV87Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV43TFRepresentanteOrgaoExpedidor_Sel;
         AV88Representantewwds_22_tfrepresentanterguf = AV44TFRepresentanteRGUF;
         AV89Representantewwds_23_tfrepresentanterguf_sel = AV45TFRepresentanteRGUF_Sel;
         AV90Representantewwds_24_tfrepresentantecpf = AV46TFRepresentanteCPF;
         AV91Representantewwds_25_tfrepresentantecpf_sel = AV47TFRepresentanteCPF_Sel;
         AV92Representantewwds_26_tfrepresentanteestadocivil_sels = AV50TFRepresentanteEstadoCivil_Sels;
         AV93Representantewwds_27_tfrepresentantenacionalidade = AV51TFRepresentanteNacionalidade;
         AV94Representantewwds_28_tfrepresentantenacionalidade_sel = AV52TFRepresentanteNacionalidade_Sel;
         AV95Representantewwds_29_tfrepresentanteprofissaodescricao = AV62TFRepresentanteProfissaoDescricao;
         AV96Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV63TFRepresentanteProfissaoDescricao_Sel;
         AV97Representantewwds_31_tfrepresentanteemail = AV55TFRepresentanteEmail;
         AV98Representantewwds_32_tfrepresentanteemail_sel = AV56TFRepresentanteEmail_Sel;
         AV99Representantewwds_33_tfrepresentantetipo_sels = AV59TFRepresentanteTipo_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A984RepresentanteEstadoCivil ,
                                              AV92Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                              A998RepresentanteTipo ,
                                              AV99Representantewwds_33_tfrepresentantetipo_sels ,
                                              AV67Representantewwds_1_filterfulltext ,
                                              AV68Representantewwds_2_dynamicfiltersselector1 ,
                                              AV69Representantewwds_3_dynamicfiltersoperator1 ,
                                              AV70Representantewwds_4_representantenome1 ,
                                              AV71Representantewwds_5_representantemunicipionome1 ,
                                              AV72Representantewwds_6_dynamicfiltersenabled2 ,
                                              AV73Representantewwds_7_dynamicfiltersselector2 ,
                                              AV74Representantewwds_8_dynamicfiltersoperator2 ,
                                              AV75Representantewwds_9_representantenome2 ,
                                              AV76Representantewwds_10_representantemunicipionome2 ,
                                              AV77Representantewwds_11_dynamicfiltersenabled3 ,
                                              AV78Representantewwds_12_dynamicfiltersselector3 ,
                                              AV79Representantewwds_13_dynamicfiltersoperator3 ,
                                              AV80Representantewwds_14_representantenome3 ,
                                              AV81Representantewwds_15_representantemunicipionome3 ,
                                              AV83Representantewwds_17_tfrepresentantenome_sel ,
                                              AV82Representantewwds_16_tfrepresentantenome ,
                                              AV85Representantewwds_19_tfrepresentanterg_sel ,
                                              AV84Representantewwds_18_tfrepresentanterg ,
                                              AV87Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                              AV86Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                              AV89Representantewwds_23_tfrepresentanterguf_sel ,
                                              AV88Representantewwds_22_tfrepresentanterguf ,
                                              AV91Representantewwds_25_tfrepresentantecpf_sel ,
                                              AV90Representantewwds_24_tfrepresentantecpf ,
                                              AV92Representantewwds_26_tfrepresentanteestadocivil_sels.Count ,
                                              AV94Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                              AV93Representantewwds_27_tfrepresentantenacionalidade ,
                                              AV96Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                              AV95Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                              AV98Representantewwds_32_tfrepresentanteemail_sel ,
                                              AV97Representantewwds_31_tfrepresentanteemail ,
                                              AV99Representantewwds_33_tfrepresentantetipo_sels.Count ,
                                              A979RepresentanteNome ,
                                              A980RepresentanteRG ,
                                              A981RepresentanteOrgaoExpedidor ,
                                              A982RepresentanteRGUF ,
                                              A983RepresentanteCPF ,
                                              A985RepresentanteNacionalidade ,
                                              A999RepresentanteProfissaoDescricao ,
                                              A986RepresentanteEmail ,
                                              A997RepresentanteMunicipioNome ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV61ClienteId ,
                                              A168ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV67Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV67Representantewwds_1_filterfulltext), "%", "");
         lV70Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_4_representantenome1), "%", "");
         lV70Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV70Representantewwds_4_representantenome1), "%", "");
         lV71Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV71Representantewwds_5_representantemunicipionome1), "%", "");
         lV71Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV71Representantewwds_5_representantemunicipionome1), "%", "");
         lV75Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_9_representantenome2), "%", "");
         lV75Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_9_representantenome2), "%", "");
         lV76Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_10_representantemunicipionome2), "%", "");
         lV76Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_10_representantemunicipionome2), "%", "");
         lV80Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_14_representantenome3), "%", "");
         lV80Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_14_representantenome3), "%", "");
         lV81Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_15_representantemunicipionome3), "%", "");
         lV81Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_15_representantemunicipionome3), "%", "");
         lV82Representantewwds_16_tfrepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV82Representantewwds_16_tfrepresentantenome), "%", "");
         lV84Representantewwds_18_tfrepresentanterg = StringUtil.Concat( StringUtil.RTrim( AV84Representantewwds_18_tfrepresentanterg), "%", "");
         lV86Representantewwds_20_tfrepresentanteorgaoexpedidor = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_20_tfrepresentanteorgaoexpedidor), "%", "");
         lV88Representantewwds_22_tfrepresentanterguf = StringUtil.Concat( StringUtil.RTrim( AV88Representantewwds_22_tfrepresentanterguf), "%", "");
         lV90Representantewwds_24_tfrepresentantecpf = StringUtil.Concat( StringUtil.RTrim( AV90Representantewwds_24_tfrepresentantecpf), "%", "");
         lV93Representantewwds_27_tfrepresentantenacionalidade = StringUtil.Concat( StringUtil.RTrim( AV93Representantewwds_27_tfrepresentantenacionalidade), "%", "");
         lV95Representantewwds_29_tfrepresentanteprofissaodescricao = StringUtil.Concat( StringUtil.RTrim( AV95Representantewwds_29_tfrepresentanteprofissaodescricao), "%", "");
         lV97Representantewwds_31_tfrepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV97Representantewwds_31_tfrepresentanteemail), "%", "");
         /* Using cursor P00EY2 */
         pr_default.execute(0, new Object[] {AV61ClienteId, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV67Representantewwds_1_filterfulltext, lV70Representantewwds_4_representantenome1, lV70Representantewwds_4_representantenome1, lV71Representantewwds_5_representantemunicipionome1, lV71Representantewwds_5_representantemunicipionome1, lV75Representantewwds_9_representantenome2, lV75Representantewwds_9_representantenome2, lV76Representantewwds_10_representantemunicipionome2, lV76Representantewwds_10_representantemunicipionome2, lV80Representantewwds_14_representantenome3, lV80Representantewwds_14_representantenome3, lV81Representantewwds_15_representantemunicipionome3, lV81Representantewwds_15_representantemunicipionome3, lV82Representantewwds_16_tfrepresentantenome, AV83Representantewwds_17_tfrepresentantenome_sel, lV84Representantewwds_18_tfrepresentanterg, AV85Representantewwds_19_tfrepresentanterg_sel, lV86Representantewwds_20_tfrepresentanteorgaoexpedidor, AV87Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, lV88Representantewwds_22_tfrepresentanterguf, AV89Representantewwds_23_tfrepresentanterguf_sel, lV90Representantewwds_24_tfrepresentantecpf, AV91Representantewwds_25_tfrepresentantecpf_sel, lV93Representantewwds_27_tfrepresentantenacionalidade, AV94Representantewwds_28_tfrepresentantenacionalidade_sel, lV95Representantewwds_29_tfrepresentanteprofissaodescricao, AV96Representantewwds_30_tfrepresentanteprofissaodescricao_sel, lV97Representantewwds_31_tfrepresentanteemail, AV98Representantewwds_32_tfrepresentanteemail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A977RepresentanteProfissao = P00EY2_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = P00EY2_n977RepresentanteProfissao[0];
            A991RepresentanteMunicipio = P00EY2_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = P00EY2_n991RepresentanteMunicipio[0];
            A168ClienteId = P00EY2_A168ClienteId[0];
            n168ClienteId = P00EY2_n168ClienteId[0];
            A997RepresentanteMunicipioNome = P00EY2_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EY2_n997RepresentanteMunicipioNome[0];
            A998RepresentanteTipo = P00EY2_A998RepresentanteTipo[0];
            n998RepresentanteTipo = P00EY2_n998RepresentanteTipo[0];
            A986RepresentanteEmail = P00EY2_A986RepresentanteEmail[0];
            n986RepresentanteEmail = P00EY2_n986RepresentanteEmail[0];
            A999RepresentanteProfissaoDescricao = P00EY2_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EY2_n999RepresentanteProfissaoDescricao[0];
            A985RepresentanteNacionalidade = P00EY2_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = P00EY2_n985RepresentanteNacionalidade[0];
            A984RepresentanteEstadoCivil = P00EY2_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = P00EY2_n984RepresentanteEstadoCivil[0];
            A983RepresentanteCPF = P00EY2_A983RepresentanteCPF[0];
            n983RepresentanteCPF = P00EY2_n983RepresentanteCPF[0];
            A982RepresentanteRGUF = P00EY2_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = P00EY2_n982RepresentanteRGUF[0];
            A981RepresentanteOrgaoExpedidor = P00EY2_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = P00EY2_n981RepresentanteOrgaoExpedidor[0];
            A980RepresentanteRG = P00EY2_A980RepresentanteRG[0];
            n980RepresentanteRG = P00EY2_n980RepresentanteRG[0];
            A979RepresentanteNome = P00EY2_A979RepresentanteNome[0];
            n979RepresentanteNome = P00EY2_n979RepresentanteNome[0];
            A978RepresentanteId = P00EY2_A978RepresentanteId[0];
            A999RepresentanteProfissaoDescricao = P00EY2_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EY2_n999RepresentanteProfissaoDescricao[0];
            A997RepresentanteMunicipioNome = P00EY2_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EY2_n997RepresentanteMunicipioNome[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A979RepresentanteNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A980RepresentanteRG, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A981RepresentanteOrgaoExpedidor, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A982RepresentanteRGUF, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A983RepresentanteCPF, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = gxdomaindmestadocivil.getDescription(context,A984RepresentanteEstadoCivil);
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A985RepresentanteNacionalidade, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A999RepresentanteProfissaoDescricao, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A986RepresentanteEmail, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+8, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+9, 1, 1).Text = gxdomaindmtiporepresentante.getDescription(context,A998RepresentanteTipo);
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
         AV34Session.Set("WWPExportFileName", "RepresentanteWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV34Session.Get("RepresentanteWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "RepresentanteWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("RepresentanteWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV36GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV36GridState.gxTpr_Ordereddsc;
         AV100GXV3 = 1;
         while ( AV100GXV3 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV100GXV3));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTENOME") == 0 )
            {
               AV38TFRepresentanteNome = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTENOME_SEL") == 0 )
            {
               AV39TFRepresentanteNome_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTERG") == 0 )
            {
               AV40TFRepresentanteRG = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTERG_SEL") == 0 )
            {
               AV41TFRepresentanteRG_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEORGAOEXPEDIDOR") == 0 )
            {
               AV42TFRepresentanteOrgaoExpedidor = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEORGAOEXPEDIDOR_SEL") == 0 )
            {
               AV43TFRepresentanteOrgaoExpedidor_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTERGUF") == 0 )
            {
               AV44TFRepresentanteRGUF = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTERGUF_SEL") == 0 )
            {
               AV45TFRepresentanteRGUF_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTECPF") == 0 )
            {
               AV46TFRepresentanteCPF = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTECPF_SEL") == 0 )
            {
               AV47TFRepresentanteCPF_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEESTADOCIVIL_SEL") == 0 )
            {
               AV48TFRepresentanteEstadoCivil_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV50TFRepresentanteEstadoCivil_Sels.FromJSonString(AV48TFRepresentanteEstadoCivil_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTENACIONALIDADE") == 0 )
            {
               AV51TFRepresentanteNacionalidade = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTENACIONALIDADE_SEL") == 0 )
            {
               AV52TFRepresentanteNacionalidade_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEPROFISSAODESCRICAO") == 0 )
            {
               AV62TFRepresentanteProfissaoDescricao = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEPROFISSAODESCRICAO_SEL") == 0 )
            {
               AV63TFRepresentanteProfissaoDescricao_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEEMAIL") == 0 )
            {
               AV55TFRepresentanteEmail = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEEMAIL_SEL") == 0 )
            {
               AV56TFRepresentanteEmail_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTETIPO_SEL") == 0 )
            {
               AV57TFRepresentanteTipo_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV59TFRepresentanteTipo_Sels.FromJSonString(AV57TFRepresentanteTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTEID") == 0 )
            {
               AV61ClienteId = (int)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV100GXV3 = (int)(AV100GXV3+1);
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
         AV21RepresentanteNome1 = "";
         AV22RepresentanteMunicipioNome1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26RepresentanteNome2 = "";
         AV27RepresentanteMunicipioNome2 = "";
         AV29DynamicFiltersSelector3 = "";
         AV31RepresentanteNome3 = "";
         AV32RepresentanteMunicipioNome3 = "";
         AV39TFRepresentanteNome_Sel = "";
         AV38TFRepresentanteNome = "";
         AV41TFRepresentanteRG_Sel = "";
         AV40TFRepresentanteRG = "";
         AV43TFRepresentanteOrgaoExpedidor_Sel = "";
         AV42TFRepresentanteOrgaoExpedidor = "";
         AV45TFRepresentanteRGUF_Sel = "";
         AV44TFRepresentanteRGUF = "";
         AV47TFRepresentanteCPF_Sel = "";
         AV46TFRepresentanteCPF = "";
         AV50TFRepresentanteEstadoCivil_Sels = new GxSimpleCollection<string>();
         AV49TFRepresentanteEstadoCivil_Sel = "";
         AV52TFRepresentanteNacionalidade_Sel = "";
         AV51TFRepresentanteNacionalidade = "";
         AV63TFRepresentanteProfissaoDescricao_Sel = "";
         AV62TFRepresentanteProfissaoDescricao = "";
         AV56TFRepresentanteEmail_Sel = "";
         AV55TFRepresentanteEmail = "";
         AV59TFRepresentanteTipo_Sels = new GxSimpleCollection<string>();
         AV58TFRepresentanteTipo_Sel = "";
         AV67Representantewwds_1_filterfulltext = "";
         AV68Representantewwds_2_dynamicfiltersselector1 = "";
         AV70Representantewwds_4_representantenome1 = "";
         AV71Representantewwds_5_representantemunicipionome1 = "";
         AV73Representantewwds_7_dynamicfiltersselector2 = "";
         AV75Representantewwds_9_representantenome2 = "";
         AV76Representantewwds_10_representantemunicipionome2 = "";
         AV78Representantewwds_12_dynamicfiltersselector3 = "";
         AV80Representantewwds_14_representantenome3 = "";
         AV81Representantewwds_15_representantemunicipionome3 = "";
         AV82Representantewwds_16_tfrepresentantenome = "";
         AV83Representantewwds_17_tfrepresentantenome_sel = "";
         AV84Representantewwds_18_tfrepresentanterg = "";
         AV85Representantewwds_19_tfrepresentanterg_sel = "";
         AV86Representantewwds_20_tfrepresentanteorgaoexpedidor = "";
         AV87Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = "";
         AV88Representantewwds_22_tfrepresentanterguf = "";
         AV89Representantewwds_23_tfrepresentanterguf_sel = "";
         AV90Representantewwds_24_tfrepresentantecpf = "";
         AV91Representantewwds_25_tfrepresentantecpf_sel = "";
         AV92Representantewwds_26_tfrepresentanteestadocivil_sels = new GxSimpleCollection<string>();
         AV93Representantewwds_27_tfrepresentantenacionalidade = "";
         AV94Representantewwds_28_tfrepresentantenacionalidade_sel = "";
         AV95Representantewwds_29_tfrepresentanteprofissaodescricao = "";
         AV96Representantewwds_30_tfrepresentanteprofissaodescricao_sel = "";
         AV97Representantewwds_31_tfrepresentanteemail = "";
         AV98Representantewwds_32_tfrepresentanteemail_sel = "";
         AV99Representantewwds_33_tfrepresentantetipo_sels = new GxSimpleCollection<string>();
         lV67Representantewwds_1_filterfulltext = "";
         lV70Representantewwds_4_representantenome1 = "";
         lV71Representantewwds_5_representantemunicipionome1 = "";
         lV75Representantewwds_9_representantenome2 = "";
         lV76Representantewwds_10_representantemunicipionome2 = "";
         lV80Representantewwds_14_representantenome3 = "";
         lV81Representantewwds_15_representantemunicipionome3 = "";
         lV82Representantewwds_16_tfrepresentantenome = "";
         lV84Representantewwds_18_tfrepresentanterg = "";
         lV86Representantewwds_20_tfrepresentanteorgaoexpedidor = "";
         lV88Representantewwds_22_tfrepresentanterguf = "";
         lV90Representantewwds_24_tfrepresentantecpf = "";
         lV93Representantewwds_27_tfrepresentantenacionalidade = "";
         lV95Representantewwds_29_tfrepresentanteprofissaodescricao = "";
         lV97Representantewwds_31_tfrepresentanteemail = "";
         A984RepresentanteEstadoCivil = "";
         A998RepresentanteTipo = "";
         A979RepresentanteNome = "";
         A980RepresentanteRG = "";
         A981RepresentanteOrgaoExpedidor = "";
         A982RepresentanteRGUF = "";
         A983RepresentanteCPF = "";
         A985RepresentanteNacionalidade = "";
         A999RepresentanteProfissaoDescricao = "";
         A986RepresentanteEmail = "";
         A997RepresentanteMunicipioNome = "";
         P00EY2_A977RepresentanteProfissao = new int[1] ;
         P00EY2_n977RepresentanteProfissao = new bool[] {false} ;
         P00EY2_A991RepresentanteMunicipio = new string[] {""} ;
         P00EY2_n991RepresentanteMunicipio = new bool[] {false} ;
         P00EY2_A168ClienteId = new int[1] ;
         P00EY2_n168ClienteId = new bool[] {false} ;
         P00EY2_A997RepresentanteMunicipioNome = new string[] {""} ;
         P00EY2_n997RepresentanteMunicipioNome = new bool[] {false} ;
         P00EY2_A998RepresentanteTipo = new string[] {""} ;
         P00EY2_n998RepresentanteTipo = new bool[] {false} ;
         P00EY2_A986RepresentanteEmail = new string[] {""} ;
         P00EY2_n986RepresentanteEmail = new bool[] {false} ;
         P00EY2_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         P00EY2_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         P00EY2_A985RepresentanteNacionalidade = new string[] {""} ;
         P00EY2_n985RepresentanteNacionalidade = new bool[] {false} ;
         P00EY2_A984RepresentanteEstadoCivil = new string[] {""} ;
         P00EY2_n984RepresentanteEstadoCivil = new bool[] {false} ;
         P00EY2_A983RepresentanteCPF = new string[] {""} ;
         P00EY2_n983RepresentanteCPF = new bool[] {false} ;
         P00EY2_A982RepresentanteRGUF = new string[] {""} ;
         P00EY2_n982RepresentanteRGUF = new bool[] {false} ;
         P00EY2_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         P00EY2_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         P00EY2_A980RepresentanteRG = new string[] {""} ;
         P00EY2_n980RepresentanteRG = new bool[] {false} ;
         P00EY2_A979RepresentanteNome = new string[] {""} ;
         P00EY2_n979RepresentanteNome = new bool[] {false} ;
         P00EY2_A978RepresentanteId = new int[1] ;
         A991RepresentanteMunicipio = "";
         GXt_char1 = "";
         AV34Session = context.GetSession();
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV48TFRepresentanteEstadoCivil_SelsJson = "";
         AV57TFRepresentanteTipo_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.representantewwexport__default(),
            new Object[][] {
                new Object[] {
               P00EY2_A977RepresentanteProfissao, P00EY2_n977RepresentanteProfissao, P00EY2_A991RepresentanteMunicipio, P00EY2_n991RepresentanteMunicipio, P00EY2_A168ClienteId, P00EY2_n168ClienteId, P00EY2_A997RepresentanteMunicipioNome, P00EY2_n997RepresentanteMunicipioNome, P00EY2_A998RepresentanteTipo, P00EY2_n998RepresentanteTipo,
               P00EY2_A986RepresentanteEmail, P00EY2_n986RepresentanteEmail, P00EY2_A999RepresentanteProfissaoDescricao, P00EY2_n999RepresentanteProfissaoDescricao, P00EY2_A985RepresentanteNacionalidade, P00EY2_n985RepresentanteNacionalidade, P00EY2_A984RepresentanteEstadoCivil, P00EY2_n984RepresentanteEstadoCivil, P00EY2_A983RepresentanteCPF, P00EY2_n983RepresentanteCPF,
               P00EY2_A982RepresentanteRGUF, P00EY2_n982RepresentanteRGUF, P00EY2_A981RepresentanteOrgaoExpedidor, P00EY2_n981RepresentanteOrgaoExpedidor, P00EY2_A980RepresentanteRG, P00EY2_n980RepresentanteRG, P00EY2_A979RepresentanteNome, P00EY2_n979RepresentanteNome, P00EY2_A978RepresentanteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV30DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV69Representantewwds_3_dynamicfiltersoperator1 ;
      private short AV74Representantewwds_8_dynamicfiltersoperator2 ;
      private short AV79Representantewwds_13_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV64GXV1 ;
      private int AV65GXV2 ;
      private int AV92Representantewwds_26_tfrepresentanteestadocivil_sels_Count ;
      private int AV99Representantewwds_33_tfrepresentantetipo_sels_Count ;
      private int AV61ClienteId ;
      private int A168ClienteId ;
      private int A977RepresentanteProfissao ;
      private int A978RepresentanteId ;
      private int AV100GXV3 ;
      private long AV60i ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV28DynamicFiltersEnabled3 ;
      private bool AV72Representantewwds_6_dynamicfiltersenabled2 ;
      private bool AV77Representantewwds_11_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n977RepresentanteProfissao ;
      private bool n991RepresentanteMunicipio ;
      private bool n168ClienteId ;
      private bool n997RepresentanteMunicipioNome ;
      private bool n998RepresentanteTipo ;
      private bool n986RepresentanteEmail ;
      private bool n999RepresentanteProfissaoDescricao ;
      private bool n985RepresentanteNacionalidade ;
      private bool n984RepresentanteEstadoCivil ;
      private bool n983RepresentanteCPF ;
      private bool n982RepresentanteRGUF ;
      private bool n981RepresentanteOrgaoExpedidor ;
      private bool n980RepresentanteRG ;
      private bool n979RepresentanteNome ;
      private string AV48TFRepresentanteEstadoCivil_SelsJson ;
      private string AV57TFRepresentanteTipo_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21RepresentanteNome1 ;
      private string AV22RepresentanteMunicipioNome1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26RepresentanteNome2 ;
      private string AV27RepresentanteMunicipioNome2 ;
      private string AV29DynamicFiltersSelector3 ;
      private string AV31RepresentanteNome3 ;
      private string AV32RepresentanteMunicipioNome3 ;
      private string AV39TFRepresentanteNome_Sel ;
      private string AV38TFRepresentanteNome ;
      private string AV41TFRepresentanteRG_Sel ;
      private string AV40TFRepresentanteRG ;
      private string AV43TFRepresentanteOrgaoExpedidor_Sel ;
      private string AV42TFRepresentanteOrgaoExpedidor ;
      private string AV45TFRepresentanteRGUF_Sel ;
      private string AV44TFRepresentanteRGUF ;
      private string AV47TFRepresentanteCPF_Sel ;
      private string AV46TFRepresentanteCPF ;
      private string AV49TFRepresentanteEstadoCivil_Sel ;
      private string AV52TFRepresentanteNacionalidade_Sel ;
      private string AV51TFRepresentanteNacionalidade ;
      private string AV63TFRepresentanteProfissaoDescricao_Sel ;
      private string AV62TFRepresentanteProfissaoDescricao ;
      private string AV56TFRepresentanteEmail_Sel ;
      private string AV55TFRepresentanteEmail ;
      private string AV58TFRepresentanteTipo_Sel ;
      private string AV67Representantewwds_1_filterfulltext ;
      private string AV68Representantewwds_2_dynamicfiltersselector1 ;
      private string AV70Representantewwds_4_representantenome1 ;
      private string AV71Representantewwds_5_representantemunicipionome1 ;
      private string AV73Representantewwds_7_dynamicfiltersselector2 ;
      private string AV75Representantewwds_9_representantenome2 ;
      private string AV76Representantewwds_10_representantemunicipionome2 ;
      private string AV78Representantewwds_12_dynamicfiltersselector3 ;
      private string AV80Representantewwds_14_representantenome3 ;
      private string AV81Representantewwds_15_representantemunicipionome3 ;
      private string AV82Representantewwds_16_tfrepresentantenome ;
      private string AV83Representantewwds_17_tfrepresentantenome_sel ;
      private string AV84Representantewwds_18_tfrepresentanterg ;
      private string AV85Representantewwds_19_tfrepresentanterg_sel ;
      private string AV86Representantewwds_20_tfrepresentanteorgaoexpedidor ;
      private string AV87Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ;
      private string AV88Representantewwds_22_tfrepresentanterguf ;
      private string AV89Representantewwds_23_tfrepresentanterguf_sel ;
      private string AV90Representantewwds_24_tfrepresentantecpf ;
      private string AV91Representantewwds_25_tfrepresentantecpf_sel ;
      private string AV93Representantewwds_27_tfrepresentantenacionalidade ;
      private string AV94Representantewwds_28_tfrepresentantenacionalidade_sel ;
      private string AV95Representantewwds_29_tfrepresentanteprofissaodescricao ;
      private string AV96Representantewwds_30_tfrepresentanteprofissaodescricao_sel ;
      private string AV97Representantewwds_31_tfrepresentanteemail ;
      private string AV98Representantewwds_32_tfrepresentanteemail_sel ;
      private string lV67Representantewwds_1_filterfulltext ;
      private string lV70Representantewwds_4_representantenome1 ;
      private string lV71Representantewwds_5_representantemunicipionome1 ;
      private string lV75Representantewwds_9_representantenome2 ;
      private string lV76Representantewwds_10_representantemunicipionome2 ;
      private string lV80Representantewwds_14_representantenome3 ;
      private string lV81Representantewwds_15_representantemunicipionome3 ;
      private string lV82Representantewwds_16_tfrepresentantenome ;
      private string lV84Representantewwds_18_tfrepresentanterg ;
      private string lV86Representantewwds_20_tfrepresentanteorgaoexpedidor ;
      private string lV88Representantewwds_22_tfrepresentanterguf ;
      private string lV90Representantewwds_24_tfrepresentantecpf ;
      private string lV93Representantewwds_27_tfrepresentantenacionalidade ;
      private string lV95Representantewwds_29_tfrepresentanteprofissaodescricao ;
      private string lV97Representantewwds_31_tfrepresentanteemail ;
      private string A984RepresentanteEstadoCivil ;
      private string A998RepresentanteTipo ;
      private string A979RepresentanteNome ;
      private string A980RepresentanteRG ;
      private string A981RepresentanteOrgaoExpedidor ;
      private string A982RepresentanteRGUF ;
      private string A983RepresentanteCPF ;
      private string A985RepresentanteNacionalidade ;
      private string A999RepresentanteProfissaoDescricao ;
      private string A986RepresentanteEmail ;
      private string A997RepresentanteMunicipioNome ;
      private string A991RepresentanteMunicipio ;
      private IGxSession AV34Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV33GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV50TFRepresentanteEstadoCivil_Sels ;
      private GxSimpleCollection<string> AV59TFRepresentanteTipo_Sels ;
      private GxSimpleCollection<string> AV92Representantewwds_26_tfrepresentanteestadocivil_sels ;
      private GxSimpleCollection<string> AV99Representantewwds_33_tfrepresentantetipo_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00EY2_A977RepresentanteProfissao ;
      private bool[] P00EY2_n977RepresentanteProfissao ;
      private string[] P00EY2_A991RepresentanteMunicipio ;
      private bool[] P00EY2_n991RepresentanteMunicipio ;
      private int[] P00EY2_A168ClienteId ;
      private bool[] P00EY2_n168ClienteId ;
      private string[] P00EY2_A997RepresentanteMunicipioNome ;
      private bool[] P00EY2_n997RepresentanteMunicipioNome ;
      private string[] P00EY2_A998RepresentanteTipo ;
      private bool[] P00EY2_n998RepresentanteTipo ;
      private string[] P00EY2_A986RepresentanteEmail ;
      private bool[] P00EY2_n986RepresentanteEmail ;
      private string[] P00EY2_A999RepresentanteProfissaoDescricao ;
      private bool[] P00EY2_n999RepresentanteProfissaoDescricao ;
      private string[] P00EY2_A985RepresentanteNacionalidade ;
      private bool[] P00EY2_n985RepresentanteNacionalidade ;
      private string[] P00EY2_A984RepresentanteEstadoCivil ;
      private bool[] P00EY2_n984RepresentanteEstadoCivil ;
      private string[] P00EY2_A983RepresentanteCPF ;
      private bool[] P00EY2_n983RepresentanteCPF ;
      private string[] P00EY2_A982RepresentanteRGUF ;
      private bool[] P00EY2_n982RepresentanteRGUF ;
      private string[] P00EY2_A981RepresentanteOrgaoExpedidor ;
      private bool[] P00EY2_n981RepresentanteOrgaoExpedidor ;
      private string[] P00EY2_A980RepresentanteRG ;
      private bool[] P00EY2_n980RepresentanteRG ;
      private string[] P00EY2_A979RepresentanteNome ;
      private bool[] P00EY2_n979RepresentanteNome ;
      private int[] P00EY2_A978RepresentanteId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class representantewwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EY2( IGxContext context ,
                                             string A984RepresentanteEstadoCivil ,
                                             GxSimpleCollection<string> AV92Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                             string A998RepresentanteTipo ,
                                             GxSimpleCollection<string> AV99Representantewwds_33_tfrepresentantetipo_sels ,
                                             string AV67Representantewwds_1_filterfulltext ,
                                             string AV68Representantewwds_2_dynamicfiltersselector1 ,
                                             short AV69Representantewwds_3_dynamicfiltersoperator1 ,
                                             string AV70Representantewwds_4_representantenome1 ,
                                             string AV71Representantewwds_5_representantemunicipionome1 ,
                                             bool AV72Representantewwds_6_dynamicfiltersenabled2 ,
                                             string AV73Representantewwds_7_dynamicfiltersselector2 ,
                                             short AV74Representantewwds_8_dynamicfiltersoperator2 ,
                                             string AV75Representantewwds_9_representantenome2 ,
                                             string AV76Representantewwds_10_representantemunicipionome2 ,
                                             bool AV77Representantewwds_11_dynamicfiltersenabled3 ,
                                             string AV78Representantewwds_12_dynamicfiltersselector3 ,
                                             short AV79Representantewwds_13_dynamicfiltersoperator3 ,
                                             string AV80Representantewwds_14_representantenome3 ,
                                             string AV81Representantewwds_15_representantemunicipionome3 ,
                                             string AV83Representantewwds_17_tfrepresentantenome_sel ,
                                             string AV82Representantewwds_16_tfrepresentantenome ,
                                             string AV85Representantewwds_19_tfrepresentanterg_sel ,
                                             string AV84Representantewwds_18_tfrepresentanterg ,
                                             string AV87Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                             string AV86Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                             string AV89Representantewwds_23_tfrepresentanterguf_sel ,
                                             string AV88Representantewwds_22_tfrepresentanterguf ,
                                             string AV91Representantewwds_25_tfrepresentantecpf_sel ,
                                             string AV90Representantewwds_24_tfrepresentantecpf ,
                                             int AV92Representantewwds_26_tfrepresentanteestadocivil_sels_Count ,
                                             string AV94Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                             string AV93Representantewwds_27_tfrepresentantenacionalidade ,
                                             string AV96Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                             string AV95Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                             string AV98Representantewwds_32_tfrepresentanteemail_sel ,
                                             string AV97Representantewwds_31_tfrepresentanteemail ,
                                             int AV99Representantewwds_33_tfrepresentantetipo_sels_Count ,
                                             string A979RepresentanteNome ,
                                             string A980RepresentanteRG ,
                                             string A981RepresentanteOrgaoExpedidor ,
                                             string A982RepresentanteRGUF ,
                                             string A983RepresentanteCPF ,
                                             string A985RepresentanteNacionalidade ,
                                             string A999RepresentanteProfissaoDescricao ,
                                             string A986RepresentanteEmail ,
                                             string A997RepresentanteMunicipioNome ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             int AV61ClienteId ,
                                             int A168ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[45];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.RepresentanteProfissao AS RepresentanteProfissao, T1.RepresentanteMunicipio AS RepresentanteMunicipio, T1.ClienteId, T3.MunicipioNome AS RepresentanteMunicipioNome, T1.RepresentanteTipo, T1.RepresentanteEmail, T2.ProfissaoNome AS RepresentanteProfissaoDescricao, T1.RepresentanteNacionalidade, T1.RepresentanteEstadoCivil, T1.RepresentanteCPF, T1.RepresentanteRGUF, T1.RepresentanteOrgaoExpedidor, T1.RepresentanteRG, T1.RepresentanteNome, T1.RepresentanteId FROM ((Representante T1 LEFT JOIN Profissao T2 ON T2.ProfissaoId = T1.RepresentanteProfissao) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.RepresentanteMunicipio)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV61ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Representantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.RepresentanteNome like '%' || :lV67Representantewwds_1_filterfulltext) or ( T1.RepresentanteRG like '%' || :lV67Representantewwds_1_filterfulltext) or ( T1.RepresentanteOrgaoExpedidor like '%' || :lV67Representantewwds_1_filterfulltext) or ( T1.RepresentanteRGUF like '%' || :lV67Representantewwds_1_filterfulltext) or ( T1.RepresentanteCPF like '%' || :lV67Representantewwds_1_filterfulltext) or ( 'solteiro(a)' like '%' || LOWER(:lV67Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SOLTEIRO')) or ( 'casado(a)' like '%' || LOWER(:lV67Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'CASADO')) or ( 'divorciado(a)' like '%' || LOWER(:lV67Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'DIVORCIADO')) or ( 'viúvo(a)' like '%' || LOWER(:lV67Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'VIUVO')) or ( 'separado(a)' like '%' || LOWER(:lV67Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SEPARADO')) or ( 'união estável' like '%' || LOWER(:lV67Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'UNIAO_ESTAVEL')) or ( T1.RepresentanteNacionalidade like '%' || :lV67Representantewwds_1_filterfulltext) or ( T2.ProfissaoNome like '%' || :lV67Representantewwds_1_filterfulltext) or ( T1.RepresentanteEmail like '%' || :lV67Representantewwds_1_filterfulltext) or ( 'representante' like '%' || LOWER(:lV67Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Representante')) or ( 'responsável solidário' like '%' || LOWER(:lV67Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Responsavel_solidario')))");
         }
         else
         {
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
            GXv_int3[15] = 1;
            GXv_int3[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV69Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV70Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV69Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV70Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV69Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV71Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV68Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV69Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV71Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( AV72Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV75Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( AV72Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV75Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV72Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV76Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV72Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV76Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( AV77Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV78Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV80Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( AV77Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV78Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV80Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( AV77Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV78Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV81Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV77Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV78Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV81Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Representantewwds_17_tfrepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Representantewwds_16_tfrepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV82Representantewwds_16_tfrepresentantenome)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Representantewwds_17_tfrepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV83Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome = ( :AV83Representantewwds_17_tfrepresentantenome_sel))");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( StringUtil.StrCmp(AV83Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_19_tfrepresentanterg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Representantewwds_18_tfrepresentanterg)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG like :lV84Representantewwds_18_tfrepresentanterg)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_19_tfrepresentanterg_sel)) && ! ( StringUtil.StrCmp(AV85Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG = ( :AV85Representantewwds_19_tfrepresentanterg_sel))");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( StringUtil.StrCmp(AV85Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRG))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_20_tfrepresentanteorgaoexpedidor)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor like :lV86Representantewwds_20_tfrepresentanteorgaoexpedidor)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ! ( StringUtil.StrCmp(AV87Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor = ( :AV87Representantewwds_21_tfrepresentanteorgaoexpedidor_sel))");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( StringUtil.StrCmp(AV87Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteOrgaoExpedidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Representantewwds_23_tfrepresentanterguf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_22_tfrepresentanterguf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF like :lV88Representantewwds_22_tfrepresentanterguf)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Representantewwds_23_tfrepresentanterguf_sel)) && ! ( StringUtil.StrCmp(AV89Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF = ( :AV89Representantewwds_23_tfrepresentanterguf_sel))");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( StringUtil.StrCmp(AV89Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRGUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Representantewwds_25_tfrepresentantecpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_24_tfrepresentantecpf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF like :lV90Representantewwds_24_tfrepresentantecpf)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Representantewwds_25_tfrepresentantecpf_sel)) && ! ( StringUtil.StrCmp(AV91Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF = ( :AV91Representantewwds_25_tfrepresentantecpf_sel))");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( StringUtil.StrCmp(AV91Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteCPF))=0))");
         }
         if ( AV92Representantewwds_26_tfrepresentanteestadocivil_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV92Representantewwds_26_tfrepresentanteestadocivil_sels, "T1.RepresentanteEstadoCivil IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_28_tfrepresentantenacionalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Representantewwds_27_tfrepresentantenacionalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade like :lV93Representantewwds_27_tfrepresentantenacionalidade)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_28_tfrepresentantenacionalidade_sel)) && ! ( StringUtil.StrCmp(AV94Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade = ( :AV94Representantewwds_28_tfrepresentantenacionalidade_sel))");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( StringUtil.StrCmp(AV94Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNacionalidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Representantewwds_29_tfrepresentanteprofissaodescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome like :lV95Representantewwds_29_tfrepresentanteprofissaodescricao)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ! ( StringUtil.StrCmp(AV96Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome = ( :AV96Representantewwds_30_tfrepresentanteprofissaodescricao_sel))");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( StringUtil.StrCmp(AV96Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome IS NULL or (char_length(trim(trailing ' ' from T2.ProfissaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Representantewwds_32_tfrepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Representantewwds_31_tfrepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail like :lV97Representantewwds_31_tfrepresentanteemail)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Representantewwds_32_tfrepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV98Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail = ( :AV98Representantewwds_32_tfrepresentanteemail_sel))");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( StringUtil.StrCmp(AV98Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteEmail))=0))");
         }
         if ( AV99Representantewwds_33_tfrepresentantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV99Representantewwds_33_tfrepresentantetipo_sels, "T1.RepresentanteTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.RepresentanteNome";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.RepresentanteNome DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.RepresentanteRG";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.RepresentanteRG DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.RepresentanteOrgaoExpedidor";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.RepresentanteOrgaoExpedidor DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.RepresentanteRGUF";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.RepresentanteRGUF DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.RepresentanteCPF";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.RepresentanteCPF DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.RepresentanteEstadoCivil";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.RepresentanteEstadoCivil DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.RepresentanteNacionalidade";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.RepresentanteNacionalidade DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.ProfissaoNome";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.ProfissaoNome DESC";
         }
         else if ( ( AV16OrderedBy == 9 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.RepresentanteEmail";
         }
         else if ( ( AV16OrderedBy == 9 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.RepresentanteEmail DESC";
         }
         else if ( ( AV16OrderedBy == 10 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.RepresentanteTipo";
         }
         else if ( ( AV16OrderedBy == 10 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.RepresentanteTipo DESC";
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
                     return conditional_P00EY2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (short)dynConstraints[46] , (bool)dynConstraints[47] , (int)dynConstraints[48] , (int)dynConstraints[49] );
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
          Object[] prmP00EY2;
          prmP00EY2 = new Object[] {
          new ParDef("AV61ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV67Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV70Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV71Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV71Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV75Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV76Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV76Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV80Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV80Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV81Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV81Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV82Representantewwds_16_tfrepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV83Representantewwds_17_tfrepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV84Representantewwds_18_tfrepresentanterg",GXType.VarChar,40,0) ,
          new ParDef("AV85Representantewwds_19_tfrepresentanterg_sel",GXType.VarChar,40,0) ,
          new ParDef("lV86Representantewwds_20_tfrepresentanteorgaoexpedidor",GXType.VarChar,40,0) ,
          new ParDef("AV87Representantewwds_21_tfrepresentanteorgaoexpedidor_sel",GXType.VarChar,40,0) ,
          new ParDef("lV88Representantewwds_22_tfrepresentanterguf",GXType.VarChar,40,0) ,
          new ParDef("AV89Representantewwds_23_tfrepresentanterguf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV90Representantewwds_24_tfrepresentantecpf",GXType.VarChar,40,0) ,
          new ParDef("AV91Representantewwds_25_tfrepresentantecpf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV93Representantewwds_27_tfrepresentantenacionalidade",GXType.VarChar,60,0) ,
          new ParDef("AV94Representantewwds_28_tfrepresentantenacionalidade_sel",GXType.VarChar,60,0) ,
          new ParDef("lV95Representantewwds_29_tfrepresentanteprofissaodescricao",GXType.VarChar,90,0) ,
          new ParDef("AV96Representantewwds_30_tfrepresentanteprofissaodescricao_sel",GXType.VarChar,90,0) ,
          new ParDef("lV97Representantewwds_31_tfrepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV98Representantewwds_32_tfrepresentanteemail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EY2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EY2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                return;
       }
    }

 }

}
