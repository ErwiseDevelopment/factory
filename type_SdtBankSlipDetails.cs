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
   public class SdtBankSlipDetails : GxUserType, IGxExternalObject
   {
      public SdtBankSlipDetails( )
      {
         /* Constructor for serialization */
      }

      public SdtBankSlipDetails( IGxContext context )
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

      public string gxTpr_Digitableline
      {
         get {
            if ( BankSlipDetails_externalReference == null )
            {
               BankSlipDetails_externalReference = new APISantanderDll.Models.Responses.BankSlipDetails();
            }
            return BankSlipDetails_externalReference.DigitableLine ;
         }

         set {
            if ( BankSlipDetails_externalReference == null )
            {
               BankSlipDetails_externalReference = new APISantanderDll.Models.Responses.BankSlipDetails();
            }
            BankSlipDetails_externalReference.DigitableLine = value;
            SetDirty("Digitableline");
         }

      }

      public string gxTpr_Barcode
      {
         get {
            if ( BankSlipDetails_externalReference == null )
            {
               BankSlipDetails_externalReference = new APISantanderDll.Models.Responses.BankSlipDetails();
            }
            return BankSlipDetails_externalReference.BarCode ;
         }

         set {
            if ( BankSlipDetails_externalReference == null )
            {
               BankSlipDetails_externalReference = new APISantanderDll.Models.Responses.BankSlipDetails();
            }
            BankSlipDetails_externalReference.BarCode = value;
            SetDirty("Barcode");
         }

      }

      public GxSimpleCollection<string> gxTpr_Messages
      {
         get {
            if ( BankSlipDetails_externalReference == null )
            {
               BankSlipDetails_externalReference = new APISantanderDll.Models.Responses.BankSlipDetails();
            }
            GxSimpleCollection<string> intValue;
            intValue = new GxSimpleCollection<string>();
            System.Collections.Generic.List< System.String> externalParm0;
            externalParm0 = BankSlipDetails_externalReference.Messages;
            intValue.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< System.String>), externalParm0);
            return intValue ;
         }

         set {
            if ( BankSlipDetails_externalReference == null )
            {
               BankSlipDetails_externalReference = new APISantanderDll.Models.Responses.BankSlipDetails();
            }
            GxSimpleCollection<string> intValue;
            System.Collections.Generic.List< System.String> externalParm1;
            intValue = value;
            externalParm1 = (System.Collections.Generic.List< System.String>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< System.String>), intValue.ExternalInstance);
            BankSlipDetails_externalReference.Messages = externalParm1;
            SetDirty("Messages");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( BankSlipDetails_externalReference == null )
            {
               BankSlipDetails_externalReference = new APISantanderDll.Models.Responses.BankSlipDetails();
            }
            return BankSlipDetails_externalReference ;
         }

         set {
            BankSlipDetails_externalReference = (APISantanderDll.Models.Responses.BankSlipDetails)(value);
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

      protected APISantanderDll.Models.Responses.BankSlipDetails BankSlipDetails_externalReference=null ;
   }

}
