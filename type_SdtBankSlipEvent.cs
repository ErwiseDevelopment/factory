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
   public class SdtBankSlipEvent : GxUserType, IGxExternalObject
   {
      public SdtBankSlipEvent( )
      {
         /* Constructor for serialization */
      }

      public SdtBankSlipEvent( IGxContext context )
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

      public string gxTpr_Type
      {
         get {
            if ( BankSlipEvent_externalReference == null )
            {
               BankSlipEvent_externalReference = new APISantanderDll.Models.Responses.BankSlipEvent();
            }
            return BankSlipEvent_externalReference.Type ;
         }

         set {
            if ( BankSlipEvent_externalReference == null )
            {
               BankSlipEvent_externalReference = new APISantanderDll.Models.Responses.BankSlipEvent();
            }
            BankSlipEvent_externalReference.Type = value;
            SetDirty("Type");
         }

      }

      public string gxTpr_Description
      {
         get {
            if ( BankSlipEvent_externalReference == null )
            {
               BankSlipEvent_externalReference = new APISantanderDll.Models.Responses.BankSlipEvent();
            }
            return BankSlipEvent_externalReference.Description ;
         }

         set {
            if ( BankSlipEvent_externalReference == null )
            {
               BankSlipEvent_externalReference = new APISantanderDll.Models.Responses.BankSlipEvent();
            }
            BankSlipEvent_externalReference.Description = value;
            SetDirty("Description");
         }

      }

      public DateTime gxTpr_Timestamp
      {
         get {
            if ( BankSlipEvent_externalReference == null )
            {
               BankSlipEvent_externalReference = new APISantanderDll.Models.Responses.BankSlipEvent();
            }
            return BankSlipEvent_externalReference.Timestamp ;
         }

         set {
            if ( BankSlipEvent_externalReference == null )
            {
               BankSlipEvent_externalReference = new APISantanderDll.Models.Responses.BankSlipEvent();
            }
            BankSlipEvent_externalReference.Timestamp = value;
            SetDirty("Timestamp");
         }

      }

      public decimal gxTpr_Value
      {
         get {
            if ( BankSlipEvent_externalReference == null )
            {
               BankSlipEvent_externalReference = new APISantanderDll.Models.Responses.BankSlipEvent();
            }
            return BankSlipEvent_externalReference.Value ;
         }

         set {
            if ( BankSlipEvent_externalReference == null )
            {
               BankSlipEvent_externalReference = new APISantanderDll.Models.Responses.BankSlipEvent();
            }
            BankSlipEvent_externalReference.Value = value;
            SetDirty("Value");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( BankSlipEvent_externalReference == null )
            {
               BankSlipEvent_externalReference = new APISantanderDll.Models.Responses.BankSlipEvent();
            }
            return BankSlipEvent_externalReference ;
         }

         set {
            BankSlipEvent_externalReference = (APISantanderDll.Models.Responses.BankSlipEvent)(value);
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

      protected APISantanderDll.Models.Responses.BankSlipEvent BankSlipEvent_externalReference=null ;
   }

}
