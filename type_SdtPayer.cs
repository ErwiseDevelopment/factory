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
   public class SdtPayer : GxUserType, IGxExternalObject
   {
      public SdtPayer( )
      {
         /* Constructor for serialization */
      }

      public SdtPayer( IGxContext context )
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

      public string gxTpr_Name
      {
         get {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            return Payer_externalReference.Name ;
         }

         set {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            Payer_externalReference.Name = value;
            SetDirty("Name");
         }

      }

      public string gxTpr_Documenttype
      {
         get {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            return Payer_externalReference.DocumentType ;
         }

         set {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            Payer_externalReference.DocumentType = value;
            SetDirty("Documenttype");
         }

      }

      public string gxTpr_Documentnumber
      {
         get {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            return Payer_externalReference.DocumentNumber ;
         }

         set {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            Payer_externalReference.DocumentNumber = value;
            SetDirty("Documentnumber");
         }

      }

      public string gxTpr_Address
      {
         get {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            return Payer_externalReference.Address ;
         }

         set {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            Payer_externalReference.Address = value;
            SetDirty("Address");
         }

      }

      public string gxTpr_Neighborhood
      {
         get {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            return Payer_externalReference.Neighborhood ;
         }

         set {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            Payer_externalReference.Neighborhood = value;
            SetDirty("Neighborhood");
         }

      }

      public string gxTpr_City
      {
         get {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            return Payer_externalReference.City ;
         }

         set {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            Payer_externalReference.City = value;
            SetDirty("City");
         }

      }

      public string gxTpr_State
      {
         get {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            return Payer_externalReference.State ;
         }

         set {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            Payer_externalReference.State = value;
            SetDirty("State");
         }

      }

      public string gxTpr_Zipcode
      {
         get {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            return Payer_externalReference.ZipCode ;
         }

         set {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            Payer_externalReference.ZipCode = value;
            SetDirty("Zipcode");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( Payer_externalReference == null )
            {
               Payer_externalReference = new APISantanderDll.Models.Requests.Payer();
            }
            return Payer_externalReference ;
         }

         set {
            Payer_externalReference = (APISantanderDll.Models.Requests.Payer)(value);
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

      protected APISantanderDll.Models.Requests.Payer Payer_externalReference=null ;
   }

}
