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
   public class SdtPagination : GxUserType, IGxExternalObject
   {
      public SdtPagination( )
      {
         /* Constructor for serialization */
      }

      public SdtPagination( IGxContext context )
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

      public int gxTpr_Page
      {
         get {
            if ( Pagination_externalReference == null )
            {
               Pagination_externalReference = new APISantanderDll.Models.Common.Pagination();
            }
            return Pagination_externalReference.Page ;
         }

         set {
            if ( Pagination_externalReference == null )
            {
               Pagination_externalReference = new APISantanderDll.Models.Common.Pagination();
            }
            Pagination_externalReference.Page = value;
            SetDirty("Page");
         }

      }

      public int gxTpr_Pagesize
      {
         get {
            if ( Pagination_externalReference == null )
            {
               Pagination_externalReference = new APISantanderDll.Models.Common.Pagination();
            }
            return Pagination_externalReference.PageSize ;
         }

         set {
            if ( Pagination_externalReference == null )
            {
               Pagination_externalReference = new APISantanderDll.Models.Common.Pagination();
            }
            Pagination_externalReference.PageSize = value;
            SetDirty("Pagesize");
         }

      }

      public int gxTpr_Totalpages
      {
         get {
            if ( Pagination_externalReference == null )
            {
               Pagination_externalReference = new APISantanderDll.Models.Common.Pagination();
            }
            return Pagination_externalReference.TotalPages ;
         }

         set {
            if ( Pagination_externalReference == null )
            {
               Pagination_externalReference = new APISantanderDll.Models.Common.Pagination();
            }
            Pagination_externalReference.TotalPages = value;
            SetDirty("Totalpages");
         }

      }

      public int gxTpr_Totalitems
      {
         get {
            if ( Pagination_externalReference == null )
            {
               Pagination_externalReference = new APISantanderDll.Models.Common.Pagination();
            }
            return Pagination_externalReference.TotalItems ;
         }

         set {
            if ( Pagination_externalReference == null )
            {
               Pagination_externalReference = new APISantanderDll.Models.Common.Pagination();
            }
            Pagination_externalReference.TotalItems = value;
            SetDirty("Totalitems");
         }

      }

      public bool gxTpr_Hasnext
      {
         get {
            if ( Pagination_externalReference == null )
            {
               Pagination_externalReference = new APISantanderDll.Models.Common.Pagination();
            }
            return Pagination_externalReference.HasNext ;
         }

         set {
            if ( Pagination_externalReference == null )
            {
               Pagination_externalReference = new APISantanderDll.Models.Common.Pagination();
            }
            Pagination_externalReference.HasNext = value;
            SetDirty("Hasnext");
         }

      }

      public bool gxTpr_Hasprevious
      {
         get {
            if ( Pagination_externalReference == null )
            {
               Pagination_externalReference = new APISantanderDll.Models.Common.Pagination();
            }
            return Pagination_externalReference.HasPrevious ;
         }

         set {
            if ( Pagination_externalReference == null )
            {
               Pagination_externalReference = new APISantanderDll.Models.Common.Pagination();
            }
            Pagination_externalReference.HasPrevious = value;
            SetDirty("Hasprevious");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( Pagination_externalReference == null )
            {
               Pagination_externalReference = new APISantanderDll.Models.Common.Pagination();
            }
            return Pagination_externalReference ;
         }

         set {
            Pagination_externalReference = (APISantanderDll.Models.Common.Pagination)(value);
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

      protected APISantanderDll.Models.Common.Pagination Pagination_externalReference=null ;
   }

}
