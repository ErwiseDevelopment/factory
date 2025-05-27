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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_import : GXProcedure
   {
      public wwp_df_import( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_import( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_FilePath ,
                           bool aP1_Overwrite ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ,
                           out bool aP3_IsOk )
      {
         this.AV9FilePath = aP0_FilePath;
         this.AV12Overwrite = aP1_Overwrite;
         this.AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV10IsOk = false ;
         initialize();
         ExecuteImpl();
         aP2_Messages=this.AV11Messages;
         aP3_IsOk=this.AV10IsOk;
      }

      public bool executeUdp( string aP0_FilePath ,
                              bool aP1_Overwrite ,
                              out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages )
      {
         execute(aP0_FilePath, aP1_Overwrite, out aP2_Messages, out aP3_IsOk);
         return AV10IsOk ;
      }

      public void executeSubmit( string aP0_FilePath ,
                                 bool aP1_Overwrite ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ,
                                 out bool aP3_IsOk )
      {
         this.AV9FilePath = aP0_FilePath;
         this.AV12Overwrite = aP1_Overwrite;
         this.AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         this.AV10IsOk = false ;
         SubmitImpl();
         aP2_Messages=this.AV11Messages;
         aP3_IsOk=this.AV10IsOk;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV10IsOk = true;
         AV8File.Source = AV9FilePath;
         AV10IsOk = AV13WWPForm.FromJSonFile(AV8File, null);
         if ( AV10IsOk )
         {
            GXt_boolean1 = AV20UniqueReferenceName;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_validateuniquereferencename(context ).execute(  0,  AV13WWPForm.gxTpr_Wwpformreferencename, out  GXt_boolean1) ;
            AV20UniqueReferenceName = GXt_boolean1;
            if ( AV20UniqueReferenceName )
            {
               /* Using cursor P00492 */
               pr_default.execute(0);
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A94WWPFormId = P00492_A94WWPFormId[0];
                  A95WWPFormVersionNumber = P00492_A95WWPFormVersionNumber[0];
                  AV13WWPForm.gxTpr_Wwpformid = A94WWPFormId;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               AV13WWPForm.gxTpr_Wwpformid = (short)(AV13WWPForm.gxTpr_Wwpformid+1);
               AV13WWPForm.gxTpr_Wwpformversionnumber = 1;
               AV13WWPForm.gxTpr_Wwpformdate = DateTimeUtil.Now( context);
               AV13WWPForm.Insert();
               /* Execute user subroutine: 'EVALUATEANDCOMMITFORM' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else
            {
               if ( AV12Overwrite )
               {
                  /* Using cursor P00493 */
                  pr_default.execute(1, new Object[] {AV13WWPForm.gxTpr_Wwpformreferencename});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A96WWPFormReferenceName = P00493_A96WWPFormReferenceName[0];
                     A94WWPFormId = P00493_A94WWPFormId[0];
                     A122WWPFormInstantiated = P00493_A122WWPFormInstantiated[0];
                     A119WWPFormDate = P00493_A119WWPFormDate[0];
                     A95WWPFormVersionNumber = P00493_A95WWPFormVersionNumber[0];
                     AV14WWPFormId = A94WWPFormId;
                     AV16WWPFormVersionNumber = A95WWPFormVersionNumber;
                     AV19FormWasInstantiated = A122WWPFormInstantiated;
                     AV17WWPFormDate = A119WWPFormDate;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     pr_default.readNext(1);
                  }
                  pr_default.close(1);
                  if ( AV19FormWasInstantiated )
                  {
                     AV15NewWWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
                     AV15NewWWPForm.gxTpr_Wwpformid = AV14WWPFormId;
                     AV15NewWWPForm.gxTpr_Wwpformversionnumber = (short)(AV16WWPFormVersionNumber+1);
                     AV15NewWWPForm.gxTpr_Wwpformreferencename = AV13WWPForm.gxTpr_Wwpformreferencename;
                  }
                  else
                  {
                     AV15NewWWPForm.Load(AV14WWPFormId, AV16WWPFormVersionNumber);
                     AV15NewWWPForm.gxTpr_Element.Clear();
                     AV15NewWWPForm.gxTpr_Element.Sort("(WWPFormElementId)");
                     AV15NewWWPForm.Save();
                  }
                  AV15NewWWPForm.gxTpr_Wwpformtitle = AV13WWPForm.gxTpr_Wwpformtitle;
                  AV15NewWWPForm.gxTpr_Wwpformiswizard = AV13WWPForm.gxTpr_Wwpformiswizard;
                  AV15NewWWPForm.gxTpr_Wwpformvalidations = AV13WWPForm.gxTpr_Wwpformvalidations;
                  AV15NewWWPForm.gxTpr_Wwpformresume = AV13WWPForm.gxTpr_Wwpformresume;
                  AV15NewWWPForm.gxTpr_Wwpformresumemessage = AV13WWPForm.gxTpr_Wwpformresumemessage;
                  AV23GXV1 = 1;
                  while ( AV23GXV1 <= AV13WWPForm.gxTpr_Element.Count )
                  {
                     AV18Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV13WWPForm.gxTpr_Element.Item(AV23GXV1));
                     if ( AV18Element.gxTpr_Wwpformelementparentid >= 0 )
                     {
                        AV15NewWWPForm.gxTpr_Element.Add(AV18Element, 0);
                     }
                     AV23GXV1 = (int)(AV23GXV1+1);
                  }
                  AV13WWPForm = AV15NewWWPForm;
                  AV13WWPForm.gxTpr_Wwpformdate = DateTimeUtil.Now( context);
                  AV13WWPForm.Save();
                  /* Execute user subroutine: 'EVALUATEANDCOMMITFORM' */
                  S111 ();
                  if ( returnInSub )
                  {
                     cleanup();
                     if (true) return;
                  }
               }
               else
               {
                  AV10IsOk = false;
                  new GeneXus.Programs.wwpbaseobjects.wwp_addmessage(context ).execute(  "WWP_DF_Import_ReferenceExistentTitle",  1,  "Nome de referência existente", ref  AV11Messages) ;
               }
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'EVALUATEANDCOMMITFORM' Routine */
         returnInSub = false;
         if ( AV13WWPForm.Success() )
         {
            context.CommitDataStores("workwithplus.dynamicforms.wwp_df_import",pr_default);
         }
         else
         {
            new GeneXus.Programs.wwpbaseobjects.wwp_addimporterrormessages(context ).execute( ref  AV11Messages,  "",  AV13WWPForm.GetMessages()) ;
            AV10IsOk = false;
         }
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
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV8File = new GxFile(context.GetPhysicalPath());
         AV13WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         P00492_A94WWPFormId = new short[1] ;
         P00492_A95WWPFormVersionNumber = new short[1] ;
         P00493_A96WWPFormReferenceName = new string[] {""} ;
         P00493_A94WWPFormId = new short[1] ;
         P00493_A122WWPFormInstantiated = new bool[] {false} ;
         P00493_A119WWPFormDate = new DateTime[] {DateTime.MinValue} ;
         P00493_A95WWPFormVersionNumber = new short[1] ;
         A96WWPFormReferenceName = "";
         A119WWPFormDate = (DateTime)(DateTime.MinValue);
         AV17WWPFormDate = (DateTime)(DateTime.MinValue);
         AV15NewWWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV18Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_import__default(),
            new Object[][] {
                new Object[] {
               P00492_A94WWPFormId, P00492_A95WWPFormVersionNumber
               }
               , new Object[] {
               P00493_A96WWPFormReferenceName, P00493_A94WWPFormId, P00493_A122WWPFormInstantiated, P00493_A119WWPFormDate, P00493_A95WWPFormVersionNumber
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A94WWPFormId ;
      private short A95WWPFormVersionNumber ;
      private short AV14WWPFormId ;
      private short AV16WWPFormVersionNumber ;
      private int AV23GXV1 ;
      private DateTime A119WWPFormDate ;
      private DateTime AV17WWPFormDate ;
      private bool AV12Overwrite ;
      private bool AV10IsOk ;
      private bool AV20UniqueReferenceName ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool A122WWPFormInstantiated ;
      private bool AV19FormWasInstantiated ;
      private string AV9FilePath ;
      private string A96WWPFormReferenceName ;
      private GxFile AV8File ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV13WWPForm ;
      private IDataStoreProvider pr_default ;
      private short[] P00492_A94WWPFormId ;
      private short[] P00492_A95WWPFormVersionNumber ;
      private string[] P00493_A96WWPFormReferenceName ;
      private short[] P00493_A94WWPFormId ;
      private bool[] P00493_A122WWPFormInstantiated ;
      private DateTime[] P00493_A119WWPFormDate ;
      private short[] P00493_A95WWPFormVersionNumber ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV15NewWWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV18Element ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP2_Messages ;
      private bool aP3_IsOk ;
   }

   public class wwp_df_import__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00492;
          prmP00492 = new Object[] {
          };
          Object[] prmP00493;
          prmP00493 = new Object[] {
          new ParDef("AV13WWPF_1Wwpformreferencenam",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00492", "SELECT WWPFormId, WWPFormVersionNumber FROM WWP_Form ORDER BY WWPFormId DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00492,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00493", "SELECT WWPFormReferenceName, WWPFormId, WWPFormInstantiated, WWPFormDate, WWPFormVersionNumber FROM WWP_Form WHERE WWPFormReferenceName = ( :AV13WWPF_1Wwpformreferencenam) ORDER BY WWPFormReferenceName, WWPFormVersionNumber DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00493,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
