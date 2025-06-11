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
   public class bancowwgetfilterdata : GXProcedure
   {
      public bancowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public bancowwgetfilterdata( IGxContext context )
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
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV35OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV30DDOName = aP0_DDOName;
         this.AV31SearchTxtParms = aP1_SearchTxtParms;
         this.AV32SearchTxtTo = aP2_SearchTxtTo;
         this.AV33OptionsJson = "" ;
         this.AV34OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV33OptionsJson;
         aP4_OptionsDescJson=this.AV34OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV20Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV17MaxItems = 10;
         AV16PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV31SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV31SearchTxtParms)) ? "" : StringUtil.Substring( AV31SearchTxtParms, 3, -1));
         AV15SkipItems = (short)(AV16PageIndex*AV17MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_BANCONOME") == 0 )
         {
            /* Execute user subroutine: 'LOADBANCONOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV33OptionsJson = AV20Options.ToJSonString(false);
         AV34OptionsDescJson = AV22OptionsDesc.ToJSonString(false);
         AV35OptionIndexesJson = AV23OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV25Session.Get("BancoWWGridState"), "") == 0 )
         {
            AV27GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "BancoWWGridState"), null, "", "");
         }
         else
         {
            AV27GridState.FromXml(AV25Session.Get("BancoWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV36FilterFullText = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFBANCOCODIGO") == 0 )
            {
               AV10TFBancoCodigo = (int)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV11TFBancoCodigo_To = (int)(Math.Round(NumberUtil.Val( AV28GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFBANCONOME") == 0 )
            {
               AV12TFBancoNome = AV28GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Name, "TFBANCONOME_SEL") == 0 )
            {
               AV13TFBancoNome_Sel = AV28GridStateFilterValue.gxTpr_Value;
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADBANCONOMEOPTIONS' Routine */
         returnInSub = false;
         AV12TFBancoNome = AV14SearchTxt;
         AV13TFBancoNome_Sel = "";
         AV50Bancowwds_1_filterfulltext = AV36FilterFullText;
         AV51Bancowwds_2_tfbancocodigo = AV10TFBancoCodigo;
         AV52Bancowwds_3_tfbancocodigo_to = AV11TFBancoCodigo_To;
         AV53Bancowwds_4_tfbanconome = AV12TFBancoNome;
         AV54Bancowwds_5_tfbanconome_sel = AV13TFBancoNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Bancowwds_1_filterfulltext ,
                                              AV51Bancowwds_2_tfbancocodigo ,
                                              AV52Bancowwds_3_tfbancocodigo_to ,
                                              AV54Bancowwds_5_tfbanconome_sel ,
                                              AV53Bancowwds_4_tfbanconome ,
                                              A404BancoCodigo ,
                                              A403BancoNome } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV50Bancowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Bancowwds_1_filterfulltext), "%", "");
         lV50Bancowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Bancowwds_1_filterfulltext), "%", "");
         lV53Bancowwds_4_tfbanconome = StringUtil.Concat( StringUtil.RTrim( AV53Bancowwds_4_tfbanconome), "%", "");
         /* Using cursor P00D42 */
         pr_default.execute(0, new Object[] {lV50Bancowwds_1_filterfulltext, lV50Bancowwds_1_filterfulltext, AV51Bancowwds_2_tfbancocodigo, AV52Bancowwds_3_tfbancocodigo_to, lV53Bancowwds_4_tfbanconome, AV54Bancowwds_5_tfbanconome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKD42 = false;
            A403BancoNome = P00D42_A403BancoNome[0];
            n403BancoNome = P00D42_n403BancoNome[0];
            A404BancoCodigo = P00D42_A404BancoCodigo[0];
            n404BancoCodigo = P00D42_n404BancoCodigo[0];
            A402BancoId = P00D42_A402BancoId[0];
            AV24count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00D42_A403BancoNome[0], A403BancoNome) == 0 ) )
            {
               BRKD42 = false;
               A402BancoId = P00D42_A402BancoId[0];
               AV24count = (long)(AV24count+1);
               BRKD42 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV15SkipItems) )
            {
               AV19Option = (String.IsNullOrEmpty(StringUtil.RTrim( A403BancoNome)) ? "<#Empty#>" : A403BancoNome);
               AV20Options.Add(AV19Option, 0);
               AV23OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV24count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV20Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV15SkipItems = (short)(AV15SkipItems-1);
            }
            if ( ! BRKD42 )
            {
               BRKD42 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV33OptionsJson = "";
         AV34OptionsDescJson = "";
         AV35OptionIndexesJson = "";
         AV20Options = new GxSimpleCollection<string>();
         AV22OptionsDesc = new GxSimpleCollection<string>();
         AV23OptionIndexes = new GxSimpleCollection<string>();
         AV14SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV25Session = context.GetSession();
         AV27GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV28GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV36FilterFullText = "";
         AV12TFBancoNome = "";
         AV13TFBancoNome_Sel = "";
         AV50Bancowwds_1_filterfulltext = "";
         AV53Bancowwds_4_tfbanconome = "";
         AV54Bancowwds_5_tfbanconome_sel = "";
         lV50Bancowwds_1_filterfulltext = "";
         lV53Bancowwds_4_tfbanconome = "";
         A403BancoNome = "";
         P00D42_A403BancoNome = new string[] {""} ;
         P00D42_n403BancoNome = new bool[] {false} ;
         P00D42_A404BancoCodigo = new int[1] ;
         P00D42_n404BancoCodigo = new bool[] {false} ;
         P00D42_A402BancoId = new int[1] ;
         AV19Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00D42_A403BancoNome, P00D42_n403BancoNome, P00D42_A404BancoCodigo, P00D42_n404BancoCodigo, P00D42_A402BancoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV17MaxItems ;
      private short AV16PageIndex ;
      private short AV15SkipItems ;
      private int AV48GXV1 ;
      private int AV10TFBancoCodigo ;
      private int AV11TFBancoCodigo_To ;
      private int AV51Bancowwds_2_tfbancocodigo ;
      private int AV52Bancowwds_3_tfbancocodigo_to ;
      private int A404BancoCodigo ;
      private int A402BancoId ;
      private long AV24count ;
      private bool returnInSub ;
      private bool BRKD42 ;
      private bool n403BancoNome ;
      private bool n404BancoCodigo ;
      private string AV33OptionsJson ;
      private string AV34OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV30DDOName ;
      private string AV31SearchTxtParms ;
      private string AV32SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV36FilterFullText ;
      private string AV12TFBancoNome ;
      private string AV13TFBancoNome_Sel ;
      private string AV50Bancowwds_1_filterfulltext ;
      private string AV53Bancowwds_4_tfbanconome ;
      private string AV54Bancowwds_5_tfbanconome_sel ;
      private string lV50Bancowwds_1_filterfulltext ;
      private string lV53Bancowwds_4_tfbanconome ;
      private string A403BancoNome ;
      private string AV19Option ;
      private IGxSession AV25Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV20Options ;
      private GxSimpleCollection<string> AV22OptionsDesc ;
      private GxSimpleCollection<string> AV23OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV27GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV28GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private string[] P00D42_A403BancoNome ;
      private bool[] P00D42_n403BancoNome ;
      private int[] P00D42_A404BancoCodigo ;
      private bool[] P00D42_n404BancoCodigo ;
      private int[] P00D42_A402BancoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class bancowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00D42( IGxContext context ,
                                             string AV50Bancowwds_1_filterfulltext ,
                                             int AV51Bancowwds_2_tfbancocodigo ,
                                             int AV52Bancowwds_3_tfbancocodigo_to ,
                                             string AV54Bancowwds_5_tfbanconome_sel ,
                                             string AV53Bancowwds_4_tfbanconome ,
                                             int A404BancoCodigo ,
                                             string A403BancoNome )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT BancoNome, BancoCodigo, BancoId FROM Banco";
         AddWhere(sWhereString, "(BancoCodigo > 0)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Bancowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(BancoCodigo,'999999999'), 2) like '%' || :lV50Bancowwds_1_filterfulltext) or ( LOWER(BancoNome) like '%' || LOWER(:lV50Bancowwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV51Bancowwds_2_tfbancocodigo) )
         {
            AddWhere(sWhereString, "(BancoCodigo >= :AV51Bancowwds_2_tfbancocodigo)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV52Bancowwds_3_tfbancocodigo_to) )
         {
            AddWhere(sWhereString, "(BancoCodigo <= :AV52Bancowwds_3_tfbancocodigo_to)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Bancowwds_5_tfbanconome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Bancowwds_4_tfbanconome)) ) )
         {
            AddWhere(sWhereString, "(BancoNome like :lV53Bancowwds_4_tfbanconome)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Bancowwds_5_tfbanconome_sel)) && ! ( StringUtil.StrCmp(AV54Bancowwds_5_tfbanconome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(BancoNome = ( :AV54Bancowwds_5_tfbanconome_sel))");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( StringUtil.StrCmp(AV54Bancowwds_5_tfbanconome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(BancoNome IS NULL or (char_length(trim(trailing ' ' from BancoNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY BancoNome";
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
                     return conditional_P00D42(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] );
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
          Object[] prmP00D42;
          prmP00D42 = new Object[] {
          new ParDef("lV50Bancowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV50Bancowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV51Bancowwds_2_tfbancocodigo",GXType.Int32,9,0) ,
          new ParDef("AV52Bancowwds_3_tfbancocodigo_to",GXType.Int32,9,0) ,
          new ParDef("lV53Bancowwds_4_tfbanconome",GXType.VarChar,150,0) ,
          new ParDef("AV54Bancowwds_5_tfbanconome_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D42", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D42,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
