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
   public class prgetconectionws : GXProcedure
   {
      public prgetconectionws( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prgetconectionws( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WebServiceTipoDmWS ,
                           out string aP1_WebServiceEndPoint ,
                           out string aP2_WebServiceAuthTipo ,
                           out string aP3_WebServiceUsuario ,
                           out string aP4_WebServiceSenha ,
                           out string aP5_WebServiceCertificadoPath ,
                           out string aP6_WebServiceCertificadoPass ,
                           out string aP7_WebServiceClientid ,
                           out string aP8_WebServiceClientSecret )
      {
         this.AV8WebServiceTipoDmWS = aP0_WebServiceTipoDmWS;
         this.AV9WebServiceEndPoint = "" ;
         this.AV10WebServiceAuthTipo = "" ;
         this.AV11WebServiceUsuario = "" ;
         this.AV12WebServiceSenha = "" ;
         this.AV13WebServiceCertificadoPath = "" ;
         this.AV14WebServiceCertificadoPass = "" ;
         this.AV16WebServiceClientid = "" ;
         this.AV17WebServiceClientSecret = "" ;
         initialize();
         ExecuteImpl();
         aP1_WebServiceEndPoint=this.AV9WebServiceEndPoint;
         aP2_WebServiceAuthTipo=this.AV10WebServiceAuthTipo;
         aP3_WebServiceUsuario=this.AV11WebServiceUsuario;
         aP4_WebServiceSenha=this.AV12WebServiceSenha;
         aP5_WebServiceCertificadoPath=this.AV13WebServiceCertificadoPath;
         aP6_WebServiceCertificadoPass=this.AV14WebServiceCertificadoPass;
         aP7_WebServiceClientid=this.AV16WebServiceClientid;
         aP8_WebServiceClientSecret=this.AV17WebServiceClientSecret;
      }

      public string executeUdp( string aP0_WebServiceTipoDmWS ,
                                out string aP1_WebServiceEndPoint ,
                                out string aP2_WebServiceAuthTipo ,
                                out string aP3_WebServiceUsuario ,
                                out string aP4_WebServiceSenha ,
                                out string aP5_WebServiceCertificadoPath ,
                                out string aP6_WebServiceCertificadoPass ,
                                out string aP7_WebServiceClientid )
      {
         execute(aP0_WebServiceTipoDmWS, out aP1_WebServiceEndPoint, out aP2_WebServiceAuthTipo, out aP3_WebServiceUsuario, out aP4_WebServiceSenha, out aP5_WebServiceCertificadoPath, out aP6_WebServiceCertificadoPass, out aP7_WebServiceClientid, out aP8_WebServiceClientSecret);
         return AV17WebServiceClientSecret ;
      }

      public void executeSubmit( string aP0_WebServiceTipoDmWS ,
                                 out string aP1_WebServiceEndPoint ,
                                 out string aP2_WebServiceAuthTipo ,
                                 out string aP3_WebServiceUsuario ,
                                 out string aP4_WebServiceSenha ,
                                 out string aP5_WebServiceCertificadoPath ,
                                 out string aP6_WebServiceCertificadoPass ,
                                 out string aP7_WebServiceClientid ,
                                 out string aP8_WebServiceClientSecret )
      {
         this.AV8WebServiceTipoDmWS = aP0_WebServiceTipoDmWS;
         this.AV9WebServiceEndPoint = "" ;
         this.AV10WebServiceAuthTipo = "" ;
         this.AV11WebServiceUsuario = "" ;
         this.AV12WebServiceSenha = "" ;
         this.AV13WebServiceCertificadoPath = "" ;
         this.AV14WebServiceCertificadoPass = "" ;
         this.AV16WebServiceClientid = "" ;
         this.AV17WebServiceClientSecret = "" ;
         SubmitImpl();
         aP1_WebServiceEndPoint=this.AV9WebServiceEndPoint;
         aP2_WebServiceAuthTipo=this.AV10WebServiceAuthTipo;
         aP3_WebServiceUsuario=this.AV11WebServiceUsuario;
         aP4_WebServiceSenha=this.AV12WebServiceSenha;
         aP5_WebServiceCertificadoPath=this.AV13WebServiceCertificadoPath;
         aP6_WebServiceCertificadoPass=this.AV14WebServiceCertificadoPass;
         aP7_WebServiceClientid=this.AV16WebServiceClientid;
         aP8_WebServiceClientSecret=this.AV17WebServiceClientSecret;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00FI2 */
         pr_default.execute(0, new Object[] {AV8WebServiceTipoDmWS});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A657WebServiceTipoDmWS = P00FI2_A657WebServiceTipoDmWS[0];
            n657WebServiceTipoDmWS = P00FI2_n657WebServiceTipoDmWS[0];
            A1060WebServiceClientSecret = P00FI2_A1060WebServiceClientSecret[0];
            n1060WebServiceClientSecret = P00FI2_n1060WebServiceClientSecret[0];
            A1059WebServiceClientid = P00FI2_A1059WebServiceClientid[0];
            n1059WebServiceClientid = P00FI2_n1059WebServiceClientid[0];
            A1056WebServiceCertificadoPass = P00FI2_A1056WebServiceCertificadoPass[0];
            n1056WebServiceCertificadoPass = P00FI2_n1056WebServiceCertificadoPass[0];
            A1055WebServiceCertificadoBase64 = P00FI2_A1055WebServiceCertificadoBase64[0];
            n1055WebServiceCertificadoBase64 = P00FI2_n1055WebServiceCertificadoBase64[0];
            A661WebServiceSenha = P00FI2_A661WebServiceSenha[0];
            n661WebServiceSenha = P00FI2_n661WebServiceSenha[0];
            A660WebServiceUsuario = P00FI2_A660WebServiceUsuario[0];
            n660WebServiceUsuario = P00FI2_n660WebServiceUsuario[0];
            A659WebServiceAuthTipo = P00FI2_A659WebServiceAuthTipo[0];
            n659WebServiceAuthTipo = P00FI2_n659WebServiceAuthTipo[0];
            A658WebServiceEndPoint = P00FI2_A658WebServiceEndPoint[0];
            n658WebServiceEndPoint = P00FI2_n658WebServiceEndPoint[0];
            A656WebServiceId = P00FI2_A656WebServiceId[0];
            GXt_char1 = A1061WebServiceEndPointDecrypted;
            new decrypt(context ).execute(  A658WebServiceEndPoint, out  GXt_char1) ;
            A1061WebServiceEndPointDecrypted = GXt_char1;
            GXt_char1 = A1062WebServiceAuthTipoDecrypted;
            new decrypt(context ).execute(  A659WebServiceAuthTipo, out  GXt_char1) ;
            A1062WebServiceAuthTipoDecrypted = GXt_char1;
            GXt_char1 = A1063WebServiceUsuarioDecrypted;
            new decrypt(context ).execute(  A660WebServiceUsuario, out  GXt_char1) ;
            A1063WebServiceUsuarioDecrypted = GXt_char1;
            GXt_char1 = A1064WebServiceSenhaDecrypted;
            new decrypt(context ).execute(  A661WebServiceSenha, out  GXt_char1) ;
            A1064WebServiceSenhaDecrypted = GXt_char1;
            GXt_char1 = A1065WebServiceCertificadoBase64Decrypted;
            new decrypt(context ).execute(  A1055WebServiceCertificadoBase64, out  GXt_char1) ;
            A1065WebServiceCertificadoBase64Decrypted = GXt_char1;
            GXt_char1 = A1066WebServiceCertificadoPassDecrypted;
            new decrypt(context ).execute(  A1056WebServiceCertificadoPass, out  GXt_char1) ;
            A1066WebServiceCertificadoPassDecrypted = GXt_char1;
            GXt_char1 = A1067WebServiceClientidDecrypted;
            new decrypt(context ).execute(  A1059WebServiceClientid, out  GXt_char1) ;
            A1067WebServiceClientidDecrypted = GXt_char1;
            GXt_char1 = A1068WebServiceClientSecretDecrypted;
            new decrypt(context ).execute(  A1060WebServiceClientSecret, out  GXt_char1) ;
            A1068WebServiceClientSecretDecrypted = GXt_char1;
            AV9WebServiceEndPoint = A1061WebServiceEndPointDecrypted;
            AV10WebServiceAuthTipo = A1062WebServiceAuthTipoDecrypted;
            AV11WebServiceUsuario = A1063WebServiceUsuarioDecrypted;
            AV12WebServiceSenha = A1064WebServiceSenhaDecrypted;
            AV18WebServiceCertificadoBase64 = A1065WebServiceCertificadoBase64Decrypted;
            AV14WebServiceCertificadoPass = A1066WebServiceCertificadoPassDecrypted;
            AV16WebServiceClientid = A1067WebServiceClientidDecrypted;
            AV17WebServiceClientSecret = A1068WebServiceClientSecretDecrypted;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18WebServiceCertificadoBase64)) )
         {
            AV21Directory.Source = "./PublicTempStorage/";
            if ( ! AV21Directory.Exists() )
            {
               AV21Directory.Create();
            }
            AV19GUID = Guid.NewGuid( );
            AV20Source = "./PublicTempStorage/" + StringUtil.Trim( AV19GUID.ToString()) + ".pfx";
            AV22CertificadoFIle = new GxFile(context.GetPhysicalPath());
            AV22CertificadoFIle.Source = AV20Source;
            AV22CertificadoFIle.FromBase64(AV18WebServiceCertificadoBase64);
            AV22CertificadoFIle.Create();
            AV13WebServiceCertificadoPath = AV22CertificadoFIle.GetAbsoluteName();
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
         AV9WebServiceEndPoint = "";
         AV10WebServiceAuthTipo = "";
         AV11WebServiceUsuario = "";
         AV12WebServiceSenha = "";
         AV13WebServiceCertificadoPath = "";
         AV14WebServiceCertificadoPass = "";
         AV16WebServiceClientid = "";
         AV17WebServiceClientSecret = "";
         P00FI2_A657WebServiceTipoDmWS = new string[] {""} ;
         P00FI2_n657WebServiceTipoDmWS = new bool[] {false} ;
         P00FI2_A1060WebServiceClientSecret = new string[] {""} ;
         P00FI2_n1060WebServiceClientSecret = new bool[] {false} ;
         P00FI2_A1059WebServiceClientid = new string[] {""} ;
         P00FI2_n1059WebServiceClientid = new bool[] {false} ;
         P00FI2_A1056WebServiceCertificadoPass = new string[] {""} ;
         P00FI2_n1056WebServiceCertificadoPass = new bool[] {false} ;
         P00FI2_A1055WebServiceCertificadoBase64 = new string[] {""} ;
         P00FI2_n1055WebServiceCertificadoBase64 = new bool[] {false} ;
         P00FI2_A661WebServiceSenha = new string[] {""} ;
         P00FI2_n661WebServiceSenha = new bool[] {false} ;
         P00FI2_A660WebServiceUsuario = new string[] {""} ;
         P00FI2_n660WebServiceUsuario = new bool[] {false} ;
         P00FI2_A659WebServiceAuthTipo = new string[] {""} ;
         P00FI2_n659WebServiceAuthTipo = new bool[] {false} ;
         P00FI2_A658WebServiceEndPoint = new string[] {""} ;
         P00FI2_n658WebServiceEndPoint = new bool[] {false} ;
         P00FI2_A656WebServiceId = new int[1] ;
         A657WebServiceTipoDmWS = "";
         A1060WebServiceClientSecret = "";
         A1059WebServiceClientid = "";
         A1056WebServiceCertificadoPass = "";
         A1055WebServiceCertificadoBase64 = "";
         A661WebServiceSenha = "";
         A660WebServiceUsuario = "";
         A659WebServiceAuthTipo = "";
         A658WebServiceEndPoint = "";
         A1061WebServiceEndPointDecrypted = "";
         A1062WebServiceAuthTipoDecrypted = "";
         A1063WebServiceUsuarioDecrypted = "";
         A1064WebServiceSenhaDecrypted = "";
         A1065WebServiceCertificadoBase64Decrypted = "";
         A1066WebServiceCertificadoPassDecrypted = "";
         A1067WebServiceClientidDecrypted = "";
         A1068WebServiceClientSecretDecrypted = "";
         GXt_char1 = "";
         AV18WebServiceCertificadoBase64 = "";
         AV21Directory = new GxDirectory(context.GetPhysicalPath());
         AV19GUID = Guid.Empty;
         AV20Source = "";
         AV22CertificadoFIle = new GxFile(context.GetPhysicalPath());
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prgetconectionws__default(),
            new Object[][] {
                new Object[] {
               P00FI2_A657WebServiceTipoDmWS, P00FI2_n657WebServiceTipoDmWS, P00FI2_A1060WebServiceClientSecret, P00FI2_n1060WebServiceClientSecret, P00FI2_A1059WebServiceClientid, P00FI2_n1059WebServiceClientid, P00FI2_A1056WebServiceCertificadoPass, P00FI2_n1056WebServiceCertificadoPass, P00FI2_A1055WebServiceCertificadoBase64, P00FI2_n1055WebServiceCertificadoBase64,
               P00FI2_A661WebServiceSenha, P00FI2_n661WebServiceSenha, P00FI2_A660WebServiceUsuario, P00FI2_n660WebServiceUsuario, P00FI2_A659WebServiceAuthTipo, P00FI2_n659WebServiceAuthTipo, P00FI2_A658WebServiceEndPoint, P00FI2_n658WebServiceEndPoint, P00FI2_A656WebServiceId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A656WebServiceId ;
      private string GXt_char1 ;
      private bool n657WebServiceTipoDmWS ;
      private bool n1060WebServiceClientSecret ;
      private bool n1059WebServiceClientid ;
      private bool n1056WebServiceCertificadoPass ;
      private bool n1055WebServiceCertificadoBase64 ;
      private bool n661WebServiceSenha ;
      private bool n660WebServiceUsuario ;
      private bool n659WebServiceAuthTipo ;
      private bool n658WebServiceEndPoint ;
      private string AV9WebServiceEndPoint ;
      private string AV10WebServiceAuthTipo ;
      private string AV11WebServiceUsuario ;
      private string AV12WebServiceSenha ;
      private string AV14WebServiceCertificadoPass ;
      private string AV16WebServiceClientid ;
      private string AV17WebServiceClientSecret ;
      private string A1060WebServiceClientSecret ;
      private string A1059WebServiceClientid ;
      private string A1056WebServiceCertificadoPass ;
      private string A1055WebServiceCertificadoBase64 ;
      private string A661WebServiceSenha ;
      private string A660WebServiceUsuario ;
      private string A659WebServiceAuthTipo ;
      private string A658WebServiceEndPoint ;
      private string A1061WebServiceEndPointDecrypted ;
      private string A1062WebServiceAuthTipoDecrypted ;
      private string A1063WebServiceUsuarioDecrypted ;
      private string A1064WebServiceSenhaDecrypted ;
      private string A1065WebServiceCertificadoBase64Decrypted ;
      private string A1066WebServiceCertificadoPassDecrypted ;
      private string A1067WebServiceClientidDecrypted ;
      private string A1068WebServiceClientSecretDecrypted ;
      private string AV18WebServiceCertificadoBase64 ;
      private string AV20Source ;
      private string AV8WebServiceTipoDmWS ;
      private string AV13WebServiceCertificadoPath ;
      private string A657WebServiceTipoDmWS ;
      private Guid AV19GUID ;
      private GxFile AV22CertificadoFIle ;
      private GxDirectory AV21Directory ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00FI2_A657WebServiceTipoDmWS ;
      private bool[] P00FI2_n657WebServiceTipoDmWS ;
      private string[] P00FI2_A1060WebServiceClientSecret ;
      private bool[] P00FI2_n1060WebServiceClientSecret ;
      private string[] P00FI2_A1059WebServiceClientid ;
      private bool[] P00FI2_n1059WebServiceClientid ;
      private string[] P00FI2_A1056WebServiceCertificadoPass ;
      private bool[] P00FI2_n1056WebServiceCertificadoPass ;
      private string[] P00FI2_A1055WebServiceCertificadoBase64 ;
      private bool[] P00FI2_n1055WebServiceCertificadoBase64 ;
      private string[] P00FI2_A661WebServiceSenha ;
      private bool[] P00FI2_n661WebServiceSenha ;
      private string[] P00FI2_A660WebServiceUsuario ;
      private bool[] P00FI2_n660WebServiceUsuario ;
      private string[] P00FI2_A659WebServiceAuthTipo ;
      private bool[] P00FI2_n659WebServiceAuthTipo ;
      private string[] P00FI2_A658WebServiceEndPoint ;
      private bool[] P00FI2_n658WebServiceEndPoint ;
      private int[] P00FI2_A656WebServiceId ;
      private string aP1_WebServiceEndPoint ;
      private string aP2_WebServiceAuthTipo ;
      private string aP3_WebServiceUsuario ;
      private string aP4_WebServiceSenha ;
      private string aP5_WebServiceCertificadoPath ;
      private string aP6_WebServiceCertificadoPass ;
      private string aP7_WebServiceClientid ;
      private string aP8_WebServiceClientSecret ;
   }

   public class prgetconectionws__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00FI2;
          prmP00FI2 = new Object[] {
          new ParDef("AV8WebServiceTipoDmWS",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FI2", "SELECT WebServiceTipoDmWS, WebServiceClientSecret, WebServiceClientid, WebServiceCertificadoPass, WebServiceCertificadoBase64, WebServiceSenha, WebServiceUsuario, WebServiceAuthTipo, WebServiceEndPoint, WebServiceId FROM WebService WHERE WebServiceTipoDmWS = ( :AV8WebServiceTipoDmWS) ORDER BY WebServiceId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FI2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[8])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getLongVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                return;
       }
    }

 }

}
