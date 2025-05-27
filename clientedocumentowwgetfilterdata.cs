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
   public class clientedocumentowwgetfilterdata : GXProcedure
   {
      public clientedocumentowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientedocumentowwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV28DDOName = aP0_DDOName;
         this.AV29SearchTxtParms = aP1_SearchTxtParms;
         this.AV30SearchTxtTo = aP2_SearchTxtTo;
         this.AV31OptionsJson = "" ;
         this.AV32OptionsDescJson = "" ;
         this.AV33OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV31OptionsJson;
         aP4_OptionsDescJson=this.AV32OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV33OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV28DDOName = aP0_DDOName;
         this.AV29SearchTxtParms = aP1_SearchTxtParms;
         this.AV30SearchTxtTo = aP2_SearchTxtTo;
         this.AV31OptionsJson = "" ;
         this.AV32OptionsDescJson = "" ;
         this.AV33OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV31OptionsJson;
         aP4_OptionsDescJson=this.AV32OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV18Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV20OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV15MaxItems = 10;
         AV14PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV29SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV29SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV12SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV29SearchTxtParms)) ? "" : StringUtil.Substring( AV29SearchTxtParms, 3, -1));
         AV13SkipItems = (short)(AV14PageIndex*AV15MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_DOCUMENTOSDESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADDOCUMENTOSDESCRICAOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_CLIENTENOMEDOARQUIVO_F") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTENOMEDOARQUIVO_FOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV31OptionsJson = AV18Options.ToJSonString(false);
         AV32OptionsDescJson = AV20OptionsDesc.ToJSonString(false);
         AV33OptionIndexesJson = AV21OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV23Session.Get("ClienteDocumentoWWGridState"), "") == 0 )
         {
            AV25GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ClienteDocumentoWWGridState"), null, "", "");
         }
         else
         {
            AV25GridState.FromXml(AV23Session.Get("ClienteDocumentoWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV25GridState.gxTpr_Filtervalues.Count )
         {
            AV26GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV25GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV34FilterFullText = AV26GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOSDESCRICAO") == 0 )
            {
               AV43TFDocumentosDescricao = AV26GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFDOCUMENTOSDESCRICAO_SEL") == 0 )
            {
               AV44TFDocumentosDescricao_Sel = AV26GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFCLIENTENOMEDOARQUIVO_F") == 0 )
            {
               AV45TFClienteNomeDoArquivo_F = AV26GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "TFCLIENTENOMEDOARQUIVO_F_SEL") == 0 )
            {
               AV46TFClienteNomeDoArquivo_F_Sel = AV26GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV26GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTEID") == 0 )
            {
               AV47ClienteId = (int)(Math.Round(NumberUtil.Val( AV26GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADDOCUMENTOSDESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV43TFDocumentosDescricao = AV12SearchTxt;
         AV44TFDocumentosDescricao_Sel = "";
         AV50Clientedocumentowwds_1_clienteid = AV47ClienteId;
         AV51Clientedocumentowwds_2_filterfulltext = AV34FilterFullText;
         AV52Clientedocumentowwds_3_tfdocumentosdescricao = AV43TFDocumentosDescricao;
         AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel = AV44TFDocumentosDescricao_Sel;
         AV54Clientedocumentowwds_5_tfclientenomedoarquivo_f = AV45TFClienteNomeDoArquivo_F;
         AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel = AV46TFClienteNomeDoArquivo_F_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel ,
                                              AV52Clientedocumentowwds_3_tfdocumentosdescricao ,
                                              A406DocumentosDescricao ,
                                              AV51Clientedocumentowwds_2_filterfulltext ,
                                              A607ClienteNomeDoArquivo_F ,
                                              AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel ,
                                              AV54Clientedocumentowwds_5_tfclientenomedoarquivo_f ,
                                              AV50Clientedocumentowwds_1_clienteid ,
                                              A168ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Clientedocumentowwds_3_tfdocumentosdescricao = StringUtil.Concat( StringUtil.RTrim( AV52Clientedocumentowwds_3_tfdocumentosdescricao), "%", "");
         /* Using cursor P00BR2 */
         pr_default.execute(0, new Object[] {AV50Clientedocumentowwds_1_clienteid, lV52Clientedocumentowwds_3_tfdocumentosdescricao, AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKBR2 = false;
            A168ClienteId = P00BR2_A168ClienteId[0];
            n168ClienteId = P00BR2_n168ClienteId[0];
            A405DocumentosId = P00BR2_A405DocumentosId[0];
            n405DocumentosId = P00BR2_n405DocumentosId[0];
            A406DocumentosDescricao = P00BR2_A406DocumentosDescricao[0];
            n406DocumentosDescricao = P00BR2_n406DocumentosDescricao[0];
            A603ClienteDocumentoExtensao = P00BR2_A603ClienteDocumentoExtensao[0];
            n603ClienteDocumentoExtensao = P00BR2_n603ClienteDocumentoExtensao[0];
            A602ClienteDocumentoNome = P00BR2_A602ClienteDocumentoNome[0];
            n602ClienteDocumentoNome = P00BR2_n602ClienteDocumentoNome[0];
            A599ClienteDocumentoId = P00BR2_A599ClienteDocumentoId[0];
            A406DocumentosDescricao = P00BR2_A406DocumentosDescricao[0];
            n406DocumentosDescricao = P00BR2_n406DocumentosDescricao[0];
            A607ClienteNomeDoArquivo_F = StringUtil.Format( "%1.%2", A602ClienteDocumentoNome, A603ClienteDocumentoExtensao, "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Clientedocumentowwds_2_filterfulltext)) || ( ( StringUtil.Like( A406DocumentosDescricao , StringUtil.PadR( "%" + AV51Clientedocumentowwds_2_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A607ClienteNomeDoArquivo_F , StringUtil.PadR( "%" + AV51Clientedocumentowwds_2_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Clientedocumentowwds_5_tfclientenomedoarquivo_f)) ) ) || ( StringUtil.Like( A607ClienteNomeDoArquivo_F , StringUtil.PadR( AV54Clientedocumentowwds_5_tfclientenomedoarquivo_f , 100 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel)) && ! ( StringUtil.StrCmp(AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A607ClienteNomeDoArquivo_F, AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A607ClienteNomeDoArquivo_F)) ) )
                     {
                        AV22count = 0;
                        while ( (pr_default.getStatus(0) != 101) && ( P00BR2_A168ClienteId[0] == A168ClienteId ) && ( P00BR2_A405DocumentosId[0] == A405DocumentosId ) )
                        {
                           BRKBR2 = false;
                           A599ClienteDocumentoId = P00BR2_A599ClienteDocumentoId[0];
                           AV22count = (long)(AV22count+1);
                           BRKBR2 = true;
                           pr_default.readNext(0);
                        }
                        AV17Option = (String.IsNullOrEmpty(StringUtil.RTrim( A406DocumentosDescricao)) ? "<#Empty#>" : A406DocumentosDescricao);
                        AV16InsertIndex = 1;
                        while ( ( StringUtil.StrCmp(AV17Option, "<#Empty#>") != 0 ) && ( AV16InsertIndex <= AV18Options.Count ) && ( ( StringUtil.StrCmp(((string)AV18Options.Item(AV16InsertIndex)), AV17Option) < 0 ) || ( StringUtil.StrCmp(((string)AV18Options.Item(AV16InsertIndex)), "<#Empty#>") == 0 ) ) )
                        {
                           AV16InsertIndex = (int)(AV16InsertIndex+1);
                        }
                        AV18Options.Add(AV17Option, AV16InsertIndex);
                        AV21OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV22count), "Z,ZZZ,ZZZ,ZZ9")), AV16InsertIndex);
                        if ( AV18Options.Count == AV13SkipItems + 11 )
                        {
                           AV18Options.RemoveItem(AV18Options.Count);
                           AV21OptionIndexes.RemoveItem(AV21OptionIndexes.Count);
                        }
                     }
                  }
               }
            }
            if ( ! BRKBR2 )
            {
               BRKBR2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV13SkipItems > 0 )
         {
            AV18Options.RemoveItem(1);
            AV21OptionIndexes.RemoveItem(1);
            AV13SkipItems = (short)(AV13SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADCLIENTENOMEDOARQUIVO_FOPTIONS' Routine */
         returnInSub = false;
         AV45TFClienteNomeDoArquivo_F = AV12SearchTxt;
         AV46TFClienteNomeDoArquivo_F_Sel = "";
         AV50Clientedocumentowwds_1_clienteid = AV47ClienteId;
         AV51Clientedocumentowwds_2_filterfulltext = AV34FilterFullText;
         AV52Clientedocumentowwds_3_tfdocumentosdescricao = AV43TFDocumentosDescricao;
         AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel = AV44TFDocumentosDescricao_Sel;
         AV54Clientedocumentowwds_5_tfclientenomedoarquivo_f = AV45TFClienteNomeDoArquivo_F;
         AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel = AV46TFClienteNomeDoArquivo_F_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel ,
                                              AV52Clientedocumentowwds_3_tfdocumentosdescricao ,
                                              A406DocumentosDescricao ,
                                              AV51Clientedocumentowwds_2_filterfulltext ,
                                              A607ClienteNomeDoArquivo_F ,
                                              AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel ,
                                              AV54Clientedocumentowwds_5_tfclientenomedoarquivo_f ,
                                              AV50Clientedocumentowwds_1_clienteid ,
                                              A168ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV52Clientedocumentowwds_3_tfdocumentosdescricao = StringUtil.Concat( StringUtil.RTrim( AV52Clientedocumentowwds_3_tfdocumentosdescricao), "%", "");
         /* Using cursor P00BR3 */
         pr_default.execute(1, new Object[] {AV50Clientedocumentowwds_1_clienteid, lV52Clientedocumentowwds_3_tfdocumentosdescricao, AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A405DocumentosId = P00BR3_A405DocumentosId[0];
            n405DocumentosId = P00BR3_n405DocumentosId[0];
            A406DocumentosDescricao = P00BR3_A406DocumentosDescricao[0];
            n406DocumentosDescricao = P00BR3_n406DocumentosDescricao[0];
            A168ClienteId = P00BR3_A168ClienteId[0];
            n168ClienteId = P00BR3_n168ClienteId[0];
            A603ClienteDocumentoExtensao = P00BR3_A603ClienteDocumentoExtensao[0];
            n603ClienteDocumentoExtensao = P00BR3_n603ClienteDocumentoExtensao[0];
            A602ClienteDocumentoNome = P00BR3_A602ClienteDocumentoNome[0];
            n602ClienteDocumentoNome = P00BR3_n602ClienteDocumentoNome[0];
            A599ClienteDocumentoId = P00BR3_A599ClienteDocumentoId[0];
            A406DocumentosDescricao = P00BR3_A406DocumentosDescricao[0];
            n406DocumentosDescricao = P00BR3_n406DocumentosDescricao[0];
            A607ClienteNomeDoArquivo_F = StringUtil.Format( "%1.%2", A602ClienteDocumentoNome, A603ClienteDocumentoExtensao, "", "", "", "", "", "", "");
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Clientedocumentowwds_2_filterfulltext)) || ( ( StringUtil.Like( A406DocumentosDescricao , StringUtil.PadR( "%" + AV51Clientedocumentowwds_2_filterfulltext , 101 , "%"),  ' ' ) ) || ( StringUtil.Like( A607ClienteNomeDoArquivo_F , StringUtil.PadR( "%" + AV51Clientedocumentowwds_2_filterfulltext , 101 , "%"),  ' ' ) ) ) )
            {
               if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Clientedocumentowwds_5_tfclientenomedoarquivo_f)) ) ) || ( StringUtil.Like( A607ClienteNomeDoArquivo_F , StringUtil.PadR( AV54Clientedocumentowwds_5_tfclientenomedoarquivo_f , 100 , "%"),  ' ' ) ) )
               {
                  if ( ! ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel)) && ! ( StringUtil.StrCmp(AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel, "<#Empty#>") == 0 ) ) || ( ( StringUtil.StrCmp(A607ClienteNomeDoArquivo_F, AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel) == 0 ) ) )
                  {
                     if ( ( StringUtil.StrCmp(AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel, "<#Empty#>") != 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( A607ClienteNomeDoArquivo_F)) ) )
                     {
                        AV17Option = (String.IsNullOrEmpty(StringUtil.RTrim( A607ClienteNomeDoArquivo_F)) ? "<#Empty#>" : A607ClienteNomeDoArquivo_F);
                        AV16InsertIndex = 1;
                        while ( ( StringUtil.StrCmp(AV17Option, "<#Empty#>") != 0 ) && ( AV16InsertIndex <= AV18Options.Count ) && ( ( StringUtil.StrCmp(((string)AV18Options.Item(AV16InsertIndex)), AV17Option) < 0 ) || ( StringUtil.StrCmp(((string)AV18Options.Item(AV16InsertIndex)), "<#Empty#>") == 0 ) ) )
                        {
                           AV16InsertIndex = (int)(AV16InsertIndex+1);
                        }
                        if ( ( AV16InsertIndex <= AV18Options.Count ) && ( StringUtil.StrCmp(((string)AV18Options.Item(AV16InsertIndex)), AV17Option) == 0 ) )
                        {
                           AV22count = (long)(Math.Round(NumberUtil.Val( ((string)AV21OptionIndexes.Item(AV16InsertIndex)), "."), 18, MidpointRounding.ToEven));
                           AV22count = (long)(AV22count+1);
                           AV21OptionIndexes.RemoveItem(AV16InsertIndex);
                           AV21OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV22count), "Z,ZZZ,ZZZ,ZZ9")), AV16InsertIndex);
                        }
                        else
                        {
                           AV18Options.Add(AV17Option, AV16InsertIndex);
                           AV21OptionIndexes.Add("1", AV16InsertIndex);
                        }
                        if ( AV18Options.Count == AV13SkipItems + 11 )
                        {
                           AV18Options.RemoveItem(AV18Options.Count);
                           AV21OptionIndexes.RemoveItem(AV21OptionIndexes.Count);
                        }
                     }
                  }
               }
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         while ( AV13SkipItems > 0 )
         {
            AV18Options.RemoveItem(1);
            AV21OptionIndexes.RemoveItem(1);
            AV13SkipItems = (short)(AV13SkipItems-1);
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
         AV31OptionsJson = "";
         AV32OptionsDescJson = "";
         AV33OptionIndexesJson = "";
         AV18Options = new GxSimpleCollection<string>();
         AV20OptionsDesc = new GxSimpleCollection<string>();
         AV21OptionIndexes = new GxSimpleCollection<string>();
         AV12SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV23Session = context.GetSession();
         AV25GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV34FilterFullText = "";
         AV43TFDocumentosDescricao = "";
         AV44TFDocumentosDescricao_Sel = "";
         AV45TFClienteNomeDoArquivo_F = "";
         AV46TFClienteNomeDoArquivo_F_Sel = "";
         AV51Clientedocumentowwds_2_filterfulltext = "";
         AV52Clientedocumentowwds_3_tfdocumentosdescricao = "";
         AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel = "";
         AV54Clientedocumentowwds_5_tfclientenomedoarquivo_f = "";
         AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel = "";
         lV52Clientedocumentowwds_3_tfdocumentosdescricao = "";
         A406DocumentosDescricao = "";
         A607ClienteNomeDoArquivo_F = "";
         P00BR2_A168ClienteId = new int[1] ;
         P00BR2_n168ClienteId = new bool[] {false} ;
         P00BR2_A405DocumentosId = new int[1] ;
         P00BR2_n405DocumentosId = new bool[] {false} ;
         P00BR2_A406DocumentosDescricao = new string[] {""} ;
         P00BR2_n406DocumentosDescricao = new bool[] {false} ;
         P00BR2_A603ClienteDocumentoExtensao = new string[] {""} ;
         P00BR2_n603ClienteDocumentoExtensao = new bool[] {false} ;
         P00BR2_A602ClienteDocumentoNome = new string[] {""} ;
         P00BR2_n602ClienteDocumentoNome = new bool[] {false} ;
         P00BR2_A599ClienteDocumentoId = new int[1] ;
         A603ClienteDocumentoExtensao = "";
         A602ClienteDocumentoNome = "";
         AV17Option = "";
         P00BR3_A405DocumentosId = new int[1] ;
         P00BR3_n405DocumentosId = new bool[] {false} ;
         P00BR3_A406DocumentosDescricao = new string[] {""} ;
         P00BR3_n406DocumentosDescricao = new bool[] {false} ;
         P00BR3_A168ClienteId = new int[1] ;
         P00BR3_n168ClienteId = new bool[] {false} ;
         P00BR3_A603ClienteDocumentoExtensao = new string[] {""} ;
         P00BR3_n603ClienteDocumentoExtensao = new bool[] {false} ;
         P00BR3_A602ClienteDocumentoNome = new string[] {""} ;
         P00BR3_n602ClienteDocumentoNome = new bool[] {false} ;
         P00BR3_A599ClienteDocumentoId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientedocumentowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00BR2_A168ClienteId, P00BR2_n168ClienteId, P00BR2_A405DocumentosId, P00BR2_n405DocumentosId, P00BR2_A406DocumentosDescricao, P00BR2_n406DocumentosDescricao, P00BR2_A603ClienteDocumentoExtensao, P00BR2_n603ClienteDocumentoExtensao, P00BR2_A602ClienteDocumentoNome, P00BR2_n602ClienteDocumentoNome,
               P00BR2_A599ClienteDocumentoId
               }
               , new Object[] {
               P00BR3_A405DocumentosId, P00BR3_n405DocumentosId, P00BR3_A406DocumentosDescricao, P00BR3_n406DocumentosDescricao, P00BR3_A168ClienteId, P00BR3_n168ClienteId, P00BR3_A603ClienteDocumentoExtensao, P00BR3_n603ClienteDocumentoExtensao, P00BR3_A602ClienteDocumentoNome, P00BR3_n602ClienteDocumentoNome,
               P00BR3_A599ClienteDocumentoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV15MaxItems ;
      private short AV14PageIndex ;
      private short AV13SkipItems ;
      private int AV48GXV1 ;
      private int AV47ClienteId ;
      private int AV50Clientedocumentowwds_1_clienteid ;
      private int A168ClienteId ;
      private int A405DocumentosId ;
      private int A599ClienteDocumentoId ;
      private int AV16InsertIndex ;
      private long AV22count ;
      private bool returnInSub ;
      private bool BRKBR2 ;
      private bool n168ClienteId ;
      private bool n405DocumentosId ;
      private bool n406DocumentosDescricao ;
      private bool n603ClienteDocumentoExtensao ;
      private bool n602ClienteDocumentoNome ;
      private string AV31OptionsJson ;
      private string AV32OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV28DDOName ;
      private string AV29SearchTxtParms ;
      private string AV30SearchTxtTo ;
      private string AV12SearchTxt ;
      private string AV34FilterFullText ;
      private string AV43TFDocumentosDescricao ;
      private string AV44TFDocumentosDescricao_Sel ;
      private string AV45TFClienteNomeDoArquivo_F ;
      private string AV46TFClienteNomeDoArquivo_F_Sel ;
      private string AV51Clientedocumentowwds_2_filterfulltext ;
      private string AV52Clientedocumentowwds_3_tfdocumentosdescricao ;
      private string AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel ;
      private string AV54Clientedocumentowwds_5_tfclientenomedoarquivo_f ;
      private string AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel ;
      private string lV52Clientedocumentowwds_3_tfdocumentosdescricao ;
      private string A406DocumentosDescricao ;
      private string A607ClienteNomeDoArquivo_F ;
      private string A603ClienteDocumentoExtensao ;
      private string A602ClienteDocumentoNome ;
      private string AV17Option ;
      private IGxSession AV23Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV18Options ;
      private GxSimpleCollection<string> AV20OptionsDesc ;
      private GxSimpleCollection<string> AV21OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV25GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV26GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private int[] P00BR2_A168ClienteId ;
      private bool[] P00BR2_n168ClienteId ;
      private int[] P00BR2_A405DocumentosId ;
      private bool[] P00BR2_n405DocumentosId ;
      private string[] P00BR2_A406DocumentosDescricao ;
      private bool[] P00BR2_n406DocumentosDescricao ;
      private string[] P00BR2_A603ClienteDocumentoExtensao ;
      private bool[] P00BR2_n603ClienteDocumentoExtensao ;
      private string[] P00BR2_A602ClienteDocumentoNome ;
      private bool[] P00BR2_n602ClienteDocumentoNome ;
      private int[] P00BR2_A599ClienteDocumentoId ;
      private int[] P00BR3_A405DocumentosId ;
      private bool[] P00BR3_n405DocumentosId ;
      private string[] P00BR3_A406DocumentosDescricao ;
      private bool[] P00BR3_n406DocumentosDescricao ;
      private int[] P00BR3_A168ClienteId ;
      private bool[] P00BR3_n168ClienteId ;
      private string[] P00BR3_A603ClienteDocumentoExtensao ;
      private bool[] P00BR3_n603ClienteDocumentoExtensao ;
      private string[] P00BR3_A602ClienteDocumentoNome ;
      private bool[] P00BR3_n602ClienteDocumentoNome ;
      private int[] P00BR3_A599ClienteDocumentoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class clientedocumentowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BR2( IGxContext context ,
                                             string AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel ,
                                             string AV52Clientedocumentowwds_3_tfdocumentosdescricao ,
                                             string A406DocumentosDescricao ,
                                             string AV51Clientedocumentowwds_2_filterfulltext ,
                                             string A607ClienteNomeDoArquivo_F ,
                                             string AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel ,
                                             string AV54Clientedocumentowwds_5_tfclientenomedoarquivo_f ,
                                             int AV50Clientedocumentowwds_1_clienteid ,
                                             int A168ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ClienteId, T1.DocumentosId, T2.DocumentosDescricao, T1.ClienteDocumentoExtensao, T1.ClienteDocumentoNome, T1.ClienteDocumentoId FROM (ClienteDocumento T1 LEFT JOIN Documentos T2 ON T2.DocumentosId = T1.DocumentosId)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV50Clientedocumentowwds_1_clienteid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Clientedocumentowwds_3_tfdocumentosdescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.DocumentosDescricao like :lV52Clientedocumentowwds_3_tfdocumentosdescricao)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel)) && ! ( StringUtil.StrCmp(AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.DocumentosDescricao = ( :AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.DocumentosDescricao IS NULL or (char_length(trim(trailing ' ' from T2.DocumentosDescricao))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteId, T1.DocumentosId";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00BR3( IGxContext context ,
                                             string AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel ,
                                             string AV52Clientedocumentowwds_3_tfdocumentosdescricao ,
                                             string A406DocumentosDescricao ,
                                             string AV51Clientedocumentowwds_2_filterfulltext ,
                                             string A607ClienteNomeDoArquivo_F ,
                                             string AV55Clientedocumentowwds_6_tfclientenomedoarquivo_f_sel ,
                                             string AV54Clientedocumentowwds_5_tfclientenomedoarquivo_f ,
                                             int AV50Clientedocumentowwds_1_clienteid ,
                                             int A168ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[3];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.DocumentosId, T2.DocumentosDescricao, T1.ClienteId, T1.ClienteDocumentoExtensao, T1.ClienteDocumentoNome, T1.ClienteDocumentoId FROM (ClienteDocumento T1 LEFT JOIN Documentos T2 ON T2.DocumentosId = T1.DocumentosId)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV50Clientedocumentowwds_1_clienteid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Clientedocumentowwds_3_tfdocumentosdescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.DocumentosDescricao like :lV52Clientedocumentowwds_3_tfdocumentosdescricao)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel)) && ! ( StringUtil.StrCmp(AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.DocumentosDescricao = ( :AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel))");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( StringUtil.StrCmp(AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.DocumentosDescricao IS NULL or (char_length(trim(trailing ' ' from T2.DocumentosDescricao))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.ClienteId";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00BR2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] );
               case 1 :
                     return conditional_P00BR3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00BR2;
          prmP00BR2 = new Object[] {
          new ParDef("AV50Clientedocumentowwds_1_clienteid",GXType.Int32,9,0) ,
          new ParDef("lV52Clientedocumentowwds_3_tfdocumentosdescricao",GXType.VarChar,40,0) ,
          new ParDef("AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00BR3;
          prmP00BR3 = new Object[] {
          new ParDef("AV50Clientedocumentowwds_1_clienteid",GXType.Int32,9,0) ,
          new ParDef("lV52Clientedocumentowwds_3_tfdocumentosdescricao",GXType.VarChar,40,0) ,
          new ParDef("AV53Clientedocumentowwds_4_tfdocumentosdescricao_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BR2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BR2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BR3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BR3,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
