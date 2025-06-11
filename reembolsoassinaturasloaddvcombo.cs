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
   public class reembolsoassinaturasloaddvcombo : GXProcedure
   {
      public reembolsoassinaturasloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoassinaturasloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_ReembolsoAssinaturasId ,
                           string aP4_SearchTxtParms ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19ReembolsoAssinaturasId = aP3_ReembolsoAssinaturasId;
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
                                int aP3_ReembolsoAssinaturasId ,
                                string aP4_SearchTxtParms ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_ReembolsoAssinaturasId, aP4_SearchTxtParms, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV23Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_ReembolsoAssinaturasId ,
                                 string aP4_SearchTxtParms ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17TrnMode = aP1_TrnMode;
         this.AV18IsDynamicCall = aP2_IsDynamicCall;
         this.AV19ReembolsoAssinaturasId = aP3_ReembolsoAssinaturasId;
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
         if ( StringUtil.StrCmp(AV16ComboName, "ReembolsoId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_REEMBOLSOID' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "PropostaContratoAssinaturaId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PROPOSTACONTRATOASSINATURAID' */
            S121 ();
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
         /* 'LOADCOMBOITEMS_REEMBOLSOID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom2 = AV11SkipItems;
            GXPagingTo2 = AV10MaxItems;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV13SearchTxt ,
                                                 A550ReembolsoPropostaPacienteClienteRazaoSocial } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV13SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV13SearchTxt), "%", "");
            /* Using cursor P00C82 */
            pr_default.execute(0, new Object[] {lV13SearchTxt, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A542ReembolsoPropostaId = P00C82_A542ReembolsoPropostaId[0];
               n542ReembolsoPropostaId = P00C82_n542ReembolsoPropostaId[0];
               A558ReembolsoPropostaPacienteClienteId = P00C82_A558ReembolsoPropostaPacienteClienteId[0];
               n558ReembolsoPropostaPacienteClienteId = P00C82_n558ReembolsoPropostaPacienteClienteId[0];
               A550ReembolsoPropostaPacienteClienteRazaoSocial = P00C82_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               n550ReembolsoPropostaPacienteClienteRazaoSocial = P00C82_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               A518ReembolsoId = P00C82_A518ReembolsoId[0];
               n518ReembolsoId = P00C82_n518ReembolsoId[0];
               A558ReembolsoPropostaPacienteClienteId = P00C82_A558ReembolsoPropostaPacienteClienteId[0];
               n558ReembolsoPropostaPacienteClienteId = P00C82_n558ReembolsoPropostaPacienteClienteId[0];
               A550ReembolsoPropostaPacienteClienteRazaoSocial = P00C82_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               n550ReembolsoPropostaPacienteClienteRazaoSocial = P00C82_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A518ReembolsoId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = A550ReembolsoPropostaPacienteClienteRazaoSocial;
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
                  /* Using cursor P00C83 */
                  pr_default.execute(1, new Object[] {AV19ReembolsoAssinaturasId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A542ReembolsoPropostaId = P00C83_A542ReembolsoPropostaId[0];
                     n542ReembolsoPropostaId = P00C83_n542ReembolsoPropostaId[0];
                     A558ReembolsoPropostaPacienteClienteId = P00C83_A558ReembolsoPropostaPacienteClienteId[0];
                     n558ReembolsoPropostaPacienteClienteId = P00C83_n558ReembolsoPropostaPacienteClienteId[0];
                     A631ReembolsoAssinaturasId = P00C83_A631ReembolsoAssinaturasId[0];
                     A518ReembolsoId = P00C83_A518ReembolsoId[0];
                     n518ReembolsoId = P00C83_n518ReembolsoId[0];
                     A550ReembolsoPropostaPacienteClienteRazaoSocial = P00C83_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
                     n550ReembolsoPropostaPacienteClienteRazaoSocial = P00C83_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
                     A542ReembolsoPropostaId = P00C83_A542ReembolsoPropostaId[0];
                     n542ReembolsoPropostaId = P00C83_n542ReembolsoPropostaId[0];
                     A558ReembolsoPropostaPacienteClienteId = P00C83_A558ReembolsoPropostaPacienteClienteId[0];
                     n558ReembolsoPropostaPacienteClienteId = P00C83_n558ReembolsoPropostaPacienteClienteId[0];
                     A550ReembolsoPropostaPacienteClienteRazaoSocial = P00C83_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
                     n550ReembolsoPropostaPacienteClienteRazaoSocial = P00C83_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
                     AV21SelectedValue = ((0==A518ReembolsoId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A518ReembolsoId), 9, 0)));
                     AV22SelectedText = A550ReembolsoPropostaPacienteClienteRazaoSocial;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV27ReembolsoId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P00C84 */
                  pr_default.execute(2, new Object[] {AV27ReembolsoId});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A542ReembolsoPropostaId = P00C84_A542ReembolsoPropostaId[0];
                     n542ReembolsoPropostaId = P00C84_n542ReembolsoPropostaId[0];
                     A558ReembolsoPropostaPacienteClienteId = P00C84_A558ReembolsoPropostaPacienteClienteId[0];
                     n558ReembolsoPropostaPacienteClienteId = P00C84_n558ReembolsoPropostaPacienteClienteId[0];
                     A518ReembolsoId = P00C84_A518ReembolsoId[0];
                     n518ReembolsoId = P00C84_n518ReembolsoId[0];
                     A550ReembolsoPropostaPacienteClienteRazaoSocial = P00C84_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
                     n550ReembolsoPropostaPacienteClienteRazaoSocial = P00C84_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
                     A558ReembolsoPropostaPacienteClienteId = P00C84_A558ReembolsoPropostaPacienteClienteId[0];
                     n558ReembolsoPropostaPacienteClienteId = P00C84_n558ReembolsoPropostaPacienteClienteId[0];
                     A550ReembolsoPropostaPacienteClienteRazaoSocial = P00C84_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
                     n550ReembolsoPropostaPacienteClienteRazaoSocial = P00C84_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
                     AV22SelectedText = A550ReembolsoPropostaPacienteClienteRazaoSocial;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_PROPOSTACONTRATOASSINATURAID' Routine */
         returnInSub = false;
         if ( AV18IsDynamicCall )
         {
            GXPagingFrom5 = AV11SkipItems;
            GXPagingTo5 = AV10MaxItems;
            /* Using cursor P00C85 */
            pr_default.execute(3, new Object[] {GXPagingFrom5, GXPagingTo5});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A571PropostaAssinatura = P00C85_A571PropostaAssinatura[0];
               n571PropostaAssinatura = P00C85_n571PropostaAssinatura[0];
               A572PropostaContratoAssinaturaId = P00C85_A572PropostaContratoAssinaturaId[0];
               n572PropostaContratoAssinaturaId = P00C85_n572PropostaContratoAssinaturaId[0];
               A574PropostaAssinaturaStatus = P00C85_A574PropostaAssinaturaStatus[0];
               n574PropostaAssinaturaStatus = P00C85_n574PropostaAssinaturaStatus[0];
               A574PropostaAssinaturaStatus = P00C85_A574PropostaAssinaturaStatus[0];
               n574PropostaAssinaturaStatus = P00C85_n574PropostaAssinaturaStatus[0];
               AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV15Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A572PropostaContratoAssinaturaId), 9, 0));
               AV15Combo_DataItem.gxTpr_Title = StringUtil.Trim( gxdomaindmassinaturastatus.getDescription(context,A574PropostaAssinaturaStatus));
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
                  /* Using cursor P00C86 */
                  pr_default.execute(4, new Object[] {AV19ReembolsoAssinaturasId});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A571PropostaAssinatura = P00C86_A571PropostaAssinatura[0];
                     n571PropostaAssinatura = P00C86_n571PropostaAssinatura[0];
                     A631ReembolsoAssinaturasId = P00C86_A631ReembolsoAssinaturasId[0];
                     A572PropostaContratoAssinaturaId = P00C86_A572PropostaContratoAssinaturaId[0];
                     n572PropostaContratoAssinaturaId = P00C86_n572PropostaContratoAssinaturaId[0];
                     A574PropostaAssinaturaStatus = P00C86_A574PropostaAssinaturaStatus[0];
                     n574PropostaAssinaturaStatus = P00C86_n574PropostaAssinaturaStatus[0];
                     A571PropostaAssinatura = P00C86_A571PropostaAssinatura[0];
                     n571PropostaAssinatura = P00C86_n571PropostaAssinatura[0];
                     A574PropostaAssinaturaStatus = P00C86_A574PropostaAssinaturaStatus[0];
                     n574PropostaAssinaturaStatus = P00C86_n574PropostaAssinaturaStatus[0];
                     AV21SelectedValue = ((0==A572PropostaContratoAssinaturaId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A572PropostaContratoAssinaturaId), 9, 0)));
                     AV22SelectedText = (String.IsNullOrEmpty(StringUtil.RTrim( A574PropostaAssinaturaStatus)) ? "" : StringUtil.Trim( gxdomaindmassinaturastatus.getDescription(context,A574PropostaAssinaturaStatus)));
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV28PropostaContratoAssinaturaId = (int)(Math.Round(NumberUtil.Val( AV13SearchTxt, "."), 18, MidpointRounding.ToEven));
                  /* Using cursor P00C87 */
                  pr_default.execute(5, new Object[] {AV28PropostaContratoAssinaturaId});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A571PropostaAssinatura = P00C87_A571PropostaAssinatura[0];
                     n571PropostaAssinatura = P00C87_n571PropostaAssinatura[0];
                     A572PropostaContratoAssinaturaId = P00C87_A572PropostaContratoAssinaturaId[0];
                     n572PropostaContratoAssinaturaId = P00C87_n572PropostaContratoAssinaturaId[0];
                     A574PropostaAssinaturaStatus = P00C87_A574PropostaAssinaturaStatus[0];
                     n574PropostaAssinaturaStatus = P00C87_n574PropostaAssinaturaStatus[0];
                     A574PropostaAssinaturaStatus = P00C87_A574PropostaAssinaturaStatus[0];
                     n574PropostaAssinaturaStatus = P00C87_n574PropostaAssinaturaStatus[0];
                     AV22SelectedText = StringUtil.Trim( gxdomaindmassinaturastatus.getDescription(context,A574PropostaAssinaturaStatus));
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(5);
               }
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
         A550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         P00C82_A542ReembolsoPropostaId = new int[1] ;
         P00C82_n542ReembolsoPropostaId = new bool[] {false} ;
         P00C82_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         P00C82_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         P00C82_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00C82_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00C82_A518ReembolsoId = new int[1] ;
         P00C82_n518ReembolsoId = new bool[] {false} ;
         AV15Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV14Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00C83_A542ReembolsoPropostaId = new int[1] ;
         P00C83_n542ReembolsoPropostaId = new bool[] {false} ;
         P00C83_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         P00C83_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         P00C83_A631ReembolsoAssinaturasId = new int[1] ;
         P00C83_A518ReembolsoId = new int[1] ;
         P00C83_n518ReembolsoId = new bool[] {false} ;
         P00C83_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00C83_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00C84_A542ReembolsoPropostaId = new int[1] ;
         P00C84_n542ReembolsoPropostaId = new bool[] {false} ;
         P00C84_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         P00C84_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         P00C84_A518ReembolsoId = new int[1] ;
         P00C84_n518ReembolsoId = new bool[] {false} ;
         P00C84_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P00C84_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P00C85_A571PropostaAssinatura = new long[1] ;
         P00C85_n571PropostaAssinatura = new bool[] {false} ;
         P00C85_A572PropostaContratoAssinaturaId = new int[1] ;
         P00C85_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         P00C85_A574PropostaAssinaturaStatus = new string[] {""} ;
         P00C85_n574PropostaAssinaturaStatus = new bool[] {false} ;
         A574PropostaAssinaturaStatus = "";
         P00C86_A571PropostaAssinatura = new long[1] ;
         P00C86_n571PropostaAssinatura = new bool[] {false} ;
         P00C86_A631ReembolsoAssinaturasId = new int[1] ;
         P00C86_A572PropostaContratoAssinaturaId = new int[1] ;
         P00C86_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         P00C86_A574PropostaAssinaturaStatus = new string[] {""} ;
         P00C86_n574PropostaAssinaturaStatus = new bool[] {false} ;
         P00C87_A571PropostaAssinatura = new long[1] ;
         P00C87_n571PropostaAssinatura = new bool[] {false} ;
         P00C87_A572PropostaContratoAssinaturaId = new int[1] ;
         P00C87_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         P00C87_A574PropostaAssinaturaStatus = new string[] {""} ;
         P00C87_n574PropostaAssinaturaStatus = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoassinaturasloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00C82_A542ReembolsoPropostaId, P00C82_n542ReembolsoPropostaId, P00C82_A558ReembolsoPropostaPacienteClienteId, P00C82_n558ReembolsoPropostaPacienteClienteId, P00C82_A550ReembolsoPropostaPacienteClienteRazaoSocial, P00C82_n550ReembolsoPropostaPacienteClienteRazaoSocial, P00C82_A518ReembolsoId
               }
               , new Object[] {
               P00C83_A542ReembolsoPropostaId, P00C83_n542ReembolsoPropostaId, P00C83_A558ReembolsoPropostaPacienteClienteId, P00C83_n558ReembolsoPropostaPacienteClienteId, P00C83_A631ReembolsoAssinaturasId, P00C83_A518ReembolsoId, P00C83_n518ReembolsoId, P00C83_A550ReembolsoPropostaPacienteClienteRazaoSocial, P00C83_n550ReembolsoPropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               P00C84_A542ReembolsoPropostaId, P00C84_n542ReembolsoPropostaId, P00C84_A558ReembolsoPropostaPacienteClienteId, P00C84_n558ReembolsoPropostaPacienteClienteId, P00C84_A518ReembolsoId, P00C84_A550ReembolsoPropostaPacienteClienteRazaoSocial, P00C84_n550ReembolsoPropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               P00C85_A571PropostaAssinatura, P00C85_n571PropostaAssinatura, P00C85_A572PropostaContratoAssinaturaId, P00C85_A574PropostaAssinaturaStatus, P00C85_n574PropostaAssinaturaStatus
               }
               , new Object[] {
               P00C86_A571PropostaAssinatura, P00C86_n571PropostaAssinatura, P00C86_A631ReembolsoAssinaturasId, P00C86_A572PropostaContratoAssinaturaId, P00C86_n572PropostaContratoAssinaturaId, P00C86_A574PropostaAssinaturaStatus, P00C86_n574PropostaAssinaturaStatus
               }
               , new Object[] {
               P00C87_A571PropostaAssinatura, P00C87_n571PropostaAssinatura, P00C87_A572PropostaContratoAssinaturaId, P00C87_A574PropostaAssinaturaStatus, P00C87_n574PropostaAssinaturaStatus
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12PageIndex ;
      private short AV11SkipItems ;
      private int AV19ReembolsoAssinaturasId ;
      private int AV10MaxItems ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A542ReembolsoPropostaId ;
      private int A558ReembolsoPropostaPacienteClienteId ;
      private int A518ReembolsoId ;
      private int A631ReembolsoAssinaturasId ;
      private int AV27ReembolsoId ;
      private int GXPagingFrom5 ;
      private int GXPagingTo5 ;
      private int A572PropostaContratoAssinaturaId ;
      private int AV28PropostaContratoAssinaturaId ;
      private long A571PropostaAssinatura ;
      private string AV17TrnMode ;
      private bool AV18IsDynamicCall ;
      private bool returnInSub ;
      private bool n542ReembolsoPropostaId ;
      private bool n558ReembolsoPropostaPacienteClienteId ;
      private bool n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool n518ReembolsoId ;
      private bool n571PropostaAssinatura ;
      private bool n572PropostaContratoAssinaturaId ;
      private bool n574PropostaAssinaturaStatus ;
      private string AV23Combo_DataJson ;
      private string AV16ComboName ;
      private string AV20SearchTxtParms ;
      private string AV21SelectedValue ;
      private string AV22SelectedText ;
      private string AV13SearchTxt ;
      private string lV13SearchTxt ;
      private string A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string A574PropostaAssinaturaStatus ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private int[] P00C82_A542ReembolsoPropostaId ;
      private bool[] P00C82_n542ReembolsoPropostaId ;
      private int[] P00C82_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] P00C82_n558ReembolsoPropostaPacienteClienteId ;
      private string[] P00C82_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] P00C82_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private int[] P00C82_A518ReembolsoId ;
      private bool[] P00C82_n518ReembolsoId ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV15Combo_DataItem ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14Combo_Data ;
      private int[] P00C83_A542ReembolsoPropostaId ;
      private bool[] P00C83_n542ReembolsoPropostaId ;
      private int[] P00C83_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] P00C83_n558ReembolsoPropostaPacienteClienteId ;
      private int[] P00C83_A631ReembolsoAssinaturasId ;
      private int[] P00C83_A518ReembolsoId ;
      private bool[] P00C83_n518ReembolsoId ;
      private string[] P00C83_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] P00C83_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private int[] P00C84_A542ReembolsoPropostaId ;
      private bool[] P00C84_n542ReembolsoPropostaId ;
      private int[] P00C84_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] P00C84_n558ReembolsoPropostaPacienteClienteId ;
      private int[] P00C84_A518ReembolsoId ;
      private bool[] P00C84_n518ReembolsoId ;
      private string[] P00C84_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] P00C84_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private long[] P00C85_A571PropostaAssinatura ;
      private bool[] P00C85_n571PropostaAssinatura ;
      private int[] P00C85_A572PropostaContratoAssinaturaId ;
      private bool[] P00C85_n572PropostaContratoAssinaturaId ;
      private string[] P00C85_A574PropostaAssinaturaStatus ;
      private bool[] P00C85_n574PropostaAssinaturaStatus ;
      private long[] P00C86_A571PropostaAssinatura ;
      private bool[] P00C86_n571PropostaAssinatura ;
      private int[] P00C86_A631ReembolsoAssinaturasId ;
      private int[] P00C86_A572PropostaContratoAssinaturaId ;
      private bool[] P00C86_n572PropostaContratoAssinaturaId ;
      private string[] P00C86_A574PropostaAssinaturaStatus ;
      private bool[] P00C86_n574PropostaAssinaturaStatus ;
      private long[] P00C87_A571PropostaAssinatura ;
      private bool[] P00C87_n571PropostaAssinatura ;
      private int[] P00C87_A572PropostaContratoAssinaturaId ;
      private bool[] P00C87_n572PropostaContratoAssinaturaId ;
      private string[] P00C87_A574PropostaAssinaturaStatus ;
      private bool[] P00C87_n574PropostaAssinaturaStatus ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
   }

   public class reembolsoassinaturasloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C82( IGxContext context ,
                                             string AV13SearchTxt ,
                                             string A550ReembolsoPropostaPacienteClienteRazaoSocial )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
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
            GXv_int1[0] = 1;
         }
         sOrderString += " ORDER BY T3.ClienteRazaoSocial, T1.ReembolsoId";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
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
                     return conditional_P00C82(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00C83;
          prmP00C83 = new Object[] {
          new ParDef("AV19ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmP00C84;
          prmP00C84 = new Object[] {
          new ParDef("AV27ReembolsoId",GXType.Int32,9,0)
          };
          Object[] prmP00C85;
          prmP00C85 = new Object[] {
          new ParDef("GXPagingFrom5",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo5",GXType.Int32,9,0)
          };
          Object[] prmP00C86;
          prmP00C86 = new Object[] {
          new ParDef("AV19ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmP00C87;
          prmP00C87 = new Object[] {
          new ParDef("AV28PropostaContratoAssinaturaId",GXType.Int32,9,0)
          };
          Object[] prmP00C82;
          prmP00C82 = new Object[] {
          new ParDef("lV13SearchTxt",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C82", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C82,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C83", "SELECT T2.ReembolsoPropostaId AS ReembolsoPropostaId, T3.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T1.ReembolsoAssinaturasId, T1.ReembolsoId, T4.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial FROM (((ReembolsoAssinaturas T1 LEFT JOIN Reembolso T2 ON T2.ReembolsoId = T1.ReembolsoId) LEFT JOIN Proposta T3 ON T3.PropostaId = T2.ReembolsoPropostaId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.PropostaPacienteClienteId) WHERE T1.ReembolsoAssinaturasId = :AV19ReembolsoAssinaturasId ORDER BY T1.ReembolsoAssinaturasId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C83,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C84", "SELECT T1.ReembolsoPropostaId AS ReembolsoPropostaId, T2.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T1.ReembolsoId, T3.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial FROM ((Reembolso T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.ReembolsoPropostaId) LEFT JOIN Cliente T3 ON T3.ClienteId = T2.PropostaPacienteClienteId) WHERE T1.ReembolsoId = :AV27ReembolsoId ORDER BY T1.ReembolsoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C84,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C85", "SELECT T1.PropostaAssinatura AS PropostaAssinatura, T1.PropostaContratoAssinaturaId, T2.AssinaturaStatus AS PropostaAssinaturaStatus FROM (PropostaContratoAssinatura T1 LEFT JOIN Assinatura T2 ON T2.AssinaturaId = T1.PropostaAssinatura) ORDER BY T2.AssinaturaStatus, T1.PropostaContratoAssinaturaId  OFFSET :GXPagingFrom5 LIMIT CASE WHEN :GXPagingTo5 > 0 THEN :GXPagingTo5 ELSE 1e9 END",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C85,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C86", "SELECT T2.PropostaAssinatura AS PropostaAssinatura, T1.ReembolsoAssinaturasId, T1.PropostaContratoAssinaturaId, T3.AssinaturaStatus AS PropostaAssinaturaStatus FROM ((ReembolsoAssinaturas T1 LEFT JOIN PropostaContratoAssinatura T2 ON T2.PropostaContratoAssinaturaId = T1.PropostaContratoAssinaturaId) LEFT JOIN Assinatura T3 ON T3.AssinaturaId = T2.PropostaAssinatura) WHERE T1.ReembolsoAssinaturasId = :AV19ReembolsoAssinaturasId ORDER BY T1.ReembolsoAssinaturasId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C86,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C87", "SELECT T1.PropostaAssinatura AS PropostaAssinatura, T1.PropostaContratoAssinaturaId, T2.AssinaturaStatus AS PropostaAssinaturaStatus FROM (PropostaContratoAssinatura T1 LEFT JOIN Assinatura T2 ON T2.AssinaturaId = T1.PropostaAssinatura) WHERE T1.PropostaContratoAssinaturaId = :AV28PropostaContratoAssinaturaId ORDER BY T1.PropostaContratoAssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C87,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
