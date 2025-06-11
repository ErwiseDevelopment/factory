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
   public class SdtInstructionResponse : GxUserType, IGxExternalObject
   {
      public SdtInstructionResponse( )
      {
         /* Constructor for serialization */
      }

      public SdtInstructionResponse( IGxContext context )
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

      public string gxTpr_Status
      {
         get {
            if ( InstructionResponse_externalReference == null )
            {
               InstructionResponse_externalReference = new APISantanderDll.Models.Responses.InstructionResponse();
            }
            return InstructionResponse_externalReference.Status ;
         }

         set {
            if ( InstructionResponse_externalReference == null )
            {
               InstructionResponse_externalReference = new APISantanderDll.Models.Responses.InstructionResponse();
            }
            InstructionResponse_externalReference.Status = value;
            SetDirty("Status");
         }

      }

      public string gxTpr_Message
      {
         get {
            if ( InstructionResponse_externalReference == null )
            {
               InstructionResponse_externalReference = new APISantanderDll.Models.Responses.InstructionResponse();
            }
            return InstructionResponse_externalReference.Message ;
         }

         set {
            if ( InstructionResponse_externalReference == null )
            {
               InstructionResponse_externalReference = new APISantanderDll.Models.Responses.InstructionResponse();
            }
            InstructionResponse_externalReference.Message = value;
            SetDirty("Message");
         }

      }

      public DateTime gxTpr_Processedat
      {
         get {
            if ( InstructionResponse_externalReference == null )
            {
               InstructionResponse_externalReference = new APISantanderDll.Models.Responses.InstructionResponse();
            }
            return InstructionResponse_externalReference.ProcessedAt ;
         }

         set {
            if ( InstructionResponse_externalReference == null )
            {
               InstructionResponse_externalReference = new APISantanderDll.Models.Responses.InstructionResponse();
            }
            InstructionResponse_externalReference.ProcessedAt = value;
            SetDirty("Processedat");
         }

      }

      public GXExternalCollection<SdtError> gxTpr_Errors
      {
         get {
            if ( InstructionResponse_externalReference == null )
            {
               InstructionResponse_externalReference = new APISantanderDll.Models.Responses.InstructionResponse();
            }
            GXExternalCollection<SdtError> intValue;
            intValue = new GXExternalCollection<SdtError>( context, "SdtError", "GeneXus.Programs");
            System.Collections.Generic.List< APISantanderDll.Models.Common.Error> externalParm0;
            externalParm0 = InstructionResponse_externalReference.Errors;
            intValue.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Common.Error>), externalParm0);
            return intValue ;
         }

         set {
            if ( InstructionResponse_externalReference == null )
            {
               InstructionResponse_externalReference = new APISantanderDll.Models.Responses.InstructionResponse();
            }
            GXExternalCollection<SdtError> intValue;
            System.Collections.Generic.List< APISantanderDll.Models.Common.Error> externalParm1;
            intValue = value;
            externalParm1 = (System.Collections.Generic.List< APISantanderDll.Models.Common.Error>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Common.Error>), intValue.ExternalInstance);
            InstructionResponse_externalReference.Errors = externalParm1;
            SetDirty("Errors");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( InstructionResponse_externalReference == null )
            {
               InstructionResponse_externalReference = new APISantanderDll.Models.Responses.InstructionResponse();
            }
            return InstructionResponse_externalReference ;
         }

         set {
            InstructionResponse_externalReference = (APISantanderDll.Models.Responses.InstructionResponse)(value);
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

      protected APISantanderDll.Models.Responses.InstructionResponse InstructionResponse_externalReference=null ;
   }

}
