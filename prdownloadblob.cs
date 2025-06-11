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
   public class prdownloadblob : GXProcedure
   {
      public prdownloadblob( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prdownloadblob( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Blob ,
                           string aP1_Name ,
                           string aP2_Extesion ,
                           out string aP3_Arquivo )
      {
         this.AV8Blob = aP0_Blob;
         this.AV9Name = aP1_Name;
         this.AV10Extesion = aP2_Extesion;
         this.AV12Arquivo = "" ;
         initialize();
         ExecuteImpl();
         aP3_Arquivo=this.AV12Arquivo;
      }

      public string executeUdp( string aP0_Blob ,
                                string aP1_Name ,
                                string aP2_Extesion )
      {
         execute(aP0_Blob, aP1_Name, aP2_Extesion, out aP3_Arquivo);
         return AV12Arquivo ;
      }

      public void executeSubmit( string aP0_Blob ,
                                 string aP1_Name ,
                                 string aP2_Extesion ,
                                 out string aP3_Arquivo )
      {
         this.AV8Blob = aP0_Blob;
         this.AV9Name = aP1_Name;
         this.AV10Extesion = aP2_Extesion;
         this.AV12Arquivo = "" ;
         SubmitImpl();
         aP3_Arquivo=this.AV12Arquivo;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12Arquivo = "./PrivateTempStorage/" + StringUtil.Trim( AV9Name) + "." + StringUtil.Trim( AV10Extesion);
         AV11File.Source = AV12Arquivo;
         AV11File.FromBase64(context.FileToBase64( AV8Blob));
         AV11File.Create();
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
         AV12Arquivo = "";
         AV11File = new GxFile(context.GetPhysicalPath());
         /* GeneXus formulas. */
      }

      private string AV9Name ;
      private string AV10Extesion ;
      private string AV12Arquivo ;
      private string AV8Blob ;
      private GxFile AV11File ;
      private string aP3_Arquivo ;
   }

}
