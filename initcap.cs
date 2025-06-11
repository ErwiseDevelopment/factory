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
namespace GeneXus.Programs {
   public class initcap : GXProcedure
   {
      public initcap( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public initcap( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Text ,
                           out string aP1_Result )
      {
         this.AV9Text = aP0_Text;
         this.AV10Result = "" ;
         initialize();
         ExecuteImpl();
         aP1_Result=this.AV10Result;
      }

      public string executeUdp( string aP0_Text )
      {
         execute(aP0_Text, out aP1_Result);
         return AV10Result ;
      }

      public void executeSubmit( string aP0_Text ,
                                 out string aP1_Result )
      {
         this.AV9Text = aP0_Text;
         this.AV10Result = "" ;
         SubmitImpl();
         aP1_Result=this.AV10Result;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Words = (GxSimpleCollection<string>)(GxRegex.Split(AV9Text," "));
         AV10Result = "";
         AV12GXV1 = 1;
         while ( AV12GXV1 <= AV8Words.Count )
         {
            AV11Word = ((string)AV8Words.Item(AV12GXV1));
            if ( StringUtil.Len( AV11Word) > 0 )
            {
               AV11Word = StringUtil.Lower( AV11Word);
               AV11Word = StringUtil.Upper( StringUtil.Substring( AV11Word, 1, 1)) + StringUtil.Substring( AV11Word, 2, StringUtil.Len( AV11Word)-1);
            }
            AV10Result += AV11Word + " ";
            AV12GXV1 = (int)(AV12GXV1+1);
         }
         AV10Result = StringUtil.Trim( AV10Result);
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
         AV10Result = "";
         AV8Words = new GxSimpleCollection<string>();
         AV11Word = "";
         /* GeneXus formulas. */
      }

      private int AV12GXV1 ;
      private string AV9Text ;
      private string AV10Result ;
      private string AV11Word ;
      private GxSimpleCollection<string> AV8Words ;
      private string aP1_Result ;
   }

}
