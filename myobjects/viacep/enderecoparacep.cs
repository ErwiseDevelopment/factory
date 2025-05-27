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
namespace GeneXus.Programs.myobjects.viacep {
   public class enderecoparacep : GXProcedure
   {
      public enderecoparacep( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public enderecoparacep( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UF ,
                           string aP1_inLocalidade ,
                           string aP2_inLogradouro ,
                           out string aP3_ModeloRetorno ,
                           out string aP4_Mensagem )
      {
         this.AV2UF = aP0_UF;
         this.AV3inLocalidade = aP1_inLocalidade;
         this.AV4inLogradouro = aP2_inLogradouro;
         this.AV5ModeloRetorno = "" ;
         this.AV6Mensagem = "" ;
         initialize();
         ExecuteImpl();
         aP3_ModeloRetorno=this.AV5ModeloRetorno;
         aP4_Mensagem=this.AV6Mensagem;
      }

      public string executeUdp( string aP0_UF ,
                                string aP1_inLocalidade ,
                                string aP2_inLogradouro ,
                                out string aP3_ModeloRetorno )
      {
         execute(aP0_UF, aP1_inLocalidade, aP2_inLogradouro, out aP3_ModeloRetorno, out aP4_Mensagem);
         return AV6Mensagem ;
      }

      public void executeSubmit( string aP0_UF ,
                                 string aP1_inLocalidade ,
                                 string aP2_inLogradouro ,
                                 out string aP3_ModeloRetorno ,
                                 out string aP4_Mensagem )
      {
         this.AV2UF = aP0_UF;
         this.AV3inLocalidade = aP1_inLocalidade;
         this.AV4inLogradouro = aP2_inLogradouro;
         this.AV5ModeloRetorno = "" ;
         this.AV6Mensagem = "" ;
         SubmitImpl();
         aP3_ModeloRetorno=this.AV5ModeloRetorno;
         aP4_Mensagem=this.AV6Mensagem;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         args = new Object[] {(string)AV2UF,(string)AV3inLocalidade,(string)AV4inLogradouro,(string)AV5ModeloRetorno,(string)AV6Mensagem} ;
         ClassLoader.Execute("myobjects.viacep.aenderecoparacep","GeneXus.Programs","myobjects.viacep.aenderecoparacep", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 5 ) )
         {
            AV5ModeloRetorno = (string)(args[3]) ;
            AV6Mensagem = (string)(args[4]) ;
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
      }

      public override void initialize( )
      {
         AV5ModeloRetorno = "";
         AV6Mensagem = "";
         /* GeneXus formulas. */
      }

      private string AV2UF ;
      private string AV5ModeloRetorno ;
      private string AV3inLocalidade ;
      private string AV4inLogradouro ;
      private string AV6Mensagem ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private string aP3_ModeloRetorno ;
      private string aP4_Mensagem ;
   }

}
