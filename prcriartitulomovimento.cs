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
   public class prcriartitulomovimento : GXProcedure
   {
      public prcriartitulomovimento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcriartitulomovimento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtSdTituloMovimento aP0_SdTituloMovimento ,
                           out SdtSdErro aP1_SdErro )
      {
         this.AV9SdTituloMovimento = aP0_SdTituloMovimento;
         this.AV10SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP1_SdErro=this.AV10SdErro;
      }

      public SdtSdErro executeUdp( SdtSdTituloMovimento aP0_SdTituloMovimento )
      {
         execute(aP0_SdTituloMovimento, out aP1_SdErro);
         return AV10SdErro ;
      }

      public void executeSubmit( SdtSdTituloMovimento aP0_SdTituloMovimento ,
                                 out SdtSdErro aP1_SdErro )
      {
         this.AV9SdTituloMovimento = aP0_SdTituloMovimento;
         this.AV10SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP1_SdErro=this.AV10SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8TituloMovimento = new SdtTituloMovimento(context);
         AV10SdErro = new SdtSdErro(context);
         AV8TituloMovimento = new SdtTituloMovimento(context);
         AV8TituloMovimento.gxTpr_Tipopagamentoid = AV9SdTituloMovimento.gxTpr_Tipopagamentoid;
         AV8TituloMovimento.gxTpr_Tituloid = AV9SdTituloMovimento.gxTpr_Tituloid;
         AV8TituloMovimento.gxTpr_Titulomovimentovalor = AV9SdTituloMovimento.gxTpr_Titulomovimentovalor;
         AV8TituloMovimento.gxTpr_Titulomovimentotipo = AV9SdTituloMovimento.gxTpr_Titulomovimentotipo;
         AV8TituloMovimento.gxTpr_Titulomovimentosoma = AV9SdTituloMovimento.gxTpr_Titulomovimentosoma;
         AV8TituloMovimento.gxTpr_Titulomovimentodatacredito = AV9SdTituloMovimento.gxTpr_Titulomovimentodatacredito;
         AV8TituloMovimento.gxTpr_Titulomovimentocreatedat = DateTimeUtil.ServerNow( context, pr_default);
         AV8TituloMovimento.gxTpr_Titulomovimentoupdatedat = DateTimeUtil.ServerNow( context, pr_default);
         AV8TituloMovimento.gxTpr_Titulomovimentoope = AV9SdTituloMovimento.gxTpr_Titulomovimentoope;
         AV8TituloMovimento.gxTpr_Titulomovimentoconta = AV9SdTituloMovimento.gxTpr_Titulomovimentoconta;
         AV8TituloMovimento.Save();
         if ( AV8TituloMovimento.Fail() )
         {
            AV10SdErro.gxTpr_Status = 403;
            AV10SdErro.gxTpr_Internalcode = 1;
            AV10SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV8TituloMovimento.GetMessages().Item(1)).gxTpr_Description;
         }
         else
         {
            AV10SdErro.gxTpr_Status = 200;
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
         AV8TituloMovimento = new SdtTituloMovimento(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prcriartitulomovimento__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private IGxDataStore dsDefault ;
      private SdtSdTituloMovimento AV9SdTituloMovimento ;
      private SdtSdErro AV10SdErro ;
      private SdtTituloMovimento AV8TituloMovimento ;
      private IDataStoreProvider pr_default ;
      private SdtSdErro aP1_SdErro ;
   }

   public class prcriartitulomovimento__default : DataStoreHelperBase, IDataStoreHelper
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
