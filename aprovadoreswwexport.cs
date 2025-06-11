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
   public class aprovadoreswwexport : GXProcedure
   {
      public aprovadoreswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprovadoreswwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "AprovadoresWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "APROVADORESSTATUS") == 0 )
            {
               AV43AprovadoresStatus1 = BooleanUtil.Val( AV33GridStateDynamicFilter.gxTpr_Value);
               if ( ! (false==AV43AprovadoresStatus1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Status";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                  if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( AV43AprovadoresStatus1)), "true") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Ativo";
                  }
                  else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( AV43AprovadoresStatus1)), "false") == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Inativo";
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
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "APROVADORESSTATUS") == 0 )
               {
                  AV44AprovadoresStatus2 = BooleanUtil.Val( AV33GridStateDynamicFilter.gxTpr_Value);
                  if ( ! (false==AV44AprovadoresStatus2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Status";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                     if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( AV44AprovadoresStatus2)), "true") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Ativo";
                     }
                     else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( AV44AprovadoresStatus2)), "false") == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Inativo";
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
                  if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "APROVADORESSTATUS") == 0 )
                  {
                     AV45AprovadoresStatus3 = BooleanUtil.Val( AV33GridStateDynamicFilter.gxTpr_Value);
                     if ( ! (false==AV45AprovadoresStatus3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Status";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
                        if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( AV45AprovadoresStatus3)), "true") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Ativo";
                        }
                        else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( AV45AprovadoresStatus3)), "false") == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Inativo";
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
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecUserEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "E-mail") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV41TFSecUserEmail_Sel)) ? "(Vazio)" : AV41TFSecUserEmail_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecUserEmail)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "E-mail") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFSecUserEmail, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV42TFAprovadoresStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV42TFAprovadoresStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV42TFAprovadoresStatus_Sel == 2 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Usuário";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "E-mail";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV47Aprovadoreswwds_1_filterfulltext = AV18FilterFullText;
         AV48Aprovadoreswwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV49Aprovadoreswwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV50Aprovadoreswwds_4_aprovadoresstatus1 = AV43AprovadoresStatus1;
         AV51Aprovadoreswwds_5_secusername1 = AV22SecUserName1;
         AV52Aprovadoreswwds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV53Aprovadoreswwds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV54Aprovadoreswwds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV55Aprovadoreswwds_9_aprovadoresstatus2 = AV44AprovadoresStatus2;
         AV56Aprovadoreswwds_10_secusername2 = AV27SecUserName2;
         AV57Aprovadoreswwds_11_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV58Aprovadoreswwds_12_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV59Aprovadoreswwds_13_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV60Aprovadoreswwds_14_aprovadoresstatus3 = AV45AprovadoresStatus3;
         AV61Aprovadoreswwds_15_secusername3 = AV32SecUserName3;
         AV62Aprovadoreswwds_16_tfsecusername = AV38TFSecUserName;
         AV63Aprovadoreswwds_17_tfsecusername_sel = AV39TFSecUserName_Sel;
         AV64Aprovadoreswwds_18_tfsecuseremail = AV40TFSecUserEmail;
         AV65Aprovadoreswwds_19_tfsecuseremail_sel = AV41TFSecUserEmail_Sel;
         AV66Aprovadoreswwds_20_tfaprovadoresstatus_sel = AV42TFAprovadoresStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV47Aprovadoreswwds_1_filterfulltext ,
                                              AV48Aprovadoreswwds_2_dynamicfiltersselector1 ,
                                              AV50Aprovadoreswwds_4_aprovadoresstatus1 ,
                                              AV49Aprovadoreswwds_3_dynamicfiltersoperator1 ,
                                              AV51Aprovadoreswwds_5_secusername1 ,
                                              AV52Aprovadoreswwds_6_dynamicfiltersenabled2 ,
                                              AV53Aprovadoreswwds_7_dynamicfiltersselector2 ,
                                              AV55Aprovadoreswwds_9_aprovadoresstatus2 ,
                                              AV54Aprovadoreswwds_8_dynamicfiltersoperator2 ,
                                              AV56Aprovadoreswwds_10_secusername2 ,
                                              AV57Aprovadoreswwds_11_dynamicfiltersenabled3 ,
                                              AV58Aprovadoreswwds_12_dynamicfiltersselector3 ,
                                              AV60Aprovadoreswwds_14_aprovadoresstatus3 ,
                                              AV59Aprovadoreswwds_13_dynamicfiltersoperator3 ,
                                              AV61Aprovadoreswwds_15_secusername3 ,
                                              AV63Aprovadoreswwds_17_tfsecusername_sel ,
                                              AV62Aprovadoreswwds_16_tfsecusername ,
                                              AV65Aprovadoreswwds_19_tfsecuseremail_sel ,
                                              AV64Aprovadoreswwds_18_tfsecuseremail ,
                                              AV66Aprovadoreswwds_20_tfaprovadoresstatus_sel ,
                                              A141SecUserName ,
                                              A144SecUserEmail ,
                                              A380AprovadoresStatus ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV47Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Aprovadoreswwds_1_filterfulltext), "%", "");
         lV47Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Aprovadoreswwds_1_filterfulltext), "%", "");
         lV47Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Aprovadoreswwds_1_filterfulltext), "%", "");
         lV47Aprovadoreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV47Aprovadoreswwds_1_filterfulltext), "%", "");
         lV51Aprovadoreswwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV51Aprovadoreswwds_5_secusername1), "%", "");
         lV51Aprovadoreswwds_5_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV51Aprovadoreswwds_5_secusername1), "%", "");
         lV56Aprovadoreswwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV56Aprovadoreswwds_10_secusername2), "%", "");
         lV56Aprovadoreswwds_10_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV56Aprovadoreswwds_10_secusername2), "%", "");
         lV61Aprovadoreswwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV61Aprovadoreswwds_15_secusername3), "%", "");
         lV61Aprovadoreswwds_15_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV61Aprovadoreswwds_15_secusername3), "%", "");
         lV62Aprovadoreswwds_16_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV62Aprovadoreswwds_16_tfsecusername), "%", "");
         lV64Aprovadoreswwds_18_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV64Aprovadoreswwds_18_tfsecuseremail), "%", "");
         /* Using cursor P009E2 */
         pr_default.execute(0, new Object[] {lV47Aprovadoreswwds_1_filterfulltext, lV47Aprovadoreswwds_1_filterfulltext, lV47Aprovadoreswwds_1_filterfulltext, lV47Aprovadoreswwds_1_filterfulltext, AV50Aprovadoreswwds_4_aprovadoresstatus1, lV51Aprovadoreswwds_5_secusername1, lV51Aprovadoreswwds_5_secusername1, AV55Aprovadoreswwds_9_aprovadoresstatus2, lV56Aprovadoreswwds_10_secusername2, lV56Aprovadoreswwds_10_secusername2, AV60Aprovadoreswwds_14_aprovadoresstatus3, lV61Aprovadoreswwds_15_secusername3, lV61Aprovadoreswwds_15_secusername3, lV62Aprovadoreswwds_16_tfsecusername, AV63Aprovadoreswwds_17_tfsecusername_sel, lV64Aprovadoreswwds_18_tfsecuseremail, AV65Aprovadoreswwds_19_tfsecuseremail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133SecUserId = P009E2_A133SecUserId[0];
            n133SecUserId = P009E2_n133SecUserId[0];
            A380AprovadoresStatus = P009E2_A380AprovadoresStatus[0];
            n380AprovadoresStatus = P009E2_n380AprovadoresStatus[0];
            A144SecUserEmail = P009E2_A144SecUserEmail[0];
            n144SecUserEmail = P009E2_n144SecUserEmail[0];
            A141SecUserName = P009E2_A141SecUserName[0];
            n141SecUserName = P009E2_n141SecUserName[0];
            A375AprovadoresId = P009E2_A375AprovadoresId[0];
            A144SecUserEmail = P009E2_A144SecUserEmail[0];
            n144SecUserEmail = P009E2_n144SecUserEmail[0];
            A141SecUserName = P009E2_A141SecUserName[0];
            n141SecUserName = P009E2_n141SecUserName[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A144SecUserEmail, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A380AprovadoresStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Ativo";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A380AprovadoresStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Inativo";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A380AprovadoresStatus)), "true") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A380AprovadoresStatus)), "false") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
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
         AV34Session.Set("WWPExportFilePath", AV11Filename);
         AV34Session.Set("WWPExportFileName", "AprovadoresWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV34Session.Get("AprovadoresWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "AprovadoresWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("AprovadoresWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV36GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV36GridState.gxTpr_Ordereddsc;
         AV67GXV1 = 1;
         while ( AV67GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV67GXV1));
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
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL") == 0 )
            {
               AV40TFSecUserEmail = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL_SEL") == 0 )
            {
               AV41TFSecUserEmail_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFAPROVADORESSTATUS_SEL") == 0 )
            {
               AV42TFAprovadoresStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV67GXV1 = (int)(AV67GXV1+1);
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
         AV22SecUserName1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV27SecUserName2 = "";
         AV29DynamicFiltersSelector3 = "";
         AV32SecUserName3 = "";
         AV39TFSecUserName_Sel = "";
         AV38TFSecUserName = "";
         AV41TFSecUserEmail_Sel = "";
         AV40TFSecUserEmail = "";
         AV47Aprovadoreswwds_1_filterfulltext = "";
         AV48Aprovadoreswwds_2_dynamicfiltersselector1 = "";
         AV51Aprovadoreswwds_5_secusername1 = "";
         AV53Aprovadoreswwds_7_dynamicfiltersselector2 = "";
         AV56Aprovadoreswwds_10_secusername2 = "";
         AV58Aprovadoreswwds_12_dynamicfiltersselector3 = "";
         AV61Aprovadoreswwds_15_secusername3 = "";
         AV62Aprovadoreswwds_16_tfsecusername = "";
         AV63Aprovadoreswwds_17_tfsecusername_sel = "";
         AV64Aprovadoreswwds_18_tfsecuseremail = "";
         AV65Aprovadoreswwds_19_tfsecuseremail_sel = "";
         lV47Aprovadoreswwds_1_filterfulltext = "";
         lV51Aprovadoreswwds_5_secusername1 = "";
         lV56Aprovadoreswwds_10_secusername2 = "";
         lV61Aprovadoreswwds_15_secusername3 = "";
         lV62Aprovadoreswwds_16_tfsecusername = "";
         lV64Aprovadoreswwds_18_tfsecuseremail = "";
         A141SecUserName = "";
         A144SecUserEmail = "";
         P009E2_A133SecUserId = new short[1] ;
         P009E2_n133SecUserId = new bool[] {false} ;
         P009E2_A380AprovadoresStatus = new bool[] {false} ;
         P009E2_n380AprovadoresStatus = new bool[] {false} ;
         P009E2_A144SecUserEmail = new string[] {""} ;
         P009E2_n144SecUserEmail = new bool[] {false} ;
         P009E2_A141SecUserName = new string[] {""} ;
         P009E2_n141SecUserName = new bool[] {false} ;
         P009E2_A375AprovadoresId = new int[1] ;
         GXt_char1 = "";
         AV34Session = context.GetSession();
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprovadoreswwexport__default(),
            new Object[][] {
                new Object[] {
               P009E2_A133SecUserId, P009E2_n133SecUserId, P009E2_A380AprovadoresStatus, P009E2_n380AprovadoresStatus, P009E2_A144SecUserEmail, P009E2_n144SecUserEmail, P009E2_A141SecUserName, P009E2_n141SecUserName, P009E2_A375AprovadoresId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV30DynamicFiltersOperator3 ;
      private short AV42TFAprovadoresStatus_Sel ;
      private short GXt_int2 ;
      private short AV49Aprovadoreswwds_3_dynamicfiltersoperator1 ;
      private short AV54Aprovadoreswwds_8_dynamicfiltersoperator2 ;
      private short AV59Aprovadoreswwds_13_dynamicfiltersoperator3 ;
      private short AV66Aprovadoreswwds_20_tfaprovadoresstatus_sel ;
      private short AV16OrderedBy ;
      private short A133SecUserId ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A375AprovadoresId ;
      private int AV67GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV43AprovadoresStatus1 ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV44AprovadoresStatus2 ;
      private bool AV28DynamicFiltersEnabled3 ;
      private bool AV45AprovadoresStatus3 ;
      private bool AV50Aprovadoreswwds_4_aprovadoresstatus1 ;
      private bool AV52Aprovadoreswwds_6_dynamicfiltersenabled2 ;
      private bool AV55Aprovadoreswwds_9_aprovadoresstatus2 ;
      private bool AV57Aprovadoreswwds_11_dynamicfiltersenabled3 ;
      private bool AV60Aprovadoreswwds_14_aprovadoresstatus3 ;
      private bool A380AprovadoresStatus ;
      private bool AV17OrderedDsc ;
      private bool n133SecUserId ;
      private bool n380AprovadoresStatus ;
      private bool n144SecUserEmail ;
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
      private string AV41TFSecUserEmail_Sel ;
      private string AV40TFSecUserEmail ;
      private string AV47Aprovadoreswwds_1_filterfulltext ;
      private string AV48Aprovadoreswwds_2_dynamicfiltersselector1 ;
      private string AV51Aprovadoreswwds_5_secusername1 ;
      private string AV53Aprovadoreswwds_7_dynamicfiltersselector2 ;
      private string AV56Aprovadoreswwds_10_secusername2 ;
      private string AV58Aprovadoreswwds_12_dynamicfiltersselector3 ;
      private string AV61Aprovadoreswwds_15_secusername3 ;
      private string AV62Aprovadoreswwds_16_tfsecusername ;
      private string AV63Aprovadoreswwds_17_tfsecusername_sel ;
      private string AV64Aprovadoreswwds_18_tfsecuseremail ;
      private string AV65Aprovadoreswwds_19_tfsecuseremail_sel ;
      private string lV47Aprovadoreswwds_1_filterfulltext ;
      private string lV51Aprovadoreswwds_5_secusername1 ;
      private string lV56Aprovadoreswwds_10_secusername2 ;
      private string lV61Aprovadoreswwds_15_secusername3 ;
      private string lV62Aprovadoreswwds_16_tfsecusername ;
      private string lV64Aprovadoreswwds_18_tfsecuseremail ;
      private string A141SecUserName ;
      private string A144SecUserEmail ;
      private IGxSession AV34Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV33GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P009E2_A133SecUserId ;
      private bool[] P009E2_n133SecUserId ;
      private bool[] P009E2_A380AprovadoresStatus ;
      private bool[] P009E2_n380AprovadoresStatus ;
      private string[] P009E2_A144SecUserEmail ;
      private bool[] P009E2_n144SecUserEmail ;
      private string[] P009E2_A141SecUserName ;
      private bool[] P009E2_n141SecUserName ;
      private int[] P009E2_A375AprovadoresId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class aprovadoreswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009E2( IGxContext context ,
                                             string AV47Aprovadoreswwds_1_filterfulltext ,
                                             string AV48Aprovadoreswwds_2_dynamicfiltersselector1 ,
                                             bool AV50Aprovadoreswwds_4_aprovadoresstatus1 ,
                                             short AV49Aprovadoreswwds_3_dynamicfiltersoperator1 ,
                                             string AV51Aprovadoreswwds_5_secusername1 ,
                                             bool AV52Aprovadoreswwds_6_dynamicfiltersenabled2 ,
                                             string AV53Aprovadoreswwds_7_dynamicfiltersselector2 ,
                                             bool AV55Aprovadoreswwds_9_aprovadoresstatus2 ,
                                             short AV54Aprovadoreswwds_8_dynamicfiltersoperator2 ,
                                             string AV56Aprovadoreswwds_10_secusername2 ,
                                             bool AV57Aprovadoreswwds_11_dynamicfiltersenabled3 ,
                                             string AV58Aprovadoreswwds_12_dynamicfiltersselector3 ,
                                             bool AV60Aprovadoreswwds_14_aprovadoresstatus3 ,
                                             short AV59Aprovadoreswwds_13_dynamicfiltersoperator3 ,
                                             string AV61Aprovadoreswwds_15_secusername3 ,
                                             string AV63Aprovadoreswwds_17_tfsecusername_sel ,
                                             string AV62Aprovadoreswwds_16_tfsecusername ,
                                             string AV65Aprovadoreswwds_19_tfsecuseremail_sel ,
                                             string AV64Aprovadoreswwds_18_tfsecuseremail ,
                                             short AV66Aprovadoreswwds_20_tfaprovadoresstatus_sel ,
                                             string A141SecUserName ,
                                             string A144SecUserEmail ,
                                             bool A380AprovadoresStatus ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecUserId, T1.AprovadoresStatus, T2.SecUserEmail, T2.SecUserName, T1.AprovadoresId FROM (Aprovadores T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Aprovadoreswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.SecUserName like '%' || :lV47Aprovadoreswwds_1_filterfulltext) or ( T2.SecUserEmail like '%' || :lV47Aprovadoreswwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV47Aprovadoreswwds_1_filterfulltext) and T1.AprovadoresStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV47Aprovadoreswwds_1_filterfulltext) and T1.AprovadoresStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV48Aprovadoreswwds_2_dynamicfiltersselector1, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV50Aprovadoreswwds_4_aprovadoresstatus1) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV50Aprovadoreswwds_4_aprovadoresstatus1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV48Aprovadoreswwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV49Aprovadoreswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Aprovadoreswwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV51Aprovadoreswwds_5_secusername1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV48Aprovadoreswwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV49Aprovadoreswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Aprovadoreswwds_5_secusername1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV51Aprovadoreswwds_5_secusername1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV52Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Aprovadoreswwds_7_dynamicfiltersselector2, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV55Aprovadoreswwds_9_aprovadoresstatus2) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV55Aprovadoreswwds_9_aprovadoresstatus2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV52Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Aprovadoreswwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV54Aprovadoreswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Aprovadoreswwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV56Aprovadoreswwds_10_secusername2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV52Aprovadoreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Aprovadoreswwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV54Aprovadoreswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Aprovadoreswwds_10_secusername2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV56Aprovadoreswwds_10_secusername2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV57Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Aprovadoreswwds_12_dynamicfiltersselector3, "APROVADORESSTATUS") == 0 ) && ( ! (false==AV60Aprovadoreswwds_14_aprovadoresstatus3) ) )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = :AV60Aprovadoreswwds_14_aprovadoresstatus3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV57Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Aprovadoreswwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV59Aprovadoreswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Aprovadoreswwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV61Aprovadoreswwds_15_secusername3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV57Aprovadoreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Aprovadoreswwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV59Aprovadoreswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Aprovadoreswwds_15_secusername3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV61Aprovadoreswwds_15_secusername3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Aprovadoreswwds_17_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Aprovadoreswwds_16_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV62Aprovadoreswwds_16_tfsecusername)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Aprovadoreswwds_17_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV63Aprovadoreswwds_17_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName = ( :AV63Aprovadoreswwds_17_tfsecusername_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV63Aprovadoreswwds_17_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserName IS NULL or (char_length(trim(trailing ' ' from T2.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Aprovadoreswwds_19_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Aprovadoreswwds_18_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail like :lV64Aprovadoreswwds_18_tfsecuseremail)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Aprovadoreswwds_19_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV65Aprovadoreswwds_19_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail = ( :AV65Aprovadoreswwds_19_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV65Aprovadoreswwds_19_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T2.SecUserEmail))=0))");
         }
         if ( AV66Aprovadoreswwds_20_tfaprovadoresstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = TRUE)");
         }
         if ( AV66Aprovadoreswwds_20_tfaprovadoresstatus_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.AprovadoresStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AprovadoresStatus";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AprovadoresStatus DESC";
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
            scmdbuf += " ORDER BY T2.SecUserEmail";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.SecUserEmail DESC";
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
                     return conditional_P009E2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP009E2;
          prmP009E2 = new Object[] {
          new ParDef("lV47Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV47Aprovadoreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV50Aprovadoreswwds_4_aprovadoresstatus1",GXType.Boolean,4,0) ,
          new ParDef("lV51Aprovadoreswwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV51Aprovadoreswwds_5_secusername1",GXType.VarChar,100,0) ,
          new ParDef("AV55Aprovadoreswwds_9_aprovadoresstatus2",GXType.Boolean,4,0) ,
          new ParDef("lV56Aprovadoreswwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV56Aprovadoreswwds_10_secusername2",GXType.VarChar,100,0) ,
          new ParDef("AV60Aprovadoreswwds_14_aprovadoresstatus3",GXType.Boolean,4,0) ,
          new ParDef("lV61Aprovadoreswwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV61Aprovadoreswwds_15_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV62Aprovadoreswwds_16_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV63Aprovadoreswwds_17_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Aprovadoreswwds_18_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV65Aprovadoreswwds_19_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009E2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
