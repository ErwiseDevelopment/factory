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
   public class SdtError : GxUserType, IGxExternalObject
   {
      public SdtError( )
      {
         /* Constructor for serialization */
      }

      public SdtError( IGxContext context )
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

      public string gxTpr_Code
      {
         get {
            if ( Error_externalReference == null )
            {
               Error_externalReference = new APISantanderDll.Models.Common.Error();
            }
            return Error_externalReference.Code ;
         }

         set {
            if ( Error_externalReference == null )
            {
               Error_externalReference = new APISantanderDll.Models.Common.Error();
            }
            Error_externalReference.Code = value;
            SetDirty("Code");
         }

      }

      public string gxTpr_Message
      {
         get {
            if ( Error_externalReference == null )
            {
               Error_externalReference = new APISantanderDll.Models.Common.Error();
            }
            return Error_externalReference.Message ;
         }

         set {
            if ( Error_externalReference == null )
            {
               Error_externalReference = new APISantanderDll.Models.Common.Error();
            }
            Error_externalReference.Message = value;
            SetDirty("Message");
         }

      }

      public string gxTpr_Field
      {
         get {
            if ( Error_externalReference == null )
            {
               Error_externalReference = new APISantanderDll.Models.Common.Error();
            }
            return Error_externalReference.Field ;
         }

         set {
            if ( Error_externalReference == null )
            {
               Error_externalReference = new APISantanderDll.Models.Common.Error();
            }
            Error_externalReference.Field = value;
            SetDirty("Field");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( Error_externalReference == null )
            {
               Error_externalReference = new APISantanderDll.Models.Common.Error();
            }
            return Error_externalReference ;
         }

         set {
            Error_externalReference = (APISantanderDll.Models.Common.Error)(value);
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

      protected APISantanderDll.Models.Common.Error Error_externalReference=null ;
   }

}
