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
   public class prcadastrarrepresentante : GXProcedure
   {
      public prcadastrarrepresentante( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prcadastrarrepresentante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           SdtSdCadastroRepresentante aP1_SdCadastroRepresentante ,
                           out SdtSdErro aP2_SdErro )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8SdCadastroRepresentante = aP1_SdCadastroRepresentante;
         this.AV9SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP2_SdErro=this.AV9SdErro;
      }

      public SdtSdErro executeUdp( string aP0_Gx_mode ,
                                   SdtSdCadastroRepresentante aP1_SdCadastroRepresentante )
      {
         execute(aP0_Gx_mode, aP1_SdCadastroRepresentante, out aP2_SdErro);
         return AV9SdErro ;
      }

      public void executeSubmit( string aP0_Gx_mode ,
                                 SdtSdCadastroRepresentante aP1_SdCadastroRepresentante ,
                                 out SdtSdErro aP2_SdErro )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8SdCadastroRepresentante = aP1_SdCadastroRepresentante;
         this.AV9SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP2_SdErro=this.AV9SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9SdErro = new SdtSdErro(context);
         /* Execute user subroutine: 'VERIFICARDADOSVALIDOS' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( AV13IsValid )
         {
            GXt_char1 = AV12CNPJDigitos;
            new prretornadigitos(context ).execute(  StringUtil.Trim( AV8SdCadastroRepresentante.gxTpr_Empresacnpj), out  GXt_char1) ;
            AV12CNPJDigitos = GXt_char1;
            GXt_SdtSdEmpresas2 = AV11SdEmpresas;
            new prgetempresaapi(context ).execute(  AV12CNPJDigitos, out  GXt_SdtSdEmpresas2) ;
            AV11SdEmpresas = GXt_SdtSdEmpresas2;
            if ( AV10Cliente.Fail() )
            {
               AV10Cliente = new SdtCliente(context);
            }
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               AV10Cliente = new SdtCliente(context);
            }
            else
            {
               AV10Cliente.Load(AV8SdCadastroRepresentante.gxTpr_Id);
            }
            AV10Cliente.gxTpr_Clientedocumento = StringUtil.Trim( AV11SdEmpresas.gxTpr_Taxid);
            AV10Cliente.gxTpr_Clienterazaosocial = StringUtil.Trim( AV11SdEmpresas.gxTpr_Company.gxTpr_Name);
            AV10Cliente.gxTpr_Clientenomefantasia = StringUtil.Trim( AV11SdEmpresas.gxTpr_Company.gxTpr_Name);
            AV10Cliente.gxTpr_Clientetipopessoa = "JURIDICA";
            AV10Cliente.gxTpr_Tipoclienteid = 4;
            AV10Cliente.gxTpr_Clientestatus = true;
            AV10Cliente.gxTpr_Clientesituacao = "P";
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               AV10Cliente.gxTpr_Clientecreatedat = DateTimeUtil.ServerNow( context, pr_default);
            }
            AV10Cliente.gxTpr_Clienteupdatedat = DateTimeUtil.ServerNow( context, pr_default);
            AV10Cliente.gxTpr_Enderecocep = StringUtil.Trim( AV11SdEmpresas.gxTpr_Address.gxTpr_Zip);
            AV10Cliente.gxTpr_Enderecologradouro = StringUtil.Trim( AV11SdEmpresas.gxTpr_Address.gxTpr_Street);
            AV10Cliente.gxTpr_Enderecobairro = StringUtil.Trim( AV11SdEmpresas.gxTpr_Address.gxTpr_District);
            AV10Cliente.gxTpr_Enderecocidade = StringUtil.Trim( AV11SdEmpresas.gxTpr_Address.gxTpr_City);
            AV10Cliente.gxTpr_Endereconumero = StringUtil.Trim( AV11SdEmpresas.gxTpr_Address.gxTpr_Number);
            AV10Cliente.gxTpr_Enderecocomplemento = AV11SdEmpresas.gxTpr_Address.gxTpr_Details;
            AV10Cliente.gxTpr_Responsavelnome = AV8SdCadastroRepresentante.gxTpr_Nome;
            AV10Cliente.gxTpr_Responsavelcpf = AV8SdCadastroRepresentante.gxTpr_Cpf;
            GXt_char1 = AV18DDD;
            new prretornadigitos(context ).execute(  StringUtil.Trim( AV8SdCadastroRepresentante.gxTpr_Celular), out  GXt_char1) ;
            AV18DDD = StringUtil.Substring( GXt_char1, 1, 2);
            GXt_char1 = AV17Phone;
            new prretornadigitos(context ).execute(  AV8SdCadastroRepresentante.gxTpr_Celular, out  GXt_char1) ;
            AV17Phone = StringUtil.Substring( GXt_char1, 3, (int)(Math.Round(NumberUtil.Val( StringUtil.Trim( AV8SdCadastroRepresentante.gxTpr_Celular), ".")-1, 18, MidpointRounding.ToEven)));
            AV10Cliente.gxTpr_Responsavelddd = (short)(Math.Round(NumberUtil.Val( AV18DDD, "."), 18, MidpointRounding.ToEven));
            AV10Cliente.gxTpr_Responsavelnumero = (int)(Math.Round(NumberUtil.Val( AV17Phone, "."), 18, MidpointRounding.ToEven));
            AV10Cliente.gxTpr_Responsavelemail = StringUtil.Trim( AV8SdCadastroRepresentante.gxTpr_Email);
            AV10Cliente.gxTpr_Responsavelcargo = AV8SdCadastroRepresentante.gxTpr_Cargo;
            AV10Cliente.Save();
            if ( ! AV10Cliente.Success() )
            {
               AV14ErrorMessage = "";
               AV21GXV2 = 1;
               AV20GXV1 = AV10Cliente.GetMessages();
               while ( AV21GXV2 <= AV20GXV1.Count )
               {
                  AV16Message = ((GeneXus.Utils.SdtMessages_Message)AV20GXV1.Item(AV21GXV2));
                  AV14ErrorMessage += StringUtil.Trim( AV16Message.gxTpr_Description) + StringUtil.NewLine( );
                  AV21GXV2 = (int)(AV21GXV2+1);
               }
               /* Execute user subroutine: 'RETORNACOMERRO' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            AV9SdErro.gxTpr_Msg = ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? "Representante cadastrado com sucesso!" : "Representante atualizado com sucesso!");
            AV9SdErro.gxTpr_Status = (short)(((StringUtil.StrCmp(Gx_mode, "INS")==0) ? 201 : 200));
            context.CommitDataStores("prcadastrarrepresentante",pr_default);
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'VERIFICARDADOSVALIDOS' Routine */
         returnInSub = false;
         AV13IsValid = true;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && new prexisterepresentantecadastrado(context).executeUdp(  AV11SdEmpresas.gxTpr_Taxid) )
         {
            AV13IsValid = false;
            AV14ErrorMessage = "Já existe uma empresa cadastrada com mesmo CNPJ. Verifique!";
            /* Execute user subroutine: 'RETORNACOMERRO' */
            S121 ();
            if (returnInSub) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8SdCadastroRepresentante.gxTpr_Nome)) )
         {
            AV13IsValid = false;
            AV14ErrorMessage = "Nome do Representante é obrigatório.";
            /* Execute user subroutine: 'RETORNACOMERRO' */
            S121 ();
            if (returnInSub) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8SdCadastroRepresentante.gxTpr_Email)) )
         {
            AV13IsValid = false;
            AV14ErrorMessage = "E-mail do Representante é obrigatório.";
            /* Execute user subroutine: 'RETORNACOMERRO' */
            S121 ();
            if (returnInSub) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8SdCadastroRepresentante.gxTpr_Celular)) )
         {
            AV13IsValid = false;
            AV14ErrorMessage = "Celular do Representante é obrigatório.";
            /* Execute user subroutine: 'RETORNACOMERRO' */
            S121 ();
            if (returnInSub) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8SdCadastroRepresentante.gxTpr_Cpf)) )
         {
            AV13IsValid = false;
            AV14ErrorMessage = "CPF do Representante é obrigatório.";
            /* Execute user subroutine: 'RETORNACOMERRO' */
            S121 ();
            if (returnInSub) return;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8SdCadastroRepresentante.gxTpr_Cargo)) )
         {
            AV13IsValid = false;
            AV14ErrorMessage = "Cargo do Representante é obrigatório.";
            /* Execute user subroutine: 'RETORNACOMERRO' */
            S121 ();
            if (returnInSub) return;
         }
         if ( ! new prvalidaemail(context).executeUdp(  AV8SdCadastroRepresentante.gxTpr_Email) )
         {
            AV13IsValid = false;
            AV14ErrorMessage = "Email inválido. Verifique!";
            /* Execute user subroutine: 'RETORNACOMERRO' */
            S121 ();
            if (returnInSub) return;
         }
         new prvalidcpf(context ).execute(  "FISICA",  new prretornadigitos(context).executeUdp(  AV8SdCadastroRepresentante.gxTpr_Cpf), out  AV15IsCPFValid, out  AV14ErrorMessage) ;
         if ( ! AV15IsCPFValid )
         {
            AV13IsValid = false;
            AV14ErrorMessage = "CPF inválido. Verifique!";
            /* Execute user subroutine: 'RETORNACOMERRO' */
            S121 ();
            if (returnInSub) return;
         }
         if ( StringUtil.Len( new prretornadigitos(context).executeUdp(  AV8SdCadastroRepresentante.gxTpr_Celular)) < 10 )
         {
            AV13IsValid = false;
            AV14ErrorMessage = "Telefone inválido. Digite um celular no padrão (99)9999-9999 ou (99)99999-9999";
            /* Execute user subroutine: 'RETORNACOMERRO' */
            S121 ();
            if (returnInSub) return;
         }
      }

      protected void S121( )
      {
         /* 'RETORNACOMERRO' Routine */
         returnInSub = false;
         context.RollbackDataStores("prcadastrarrepresentante",pr_default);
         AV9SdErro.gxTpr_Status = 400;
         AV9SdErro.gxTpr_Msg = StringUtil.Trim( AV14ErrorMessage);
         returnInSub = true;
         if (true) return;
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
         AV9SdErro = new SdtSdErro(context);
         AV12CNPJDigitos = "";
         AV11SdEmpresas = new SdtSdEmpresas(context);
         GXt_SdtSdEmpresas2 = new SdtSdEmpresas(context);
         AV10Cliente = new SdtCliente(context);
         AV18DDD = "";
         AV17Phone = "";
         GXt_char1 = "";
         AV14ErrorMessage = "";
         AV20GXV1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV16Message = new GeneXus.Utils.SdtMessages_Message(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prcadastrarrepresentante__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private int AV21GXV2 ;
      private string Gx_mode ;
      private string AV17Phone ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV13IsValid ;
      private bool AV15IsCPFValid ;
      private string AV12CNPJDigitos ;
      private string AV18DDD ;
      private string AV14ErrorMessage ;
      private IGxDataStore dsDefault ;
      private SdtSdCadastroRepresentante AV8SdCadastroRepresentante ;
      private SdtSdErro AV9SdErro ;
      private SdtSdEmpresas AV11SdEmpresas ;
      private SdtSdEmpresas GXt_SdtSdEmpresas2 ;
      private SdtCliente AV10Cliente ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV20GXV1 ;
      private GeneXus.Utils.SdtMessages_Message AV16Message ;
      private SdtSdErro aP2_SdErro ;
   }

   public class prcadastrarrepresentante__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

}
