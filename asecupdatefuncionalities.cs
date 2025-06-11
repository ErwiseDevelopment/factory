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
   public class asecupdatefuncionalities : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new asecupdatefuncionalities().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         execute();
         return GX.GXRuntime.ExitCode ;
      }

      public asecupdatefuncionalities( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public asecupdatefuncionalities( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16RoleName = "ADMINISTRADOR";
         AV17AdminUserName = "SUPERVISOR";
         /* Using cursor P004Y2 */
         pr_default.execute(0, new Object[] {AV17AdminUserName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A141SecUserName = P004Y2_A141SecUserName[0];
            n141SecUserName = P004Y2_n141SecUserName[0];
            A133SecUserId = P004Y2_A133SecUserId[0];
            AV22SecUserId = A133SecUserId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P004Y3 */
         pr_default.execute(1, new Object[] {AV16RoleName});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A140SecRoleName = P004Y3_A140SecRoleName[0];
            A131SecRoleId = P004Y3_A131SecRoleId[0];
            AV23SecRoleId = A131SecRoleId;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         context.StatusMessage( StringUtil.Format( "Administrator role: '%1'", AV16RoleName, "", "", "", "", "", "", "", "") );
         n134SecFunctionalityActive = false;
         /* Optimized UPDATE. */
         /* Using cursor P004Y4 */
         pr_default.execute(2);
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
         /* End optimized UPDATE. */
         GXt_objcol_SdtDVelop_Menu_Item1 = AV19Dvelop_menu;
         new GeneXus.Programs.wwpbaseobjects.menuoptionsdatavendas(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item1) ;
         AV19Dvelop_menu = GXt_objcol_SdtDVelop_Menu_Item1;
         new prgravadevelopmenu(context ).execute(  AV19Dvelop_menu,  0,  "Vendas") ;
         GXt_objcol_SdtDVelop_Menu_Item1 = AV19Dvelop_menu;
         new GeneXus.Programs.wwpbaseobjects.menuoptionsdata(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item1) ;
         AV19Dvelop_menu = GXt_objcol_SdtDVelop_Menu_Item1;
         new prgravadevelopmenu(context ).execute(  AV19Dvelop_menu,  0,  "Financeiro") ;
         GXt_objcol_SdtDVelop_Menu_Item1 = AV19Dvelop_menu;
         new GeneXus.Programs.wwpbaseobjects.menuoptionsdatacontratos(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item1) ;
         AV19Dvelop_menu = GXt_objcol_SdtDVelop_Menu_Item1;
         new prgravadevelopmenu(context ).execute(  AV19Dvelop_menu,  0,  "Contratos") ;
         GXt_objcol_SdtDVelop_Menu_Item1 = AV19Dvelop_menu;
         new GeneXus.Programs.wwpbaseobjects.menuoptionsdataseguranca(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item1) ;
         AV19Dvelop_menu = GXt_objcol_SdtDVelop_Menu_Item1;
         new prgravadevelopmenu(context ).execute(  AV19Dvelop_menu,  0,  "Segurança") ;
         GXt_objcol_SdtDVelop_Menu_Item1 = AV19Dvelop_menu;
         new GeneXus.Programs.wwpbaseobjects.menuoptionsdatanotificacoes(context ).execute( out  GXt_objcol_SdtDVelop_Menu_Item1) ;
         AV19Dvelop_menu = GXt_objcol_SdtDVelop_Menu_Item1;
         new prgravadevelopmenu(context ).execute(  AV19Dvelop_menu,  0,  "") ;
         /* Using cursor P004Y5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A140SecRoleName = P004Y5_A140SecRoleName[0];
            A131SecRoleId = P004Y5_A131SecRoleId[0];
            AV23SecRoleId = A131SecRoleId;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Optimized UPDATE. */
         /* Using cursor P004Y6 */
         pr_default.execute(4, new Object[] {AV23SecRoleId});
         pr_default.close(4);
         pr_default.SmartCacheProvider.SetUpdated("SecFunctionalityRole");
         /* End optimized UPDATE. */
         if ( AV23SecRoleId > 0 )
         {
            /* Using cursor P004Y7 */
            pr_default.execute(5);
            while ( (pr_default.getStatus(5) != 101) )
            {
               A134SecFunctionalityActive = P004Y7_A134SecFunctionalityActive[0];
               n134SecFunctionalityActive = P004Y7_n134SecFunctionalityActive[0];
               A128SecFunctionalityId = P004Y7_A128SecFunctionalityId[0];
               AV25SecFunctionalityRole.Load(A128SecFunctionalityId, AV23SecRoleId);
               AV25SecFunctionalityRole.gxTpr_Secfunctionalityroleativo = true;
               AV25SecFunctionalityRole.Save();
               pr_default.readNext(5);
            }
            pr_default.close(5);
         }
         context.CommitDataStores("secupdatefuncionalities",pr_default);
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
         AV16RoleName = "";
         AV17AdminUserName = "";
         P004Y2_A141SecUserName = new string[] {""} ;
         P004Y2_n141SecUserName = new bool[] {false} ;
         P004Y2_A133SecUserId = new short[1] ;
         A141SecUserName = "";
         P004Y3_A140SecRoleName = new string[] {""} ;
         P004Y3_A131SecRoleId = new short[1] ;
         A140SecRoleName = "";
         AV19Dvelop_menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         GXt_objcol_SdtDVelop_Menu_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         P004Y5_A140SecRoleName = new string[] {""} ;
         P004Y5_A131SecRoleId = new short[1] ;
         P004Y7_A134SecFunctionalityActive = new bool[] {false} ;
         P004Y7_n134SecFunctionalityActive = new bool[] {false} ;
         P004Y7_A128SecFunctionalityId = new long[1] ;
         AV25SecFunctionalityRole = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.asecupdatefuncionalities__default(),
            new Object[][] {
                new Object[] {
               P004Y2_A141SecUserName, P004Y2_n141SecUserName, P004Y2_A133SecUserId
               }
               , new Object[] {
               P004Y3_A140SecRoleName, P004Y3_A131SecRoleId
               }
               , new Object[] {
               }
               , new Object[] {
               P004Y5_A140SecRoleName, P004Y5_A131SecRoleId
               }
               , new Object[] {
               }
               , new Object[] {
               P004Y7_A134SecFunctionalityActive, P004Y7_n134SecFunctionalityActive, P004Y7_A128SecFunctionalityId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A133SecUserId ;
      private short AV22SecUserId ;
      private short A131SecRoleId ;
      private short AV23SecRoleId ;
      private long A128SecFunctionalityId ;
      private bool n141SecUserName ;
      private bool n134SecFunctionalityActive ;
      private bool A134SecFunctionalityActive ;
      private string AV16RoleName ;
      private string AV17AdminUserName ;
      private string A141SecUserName ;
      private string A140SecRoleName ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004Y2_A141SecUserName ;
      private bool[] P004Y2_n141SecUserName ;
      private short[] P004Y2_A133SecUserId ;
      private string[] P004Y3_A140SecRoleName ;
      private short[] P004Y3_A131SecRoleId ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV19Dvelop_menu ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> GXt_objcol_SdtDVelop_Menu_Item1 ;
      private string[] P004Y5_A140SecRoleName ;
      private short[] P004Y5_A131SecRoleId ;
      private bool[] P004Y7_A134SecFunctionalityActive ;
      private bool[] P004Y7_n134SecFunctionalityActive ;
      private long[] P004Y7_A128SecFunctionalityId ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole AV25SecFunctionalityRole ;
   }

   public class asecupdatefuncionalities__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004Y2;
          prmP004Y2 = new Object[] {
          new ParDef("AV17AdminUserName",GXType.VarChar,100,0)
          };
          Object[] prmP004Y3;
          prmP004Y3 = new Object[] {
          new ParDef("AV16RoleName",GXType.VarChar,100,0)
          };
          Object[] prmP004Y4;
          prmP004Y4 = new Object[] {
          };
          Object[] prmP004Y5;
          prmP004Y5 = new Object[] {
          };
          Object[] prmP004Y6;
          prmP004Y6 = new Object[] {
          new ParDef("AV23SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmP004Y7;
          prmP004Y7 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P004Y2", "SELECT SecUserName, SecUserId FROM SecUser WHERE SecUserName = ( :AV17AdminUserName) ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Y2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004Y3", "SELECT SecRoleName, SecRoleId FROM SecRole WHERE SecRoleName = ( :AV16RoleName) ORDER BY SecRoleId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Y3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004Y4", "UPDATE SecFunctionality SET SecFunctionalityActive=FALSE  WHERE SecFunctionalityActive", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP004Y4)
             ,new CursorDef("P004Y5", "SELECT SecRoleName, SecRoleId FROM SecRole WHERE UPPER(SecRoleName) = ( 'ADMINISTRADOR') ORDER BY SecRoleId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Y5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004Y6", "UPDATE SecFunctionalityRole SET SecFunctionalityRoleAtivo=FALSE  WHERE SecRoleId = :AV23SecRoleId", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP004Y6)
             ,new CursorDef("P004Y7", "SELECT SecFunctionalityActive, SecFunctionalityId FROM SecFunctionality WHERE SecFunctionalityActive ORDER BY SecFunctionalityId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Y7,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 5 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}
