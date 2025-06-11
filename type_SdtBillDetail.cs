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
   public class SdtBillDetail : GxUserType, IGxExternalObject
   {
      public SdtBillDetail( )
      {
         /* Constructor for serialization */
      }

      public SdtBillDetail( IGxContext context )
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
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            return BillDetail_externalReference.Id ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            BillDetail_externalReference.Id = value;
            SetDirty("Id");
         }

      }

      public string gxTpr_Banknumber
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            return BillDetail_externalReference.BankNumber ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            BillDetail_externalReference.BankNumber = value;
            SetDirty("Banknumber");
         }

      }

      public string gxTpr_Beneficiarycode
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            return BillDetail_externalReference.BeneficiaryCode ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            BillDetail_externalReference.BeneficiaryCode = value;
            SetDirty("Beneficiarycode");
         }

      }

      public string gxTpr_Status
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            return BillDetail_externalReference.Status ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            BillDetail_externalReference.Status = value;
            SetDirty("Status");
         }

      }

      public decimal gxTpr_Nominalvalue
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            return BillDetail_externalReference.NominalValue ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            BillDetail_externalReference.NominalValue = value;
            SetDirty("Nominalvalue");
         }

      }

      public decimal gxTpr_Paidvalue
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            return BillDetail_externalReference.PaidValue ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            BillDetail_externalReference.PaidValue = value;
            SetDirty("Paidvalue");
         }

      }

      public string gxTpr_Duedate
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            return BillDetail_externalReference.DueDate ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            BillDetail_externalReference.DueDate = value;
            SetDirty("Duedate");
         }

      }

      public string gxTpr_Paymentdate
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            return BillDetail_externalReference.PaymentDate ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            BillDetail_externalReference.PaymentDate = value;
            SetDirty("Paymentdate");
         }

      }

      public string gxTpr_Issuedate
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            return BillDetail_externalReference.IssueDate ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            BillDetail_externalReference.IssueDate = value;
            SetDirty("Issuedate");
         }

      }

      public SdtPayer gxTpr_Payer
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            SdtPayer intValue;
            intValue = new SdtPayer(context);
            APISantanderDll.Models.Requests.Payer externalParm0;
            externalParm0 = BillDetail_externalReference.Payer;
            intValue.ExternalInstance = externalParm0;
            return intValue ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            SdtPayer intValue;
            APISantanderDll.Models.Requests.Payer externalParm1;
            intValue = value;
            externalParm1 = (APISantanderDll.Models.Requests.Payer)(intValue.ExternalInstance);
            BillDetail_externalReference.Payer = externalParm1;
            SetDirty("Payer");
         }

      }

      public SdtBeneficiary gxTpr_Beneficiary
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            SdtBeneficiary intValue;
            intValue = new SdtBeneficiary(context);
            APISantanderDll.Models.Requests.Beneficiary externalParm2;
            externalParm2 = BillDetail_externalReference.Beneficiary;
            intValue.ExternalInstance = externalParm2;
            return intValue ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            SdtBeneficiary intValue;
            APISantanderDll.Models.Requests.Beneficiary externalParm3;
            intValue = value;
            externalParm3 = (APISantanderDll.Models.Requests.Beneficiary)(intValue.ExternalInstance);
            BillDetail_externalReference.Beneficiary = externalParm3;
            SetDirty("Beneficiary");
         }

      }

      public GXExternalCollection<SdtBankSlipEvent> gxTpr_Events
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            GXExternalCollection<SdtBankSlipEvent> intValue;
            intValue = new GXExternalCollection<SdtBankSlipEvent>( context, "SdtBankSlipEvent", "GeneXus.Programs");
            System.Collections.Generic.List< APISantanderDll.Models.Responses.BankSlipEvent> externalParm4;
            externalParm4 = BillDetail_externalReference.Events;
            intValue.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Responses.BankSlipEvent>), externalParm4);
            return intValue ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            GXExternalCollection<SdtBankSlipEvent> intValue;
            System.Collections.Generic.List< APISantanderDll.Models.Responses.BankSlipEvent> externalParm5;
            intValue = value;
            externalParm5 = (System.Collections.Generic.List< APISantanderDll.Models.Responses.BankSlipEvent>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Responses.BankSlipEvent>), intValue.ExternalInstance);
            BillDetail_externalReference.Events = externalParm5;
            SetDirty("Events");
         }

      }

      public SdtBankSlipDetails gxTpr_Bankslipdetails
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            SdtBankSlipDetails intValue;
            intValue = new SdtBankSlipDetails(context);
            APISantanderDll.Models.Responses.BankSlipDetails externalParm6;
            externalParm6 = BillDetail_externalReference.BankSlipDetails;
            intValue.ExternalInstance = externalParm6;
            return intValue ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            SdtBankSlipDetails intValue;
            APISantanderDll.Models.Responses.BankSlipDetails externalParm7;
            intValue = value;
            externalParm7 = (APISantanderDll.Models.Responses.BankSlipDetails)(intValue.ExternalInstance);
            BillDetail_externalReference.BankSlipDetails = externalParm7;
            SetDirty("Bankslipdetails");
         }

      }

      public SdtRegistryDetails gxTpr_Registrydetails
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            SdtRegistryDetails intValue;
            intValue = new SdtRegistryDetails(context);
            APISantanderDll.Models.Responses.RegistryDetails externalParm8;
            externalParm8 = BillDetail_externalReference.RegistryDetails;
            intValue.ExternalInstance = externalParm8;
            return intValue ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            SdtRegistryDetails intValue;
            APISantanderDll.Models.Responses.RegistryDetails externalParm9;
            intValue = value;
            externalParm9 = (APISantanderDll.Models.Responses.RegistryDetails)(intValue.ExternalInstance);
            BillDetail_externalReference.RegistryDetails = externalParm9;
            SetDirty("Registrydetails");
         }

      }

      public SdtSettlementDetails gxTpr_Settlementdetails
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            SdtSettlementDetails intValue;
            intValue = new SdtSettlementDetails(context);
            APISantanderDll.Models.Responses.SettlementDetails externalParm10;
            externalParm10 = BillDetail_externalReference.SettlementDetails;
            intValue.ExternalInstance = externalParm10;
            return intValue ;
         }

         set {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            SdtSettlementDetails intValue;
            APISantanderDll.Models.Responses.SettlementDetails externalParm11;
            intValue = value;
            externalParm11 = (APISantanderDll.Models.Responses.SettlementDetails)(intValue.ExternalInstance);
            BillDetail_externalReference.SettlementDetails = externalParm11;
            SetDirty("Settlementdetails");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( BillDetail_externalReference == null )
            {
               BillDetail_externalReference = new APISantanderDll.Models.Responses.BillDetail();
            }
            return BillDetail_externalReference ;
         }

         set {
            BillDetail_externalReference = (APISantanderDll.Models.Responses.BillDetail)(value);
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

      protected APISantanderDll.Models.Responses.BillDetail BillDetail_externalReference=null ;
   }

}
