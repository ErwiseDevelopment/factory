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
   public class SdtRegistryDetails : GxUserType, IGxExternalObject
   {
      public SdtRegistryDetails( )
      {
         /* Constructor for serialization */
      }

      public SdtRegistryDetails( IGxContext context )
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

      public string gxTpr_Registrystatus
      {
         get {
            if ( RegistryDetails_externalReference == null )
            {
               RegistryDetails_externalReference = new APISantanderDll.Models.Responses.RegistryDetails();
            }
            return RegistryDetails_externalReference.RegistryStatus ;
         }

         set {
            if ( RegistryDetails_externalReference == null )
            {
               RegistryDetails_externalReference = new APISantanderDll.Models.Responses.RegistryDetails();
            }
            RegistryDetails_externalReference.RegistryStatus = value;
            SetDirty("Registrystatus");
         }

      }

      public DateTime gxTpr_Registrydate
      {
         get {
            if ( RegistryDetails_externalReference == null )
            {
               RegistryDetails_externalReference = new APISantanderDll.Models.Responses.RegistryDetails();
            }
            return RegistryDetails_externalReference.RegistryDate ;
         }

         set {
            if ( RegistryDetails_externalReference == null )
            {
               RegistryDetails_externalReference = new APISantanderDll.Models.Responses.RegistryDetails();
            }
            RegistryDetails_externalReference.RegistryDate = value;
            SetDirty("Registrydate");
         }

      }

      public string gxTpr_Registrycode
      {
         get {
            if ( RegistryDetails_externalReference == null )
            {
               RegistryDetails_externalReference = new APISantanderDll.Models.Responses.RegistryDetails();
            }
            return RegistryDetails_externalReference.RegistryCode ;
         }

         set {
            if ( RegistryDetails_externalReference == null )
            {
               RegistryDetails_externalReference = new APISantanderDll.Models.Responses.RegistryDetails();
            }
            RegistryDetails_externalReference.RegistryCode = value;
            SetDirty("Registrycode");
         }

      }

      public GxSimpleCollection<string> gxTpr_Registrymessages
      {
         get {
            if ( RegistryDetails_externalReference == null )
            {
               RegistryDetails_externalReference = new APISantanderDll.Models.Responses.RegistryDetails();
            }
            GxSimpleCollection<string> intValue;
            intValue = new GxSimpleCollection<string>();
            System.Collections.Generic.List< System.String> externalParm0;
            externalParm0 = RegistryDetails_externalReference.RegistryMessages;
            intValue.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< System.String>), externalParm0);
            return intValue ;
         }

         set {
            if ( RegistryDetails_externalReference == null )
            {
               RegistryDetails_externalReference = new APISantanderDll.Models.Responses.RegistryDetails();
            }
            GxSimpleCollection<string> intValue;
            System.Collections.Generic.List< System.String> externalParm1;
            intValue = value;
            externalParm1 = (System.Collections.Generic.List< System.String>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< System.String>), intValue.ExternalInstance);
            RegistryDetails_externalReference.RegistryMessages = externalParm1;
            SetDirty("Registrymessages");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( RegistryDetails_externalReference == null )
            {
               RegistryDetails_externalReference = new APISantanderDll.Models.Responses.RegistryDetails();
            }
            return RegistryDetails_externalReference ;
         }

         set {
            RegistryDetails_externalReference = (APISantanderDll.Models.Responses.RegistryDetails)(value);
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

      protected APISantanderDll.Models.Responses.RegistryDetails RegistryDetails_externalReference=null ;
   }

}
