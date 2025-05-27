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
   public class acriapdfchavedatahora : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new acriapdfchavedatahora().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         execute();
         return GX.GXRuntime.ExitCode ;
      }

      public acriapdfchavedatahora( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public acriapdfchavedatahora( IGxContext context )
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
         /* Using cursor P005B2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A153SecUserTeste = P005B2_A153SecUserTeste[0];
            n153SecUserTeste = P005B2_n153SecUserTeste[0];
            A133SecUserId = P005B2_A133SecUserId[0];
            AV49HTML = A153SecUserTeste;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV59PathSource = "C:\\temp\\teste.pdf";
         new htmltopdf(context ).execute(  AV49HTML,  AV59PathSource) ;
         AV60CountPages = (short)(AV51PDFTools.pagecount(AV59PathSource));
         context.StatusMessage( StringUtil.Str( (decimal)(AV60CountPages), 4, 0) );
         AV63GUID = Guid.NewGuid( );
         AV64ServerNow = DateTimeUtil.ServerNow( context, pr_default);
         AV65String = StringUtil.Format( "%1", AV63GUID.ToString(), "", "", "", "", "", "", "", "");
         AV61i = 1;
         while ( AV61i <= AV60CountPages )
         {
            AV62PDFOut = "C:\\temp\\teste" + StringUtil.Trim( StringUtil.Str( (decimal)(AV61i), 4, 0)) + ".pdf";
            AV50result = AV51PDFTools.addtext(AV59PathSource, AV62PDFOut, 30, 16, AV61i, AV65String, 10);
            AV59PathSource = AV62PDFOut;
            AV62PDFOut = "C:\\temp\\data" + StringUtil.Trim( StringUtil.Str( (decimal)(AV61i), 4, 0)) + ".pdf";
            AV50result = AV51PDFTools.addtext(AV59PathSource, AV62PDFOut, 470, 830, AV61i, context.localUtil.Format( AV64ServerNow, "99/99/9999 99:99:99"), 12);
            AV59PathSource = AV62PDFOut;
            AV61i = (short)(AV61i+1);
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
         P005B2_A153SecUserTeste = new string[] {""} ;
         P005B2_n153SecUserTeste = new bool[] {false} ;
         P005B2_A133SecUserId = new short[1] ;
         A153SecUserTeste = "";
         AV49HTML = "";
         AV59PathSource = "";
         AV51PDFTools = new SdtPDFTools(context);
         AV63GUID = Guid.Empty;
         AV64ServerNow = (DateTime)(DateTime.MinValue);
         AV65String = "";
         AV62PDFOut = "";
         AV50result = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acriapdfchavedatahora__default(),
            new Object[][] {
                new Object[] {
               P005B2_A153SecUserTeste, P005B2_n153SecUserTeste, P005B2_A133SecUserId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A133SecUserId ;
      private short AV60CountPages ;
      private short AV61i ;
      private DateTime AV64ServerNow ;
      private bool n153SecUserTeste ;
      private string A153SecUserTeste ;
      private string AV49HTML ;
      private string AV65String ;
      private string AV59PathSource ;
      private string AV62PDFOut ;
      private string AV50result ;
      private Guid AV63GUID ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005B2_A153SecUserTeste ;
      private bool[] P005B2_n153SecUserTeste ;
      private short[] P005B2_A133SecUserId ;
      private SdtPDFTools AV51PDFTools ;
   }

   public class acriapdfchavedatahora__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005B2;
          prmP005B2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P005B2", "SELECT SecUserTeste, SecUserId FROM SecUser ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005B2,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
