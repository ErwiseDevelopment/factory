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
   public class debug : GXProcedure
   {
      public debug( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public debug( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_String )
      {
         this.AV10String = aP0_String;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( string aP0_String )
      {
         this.AV10String = aP0_String;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11dir = "PublicTempStorage\\";
         AV8File.Source = ".\\PublicTempStorage\\";
         AV9i = (short)(StringUtil.StringSearch( AV8File.GetAbsoluteName(), "bin", 1));
         if ( ! (0==AV9i) )
         {
            AV11dir = "..\\PublicTempStorage\\";
         }
         AV12ServerNow = DateTimeUtil.ServerNow( context, pr_default);
         AV14Errotxt = (decimal)(context.FileIOInstance.dfwopen( StringUtil.Trim( AV11dir)+"debugSiSWeb_teste.txt", "", "", 1, ""));
         AV14Errotxt = (decimal)(context.FileIOInstance.dfwptxt( context.localUtil.TToC( AV12ServerNow, 10, 8, 0, 3, "/", ":", " ")+" - "+AV10String, 0));
         AV14Errotxt = (decimal)(context.FileIOInstance.dfwnext( ));
         AV14Errotxt = (decimal)(context.FileIOInstance.dfwclose( ));
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
         AV11dir = "";
         AV8File = new GxFile(context.GetPhysicalPath());
         AV12ServerNow = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.debug__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9i ;
      private decimal AV14Errotxt ;
      private DateTime AV12ServerNow ;
      private string AV10String ;
      private string AV11dir ;
      private GxFile AV8File ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
   }

   public class debug__default : DataStoreHelperBase, IDataStoreHelper
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
