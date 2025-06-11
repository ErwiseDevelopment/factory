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
   public class unittime : GXProcedure
   {
      public unittime( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public unittime( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( DateTime aP0_DateTime ,
                           out long aP1_UnitTime )
      {
         this.AV8DateTime = aP0_DateTime;
         this.AV9UnitTime = 0 ;
         initialize();
         ExecuteImpl();
         aP1_UnitTime=this.AV9UnitTime;
      }

      public long executeUdp( DateTime aP0_DateTime )
      {
         execute(aP0_DateTime, out aP1_UnitTime);
         return AV9UnitTime ;
      }

      public void executeSubmit( DateTime aP0_DateTime ,
                                 out long aP1_UnitTime )
      {
         this.AV8DateTime = aP0_DateTime;
         this.AV9UnitTime = 0 ;
         SubmitImpl();
         aP1_UnitTime=this.AV9UnitTime;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10DifDateTime = context.localUtil.YMDHMSToT( 1970, 1, 1, 0, 0, 0);
         AV9UnitTime = (long)(DateTimeUtil.TDiff( AV8DateTime, AV10DifDateTime));
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
         AV10DifDateTime = (DateTime)(DateTime.MinValue);
         /* GeneXus formulas. */
      }

      private long AV9UnitTime ;
      private DateTime AV8DateTime ;
      private DateTime AV10DifDateTime ;
      private long aP1_UnitTime ;
   }

}
