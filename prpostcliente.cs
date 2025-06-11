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
   public class prpostcliente : GXProcedure
   {
      public prpostcliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prpostcliente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtSdClientePFPJ aP0_SdClientePFPJ ,
                           out SdtSdClientePFPJRetorno aP1_SdClientePFPJRetorno )
      {
         this.AV8SdClientePFPJ = aP0_SdClientePFPJ;
         this.AV9SdClientePFPJRetorno = new SdtSdClientePFPJRetorno(context) ;
         initialize();
         ExecuteImpl();
         aP1_SdClientePFPJRetorno=this.AV9SdClientePFPJRetorno;
      }

      public SdtSdClientePFPJRetorno executeUdp( SdtSdClientePFPJ aP0_SdClientePFPJ )
      {
         execute(aP0_SdClientePFPJ, out aP1_SdClientePFPJRetorno);
         return AV9SdClientePFPJRetorno ;
      }

      public void executeSubmit( SdtSdClientePFPJ aP0_SdClientePFPJ ,
                                 out SdtSdClientePFPJRetorno aP1_SdClientePFPJRetorno )
      {
         this.AV8SdClientePFPJ = aP0_SdClientePFPJ;
         this.AV9SdClientePFPJRetorno = new SdtSdClientePFPJRetorno(context) ;
         SubmitImpl();
         aP1_SdClientePFPJRetorno=this.AV9SdClientePFPJRetorno;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Cliente = new SdtCliente(context);
         /* Using cursor P00D92 */
         pr_default.execute(0, new Object[] {AV8SdClientePFPJ.gxTpr_Document});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A169ClienteDocumento = P00D92_A169ClienteDocumento[0];
            n169ClienteDocumento = P00D92_n169ClienteDocumento[0];
            A168ClienteId = P00D92_A168ClienteId[0];
            AV9SdClientePFPJRetorno.gxTpr_Message = "Customer with this document already exists";
            pr_default.close(0);
            cleanup();
            if (true) return;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00D93 */
         pr_default.execute(1, new Object[] {AV8SdClientePFPJ.gxTpr_Contact.gxTpr_Email});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A169ClienteDocumento = P00D93_A169ClienteDocumento[0];
            n169ClienteDocumento = P00D93_n169ClienteDocumento[0];
            A168ClienteId = P00D93_A168ClienteId[0];
            AV9SdClientePFPJRetorno.gxTpr_Message = "Customer with this email already exists";
            pr_default.close(1);
            cleanup();
            if (true) return;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV11created_at = DateTimeUtil.ServerNow( context, pr_default);
         AV10Cliente.gxTpr_Clientedocumento = AV8SdClientePFPJ.gxTpr_Document;
         AV10Cliente.gxTpr_Clienterazaosocial = AV8SdClientePFPJ.gxTpr_Company_name;
         AV10Cliente.gxTpr_Clientenomefantasia = AV8SdClientePFPJ.gxTpr_Trade_name;
         AV10Cliente.Save();
         if ( AV10Cliente.Success() )
         {
            context.CommitDataStores("prpostcliente",pr_default);
            AV9SdClientePFPJRetorno.gxTpr_Id = AV10Cliente.gxTpr_Clienteid;
            AV9SdClientePFPJRetorno.gxTpr_Created_at = AV11created_at;
            AV9SdClientePFPJRetorno.gxTpr_Document = AV8SdClientePFPJ.gxTpr_Document;
         }
         else
         {
            context.RollbackDataStores("prpostcliente",pr_default);
            AV9SdClientePFPJRetorno.gxTpr_Message = ((GeneXus.Utils.SdtMessages_Message)AV10Cliente.GetMessages().Item(1)).gxTpr_Description;
            cleanup();
            if (true) return;
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
         AV9SdClientePFPJRetorno = new SdtSdClientePFPJRetorno(context);
         AV10Cliente = new SdtCliente(context);
         P00D92_A169ClienteDocumento = new string[] {""} ;
         P00D92_n169ClienteDocumento = new bool[] {false} ;
         P00D92_A168ClienteId = new int[1] ;
         A169ClienteDocumento = "";
         P00D93_A169ClienteDocumento = new string[] {""} ;
         P00D93_n169ClienteDocumento = new bool[] {false} ;
         P00D93_A168ClienteId = new int[1] ;
         AV11created_at = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prpostcliente__default(),
            new Object[][] {
                new Object[] {
               P00D92_A169ClienteDocumento, P00D92_n169ClienteDocumento, P00D92_A168ClienteId
               }
               , new Object[] {
               P00D93_A169ClienteDocumento, P00D93_n169ClienteDocumento, P00D93_A168ClienteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A168ClienteId ;
      private DateTime AV11created_at ;
      private bool n169ClienteDocumento ;
      private string A169ClienteDocumento ;
      private IGxDataStore dsDefault ;
      private SdtSdClientePFPJ AV8SdClientePFPJ ;
      private SdtSdClientePFPJRetorno AV9SdClientePFPJRetorno ;
      private SdtCliente AV10Cliente ;
      private IDataStoreProvider pr_default ;
      private string[] P00D92_A169ClienteDocumento ;
      private bool[] P00D92_n169ClienteDocumento ;
      private int[] P00D92_A168ClienteId ;
      private string[] P00D93_A169ClienteDocumento ;
      private bool[] P00D93_n169ClienteDocumento ;
      private int[] P00D93_A168ClienteId ;
      private SdtSdClientePFPJRetorno aP1_SdClientePFPJRetorno ;
   }

   public class prpostcliente__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00D92;
          prmP00D92 = new Object[] {
          new ParDef("AV8SdClientePFPJ__Document",GXType.VarChar,100,0)
          };
          Object[] prmP00D93;
          prmP00D93 = new Object[] {
          new ParDef("AV8SdCli_1Contact_1Email",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D92", "SELECT ClienteDocumento, ClienteId FROM Cliente WHERE ClienteDocumento = ( :AV8SdClientePFPJ__Document) ORDER BY ClienteDocumento ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D92,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00D93", "SELECT ClienteDocumento, ClienteId FROM Cliente WHERE ClienteDocumento = ( :AV8SdCli_1Contact_1Email) ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D93,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
