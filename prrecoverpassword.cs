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
   public class prrecoverpassword : GXProcedure
   {
      public prrecoverpassword( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prrecoverpassword( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SecUserName ,
                           string aP1_SecUserEmail ,
                           out string aP2_message )
      {
         this.AV8SecUserName = aP0_SecUserName;
         this.AV9SecUserEmail = aP1_SecUserEmail;
         this.AV10message = "" ;
         initialize();
         ExecuteImpl();
         aP2_message=this.AV10message;
      }

      public string executeUdp( string aP0_SecUserName ,
                                string aP1_SecUserEmail )
      {
         execute(aP0_SecUserName, aP1_SecUserEmail, out aP2_message);
         return AV10message ;
      }

      public void executeSubmit( string aP0_SecUserName ,
                                 string aP1_SecUserEmail ,
                                 out string aP2_message )
      {
         this.AV8SecUserName = aP0_SecUserName;
         this.AV9SecUserEmail = aP1_SecUserEmail;
         this.AV10message = "" ;
         SubmitImpl();
         aP2_message=this.AV10message;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV25GXLvl3 = 0;
         /* Using cursor P005K2 */
         pr_default.execute(0, new Object[] {AV8SecUserName, AV9SecUserEmail});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A144SecUserEmail = P005K2_A144SecUserEmail[0];
            n144SecUserEmail = P005K2_n144SecUserEmail[0];
            A141SecUserName = P005K2_A141SecUserName[0];
            n141SecUserName = P005K2_n141SecUserName[0];
            A143SecUserFullName = P005K2_A143SecUserFullName[0];
            n143SecUserFullName = P005K2_n143SecUserFullName[0];
            A133SecUserId = P005K2_A133SecUserId[0];
            AV25GXLvl3 = 1;
            AV20SecUserUID = new SdtSecUserToken(context);
            AV21GUID = Guid.NewGuid( );
            AV22DateTime = DateTimeUtil.ServerNow( context, pr_default);
            AV22DateTime = DateTimeUtil.TAdd( AV22DateTime, 3600*(3));
            AV20SecUserUID.gxTpr_Secusertokenkey = AV21GUID.ToString();
            AV20SecUserUID.gxTpr_Secusertokendatetime = AV22DateTime;
            AV20SecUserUID.gxTpr_Secuserid = A133SecUserId;
            AV20SecUserUID.gxTpr_Secusertokenused = false;
            AV20SecUserUID.Save();
            if ( AV20SecUserUID.Fail() )
            {
               AV10message = "Ocorreu um erro com nossos servidores, por favor tente novamente mais tarde";
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            else
            {
               context.CommitDataStores("prrecoverpassword",pr_default);
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "newpassword"+GXUtil.UrlEncode(StringUtil.RTrim(AV21GUID.ToString()));
            AV17Link = AV24HTTPREQUEST.BaseURL + formatLink("newpassword") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            GXt_char1 = AV16RecoverHTML;
            new emailrecover(context ).execute(  A143SecUserFullName,  AV17Link, out  GXt_char1) ;
            AV16RecoverHTML = GXt_char1;
            AV19Email = A144SecUserEmail;
            AV18Array_Email.Add(AV19Email, 0);
            new sendemail(context ).execute(  "Recuperar senha",  AV16RecoverHTML,  AV18Array_Email, out  AV10message) ;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV25GXLvl3 == 0 )
         {
            AV10message = "Não encontrado usuário com esse e-mail/login";
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
         AV10message = "";
         P005K2_A144SecUserEmail = new string[] {""} ;
         P005K2_n144SecUserEmail = new bool[] {false} ;
         P005K2_A141SecUserName = new string[] {""} ;
         P005K2_n141SecUserName = new bool[] {false} ;
         P005K2_A143SecUserFullName = new string[] {""} ;
         P005K2_n143SecUserFullName = new bool[] {false} ;
         P005K2_A133SecUserId = new short[1] ;
         A144SecUserEmail = "";
         A141SecUserName = "";
         A143SecUserFullName = "";
         AV20SecUserUID = new SdtSecUserToken(context);
         AV21GUID = Guid.Empty;
         AV22DateTime = (DateTime)(DateTime.MinValue);
         AV17Link = "";
         AV24HTTPREQUEST = new GxHttpRequest( context);
         GXKey = "";
         GXEncryptionTmp = "";
         AV16RecoverHTML = "";
         GXt_char1 = "";
         AV19Email = "";
         AV18Array_Email = new GxSimpleCollection<string>();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prrecoverpassword__default(),
            new Object[][] {
                new Object[] {
               P005K2_A144SecUserEmail, P005K2_n144SecUserEmail, P005K2_A141SecUserName, P005K2_n141SecUserName, P005K2_A143SecUserFullName, P005K2_n143SecUserFullName, P005K2_A133SecUserId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV25GXLvl3 ;
      private short A133SecUserId ;
      private short gxcookieaux ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GXt_char1 ;
      private DateTime AV22DateTime ;
      private bool n144SecUserEmail ;
      private bool n141SecUserName ;
      private bool n143SecUserFullName ;
      private string AV16RecoverHTML ;
      private string AV8SecUserName ;
      private string AV9SecUserEmail ;
      private string AV10message ;
      private string A144SecUserEmail ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private string AV17Link ;
      private string AV19Email ;
      private Guid AV21GUID ;
      private GxHttpRequest AV24HTTPREQUEST ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005K2_A144SecUserEmail ;
      private bool[] P005K2_n144SecUserEmail ;
      private string[] P005K2_A141SecUserName ;
      private bool[] P005K2_n141SecUserName ;
      private string[] P005K2_A143SecUserFullName ;
      private bool[] P005K2_n143SecUserFullName ;
      private short[] P005K2_A133SecUserId ;
      private SdtSecUserToken AV20SecUserUID ;
      private GxSimpleCollection<string> AV18Array_Email ;
      private string aP2_message ;
   }

   public class prrecoverpassword__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005K2;
          prmP005K2 = new Object[] {
          new ParDef("AV8SecUserName",GXType.VarChar,100,0) ,
          new ParDef("AV9SecUserEmail",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005K2", "SELECT SecUserEmail, SecUserName, SecUserFullName, SecUserId FROM SecUser WHERE (UPPER(SecUserName) = ( UPPER(:AV8SecUserName))) AND (UPPER(SecUserEmail) = ( UPPER(:AV9SecUserEmail))) ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005K2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((short[]) buf[6])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
