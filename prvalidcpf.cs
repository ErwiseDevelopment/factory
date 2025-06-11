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
   public class prvalidcpf : GXProcedure
   {
      public prvalidcpf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prvalidcpf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_Tipo ,
                           string aP1_Chave ,
                           out bool aP2_isOk ,
                           out string aP3_ErroMsg )
      {
         this.AV21Tipo = aP0_Tipo;
         this.AV34Chave = aP1_Chave;
         this.AV33isOk = false ;
         this.AV32ErroMsg = "" ;
         initialize();
         ExecuteImpl();
         aP2_isOk=this.AV33isOk;
         aP3_ErroMsg=this.AV32ErroMsg;
      }

      public string executeUdp( string aP0_Tipo ,
                                string aP1_Chave ,
                                out bool aP2_isOk )
      {
         execute(aP0_Tipo, aP1_Chave, out aP2_isOk, out aP3_ErroMsg);
         return AV32ErroMsg ;
      }

      public void executeSubmit( string aP0_Tipo ,
                                 string aP1_Chave ,
                                 out bool aP2_isOk ,
                                 out string aP3_ErroMsg )
      {
         this.AV21Tipo = aP0_Tipo;
         this.AV34Chave = aP1_Chave;
         this.AV33isOk = false ;
         this.AV32ErroMsg = "" ;
         SubmitImpl();
         aP2_isOk=this.AV33isOk;
         aP3_ErroMsg=this.AV32ErroMsg;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV22MaximoDefault = (short)(((StringUtil.StrCmp(AV21Tipo, "FISICA")==0) ? 8 : 11));
         AV23VerificaJuridica = ((StringUtil.StrCmp(AV21Tipo, "JURIDICA")==0) ? true : false);
         AV33isOk = false;
         AV24CNPJCPF = StringUtil.Trim( StringUtil.StringReplace( StringUtil.StringReplace( StringUtil.StringReplace( AV34Chave, "/", ""), "-", ""), ".", ""));
         AV25Numeros = "0123456789";
         AV26Maximo = 1;
         while ( AV26Maximo <= 10 )
         {
            AV27AuxCPFCNPJ = StringUtil.PadL( AV27AuxCPFCNPJ, (short)(StringUtil.Len( AV24CNPJCPF)), StringUtil.Substring( AV25Numeros, AV26Maximo, 1));
            if ( StringUtil.StrCmp(AV24CNPJCPF, AV27AuxCPFCNPJ) == 0 )
            {
               AV32ErroMsg = ((StringUtil.StrCmp(AV21Tipo, "FISICA")==0) ? "CPF" : "CNPJ") + " inválido!<br /> Verifique!";
               cleanup();
               if (true) return;
            }
            AV26Maximo = (short)(AV26Maximo+1);
         }
         AV38Digitocont = 1;
         while ( AV38Digitocont <= 2 )
         {
            AV29Soma = 0;
            AV30Digito = 0;
            AV31Sobra = 0;
            AV32ErroMsg = "";
            AV22MaximoDefault = (short)(AV22MaximoDefault+1);
            AV26Maximo = (short)(((StringUtil.StrCmp(AV21Tipo, "FISICA")==0) ? AV22MaximoDefault : ((AV38Digitocont==1) ? 4 : 5)));
            AV36Count = 1;
            while ( AV36Count <= AV22MaximoDefault )
            {
               AV29Soma = (decimal)(AV29Soma+((NumberUtil.Val( StringUtil.Substring( AV24CNPJCPF, AV36Count, 1), ".")*((AV26Maximo+1)))));
               AV26Maximo = (short)(AV26Maximo-1);
               if ( AV26Maximo < 1 )
               {
                  if ( StringUtil.StrCmp(AV21Tipo, "FISICA") == 0 )
                  {
                     AV26Maximo = AV22MaximoDefault;
                  }
                  else
                  {
                     AV26Maximo = 8;
                  }
               }
               AV36Count = (short)(AV36Count+1);
            }
            AV31Sobra = (decimal)(((int)((AV29Soma) % (11))));
            AV30Digito = (short)(((AV31Sobra<Convert.ToDecimal(2)) ? 0 : 11-AV31Sobra));
            AV32ErroMsg = ((Convert.ToDecimal(AV30Digito)==NumberUtil.Val( StringUtil.Substring( AV24CNPJCPF, AV36Count, 1), ".")) ? "" : ((StringUtil.StrCmp(AV21Tipo, "FISICA")==0) ? "CPF" : "CNPJ")+"<br /> inválido! Verifique!");
            AV35Valido = ((Convert.ToDecimal(AV30Digito)==NumberUtil.Val( StringUtil.Substring( AV24CNPJCPF, AV36Count, 1), ".")) ? true : false);
            AV33isOk = AV35Valido;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32ErroMsg)) )
            {
               cleanup();
               if (true) return;
            }
            AV38Digitocont = (short)(AV38Digitocont+1);
         }
         AV33isOk = AV35Valido;
         AV32ErroMsg = ((StringUtil.StrCmp(AV21Tipo, "FISICA")==0) ? "CPF" : "CNPJ") + " válido!";
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
         AV32ErroMsg = "";
         AV24CNPJCPF = "";
         AV25Numeros = "";
         AV27AuxCPFCNPJ = "";
         /* GeneXus formulas. */
      }

      private short AV22MaximoDefault ;
      private short AV26Maximo ;
      private short AV38Digitocont ;
      private short AV30Digito ;
      private short AV36Count ;
      private decimal AV29Soma ;
      private decimal AV31Sobra ;
      private bool AV33isOk ;
      private bool AV23VerificaJuridica ;
      private bool AV35Valido ;
      private string AV21Tipo ;
      private string AV34Chave ;
      private string AV32ErroMsg ;
      private string AV24CNPJCPF ;
      private string AV25Numeros ;
      private string AV27AuxCPFCNPJ ;
      private bool aP2_isOk ;
      private string aP3_ErroMsg ;
   }

}
