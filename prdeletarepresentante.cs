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
   public class prdeletarepresentante : GXProcedure
   {
      public prdeletarepresentante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prdeletarepresentante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_ClienteId ,
                           out SdtSdErro aP1_SdErro )
      {
         this.AV9ClienteId = aP0_ClienteId;
         this.AV10SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP1_SdErro=this.AV10SdErro;
      }

      public SdtSdErro executeUdp( int aP0_ClienteId )
      {
         execute(aP0_ClienteId, out aP1_SdErro);
         return AV10SdErro ;
      }

      public void executeSubmit( int aP0_ClienteId ,
                                 out SdtSdErro aP1_SdErro )
      {
         this.AV9ClienteId = aP0_ClienteId;
         this.AV10SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP1_SdErro=this.AV10SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10SdErro = new SdtSdErro(context);
         AV8Cliente.Load(AV9ClienteId);
         AV8Cliente.Delete();
         if ( AV8Cliente.Success() )
         {
            AV10SdErro.gxTpr_Msg = "Representante Excluido com sucesso!";
            AV10SdErro.gxTpr_Status = 204;
         }
         else
         {
            AV10SdErro.gxTpr_Status = 404;
            AV13GXV2 = 1;
            AV12GXV1 = AV8Cliente.GetMessages();
            while ( AV13GXV2 <= AV12GXV1.Count )
            {
               AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV12GXV1.Item(AV13GXV2));
               AV10SdErro.gxTpr_Msg = AV10SdErro.gxTpr_Msg+StringUtil.Trim( AV11Message.gxTpr_Description)+StringUtil.NewLine( );
               AV13GXV2 = (int)(AV13GXV2+1);
            }
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
         AV10SdErro = new SdtSdErro(context);
         AV8Cliente = new SdtCliente(context);
         AV12GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
         /* GeneXus formulas. */
      }

      private int AV9ClienteId ;
      private int AV13GXV2 ;
      private SdtSdErro AV10SdErro ;
      private SdtCliente AV8Cliente ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV12GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV11Message ;
      private SdtSdErro aP1_SdErro ;
   }

}
