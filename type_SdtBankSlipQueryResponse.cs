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
   public class SdtBankSlipQueryResponse : GxUserType, IGxExternalObject
   {
      public SdtBankSlipQueryResponse( )
      {
         /* Constructor for serialization */
      }

      public SdtBankSlipQueryResponse( IGxContext context )
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
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            return BankSlipQueryResponse_externalReference.Id ;
         }

         set {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            BankSlipQueryResponse_externalReference.Id = value;
            SetDirty("Id");
         }

      }

      public string gxTpr_Status
      {
         get {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            return BankSlipQueryResponse_externalReference.Status ;
         }

         set {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            BankSlipQueryResponse_externalReference.Status = value;
            SetDirty("Status");
         }

      }

      public string gxTpr_Bankslipcode
      {
         get {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            return BankSlipQueryResponse_externalReference.BankSlipCode ;
         }

         set {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            BankSlipQueryResponse_externalReference.BankSlipCode = value;
            SetDirty("Bankslipcode");
         }

      }

      public string gxTpr_Digitableline
      {
         get {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            return BankSlipQueryResponse_externalReference.DigitableLine ;
         }

         set {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            BankSlipQueryResponse_externalReference.DigitableLine = value;
            SetDirty("Digitableline");
         }

      }

      public string gxTpr_Barcode
      {
         get {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            return BankSlipQueryResponse_externalReference.BarCode ;
         }

         set {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            BankSlipQueryResponse_externalReference.BarCode = value;
            SetDirty("Barcode");
         }

      }

      public decimal gxTpr_Nominalvalue
      {
         get {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            return BankSlipQueryResponse_externalReference.NominalValue ;
         }

         set {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            BankSlipQueryResponse_externalReference.NominalValue = value;
            SetDirty("Nominalvalue");
         }

      }

      public decimal gxTpr_Paidvalue
      {
         get {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            return BankSlipQueryResponse_externalReference.PaidValue ;
         }

         set {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            BankSlipQueryResponse_externalReference.PaidValue = value;
            SetDirty("Paidvalue");
         }

      }

      public string gxTpr_Duedate
      {
         get {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            return BankSlipQueryResponse_externalReference.DueDate ;
         }

         set {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            BankSlipQueryResponse_externalReference.DueDate = value;
            SetDirty("Duedate");
         }

      }

      public string gxTpr_Paymentdate
      {
         get {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            return BankSlipQueryResponse_externalReference.PaymentDate ;
         }

         set {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            BankSlipQueryResponse_externalReference.PaymentDate = value;
            SetDirty("Paymentdate");
         }

      }

      public string gxTpr_Issuedate
      {
         get {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            return BankSlipQueryResponse_externalReference.IssueDate ;
         }

         set {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            BankSlipQueryResponse_externalReference.IssueDate = value;
            SetDirty("Issuedate");
         }

      }

      public SdtPayer gxTpr_Payer
      {
         get {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            SdtPayer intValue;
            intValue = new SdtPayer(context);
            APISantanderDll.Models.Requests.Payer externalParm0;
            externalParm0 = BankSlipQueryResponse_externalReference.Payer;
            intValue.ExternalInstance = externalParm0;
            return intValue ;
         }

         set {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            SdtPayer intValue;
            APISantanderDll.Models.Requests.Payer externalParm1;
            intValue = value;
            externalParm1 = (APISantanderDll.Models.Requests.Payer)(intValue.ExternalInstance);
            BankSlipQueryResponse_externalReference.Payer = externalParm1;
            SetDirty("Payer");
         }

      }

      public SdtBeneficiary gxTpr_Beneficiary
      {
         get {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            SdtBeneficiary intValue;
            intValue = new SdtBeneficiary(context);
            APISantanderDll.Models.Requests.Beneficiary externalParm2;
            externalParm2 = BankSlipQueryResponse_externalReference.Beneficiary;
            intValue.ExternalInstance = externalParm2;
            return intValue ;
         }

         set {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            SdtBeneficiary intValue;
            APISantanderDll.Models.Requests.Beneficiary externalParm3;
            intValue = value;
            externalParm3 = (APISantanderDll.Models.Requests.Beneficiary)(intValue.ExternalInstance);
            BankSlipQueryResponse_externalReference.Beneficiary = externalParm3;
            SetDirty("Beneficiary");
         }

      }

      public GxSimpleCollection<string> gxTpr_Messages
      {
         get {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            GxSimpleCollection<string> intValue;
            intValue = new GxSimpleCollection<string>();
            System.Collections.Generic.List< System.String> externalParm4;
            externalParm4 = BankSlipQueryResponse_externalReference.Messages;
            intValue.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< System.String>), externalParm4);
            return intValue ;
         }

         set {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            GxSimpleCollection<string> intValue;
            System.Collections.Generic.List< System.String> externalParm5;
            intValue = value;
            externalParm5 = (System.Collections.Generic.List< System.String>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< System.String>), intValue.ExternalInstance);
            BankSlipQueryResponse_externalReference.Messages = externalParm5;
            SetDirty("Messages");
         }

      }

      public GXExternalCollection<SdtBankSlipEvent> gxTpr_Events
      {
         get {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            GXExternalCollection<SdtBankSlipEvent> intValue;
            intValue = new GXExternalCollection<SdtBankSlipEvent>( context, "SdtBankSlipEvent", "GeneXus.Programs");
            System.Collections.Generic.List< APISantanderDll.Models.Responses.BankSlipEvent> externalParm6;
            externalParm6 = BankSlipQueryResponse_externalReference.Events;
            intValue.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Responses.BankSlipEvent>), externalParm6);
            return intValue ;
         }

         set {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            GXExternalCollection<SdtBankSlipEvent> intValue;
            System.Collections.Generic.List< APISantanderDll.Models.Responses.BankSlipEvent> externalParm7;
            intValue = value;
            externalParm7 = (System.Collections.Generic.List< APISantanderDll.Models.Responses.BankSlipEvent>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Responses.BankSlipEvent>), intValue.ExternalInstance);
            BankSlipQueryResponse_externalReference.Events = externalParm7;
            SetDirty("Events");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( BankSlipQueryResponse_externalReference == null )
            {
               BankSlipQueryResponse_externalReference = new APISantanderDll.Models.Responses.BankSlipQueryResponse();
            }
            return BankSlipQueryResponse_externalReference ;
         }

         set {
            BankSlipQueryResponse_externalReference = (APISantanderDll.Models.Responses.BankSlipQueryResponse)(value);
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

      protected APISantanderDll.Models.Responses.BankSlipQueryResponse BankSlipQueryResponse_externalReference=null ;
   }

}
