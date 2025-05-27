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
   public class wwp_df_evaluatecondition : GXProcedure
   {
      public wwp_df_evaluatecondition( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_df_evaluatecondition( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                           WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression aP1_VisibleCondition ,
                           bool aP2_TestingCondition ,
                           short aP3_WWPFormInstanceElementId ,
                           string aP4_ThisElementValue ,
                           out bool aP5_ConditionResult ,
                           out string aP6_ErrorMessage )
      {
         this.AV28WWPFormInstance = aP0_WWPFormInstance;
         this.AV25VisibleCondition = aP1_VisibleCondition;
         this.AV23TestingCondition = aP2_TestingCondition;
         this.AV31WWPFormInstanceElementId = aP3_WWPFormInstanceElementId;
         this.AV24ThisElementValue = aP4_ThisElementValue;
         this.AV12ConditionResult = false ;
         this.AV15ErrorMessage = "" ;
         initialize();
         ExecuteImpl();
         aP5_ConditionResult=this.AV12ConditionResult;
         aP6_ErrorMessage=this.AV15ErrorMessage;
      }

      public string executeUdp( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression aP1_VisibleCondition ,
                                bool aP2_TestingCondition ,
                                short aP3_WWPFormInstanceElementId ,
                                string aP4_ThisElementValue ,
                                out bool aP5_ConditionResult )
      {
         execute(aP0_WWPFormInstance, aP1_VisibleCondition, aP2_TestingCondition, aP3_WWPFormInstanceElementId, aP4_ThisElementValue, out aP5_ConditionResult, out aP6_ErrorMessage);
         return AV15ErrorMessage ;
      }

      public void executeSubmit( GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance aP0_WWPFormInstance ,
                                 WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression aP1_VisibleCondition ,
                                 bool aP2_TestingCondition ,
                                 short aP3_WWPFormInstanceElementId ,
                                 string aP4_ThisElementValue ,
                                 out bool aP5_ConditionResult ,
                                 out string aP6_ErrorMessage )
      {
         this.AV28WWPFormInstance = aP0_WWPFormInstance;
         this.AV25VisibleCondition = aP1_VisibleCondition;
         this.AV23TestingCondition = aP2_TestingCondition;
         this.AV31WWPFormInstanceElementId = aP3_WWPFormInstanceElementId;
         this.AV24ThisElementValue = aP4_ThisElementValue;
         this.AV12ConditionResult = false ;
         this.AV15ErrorMessage = "" ;
         SubmitImpl();
         aP5_ConditionResult=this.AV12ConditionResult;
         aP6_ErrorMessage=this.AV15ErrorMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8AllElementsFound = true;
         AV11CleanedExpression = AV25VisibleCondition.gxTpr_Expression;
         AV39GXV1 = 1;
         while ( AV39GXV1 <= AV25VisibleCondition.gxTpr_Mentionedfields.Count )
         {
            AV18FieldName = ((string)AV25VisibleCondition.gxTpr_Mentionedfields.Item(AV39GXV1));
            if ( ( ( StringUtil.StrCmp(StringUtil.Lower( AV18FieldName), "value") != 0 ) || AV23TestingCondition ) && ( StringUtil.StrCmp(StringUtil.Lower( AV18FieldName), "today") != 0 ) )
            {
               /* Execute user subroutine: 'GET ELEMENT BY FIELDNAME' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid)) )
               {
                  GXt_char1 = AV14ElementValue;
                  new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getvalueforvalidation(context ).execute(  AV29WWPFormInstanceElement.ToJSonString(true, true), out  GXt_char1) ;
                  AV14ElementValue = GXt_char1;
                  AV29WWPFormInstanceElement.FromJSonString(AV38WWPFormInstanceElementJson, null);
               }
               else
               {
                  AV10ChildWWPFormElementId = 0;
                  if ( StringUtil.EndsWith( StringUtil.Lower( AV18FieldName), "_repetitions") )
                  {
                     AV19FieldNameToSearch = StringUtil.Substring( StringUtil.Lower( AV18FieldName), 1, StringUtil.Len( AV18FieldName)-12);
                     AV27WWPFormElementId = 0;
                     /* Using cursor P003G2 */
                     pr_default.execute(0, new Object[] {AV28WWPFormInstance.gxTpr_Wwpformid, AV28WWPFormInstance.gxTpr_Wwpformversionnumber, AV19FieldNameToSearch});
                     while ( (pr_default.getStatus(0) != 101) )
                     {
                        A105WWPFormElementType = P003G2_A105WWPFormElementType[0];
                        A101WWPFormElementReferenceId = P003G2_A101WWPFormElementReferenceId[0];
                        A95WWPFormVersionNumber = P003G2_A95WWPFormVersionNumber[0];
                        A94WWPFormId = P003G2_A94WWPFormId[0];
                        A98WWPFormElementId = P003G2_A98WWPFormElementId[0];
                        AV27WWPFormElementId = A98WWPFormElementId;
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                        pr_default.readNext(0);
                     }
                     pr_default.close(0);
                     if ( ! (0==AV27WWPFormElementId) )
                     {
                        AV10ChildWWPFormElementId = AV27WWPFormElementId;
                        new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getsimpleelementofmultipledata(context ).execute(  AV28WWPFormInstance.gxTpr_Wwpformid,  AV28WWPFormInstance.gxTpr_Wwpformversionnumber, ref  AV10ChildWWPFormElementId) ;
                        if ( ! (0==AV10ChildWWPFormElementId) )
                        {
                           AV9ChildrenCount = 0;
                           AV20HasDeletedElements = (bool)((!(0==AV28WWPFormInstance.gxTpr_Wwpforminstanceid)));
                           AV41GXV2 = 1;
                           while ( AV41GXV2 <= AV28WWPFormInstance.gxTpr_Element.Count )
                           {
                              AV13Element = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV28WWPFormInstance.gxTpr_Element.Item(AV41GXV2));
                              if ( ( AV13Element.gxTpr_Wwpformelementid == AV10ChildWWPFormElementId ) && ( ! AV20HasDeletedElements || ! StringUtil.Contains( AV13Element.ToJSonString(true, true), "\"Mode\":\"DLT\"") ) )
                              {
                                 AV9ChildrenCount = (short)(AV9ChildrenCount+1);
                              }
                              AV41GXV2 = (int)(AV41GXV2+1);
                           }
                           AV14ElementValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9ChildrenCount), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     /* Using cursor P003G3 */
                     pr_default.execute(1, new Object[] {AV28WWPFormInstance.gxTpr_Wwpformid, AV28WWPFormInstance.gxTpr_Wwpformversionnumber});
                     while ( (pr_default.getStatus(1) != 101) )
                     {
                        A95WWPFormVersionNumber = P003G3_A95WWPFormVersionNumber[0];
                        A94WWPFormId = P003G3_A94WWPFormId[0];
                        A290WWPFormType = P003G3_A290WWPFormType[0];
                        AV36WWPFormType = A290WWPFormType;
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(1);
                     if ( AV36WWPFormType == 1 )
                     {
                        AV32Properties.FromJSonString(AV28WWPFormInstance.gxTpr_Wwpforminstancerecordkey, null);
                        AV34SectionReferencedElements.FromJSonString(AV32Properties.Get("SectionReferencedElements"), null);
                        AV14ElementValue = AV34SectionReferencedElements.Get(AV18FieldName);
                        AV33IsElementTrnAttribute = true;
                     }
                  }
               }
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29WWPFormInstanceElement.gxTpr_Wwpformelementreferenceid)) || ! (0==AV10ChildWWPFormElementId) || AV33IsElementTrnAttribute )
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14ElementValue)) )
                  {
                     /* Execute user subroutine: 'ASSINGEXPRESIONVARIABLE' */
                     S121 ();
                     if ( returnInSub )
                     {
                        cleanup();
                        if (true) return;
                     }
                  }
               }
               else
               {
                  AV15ErrorMessage = StringUtil.Format( "Controle referenciado não encontrado: %1", AV18FieldName, "", "", "", "", "", "", "", "");
                  AV8AllElementsFound = false;
                  if (true) break;
               }
            }
            AV39GXV1 = (int)(AV39GXV1+1);
         }
         if ( AV8AllElementsFound )
         {
            AV18FieldName = "Today";
            GXt_int2 = 0;
            new WorkWithPlus.workwithplus_dynamicforms.wwp_df_getdatenumber(context ).execute(  Gx_date, out  GXt_int2) ;
            AV14ElementValue = StringUtil.Trim( StringUtil.Str( (decimal)(GXt_int2), 10, 0));
            /* Execute user subroutine: 'ASSINGEXPRESIONVARIABLE' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV24ThisElementValue))) )
            {
               AV18FieldName = "Value";
               AV14ElementValue = AV24ThisElementValue;
               /* Execute user subroutine: 'ASSINGEXPRESIONVARIABLE' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            AV11CleanedExpression = StringUtil.StringReplace( AV11CleanedExpression, "(", " (");
            AV11CleanedExpression = StringUtil.StringReplace( AV11CleanedExpression, "<>", "!=");
            AV11CleanedExpression = StringUtil.StringReplace( AV11CleanedExpression, "'", "[']");
            AV11CleanedExpression = StringUtil.StringReplace( AV11CleanedExpression, "\"", "'");
            AV11CleanedExpression = StringUtil.StringReplace( AV11CleanedExpression, "\\'", "\"");
            AV11CleanedExpression = StringUtil.StringReplace( AV11CleanedExpression, "[']", "'");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = GXUtil.UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + GXUtil.UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + GXUtil.UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + GXUtil.UrlEncode(StringUtil.LTrimStr(0,1,0)) + "," + GXUtil.UrlEncode(StringUtil.LTrimStr(0,1,0));
            AV26WWPDateSumCall = formatLink("workwithplus_dynamicforms.wwp_df_datesum") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AV26WWPDateSumCall = StringUtil.Substring( AV26WWPDateSumCall, 1, StringUtil.StringSearch( AV26WWPDateSumCall, "?", 1)-1);
            AV11CleanedExpression = StringUtil.StringReplace( AV11CleanedExpression, "DateSum (", AV26WWPDateSumCall+"(");
            AV11CleanedExpression = StringUtil.StringReplace( AV11CleanedExpression, " iif (", " iif(");
            AV17ExpressionEvaluator.Expression = StringUtil.Format( "iif((%1), 1, 0)", AV11CleanedExpression, "", "", "", "", "", "", "", "");
            /* User Code */
             try{
            AV22Result = (decimal)(AV17ExpressionEvaluator.Evaluate());
            /* User Code */
             }catch(Exception exc){
            /* User Code */
             AV21IsException = true;
            /* User Code */
             AV16ExceptionMessage = exc.Message;
            /* User Code */
             }
            if ( ( AV17ExpressionEvaluator.ErrCode == 0 ) && ! AV21IsException )
            {
               AV12ConditionResult = ((AV22Result==Convert.ToDecimal(1)) ? true : false);
            }
            else
            {
               AV15ErrorMessage = (AV21IsException ? AV16ExceptionMessage : StringUtil.Trim( AV17ExpressionEvaluator.ErrDescription));
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV15ErrorMessage)) )
               {
                  AV15ErrorMessage = "Erro desconhecido";
               }
               else
               {
                  if ( StringUtil.StrCmp(AV15ErrorMessage, "Failed to load type: GeneXus.Programs.iif") == 0 )
                  {
                     AV15ErrorMessage = "Para usar a função IIF, inclua um espaço antes";
                  }
                  else if ( StringUtil.Contains( AV15ErrorMessage, "'iif((") && StringUtil.Contains( AV15ErrorMessage, "), 1, 0)'") )
                  {
                     AV15ErrorMessage = StringUtil.StringReplace( AV15ErrorMessage, "'iif((", "'");
                     AV15ErrorMessage = StringUtil.StringReplace( AV15ErrorMessage, "), 1, 0)'", "'");
                  }
               }
               if ( AV21IsException || StringUtil.Contains( StringUtil.Lower( AV15ErrorMessage), "supported") || StringUtil.Contains( StringUtil.Lower( AV15ErrorMessage), "evaluate expression") )
               {
                  new GeneXus.Core.genexus.common.SdtLog(context).error(AV15ErrorMessage, AV44Pgmname) ;
               }
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'GET ELEMENT BY FIELDNAME' Routine */
         returnInSub = false;
         AV29WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV45GXV3 = 1;
         while ( AV45GXV3 <= AV28WWPFormInstance.gxTpr_Element.Count )
         {
            AV30WWPFormInstanceElementAux = ((GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element)AV28WWPFormInstance.gxTpr_Element.Item(AV45GXV3));
            if ( ( StringUtil.StrCmp(StringUtil.Lower( AV30WWPFormInstanceElementAux.gxTpr_Wwpformelementreferenceid), StringUtil.Lower( AV18FieldName)) == 0 ) && ( AV31WWPFormInstanceElementId == AV30WWPFormInstanceElementAux.gxTpr_Wwpforminstanceelementid ) )
            {
               AV29WWPFormInstanceElement = AV30WWPFormInstanceElementAux;
               if (true) break;
            }
            AV45GXV3 = (int)(AV45GXV3+1);
         }
      }

      protected void S121( )
      {
         /* 'ASSINGEXPRESIONVARIABLE' Routine */
         returnInSub = false;
         AV17ExpressionEvaluator.Variables.Set(AV18FieldName, AV14ElementValue);
         AV37AmpReplacerExp = StringUtil.Format( "(?i:&%1)", AV18FieldName, "", "", "", "", "", "", "", "");
         AV11CleanedExpression = GxRegex.Replace(AV11CleanedExpression,AV37AmpReplacerExp,AV18FieldName);
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
         AV15ErrorMessage = "";
         AV11CleanedExpression = "";
         AV18FieldName = "";
         AV29WWPFormInstanceElement = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV14ElementValue = "";
         GXt_char1 = "";
         AV38WWPFormInstanceElementJson = "";
         AV19FieldNameToSearch = "";
         P003G2_A105WWPFormElementType = new short[1] ;
         P003G2_A101WWPFormElementReferenceId = new string[] {""} ;
         P003G2_A95WWPFormVersionNumber = new short[1] ;
         P003G2_A94WWPFormId = new short[1] ;
         P003G2_A98WWPFormElementId = new short[1] ;
         A101WWPFormElementReferenceId = "";
         AV13Element = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         P003G3_A95WWPFormVersionNumber = new short[1] ;
         P003G3_A94WWPFormId = new short[1] ;
         P003G3_A290WWPFormType = new short[1] ;
         AV32Properties = new GXProperties();
         AV34SectionReferencedElements = new GXProperties();
         Gx_date = DateTime.MinValue;
         AV26WWPDateSumCall = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV17ExpressionEvaluator = new ExpressionEvaluator(context);
         AV16ExceptionMessage = "";
         AV44Pgmname = "";
         AV30WWPFormInstanceElementAux = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element(context);
         AV37AmpReplacerExp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_evaluatecondition__default(),
            new Object[][] {
                new Object[] {
               P003G2_A105WWPFormElementType, P003G2_A101WWPFormElementReferenceId, P003G2_A95WWPFormVersionNumber, P003G2_A94WWPFormId, P003G2_A98WWPFormElementId
               }
               , new Object[] {
               P003G3_A95WWPFormVersionNumber, P003G3_A94WWPFormId, P003G3_A290WWPFormType
               }
            }
         );
         AV44Pgmname = "WorkWithPlus.DynamicForms.WWP_DF_EvaluateCondition";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         AV44Pgmname = "WorkWithPlus.DynamicForms.WWP_DF_EvaluateCondition";
         Gx_date = DateTimeUtil.Today( context);
      }

      private short AV31WWPFormInstanceElementId ;
      private short AV10ChildWWPFormElementId ;
      private short AV27WWPFormElementId ;
      private short A105WWPFormElementType ;
      private short A95WWPFormVersionNumber ;
      private short A94WWPFormId ;
      private short A98WWPFormElementId ;
      private short AV9ChildrenCount ;
      private short A290WWPFormType ;
      private short AV36WWPFormType ;
      private short gxcookieaux ;
      private int AV39GXV1 ;
      private int AV41GXV2 ;
      private int GXt_int2 ;
      private int AV45GXV3 ;
      private decimal AV22Result ;
      private string GXt_char1 ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV44Pgmname ;
      private DateTime Gx_date ;
      private bool AV23TestingCondition ;
      private bool AV12ConditionResult ;
      private bool AV8AllElementsFound ;
      private bool returnInSub ;
      private bool AV20HasDeletedElements ;
      private bool AV33IsElementTrnAttribute ;
      private bool AV21IsException ;
      private string AV24ThisElementValue ;
      private string AV15ErrorMessage ;
      private string AV11CleanedExpression ;
      private string AV18FieldName ;
      private string AV14ElementValue ;
      private string AV38WWPFormInstanceElementJson ;
      private string AV19FieldNameToSearch ;
      private string A101WWPFormElementReferenceId ;
      private string AV26WWPDateSumCall ;
      private string AV16ExceptionMessage ;
      private string AV37AmpReplacerExp ;
      private GXProperties AV32Properties ;
      private GXProperties AV34SectionReferencedElements ;
      private ExpressionEvaluator AV17ExpressionEvaluator ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance AV28WWPFormInstance ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_ConditionExpression AV25VisibleCondition ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV29WWPFormInstanceElement ;
      private IDataStoreProvider pr_default ;
      private short[] P003G2_A105WWPFormElementType ;
      private string[] P003G2_A101WWPFormElementReferenceId ;
      private short[] P003G2_A95WWPFormVersionNumber ;
      private short[] P003G2_A94WWPFormId ;
      private short[] P003G2_A98WWPFormElementId ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV13Element ;
      private short[] P003G3_A95WWPFormVersionNumber ;
      private short[] P003G3_A94WWPFormId ;
      private short[] P003G3_A290WWPFormType ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_FormInstance_Element AV30WWPFormInstanceElementAux ;
      private bool aP5_ConditionResult ;
      private string aP6_ErrorMessage ;
   }

   public class wwp_df_evaluatecondition__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP003G2;
          prmP003G2 = new Object[] {
          new ParDef("AV28WWPF_2Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV28WWPF_1Wwpformversionnumbe",GXType.Int16,4,0) ,
          new ParDef("AV19FieldNameToSearch",GXType.VarChar,40,0)
          };
          Object[] prmP003G3;
          prmP003G3 = new Object[] {
          new ParDef("AV28WWPF_2Wwpformid",GXType.Int16,4,0) ,
          new ParDef("AV28WWPF_1Wwpformversionnumbe",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003G2", "SELECT WWPFormElementType, WWPFormElementReferenceId, WWPFormVersionNumber, WWPFormId, WWPFormElementId FROM WWP_FormElement WHERE (WWPFormId = :AV28WWPF_2Wwpformid and WWPFormVersionNumber = :AV28WWPF_1Wwpformversionnumbe) AND (LOWER(WWPFormElementReferenceId) = ( :AV19FieldNameToSearch)) AND (WWPFormElementType = 3) ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003G2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003G3", "SELECT WWPFormVersionNumber, WWPFormId, WWPFormType FROM WWP_Form WHERE WWPFormId = :AV28WWPF_2Wwpformid and WWPFormVersionNumber = :AV28WWPF_1Wwpformversionnumbe ORDER BY WWPFormId, WWPFormVersionNumber ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003G3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
