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
   public class SdtWorkspaceResponse : GxUserType, IGxExternalObject
   {
      public SdtWorkspaceResponse( )
      {
         /* Constructor for serialization */
      }

      public SdtWorkspaceResponse( IGxContext context )
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

      public string gxTpr_Id
      {
         get {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            return WorkspaceResponse_externalReference.Id ;
         }

         set {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            WorkspaceResponse_externalReference.Id = value;
            SetDirty("Id");
         }

      }

      public string gxTpr_Type
      {
         get {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            return WorkspaceResponse_externalReference.Type ;
         }

         set {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            WorkspaceResponse_externalReference.Type = value;
            SetDirty("Type");
         }

      }

      public GXExternalCollection<SdtCovenant> gxTpr_Covenants
      {
         get {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            GXExternalCollection<SdtCovenant> intValue;
            intValue = new GXExternalCollection<SdtCovenant>( context, "SdtCovenant", "GeneXus.Programs");
            System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant> externalParm0;
            externalParm0 = WorkspaceResponse_externalReference.Covenants;
            intValue.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant>), externalParm0);
            return intValue ;
         }

         set {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            GXExternalCollection<SdtCovenant> intValue;
            System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant> externalParm1;
            intValue = value;
            externalParm1 = (System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant>), intValue.ExternalInstance);
            WorkspaceResponse_externalReference.Covenants = externalParm1;
            SetDirty("Covenants");
         }

      }

      public string gxTpr_Description
      {
         get {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            return WorkspaceResponse_externalReference.Description ;
         }

         set {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            WorkspaceResponse_externalReference.Description = value;
            SetDirty("Description");
         }

      }

      public bool gxTpr_Bankslipbillingwebhookactive
      {
         get {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            return WorkspaceResponse_externalReference.BankSlipBillingWebhookActive ;
         }

         set {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            WorkspaceResponse_externalReference.BankSlipBillingWebhookActive = value;
            SetDirty("Bankslipbillingwebhookactive");
         }

      }

      public bool gxTpr_Pixbillingwebhookactive
      {
         get {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            return WorkspaceResponse_externalReference.PixBillingWebhookActive ;
         }

         set {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            WorkspaceResponse_externalReference.PixBillingWebhookActive = value;
            SetDirty("Pixbillingwebhookactive");
         }

      }

      public string gxTpr_Webhookurl
      {
         get {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            return WorkspaceResponse_externalReference.WebhookURL ;
         }

         set {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            WorkspaceResponse_externalReference.WebhookURL = value;
            SetDirty("Webhookurl");
         }

      }

      public DateTime gxTpr_Createdat
      {
         get {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            return WorkspaceResponse_externalReference.CreatedAt ;
         }

         set {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            WorkspaceResponse_externalReference.CreatedAt = value;
            SetDirty("Createdat");
         }

      }

      public DateTime gxTpr_Updatedat
      {
         get {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            return WorkspaceResponse_externalReference.UpdatedAt ;
         }

         set {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            WorkspaceResponse_externalReference.UpdatedAt = value;
            SetDirty("Updatedat");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( WorkspaceResponse_externalReference == null )
            {
               WorkspaceResponse_externalReference = new APISantanderDll.Models.Responses.WorkspaceResponse();
            }
            return WorkspaceResponse_externalReference ;
         }

         set {
            WorkspaceResponse_externalReference = (APISantanderDll.Models.Responses.WorkspaceResponse)(value);
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

      protected APISantanderDll.Models.Responses.WorkspaceResponse WorkspaceResponse_externalReference=null ;
   }

}
