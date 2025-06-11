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
   public class prcriarntitulomovimentos : GXProcedure
   {
      public prcriarntitulomovimentos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcriarntitulomovimentos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GXBaseCollection<SdtSdTituloMovimento> aP0_Array_SdTituloMovimento ,
                           out SdtSdErro aP1_SdErro )
      {
         this.AV9Array_SdTituloMovimento = aP0_Array_SdTituloMovimento;
         this.AV8SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP1_SdErro=this.AV8SdErro;
      }

      public SdtSdErro executeUdp( GXBaseCollection<SdtSdTituloMovimento> aP0_Array_SdTituloMovimento )
      {
         execute(aP0_Array_SdTituloMovimento, out aP1_SdErro);
         return AV8SdErro ;
      }

      public void executeSubmit( GXBaseCollection<SdtSdTituloMovimento> aP0_Array_SdTituloMovimento ,
                                 out SdtSdErro aP1_SdErro )
      {
         this.AV9Array_SdTituloMovimento = aP0_Array_SdTituloMovimento;
         this.AV8SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP1_SdErro=this.AV8SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11GXV1 = 1;
         while ( AV11GXV1 <= AV9Array_SdTituloMovimento.Count )
         {
            AV10SdTituloMovimento = ((SdtSdTituloMovimento)AV9Array_SdTituloMovimento.Item(AV11GXV1));
            new prcriartitulomovimento(context ).execute(  AV10SdTituloMovimento, out  AV8SdErro) ;
            if ( AV8SdErro.gxTpr_Status != 200 )
            {
               context.RollbackDataStores("prcriarntitulomovimentos",pr_default);
               cleanup();
               if (true) return;
            }
            AV11GXV1 = (int)(AV11GXV1+1);
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
         AV8SdErro = new SdtSdErro(context);
         AV10SdTituloMovimento = new SdtSdTituloMovimento(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prcriarntitulomovimentos__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV11GXV1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSdTituloMovimento> AV9Array_SdTituloMovimento ;
      private SdtSdErro AV8SdErro ;
      private SdtSdTituloMovimento AV10SdTituloMovimento ;
      private IDataStoreProvider pr_default ;
      private SdtSdErro aP1_SdErro ;
   }

   public class prcriarntitulomovimentos__default : DataStoreHelperBase, IDataStoreHelper
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
