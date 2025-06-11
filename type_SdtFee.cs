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
   public class SdtFee : GxUserType, IGxExternalObject
   {
      public SdtFee( )
      {
         /* Constructor for serialization */
      }

      public SdtFee( IGxContext context )
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
            if ( Fee_externalReference == null )
            {
               Fee_externalReference = new APISantanderDll.Models.Responses.Fee();
            }
            return Fee_externalReference.Type ;
         }

         set {
            if ( Fee_externalReference == null )
            {
               Fee_externalReference = new APISantanderDll.Models.Responses.Fee();
            }
            Fee_externalReference.Type = value;
            SetDirty("Type");
         }

      }

      public decimal gxTpr_Value
      {
         get {
            if ( Fee_externalReference == null )
            {
               Fee_externalReference = new APISantanderDll.Models.Responses.Fee();
            }
            return Fee_externalReference.Value ;
         }

         set {
            if ( Fee_externalReference == null )
            {
               Fee_externalReference = new APISantanderDll.Models.Responses.Fee();
            }
            Fee_externalReference.Value = value;
            SetDirty("Value");
         }

      }

      public string gxTpr_Description
      {
         get {
            if ( Fee_externalReference == null )
            {
               Fee_externalReference = new APISantanderDll.Models.Responses.Fee();
            }
            return Fee_externalReference.Description ;
         }

         set {
            if ( Fee_externalReference == null )
            {
               Fee_externalReference = new APISantanderDll.Models.Responses.Fee();
            }
            Fee_externalReference.Description = value;
            SetDirty("Description");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( Fee_externalReference == null )
            {
               Fee_externalReference = new APISantanderDll.Models.Responses.Fee();
            }
            return Fee_externalReference ;
         }

         set {
            Fee_externalReference = (APISantanderDll.Models.Responses.Fee)(value);
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

      protected APISantanderDll.Models.Responses.Fee Fee_externalReference=null ;
   }

}
