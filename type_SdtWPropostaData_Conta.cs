/*
				   File: type_SdtWPropostaData_Conta
			Description: Conta
				 Author: Nemo 🐠 for C# (.NET) version 18.0.12.186073
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="WPropostaData.Conta")]
	[XmlType(TypeName="WPropostaData.Conta" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWPropostaData_Conta : GxUserType
	{
		public SdtWPropostaData_Conta( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPropostaData_Conta_Clientedepositotipo = "";

			gxTv_SdtWPropostaData_Conta_Clientepixtipo = "";

			gxTv_SdtWPropostaData_Conta_Clientepix = "";

			gxTv_SdtWPropostaData_Conta_Contaagencia = "";

			gxTv_SdtWPropostaData_Conta_Contanumero = "";

		}

		public SdtWPropostaData_Conta(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("ClienteDepositoTipo", gxTpr_Clientedepositotipo, false);


			AddObjectProperty("ClientePixTipo", gxTpr_Clientepixtipo, false);


			AddObjectProperty("ClientePix", gxTpr_Clientepix, false);


			AddObjectProperty("BancoId", gxTpr_Bancoid, false);


			AddObjectProperty("ContaAgencia", gxTpr_Contaagencia, false);


			AddObjectProperty("ContaNumero", gxTpr_Contanumero, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ClienteDepositoTipo")]
		[XmlElement(ElementName="ClienteDepositoTipo")]
		public string gxTpr_Clientedepositotipo
		{
			get {
				return gxTv_SdtWPropostaData_Conta_Clientedepositotipo; 
			}
			set {
				gxTv_SdtWPropostaData_Conta_Clientedepositotipo = value;
				SetDirty("Clientedepositotipo");
			}
		}




		[SoapElement(ElementName="ClientePixTipo")]
		[XmlElement(ElementName="ClientePixTipo")]
		public string gxTpr_Clientepixtipo
		{
			get {
				return gxTv_SdtWPropostaData_Conta_Clientepixtipo; 
			}
			set {
				gxTv_SdtWPropostaData_Conta_Clientepixtipo = value;
				SetDirty("Clientepixtipo");
			}
		}




		[SoapElement(ElementName="ClientePix")]
		[XmlElement(ElementName="ClientePix")]
		public string gxTpr_Clientepix
		{
			get {
				return gxTv_SdtWPropostaData_Conta_Clientepix; 
			}
			set {
				gxTv_SdtWPropostaData_Conta_Clientepix = value;
				SetDirty("Clientepix");
			}
		}




		[SoapElement(ElementName="BancoId")]
		[XmlElement(ElementName="BancoId")]
		public int gxTpr_Bancoid
		{
			get {
				return gxTv_SdtWPropostaData_Conta_Bancoid; 
			}
			set {
				gxTv_SdtWPropostaData_Conta_Bancoid = value;
				SetDirty("Bancoid");
			}
		}




		[SoapElement(ElementName="ContaAgencia")]
		[XmlElement(ElementName="ContaAgencia")]
		public string gxTpr_Contaagencia
		{
			get {
				return gxTv_SdtWPropostaData_Conta_Contaagencia; 
			}
			set {
				gxTv_SdtWPropostaData_Conta_Contaagencia = value;
				SetDirty("Contaagencia");
			}
		}




		[SoapElement(ElementName="ContaNumero")]
		[XmlElement(ElementName="ContaNumero")]
		public string gxTpr_Contanumero
		{
			get {
				return gxTv_SdtWPropostaData_Conta_Contanumero; 
			}
			set {
				gxTv_SdtWPropostaData_Conta_Contanumero = value;
				SetDirty("Contanumero");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWPropostaData_Conta_Clientedepositotipo = "";
			gxTv_SdtWPropostaData_Conta_Clientepixtipo = "";
			gxTv_SdtWPropostaData_Conta_Clientepix = "";

			gxTv_SdtWPropostaData_Conta_Contaagencia = "";
			gxTv_SdtWPropostaData_Conta_Contanumero = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWPropostaData_Conta_Clientedepositotipo;
		 

		protected string gxTv_SdtWPropostaData_Conta_Clientepixtipo;
		 

		protected string gxTv_SdtWPropostaData_Conta_Clientepix;
		 

		protected int gxTv_SdtWPropostaData_Conta_Bancoid;
		 

		protected string gxTv_SdtWPropostaData_Conta_Contaagencia;
		 

		protected string gxTv_SdtWPropostaData_Conta_Contanumero;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WPropostaData.Conta", Namespace="Factory21")]
	public class SdtWPropostaData_Conta_RESTInterface : GxGenericCollectionItem<SdtWPropostaData_Conta>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPropostaData_Conta_RESTInterface( ) : base()
		{	
		}

		public SdtWPropostaData_Conta_RESTInterface( SdtWPropostaData_Conta psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ClienteDepositoTipo")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="ClienteDepositoTipo", Order=0)]
		public  string gxTpr_Clientedepositotipo
		{
			get { 
				return sdt.gxTpr_Clientedepositotipo;

			}
			set { 
				 sdt.gxTpr_Clientedepositotipo = value;
			}
		}

		[JsonPropertyName("ClientePixTipo")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="ClientePixTipo", Order=1)]
		public  string gxTpr_Clientepixtipo
		{
			get { 
				return sdt.gxTpr_Clientepixtipo;

			}
			set { 
				 sdt.gxTpr_Clientepixtipo = value;
			}
		}

		[JsonPropertyName("ClientePix")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="ClientePix", Order=2)]
		public  string gxTpr_Clientepix
		{
			get { 
				return sdt.gxTpr_Clientepix;

			}
			set { 
				 sdt.gxTpr_Clientepix = value;
			}
		}

		[JsonPropertyName("BancoId")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="BancoId", Order=3)]
		public  string gxTpr_Bancoid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Bancoid, 9, 0));

			}
			set { 
				sdt.gxTpr_Bancoid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ContaAgencia")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="ContaAgencia", Order=4)]
		public  string gxTpr_Contaagencia
		{
			get { 
				return sdt.gxTpr_Contaagencia;

			}
			set { 
				 sdt.gxTpr_Contaagencia = value;
			}
		}

		[JsonPropertyName("ContaNumero")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="ContaNumero", Order=5)]
		public  string gxTpr_Contanumero
		{
			get { 
				return sdt.gxTpr_Contanumero;

			}
			set { 
				 sdt.gxTpr_Contanumero = value;
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWPropostaData_Conta sdt
		{
			get { 
				return (SdtWPropostaData_Conta)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtWPropostaData_Conta() ;
			}
		}
	}
	#endregion
}