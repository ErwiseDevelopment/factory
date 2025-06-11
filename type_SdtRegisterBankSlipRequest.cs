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
   public class SdtRegisterBankSlipRequest : GxUserType, IGxExternalObject
   {
      public SdtRegisterBankSlipRequest( )
      {
         /* Constructor for serialization */
      }

      public SdtRegisterBankSlipRequest( IGxContext context )
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

      public string gxTpr_Environment
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference.Environment ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            RegisterBankSlipRequest_externalReference.Environment = value;
            SetDirty("Environment");
         }

      }

      public int gxTpr_Nsucode
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference.NsuCode ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            RegisterBankSlipRequest_externalReference.NsuCode = value;
            SetDirty("Nsucode");
         }

      }

      public string gxTpr_Nsudate
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference.NsuDate ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            RegisterBankSlipRequest_externalReference.NsuDate = value;
            SetDirty("Nsudate");
         }

      }

      public int gxTpr_Covenantcode
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference.CovenantCode ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            RegisterBankSlipRequest_externalReference.CovenantCode = value;
            SetDirty("Covenantcode");
         }

      }

      public string gxTpr_Banknumber
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference.BankNumber ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            RegisterBankSlipRequest_externalReference.BankNumber = value;
            SetDirty("Banknumber");
         }

      }

      public string gxTpr_Clientnumber
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference.ClientNumber ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            RegisterBankSlipRequest_externalReference.ClientNumber = value;
            SetDirty("Clientnumber");
         }

      }

      public string gxTpr_Duedate
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference.DueDate ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            RegisterBankSlipRequest_externalReference.DueDate = value;
            SetDirty("Duedate");
         }

      }

      public string gxTpr_Issuedate
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference.IssueDate ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            RegisterBankSlipRequest_externalReference.IssueDate = value;
            SetDirty("Issuedate");
         }

      }

      public string gxTpr_Participantcode
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference.ParticipantCode ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            RegisterBankSlipRequest_externalReference.ParticipantCode = value;
            SetDirty("Participantcode");
         }

      }

      public decimal gxTpr_Nominalvalue
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference.NominalValue ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            RegisterBankSlipRequest_externalReference.NominalValue = value;
            SetDirty("Nominalvalue");
         }

      }

      public SdtPayer gxTpr_Payer
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            SdtPayer intValue;
            intValue = new SdtPayer(context);
            APISantanderDll.Models.Requests.Payer externalParm0;
            externalParm0 = RegisterBankSlipRequest_externalReference.Payer;
            intValue.ExternalInstance = externalParm0;
            return intValue ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            SdtPayer intValue;
            APISantanderDll.Models.Requests.Payer externalParm1;
            intValue = value;
            externalParm1 = (APISantanderDll.Models.Requests.Payer)(intValue.ExternalInstance);
            RegisterBankSlipRequest_externalReference.Payer = externalParm1;
            SetDirty("Payer");
         }

      }

      public SdtBeneficiary gxTpr_Beneficiary
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            SdtBeneficiary intValue;
            intValue = new SdtBeneficiary(context);
            APISantanderDll.Models.Requests.Beneficiary externalParm2;
            externalParm2 = RegisterBankSlipRequest_externalReference.Beneficiary;
            intValue.ExternalInstance = externalParm2;
            return intValue ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            SdtBeneficiary intValue;
            APISantanderDll.Models.Requests.Beneficiary externalParm3;
            intValue = value;
            externalParm3 = (APISantanderDll.Models.Requests.Beneficiary)(intValue.ExternalInstance);
            RegisterBankSlipRequest_externalReference.Beneficiary = externalParm3;
            SetDirty("Beneficiary");
         }

      }

      public string gxTpr_Documentkind
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference.DocumentKind ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            RegisterBankSlipRequest_externalReference.DocumentKind = value;
            SetDirty("Documentkind");
         }

      }

      public string gxTpr_Deductionvalue
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference.DeductionValue ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            RegisterBankSlipRequest_externalReference.DeductionValue = value;
            SetDirty("Deductionvalue");
         }

      }

      public string gxTpr_Paymenttype
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference.PaymentType ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            RegisterBankSlipRequest_externalReference.PaymentType = value;
            SetDirty("Paymenttype");
         }

      }

      public string gxTpr_Writeoffquantitydays
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference.WriteOffQuantityDays ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            RegisterBankSlipRequest_externalReference.WriteOffQuantityDays = value;
            SetDirty("Writeoffquantitydays");
         }

      }

      public GxSimpleCollection<string> gxTpr_Messages
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            GxSimpleCollection<string> intValue;
            intValue = new GxSimpleCollection<string>();
            System.Collections.Generic.List< System.String> externalParm4;
            externalParm4 = RegisterBankSlipRequest_externalReference.Messages;
            intValue.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< System.String>), externalParm4);
            return intValue ;
         }

         set {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            GxSimpleCollection<string> intValue;
            System.Collections.Generic.List< System.String> externalParm5;
            intValue = value;
            externalParm5 = (System.Collections.Generic.List< System.String>)CollectionUtils.ConvertToExternal( typeof(System.Collections.Generic.List< System.String>), intValue.ExternalInstance);
            RegisterBankSlipRequest_externalReference.Messages = externalParm5;
            SetDirty("Messages");
         }

      }

      public Object ExternalInstance
      {
         get {
            if ( RegisterBankSlipRequest_externalReference == null )
            {
               RegisterBankSlipRequest_externalReference = new APISantanderDll.Models.Requests.RegisterBankSlipRequest();
            }
            return RegisterBankSlipRequest_externalReference ;
         }

         set {
            RegisterBankSlipRequest_externalReference = (APISantanderDll.Models.Requests.RegisterBankSlipRequest)(value);
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

      protected APISantanderDll.Models.Requests.RegisterBankSlipRequest RegisterBankSlipRequest_externalReference=null ;
   }

}
