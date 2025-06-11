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
   public class SdtUpdateWorkspaceRequest : GxUserType, IGxExternalObject
   {
      public SdtUpdateWorkspaceRequest( )
      {
         /* Constructor for serialization */
      }

      public SdtUpdateWorkspaceRequest( IGxContext context )
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

      public GXExternalCollection<SdtCovenant> gxTpr_Covenants
      {
         get {
            if ( UpdateWorkspaceRequest_externalReference == null )
            {
               UpdateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.UpdateWorkspaceRequest();
            }
            GXExternalCollection<SdtCovenant> intValue;
            intValue = new GXExternalCollection<SdtCovenant>( context, "SdtCovenant", "GeneXus.Programs");
            System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant> externalParm0;
            externalParm0 = UpdateWorkspaceRequest_externalReference.Covenants;
            intValue.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant>), externalParm0);
            return intValue ;
         }

         set {
            if ( UpdateWorkspaceRequest_externalReference == null )
            {
               UpdateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.UpdateWorkspaceRequest();
            }
            GXExternalCollection<SdtCovenant> intValue;
            System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant> externalParm1;
            intValue = value;
            externalParm1 = (System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Common.Covenant>), intValue.ExternalInstance);
            UpdateWorkspaceRequest_externalReference.Covenants = externalParm1;
            SetDirty("Covenants");
         }

      }

      public string gxTpr_Description
      {
         get {
            if ( UpdateWorkspaceRequest_externalReference == null )
            {
               UpdateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.UpdateWorkspaceRequest();
            }
            return UpdateWorkspaceRequest_externalReference.Description ;
         }

         set {
            if ( UpdateWorkspaceRequest_externalReference == null )
            {
               UpdateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.UpdateWorkspaceRequest();
            }
            UpdateWorkspaceRequest_externalReference.Description = value;
            SetDirty("Description");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( UpdateWorkspaceRequest_externalReference == null )
            {
               UpdateWorkspaceRequest_externalReference = new APISantanderDll.Models.Requests.UpdateWorkspaceRequest();
            }
            return UpdateWorkspaceRequest_externalReference ;
         }

         set {
            UpdateWorkspaceRequest_externalReference = (APISantanderDll.Models.Requests.UpdateWorkspaceRequest)(value);
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

      protected APISantanderDll.Models.Requests.UpdateWorkspaceRequest UpdateWorkspaceRequest_externalReference=null ;
   }

}
