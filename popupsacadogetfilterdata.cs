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
   public class popupsacadogetfilterdata : GXProcedure
   {
      public popupsacadogetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public popupsacadogetfilterdata( IGxContext context )
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
         this.AV32DDOName = aP0_DDOName;
         this.AV33SearchTxtParms = aP1_SearchTxtParms;
         this.AV34SearchTxtTo = aP2_SearchTxtTo;
         this.AV35OptionsJson = "" ;
         this.AV36OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV35OptionsJson;
         aP4_OptionsDescJson=this.AV36OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV37OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV32DDOName = aP0_DDOName;
         this.AV33SearchTxtParms = aP1_SearchTxtParms;
         this.AV34SearchTxtTo = aP2_SearchTxtTo;
         this.AV35OptionsJson = "" ;
         this.AV36OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV35OptionsJson;
         aP4_OptionsDescJson=this.AV36OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV22Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV19MaxItems = 10;
         AV18PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV33SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV33SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV16SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV33SearchTxtParms)) ? "" : StringUtil.Substring( AV33SearchTxtParms, 3, -1));
         AV17SkipItems = (short)(AV18PageIndex*AV19MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_CLIENTEDOCUMENTO") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTEDOCUMENTOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_CLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTERAZAOSOCIALOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_CLIENTENOMEFANTASIA") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTENOMEFANTASIAOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV35OptionsJson = AV22Options.ToJSonString(false);
         AV36OptionsDescJson = AV24OptionsDesc.ToJSonString(false);
         AV37OptionIndexesJson = AV25OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("PopUpSacadoGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PopUpSacadoGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("PopUpSacadoGridState"), null, "", "");
         }
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV39GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV38FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO") == 0 )
            {
               AV10TFClienteDocumento = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCLIENTEDOCUMENTO_SEL") == 0 )
            {
               AV11TFClienteDocumento_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV12TFClienteRazaoSocial = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV13TFClienteRazaoSocial_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCLIENTENOMEFANTASIA") == 0 )
            {
               AV14TFClienteNomeFantasia = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCLIENTENOMEFANTASIA_SEL") == 0 )
            {
               AV15TFClienteNomeFantasia_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCLIENTEDOCUMENTOOPTIONS' Routine */
         returnInSub = false;
         AV10TFClienteDocumento = AV16SearchTxt;
         AV11TFClienteDocumento_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV38FilterFullText ,
                                              AV11TFClienteDocumento_Sel ,
                                              AV10TFClienteDocumento ,
                                              AV13TFClienteRazaoSocial_Sel ,
                                              AV12TFClienteRazaoSocial ,
                                              AV15TFClienteNomeFantasia_Sel ,
                                              AV14TFClienteNomeFantasia ,
                                              A169ClienteDocumento ,
                                              A170ClienteRazaoSocial ,
                                              A171ClienteNomeFantasia ,
                                              A1030ClienteSacado } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV38FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV38FilterFullText), "%", "");
         lV38FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV38FilterFullText), "%", "");
         lV38FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV38FilterFullText), "%", "");
         lV10TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV10TFClienteDocumento), "%", "");
         lV12TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV12TFClienteRazaoSocial), "%", "");
         lV14TFClienteNomeFantasia = StringUtil.Concat( StringUtil.RTrim( AV14TFClienteNomeFantasia), "%", "");
         /* Using cursor P00F43 */
         pr_default.execute(0, new Object[] {lV38FilterFullText, lV38FilterFullText, lV38FilterFullText, lV10TFClienteDocumento, AV11TFClienteDocumento_Sel, lV12TFClienteRazaoSocial, AV13TFClienteRazaoSocial_Sel, lV14TFClienteNomeFantasia, AV15TFClienteNomeFantasia_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKF42 = false;
            A168ClienteId = P00F43_A168ClienteId[0];
            n168ClienteId = P00F43_n168ClienteId[0];
            A169ClienteDocumento = P00F43_A169ClienteDocumento[0];
            n169ClienteDocumento = P00F43_n169ClienteDocumento[0];
            A171ClienteNomeFantasia = P00F43_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = P00F43_n171ClienteNomeFantasia[0];
            A170ClienteRazaoSocial = P00F43_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00F43_n170ClienteRazaoSocial[0];
            A1031RelacionamentoSacado = P00F43_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = P00F43_n1031RelacionamentoSacado[0];
            A1031RelacionamentoSacado = P00F43_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = P00F43_n1031RelacionamentoSacado[0];
            A1030ClienteSacado = ((A1031RelacionamentoSacado==0) ? false : true);
            if ( A1030ClienteSacado )
            {
               AV26count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00F43_A169ClienteDocumento[0], A169ClienteDocumento) == 0 ) )
               {
                  BRKF42 = false;
                  A168ClienteId = P00F43_A168ClienteId[0];
                  n168ClienteId = P00F43_n168ClienteId[0];
                  AV26count = (long)(AV26count+1);
                  BRKF42 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV17SkipItems) )
               {
                  AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A169ClienteDocumento)) ? "<#Empty#>" : A169ClienteDocumento);
                  AV22Options.Add(AV21Option, 0);
                  AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV22Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV17SkipItems = (short)(AV17SkipItems-1);
               }
            }
            if ( ! BRKF42 )
            {
               BRKF42 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV12TFClienteRazaoSocial = AV16SearchTxt;
         AV13TFClienteRazaoSocial_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV38FilterFullText ,
                                              AV11TFClienteDocumento_Sel ,
                                              AV10TFClienteDocumento ,
                                              AV13TFClienteRazaoSocial_Sel ,
                                              AV12TFClienteRazaoSocial ,
                                              AV15TFClienteNomeFantasia_Sel ,
                                              AV14TFClienteNomeFantasia ,
                                              A169ClienteDocumento ,
                                              A170ClienteRazaoSocial ,
                                              A171ClienteNomeFantasia ,
                                              A1030ClienteSacado } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV38FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV38FilterFullText), "%", "");
         lV38FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV38FilterFullText), "%", "");
         lV38FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV38FilterFullText), "%", "");
         lV10TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV10TFClienteDocumento), "%", "");
         lV12TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV12TFClienteRazaoSocial), "%", "");
         lV14TFClienteNomeFantasia = StringUtil.Concat( StringUtil.RTrim( AV14TFClienteNomeFantasia), "%", "");
         /* Using cursor P00F45 */
         pr_default.execute(1, new Object[] {lV38FilterFullText, lV38FilterFullText, lV38FilterFullText, lV10TFClienteDocumento, AV11TFClienteDocumento_Sel, lV12TFClienteRazaoSocial, AV13TFClienteRazaoSocial_Sel, lV14TFClienteNomeFantasia, AV15TFClienteNomeFantasia_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKF44 = false;
            A168ClienteId = P00F45_A168ClienteId[0];
            n168ClienteId = P00F45_n168ClienteId[0];
            A170ClienteRazaoSocial = P00F45_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00F45_n170ClienteRazaoSocial[0];
            A171ClienteNomeFantasia = P00F45_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = P00F45_n171ClienteNomeFantasia[0];
            A169ClienteDocumento = P00F45_A169ClienteDocumento[0];
            n169ClienteDocumento = P00F45_n169ClienteDocumento[0];
            A1031RelacionamentoSacado = P00F45_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = P00F45_n1031RelacionamentoSacado[0];
            A1031RelacionamentoSacado = P00F45_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = P00F45_n1031RelacionamentoSacado[0];
            A1030ClienteSacado = ((A1031RelacionamentoSacado==0) ? false : true);
            if ( A1030ClienteSacado )
            {
               AV26count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00F45_A170ClienteRazaoSocial[0], A170ClienteRazaoSocial) == 0 ) )
               {
                  BRKF44 = false;
                  A168ClienteId = P00F45_A168ClienteId[0];
                  n168ClienteId = P00F45_n168ClienteId[0];
                  AV26count = (long)(AV26count+1);
                  BRKF44 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV17SkipItems) )
               {
                  AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ClienteRazaoSocial)) ? "<#Empty#>" : A170ClienteRazaoSocial);
                  AV23OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")));
                  AV22Options.Add(AV21Option, 0);
                  AV24OptionsDesc.Add(AV23OptionDesc, 0);
                  AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV22Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV17SkipItems = (short)(AV17SkipItems-1);
               }
            }
            if ( ! BRKF44 )
            {
               BRKF44 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCLIENTENOMEFANTASIAOPTIONS' Routine */
         returnInSub = false;
         AV14TFClienteNomeFantasia = AV16SearchTxt;
         AV15TFClienteNomeFantasia_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV38FilterFullText ,
                                              AV11TFClienteDocumento_Sel ,
                                              AV10TFClienteDocumento ,
                                              AV13TFClienteRazaoSocial_Sel ,
                                              AV12TFClienteRazaoSocial ,
                                              AV15TFClienteNomeFantasia_Sel ,
                                              AV14TFClienteNomeFantasia ,
                                              A169ClienteDocumento ,
                                              A170ClienteRazaoSocial ,
                                              A171ClienteNomeFantasia ,
                                              A1030ClienteSacado } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV38FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV38FilterFullText), "%", "");
         lV38FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV38FilterFullText), "%", "");
         lV38FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV38FilterFullText), "%", "");
         lV10TFClienteDocumento = StringUtil.Concat( StringUtil.RTrim( AV10TFClienteDocumento), "%", "");
         lV12TFClienteRazaoSocial = StringUtil.Concat( StringUtil.RTrim( AV12TFClienteRazaoSocial), "%", "");
         lV14TFClienteNomeFantasia = StringUtil.Concat( StringUtil.RTrim( AV14TFClienteNomeFantasia), "%", "");
         /* Using cursor P00F47 */
         pr_default.execute(2, new Object[] {lV38FilterFullText, lV38FilterFullText, lV38FilterFullText, lV10TFClienteDocumento, AV11TFClienteDocumento_Sel, lV12TFClienteRazaoSocial, AV13TFClienteRazaoSocial_Sel, lV14TFClienteNomeFantasia, AV15TFClienteNomeFantasia_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKF46 = false;
            A168ClienteId = P00F47_A168ClienteId[0];
            n168ClienteId = P00F47_n168ClienteId[0];
            A171ClienteNomeFantasia = P00F47_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = P00F47_n171ClienteNomeFantasia[0];
            A170ClienteRazaoSocial = P00F47_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00F47_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = P00F47_A169ClienteDocumento[0];
            n169ClienteDocumento = P00F47_n169ClienteDocumento[0];
            A1031RelacionamentoSacado = P00F47_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = P00F47_n1031RelacionamentoSacado[0];
            A1031RelacionamentoSacado = P00F47_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = P00F47_n1031RelacionamentoSacado[0];
            A1030ClienteSacado = ((A1031RelacionamentoSacado==0) ? false : true);
            if ( A1030ClienteSacado )
            {
               AV26count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00F47_A171ClienteNomeFantasia[0], A171ClienteNomeFantasia) == 0 ) )
               {
                  BRKF46 = false;
                  A168ClienteId = P00F47_A168ClienteId[0];
                  n168ClienteId = P00F47_n168ClienteId[0];
                  AV26count = (long)(AV26count+1);
                  BRKF46 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV17SkipItems) )
               {
                  AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A171ClienteNomeFantasia)) ? "<#Empty#>" : A171ClienteNomeFantasia);
                  AV23OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A171ClienteNomeFantasia, "@!")));
                  AV22Options.Add(AV21Option, 0);
                  AV24OptionsDesc.Add(AV23OptionDesc, 0);
                  AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV22Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV17SkipItems = (short)(AV17SkipItems-1);
               }
            }
            if ( ! BRKF46 )
            {
               BRKF46 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV35OptionsJson = "";
         AV36OptionsDescJson = "";
         AV37OptionIndexesJson = "";
         AV22Options = new GxSimpleCollection<string>();
         AV24OptionsDesc = new GxSimpleCollection<string>();
         AV25OptionIndexes = new GxSimpleCollection<string>();
         AV16SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV38FilterFullText = "";
         AV10TFClienteDocumento = "";
         AV11TFClienteDocumento_Sel = "";
         AV12TFClienteRazaoSocial = "";
         AV13TFClienteRazaoSocial_Sel = "";
         AV14TFClienteNomeFantasia = "";
         AV15TFClienteNomeFantasia_Sel = "";
         lV38FilterFullText = "";
         lV10TFClienteDocumento = "";
         lV12TFClienteRazaoSocial = "";
         lV14TFClienteNomeFantasia = "";
         A169ClienteDocumento = "";
         A170ClienteRazaoSocial = "";
         A171ClienteNomeFantasia = "";
         P00F43_A168ClienteId = new int[1] ;
         P00F43_n168ClienteId = new bool[] {false} ;
         P00F43_A169ClienteDocumento = new string[] {""} ;
         P00F43_n169ClienteDocumento = new bool[] {false} ;
         P00F43_A171ClienteNomeFantasia = new string[] {""} ;
         P00F43_n171ClienteNomeFantasia = new bool[] {false} ;
         P00F43_A170ClienteRazaoSocial = new string[] {""} ;
         P00F43_n170ClienteRazaoSocial = new bool[] {false} ;
         P00F43_A1031RelacionamentoSacado = new short[1] ;
         P00F43_n1031RelacionamentoSacado = new bool[] {false} ;
         AV21Option = "";
         P00F45_A168ClienteId = new int[1] ;
         P00F45_n168ClienteId = new bool[] {false} ;
         P00F45_A170ClienteRazaoSocial = new string[] {""} ;
         P00F45_n170ClienteRazaoSocial = new bool[] {false} ;
         P00F45_A171ClienteNomeFantasia = new string[] {""} ;
         P00F45_n171ClienteNomeFantasia = new bool[] {false} ;
         P00F45_A169ClienteDocumento = new string[] {""} ;
         P00F45_n169ClienteDocumento = new bool[] {false} ;
         P00F45_A1031RelacionamentoSacado = new short[1] ;
         P00F45_n1031RelacionamentoSacado = new bool[] {false} ;
         AV23OptionDesc = "";
         P00F47_A168ClienteId = new int[1] ;
         P00F47_n168ClienteId = new bool[] {false} ;
         P00F47_A171ClienteNomeFantasia = new string[] {""} ;
         P00F47_n171ClienteNomeFantasia = new bool[] {false} ;
         P00F47_A170ClienteRazaoSocial = new string[] {""} ;
         P00F47_n170ClienteRazaoSocial = new bool[] {false} ;
         P00F47_A169ClienteDocumento = new string[] {""} ;
         P00F47_n169ClienteDocumento = new bool[] {false} ;
         P00F47_A1031RelacionamentoSacado = new short[1] ;
         P00F47_n1031RelacionamentoSacado = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.popupsacadogetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00F43_A168ClienteId, P00F43_A169ClienteDocumento, P00F43_n169ClienteDocumento, P00F43_A171ClienteNomeFantasia, P00F43_n171ClienteNomeFantasia, P00F43_A170ClienteRazaoSocial, P00F43_n170ClienteRazaoSocial, P00F43_A1031RelacionamentoSacado, P00F43_n1031RelacionamentoSacado
               }
               , new Object[] {
               P00F45_A168ClienteId, P00F45_A170ClienteRazaoSocial, P00F45_n170ClienteRazaoSocial, P00F45_A171ClienteNomeFantasia, P00F45_n171ClienteNomeFantasia, P00F45_A169ClienteDocumento, P00F45_n169ClienteDocumento, P00F45_A1031RelacionamentoSacado, P00F45_n1031RelacionamentoSacado
               }
               , new Object[] {
               P00F47_A168ClienteId, P00F47_A171ClienteNomeFantasia, P00F47_n171ClienteNomeFantasia, P00F47_A170ClienteRazaoSocial, P00F47_n170ClienteRazaoSocial, P00F47_A169ClienteDocumento, P00F47_n169ClienteDocumento, P00F47_A1031RelacionamentoSacado, P00F47_n1031RelacionamentoSacado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private short A1031RelacionamentoSacado ;
      private int AV39GXV1 ;
      private int A168ClienteId ;
      private long AV26count ;
      private bool returnInSub ;
      private bool A1030ClienteSacado ;
      private bool BRKF42 ;
      private bool n168ClienteId ;
      private bool n169ClienteDocumento ;
      private bool n171ClienteNomeFantasia ;
      private bool n170ClienteRazaoSocial ;
      private bool n1031RelacionamentoSacado ;
      private bool BRKF44 ;
      private bool BRKF46 ;
      private string AV35OptionsJson ;
      private string AV36OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV32DDOName ;
      private string AV33SearchTxtParms ;
      private string AV34SearchTxtTo ;
      private string AV16SearchTxt ;
      private string AV38FilterFullText ;
      private string AV10TFClienteDocumento ;
      private string AV11TFClienteDocumento_Sel ;
      private string AV12TFClienteRazaoSocial ;
      private string AV13TFClienteRazaoSocial_Sel ;
      private string AV14TFClienteNomeFantasia ;
      private string AV15TFClienteNomeFantasia_Sel ;
      private string lV38FilterFullText ;
      private string lV10TFClienteDocumento ;
      private string lV12TFClienteRazaoSocial ;
      private string lV14TFClienteNomeFantasia ;
      private string A169ClienteDocumento ;
      private string A170ClienteRazaoSocial ;
      private string A171ClienteNomeFantasia ;
      private string AV21Option ;
      private string AV23OptionDesc ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV24OptionsDesc ;
      private GxSimpleCollection<string> AV25OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private int[] P00F43_A168ClienteId ;
      private bool[] P00F43_n168ClienteId ;
      private string[] P00F43_A169ClienteDocumento ;
      private bool[] P00F43_n169ClienteDocumento ;
      private string[] P00F43_A171ClienteNomeFantasia ;
      private bool[] P00F43_n171ClienteNomeFantasia ;
      private string[] P00F43_A170ClienteRazaoSocial ;
      private bool[] P00F43_n170ClienteRazaoSocial ;
      private short[] P00F43_A1031RelacionamentoSacado ;
      private bool[] P00F43_n1031RelacionamentoSacado ;
      private int[] P00F45_A168ClienteId ;
      private bool[] P00F45_n168ClienteId ;
      private string[] P00F45_A170ClienteRazaoSocial ;
      private bool[] P00F45_n170ClienteRazaoSocial ;
      private string[] P00F45_A171ClienteNomeFantasia ;
      private bool[] P00F45_n171ClienteNomeFantasia ;
      private string[] P00F45_A169ClienteDocumento ;
      private bool[] P00F45_n169ClienteDocumento ;
      private short[] P00F45_A1031RelacionamentoSacado ;
      private bool[] P00F45_n1031RelacionamentoSacado ;
      private int[] P00F47_A168ClienteId ;
      private bool[] P00F47_n168ClienteId ;
      private string[] P00F47_A171ClienteNomeFantasia ;
      private bool[] P00F47_n171ClienteNomeFantasia ;
      private string[] P00F47_A170ClienteRazaoSocial ;
      private bool[] P00F47_n170ClienteRazaoSocial ;
      private string[] P00F47_A169ClienteDocumento ;
      private bool[] P00F47_n169ClienteDocumento ;
      private short[] P00F47_A1031RelacionamentoSacado ;
      private bool[] P00F47_n1031RelacionamentoSacado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class popupsacadogetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00F43( IGxContext context ,
                                             string AV38FilterFullText ,
                                             string AV11TFClienteDocumento_Sel ,
                                             string AV10TFClienteDocumento ,
                                             string AV13TFClienteRazaoSocial_Sel ,
                                             string AV12TFClienteRazaoSocial ,
                                             string AV15TFClienteNomeFantasia_Sel ,
                                             string AV14TFClienteNomeFantasia ,
                                             string A169ClienteDocumento ,
                                             string A170ClienteRazaoSocial ,
                                             string A171ClienteNomeFantasia ,
                                             bool A1030ClienteSacado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ClienteId, T1.ClienteDocumento, T1.ClienteNomeFantasia, T1.ClienteRazaoSocial, COALESCE( T2.RelacionamentoSacado, 0) AS RelacionamentoSacado FROM (Cliente T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS RelacionamentoSacado, ClienteId FROM Relacionamento WHERE (T1.ClienteId = ClienteId) AND (RelacionamentoTipo = ( 'Sacado')) GROUP BY ClienteId ) T2 ON T2.ClienteId = T1.ClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.ClienteDocumento like '%' || :lV38FilterFullText) or ( T1.ClienteRazaoSocial like '%' || :lV38FilterFullText) or ( T1.ClienteNomeFantasia like '%' || :lV38FilterFullText))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV10TFClienteDocumento)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV11TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV11TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV12TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV13TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV13TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFClienteNomeFantasia_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFClienteNomeFantasia)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia like :lV14TFClienteNomeFantasia)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFClienteNomeFantasia_Sel)) && ! ( StringUtil.StrCmp(AV15TFClienteNomeFantasia_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia = ( :AV15TFClienteNomeFantasia_Sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV15TFClienteNomeFantasia_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia IS NULL or (char_length(trim(trailing ' ' from T1.ClienteNomeFantasia))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteDocumento";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00F45( IGxContext context ,
                                             string AV38FilterFullText ,
                                             string AV11TFClienteDocumento_Sel ,
                                             string AV10TFClienteDocumento ,
                                             string AV13TFClienteRazaoSocial_Sel ,
                                             string AV12TFClienteRazaoSocial ,
                                             string AV15TFClienteNomeFantasia_Sel ,
                                             string AV14TFClienteNomeFantasia ,
                                             string A169ClienteDocumento ,
                                             string A170ClienteRazaoSocial ,
                                             string A171ClienteNomeFantasia ,
                                             bool A1030ClienteSacado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ClienteId, T1.ClienteRazaoSocial, T1.ClienteNomeFantasia, T1.ClienteDocumento, COALESCE( T2.RelacionamentoSacado, 0) AS RelacionamentoSacado FROM (Cliente T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS RelacionamentoSacado, ClienteId FROM Relacionamento WHERE (T1.ClienteId = ClienteId) AND (RelacionamentoTipo = ( 'Sacado')) GROUP BY ClienteId ) T2 ON T2.ClienteId = T1.ClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.ClienteDocumento like '%' || :lV38FilterFullText) or ( T1.ClienteRazaoSocial like '%' || :lV38FilterFullText) or ( T1.ClienteNomeFantasia like '%' || :lV38FilterFullText))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV10TFClienteDocumento)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV11TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV11TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV12TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV13TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV13TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFClienteNomeFantasia_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFClienteNomeFantasia)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia like :lV14TFClienteNomeFantasia)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFClienteNomeFantasia_Sel)) && ! ( StringUtil.StrCmp(AV15TFClienteNomeFantasia_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia = ( :AV15TFClienteNomeFantasia_Sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV15TFClienteNomeFantasia_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia IS NULL or (char_length(trim(trailing ' ' from T1.ClienteNomeFantasia))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteRazaoSocial";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00F47( IGxContext context ,
                                             string AV38FilterFullText ,
                                             string AV11TFClienteDocumento_Sel ,
                                             string AV10TFClienteDocumento ,
                                             string AV13TFClienteRazaoSocial_Sel ,
                                             string AV12TFClienteRazaoSocial ,
                                             string AV15TFClienteNomeFantasia_Sel ,
                                             string AV14TFClienteNomeFantasia ,
                                             string A169ClienteDocumento ,
                                             string A170ClienteRazaoSocial ,
                                             string A171ClienteNomeFantasia ,
                                             bool A1030ClienteSacado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[9];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.ClienteId, T1.ClienteNomeFantasia, T1.ClienteRazaoSocial, T1.ClienteDocumento, COALESCE( T2.RelacionamentoSacado, 0) AS RelacionamentoSacado FROM (Cliente T1 LEFT JOIN LATERAL (SELECT COUNT(*) AS RelacionamentoSacado, ClienteId FROM Relacionamento WHERE (T1.ClienteId = ClienteId) AND (RelacionamentoTipo = ( 'Sacado')) GROUP BY ClienteId ) T2 ON T2.ClienteId = T1.ClienteId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.ClienteDocumento like '%' || :lV38FilterFullText) or ( T1.ClienteRazaoSocial like '%' || :lV38FilterFullText) or ( T1.ClienteNomeFantasia like '%' || :lV38FilterFullText))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFClienteDocumento_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFClienteDocumento)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento like :lV10TFClienteDocumento)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFClienteDocumento_Sel)) && ! ( StringUtil.StrCmp(AV11TFClienteDocumento_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento = ( :AV11TFClienteDocumento_Sel))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFClienteDocumento_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteDocumento IS NULL or (char_length(trim(trailing ' ' from T1.ClienteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFClienteRazaoSocial_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFClienteRazaoSocial)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial like :lV12TFClienteRazaoSocial)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFClienteRazaoSocial_Sel)) && ! ( StringUtil.StrCmp(AV13TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial = ( :AV13TFClienteRazaoSocial_Sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV13TFClienteRazaoSocial_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T1.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFClienteNomeFantasia_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFClienteNomeFantasia)) ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia like :lV14TFClienteNomeFantasia)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFClienteNomeFantasia_Sel)) && ! ( StringUtil.StrCmp(AV15TFClienteNomeFantasia_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia = ( :AV15TFClienteNomeFantasia_Sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV15TFClienteNomeFantasia_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.ClienteNomeFantasia IS NULL or (char_length(trim(trailing ' ' from T1.ClienteNomeFantasia))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteNomeFantasia";
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
                     return conditional_P00F43(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] );
               case 1 :
                     return conditional_P00F45(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] );
               case 2 :
                     return conditional_P00F47(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00F43;
          prmP00F43 = new Object[] {
          new ParDef("lV38FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV38FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV38FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV10TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV11TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV12TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV13TFClienteRazaoSocial_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV14TFClienteNomeFantasia",GXType.VarChar,150,0) ,
          new ParDef("AV15TFClienteNomeFantasia_Sel",GXType.VarChar,150,0)
          };
          Object[] prmP00F45;
          prmP00F45 = new Object[] {
          new ParDef("lV38FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV38FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV38FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV10TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV11TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV12TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV13TFClienteRazaoSocial_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV14TFClienteNomeFantasia",GXType.VarChar,150,0) ,
          new ParDef("AV15TFClienteNomeFantasia_Sel",GXType.VarChar,150,0)
          };
          Object[] prmP00F47;
          prmP00F47 = new Object[] {
          new ParDef("lV38FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV38FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV38FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("lV10TFClienteDocumento",GXType.VarChar,20,0) ,
          new ParDef("AV11TFClienteDocumento_Sel",GXType.VarChar,20,0) ,
          new ParDef("lV12TFClienteRazaoSocial",GXType.VarChar,150,0) ,
          new ParDef("AV13TFClienteRazaoSocial_Sel",GXType.VarChar,150,0) ,
          new ParDef("lV14TFClienteNomeFantasia",GXType.VarChar,150,0) ,
          new ParDef("AV15TFClienteNomeFantasia_Sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00F43", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F43,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F45", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F45,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F47", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F47,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
