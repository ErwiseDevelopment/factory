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
   public class prnewarquivo : GXProcedure
   {
      public prnewarquivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prnewarquivo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ArquivoBlob ,
                           string aP1_ContratoNome ,
                           out int aP2_ArquivoId ,
                           out SdtSdErro aP3_SdErro )
      {
         this.AV9ArquivoBlob = aP0_ArquivoBlob;
         this.AV10ContratoNome = aP1_ContratoNome;
         this.AV13ArquivoId = 0 ;
         this.AV12SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP2_ArquivoId=this.AV13ArquivoId;
         aP3_SdErro=this.AV12SdErro;
      }

      public SdtSdErro executeUdp( string aP0_ArquivoBlob ,
                                   string aP1_ContratoNome ,
                                   out int aP2_ArquivoId )
      {
         execute(aP0_ArquivoBlob, aP1_ContratoNome, out aP2_ArquivoId, out aP3_SdErro);
         return AV12SdErro ;
      }

      public void executeSubmit( string aP0_ArquivoBlob ,
                                 string aP1_ContratoNome ,
                                 out int aP2_ArquivoId ,
                                 out SdtSdErro aP3_SdErro )
      {
         this.AV9ArquivoBlob = aP0_ArquivoBlob;
         this.AV10ContratoNome = aP1_ContratoNome;
         this.AV13ArquivoId = 0 ;
         this.AV12SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP2_ArquivoId=this.AV13ArquivoId;
         aP3_SdErro=this.AV12SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12SdErro = new SdtSdErro(context);
         AV12SdErro.gxTpr_Status = 200;
         AV8Arquivo = new SdtArquivo(context);
         AV8Arquivo.gxTpr_Arquivoblob = AV9ArquivoBlob;
         AV8Arquivo.gxTpr_Arquivoextensao = "pdf";
         AV8Arquivo.gxTpr_Arquivonome = AV10ContratoNome;
         AV8Arquivo.Save();
         if ( AV8Arquivo.Fail() )
         {
            AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV8Arquivo.GetMessages().Item(1)).gxTpr_Description;
            AV12SdErro.gxTpr_Msg = AV11Message;
            AV12SdErro.gxTpr_Status = 401;
            AV12SdErro.gxTpr_Internalcode = 1;
            cleanup();
            if (true) return;
         }
         else
         {
            AV13ArquivoId = AV8Arquivo.gxTpr_Arquivoid;
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
         AV12SdErro = new SdtSdErro(context);
         AV8Arquivo = new SdtArquivo(context);
         AV11Message = "";
         /* GeneXus formulas. */
      }

      private int AV13ArquivoId ;
      private string AV10ContratoNome ;
      private string AV11Message ;
      private string AV9ArquivoBlob ;
      private SdtSdErro AV12SdErro ;
      private SdtArquivo AV8Arquivo ;
      private int aP2_ArquivoId ;
      private SdtSdErro aP3_SdErro ;
   }

}
