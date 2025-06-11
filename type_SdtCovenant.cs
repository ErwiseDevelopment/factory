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
   public class SdtCovenant : GxUserType, IGxExternalObject
   {
      public SdtCovenant( )
      {
         /* Constructor for serialization */
      }

      public SdtCovenant( IGxContext context )
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

      public int gxTpr_Code
      {
         get {
            if ( Covenant_externalReference == null )
            {
               Covenant_externalReference = new APISantanderDll.Models.Common.Covenant();
            }
            return Covenant_externalReference.Code ;
         }

         set {
            if ( Covenant_externalReference == null )
            {
               Covenant_externalReference = new APISantanderDll.Models.Common.Covenant();
            }
            Covenant_externalReference.Code = value;
            SetDirty("Code");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( Covenant_externalReference == null )
            {
               Covenant_externalReference = new APISantanderDll.Models.Common.Covenant();
            }
            return Covenant_externalReference ;
         }

         set {
            Covenant_externalReference = (APISantanderDll.Models.Common.Covenant)(value);
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

      protected APISantanderDll.Models.Common.Covenant Covenant_externalReference=null ;
   }

}
