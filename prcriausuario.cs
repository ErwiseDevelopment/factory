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
   public class prcriausuario : GXProcedure
   {
      public prcriausuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcriausuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SecUserName ,
                           string aP1_SecUserFullName ,
                           string aP2_SecUserEmail ,
                           short aP3_LogSecUserId ,
                           int aP4_ClienteId ,
                           ref short aP5_SecUserId ,
                           ref SdtSdErro aP6_SdErro )
      {
         this.AV13SecUserName = aP0_SecUserName;
         this.AV12SecUserFullName = aP1_SecUserFullName;
         this.AV9SecUserEmail = aP2_SecUserEmail;
         this.AV11LogSecUserId = aP3_LogSecUserId;
         this.AV20ClienteId = aP4_ClienteId;
         this.AV19SecUserId = aP5_SecUserId;
         this.AV14SdErro = aP6_SdErro;
         initialize();
         ExecuteImpl();
         aP5_SecUserId=this.AV19SecUserId;
         aP6_SdErro=this.AV14SdErro;
      }

      public SdtSdErro executeUdp( string aP0_SecUserName ,
                                   string aP1_SecUserFullName ,
                                   string aP2_SecUserEmail ,
                                   short aP3_LogSecUserId ,
                                   int aP4_ClienteId ,
                                   ref short aP5_SecUserId )
      {
         execute(aP0_SecUserName, aP1_SecUserFullName, aP2_SecUserEmail, aP3_LogSecUserId, aP4_ClienteId, ref aP5_SecUserId, ref aP6_SdErro);
         return AV14SdErro ;
      }

      public void executeSubmit( string aP0_SecUserName ,
                                 string aP1_SecUserFullName ,
                                 string aP2_SecUserEmail ,
                                 short aP3_LogSecUserId ,
                                 int aP4_ClienteId ,
                                 ref short aP5_SecUserId ,
                                 ref SdtSdErro aP6_SdErro )
      {
         this.AV13SecUserName = aP0_SecUserName;
         this.AV12SecUserFullName = aP1_SecUserFullName;
         this.AV9SecUserEmail = aP2_SecUserEmail;
         this.AV11LogSecUserId = aP3_LogSecUserId;
         this.AV20ClienteId = aP4_ClienteId;
         this.AV19SecUserId = aP5_SecUserId;
         this.AV14SdErro = aP6_SdErro;
         SubmitImpl();
         aP5_SecUserId=this.AV19SecUserId;
         aP6_SdErro=this.AV14SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15SecUser = new SdtSecUser(context);
         AV15SecUser.gxTpr_Secusername = AV13SecUserName;
         AV15SecUser.gxTpr_Secuserfullname = AV12SecUserFullName;
         AV15SecUser.gxTpr_Secuseremail = AV9SecUserEmail;
         AV15SecUser.gxTpr_Secuserstatus = true;
         AV15SecUser.gxTv_SdtSecUser_Secuserpassword_SetNull();
         AV15SecUser.gxTpr_Secusercreatedat = DateTimeUtil.ServerNow( context, pr_default);
         AV15SecUser.gxTv_SdtSecUser_Secuserupdateat_SetNull();
         AV15SecUser.gxTpr_Secuseruserman = AV11LogSecUserId;
         AV15SecUser.gxTpr_Secusertemp = false;
         AV15SecUser.gxTpr_Secuserclienteacesso = true;
         AV15SecUser.gxTpr_Secuserownerid = AV20ClienteId;
         AV15SecUser.Save();
         if ( AV15SecUser.Success() )
         {
            context.CommitDataStores("prcriausuario",pr_default);
            AV14SdErro.gxTpr_Status = 200;
         }
         else
         {
            context.RollbackDataStores("prcriausuario",pr_default);
            AV14SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV15SecUser.GetMessages().Item(1)).gxTpr_Description;
            AV14SdErro.gxTpr_Status = 400;
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
         AV15SecUser = new SdtSecUser(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prcriausuario__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11LogSecUserId ;
      private short AV19SecUserId ;
      private int AV20ClienteId ;
      private string AV13SecUserName ;
      private string AV12SecUserFullName ;
      private string AV9SecUserEmail ;
      private IGxDataStore dsDefault ;
      private short aP5_SecUserId ;
      private SdtSdErro AV14SdErro ;
      private SdtSdErro aP6_SdErro ;
      private SdtSecUser AV15SecUser ;
      private IDataStoreProvider pr_default ;
   }

   public class prcriausuario__default : DataStoreHelperBase, IDataStoreHelper
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
