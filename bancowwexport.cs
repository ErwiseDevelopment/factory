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
   public class bancowwexport : GXProcedure
   {
      public bancowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public bancowwexport( IGxContext context )
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
         AV11Filename = GXt_char1 + "BancoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV35TFBancoCodigo) && (0==AV36TFBancoCodigo_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV35TFBancoCodigo;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  false, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Até") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV36TFBancoCodigo_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFBancoNome_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Banco") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  (String.IsNullOrEmpty(StringUtil.RTrim( AV38TFBancoNome_Sel)) ? "(Vazio)" : AV38TFBancoNome_Sel), out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFBancoNome)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Banco") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFBancoNome, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Codigo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Banco";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV40Bancowwds_1_filterfulltext = AV18FilterFullText;
         AV41Bancowwds_2_tfbancocodigo = AV35TFBancoCodigo;
         AV42Bancowwds_3_tfbancocodigo_to = AV36TFBancoCodigo_To;
         AV43Bancowwds_4_tfbanconome = AV37TFBancoNome;
         AV44Bancowwds_5_tfbanconome_sel = AV38TFBancoNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV40Bancowwds_1_filterfulltext ,
                                              AV41Bancowwds_2_tfbancocodigo ,
                                              AV42Bancowwds_3_tfbancocodigo_to ,
                                              AV44Bancowwds_5_tfbanconome_sel ,
                                              AV43Bancowwds_4_tfbanconome ,
                                              A404BancoCodigo ,
                                              A403BancoNome ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV40Bancowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Bancowwds_1_filterfulltext), "%", "");
         lV40Bancowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV40Bancowwds_1_filterfulltext), "%", "");
         lV43Bancowwds_4_tfbanconome = StringUtil.Concat( StringUtil.RTrim( AV43Bancowwds_4_tfbanconome), "%", "");
         /* Using cursor P00D73 */
         pr_default.execute(0, new Object[] {lV40Bancowwds_1_filterfulltext, lV40Bancowwds_1_filterfulltext, AV41Bancowwds_2_tfbancocodigo, AV42Bancowwds_3_tfbancocodigo_to, lV43Bancowwds_4_tfbanconome, AV44Bancowwds_5_tfbanconome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A403BancoNome = P00D73_A403BancoNome[0];
            n403BancoNome = P00D73_n403BancoNome[0];
            A404BancoCodigo = P00D73_A404BancoCodigo[0];
            n404BancoCodigo = P00D73_n404BancoCodigo[0];
            A402BancoId = P00D73_A402BancoId[0];
            A946BancoCountAgencia_F = P00D73_A946BancoCountAgencia_F[0];
            n946BancoCountAgencia_F = P00D73_n946BancoCountAgencia_F[0];
            A946BancoCountAgencia_F = P00D73_A946BancoCountAgencia_F[0];
            n946BancoCountAgencia_F = P00D73_n946BancoCountAgencia_F[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A404BancoCodigo;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A403BancoNome, out  GXt_char1) ;
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
         AV31Session.Set("WWPExportFilePath", AV11Filename);
         AV31Session.Set("WWPExportFileName", "BancoWWExport.xlsx");
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
         if ( StringUtil.StrCmp(AV31Session.Get("BancoWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "BancoWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("BancoWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV45GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV18FilterFullText = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBANCOCODIGO") == 0 )
            {
               AV35TFBancoCodigo = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV36TFBancoCodigo_To = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBANCONOME") == 0 )
            {
               AV37TFBancoNome = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBANCONOME_SEL") == 0 )
            {
               AV38TFBancoNome_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            AV45GXV1 = (int)(AV45GXV1+1);
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
         AV38TFBancoNome_Sel = "";
         AV37TFBancoNome = "";
         AV40Bancowwds_1_filterfulltext = "";
         AV43Bancowwds_4_tfbanconome = "";
         AV44Bancowwds_5_tfbanconome_sel = "";
         lV40Bancowwds_1_filterfulltext = "";
         lV43Bancowwds_4_tfbanconome = "";
         A403BancoNome = "";
         P00D73_A403BancoNome = new string[] {""} ;
         P00D73_n403BancoNome = new bool[] {false} ;
         P00D73_A404BancoCodigo = new int[1] ;
         P00D73_n404BancoCodigo = new bool[] {false} ;
         P00D73_A402BancoId = new int[1] ;
         P00D73_A946BancoCountAgencia_F = new short[1] ;
         P00D73_n946BancoCountAgencia_F = new bool[] {false} ;
         GXt_char1 = "";
         AV31Session = context.GetSession();
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancowwexport__default(),
            new Object[][] {
                new Object[] {
               P00D73_A403BancoNome, P00D73_n403BancoNome, P00D73_A404BancoCodigo, P00D73_n404BancoCodigo, P00D73_A402BancoId, P00D73_A946BancoCountAgencia_F, P00D73_n946BancoCountAgencia_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXt_int2 ;
      private short AV16OrderedBy ;
      private short A946BancoCountAgencia_F ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV35TFBancoCodigo ;
      private int AV36TFBancoCodigo_To ;
      private int AV41Bancowwds_2_tfbancocodigo ;
      private int AV42Bancowwds_3_tfbancocodigo_to ;
      private int A404BancoCodigo ;
      private int A402BancoId ;
      private int AV45GXV1 ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV17OrderedDsc ;
      private bool n403BancoNome ;
      private bool n404BancoCodigo ;
      private bool n946BancoCountAgencia_F ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18FilterFullText ;
      private string AV38TFBancoNome_Sel ;
      private string AV37TFBancoNome ;
      private string AV40Bancowwds_1_filterfulltext ;
      private string AV43Bancowwds_4_tfbanconome ;
      private string AV44Bancowwds_5_tfbanconome_sel ;
      private string lV40Bancowwds_1_filterfulltext ;
      private string lV43Bancowwds_4_tfbanconome ;
      private string A403BancoNome ;
      private IGxSession AV31Session ;
      private ExcelDocumentI AV10ExcelDocument ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00D73_A403BancoNome ;
      private bool[] P00D73_n403BancoNome ;
      private int[] P00D73_A404BancoCodigo ;
      private bool[] P00D73_n404BancoCodigo ;
      private int[] P00D73_A402BancoId ;
      private short[] P00D73_A946BancoCountAgencia_F ;
      private bool[] P00D73_n946BancoCountAgencia_F ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
   }

   public class bancowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00D73( IGxContext context ,
                                             string AV40Bancowwds_1_filterfulltext ,
                                             int AV41Bancowwds_2_tfbancocodigo ,
                                             int AV42Bancowwds_3_tfbancocodigo_to ,
                                             string AV44Bancowwds_5_tfbanconome_sel ,
                                             string AV43Bancowwds_4_tfbanconome ,
                                             int A404BancoCodigo ,
                                             string A403BancoNome ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.BancoNome, T1.BancoCodigo, T1.BancoId, COALESCE( T2.BancoCountAgencia_F, 0) AS BancoCountAgencia_F FROM (Banco T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS BancoCountAgencia_F, AgenciaBancoId FROM Agencia WHERE T1.BancoId = AgenciaBancoId GROUP BY AgenciaBancoId ) T2 ON T2.AgenciaBancoId = T1.BancoId)";
         AddWhere(sWhereString, "(T1.BancoCodigo > 0)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Bancowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(T1.BancoCodigo,'999999999'), 2) like '%' || :lV40Bancowwds_1_filterfulltext) or ( LOWER(T1.BancoNome) like '%' || LOWER(:lV40Bancowwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV41Bancowwds_2_tfbancocodigo) )
         {
            AddWhere(sWhereString, "(T1.BancoCodigo >= :AV41Bancowwds_2_tfbancocodigo)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV42Bancowwds_3_tfbancocodigo_to) )
         {
            AddWhere(sWhereString, "(T1.BancoCodigo <= :AV42Bancowwds_3_tfbancocodigo_to)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44Bancowwds_5_tfbanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Bancowwds_4_tfbanconome)) ) )
         {
            AddWhere(sWhereString, "(T1.BancoNome like :lV43Bancowwds_4_tfbanconome)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Bancowwds_5_tfbanconome_sel)) && ! ( StringUtil.StrCmp(AV44Bancowwds_5_tfbanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.BancoNome = ( :AV44Bancowwds_5_tfbanconome_sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV44Bancowwds_5_tfbanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.BancoNome IS NULL or (char_length(trim(trailing ' ' from T1.BancoNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV16OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T2.BancoCountAgencia_F";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.BancoCodigo";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.BancoCodigo DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.BancoNome";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.BancoNome DESC";
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
                     return conditional_P00D73(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] );
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
          Object[] prmP00D73;
          prmP00D73 = new Object[] {
          new ParDef("lV40Bancowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV40Bancowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV41Bancowwds_2_tfbancocodigo",GXType.Int32,9,0) ,
          new ParDef("AV42Bancowwds_3_tfbancocodigo_to",GXType.Int32,9,0) ,
          new ParDef("lV43Bancowwds_4_tfbanconome",GXType.VarChar,150,0) ,
          new ParDef("AV44Bancowwds_5_tfbanconome_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D73", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D73,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
