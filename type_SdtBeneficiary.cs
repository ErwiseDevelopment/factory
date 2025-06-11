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
   public class SdtBeneficiary : GxUserType, IGxExternalObject
   {
      public SdtBeneficiary( )
      {
         /* Constructor for serialization */
      }

      public SdtBeneficiary( IGxContext context )
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
            if ( Beneficiary_externalReference == null )
            {
               Beneficiary_externalReference = new APISantanderDll.Models.Requests.Beneficiary();
            }
            return Beneficiary_externalReference.Name ;
         }

         set {
            if ( Beneficiary_externalReference == null )
            {
               Beneficiary_externalReference = new APISantanderDll.Models.Requests.Beneficiary();
            }
            Beneficiary_externalReference.Name = value;
            SetDirty("Name");
         }

      }

      public string gxTpr_Documenttype
      {
         get {
            if ( Beneficiary_externalReference == null )
            {
               Beneficiary_externalReference = new APISantanderDll.Models.Requests.Beneficiary();
            }
            return Beneficiary_externalReference.DocumentType ;
         }

         set {
            if ( Beneficiary_externalReference == null )
            {
               Beneficiary_externalReference = new APISantanderDll.Models.Requests.Beneficiary();
            }
            Beneficiary_externalReference.DocumentType = value;
            SetDirty("Documenttype");
         }

      }

      public string gxTpr_Documentnumber
      {
         get {
            if ( Beneficiary_externalReference == null )
            {
               Beneficiary_externalReference = new APISantanderDll.Models.Requests.Beneficiary();
            }
            return Beneficiary_externalReference.DocumentNumber ;
         }

         set {
            if ( Beneficiary_externalReference == null )
            {
               Beneficiary_externalReference = new APISantanderDll.Models.Requests.Beneficiary();
            }
            Beneficiary_externalReference.DocumentNumber = value;
            SetDirty("Documentnumber");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( Beneficiary_externalReference == null )
            {
               Beneficiary_externalReference = new APISantanderDll.Models.Requests.Beneficiary();
            }
            return Beneficiary_externalReference ;
         }

         set {
            Beneficiary_externalReference = (APISantanderDll.Models.Requests.Beneficiary)(value);
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

      protected APISantanderDll.Models.Requests.Beneficiary Beneficiary_externalReference=null ;
   }

}
