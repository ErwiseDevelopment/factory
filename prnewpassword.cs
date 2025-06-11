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
   public class prnewpassword : GXProcedure
   {
      public prnewpassword( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prnewpassword( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_SecUserId ,
                           string aP1_Pass ,
                           out SdtSdErro aP2_SdErro )
      {
         this.AV9SecUserId = aP0_SecUserId;
         this.AV10Pass = aP1_Pass;
         this.AV12SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP2_SdErro=this.AV12SdErro;
      }

      public SdtSdErro executeUdp( short aP0_SecUserId ,
                                   string aP1_Pass )
      {
         execute(aP0_SecUserId, aP1_Pass, out aP2_SdErro);
         return AV12SdErro ;
      }

      public void executeSubmit( short aP0_SecUserId ,
                                 string aP1_Pass ,
                                 out SdtSdErro aP2_SdErro )
      {
         this.AV9SecUserId = aP0_SecUserId;
         this.AV10Pass = aP1_Pass;
         this.AV12SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP2_SdErro=this.AV12SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12SdErro = new SdtSdErro(context);
         AV12SdErro.gxTpr_Status = 200;
         AV11SecUser.Load(AV9SecUserId);
         AV14Auxnewpassword = AV13Hashing.dohash("SHA256", AV10Pass);
         AV11SecUser.gxTpr_Secuserpassword = AV14Auxnewpassword;
         AV11SecUser.gxTpr_Secuserupdateat = DateTimeUtil.ServerNow( context, pr_default);
         AV11SecUser.Save();
         if ( AV11SecUser.Fail() )
         {
            context.RollbackDataStores("prnewpassword",pr_default);
            AV12SdErro.gxTpr_Status = 400;
            AV12SdErro.gxTpr_Internalcode = 1002;
            AV12SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV11SecUser.GetMessages().Item(1)).gxTpr_Description;
         }
         else
         {
            context.CommitDataStores("prnewpassword",pr_default);
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
         AV12SdErro = new SdtSdErro(context);
         AV11SecUser = new SdtSecUser(context);
         AV14Auxnewpassword = "";
         AV13Hashing = new GeneXus.Programs.genexuscryptography.SdtHashing(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prnewpassword__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9SecUserId ;
      private string AV14Auxnewpassword ;
      private string AV10Pass ;
      private IGxDataStore dsDefault ;
      private SdtSdErro AV12SdErro ;
      private SdtSecUser AV11SecUser ;
      private GeneXus.Programs.genexuscryptography.SdtHashing AV13Hashing ;
      private IDataStoreProvider pr_default ;
      private SdtSdErro aP2_SdErro ;
   }

   public class prnewpassword__default : DataStoreHelperBase, IDataStoreHelper
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
