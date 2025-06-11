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
   public class prtrocataghtml : GXProcedure
   {
      public prtrocataghtml( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prtrocataghtml( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_PropostaId ,
                           int aP1_ContratoId ,
                           ref string aP2_HTMl )
      {
         this.AV12PropostaId = aP0_PropostaId;
         this.AV13ContratoId = aP1_ContratoId;
         this.AV10HTMl = aP2_HTMl;
         initialize();
         ExecuteImpl();
         aP2_HTMl=this.AV10HTMl;
      }

      public string executeUdp( int aP0_PropostaId ,
                                int aP1_ContratoId )
      {
         execute(aP0_PropostaId, aP1_ContratoId, ref aP2_HTMl);
         return AV10HTMl ;
      }

      public void executeSubmit( int aP0_PropostaId ,
                                 int aP1_ContratoId ,
                                 ref string aP2_HTMl )
      {
         this.AV12PropostaId = aP0_PropostaId;
         this.AV13ContratoId = aP1_ContratoId;
         this.AV10HTMl = aP2_HTMl;
         SubmitImpl();
         aP2_HTMl=this.AV10HTMl;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prprocuratags(context ).execute(  AV10HTMl, out  AV8Array_SDMapearTags) ;
         new pralimentatags(context ).execute(  AV12PropostaId,  AV13ContratoId,  AV8Array_SDMapearTags, out  AV9SdtListaTags) ;
         new prtags(context ).execute(  AV9SdtListaTags, ref  AV10HTMl) ;
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
         AV8Array_SDMapearTags = new GXBaseCollection<SdtSdMapearTags>( context, "SdMapearTags", "Factory21");
         AV9SdtListaTags = new SdtSdtListaTags(context);
         /* GeneXus formulas. */
      }

      private int AV12PropostaId ;
      private int AV13ContratoId ;
      private string AV10HTMl ;
      private string aP2_HTMl ;
      private GXBaseCollection<SdtSdMapearTags> AV8Array_SDMapearTags ;
      private SdtSdtListaTags AV9SdtListaTags ;
   }

}
