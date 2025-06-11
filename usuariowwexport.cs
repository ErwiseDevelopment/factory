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
   public class usuariowwexport : GXProcedure
   {
      public usuariowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usuariowwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "UsuarioWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV21SecUserName1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21SecUserName1)) )
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
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21SecUserName1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV25SecUserName2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25SecUserName2)) )
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
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25SecUserName2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV28DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV29SecUserName3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29SecUserName3)) )
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
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29SecUserName3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSecUserName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Usuário") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSecUserName_Sel)) ? "(Vazio)" : AV36TFSecUserName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFSecUserName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Usuário") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFSecUserName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecUserFullName_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSecUserFullName_Sel)) ? "(Vazio)" : AV38TFSecUserFullName_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSecUserFullName)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFSecUserFullName, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecUserEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "E-mail") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV40TFSecUserEmail_Sel)) ? "(Vazio)" : AV40TFSecUserEmail_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSecUserEmail)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "E-mail") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFSecUserEmail, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV41TFSecUserStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            if ( AV41TFSecUserStatus_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV41TFSecUserStatus_Sel == 2 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Nome";
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
         AV43Usuariowwds_1_filterfulltext = AV18FilterFullText;
         AV44Usuariowwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV45Usuariowwds_3_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV46Usuariowwds_4_secusername1 = AV21SecUserName1;
         AV47Usuariowwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV48Usuariowwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV49Usuariowwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV50Usuariowwds_8_secusername2 = AV25SecUserName2;
         AV51Usuariowwds_9_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV52Usuariowwds_10_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV53Usuariowwds_11_dynamicfiltersoperator3 = AV28DynamicFiltersOperator3;
         AV54Usuariowwds_12_secusername3 = AV29SecUserName3;
         AV55Usuariowwds_13_tfsecusername = AV35TFSecUserName;
         AV56Usuariowwds_14_tfsecusername_sel = AV36TFSecUserName_Sel;
         AV57Usuariowwds_15_tfsecuserfullname = AV37TFSecUserFullName;
         AV58Usuariowwds_16_tfsecuserfullname_sel = AV38TFSecUserFullName_Sel;
         AV59Usuariowwds_17_tfsecuseremail = AV39TFSecUserEmail;
         AV60Usuariowwds_18_tfsecuseremail_sel = AV40TFSecUserEmail_Sel;
         AV61Usuariowwds_19_tfsecuserstatus_sel = AV41TFSecUserStatus_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV43Usuariowwds_1_filterfulltext ,
                                              AV44Usuariowwds_2_dynamicfiltersselector1 ,
                                              AV45Usuariowwds_3_dynamicfiltersoperator1 ,
                                              AV46Usuariowwds_4_secusername1 ,
                                              AV47Usuariowwds_5_dynamicfiltersenabled2 ,
                                              AV48Usuariowwds_6_dynamicfiltersselector2 ,
                                              AV49Usuariowwds_7_dynamicfiltersoperator2 ,
                                              AV50Usuariowwds_8_secusername2 ,
                                              AV51Usuariowwds_9_dynamicfiltersenabled3 ,
                                              AV52Usuariowwds_10_dynamicfiltersselector3 ,
                                              AV53Usuariowwds_11_dynamicfiltersoperator3 ,
                                              AV54Usuariowwds_12_secusername3 ,
                                              AV56Usuariowwds_14_tfsecusername_sel ,
                                              AV55Usuariowwds_13_tfsecusername ,
                                              AV58Usuariowwds_16_tfsecuserfullname_sel ,
                                              AV57Usuariowwds_15_tfsecuserfullname ,
                                              AV60Usuariowwds_18_tfsecuseremail_sel ,
                                              AV59Usuariowwds_17_tfsecuseremail ,
                                              AV61Usuariowwds_19_tfsecuserstatus_sel ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV43Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Usuariowwds_1_filterfulltext), "%", "");
         lV43Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Usuariowwds_1_filterfulltext), "%", "");
         lV43Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Usuariowwds_1_filterfulltext), "%", "");
         lV43Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Usuariowwds_1_filterfulltext), "%", "");
         lV43Usuariowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV43Usuariowwds_1_filterfulltext), "%", "");
         lV46Usuariowwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV46Usuariowwds_4_secusername1), "%", "");
         lV46Usuariowwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV46Usuariowwds_4_secusername1), "%", "");
         lV50Usuariowwds_8_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV50Usuariowwds_8_secusername2), "%", "");
         lV50Usuariowwds_8_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV50Usuariowwds_8_secusername2), "%", "");
         lV54Usuariowwds_12_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV54Usuariowwds_12_secusername3), "%", "");
         lV54Usuariowwds_12_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV54Usuariowwds_12_secusername3), "%", "");
         lV55Usuariowwds_13_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV55Usuariowwds_13_tfsecusername), "%", "");
         lV57Usuariowwds_15_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV57Usuariowwds_15_tfsecuserfullname), "%", "");
         lV59Usuariowwds_17_tfsecuseremail = StringUtil.Concat( StringUtil.RTrim( AV59Usuariowwds_17_tfsecuseremail), "%", "");
         /* Using cursor P00B02 */
         pr_default.execute(0, new Object[] {lV43Usuariowwds_1_filterfulltext, lV43Usuariowwds_1_filterfulltext, lV43Usuariowwds_1_filterfulltext, lV43Usuariowwds_1_filterfulltext, lV43Usuariowwds_1_filterfulltext, lV46Usuariowwds_4_secusername1, lV46Usuariowwds_4_secusername1, lV50Usuariowwds_8_secusername2, lV50Usuariowwds_8_secusername2, lV54Usuariowwds_12_secusername3, lV54Usuariowwds_12_secusername3, lV55Usuariowwds_13_tfsecusername, AV56Usuariowwds_14_tfsecusername_sel, lV57Usuariowwds_15_tfsecuserfullname, AV58Usuariowwds_16_tfsecuserfullname_sel, lV59Usuariowwds_17_tfsecuseremail, AV60Usuariowwds_18_tfsecuseremail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A150SecUserStatus = P00B02_A150SecUserStatus[0];
            n150SecUserStatus = P00B02_n150SecUserStatus[0];
            A144SecUserEmail = P00B02_A144SecUserEmail[0];
            n144SecUserEmail = P00B02_n144SecUserEmail[0];
            A143SecUserFullName = P00B02_A143SecUserFullName[0];
            n143SecUserFullName = P00B02_n143SecUserFullName[0];
            A141SecUserName = P00B02_A141SecUserName[0];
            n141SecUserName = P00B02_n141SecUserName[0];
            A133SecUserId = P00B02_A133SecUserId[0];
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
         AV31Session.Set("WWPExportFileName", "UsuarioWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("UsuarioWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "UsuarioWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("UsuarioWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV62GXV1 = 1;
         while ( AV62GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV62GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV35TFSecUserName = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV36TFSecUserName_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV37TFSecUserFullName = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV38TFSecUserFullName_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL") == 0 )
            {
               AV39TFSecUserEmail = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL_SEL") == 0 )
            {
               AV40TFSecUserEmail_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSECUSERSTATUS_SEL") == 0 )
            {
               AV41TFSecUserStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV62GXV1 = (int)(AV62GXV1+1);
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
         AV21SecUserName1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25SecUserName2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29SecUserName3 = "";
         AV36TFSecUserName_Sel = "";
         AV35TFSecUserName = "";
         AV38TFSecUserFullName_Sel = "";
         AV37TFSecUserFullName = "";
         AV40TFSecUserEmail_Sel = "";
         AV39TFSecUserEmail = "";
         AV43Usuariowwds_1_filterfulltext = "";
         AV44Usuariowwds_2_dynamicfiltersselector1 = "";
         AV46Usuariowwds_4_secusername1 = "";
         AV48Usuariowwds_6_dynamicfiltersselector2 = "";
         AV50Usuariowwds_8_secusername2 = "";
         AV52Usuariowwds_10_dynamicfiltersselector3 = "";
         AV54Usuariowwds_12_secusername3 = "";
         AV55Usuariowwds_13_tfsecusername = "";
         AV56Usuariowwds_14_tfsecusername_sel = "";
         AV57Usuariowwds_15_tfsecuserfullname = "";
         AV58Usuariowwds_16_tfsecuserfullname_sel = "";
         AV59Usuariowwds_17_tfsecuseremail = "";
         AV60Usuariowwds_18_tfsecuseremail_sel = "";
         lV43Usuariowwds_1_filterfulltext = "";
         lV46Usuariowwds_4_secusername1 = "";
         lV50Usuariowwds_8_secusername2 = "";
         lV54Usuariowwds_12_secusername3 = "";
         lV55Usuariowwds_13_tfsecusername = "";
         lV57Usuariowwds_15_tfsecuserfullname = "";
         lV59Usuariowwds_17_tfsecuseremail = "";
         A141SecUserName = "";
         A143SecUserFullName = "";
         A144SecUserEmail = "";
         P00B02_A150SecUserStatus = new bool[] {false} ;
         P00B02_n150SecUserStatus = new bool[] {false} ;
         P00B02_A144SecUserEmail = new string[] {""} ;
         P00B02_n144SecUserEmail = new bool[] {false} ;
         P00B02_A143SecUserFullName = new string[] {""} ;
         P00B02_n143SecUserFullName = new bool[] {false} ;
         P00B02_A141SecUserName = new string[] {""} ;
         P00B02_n141SecUserName = new bool[] {false} ;
         P00B02_A133SecUserId = new short[1] ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuariowwexport__default(),
            new Object[][] {
                new Object[] {
               P00B02_A150SecUserStatus, P00B02_n150SecUserStatus, P00B02_A144SecUserEmail, P00B02_n144SecUserEmail, P00B02_A143SecUserFullName, P00B02_n143SecUserFullName, P00B02_A141SecUserName, P00B02_n141SecUserName, P00B02_A133SecUserId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV28DynamicFiltersOperator3 ;
      private short AV41TFSecUserStatus_Sel ;
      private short GXt_int2 ;
      private short AV45Usuariowwds_3_dynamicfiltersoperator1 ;
      private short AV49Usuariowwds_7_dynamicfiltersoperator2 ;
      private short AV53Usuariowwds_11_dynamicfiltersoperator3 ;
      private short AV61Usuariowwds_19_tfsecuserstatus_sel ;
      private short AV16OrderedBy ;
      private short A133SecUserId ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV62GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV47Usuariowwds_5_dynamicfiltersenabled2 ;
      private bool AV51Usuariowwds_9_dynamicfiltersenabled3 ;
      private bool A150SecUserStatus ;
      private bool AV17OrderedDsc ;
      private bool n150SecUserStatus ;
      private bool n144SecUserEmail ;
      private bool n143SecUserFullName ;
      private bool n141SecUserName ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21SecUserName1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25SecUserName2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29SecUserName3 ;
      private string AV36TFSecUserName_Sel ;
      private string AV35TFSecUserName ;
      private string AV38TFSecUserFullName_Sel ;
      private string AV37TFSecUserFullName ;
      private string AV40TFSecUserEmail_Sel ;
      private string AV39TFSecUserEmail ;
      private string AV43Usuariowwds_1_filterfulltext ;
      private string AV44Usuariowwds_2_dynamicfiltersselector1 ;
      private string AV46Usuariowwds_4_secusername1 ;
      private string AV48Usuariowwds_6_dynamicfiltersselector2 ;
      private string AV50Usuariowwds_8_secusername2 ;
      private string AV52Usuariowwds_10_dynamicfiltersselector3 ;
      private string AV54Usuariowwds_12_secusername3 ;
      private string AV55Usuariowwds_13_tfsecusername ;
      private string AV56Usuariowwds_14_tfsecusername_sel ;
      private string AV57Usuariowwds_15_tfsecuserfullname ;
      private string AV58Usuariowwds_16_tfsecuserfullname_sel ;
      private string AV59Usuariowwds_17_tfsecuseremail ;
      private string AV60Usuariowwds_18_tfsecuseremail_sel ;
      private string lV43Usuariowwds_1_filterfulltext ;
      private string lV46Usuariowwds_4_secusername1 ;
      private string lV50Usuariowwds_8_secusername2 ;
      private string lV54Usuariowwds_12_secusername3 ;
      private string lV55Usuariowwds_13_tfsecusername ;
      private string lV57Usuariowwds_15_tfsecuserfullname ;
      private string lV59Usuariowwds_17_tfsecuseremail ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private string A144SecUserEmail ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private bool[] P00B02_A150SecUserStatus ;
      private bool[] P00B02_n150SecUserStatus ;
      private string[] P00B02_A144SecUserEmail ;
      private bool[] P00B02_n144SecUserEmail ;
      private string[] P00B02_A143SecUserFullName ;
      private bool[] P00B02_n143SecUserFullName ;
      private string[] P00B02_A141SecUserName ;
      private bool[] P00B02_n141SecUserName ;
      private short[] P00B02_A133SecUserId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class usuariowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B02( IGxContext context ,
                                             string AV43Usuariowwds_1_filterfulltext ,
                                             string AV44Usuariowwds_2_dynamicfiltersselector1 ,
                                             short AV45Usuariowwds_3_dynamicfiltersoperator1 ,
                                             string AV46Usuariowwds_4_secusername1 ,
                                             bool AV47Usuariowwds_5_dynamicfiltersenabled2 ,
                                             string AV48Usuariowwds_6_dynamicfiltersselector2 ,
                                             short AV49Usuariowwds_7_dynamicfiltersoperator2 ,
                                             string AV50Usuariowwds_8_secusername2 ,
                                             bool AV51Usuariowwds_9_dynamicfiltersenabled3 ,
                                             string AV52Usuariowwds_10_dynamicfiltersselector3 ,
                                             short AV53Usuariowwds_11_dynamicfiltersoperator3 ,
                                             string AV54Usuariowwds_12_secusername3 ,
                                             string AV56Usuariowwds_14_tfsecusername_sel ,
                                             string AV55Usuariowwds_13_tfsecusername ,
                                             string AV58Usuariowwds_16_tfsecuserfullname_sel ,
                                             string AV57Usuariowwds_15_tfsecuserfullname ,
                                             string AV60Usuariowwds_18_tfsecuseremail_sel ,
                                             string AV59Usuariowwds_17_tfsecuseremail ,
                                             short AV61Usuariowwds_19_tfsecuserstatus_sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SecUserStatus, SecUserEmail, SecUserFullName, SecUserName, SecUserId FROM SecUser";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Usuariowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SecUserName like '%' || :lV43Usuariowwds_1_filterfulltext) or ( SecUserFullName like '%' || :lV43Usuariowwds_1_filterfulltext) or ( SecUserEmail like '%' || :lV43Usuariowwds_1_filterfulltext) or ( 'ativo' like '%' || LOWER(:lV43Usuariowwds_1_filterfulltext) and SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV43Usuariowwds_1_filterfulltext) and SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV44Usuariowwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV45Usuariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Usuariowwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV46Usuariowwds_4_secusername1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV44Usuariowwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV45Usuariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Usuariowwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV46Usuariowwds_4_secusername1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV47Usuariowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV48Usuariowwds_6_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV49Usuariowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Usuariowwds_8_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV50Usuariowwds_8_secusername2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV47Usuariowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV48Usuariowwds_6_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV49Usuariowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Usuariowwds_8_secusername2)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV50Usuariowwds_8_secusername2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV51Usuariowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Usuariowwds_10_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV53Usuariowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Usuariowwds_12_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV54Usuariowwds_12_secusername3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV51Usuariowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV52Usuariowwds_10_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV53Usuariowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Usuariowwds_12_secusername3)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV54Usuariowwds_12_secusername3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Usuariowwds_14_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Usuariowwds_13_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(SecUserName like :lV55Usuariowwds_13_tfsecusername)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Usuariowwds_14_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV56Usuariowwds_14_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserName = ( :AV56Usuariowwds_14_tfsecusername_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV56Usuariowwds_14_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserName IS NULL or (char_length(trim(trailing ' ' from SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Usuariowwds_16_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Usuariowwds_15_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(SecUserFullName like :lV57Usuariowwds_15_tfsecuserfullname)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Usuariowwds_16_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV58Usuariowwds_16_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserFullName = ( :AV58Usuariowwds_16_tfsecuserfullname_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV58Usuariowwds_16_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserFullName IS NULL or (char_length(trim(trailing ' ' from SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Usuariowwds_18_tfsecuseremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Usuariowwds_17_tfsecuseremail)) ) )
         {
            AddWhere(sWhereString, "(SecUserEmail like :lV59Usuariowwds_17_tfsecuseremail)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Usuariowwds_18_tfsecuseremail_sel)) && ! ( StringUtil.StrCmp(AV60Usuariowwds_18_tfsecuseremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SecUserEmail = ( :AV60Usuariowwds_18_tfsecuseremail_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV60Usuariowwds_18_tfsecuseremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SecUserEmail IS NULL or (char_length(trim(trailing ' ' from SecUserEmail))=0))");
         }
         if ( AV61Usuariowwds_19_tfsecuserstatus_sel == 1 )
         {
            AddWhere(sWhereString, "(SecUserStatus = TRUE)");
         }
         if ( AV61Usuariowwds_19_tfsecuserstatus_sel == 2 )
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
                     return conditional_P00B02(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (bool)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP00B02;
          prmP00B02 = new Object[] {
          new ParDef("lV43Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV43Usuariowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV46Usuariowwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV46Usuariowwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("lV50Usuariowwds_8_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV50Usuariowwds_8_secusername2",GXType.VarChar,100,0) ,
          new ParDef("lV54Usuariowwds_12_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV54Usuariowwds_12_secusername3",GXType.VarChar,100,0) ,
          new ParDef("lV55Usuariowwds_13_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV56Usuariowwds_14_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("lV57Usuariowwds_15_tfsecuserfullname",GXType.VarChar,150,0) ,
          new ParDef("AV58Usuariowwds_16_tfsecuserfullname_sel",GXType.VarChar,150,0) ,
          new ParDef("lV59Usuariowwds_17_tfsecuseremail",GXType.VarChar,100,0) ,
          new ParDef("AV60Usuariowwds_18_tfsecuseremail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B02,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
