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
   public class secuserclientewwexport : GXProcedure
   {
      public secuserclientewwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserclientewwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "SecUserClienteWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "SECUSERFULLNAME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21SecUserFullName1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21SecUserFullName1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21SecUserFullName1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV43SecUserName1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43SecUserName1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43SecUserName1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "SECUSERFULLNAME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25SecUserFullName2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SecUserFullName2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25SecUserFullName2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV44SecUserName2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44SecUserName2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44SecUserName2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "SECUSERFULLNAME") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29SecUserFullName3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29SecUserFullName3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nome", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29SecUserFullName3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV45SecUserName3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45SecUserName3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV28DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV28DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45SecUserName3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSecUserFullName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome completo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSecUserFullName_Sel)) ? "(Vazio)" : AV36TFSecUserFullName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSecUserFullName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome completo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFSecUserFullName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSecUserName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Usuário") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSecUserName_Sel)) ? "(Vazio)" : AV42TFSecUserName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecUserName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Usuário") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFSecUserName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecUserEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "E-mail") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecUserEmail_Sel)) ? "(Vazio)" : AV38TFSecUserEmail_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSecUserEmail)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "E-mail") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFSecUserEmail, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV39TFSecUserStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV39TFSecUserStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV39TFSecUserStatus_Sel == 2 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Nome completo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Usuário";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "E-mail";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV47Secuserclientewwds_1_filterfulltext = AV18FilterFullText;
         AV48Secuserclientewwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV49Secuserclientewwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV50Secuserclientewwds_4_secuserfullname1 = AV21SecUserFullName1;
         AV51Secuserclientewwds_5_secusername1 = AV43SecUserName1;
         AV52Secuserclientewwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV53Secuserclientewwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV54Secuserclientewwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV55Secuserclientewwds_9_secuserfullname2 = AV25SecUserFullName2;
         AV56Secuserclientewwds_10_secusername2 = AV44SecUserName2;
         AV57Secuserclientewwds_11_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV58Secuserclientewwds_12_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV59Secuserclientewwds_13_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV60Secuserclientewwds_14_secuserfullname3 = AV29SecUserFullName3;
         AV61Secuserclientewwds_15_secusername3 = AV45SecUserName3;
         AV62Secuserclientewwds_16_tfsecuserfullname = AV35TFSecUserFullName;
         AV63Secuserclientewwds_17_tfsecuserfullname_sel = AV36TFSecUserFullName_Sel;
         AV64Secuserclientewwds_18_tfsecusername = AV41TFSecUserName;
         AV65Secuserclientewwds_19_tfsecusername_sel = AV42TFSecUserName_Sel;
         AV66Secuserclientewwds_20_tfsecuseremail = AV37TFSecUserEmail;
         AV67Secuserclientewwds_21_tfsecuseremail_sel = AV38TFSecUserEmail_Sel;
         AV68Secuserclientewwds_22_tfsecuserstatus_sel = AV39TFSecUserStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV47Secuserclientewwds_1_filterfulltext ,
                                              AV48Secuserclientewwds_2_dynamicfiltersselector1 ,
                                              AV49Secuserclientewwds_3_dynamicfiltersoperator1 ,
                                              AV50Secuserclientewwds_4_secuserfullname1 ,
                                              AV51Secuserclientewwds_5_secusername1 ,
                                              AV52Secuserclientewwds_6_dynamicfiltersenabled2 ,
                                              AV53Secuserclientewwds_7_dynamicfiltersselector2 ,
                                              AV54Secuserclientewwds_8_dynamicfiltersoperator2 ,
                                              AV55Secuserclientewwds_9_secuserfullname2 ,
                                              AV56Secuserclientewwds_10_secusername2 ,
                                              AV57Secuserclientewwds_11_dynamicfiltersenabled3 ,
                                              AV58Secuserclientewwds_12_dynamicfiltersselector3 ,
                                              AV59Secuserclientewwds_13_dynamicfiltersoperator3 ,
                                              AV60Secuserclientewwds_14_secuserfullname3 ,
                                              AV61Secuserclientewwds_15_secusername3 ,
                                              AV63Secuserclientewwds_17_tfsecuserfullname_sel ,
                                              AV62Secuserclientewwds_16_tfsecuserfullname ,
                                              AV65Secuserclientewwds_19_tfsecusername_sel ,
                                              AV64Secuserclientewwds_18_tfsecusername ,
                                              AV67Secuserclientewwds_21_tfsecuseremail_sel ,
                                              AV66Secuserclientewwds_20_tfsecuseremail ,
                                              AV68Secuserclientewwds_22_tfsecuserstatus_sel ,
                                              A143SecUserFullName ,
                                              A141SecUserName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV40SecUserClienteId ,
                                              A210SecUserClienteId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV47Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Secuserclientewwds_1_filterfulltext), "%", "");
         lV47Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Secuserclientewwds_1_filterfulltext), "%", "");
         lV47Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Secuserclientewwds_1_filterfulltext), "%", "");
         lV47Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Secuserclientewwds_1_filterfulltext), "%", "");
         lV47Secuserclientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Secuserclientewwds_1_filterfulltext), "%", "");
         lV50Secuserclientewwds_4_secuserfullname1 = StringUtil.Concat( StringUtil.RTrim( AV50Secuserclientewwds_4_secuserfullname1), "%", "");
         lV50Secuserclientewwds_4_secuserfullname1 = StringUtil.Concat( StringUtil.RTrim( AV50Secuserclientewwds_4_secuserfullname1), "%", "");
         lV51Secuserclientewwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV51Secuserclientewwds_5_secusername1), "%", "");
         lV51Secuserclientewwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV51Secuserclientewwds_5_secusername1), "%", "");
         lV55Secuserclientewwds_9_secuserfullname2 = StringUtil.Concat( StringUtil.RTrim( AV55Secuserclientewwds_9_secuserfullname2), "%", "");
         lV55Secuserclientewwds_9_secuserfullname2 = StringUtil.Concat( StringUtil.RTrim( AV55Secuserclientewwds_9_secuserfullname2), "%", "");
         lV56Secuserclientewwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV56Secuserclientewwds_10_secusername2), "%", "");
         lV56Secuserclientewwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV56Secuserclientewwds_10_secusername2), "%", "");
         lV60Secuserclientewwds_14_secuserfullname3 = StringUtil.Concat( StringUtil.RTrim( AV60Secuserclientewwds_14_secuserfullname3), "%", "");
         lV60Secuserclientewwds_14_secuserfullname3 = StringUtil.Concat( StringUtil.RTrim( AV60Secuserclientewwds_14_secuserfullname3), "%", "");
         lV61Secuserclientewwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV61Secuserclientewwds_15_secusername3), "%", "");
         lV61Secuserclientewwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV61Secuserclientewwds_15_secusername3), "%", "");
         lV62Secuserclientewwds_16_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV62Secuserclientewwds_16_tfsecuserfullname), "%", "");
         lV64Secuserclientewwds_18_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV64Secuserclientewwds_18_tfsecusername), "%", "");
         lV66Secuserclientewwds_20_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV66Secuserclientewwds_20_tfsecuseremail), "%", "");
         /* Using cursor P006M2 */
         pr_default.execute(0, new Object[] {AV40SecUserClienteId, lV47Secuserclientewwds_1_filterfulltext, lV47Secuserclientewwds_1_filterfulltext, lV47Secuserclientewwds_1_filterfulltext, lV47Secuserclientewwds_1_filterfulltext, lV47Secuserclientewwds_1_filterfulltext, lV50Secuserclientewwds_4_secuserfullname1, lV50Secuserclientewwds_4_secuserfullname1, lV51Secuserclientewwds_5_secusername1, lV51Secuserclientewwds_5_secusername1, lV55Secuserclientewwds_9_secuserfullname2, lV55Secuserclientewwds_9_secuserfullname2, lV56Secuserclientewwds_10_secusername2, lV56Secuserclientewwds_10_secusername2, lV60Secuserclientewwds_14_secuserfullname3, lV60Secuserclientewwds_14_secuserfullname3, lV61Secuserclientewwds_15_secusername3, lV61Secuserclientewwds_15_secusername3, lV62Secuserclientewwds_16_tfsecuserfullname, AV63Secuserclientewwds_17_tfsecuserfullname_sel, lV64Secuserclientewwds_18_tfsecusername, AV65Secuserclientewwds_19_tfsecusername_sel, lV66Secuserclientewwds_20_tfsecuseremail, AV67Secuserclientewwds_21_tfsecuseremail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A210SecUserClienteId = P006M2_A210SecUserClienteId[0];
            n210SecUserClienteId = P006M2_n210SecUserClienteId[0];
            A150SecUserStatus = P006M2_A150SecUserStatus[0];
            n150SecUserStatus = P006M2_n150SecUserStatus[0];
            A144SecUserEmail = P006M2_A144SecUserEmail[0];
            n144SecUserEmail = P006M2_n144SecUserEmail[0];
            A141SecUserName = P006M2_A141SecUserName[0];
            n141SecUserName = P006M2_n141SecUserName[0];
            A143SecUserFullName = P006M2_A143SecUserFullName[0];
            n143SecUserFullName = P006M2_n143SecUserFullName[0];
            A133SecUserId = P006M2_A133SecUserId[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A143SecUserFullName, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A141SecUserName, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A144SecUserEmail, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A150SecUserStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "ATIVO";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A150SecUserStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "INATIVO";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A150SecUserStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A150SecUserStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
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
         AV31Session.Set("WWPExportFileName", "SecUserClienteWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("SecUserClienteWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SecUserClienteWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("SecUserClienteWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV69GXV1 = 1;
         while ( AV69GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV69GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV35TFSecUserFullName = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV36TFSecUserFullName_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV41TFSecUserName = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV42TFSecUserName_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL") == 0 )
            {
               AV37TFSecUserEmail = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL_SEL") == 0 )
            {
               AV38TFSecUserEmail_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERSTATUS_SEL") == 0 )
            {
               AV39TFSecUserStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV69GXV1 = (int)(AV69GXV1+1);
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
         AV21SecUserFullName1 = "";
         AV43SecUserName1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25SecUserFullName2 = "";
         AV44SecUserName2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29SecUserFullName3 = "";
         AV45SecUserName3 = "";
         AV36TFSecUserFullName_Sel = "";
         AV35TFSecUserFullName = "";
         AV42TFSecUserName_Sel = "";
         AV41TFSecUserName = "";
         AV38TFSecUserEmail_Sel = "";
         AV37TFSecUserEmail = "";
         AV47Secuserclientewwds_1_filterfulltext = "";
         AV48Secuserclientewwds_2_dynamicfiltersselector1 = "";
         AV50Secuserclientewwds_4_secuserfullname1 = "";
         AV51Secuserclientewwds_5_secusername1 = "";
         AV53Secuserclientewwds_7_dynamicfiltersselector2 = "";
         AV55Secuserclientewwds_9_secuserfullname2 = "";
         AV56Secuserclientewwds_10_secusername2 = "";
         AV58Secuserclientewwds_12_dynamicfiltersselector3 = "";
         AV60Secuserclientewwds_14_secuserfullname3 = "";
         AV61Secuserclientewwds_15_secusername3 = "";
         AV62Secuserclientewwds_16_tfsecuserfullname = "";
         AV63Secuserclientewwds_17_tfsecuserfullname_sel = "";
         AV64Secuserclientewwds_18_tfsecusername = "";
         AV65Secuserclientewwds_19_tfsecusername_sel = "";
         AV66Secuserclientewwds_20_tfsecuseremail = "";
         AV67Secuserclientewwds_21_tfsecuseremail_sel = "";
         lV47Secuserclientewwds_1_filterfulltext = "";
         lV50Secuserclientewwds_4_secuserfullname1 = "";
         lV51Secuserclientewwds_5_secusername1 = "";
         lV55Secuserclientewwds_9_secuserfullname2 = "";
         lV56Secuserclientewwds_10_secusername2 = "";
         lV60Secuserclientewwds_14_secuserfullname3 = "";
         lV61Secuserclientewwds_15_secusername3 = "";
         lV62Secuserclientewwds_16_tfsecuserfullname = "";
         lV64Secuserclientewwds_18_tfsecusername = "";
         lV66Secuserclientewwds_20_tfsecuseremail = "";
         A143SecUserFullName = "";
         A141SecUserName = "";
         A144SecUserEmail = "";
         P006M2_A210SecUserClienteId = new short[1] ;
         P006M2_n210SecUserClienteId = new bool[] {false} ;
         P006M2_A150SecUserStatus = new bool[] {false} ;
         P006M2_n150SecUserStatus = new bool[] {false} ;
         P006M2_A144SecUserEmail = new string[] {""} ;
         P006M2_n144SecUserEmail = new bool[] {false} ;
         P006M2_A141SecUserName = new string[] {""} ;
         P006M2_n141SecUserName = new bool[] {false} ;
         P006M2_A143SecUserFullName = new string[] {""} ;
         P006M2_n143SecUserFullName = new bool[] {false} ;
         P006M2_A133SecUserId = new short[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secuserclientewwexport__default(),
            new Object[][] {
                new Object[] {
               P006M2_A210SecUserClienteId, P006M2_n210SecUserClienteId, P006M2_A150SecUserStatus, P006M2_n150SecUserStatus, P006M2_A144SecUserEmail, P006M2_n144SecUserEmail, P006M2_A141SecUserName, P006M2_n141SecUserName, P006M2_A143SecUserFullName, P006M2_n143SecUserFullName,
               P006M2_A133SecUserId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV39TFSecUserStatus_Sel ;
      private short GXt_int2 ;
      private short AV49Secuserclientewwds_3_dynamicfiltersoperator1 ;
      private short AV54Secuserclientewwds_8_dynamicfiltersoperator2 ;
      private short AV59Secuserclientewwds_13_dynamicfiltersoperator3 ;
      private short AV68Secuserclientewwds_22_tfsecuserstatus_sel ;
      private short AV16OrderedBy ;
      private short AV40SecUserClienteId ;
      private short A210SecUserClienteId ;
      private short A133SecUserId ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV69GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV52Secuserclientewwds_6_dynamicfiltersenabled2 ;
      private bool AV57Secuserclientewwds_11_dynamicfiltersenabled3 ;
      private bool A150SecUserStatus ;
      private bool AV17OrderedDsc ;
      private bool n210SecUserClienteId ;
      private bool n150SecUserStatus ;
      private bool n144SecUserEmail ;
      private bool n141SecUserName ;
      private bool n143SecUserFullName ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21SecUserFullName1 ;
      private string AV43SecUserName1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25SecUserFullName2 ;
      private string AV44SecUserName2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29SecUserFullName3 ;
      private string AV45SecUserName3 ;
      private string AV36TFSecUserFullName_Sel ;
      private string AV35TFSecUserFullName ;
      private string AV42TFSecUserName_Sel ;
      private string AV41TFSecUserName ;
      private string AV38TFSecUserEmail_Sel ;
      private string AV37TFSecUserEmail ;
      private string AV47Secuserclientewwds_1_filterfulltext ;
      private string AV48Secuserclientewwds_2_dynamicfiltersselector1 ;
      private string AV50Secuserclientewwds_4_secuserfullname1 ;
      private string AV51Secuserclientewwds_5_secusername1 ;
      private string AV53Secuserclientewwds_7_dynamicfiltersselector2 ;
      private string AV55Secuserclientewwds_9_secuserfullname2 ;
      private string AV56Secuserclientewwds_10_secusername2 ;
      private string AV58Secuserclientewwds_12_dynamicfiltersselector3 ;
      private string AV60Secuserclientewwds_14_secuserfullname3 ;
      private string AV61Secuserclientewwds_15_secusername3 ;
      private string AV62Secuserclientewwds_16_tfsecuserfullname ;
      private string AV63Secuserclientewwds_17_tfsecuserfullname_sel ;
      private string AV64Secuserclientewwds_18_tfsecusername ;
      private string AV65Secuserclientewwds_19_tfsecusername_sel ;
      private string AV66Secuserclientewwds_20_tfsecuseremail ;
      private string AV67Secuserclientewwds_21_tfsecuseremail_sel ;
      private string lV47Secuserclientewwds_1_filterfulltext ;
      private string lV50Secuserclientewwds_4_secuserfullname1 ;
      private string lV51Secuserclientewwds_5_secusername1 ;
      private string lV55Secuserclientewwds_9_secuserfullname2 ;
      private string lV56Secuserclientewwds_10_secusername2 ;
      private string lV60Secuserclientewwds_14_secuserfullname3 ;
      private string lV61Secuserclientewwds_15_secusername3 ;
      private string lV62Secuserclientewwds_16_tfsecuserfullname ;
      private string lV64Secuserclientewwds_18_tfsecusername ;
      private string lV66Secuserclientewwds_20_tfsecuseremail ;
      private string A143SecUserFullName ;
      private string A141SecUserName ;
      private string A144SecUserEmail ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P006M2_A210SecUserClienteId ;
      private bool[] P006M2_n210SecUserClienteId ;
      private bool[] P006M2_A150SecUserStatus ;
      private bool[] P006M2_n150SecUserStatus ;
      private string[] P006M2_A144SecUserEmail ;
      private bool[] P006M2_n144SecUserEmail ;
      private string[] P006M2_A141SecUserName ;
      private bool[] P006M2_n141SecUserName ;
      private string[] P006M2_A143SecUserFullName ;
      private bool[] P006M2_n143SecUserFullName ;
      private short[] P006M2_A133SecUserId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class secuserclientewwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006M2( IGxContext context ,
                                             string AV47Secuserclientewwds_1_filterfulltext ,
                                             string AV48Secuserclientewwds_2_dynamicfiltersselector1 ,
                                             short AV49Secuserclientewwds_3_dynamicfiltersoperator1 ,
                                             string AV50Secuserclientewwds_4_secuserfullname1 ,
                                             string AV51Secuserclientewwds_5_secusername1 ,
                                             bool AV52Secuserclientewwds_6_dynamicfiltersenabled2 ,
                                             string AV53Secuserclientewwds_7_dynamicfiltersselector2 ,
                                             short AV54Secuserclientewwds_8_dynamicfiltersoperator2 ,
                                             string AV55Secuserclientewwds_9_secuserfullname2 ,
                                             string AV56Secuserclientewwds_10_secusername2 ,
                                             bool AV57Secuserclientewwds_11_dynamicfiltersenabled3 ,
                                             string AV58Secuserclientewwds_12_dynamicfiltersselector3 ,
                                             short AV59Secuserclientewwds_13_dynamicfiltersoperator3 ,
                                             string AV60Secuserclientewwds_14_secuserfullname3 ,
                                             string AV61Secuserclientewwds_15_secusername3 ,
                                             string AV63Secuserclientewwds_17_tfsecuserfullname_sel ,
                                             string AV62Secuserclientewwds_16_tfsecuserfullname ,
                                             string AV65Secuserclientewwds_19_tfsecusername_sel ,
                                             string AV64Secuserclientewwds_18_tfsecusername ,
                                             string AV67Secuserclientewwds_21_tfsecuseremail_sel ,
                                             string AV66Secuserclientewwds_20_tfsecuseremail ,
                                             short AV68Secuserclientewwds_22_tfsecuserstatus_sel ,
                                             string A143SecUserFullName ,
                                             string A141SecUserName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             short AV40SecUserClienteId ,
                                             short A210SecUserClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[24];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SecUserClienteId, SecUserStatus, SecUserEmail, SecUserName, SecUserFullName, SecUserId FROM SecUser";
         AddWhere(sWhereString, "(SecUserClienteId = :AV40SecUserClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Secuserclientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecUserFullName like '%' || :lV47Secuserclientewwds_1_filterfulltext) or ( SecUserName like '%' || :lV47Secuserclientewwds_1_filterfulltext) or ( SecUserEmail like '%' || :lV47Secuserclientewwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV47Secuserclientewwds_1_filterfulltext) and SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV47Secuserclientewwds_1_filterfulltext) and SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV48Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERFULLNAME") == 0 ) && ( AV49Secuserclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Secuserclientewwds_4_secuserfullname1)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV50Secuserclientewwds_4_secuserfullname1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV48Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERFULLNAME") == 0 ) && ( AV49Secuserclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Secuserclientewwds_4_secuserfullname1)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV50Secuserclientewwds_4_secuserfullname1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV48Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV49Secuserclientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Secuserclientewwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV51Secuserclientewwds_5_secusername1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV48Secuserclientewwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV49Secuserclientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Secuserclientewwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV51Secuserclientewwds_5_secusername1)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV52Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERFULLNAME") == 0 ) && ( AV54Secuserclientewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Secuserclientewwds_9_secuserfullname2)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV55Secuserclientewwds_9_secuserfullname2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV52Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERFULLNAME") == 0 ) && ( AV54Secuserclientewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Secuserclientewwds_9_secuserfullname2)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV55Secuserclientewwds_9_secuserfullname2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV52Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV54Secuserclientewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Secuserclientewwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV56Secuserclientewwds_10_secusername2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV52Secuserclientewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Secuserclientewwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV54Secuserclientewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Secuserclientewwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV56Secuserclientewwds_10_secusername2)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV57Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERFULLNAME") == 0 ) && ( AV59Secuserclientewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Secuserclientewwds_14_secuserfullname3)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV60Secuserclientewwds_14_secuserfullname3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV57Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERFULLNAME") == 0 ) && ( AV59Secuserclientewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Secuserclientewwds_14_secuserfullname3)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like '%' || :lV60Secuserclientewwds_14_secuserfullname3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV57Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV59Secuserclientewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Secuserclientewwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV61Secuserclientewwds_15_secusername3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV57Secuserclientewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Secuserclientewwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV59Secuserclientewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Secuserclientewwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV61Secuserclientewwds_15_secusername3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Secuserclientewwds_17_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Secuserclientewwds_16_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV62Secuserclientewwds_16_tfsecuserfullname)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Secuserclientewwds_17_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV63Secuserclientewwds_17_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserFullName = ( :AV63Secuserclientewwds_17_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( StringUtil.StrCmp(AV63Secuserclientewwds_17_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserFullName IS NULL or (char_length(trim(trailing ' ' from SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Secuserclientewwds_19_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Secuserclientewwds_18_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV64Secuserclientewwds_18_tfsecusername)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Secuserclientewwds_19_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV65Secuserclientewwds_19_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserName = ( :AV65Secuserclientewwds_19_tfsecusername_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV65Secuserclientewwds_19_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserName IS NULL or (char_length(trim(trailing ' ' from SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Secuserclientewwds_21_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Secuserclientewwds_20_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(SecUserEmail like :lV66Secuserclientewwds_20_tfsecuseremail)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Secuserclientewwds_21_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV67Secuserclientewwds_21_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserEmail = ( :AV67Secuserclientewwds_21_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV67Secuserclientewwds_21_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserEmail IS NULL or (char_length(trim(trailing ' ' from SecUserEmail))=0))");
         }
         if ( AV68Secuserclientewwds_22_tfsecuserstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(SecUserStatus = TRUE)");
         }
         if ( AV68Secuserclientewwds_22_tfsecuserstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY SecUserFullName";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY SecUserFullName DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY SecUserName";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY SecUserName DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY SecUserEmail";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY SecUserEmail DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY SecUserStatus";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY SecUserStatus DESC";
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
                     return conditional_P006M2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (short)dynConstraints[28] , (short)dynConstraints[29] );
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
          Object[] prmP006M2;
          prmP006M2 = new Object[] {
          new ParDef("AV40SecUserClienteId",GXType.Int16,4,0) ,
          new ParDef("lV47Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Secuserclientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Secuserclientewwds_4_secuserfullname1",GXType.VarChar,150,0) ,
          new ParDef("lV50Secuserclientewwds_4_secuserfullname1",GXType.VarChar,150,0) ,
          new ParDef("lV51Secuserclientewwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV51Secuserclientewwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV55Secuserclientewwds_9_secuserfullname2",GXType.VarChar,150,0) ,
          new ParDef("lV55Secuserclientewwds_9_secuserfullname2",GXType.VarChar,150,0) ,
          new ParDef("lV56Secuserclientewwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV56Secuserclientewwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV60Secuserclientewwds_14_secuserfullname3",GXType.VarChar,150,0) ,
          new ParDef("lV60Secuserclientewwds_14_secuserfullname3",GXType.VarChar,150,0) ,
          new ParDef("lV61Secuserclientewwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV61Secuserclientewwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV62Secuserclientewwds_16_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV63Secuserclientewwds_17_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("lV64Secuserclientewwds_18_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV65Secuserclientewwds_19_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV66Secuserclientewwds_20_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV67Secuserclientewwds_21_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006M2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
