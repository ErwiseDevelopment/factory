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
   public class prcalcularjurosmora : GXProcedure
   {
      public prcalcularjurosmora( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcalcularjurosmora( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_Date ,
                           short aP1_SLA ,
                           decimal aP2_Juros ,
                           decimal aP3_Valor ,
                           out decimal aP4_JurosValor )
      {
         this.AV8Date = aP0_Date;
         this.AV9SLA = aP1_SLA;
         this.AV14Juros = aP2_Juros;
         this.AV11Valor = aP3_Valor;
         this.AV10JurosValor = 0 ;
         initialize();
         ExecuteImpl();
         aP4_JurosValor=this.AV10JurosValor;
      }

      public decimal executeUdp( DateTime aP0_Date ,
                                 short aP1_SLA ,
                                 decimal aP2_Juros ,
                                 decimal aP3_Valor )
      {
         execute(aP0_Date, aP1_SLA, aP2_Juros, aP3_Valor, out aP4_JurosValor);
         return AV10JurosValor ;
      }

      public void executeSubmit( DateTime aP0_Date ,
                                 short aP1_SLA ,
                                 decimal aP2_Juros ,
                                 decimal aP3_Valor ,
                                 out decimal aP4_JurosValor )
      {
         this.AV8Date = aP0_Date;
         this.AV9SLA = aP1_SLA;
         this.AV14Juros = aP2_Juros;
         this.AV11Valor = aP3_Valor;
         this.AV10JurosValor = 0 ;
         SubmitImpl();
         aP4_JurosValor=this.AV10JurosValor;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! (DateTime.MinValue==AV8Date) )
         {
            AV12AuxDate = AV8Date;
            if ( DateTimeUtil.ResetTime ( AV12AuxDate ) < DateTimeUtil.ResetTime ( Gx_date ) )
            {
               AV13Diferenca = (long)(DateTimeUtil.DDiff(Gx_date,AV12AuxDate));
               AV15DiaJuros = (decimal)(AV14Juros/ (decimal)(30));
               AV16AplicadoJuros = (decimal)(AV15DiaJuros*AV13Diferenca);
               AV10JurosValor = (decimal)(AV11Valor*(AV16AplicadoJuros/ (decimal)(100)));
            }
            else
            {
               AV10JurosValor = 0;
            }
         }
         else
         {
            AV10JurosValor = 0;
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
         AV12AuxDate = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV9SLA ;
      private long AV13Diferenca ;
      private decimal AV14Juros ;
      private decimal AV11Valor ;
      private decimal AV10JurosValor ;
      private decimal AV15DiaJuros ;
      private decimal AV16AplicadoJuros ;
      private DateTime AV8Date ;
      private DateTime AV12AuxDate ;
      private DateTime Gx_date ;
      private decimal aP4_JurosValor ;
   }

}
