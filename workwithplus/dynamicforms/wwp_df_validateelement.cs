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
   public class wwp_df_validateelement : GXProcedure
   {
      public wwp_df_validateelement( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_validateelement( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                           string aP1_WWPFormInstanceElementJson ,
                           bool aP2_HasDeletedElements ,
                           ref GxSimpleCollection<string> aP3_HiddenContainers ,
                           out bool aP4_HasErrors ,
                           out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages )
      {
         this.AV23WWPFormInstance = aP0_WWPFormInstance;
         this.AV27WWPFormInstanceElementJson = aP1_WWPFormInstanceElementJson;
         this.AV10HasDeletedElements = aP2_HasDeletedElements;
         this.AV12HiddenContainers = aP3_HiddenContainers;
         this.AV11HasErrors = false ;
         this.AV15Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         initialize();
         ExecuteImpl();
         aP3_HiddenContainers=this.AV12HiddenContainers;
         aP4_HasErrors=this.AV11HasErrors;
         aP5_Messages=this.AV15Messages;
      }

      public GXBaseCollection<GeneXus.Utils.SdtMessages_Message> executeUdp( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                                                             string aP1_WWPFormInstanceElementJson ,
                                                                             bool aP2_HasDeletedElements ,
                                                                             ref GxSimpleCollection<string> aP3_HiddenContainers ,
                                                                             out bool aP4_HasErrors )
      {
         execute(aP0_WWPFormInstance, aP1_WWPFormInstanceElementJson, aP2_HasDeletedElements, ref aP3_HiddenContainers, out aP4_HasErrors, out aP5_Messages);
         return AV15Messages ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                 string aP1_WWPFormInstanceElementJson ,
                                 bool aP2_HasDeletedElements ,
                                 ref GxSimpleCollection<string> aP3_HiddenContainers ,
                                 out bool aP4_HasErrors ,
                                 out GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages )
      {
         this.AV23WWPFormInstance = aP0_WWPFormInstance;
         this.AV27WWPFormInstanceElementJson = aP1_WWPFormInstanceElementJson;
         this.AV10HasDeletedElements = aP2_HasDeletedElements;
         this.AV12HiddenContainers = aP3_HiddenContainers;
         this.AV11HasErrors = false ;
         this.AV15Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus") ;
         SubmitImpl();
         aP3_HiddenContainers=this.AV12HiddenContainers;
         aP4_HasErrors=this.AV11HasErrors;
         aP5_Messages=this.AV15Messages;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV11HasErrors = false;
         AV24WWPFormInstanceElement.FromJSonString(AV27WWPFormInstanceElementJson, null);
         if ( ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementtype == 1 ) && ( ! AV10HasDeletedElements || ! StringUtil.Contains( AV24WWPFormInstanceElement.ToJSonString(true, true), "\"Mode\":\"DLT\"") ) )
         {
            if ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementparentid > 0 )
            {
               if ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementparenttype == 3 )
               {
                  AV25ContainerKey = StringUtil.Format( "%1.%2", StringUtil.LTrimStr( (decimal)(AV24WWPFormInstanceElement.gxTpr_Wwpformelementparentid), 4, 0), StringUtil.Str( (decimal)(0), 1, 0), "", "", "", "", "", "", "");
               }
               else
               {
                  AV25ContainerKey = StringUtil.Format( "%1.%2", StringUtil.LTrimStr( (decimal)(AV24WWPFormInstanceElement.gxTpr_Wwpformelementparentid), 4, 0), StringUtil.LTrimStr( (decimal)(AV24WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid), 4, 0), "", "", "", "", "", "", "");
               }
               AV26IsParentVisible = (bool)((AV12HiddenContainers.IndexOf(AV25ContainerKey)==0));
            }
            if ( AV26IsParentVisible )
            {
               AV16Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Factory21");
               AV17VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
               AV13IsRequired = false;
               if ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 1 )
               {
                  AV18WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
                  AV18WWP_DF_BooleanMetadata.FromJSonString(AV24WWPFormInstanceElement.gxTpr_Wwpformelementmetadata, null);
                  AV16Validations = AV18WWP_DF_BooleanMetadata.gxTpr_Validations;
                  AV17VisibleCondition = AV18WWP_DF_BooleanMetadata.gxTpr_Visiblecondition;
               }
               else if ( ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 2 ) || ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 6 ) || ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 7 ) || ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 8 ) )
               {
                  AV19WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
                  AV19WWP_DF_CharMetadata.FromJSonString(AV24WWPFormInstanceElement.gxTpr_Wwpformelementmetadata, null);
                  AV13IsRequired = AV19WWP_DF_CharMetadata.gxTpr_Isrequired;
                  AV16Validations = AV19WWP_DF_CharMetadata.gxTpr_Validations;
                  AV17VisibleCondition = AV19WWP_DF_CharMetadata.gxTpr_Visiblecondition;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24WWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar)) && ( ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 7 ) || ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 8 ) ) )
                  {
                     if ( new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV23WWPFormInstance,  AV24WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid,  AV17VisibleCondition) )
                     {
                        new WorkWithPlus.workwithplus_dynamicforms.wwp_df_validatetextvalue(context ).execute(  AV24WWPFormInstanceElement.gxTpr_Wwpformelementdatatype,  StringUtil.Trim( AV24WWPFormInstanceElement.gxTpr_Wwpforminstanceelemchar), out  AV9ErrorMessage, out  AV28IsValid) ;
                        if ( ! AV28IsValid )
                        {
                           AV11HasErrors = true;
                           AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
                           AV14Message.gxTpr_Description = AV9ErrorMessage;
                           AV15Messages.Add(AV14Message, 0);
                           AV16Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Factory21");
                        }
                     }
                     else
                     {
                        AV13IsRequired = false;
                        AV16Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Factory21");
                     }
                     AV17VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
                  }
               }
               else if ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 3 )
               {
                  AV22WWP_DF_NumericMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata(context);
                  AV22WWP_DF_NumericMetadata.FromJSonString(AV24WWPFormInstanceElement.gxTpr_Wwpformelementmetadata, null);
                  AV13IsRequired = AV22WWP_DF_NumericMetadata.gxTpr_Isrequired;
                  AV16Validations = AV22WWP_DF_NumericMetadata.gxTpr_Validations;
                  AV17VisibleCondition = AV22WWP_DF_NumericMetadata.gxTpr_Visiblecondition;
               }
               else if ( ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 4 ) || ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 5 ) )
               {
                  AV20WWP_DF_DateMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata(context);
                  AV20WWP_DF_DateMetadata.FromJSonString(AV24WWPFormInstanceElement.gxTpr_Wwpformelementmetadata, null);
                  AV13IsRequired = AV20WWP_DF_DateMetadata.gxTpr_Isrequired;
                  AV16Validations = AV20WWP_DF_DateMetadata.gxTpr_Validations;
                  AV17VisibleCondition = AV20WWP_DF_DateMetadata.gxTpr_Visiblecondition;
               }
               else if ( ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 9 ) || ( AV24WWPFormInstanceElement.gxTpr_Wwpformelementdatatype == 10 ) )
               {
                  AV21WWP_DF_ImageMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata(context);
                  AV21WWP_DF_ImageMetadata.FromJSonString(AV24WWPFormInstanceElement.gxTpr_Wwpformelementmetadata, null);
                  AV13IsRequired = AV21WWP_DF_ImageMetadata.gxTpr_Isrequired;
                  AV16Validations = AV21WWP_DF_ImageMetadata.gxTpr_Validations;
                  AV17VisibleCondition = AV21WWP_DF_ImageMetadata.gxTpr_Visiblecondition;
               }
               if ( ( AV13IsRequired || ( AV16Validations.Count > 0 ) ) && new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV23WWPFormInstance,  AV24WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid,  AV17VisibleCondition) )
               {
                  GXt_char1 = AV8ElementValue;
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getvalueforvalidation(context ).execute(  AV27WWPFormInstanceElementJson, out  GXt_char1) ;
                  AV8ElementValue = GXt_char1;
                  if ( AV13IsRequired && ( StringUtil.StrCmp(StringUtil.Trim( AV8ElementValue), "''") == 0 ) )
                  {
                     AV11HasErrors = true;
                     AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
                     AV14Message.gxTpr_Description = StringUtil.Format( "%1 é obrigatório.", AV24WWPFormInstanceElement.gxTpr_Wwpformelementtitle, "", "", "", "", "", "", "", "");
                     AV15Messages.Add(AV14Message, 0);
                  }
                  else
                  {
                     if ( AV16Validations.Count > 0 )
                     {
                        new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_executeelementvalidations(context ).execute(  AV23WWPFormInstance,  AV24WWPFormInstanceElement.gxTpr_Wwpforminstanceelementid,  AV8ElementValue,  AV16Validations, out  AV15Messages) ;
                        if ( AV15Messages.Count > 0 )
                        {
                           AV11HasErrors = true;
                        }
                     }
                  }
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
         AV15Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV24WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV25ContainerKey = "";
         AV16Validations = new GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation>( context, "WWP_DF_Validation", "Factory21");
         AV17VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         AV18WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
         AV19WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV9ErrorMessage = "";
         AV14Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV22WWP_DF_NumericMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata(context);
         AV20WWP_DF_DateMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata(context);
         AV21WWP_DF_ImageMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata(context);
         AV8ElementValue = "";
         GXt_char1 = "";
         /* GeneXus formulas. */
      }

      private string GXt_char1 ;
      private bool AV10HasDeletedElements ;
      private bool AV11HasErrors ;
      private bool AV26IsParentVisible ;
      private bool AV13IsRequired ;
      private bool AV28IsValid ;
      private string AV27WWPFormInstanceElementJson ;
      private string AV25ContainerKey ;
      private string AV9ErrorMessage ;
      private string AV8ElementValue ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV23WWPFormInstance ;
      private GxSimpleCollection<string> AV12HiddenContainers ;
      private GxSimpleCollection<string> aP3_HiddenContainers ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV15Messages ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV24WWPFormInstanceElement ;
      private GXBaseCollection<WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation> AV16Validations ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV17VisibleCondition ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata AV18WWP_DF_BooleanMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV19WWP_DF_CharMetadata ;
      private GeneXus.Utils.SdtMessages_Message AV14Message ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata AV22WWP_DF_NumericMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata AV20WWP_DF_DateMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata AV21WWP_DF_ImageMetadata ;
      private bool aP4_HasErrors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> aP5_Messages ;
   }

}
