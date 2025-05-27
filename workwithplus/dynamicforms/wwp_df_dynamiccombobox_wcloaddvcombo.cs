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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_dynamiccombobox_wcloaddvcombo : GXProcedure
   {
      public wwp_df_dynamiccombobox_wcloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_dynamiccombobox_wcloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           short aP1_Cond_SessionId ,
                           short aP2_Cond_WWPFormElementId ,
                           string aP3_SearchTxtParms ,
                           out string aP4_Combo_DataJson )
      {
         this.AV15ComboName = aP0_ComboName;
         this.AV16Cond_SessionId = aP1_Cond_SessionId;
         this.AV17Cond_WWPFormElementId = aP2_Cond_WWPFormElementId;
         this.AV28SearchTxtParms = aP3_SearchTxtParms;
         this.AV14Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP4_Combo_DataJson=this.AV14Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                short aP1_Cond_SessionId ,
                                short aP2_Cond_WWPFormElementId ,
                                string aP3_SearchTxtParms )
      {
         execute(aP0_ComboName, aP1_Cond_SessionId, aP2_Cond_WWPFormElementId, aP3_SearchTxtParms, out aP4_Combo_DataJson);
         return AV14Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 short aP1_Cond_SessionId ,
                                 short aP2_Cond_WWPFormElementId ,
                                 string aP3_SearchTxtParms ,
                                 out string aP4_Combo_DataJson )
      {
         this.AV15ComboName = aP0_ComboName;
         this.AV16Cond_SessionId = aP1_Cond_SessionId;
         this.AV17Cond_WWPFormElementId = aP2_Cond_WWPFormElementId;
         this.AV28SearchTxtParms = aP3_SearchTxtParms;
         this.AV14Combo_DataJson = "" ;
         SubmitImpl();
         aP4_Combo_DataJson=this.AV14Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtWWP_FormInstance1 = AV10WWPFormInstance;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadforminstance(context ).execute(  AV16Cond_SessionId, out  GXt_SdtWWP_FormInstance1) ;
         AV10WWPFormInstance = GXt_SdtWWP_FormInstance1;
         AV18Cond_WWPFormId = AV10WWPFormInstance.gxTpr_Wwpformid;
         AV19Cond_WWPFormVersionNumber = AV10WWPFormInstance.gxTpr_Wwpformversionnumber;
         /* Using cursor P00402 */
         pr_default.execute(0, new Object[] {AV18Cond_WWPFormId, AV19Cond_WWPFormVersionNumber, AV17Cond_WWPFormElementId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A98WWPFormElementId = P00402_A98WWPFormElementId[0];
            A95WWPFormVersionNumber = P00402_A95WWPFormVersionNumber[0];
            A94WWPFormId = P00402_A94WWPFormId[0];
            A124WWPFormElementMetadata = P00402_A124WWPFormElementMetadata[0];
            AV32WWP_DF_CharMetadata.FromJSonString(A124WWPFormElementMetadata, null);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV33WWPContext) ;
         AV24MaxItems = 10;
         AV25PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV28SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV28SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV27SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV28SearchTxtParms)) ? "" : StringUtil.Substring( AV28SearchTxtParms, 3, -1));
         AV31SkipItems = (short)(AV25PageIndex*AV24MaxItems);
         if ( StringUtil.StrCmp(AV15ComboName, "Data") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_DATA' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_DATA' Routine */
         returnInSub = false;
         AV20HTTPClient.AddHeader("Content-type", "application/json");
         AV11BaseUrl = StringUtil.StringReplace( AV21HTTPRequest.BaseURL, "//", "");
         AV11BaseUrl = StringUtil.Substring( AV11BaseUrl, StringUtil.StringSearch( AV11BaseUrl, "/", 1)+1, -1);
         AV11BaseUrl = StringUtil.Substring( AV11BaseUrl, 1, StringUtil.StringSearch( AV11BaseUrl, "/", 1));
         AV20HTTPClient.Host = AV21HTTPRequest.ServerHost;
         AV20HTTPClient.Port = AV21HTTPRequest.ServerPort;
         AV20HTTPClient.Secure = AV21HTTPRequest.Secure;
         AV20HTTPClient.BaseURL = AV11BaseUrl+"rest";
         AV30ServiceName = StringUtil.Lower( AV32WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Dynamic.gxTpr_Getoptionsservice);
         AV30ServiceName = StringUtil.Upper( StringUtil.Substring( AV30ServiceName, 1, 1)) + StringUtil.Substring( AV30ServiceName, 2, -1);
         AV8Properties.Set("WWPFormInstanceJson", AV10WWPFormInstance.ToJSonString(true, true));
         AV8Properties.Set("SessionId", StringUtil.Str( (decimal)(AV16Cond_SessionId), 4, 0));
         AV8Properties.Set("WWPFormElementId", StringUtil.Str( (decimal)(AV17Cond_WWPFormElementId), 4, 0));
         AV8Properties.Set("MaxItems", StringUtil.Str( (decimal)(AV24MaxItems), 6, 0));
         AV8Properties.Set("PageIndex", StringUtil.Str( (decimal)(AV25PageIndex), 4, 0));
         AV8Properties.Set("SearchTxt", AV27SearchTxt);
         AV20HTTPClient.AddString(AV8Properties.ToJSonString());
         AV20HTTPClient.Execute("POST", AV30ServiceName);
         if ( AV20HTTPClient.StatusCode == 200 )
         {
            AV26Result = AV20HTTPClient.ToString();
            AV22i = (short)(StringUtil.StringSearch( AV26Result, ":", 1));
            if ( AV22i > 0 )
            {
               AV26Result = "{\"Result\"" + StringUtil.Substring( AV26Result, AV22i, -1);
               AV9SDTResult.FromJSonString(AV26Result, null);
               AV26Result = AV9SDTResult.gxTpr_Result;
            }
            AV12Combo_Data.FromJSonString(AV26Result, null);
            new GeneXus.Programs.wwpbaseobjects.wwp_extendedcombopagedata(context ).execute( ref  AV12Combo_Data,  AV31SkipItems,  AV24MaxItems) ;
            AV14Combo_DataJson = AV12Combo_Data.ToJSonString(false);
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
         AV14Combo_DataJson = "";
         AV10WWPFormInstance = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         GXt_SdtWWP_FormInstance1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance(context);
         P00402_A98WWPFormElementId = new short[1] ;
         P00402_A95WWPFormVersionNumber = new short[1] ;
         P00402_A94WWPFormId = new short[1] ;
         P00402_A124WWPFormElementMetadata = new string[] {""} ;
         A124WWPFormElementMetadata = "";
         AV32WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV33WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27SearchTxt = "";
         AV20HTTPClient = new GxHttpClient( context);
         AV11BaseUrl = "";
         AV21HTTPRequest = new GxHttpRequest( context);
         AV30ServiceName = "";
         AV8Properties = new GXProperties();
         AV26Result = "";
         AV9SDTResult = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTResult(context);
         AV12Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_dynamiccombobox_wcloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00402_A98WWPFormElementId, P00402_A95WWPFormVersionNumber, P00402_A94WWPFormId, P00402_A124WWPFormElementMetadata
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16Cond_SessionId ;
      private short AV17Cond_WWPFormElementId ;
      private short AV18Cond_WWPFormId ;
      private short AV19Cond_WWPFormVersionNumber ;
      private short A98WWPFormElementId ;
      private short A95WWPFormVersionNumber ;
      private short A94WWPFormId ;
      private short AV25PageIndex ;
      private short AV31SkipItems ;
      private short AV22i ;
      private int AV24MaxItems ;
      private bool returnInSub ;
      private string AV14Combo_DataJson ;
      private string A124WWPFormElementMetadata ;
      private string AV15ComboName ;
      private string AV28SearchTxtParms ;
      private string AV27SearchTxt ;
      private string AV11BaseUrl ;
      private string AV30ServiceName ;
      private string AV26Result ;
      private GxHttpClient AV20HTTPClient ;
      private GxHttpRequest AV21HTTPRequest ;
      private GXProperties AV8Properties ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV10WWPFormInstance ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance GXt_SdtWWP_FormInstance1 ;
      private IDataStoreProvider pr_default ;
      private short[] P00402_A98WWPFormElementId ;
      private short[] P00402_A95WWPFormVersionNumber ;
      private short[] P00402_A94WWPFormId ;
      private string[] P00402_A124WWPFormElementMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV32WWP_DF_CharMetadata ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV33WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTResult AV9SDTResult ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV12Combo_Data ;
      private string aP4_Combo_DataJson ;
   }

   public class wwp_df_dynamiccombobox_wcloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00402;
          prmP00402 = new Object[] {
          new ParDef("AV18Cond_WWPFormId",GXType.Int16,4,0) ,
          new ParDef("AV19Cond_WWPFormVersionNumber",GXType.Int16,4,0) ,
          new ParDef("AV17Cond_WWPFormElementId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00402", "SELECT WWPFormElementId, WWPFormVersionNumber, WWPFormId, WWPFormElementMetadata FROM WWP_FormElement WHERE WWPFormId = :AV18Cond_WWPFormId and WWPFormVersionNumber = :AV19Cond_WWPFormVersionNumber and WWPFormElementId = :AV17Cond_WWPFormElementId ORDER BY WWPFormId, WWPFormVersionNumber, WWPFormElementId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00402,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                return;
       }
    }

 }

}
