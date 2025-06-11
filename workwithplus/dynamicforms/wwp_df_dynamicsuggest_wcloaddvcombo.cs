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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_dynamicsuggest_wcloaddvcombo : GXProcedure
   {
      public wwp_df_dynamicsuggest_wcloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_dynamicsuggest_wcloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_ComboName ,
                           short aP1_Cond_SessionId ,
                           short aP2_Cond_WWPFormElementId ,
                           string aP3_SearchTxtParms ,
                           out string aP4_Combo_DataJson )
      {
         this.AV10ComboName = aP0_ComboName;
         this.AV11Cond_SessionId = aP1_Cond_SessionId;
         this.AV12Cond_WWPFormElementId = aP2_Cond_WWPFormElementId;
         this.AV16SearchTxtParms = aP3_SearchTxtParms;
         this.AV9Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP4_Combo_DataJson=this.AV9Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                short aP1_Cond_SessionId ,
                                short aP2_Cond_WWPFormElementId ,
                                string aP3_SearchTxtParms )
      {
         execute(aP0_ComboName, aP1_Cond_SessionId, aP2_Cond_WWPFormElementId, aP3_SearchTxtParms, out aP4_Combo_DataJson);
         return AV9Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 short aP1_Cond_SessionId ,
                                 short aP2_Cond_WWPFormElementId ,
                                 string aP3_SearchTxtParms ,
                                 out string aP4_Combo_DataJson )
      {
         this.AV10ComboName = aP0_ComboName;
         this.AV11Cond_SessionId = aP1_Cond_SessionId;
         this.AV12Cond_WWPFormElementId = aP2_Cond_WWPFormElementId;
         this.AV16SearchTxtParms = aP3_SearchTxtParms;
         this.AV9Combo_DataJson = "" ;
         SubmitImpl();
         aP4_Combo_DataJson=this.AV9Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV18WWPContext) ;
         AV13MaxItems = 10;
         AV14PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV16SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV16SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV15SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV16SearchTxtParms)) ? "" : StringUtil.Substring( AV16SearchTxtParms, 3, -1));
         AV17SkipItems = (short)(AV14PageIndex*AV13MaxItems);
         if ( StringUtil.StrCmp(AV10ComboName, "Data") == 0 )
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
         AV21HTTPClient.AddHeader("Content-type", "application/json");
         AV20BaseUrl = StringUtil.StringReplace( AV22HTTPRequest.BaseURL, "//", "");
         AV20BaseUrl = StringUtil.Substring( AV20BaseUrl, StringUtil.StringSearch( AV20BaseUrl, "/", 1)+1, -1);
         AV20BaseUrl = StringUtil.Substring( AV20BaseUrl, 1, StringUtil.StringSearch( AV20BaseUrl, "/", 1));
         AV21HTTPClient.Host = AV22HTTPRequest.ServerHost;
         AV21HTTPClient.Port = AV22HTTPRequest.ServerPort;
         AV21HTTPClient.Secure = AV22HTTPRequest.Secure;
         AV21HTTPClient.BaseURL = AV20BaseUrl+"rest";
         AV26ServiceName = StringUtil.Lower( AV27WWP_DF_CharMetadata.gxTpr_Multipleoptions.gxTpr_Dynamic.gxTpr_Getoptionsservice);
         AV26ServiceName = StringUtil.Upper( StringUtil.Substring( AV26ServiceName, 1, 1)) + StringUtil.Substring( AV26ServiceName, 2, -1);
         AV24Request = StringUtil.Format( "%1?Sessionid=%2&Wwpformelementid=%3&MaxItems=%4&PageIndex=%5&SearchTxt=%6", AV26ServiceName, StringUtil.LTrimStr( (decimal)(AV11Cond_SessionId), 4, 0), StringUtil.LTrimStr( (decimal)(AV12Cond_WWPFormElementId), 4, 0), StringUtil.LTrimStr( (decimal)(AV13MaxItems), 6, 0), StringUtil.LTrimStr( (decimal)(AV14PageIndex), 4, 0), AV15SearchTxt, "", "", "");
         AV21HTTPClient.Execute("POST", AV24Request);
         if ( AV21HTTPClient.StatusCode == 200 )
         {
            AV25result = AV21HTTPClient.ToString();
            AV23i = (short)(StringUtil.StringSearch( AV25result, ":", 1));
            if ( AV23i > 0 )
            {
               AV25result = "{\"Result\"" + StringUtil.Substring( AV25result, AV23i, -1);
               AV19SDTResult.FromJSonString(AV25result, null);
               AV25result = AV19SDTResult.gxTpr_Result;
            }
            AV8Combo_Data.FromJSonString(AV25result, null);
            new GeneXus.Programs.wwpbaseobjects.wwp_extendedcombopagedata(context ).execute( ref  AV8Combo_Data,  AV17SkipItems,  AV13MaxItems) ;
            AV8Combo_Data.Sort("Title");
            AV9Combo_DataJson = AV8Combo_Data.ToJSonString(false);
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
         AV9Combo_DataJson = "";
         AV18WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV15SearchTxt = "";
         AV21HTTPClient = new GxHttpClient( context);
         AV20BaseUrl = "";
         AV22HTTPRequest = new GxHttpRequest( context);
         AV26ServiceName = "";
         AV27WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV24Request = "";
         AV25result = "";
         AV19SDTResult = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTResult(context);
         AV8Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         /* GeneXus formulas. */
      }

      private short AV11Cond_SessionId ;
      private short AV12Cond_WWPFormElementId ;
      private short AV14PageIndex ;
      private short AV17SkipItems ;
      private short AV23i ;
      private int AV13MaxItems ;
      private bool returnInSub ;
      private string AV9Combo_DataJson ;
      private string AV10ComboName ;
      private string AV16SearchTxtParms ;
      private string AV15SearchTxt ;
      private string AV20BaseUrl ;
      private string AV26ServiceName ;
      private string AV24Request ;
      private string AV25result ;
      private GxHttpClient AV21HTTPClient ;
      private GxHttpRequest AV22HTTPRequest ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV18WWPContext ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV27WWP_DF_CharMetadata ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTResult AV19SDTResult ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV8Combo_Data ;
      private string aP4_Combo_DataJson ;
   }

}
