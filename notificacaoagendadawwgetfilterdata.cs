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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class notificacaoagendadawwgetfilterdata : GXProcedure
   {
      public notificacaoagendadawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notificacaoagendadawwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV46OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28MaxItems = 10;
         AV27PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV42SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV25SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? "" : StringUtil.Substring( AV42SearchTxtParms, 3, -1));
         AV26SkipItems = (short)(AV27PageIndex*AV28MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_NOTIFICACAOAGENDADADESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTIFICACAOAGENDADADESCRICAOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV44OptionsJson = AV31Options.ToJSonString(false);
         AV45OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV46OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("NotificacaoAgendadaWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "NotificacaoAgendadaWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("NotificacaoAgendadaWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFNOTIFICACAOAGENDADAORIGEM_SEL") == 0 )
            {
               AV12TFNotificacaoAgendadaOrigem_SelsJson = AV39GridStateFilterValue.gxTpr_Value;
               AV13TFNotificacaoAgendadaOrigem_Sels.FromJSonString(AV12TFNotificacaoAgendadaOrigem_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFNOTIFICACAOAGENDADADESCRICAO") == 0 )
            {
               AV14TFNotificacaoAgendadaDescricao = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFNOTIFICACAOAGENDADADESCRICAO_SEL") == 0 )
            {
               AV15TFNotificacaoAgendadaDescricao_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFNOTIFICACAOAGENDADADIAS") == 0 )
            {
               AV16TFNotificacaoAgendadaDias = (int)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV17TFNotificacaoAgendadaDias_To = (int)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFNOTIFICACAOAGENDADAMOMENTOENVIO_SEL") == 0 )
            {
               AV18TFNotificacaoAgendadaMomentoEnvio_SelsJson = AV39GridStateFilterValue.gxTpr_Value;
               AV19TFNotificacaoAgendadaMomentoEnvio_Sels.FromJSonString(AV18TFNotificacaoAgendadaMomentoEnvio_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFNOTIFICACAOAGENDADATIPO_SEL") == 0 )
            {
               AV20TFNotificacaoAgendadaTipo_SelsJson = AV39GridStateFilterValue.gxTpr_Value;
               AV21TFNotificacaoAgendadaTipo_Sels.FromJSonString(AV20TFNotificacaoAgendadaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFNOTIFICACAOAGENDADASTATUS_SEL") == 0 )
            {
               AV24TFNotificacaoAgendadaStatus_Sel = (short)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADNOTIFICACAOAGENDADADESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV14TFNotificacaoAgendadaDescricao = AV25SearchTxt;
         AV15TFNotificacaoAgendadaDescricao_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A899NotificacaoAgendadaOrigem ,
                                              AV13TFNotificacaoAgendadaOrigem_Sels ,
                                              A902NotificacaoAgendadaMomentoEnvio ,
                                              AV19TFNotificacaoAgendadaMomentoEnvio_Sels ,
                                              A903NotificacaoAgendadaTipo ,
                                              AV21TFNotificacaoAgendadaTipo_Sels ,
                                              AV47FilterFullText ,
                                              AV13TFNotificacaoAgendadaOrigem_Sels.Count ,
                                              AV15TFNotificacaoAgendadaDescricao_Sel ,
                                              AV14TFNotificacaoAgendadaDescricao ,
                                              AV16TFNotificacaoAgendadaDias ,
                                              AV17TFNotificacaoAgendadaDias_To ,
                                              AV19TFNotificacaoAgendadaMomentoEnvio_Sels.Count ,
                                              AV21TFNotificacaoAgendadaTipo_Sels.Count ,
                                              AV24TFNotificacaoAgendadaStatus_Sel ,
                                              A900NotificacaoAgendadaDescricao ,
                                              A901NotificacaoAgendadaDias ,
                                              A905NotificacaoAgendadaStatus } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV47FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV47FilterFullText), "%", "");
         lV14TFNotificacaoAgendadaDescricao = StringUtil.Concat( StringUtil.RTrim( AV14TFNotificacaoAgendadaDescricao), "%", "");
         /* Using cursor P00EF2 */
         pr_default.execute(0, new Object[] {lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV47FilterFullText, lV14TFNotificacaoAgendadaDescricao, AV15TFNotificacaoAgendadaDescricao_Sel, AV16TFNotificacaoAgendadaDias, AV17TFNotificacaoAgendadaDias_To});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKEF2 = false;
            A900NotificacaoAgendadaDescricao = P00EF2_A900NotificacaoAgendadaDescricao[0];
            A905NotificacaoAgendadaStatus = P00EF2_A905NotificacaoAgendadaStatus[0];
            n905NotificacaoAgendadaStatus = P00EF2_n905NotificacaoAgendadaStatus[0];
            A903NotificacaoAgendadaTipo = P00EF2_A903NotificacaoAgendadaTipo[0];
            n903NotificacaoAgendadaTipo = P00EF2_n903NotificacaoAgendadaTipo[0];
            A902NotificacaoAgendadaMomentoEnvio = P00EF2_A902NotificacaoAgendadaMomentoEnvio[0];
            n902NotificacaoAgendadaMomentoEnvio = P00EF2_n902NotificacaoAgendadaMomentoEnvio[0];
            A901NotificacaoAgendadaDias = P00EF2_A901NotificacaoAgendadaDias[0];
            n901NotificacaoAgendadaDias = P00EF2_n901NotificacaoAgendadaDias[0];
            A899NotificacaoAgendadaOrigem = P00EF2_A899NotificacaoAgendadaOrigem[0];
            A898NotificacaoAgendadaId = P00EF2_A898NotificacaoAgendadaId[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00EF2_A900NotificacaoAgendadaDescricao[0], A900NotificacaoAgendadaDescricao) == 0 ) )
            {
               BRKEF2 = false;
               A898NotificacaoAgendadaId = P00EF2_A898NotificacaoAgendadaId[0];
               AV35count = (long)(AV35count+1);
               BRKEF2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A900NotificacaoAgendadaDescricao)) ? "<#Empty#>" : A900NotificacaoAgendadaDescricao);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRKEF2 )
            {
               BRKEF2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV44OptionsJson = "";
         AV45OptionsDescJson = "";
         AV46OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV33OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV25SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV36Session = context.GetSession();
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47FilterFullText = "";
         AV12TFNotificacaoAgendadaOrigem_SelsJson = "";
         AV13TFNotificacaoAgendadaOrigem_Sels = new GxSimpleCollection<string>();
         AV14TFNotificacaoAgendadaDescricao = "";
         AV15TFNotificacaoAgendadaDescricao_Sel = "";
         AV18TFNotificacaoAgendadaMomentoEnvio_SelsJson = "";
         AV19TFNotificacaoAgendadaMomentoEnvio_Sels = new GxSimpleCollection<string>();
         AV20TFNotificacaoAgendadaTipo_SelsJson = "";
         AV21TFNotificacaoAgendadaTipo_Sels = new GxSimpleCollection<string>();
         lV47FilterFullText = "";
         lV14TFNotificacaoAgendadaDescricao = "";
         A899NotificacaoAgendadaOrigem = "";
         A902NotificacaoAgendadaMomentoEnvio = "";
         A903NotificacaoAgendadaTipo = "";
         A900NotificacaoAgendadaDescricao = "";
         P00EF2_A900NotificacaoAgendadaDescricao = new string[] {""} ;
         P00EF2_A905NotificacaoAgendadaStatus = new bool[] {false} ;
         P00EF2_n905NotificacaoAgendadaStatus = new bool[] {false} ;
         P00EF2_A903NotificacaoAgendadaTipo = new string[] {""} ;
         P00EF2_n903NotificacaoAgendadaTipo = new bool[] {false} ;
         P00EF2_A902NotificacaoAgendadaMomentoEnvio = new string[] {""} ;
         P00EF2_n902NotificacaoAgendadaMomentoEnvio = new bool[] {false} ;
         P00EF2_A901NotificacaoAgendadaDias = new int[1] ;
         P00EF2_n901NotificacaoAgendadaDias = new bool[] {false} ;
         P00EF2_A899NotificacaoAgendadaOrigem = new string[] {""} ;
         P00EF2_A898NotificacaoAgendadaId = new int[1] ;
         AV30Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notificacaoagendadawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00EF2_A900NotificacaoAgendadaDescricao, P00EF2_A905NotificacaoAgendadaStatus, P00EF2_n905NotificacaoAgendadaStatus, P00EF2_A903NotificacaoAgendadaTipo, P00EF2_n903NotificacaoAgendadaTipo, P00EF2_A902NotificacaoAgendadaMomentoEnvio, P00EF2_n902NotificacaoAgendadaMomentoEnvio, P00EF2_A901NotificacaoAgendadaDias, P00EF2_n901NotificacaoAgendadaDias, P00EF2_A899NotificacaoAgendadaOrigem,
               P00EF2_A898NotificacaoAgendadaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short AV24TFNotificacaoAgendadaStatus_Sel ;
      private int AV48GXV1 ;
      private int AV16TFNotificacaoAgendadaDias ;
      private int AV17TFNotificacaoAgendadaDias_To ;
      private int AV13TFNotificacaoAgendadaOrigem_Sels_Count ;
      private int AV19TFNotificacaoAgendadaMomentoEnvio_Sels_Count ;
      private int AV21TFNotificacaoAgendadaTipo_Sels_Count ;
      private int A901NotificacaoAgendadaDias ;
      private int A898NotificacaoAgendadaId ;
      private long AV35count ;
      private bool returnInSub ;
      private bool A905NotificacaoAgendadaStatus ;
      private bool BRKEF2 ;
      private bool n905NotificacaoAgendadaStatus ;
      private bool n903NotificacaoAgendadaTipo ;
      private bool n902NotificacaoAgendadaMomentoEnvio ;
      private bool n901NotificacaoAgendadaDias ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV12TFNotificacaoAgendadaOrigem_SelsJson ;
      private string AV18TFNotificacaoAgendadaMomentoEnvio_SelsJson ;
      private string AV20TFNotificacaoAgendadaTipo_SelsJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV14TFNotificacaoAgendadaDescricao ;
      private string AV15TFNotificacaoAgendadaDescricao_Sel ;
      private string lV47FilterFullText ;
      private string lV14TFNotificacaoAgendadaDescricao ;
      private string A899NotificacaoAgendadaOrigem ;
      private string A902NotificacaoAgendadaMomentoEnvio ;
      private string A903NotificacaoAgendadaTipo ;
      private string A900NotificacaoAgendadaDescricao ;
      private string AV30Option ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GxSimpleCollection<string> AV13TFNotificacaoAgendadaOrigem_Sels ;
      private GxSimpleCollection<string> AV19TFNotificacaoAgendadaMomentoEnvio_Sels ;
      private GxSimpleCollection<string> AV21TFNotificacaoAgendadaTipo_Sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00EF2_A900NotificacaoAgendadaDescricao ;
      private bool[] P00EF2_A905NotificacaoAgendadaStatus ;
      private bool[] P00EF2_n905NotificacaoAgendadaStatus ;
      private string[] P00EF2_A903NotificacaoAgendadaTipo ;
      private bool[] P00EF2_n903NotificacaoAgendadaTipo ;
      private string[] P00EF2_A902NotificacaoAgendadaMomentoEnvio ;
      private bool[] P00EF2_n902NotificacaoAgendadaMomentoEnvio ;
      private int[] P00EF2_A901NotificacaoAgendadaDias ;
      private bool[] P00EF2_n901NotificacaoAgendadaDias ;
      private string[] P00EF2_A899NotificacaoAgendadaOrigem ;
      private int[] P00EF2_A898NotificacaoAgendadaId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class notificacaoagendadawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EF2( IGxContext context ,
                                             string A899NotificacaoAgendadaOrigem ,
                                             GxSimpleCollection<string> AV13TFNotificacaoAgendadaOrigem_Sels ,
                                             string A902NotificacaoAgendadaMomentoEnvio ,
                                             GxSimpleCollection<string> AV19TFNotificacaoAgendadaMomentoEnvio_Sels ,
                                             string A903NotificacaoAgendadaTipo ,
                                             GxSimpleCollection<string> AV21TFNotificacaoAgendadaTipo_Sels ,
                                             string AV47FilterFullText ,
                                             int AV13TFNotificacaoAgendadaOrigem_Sels_Count ,
                                             string AV15TFNotificacaoAgendadaDescricao_Sel ,
                                             string AV14TFNotificacaoAgendadaDescricao ,
                                             int AV16TFNotificacaoAgendadaDias ,
                                             int AV17TFNotificacaoAgendadaDias_To ,
                                             int AV19TFNotificacaoAgendadaMomentoEnvio_Sels_Count ,
                                             int AV21TFNotificacaoAgendadaTipo_Sels_Count ,
                                             short AV24TFNotificacaoAgendadaStatus_Sel ,
                                             string A900NotificacaoAgendadaDescricao ,
                                             int A901NotificacaoAgendadaDias ,
                                             bool A905NotificacaoAgendadaStatus )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT NotificacaoAgendadaDescricao, NotificacaoAgendadaStatus, NotificacaoAgendadaTipo, NotificacaoAgendadaMomentoEnvio, NotificacaoAgendadaDias, NotificacaoAgendadaOrigem, NotificacaoAgendadaId FROM NotificacaoAgendada";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47FilterFullText)) )
         {
            AddWhere(sWhereString, "(( 'título a receber' like '%' || LOWER(:lV47FilterFullText) and NotificacaoAgendadaOrigem = ( 'R')) or ( NotificacaoAgendadaDescricao like '%' || :lV47FilterFullText) or ( SUBSTR(TO_CHAR(NotificacaoAgendadaDias,'999999999'), 2) like '%' || :lV47FilterFullText) or ( 'antes' like '%' || LOWER(:lV47FilterFullText) and NotificacaoAgendadaMomentoEnvio = ( 'A')) or ( 'depois' like '%' || LOWER(:lV47FilterFullText) and NotificacaoAgendadaMomentoEnvio = ( 'D')) or ( 'email' like '%' || LOWER(:lV47FilterFullText) and NotificacaoAgendadaTipo = ( 'E')) or ( 'sim' like '%' || LOWER(:lV47FilterFullText) and NotificacaoAgendadaStatus = TRUE) or ( 'não' like '%' || LOWER(:lV47FilterFullText) and NotificacaoAgendadaStatus = FALSE))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
         }
         if ( AV13TFNotificacaoAgendadaOrigem_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV13TFNotificacaoAgendadaOrigem_Sels, "NotificacaoAgendadaOrigem IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotificacaoAgendadaDescricao_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNotificacaoAgendadaDescricao)) ) )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaDescricao like :lV14TFNotificacaoAgendadaDescricao)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotificacaoAgendadaDescricao_Sel)) && ! ( StringUtil.StrCmp(AV15TFNotificacaoAgendadaDescricao_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaDescricao = ( :AV15TFNotificacaoAgendadaDescricao_Sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV15TFNotificacaoAgendadaDescricao_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from NotificacaoAgendadaDescricao))=0))");
         }
         if ( ! (0==AV16TFNotificacaoAgendadaDias) )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaDias >= :AV16TFNotificacaoAgendadaDias)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (0==AV17TFNotificacaoAgendadaDias_To) )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaDias <= :AV17TFNotificacaoAgendadaDias_To)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV19TFNotificacaoAgendadaMomentoEnvio_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV19TFNotificacaoAgendadaMomentoEnvio_Sels, "NotificacaoAgendadaMomentoEnvio IN (", ")")+")");
         }
         if ( AV21TFNotificacaoAgendadaTipo_Sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV21TFNotificacaoAgendadaTipo_Sels, "NotificacaoAgendadaTipo IN (", ")")+")");
         }
         if ( AV24TFNotificacaoAgendadaStatus_Sel == 1 )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaStatus = TRUE)");
         }
         if ( AV24TFNotificacaoAgendadaStatus_Sel == 2 )
         {
            AddWhere(sWhereString, "(NotificacaoAgendadaStatus = FALSE)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY NotificacaoAgendadaDescricao";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00EF2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (bool)dynConstraints[17] );
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
          Object[] prmP00EF2;
          prmP00EF2 = new Object[] {
          new ParDef("lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV47FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV14TFNotificacaoAgendadaDescricao",GXType.VarChar,120,0) ,
          new ParDef("AV15TFNotificacaoAgendadaDescricao_Sel",GXType.VarChar,120,0) ,
          new ParDef("AV16TFNotificacaoAgendadaDias",GXType.Int32,9,0) ,
          new ParDef("AV17TFNotificacaoAgendadaDias_To",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EF2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EF2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((int[]) buf[10])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
