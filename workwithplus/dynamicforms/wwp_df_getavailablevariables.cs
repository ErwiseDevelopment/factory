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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_getavailablevariables : GXProcedure
   {
      public wwp_df_getavailablevariables( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_getavailablevariables( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( short aP0_SessionId ,
                           bool aP1_IncludeCurrentElement ,
                           short aP2_CurrentElementId ,
                           short aP3_MaxOptions ,
                           string aP4_SearchTxt ,
                           out string aP5_OptionsJson )
      {
         this.AV17SessionId = aP0_SessionId;
         this.AV13IncludeCurrentElement = aP1_IncludeCurrentElement;
         this.AV16CurrentElementId = aP2_CurrentElementId;
         this.AV8MaxOptions = aP3_MaxOptions;
         this.AV12SearchTxt = aP4_SearchTxt;
         this.AV11OptionsJson = "" ;
         initialize();
         ExecuteImpl();
         aP5_OptionsJson=this.AV11OptionsJson;
      }

      public string executeUdp( short aP0_SessionId ,
                                bool aP1_IncludeCurrentElement ,
                                short aP2_CurrentElementId ,
                                short aP3_MaxOptions ,
                                string aP4_SearchTxt )
      {
         execute(aP0_SessionId, aP1_IncludeCurrentElement, aP2_CurrentElementId, aP3_MaxOptions, aP4_SearchTxt, out aP5_OptionsJson);
         return AV11OptionsJson ;
      }

      public void executeSubmit( short aP0_SessionId ,
                                 bool aP1_IncludeCurrentElement ,
                                 short aP2_CurrentElementId ,
                                 short aP3_MaxOptions ,
                                 string aP4_SearchTxt ,
                                 out string aP5_OptionsJson )
      {
         this.AV17SessionId = aP0_SessionId;
         this.AV13IncludeCurrentElement = aP1_IncludeCurrentElement;
         this.AV16CurrentElementId = aP2_CurrentElementId;
         this.AV8MaxOptions = aP3_MaxOptions;
         this.AV12SearchTxt = aP4_SearchTxt;
         this.AV11OptionsJson = "" ;
         SubmitImpl();
         aP5_OptionsJson=this.AV11OptionsJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Options = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "Factory21");
         GXt_SdtWWP_Form1 = AV14WWPForm;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV17SessionId, out  GXt_SdtWWP_Form1) ;
         AV14WWPForm = GXt_SdtWWP_Form1;
         GXt_int2 = AV18CurrentElementMultipleDataId;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getparentmultipledataid(context ).execute( ref  AV14WWPForm,  AV16CurrentElementId, out  GXt_int2) ;
         AV18CurrentElementMultipleDataId = GXt_int2;
         AV23GXV1 = 1;
         while ( AV23GXV1 <= AV14WWPForm.gxTpr_Element.Count )
         {
            AV15Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element)AV14WWPForm.gxTpr_Element.Item(AV23GXV1));
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15Element.gxTpr_Wwpformelementreferenceid)) && ( AV15Element.gxTpr_Wwpformelementid != AV16CurrentElementId ) && ( String.IsNullOrEmpty(StringUtil.RTrim( AV12SearchTxt)) || StringUtil.Contains( StringUtil.Lower( AV15Element.gxTpr_Wwpformelementreferenceid), StringUtil.Lower( AV12SearchTxt)) ) )
            {
               GXt_int2 = AV19ElementMultipleDataId;
               new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getparentmultipledataid(context ).execute( ref  AV14WWPForm,  AV15Element.gxTpr_Wwpformelementid, out  GXt_int2) ;
               AV19ElementMultipleDataId = GXt_int2;
               if ( (0==AV19ElementMultipleDataId) || ( AV19ElementMultipleDataId == AV18CurrentElementMultipleDataId ) )
               {
                  AV9Option = new GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem(context);
                  AV9Option.gxTpr_Id = AV15Element.gxTpr_Wwpformelementreferenceid+((AV15Element.gxTpr_Wwpformelementtype==3) ? "_Repetitions" : "");
                  AV9Option.gxTpr_Displayname = AV9Option.gxTpr_Id;
                  AV9Option.gxTpr_Text.Add(AV9Option.gxTpr_Id, 0);
                  AV10Options.Add(AV9Option, 0);
               }
            }
            AV23GXV1 = (int)(AV23GXV1+1);
         }
         if ( AV14WWPForm.gxTpr_Wwpformtype == 1 )
         {
            AV21SectionReferencedElements.FromJSonString(AV14WWPForm.gxTpr_Wwpformsectionrefelements, null);
            AV20Property = AV21SectionReferencedElements.GetFirst();
            while ( ! AV21SectionReferencedElements.Eof() )
            {
               AV9Option = new GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem(context);
               AV9Option.gxTpr_Id = AV20Property.Key;
               AV9Option.gxTpr_Displayname = AV9Option.gxTpr_Id;
               AV9Option.gxTpr_Text.Add(AV9Option.gxTpr_Id, 0);
               AV10Options.Add(AV9Option, 0);
               AV20Property = AV21SectionReferencedElements.GetNext();
            }
         }
         AV9Option = new GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem(context);
         AV9Option.gxTpr_Id = "Today";
         AV9Option.gxTpr_Displayname = AV9Option.gxTpr_Id;
         AV9Option.gxTpr_Text.Add(AV9Option.gxTpr_Id, 0);
         AV10Options.Add(AV9Option, 0);
         if ( AV13IncludeCurrentElement )
         {
            AV9Option = new GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem(context);
            AV9Option.gxTpr_Id = "Value";
            AV9Option.gxTpr_Displayname = AV9Option.gxTpr_Id;
            AV9Option.gxTpr_Text.Add(AV9Option.gxTpr_Id, 0);
            AV10Options.Add(AV9Option, 0);
         }
         AV10Options.Sort("DisplayName");
         while ( AV10Options.Count > AV8MaxOptions )
         {
            AV10Options.RemoveItem(AV10Options.Count);
         }
         AV11OptionsJson = AV10Options.ToJSonString(false);
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
         AV11OptionsJson = "";
         AV10Options = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "Factory21");
         AV14WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         GXt_SdtWWP_Form1 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV15Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         AV9Option = new GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem(context);
         AV21SectionReferencedElements = new GXProperties();
         AV20Property = new GxKeyValuePair();
         /* GeneXus formulas. */
      }

      private short AV17SessionId ;
      private short AV16CurrentElementId ;
      private short AV8MaxOptions ;
      private short AV18CurrentElementMultipleDataId ;
      private short AV19ElementMultipleDataId ;
      private short GXt_int2 ;
      private int AV23GXV1 ;
      private bool AV13IncludeCurrentElement ;
      private string AV11OptionsJson ;
      private string AV12SearchTxt ;
      private GXProperties AV21SectionReferencedElements ;
      private GxKeyValuePair AV20Property ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem> AV10Options ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV14WWPForm ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form GXt_SdtWWP_Form1 ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV15Element ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem AV9Option ;
      private string aP5_OptionsJson ;
   }

}
