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
   public class wwp_getelementsforreport : GXProcedure
   {
      public wwp_getelementsforreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_getelementsforreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                           short aP1_WWPFormInstanceElementId ,
                           short aP2_WWPFormElementParentId ,
                           bool aP3_EvaluateVisibilities ,
                           ref GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> aP4_WWPFormElements )
      {
         this.AV21WWPFormInstance = aP0_WWPFormInstance;
         this.AV22WWPFormInstanceElementId = aP1_WWPFormInstanceElementId;
         this.AV19WWPFormElementParentId = aP2_WWPFormElementParentId;
         this.AV23EvaluateVisibilities = aP3_EvaluateVisibilities;
         this.AV20WWPFormElements = aP4_WWPFormElements;
         initialize();
         ExecuteImpl();
         aP4_WWPFormElements=this.AV20WWPFormElements;
      }

      public GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> executeUdp( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                                                                                             short aP1_WWPFormInstanceElementId ,
                                                                                                             short aP2_WWPFormElementParentId ,
                                                                                                             bool aP3_EvaluateVisibilities )
      {
         execute(aP0_WWPFormInstance, aP1_WWPFormInstanceElementId, aP2_WWPFormElementParentId, aP3_EvaluateVisibilities, ref aP4_WWPFormElements);
         return AV20WWPFormElements ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                 short aP1_WWPFormInstanceElementId ,
                                 short aP2_WWPFormElementParentId ,
                                 bool aP3_EvaluateVisibilities ,
                                 ref GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> aP4_WWPFormElements )
      {
         this.AV21WWPFormInstance = aP0_WWPFormInstance;
         this.AV22WWPFormInstanceElementId = aP1_WWPFormInstanceElementId;
         this.AV19WWPFormElementParentId = aP2_WWPFormElementParentId;
         this.AV23EvaluateVisibilities = aP3_EvaluateVisibilities;
         this.AV20WWPFormElements = aP4_WWPFormElements;
         SubmitImpl();
         aP4_WWPFormElements=this.AV20WWPFormElements;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV19WWPFormElementParentId ,
                                              A99WWPFormElementParentId ,
                                              A106WWPFormElementDataType ,
                                              A126WWPFormElementExcludeFromExport ,
                                              A94WWPFormId ,
                                              AV21WWPFormInstance.gxTpr_Wwpformid ,
                                              A95WWPFormVersionNumber ,
                                              AV21WWPFormInstance.gxTpr_Wwpformversionnumber } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00472 */
         pr_default.execute(0, new Object[] {AV21WWPFormInstance.gxTpr_Wwpformid, AV21WWPFormInstance.gxTpr_Wwpformversionnumber, AV19WWPFormElementParentId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A126WWPFormElementExcludeFromExport = P00472_A126WWPFormElementExcludeFromExport[0];
            A106WWPFormElementDataType = P00472_A106WWPFormElementDataType[0];
            A99WWPFormElementParentId = P00472_A99WWPFormElementParentId[0];
            n99WWPFormElementParentId = P00472_n99WWPFormElementParentId[0];
            A95WWPFormVersionNumber = P00472_A95WWPFormVersionNumber[0];
            A94WWPFormId = P00472_A94WWPFormId[0];
            A105WWPFormElementType = P00472_A105WWPFormElementType[0];
            A124WWPFormElementMetadata = P00472_A124WWPFormElementMetadata[0];
            A98WWPFormElementId = P00472_A98WWPFormElementId[0];
            A125WWPFormElementCaption = P00472_A125WWPFormElementCaption[0];
            A117WWPFormElementTitle = P00472_A117WWPFormElementTitle[0];
            A100WWPFormElementOrderIndex = P00472_A100WWPFormElementOrderIndex[0];
            AV8VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
            AV24IncludeElement = true;
            if ( A105WWPFormElementType == 1 )
            {
               if ( A106WWPFormElementDataType == 1 )
               {
                  AV9WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
                  AV9WWP_DF_BooleanMetadata.FromJSonString(A124WWPFormElementMetadata, null);
                  AV8VisibleCondition = AV9WWP_DF_BooleanMetadata.gxTpr_Visiblecondition;
               }
               else if ( ( A106WWPFormElementDataType == 2 ) || ( A106WWPFormElementDataType == 7 ) || ( A106WWPFormElementDataType == 8 ) )
               {
                  AV10WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
                  AV10WWP_DF_CharMetadata.FromJSonString(A124WWPFormElementMetadata, null);
                  if ( AV10WWP_DF_CharMetadata.gxTpr_Controltype == 3 )
                  {
                     AV24IncludeElement = false;
                  }
                  else
                  {
                     AV8VisibleCondition = AV10WWP_DF_CharMetadata.gxTpr_Visiblecondition;
                  }
               }
               else if ( A106WWPFormElementDataType == 3 )
               {
                  AV16WWP_DF_NumericMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata(context);
                  AV16WWP_DF_NumericMetadata.FromJSonString(A124WWPFormElementMetadata, null);
                  AV8VisibleCondition = AV16WWP_DF_NumericMetadata.gxTpr_Visiblecondition;
               }
               else if ( ( A106WWPFormElementDataType == 4 ) || ( A106WWPFormElementDataType == 5 ) )
               {
                  AV11WWP_DF_DateMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata(context);
                  AV11WWP_DF_DateMetadata.FromJSonString(A124WWPFormElementMetadata, null);
                  AV8VisibleCondition = AV11WWP_DF_DateMetadata.gxTpr_Visiblecondition;
               }
               else if ( A106WWPFormElementDataType == 10 )
               {
                  AV13WWP_DF_ImageMetadata.FromJSonString(A124WWPFormElementMetadata, null);
                  AV8VisibleCondition = AV13WWP_DF_ImageMetadata.gxTpr_Visiblecondition;
               }
            }
            else if ( A105WWPFormElementType == 2 )
            {
               AV12WWP_DF_GroupMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
               AV12WWP_DF_GroupMetadata.FromJSonString(A124WWPFormElementMetadata, null);
               AV8VisibleCondition = AV12WWP_DF_GroupMetadata.gxTpr_Visiblecondition;
            }
            else if ( A105WWPFormElementType == 3 )
            {
               AV15WWP_DF_MultipleMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
               AV15WWP_DF_MultipleMetadata.FromJSonString(A124WWPFormElementMetadata, null);
               AV8VisibleCondition = AV15WWP_DF_MultipleMetadata.gxTpr_Visiblecondition;
            }
            else if ( A105WWPFormElementType == 4 )
            {
               AV14WWP_DF_LabelMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata(context);
               AV14WWP_DF_LabelMetadata.FromJSonString(A124WWPFormElementMetadata, null);
               AV8VisibleCondition = AV14WWP_DF_LabelMetadata.gxTpr_Visiblecondition;
            }
            else if ( A105WWPFormElementType == 5 )
            {
               AV17WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
               AV17WWP_DF_StepMetadata.FromJSonString(A124WWPFormElementMetadata, null);
               AV8VisibleCondition = AV17WWP_DF_StepMetadata.gxTpr_Visiblecondition;
            }
            if ( AV24IncludeElement && ( ! AV23EvaluateVisibilities || new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluateelementvisibility(context).executeUdp(  AV21WWPFormInstance,  AV22WWPFormInstanceElementId,  AV8VisibleCondition) ) )
            {
               if ( ( A105WWPFormElementType != 2 ) || ( AV12WWP_DF_GroupMetadata.gxTpr_Style == 2 ) )
               {
                  AV18WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
                  AV18WWPFormElement.gxTpr_Wwpformelementid = A98WWPFormElementId;
                  AV18WWPFormElement.gxTpr_Wwpformelementcaption = A125WWPFormElementCaption;
                  AV18WWPFormElement.gxTpr_Wwpformelementdatatype = A106WWPFormElementDataType;
                  AV18WWPFormElement.gxTpr_Wwpformelementmetadata = A124WWPFormElementMetadata;
                  AV18WWPFormElement.gxTpr_Wwpformelementtitle = A117WWPFormElementTitle;
                  AV18WWPFormElement.gxTpr_Wwpformelementtype = A105WWPFormElementType;
                  AV18WWPFormElement.gxTpr_Wwpformelementparentid = A99WWPFormElementParentId;
                  AV20WWPFormElements.Add(AV18WWPFormElement, 0);
               }
               if ( ( A105WWPFormElementType == 2 ) || ( A105WWPFormElementType == 5 ) )
               {
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_getelementsforreport(context ).execute(  AV21WWPFormInstance,  AV22WWPFormInstanceElementId,  A98WWPFormElementId,  AV23EvaluateVisibilities, ref  AV20WWPFormElements) ;
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P00472_A126WWPFormElementExcludeFromExport = new bool[] {false} ;
         P00472_A106WWPFormElementDataType = new short[1] ;
         P00472_A99WWPFormElementParentId = new short[1] ;
         P00472_n99WWPFormElementParentId = new bool[] {false} ;
         P00472_A95WWPFormVersionNumber = new short[1] ;
         P00472_A94WWPFormId = new short[1] ;
         P00472_A105WWPFormElementType = new short[1] ;
         P00472_A124WWPFormElementMetadata = new string[] {""} ;
         P00472_A98WWPFormElementId = new short[1] ;
         P00472_A125WWPFormElementCaption = new short[1] ;
         P00472_A117WWPFormElementTitle = new string[] {""} ;
         P00472_A100WWPFormElementOrderIndex = new short[1] ;
         A124WWPFormElementMetadata = "";
         A117WWPFormElementTitle = "";
         AV8VisibleCondition = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression(context);
         AV9WWP_DF_BooleanMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata(context);
         AV10WWP_DF_CharMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata(context);
         AV16WWP_DF_NumericMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata(context);
         AV11WWP_DF_DateMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata(context);
         AV13WWP_DF_ImageMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata(context);
         AV12WWP_DF_GroupMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata(context);
         AV15WWP_DF_MultipleMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata(context);
         AV14WWP_DF_LabelMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata(context);
         AV17WWP_DF_StepMetadata = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata(context);
         AV18WWPFormElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_getelementsforreport__default(),
            new Object[][] {
                new Object[] {
               P00472_A126WWPFormElementExcludeFromExport, P00472_A106WWPFormElementDataType, P00472_A99WWPFormElementParentId, P00472_n99WWPFormElementParentId, P00472_A95WWPFormVersionNumber, P00472_A94WWPFormId, P00472_A105WWPFormElementType, P00472_A124WWPFormElementMetadata, P00472_A98WWPFormElementId, P00472_A125WWPFormElementCaption,
               P00472_A117WWPFormElementTitle, P00472_A100WWPFormElementOrderIndex
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22WWPFormInstanceElementId ;
      private short AV19WWPFormElementParentId ;
      private short AV21WWPFormInstance_gxTpr_Wwpformid ;
      private short AV21WWPFormInstance_gxTpr_Wwpformversionnumber ;
      private short A99WWPFormElementParentId ;
      private short A106WWPFormElementDataType ;
      private short A94WWPFormId ;
      private short A95WWPFormVersionNumber ;
      private short A105WWPFormElementType ;
      private short A98WWPFormElementId ;
      private short A125WWPFormElementCaption ;
      private short A100WWPFormElementOrderIndex ;
      private bool AV23EvaluateVisibilities ;
      private bool A126WWPFormElementExcludeFromExport ;
      private bool n99WWPFormElementParentId ;
      private bool AV24IncludeElement ;
      private string A124WWPFormElementMetadata ;
      private string A117WWPFormElementTitle ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV21WWPFormInstance ;
      private GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> AV20WWPFormElements ;
      private GXBCLevelCollection<GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element> aP4_WWPFormElements ;
      private IDataStoreProvider pr_default ;
      private bool[] P00472_A126WWPFormElementExcludeFromExport ;
      private short[] P00472_A106WWPFormElementDataType ;
      private short[] P00472_A99WWPFormElementParentId ;
      private bool[] P00472_n99WWPFormElementParentId ;
      private short[] P00472_A95WWPFormVersionNumber ;
      private short[] P00472_A94WWPFormId ;
      private short[] P00472_A105WWPFormElementType ;
      private string[] P00472_A124WWPFormElementMetadata ;
      private short[] P00472_A98WWPFormElementId ;
      private short[] P00472_A125WWPFormElementCaption ;
      private string[] P00472_A117WWPFormElementTitle ;
      private short[] P00472_A100WWPFormElementOrderIndex ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV8VisibleCondition ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_BooleanMetadata AV9WWP_DF_BooleanMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_CharMetadata AV10WWP_DF_CharMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_NumericMetadata AV16WWP_DF_NumericMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_DateMetadata AV11WWP_DF_DateMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ImageMetadata AV13WWP_DF_ImageMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ContainerMetadata AV12WWP_DF_GroupMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ElementsRepeaterMetadata AV15WWP_DF_MultipleMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_LabelMetadata AV14WWP_DF_LabelMetadata ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_StepMetadata AV17WWP_DF_StepMetadata ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form_Element AV18WWPFormElement ;
   }

   public class wwp_getelementsforreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00472( IGxContext context ,
                                             short AV19WWPFormElementParentId ,
                                             short A99WWPFormElementParentId ,
                                             short A106WWPFormElementDataType ,
                                             bool A126WWPFormElementExcludeFromExport ,
                                             short A94WWPFormId ,
                                             short AV21WWPFormInstance_gxTpr_Wwpformid ,
                                             short A95WWPFormVersionNumber ,
                                             short AV21WWPFormInstance_gxTpr_Wwpformversionnumber )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT WWPFormElementExcludeFromExport, WWPFormElementDataType, WWPFormElementParentId, WWPFormVersionNumber, WWPFormId, WWPFormElementType, WWPFormElementMetadata, WWPFormElementId, WWPFormElementCaption, WWPFormElementTitle, WWPFormElementOrderIndex FROM WWP_FormElement";
         AddWhere(sWhereString, "(WWPFormElementDataType <> 9)");
         AddWhere(sWhereString, "(WWPFormElementDataType <> 6)");
         AddWhere(sWhereString, "(Not WWPFormElementExcludeFromExport)");
         AddWhere(sWhereString, "(WWPFormId = :AV21WWPF_1Wwpformid)");
         AddWhere(sWhereString, "(WWPFormVersionNumber = :AV21WWPF_2Wwpformversionnumbe)");
         if ( AV19WWPFormElementParentId > 0 )
         {
            AddWhere(sWhereString, "(WWPFormElementParentId = :AV19WWPFormElementParentId)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV19WWPFormElementParentId == 0 )
         {
            AddWhere(sWhereString, "(WWPFormElementParentId IS NULL)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY WWPFormElementOrderIndex";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00472(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (bool)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00472;
          prmP00472 = new Object[] {
          new ParDef("AV21WWPF_1Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV21WWPF_2Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV19WWPFormElementParentId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00472", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00472,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                return;
       }
    }

 }

}
