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
   public class SdtCreateWorkspaceRequest : GxUserType, IGxExternalObject
   {
      public SdtCreateWorkspaceRequest( )
      {
         /* Constructor for serialization */
      }

      public SdtCreateWorkspaceRequest( IGxContext context )
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
            if ( CreateWorkspaceRequest_externalReference == null )
            {
               CreateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.CreateWorkspaceRequest();
            }
            return CreateWorkspaceRequest_externalReference.Type ;
         }

         set {
            if ( CreateWorkspaceRequest_externalReference == null )
            {
               CreateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.CreateWorkspaceRequest();
            }
            CreateWorkspaceRequest_externalReference.Type = value;
            SetDirty("Type");
         }

      }

      public GXExternalCollection<SdtCovenant> gxTpr_Covenants
      {
         get {
            if ( CreateWorkspaceRequest_externalReference == null )
            {
               CreateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.CreateWorkspaceRequest();
            }
            GXExternalCollection<SdtCovenant> intValue;
            intValue = new GXExternalCollection<SdtCovenant>( context, "SdtCovenant", "GeneXus.Programs");
            System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant> externalParm0;
            externalParm0 = CreateWorkspaceRequest_externalReference.Covenants;
            intValue.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant>), externalParm0);
            return intValue ;
         }

         set {
            if ( CreateWorkspaceRequest_externalReference == null )
            {
               CreateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.CreateWorkspaceRequest();
            }
            GXExternalCollection<SdtCovenant> intValue;
            System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant> externalParm1;
            intValue = value;
            externalParm1 = (System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant>), intValue.ExternalInstance);
            CreateWorkspaceRequest_externalReference.Covenants = externalParm1;
            SetDirty("Covenants");
         }

      }

      public string gxTpr_Description
      {
         get {
            if ( CreateWorkspaceRequest_externalReference == null )
            {
               CreateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.CreateWorkspaceRequest();
            }
            return CreateWorkspaceRequest_externalReference.Description ;
         }

         set {
            if ( CreateWorkspaceRequest_externalReference == null )
            {
               CreateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.CreateWorkspaceRequest();
            }
            CreateWorkspaceRequest_externalReference.Description = value;
            SetDirty("Description");
         }

      }

      public bool gxTpr_Bankslipbillingwebhookactive
      {
         get {
            if ( CreateWorkspaceRequest_externalReference == null )
            {
               CreateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.CreateWorkspaceRequest();
            }
            return CreateWorkspaceRequest_externalReference.BankSlipBillingWebhookActive ;
         }

         set {
            if ( CreateWorkspaceRequest_externalReference == null )
            {
               CreateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.CreateWorkspaceRequest();
            }
            CreateWorkspaceRequest_externalReference.BankSlipBillingWebhookActive = value;
            SetDirty("Bankslipbillingwebhookactive");
         }

      }

      public bool gxTpr_Pixbillingwebhookactive
      {
         get {
            if ( CreateWorkspaceRequest_externalReference == null )
            {
               CreateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.CreateWorkspaceRequest();
            }
            return CreateWorkspaceRequest_externalReference.PixBillingWebhookActive ;
         }

         set {
            if ( CreateWorkspaceRequest_externalReference == null )
            {
               CreateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.CreateWorkspaceRequest();
            }
            CreateWorkspaceRequest_externalReference.PixBillingWebhookActive = value;
            SetDirty("Pixbillingwebhookactive");
         }

      }

      public string gxTpr_Webhookurl
      {
         get {
            if ( CreateWorkspaceRequest_externalReference == null )
            {
               CreateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.CreateWorkspaceRequest();
            }
            return CreateWorkspaceRequest_externalReference.WebhookURL ;
         }

         set {
            if ( CreateWorkspaceRequest_externalReference == null )
            {
               CreateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.CreateWorkspaceRequest();
            }
            CreateWorkspaceRequest_externalReference.WebhookURL = value;
            SetDirty("Webhookurl");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( CreateWorkspaceRequest_externalReference == null )
            {
               CreateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.CreateWorkspaceRequest();
            }
            return CreateWorkspaceRequest_externalReference ;
         }

         set {
            CreateWorkspaceRequest_externalReference = (APISantanderDll.Models.Requests.CreateWorkspaceRequest)(value);
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

      protected APISantanderDll.Models.Requests.CreateWorkspaceRequest CreateWorkspaceRequest_externalReference=null ;
   }

}
