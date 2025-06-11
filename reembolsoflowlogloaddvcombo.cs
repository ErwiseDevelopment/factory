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
   public class reembolsoflowlogloaddvcombo : GXProcedure
   {
      public reembolsoflowlogloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoflowlogloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_ReembolsoFlowLogId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19ReembolsoFlowLogId = aP3_ReembolsoFlowLogId;
         this.AV20SearchTxtParms = aP4_SearchTxtParms;
         this.AV21SelectedValue = "" ;
         this.AV22SelectedText = "" ;
         this.AV23Combo_DataJson = "" ;
         initialize();
         ExecuteImpl();
         aP5_SelectedValue=this.AV21SelectedValue;
         aP6_SelectedText=this.AV22SelectedText;
         aP7_Combo_DataJson=this.AV23Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                int aP3_ReembolsoFlowLogId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_ReembolsoFlowLogId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_ReembolsoFlowLogId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19ReembolsoFlowLogId = aP3_ReembolsoFlowLogId;
         this.AV20SearchTxtParms = aP4_SearchTxtParms;
         this.AV21SelectedValue = "" ;
         this.AV22SelectedText = "" ;
         this.AV23Combo_DataJson = "" ;
         SubmitImpl();
         aP5_SelectedValue=this.AV21SelectedValue;
         aP6_SelectedText=this.AV22SelectedText;
         aP7_Combo_DataJson=this.AV23Combo_DataJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10MaxItems = 10;
         AV12PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV20SearchTxtParms))||StringUtil.StartsWith( AV17TrnMode, "GET") ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV20SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV13SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV20SearchTxtParms))||StringUtil.StartsWith( AV17TrnMode, "GET") ? AV20SearchTxtParms : StringUtil.Substring( AV20SearchTxtParms, 3, -1));
         AV11SkipItems = (short)(AV12PageIndex*AV10MaxItems);
         if ( StringUtil.StrCmp(AV16ComboName, "LogWorkflowConvenioId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_LOGWORKFLOWCONVENIOID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "ReembolsoFlowLogUser") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_REEMBOLSOFLOWLOGUSER' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "ReembolsoLogId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_REEMBOLSOLOGID' */
            S131 ();
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
         /* 'LOADCOMBOITEMS_LOGWORKFLOWCONVENIOID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A736WorkflowConvenioDesc } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00CP2 */
            pr_default.execute(0, new Object[] {lV13SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A736WorkflowConvenioDesc = P00CP2_A736WorkflowConvenioDesc[0];
               n736WorkflowConvenioDesc = P00CP2_n736WorkflowConvenioDesc[0];
               A742WorkflowConvenioId = P00CP2_A742WorkflowConvenioId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A742WorkflowConvenioId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = A736WorkflowConvenioDesc;
               AV14Combo_Data.Add(AV15Combo_DataItem, 0);
               if ( AV14Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV23Combo_DataJson = AV14Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV17TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV17TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00CP3 */
                  pr_default.execute(1, new Object[] {AV19ReembolsoFlowLogId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A746ReembolsoFlowLogId = P00CP3_A746ReembolsoFlowLogId[0];
                     A750LogWorkflowConvenioId = P00CP3_A750LogWorkflowConvenioId[0];
                     n750LogWorkflowConvenioId = P00CP3_n750LogWorkflowConvenioId[0];
                     AV21SelectedValue = ((0==A750LogWorkflowConvenioId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A750LogWorkflowConvenioId), 9, 0)));
                     AV27WorkflowConvenioId = A750LogWorkflowConvenioId;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27WorkflowConvenioId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
               }
               /* Using cursor P00CP4 */
               pr_default.execute(2, new Object[] {AV27WorkflowConvenioId});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A742WorkflowConvenioId = P00CP4_A742WorkflowConvenioId[0];
                  A736WorkflowConvenioDesc = P00CP4_A736WorkflowConvenioDesc[0];
                  n736WorkflowConvenioDesc = P00CP4_n736WorkflowConvenioDesc[0];
                  AV22SelectedText = A736WorkflowConvenioDesc;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_REEMBOLSOFLOWLOGUSER' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom5 = AV11SkipItems;
            GXPagingTo5 = AV10MaxItems;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A141SecUserName } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00CP5 */
            pr_default.execute(3, new Object[] {lV13SearchTxt, GXPagingFrom5, GXPagingTo5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A141SecUserName = P00CP5_A141SecUserName[0];
               n141SecUserName = P00CP5_n141SecUserName[0];
               A133SecUserId = P00CP5_A133SecUserId[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A133SecUserId), 4, 0));
               AV15Combo_DataItem.gxTpr_Title = A141SecUserName;
               AV14Combo_Data.Add(AV15Combo_DataItem, 0);
               if ( AV14Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV23Combo_DataJson = AV14Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV17TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV17TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00CP6 */
                  pr_default.execute(4, new Object[] {AV19ReembolsoFlowLogId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A746ReembolsoFlowLogId = P00CP6_A746ReembolsoFlowLogId[0];
                     A744ReembolsoFlowLogUser = P00CP6_A744ReembolsoFlowLogUser[0];
                     n744ReembolsoFlowLogUser = P00CP6_n744ReembolsoFlowLogUser[0];
                     AV21SelectedValue = ((0==A744ReembolsoFlowLogUser) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A744ReembolsoFlowLogUser), 4, 0)));
                     AV28SecUserId = A744ReembolsoFlowLogUser;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV28SecUserId = (short)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
               }
               /* Using cursor P00CP7 */
               pr_default.execute(5, new Object[] {AV28SecUserId});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A133SecUserId = P00CP7_A133SecUserId[0];
                  A141SecUserName = P00CP7_A141SecUserName[0];
                  n141SecUserName = P00CP7_n141SecUserName[0];
                  AV22SelectedText = A141SecUserName;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(5);
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_REEMBOLSOLOGID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom8 = AV11SkipItems;
            GXPagingTo8 = AV10MaxItems;
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A550ReembolsoPropostaPacienteClienteRazaoSocial } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00CP8 */
            pr_default.execute(6, new Object[] {lV13SearchTxt, GXPagingFrom8, GXPagingTo8, GXPagingTo8});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A542ReembolsoPropostaId = P00CP8_A542ReembolsoPropostaId[0];
               n542ReembolsoPropostaId = P00CP8_n542ReembolsoPropostaId[0];
               A558ReembolsoPropostaPacienteClienteId = P00CP8_A558ReembolsoPropostaPacienteClienteId[0];
               n558ReembolsoPropostaPacienteClienteId = P00CP8_n558ReembolsoPropostaPacienteClienteId[0];
               A550ReembolsoPropostaPacienteClienteRazaoSocial = P00CP8_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               n550ReembolsoPropostaPacienteClienteRazaoSocial = P00CP8_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               A518ReembolsoId = P00CP8_A518ReembolsoId[0];
               A558ReembolsoPropostaPacienteClienteId = P00CP8_A558ReembolsoPropostaPacienteClienteId[0];
               n558ReembolsoPropostaPacienteClienteId = P00CP8_n558ReembolsoPropostaPacienteClienteId[0];
               A550ReembolsoPropostaPacienteClienteRazaoSocial = P00CP8_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               n550ReembolsoPropostaPacienteClienteRazaoSocial = P00CP8_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A518ReembolsoId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = A550ReembolsoPropostaPacienteClienteRazaoSocial;
               AV14Combo_Data.Add(AV15Combo_DataItem, 0);
               if ( AV14Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(6);
            }
            pr_default.close(6);
            AV23Combo_DataJson = AV14Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV17TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV17TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00CP9 */
                  pr_default.execute(7, new Object[] {AV19ReembolsoFlowLogId});
                  while ( (pr_default.getStatus(7) != 101) )
                  {
                     A746ReembolsoFlowLogId = P00CP9_A746ReembolsoFlowLogId[0];
                     A748ReembolsoLogId = P00CP9_A748ReembolsoLogId[0];
                     n748ReembolsoLogId = P00CP9_n748ReembolsoLogId[0];
                     AV21SelectedValue = ((0==A748ReembolsoLogId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A748ReembolsoLogId), 9, 0)));
                     AV29ReembolsoId = A748ReembolsoLogId;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(7);
               }
               else
               {
                  AV29ReembolsoId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
               }
               /* Using cursor P00CP10 */
               pr_default.execute(8, new Object[] {AV29ReembolsoId});
               while ( (pr_default.getStatus(8) != 101) )
               {
                  A542ReembolsoPropostaId = P00CP10_A542ReembolsoPropostaId[0];
                  n542ReembolsoPropostaId = P00CP10_n542ReembolsoPropostaId[0];
                  A558ReembolsoPropostaPacienteClienteId = P00CP10_A558ReembolsoPropostaPacienteClienteId[0];
                  n558ReembolsoPropostaPacienteClienteId = P00CP10_n558ReembolsoPropostaPacienteClienteId[0];
                  A518ReembolsoId = P00CP10_A518ReembolsoId[0];
                  A550ReembolsoPropostaPacienteClienteRazaoSocial = P00CP10_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
                  n550ReembolsoPropostaPacienteClienteRazaoSocial = P00CP10_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
                  A558ReembolsoPropostaPacienteClienteId = P00CP10_A558ReembolsoPropostaPacienteClienteId[0];
                  n558ReembolsoPropostaPacienteClienteId = P00CP10_n558ReembolsoPropostaPacienteClienteId[0];
                  A550ReembolsoPropostaPacienteClienteRazaoSocial = P00CP10_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
                  n550ReembolsoPropostaPacienteClienteRazaoSocial = P00CP10_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
                  AV22SelectedText = A550ReembolsoPropostaPacienteClienteRazaoSocial;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(8);
            }
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
         AV21SelectedValue = "";
         AV22SelectedText = "";
         AV23Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13SearchTxt = "";
         lV13SearchTxt = "";
         A736WorkflowConvenioDesc = "";
         P00CP2_A736WorkflowConvenioDesc = new string[] {""} ;
         P00CP2_n736WorkflowConvenioDesc = new bool[] {false} ;
         P00CP2_A742WorkflowConvenioId = new int[1] ;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00CP3_A746ReembolsoFlowLogId = new int[1] ;
         P00CP3_A750LogWorkflowConvenioId = new int[1] ;
         P00CP3_n750LogWorkflowConvenioId = new bool[] {false} ;
         P00CP4_A742WorkflowConvenioId = new int[1] ;
         P00CP4_A736WorkflowConvenioDesc = new string[] {""} ;
         P00CP4_n736WorkflowConvenioDesc = new bool[] {false} ;
         A141SecUserName = "";
         P00CP5_A141SecUserName = new string[] {""} ;
         P00CP5_n141SecUserName = new bool[] {false} ;
         P00CP5_A133SecUserId = new short[1] ;
         P00CP6_A746ReembolsoFlowLogId = new int[1] ;
         P00CP6_A744ReembolsoFlowLogUser = new short[1] ;
         P00CP6_n744ReembolsoFlowLogUser = new bool[] {false} ;
         P00CP7_A133SecUserId = new short[1] ;
         P00CP7_A141SecUserName = new string[] {""} ;
         P00CP7_n141SecUserName = new bool[] {false} ;
         A550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         P00CP8_A542ReembolsoPropostaId = new int[1] ;
         P00CP8_n542ReembolsoPropostaId = new bool[] {false} ;
         P00CP8_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         P00CP8_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         P00CP8_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00CP8_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00CP8_A518ReembolsoId = new int[1] ;
         P00CP9_A746ReembolsoFlowLogId = new int[1] ;
         P00CP9_A748ReembolsoLogId = new int[1] ;
         P00CP9_n748ReembolsoLogId = new bool[] {false} ;
         P00CP10_A542ReembolsoPropostaId = new int[1] ;
         P00CP10_n542ReembolsoPropostaId = new bool[] {false} ;
         P00CP10_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         P00CP10_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         P00CP10_A518ReembolsoId = new int[1] ;
         P00CP10_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00CP10_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoflowlogloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00CP2_A736WorkflowConvenioDesc, P00CP2_n736WorkflowConvenioDesc, P00CP2_A742WorkflowConvenioId
               }
               , new Object[] {
               P00CP3_A746ReembolsoFlowLogId, P00CP3_A750LogWorkflowConvenioId, P00CP3_n750LogWorkflowConvenioId
               }
               , new Object[] {
               P00CP4_A742WorkflowConvenioId, P00CP4_A736WorkflowConvenioDesc, P00CP4_n736WorkflowConvenioDesc
               }
               , new Object[] {
               P00CP5_A141SecUserName, P00CP5_n141SecUserName, P00CP5_A133SecUserId
               }
               , new Object[] {
               P00CP6_A746ReembolsoFlowLogId, P00CP6_A744ReembolsoFlowLogUser, P00CP6_n744ReembolsoFlowLogUser
               }
               , new Object[] {
               P00CP7_A133SecUserId, P00CP7_A141SecUserName, P00CP7_n141SecUserName
               }
               , new Object[] {
               P00CP8_A542ReembolsoPropostaId, P00CP8_n542ReembolsoPropostaId, P00CP8_A558ReembolsoPropostaPacienteClienteId, P00CP8_n558ReembolsoPropostaPacienteClienteId, P00CP8_A550ReembolsoPropostaPacienteClienteRazaoSocial, P00CP8_n550ReembolsoPropostaPacienteClienteRazaoSocial, P00CP8_A518ReembolsoId
               }
               , new Object[] {
               P00CP9_A746ReembolsoFlowLogId, P00CP9_A748ReembolsoLogId, P00CP9_n748ReembolsoLogId
               }
               , new Object[] {
               P00CP10_A542ReembolsoPropostaId, P00CP10_n542ReembolsoPropostaId, P00CP10_A558ReembolsoPropostaPacienteClienteId, P00CP10_n558ReembolsoPropostaPacienteClienteId, P00CP10_A518ReembolsoId, P00CP10_A550ReembolsoPropostaPacienteClienteRazaoSocial, P00CP10_n550ReembolsoPropostaPacienteClienteRazaoSocial
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private short A133SecUserId ;
      private short A744ReembolsoFlowLogUser ;
      private short AV28SecUserId ;
      private int AV19ReembolsoFlowLogId ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A742WorkflowConvenioId ;
      private int A746ReembolsoFlowLogId ;
      private int A750LogWorkflowConvenioId ;
      private int AV27WorkflowConvenioId ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int GXPagingFrom8 ;
      private int GXPagingTo8 ;
      private int A542ReembolsoPropostaId ;
      private int A558ReembolsoPropostaPacienteClienteId ;
      private int A518ReembolsoId ;
      private int A748ReembolsoLogId ;
      private int AV29ReembolsoId ;
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private bool n736WorkflowConvenioDesc ;
      private bool n750LogWorkflowConvenioId ;
      private bool n141SecUserName ;
      private bool n744ReembolsoFlowLogUser ;
      private bool n542ReembolsoPropostaId ;
      private bool n558ReembolsoPropostaPacienteClienteId ;
      private bool n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool n748ReembolsoLogId ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private string A736WorkflowConvenioDesc ;
      private string A141SecUserName ;
      private string A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private string[] P00CP2_A736WorkflowConvenioDesc ;
      private bool[] P00CP2_n736WorkflowConvenioDesc ;
      private int[] P00CP2_A742WorkflowConvenioId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private int[] P00CP3_A746ReembolsoFlowLogId ;
      private int[] P00CP3_A750LogWorkflowConvenioId ;
      private bool[] P00CP3_n750LogWorkflowConvenioId ;
      private int[] P00CP4_A742WorkflowConvenioId ;
      private string[] P00CP4_A736WorkflowConvenioDesc ;
      private bool[] P00CP4_n736WorkflowConvenioDesc ;
      private string[] P00CP5_A141SecUserName ;
      private bool[] P00CP5_n141SecUserName ;
      private short[] P00CP5_A133SecUserId ;
      private int[] P00CP6_A746ReembolsoFlowLogId ;
      private short[] P00CP6_A744ReembolsoFlowLogUser ;
      private bool[] P00CP6_n744ReembolsoFlowLogUser ;
      private short[] P00CP7_A133SecUserId ;
      private string[] P00CP7_A141SecUserName ;
      private bool[] P00CP7_n141SecUserName ;
      private int[] P00CP8_A542ReembolsoPropostaId ;
      private bool[] P00CP8_n542ReembolsoPropostaId ;
      private int[] P00CP8_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] P00CP8_n558ReembolsoPropostaPacienteClienteId ;
      private string[] P00CP8_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] P00CP8_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private int[] P00CP8_A518ReembolsoId ;
      private int[] P00CP9_A746ReembolsoFlowLogId ;
      private int[] P00CP9_A748ReembolsoLogId ;
      private bool[] P00CP9_n748ReembolsoLogId ;
      private int[] P00CP10_A542ReembolsoPropostaId ;
      private bool[] P00CP10_n542ReembolsoPropostaId ;
      private int[] P00CP10_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] P00CP10_n558ReembolsoPropostaPacienteClienteId ;
      private int[] P00CP10_A518ReembolsoId ;
      private string[] P00CP10_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] P00CP10_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class reembolsoflowlogloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CP2( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A736WorkflowConvenioDesc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " WorkflowConvenioDesc, WorkflowConvenioId";
         sFromString = " FROM WorkflowConvenio";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(WorkflowConvenioDesc like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY WorkflowConvenioDesc, WorkflowConvenioId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00CP5( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A141SecUserName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " SecUserName, SecUserId";
         sFromString = " FROM SecUser";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(SecUserName like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         sOrderString += " ORDER BY SecUserName, SecUserId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom5" + " LIMIT CASE WHEN " + ":GXPagingTo5" + " > 0 THEN " + ":GXPagingTo5" + " ELSE 1e9 END";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00CP8( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A550ReembolsoPropostaPacienteClienteRazaoSocial )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[4];
         Object[] GXv_Object6 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T1.ReembolsoPropostaId AS ReembolsoPropostaId, T2.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T3.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, T1.ReembolsoId";
         sFromString = " FROM ((Reembolso T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.ReembolsoPropostaId) LEFT JOIN Cliente T3 ON T3.ClienteId = T2.PropostaPacienteClienteId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13SearchTxt)) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like '%' || :lV13SearchTxt)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         sOrderString += " ORDER BY T3.ClienteRazaoSocial, T1.ReembolsoId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom8" + " LIMIT CASE WHEN " + ":GXPagingTo8" + " > 0 THEN " + ":GXPagingTo8" + " ELSE 1e9 END";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00CP2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P00CP5(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 6 :
                     return conditional_P00CP8(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CP3;
          prmP00CP3 = new Object[] {
          new ParDef("AV19ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmP00CP4;
          prmP00CP4 = new Object[] {
          new ParDef("AV27WorkflowConvenioId",GXType.Int32,9,0)
          };
          Object[] prmP00CP6;
          prmP00CP6 = new Object[] {
          new ParDef("AV19ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmP00CP7;
          prmP00CP7 = new Object[] {
          new ParDef("AV28SecUserId",GXType.Int16,4,0)
          };
          Object[] prmP00CP9;
          prmP00CP9 = new Object[] {
          new ParDef("AV19ReembolsoFlowLogId",GXType.Int32,9,0)
          };
          Object[] prmP00CP10;
          prmP00CP10 = new Object[] {
          new ParDef("AV29ReembolsoId",GXType.Int32,9,0)
          };
          Object[] prmP00CP2;
          prmP00CP2 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP00CP5;
          prmP00CP5 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          Object[] prmP00CP8;
          prmP00CP8 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom8",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo8",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo8",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CP2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CP3", "SELECT ReembolsoFlowLogId, LogWorkflowConvenioId FROM ReembolsoFlowLog WHERE ReembolsoFlowLogId = :AV19ReembolsoFlowLogId ORDER BY ReembolsoFlowLogId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CP4", "SELECT WorkflowConvenioId, WorkflowConvenioDesc FROM WorkflowConvenio WHERE WorkflowConvenioId = :AV27WorkflowConvenioId ORDER BY WorkflowConvenioId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CP5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CP6", "SELECT ReembolsoFlowLogId, ReembolsoFlowLogUser FROM ReembolsoFlowLog WHERE ReembolsoFlowLogId = :AV19ReembolsoFlowLogId ORDER BY ReembolsoFlowLogId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CP7", "SELECT SecUserId, SecUserName FROM SecUser WHERE SecUserId = :AV28SecUserId ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CP8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CP9", "SELECT ReembolsoFlowLogId, ReembolsoLogId FROM ReembolsoFlowLog WHERE ReembolsoFlowLogId = :AV19ReembolsoFlowLogId ORDER BY ReembolsoFlowLogId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CP10", "SELECT T1.ReembolsoPropostaId AS ReembolsoPropostaId, T2.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T1.ReembolsoId, T3.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial FROM ((Reembolso T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.ReembolsoPropostaId) LEFT JOIN Cliente T3 ON T3.ClienteId = T2.PropostaPacienteClienteId) WHERE T1.ReembolsoId = :AV29ReembolsoId ORDER BY T1.ReembolsoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CP10,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
