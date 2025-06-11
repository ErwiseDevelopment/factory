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
   public class prtoken : GXProcedure
   {
      public prtoken( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prtoken( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TokensType ,
                           out string aP1_TokensContent )
      {
         this.AV8TokensType = aP0_TokensType;
         this.AV9TokensContent = "" ;
         initialize();
         ExecuteImpl();
         aP1_TokensContent=this.AV9TokensContent;
      }

      public string executeUdp( string aP0_TokensType )
      {
         execute(aP0_TokensType, out aP1_TokensContent);
         return AV9TokensContent ;
      }

      public void executeSubmit( string aP0_TokensType ,
                                 out string aP1_TokensContent )
      {
         this.AV8TokensType = aP0_TokensType;
         this.AV9TokensContent = "" ;
         SubmitImpl();
         aP1_TokensContent=this.AV9TokensContent;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Now = DateTimeUtil.ServerNow( context, pr_default);
         new unittime(context ).execute(  AV10Now, out  AV12SecondsNow) ;
         AV12SecondsNow = (long)(AV12SecondsNow+5);
         /* Using cursor P00FG2 */
         pr_default.execute(0, new Object[] {AV8TokensType, AV12SecondsNow});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1053TokensType = P00FG2_A1053TokensType[0];
            n1053TokensType = P00FG2_n1053TokensType[0];
            A1052TokensExpire = P00FG2_A1052TokensExpire[0];
            n1052TokensExpire = P00FG2_n1052TokensExpire[0];
            A1051TokensContent = P00FG2_A1051TokensContent[0];
            n1051TokensContent = P00FG2_n1051TokensContent[0];
            A1057TokensSalt = P00FG2_A1057TokensSalt[0];
            n1057TokensSalt = P00FG2_n1057TokensSalt[0];
            A1058TokensDateTime = P00FG2_A1058TokensDateTime[0];
            n1058TokensDateTime = P00FG2_n1058TokensDateTime[0];
            A1050TokensId = P00FG2_A1050TokensId[0];
            AV9TokensContent = A1051TokensContent;
            AV13TokensSalt = A1057TokensSalt;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9TokensContent)) )
         {
            new decrypt(context ).execute(  AV9TokensContent, out  AV9TokensContent) ;
         }
         else
         {
            new prgetconectionws(context ).execute(  "Santander", out  AV22WebServiceEndPoint, out  AV14WebServiceAuthTipo, out  AV15WebServiceUsuario, out  AV16WebServiceSenha, out  AV17WebServiceCertificadoPath, out  AV23WebServiceCertificadoPass, out  AV18WebServiceClientid, out  AV19WebServiceClientSecret) ;
            AV20TokenResponse = AV21SantanderApiClient.gettoken(AV22WebServiceEndPoint, AV18WebServiceClientid, AV19WebServiceClientSecret, AV17WebServiceCertificadoPath, AV23WebServiceCertificadoPass);
            AV24Tokens = new SdtTokens(context);
            AV13TokensSalt = AV25SaltGenerator.generatesecuresalt(36);
            AV26NowDateTime = DateTimeUtil.ServerNow( context, pr_default);
            GXt_char1 = "";
            new prencrypt(context ).execute(  AV20TokenResponse.gxTpr_Accesstoken, out  GXt_char1) ;
            AV24Tokens.gxTpr_Tokenscontent = GXt_char1;
            GXt_int2 = 0;
            new unittime(context ).execute(  DateTimeUtil.TAdd( AV26NowDateTime, AV20TokenResponse.gxTpr_Expiresin), out  GXt_int2) ;
            AV24Tokens.gxTpr_Tokensexpire = (int)(GXt_int2);
            AV24Tokens.gxTpr_Tokenstype = "9cf42625-e388-45f6-aae5-e7c2b7ddcffc";
            GXt_int2 = 0;
            new unittime(context ).execute(  AV26NowDateTime, out  GXt_int2) ;
            AV24Tokens.gxTpr_Tokensdatetime = GXt_int2;
            AV24Tokens.Save();
            if ( AV24Tokens.Success() )
            {
               context.CommitDataStores("prtoken",pr_default);
               AV9TokensContent = AV20TokenResponse.gxTpr_Accesstoken;
               cleanup();
               if (true) return;
            }
            else
            {
               context.RollbackDataStores("prtoken",pr_default);
               AV9TokensContent = "";
               cleanup();
               if (true) return;
            }
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
         AV9TokensContent = "";
         AV10Now = (DateTime)(DateTime.MinValue);
         P00FG2_A1053TokensType = new string[] {""} ;
         P00FG2_n1053TokensType = new bool[] {false} ;
         P00FG2_A1052TokensExpire = new int[1] ;
         P00FG2_n1052TokensExpire = new bool[] {false} ;
         P00FG2_A1051TokensContent = new string[] {""} ;
         P00FG2_n1051TokensContent = new bool[] {false} ;
         P00FG2_A1057TokensSalt = new string[] {""} ;
         P00FG2_n1057TokensSalt = new bool[] {false} ;
         P00FG2_A1058TokensDateTime = new long[1] ;
         P00FG2_n1058TokensDateTime = new bool[] {false} ;
         P00FG2_A1050TokensId = new int[1] ;
         A1053TokensType = "";
         A1051TokensContent = "";
         A1057TokensSalt = "";
         AV13TokensSalt = "";
         AV22WebServiceEndPoint = "";
         AV14WebServiceAuthTipo = "";
         AV15WebServiceUsuario = "";
         AV16WebServiceSenha = "";
         AV17WebServiceCertificadoPath = "";
         AV23WebServiceCertificadoPass = "";
         AV18WebServiceClientid = "";
         AV19WebServiceClientSecret = "";
         AV20TokenResponse = new SdtTokenResponse(context);
         AV21SantanderApiClient = new SdtSantanderApiClient(context);
         AV24Tokens = new SdtTokens(context);
         AV25SaltGenerator = new SdtSaltGenerator(context);
         AV26NowDateTime = (DateTime)(DateTime.MinValue);
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prtoken__default(),
            new Object[][] {
                new Object[] {
               P00FG2_A1053TokensType, P00FG2_n1053TokensType, P00FG2_A1052TokensExpire, P00FG2_n1052TokensExpire, P00FG2_A1051TokensContent, P00FG2_n1051TokensContent, P00FG2_A1057TokensSalt, P00FG2_n1057TokensSalt, P00FG2_A1058TokensDateTime, P00FG2_n1058TokensDateTime,
               P00FG2_A1050TokensId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A1052TokensExpire ;
      private int A1050TokensId ;
      private long AV12SecondsNow ;
      private long A1058TokensDateTime ;
      private long GXt_int2 ;
      private string GXt_char1 ;
      private DateTime AV10Now ;
      private DateTime AV26NowDateTime ;
      private bool n1053TokensType ;
      private bool n1052TokensExpire ;
      private bool n1051TokensContent ;
      private bool n1057TokensSalt ;
      private bool n1058TokensDateTime ;
      private string AV9TokensContent ;
      private string A1051TokensContent ;
      private string A1057TokensSalt ;
      private string AV13TokensSalt ;
      private string AV22WebServiceEndPoint ;
      private string AV14WebServiceAuthTipo ;
      private string AV15WebServiceUsuario ;
      private string AV16WebServiceSenha ;
      private string AV23WebServiceCertificadoPass ;
      private string AV18WebServiceClientid ;
      private string AV19WebServiceClientSecret ;
      private string AV8TokensType ;
      private string A1053TokensType ;
      private string AV17WebServiceCertificadoPath ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00FG2_A1053TokensType ;
      private bool[] P00FG2_n1053TokensType ;
      private int[] P00FG2_A1052TokensExpire ;
      private bool[] P00FG2_n1052TokensExpire ;
      private string[] P00FG2_A1051TokensContent ;
      private bool[] P00FG2_n1051TokensContent ;
      private string[] P00FG2_A1057TokensSalt ;
      private bool[] P00FG2_n1057TokensSalt ;
      private long[] P00FG2_A1058TokensDateTime ;
      private bool[] P00FG2_n1058TokensDateTime ;
      private int[] P00FG2_A1050TokensId ;
      private SdtTokenResponse AV20TokenResponse ;
      private SdtSantanderApiClient AV21SantanderApiClient ;
      private SdtTokens AV24Tokens ;
      private SdtSaltGenerator AV25SaltGenerator ;
      private string aP1_TokensContent ;
   }

   public class prtoken__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00FG2;
          prmP00FG2 = new Object[] {
          new ParDef("AV8TokensType",GXType.VarChar,100,0) ,
          new ParDef("AV12SecondsNow",GXType.Int64,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FG2", "SELECT TokensType, TokensExpire, TokensContent, TokensSalt, TokensDateTime, TokensId FROM Tokens WHERE (TokensType = ( :AV8TokensType)) AND (TokensExpire >= :AV12SecondsNow) ORDER BY TokensType, TokensDateTime DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FG2,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
