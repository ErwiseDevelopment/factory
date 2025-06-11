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
   public class praprovarrepresentante : GXProcedure
   {
      public praprovarrepresentante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public praprovarrepresentante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ClienteId ,
                           out SdtSdErro aP1_SdErro )
      {
         this.AV9ClienteId = aP0_ClienteId;
         this.AV11SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP1_SdErro=this.AV11SdErro;
      }

      public SdtSdErro executeUdp( int aP0_ClienteId )
      {
         execute(aP0_ClienteId, out aP1_SdErro);
         return AV11SdErro ;
      }

      public void executeSubmit( int aP0_ClienteId ,
                                 out SdtSdErro aP1_SdErro )
      {
         this.AV9ClienteId = aP0_ClienteId;
         this.AV11SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP1_SdErro=this.AV11SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Cliente.Load(AV9ClienteId);
         AV8Cliente.gxTpr_Clientesituacao = "A";
         AV8Cliente.Save();
         if ( AV8Cliente.Success() )
         {
            AV12SdSecUser = new SdtSdSecUser(context);
            AV12SdSecUser.gxTpr_Secusername = StringUtil.Trim( AV8Cliente.gxTpr_Responsavelcpf);
            AV12SdSecUser.gxTpr_Secuserfullname = StringUtil.Trim( AV8Cliente.gxTpr_Responsavelnome);
            AV12SdSecUser.gxTpr_Secuseremail = StringUtil.Trim( AV8Cliente.gxTpr_Responsavelemail);
            AV12SdSecUser.gxTpr_Secuserstatus = true;
            AV12SdSecUser.gxTpr_Secuseranalista = false;
            AV12SdSecUser.gxTpr_Secusercreatedat = DateTimeUtil.ServerNow( context, pr_default);
            AV12SdSecUser.gxTpr_Secuserupdateat = DateTimeUtil.ServerNow( context, pr_default);
            AV12SdSecUser.gxTpr_Secuserownerid = AV8Cliente.gxTpr_Clienteid;
            GXt_SdtSdErro1 = AV11SdErro;
            new prcriarusuario(context ).execute(  AV12SdSecUser, out  GXt_SdtSdErro1) ;
            AV11SdErro = GXt_SdtSdErro1;
         }
         else
         {
            context.RollbackDataStores("praprovarrepresentante",pr_default);
            AV11SdErro = new SdtSdErro(context);
            AV11SdErro.gxTpr_Internalcode = 1;
            AV14GXV2 = 1;
            AV13GXV1 = AV8Cliente.GetMessages();
            while ( AV14GXV2 <= AV13GXV1.Count )
            {
               AV10Message = ((GeneXus.Utils.SdtMessages_Message)AV13GXV1.Item(AV14GXV2));
               AV11SdErro.gxTpr_Msg = AV11SdErro.gxTpr_Msg+StringUtil.Trim( AV10Message.gxTpr_Description)+StringUtil.NewLine( );
               AV14GXV2 = (int)(AV14GXV2+1);
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
         AV11SdErro = new SdtSdErro(context);
         AV8Cliente = new SdtCliente(context);
         AV12SdSecUser = new SdtSdSecUser(context);
         GXt_SdtSdErro1 = new SdtSdErro(context);
         AV13GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.praprovarrepresentante__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV9ClienteId ;
      private int AV14GXV2 ;
      private IGxDataStore dsDefault ;
      private SdtSdErro AV11SdErro ;
      private SdtCliente AV8Cliente ;
      private SdtSdSecUser AV12SdSecUser ;
      private IDataStoreProvider pr_default ;
      private SdtSdErro GXt_SdtSdErro1 ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV13GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV10Message ;
      private SdtSdErro aP1_SdErro ;
   }

   public class praprovarrepresentante__default : DataStoreHelperBase, IDataStoreHelper
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
