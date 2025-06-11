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
namespace GeneXus.Programs.workwithplus {
   public class awwp_parameter_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new workwithplus.awwp_parameter_dataprovider().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> aP0_Gxm1rootcol = new GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter>()  ;
         execute(out aP0_Gxm1rootcol);
         return GX.GXRuntime.ExitCode ;
      }

      public awwp_parameter_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public awwp_parameter_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> aP0_Gxm1rootcol )
      {
         this.Gxm1rootcol = new GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter>( context, "WWP_Parameter", "Factory21") ;
         initialize();
         ExecuteImpl();
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      public GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> executeUdp( )
      {
         execute(out aP0_Gxm1rootcol);
         return Gxm1rootcol ;
      }

      public void executeSubmit( out GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> aP0_Gxm1rootcol )
      {
         this.Gxm1rootcol = new GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter>( context, "WWP_Parameter", "Factory21") ;
         SubmitImpl();
         aP0_Gxm1rootcol=this.Gxm1rootcol;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
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
         /* GeneXus formulas. */
      }

      private GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> Gxm1rootcol ;
      private GXBCCollection<GeneXus.Programs.workwithplus.SdtWWP_Parameter> aP0_Gxm1rootcol ;
   }

}
