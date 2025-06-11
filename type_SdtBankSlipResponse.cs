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
   public class SdtBankSlipResponse : GxUserType, IGxExternalObject
   {
      public SdtBankSlipResponse( )
      {
         /* Constructor for serialization */
      }

      public SdtBankSlipResponse( IGxContext context )
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
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            return BankSlipResponse_externalReference.Id ;
         }

         set {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            BankSlipResponse_externalReference.Id = value;
            SetDirty("Id");
         }

      }

      public string gxTpr_Status
      {
         get {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            return BankSlipResponse_externalReference.Status ;
         }

         set {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            BankSlipResponse_externalReference.Status = value;
            SetDirty("Status");
         }

      }

      public string gxTpr_Bankslipcode
      {
         get {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            return BankSlipResponse_externalReference.BankSlipCode ;
         }

         set {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            BankSlipResponse_externalReference.BankSlipCode = value;
            SetDirty("Bankslipcode");
         }

      }

      public string gxTpr_Digitableline
      {
         get {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            return BankSlipResponse_externalReference.DigitableLine ;
         }

         set {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            BankSlipResponse_externalReference.DigitableLine = value;
            SetDirty("Digitableline");
         }

      }

      public string gxTpr_Barcode
      {
         get {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            return BankSlipResponse_externalReference.BarCode ;
         }

         set {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            BankSlipResponse_externalReference.BarCode = value;
            SetDirty("Barcode");
         }

      }

      public DateTime gxTpr_Createdat
      {
         get {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            return BankSlipResponse_externalReference.CreatedAt ;
         }

         set {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            BankSlipResponse_externalReference.CreatedAt = value;
            SetDirty("Createdat");
         }

      }

      public DateTime gxTpr_Updatedat
      {
         get {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            return BankSlipResponse_externalReference.UpdatedAt ;
         }

         set {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            BankSlipResponse_externalReference.UpdatedAt = value;
            SetDirty("Updatedat");
         }

      }

      public decimal gxTpr_Nominalvalue
      {
         get {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            return BankSlipResponse_externalReference.NominalValue ;
         }

         set {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            BankSlipResponse_externalReference.NominalValue = value;
            SetDirty("Nominalvalue");
         }

      }

      public string gxTpr_Duedate
      {
         get {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            return BankSlipResponse_externalReference.DueDate ;
         }

         set {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            BankSlipResponse_externalReference.DueDate = value;
            SetDirty("Duedate");
         }

      }

      public string gxTpr_Issuedate
      {
         get {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            return BankSlipResponse_externalReference.IssueDate ;
         }

         set {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            BankSlipResponse_externalReference.IssueDate = value;
            SetDirty("Issuedate");
         }

      }

      public SdtPayer gxTpr_Payer
      {
         get {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            SdtPayer intValue;
            intValue = new SdtPayer(context);
            APISantanderDll.Models.Requests.Payer externalParm0;
            externalParm0 = BankSlipResponse_externalReference.Payer;
            intValue.ExternalInstance = externalParm0;
            return intValue ;
         }

         set {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            SdtPayer intValue;
            APISantanderDll.Models.Requests.Payer externalParm1;
            intValue = value;
            externalParm1 = (APISantanderDll.Models.Requests.Payer)(intValue.ExternalInstance);
            BankSlipResponse_externalReference.Payer = externalParm1;
            SetDirty("Payer");
         }

      }

      public SdtBeneficiary gxTpr_Beneficiary
      {
         get {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            SdtBeneficiary intValue;
            intValue = new SdtBeneficiary(context);
            APISantanderDll.Models.Requests.Beneficiary externalParm2;
            externalParm2 = BankSlipResponse_externalReference.Beneficiary;
            intValue.ExternalInstance = externalParm2;
            return intValue ;
         }

         set {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            SdtBeneficiary intValue;
            APISantanderDll.Models.Requests.Beneficiary externalParm3;
            intValue = value;
            externalParm3 = (APISantanderDll.Models.Requests.Beneficiary)(intValue.ExternalInstance);
            BankSlipResponse_externalReference.Beneficiary = externalParm3;
            SetDirty("Beneficiary");
         }

      }

      public GxSimpleCollection<string> gxTpr_Messages
      {
         get {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            GxSimpleCollection<string> intValue;
            intValue = new GxSimpleCollection<string>();
            System.Collections.Generic.List< System.String> externalParm4;
            externalParm4 = BankSlipResponse_externalReference.Messages;
            intValue.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< System.String>), externalParm4);
            return intValue ;
         }

         set {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            GxSimpleCollection<string> intValue;
            System.Collections.Generic.List< System.String> externalParm5;
            intValue = value;
            externalParm5 = (System.Collections.Generic.List< System.String>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< System.String>), intValue.ExternalInstance);
            BankSlipResponse_externalReference.Messages = externalParm5;
            SetDirty("Messages");
         }

      }

      public GXExternalCollection<SdtError> gxTpr_Errors
      {
         get {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            GXExternalCollection<SdtError> intValue;
            intValue = new GXExternalCollection<SdtError>( context, "SdtError", "GeneXus.Programs");
            System.Collections.Generic.List< APISantanderDll.Models.Common.Error> externalParm6;
            externalParm6 = BankSlipResponse_externalReference.Errors;
            intValue.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Common.Error>), externalParm6);
            return intValue ;
         }

         set {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            GXExternalCollection<SdtError> intValue;
            System.Collections.Generic.List< APISantanderDll.Models.Common.Error> externalParm7;
            intValue = value;
            externalParm7 = (System.Collections.Generic.List< APISantanderDll.Models.Common.Error>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Common.Error>), intValue.ExternalInstance);
            BankSlipResponse_externalReference.Errors = externalParm7;
            SetDirty("Errors");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( BankSlipResponse_externalReference == null )
            {
               BankSlipResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipResponse();
            }
            return BankSlipResponse_externalReference ;
         }

         set {
            BankSlipResponse_externalReference = (APISantanderDll.Models.Responses.BankSlipResponse)(value);
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

      protected APISantanderDll.Models.Responses.BankSlipResponse BankSlipResponse_externalReference=null ;
   }

}
