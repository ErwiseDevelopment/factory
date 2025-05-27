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
   public class wcuserssignaturegetfilterdata : GXProcedure
   {
      public wcuserssignaturegetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wcuserssignaturegetfilterdata( IGxContext context )
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
         this.AV40DDOName = aP0_DDOName;
         this.AV41SearchTxtParms = aP1_SearchTxtParms;
         this.AV42SearchTxtTo = aP2_SearchTxtTo;
         this.AV43OptionsJson = "" ;
         this.AV44OptionsDescJson = "" ;
         this.AV45OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV43OptionsJson;
         aP4_OptionsDescJson=this.AV44OptionsDescJson;
         aP5_OptionIndexesJson=this.AV45OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV45OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV40DDOName = aP0_DDOName;
         this.AV41SearchTxtParms = aP1_SearchTxtParms;
         this.AV42SearchTxtTo = aP2_SearchTxtTo;
         this.AV43OptionsJson = "" ;
         this.AV44OptionsDescJson = "" ;
         this.AV45OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV43OptionsJson;
         aP4_OptionsDescJson=this.AV44OptionsDescJson;
         aP5_OptionIndexesJson=this.AV45OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV30Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27MaxItems = 10;
         AV26PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV41SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV41SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV24SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV41SearchTxtParms)) ? "" : StringUtil.Substring( AV41SearchTxtParms, 3, -1));
         AV25SkipItems = (short)(AV26PageIndex*AV27MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV40DDOName), "DDO_PARTICIPANTENOME") == 0 )
         {
            /* Execute user subroutine: 'LOADPARTICIPANTENOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV43OptionsJson = AV30Options.ToJSonString(false);
         AV44OptionsDescJson = AV32OptionsDesc.ToJSonString(false);
         AV45OptionIndexesJson = AV33OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35Session.Get("WcUsersSignatureGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WcUsersSignatureGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("WcUsersSignatureGridState"), null, "", "");
         }
         AV67GXV1 = 1;
         while ( AV67GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV67GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTENOME") == 0 )
            {
               AV48TFParticipanteNome = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTENOME_SEL") == 0 )
            {
               AV49TFParticipanteNome_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "PARM_&ASSINATURAID") == 0 )
            {
               AV46AssinaturaId = (long)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "PARM_&ASSINATURAPARTICIPANTEID") == 0 )
            {
               AV47AssinaturaParticipanteId = (int)(Math.Round(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV67GXV1 = (int)(AV67GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPARTICIPANTENOMEOPTIONS' Routine */
         returnInSub = false;
         AV48TFParticipanteNome = AV24SearchTxt;
         AV49TFParticipanteNome_Sel = "";
         AV69Wcuserssignatureds_1_assinaturaid = AV46AssinaturaId;
         AV70Wcuserssignatureds_2_tfparticipantenome = AV48TFParticipanteNome;
         AV71Wcuserssignatureds_3_tfparticipantenome_sel = AV49TFParticipanteNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV71Wcuserssignatureds_3_tfparticipantenome_sel ,
                                              AV70Wcuserssignatureds_2_tfparticipantenome ,
                                              A248ParticipanteNome ,
                                              A242AssinaturaParticipanteId ,
                                              AV47AssinaturaParticipanteId ,
                                              AV69Wcuserssignatureds_1_assinaturaid ,
                                              A238AssinaturaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV70Wcuserssignatureds_2_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV70Wcuserssignatureds_2_tfparticipantenome), "%", "");
         /* Using cursor P008S2 */
         pr_default.execute(0, new Object[] {AV69Wcuserssignatureds_1_assinaturaid, AV47AssinaturaParticipanteId, lV70Wcuserssignatureds_2_tfparticipantenome, AV71Wcuserssignatureds_3_tfparticipantenome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8S2 = false;
            A233ParticipanteId = P008S2_A233ParticipanteId[0];
            n233ParticipanteId = P008S2_n233ParticipanteId[0];
            A238AssinaturaId = P008S2_A238AssinaturaId[0];
            n238AssinaturaId = P008S2_n238AssinaturaId[0];
            A248ParticipanteNome = P008S2_A248ParticipanteNome[0];
            n248ParticipanteNome = P008S2_n248ParticipanteNome[0];
            A242AssinaturaParticipanteId = P008S2_A242AssinaturaParticipanteId[0];
            A248ParticipanteNome = P008S2_A248ParticipanteNome[0];
            n248ParticipanteNome = P008S2_n248ParticipanteNome[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P008S2_A238AssinaturaId[0] == A238AssinaturaId ) && ( StringUtil.StrCmp(P008S2_A248ParticipanteNome[0], A248ParticipanteNome) == 0 ) )
            {
               BRK8S2 = false;
               A233ParticipanteId = P008S2_A233ParticipanteId[0];
               n233ParticipanteId = P008S2_n233ParticipanteId[0];
               A242AssinaturaParticipanteId = P008S2_A242AssinaturaParticipanteId[0];
               AV34count = (long)(AV34count+1);
               BRK8S2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV25SkipItems) )
            {
               AV29Option = (String.IsNullOrEmpty(StringUtil.RTrim( A248ParticipanteNome)) ? "<#Empty#>" : A248ParticipanteNome);
               AV30Options.Add(AV29Option, 0);
               AV33OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV30Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV25SkipItems = (short)(AV25SkipItems-1);
            }
            if ( ! BRK8S2 )
            {
               BRK8S2 = true;
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
         AV43OptionsJson = "";
         AV44OptionsDescJson = "";
         AV45OptionIndexesJson = "";
         AV30Options = new GxSimpleCollection<string>();
         AV32OptionsDesc = new GxSimpleCollection<string>();
         AV33OptionIndexes = new GxSimpleCollection<string>();
         AV24SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV35Session = context.GetSession();
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV48TFParticipanteNome = "";
         AV49TFParticipanteNome_Sel = "";
         AV70Wcuserssignatureds_2_tfparticipantenome = "";
         AV71Wcuserssignatureds_3_tfparticipantenome_sel = "";
         lV70Wcuserssignatureds_2_tfparticipantenome = "";
         A248ParticipanteNome = "";
         P008S2_A233ParticipanteId = new int[1] ;
         P008S2_n233ParticipanteId = new bool[] {false} ;
         P008S2_A238AssinaturaId = new long[1] ;
         P008S2_n238AssinaturaId = new bool[] {false} ;
         P008S2_A248ParticipanteNome = new string[] {""} ;
         P008S2_n248ParticipanteNome = new bool[] {false} ;
         P008S2_A242AssinaturaParticipanteId = new int[1] ;
         AV29Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcuserssignaturegetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P008S2_A233ParticipanteId, P008S2_n233ParticipanteId, P008S2_A238AssinaturaId, P008S2_n238AssinaturaId, P008S2_A248ParticipanteNome, P008S2_n248ParticipanteNome, P008S2_A242AssinaturaParticipanteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV27MaxItems ;
      private short AV26PageIndex ;
      private short AV25SkipItems ;
      private int AV67GXV1 ;
      private int AV47AssinaturaParticipanteId ;
      private int A242AssinaturaParticipanteId ;
      private int A233ParticipanteId ;
      private long AV46AssinaturaId ;
      private long AV69Wcuserssignatureds_1_assinaturaid ;
      private long A238AssinaturaId ;
      private long AV34count ;
      private bool returnInSub ;
      private bool BRK8S2 ;
      private bool n233ParticipanteId ;
      private bool n238AssinaturaId ;
      private bool n248ParticipanteNome ;
      private string AV43OptionsJson ;
      private string AV44OptionsDescJson ;
      private string AV45OptionIndexesJson ;
      private string AV40DDOName ;
      private string AV41SearchTxtParms ;
      private string AV42SearchTxtTo ;
      private string AV24SearchTxt ;
      private string AV48TFParticipanteNome ;
      private string AV49TFParticipanteNome_Sel ;
      private string AV70Wcuserssignatureds_2_tfparticipantenome ;
      private string AV71Wcuserssignatureds_3_tfparticipantenome_sel ;
      private string lV70Wcuserssignatureds_2_tfparticipantenome ;
      private string A248ParticipanteNome ;
      private string AV29Option ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV30Options ;
      private GxSimpleCollection<string> AV32OptionsDesc ;
      private GxSimpleCollection<string> AV33OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private int[] P008S2_A233ParticipanteId ;
      private bool[] P008S2_n233ParticipanteId ;
      private long[] P008S2_A238AssinaturaId ;
      private bool[] P008S2_n238AssinaturaId ;
      private string[] P008S2_A248ParticipanteNome ;
      private bool[] P008S2_n248ParticipanteNome ;
      private int[] P008S2_A242AssinaturaParticipanteId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wcuserssignaturegetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008S2( IGxContext context ,
                                             string AV71Wcuserssignatureds_3_tfparticipantenome_sel ,
                                             string AV70Wcuserssignatureds_2_tfparticipantenome ,
                                             string A248ParticipanteNome ,
                                             int A242AssinaturaParticipanteId ,
                                             int AV47AssinaturaParticipanteId ,
                                             long AV69Wcuserssignatureds_1_assinaturaid ,
                                             long A238AssinaturaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ParticipanteId, T1.AssinaturaId, T2.ParticipanteNome, T1.AssinaturaParticipanteId FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV69Wcuserssignatureds_1_assinaturaid)");
         AddWhere(sWhereString, "(T1.AssinaturaParticipanteId <> :AV47AssinaturaParticipanteId)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Wcuserssignatureds_3_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wcuserssignatureds_2_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV70Wcuserssignatureds_2_tfparticipantenome)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Wcuserssignatureds_3_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV71Wcuserssignatureds_3_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV71Wcuserssignatureds_3_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV71Wcuserssignatureds_3_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AssinaturaId, T2.ParticipanteNome";
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
                     return conditional_P008S2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] );
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
          Object[] prmP008S2;
          prmP008S2 = new Object[] {
          new ParDef("AV69Wcuserssignatureds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("AV47AssinaturaParticipanteId",GXType.Int32,9,0) ,
          new ParDef("lV70Wcuserssignatureds_2_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV71Wcuserssignatureds_3_tfparticipantenome_sel",GXType.VarChar,150,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008S2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
