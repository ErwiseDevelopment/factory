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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prsendsignaturewithcontract : GXProcedure
   {
      public prsendsignaturewithcontract( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prsendsignaturewithcontract( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ArquivoBlob ,
                           int aP1_ContratoId ,
                           GXBaseCollection<SdtSdParticipantes> aP2_Array_SdParticipantes ,
                           out SdtSdErro aP3_SdErro )
      {
         this.AV8ArquivoBlob = aP0_ArquivoBlob;
         this.AV15ContratoId = aP1_ContratoId;
         this.AV17Array_SdParticipantes = aP2_Array_SdParticipantes;
         this.AV10SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP3_SdErro=this.AV10SdErro;
      }

      public SdtSdErro executeUdp( string aP0_ArquivoBlob ,
                                   int aP1_ContratoId ,
                                   GXBaseCollection<SdtSdParticipantes> aP2_Array_SdParticipantes )
      {
         execute(aP0_ArquivoBlob, aP1_ContratoId, aP2_Array_SdParticipantes, out aP3_SdErro);
         return AV10SdErro ;
      }

      public void executeSubmit( string aP0_ArquivoBlob ,
                                 int aP1_ContratoId ,
                                 GXBaseCollection<SdtSdParticipantes> aP2_Array_SdParticipantes ,
                                 out SdtSdErro aP3_SdErro )
      {
         this.AV8ArquivoBlob = aP0_ArquivoBlob;
         this.AV15ContratoId = aP1_ContratoId;
         this.AV17Array_SdParticipantes = aP2_Array_SdParticipantes;
         this.AV10SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP3_SdErro=this.AV10SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new prnewarquivo(context ).execute(  AV8ArquivoBlob,  AV9ContratoNome, out  AV14ArquivoId, out  AV10SdErro) ;
         if ( AV10SdErro.gxTpr_Status != 200 )
         {
            cleanup();
            if (true) return;
         }
         new prnewassinatura(context ).execute(  AV15ContratoId,  AV14ArquivoId, out  AV16AssinaturaId, out  AV10SdErro) ;
         if ( AV10SdErro.gxTpr_Status != 200 )
         {
            cleanup();
            if (true) return;
         }
         new prnewassinaturaparticipantes(context ).execute(  AV16AssinaturaId,  AV17Array_SdParticipantes, out  AV10SdErro) ;
         if ( AV10SdErro.gxTpr_Status != 200 )
         {
            cleanup();
            if (true) return;
         }
         else
         {
            context.CommitDataStores("prsendsignaturewithcontract",pr_default);
         }
         AV19BaseUrl = AV18HTTPREQUEST.BaseURL;
         new prsendemailsignature(context).executeSubmit(  AV16AssinaturaId,  AV19BaseUrl) ;
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
         AV9ContratoNome = "";
         AV19BaseUrl = "";
         AV18HTTPREQUEST = new GxHttpRequest( context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prsendsignaturewithcontract__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV15ContratoId ;
      private int AV14ArquivoId ;
      private long AV16AssinaturaId ;
      private string AV9ContratoNome ;
      private string AV19BaseUrl ;
      private string AV8ArquivoBlob ;
      private GxHttpRequest AV18HTTPREQUEST ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSdParticipantes> AV17Array_SdParticipantes ;
      private SdtSdErro AV10SdErro ;
      private IDataStoreProvider pr_default ;
      private SdtSdErro aP3_SdErro ;
   }

   public class prsendsignaturewithcontract__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
