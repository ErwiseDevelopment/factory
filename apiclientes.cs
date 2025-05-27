using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class apiclientes : GXProcedure
   {
      public apiclientes( )
      {
         context = new GxContext(  );
         IsMain = true;
         IsApiObject = true;
      }

      public apiclientes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         if ( context.HttpContext != null )
         {
            Gx_restmethod = (string)(context.HttpContext.Request.Method);
         }
      }

      public void execute( )
      {
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      protected void E11012( )
      {
         /* Customers_After Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV7retorno.gxTpr_Message, "") != 0 )
         {
            Gx_restcode = 400;
         }
      }

      public void gxep_customers__post( SdtSdClientePFPJ aP0_SdClientePFPJ ,
                                        out SdtSdClientePFPJRetorno aP1_retorno )
      {
         this.AV5SdClientePFPJ = aP0_SdClientePFPJ;
         AV7retorno = new SdtSdClientePFPJRetorno(context);
         initialize();
         /* customers__post Constructor */
         new prpostcliente(context ).execute(  AV5SdClientePFPJ, out  AV7retorno) ;
         /* Execute user event: Customers.After */
         E11012 ();
         if ( returnInSub )
         {
            aP1_retorno=this.AV7retorno;
            return;
         }
         aP1_retorno=this.AV7retorno;
      }

      public void gxep_customers__put( int aP0_id ,
                                       SdtSdClientePFPJ aP1_SdClientePFPJ ,
                                       out SdtSdClientePFPJ aP2_RetSdClientePFPJ )
      {
         this.AV6id = aP0_id;
         this.AV5SdClientePFPJ = aP1_SdClientePFPJ;
         initialize();
         /* customers__put Constructor */
         new prputcliente(context ).execute(  AV6id,  AV5SdClientePFPJ, out  AV8RetSdClientePFPJ) ;
         /* Execute user event: Customers.After */
         E11012 ();
         if ( returnInSub )
         {
            aP2_RetSdClientePFPJ=this.AV8RetSdClientePFPJ;
            return;
         }
         aP2_RetSdClientePFPJ=this.AV8RetSdClientePFPJ;
      }

      public short getrestcode( )
      {
         return Gx_restcode ;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV7retorno = new SdtSdClientePFPJRetorno(context);
         AV8RetSdClientePFPJ = new SdtSdClientePFPJ(context);
         /* GeneXus formulas. */
      }

      protected short Gx_restcode ;
      protected int AV6id ;
      protected string Gx_restmethod ;
      protected bool returnInSub ;
      protected SdtSdClientePFPJRetorno AV7retorno ;
      protected SdtSdClientePFPJ AV5SdClientePFPJ ;
      protected SdtSdClientePFPJRetorno aP1_retorno ;
      protected SdtSdClientePFPJ AV8RetSdClientePFPJ ;
      protected SdtSdClientePFPJ aP2_RetSdClientePFPJ ;
   }

}
