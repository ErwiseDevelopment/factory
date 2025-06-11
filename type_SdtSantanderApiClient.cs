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
   public class SdtSantanderApiClient : GxUserType, IGxExternalObject
   {
      public SdtSantanderApiClient( )
      {
         /* Constructor for serialization */
      }

      public SdtSantanderApiClient( IGxContext context )
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

      public SdtTokenResponse gettoken( string gxTp_baseUrl ,
                                        string gxTp_clientId ,
                                        string gxTp_clientSecret ,
                                        string gxTp_certificatePath ,
                                        string gxTp_certificatePassword )
      {
         SdtTokenResponse returngettoken;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returngettoken = new SdtTokenResponse(context);
         APISantanderDll.Models.Responses.TokenResponse externalParm0;
         externalParm0 = SantanderApiClient_externalReference.GetToken(gxTp_baseUrl, gxTp_clientId, gxTp_clientSecret, gxTp_certificatePath, gxTp_certificatePassword);
         returngettoken.ExternalInstance = externalParm0;
         return returngettoken ;
      }

      public string getworkspacesraw( string gxTp_baseUrl ,
                                      string gxTp_clientId ,
                                      string gxTp_accessToken ,
                                      string gxTp_certificatePath ,
                                      string gxTp_certificatePassword )
      {
         string returngetworkspacesraw;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returngetworkspacesraw = "";
         returngetworkspacesraw = (string)(SantanderApiClient_externalReference.GetWorkspacesRaw(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword));
         return returngetworkspacesraw ;
      }

      public GXExternalCollection<SdtWorkspaceResponse> getworkspaces( string gxTp_baseUrl ,
                                                                       string gxTp_clientId ,
                                                                       string gxTp_accessToken ,
                                                                       string gxTp_certificatePath ,
                                                                       string gxTp_certificatePassword )
      {
         GXExternalCollection<SdtWorkspaceResponse> returngetworkspaces;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returngetworkspaces = new GXExternalCollection<SdtWorkspaceResponse>( context, "SdtWorkspaceResponse", "GeneXus.Programs");
         System.Collections.Generic.List< APISantanderDll.Models.Responses.WorkspaceResponse> externalParm0;
         externalParm0 = SantanderApiClient_externalReference.GetWorkspaces(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword);
         returngetworkspaces.ExternalInstance = (IList)CollectionUtils.ConvertToInternal( typeof(System.Collections.Generic.List< APISantanderDll.Models.Responses.WorkspaceResponse>), externalParm0);
         return returngetworkspaces ;
      }

      public SdtWorkspaceResponse createworkspace( string gxTp_baseUrl ,
                                                   string gxTp_clientId ,
                                                   string gxTp_accessToken ,
                                                   string gxTp_certificatePath ,
                                                   string gxTp_certificatePassword ,
                                                   SdtCreateWorkspaceRequest gxTp_request )
      {
         SdtWorkspaceResponse returncreateworkspace;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returncreateworkspace = new SdtWorkspaceResponse(context);
         APISantanderDll.Models.Responses.WorkspaceResponse externalParm0;
         APISantanderDll.Models.Requests.CreateWorkspaceRequest externalParm1;
         externalParm1 = (APISantanderDll.Models.Requests.CreateWorkspaceRequest)(gxTp_request.ExternalInstance);
         externalParm0 = SantanderApiClient_externalReference.CreateWorkspace(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword, externalParm1);
         returncreateworkspace.ExternalInstance = externalParm0;
         return returncreateworkspace ;
      }

      public SdtWorkspaceResponse getworkspacebyid( string gxTp_baseUrl ,
                                                    string gxTp_clientId ,
                                                    string gxTp_accessToken ,
                                                    string gxTp_certificatePath ,
                                                    string gxTp_certificatePassword ,
                                                    string gxTp_workspaceId )
      {
         SdtWorkspaceResponse returngetworkspacebyid;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returngetworkspacebyid = new SdtWorkspaceResponse(context);
         APISantanderDll.Models.Responses.WorkspaceResponse externalParm0;
         externalParm0 = SantanderApiClient_externalReference.GetWorkspaceById(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword, gxTp_workspaceId);
         returngetworkspacebyid.ExternalInstance = externalParm0;
         return returngetworkspacebyid ;
      }

      public SdtWorkspaceResponse updateworkspace( string gxTp_baseUrl ,
                                                   string gxTp_clientId ,
                                                   string gxTp_accessToken ,
                                                   string gxTp_certificatePath ,
                                                   string gxTp_certificatePassword ,
                                                   string gxTp_workspaceId ,
                                                   SdtUpdateWorkspaceRequest gxTp_request )
      {
         SdtWorkspaceResponse returnupdateworkspace;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returnupdateworkspace = new SdtWorkspaceResponse(context);
         APISantanderDll.Models.Responses.WorkspaceResponse externalParm0;
         APISantanderDll.Models.Requests.UpdateWorkspaceRequest externalParm1;
         externalParm1 = (APISantanderDll.Models.Requests.UpdateWorkspaceRequest)(gxTp_request.ExternalInstance);
         externalParm0 = SantanderApiClient_externalReference.UpdateWorkspace(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword, gxTp_workspaceId, externalParm1);
         returnupdateworkspace.ExternalInstance = externalParm0;
         return returnupdateworkspace ;
      }

      public bool deleteworkspace( string gxTp_baseUrl ,
                                   string gxTp_clientId ,
                                   string gxTp_accessToken ,
                                   string gxTp_certificatePath ,
                                   string gxTp_certificatePassword ,
                                   string gxTp_workspaceId )
      {
         bool returndeleteworkspace;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returndeleteworkspace = false;
         returndeleteworkspace = (bool)(SantanderApiClient_externalReference.DeleteWorkspace(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword, gxTp_workspaceId));
         return returndeleteworkspace ;
      }

      public SdtBankSlipResponse registerbankslip( string gxTp_baseUrl ,
                                                   string gxTp_clientId ,
                                                   string gxTp_accessToken ,
                                                   string gxTp_certificatePath ,
                                                   string gxTp_certificatePassword ,
                                                   string gxTp_workspaceId ,
                                                   SdtRegisterBankSlipRequest gxTp_request )
      {
         SdtBankSlipResponse returnregisterbankslip;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returnregisterbankslip = new SdtBankSlipResponse(context);
         APISantanderDll.Models.Responses.BankSlipResponse externalParm0;
         APISantanderDll.Models.Requests.RegisterBankSlipRequest externalParm1;
         externalParm1 = (APISantanderDll.Models.Requests.RegisterBankSlipRequest)(gxTp_request.ExternalInstance);
         externalParm0 = SantanderApiClient_externalReference.RegisterBankSlip(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword, gxTp_workspaceId, externalParm1);
         returnregisterbankslip.ExternalInstance = externalParm0;
         return returnregisterbankslip ;
      }

      public SdtInstructionResponse sendinstruction( string gxTp_baseUrl ,
                                                     string gxTp_clientId ,
                                                     string gxTp_accessToken ,
                                                     string gxTp_certificatePath ,
                                                     string gxTp_certificatePassword ,
                                                     string gxTp_workspaceId ,
                                                     SdtInstructionRequest gxTp_request )
      {
         SdtInstructionResponse returnsendinstruction;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returnsendinstruction = new SdtInstructionResponse(context);
         APISantanderDll.Models.Responses.InstructionResponse externalParm0;
         APISantanderDll.Models.Requests.InstructionRequest externalParm1;
         externalParm1 = (APISantanderDll.Models.Requests.InstructionRequest)(gxTp_request.ExternalInstance);
         externalParm0 = SantanderApiClient_externalReference.SendInstruction(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword, gxTp_workspaceId, externalParm1);
         returnsendinstruction.ExternalInstance = externalParm0;
         return returnsendinstruction ;
      }

      public SdtBankSlipQueryResponse querybankslip( string gxTp_baseUrl ,
                                                     string gxTp_clientId ,
                                                     string gxTp_accessToken ,
                                                     string gxTp_certificatePath ,
                                                     string gxTp_certificatePassword ,
                                                     string gxTp_workspaceId ,
                                                     string gxTp_bankSlipId )
      {
         SdtBankSlipQueryResponse returnquerybankslip;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returnquerybankslip = new SdtBankSlipQueryResponse(context);
         APISantanderDll.Models.Responses.BankSlipQueryResponse externalParm0;
         externalParm0 = SantanderApiClient_externalReference.QueryBankSlip(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword, gxTp_workspaceId, gxTp_bankSlipId);
         returnquerybankslip.ExternalInstance = externalParm0;
         return returnquerybankslip ;
      }

      public SdtDetailedQueryResponse querybybeneficiaryandbanknumber( string gxTp_baseUrl ,
                                                                       string gxTp_clientId ,
                                                                       string gxTp_accessToken ,
                                                                       string gxTp_certificatePath ,
                                                                       string gxTp_certificatePassword ,
                                                                       string gxTp_beneficiaryCode ,
                                                                       string gxTp_bankNumber )
      {
         SdtDetailedQueryResponse returnquerybybeneficiaryandbanknumber;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returnquerybybeneficiaryandbanknumber = new SdtDetailedQueryResponse(context);
         APISantanderDll.Models.Responses.DetailedQueryResponse externalParm0;
         externalParm0 = SantanderApiClient_externalReference.QueryByBeneficiaryAndBankNumber(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword, gxTp_beneficiaryCode, gxTp_bankNumber);
         returnquerybybeneficiaryandbanknumber.ExternalInstance = externalParm0;
         return returnquerybybeneficiaryandbanknumber ;
      }

      public SdtDetailedQueryResponse querywithfilters( string gxTp_baseUrl ,
                                                        string gxTp_clientId ,
                                                        string gxTp_accessToken ,
                                                        string gxTp_certificatePath ,
                                                        string gxTp_certificatePassword ,
                                                        string gxTp_beneficiaryCode ,
                                                        string gxTp_bankNumber ,
                                                        string gxTp_dueDate ,
                                                        decimal gxTp_nominalValue )
      {
         SdtDetailedQueryResponse returnquerywithfilters;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returnquerywithfilters = new SdtDetailedQueryResponse(context);
         APISantanderDll.Models.Responses.DetailedQueryResponse externalParm0;
         externalParm0 = SantanderApiClient_externalReference.QueryWithFilters(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword, gxTp_beneficiaryCode, gxTp_bankNumber, gxTp_dueDate, gxTp_nominalValue);
         returnquerywithfilters.ExternalInstance = externalParm0;
         return returnquerywithfilters ;
      }

      public SdtDetailedQueryResponse querybankslips( string gxTp_baseUrl ,
                                                      string gxTp_clientId ,
                                                      string gxTp_accessToken ,
                                                      string gxTp_certificatePath ,
                                                      string gxTp_certificatePassword ,
                                                      string gxTp_billId )
      {
         SdtDetailedQueryResponse returnquerybankslips;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returnquerybankslips = new SdtDetailedQueryResponse(context);
         APISantanderDll.Models.Responses.DetailedQueryResponse externalParm0;
         externalParm0 = SantanderApiClient_externalReference.QueryBankSlips(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword, gxTp_billId);
         returnquerybankslips.ExternalInstance = externalParm0;
         return returnquerybankslips ;
      }

      public SdtDetailedQueryResponse querydefault( string gxTp_baseUrl ,
                                                    string gxTp_clientId ,
                                                    string gxTp_accessToken ,
                                                    string gxTp_certificatePath ,
                                                    string gxTp_certificatePassword ,
                                                    string gxTp_billId )
      {
         SdtDetailedQueryResponse returnquerydefault;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returnquerydefault = new SdtDetailedQueryResponse(context);
         APISantanderDll.Models.Responses.DetailedQueryResponse externalParm0;
         externalParm0 = SantanderApiClient_externalReference.QueryDefault(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword, gxTp_billId);
         returnquerydefault.ExternalInstance = externalParm0;
         return returnquerydefault ;
      }

      public SdtDetailedQueryResponse queryduplicate( string gxTp_baseUrl ,
                                                      string gxTp_clientId ,
                                                      string gxTp_accessToken ,
                                                      string gxTp_certificatePath ,
                                                      string gxTp_certificatePassword ,
                                                      string gxTp_billId )
      {
         SdtDetailedQueryResponse returnqueryduplicate;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returnqueryduplicate = new SdtDetailedQueryResponse(context);
         APISantanderDll.Models.Responses.DetailedQueryResponse externalParm0;
         externalParm0 = SantanderApiClient_externalReference.QueryDuplicate(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword, gxTp_billId);
         returnqueryduplicate.ExternalInstance = externalParm0;
         return returnqueryduplicate ;
      }

      public SdtDetailedQueryResponse queryregistry( string gxTp_baseUrl ,
                                                     string gxTp_clientId ,
                                                     string gxTp_accessToken ,
                                                     string gxTp_certificatePath ,
                                                     string gxTp_certificatePassword ,
                                                     string gxTp_billId )
      {
         SdtDetailedQueryResponse returnqueryregistry;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returnqueryregistry = new SdtDetailedQueryResponse(context);
         APISantanderDll.Models.Responses.DetailedQueryResponse externalParm0;
         externalParm0 = SantanderApiClient_externalReference.QueryRegistry(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword, gxTp_billId);
         returnqueryregistry.ExternalInstance = externalParm0;
         return returnqueryregistry ;
      }

      public SdtDetailedQueryResponse querysettlement( string gxTp_baseUrl ,
                                                       string gxTp_clientId ,
                                                       string gxTp_accessToken ,
                                                       string gxTp_certificatePath ,
                                                       string gxTp_certificatePassword ,
                                                       string gxTp_billId )
      {
         SdtDetailedQueryResponse returnquerysettlement;
         if ( SantanderApiClient_externalReference == null )
         {
            SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
         }
         returnquerysettlement = new SdtDetailedQueryResponse(context);
         APISantanderDll.Models.Responses.DetailedQueryResponse externalParm0;
         externalParm0 = SantanderApiClient_externalReference.QuerySettlement(gxTp_baseUrl, gxTp_clientId, gxTp_accessToken, gxTp_certificatePath, gxTp_certificatePassword, gxTp_billId);
         returnquerysettlement.ExternalInstance = externalParm0;
         return returnquerysettlement ;
      }

      public Object ExternalInstance
      {
         get {
            if ( SantanderApiClient_externalReference == null )
            {
               SantanderApiClient_externalReference = new APISantanderDll.Client.SantanderApiClient();
            }
            return SantanderApiClient_externalReference ;
         }

         set {
            SantanderApiClient_externalReference = (APISantanderDll.Client.SantanderApiClient)(value);
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

      protected APISantanderDll.Client.SantanderApiClient SantanderApiClient_externalReference=null ;
   }

}
