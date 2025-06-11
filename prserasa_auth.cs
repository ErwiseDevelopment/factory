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
   public class prserasa_auth : GXProcedure
   {
      public prserasa_auth( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prserasa_auth( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out SdtSdSerasaAuth aP0_SdSerasaAuth )
      {
         this.AV12SdSerasaAuth = new SdtSdSerasaAuth(context) ;
         initialize();
         ExecuteImpl();
         aP0_SdSerasaAuth=this.AV12SdSerasaAuth;
      }

      public SdtSdSerasaAuth executeUdp( )
      {
         execute(out aP0_SdSerasaAuth);
         return AV12SdSerasaAuth ;
      }

      public void executeSubmit( out SdtSdSerasaAuth aP0_SdSerasaAuth )
      {
         this.AV12SdSerasaAuth = new SdtSdSerasaAuth(context) ;
         SubmitImpl();
         aP0_SdSerasaAuth=this.AV12SdSerasaAuth;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00CF2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A657WebServiceTipoDmWS = P00CF2_A657WebServiceTipoDmWS[0];
            n657WebServiceTipoDmWS = P00CF2_n657WebServiceTipoDmWS[0];
            A660WebServiceUsuario = P00CF2_A660WebServiceUsuario[0];
            n660WebServiceUsuario = P00CF2_n660WebServiceUsuario[0];
            A661WebServiceSenha = P00CF2_A661WebServiceSenha[0];
            n661WebServiceSenha = P00CF2_n661WebServiceSenha[0];
            A658WebServiceEndPoint = P00CF2_A658WebServiceEndPoint[0];
            n658WebServiceEndPoint = P00CF2_n658WebServiceEndPoint[0];
            A656WebServiceId = P00CF2_A656WebServiceId[0];
            AV8HTTPCLIENT = new GxHttpClient( context);
            new prbasicauth(context ).execute(  A660WebServiceUsuario,  A661WebServiceSenha, out  AV10Basic) ;
            AV8HTTPCLIENT.AddHeader("Authorization", "Basic "+StringUtil.Trim( AV10Basic));
            AV8HTTPCLIENT.Execute("POST", A658WebServiceEndPoint);
            AV11Response = AV8HTTPCLIENT.ToString();
            if ( AV8HTTPCLIENT.StatusCode == 201 )
            {
               AV12SdSerasaAuth.FromJSonString(AV11Response, null);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         AV12SdSerasaAuth = new SdtSdSerasaAuth(context);
         P00CF2_A657WebServiceTipoDmWS = new string[] {""} ;
         P00CF2_n657WebServiceTipoDmWS = new bool[] {false} ;
         P00CF2_A660WebServiceUsuario = new string[] {""} ;
         P00CF2_n660WebServiceUsuario = new bool[] {false} ;
         P00CF2_A661WebServiceSenha = new string[] {""} ;
         P00CF2_n661WebServiceSenha = new bool[] {false} ;
         P00CF2_A658WebServiceEndPoint = new string[] {""} ;
         P00CF2_n658WebServiceEndPoint = new bool[] {false} ;
         P00CF2_A656WebServiceId = new int[1] ;
         A657WebServiceTipoDmWS = "";
         A660WebServiceUsuario = "";
         A661WebServiceSenha = "";
         A658WebServiceEndPoint = "";
         AV8HTTPCLIENT = new GxHttpClient( context);
         AV10Basic = "";
         AV11Response = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prserasa_auth__default(),
            new Object[][] {
                new Object[] {
               P00CF2_A657WebServiceTipoDmWS, P00CF2_n657WebServiceTipoDmWS, P00CF2_A660WebServiceUsuario, P00CF2_n660WebServiceUsuario, P00CF2_A661WebServiceSenha, P00CF2_n661WebServiceSenha, P00CF2_A658WebServiceEndPoint, P00CF2_n658WebServiceEndPoint, P00CF2_A656WebServiceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A656WebServiceId ;
      private bool n657WebServiceTipoDmWS ;
      private bool n660WebServiceUsuario ;
      private bool n661WebServiceSenha ;
      private bool n658WebServiceEndPoint ;
      private string A660WebServiceUsuario ;
      private string A661WebServiceSenha ;
      private string A658WebServiceEndPoint ;
      private string A657WebServiceTipoDmWS ;
      private string AV10Basic ;
      private string AV11Response ;
      private GxHttpClient AV8HTTPCLIENT ;
      private IGxDataStore dsDefault ;
      private SdtSdSerasaAuth AV12SdSerasaAuth ;
      private IDataStoreProvider pr_default ;
      private string[] P00CF2_A657WebServiceTipoDmWS ;
      private bool[] P00CF2_n657WebServiceTipoDmWS ;
      private string[] P00CF2_A660WebServiceUsuario ;
      private bool[] P00CF2_n660WebServiceUsuario ;
      private string[] P00CF2_A661WebServiceSenha ;
      private bool[] P00CF2_n661WebServiceSenha ;
      private string[] P00CF2_A658WebServiceEndPoint ;
      private bool[] P00CF2_n658WebServiceEndPoint ;
      private int[] P00CF2_A656WebServiceId ;
      private SdtSdSerasaAuth aP0_SdSerasaAuth ;
   }

   public class prserasa_auth__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00CF2;
          prmP00CF2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00CF2", "SELECT WebServiceTipoDmWS, WebServiceUsuario, WebServiceSenha, WebServiceEndPoint, WebServiceId FROM WebService WHERE WebServiceTipoDmWS = ( 'Serasa_AUTH') ORDER BY WebServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CF2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
