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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prnewassinatura : GXProcedure
   {
      public prnewassinatura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prnewassinatura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( int aP0_ContratoId ,
                           int aP1_ArquivoId ,
                           out long aP2_AssinaturaId ,
                           out SdtSdErro aP3_SdErro )
      {
         this.AV10ContratoId = aP0_ContratoId;
         this.AV14ArquivoId = aP1_ArquivoId;
         this.AV11AssinaturaId = 0 ;
         this.AV13SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP2_AssinaturaId=this.AV11AssinaturaId;
         aP3_SdErro=this.AV13SdErro;
      }

      public SdtSdErro executeUdp( int aP0_ContratoId ,
                                   int aP1_ArquivoId ,
                                   out long aP2_AssinaturaId )
      {
         execute(aP0_ContratoId, aP1_ArquivoId, out aP2_AssinaturaId, out aP3_SdErro);
         return AV13SdErro ;
      }

      public void executeSubmit( int aP0_ContratoId ,
                                 int aP1_ArquivoId ,
                                 out long aP2_AssinaturaId ,
                                 out SdtSdErro aP3_SdErro )
      {
         this.AV10ContratoId = aP0_ContratoId;
         this.AV14ArquivoId = aP1_ArquivoId;
         this.AV11AssinaturaId = 0 ;
         this.AV13SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP2_AssinaturaId=this.AV11AssinaturaId;
         aP3_SdErro=this.AV13SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13SdErro = new SdtSdErro(context);
         AV13SdErro.gxTpr_Status = 200;
         AV9Assinatura = new SdtAssinatura(context);
         AV8AssinaturaPublicKey = Guid.NewGuid( );
         AV9Assinatura.gxTpr_Assinaturastatus = "ENVIADO";
         AV9Assinatura.gxTpr_Contratoid = AV10ContratoId;
         AV9Assinatura.gxTpr_Assinaturapublickey = AV8AssinaturaPublicKey;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "consultacontratodigital"+GXUtil.UrlEncode(StringUtil.LTrimStr(AV9Assinatura.gxTpr_Assinaturaid,10,0));
         AV9Assinatura.gxTpr_Assinaturapaginaconsulta = AV15HTTPREQUEST.BaseURL+formatLink("consultacontratodigital") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         AV9Assinatura.gxTpr_Arquivoid = AV14ArquivoId;
         AV9Assinatura.Save();
         if ( AV9Assinatura.Fail() )
         {
            AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV9Assinatura.GetMessages().Item(1)).gxTpr_Description;
            AV13SdErro.gxTpr_Msg = AV12Message;
            AV13SdErro.gxTpr_Status = 401;
            AV13SdErro.gxTpr_Internalcode = 1;
            cleanup();
            if (true) return;
         }
         else
         {
            AV11AssinaturaId = AV9Assinatura.gxTpr_Assinaturaid;
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
         ExitApp();
      }

      public override void initialize( )
      {
         AV13SdErro = new SdtSdErro(context);
         AV9Assinatura = new SdtAssinatura(context);
         AV8AssinaturaPublicKey = Guid.Empty;
         AV15HTTPREQUEST = new GxHttpRequest( context);
         GXKey = "";
         GXEncryptionTmp = "";
         AV12Message = "";
         /* GeneXus formulas. */
      }

      private short gxcookieaux ;
      private int AV10ContratoId ;
      private int AV14ArquivoId ;
      private long AV11AssinaturaId ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV12Message ;
      private Guid AV8AssinaturaPublicKey ;
      private GxHttpRequest AV15HTTPREQUEST ;
      private SdtSdErro AV13SdErro ;
      private SdtAssinatura AV9Assinatura ;
      private long aP2_AssinaturaId ;
      private SdtSdErro aP3_SdErro ;
   }

}
