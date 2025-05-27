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
   public class prcriarusuario : GXProcedure
   {
      public prcriarusuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcriarusuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtSdSecUser aP0_SdSecUser ,
                           out SdtSdErro aP1_SdErro )
      {
         this.AV9SdSecUser = aP0_SdSecUser;
         this.AV10SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP1_SdErro=this.AV10SdErro;
      }

      public SdtSdErro executeUdp( SdtSdSecUser aP0_SdSecUser )
      {
         execute(aP0_SdSecUser, out aP1_SdErro);
         return AV10SdErro ;
      }

      public void executeSubmit( SdtSdSecUser aP0_SdSecUser ,
                                 out SdtSdErro aP1_SdErro )
      {
         this.AV9SdSecUser = aP0_SdSecUser;
         this.AV10SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP1_SdErro=this.AV10SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8SecUser = new SdtSecUser(context);
         AV8SecUser.gxTpr_Secusername = AV9SdSecUser.gxTpr_Secusername;
         AV8SecUser.gxTpr_Secuserfullname = AV9SdSecUser.gxTpr_Secuserfullname;
         AV8SecUser.gxTpr_Secuseremail = AV9SdSecUser.gxTpr_Secuseremail;
         AV8SecUser.gxTpr_Secuserstatus = AV9SdSecUser.gxTpr_Secuserstatus;
         AV8SecUser.gxTpr_Secuseranalista = AV9SdSecUser.gxTpr_Secuseranalista;
         AV8SecUser.gxTpr_Secusercreatedat = AV9SdSecUser.gxTpr_Secusercreatedat;
         AV8SecUser.gxTpr_Secuserupdateat = AV9SdSecUser.gxTpr_Secuserupdateat;
         AV8SecUser.gxTpr_Secuserownerid = AV9SdSecUser.gxTpr_Secuserownerid;
         AV8SecUser.Save();
         if ( ! AV8SecUser.Success() )
         {
            context.RollbackDataStores("prcriarusuario",pr_default);
            AV10SdErro = new SdtSdErro(context);
            AV10SdErro.gxTpr_Internalcode = 1;
            AV13GXV2 = 1;
            AV12GXV1 = AV8SecUser.GetMessages();
            while ( AV13GXV2 <= AV12GXV1.Count )
            {
               AV11Message = ((GeneXus.Utils.SdtMessages_Message)AV12GXV1.Item(AV13GXV2));
               AV10SdErro.gxTpr_Msg = AV10SdErro.gxTpr_Msg+StringUtil.Trim( AV11Message.gxTpr_Description)+StringUtil.NewLine( );
               AV13GXV2 = (int)(AV13GXV2+1);
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
         AV10SdErro = new SdtSdErro(context);
         AV8SecUser = new SdtSecUser(context);
         AV12GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV11Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prcriarusuario__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV13GXV2 ;
      private IGxDataStore dsDefault ;
      private SdtSdSecUser AV9SdSecUser ;
      private SdtSdErro AV10SdErro ;
      private SdtSecUser AV8SecUser ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV12GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV11Message ;
      private SdtSdErro aP1_SdErro ;
   }

   public class prcriarusuario__default : DataStoreHelperBase, IDataStoreHelper
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
