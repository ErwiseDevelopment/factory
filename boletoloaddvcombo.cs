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
   public class boletoloaddvcombo : GXProcedure
   {
      public boletoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public boletoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_BoletosId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19BoletosId = aP3_BoletosId;
         this.AV20SearchTxtParms = aP4_SearchTxtParms;
         this.AV21SelectedValue = "" ;
         this.AV22SelectedText = "" ;
         this.AV23Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP5_SelectedValue=this.AV21SelectedValue;
         aP6_SelectedText=this.AV22SelectedText;
         aP7_Combo_DataJson=this.AV23Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                int aP3_BoletosId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_BoletosId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_BoletosId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19BoletosId = aP3_BoletosId;
         this.AV20SearchTxtParms = aP4_SearchTxtParms;
         this.AV21SelectedValue = "" ;
         this.AV22SelectedText = "" ;
         this.AV23Combo_DataJson = "" ;
         SubmitImpl();
         aP5_SelectedValue=this.AV21SelectedValue;
         aP6_SelectedText=this.AV22SelectedText;
         aP7_Combo_DataJson=this.AV23Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10MaxItems = 10;
         AV12PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV20SearchTxtParms))||StringUtil.StartsWith( AV17TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV20SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV13SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV20SearchTxtParms))||StringUtil.StartsWith( AV17TrnMode, "GET") ? AV20SearchTxtParms : StringUtil.Substring( AV20SearchTxtParms, 3, -1));
         AV11SkipItems = (short)(AV12PageIndex*AV10MaxItems);
         if ( StringUtil.StrCmp(AV16ComboName, "CarteiraDeCobrancaId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CARTEIRADECOBRANCAID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "TituloId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_TITULOID' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_CARTEIRADECOBRANCAID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A1070CarteiraDeCobrancaCodigo } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00FE2 */
            pr_default.execute(0, new Object[] {lV13SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1070CarteiraDeCobrancaCodigo = P00FE2_A1070CarteiraDeCobrancaCodigo[0];
               n1070CarteiraDeCobrancaCodigo = P00FE2_n1070CarteiraDeCobrancaCodigo[0];
               A1069CarteiraDeCobrancaId = P00FE2_A1069CarteiraDeCobrancaId[0];
               n1069CarteiraDeCobrancaId = P00FE2_n1069CarteiraDeCobrancaId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A1069CarteiraDeCobrancaId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = A1070CarteiraDeCobrancaCodigo;
               AV14Combo_Data.Add(AV15Combo_DataItem, 0);
               if ( AV14Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV23Combo_DataJson = AV14Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV17TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV17TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00FE3 */
                  pr_default.execute(1, new Object[] {AV19BoletosId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A1077BoletosId = P00FE3_A1077BoletosId[0];
                     A1069CarteiraDeCobrancaId = P00FE3_A1069CarteiraDeCobrancaId[0];
                     n1069CarteiraDeCobrancaId = P00FE3_n1069CarteiraDeCobrancaId[0];
                     A1070CarteiraDeCobrancaCodigo = P00FE3_A1070CarteiraDeCobrancaCodigo[0];
                     n1070CarteiraDeCobrancaCodigo = P00FE3_n1070CarteiraDeCobrancaCodigo[0];
                     A1070CarteiraDeCobrancaCodigo = P00FE3_A1070CarteiraDeCobrancaCodigo[0];
                     n1070CarteiraDeCobrancaCodigo = P00FE3_n1070CarteiraDeCobrancaCodigo[0];
                     AV21SelectedValue = ((0==A1069CarteiraDeCobrancaId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A1069CarteiraDeCobrancaId), 9, 0)));
                     AV22SelectedText = A1070CarteiraDeCobrancaCodigo;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P00FE4 */
                  pr_default.execute(2, new Object[] {AV27CarteiraDeCobrancaId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A1069CarteiraDeCobrancaId = P00FE4_A1069CarteiraDeCobrancaId[0];
                     n1069CarteiraDeCobrancaId = P00FE4_n1069CarteiraDeCobrancaId[0];
                     A1070CarteiraDeCobrancaCodigo = P00FE4_A1070CarteiraDeCobrancaCodigo[0];
                     n1070CarteiraDeCobrancaCodigo = P00FE4_n1070CarteiraDeCobrancaCodigo[0];
                     AV22SelectedText = A1070CarteiraDeCobrancaCodigo;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_TITULOID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom5 = AV11SkipItems;
            GXPagingTo5 = AV10MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A972TituloCLienteRazaoSocial } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00FE5 */
            pr_default.execute(3, new Object[] {lV13SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A420TituloClienteId = P00FE5_A420TituloClienteId[0];
               n420TituloClienteId = P00FE5_n420TituloClienteId[0];
               A972TituloCLienteRazaoSocial = P00FE5_A972TituloCLienteRazaoSocial[0];
               n972TituloCLienteRazaoSocial = P00FE5_n972TituloCLienteRazaoSocial[0];
               A261TituloId = P00FE5_A261TituloId[0];
               n261TituloId = P00FE5_n261TituloId[0];
               A972TituloCLienteRazaoSocial = P00FE5_A972TituloCLienteRazaoSocial[0];
               n972TituloCLienteRazaoSocial = P00FE5_n972TituloCLienteRazaoSocial[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A261TituloId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = A972TituloCLienteRazaoSocial;
               AV14Combo_Data.Add(AV15Combo_DataItem, 0);
               if ( AV14Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV23Combo_DataJson = AV14Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV17TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV17TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00FE6 */
                  pr_default.execute(4, new Object[] {AV19BoletosId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A420TituloClienteId = P00FE6_A420TituloClienteId[0];
                     n420TituloClienteId = P00FE6_n420TituloClienteId[0];
                     A1077BoletosId = P00FE6_A1077BoletosId[0];
                     A261TituloId = P00FE6_A261TituloId[0];
                     n261TituloId = P00FE6_n261TituloId[0];
                     A972TituloCLienteRazaoSocial = P00FE6_A972TituloCLienteRazaoSocial[0];
                     n972TituloCLienteRazaoSocial = P00FE6_n972TituloCLienteRazaoSocial[0];
                     A420TituloClienteId = P00FE6_A420TituloClienteId[0];
                     n420TituloClienteId = P00FE6_n420TituloClienteId[0];
                     A972TituloCLienteRazaoSocial = P00FE6_A972TituloCLienteRazaoSocial[0];
                     n972TituloCLienteRazaoSocial = P00FE6_n972TituloCLienteRazaoSocial[0];
                     AV21SelectedValue = ((0==A261TituloId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A261TituloId), 9, 0)));
                     AV22SelectedText = A972TituloCLienteRazaoSocial;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV28TituloId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P00FE7 */
                  pr_default.execute(5, new Object[] {AV28TituloId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A420TituloClienteId = P00FE7_A420TituloClienteId[0];
                     n420TituloClienteId = P00FE7_n420TituloClienteId[0];
                     A261TituloId = P00FE7_A261TituloId[0];
                     n261TituloId = P00FE7_n261TituloId[0];
                     A972TituloCLienteRazaoSocial = P00FE7_A972TituloCLienteRazaoSocial[0];
                     n972TituloCLienteRazaoSocial = P00FE7_n972TituloCLienteRazaoSocial[0];
                     A972TituloCLienteRazaoSocial = P00FE7_A972TituloCLienteRazaoSocial[0];
                     n972TituloCLienteRazaoSocial = P00FE7_n972TituloCLienteRazaoSocial[0];
                     AV22SelectedText = A972TituloCLienteRazaoSocial;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(5);
               }
            }
         }
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
         AV21SelectedValue = "";
         AV22SelectedText = "";
         AV23Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13SearchTxt = "";
         lV13SearchTxt = "";
         A1070CarteiraDeCobrancaCodigo = "";
         P00FE2_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         P00FE2_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         P00FE2_A1069CarteiraDeCobrancaId = new int[1] ;
         P00FE2_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00FE3_A1077BoletosId = new int[1] ;
         P00FE3_A1069CarteiraDeCobrancaId = new int[1] ;
         P00FE3_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         P00FE3_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         P00FE3_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         P00FE4_A1069CarteiraDeCobrancaId = new int[1] ;
         P00FE4_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         P00FE4_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         P00FE4_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         A972TituloCLienteRazaoSocial = "";
         P00FE5_A420TituloClienteId = new int[1] ;
         P00FE5_n420TituloClienteId = new bool[] {false} ;
         P00FE5_A972TituloCLienteRazaoSocial = new string[] {""} ;
         P00FE5_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         P00FE5_A261TituloId = new int[1] ;
         P00FE5_n261TituloId = new bool[] {false} ;
         P00FE6_A420TituloClienteId = new int[1] ;
         P00FE6_n420TituloClienteId = new bool[] {false} ;
         P00FE6_A1077BoletosId = new int[1] ;
         P00FE6_A261TituloId = new int[1] ;
         P00FE6_n261TituloId = new bool[] {false} ;
         P00FE6_A972TituloCLienteRazaoSocial = new string[] {""} ;
         P00FE6_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         P00FE7_A420TituloClienteId = new int[1] ;
         P00FE7_n420TituloClienteId = new bool[] {false} ;
         P00FE7_A261TituloId = new int[1] ;
         P00FE7_n261TituloId = new bool[] {false} ;
         P00FE7_A972TituloCLienteRazaoSocial = new string[] {""} ;
         P00FE7_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.boletoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00FE2_A1070CarteiraDeCobrancaCodigo, P00FE2_n1070CarteiraDeCobrancaCodigo, P00FE2_A1069CarteiraDeCobrancaId
               }
               , new Object[] {
               P00FE3_A1077BoletosId, P00FE3_A1069CarteiraDeCobrancaId, P00FE3_n1069CarteiraDeCobrancaId, P00FE3_A1070CarteiraDeCobrancaCodigo, P00FE3_n1070CarteiraDeCobrancaCodigo
               }
               , new Object[] {
               P00FE4_A1069CarteiraDeCobrancaId, P00FE4_A1070CarteiraDeCobrancaCodigo, P00FE4_n1070CarteiraDeCobrancaCodigo
               }
               , new Object[] {
               P00FE5_A420TituloClienteId, P00FE5_n420TituloClienteId, P00FE5_A972TituloCLienteRazaoSocial, P00FE5_n972TituloCLienteRazaoSocial, P00FE5_A261TituloId
               }
               , new Object[] {
               P00FE6_A420TituloClienteId, P00FE6_n420TituloClienteId, P00FE6_A1077BoletosId, P00FE6_A261TituloId, P00FE6_n261TituloId, P00FE6_A972TituloCLienteRazaoSocial, P00FE6_n972TituloCLienteRazaoSocial
               }
               , new Object[] {
               P00FE7_A420TituloClienteId, P00FE7_n420TituloClienteId, P00FE7_A261TituloId, P00FE7_A972TituloCLienteRazaoSocial, P00FE7_n972TituloCLienteRazaoSocial
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private int AV19BoletosId ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A1069CarteiraDeCobrancaId ;
      private int A1077BoletosId ;
      private int AV27CarteiraDeCobrancaId ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int A420TituloClienteId ;
      private int A261TituloId ;
      private int AV28TituloId ;
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private bool n1070CarteiraDeCobrancaCodigo ;
      private bool n1069CarteiraDeCobrancaId ;
      private bool n420TituloClienteId ;
      private bool n972TituloCLienteRazaoSocial ;
      private bool n261TituloId ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private string A1070CarteiraDeCobrancaCodigo ;
      private string A972TituloCLienteRazaoSocial ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00FE2_A1070CarteiraDeCobrancaCodigo ;
      private bool[] P00FE2_n1070CarteiraDeCobrancaCodigo ;
      private int[] P00FE2_A1069CarteiraDeCobrancaId ;
      private bool[] P00FE2_n1069CarteiraDeCobrancaId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private int[] P00FE3_A1077BoletosId ;
      private int[] P00FE3_A1069CarteiraDeCobrancaId ;
      private bool[] P00FE3_n1069CarteiraDeCobrancaId ;
      private string[] P00FE3_A1070CarteiraDeCobrancaCodigo ;
      private bool[] P00FE3_n1070CarteiraDeCobrancaCodigo ;
      private int[] P00FE4_A1069CarteiraDeCobrancaId ;
      private bool[] P00FE4_n1069CarteiraDeCobrancaId ;
      private string[] P00FE4_A1070CarteiraDeCobrancaCodigo ;
      private bool[] P00FE4_n1070CarteiraDeCobrancaCodigo ;
      private int[] P00FE5_A420TituloClienteId ;
      private bool[] P00FE5_n420TituloClienteId ;
      private string[] P00FE5_A972TituloCLienteRazaoSocial ;
      private bool[] P00FE5_n972TituloCLienteRazaoSocial ;
      private int[] P00FE5_A261TituloId ;
      private bool[] P00FE5_n261TituloId ;
      private int[] P00FE6_A420TituloClienteId ;
      private bool[] P00FE6_n420TituloClienteId ;
      private int[] P00FE6_A1077BoletosId ;
      private int[] P00FE6_A261TituloId ;
      private bool[] P00FE6_n261TituloId ;
      private string[] P00FE6_A972TituloCLienteRazaoSocial ;
      private bool[] P00FE6_n972TituloCLienteRazaoSocial ;
      private int[] P00FE7_A420TituloClienteId ;
      private bool[] P00FE7_n420TituloClienteId ;
      private int[] P00FE7_A261TituloId ;
      private bool[] P00FE7_n261TituloId ;
      private string[] P00FE7_A972TituloCLienteRazaoSocial ;
      private bool[] P00FE7_n972TituloCLienteRazaoSocial ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class boletoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FE2( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A1070CarteiraDeCobrancaCodigo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " CarteiraDeCobrancaCodigo, CarteiraDeCobrancaId";
         sFromString = " FROM CarteiraDeCobranca";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(CarteiraDeCobrancaCodigo like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY CarteiraDeCobrancaCodigo, CarteiraDeCobrancaId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00FE5( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A972TituloCLienteRazaoSocial )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.TituloClienteId AS TituloClienteId, T2.ClienteRazaoSocial AS TituloCLienteRazaoSocial, T1.TituloId";
         sFromString = " FROM (Titulo T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.TituloClienteId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY T2.ClienteRazaoSocial, T1.TituloId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom5" + " LIMIT CASE WHEN " + ":GXPagingTo5" + " > 0 THEN " + ":GXPagingTo5" + " ELSE 1e9 END";
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
                     return conditional_P00FE2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P00FE5(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00FE3;
          prmP00FE3 = new Object[] {
          new ParDef("AV19BoletosId",GXType.Int32,9,0)
          };
          Object[] prmP00FE4;
          prmP00FE4 = new Object[] {
          new ParDef("AV27CarteiraDeCobrancaId",GXType.Int32,9,0)
          };
          Object[] prmP00FE6;
          prmP00FE6 = new Object[] {
          new ParDef("AV19BoletosId",GXType.Int32,9,0)
          };
          Object[] prmP00FE7;
          prmP00FE7 = new Object[] {
          new ParDef("AV28TituloId",GXType.Int32,9,0)
          };
          Object[] prmP00FE2;
          prmP00FE2 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00FE5;
          prmP00FE5 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FE2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FE2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FE3", "SELECT T1.BoletosId, T1.CarteiraDeCobrancaId, T2.CarteiraDeCobrancaCodigo FROM (Boleto T1 LEFT JOIN CarteiraDeCobranca T2 ON T2.CarteiraDeCobrancaId = T1.CarteiraDeCobrancaId) WHERE T1.BoletosId = :AV19BoletosId ORDER BY T1.BoletosId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FE3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FE4", "SELECT CarteiraDeCobrancaId, CarteiraDeCobrancaCodigo FROM CarteiraDeCobranca WHERE CarteiraDeCobrancaId = :AV27CarteiraDeCobrancaId ORDER BY CarteiraDeCobrancaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FE4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FE5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FE5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FE6", "SELECT T2.TituloClienteId AS TituloClienteId, T1.BoletosId, T1.TituloId, T3.ClienteRazaoSocial AS TituloCLienteRazaoSocial FROM ((Boleto T1 LEFT JOIN Titulo T2 ON T2.TituloId = T1.TituloId) LEFT JOIN Cliente T3 ON T3.ClienteId = T2.TituloClienteId) WHERE T1.BoletosId = :AV19BoletosId ORDER BY T1.BoletosId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FE6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FE7", "SELECT T1.TituloClienteId AS TituloClienteId, T1.TituloId, T2.ClienteRazaoSocial AS TituloCLienteRazaoSocial FROM (Titulo T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.TituloClienteId) WHERE T1.TituloId = :AV28TituloId ORDER BY T1.TituloId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FE7,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
