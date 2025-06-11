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
   public class SdtSettlementDetails : GxUserType, IGxExternalObject
   {
      public SdtSettlementDetails( )
      {
         /* Constructor for serialization */
      }

      public SdtSettlementDetails( IGxContext context )
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

      public string gxTpr_Settlementstatus
      {
         get {
            if ( SettlementDetails_externalReference == null )
            {
               SettlementDetails_externalReference = new APISantanderDll.Models.Responses.SettlementDetails();
            }
            return SettlementDetails_externalReference.SettlementStatus ;
         }

         set {
            if ( SettlementDetails_externalReference == null )
            {
               SettlementDetails_externalReference = new APISantanderDll.Models.Responses.SettlementDetails();
            }
            SettlementDetails_externalReference.SettlementStatus = value;
            SetDirty("Settlementstatus");
         }

      }

      public DateTime gxTpr_Settlementdate
      {
         get {
            if ( SettlementDetails_externalReference == null )
            {
               SettlementDetails_externalReference = new APISantanderDll.Models.Responses.SettlementDetails();
            }
            return SettlementDetails_externalReference.SettlementDate ;
         }

         set {
            if ( SettlementDetails_externalReference == null )
            {
               SettlementDetails_externalReference = new APISantanderDll.Models.Responses.SettlementDetails();
            }
            SettlementDetails_externalReference.SettlementDate = value;
            SetDirty("Settlementdate");
         }

      }

      public decimal gxTpr_Settlementvalue
      {
         get {
            if ( SettlementDetails_externalReference == null )
            {
               SettlementDetails_externalReference = new APISantanderDll.Models.Responses.SettlementDetails();
            }
            return SettlementDetails_externalReference.SettlementValue ;
         }

         set {
            if ( SettlementDetails_externalReference == null )
            {
               SettlementDetails_externalReference = new APISantanderDll.Models.Responses.SettlementDetails();
            }
            SettlementDetails_externalReference.SettlementValue = value;
            SetDirty("Settlementvalue");
         }

      }

      public string gxTpr_Settlementchannel
      {
         get {
            if ( SettlementDetails_externalReference == null )
            {
               SettlementDetails_externalReference = new APISantanderDll.Models.Responses.SettlementDetails();
            }
            return SettlementDetails_externalReference.SettlementChannel ;
         }

         set {
            if ( SettlementDetails_externalReference == null )
            {
               SettlementDetails_externalReference = new APISantanderDll.Models.Responses.SettlementDetails();
            }
            SettlementDetails_externalReference.SettlementChannel = value;
            SetDirty("Settlementchannel");
         }

      }

      public GXExternalCollection<SdtFee> gxTpr_Fees
      {
         get {
            if ( SettlementDetails_externalReference == null )
            {
               SettlementDetails_externalReference = new APISantanderDll.Models.Responses.SettlementDetails();
            }
            GXExternalCollection<SdtFee> intValue;
            intValue = new GXExternalCollection<SdtFee>( context, "SdtFee", "GeneXus.Programs");
            System.Collections.Generic.List< APISantanderDll.Models.Responses.Fee> externalParm0;
            externalParm0 = SettlementDetails_externalReference.Fees;
            intValue.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Responses.Fee>), externalParm0);
            return intValue ;
         }

         set {
            if ( SettlementDetails_externalReference == null )
            {
               SettlementDetails_externalReference = new APISantanderDll.Models.Responses.SettlementDetails();
            }
            GXExternalCollection<SdtFee> intValue;
            System.Collections.Generic.List< APISantanderDll.Models.Responses.Fee> externalParm1;
            intValue = value;
            externalParm1 = (System.Collections.Generic.List< APISantanderDll.Models.Responses.Fee>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Responses.Fee>), intValue.ExternalInstance);
            SettlementDetails_externalReference.Fees = externalParm1;
            SetDirty("Fees");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( SettlementDetails_externalReference == null )
            {
               SettlementDetails_externalReference = new APISantanderDll.Models.Responses.SettlementDetails();
            }
            return SettlementDetails_externalReference ;
         }

         set {
            SettlementDetails_externalReference = (APISantanderDll.Models.Responses.SettlementDetails)(value);
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

      protected APISantanderDll.Models.Responses.SettlementDetails SettlementDetails_externalReference=null ;
   }

}
