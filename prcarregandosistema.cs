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
   public class prcarregandosistema : GXProcedure
   {
      public prcarregandosistema( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcarregandosistema( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_objcol_SdtSdBanco_Banco1 = AV8SdBanco;
         new dpbanco(context ).execute( out  GXt_objcol_SdtSdBanco_Banco1) ;
         AV8SdBanco = GXt_objcol_SdtSdBanco_Banco1;
         AV17GXV1 = 1;
         while ( AV17GXV1 <= AV8SdBanco.Count )
         {
            AV9SdBancoBanco = ((SdtSdBanco_Banco)AV8SdBanco.Item(AV17GXV1));
            AV10Banco = new SdtBanco(context);
            AV10Banco.gxTpr_Bancocodigo = AV9SdBancoBanco.gxTpr_Bancocodigo;
            AV10Banco.gxTpr_Banconome = AV9SdBancoBanco.gxTpr_Banconome;
            AV10Banco.Save();
            AV12ProgressIndicator.gxTpr_Value = (int)(Math.Round((AV13I/ (decimal)(AV11Total))/ (decimal)(100)-1, 18, MidpointRounding.ToEven));
            AV17GXV1 = (int)(AV17GXV1+1);
         }
         AV12ProgressIndicator.gxTpr_Value = 100;
         context.CommitDataStores("prcarregandosistema",pr_default);
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
         AV8SdBanco = new GXBaseCollection<SdtSdBanco_Banco>( context, "Banco", "Factory21");
         GXt_objcol_SdtSdBanco_Banco1 = new GXBaseCollection<SdtSdBanco_Banco>( context, "Banco", "Factory21");
         AV9SdBancoBanco = new SdtSdBanco_Banco(context);
         AV10Banco = new SdtBanco(context);
         AV12ProgressIndicator = new GeneXus.Core.genexus.common.ui.SdtProgress(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prcarregandosistema__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13I ;
      private short AV11Total ;
      private int AV17GXV1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSdBanco_Banco> AV8SdBanco ;
      private GXBaseCollection<SdtSdBanco_Banco> GXt_objcol_SdtSdBanco_Banco1 ;
      private SdtSdBanco_Banco AV9SdBancoBanco ;
      private SdtBanco AV10Banco ;
      private GeneXus.Core.genexus.common.ui.SdtProgress AV12ProgressIndicator ;
      private IDataStoreProvider pr_default ;
   }

   public class prcarregandosistema__default : DataStoreHelperBase, IDataStoreHelper
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
