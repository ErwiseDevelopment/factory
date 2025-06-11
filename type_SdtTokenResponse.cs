using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [Serializable]
   public class SdtTokenResponse : GxUserType, IGxExternalObject
   {
      public SdtTokenResponse( )
      {
         /* Constructor for serialization */
      }

      public SdtTokenResponse( IGxContext context )
      {
         this.context = context;
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public string gxTpr_Accesstoken
      {
         get {
            if ( TokenResponse_externalReference == null )
            {
               TokenResponse_externalReference = new APISantanderDll.Models.Responses.TokenResponse();
            }
            return TokenResponse_externalReference.AccessToken ;
         }

         set {
            if ( TokenResponse_externalReference == null )
            {
               TokenResponse_externalReference = new APISantanderDll.Models.Responses.TokenResponse();
            }
            TokenResponse_externalReference.AccessToken = value;
            SetDirty("Accesstoken");
         }

      }

      public string gxTpr_Tokentype
      {
         get {
            if ( TokenResponse_externalReference == null )
            {
               TokenResponse_externalReference = new APISantanderDll.Models.Responses.TokenResponse();
            }
            return TokenResponse_externalReference.TokenType ;
         }

         set {
            if ( TokenResponse_externalReference == null )
            {
               TokenResponse_externalReference = new APISantanderDll.Models.Responses.TokenResponse();
            }
            TokenResponse_externalReference.TokenType = value;
            SetDirty("Tokentype");
         }

      }

      public int gxTpr_Expiresin
      {
         get {
            if ( TokenResponse_externalReference == null )
            {
               TokenResponse_externalReference = new APISantanderDll.Models.Responses.TokenResponse();
            }
            return TokenResponse_externalReference.ExpiresIn ;
         }

         set {
            if ( TokenResponse_externalReference == null )
            {
               TokenResponse_externalReference = new APISantanderDll.Models.Responses.TokenResponse();
            }
            TokenResponse_externalReference.ExpiresIn = value;
            SetDirty("Expiresin");
         }

      }

      public string gxTpr_Scope
      {
         get {
            if ( TokenResponse_externalReference == null )
            {
               TokenResponse_externalReference = new APISantanderDll.Models.Responses.TokenResponse();
            }
            return TokenResponse_externalReference.Scope ;
         }

         set {
            if ( TokenResponse_externalReference == null )
            {
               TokenResponse_externalReference = new APISantanderDll.Models.Responses.TokenResponse();
            }
            TokenResponse_externalReference.Scope = value;
            SetDirty("Scope");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( TokenResponse_externalReference == null )
            {
               TokenResponse_externalReference = new APISantanderDll.Models.Responses.TokenResponse();
            }
            return TokenResponse_externalReference ;
         }

         set {
            TokenResponse_externalReference = (APISantanderDll.Models.Responses.TokenResponse)(value);
         }

      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         return  ;
      }

      protected APISantanderDll.Models.Responses.TokenResponse TokenResponse_externalReference=null ;
   }

}
