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
   public class secuserwwexport : GXProcedure
   {
      public secuserwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserwwexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV13ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         this.AV12Filename = "" ;
         this.AV13ErrorMessage = "" ;
         SubmitImpl();
         aP0_Filename=this.AV12Filename;
         aP1_ErrorMessage=this.AV13ErrorMessage;
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
         AV14CellRow = 1;
         AV15FirstColumn = 1;
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
         AV16Random = (int)(NumberUtil.Random( )*10000);
         GXt_char1 = AV12Filename;
         new GeneXus.Programs.wwpbaseobjects.wwp_getdefaultexportpath(context ).execute( out  GXt_char1) ;
         AV12Filename = GXt_char1 + "SecUserWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Random), 8, 0)) + ".xlsx";
         AV11ExcelDocument.Open(AV12Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Filtro principal") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV19FilterFullText, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(1));
            AV20DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV22SecUserName1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SecUserName1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Contém", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22SecUserName1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "SECUSERMANNAME") == 0 )
            {
               AV21DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV56SecUserManName1 = AV31GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56SecUserManName1)) )
               {
                  AV14CellRow = (int)(AV14CellRow+1);
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                  if ( AV21DynamicFiltersOperator1 == 0 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário manutenção", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV21DynamicFiltersOperator1 == 1 )
                  {
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário manutenção", "Contém", "", "", "", "", "", "", "");
                  }
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56SecUserManName1, out  GXt_char1) ;
                  AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV26SecUserName2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26SecUserName2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Contém", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26SecUserName2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERMANNAME") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV57SecUserManName2 = AV31GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57SecUserManName2)) )
                  {
                     AV14CellRow = (int)(AV14CellRow+1);
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário manutenção", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário manutenção", "Contém", "", "", "", "", "", "", "");
                     }
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57SecUserManName2, out  GXt_char1) ;
                     AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV30SecUserName3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30SecUserName3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário", "Contém", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30SecUserName3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "SECUSERMANNAME") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV58SecUserManName3 = AV31GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58SecUserManName3)) )
                     {
                        AV14CellRow = (int)(AV14CellRow+1);
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Bold = 1;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário manutenção", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Usuário manutenção", "Contém", "", "", "", "", "", "", "");
                        }
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV58SecUserManName3, out  GXt_char1) ;
                        AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFSecUserName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Usuário") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV48TFSecUserName_Sel)) ? "(Vazio)" : AV48TFSecUserName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFSecUserName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Usuário") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFSecUserName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFSecUserFullName_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV50TFSecUserFullName_Sel)) ? "(Vazio)" : AV50TFSecUserFullName_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV49TFSecUserFullName)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Nome") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49TFSecUserFullName, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecUserEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "E-mail") ;
            AV14CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecUserEmail_Sel)) ? "(Vazio)" : AV52TFSecUserEmail_Sel), out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecUserEmail)) ) )
            {
               GXt_int2 = (short)(AV14CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "E-mail") ;
               AV14CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV51TFSecUserEmail, out  GXt_char1) ;
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV53TFSecUserStatus_Sel) ) )
         {
            GXt_int2 = (short)(AV14CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV11ExcelDocument,  true, ref  GXt_int2,  (short)(AV15FirstColumn),  "Status") ;
            AV14CellRow = GXt_int2;
            if ( AV53TFSecUserStatus_Sel == 1 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV53TFSecUserStatus_Sel == 2 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         AV14CellRow = (int)(AV14CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "Usuário";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Nome";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = "E-mail";
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Bold = 1;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Color = 11;
         AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = "Status";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV19FilterFullText ,
                                              AV20DynamicFiltersSelector1 ,
                                              AV21DynamicFiltersOperator1 ,
                                              AV22SecUserName1 ,
                                              AV56SecUserManName1 ,
                                              AV23DynamicFiltersEnabled2 ,
                                              AV24DynamicFiltersSelector2 ,
                                              AV25DynamicFiltersOperator2 ,
                                              AV26SecUserName2 ,
                                              AV57SecUserManName2 ,
                                              AV27DynamicFiltersEnabled3 ,
                                              AV28DynamicFiltersSelector3 ,
                                              AV29DynamicFiltersOperator3 ,
                                              AV30SecUserName3 ,
                                              AV58SecUserManName3 ,
                                              AV48TFSecUserName_Sel ,
                                              AV47TFSecUserName ,
                                              AV50TFSecUserFullName_Sel ,
                                              AV49TFSecUserFullName ,
                                              AV52TFSecUserEmail_Sel ,
                                              AV51TFSecUserEmail ,
                                              AV53TFSecUserStatus_Sel ,
                                              A141SecUserName ,
                                              A143SecUserFullName ,
                                              A144SecUserEmail ,
                                              A150SecUserStatus ,
                                              A148SecUserManName ,
                                              AV17OrderedBy ,
                                              AV18OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV19FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV19FilterFullText), "%", "");
         lV19FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV19FilterFullText), "%", "");
         lV19FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV19FilterFullText), "%", "");
         lV19FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV19FilterFullText), "%", "");
         lV19FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV19FilterFullText), "%", "");
         lV22SecUserName1 = StringUtil.Concat( StringUtil.RTrim( AV22SecUserName1), "%", "");
         lV22SecUserName1 = StringUtil.Concat( StringUtil.RTrim( AV22SecUserName1), "%", "");
         lV56SecUserManName1 = StringUtil.Concat( StringUtil.RTrim( AV56SecUserManName1), "%", "");
         lV56SecUserManName1 = StringUtil.Concat( StringUtil.RTrim( AV56SecUserManName1), "%", "");
         lV26SecUserName2 = StringUtil.Concat( StringUtil.RTrim( AV26SecUserName2), "%", "");
         lV26SecUserName2 = StringUtil.Concat( StringUtil.RTrim( AV26SecUserName2), "%", "");
         lV57SecUserManName2 = StringUtil.Concat( StringUtil.RTrim( AV57SecUserManName2), "%", "");
         lV57SecUserManName2 = StringUtil.Concat( StringUtil.RTrim( AV57SecUserManName2), "%", "");
         lV30SecUserName3 = StringUtil.Concat( StringUtil.RTrim( AV30SecUserName3), "%", "");
         lV30SecUserName3 = StringUtil.Concat( StringUtil.RTrim( AV30SecUserName3), "%", "");
         lV58SecUserManName3 = StringUtil.Concat( StringUtil.RTrim( AV58SecUserManName3), "%", "");
         lV58SecUserManName3 = StringUtil.Concat( StringUtil.RTrim( AV58SecUserManName3), "%", "");
         lV47TFSecUserName = StringUtil.Concat( StringUtil.RTrim( AV47TFSecUserName), "%", "");
         lV49TFSecUserFullName = StringUtil.Concat( StringUtil.RTrim( AV49TFSecUserFullName), "%", "");
         lV51TFSecUserEmail = StringUtil.Concat( StringUtil.RTrim( AV51TFSecUserEmail), "%", "");
         /* Using cursor P00552 */
         pr_default.execute(0, new Object[] {lV19FilterFullText, lV19FilterFullText, lV19FilterFullText, lV19FilterFullText, lV19FilterFullText, lV22SecUserName1, lV22SecUserName1, lV56SecUserManName1, lV56SecUserManName1, lV26SecUserName2, lV26SecUserName2, lV57SecUserManName2, lV57SecUserManName2, lV30SecUserName3, lV30SecUserName3, lV58SecUserManName3, lV58SecUserManName3, lV47TFSecUserName, AV48TFSecUserName_Sel, lV49TFSecUserFullName, AV50TFSecUserFullName_Sel, lV51TFSecUserEmail, AV52TFSecUserEmail_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A147SecUserUserMan = P00552_A147SecUserUserMan[0];
            n147SecUserUserMan = P00552_n147SecUserUserMan[0];
            A148SecUserManName = P00552_A148SecUserManName[0];
            n148SecUserManName = P00552_n148SecUserManName[0];
            A150SecUserStatus = P00552_A150SecUserStatus[0];
            n150SecUserStatus = P00552_n150SecUserStatus[0];
            A144SecUserEmail = P00552_A144SecUserEmail[0];
            n144SecUserEmail = P00552_n144SecUserEmail[0];
            A143SecUserFullName = P00552_A143SecUserFullName[0];
            n143SecUserFullName = P00552_n143SecUserFullName[0];
            A141SecUserName = P00552_A141SecUserName[0];
            n141SecUserName = P00552_n141SecUserName[0];
            A133SecUserId = P00552_A133SecUserId[0];
            A148SecUserManName = P00552_A148SecUserManName[0];
            n148SecUserManName = P00552_n148SecUserManName[0];
            AV14CellRow = (int)(AV14CellRow+1);
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
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A143SecUserFullName, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A144SecUserEmail, out  GXt_char1) ;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = GXt_char1;
            AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A150SecUserStatus)), "true") == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = "ATIVO";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A150SecUserStatus)), "false") == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = "INATIVO";
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A150SecUserStatus)), "true") == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.BoolToStr( A150SecUserStatus)), "false") == 0 )
            {
               AV11ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
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
         AV11ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV11ExcelDocument.Close();
         AV32Session.Set("WWPExportFilePath", AV12Filename);
         AV32Session.Set("WWPExportFileName", "SecUserWWExport.xlsx");
         AV12Filename = formatLink("wwpbaseobjects.wwp_downloadreport") ;
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV11ExcelDocument.ErrCode != 0 )
         {
            AV12Filename = "";
            AV13ErrorMessage = AV11ExcelDocument.ErrDescription;
            AV11ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S191( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("SecUserWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SecUserWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("SecUserWWGridState"), null, "", "");
         }
         AV17OrderedBy = AV34GridState.gxTpr_Orderedby;
         AV18OrderedDsc = AV34GridState.gxTpr_Ordereddsc;
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV60GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV19FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV47TFSecUserName = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV48TFSecUserName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV49TFSecUserFullName = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV50TFSecUserFullName_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL") == 0 )
            {
               AV51TFSecUserEmail = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSECUSEREMAIL_SEL") == 0 )
            {
               AV52TFSecUserEmail_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFSECUSERSTATUS_SEL") == 0 )
            {
               AV53TFSecUserStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV60GXV1 = (int)(AV60GXV1+1);
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
         AV12Filename = "";
         AV13ErrorMessage = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11ExcelDocument = new ExcelDocumentI();
         AV19FilterFullText = "";
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV20DynamicFiltersSelector1 = "";
         AV22SecUserName1 = "";
         AV56SecUserManName1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26SecUserName2 = "";
         AV57SecUserManName2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30SecUserName3 = "";
         AV58SecUserManName3 = "";
         AV48TFSecUserName_Sel = "";
         AV47TFSecUserName = "";
         AV50TFSecUserFullName_Sel = "";
         AV49TFSecUserFullName = "";
         AV52TFSecUserEmail_Sel = "";
         AV51TFSecUserEmail = "";
         lV19FilterFullText = "";
         lV22SecUserName1 = "";
         lV56SecUserManName1 = "";
         lV26SecUserName2 = "";
         lV57SecUserManName2 = "";
         lV30SecUserName3 = "";
         lV58SecUserManName3 = "";
         lV47TFSecUserName = "";
         lV49TFSecUserFullName = "";
         lV51TFSecUserEmail = "";
         A141SecUserName = "";
         A143SecUserFullName = "";
         A144SecUserEmail = "";
         A148SecUserManName = "";
         P00552_A147SecUserUserMan = new short[1] ;
         P00552_n147SecUserUserMan = new bool[] {false} ;
         P00552_A148SecUserManName = new string[] {""} ;
         P00552_n148SecUserManName = new bool[] {false} ;
         P00552_A150SecUserStatus = new bool[] {false} ;
         P00552_n150SecUserStatus = new bool[] {false} ;
         P00552_A144SecUserEmail = new string[] {""} ;
         P00552_n144SecUserEmail = new bool[] {false} ;
         P00552_A143SecUserFullName = new string[] {""} ;
         P00552_n143SecUserFullName = new bool[] {false} ;
         P00552_A141SecUserName = new string[] {""} ;
         P00552_n141SecUserName = new bool[] {false} ;
         P00552_A133SecUserId = new short[1] ;
         GXt_char1 = "";
         AV32Session = context.GetSession();
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secuserwwexport__default(),
            new Object[][] {
                new Object[] {
               P00552_A147SecUserUserMan, P00552_n147SecUserUserMan, P00552_A148SecUserManName, P00552_n148SecUserManName, P00552_A150SecUserStatus, P00552_n150SecUserStatus, P00552_A144SecUserEmail, P00552_n144SecUserEmail, P00552_A143SecUserFullName, P00552_n143SecUserFullName,
               P00552_A141SecUserName, P00552_n141SecUserName, P00552_A133SecUserId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV53TFSecUserStatus_Sel ;
      private short GXt_int2 ;
      private short AV17OrderedBy ;
      private short A147SecUserUserMan ;
      private short A133SecUserId ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV16Random ;
      private int AV60GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool A150SecUserStatus ;
      private bool AV18OrderedDsc ;
      private bool n147SecUserUserMan ;
      private bool n148SecUserManName ;
      private bool n150SecUserStatus ;
      private bool n144SecUserEmail ;
      private bool n143SecUserFullName ;
      private bool n141SecUserName ;
      private string AV12Filename ;
      private string AV13ErrorMessage ;
      private string AV19FilterFullText ;
      private string AV20DynamicFiltersSelector1 ;
      private string AV22SecUserName1 ;
      private string AV56SecUserManName1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26SecUserName2 ;
      private string AV57SecUserManName2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV30SecUserName3 ;
      private string AV58SecUserManName3 ;
      private string AV48TFSecUserName_Sel ;
      private string AV47TFSecUserName ;
      private string AV50TFSecUserFullName_Sel ;
      private string AV49TFSecUserFullName ;
      private string AV52TFSecUserEmail_Sel ;
      private string AV51TFSecUserEmail ;
      private string lV19FilterFullText ;
      private string lV22SecUserName1 ;
      private string lV56SecUserManName1 ;
      private string lV26SecUserName2 ;
      private string lV57SecUserManName2 ;
      private string lV30SecUserName3 ;
      private string lV58SecUserManName3 ;
      private string lV47TFSecUserName ;
      private string lV49TFSecUserFullName ;
      private string lV51TFSecUserEmail ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private string A144SecUserEmail ;
      private string A148SecUserManName ;
      private IGxSession AV32Session ;
      private ExcelDocumentI AV11ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private short[] P00552_A147SecUserUserMan ;
      private bool[] P00552_n147SecUserUserMan ;
      private string[] P00552_A148SecUserManName ;
      private bool[] P00552_n148SecUserManName ;
      private bool[] P00552_A150SecUserStatus ;
      private bool[] P00552_n150SecUserStatus ;
      private string[] P00552_A144SecUserEmail ;
      private bool[] P00552_n144SecUserEmail ;
      private string[] P00552_A143SecUserFullName ;
      private bool[] P00552_n143SecUserFullName ;
      private string[] P00552_A141SecUserName ;
      private bool[] P00552_n141SecUserName ;
      private short[] P00552_A133SecUserId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class secuserwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00552( IGxContext context ,
                                             string AV19FilterFullText ,
                                             string AV20DynamicFiltersSelector1 ,
                                             short AV21DynamicFiltersOperator1 ,
                                             string AV22SecUserName1 ,
                                             string AV56SecUserManName1 ,
                                             bool AV23DynamicFiltersEnabled2 ,
                                             string AV24DynamicFiltersSelector2 ,
                                             short AV25DynamicFiltersOperator2 ,
                                             string AV26SecUserName2 ,
                                             string AV57SecUserManName2 ,
                                             bool AV27DynamicFiltersEnabled3 ,
                                             string AV28DynamicFiltersSelector3 ,
                                             short AV29DynamicFiltersOperator3 ,
                                             string AV30SecUserName3 ,
                                             string AV58SecUserManName3 ,
                                             string AV48TFSecUserName_Sel ,
                                             string AV47TFSecUserName ,
                                             string AV50TFSecUserFullName_Sel ,
                                             string AV49TFSecUserFullName ,
                                             string AV52TFSecUserEmail_Sel ,
                                             string AV51TFSecUserEmail ,
                                             short AV53TFSecUserStatus_Sel ,
                                             string A141SecUserName ,
                                             string A143SecUserFullName ,
                                             string A144SecUserEmail ,
                                             bool A150SecUserStatus ,
                                             string A148SecUserManName ,
                                             short AV17OrderedBy ,
                                             bool AV18OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[23];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SecUserUserMan AS SecUserUserMan, T2.SecUserName AS SecUserManName, T1.SecUserStatus, T1.SecUserEmail, T1.SecUserFullName, T1.SecUserName, T1.SecUserId FROM (SecUser T1 LEFT JOIN SecUser T2 ON T2.SecUserId = T1.SecUserUserMan)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19FilterFullText)) )
         {
            AddWhere(sWhereString, "(( LOWER(T1.SecUserName) like '%' || LOWER(:lV19FilterFullText)) or ( LOWER(T1.SecUserFullName) like '%' || LOWER(:lV19FilterFullText)) or ( LOWER(T1.SecUserEmail) like '%' || LOWER(:lV19FilterFullText)) or ( 'ativo' like '%' || LOWER(:lV19FilterFullText) and T1.SecUserStatus = TRUE) or ( 'inativo' like '%' || LOWER(:lV19FilterFullText) and T1.SecUserStatus = FALSE))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ( AV21DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SecUserName1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV22SecUserName1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "SECUSERNAME") == 0 ) && ( AV21DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22SecUserName1)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV22SecUserName1)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ( AV21DynamicFiltersOperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56SecUserManName1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV56SecUserManName1)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV20DynamicFiltersSelector1, "SECUSERMANNAME") == 0 ) && ( AV21DynamicFiltersOperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56SecUserManName1)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV56SecUserManName1)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV23DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ( AV25DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26SecUserName2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV26SecUserName2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV23DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERNAME") == 0 ) && ( AV25DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26SecUserName2)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV26SecUserName2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV23DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ( AV25DynamicFiltersOperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57SecUserManName2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV57SecUserManName2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV23DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "SECUSERMANNAME") == 0 ) && ( AV25DynamicFiltersOperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57SecUserManName2)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV57SecUserManName2)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV27DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ( AV29DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30SecUserName3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV30SecUserName3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV27DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "SECUSERNAME") == 0 ) && ( AV29DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30SecUserName3)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like '%' || :lV30SecUserName3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV27DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ( AV29DynamicFiltersOperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58SecUserManName3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like :lV58SecUserManName3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV27DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "SECUSERMANNAME") == 0 ) && ( AV29DynamicFiltersOperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58SecUserManName3)) ) )
         {
            AddWhere(sWhereString, "(T2.SecUserName like '%' || :lV58SecUserManName3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFSecUserName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFSecUserName)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName like :lV47TFSecUserName)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFSecUserName_Sel)) && ! ( StringUtil.StrCmp(AV48TFSecUserName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserName = ( :AV48TFSecUserName_Sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV48TFSecUserName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFSecUserFullName_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFSecUserFullName)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName like :lV49TFSecUserFullName)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFSecUserFullName_Sel)) && ! ( StringUtil.StrCmp(AV50TFSecUserFullName_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName = ( :AV50TFSecUserFullName_Sel))");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( StringUtil.StrCmp(AV50TFSecUserFullName_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserFullName IS NULL or (char_length(trim(trailing ' ' from T1.SecUserFullName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecUserEmail_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFSecUserEmail)) ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail like :lV51TFSecUserEmail)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TFSecUserEmail_Sel)) && ! ( StringUtil.StrCmp(AV52TFSecUserEmail_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail = ( :AV52TFSecUserEmail_Sel))");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( StringUtil.StrCmp(AV52TFSecUserEmail_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SecUserEmail IS NULL or (char_length(trim(trailing ' ' from T1.SecUserEmail))=0))");
         }
         if ( AV53TFSecUserStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = TRUE)");
         }
         if ( AV53TFSecUserStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(T1.SecUserStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( ( AV17OrderedBy == 1 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecUserName";
         }
         else if ( ( AV17OrderedBy == 1 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecUserName DESC";
         }
         else if ( ( AV17OrderedBy == 2 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecUserFullName";
         }
         else if ( ( AV17OrderedBy == 2 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecUserFullName DESC";
         }
         else if ( ( AV17OrderedBy == 3 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecUserEmail";
         }
         else if ( ( AV17OrderedBy == 3 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecUserEmail DESC";
         }
         else if ( ( AV17OrderedBy == 4 ) && ! AV18OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.SecUserStatus";
         }
         else if ( ( AV17OrderedBy == 4 ) && ( AV18OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.SecUserStatus DESC";
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
                     return conditional_P00552(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (bool)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
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
          Object[] prmP00552;
          prmP00552 = new Object[] {
          new ParDef("lV19FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV19FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV19FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV19FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV19FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV22SecUserName1",GXType.VarChar,100,0) ,
          new ParDef("lV22SecUserName1",GXType.VarChar,100,0) ,
          new ParDef("lV56SecUserManName1",GXType.VarChar,100,0) ,
          new ParDef("lV56SecUserManName1",GXType.VarChar,100,0) ,
          new ParDef("lV26SecUserName2",GXType.VarChar,100,0) ,
          new ParDef("lV26SecUserName2",GXType.VarChar,100,0) ,
          new ParDef("lV57SecUserManName2",GXType.VarChar,100,0) ,
          new ParDef("lV57SecUserManName2",GXType.VarChar,100,0) ,
          new ParDef("lV30SecUserName3",GXType.VarChar,100,0) ,
          new ParDef("lV30SecUserName3",GXType.VarChar,100,0) ,
          new ParDef("lV58SecUserManName3",GXType.VarChar,100,0) ,
          new ParDef("lV58SecUserManName3",GXType.VarChar,100,0) ,
          new ParDef("lV47TFSecUserName",GXType.VarChar,100,0) ,
          new ParDef("AV48TFSecUserName_Sel",GXType.VarChar,100,0) ,
          new ParDef("lV49TFSecUserFullName",GXType.VarChar,150,0) ,
          new ParDef("AV50TFSecUserFullName_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV51TFSecUserEmail",GXType.VarChar,100,0) ,
          new ParDef("AV52TFSecUserEmail_Sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00552", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00552,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((short[]) buf[12])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
