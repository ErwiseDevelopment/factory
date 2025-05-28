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
   public class wclistaassinantesexport : GXProcedure
   {
      public wclistaassinantesexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wclistaassinantesexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "WcListaAssinantesExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "ASSINATURAPARTICIPANTESTATUS") == 0 )
            {
               AV21AssinaturaParticipanteStatus1 = AV33GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21AssinaturaParticipanteStatus1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Participante Status";
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21AssinaturaParticipanteStatus1)) )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmassinaturaparticipantestatus.getDescription(context,AV21AssinaturaParticipanteStatus1);
                  }
               }
            }
            else if ( StringUtil.StrCmp(AV19DynamicFiltersSelector1, "PARTICIPANTEDOCUMENTO") == 0 )
            {
               AV20DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV22ParticipanteDocumento1 = AV33GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ParticipanteDocumento1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV20DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Participante Documento", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV20DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Participante Documento", "Contém", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22ParticipanteDocumento1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "ASSINATURAPARTICIPANTESTATUS") == 0 )
               {
                  AV26AssinaturaParticipanteStatus2 = AV33GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26AssinaturaParticipanteStatus2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Participante Status";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26AssinaturaParticipanteStatus2)) )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmassinaturaparticipantestatus.getDescription(context,AV26AssinaturaParticipanteStatus2);
                     }
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "PARTICIPANTEDOCUMENTO") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV27ParticipanteDocumento2 = AV33GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ParticipanteDocumento2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Participante Documento", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Participante Documento", "Contém", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27ParticipanteDocumento2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV28DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(3));
                  AV29DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "ASSINATURAPARTICIPANTESTATUS") == 0 )
                  {
                     AV31AssinaturaParticipanteStatus3 = AV33GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31AssinaturaParticipanteStatus3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Participante Status";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31AssinaturaParticipanteStatus3)) )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = gxdomaindmassinaturaparticipantestatus.getDescription(context,AV31AssinaturaParticipanteStatus3);
                        }
                     }
                  }
                  else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector3, "PARTICIPANTEDOCUMENTO") == 0 )
                  {
                     AV30DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV32ParticipanteDocumento3 = AV33GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32ParticipanteDocumento3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV30DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Participante Documento", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV30DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Participante Documento", "Contém", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV32ParticipanteDocumento3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFParticipanteNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV39TFParticipanteNome_Sel)) ? "(Vazio)" : AV39TFParticipanteNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFParticipanteNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nome") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFParticipanteNome, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFParticipanteEmail_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Email") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV41TFParticipanteEmail_Sel)) ? "(Vazio)" : AV41TFParticipanteEmail_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFParticipanteEmail)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Email") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFParticipanteEmail, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFParticipanteDocumento_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Documento") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV43TFParticipanteDocumento_Sel)) ? "(Vazio)" : AV43TFParticipanteDocumento_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFParticipanteDocumento)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Documento") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFParticipanteDocumento, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV55TFAssinaturaParticipanteTipo_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo do participante") ;
            AV13CellRow = GXt_int2;
            AV51i = 1;
            AV56GXV1 = 1;
            while ( AV56GXV1 <= AV55TFAssinaturaParticipanteTipo_Sels.Count )
            {
               AV54TFAssinaturaParticipanteTipo_Sel = ((string)AV55TFAssinaturaParticipanteTipo_Sels.Item(AV56GXV1));
               if ( AV51i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmtipoparticipante.getDescription(context,AV54TFAssinaturaParticipanteTipo_Sel);
               AV51i = (long)(AV51i+1);
               AV56GXV1 = (int)(AV56GXV1+1);
            }
         }
         if ( ! ( ( AV46TFAssinaturaParticipanteStatus_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Status") ;
            AV13CellRow = GXt_int2;
            AV51i = 1;
            AV57GXV2 = 1;
            while ( AV57GXV2 <= AV46TFAssinaturaParticipanteStatus_Sels.Count )
            {
               AV45TFAssinaturaParticipanteStatus_Sel = ((string)AV46TFAssinaturaParticipanteStatus_Sels.Item(AV57GXV2));
               if ( AV51i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomaindmassinaturaparticipantestatus.getDescription(context,AV45TFAssinaturaParticipanteStatus_Sel);
               AV51i = (long)(AV51i+1);
               AV57GXV2 = (int)(AV57GXV2+1);
            }
         }
         if ( ! ( (DateTime.MinValue==AV47TFAssinaturaParticipanteDataVisualizacao) && (DateTime.MinValue==AV48TFAssinaturaParticipanteDataVisualizacao_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Visualizado") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV47TFAssinaturaParticipanteDataVisualizacao;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV48TFAssinaturaParticipanteDataVisualizacao_To;
         }
         if ( ! ( (DateTime.MinValue==AV49TFAssinaturaParticipanteDataConclusao) && (DateTime.MinValue==AV50TFAssinaturaParticipanteDataConclusao_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Assinatura") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV49TFAssinaturaParticipanteDataConclusao;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV50TFAssinaturaParticipanteDataConclusao_To;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Email";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Documento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Tipo do participante";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Status";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Visualizado";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Assinatura";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV59Wclistaassinantesds_1_assinaturaid = AV52AssinaturaId;
         AV60Wclistaassinantesds_2_filterfulltext = AV18FilterFullText;
         AV61Wclistaassinantesds_3_dynamicfiltersselector1 = AV19DynamicFiltersSelector1;
         AV62Wclistaassinantesds_4_dynamicfiltersoperator1 = AV20DynamicFiltersOperator1;
         AV63Wclistaassinantesds_5_assinaturaparticipantestatus1 = AV21AssinaturaParticipanteStatus1;
         AV64Wclistaassinantesds_6_participantedocumento1 = AV22ParticipanteDocumento1;
         AV65Wclistaassinantesds_7_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV66Wclistaassinantesds_8_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV67Wclistaassinantesds_9_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV68Wclistaassinantesds_10_assinaturaparticipantestatus2 = AV26AssinaturaParticipanteStatus2;
         AV69Wclistaassinantesds_11_participantedocumento2 = AV27ParticipanteDocumento2;
         AV70Wclistaassinantesds_12_dynamicfiltersenabled3 = AV28DynamicFiltersEnabled3;
         AV71Wclistaassinantesds_13_dynamicfiltersselector3 = AV29DynamicFiltersSelector3;
         AV72Wclistaassinantesds_14_dynamicfiltersoperator3 = AV30DynamicFiltersOperator3;
         AV73Wclistaassinantesds_15_assinaturaparticipantestatus3 = AV31AssinaturaParticipanteStatus3;
         AV74Wclistaassinantesds_16_participantedocumento3 = AV32ParticipanteDocumento3;
         AV75Wclistaassinantesds_17_tfparticipantenome = AV38TFParticipanteNome;
         AV76Wclistaassinantesds_18_tfparticipantenome_sel = AV39TFParticipanteNome_Sel;
         AV77Wclistaassinantesds_19_tfparticipanteemail = AV40TFParticipanteEmail;
         AV78Wclistaassinantesds_20_tfparticipanteemail_sel = AV41TFParticipanteEmail_Sel;
         AV79Wclistaassinantesds_21_tfparticipantedocumento = AV42TFParticipanteDocumento;
         AV80Wclistaassinantesds_22_tfparticipantedocumento_sel = AV43TFParticipanteDocumento_Sel;
         AV81Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels = AV55TFAssinaturaParticipanteTipo_Sels;
         AV82Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels = AV46TFAssinaturaParticipanteStatus_Sels;
         AV83Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao = AV47TFAssinaturaParticipanteDataVisualizacao;
         AV84Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to = AV48TFAssinaturaParticipanteDataVisualizacao_To;
         AV85Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao = AV49TFAssinaturaParticipanteDataConclusao;
         AV86Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to = AV50TFAssinaturaParticipanteDataConclusao_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A247AssinaturaParticipanteTipo ,
                                              AV81Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ,
                                              A353AssinaturaParticipanteStatus ,
                                              AV82Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ,
                                              AV60Wclistaassinantesds_2_filterfulltext ,
                                              AV61Wclistaassinantesds_3_dynamicfiltersselector1 ,
                                              AV63Wclistaassinantesds_5_assinaturaparticipantestatus1 ,
                                              AV62Wclistaassinantesds_4_dynamicfiltersoperator1 ,
                                              AV64Wclistaassinantesds_6_participantedocumento1 ,
                                              AV65Wclistaassinantesds_7_dynamicfiltersenabled2 ,
                                              AV66Wclistaassinantesds_8_dynamicfiltersselector2 ,
                                              AV68Wclistaassinantesds_10_assinaturaparticipantestatus2 ,
                                              AV67Wclistaassinantesds_9_dynamicfiltersoperator2 ,
                                              AV69Wclistaassinantesds_11_participantedocumento2 ,
                                              AV70Wclistaassinantesds_12_dynamicfiltersenabled3 ,
                                              AV71Wclistaassinantesds_13_dynamicfiltersselector3 ,
                                              AV73Wclistaassinantesds_15_assinaturaparticipantestatus3 ,
                                              AV72Wclistaassinantesds_14_dynamicfiltersoperator3 ,
                                              AV74Wclistaassinantesds_16_participantedocumento3 ,
                                              AV76Wclistaassinantesds_18_tfparticipantenome_sel ,
                                              AV75Wclistaassinantesds_17_tfparticipantenome ,
                                              AV78Wclistaassinantesds_20_tfparticipanteemail_sel ,
                                              AV77Wclistaassinantesds_19_tfparticipanteemail ,
                                              AV80Wclistaassinantesds_22_tfparticipantedocumento_sel ,
                                              AV79Wclistaassinantesds_21_tfparticipantedocumento ,
                                              AV81Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels.Count ,
                                              AV82Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels.Count ,
                                              AV83Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ,
                                              AV84Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ,
                                              AV85Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ,
                                              AV86Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ,
                                              A248ParticipanteNome ,
                                              A235ParticipanteEmail ,
                                              A234ParticipanteDocumento ,
                                              A244AssinaturaParticipanteDataVisualizacao ,
                                              A245AssinaturaParticipanteDataConclusao ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc ,
                                              AV59Wclistaassinantesds_1_assinaturaid ,
                                              A238AssinaturaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV60Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Wclistaassinantesds_2_filterfulltext), "%", "");
         lV60Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Wclistaassinantesds_2_filterfulltext), "%", "");
         lV60Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Wclistaassinantesds_2_filterfulltext), "%", "");
         lV60Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Wclistaassinantesds_2_filterfulltext), "%", "");
         lV60Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Wclistaassinantesds_2_filterfulltext), "%", "");
         lV60Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Wclistaassinantesds_2_filterfulltext), "%", "");
         lV60Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Wclistaassinantesds_2_filterfulltext), "%", "");
         lV60Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Wclistaassinantesds_2_filterfulltext), "%", "");
         lV60Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Wclistaassinantesds_2_filterfulltext), "%", "");
         lV60Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV60Wclistaassinantesds_2_filterfulltext), "%", "");
         lV64Wclistaassinantesds_6_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV64Wclistaassinantesds_6_participantedocumento1), "%", "");
         lV64Wclistaassinantesds_6_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV64Wclistaassinantesds_6_participantedocumento1), "%", "");
         lV69Wclistaassinantesds_11_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV69Wclistaassinantesds_11_participantedocumento2), "%", "");
         lV69Wclistaassinantesds_11_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV69Wclistaassinantesds_11_participantedocumento2), "%", "");
         lV74Wclistaassinantesds_16_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV74Wclistaassinantesds_16_participantedocumento3), "%", "");
         lV74Wclistaassinantesds_16_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV74Wclistaassinantesds_16_participantedocumento3), "%", "");
         lV75Wclistaassinantesds_17_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV75Wclistaassinantesds_17_tfparticipantenome), "%", "");
         lV77Wclistaassinantesds_19_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV77Wclistaassinantesds_19_tfparticipanteemail), "%", "");
         lV79Wclistaassinantesds_21_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV79Wclistaassinantesds_21_tfparticipantedocumento), "%", "");
         /* Using cursor P00922 */
         pr_default.execute(0, new Object[] {AV59Wclistaassinantesds_1_assinaturaid, lV60Wclistaassinantesds_2_filterfulltext, lV60Wclistaassinantesds_2_filterfulltext, lV60Wclistaassinantesds_2_filterfulltext, lV60Wclistaassinantesds_2_filterfulltext, lV60Wclistaassinantesds_2_filterfulltext, lV60Wclistaassinantesds_2_filterfulltext, lV60Wclistaassinantesds_2_filterfulltext, lV60Wclistaassinantesds_2_filterfulltext, lV60Wclistaassinantesds_2_filterfulltext, lV60Wclistaassinantesds_2_filterfulltext, AV63Wclistaassinantesds_5_assinaturaparticipantestatus1, lV64Wclistaassinantesds_6_participantedocumento1, lV64Wclistaassinantesds_6_participantedocumento1, AV68Wclistaassinantesds_10_assinaturaparticipantestatus2, lV69Wclistaassinantesds_11_participantedocumento2, lV69Wclistaassinantesds_11_participantedocumento2, AV73Wclistaassinantesds_15_assinaturaparticipantestatus3, lV74Wclistaassinantesds_16_participantedocumento3, lV74Wclistaassinantesds_16_participantedocumento3, lV75Wclistaassinantesds_17_tfparticipantenome, AV76Wclistaassinantesds_18_tfparticipantenome_sel, lV77Wclistaassinantesds_19_tfparticipanteemail, AV78Wclistaassinantesds_20_tfparticipanteemail_sel, lV79Wclistaassinantesds_21_tfparticipantedocumento, AV80Wclistaassinantesds_22_tfparticipantedocumento_sel, AV83Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao, AV84Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to, AV85Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao, AV86Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A233ParticipanteId = P00922_A233ParticipanteId[0];
            n233ParticipanteId = P00922_n233ParticipanteId[0];
            A245AssinaturaParticipanteDataConclusao = P00922_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = P00922_n245AssinaturaParticipanteDataConclusao[0];
            A244AssinaturaParticipanteDataVisualizacao = P00922_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = P00922_n244AssinaturaParticipanteDataVisualizacao[0];
            A353AssinaturaParticipanteStatus = P00922_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = P00922_n353AssinaturaParticipanteStatus[0];
            A247AssinaturaParticipanteTipo = P00922_A247AssinaturaParticipanteTipo[0];
            n247AssinaturaParticipanteTipo = P00922_n247AssinaturaParticipanteTipo[0];
            A234ParticipanteDocumento = P00922_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00922_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00922_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00922_n235ParticipanteEmail[0];
            A248ParticipanteNome = P00922_A248ParticipanteNome[0];
            n248ParticipanteNome = P00922_n248ParticipanteNome[0];
            A238AssinaturaId = P00922_A238AssinaturaId[0];
            n238AssinaturaId = P00922_n238AssinaturaId[0];
            A242AssinaturaParticipanteId = P00922_A242AssinaturaParticipanteId[0];
            A234ParticipanteDocumento = P00922_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00922_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00922_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00922_n235ParticipanteEmail[0];
            A248ParticipanteNome = P00922_A248ParticipanteNome[0];
            n248ParticipanteNome = P00922_n248ParticipanteNome[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A248ParticipanteNome, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A235ParticipanteEmail, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A234ParticipanteDocumento, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = gxdomaindmtipoparticipante.getDescription(context,A247AssinaturaParticipanteTipo);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = gxdomaindmassinaturaparticipantestatus.getDescription(context,A353AssinaturaParticipanteStatus);
            if ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Pendente") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = GXUtil.RGB( 60, 141, 188);
            }
            else if ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Assinado") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = GXUtil.RGB( 0, 166, 90);
            }
            else if ( StringUtil.StrCmp(A353AssinaturaParticipanteStatus, "Recusado") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = GXUtil.RGB( 221, 75, 57);
            }
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Date = A244AssinaturaParticipanteDataVisualizacao;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Date = A245AssinaturaParticipanteDataConclusao;
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
         AV34Session.Set("WWPExportFileName", "WcListaAssinantesExport.xlsx");
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
         if ( StringUtil.StrCmp(AV34Session.Get("WcListaAssinantesGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WcListaAssinantesGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("WcListaAssinantesGridState"), null, "", "");
         }
         AV16OrderedBy = AV36GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV36GridState.gxTpr_Ordereddsc;
         AV87GXV3 = 1;
         while ( AV87GXV3 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV87GXV3));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTENOME") == 0 )
            {
               AV38TFParticipanteNome = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTENOME_SEL") == 0 )
            {
               AV39TFParticipanteNome_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL") == 0 )
            {
               AV40TFParticipanteEmail = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL_SEL") == 0 )
            {
               AV41TFParticipanteEmail_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO") == 0 )
            {
               AV42TFParticipanteDocumento = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO_SEL") == 0 )
            {
               AV43TFParticipanteDocumento_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTETIPO_SEL") == 0 )
            {
               AV53TFAssinaturaParticipanteTipo_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV55TFAssinaturaParticipanteTipo_Sels.FromJSonString(AV53TFAssinaturaParticipanteTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTESTATUS_SEL") == 0 )
            {
               AV44TFAssinaturaParticipanteStatus_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV46TFAssinaturaParticipanteStatus_Sels.FromJSonString(AV44TFAssinaturaParticipanteStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTEDATAVISUALIZACAO") == 0 )
            {
               AV47TFAssinaturaParticipanteDataVisualizacao = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Value, 4);
               AV48TFAssinaturaParticipanteDataVisualizacao_To = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTEDATACONCLUSAO") == 0 )
            {
               AV49TFAssinaturaParticipanteDataConclusao = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Value, 4);
               AV50TFAssinaturaParticipanteDataConclusao_To = context.localUtil.CToT( AV37GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "PARM_&ASSINATURAID") == 0 )
            {
               AV52AssinaturaId = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV87GXV3 = (int)(AV87GXV3+1);
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
         AV21AssinaturaParticipanteStatus1 = "";
         AV22ParticipanteDocumento1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26AssinaturaParticipanteStatus2 = "";
         AV27ParticipanteDocumento2 = "";
         AV29DynamicFiltersSelector3 = "";
         AV31AssinaturaParticipanteStatus3 = "";
         AV32ParticipanteDocumento3 = "";
         AV39TFParticipanteNome_Sel = "";
         AV38TFParticipanteNome = "";
         AV41TFParticipanteEmail_Sel = "";
         AV40TFParticipanteEmail = "";
         AV43TFParticipanteDocumento_Sel = "";
         AV42TFParticipanteDocumento = "";
         AV55TFAssinaturaParticipanteTipo_Sels = new GxSimpleCollection<string>();
         AV54TFAssinaturaParticipanteTipo_Sel = "";
         AV46TFAssinaturaParticipanteStatus_Sels = new GxSimpleCollection<string>();
         AV45TFAssinaturaParticipanteStatus_Sel = "";
         AV47TFAssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         AV48TFAssinaturaParticipanteDataVisualizacao_To = (DateTime)(DateTime.MinValue);
         AV49TFAssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         AV50TFAssinaturaParticipanteDataConclusao_To = (DateTime)(DateTime.MinValue);
         AV60Wclistaassinantesds_2_filterfulltext = "";
         AV61Wclistaassinantesds_3_dynamicfiltersselector1 = "";
         AV63Wclistaassinantesds_5_assinaturaparticipantestatus1 = "";
         AV64Wclistaassinantesds_6_participantedocumento1 = "";
         AV66Wclistaassinantesds_8_dynamicfiltersselector2 = "";
         AV68Wclistaassinantesds_10_assinaturaparticipantestatus2 = "";
         AV69Wclistaassinantesds_11_participantedocumento2 = "";
         AV71Wclistaassinantesds_13_dynamicfiltersselector3 = "";
         AV73Wclistaassinantesds_15_assinaturaparticipantestatus3 = "";
         AV74Wclistaassinantesds_16_participantedocumento3 = "";
         AV75Wclistaassinantesds_17_tfparticipantenome = "";
         AV76Wclistaassinantesds_18_tfparticipantenome_sel = "";
         AV77Wclistaassinantesds_19_tfparticipanteemail = "";
         AV78Wclistaassinantesds_20_tfparticipanteemail_sel = "";
         AV79Wclistaassinantesds_21_tfparticipantedocumento = "";
         AV80Wclistaassinantesds_22_tfparticipantedocumento_sel = "";
         AV81Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels = new GxSimpleCollection<string>();
         AV82Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels = new GxSimpleCollection<string>();
         AV83Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao = (DateTime)(DateTime.MinValue);
         AV84Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to = (DateTime)(DateTime.MinValue);
         AV85Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao = (DateTime)(DateTime.MinValue);
         AV86Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to = (DateTime)(DateTime.MinValue);
         lV60Wclistaassinantesds_2_filterfulltext = "";
         lV64Wclistaassinantesds_6_participantedocumento1 = "";
         lV69Wclistaassinantesds_11_participantedocumento2 = "";
         lV74Wclistaassinantesds_16_participantedocumento3 = "";
         lV75Wclistaassinantesds_17_tfparticipantenome = "";
         lV77Wclistaassinantesds_19_tfparticipanteemail = "";
         lV79Wclistaassinantesds_21_tfparticipantedocumento = "";
         A247AssinaturaParticipanteTipo = "";
         A353AssinaturaParticipanteStatus = "";
         A248ParticipanteNome = "";
         A235ParticipanteEmail = "";
         A234ParticipanteDocumento = "";
         A244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         A245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         P00922_A233ParticipanteId = new int[1] ;
         P00922_n233ParticipanteId = new bool[] {false} ;
         P00922_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         P00922_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         P00922_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         P00922_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         P00922_A353AssinaturaParticipanteStatus = new string[] {""} ;
         P00922_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         P00922_A247AssinaturaParticipanteTipo = new string[] {""} ;
         P00922_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         P00922_A234ParticipanteDocumento = new string[] {""} ;
         P00922_n234ParticipanteDocumento = new bool[] {false} ;
         P00922_A235ParticipanteEmail = new string[] {""} ;
         P00922_n235ParticipanteEmail = new bool[] {false} ;
         P00922_A248ParticipanteNome = new string[] {""} ;
         P00922_n248ParticipanteNome = new bool[] {false} ;
         P00922_A238AssinaturaId = new long[1] ;
         P00922_n238AssinaturaId = new bool[] {false} ;
         P00922_A242AssinaturaParticipanteId = new int[1] ;
         GXt_char1 = "";
         AV34Session = context.GetSession();
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53TFAssinaturaParticipanteTipo_SelsJson = "";
         AV44TFAssinaturaParticipanteStatus_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wclistaassinantesexport__default(),
            new Object[][] {
                new Object[] {
               P00922_A233ParticipanteId, P00922_n233ParticipanteId, P00922_A245AssinaturaParticipanteDataConclusao, P00922_n245AssinaturaParticipanteDataConclusao, P00922_A244AssinaturaParticipanteDataVisualizacao, P00922_n244AssinaturaParticipanteDataVisualizacao, P00922_A353AssinaturaParticipanteStatus, P00922_n353AssinaturaParticipanteStatus, P00922_A247AssinaturaParticipanteTipo, P00922_n247AssinaturaParticipanteTipo,
               P00922_A234ParticipanteDocumento, P00922_n234ParticipanteDocumento, P00922_A235ParticipanteEmail, P00922_n235ParticipanteEmail, P00922_A248ParticipanteNome, P00922_n248ParticipanteNome, P00922_A238AssinaturaId, P00922_n238AssinaturaId, P00922_A242AssinaturaParticipanteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV30DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV62Wclistaassinantesds_4_dynamicfiltersoperator1 ;
      private short AV67Wclistaassinantesds_9_dynamicfiltersoperator2 ;
      private short AV72Wclistaassinantesds_14_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV56GXV1 ;
      private int AV57GXV2 ;
      private int AV81Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count ;
      private int AV82Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count ;
      private int A233ParticipanteId ;
      private int A242AssinaturaParticipanteId ;
      private int AV87GXV3 ;
      private long AV51i ;
      private long AV59Wclistaassinantesds_1_assinaturaid ;
      private long AV52AssinaturaId ;
      private long A238AssinaturaId ;
      private string GXt_char1 ;
      private DateTime AV47TFAssinaturaParticipanteDataVisualizacao ;
      private DateTime AV48TFAssinaturaParticipanteDataVisualizacao_To ;
      private DateTime AV49TFAssinaturaParticipanteDataConclusao ;
      private DateTime AV50TFAssinaturaParticipanteDataConclusao_To ;
      private DateTime AV83Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ;
      private DateTime AV84Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ;
      private DateTime AV85Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ;
      private DateTime AV86Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ;
      private DateTime A244AssinaturaParticipanteDataVisualizacao ;
      private DateTime A245AssinaturaParticipanteDataConclusao ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV28DynamicFiltersEnabled3 ;
      private bool AV65Wclistaassinantesds_7_dynamicfiltersenabled2 ;
      private bool AV70Wclistaassinantesds_12_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n233ParticipanteId ;
      private bool n245AssinaturaParticipanteDataConclusao ;
      private bool n244AssinaturaParticipanteDataVisualizacao ;
      private bool n353AssinaturaParticipanteStatus ;
      private bool n247AssinaturaParticipanteTipo ;
      private bool n234ParticipanteDocumento ;
      private bool n235ParticipanteEmail ;
      private bool n248ParticipanteNome ;
      private bool n238AssinaturaId ;
      private string AV53TFAssinaturaParticipanteTipo_SelsJson ;
      private string AV44TFAssinaturaParticipanteStatus_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV19DynamicFiltersSelector1 ;
      private string AV21AssinaturaParticipanteStatus1 ;
      private string AV22ParticipanteDocumento1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26AssinaturaParticipanteStatus2 ;
      private string AV27ParticipanteDocumento2 ;
      private string AV29DynamicFiltersSelector3 ;
      private string AV31AssinaturaParticipanteStatus3 ;
      private string AV32ParticipanteDocumento3 ;
      private string AV39TFParticipanteNome_Sel ;
      private string AV38TFParticipanteNome ;
      private string AV41TFParticipanteEmail_Sel ;
      private string AV40TFParticipanteEmail ;
      private string AV43TFParticipanteDocumento_Sel ;
      private string AV42TFParticipanteDocumento ;
      private string AV54TFAssinaturaParticipanteTipo_Sel ;
      private string AV45TFAssinaturaParticipanteStatus_Sel ;
      private string AV60Wclistaassinantesds_2_filterfulltext ;
      private string AV61Wclistaassinantesds_3_dynamicfiltersselector1 ;
      private string AV63Wclistaassinantesds_5_assinaturaparticipantestatus1 ;
      private string AV64Wclistaassinantesds_6_participantedocumento1 ;
      private string AV66Wclistaassinantesds_8_dynamicfiltersselector2 ;
      private string AV68Wclistaassinantesds_10_assinaturaparticipantestatus2 ;
      private string AV69Wclistaassinantesds_11_participantedocumento2 ;
      private string AV71Wclistaassinantesds_13_dynamicfiltersselector3 ;
      private string AV73Wclistaassinantesds_15_assinaturaparticipantestatus3 ;
      private string AV74Wclistaassinantesds_16_participantedocumento3 ;
      private string AV75Wclistaassinantesds_17_tfparticipantenome ;
      private string AV76Wclistaassinantesds_18_tfparticipantenome_sel ;
      private string AV77Wclistaassinantesds_19_tfparticipanteemail ;
      private string AV78Wclistaassinantesds_20_tfparticipanteemail_sel ;
      private string AV79Wclistaassinantesds_21_tfparticipantedocumento ;
      private string AV80Wclistaassinantesds_22_tfparticipantedocumento_sel ;
      private string lV60Wclistaassinantesds_2_filterfulltext ;
      private string lV64Wclistaassinantesds_6_participantedocumento1 ;
      private string lV69Wclistaassinantesds_11_participantedocumento2 ;
      private string lV74Wclistaassinantesds_16_participantedocumento3 ;
      private string lV75Wclistaassinantesds_17_tfparticipantenome ;
      private string lV77Wclistaassinantesds_19_tfparticipanteemail ;
      private string lV79Wclistaassinantesds_21_tfparticipantedocumento ;
      private string A247AssinaturaParticipanteTipo ;
      private string A353AssinaturaParticipanteStatus ;
      private string A248ParticipanteNome ;
      private string A235ParticipanteEmail ;
      private string A234ParticipanteDocumento ;
      private IGxSession AV34Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV33GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV55TFAssinaturaParticipanteTipo_Sels ;
      private GxSimpleCollection<string> AV46TFAssinaturaParticipanteStatus_Sels ;
      private GxSimpleCollection<string> AV81Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ;
      private GxSimpleCollection<string> AV82Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00922_A233ParticipanteId ;
      private bool[] P00922_n233ParticipanteId ;
      private DateTime[] P00922_A245AssinaturaParticipanteDataConclusao ;
      private bool[] P00922_n245AssinaturaParticipanteDataConclusao ;
      private DateTime[] P00922_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] P00922_n244AssinaturaParticipanteDataVisualizacao ;
      private string[] P00922_A353AssinaturaParticipanteStatus ;
      private bool[] P00922_n353AssinaturaParticipanteStatus ;
      private string[] P00922_A247AssinaturaParticipanteTipo ;
      private bool[] P00922_n247AssinaturaParticipanteTipo ;
      private string[] P00922_A234ParticipanteDocumento ;
      private bool[] P00922_n234ParticipanteDocumento ;
      private string[] P00922_A235ParticipanteEmail ;
      private bool[] P00922_n235ParticipanteEmail ;
      private string[] P00922_A248ParticipanteNome ;
      private bool[] P00922_n248ParticipanteNome ;
      private long[] P00922_A238AssinaturaId ;
      private bool[] P00922_n238AssinaturaId ;
      private int[] P00922_A242AssinaturaParticipanteId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class wclistaassinantesexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00922( IGxContext context ,
                                             string A247AssinaturaParticipanteTipo ,
                                             GxSimpleCollection<string> AV81Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ,
                                             string A353AssinaturaParticipanteStatus ,
                                             GxSimpleCollection<string> AV82Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ,
                                             string AV60Wclistaassinantesds_2_filterfulltext ,
                                             string AV61Wclistaassinantesds_3_dynamicfiltersselector1 ,
                                             string AV63Wclistaassinantesds_5_assinaturaparticipantestatus1 ,
                                             short AV62Wclistaassinantesds_4_dynamicfiltersoperator1 ,
                                             string AV64Wclistaassinantesds_6_participantedocumento1 ,
                                             bool AV65Wclistaassinantesds_7_dynamicfiltersenabled2 ,
                                             string AV66Wclistaassinantesds_8_dynamicfiltersselector2 ,
                                             string AV68Wclistaassinantesds_10_assinaturaparticipantestatus2 ,
                                             short AV67Wclistaassinantesds_9_dynamicfiltersoperator2 ,
                                             string AV69Wclistaassinantesds_11_participantedocumento2 ,
                                             bool AV70Wclistaassinantesds_12_dynamicfiltersenabled3 ,
                                             string AV71Wclistaassinantesds_13_dynamicfiltersselector3 ,
                                             string AV73Wclistaassinantesds_15_assinaturaparticipantestatus3 ,
                                             short AV72Wclistaassinantesds_14_dynamicfiltersoperator3 ,
                                             string AV74Wclistaassinantesds_16_participantedocumento3 ,
                                             string AV76Wclistaassinantesds_18_tfparticipantenome_sel ,
                                             string AV75Wclistaassinantesds_17_tfparticipantenome ,
                                             string AV78Wclistaassinantesds_20_tfparticipanteemail_sel ,
                                             string AV77Wclistaassinantesds_19_tfparticipanteemail ,
                                             string AV80Wclistaassinantesds_22_tfparticipantedocumento_sel ,
                                             string AV79Wclistaassinantesds_21_tfparticipantedocumento ,
                                             int AV81Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count ,
                                             int AV82Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count ,
                                             DateTime AV83Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ,
                                             DateTime AV84Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ,
                                             DateTime AV85Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ,
                                             DateTime AV86Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ,
                                             string A248ParticipanteNome ,
                                             string A235ParticipanteEmail ,
                                             string A234ParticipanteDocumento ,
                                             DateTime A244AssinaturaParticipanteDataVisualizacao ,
                                             DateTime A245AssinaturaParticipanteDataConclusao ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc ,
                                             long AV59Wclistaassinantesds_1_assinaturaid ,
                                             long A238AssinaturaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[30];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ParticipanteId, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteStatus, T1.AssinaturaParticipanteTipo, T2.ParticipanteDocumento, T2.ParticipanteEmail, T2.ParticipanteNome, T1.AssinaturaId, T1.AssinaturaParticipanteId FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV59Wclistaassinantesds_1_assinaturaid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Wclistaassinantesds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ParticipanteNome like '%' || :lV60Wclistaassinantesds_2_filterfulltext) or ( T2.ParticipanteEmail like '%' || :lV60Wclistaassinantesds_2_filterfulltext) or ( T2.ParticipanteDocumento like '%' || :lV60Wclistaassinantesds_2_filterfulltext) or ( 'contratada' like '%' || LOWER(:lV60Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Contratado')) or ( 'contratante' like '%' || LOWER(:lV60Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Contratante')) or ( 'testemunha' like '%' || LOWER(:lV60Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Testemunha')) or ( 'sacado' like '%' || LOWER(:lV60Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Sacado')) or ( 'pendente' like '%' || LOWER(:lV60Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Pendente')) or ( 'assinado' like '%' || LOWER(:lV60Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Assinado')) or ( 'recusado' like '%' || LOWER(:lV60Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Recusado')))");
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
         }
         if ( ( StringUtil.StrCmp(AV61Wclistaassinantesds_3_dynamicfiltersselector1, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Wclistaassinantesds_5_assinaturaparticipantestatus1)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV63Wclistaassinantesds_5_assinaturaparticipantestatus1))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Wclistaassinantesds_3_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV62Wclistaassinantesds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wclistaassinantesds_6_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV64Wclistaassinantesds_6_participantedocumento1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Wclistaassinantesds_3_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV62Wclistaassinantesds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Wclistaassinantesds_6_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV64Wclistaassinantesds_6_participantedocumento1)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV65Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Wclistaassinantesds_8_dynamicfiltersselector2, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wclistaassinantesds_10_assinaturaparticipantestatus2)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV68Wclistaassinantesds_10_assinaturaparticipantestatus2))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV65Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Wclistaassinantesds_8_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV67Wclistaassinantesds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wclistaassinantesds_11_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV69Wclistaassinantesds_11_participantedocumento2)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV65Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Wclistaassinantesds_8_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV67Wclistaassinantesds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wclistaassinantesds_11_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV69Wclistaassinantesds_11_participantedocumento2)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV70Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Wclistaassinantesds_13_dynamicfiltersselector3, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wclistaassinantesds_15_assinaturaparticipantestatus3)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV73Wclistaassinantesds_15_assinaturaparticipantestatus3))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV70Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Wclistaassinantesds_13_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV72Wclistaassinantesds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wclistaassinantesds_16_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV74Wclistaassinantesds_16_participantedocumento3)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV70Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Wclistaassinantesds_13_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV72Wclistaassinantesds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wclistaassinantesds_16_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV74Wclistaassinantesds_16_participantedocumento3)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Wclistaassinantesds_18_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wclistaassinantesds_17_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV75Wclistaassinantesds_17_tfparticipantenome)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Wclistaassinantesds_18_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV76Wclistaassinantesds_18_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV76Wclistaassinantesds_18_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV76Wclistaassinantesds_18_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Wclistaassinantesds_20_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Wclistaassinantesds_19_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail like :lV77Wclistaassinantesds_19_tfparticipanteemail)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wclistaassinantesds_20_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV78Wclistaassinantesds_20_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail = ( :AV78Wclistaassinantesds_20_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV78Wclistaassinantesds_20_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Wclistaassinantesds_22_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wclistaassinantesds_21_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV79Wclistaassinantesds_21_tfparticipantedocumento)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wclistaassinantesds_22_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV80Wclistaassinantesds_22_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento = ( :AV80Wclistaassinantesds_22_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( StringUtil.StrCmp(AV80Wclistaassinantesds_22_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteDocumento))=0))");
         }
         if ( AV81Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV81Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels, "T1.AssinaturaParticipanteTipo IN (", ")")+")");
         }
         if ( AV82Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV82Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels, "T1.AssinaturaParticipanteStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV83Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao >= :AV83Wclistaassinantesds_25_tfassinaturaparticipantedatavisualiz)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV84Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao <= :AV84Wclistaassinantesds_26_tfassinaturaparticipantedatavisualiz)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV85Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao >= :AV85Wclistaassinantesds_27_tfassinaturaparticipantedataconclusa)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ! (DateTime.MinValue==AV86Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao <= :AV86Wclistaassinantesds_28_tfassinaturaparticipantedataconclusa)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId, T1.AssinaturaParticipanteStatus";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId DESC, T1.AssinaturaParticipanteStatus DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId, T2.ParticipanteNome";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId DESC, T2.ParticipanteNome DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId, T2.ParticipanteEmail";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId DESC, T2.ParticipanteEmail DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId, T2.ParticipanteDocumento";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId DESC, T2.ParticipanteDocumento DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId, T1.AssinaturaParticipanteTipo";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId DESC, T1.AssinaturaParticipanteTipo DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId, T1.AssinaturaParticipanteDataVisualizacao";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId DESC, T1.AssinaturaParticipanteDataVisualizacao DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId, T1.AssinaturaParticipanteDataConclusao";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.AssinaturaId DESC, T1.AssinaturaParticipanteDataConclusao DESC";
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
                     return conditional_P00922(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (short)dynConstraints[36] , (bool)dynConstraints[37] , (long)dynConstraints[38] , (long)dynConstraints[39] );
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
          Object[] prmP00922;
          prmP00922 = new Object[] {
          new ParDef("AV59Wclistaassinantesds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("lV60Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV60Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV63Wclistaassinantesds_5_assinaturaparticipantestatus1",GXType.VarChar,40,0) ,
          new ParDef("lV64Wclistaassinantesds_6_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("lV64Wclistaassinantesds_6_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("AV68Wclistaassinantesds_10_assinaturaparticipantestatus2",GXType.VarChar,40,0) ,
          new ParDef("lV69Wclistaassinantesds_11_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("lV69Wclistaassinantesds_11_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("AV73Wclistaassinantesds_15_assinaturaparticipantestatus3",GXType.VarChar,40,0) ,
          new ParDef("lV74Wclistaassinantesds_16_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("lV74Wclistaassinantesds_16_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("lV75Wclistaassinantesds_17_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV76Wclistaassinantesds_18_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV77Wclistaassinantesds_19_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV78Wclistaassinantesds_20_tfparticipanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV79Wclistaassinantesds_21_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV80Wclistaassinantesds_22_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("AV83Wclistaassinantesds_25_tfassinaturaparticipantedatavisualiz",GXType.DateTime,10,8) ,
          new ParDef("AV84Wclistaassinantesds_26_tfassinaturaparticipantedatavisualiz",GXType.DateTime,10,8) ,
          new ParDef("AV85Wclistaassinantesds_27_tfassinaturaparticipantedataconclusa",GXType.DateTime,10,8) ,
          new ParDef("AV86Wclistaassinantesds_28_tfassinaturaparticipantedataconclusa",GXType.DateTime,10,8)
          };
          def= new CursorDef[] {
              new CursorDef("P00922", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00922,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
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
                ((long[]) buf[16])[0] = rslt.getLong(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                return;
       }
    }

 }

}
