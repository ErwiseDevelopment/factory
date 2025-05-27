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
namespace GeneXus.Programs.costumer {
   public class invoicesgetfilterdata : GXProcedure
   {
      public invoicesgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public invoicesgetfilterdata( IGxContext context )
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
         this.AV38DDOName = aP0_DDOName;
         this.AV39SearchTxtParms = aP1_SearchTxtParms;
         this.AV40SearchTxtTo = aP2_SearchTxtTo;
         this.AV41OptionsJson = "" ;
         this.AV42OptionsDescJson = "" ;
         this.AV43OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV41OptionsJson;
         aP4_OptionsDescJson=this.AV42OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV43OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV38DDOName = aP0_DDOName;
         this.AV39SearchTxtParms = aP1_SearchTxtParms;
         this.AV40SearchTxtTo = aP2_SearchTxtTo;
         this.AV41OptionsJson = "" ;
         this.AV42OptionsDescJson = "" ;
         this.AV43OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV41OptionsJson;
         aP4_OptionsDescJson=this.AV42OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV28Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25MaxItems = 10;
         AV24PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV39SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV39SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV22SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV39SearchTxtParms)) ? "" : StringUtil.Substring( AV39SearchTxtParms, 3, -1));
         AV23SkipItems = (short)(AV24PageIndex*AV25MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_NOTAFISCALNUMERO") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALNUMEROOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_NOTAFISCALQUANTIDADERESUMO_F") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALQUANTIDADERESUMO_FOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_NOTAFISCALVALORFORMATADO_F") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALVALORFORMATADO_FOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_NOTAFISCALVALORVENDIDOFORMATADO_F") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALVALORVENDIDOFORMATADO_FOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_NOTAFISCALSALDOFORMATADO_F") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALSALDOFORMATADO_FOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV41OptionsJson = AV28Options.ToJSonString(false);
         AV42OptionsDescJson = AV30OptionsDesc.ToJSonString(false);
         AV43OptionIndexesJson = AV31OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get("Costumer.invoicesGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Costumer.invoicesGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Costumer.invoicesGridState"), null, "", "");
         }
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV44FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO") == 0 )
            {
               AV10TFNotaFiscalNumero = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO_SEL") == 0 )
            {
               AV11TFNotaFiscalNumero_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALQUANTIDADERESUMO_F") == 0 )
            {
               AV12TFNotaFiscalQuantidadeResumo_F = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALQUANTIDADERESUMO_F_SEL") == 0 )
            {
               AV13TFNotaFiscalQuantidadeResumo_F_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALVALORFORMATADO_F") == 0 )
            {
               AV14TFNotaFiscalValorFormatado_F = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALVALORFORMATADO_F_SEL") == 0 )
            {
               AV15TFNotaFiscalValorFormatado_F_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALVALORVENDIDOFORMATADO_F") == 0 )
            {
               AV16TFNotaFiscalValorVendidoFormatado_F = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALVALORVENDIDOFORMATADO_F_SEL") == 0 )
            {
               AV17TFNotaFiscalValorVendidoFormatado_F_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALSALDOFORMATADO_F") == 0 )
            {
               AV18TFNotaFiscalSaldoFormatado_F = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALSALDOFORMATADO_F_SEL") == 0 )
            {
               AV19TFNotaFiscalSaldoFormatado_F_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALSTATUS_SEL") == 0 )
            {
               AV20TFNotaFiscalStatus_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV21TFNotaFiscalStatus_Sels.FromJSonString(AV20TFNotaFiscalStatus_SelsJson, null);
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV45DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "NOTAFISCALUF") == 0 )
            {
               AV46NotaFiscalUF1 = (short)(Math.Round(NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV47DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV48DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "NOTAFISCALUF") == 0 )
               {
                  AV49NotaFiscalUF2 = (short)(Math.Round(NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV50DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV51DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV51DynamicFiltersSelector3, "NOTAFISCALUF") == 0 )
                  {
                     AV52NotaFiscalUF3 = (short)(Math.Round(NumberUtil.Val( AV37GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADNOTAFISCALNUMEROOPTIONS' Routine */
         returnInSub = false;
         AV10TFNotaFiscalNumero = AV22SearchTxt;
         AV11TFNotaFiscalNumero_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A880NotaFiscalStatus ,
                                              AV21TFNotaFiscalStatus_Sels ,
                                              AV45DynamicFiltersSelector1 ,
                                              AV46NotaFiscalUF1 ,
                                              AV47DynamicFiltersEnabled2 ,
                                              AV48DynamicFiltersSelector2 ,
                                              AV49NotaFiscalUF2 ,
                                              AV50DynamicFiltersEnabled3 ,
                                              AV51DynamicFiltersSelector3 ,
                                              AV52NotaFiscalUF3 ,
                                              AV11TFNotaFiscalNumero_Sel ,
                                              AV10TFNotaFiscalNumero ,
                                              A795NotaFiscalUF ,
                                              A799NotaFiscalNumero ,
                                              AV44FilterFullText ,
                                              A879NotaFiscalQuantidadeResumo_F ,
                                              A881NotaFiscalValorFormatado_F ,
                                              A882NotaFiscalValorVendidoFormatado_F ,
                                              A883NotaFiscalSaldoFormatado_F ,
                                              AV13TFNotaFiscalQuantidadeResumo_F_Sel ,
                                              AV12TFNotaFiscalQuantidadeResumo_F ,
                                              AV15TFNotaFiscalValorFormatado_F_Sel ,
                                              AV14TFNotaFiscalValorFormatado_F ,
                                              AV17TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                              AV16TFNotaFiscalValorVendidoFormatado_F ,
                                              AV19TFNotaFiscalSaldoFormatado_F_Sel ,
                                              AV18TFNotaFiscalSaldoFormatado_F ,
                                              AV21TFNotaFiscalStatus_Sels.Count } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV10TFNotaFiscalNumero = StringUtil.Concat( StringUtil.RTrim( AV10TFNotaFiscalNumero), "%", "");
         /* Using cursor P00DG7 */
         pr_default.execute(0, new Object[] {AV21TFNotaFiscalStatus_Sels.Count, AV46NotaFiscalUF1, AV49NotaFiscalUF2, AV52NotaFiscalUF3, lV10TFNotaFiscalNumero, AV11TFNotaFiscalNumero_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKDG2 = false;
            A794NotaFiscalId = P00DG7_A794NotaFiscalId[0];
            n794NotaFiscalId = P00DG7_n794NotaFiscalId[0];
            A799NotaFiscalNumero = P00DG7_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00DG7_n799NotaFiscalNumero[0];
            A795NotaFiscalUF = P00DG7_A795NotaFiscalUF[0];
            n795NotaFiscalUF = P00DG7_n795NotaFiscalUF[0];
            A880NotaFiscalStatus = P00DG7_A880NotaFiscalStatus[0];
            n880NotaFiscalStatus = P00DG7_n880NotaFiscalStatus[0];
            A877NotaFiscalQuantidadeDeItens_F = P00DG7_A877NotaFiscalQuantidadeDeItens_F[0];
            n877NotaFiscalQuantidadeDeItens_F = P00DG7_n877NotaFiscalQuantidadeDeItens_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = P00DG7_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            n878NotaFiscalQuantidadeDeItensVendidos_F = P00DG7_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A875NotaFiscalValorTotalVendido_F = P00DG7_A875NotaFiscalValorTotalVendido_F[0];
            A874NotaFiscalValorTotal_F = P00DG7_A874NotaFiscalValorTotal_F[0];
            A880NotaFiscalStatus = P00DG7_A880NotaFiscalStatus[0];
            n880NotaFiscalStatus = P00DG7_n880NotaFiscalStatus[0];
            A877NotaFiscalQuantidadeDeItens_F = P00DG7_A877NotaFiscalQuantidadeDeItens_F[0];
            n877NotaFiscalQuantidadeDeItens_F = P00DG7_n877NotaFiscalQuantidadeDeItens_F[0];
            A874NotaFiscalValorTotal_F = P00DG7_A874NotaFiscalValorTotal_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = P00DG7_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            n878NotaFiscalQuantidadeDeItensVendidos_F = P00DG7_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A875NotaFiscalValorTotalVendido_F = P00DG7_A875NotaFiscalValorTotalVendido_F[0];
            A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNotaFiscalQuantidadeResumo_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFNotaFiscalQuantidadeResumo_F)) ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( AV12TFNotaFiscalQuantidadeResumo_F , 40 , "%"),  ' ' ) ) )
            {
               if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNotaFiscalQuantidadeResumo_F_Sel)) && ! ( StringUtil.StrCmp(AV13TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A879NotaFiscalQuantidadeResumo_F, AV13TFNotaFiscalQuantidadeResumo_F_Sel) == 0 ) ) )
               {
                  if ( ( StringUtil.StrCmp(AV13TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A879NotaFiscalQuantidadeResumo_F)) ) )
                  {
                     A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotaFiscalValorFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNotaFiscalValorFormatado_F)) ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( AV14TFNotaFiscalValorFormatado_F , 40 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotaFiscalValorFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV15TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A881NotaFiscalValorFormatado_F, AV15TFNotaFiscalValorFormatado_F_Sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV15TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A881NotaFiscalValorFormatado_F)) ) )
                           {
                              A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
                              A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
                              if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNotaFiscalSaldoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNotaFiscalSaldoFormatado_F)) ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( AV18TFNotaFiscalSaldoFormatado_F , 40 , "%"),  ' ' ) ) )
                              {
                                 if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNotaFiscalSaldoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV19TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A883NotaFiscalSaldoFormatado_F, AV19TFNotaFiscalSaldoFormatado_F_Sel) == 0 ) ) )
                                 {
                                    if ( ( StringUtil.StrCmp(AV19TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A883NotaFiscalSaldoFormatado_F)) ) )
                                    {
                                       A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
                                       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44FilterFullText)) || ( ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "parcial" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Parcial") == 0 ) ) || ( StringUtil.Like( "completo" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Completo") == 0 ) ) ) )
                                       {
                                          if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNotaFiscalValorVendidoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNotaFiscalValorVendidoFormatado_F)) ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( AV16TFNotaFiscalValorVendidoFormatado_F , 40 , "%"),  ' ' ) ) )
                                          {
                                             if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNotaFiscalValorVendidoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV17TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A882NotaFiscalValorVendidoFormatado_F, AV17TFNotaFiscalValorVendidoFormatado_F_Sel) == 0 ) ) )
                                             {
                                                if ( ( StringUtil.StrCmp(AV17TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A882NotaFiscalValorVendidoFormatado_F)) ) )
                                                {
                                                   AV32count = 0;
                                                   while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00DG7_A799NotaFiscalNumero[0], A799NotaFiscalNumero) == 0 ) )
                                                   {
                                                      BRKDG2 = false;
                                                      A794NotaFiscalId = P00DG7_A794NotaFiscalId[0];
                                                      n794NotaFiscalId = P00DG7_n794NotaFiscalId[0];
                                                      AV32count = (long)(AV32count+1);
                                                      BRKDG2 = true;
                                                      pr_default.readNext(0);
                                                   }
                                                   if ( (0==AV23SkipItems) )
                                                   {
                                                      AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A799NotaFiscalNumero)) ? "<#Empty#>" : A799NotaFiscalNumero);
                                                      AV28Options.Add(AV27Option, 0);
                                                      AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                                                      if ( AV28Options.Count == 10 )
                                                      {
                                                         /* Exit For each command. Update data (if necessary), close cursors & exit. */
                                                         if (true) break;
                                                      }
                                                   }
                                                   else
                                                   {
                                                      AV23SkipItems = (short)(AV23SkipItems-1);
                                                   }
                                                }
                                             }
                                          }
                                       }
                                    }
                                 }
                              }
                           }
                        }
                     }
                  }
               }
            }
            if ( ! BRKDG2 )
            {
               BRKDG2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADNOTAFISCALQUANTIDADERESUMO_FOPTIONS' Routine */
         returnInSub = false;
         AV12TFNotaFiscalQuantidadeResumo_F = AV22SearchTxt;
         AV13TFNotaFiscalQuantidadeResumo_F_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A880NotaFiscalStatus ,
                                              AV21TFNotaFiscalStatus_Sels ,
                                              AV45DynamicFiltersSelector1 ,
                                              AV46NotaFiscalUF1 ,
                                              AV47DynamicFiltersEnabled2 ,
                                              AV48DynamicFiltersSelector2 ,
                                              AV49NotaFiscalUF2 ,
                                              AV50DynamicFiltersEnabled3 ,
                                              AV51DynamicFiltersSelector3 ,
                                              AV52NotaFiscalUF3 ,
                                              AV11TFNotaFiscalNumero_Sel ,
                                              AV10TFNotaFiscalNumero ,
                                              A795NotaFiscalUF ,
                                              A799NotaFiscalNumero ,
                                              AV44FilterFullText ,
                                              A879NotaFiscalQuantidadeResumo_F ,
                                              A881NotaFiscalValorFormatado_F ,
                                              A882NotaFiscalValorVendidoFormatado_F ,
                                              A883NotaFiscalSaldoFormatado_F ,
                                              AV13TFNotaFiscalQuantidadeResumo_F_Sel ,
                                              AV12TFNotaFiscalQuantidadeResumo_F ,
                                              AV15TFNotaFiscalValorFormatado_F_Sel ,
                                              AV14TFNotaFiscalValorFormatado_F ,
                                              AV17TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                              AV16TFNotaFiscalValorVendidoFormatado_F ,
                                              AV19TFNotaFiscalSaldoFormatado_F_Sel ,
                                              AV18TFNotaFiscalSaldoFormatado_F ,
                                              AV21TFNotaFiscalStatus_Sels.Count } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV10TFNotaFiscalNumero = StringUtil.Concat( StringUtil.RTrim( AV10TFNotaFiscalNumero), "%", "");
         /* Using cursor P00DG13 */
         pr_default.execute(1, new Object[] {AV21TFNotaFiscalStatus_Sels.Count, AV46NotaFiscalUF1, AV49NotaFiscalUF2, AV52NotaFiscalUF3, lV10TFNotaFiscalNumero, AV11TFNotaFiscalNumero_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A794NotaFiscalId = P00DG13_A794NotaFiscalId[0];
            n794NotaFiscalId = P00DG13_n794NotaFiscalId[0];
            A795NotaFiscalUF = P00DG13_A795NotaFiscalUF[0];
            n795NotaFiscalUF = P00DG13_n795NotaFiscalUF[0];
            A799NotaFiscalNumero = P00DG13_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00DG13_n799NotaFiscalNumero[0];
            A880NotaFiscalStatus = P00DG13_A880NotaFiscalStatus[0];
            n880NotaFiscalStatus = P00DG13_n880NotaFiscalStatus[0];
            A877NotaFiscalQuantidadeDeItens_F = P00DG13_A877NotaFiscalQuantidadeDeItens_F[0];
            n877NotaFiscalQuantidadeDeItens_F = P00DG13_n877NotaFiscalQuantidadeDeItens_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = P00DG13_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            n878NotaFiscalQuantidadeDeItensVendidos_F = P00DG13_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A875NotaFiscalValorTotalVendido_F = P00DG13_A875NotaFiscalValorTotalVendido_F[0];
            A874NotaFiscalValorTotal_F = P00DG13_A874NotaFiscalValorTotal_F[0];
            A880NotaFiscalStatus = P00DG13_A880NotaFiscalStatus[0];
            n880NotaFiscalStatus = P00DG13_n880NotaFiscalStatus[0];
            A877NotaFiscalQuantidadeDeItens_F = P00DG13_A877NotaFiscalQuantidadeDeItens_F[0];
            n877NotaFiscalQuantidadeDeItens_F = P00DG13_n877NotaFiscalQuantidadeDeItens_F[0];
            A874NotaFiscalValorTotal_F = P00DG13_A874NotaFiscalValorTotal_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = P00DG13_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            n878NotaFiscalQuantidadeDeItensVendidos_F = P00DG13_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A875NotaFiscalValorTotalVendido_F = P00DG13_A875NotaFiscalValorTotalVendido_F[0];
            A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNotaFiscalQuantidadeResumo_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFNotaFiscalQuantidadeResumo_F)) ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( AV12TFNotaFiscalQuantidadeResumo_F , 40 , "%"),  ' ' ) ) )
            {
               if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNotaFiscalQuantidadeResumo_F_Sel)) && ! ( StringUtil.StrCmp(AV13TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A879NotaFiscalQuantidadeResumo_F, AV13TFNotaFiscalQuantidadeResumo_F_Sel) == 0 ) ) )
               {
                  if ( ( StringUtil.StrCmp(AV13TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A879NotaFiscalQuantidadeResumo_F)) ) )
                  {
                     A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotaFiscalValorFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNotaFiscalValorFormatado_F)) ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( AV14TFNotaFiscalValorFormatado_F , 40 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotaFiscalValorFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV15TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A881NotaFiscalValorFormatado_F, AV15TFNotaFiscalValorFormatado_F_Sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV15TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A881NotaFiscalValorFormatado_F)) ) )
                           {
                              A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
                              A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
                              if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNotaFiscalSaldoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNotaFiscalSaldoFormatado_F)) ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( AV18TFNotaFiscalSaldoFormatado_F , 40 , "%"),  ' ' ) ) )
                              {
                                 if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNotaFiscalSaldoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV19TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A883NotaFiscalSaldoFormatado_F, AV19TFNotaFiscalSaldoFormatado_F_Sel) == 0 ) ) )
                                 {
                                    if ( ( StringUtil.StrCmp(AV19TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A883NotaFiscalSaldoFormatado_F)) ) )
                                    {
                                       A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
                                       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44FilterFullText)) || ( ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "parcial" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Parcial") == 0 ) ) || ( StringUtil.Like( "completo" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Completo") == 0 ) ) ) )
                                       {
                                          if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNotaFiscalValorVendidoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNotaFiscalValorVendidoFormatado_F)) ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( AV16TFNotaFiscalValorVendidoFormatado_F , 40 , "%"),  ' ' ) ) )
                                          {
                                             if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNotaFiscalValorVendidoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV17TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A882NotaFiscalValorVendidoFormatado_F, AV17TFNotaFiscalValorVendidoFormatado_F_Sel) == 0 ) ) )
                                             {
                                                if ( ( StringUtil.StrCmp(AV17TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A882NotaFiscalValorVendidoFormatado_F)) ) )
                                                {
                                                   AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A879NotaFiscalQuantidadeResumo_F)) ? "<#Empty#>" : A879NotaFiscalQuantidadeResumo_F);
                                                   AV26InsertIndex = 1;
                                                   while ( ( StringUtil.StrCmp(AV27Option, "<#Empty#>") != 0 ) && ( AV26InsertIndex <= AV28Options.Count ) && ( ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) < 0 ) || ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), "<#Empty#>") == 0 ) ) )
                                                   {
                                                      AV26InsertIndex = (int)(AV26InsertIndex+1);
                                                   }
                                                   if ( ( AV26InsertIndex <= AV28Options.Count ) && ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) == 0 ) )
                                                   {
                                                      AV32count = (long)(Math.Round(NumberUtil.Val( ((string)AV31OptionIndexes.Item(AV26InsertIndex)), "."), 18, MidpointRounding.ToEven));
                                                      AV32count = (long)(AV32count+1);
                                                      AV31OptionIndexes.RemoveItem(AV26InsertIndex);
                                                      AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), AV26InsertIndex);
                                                   }
                                                   else
                                                   {
                                                      AV28Options.Add(AV27Option, AV26InsertIndex);
                                                      AV31OptionIndexes.Add("1", AV26InsertIndex);
                                                   }
                                                   if ( AV28Options.Count == AV23SkipItems + 11 )
                                                   {
                                                      AV28Options.RemoveItem(AV28Options.Count);
                                                      AV31OptionIndexes.RemoveItem(AV31OptionIndexes.Count);
                                                   }
                                                }
                                             }
                                          }
                                       }
                                    }
                                 }
                              }
                           }
                        }
                     }
                  }
               }
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         while ( AV23SkipItems > 0 )
         {
            AV28Options.RemoveItem(1);
            AV31OptionIndexes.RemoveItem(1);
            AV23SkipItems = (short)(AV23SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADNOTAFISCALVALORFORMATADO_FOPTIONS' Routine */
         returnInSub = false;
         AV14TFNotaFiscalValorFormatado_F = AV22SearchTxt;
         AV15TFNotaFiscalValorFormatado_F_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A880NotaFiscalStatus ,
                                              AV21TFNotaFiscalStatus_Sels ,
                                              AV45DynamicFiltersSelector1 ,
                                              AV46NotaFiscalUF1 ,
                                              AV47DynamicFiltersEnabled2 ,
                                              AV48DynamicFiltersSelector2 ,
                                              AV49NotaFiscalUF2 ,
                                              AV50DynamicFiltersEnabled3 ,
                                              AV51DynamicFiltersSelector3 ,
                                              AV52NotaFiscalUF3 ,
                                              AV11TFNotaFiscalNumero_Sel ,
                                              AV10TFNotaFiscalNumero ,
                                              A795NotaFiscalUF ,
                                              A799NotaFiscalNumero ,
                                              AV44FilterFullText ,
                                              A879NotaFiscalQuantidadeResumo_F ,
                                              A881NotaFiscalValorFormatado_F ,
                                              A882NotaFiscalValorVendidoFormatado_F ,
                                              A883NotaFiscalSaldoFormatado_F ,
                                              AV13TFNotaFiscalQuantidadeResumo_F_Sel ,
                                              AV12TFNotaFiscalQuantidadeResumo_F ,
                                              AV15TFNotaFiscalValorFormatado_F_Sel ,
                                              AV14TFNotaFiscalValorFormatado_F ,
                                              AV17TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                              AV16TFNotaFiscalValorVendidoFormatado_F ,
                                              AV19TFNotaFiscalSaldoFormatado_F_Sel ,
                                              AV18TFNotaFiscalSaldoFormatado_F ,
                                              AV21TFNotaFiscalStatus_Sels.Count } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV10TFNotaFiscalNumero = StringUtil.Concat( StringUtil.RTrim( AV10TFNotaFiscalNumero), "%", "");
         /* Using cursor P00DG19 */
         pr_default.execute(2, new Object[] {AV21TFNotaFiscalStatus_Sels.Count, AV46NotaFiscalUF1, AV49NotaFiscalUF2, AV52NotaFiscalUF3, lV10TFNotaFiscalNumero, AV11TFNotaFiscalNumero_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A794NotaFiscalId = P00DG19_A794NotaFiscalId[0];
            n794NotaFiscalId = P00DG19_n794NotaFiscalId[0];
            A795NotaFiscalUF = P00DG19_A795NotaFiscalUF[0];
            n795NotaFiscalUF = P00DG19_n795NotaFiscalUF[0];
            A799NotaFiscalNumero = P00DG19_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00DG19_n799NotaFiscalNumero[0];
            A880NotaFiscalStatus = P00DG19_A880NotaFiscalStatus[0];
            n880NotaFiscalStatus = P00DG19_n880NotaFiscalStatus[0];
            A877NotaFiscalQuantidadeDeItens_F = P00DG19_A877NotaFiscalQuantidadeDeItens_F[0];
            n877NotaFiscalQuantidadeDeItens_F = P00DG19_n877NotaFiscalQuantidadeDeItens_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = P00DG19_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            n878NotaFiscalQuantidadeDeItensVendidos_F = P00DG19_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A875NotaFiscalValorTotalVendido_F = P00DG19_A875NotaFiscalValorTotalVendido_F[0];
            A874NotaFiscalValorTotal_F = P00DG19_A874NotaFiscalValorTotal_F[0];
            A880NotaFiscalStatus = P00DG19_A880NotaFiscalStatus[0];
            n880NotaFiscalStatus = P00DG19_n880NotaFiscalStatus[0];
            A877NotaFiscalQuantidadeDeItens_F = P00DG19_A877NotaFiscalQuantidadeDeItens_F[0];
            n877NotaFiscalQuantidadeDeItens_F = P00DG19_n877NotaFiscalQuantidadeDeItens_F[0];
            A874NotaFiscalValorTotal_F = P00DG19_A874NotaFiscalValorTotal_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = P00DG19_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            n878NotaFiscalQuantidadeDeItensVendidos_F = P00DG19_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A875NotaFiscalValorTotalVendido_F = P00DG19_A875NotaFiscalValorTotalVendido_F[0];
            A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNotaFiscalQuantidadeResumo_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFNotaFiscalQuantidadeResumo_F)) ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( AV12TFNotaFiscalQuantidadeResumo_F , 40 , "%"),  ' ' ) ) )
            {
               if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNotaFiscalQuantidadeResumo_F_Sel)) && ! ( StringUtil.StrCmp(AV13TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A879NotaFiscalQuantidadeResumo_F, AV13TFNotaFiscalQuantidadeResumo_F_Sel) == 0 ) ) )
               {
                  if ( ( StringUtil.StrCmp(AV13TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A879NotaFiscalQuantidadeResumo_F)) ) )
                  {
                     A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotaFiscalValorFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNotaFiscalValorFormatado_F)) ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( AV14TFNotaFiscalValorFormatado_F , 40 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotaFiscalValorFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV15TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A881NotaFiscalValorFormatado_F, AV15TFNotaFiscalValorFormatado_F_Sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV15TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A881NotaFiscalValorFormatado_F)) ) )
                           {
                              A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
                              A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
                              if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNotaFiscalSaldoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNotaFiscalSaldoFormatado_F)) ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( AV18TFNotaFiscalSaldoFormatado_F , 40 , "%"),  ' ' ) ) )
                              {
                                 if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNotaFiscalSaldoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV19TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A883NotaFiscalSaldoFormatado_F, AV19TFNotaFiscalSaldoFormatado_F_Sel) == 0 ) ) )
                                 {
                                    if ( ( StringUtil.StrCmp(AV19TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A883NotaFiscalSaldoFormatado_F)) ) )
                                    {
                                       A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
                                       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44FilterFullText)) || ( ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "parcial" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Parcial") == 0 ) ) || ( StringUtil.Like( "completo" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Completo") == 0 ) ) ) )
                                       {
                                          if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNotaFiscalValorVendidoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNotaFiscalValorVendidoFormatado_F)) ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( AV16TFNotaFiscalValorVendidoFormatado_F , 40 , "%"),  ' ' ) ) )
                                          {
                                             if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNotaFiscalValorVendidoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV17TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A882NotaFiscalValorVendidoFormatado_F, AV17TFNotaFiscalValorVendidoFormatado_F_Sel) == 0 ) ) )
                                             {
                                                if ( ( StringUtil.StrCmp(AV17TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A882NotaFiscalValorVendidoFormatado_F)) ) )
                                                {
                                                   AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A881NotaFiscalValorFormatado_F)) ? "<#Empty#>" : A881NotaFiscalValorFormatado_F);
                                                   AV26InsertIndex = 1;
                                                   while ( ( StringUtil.StrCmp(AV27Option, "<#Empty#>") != 0 ) && ( AV26InsertIndex <= AV28Options.Count ) && ( ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) < 0 ) || ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), "<#Empty#>") == 0 ) ) )
                                                   {
                                                      AV26InsertIndex = (int)(AV26InsertIndex+1);
                                                   }
                                                   if ( ( AV26InsertIndex <= AV28Options.Count ) && ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) == 0 ) )
                                                   {
                                                      AV32count = (long)(Math.Round(NumberUtil.Val( ((string)AV31OptionIndexes.Item(AV26InsertIndex)), "."), 18, MidpointRounding.ToEven));
                                                      AV32count = (long)(AV32count+1);
                                                      AV31OptionIndexes.RemoveItem(AV26InsertIndex);
                                                      AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), AV26InsertIndex);
                                                   }
                                                   else
                                                   {
                                                      AV28Options.Add(AV27Option, AV26InsertIndex);
                                                      AV31OptionIndexes.Add("1", AV26InsertIndex);
                                                   }
                                                   if ( AV28Options.Count == AV23SkipItems + 11 )
                                                   {
                                                      AV28Options.RemoveItem(AV28Options.Count);
                                                      AV31OptionIndexes.RemoveItem(AV31OptionIndexes.Count);
                                                   }
                                                }
                                             }
                                          }
                                       }
                                    }
                                 }
                              }
                           }
                        }
                     }
                  }
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         while ( AV23SkipItems > 0 )
         {
            AV28Options.RemoveItem(1);
            AV31OptionIndexes.RemoveItem(1);
            AV23SkipItems = (short)(AV23SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADNOTAFISCALVALORVENDIDOFORMATADO_FOPTIONS' Routine */
         returnInSub = false;
         AV16TFNotaFiscalValorVendidoFormatado_F = AV22SearchTxt;
         AV17TFNotaFiscalValorVendidoFormatado_F_Sel = "";
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A880NotaFiscalStatus ,
                                              AV21TFNotaFiscalStatus_Sels ,
                                              AV45DynamicFiltersSelector1 ,
                                              AV46NotaFiscalUF1 ,
                                              AV47DynamicFiltersEnabled2 ,
                                              AV48DynamicFiltersSelector2 ,
                                              AV49NotaFiscalUF2 ,
                                              AV50DynamicFiltersEnabled3 ,
                                              AV51DynamicFiltersSelector3 ,
                                              AV52NotaFiscalUF3 ,
                                              AV11TFNotaFiscalNumero_Sel ,
                                              AV10TFNotaFiscalNumero ,
                                              A795NotaFiscalUF ,
                                              A799NotaFiscalNumero ,
                                              AV44FilterFullText ,
                                              A879NotaFiscalQuantidadeResumo_F ,
                                              A881NotaFiscalValorFormatado_F ,
                                              A882NotaFiscalValorVendidoFormatado_F ,
                                              A883NotaFiscalSaldoFormatado_F ,
                                              AV13TFNotaFiscalQuantidadeResumo_F_Sel ,
                                              AV12TFNotaFiscalQuantidadeResumo_F ,
                                              AV15TFNotaFiscalValorFormatado_F_Sel ,
                                              AV14TFNotaFiscalValorFormatado_F ,
                                              AV17TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                              AV16TFNotaFiscalValorVendidoFormatado_F ,
                                              AV19TFNotaFiscalSaldoFormatado_F_Sel ,
                                              AV18TFNotaFiscalSaldoFormatado_F ,
                                              AV21TFNotaFiscalStatus_Sels.Count } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV10TFNotaFiscalNumero = StringUtil.Concat( StringUtil.RTrim( AV10TFNotaFiscalNumero), "%", "");
         /* Using cursor P00DG25 */
         pr_default.execute(3, new Object[] {AV21TFNotaFiscalStatus_Sels.Count, AV46NotaFiscalUF1, AV49NotaFiscalUF2, AV52NotaFiscalUF3, lV10TFNotaFiscalNumero, AV11TFNotaFiscalNumero_Sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A794NotaFiscalId = P00DG25_A794NotaFiscalId[0];
            n794NotaFiscalId = P00DG25_n794NotaFiscalId[0];
            A795NotaFiscalUF = P00DG25_A795NotaFiscalUF[0];
            n795NotaFiscalUF = P00DG25_n795NotaFiscalUF[0];
            A799NotaFiscalNumero = P00DG25_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00DG25_n799NotaFiscalNumero[0];
            A880NotaFiscalStatus = P00DG25_A880NotaFiscalStatus[0];
            n880NotaFiscalStatus = P00DG25_n880NotaFiscalStatus[0];
            A877NotaFiscalQuantidadeDeItens_F = P00DG25_A877NotaFiscalQuantidadeDeItens_F[0];
            n877NotaFiscalQuantidadeDeItens_F = P00DG25_n877NotaFiscalQuantidadeDeItens_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = P00DG25_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            n878NotaFiscalQuantidadeDeItensVendidos_F = P00DG25_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A875NotaFiscalValorTotalVendido_F = P00DG25_A875NotaFiscalValorTotalVendido_F[0];
            A874NotaFiscalValorTotal_F = P00DG25_A874NotaFiscalValorTotal_F[0];
            A880NotaFiscalStatus = P00DG25_A880NotaFiscalStatus[0];
            n880NotaFiscalStatus = P00DG25_n880NotaFiscalStatus[0];
            A877NotaFiscalQuantidadeDeItens_F = P00DG25_A877NotaFiscalQuantidadeDeItens_F[0];
            n877NotaFiscalQuantidadeDeItens_F = P00DG25_n877NotaFiscalQuantidadeDeItens_F[0];
            A874NotaFiscalValorTotal_F = P00DG25_A874NotaFiscalValorTotal_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = P00DG25_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            n878NotaFiscalQuantidadeDeItensVendidos_F = P00DG25_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A875NotaFiscalValorTotalVendido_F = P00DG25_A875NotaFiscalValorTotalVendido_F[0];
            A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNotaFiscalQuantidadeResumo_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFNotaFiscalQuantidadeResumo_F)) ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( AV12TFNotaFiscalQuantidadeResumo_F , 40 , "%"),  ' ' ) ) )
            {
               if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNotaFiscalQuantidadeResumo_F_Sel)) && ! ( StringUtil.StrCmp(AV13TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A879NotaFiscalQuantidadeResumo_F, AV13TFNotaFiscalQuantidadeResumo_F_Sel) == 0 ) ) )
               {
                  if ( ( StringUtil.StrCmp(AV13TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A879NotaFiscalQuantidadeResumo_F)) ) )
                  {
                     A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotaFiscalValorFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNotaFiscalValorFormatado_F)) ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( AV14TFNotaFiscalValorFormatado_F , 40 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotaFiscalValorFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV15TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A881NotaFiscalValorFormatado_F, AV15TFNotaFiscalValorFormatado_F_Sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV15TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A881NotaFiscalValorFormatado_F)) ) )
                           {
                              A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
                              A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
                              if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNotaFiscalSaldoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNotaFiscalSaldoFormatado_F)) ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( AV18TFNotaFiscalSaldoFormatado_F , 40 , "%"),  ' ' ) ) )
                              {
                                 if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNotaFiscalSaldoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV19TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A883NotaFiscalSaldoFormatado_F, AV19TFNotaFiscalSaldoFormatado_F_Sel) == 0 ) ) )
                                 {
                                    if ( ( StringUtil.StrCmp(AV19TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A883NotaFiscalSaldoFormatado_F)) ) )
                                    {
                                       A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
                                       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44FilterFullText)) || ( ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "parcial" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Parcial") == 0 ) ) || ( StringUtil.Like( "completo" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Completo") == 0 ) ) ) )
                                       {
                                          if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNotaFiscalValorVendidoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNotaFiscalValorVendidoFormatado_F)) ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( AV16TFNotaFiscalValorVendidoFormatado_F , 40 , "%"),  ' ' ) ) )
                                          {
                                             if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNotaFiscalValorVendidoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV17TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A882NotaFiscalValorVendidoFormatado_F, AV17TFNotaFiscalValorVendidoFormatado_F_Sel) == 0 ) ) )
                                             {
                                                if ( ( StringUtil.StrCmp(AV17TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A882NotaFiscalValorVendidoFormatado_F)) ) )
                                                {
                                                   AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A882NotaFiscalValorVendidoFormatado_F)) ? "<#Empty#>" : A882NotaFiscalValorVendidoFormatado_F);
                                                   AV26InsertIndex = 1;
                                                   while ( ( StringUtil.StrCmp(AV27Option, "<#Empty#>") != 0 ) && ( AV26InsertIndex <= AV28Options.Count ) && ( ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) < 0 ) || ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), "<#Empty#>") == 0 ) ) )
                                                   {
                                                      AV26InsertIndex = (int)(AV26InsertIndex+1);
                                                   }
                                                   if ( ( AV26InsertIndex <= AV28Options.Count ) && ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) == 0 ) )
                                                   {
                                                      AV32count = (long)(Math.Round(NumberUtil.Val( ((string)AV31OptionIndexes.Item(AV26InsertIndex)), "."), 18, MidpointRounding.ToEven));
                                                      AV32count = (long)(AV32count+1);
                                                      AV31OptionIndexes.RemoveItem(AV26InsertIndex);
                                                      AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), AV26InsertIndex);
                                                   }
                                                   else
                                                   {
                                                      AV28Options.Add(AV27Option, AV26InsertIndex);
                                                      AV31OptionIndexes.Add("1", AV26InsertIndex);
                                                   }
                                                   if ( AV28Options.Count == AV23SkipItems + 11 )
                                                   {
                                                      AV28Options.RemoveItem(AV28Options.Count);
                                                      AV31OptionIndexes.RemoveItem(AV31OptionIndexes.Count);
                                                   }
                                                }
                                             }
                                          }
                                       }
                                    }
                                 }
                              }
                           }
                        }
                     }
                  }
               }
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         while ( AV23SkipItems > 0 )
         {
            AV28Options.RemoveItem(1);
            AV31OptionIndexes.RemoveItem(1);
            AV23SkipItems = (short)(AV23SkipItems-1);
         }
      }

      protected void S161( )
      {
         /* 'LOADNOTAFISCALSALDOFORMATADO_FOPTIONS' Routine */
         returnInSub = false;
         AV18TFNotaFiscalSaldoFormatado_F = AV22SearchTxt;
         AV19TFNotaFiscalSaldoFormatado_F_Sel = "";
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A880NotaFiscalStatus ,
                                              AV21TFNotaFiscalStatus_Sels ,
                                              AV45DynamicFiltersSelector1 ,
                                              AV46NotaFiscalUF1 ,
                                              AV47DynamicFiltersEnabled2 ,
                                              AV48DynamicFiltersSelector2 ,
                                              AV49NotaFiscalUF2 ,
                                              AV50DynamicFiltersEnabled3 ,
                                              AV51DynamicFiltersSelector3 ,
                                              AV52NotaFiscalUF3 ,
                                              AV11TFNotaFiscalNumero_Sel ,
                                              AV10TFNotaFiscalNumero ,
                                              A795NotaFiscalUF ,
                                              A799NotaFiscalNumero ,
                                              AV44FilterFullText ,
                                              A879NotaFiscalQuantidadeResumo_F ,
                                              A881NotaFiscalValorFormatado_F ,
                                              A882NotaFiscalValorVendidoFormatado_F ,
                                              A883NotaFiscalSaldoFormatado_F ,
                                              AV13TFNotaFiscalQuantidadeResumo_F_Sel ,
                                              AV12TFNotaFiscalQuantidadeResumo_F ,
                                              AV15TFNotaFiscalValorFormatado_F_Sel ,
                                              AV14TFNotaFiscalValorFormatado_F ,
                                              AV17TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                              AV16TFNotaFiscalValorVendidoFormatado_F ,
                                              AV19TFNotaFiscalSaldoFormatado_F_Sel ,
                                              AV18TFNotaFiscalSaldoFormatado_F ,
                                              AV21TFNotaFiscalStatus_Sels.Count } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV10TFNotaFiscalNumero = StringUtil.Concat( StringUtil.RTrim( AV10TFNotaFiscalNumero), "%", "");
         /* Using cursor P00DG31 */
         pr_default.execute(4, new Object[] {AV21TFNotaFiscalStatus_Sels.Count, AV46NotaFiscalUF1, AV49NotaFiscalUF2, AV52NotaFiscalUF3, lV10TFNotaFiscalNumero, AV11TFNotaFiscalNumero_Sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A794NotaFiscalId = P00DG31_A794NotaFiscalId[0];
            n794NotaFiscalId = P00DG31_n794NotaFiscalId[0];
            A795NotaFiscalUF = P00DG31_A795NotaFiscalUF[0];
            n795NotaFiscalUF = P00DG31_n795NotaFiscalUF[0];
            A799NotaFiscalNumero = P00DG31_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00DG31_n799NotaFiscalNumero[0];
            A880NotaFiscalStatus = P00DG31_A880NotaFiscalStatus[0];
            n880NotaFiscalStatus = P00DG31_n880NotaFiscalStatus[0];
            A877NotaFiscalQuantidadeDeItens_F = P00DG31_A877NotaFiscalQuantidadeDeItens_F[0];
            n877NotaFiscalQuantidadeDeItens_F = P00DG31_n877NotaFiscalQuantidadeDeItens_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = P00DG31_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            n878NotaFiscalQuantidadeDeItensVendidos_F = P00DG31_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A875NotaFiscalValorTotalVendido_F = P00DG31_A875NotaFiscalValorTotalVendido_F[0];
            A874NotaFiscalValorTotal_F = P00DG31_A874NotaFiscalValorTotal_F[0];
            A880NotaFiscalStatus = P00DG31_A880NotaFiscalStatus[0];
            n880NotaFiscalStatus = P00DG31_n880NotaFiscalStatus[0];
            A877NotaFiscalQuantidadeDeItens_F = P00DG31_A877NotaFiscalQuantidadeDeItens_F[0];
            n877NotaFiscalQuantidadeDeItens_F = P00DG31_n877NotaFiscalQuantidadeDeItens_F[0];
            A874NotaFiscalValorTotal_F = P00DG31_A874NotaFiscalValorTotal_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = P00DG31_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            n878NotaFiscalQuantidadeDeItensVendidos_F = P00DG31_n878NotaFiscalQuantidadeDeItensVendidos_F[0];
            A875NotaFiscalValorTotalVendido_F = P00DG31_A875NotaFiscalValorTotalVendido_F[0];
            A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNotaFiscalQuantidadeResumo_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFNotaFiscalQuantidadeResumo_F)) ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( AV12TFNotaFiscalQuantidadeResumo_F , 40 , "%"),  ' ' ) ) )
            {
               if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFNotaFiscalQuantidadeResumo_F_Sel)) && ! ( StringUtil.StrCmp(AV13TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A879NotaFiscalQuantidadeResumo_F, AV13TFNotaFiscalQuantidadeResumo_F_Sel) == 0 ) ) )
               {
                  if ( ( StringUtil.StrCmp(AV13TFNotaFiscalQuantidadeResumo_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A879NotaFiscalQuantidadeResumo_F)) ) )
                  {
                     A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
                     if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotaFiscalValorFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14TFNotaFiscalValorFormatado_F)) ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( AV14TFNotaFiscalValorFormatado_F , 40 , "%"),  ' ' ) ) )
                     {
                        if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TFNotaFiscalValorFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV15TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A881NotaFiscalValorFormatado_F, AV15TFNotaFiscalValorFormatado_F_Sel) == 0 ) ) )
                        {
                           if ( ( StringUtil.StrCmp(AV15TFNotaFiscalValorFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A881NotaFiscalValorFormatado_F)) ) )
                           {
                              A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
                              A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
                              if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNotaFiscalSaldoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18TFNotaFiscalSaldoFormatado_F)) ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( AV18TFNotaFiscalSaldoFormatado_F , 40 , "%"),  ' ' ) ) )
                              {
                                 if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19TFNotaFiscalSaldoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV19TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A883NotaFiscalSaldoFormatado_F, AV19TFNotaFiscalSaldoFormatado_F_Sel) == 0 ) ) )
                                 {
                                    if ( ( StringUtil.StrCmp(AV19TFNotaFiscalSaldoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A883NotaFiscalSaldoFormatado_F)) ) )
                                    {
                                       A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
                                       if ( String.IsNullOrEmpty(StringUtil.RTrim( AV44FilterFullText)) || ( ( StringUtil.Like( A799NotaFiscalNumero , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A879NotaFiscalQuantidadeResumo_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A881NotaFiscalValorFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A883NotaFiscalSaldoFormatado_F , StringUtil.PadR( "%" + AV44FilterFullText , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( "parcial" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Parcial") == 0 ) ) || ( StringUtil.Like( "completo" , StringUtil.PadR( "%" + StringUtil.Lower( AV44FilterFullText) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A880NotaFiscalStatus, "Completo") == 0 ) ) ) )
                                       {
                                          if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNotaFiscalValorVendidoFormatado_F_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TFNotaFiscalValorVendidoFormatado_F)) ) ) || ( StringUtil.Like( A882NotaFiscalValorVendidoFormatado_F , StringUtil.PadR( AV16TFNotaFiscalValorVendidoFormatado_F , 40 , "%"),  ' ' ) ) )
                                          {
                                             if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17TFNotaFiscalValorVendidoFormatado_F_Sel)) && ! ( StringUtil.StrCmp(AV17TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A882NotaFiscalValorVendidoFormatado_F, AV17TFNotaFiscalValorVendidoFormatado_F_Sel) == 0 ) ) )
                                             {
                                                if ( ( StringUtil.StrCmp(AV17TFNotaFiscalValorVendidoFormatado_F_Sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A882NotaFiscalValorVendidoFormatado_F)) ) )
                                                {
                                                   AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A883NotaFiscalSaldoFormatado_F)) ? "<#Empty#>" : A883NotaFiscalSaldoFormatado_F);
                                                   AV26InsertIndex = 1;
                                                   while ( ( StringUtil.StrCmp(AV27Option, "<#Empty#>") != 0 ) && ( AV26InsertIndex <= AV28Options.Count ) && ( ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) < 0 ) || ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), "<#Empty#>") == 0 ) ) )
                                                   {
                                                      AV26InsertIndex = (int)(AV26InsertIndex+1);
                                                   }
                                                   if ( ( AV26InsertIndex <= AV28Options.Count ) && ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) == 0 ) )
                                                   {
                                                      AV32count = (long)(Math.Round(NumberUtil.Val( ((string)AV31OptionIndexes.Item(AV26InsertIndex)), "."), 18, MidpointRounding.ToEven));
                                                      AV32count = (long)(AV32count+1);
                                                      AV31OptionIndexes.RemoveItem(AV26InsertIndex);
                                                      AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), AV26InsertIndex);
                                                   }
                                                   else
                                                   {
                                                      AV28Options.Add(AV27Option, AV26InsertIndex);
                                                      AV31OptionIndexes.Add("1", AV26InsertIndex);
                                                   }
                                                   if ( AV28Options.Count == AV23SkipItems + 11 )
                                                   {
                                                      AV28Options.RemoveItem(AV28Options.Count);
                                                      AV31OptionIndexes.RemoveItem(AV31OptionIndexes.Count);
                                                   }
                                                }
                                             }
                                          }
                                       }
                                    }
                                 }
                              }
                           }
                        }
                     }
                  }
               }
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
         while ( AV23SkipItems > 0 )
         {
            AV28Options.RemoveItem(1);
            AV31OptionIndexes.RemoveItem(1);
            AV23SkipItems = (short)(AV23SkipItems-1);
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
         AV41OptionsJson = "";
         AV42OptionsDescJson = "";
         AV43OptionIndexesJson = "";
         AV28Options = new GxSimpleCollection<string>();
         AV30OptionsDesc = new GxSimpleCollection<string>();
         AV31OptionIndexes = new GxSimpleCollection<string>();
         AV22SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV33Session = context.GetSession();
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV44FilterFullText = "";
         AV10TFNotaFiscalNumero = "";
         AV11TFNotaFiscalNumero_Sel = "";
         AV12TFNotaFiscalQuantidadeResumo_F = "";
         AV13TFNotaFiscalQuantidadeResumo_F_Sel = "";
         AV14TFNotaFiscalValorFormatado_F = "";
         AV15TFNotaFiscalValorFormatado_F_Sel = "";
         AV16TFNotaFiscalValorVendidoFormatado_F = "";
         AV17TFNotaFiscalValorVendidoFormatado_F_Sel = "";
         AV18TFNotaFiscalSaldoFormatado_F = "";
         AV19TFNotaFiscalSaldoFormatado_F_Sel = "";
         AV20TFNotaFiscalStatus_SelsJson = "";
         AV21TFNotaFiscalStatus_Sels = new GxSimpleCollection<string>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV45DynamicFiltersSelector1 = "";
         AV48DynamicFiltersSelector2 = "";
         AV51DynamicFiltersSelector3 = "";
         lV44FilterFullText = "";
         lV10TFNotaFiscalNumero = "";
         A880NotaFiscalStatus = "";
         A799NotaFiscalNumero = "";
         A879NotaFiscalQuantidadeResumo_F = "";
         A881NotaFiscalValorFormatado_F = "";
         A882NotaFiscalValorVendidoFormatado_F = "";
         A883NotaFiscalSaldoFormatado_F = "";
         P00DG7_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DG7_n794NotaFiscalId = new bool[] {false} ;
         P00DG7_A799NotaFiscalNumero = new string[] {""} ;
         P00DG7_n799NotaFiscalNumero = new bool[] {false} ;
         P00DG7_A795NotaFiscalUF = new short[1] ;
         P00DG7_n795NotaFiscalUF = new bool[] {false} ;
         P00DG7_A880NotaFiscalStatus = new string[] {""} ;
         P00DG7_n880NotaFiscalStatus = new bool[] {false} ;
         P00DG7_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         P00DG7_n877NotaFiscalQuantidadeDeItens_F = new bool[] {false} ;
         P00DG7_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         P00DG7_n878NotaFiscalQuantidadeDeItensVendidos_F = new bool[] {false} ;
         P00DG7_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         P00DG7_A874NotaFiscalValorTotal_F = new decimal[1] ;
         A794NotaFiscalId = Guid.Empty;
         AV27Option = "";
         P00DG13_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DG13_n794NotaFiscalId = new bool[] {false} ;
         P00DG13_A795NotaFiscalUF = new short[1] ;
         P00DG13_n795NotaFiscalUF = new bool[] {false} ;
         P00DG13_A799NotaFiscalNumero = new string[] {""} ;
         P00DG13_n799NotaFiscalNumero = new bool[] {false} ;
         P00DG13_A880NotaFiscalStatus = new string[] {""} ;
         P00DG13_n880NotaFiscalStatus = new bool[] {false} ;
         P00DG13_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         P00DG13_n877NotaFiscalQuantidadeDeItens_F = new bool[] {false} ;
         P00DG13_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         P00DG13_n878NotaFiscalQuantidadeDeItensVendidos_F = new bool[] {false} ;
         P00DG13_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         P00DG13_A874NotaFiscalValorTotal_F = new decimal[1] ;
         P00DG19_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DG19_n794NotaFiscalId = new bool[] {false} ;
         P00DG19_A795NotaFiscalUF = new short[1] ;
         P00DG19_n795NotaFiscalUF = new bool[] {false} ;
         P00DG19_A799NotaFiscalNumero = new string[] {""} ;
         P00DG19_n799NotaFiscalNumero = new bool[] {false} ;
         P00DG19_A880NotaFiscalStatus = new string[] {""} ;
         P00DG19_n880NotaFiscalStatus = new bool[] {false} ;
         P00DG19_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         P00DG19_n877NotaFiscalQuantidadeDeItens_F = new bool[] {false} ;
         P00DG19_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         P00DG19_n878NotaFiscalQuantidadeDeItensVendidos_F = new bool[] {false} ;
         P00DG19_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         P00DG19_A874NotaFiscalValorTotal_F = new decimal[1] ;
         P00DG25_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DG25_n794NotaFiscalId = new bool[] {false} ;
         P00DG25_A795NotaFiscalUF = new short[1] ;
         P00DG25_n795NotaFiscalUF = new bool[] {false} ;
         P00DG25_A799NotaFiscalNumero = new string[] {""} ;
         P00DG25_n799NotaFiscalNumero = new bool[] {false} ;
         P00DG25_A880NotaFiscalStatus = new string[] {""} ;
         P00DG25_n880NotaFiscalStatus = new bool[] {false} ;
         P00DG25_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         P00DG25_n877NotaFiscalQuantidadeDeItens_F = new bool[] {false} ;
         P00DG25_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         P00DG25_n878NotaFiscalQuantidadeDeItensVendidos_F = new bool[] {false} ;
         P00DG25_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         P00DG25_A874NotaFiscalValorTotal_F = new decimal[1] ;
         P00DG31_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00DG31_n794NotaFiscalId = new bool[] {false} ;
         P00DG31_A795NotaFiscalUF = new short[1] ;
         P00DG31_n795NotaFiscalUF = new bool[] {false} ;
         P00DG31_A799NotaFiscalNumero = new string[] {""} ;
         P00DG31_n799NotaFiscalNumero = new bool[] {false} ;
         P00DG31_A880NotaFiscalStatus = new string[] {""} ;
         P00DG31_n880NotaFiscalStatus = new bool[] {false} ;
         P00DG31_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         P00DG31_n877NotaFiscalQuantidadeDeItens_F = new bool[] {false} ;
         P00DG31_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         P00DG31_n878NotaFiscalQuantidadeDeItensVendidos_F = new bool[] {false} ;
         P00DG31_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         P00DG31_A874NotaFiscalValorTotal_F = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.costumer.invoicesgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00DG7_A794NotaFiscalId, P00DG7_A799NotaFiscalNumero, P00DG7_n799NotaFiscalNumero, P00DG7_A795NotaFiscalUF, P00DG7_n795NotaFiscalUF, P00DG7_A880NotaFiscalStatus, P00DG7_n880NotaFiscalStatus, P00DG7_A877NotaFiscalQuantidadeDeItens_F, P00DG7_n877NotaFiscalQuantidadeDeItens_F, P00DG7_A878NotaFiscalQuantidadeDeItensVendidos_F,
               P00DG7_n878NotaFiscalQuantidadeDeItensVendidos_F, P00DG7_A875NotaFiscalValorTotalVendido_F, P00DG7_A874NotaFiscalValorTotal_F
               }
               , new Object[] {
               P00DG13_A794NotaFiscalId, P00DG13_A795NotaFiscalUF, P00DG13_n795NotaFiscalUF, P00DG13_A799NotaFiscalNumero, P00DG13_n799NotaFiscalNumero, P00DG13_A880NotaFiscalStatus, P00DG13_n880NotaFiscalStatus, P00DG13_A877NotaFiscalQuantidadeDeItens_F, P00DG13_A878NotaFiscalQuantidadeDeItensVendidos_F, P00DG13_A875NotaFiscalValorTotalVendido_F,
               P00DG13_A874NotaFiscalValorTotal_F
               }
               , new Object[] {
               P00DG19_A794NotaFiscalId, P00DG19_A795NotaFiscalUF, P00DG19_n795NotaFiscalUF, P00DG19_A799NotaFiscalNumero, P00DG19_n799NotaFiscalNumero, P00DG19_A880NotaFiscalStatus, P00DG19_n880NotaFiscalStatus, P00DG19_A877NotaFiscalQuantidadeDeItens_F, P00DG19_A878NotaFiscalQuantidadeDeItensVendidos_F, P00DG19_A875NotaFiscalValorTotalVendido_F,
               P00DG19_A874NotaFiscalValorTotal_F
               }
               , new Object[] {
               P00DG25_A794NotaFiscalId, P00DG25_A795NotaFiscalUF, P00DG25_n795NotaFiscalUF, P00DG25_A799NotaFiscalNumero, P00DG25_n799NotaFiscalNumero, P00DG25_A880NotaFiscalStatus, P00DG25_n880NotaFiscalStatus, P00DG25_A877NotaFiscalQuantidadeDeItens_F, P00DG25_A878NotaFiscalQuantidadeDeItensVendidos_F, P00DG25_A875NotaFiscalValorTotalVendido_F,
               P00DG25_A874NotaFiscalValorTotal_F
               }
               , new Object[] {
               P00DG31_A794NotaFiscalId, P00DG31_A795NotaFiscalUF, P00DG31_n795NotaFiscalUF, P00DG31_A799NotaFiscalNumero, P00DG31_n799NotaFiscalNumero, P00DG31_A880NotaFiscalStatus, P00DG31_n880NotaFiscalStatus, P00DG31_A877NotaFiscalQuantidadeDeItens_F, P00DG31_A878NotaFiscalQuantidadeDeItensVendidos_F, P00DG31_A875NotaFiscalValorTotalVendido_F,
               P00DG31_A874NotaFiscalValorTotal_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV25MaxItems ;
      private short AV24PageIndex ;
      private short AV23SkipItems ;
      private short AV46NotaFiscalUF1 ;
      private short AV49NotaFiscalUF2 ;
      private short AV52NotaFiscalUF3 ;
      private short A795NotaFiscalUF ;
      private short A877NotaFiscalQuantidadeDeItens_F ;
      private short A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private int AV53GXV1 ;
      private int AV21TFNotaFiscalStatus_Sels_Count ;
      private int AV26InsertIndex ;
      private long AV32count ;
      private decimal A875NotaFiscalValorTotalVendido_F ;
      private decimal A874NotaFiscalValorTotal_F ;
      private decimal A876NotaFiscalSaldo_F ;
      private bool returnInSub ;
      private bool AV47DynamicFiltersEnabled2 ;
      private bool AV50DynamicFiltersEnabled3 ;
      private bool BRKDG2 ;
      private bool n794NotaFiscalId ;
      private bool n799NotaFiscalNumero ;
      private bool n795NotaFiscalUF ;
      private bool n880NotaFiscalStatus ;
      private bool n877NotaFiscalQuantidadeDeItens_F ;
      private bool n878NotaFiscalQuantidadeDeItensVendidos_F ;
      private string AV41OptionsJson ;
      private string AV42OptionsDescJson ;
      private string AV43OptionIndexesJson ;
      private string AV20TFNotaFiscalStatus_SelsJson ;
      private string AV38DDOName ;
      private string AV39SearchTxtParms ;
      private string AV40SearchTxtTo ;
      private string AV22SearchTxt ;
      private string AV44FilterFullText ;
      private string AV10TFNotaFiscalNumero ;
      private string AV11TFNotaFiscalNumero_Sel ;
      private string AV12TFNotaFiscalQuantidadeResumo_F ;
      private string AV13TFNotaFiscalQuantidadeResumo_F_Sel ;
      private string AV14TFNotaFiscalValorFormatado_F ;
      private string AV15TFNotaFiscalValorFormatado_F_Sel ;
      private string AV16TFNotaFiscalValorVendidoFormatado_F ;
      private string AV17TFNotaFiscalValorVendidoFormatado_F_Sel ;
      private string AV18TFNotaFiscalSaldoFormatado_F ;
      private string AV19TFNotaFiscalSaldoFormatado_F_Sel ;
      private string AV45DynamicFiltersSelector1 ;
      private string AV48DynamicFiltersSelector2 ;
      private string AV51DynamicFiltersSelector3 ;
      private string lV44FilterFullText ;
      private string lV10TFNotaFiscalNumero ;
      private string A880NotaFiscalStatus ;
      private string A799NotaFiscalNumero ;
      private string A879NotaFiscalQuantidadeResumo_F ;
      private string A881NotaFiscalValorFormatado_F ;
      private string A882NotaFiscalValorVendidoFormatado_F ;
      private string A883NotaFiscalSaldoFormatado_F ;
      private string AV27Option ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV28Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV31OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GxSimpleCollection<string> AV21TFNotaFiscalStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV37GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00DG7_A794NotaFiscalId ;
      private bool[] P00DG7_n794NotaFiscalId ;
      private string[] P00DG7_A799NotaFiscalNumero ;
      private bool[] P00DG7_n799NotaFiscalNumero ;
      private short[] P00DG7_A795NotaFiscalUF ;
      private bool[] P00DG7_n795NotaFiscalUF ;
      private string[] P00DG7_A880NotaFiscalStatus ;
      private bool[] P00DG7_n880NotaFiscalStatus ;
      private short[] P00DG7_A877NotaFiscalQuantidadeDeItens_F ;
      private bool[] P00DG7_n877NotaFiscalQuantidadeDeItens_F ;
      private short[] P00DG7_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private bool[] P00DG7_n878NotaFiscalQuantidadeDeItensVendidos_F ;
      private decimal[] P00DG7_A875NotaFiscalValorTotalVendido_F ;
      private decimal[] P00DG7_A874NotaFiscalValorTotal_F ;
      private Guid[] P00DG13_A794NotaFiscalId ;
      private bool[] P00DG13_n794NotaFiscalId ;
      private short[] P00DG13_A795NotaFiscalUF ;
      private bool[] P00DG13_n795NotaFiscalUF ;
      private string[] P00DG13_A799NotaFiscalNumero ;
      private bool[] P00DG13_n799NotaFiscalNumero ;
      private string[] P00DG13_A880NotaFiscalStatus ;
      private bool[] P00DG13_n880NotaFiscalStatus ;
      private short[] P00DG13_A877NotaFiscalQuantidadeDeItens_F ;
      private bool[] P00DG13_n877NotaFiscalQuantidadeDeItens_F ;
      private short[] P00DG13_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private bool[] P00DG13_n878NotaFiscalQuantidadeDeItensVendidos_F ;
      private decimal[] P00DG13_A875NotaFiscalValorTotalVendido_F ;
      private decimal[] P00DG13_A874NotaFiscalValorTotal_F ;
      private Guid[] P00DG19_A794NotaFiscalId ;
      private bool[] P00DG19_n794NotaFiscalId ;
      private short[] P00DG19_A795NotaFiscalUF ;
      private bool[] P00DG19_n795NotaFiscalUF ;
      private string[] P00DG19_A799NotaFiscalNumero ;
      private bool[] P00DG19_n799NotaFiscalNumero ;
      private string[] P00DG19_A880NotaFiscalStatus ;
      private bool[] P00DG19_n880NotaFiscalStatus ;
      private short[] P00DG19_A877NotaFiscalQuantidadeDeItens_F ;
      private bool[] P00DG19_n877NotaFiscalQuantidadeDeItens_F ;
      private short[] P00DG19_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private bool[] P00DG19_n878NotaFiscalQuantidadeDeItensVendidos_F ;
      private decimal[] P00DG19_A875NotaFiscalValorTotalVendido_F ;
      private decimal[] P00DG19_A874NotaFiscalValorTotal_F ;
      private Guid[] P00DG25_A794NotaFiscalId ;
      private bool[] P00DG25_n794NotaFiscalId ;
      private short[] P00DG25_A795NotaFiscalUF ;
      private bool[] P00DG25_n795NotaFiscalUF ;
      private string[] P00DG25_A799NotaFiscalNumero ;
      private bool[] P00DG25_n799NotaFiscalNumero ;
      private string[] P00DG25_A880NotaFiscalStatus ;
      private bool[] P00DG25_n880NotaFiscalStatus ;
      private short[] P00DG25_A877NotaFiscalQuantidadeDeItens_F ;
      private bool[] P00DG25_n877NotaFiscalQuantidadeDeItens_F ;
      private short[] P00DG25_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private bool[] P00DG25_n878NotaFiscalQuantidadeDeItensVendidos_F ;
      private decimal[] P00DG25_A875NotaFiscalValorTotalVendido_F ;
      private decimal[] P00DG25_A874NotaFiscalValorTotal_F ;
      private Guid[] P00DG31_A794NotaFiscalId ;
      private bool[] P00DG31_n794NotaFiscalId ;
      private short[] P00DG31_A795NotaFiscalUF ;
      private bool[] P00DG31_n795NotaFiscalUF ;
      private string[] P00DG31_A799NotaFiscalNumero ;
      private bool[] P00DG31_n799NotaFiscalNumero ;
      private string[] P00DG31_A880NotaFiscalStatus ;
      private bool[] P00DG31_n880NotaFiscalStatus ;
      private short[] P00DG31_A877NotaFiscalQuantidadeDeItens_F ;
      private bool[] P00DG31_n877NotaFiscalQuantidadeDeItens_F ;
      private short[] P00DG31_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private bool[] P00DG31_n878NotaFiscalQuantidadeDeItensVendidos_F ;
      private decimal[] P00DG31_A875NotaFiscalValorTotalVendido_F ;
      private decimal[] P00DG31_A874NotaFiscalValorTotal_F ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class invoicesgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DG7( IGxContext context ,
                                             string A880NotaFiscalStatus ,
                                             GxSimpleCollection<string> AV21TFNotaFiscalStatus_Sels ,
                                             string AV45DynamicFiltersSelector1 ,
                                             short AV46NotaFiscalUF1 ,
                                             bool AV47DynamicFiltersEnabled2 ,
                                             string AV48DynamicFiltersSelector2 ,
                                             short AV49NotaFiscalUF2 ,
                                             bool AV50DynamicFiltersEnabled3 ,
                                             string AV51DynamicFiltersSelector3 ,
                                             short AV52NotaFiscalUF3 ,
                                             string AV11TFNotaFiscalNumero_Sel ,
                                             string AV10TFNotaFiscalNumero ,
                                             short A795NotaFiscalUF ,
                                             string A799NotaFiscalNumero ,
                                             string AV44FilterFullText ,
                                             string A879NotaFiscalQuantidadeResumo_F ,
                                             string A881NotaFiscalValorFormatado_F ,
                                             string A882NotaFiscalValorVendidoFormatado_F ,
                                             string A883NotaFiscalSaldoFormatado_F ,
                                             string AV13TFNotaFiscalQuantidadeResumo_F_Sel ,
                                             string AV12TFNotaFiscalQuantidadeResumo_F ,
                                             string AV15TFNotaFiscalValorFormatado_F_Sel ,
                                             string AV14TFNotaFiscalValorFormatado_F ,
                                             string AV17TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                             string AV16TFNotaFiscalValorVendidoFormatado_F ,
                                             string AV19TFNotaFiscalSaldoFormatado_F_Sel ,
                                             string AV18TFNotaFiscalSaldoFormatado_F ,
                                             int AV21TFNotaFiscalStatus_Sels_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalId, T1.NotaFiscalNumero, T1.NotaFiscalUF, COALESCE( T2.NotaFiscalStatus, '') AS NotaFiscalStatus, COALESCE( T3.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItens_F, COALESCE( T4.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F, COALESCE( T4.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T3.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F FROM (((NotaFiscal T1 LEFT JOIN (SELECT CASE  WHEN COALESCE( T6.NotaFiscalQuantidadeDeItensVendidos_F, 0) = COALESCE( T7.NotaFiscalQuantidadeDeItensVendidos_F, 0) THEN 'Completo' ELSE 'Parcial' END AS NotaFiscalStatus, T5.NotaFiscalId FROM ((NotaFiscal T5 LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T5.NotaFiscalId = NotaFiscalId) AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T6 ON T6.NotaFiscalId = T5.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T5.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T7 ON T7.NotaFiscalId = T5.NotaFiscalId) ) T2 ON T2.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T1.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T3 ON T3.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T1.NotaFiscalId = NotaFiscalId)";
         scmdbuf += " AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T4 ON T4.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "(:AV21TFNoCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV21TFNotaFiscalStatus_Sels, "COALESCE( T2.NotaFiscalStatus, '') IN (", ")")+"))");
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "NOTAFISCALUF") == 0 ) && ( ! (0==AV46NotaFiscalUF1) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV46NotaFiscalUF1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV47DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "NOTAFISCALUF") == 0 ) && ( ! (0==AV49NotaFiscalUF2) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV49NotaFiscalUF2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV50DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV51DynamicFiltersSelector3, "NOTAFISCALUF") == 0 ) && ( ! (0==AV52NotaFiscalUF3) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV52NotaFiscalUF3)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFNotaFiscalNumero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFNotaFiscalNumero)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero like :lV10TFNotaFiscalNumero)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFNotaFiscalNumero_Sel)) && ! ( StringUtil.StrCmp(AV11TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero = ( :AV11TFNotaFiscalNumero_Sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NotaFiscalNumero";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00DG13( IGxContext context ,
                                              string A880NotaFiscalStatus ,
                                              GxSimpleCollection<string> AV21TFNotaFiscalStatus_Sels ,
                                              string AV45DynamicFiltersSelector1 ,
                                              short AV46NotaFiscalUF1 ,
                                              bool AV47DynamicFiltersEnabled2 ,
                                              string AV48DynamicFiltersSelector2 ,
                                              short AV49NotaFiscalUF2 ,
                                              bool AV50DynamicFiltersEnabled3 ,
                                              string AV51DynamicFiltersSelector3 ,
                                              short AV52NotaFiscalUF3 ,
                                              string AV11TFNotaFiscalNumero_Sel ,
                                              string AV10TFNotaFiscalNumero ,
                                              short A795NotaFiscalUF ,
                                              string A799NotaFiscalNumero ,
                                              string AV44FilterFullText ,
                                              string A879NotaFiscalQuantidadeResumo_F ,
                                              string A881NotaFiscalValorFormatado_F ,
                                              string A882NotaFiscalValorVendidoFormatado_F ,
                                              string A883NotaFiscalSaldoFormatado_F ,
                                              string AV13TFNotaFiscalQuantidadeResumo_F_Sel ,
                                              string AV12TFNotaFiscalQuantidadeResumo_F ,
                                              string AV15TFNotaFiscalValorFormatado_F_Sel ,
                                              string AV14TFNotaFiscalValorFormatado_F ,
                                              string AV17TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                              string AV16TFNotaFiscalValorVendidoFormatado_F ,
                                              string AV19TFNotaFiscalSaldoFormatado_F_Sel ,
                                              string AV18TFNotaFiscalSaldoFormatado_F ,
                                              int AV21TFNotaFiscalStatus_Sels_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalId, T1.NotaFiscalUF, T1.NotaFiscalNumero, COALESCE( T2.NotaFiscalStatus, '') AS NotaFiscalStatus, COALESCE( T3.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItens_F, COALESCE( T4.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F, COALESCE( T4.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T3.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F FROM (((NotaFiscal T1 LEFT JOIN (SELECT CASE  WHEN COALESCE( T6.NotaFiscalQuantidadeDeItensVendidos_F, 0) = COALESCE( T7.NotaFiscalQuantidadeDeItensVendidos_F, 0) THEN 'Completo' ELSE 'Parcial' END AS NotaFiscalStatus, T5.NotaFiscalId FROM ((NotaFiscal T5 LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T5.NotaFiscalId = NotaFiscalId) AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T6 ON T6.NotaFiscalId = T5.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T5.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T7 ON T7.NotaFiscalId = T5.NotaFiscalId) ) T2 ON T2.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T1.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T3 ON T3.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T1.NotaFiscalId = NotaFiscalId)";
         scmdbuf += " AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T4 ON T4.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "(:AV21TFNoCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV21TFNotaFiscalStatus_Sels, "COALESCE( T2.NotaFiscalStatus, '') IN (", ")")+"))");
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "NOTAFISCALUF") == 0 ) && ( ! (0==AV46NotaFiscalUF1) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV46NotaFiscalUF1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV47DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "NOTAFISCALUF") == 0 ) && ( ! (0==AV49NotaFiscalUF2) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV49NotaFiscalUF2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV50DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV51DynamicFiltersSelector3, "NOTAFISCALUF") == 0 ) && ( ! (0==AV52NotaFiscalUF3) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV52NotaFiscalUF3)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFNotaFiscalNumero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFNotaFiscalNumero)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero like :lV10TFNotaFiscalNumero)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFNotaFiscalNumero_Sel)) && ! ( StringUtil.StrCmp(AV11TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero = ( :AV11TFNotaFiscalNumero_Sel))");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NotaFiscalId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00DG19( IGxContext context ,
                                              string A880NotaFiscalStatus ,
                                              GxSimpleCollection<string> AV21TFNotaFiscalStatus_Sels ,
                                              string AV45DynamicFiltersSelector1 ,
                                              short AV46NotaFiscalUF1 ,
                                              bool AV47DynamicFiltersEnabled2 ,
                                              string AV48DynamicFiltersSelector2 ,
                                              short AV49NotaFiscalUF2 ,
                                              bool AV50DynamicFiltersEnabled3 ,
                                              string AV51DynamicFiltersSelector3 ,
                                              short AV52NotaFiscalUF3 ,
                                              string AV11TFNotaFiscalNumero_Sel ,
                                              string AV10TFNotaFiscalNumero ,
                                              short A795NotaFiscalUF ,
                                              string A799NotaFiscalNumero ,
                                              string AV44FilterFullText ,
                                              string A879NotaFiscalQuantidadeResumo_F ,
                                              string A881NotaFiscalValorFormatado_F ,
                                              string A882NotaFiscalValorVendidoFormatado_F ,
                                              string A883NotaFiscalSaldoFormatado_F ,
                                              string AV13TFNotaFiscalQuantidadeResumo_F_Sel ,
                                              string AV12TFNotaFiscalQuantidadeResumo_F ,
                                              string AV15TFNotaFiscalValorFormatado_F_Sel ,
                                              string AV14TFNotaFiscalValorFormatado_F ,
                                              string AV17TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                              string AV16TFNotaFiscalValorVendidoFormatado_F ,
                                              string AV19TFNotaFiscalSaldoFormatado_F_Sel ,
                                              string AV18TFNotaFiscalSaldoFormatado_F ,
                                              int AV21TFNotaFiscalStatus_Sels_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[6];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalId, T1.NotaFiscalUF, T1.NotaFiscalNumero, COALESCE( T2.NotaFiscalStatus, '') AS NotaFiscalStatus, COALESCE( T3.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItens_F, COALESCE( T4.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F, COALESCE( T4.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T3.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F FROM (((NotaFiscal T1 LEFT JOIN (SELECT CASE  WHEN COALESCE( T6.NotaFiscalQuantidadeDeItensVendidos_F, 0) = COALESCE( T7.NotaFiscalQuantidadeDeItensVendidos_F, 0) THEN 'Completo' ELSE 'Parcial' END AS NotaFiscalStatus, T5.NotaFiscalId FROM ((NotaFiscal T5 LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T5.NotaFiscalId = NotaFiscalId) AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T6 ON T6.NotaFiscalId = T5.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T5.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T7 ON T7.NotaFiscalId = T5.NotaFiscalId) ) T2 ON T2.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T1.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T3 ON T3.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T1.NotaFiscalId = NotaFiscalId)";
         scmdbuf += " AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T4 ON T4.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "(:AV21TFNoCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV21TFNotaFiscalStatus_Sels, "COALESCE( T2.NotaFiscalStatus, '') IN (", ")")+"))");
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "NOTAFISCALUF") == 0 ) && ( ! (0==AV46NotaFiscalUF1) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV46NotaFiscalUF1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV47DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "NOTAFISCALUF") == 0 ) && ( ! (0==AV49NotaFiscalUF2) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV49NotaFiscalUF2)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV50DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV51DynamicFiltersSelector3, "NOTAFISCALUF") == 0 ) && ( ! (0==AV52NotaFiscalUF3) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV52NotaFiscalUF3)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFNotaFiscalNumero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFNotaFiscalNumero)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero like :lV10TFNotaFiscalNumero)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFNotaFiscalNumero_Sel)) && ! ( StringUtil.StrCmp(AV11TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero = ( :AV11TFNotaFiscalNumero_Sel))");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NotaFiscalId";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00DG25( IGxContext context ,
                                              string A880NotaFiscalStatus ,
                                              GxSimpleCollection<string> AV21TFNotaFiscalStatus_Sels ,
                                              string AV45DynamicFiltersSelector1 ,
                                              short AV46NotaFiscalUF1 ,
                                              bool AV47DynamicFiltersEnabled2 ,
                                              string AV48DynamicFiltersSelector2 ,
                                              short AV49NotaFiscalUF2 ,
                                              bool AV50DynamicFiltersEnabled3 ,
                                              string AV51DynamicFiltersSelector3 ,
                                              short AV52NotaFiscalUF3 ,
                                              string AV11TFNotaFiscalNumero_Sel ,
                                              string AV10TFNotaFiscalNumero ,
                                              short A795NotaFiscalUF ,
                                              string A799NotaFiscalNumero ,
                                              string AV44FilterFullText ,
                                              string A879NotaFiscalQuantidadeResumo_F ,
                                              string A881NotaFiscalValorFormatado_F ,
                                              string A882NotaFiscalValorVendidoFormatado_F ,
                                              string A883NotaFiscalSaldoFormatado_F ,
                                              string AV13TFNotaFiscalQuantidadeResumo_F_Sel ,
                                              string AV12TFNotaFiscalQuantidadeResumo_F ,
                                              string AV15TFNotaFiscalValorFormatado_F_Sel ,
                                              string AV14TFNotaFiscalValorFormatado_F ,
                                              string AV17TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                              string AV16TFNotaFiscalValorVendidoFormatado_F ,
                                              string AV19TFNotaFiscalSaldoFormatado_F_Sel ,
                                              string AV18TFNotaFiscalSaldoFormatado_F ,
                                              int AV21TFNotaFiscalStatus_Sels_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[6];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalId, T1.NotaFiscalUF, T1.NotaFiscalNumero, COALESCE( T2.NotaFiscalStatus, '') AS NotaFiscalStatus, COALESCE( T3.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItens_F, COALESCE( T4.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F, COALESCE( T4.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T3.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F FROM (((NotaFiscal T1 LEFT JOIN (SELECT CASE  WHEN COALESCE( T6.NotaFiscalQuantidadeDeItensVendidos_F, 0) = COALESCE( T7.NotaFiscalQuantidadeDeItensVendidos_F, 0) THEN 'Completo' ELSE 'Parcial' END AS NotaFiscalStatus, T5.NotaFiscalId FROM ((NotaFiscal T5 LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T5.NotaFiscalId = NotaFiscalId) AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T6 ON T6.NotaFiscalId = T5.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T5.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T7 ON T7.NotaFiscalId = T5.NotaFiscalId) ) T2 ON T2.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T1.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T3 ON T3.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T1.NotaFiscalId = NotaFiscalId)";
         scmdbuf += " AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T4 ON T4.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "(:AV21TFNoCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV21TFNotaFiscalStatus_Sels, "COALESCE( T2.NotaFiscalStatus, '') IN (", ")")+"))");
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "NOTAFISCALUF") == 0 ) && ( ! (0==AV46NotaFiscalUF1) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV46NotaFiscalUF1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( AV47DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "NOTAFISCALUF") == 0 ) && ( ! (0==AV49NotaFiscalUF2) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV49NotaFiscalUF2)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( AV50DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV51DynamicFiltersSelector3, "NOTAFISCALUF") == 0 ) && ( ! (0==AV52NotaFiscalUF3) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV52NotaFiscalUF3)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFNotaFiscalNumero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFNotaFiscalNumero)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero like :lV10TFNotaFiscalNumero)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFNotaFiscalNumero_Sel)) && ! ( StringUtil.StrCmp(AV11TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero = ( :AV11TFNotaFiscalNumero_Sel))");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NotaFiscalId";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00DG31( IGxContext context ,
                                              string A880NotaFiscalStatus ,
                                              GxSimpleCollection<string> AV21TFNotaFiscalStatus_Sels ,
                                              string AV45DynamicFiltersSelector1 ,
                                              short AV46NotaFiscalUF1 ,
                                              bool AV47DynamicFiltersEnabled2 ,
                                              string AV48DynamicFiltersSelector2 ,
                                              short AV49NotaFiscalUF2 ,
                                              bool AV50DynamicFiltersEnabled3 ,
                                              string AV51DynamicFiltersSelector3 ,
                                              short AV52NotaFiscalUF3 ,
                                              string AV11TFNotaFiscalNumero_Sel ,
                                              string AV10TFNotaFiscalNumero ,
                                              short A795NotaFiscalUF ,
                                              string A799NotaFiscalNumero ,
                                              string AV44FilterFullText ,
                                              string A879NotaFiscalQuantidadeResumo_F ,
                                              string A881NotaFiscalValorFormatado_F ,
                                              string A882NotaFiscalValorVendidoFormatado_F ,
                                              string A883NotaFiscalSaldoFormatado_F ,
                                              string AV13TFNotaFiscalQuantidadeResumo_F_Sel ,
                                              string AV12TFNotaFiscalQuantidadeResumo_F ,
                                              string AV15TFNotaFiscalValorFormatado_F_Sel ,
                                              string AV14TFNotaFiscalValorFormatado_F ,
                                              string AV17TFNotaFiscalValorVendidoFormatado_F_Sel ,
                                              string AV16TFNotaFiscalValorVendidoFormatado_F ,
                                              string AV19TFNotaFiscalSaldoFormatado_F_Sel ,
                                              string AV18TFNotaFiscalSaldoFormatado_F ,
                                              int AV21TFNotaFiscalStatus_Sels_Count )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[6];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalId, T1.NotaFiscalUF, T1.NotaFiscalNumero, COALESCE( T2.NotaFiscalStatus, '') AS NotaFiscalStatus, COALESCE( T3.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItens_F, COALESCE( T4.NotaFiscalQuantidadeDeItensVendidos_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F, COALESCE( T4.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T3.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F FROM (((NotaFiscal T1 LEFT JOIN (SELECT CASE  WHEN COALESCE( T6.NotaFiscalQuantidadeDeItensVendidos_F, 0) = COALESCE( T7.NotaFiscalQuantidadeDeItensVendidos_F, 0) THEN 'Completo' ELSE 'Parcial' END AS NotaFiscalStatus, T5.NotaFiscalId FROM ((NotaFiscal T5 LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T5.NotaFiscalId = NotaFiscalId) AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T6 ON T6.NotaFiscalId = T5.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T5.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T7 ON T7.NotaFiscalId = T5.NotaFiscalId) ) T2 ON T2.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE T1.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T3 ON T3.NotaFiscalId = T1.NotaFiscalId) LEFT JOIN LATERAL (SELECT NotaFiscalId, SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, COUNT(*) AS NotaFiscalQuantidadeDeItensVendidos_F FROM NotaFiscalItem WHERE (T1.NotaFiscalId = NotaFiscalId)";
         scmdbuf += " AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T4 ON T4.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "(:AV21TFNoCount <= 0 or ( "+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV21TFNotaFiscalStatus_Sels, "COALESCE( T2.NotaFiscalStatus, '') IN (", ")")+"))");
         if ( ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "NOTAFISCALUF") == 0 ) && ( ! (0==AV46NotaFiscalUF1) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV46NotaFiscalUF1)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( AV47DynamicFiltersEnabled2 && ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "NOTAFISCALUF") == 0 ) && ( ! (0==AV49NotaFiscalUF2) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV49NotaFiscalUF2)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( AV50DynamicFiltersEnabled3 && ( StringUtil.StrCmp(AV51DynamicFiltersSelector3, "NOTAFISCALUF") == 0 ) && ( ! (0==AV52NotaFiscalUF3) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalUF = :AV52NotaFiscalUF3)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFNotaFiscalNumero_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFNotaFiscalNumero)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero like :lV10TFNotaFiscalNumero)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFNotaFiscalNumero_Sel)) && ! ( StringUtil.StrCmp(AV11TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero = ( :AV11TFNotaFiscalNumero_Sel))");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( StringUtil.StrCmp(AV11TFNotaFiscalNumero_Sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalNumero))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NotaFiscalId";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00DG7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] );
               case 1 :
                     return conditional_P00DG13(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] );
               case 2 :
                     return conditional_P00DG19(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] );
               case 3 :
                     return conditional_P00DG25(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] );
               case 4 :
                     return conditional_P00DG31(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DG7;
          prmP00DG7 = new Object[] {
          new ParDef("AV21TFNoCount",GXType.Int32,9,0) ,
          new ParDef("AV46NotaFiscalUF1",GXType.Int16,4,0) ,
          new ParDef("AV49NotaFiscalUF2",GXType.Int16,4,0) ,
          new ParDef("AV52NotaFiscalUF3",GXType.Int16,4,0) ,
          new ParDef("lV10TFNotaFiscalNumero",GXType.VarChar,40,0) ,
          new ParDef("AV11TFNotaFiscalNumero_Sel",GXType.VarChar,40,0)
          };
          Object[] prmP00DG13;
          prmP00DG13 = new Object[] {
          new ParDef("AV21TFNoCount",GXType.Int32,9,0) ,
          new ParDef("AV46NotaFiscalUF1",GXType.Int16,4,0) ,
          new ParDef("AV49NotaFiscalUF2",GXType.Int16,4,0) ,
          new ParDef("AV52NotaFiscalUF3",GXType.Int16,4,0) ,
          new ParDef("lV10TFNotaFiscalNumero",GXType.VarChar,40,0) ,
          new ParDef("AV11TFNotaFiscalNumero_Sel",GXType.VarChar,40,0)
          };
          Object[] prmP00DG19;
          prmP00DG19 = new Object[] {
          new ParDef("AV21TFNoCount",GXType.Int32,9,0) ,
          new ParDef("AV46NotaFiscalUF1",GXType.Int16,4,0) ,
          new ParDef("AV49NotaFiscalUF2",GXType.Int16,4,0) ,
          new ParDef("AV52NotaFiscalUF3",GXType.Int16,4,0) ,
          new ParDef("lV10TFNotaFiscalNumero",GXType.VarChar,40,0) ,
          new ParDef("AV11TFNotaFiscalNumero_Sel",GXType.VarChar,40,0)
          };
          Object[] prmP00DG25;
          prmP00DG25 = new Object[] {
          new ParDef("AV21TFNoCount",GXType.Int32,9,0) ,
          new ParDef("AV46NotaFiscalUF1",GXType.Int16,4,0) ,
          new ParDef("AV49NotaFiscalUF2",GXType.Int16,4,0) ,
          new ParDef("AV52NotaFiscalUF3",GXType.Int16,4,0) ,
          new ParDef("lV10TFNotaFiscalNumero",GXType.VarChar,40,0) ,
          new ParDef("AV11TFNotaFiscalNumero_Sel",GXType.VarChar,40,0)
          };
          Object[] prmP00DG31;
          prmP00DG31 = new Object[] {
          new ParDef("AV21TFNoCount",GXType.Int32,9,0) ,
          new ParDef("AV46NotaFiscalUF1",GXType.Int16,4,0) ,
          new ParDef("AV49NotaFiscalUF2",GXType.Int16,4,0) ,
          new ParDef("AV52NotaFiscalUF3",GXType.Int16,4,0) ,
          new ParDef("lV10TFNotaFiscalNumero",GXType.VarChar,40,0) ,
          new ParDef("AV11TFNotaFiscalNumero_Sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DG7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DG13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG13,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DG19", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG19,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DG25", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG25,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DG31", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DG31,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(8);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((short[]) buf[8])[0] = rslt.getShort(6);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(8);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((short[]) buf[8])[0] = rslt.getShort(6);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(8);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((short[]) buf[8])[0] = rslt.getShort(6);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(8);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((short[]) buf[8])[0] = rslt.getShort(6);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(8);
                return;
       }
    }

 }

}
