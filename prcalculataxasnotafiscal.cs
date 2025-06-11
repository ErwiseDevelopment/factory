using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class prcalculataxasnotafiscal : GXProcedure
   {
      public prcalculataxasnotafiscal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcalculataxasnotafiscal( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_JSON ,
                           short aP1_Taxa ,
                           decimal aP2_TaxaAnual ,
                           out GXBaseCollection<SdtSdParcelaCalculadaTaxa> aP3_Array_SdParcelaCalculadaTaxa )
      {
         this.AV21JSON = aP0_JSON;
         this.AV14Taxa = aP1_Taxa;
         this.AV15TaxaAnual = aP2_TaxaAnual;
         this.AV10Array_SdParcelaCalculadaTaxa = new GXBaseCollection<SdtSdParcelaCalculadaTaxa>( context, "SdParcelaCalculadaTaxa", "Factory21") ;
         initialize();
         ExecuteImpl();
         aP3_Array_SdParcelaCalculadaTaxa=this.AV10Array_SdParcelaCalculadaTaxa;
      }

      public GXBaseCollection<SdtSdParcelaCalculadaTaxa> executeUdp( string aP0_JSON ,
                                                                     short aP1_Taxa ,
                                                                     decimal aP2_TaxaAnual )
      {
         execute(aP0_JSON, aP1_Taxa, aP2_TaxaAnual, out aP3_Array_SdParcelaCalculadaTaxa);
         return AV10Array_SdParcelaCalculadaTaxa ;
      }

      public void executeSubmit( string aP0_JSON ,
                                 short aP1_Taxa ,
                                 decimal aP2_TaxaAnual ,
                                 out GXBaseCollection<SdtSdParcelaCalculadaTaxa> aP3_Array_SdParcelaCalculadaTaxa )
      {
         this.AV21JSON = aP0_JSON;
         this.AV14Taxa = aP1_Taxa;
         this.AV15TaxaAnual = aP2_TaxaAnual;
         this.AV10Array_SdParcelaCalculadaTaxa = new GXBaseCollection<SdtSdParcelaCalculadaTaxa>( context, "SdParcelaCalculadaTaxa", "Factory21") ;
         SubmitImpl();
         aP3_Array_SdParcelaCalculadaTaxa=this.AV10Array_SdParcelaCalculadaTaxa;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Array_SdNotaFiscal.FromJSonString(AV21JSON, null);
         AV10Array_SdParcelaCalculadaTaxa = new GXBaseCollection<SdtSdParcelaCalculadaTaxa>( context, "SdParcelaCalculadaTaxa", "Factory21");
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV9Array_SdNotaFiscal.Count )
         {
            AV8SdNotaFiscal = ((SdtSdNotaFiscal)AV9Array_SdNotaFiscal.Item(AV28GXV1));
            AV29GXV2 = 1;
            while ( AV29GXV2 <= AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Cobr.gxTpr_Dup.Count )
            {
               AV12ItemParcelasNota = ((SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem)AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Cobr.gxTpr_Dup.Item(AV29GXV2));
               AV16DataVencimento = context.localUtil.YMDToD( (int)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV12ItemParcelasNota.gxTpr_Dvenc, 1, 4), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV12ItemParcelasNota.gxTpr_Dvenc, 6, 2), "."), 18, MidpointRounding.ToEven)), (int)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV12ItemParcelasNota.gxTpr_Dvenc, 9, 2), "."), 18, MidpointRounding.ToEven)));
               AV20Dias = (short)(DateTimeUtil.DDiff(AV16DataVencimento,Gx_date));
               AV23TaxaDiaria = (decimal)(AV15TaxaAnual/ (decimal)(365));
               AV25Valor = NumberUtil.Val( AV12ItemParcelasNota.gxTpr_Vdup, ".");
               AV27TaxaParcela = (decimal)((AV23TaxaDiaria*AV20Dias));
               AV24TaxaValor = (decimal)(AV25Valor*(AV27TaxaParcela/ (decimal)(100)));
               AV26TaxaAdminValor = (decimal)(AV25Valor*(AV14Taxa/ (decimal)(100)));
               AV11SdParcelaCalculadaTaxa = new SdtSdParcelaCalculadaTaxa(context);
               AV11SdParcelaCalculadaTaxa.gxTpr_Parcela = AV12ItemParcelasNota.gxTpr_Ndup;
               AV11SdParcelaCalculadaTaxa.gxTpr_Vencimento = AV16DataVencimento;
               AV11SdParcelaCalculadaTaxa.gxTpr_Valorbase = NumberUtil.Val( AV12ItemParcelasNota.gxTpr_Vdup, ".");
               AV11SdParcelaCalculadaTaxa.gxTpr_Jurosvalor = AV24TaxaValor;
               AV11SdParcelaCalculadaTaxa.gxTpr_Jurospercentual = AV27TaxaParcela;
               AV11SdParcelaCalculadaTaxa.gxTpr_Taxavalor = AV26TaxaAdminValor;
               AV11SdParcelaCalculadaTaxa.gxTpr_Taxapercentual = (decimal)(AV14Taxa);
               AV11SdParcelaCalculadaTaxa.gxTpr_Valortotal = (decimal)(AV25Valor-AV24TaxaValor-AV26TaxaAdminValor);
               AV11SdParcelaCalculadaTaxa.gxTpr_Dias = AV20Dias;
               AV11SdParcelaCalculadaTaxa.gxTpr_Notafiscalnumero = AV8SdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Nnf;
               AV10Array_SdParcelaCalculadaTaxa.Add(AV11SdParcelaCalculadaTaxa, 0);
               AV29GXV2 = (int)(AV29GXV2+1);
            }
            AV28GXV1 = (int)(AV28GXV1+1);
         }
         cleanup();
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
         AV10Array_SdParcelaCalculadaTaxa = new GXBaseCollection<SdtSdParcelaCalculadaTaxa>( context, "SdParcelaCalculadaTaxa", "Factory21");
         AV9Array_SdNotaFiscal = new GXBaseCollection<SdtSdNotaFiscal>( context, "SdNotaFiscal", "Factory21");
         AV8SdNotaFiscal = new SdtSdNotaFiscal(context);
         AV12ItemParcelasNota = new SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem(context);
         AV16DataVencimento = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         AV11SdParcelaCalculadaTaxa = new SdtSdParcelaCalculadaTaxa(context);
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV14Taxa ;
      private short AV20Dias ;
      private int AV28GXV1 ;
      private int AV29GXV2 ;
      private decimal AV15TaxaAnual ;
      private decimal AV23TaxaDiaria ;
      private decimal AV25Valor ;
      private decimal AV27TaxaParcela ;
      private decimal AV24TaxaValor ;
      private decimal AV26TaxaAdminValor ;
      private DateTime AV16DataVencimento ;
      private DateTime Gx_date ;
      private string AV21JSON ;
      private GXBaseCollection<SdtSdParcelaCalculadaTaxa> AV10Array_SdParcelaCalculadaTaxa ;
      private GXBaseCollection<SdtSdNotaFiscal> AV9Array_SdNotaFiscal ;
      private SdtSdNotaFiscal AV8SdNotaFiscal ;
      private SdtSdNotaFiscal_NFe_infNFe_cobr_dupItem AV12ItemParcelasNota ;
      private SdtSdParcelaCalculadaTaxa AV11SdParcelaCalculadaTaxa ;
      private GXBaseCollection<SdtSdParcelaCalculadaTaxa> aP3_Array_SdParcelaCalculadaTaxa ;
   }

}
