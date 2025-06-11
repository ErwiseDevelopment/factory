using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class pfuncmenu : GXProcedure
   {
      public pfuncmenu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pfuncmenu( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_InDVelop_Menu ,
                           ref GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP1_DVelop_Menu )
      {
         this.AV9InDVelop_Menu = aP0_InDVelop_Menu;
         this.AV8DVelop_Menu = aP1_DVelop_Menu;
         initialize();
         ExecuteImpl();
         aP1_DVelop_Menu=this.AV8DVelop_Menu;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> executeUdp( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_InDVelop_Menu )
      {
         execute(aP0_InDVelop_Menu, ref aP1_DVelop_Menu);
         return AV8DVelop_Menu ;
      }

      public void executeSubmit( GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP0_InDVelop_Menu ,
                                 ref GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP1_DVelop_Menu )
      {
         this.AV9InDVelop_Menu = aP0_InDVelop_Menu;
         this.AV8DVelop_Menu = aP1_DVelop_Menu;
         SubmitImpl();
         aP1_DVelop_Menu=this.AV8DVelop_Menu;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13GXV1 = 1;
         while ( AV13GXV1 <= AV9InDVelop_Menu.Count )
         {
            AV10DVelop_MenuItem = ((GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item)AV9InDVelop_Menu.Item(AV13GXV1));
            if ( ( StringUtil.StrCmp(AV10DVelop_MenuItem.gxTpr_Authorizationkey, "") != 0 ) && ( StringUtil.StrCmp(StringUtil.Upper( AV10DVelop_MenuItem.gxTpr_Authorizationkey), "PUBLIC") != 0 ) )
            {
               new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  AV10DVelop_MenuItem.gxTpr_Authorizationkey, out  AV11IsAuthorized) ;
            }
            else
            {
               AV11IsAuthorized = true;
            }
            if ( AV10DVelop_MenuItem.gxTpr_Subitems.Count > 0 )
            {
               AV12LevelDVelop_Menu.Clear();
               new pfuncmenu(context ).execute(  AV10DVelop_MenuItem.gxTpr_Subitems, ref  AV12LevelDVelop_Menu) ;
               AV10DVelop_MenuItem.gxTpr_Subitems.FromJSonString(AV12LevelDVelop_Menu.ToJSonString(false), null);
            }
            if ( AV11IsAuthorized )
            {
               AV8DVelop_Menu.Add(AV10DVelop_MenuItem, 0);
            }
            AV13GXV1 = (int)(AV13GXV1+1);
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
         AV10DVelop_MenuItem = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         AV12LevelDVelop_Menu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "Factory21");
         /* GeneXus formulas. */
      }

      private int AV13GXV1 ;
      private bool AV11IsAuthorized ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV9InDVelop_Menu ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV8DVelop_Menu ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP1_DVelop_Menu ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item AV10DVelop_MenuItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV12LevelDVelop_Menu ;
   }

}
