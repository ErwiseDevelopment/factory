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
   public class prgravadevelopmenu : GXProcedure
   {
      public prgravadevelopmenu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prgravadevelopmenu( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Dvelop_menu ,
                           long aP1_SecParentFunctionalityId ,
                           string aP2_SecFunctionalityModule )
      {
         this.AV8Dvelop_menu = aP0_Dvelop_menu;
         this.AV12SecParentFunctionalityId = aP1_SecParentFunctionalityId;
         this.AV13SecFunctionalityModule = aP2_SecFunctionalityModule;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_Dvelop_menu ,
                                 long aP1_SecParentFunctionalityId ,
                                 string aP2_SecFunctionalityModule )
      {
         this.AV8Dvelop_menu = aP0_Dvelop_menu;
         this.AV12SecParentFunctionalityId = aP1_SecParentFunctionalityId;
         this.AV13SecFunctionalityModule = aP2_SecFunctionalityModule;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14GXV1 = 1;
         while ( AV14GXV1 <= AV8Dvelop_menu.Count )
         {
            AV10Dvelop_menuItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item)AV8Dvelop_menu.Item(AV14GXV1));
            context.StatusMessage( AV10Dvelop_menuItem.ToJSonString(false, true) );
            if ( ( StringUtil.StrCmp(AV10Dvelop_menuItem.gxTpr_Authorizationkey, "") != 0 ) && ( StringUtil.StrCmp(StringUtil.Upper( AV10Dvelop_menuItem.gxTpr_Authorizationkey), "PUBLIC") != 0 ) )
            {
               AV15GXLvl6 = 0;
               n789SecFunctionalityModule = false;
               n134SecFunctionalityActive = false;
               n135SecFunctionalityDescription = false;
               /* Optimized UPDATE. */
               /* Using cursor P00D52 */
               pr_default.execute(0, new Object[] {n789SecFunctionalityModule, AV13SecFunctionalityModule, n135SecFunctionalityDescription, AV10Dvelop_menuItem.gxTpr_Caption, AV10Dvelop_menuItem.gxTpr_Authorizationkey});
               if ( (pr_default.getStatus(0) != 101) )
               {
                  AV15GXLvl6 = 1;
               }
               pr_default.close(0);
               pr_default.SmartCacheProvider.SetUpdated("SecFunctionality");
               /* End optimized UPDATE. */
               if ( AV15GXLvl6 == 0 )
               {
                  AV9SecFunctionality = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality(context);
                  AV9SecFunctionality.gxTpr_Secfunctionalitykey = StringUtil.Upper( AV10Dvelop_menuItem.gxTpr_Authorizationkey);
                  AV9SecFunctionality.gxTpr_Secfunctionalitydescription = AV10Dvelop_menuItem.gxTpr_Caption;
                  AV9SecFunctionality.gxTpr_Secfunctionalitytype = 4;
                  AV9SecFunctionality.gxTpr_Secfunctionalityactive = true;
                  AV9SecFunctionality.gxTpr_Secfunctionalitymodule = AV13SecFunctionalityModule;
                  if ( ! (0==AV12SecParentFunctionalityId) )
                  {
                     AV9SecFunctionality.gxTpr_Secparentfunctionalityid = AV12SecParentFunctionalityId;
                  }
                  AV9SecFunctionality.Save();
               }
            }
            if ( AV10Dvelop_menuItem.gxTpr_Subitems.Count > 0 )
            {
               new prgravadevelopmenu(context ).execute(  AV10Dvelop_menuItem.gxTpr_Subitems,  AV9SecFunctionality.gxTpr_Secfunctionalityid,  "") ;
            }
            AV14GXV1 = (int)(AV14GXV1+1);
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
         AV10Dvelop_menuItem = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         A789SecFunctionalityModule = "";
         A135SecFunctionalityDescription = "";
         AV9SecFunctionality = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prgravadevelopmenu__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV15GXLvl6 ;
      private int AV14GXV1 ;
      private long AV12SecParentFunctionalityId ;
      private bool n789SecFunctionalityModule ;
      private bool n134SecFunctionalityActive ;
      private bool n135SecFunctionalityDescription ;
      private string AV13SecFunctionalityModule ;
      private string A789SecFunctionalityModule ;
      private string A135SecFunctionalityDescription ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV8Dvelop_menu ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item AV10Dvelop_menuItem ;
      private IDataStoreProvider pr_default ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecFunctionality AV9SecFunctionality ;
   }

   public class prgravadevelopmenu__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new UpdateCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00D52;
          prmP00D52 = new Object[] {
          new ParDef("SecFunctionalityModule",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecFunctionalityDescription",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("AV10Dvel_1Authorizationkey",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D52", "UPDATE SecFunctionality SET SecFunctionalityModule=:SecFunctionalityModule, SecFunctionalityActive=TRUE, SecFunctionalityDescription=:SecFunctionalityDescription  WHERE SecFunctionalityKey = ( UPPER(:AV10Dvel_1Authorizationkey))", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00D52)
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
