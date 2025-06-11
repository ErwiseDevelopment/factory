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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_gridstateadddynfiltervalue : GXProcedure
   {
      public wwp_gridstateadddynfiltervalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_gridstateadddynfiltervalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter aP0_GridStateDynamicFilter ,
                           string aP1_FilterDsc ,
                           short aP2_FilterOperator ,
                           string aP3_FilterValue ,
                           string aP4_FilterValueDsc ,
                           bool aP5_IsRange ,
                           string aP6_FilterValueTo ,
                           string aP7_FilterValueToDsc )
      {
         this.AV15GridStateDynamicFilter = aP0_GridStateDynamicFilter;
         this.AV8FilterDsc = aP1_FilterDsc;
         this.AV9FilterOperator = aP2_FilterOperator;
         this.AV10FilterValue = aP3_FilterValue;
         this.AV11FilterValueDsc = aP4_FilterValueDsc;
         this.AV14IsRange = aP5_IsRange;
         this.AV12FilterValueTo = aP6_FilterValueTo;
         this.AV13FilterValueToDsc = aP7_FilterValueToDsc;
         initialize();
         ExecuteImpl();
         aP0_GridStateDynamicFilter=this.AV15GridStateDynamicFilter;
      }

      public void executeSubmit( ref GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter aP0_GridStateDynamicFilter ,
                                 string aP1_FilterDsc ,
                                 short aP2_FilterOperator ,
                                 string aP3_FilterValue ,
                                 string aP4_FilterValueDsc ,
                                 bool aP5_IsRange ,
                                 string aP6_FilterValueTo ,
                                 string aP7_FilterValueToDsc )
      {
         this.AV15GridStateDynamicFilter = aP0_GridStateDynamicFilter;
         this.AV8FilterDsc = aP1_FilterDsc;
         this.AV9FilterOperator = aP2_FilterOperator;
         this.AV10FilterValue = aP3_FilterValue;
         this.AV11FilterValueDsc = aP4_FilterValueDsc;
         this.AV14IsRange = aP5_IsRange;
         this.AV12FilterValueTo = aP6_FilterValueTo;
         this.AV13FilterValueToDsc = aP7_FilterValueToDsc;
         SubmitImpl();
         aP0_GridStateDynamicFilter=this.AV15GridStateDynamicFilter;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15GridStateDynamicFilter.gxTpr_Dsc = AV8FilterDsc;
         AV15GridStateDynamicFilter.gxTpr_Value = AV10FilterValue;
         AV15GridStateDynamicFilter.gxTpr_Valuedsc = AV11FilterValueDsc;
         AV15GridStateDynamicFilter.gxTpr_Operator = AV9FilterOperator;
         AV15GridStateDynamicFilter.gxTpr_Valueto = AV12FilterValueTo;
         if ( AV14IsRange )
         {
            AV15GridStateDynamicFilter.gxTpr_Valuetodsc = AV13FilterValueToDsc;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterValueToDsc)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV11FilterValueDsc)) )
            {
               AV15GridStateDynamicFilter.gxTpr_Valuedsc = StringUtil.Format( "from %1", AV11FilterValueDsc, "", "", "", "", "", "", "", "");
            }
            else
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11FilterValueDsc)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterValueToDsc)) )
               {
                  AV15GridStateDynamicFilter.gxTpr_Valuetodsc = StringUtil.Format( "up to %1", AV13FilterValueToDsc, "", "", "", "", "", "", "", "");
               }
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
         /* GeneXus formulas. */
      }

      private short AV9FilterOperator ;
      private bool AV14IsRange ;
      private string AV8FilterDsc ;
      private string AV10FilterValue ;
      private string AV11FilterValueDsc ;
      private string AV12FilterValueTo ;
      private string AV13FilterValueToDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV15GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter aP0_GridStateDynamicFilter ;
   }

}
