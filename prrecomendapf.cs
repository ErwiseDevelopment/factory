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
   public class prrecomendapf : GXProcedure
   {
      public prrecomendapf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prrecomendapf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtSdSerasaAuth aP0_SdSerasaAuth ,
                           SdtSdSerasaPFProposta aP1_SdSerasaPFProposta ,
                           out SdtSdConteudoRecomendaPF aP2_SdConteudoRecomendaPF ,
                           out short aP3_ResponseStatus )
      {
         this.AV8SdSerasaAuth = aP0_SdSerasaAuth;
         this.AV9SdSerasaPFProposta = aP1_SdSerasaPFProposta;
         this.AV12SdConteudoRecomendaPF = new SdtSdConteudoRecomendaPF(context) ;
         this.AV13ResponseStatus = 0 ;
         initialize();
         ExecuteImpl();
         aP2_SdConteudoRecomendaPF=this.AV12SdConteudoRecomendaPF;
         aP3_ResponseStatus=this.AV13ResponseStatus;
      }

      public short executeUdp( SdtSdSerasaAuth aP0_SdSerasaAuth ,
                               SdtSdSerasaPFProposta aP1_SdSerasaPFProposta ,
                               out SdtSdConteudoRecomendaPF aP2_SdConteudoRecomendaPF )
      {
         execute(aP0_SdSerasaAuth, aP1_SdSerasaPFProposta, out aP2_SdConteudoRecomendaPF, out aP3_ResponseStatus);
         return AV13ResponseStatus ;
      }

      public void executeSubmit( SdtSdSerasaAuth aP0_SdSerasaAuth ,
                                 SdtSdSerasaPFProposta aP1_SdSerasaPFProposta ,
                                 out SdtSdConteudoRecomendaPF aP2_SdConteudoRecomendaPF ,
                                 out short aP3_ResponseStatus )
      {
         this.AV8SdSerasaAuth = aP0_SdSerasaAuth;
         this.AV9SdSerasaPFProposta = aP1_SdSerasaPFProposta;
         this.AV12SdConteudoRecomendaPF = new SdtSdConteudoRecomendaPF(context) ;
         this.AV13ResponseStatus = 0 ;
         SubmitImpl();
         aP2_SdConteudoRecomendaPF=this.AV12SdConteudoRecomendaPF;
         aP3_ResponseStatus=this.AV13ResponseStatus;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00CH2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A657WebServiceTipoDmWS = P00CH2_A657WebServiceTipoDmWS[0];
            n657WebServiceTipoDmWS = P00CH2_n657WebServiceTipoDmWS[0];
            A658WebServiceEndPoint = P00CH2_A658WebServiceEndPoint[0];
            n658WebServiceEndPoint = P00CH2_n658WebServiceEndPoint[0];
            A656WebServiceId = P00CH2_A656WebServiceId[0];
            AV10HTTPClient = new GxHttpClient( context);
            AV10HTTPClient.AddString(AV9SdSerasaPFProposta.ToJSonString(false, true));
            AV10HTTPClient.AddHeader("Authorization", "Bearer "+StringUtil.Trim( AV8SdSerasaAuth.gxTpr_Accesstoken));
            AV10HTTPClient.AddHeader("cliente", "123");
            AV10HTTPClient.AddHeader("Content-Type", "application/json");
            AV10HTTPClient.Execute("POST", A658WebServiceEndPoint);
            AV11Response = AV10HTTPClient.ToString();
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV12SdConteudoRecomendaPF.FromJSonString(AV11Response, null);
         AV13ResponseStatus = AV10HTTPClient.StatusCode;
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
         AV12SdConteudoRecomendaPF = new SdtSdConteudoRecomendaPF(context);
         P00CH2_A657WebServiceTipoDmWS = new string[] {""} ;
         P00CH2_n657WebServiceTipoDmWS = new bool[] {false} ;
         P00CH2_A658WebServiceEndPoint = new string[] {""} ;
         P00CH2_n658WebServiceEndPoint = new bool[] {false} ;
         P00CH2_A656WebServiceId = new int[1] ;
         A657WebServiceTipoDmWS = "";
         A658WebServiceEndPoint = "";
         AV10HTTPClient = new GxHttpClient( context);
         AV11Response = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prrecomendapf__default(),
            new Object[][] {
                new Object[] {
               P00CH2_A657WebServiceTipoDmWS, P00CH2_n657WebServiceTipoDmWS, P00CH2_A658WebServiceEndPoint, P00CH2_n658WebServiceEndPoint, P00CH2_A656WebServiceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13ResponseStatus ;
      private int A656WebServiceId ;
      private bool n657WebServiceTipoDmWS ;
      private bool n658WebServiceEndPoint ;
      private string A658WebServiceEndPoint ;
      private string A657WebServiceTipoDmWS ;
      private string AV11Response ;
      private GxHttpClient AV10HTTPClient ;
      private IGxDataStore dsDefault ;
      private SdtSdSerasaAuth AV8SdSerasaAuth ;
      private SdtSdSerasaPFProposta AV9SdSerasaPFProposta ;
      private SdtSdConteudoRecomendaPF AV12SdConteudoRecomendaPF ;
      private IDataStoreProvider pr_default ;
      private string[] P00CH2_A657WebServiceTipoDmWS ;
      private bool[] P00CH2_n657WebServiceTipoDmWS ;
      private string[] P00CH2_A658WebServiceEndPoint ;
      private bool[] P00CH2_n658WebServiceEndPoint ;
      private int[] P00CH2_A656WebServiceId ;
      private SdtSdConteudoRecomendaPF aP2_SdConteudoRecomendaPF ;
      private short aP3_ResponseStatus ;
   }

   public class prrecomendapf__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00CH2;
          prmP00CH2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00CH2", "SELECT WebServiceTipoDmWS, WebServiceEndPoint, WebServiceId FROM WebService WHERE WebServiceTipoDmWS = ( 'Serasa_PROPOSTA_PF') ORDER BY WebServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CH2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
