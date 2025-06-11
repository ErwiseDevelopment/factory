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
   public class prlogin : GXProcedure
   {
      public prlogin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prlogin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SecUserEmail ,
                           string aP1_SecUserPassword ,
                           out short aP2_SecUserId ,
                           out bool aP3_LogInSuccessful ,
                           out string aP4_message )
      {
         this.AV17SecUserEmail = aP0_SecUserEmail;
         this.AV11SecUserPassword = aP1_SecUserPassword;
         this.AV16SecUserId = 0 ;
         this.AV9LogInSuccessful = false ;
         this.AV15message = "" ;
         initialize();
         ExecuteImpl();
         aP2_SecUserId=this.AV16SecUserId;
         aP3_LogInSuccessful=this.AV9LogInSuccessful;
         aP4_message=this.AV15message;
      }

      public string executeUdp( string aP0_SecUserEmail ,
                                string aP1_SecUserPassword ,
                                out short aP2_SecUserId ,
                                out bool aP3_LogInSuccessful )
      {
         execute(aP0_SecUserEmail, aP1_SecUserPassword, out aP2_SecUserId, out aP3_LogInSuccessful, out aP4_message);
         return AV15message ;
      }

      public void executeSubmit( string aP0_SecUserEmail ,
                                 string aP1_SecUserPassword ,
                                 out short aP2_SecUserId ,
                                 out bool aP3_LogInSuccessful ,
                                 out string aP4_message )
      {
         this.AV17SecUserEmail = aP0_SecUserEmail;
         this.AV11SecUserPassword = aP1_SecUserPassword;
         this.AV16SecUserId = 0 ;
         this.AV9LogInSuccessful = false ;
         this.AV15message = "" ;
         SubmitImpl();
         aP2_SecUserId=this.AV16SecUserId;
         aP3_LogInSuccessful=this.AV9LogInSuccessful;
         aP4_message=this.AV15message;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Pass = AV13Hashing.dohash("SHA256", AV11SecUserPassword);
         AV9LogInSuccessful = false;
         AV20GXLvl5 = 0;
         /* Using cursor P005I2 */
         pr_default.execute(0, new Object[] {AV17SecUserEmail});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133SecUserId = P005I2_A133SecUserId[0];
            n133SecUserId = P005I2_n133SecUserId[0];
            A144SecUserEmail = P005I2_A144SecUserEmail[0];
            n144SecUserEmail = P005I2_n144SecUserEmail[0];
            A142SecUserPassword = P005I2_A142SecUserPassword[0];
            n142SecUserPassword = P005I2_n142SecUserPassword[0];
            A141SecUserName = P005I2_A141SecUserName[0];
            n141SecUserName = P005I2_n141SecUserName[0];
            A143SecUserFullName = P005I2_A143SecUserFullName[0];
            n143SecUserFullName = P005I2_n143SecUserFullName[0];
            A226SecUserOwnerId = P005I2_A226SecUserOwnerId[0];
            n226SecUserOwnerId = P005I2_n226SecUserOwnerId[0];
            A791SecUserAnalista = P005I2_A791SecUserAnalista[0];
            n791SecUserAnalista = P005I2_n791SecUserAnalista[0];
            A209SecUserClienteAcesso = P005I2_A209SecUserClienteAcesso[0];
            n209SecUserClienteAcesso = P005I2_n209SecUserClienteAcesso[0];
            A210SecUserClienteId = P005I2_A210SecUserClienteId[0];
            n210SecUserClienteId = P005I2_n210SecUserClienteId[0];
            AV20GXLvl5 = 1;
            AV16SecUserId = A133SecUserId;
            if ( StringUtil.StrCmp(A142SecUserPassword, AV8Pass) != 0 )
            {
               AV15message = "Senha incorreta!";
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            AV12Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
            /* Using cursor P005I3 */
            pr_default.execute(1, new Object[] {n133SecUserId, A133SecUserId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A380AprovadoresStatus = P005I3_A380AprovadoresStatus[0];
               n380AprovadoresStatus = P005I3_n380AprovadoresStatus[0];
               A375AprovadoresId = P005I3_A375AprovadoresId[0];
               AV19AprovadoresId = A375AprovadoresId;
               AV12Context.gxTpr_Isaprover = true;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV14ExpireDateTime = DateTimeUtil.ServerNow( context, pr_default);
            AV14ExpireDateTime = DateTimeUtil.TAdd( AV14ExpireDateTime, 60*(30));
            AV12Context.gxTpr_Userid = A133SecUserId;
            AV12Context.gxTpr_Username = A141SecUserName;
            AV12Context.gxTpr_Userfullname = A143SecUserFullName;
            AV12Context.gxTpr_Ownerid = (short)(A226SecUserOwnerId);
            AV12Context.gxTpr_Expire = AV14ExpireDateTime;
            AV12Context.gxTpr_Secuseranalista = A791SecUserAnalista;
            AV12Context.gxTpr_Aprovadorid = (short)(AV19AprovadoresId);
            if ( A209SecUserClienteAcesso )
            {
               AV12Context.gxTpr_Iscliente = true;
               AV12Context.gxTpr_Secuserclienteid = (short)(((0==A210SecUserClienteId)||P005I2_n210SecUserClienteId[0] ? A133SecUserId : A210SecUserClienteId));
            }
            new GeneXus.Programs.wwpbaseobjects.setwwpcontext(context ).execute(  AV12Context) ;
            AV9LogInSuccessful = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV20GXLvl5 == 0 )
         {
            AV15message = "Usuário não existe";
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
         AV15message = "";
         AV8Pass = "";
         AV13Hashing = new GeneXus.Programs.genexuscryptography.SdtHashing(context);
         P005I2_A133SecUserId = new short[1] ;
         P005I2_n133SecUserId = new bool[] {false} ;
         P005I2_A144SecUserEmail = new string[] {""} ;
         P005I2_n144SecUserEmail = new bool[] {false} ;
         P005I2_A142SecUserPassword = new string[] {""} ;
         P005I2_n142SecUserPassword = new bool[] {false} ;
         P005I2_A141SecUserName = new string[] {""} ;
         P005I2_n141SecUserName = new bool[] {false} ;
         P005I2_A143SecUserFullName = new string[] {""} ;
         P005I2_n143SecUserFullName = new bool[] {false} ;
         P005I2_A226SecUserOwnerId = new int[1] ;
         P005I2_n226SecUserOwnerId = new bool[] {false} ;
         P005I2_A791SecUserAnalista = new bool[] {false} ;
         P005I2_n791SecUserAnalista = new bool[] {false} ;
         P005I2_A209SecUserClienteAcesso = new bool[] {false} ;
         P005I2_n209SecUserClienteAcesso = new bool[] {false} ;
         P005I2_A210SecUserClienteId = new short[1] ;
         P005I2_n210SecUserClienteId = new bool[] {false} ;
         A144SecUserEmail = "";
         A142SecUserPassword = "";
         A141SecUserName = "";
         A143SecUserFullName = "";
         AV12Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P005I3_A133SecUserId = new short[1] ;
         P005I3_n133SecUserId = new bool[] {false} ;
         P005I3_A380AprovadoresStatus = new bool[] {false} ;
         P005I3_n380AprovadoresStatus = new bool[] {false} ;
         P005I3_A375AprovadoresId = new int[1] ;
         AV14ExpireDateTime = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prlogin__default(),
            new Object[][] {
                new Object[] {
               P005I2_A133SecUserId, P005I2_A144SecUserEmail, P005I2_n144SecUserEmail, P005I2_A142SecUserPassword, P005I2_n142SecUserPassword, P005I2_A141SecUserName, P005I2_n141SecUserName, P005I2_A143SecUserFullName, P005I2_n143SecUserFullName, P005I2_A226SecUserOwnerId,
               P005I2_n226SecUserOwnerId, P005I2_A791SecUserAnalista, P005I2_n791SecUserAnalista, P005I2_A209SecUserClienteAcesso, P005I2_n209SecUserClienteAcesso, P005I2_A210SecUserClienteId, P005I2_n210SecUserClienteId
               }
               , new Object[] {
               P005I3_A133SecUserId, P005I3_n133SecUserId, P005I3_A380AprovadoresStatus, P005I3_n380AprovadoresStatus, P005I3_A375AprovadoresId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16SecUserId ;
      private short AV20GXLvl5 ;
      private short A133SecUserId ;
      private short A210SecUserClienteId ;
      private int A226SecUserOwnerId ;
      private int A375AprovadoresId ;
      private int AV19AprovadoresId ;
      private DateTime AV14ExpireDateTime ;
      private bool AV9LogInSuccessful ;
      private bool n133SecUserId ;
      private bool n144SecUserEmail ;
      private bool n142SecUserPassword ;
      private bool n141SecUserName ;
      private bool n143SecUserFullName ;
      private bool n226SecUserOwnerId ;
      private bool A791SecUserAnalista ;
      private bool n791SecUserAnalista ;
      private bool A209SecUserClienteAcesso ;
      private bool n209SecUserClienteAcesso ;
      private bool n210SecUserClienteId ;
      private bool A380AprovadoresStatus ;
      private bool n380AprovadoresStatus ;
      private string AV17SecUserEmail ;
      private string AV11SecUserPassword ;
      private string AV15message ;
      private string AV8Pass ;
      private string A144SecUserEmail ;
      private string A142SecUserPassword ;
      private string A141SecUserName ;
      private string A143SecUserFullName ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.genexuscryptography.SdtHashing AV13Hashing ;
      private IDataStoreProvider pr_default ;
      private short[] P005I2_A133SecUserId ;
      private bool[] P005I2_n133SecUserId ;
      private string[] P005I2_A144SecUserEmail ;
      private bool[] P005I2_n144SecUserEmail ;
      private string[] P005I2_A142SecUserPassword ;
      private bool[] P005I2_n142SecUserPassword ;
      private string[] P005I2_A141SecUserName ;
      private bool[] P005I2_n141SecUserName ;
      private string[] P005I2_A143SecUserFullName ;
      private bool[] P005I2_n143SecUserFullName ;
      private int[] P005I2_A226SecUserOwnerId ;
      private bool[] P005I2_n226SecUserOwnerId ;
      private bool[] P005I2_A791SecUserAnalista ;
      private bool[] P005I2_n791SecUserAnalista ;
      private bool[] P005I2_A209SecUserClienteAcesso ;
      private bool[] P005I2_n209SecUserClienteAcesso ;
      private short[] P005I2_A210SecUserClienteId ;
      private bool[] P005I2_n210SecUserClienteId ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV12Context ;
      private short[] P005I3_A133SecUserId ;
      private bool[] P005I3_n133SecUserId ;
      private bool[] P005I3_A380AprovadoresStatus ;
      private bool[] P005I3_n380AprovadoresStatus ;
      private int[] P005I3_A375AprovadoresId ;
      private short aP2_SecUserId ;
      private bool aP3_LogInSuccessful ;
      private string aP4_message ;
   }

   public class prlogin__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005I2;
          prmP005I2 = new Object[] {
          new ParDef("AV17SecUserEmail",GXType.VarChar,100,0)
          };
          Object[] prmP005I3;
          prmP005I3 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P005I2", "SELECT SecUserId, SecUserEmail, SecUserPassword, SecUserName, SecUserFullName, SecUserOwnerId, SecUserAnalista, SecUserClienteAcesso, SecUserClienteId FROM SecUser WHERE UPPER(SecUserEmail) = ( UPPER(:AV17SecUserEmail)) ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005I2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P005I3", "SELECT SecUserId, AprovadoresStatus, AprovadoresId FROM Aprovadores WHERE (SecUserId = :SecUserId) AND (AprovadoresStatus = TRUE) ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005I3,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
