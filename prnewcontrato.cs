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
   public class prnewcontrato : GXProcedure
   {
      public prnewcontrato( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prnewcontrato( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ContratoNome ,
                           out int aP1_ContratoId ,
                           int aP2_ClienteId ,
                           out SdtSdErro aP3_SdErro )
      {
         this.AV10ContratoNome = aP0_ContratoNome;
         this.AV12ContratoId = 0 ;
         this.AV14ClienteId = aP2_ClienteId;
         this.AV11SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP1_ContratoId=this.AV12ContratoId;
         aP3_SdErro=this.AV11SdErro;
      }

      public SdtSdErro executeUdp( string aP0_ContratoNome ,
                                   out int aP1_ContratoId ,
                                   int aP2_ClienteId )
      {
         execute(aP0_ContratoNome, out aP1_ContratoId, aP2_ClienteId, out aP3_SdErro);
         return AV11SdErro ;
      }

      public void executeSubmit( string aP0_ContratoNome ,
                                 out int aP1_ContratoId ,
                                 int aP2_ClienteId ,
                                 out SdtSdErro aP3_SdErro )
      {
         this.AV10ContratoNome = aP0_ContratoNome;
         this.AV12ContratoId = 0 ;
         this.AV14ClienteId = aP2_ClienteId;
         this.AV11SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP1_ContratoId=this.AV12ContratoId;
         aP3_SdErro=this.AV11SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11SdErro = new SdtSdErro(context);
         AV11SdErro.gxTpr_Status = 200;
         AV8Contrato = new SdtContrato(context);
         AV8Contrato.gxTpr_Contratonome = AV10ContratoNome;
         AV8Contrato.gxTpr_Contratoclienteid = AV14ClienteId;
         AV8Contrato.Save();
         if ( AV8Contrato.Fail() )
         {
            AV9Message = ((GeneXus.Utils.SdtMessages_Message)AV8Contrato.GetMessages().Item(1)).gxTpr_Description;
            AV11SdErro.gxTpr_Msg = AV9Message;
            AV11SdErro.gxTpr_Status = 401;
            AV11SdErro.gxTpr_Internalcode = 1;
            cleanup();
            if (true) return;
         }
         else
         {
            AV12ContratoId = AV8Contrato.gxTpr_Contratoid;
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
         AV11SdErro = new SdtSdErro(context);
         AV8Contrato = new SdtContrato(context);
         AV9Message = "";
         /* GeneXus formulas. */
      }

      private int AV12ContratoId ;
      private int AV14ClienteId ;
      private string AV10ContratoNome ;
      private string AV9Message ;
      private SdtSdErro AV11SdErro ;
      private SdtContrato AV8Contrato ;
      private int aP1_ContratoId ;
      private SdtSdErro aP3_SdErro ;
   }

}
