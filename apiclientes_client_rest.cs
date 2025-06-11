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
         initialize();
      }

      public apiclientes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         initialize();
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

      public void InitLocation( )
      {
         restLocation = new GxLocation();
         restLocation.Host = "localhost";
         restLocation.Port = 8082;
         restLocation.BaseUrl = "Factory21NETPostgreSQL/api";
         gxProperties = new GxObjectProperties();
      }

      public GxObjectProperties ObjProperties
      {
         get {
            return gxProperties ;
         }

         set {
            gxProperties = value ;
         }

      }

      public void SetObjectProperties( GxObjectProperties gxobjppt )
      {
         gxProperties = gxobjppt ;
         restLocation = gxobjppt.Location ;
      }

      public void gxep_customers__post( SdtSdClientePFPJ aP0_SdClientePFPJ ,
                                        out SdtSdClientePFPJRetorno aP1_retorno )
      {
         restClicustomers__post = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "customers";
         restClicustomers__post.Location = restLocation;
         restClicustomers__post.HttpMethod = "POST";
         restClicustomers__post.AddBodyVar("SdClientePFPJ", aP0_SdClientePFPJ);
         restClicustomers__post.RestExecute();
         if ( restClicustomers__post.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restClicustomers__post.ErrorCode;
            gxProperties.ErrorMessage = restClicustomers__post.ErrorMessage;
            gxProperties.StatusCode = restClicustomers__post.StatusCode;
            aP1_retorno = new SdtSdClientePFPJRetorno();
         }
         else
         {
            aP1_retorno = restClicustomers__post.GetBodySdt<SdtSdClientePFPJRetorno>("retorno");
         }
         /* customers__post Constructor */
      }

      public void gxep_customers__put( int aP0_id ,
                                       SdtSdClientePFPJ aP1_SdClientePFPJ ,
                                       out SdtSdClientePFPJ aP2_RetSdClientePFPJ )
      {
         restClicustomers__put = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "customers";
         restClicustomers__put.Location = restLocation;
         restClicustomers__put.HttpMethod = "PUT";
         restClicustomers__put.AddBodyVar("id", (int)(aP0_id));
         restClicustomers__put.AddBodyVar("SdClientePFPJ", aP1_SdClientePFPJ);
         restClicustomers__put.RestExecute();
         if ( restClicustomers__put.ErrorCode != 0 )
         {
            gxProperties.ErrorCode = restClicustomers__put.ErrorCode;
            gxProperties.ErrorMessage = restClicustomers__put.ErrorMessage;
            gxProperties.StatusCode = restClicustomers__put.StatusCode;
            aP2_RetSdClientePFPJ = new SdtSdClientePFPJ();
         }
         else
         {
            aP2_RetSdClientePFPJ = restClicustomers__put.GetBodySdt<SdtSdClientePFPJ>("RetSdClientePFPJ");
         }
         /* customers__put Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         gxProperties = new GxObjectProperties();
         restClicustomers__post = new GXRestAPIClient();
         aP1_retorno = new SdtSdClientePFPJRetorno();
         restClicustomers__put = new GXRestAPIClient();
         aP2_RetSdClientePFPJ = new SdtSdClientePFPJ();
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restClicustomers__post ;
      protected GXRestAPIClient restClicustomers__put ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected SdtSdClientePFPJRetorno aP1_retorno ;
      protected SdtSdClientePFPJ aP2_RetSdClientePFPJ ;
   }

}
