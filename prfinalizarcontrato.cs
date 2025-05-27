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
   public class prfinalizarcontrato : GXProcedure
   {
      public prfinalizarcontrato( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public prfinalizarcontrato( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_AssinaturaId ,
                           string aP1_BaseUrl ,
                           out SdtSdErro aP2_SdErro )
      {
         this.AV2AssinaturaId = aP0_AssinaturaId;
         this.AV3BaseUrl = aP1_BaseUrl;
         this.AV4SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP2_SdErro=this.AV4SdErro;
      }

      public SdtSdErro executeUdp( long aP0_AssinaturaId ,
                                   string aP1_BaseUrl )
      {
         execute(aP0_AssinaturaId, aP1_BaseUrl, out aP2_SdErro);
         return AV4SdErro ;
      }

      public void executeSubmit( long aP0_AssinaturaId ,
                                 string aP1_BaseUrl ,
                                 out SdtSdErro aP2_SdErro )
      {
         this.AV2AssinaturaId = aP0_AssinaturaId;
         this.AV3BaseUrl = aP1_BaseUrl;
         this.AV4SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP2_SdErro=this.AV4SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(long)AV2AssinaturaId,(string)AV3BaseUrl,(SdtSdErro)AV4SdErro} ;
         ClassLoader.Execute("aprfinalizarcontrato","GeneXus.Programs","aprfinalizarcontrato", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 3 ) )
         {
            AV4SdErro = (SdtSdErro)(args[2]) ;
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
      }

      public override void initialize( )
      {
         AV4SdErro = new SdtSdErro(context);
         /* GeneXus formulas. */
      }

      private long AV2AssinaturaId ;
      private string AV3BaseUrl ;
      private IGxDataStore dsDefault ;
      private SdtSdErro AV4SdErro ;
      private Object[] args ;
      private SdtSdErro aP2_SdErro ;
   }

}
