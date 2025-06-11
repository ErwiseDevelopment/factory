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
   public class representanteloaddvcombo : GXProcedure
   {
      public representanteloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public representanteloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_RepresentanteId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19RepresentanteId = aP3_RepresentanteId;
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
                                int aP3_RepresentanteId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_RepresentanteId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_RepresentanteId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19RepresentanteId = aP3_RepresentanteId;
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
         if ( StringUtil.StrCmp(AV16ComboName, "RepresentanteProfissao") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_REPRESENTANTEPROFISSAO' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "RepresentanteMunicipio") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_REPRESENTANTEMUNICIPIO' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "ClienteId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CLIENTEID' */
            S131 ();
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
         /* 'LOADCOMBOITEMS_REPRESENTANTEPROFISSAO' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A441ProfissaoNome } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00F02 */
            pr_default.execute(0, new Object[] {lV13SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A441ProfissaoNome = P00F02_A441ProfissaoNome[0];
               n441ProfissaoNome = P00F02_n441ProfissaoNome[0];
               A440ProfissaoId = P00F02_A440ProfissaoId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A440ProfissaoId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = A441ProfissaoNome;
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
                  /* Using cursor P00F03 */
                  pr_default.execute(1, new Object[] {AV19RepresentanteId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A978RepresentanteId = P00F03_A978RepresentanteId[0];
                     A977RepresentanteProfissao = P00F03_A977RepresentanteProfissao[0];
                     n977RepresentanteProfissao = P00F03_n977RepresentanteProfissao[0];
                     AV21SelectedValue = ((0==A977RepresentanteProfissao) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A977RepresentanteProfissao), 9, 0)));
                     AV27ProfissaoId = A977RepresentanteProfissao;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27ProfissaoId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
               }
               /* Using cursor P00F04 */
               pr_default.execute(2, new Object[] {AV27ProfissaoId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A440ProfissaoId = P00F04_A440ProfissaoId[0];
                  A441ProfissaoNome = P00F04_A441ProfissaoNome[0];
                  n441ProfissaoNome = P00F04_n441ProfissaoNome[0];
                  AV22SelectedText = A441ProfissaoNome;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_REPRESENTANTEMUNICIPIO' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom5 = AV11SkipItems;
            GXPagingTo5 = AV10MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A187MunicipioNome } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00F05 */
            pr_default.execute(3, new Object[] {lV13SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A187MunicipioNome = P00F05_A187MunicipioNome[0];
               n187MunicipioNome = P00F05_n187MunicipioNome[0];
               A186MunicipioCodigo = P00F05_A186MunicipioCodigo[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = A186MunicipioCodigo;
               AV15Combo_DataItem.gxTpr_Title = A187MunicipioNome;
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
                  /* Using cursor P00F06 */
                  pr_default.execute(4, new Object[] {AV19RepresentanteId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A978RepresentanteId = P00F06_A978RepresentanteId[0];
                     A991RepresentanteMunicipio = P00F06_A991RepresentanteMunicipio[0];
                     n991RepresentanteMunicipio = P00F06_n991RepresentanteMunicipio[0];
                     AV21SelectedValue = A991RepresentanteMunicipio;
                     AV28MunicipioCodigo = A991RepresentanteMunicipio;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV28MunicipioCodigo = AV13SearchTxt;
               }
               /* Using cursor P00F07 */
               pr_default.execute(5, new Object[] {AV28MunicipioCodigo});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A186MunicipioCodigo = P00F07_A186MunicipioCodigo[0];
                  A187MunicipioNome = P00F07_A187MunicipioNome[0];
                  n187MunicipioNome = P00F07_n187MunicipioNome[0];
                  AV22SelectedText = A187MunicipioNome;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(5);
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_CLIENTEID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom8 = AV11SkipItems;
            GXPagingTo8 = AV10MaxItems;
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A169ClienteDocumento } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00F08 */
            pr_default.execute(6, new Object[] {lV13SearchTxt, GXPagingFrom8, GXPagingTo8, GXPagingTo8});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A169ClienteDocumento = P00F08_A169ClienteDocumento[0];
               n169ClienteDocumento = P00F08_n169ClienteDocumento[0];
               A168ClienteId = P00F08_A168ClienteId[0];
               n168ClienteId = P00F08_n168ClienteId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A168ClienteId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = A169ClienteDocumento;
               AV14Combo_Data.Add(AV15Combo_DataItem, 0);
               if ( AV14Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(6);
            }
            pr_default.close(6);
            AV23Combo_DataJson = AV14Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV17TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV17TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00F09 */
                  pr_default.execute(7, new Object[] {AV19RepresentanteId});
                  while ( (pr_default.getStatus(7) != 101) )
                  {
                     A978RepresentanteId = P00F09_A978RepresentanteId[0];
                     A168ClienteId = P00F09_A168ClienteId[0];
                     n168ClienteId = P00F09_n168ClienteId[0];
                     A169ClienteDocumento = P00F09_A169ClienteDocumento[0];
                     n169ClienteDocumento = P00F09_n169ClienteDocumento[0];
                     A169ClienteDocumento = P00F09_A169ClienteDocumento[0];
                     n169ClienteDocumento = P00F09_n169ClienteDocumento[0];
                     AV21SelectedValue = ((0==A168ClienteId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A168ClienteId), 9, 0)));
                     AV22SelectedText = A169ClienteDocumento;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(7);
               }
               else
               {
                  AV29ClienteId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P00F010 */
                  pr_default.execute(8, new Object[] {AV29ClienteId});
                  while ( (pr_default.getStatus(8) != 101) )
                  {
                     A168ClienteId = P00F010_A168ClienteId[0];
                     n168ClienteId = P00F010_n168ClienteId[0];
                     A169ClienteDocumento = P00F010_A169ClienteDocumento[0];
                     n169ClienteDocumento = P00F010_n169ClienteDocumento[0];
                     AV22SelectedText = A169ClienteDocumento;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(8);
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
         A441ProfissaoNome = "";
         P00F02_A441ProfissaoNome = new string[] {""} ;
         P00F02_n441ProfissaoNome = new bool[] {false} ;
         P00F02_A440ProfissaoId = new int[1] ;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00F03_A978RepresentanteId = new int[1] ;
         P00F03_A977RepresentanteProfissao = new int[1] ;
         P00F03_n977RepresentanteProfissao = new bool[] {false} ;
         P00F04_A440ProfissaoId = new int[1] ;
         P00F04_A441ProfissaoNome = new string[] {""} ;
         P00F04_n441ProfissaoNome = new bool[] {false} ;
         A187MunicipioNome = "";
         P00F05_A187MunicipioNome = new string[] {""} ;
         P00F05_n187MunicipioNome = new bool[] {false} ;
         P00F05_A186MunicipioCodigo = new string[] {""} ;
         A186MunicipioCodigo = "";
         P00F06_A978RepresentanteId = new int[1] ;
         P00F06_A991RepresentanteMunicipio = new string[] {""} ;
         P00F06_n991RepresentanteMunicipio = new bool[] {false} ;
         A991RepresentanteMunicipio = "";
         AV28MunicipioCodigo = "";
         P00F07_A186MunicipioCodigo = new string[] {""} ;
         P00F07_A187MunicipioNome = new string[] {""} ;
         P00F07_n187MunicipioNome = new bool[] {false} ;
         A169ClienteDocumento = "";
         P00F08_A169ClienteDocumento = new string[] {""} ;
         P00F08_n169ClienteDocumento = new bool[] {false} ;
         P00F08_A168ClienteId = new int[1] ;
         P00F08_n168ClienteId = new bool[] {false} ;
         P00F09_A978RepresentanteId = new int[1] ;
         P00F09_A168ClienteId = new int[1] ;
         P00F09_n168ClienteId = new bool[] {false} ;
         P00F09_A169ClienteDocumento = new string[] {""} ;
         P00F09_n169ClienteDocumento = new bool[] {false} ;
         P00F010_A168ClienteId = new int[1] ;
         P00F010_n168ClienteId = new bool[] {false} ;
         P00F010_A169ClienteDocumento = new string[] {""} ;
         P00F010_n169ClienteDocumento = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.representanteloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00F02_A441ProfissaoNome, P00F02_n441ProfissaoNome, P00F02_A440ProfissaoId
               }
               , new Object[] {
               P00F03_A978RepresentanteId, P00F03_A977RepresentanteProfissao, P00F03_n977RepresentanteProfissao
               }
               , new Object[] {
               P00F04_A440ProfissaoId, P00F04_A441ProfissaoNome, P00F04_n441ProfissaoNome
               }
               , new Object[] {
               P00F05_A187MunicipioNome, P00F05_n187MunicipioNome, P00F05_A186MunicipioCodigo
               }
               , new Object[] {
               P00F06_A978RepresentanteId, P00F06_A991RepresentanteMunicipio, P00F06_n991RepresentanteMunicipio
               }
               , new Object[] {
               P00F07_A186MunicipioCodigo, P00F07_A187MunicipioNome, P00F07_n187MunicipioNome
               }
               , new Object[] {
               P00F08_A169ClienteDocumento, P00F08_n169ClienteDocumento, P00F08_A168ClienteId
               }
               , new Object[] {
               P00F09_A978RepresentanteId, P00F09_A168ClienteId, P00F09_n168ClienteId, P00F09_A169ClienteDocumento, P00F09_n169ClienteDocumento
               }
               , new Object[] {
               P00F010_A168ClienteId, P00F010_A169ClienteDocumento, P00F010_n169ClienteDocumento
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private int AV19RepresentanteId ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A440ProfissaoId ;
      private int A978RepresentanteId ;
      private int A977RepresentanteProfissao ;
      private int AV27ProfissaoId ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int GXPagingFrom8 ;
      private int GXPagingTo8 ;
      private int A168ClienteId ;
      private int AV29ClienteId ;
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private bool n441ProfissaoNome ;
      private bool n977RepresentanteProfissao ;
      private bool n187MunicipioNome ;
      private bool n991RepresentanteMunicipio ;
      private bool n169ClienteDocumento ;
      private bool n168ClienteId ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private string A441ProfissaoNome ;
      private string A187MunicipioNome ;
      private string A186MunicipioCodigo ;
      private string A991RepresentanteMunicipio ;
      private string AV28MunicipioCodigo ;
      private string A169ClienteDocumento ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00F02_A441ProfissaoNome ;
      private bool[] P00F02_n441ProfissaoNome ;
      private int[] P00F02_A440ProfissaoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private int[] P00F03_A978RepresentanteId ;
      private int[] P00F03_A977RepresentanteProfissao ;
      private bool[] P00F03_n977RepresentanteProfissao ;
      private int[] P00F04_A440ProfissaoId ;
      private string[] P00F04_A441ProfissaoNome ;
      private bool[] P00F04_n441ProfissaoNome ;
      private string[] P00F05_A187MunicipioNome ;
      private bool[] P00F05_n187MunicipioNome ;
      private string[] P00F05_A186MunicipioCodigo ;
      private int[] P00F06_A978RepresentanteId ;
      private string[] P00F06_A991RepresentanteMunicipio ;
      private bool[] P00F06_n991RepresentanteMunicipio ;
      private string[] P00F07_A186MunicipioCodigo ;
      private string[] P00F07_A187MunicipioNome ;
      private bool[] P00F07_n187MunicipioNome ;
      private string[] P00F08_A169ClienteDocumento ;
      private bool[] P00F08_n169ClienteDocumento ;
      private int[] P00F08_A168ClienteId ;
      private bool[] P00F08_n168ClienteId ;
      private int[] P00F09_A978RepresentanteId ;
      private int[] P00F09_A168ClienteId ;
      private bool[] P00F09_n168ClienteId ;
      private string[] P00F09_A169ClienteDocumento ;
      private bool[] P00F09_n169ClienteDocumento ;
      private int[] P00F010_A168ClienteId ;
      private bool[] P00F010_n168ClienteId ;
      private string[] P00F010_A169ClienteDocumento ;
      private bool[] P00F010_n169ClienteDocumento ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class representanteloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00F02( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A441ProfissaoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ProfissaoNome, ProfissaoId";
         sFromString = " FROM Profissao";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(ProfissaoNome like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY ProfissaoNome, ProfissaoId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00F05( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A187MunicipioNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " MunicipioNome, MunicipioCodigo";
         sFromString = " FROM Municipio";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(MunicipioNome like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY MunicipioNome, MunicipioCodigo";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom5" + " LIMIT CASE WHEN " + ":GXPagingTo5" + " > 0 THEN " + ":GXPagingTo5" + " ELSE 1e9 END";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00F08( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A169ClienteDocumento )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[4];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ClienteDocumento, ClienteId";
         sFromString = " FROM Cliente";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(ClienteDocumento like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         sOrderString += " ORDER BY ClienteDocumento";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom8" + " LIMIT CASE WHEN " + ":GXPagingTo8" + " > 0 THEN " + ":GXPagingTo8" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00F02(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P00F05(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 6 :
                     return conditional_P00F08(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00F03;
          prmP00F03 = new Object[] {
          new ParDef("AV19RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmP00F04;
          prmP00F04 = new Object[] {
          new ParDef("AV27ProfissaoId",GXType.Int32,9,0)
          };
          Object[] prmP00F06;
          prmP00F06 = new Object[] {
          new ParDef("AV19RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmP00F07;
          prmP00F07 = new Object[] {
          new ParDef("AV28MunicipioCodigo",GXType.VarChar,40,0)
          };
          Object[] prmP00F09;
          prmP00F09 = new Object[] {
          new ParDef("AV19RepresentanteId",GXType.Int32,9,0)
          };
          Object[] prmP00F010;
          prmP00F010 = new Object[] {
          new ParDef("AV29ClienteId",GXType.Int32,9,0)
          };
          Object[] prmP00F02;
          prmP00F02 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00F05;
          prmP00F05 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          Object[] prmP00F08;
          prmP00F08 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom8",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo8",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo8",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00F02", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F02,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F03", "SELECT RepresentanteId, RepresentanteProfissao FROM Representante WHERE RepresentanteId = :AV19RepresentanteId ORDER BY RepresentanteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F03,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F04", "SELECT ProfissaoId, ProfissaoNome FROM Profissao WHERE ProfissaoId = :AV27ProfissaoId ORDER BY ProfissaoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F04,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F05", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F05,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F06", "SELECT RepresentanteId, RepresentanteMunicipio FROM Representante WHERE RepresentanteId = :AV19RepresentanteId ORDER BY RepresentanteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F06,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F07", "SELECT MunicipioCodigo, MunicipioNome FROM Municipio WHERE MunicipioCodigo = ( :AV28MunicipioCodigo) ORDER BY MunicipioCodigo ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F07,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F08", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F08,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00F09", "SELECT T1.RepresentanteId, T1.ClienteId, T2.ClienteDocumento FROM (Representante T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId) WHERE T1.RepresentanteId = :AV19RepresentanteId ORDER BY T1.RepresentanteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F09,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F010", "SELECT ClienteId, ClienteDocumento FROM Cliente WHERE ClienteId = :AV29ClienteId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F010,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
