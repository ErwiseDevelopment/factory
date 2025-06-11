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
   public class participantewwexport : GXProcedure
   {
      public participantewwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public participantewwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "ParticipanteWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PARTICIPANTEDOCUMENTO") == 0 )
            {
               AV21ParticipanteDocumento1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ParticipanteDocumento1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Documento";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21ParticipanteDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PARTICIPANTEDOCUMENTO") == 0 )
               {
                  AV25ParticipanteDocumento2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ParticipanteDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Documento";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25ParticipanteDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV26DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV27DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV27DynamicFiltersSelector3, "PARTICIPANTEDOCUMENTO") == 0 )
                  {
                     AV29ParticipanteDocumento3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29ParticipanteDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Documento";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV29ParticipanteDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV46TFParticipanteId) && (0==AV47TFParticipanteId_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Id") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV46TFParticipanteId;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV47TFParticipanteId_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFParticipanteDocumento_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Documento") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV56TFParticipanteDocumento_Sel)) ? "(Vazio)" : AV56TFParticipanteDocumento_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV48TFParticipanteDocumento)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Documento") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV48TFParticipanteDocumento, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV51TFParticipanteEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Email") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV51TFParticipanteEmail_Sel)) ? "(Vazio)" : AV51TFParticipanteEmail_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV50TFParticipanteEmail)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Email") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV50TFParticipanteEmail, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Id";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Documento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Email";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV58Participantewwds_1_filterfulltext = AV18FilterFullText;
         AV59Participantewwds_2_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV60Participantewwds_3_participantedocumento1 = AV21ParticipanteDocumento1;
         AV61Participantewwds_4_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV62Participantewwds_5_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV63Participantewwds_6_participantedocumento2 = AV25ParticipanteDocumento2;
         AV64Participantewwds_7_dynamicfiltersenabled3 = AV26DynamicFiltersEnabled3;
         AV65Participantewwds_8_dynamicfiltersselector3 = AV27DynamicFiltersSelector3;
         AV66Participantewwds_9_participantedocumento3 = AV29ParticipanteDocumento3;
         AV67Participantewwds_10_tfparticipanteid = AV46TFParticipanteId;
         AV68Participantewwds_11_tfparticipanteid_to = AV47TFParticipanteId_To;
         AV69Participantewwds_12_tfparticipantedocumento = AV48TFParticipanteDocumento;
         AV70Participantewwds_13_tfparticipantedocumento_sel = AV56TFParticipanteDocumento_Sel;
         AV71Participantewwds_14_tfparticipanteemail = AV50TFParticipanteEmail;
         AV72Participantewwds_15_tfparticipanteemail_sel = AV51TFParticipanteEmail_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV58Participantewwds_1_filterfulltext ,
                                              AV59Participantewwds_2_dynamicfiltersselector1 ,
                                              AV60Participantewwds_3_participantedocumento1 ,
                                              AV61Participantewwds_4_dynamicfiltersenabled2 ,
                                              AV62Participantewwds_5_dynamicfiltersselector2 ,
                                              AV63Participantewwds_6_participantedocumento2 ,
                                              AV64Participantewwds_7_dynamicfiltersenabled3 ,
                                              AV65Participantewwds_8_dynamicfiltersselector3 ,
                                              AV66Participantewwds_9_participantedocumento3 ,
                                              AV67Participantewwds_10_tfparticipanteid ,
                                              AV68Participantewwds_11_tfparticipanteid_to ,
                                              AV70Participantewwds_13_tfparticipantedocumento_sel ,
                                              AV69Participantewwds_12_tfparticipantedocumento ,
                                              AV72Participantewwds_15_tfparticipanteemail_sel ,
                                              AV71Participantewwds_14_tfparticipanteemail ,
                                              A233ParticipanteId ,
                                              A234ParticipanteDocumento ,
                                              A235ParticipanteEmail ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Participantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Participantewwds_1_filterfulltext), "%", "");
         lV58Participantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Participantewwds_1_filterfulltext), "%", "");
         lV58Participantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Participantewwds_1_filterfulltext), "%", "");
         lV60Participantewwds_3_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV60Participantewwds_3_participantedocumento1), "%", "");
         lV63Participantewwds_6_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV63Participantewwds_6_participantedocumento2), "%", "");
         lV66Participantewwds_9_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV66Participantewwds_9_participantedocumento3), "%", "");
         lV69Participantewwds_12_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV69Participantewwds_12_tfparticipantedocumento), "%", "");
         lV71Participantewwds_14_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV71Participantewwds_14_tfparticipanteemail), "%", "");
         /* Using cursor P007C2 */
         pr_default.execute(0, new Object[] {lV58Participantewwds_1_filterfulltext, lV58Participantewwds_1_filterfulltext, lV58Participantewwds_1_filterfulltext, lV60Participantewwds_3_participantedocumento1, lV63Participantewwds_6_participantedocumento2, lV66Participantewwds_9_participantedocumento3, AV67Participantewwds_10_tfparticipanteid, AV68Participantewwds_11_tfparticipanteid_to, lV69Participantewwds_12_tfparticipantedocumento, AV70Participantewwds_13_tfparticipantedocumento_sel, lV71Participantewwds_14_tfparticipanteemail, AV72Participantewwds_15_tfparticipanteemail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A233ParticipanteId = P007C2_A233ParticipanteId[0];
            A235ParticipanteEmail = P007C2_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P007C2_n235ParticipanteEmail[0];
            A234ParticipanteDocumento = P007C2_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P007C2_n234ParticipanteDocumento[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A233ParticipanteId;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A234ParticipanteDocumento, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A235ParticipanteEmail, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
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
         AV31Session.Set("WWPExportFileName", "ParticipanteWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("ParticipanteWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ParticipanteWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("ParticipanteWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV73GXV1 = 1;
         while ( AV73GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV73GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEID") == 0 )
            {
               AV46TFParticipanteId = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV47TFParticipanteId_To = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO") == 0 )
            {
               AV48TFParticipanteDocumento = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO_SEL") == 0 )
            {
               AV56TFParticipanteDocumento_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL") == 0 )
            {
               AV50TFParticipanteEmail = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL_SEL") == 0 )
            {
               AV51TFParticipanteEmail_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            AV73GXV1 = (int)(AV73GXV1+1);
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
         AV21ParticipanteDocumento1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25ParticipanteDocumento2 = "";
         AV27DynamicFiltersSelector3 = "";
         AV29ParticipanteDocumento3 = "";
         AV56TFParticipanteDocumento_Sel = "";
         AV48TFParticipanteDocumento = "";
         AV51TFParticipanteEmail_Sel = "";
         AV50TFParticipanteEmail = "";
         AV58Participantewwds_1_filterfulltext = "";
         AV59Participantewwds_2_dynamicfiltersselector1 = "";
         AV60Participantewwds_3_participantedocumento1 = "";
         AV62Participantewwds_5_dynamicfiltersselector2 = "";
         AV63Participantewwds_6_participantedocumento2 = "";
         AV65Participantewwds_8_dynamicfiltersselector3 = "";
         AV66Participantewwds_9_participantedocumento3 = "";
         AV69Participantewwds_12_tfparticipantedocumento = "";
         AV70Participantewwds_13_tfparticipantedocumento_sel = "";
         AV71Participantewwds_14_tfparticipanteemail = "";
         AV72Participantewwds_15_tfparticipanteemail_sel = "";
         lV58Participantewwds_1_filterfulltext = "";
         lV60Participantewwds_3_participantedocumento1 = "";
         lV63Participantewwds_6_participantedocumento2 = "";
         lV66Participantewwds_9_participantedocumento3 = "";
         lV69Participantewwds_12_tfparticipantedocumento = "";
         lV71Participantewwds_14_tfparticipanteemail = "";
         A234ParticipanteDocumento = "";
         A235ParticipanteEmail = "";
         P007C2_A233ParticipanteId = new int[1] ;
         P007C2_A235ParticipanteEmail = new string[] {""} ;
         P007C2_n235ParticipanteEmail = new bool[] {false} ;
         P007C2_A234ParticipanteDocumento = new string[] {""} ;
         P007C2_n234ParticipanteDocumento = new bool[] {false} ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.participantewwexport__default(),
            new Object[][] {
                new Object[] {
               P007C2_A233ParticipanteId, P007C2_A235ParticipanteEmail, P007C2_n235ParticipanteEmail, P007C2_A234ParticipanteDocumento, P007C2_n234ParticipanteDocumento
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
      private int AV46TFParticipanteId ;
      private int AV47TFParticipanteId_To ;
      private int AV67Participantewwds_10_tfparticipanteid ;
      private int AV68Participantewwds_11_tfparticipanteid_to ;
      private int A233ParticipanteId ;
      private int AV73GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV26DynamicFiltersEnabled3 ;
      private bool AV61Participantewwds_4_dynamicfiltersenabled2 ;
      private bool AV64Participantewwds_7_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n235ParticipanteEmail ;
      private bool n234ParticipanteDocumento ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21ParticipanteDocumento1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25ParticipanteDocumento2 ;
      private string AV27DynamicFiltersSelector3 ;
      private string AV29ParticipanteDocumento3 ;
      private string AV56TFParticipanteDocumento_Sel ;
      private string AV48TFParticipanteDocumento ;
      private string AV51TFParticipanteEmail_Sel ;
      private string AV50TFParticipanteEmail ;
      private string AV58Participantewwds_1_filterfulltext ;
      private string AV59Participantewwds_2_dynamicfiltersselector1 ;
      private string AV60Participantewwds_3_participantedocumento1 ;
      private string AV62Participantewwds_5_dynamicfiltersselector2 ;
      private string AV63Participantewwds_6_participantedocumento2 ;
      private string AV65Participantewwds_8_dynamicfiltersselector3 ;
      private string AV66Participantewwds_9_participantedocumento3 ;
      private string AV69Participantewwds_12_tfparticipantedocumento ;
      private string AV70Participantewwds_13_tfparticipantedocumento_sel ;
      private string AV71Participantewwds_14_tfparticipanteemail ;
      private string AV72Participantewwds_15_tfparticipanteemail_sel ;
      private string lV58Participantewwds_1_filterfulltext ;
      private string lV60Participantewwds_3_participantedocumento1 ;
      private string lV63Participantewwds_6_participantedocumento2 ;
      private string lV66Participantewwds_9_participantedocumento3 ;
      private string lV69Participantewwds_12_tfparticipantedocumento ;
      private string lV71Participantewwds_14_tfparticipanteemail ;
      private string A234ParticipanteDocumento ;
      private string A235ParticipanteEmail ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private int[] P007C2_A233ParticipanteId ;
      private string[] P007C2_A235ParticipanteEmail ;
      private bool[] P007C2_n235ParticipanteEmail ;
      private string[] P007C2_A234ParticipanteDocumento ;
      private bool[] P007C2_n234ParticipanteDocumento ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class participantewwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007C2( IGxContext context ,
                                             string AV58Participantewwds_1_filterfulltext ,
                                             string AV59Participantewwds_2_dynamicfiltersselector1 ,
                                             string AV60Participantewwds_3_participantedocumento1 ,
                                             bool AV61Participantewwds_4_dynamicfiltersenabled2 ,
                                             string AV62Participantewwds_5_dynamicfiltersselector2 ,
                                             string AV63Participantewwds_6_participantedocumento2 ,
                                             bool AV64Participantewwds_7_dynamicfiltersenabled3 ,
                                             string AV65Participantewwds_8_dynamicfiltersselector3 ,
                                             string AV66Participantewwds_9_participantedocumento3 ,
                                             int AV67Participantewwds_10_tfparticipanteid ,
                                             int AV68Participantewwds_11_tfparticipanteid_to ,
                                             string AV70Participantewwds_13_tfparticipantedocumento_sel ,
                                             string AV69Participantewwds_12_tfparticipantedocumento ,
                                             string AV72Participantewwds_15_tfparticipanteemail_sel ,
                                             string AV71Participantewwds_14_tfparticipanteemail ,
                                             int A233ParticipanteId ,
                                             string A234ParticipanteDocumento ,
                                             string A235ParticipanteEmail ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT ParticipanteId, ParticipanteEmail, ParticipanteDocumento FROM Participante";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Participantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(ParticipanteId,'99999999'), 2) like '%' || :lV58Participantewwds_1_filterfulltext) or ( ParticipanteDocumento like '%' || :lV58Participantewwds_1_filterfulltext) or ( ParticipanteEmail like '%' || :lV58Participantewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Participantewwds_2_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Participantewwds_3_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV60Participantewwds_3_participantedocumento1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV61Participantewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Participantewwds_5_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Participantewwds_6_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV63Participantewwds_6_participantedocumento2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV64Participantewwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Participantewwds_8_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Participantewwds_9_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV66Participantewwds_9_participantedocumento3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV67Participantewwds_10_tfparticipanteid) )
         {
            AddWhere(sWhereString, "(ParticipanteId >= :AV67Participantewwds_10_tfparticipanteid)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV68Participantewwds_11_tfparticipanteid_to) )
         {
            AddWhere(sWhereString, "(ParticipanteId <= :AV68Participantewwds_11_tfparticipanteid_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Participantewwds_13_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Participantewwds_12_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV69Participantewwds_12_tfparticipantedocumento)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Participantewwds_13_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV70Participantewwds_13_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento = ( :AV70Participantewwds_13_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV70Participantewwds_13_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from ParticipanteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Participantewwds_15_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Participantewwds_14_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteEmail like :lV71Participantewwds_14_tfparticipanteemail)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Participantewwds_15_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV72Participantewwds_15_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParticipanteEmail = ( :AV72Participantewwds_15_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV72Participantewwds_15_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from ParticipanteEmail))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ParticipanteDocumento";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ParticipanteDocumento DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ParticipanteId";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ParticipanteId DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY ParticipanteEmail";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY ParticipanteEmail DESC";
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
                     return conditional_P007C2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP007C2;
          prmP007C2 = new Object[] {
          new ParDef("lV58Participantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Participantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV58Participantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Participantewwds_3_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("lV63Participantewwds_6_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("lV66Participantewwds_9_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("AV67Participantewwds_10_tfparticipanteid",GXType.Int32,8,0) ,
          new ParDef("AV68Participantewwds_11_tfparticipanteid_to",GXType.Int32,8,0) ,
          new ParDef("lV69Participantewwds_12_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV70Participantewwds_13_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("lV71Participantewwds_14_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV72Participantewwds_15_tfparticipanteemail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007C2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
