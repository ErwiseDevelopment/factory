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
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class sendemail : GXProcedure
   {
      public sendemail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public sendemail( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Subject ,
                           string aP1_Body ,
                           GxSimpleCollection<string> aP2_RecipientTo ,
                           out string aP3_message )
      {
         this.AV19Subject = aP0_Subject;
         this.AV8Body = aP1_Body;
         this.AV20RecipientTo = aP2_RecipientTo;
         this.AV16message = "" ;
         initialize();
         ExecuteImpl();
         aP3_message=this.AV16message;
      }

      public string executeUdp( string aP0_Subject ,
                                string aP1_Body ,
                                GxSimpleCollection<string> aP2_RecipientTo )
      {
         execute(aP0_Subject, aP1_Body, aP2_RecipientTo, out aP3_message);
         return AV16message ;
      }

      public void executeSubmit( string aP0_Subject ,
                                 string aP1_Body ,
                                 GxSimpleCollection<string> aP2_RecipientTo ,
                                 out string aP3_message )
      {
         this.AV19Subject = aP0_Subject;
         this.AV8Body = aP1_Body;
         this.AV20RecipientTo = aP2_RecipientTo;
         this.AV16message = "" ;
         SubmitImpl();
         aP3_message=this.AV16message;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P005M2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A159ServidorSMTPServer = P005M2_A159ServidorSMTPServer[0];
            n159ServidorSMTPServer = P005M2_n159ServidorSMTPServer[0];
            A160ServidorSMTPPorta = P005M2_A160ServidorSMTPPorta[0];
            n160ServidorSMTPPorta = P005M2_n160ServidorSMTPPorta[0];
            A161ServidorSMTPEmail = P005M2_A161ServidorSMTPEmail[0];
            n161ServidorSMTPEmail = P005M2_n161ServidorSMTPEmail[0];
            A162ServidorSMTPPass = P005M2_A162ServidorSMTPPass[0];
            n162ServidorSMTPPass = P005M2_n162ServidorSMTPPass[0];
            A163ServidorSMTPUsuario = P005M2_A163ServidorSMTPUsuario[0];
            n163ServidorSMTPUsuario = P005M2_n163ServidorSMTPUsuario[0];
            A158ServidorSMTPId = P005M2_A158ServidorSMTPId[0];
            AV9Server = A159ServidorSMTPServer;
            AV10Port = A160ServidorSMTPPorta;
            AV11Email = A161ServidorSMTPEmail;
            AV13Pass = A162ServidorSMTPPass;
            AV12User = A163ServidorSMTPUsuario;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV14SMTPSession.Host = AV9Server;
         AV14SMTPSession.Port = (int)(Math.Round(NumberUtil.Val( AV10Port, "."), 18, MidpointRounding.ToEven));
         AV14SMTPSession.Timeout = 20;
         AV14SMTPSession.Secure = 1;
         AV14SMTPSession.Authentication = 1;
         AV14SMTPSession.UserName = AV12User;
         AV14SMTPSession.Password = AV13Pass;
         AV14SMTPSession.Sender.Address = AV11Email;
         AV14SMTPSession.Sender.Name = AV12User;
         AV15ret = AV14SMTPSession.Login();
         if ( AV14SMTPSession.ErrCode != 0 )
         {
            AV16message = StringUtil.Str( (decimal)(AV15ret), 4, 0) + ":Erro ao tentar logar no servidor de e-mail";
         }
         else
         {
            AV17MailMessage.Clear();
            AV17MailMessage.To.Clear();
            AV17MailMessage.BCC.Clear();
            AV17MailMessage.CC.Clear();
            AV17MailMessage.Subject = AV19Subject;
            AV17MailMessage.HTMLText = AV8Body;
            AV17MailMessage.Attachments.Clear();
            AV25GXV1 = 1;
            while ( AV25GXV1 <= AV20RecipientTo.Count )
            {
               AV22AuxEmail = ((string)AV20RecipientTo.Item(AV25GXV1));
               AV18MailRecipient.Address = AV22AuxEmail;
               AV18MailRecipient.Name = AV22AuxEmail;
               AV17MailMessage.To.Add(AV18MailRecipient);
               AV25GXV1 = (int)(AV25GXV1+1);
            }
            AV18MailRecipient = new GeneXus.Mail.GXMailRecipient();
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18MailRecipient.Address)) )
            {
               AV17MailMessage.CC.Add(AV18MailRecipient);
               AV17MailMessage.BCC.Add(AV18MailRecipient);
            }
            AV21sendmsg = AV14SMTPSession.Send(AV17MailMessage);
            if ( ! (0==AV21sendmsg) )
            {
               AV16message = StringUtil.Str( (decimal)(AV21sendmsg), 4, 0) + ":Erro ao tentar logar no servidor de e-mail";
            }
            AV15ret = AV14SMTPSession.Logout();
         }
         AV23LogEmail = new SdtLogEmail(context);
         AV23LogEmail.gxTpr_Logemailcorpo = AV8Body;
         AV23LogEmail.gxTpr_Logemailsubject = AV19Subject;
         AV23LogEmail.gxTpr_Logemaildestinatario = AV20RecipientTo.ToJSonString(false);
         AV23LogEmail.gxTpr_Logemailcreatedat = DateTimeUtil.ServerNow( context, pr_default);
         AV23LogEmail.Save();
         if ( AV23LogEmail.Success() )
         {
            context.CommitDataStores("sendemail",pr_default);
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
         AV16message = "";
         P005M2_A159ServidorSMTPServer = new string[] {""} ;
         P005M2_n159ServidorSMTPServer = new bool[] {false} ;
         P005M2_A160ServidorSMTPPorta = new string[] {""} ;
         P005M2_n160ServidorSMTPPorta = new bool[] {false} ;
         P005M2_A161ServidorSMTPEmail = new string[] {""} ;
         P005M2_n161ServidorSMTPEmail = new bool[] {false} ;
         P005M2_A162ServidorSMTPPass = new string[] {""} ;
         P005M2_n162ServidorSMTPPass = new bool[] {false} ;
         P005M2_A163ServidorSMTPUsuario = new string[] {""} ;
         P005M2_n163ServidorSMTPUsuario = new bool[] {false} ;
         P005M2_A158ServidorSMTPId = new short[1] ;
         A159ServidorSMTPServer = "";
         A160ServidorSMTPPorta = "";
         A161ServidorSMTPEmail = "";
         A162ServidorSMTPPass = "";
         A163ServidorSMTPUsuario = "";
         AV9Server = "";
         AV10Port = "";
         AV11Email = "";
         AV13Pass = "";
         AV12User = "";
         AV14SMTPSession = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV17MailMessage = new GeneXus.Mail.GXMailMessage();
         AV22AuxEmail = "";
         AV18MailRecipient = new GeneXus.Mail.GXMailRecipient();
         AV23LogEmail = new SdtLogEmail(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sendemail__default(),
            new Object[][] {
                new Object[] {
               P005M2_A159ServidorSMTPServer, P005M2_n159ServidorSMTPServer, P005M2_A160ServidorSMTPPorta, P005M2_n160ServidorSMTPPorta, P005M2_A161ServidorSMTPEmail, P005M2_n161ServidorSMTPEmail, P005M2_A162ServidorSMTPPass, P005M2_n162ServidorSMTPPass, P005M2_A163ServidorSMTPUsuario, P005M2_n163ServidorSMTPUsuario,
               P005M2_A158ServidorSMTPId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A158ServidorSMTPId ;
      private short AV15ret ;
      private short AV21sendmsg ;
      private int AV25GXV1 ;
      private bool n159ServidorSMTPServer ;
      private bool n160ServidorSMTPPorta ;
      private bool n161ServidorSMTPEmail ;
      private bool n162ServidorSMTPPass ;
      private bool n163ServidorSMTPUsuario ;
      private string AV8Body ;
      private string AV19Subject ;
      private string AV16message ;
      private string A159ServidorSMTPServer ;
      private string A160ServidorSMTPPorta ;
      private string A161ServidorSMTPEmail ;
      private string A162ServidorSMTPPass ;
      private string A163ServidorSMTPUsuario ;
      private string AV9Server ;
      private string AV10Port ;
      private string AV11Email ;
      private string AV13Pass ;
      private string AV12User ;
      private string AV22AuxEmail ;
      private GeneXus.Mail.GXMailMessage AV17MailMessage ;
      private GeneXus.Mail.GXMailRecipient AV18MailRecipient ;
      private GeneXus.Mail.GXSMTPSession AV14SMTPSession ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV20RecipientTo ;
      private IDataStoreProvider pr_default ;
      private string[] P005M2_A159ServidorSMTPServer ;
      private bool[] P005M2_n159ServidorSMTPServer ;
      private string[] P005M2_A160ServidorSMTPPorta ;
      private bool[] P005M2_n160ServidorSMTPPorta ;
      private string[] P005M2_A161ServidorSMTPEmail ;
      private bool[] P005M2_n161ServidorSMTPEmail ;
      private string[] P005M2_A162ServidorSMTPPass ;
      private bool[] P005M2_n162ServidorSMTPPass ;
      private string[] P005M2_A163ServidorSMTPUsuario ;
      private bool[] P005M2_n163ServidorSMTPUsuario ;
      private short[] P005M2_A158ServidorSMTPId ;
      private SdtLogEmail AV23LogEmail ;
      private string aP3_message ;
   }

   public class sendemail__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP005M2;
          prmP005M2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P005M2", "SELECT ServidorSMTPServer, ServidorSMTPPorta, ServidorSMTPEmail, ServidorSMTPPass, ServidorSMTPUsuario, ServidorSMTPId FROM ServidorSMTP ORDER BY ServidorSMTPId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005M2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
