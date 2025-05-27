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
   public class prcriartitulo : GXProcedure
   {
      public prcriartitulo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcriartitulo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref SdtSdTitulo aP0_SdTitulo ,
                           out SdtSdErro aP1_SdErro )
      {
         this.AV8SdTitulo = aP0_SdTitulo;
         this.AV9SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP0_SdTitulo=this.AV8SdTitulo;
         aP1_SdErro=this.AV9SdErro;
      }

      public SdtSdErro executeUdp( ref SdtSdTitulo aP0_SdTitulo )
      {
         execute(ref aP0_SdTitulo, out aP1_SdErro);
         return AV9SdErro ;
      }

      public void executeSubmit( ref SdtSdTitulo aP0_SdTitulo ,
                                 out SdtSdErro aP1_SdErro )
      {
         this.AV8SdTitulo = aP0_SdTitulo;
         this.AV9SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP0_SdTitulo=this.AV8SdTitulo;
         aP1_SdErro=this.AV9SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Titulo = new SdtTitulo(context);
         AV9SdErro = new SdtSdErro(context);
         AV10Titulo.gxTpr_Tituloclienteid = AV8SdTitulo.gxTpr_Clienteid;
         AV10Titulo.gxTpr_Titulovalor = AV8SdTitulo.gxTpr_Titulovalor;
         AV10Titulo.gxTpr_Titulodesconto = AV8SdTitulo.gxTpr_Titulodesconto;
         AV10Titulo.gxTpr_Titulodeleted = false;
         AV10Titulo.gxTpr_Titulovencimento = AV8SdTitulo.gxTpr_Titulovencimento;
         AV10Titulo.gxTpr_Titulocompetenciaano = AV8SdTitulo.gxTpr_Titulocompetenciaano;
         AV10Titulo.gxTpr_Titulocompetenciames = AV8SdTitulo.gxTpr_Titulocompetenciames;
         AV10Titulo.gxTpr_Tituloprorrogacao = AV8SdTitulo.gxTpr_Tituloprorrogacao;
         AV10Titulo.gxTpr_Titulocep = AV8SdTitulo.gxTpr_Titulocep;
         AV10Titulo.gxTpr_Titulologradouro = AV8SdTitulo.gxTpr_Titulologradouro;
         AV10Titulo.gxTpr_Titulocomplemento = AV8SdTitulo.gxTpr_Titulocomplemento;
         AV10Titulo.gxTpr_Titulobairro = AV8SdTitulo.gxTpr_Titulobairro;
         AV10Titulo.gxTpr_Titulomunicipio = AV8SdTitulo.gxTpr_Titulomunicipio;
         AV10Titulo.gxTpr_Titulotipo = AV8SdTitulo.gxTpr_Titulotipo;
         AV10Titulo.gxTpr_Titulopropostaid = AV8SdTitulo.gxTpr_Propostaid;
         AV10Titulo.gxTpr_Contaid = AV8SdTitulo.gxTpr_Contaid;
         AV10Titulo.gxTpr_Categoriatituloid = AV8SdTitulo.gxTpr_Categoriatituloid;
         AV10Titulo.gxTpr_Titulopropostatipo = AV8SdTitulo.gxTpr_Titulopropostatipo;
         AV10Titulo.gxTpr_Notafiscalparcelamentoid = AV8SdTitulo.gxTpr_Notafiscalparcelamentoid;
         AV10Titulo.Save();
         if ( AV10Titulo.Fail() )
         {
            AV9SdErro.gxTpr_Status = 403;
            AV9SdErro.gxTpr_Internalcode = 1;
            AV9SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV10Titulo.GetMessages().Item(1)).gxTpr_Description;
         }
         else
         {
            AV8SdTitulo.gxTpr_Tituloid = AV10Titulo.gxTpr_Tituloid;
            AV9SdErro.gxTpr_Status = 200;
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
         AV9SdErro = new SdtSdErro(context);
         AV10Titulo = new SdtTitulo(context);
         /* GeneXus formulas. */
      }

      private SdtSdTitulo AV8SdTitulo ;
      private SdtSdTitulo aP0_SdTitulo ;
      private SdtSdErro AV9SdErro ;
      private SdtTitulo AV10Titulo ;
      private SdtSdErro aP1_SdErro ;
   }

}
