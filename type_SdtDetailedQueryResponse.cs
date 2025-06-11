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
   public class SdtDetailedQueryResponse : GxUserType, IGxExternalObject
   {
      public SdtDetailedQueryResponse( )
      {
         /* Constructor for serialization */
      }

      public SdtDetailedQueryResponse( IGxContext context )
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

      public GXExternalCollection<SdtBillDetail> gxTpr_Bills
      {
         get {
            if ( DetailedQueryResponse_externalReference == null )
            {
               DetailedQueryResponse_externalReference = new APISantanderDll.Models.Responses.DetailedQueryResponse();
            }
            GXExternalCollection<SdtBillDetail> intValue;
            intValue = new GXExternalCollection<SdtBillDetail>( context, "SdtBillDetail", "GeneXus.Programs");
            System.Collections.Generic.List< APISantanderDll.Models.Responses.BillDetail> externalParm0;
            externalParm0 = DetailedQueryResponse_externalReference.Bills;
            intValue.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Responses.BillDetail>), externalParm0);
            return intValue ;
         }

         set {
            if ( DetailedQueryResponse_externalReference == null )
            {
               DetailedQueryResponse_externalReference = new APISantanderDll.Models.Responses.DetailedQueryResponse();
            }
            GXExternalCollection<SdtBillDetail> intValue;
            System.Collections.Generic.List< APISantanderDll.Models.Responses.BillDetail> externalParm1;
            intValue = value;
            externalParm1 = (System.Collections.Generic.List< APISantanderDll.Models.Responses.BillDetail>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Responses.BillDetail>), intValue.ExternalInstance);
            DetailedQueryResponse_externalReference.Bills = externalParm1;
            SetDirty("Bills");
         }

      }

      public SdtPagination gxTpr_Pagination
      {
         get {
            if ( DetailedQueryResponse_externalReference == null )
            {
               DetailedQueryResponse_externalReference = new APISantanderDll.Models.Responses.DetailedQueryResponse();
            }
            SdtPagination intValue;
            intValue = new SdtPagination(context);
            APISantanderDll.Models.Common.Pagination externalParm2;
            externalParm2 = DetailedQueryResponse_externalReference.Pagination;
            intValue.ExternalInstance = externalParm2;
            return intValue ;
         }

         set {
            if ( DetailedQueryResponse_externalReference == null )
            {
               DetailedQueryResponse_externalReference = new APISantanderDll.Models.Responses.DetailedQueryResponse();
            }
            SdtPagination intValue;
            APISantanderDll.Models.Common.Pagination externalParm3;
            intValue = value;
            externalParm3 = (APISantanderDll.Models.Common.Pagination)(intValue.ExternalInstance);
            DetailedQueryResponse_externalReference.Pagination = externalParm3;
            SetDirty("Pagination");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( DetailedQueryResponse_externalReference == null )
            {
               DetailedQueryResponse_externalReference = new APISantanderDll.Models.Responses.DetailedQueryResponse();
            }
            return DetailedQueryResponse_externalReference ;
         }

         set {
            DetailedQueryResponse_externalReference = (APISantanderDll.Models.Responses.DetailedQueryResponse)(value);
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

      protected APISantanderDll.Models.Responses.DetailedQueryResponse DetailedQueryResponse_externalReference=null ;
   }

}
