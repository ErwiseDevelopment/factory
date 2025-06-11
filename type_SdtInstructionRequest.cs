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
   public class SdtInstructionRequest : GxUserType, IGxExternalObject
   {
      public SdtInstructionRequest( )
      {
         /* Constructor for serialization */
      }

      public SdtInstructionRequest( IGxContext context )
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

      public string gxTpr_Covenantcode
      {
         get {
            if ( InstructionRequest_externalReference == null )
            {
               InstructionRequest_externalReference = new APISantanderDll.Models.Requests.InstructionRequest();
            }
            return InstructionRequest_externalReference.CovenantCode ;
         }

         set {
            if ( InstructionRequest_externalReference == null )
            {
               InstructionRequest_externalReference = new APISantanderDll.Models.Requests.InstructionRequest();
            }
            InstructionRequest_externalReference.CovenantCode = value;
            SetDirty("Covenantcode");
         }

      }

      public string gxTpr_Banknumber
      {
         get {
            if ( InstructionRequest_externalReference == null )
            {
               InstructionRequest_externalReference = new APISantanderDll.Models.Requests.InstructionRequest();
            }
            return InstructionRequest_externalReference.BankNumber ;
         }

         set {
            if ( InstructionRequest_externalReference == null )
            {
               InstructionRequest_externalReference = new APISantanderDll.Models.Requests.InstructionRequest();
            }
            InstructionRequest_externalReference.BankNumber = value;
            SetDirty("Banknumber");
         }

      }

      public string gxTpr_Operation
      {
         get {
            if ( InstructionRequest_externalReference == null )
            {
               InstructionRequest_externalReference = new APISantanderDll.Models.Requests.InstructionRequest();
            }
            return InstructionRequest_externalReference.Operation ;
         }

         set {
            if ( InstructionRequest_externalReference == null )
            {
               InstructionRequest_externalReference = new APISantanderDll.Models.Requests.InstructionRequest();
            }
            InstructionRequest_externalReference.Operation = value;
            SetDirty("Operation");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( InstructionRequest_externalReference == null )
            {
               InstructionRequest_externalReference = new APISantanderDll.Models.Requests.InstructionRequest();
            }
            return InstructionRequest_externalReference ;
         }

         set {
            InstructionRequest_externalReference = (APISantanderDll.Models.Requests.InstructionRequest)(value);
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

      protected APISantanderDll.Models.Requests.InstructionRequest InstructionRequest_externalReference=null ;
   }

}
