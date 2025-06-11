/*
				   File: type_SdtWPropostaData_Resumo
			Description: Resumo
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
	[XmlRoot(ElementName="WPropostaData.Resumo")]
	[XmlType(TypeName="WPropostaData.Resumo" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWPropostaData_Resumo : GxUserType
	{
		public SdtWPropostaData_Resumo( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPropostaData_Resumo_Propostadescricao = "";

			gxTv_SdtWPropostaData_Resumo_Clientepixtipo = "";

			gxTv_SdtWPropostaData_Resumo_Clientepix = "";

			gxTv_SdtWPropostaData_Resumo_Contaagencia = "";

			gxTv_SdtWPropostaData_Resumo_Contanumero = "";

			gxTv_SdtWPropostaData_Resumo_Responsavelclienterazaosocial = "";

			gxTv_SdtWPropostaData_Resumo_Responsavelclientedocumento = "";

			gxTv_SdtWPropostaData_Resumo_Responsavelcontatoemail = "";

			gxTv_SdtWPropostaData_Resumo_Clienterazaosocial = "";

			gxTv_SdtWPropostaData_Resumo_Clientedocumento = "";

			gxTv_SdtWPropostaData_Resumo_Contatoemail = "";

		}

		public SdtWPropostaData_Resumo(IGxContext context)
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
			AddObjectProperty("ProcedimentosMedicosId", gxTpr_Procedimentosmedicosid, false);


			AddObjectProperty("PropostaValor", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Propostavalor, 18, 2)), false);


			AddObjectProperty("PropostaDescricao", gxTpr_Propostadescricao, false);


			AddObjectProperty("ConvenioId", gxTpr_Convenioid, false);


			AddObjectProperty("ConvenioCategoriaId", gxTpr_Conveniocategoriaid, false);


			AddObjectProperty("ConvenioVencimentoAno", gxTpr_Conveniovencimentoano, false);


			AddObjectProperty("ConvenioVencimentoMes", gxTpr_Conveniovencimentomes, false);


			AddObjectProperty("ClientePixTipo", gxTpr_Clientepixtipo, false);


			AddObjectProperty("ClientePix", gxTpr_Clientepix, false);


			AddObjectProperty("BancoId", gxTpr_Bancoid, false);


			AddObjectProperty("ContaAgencia", gxTpr_Contaagencia, false);


			AddObjectProperty("ContaNumero", gxTpr_Contanumero, false);


			AddObjectProperty("ResponsavelClienteRazaoSocial", gxTpr_Responsavelclienterazaosocial, false);


			AddObjectProperty("ResponsavelClienteDocumento", gxTpr_Responsavelclientedocumento, false);


			AddObjectProperty("ResponsavelContatoEmail", gxTpr_Responsavelcontatoemail, false);


			AddObjectProperty("ClienteRazaoSocial", gxTpr_Clienterazaosocial, false);


			AddObjectProperty("ClienteDocumento", gxTpr_Clientedocumento, false);


			AddObjectProperty("ContatoEmail", gxTpr_Contatoemail, false);

			if (gxTv_SdtWPropostaData_Resumo_Griddocres != null)
			{
				AddObjectProperty("GridDocRes", gxTv_SdtWPropostaData_Resumo_Griddocres, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProcedimentosMedicosId")]
		[XmlElement(ElementName="ProcedimentosMedicosId")]
		public int gxTpr_Procedimentosmedicosid
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Procedimentosmedicosid; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Procedimentosmedicosid = value;
				SetDirty("Procedimentosmedicosid");
			}
		}



		[SoapElement(ElementName="PropostaValor")]
		[XmlElement(ElementName="PropostaValor")]
		public string gxTpr_Propostavalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtWPropostaData_Resumo_Propostavalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Propostavalor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Propostavalor
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Propostavalor; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Propostavalor = value;
				SetDirty("Propostavalor");
			}
		}




		[SoapElement(ElementName="PropostaDescricao")]
		[XmlElement(ElementName="PropostaDescricao")]
		public string gxTpr_Propostadescricao
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Propostadescricao; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Propostadescricao = value;
				SetDirty("Propostadescricao");
			}
		}




		[SoapElement(ElementName="ConvenioId")]
		[XmlElement(ElementName="ConvenioId")]
		public int gxTpr_Convenioid
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Convenioid; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Convenioid = value;
				SetDirty("Convenioid");
			}
		}




		[SoapElement(ElementName="ConvenioCategoriaId")]
		[XmlElement(ElementName="ConvenioCategoriaId")]
		public int gxTpr_Conveniocategoriaid
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Conveniocategoriaid; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Conveniocategoriaid = value;
				SetDirty("Conveniocategoriaid");
			}
		}




		[SoapElement(ElementName="ConvenioVencimentoAno")]
		[XmlElement(ElementName="ConvenioVencimentoAno")]
		public short gxTpr_Conveniovencimentoano
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Conveniovencimentoano; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Conveniovencimentoano = value;
				SetDirty("Conveniovencimentoano");
			}
		}




		[SoapElement(ElementName="ConvenioVencimentoMes")]
		[XmlElement(ElementName="ConvenioVencimentoMes")]
		public short gxTpr_Conveniovencimentomes
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Conveniovencimentomes; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Conveniovencimentomes = value;
				SetDirty("Conveniovencimentomes");
			}
		}




		[SoapElement(ElementName="ClientePixTipo")]
		[XmlElement(ElementName="ClientePixTipo")]
		public string gxTpr_Clientepixtipo
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Clientepixtipo; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Clientepixtipo = value;
				SetDirty("Clientepixtipo");
			}
		}




		[SoapElement(ElementName="ClientePix")]
		[XmlElement(ElementName="ClientePix")]
		public string gxTpr_Clientepix
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Clientepix; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Clientepix = value;
				SetDirty("Clientepix");
			}
		}




		[SoapElement(ElementName="BancoId")]
		[XmlElement(ElementName="BancoId")]
		public int gxTpr_Bancoid
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Bancoid; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Bancoid = value;
				SetDirty("Bancoid");
			}
		}




		[SoapElement(ElementName="ContaAgencia")]
		[XmlElement(ElementName="ContaAgencia")]
		public string gxTpr_Contaagencia
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Contaagencia; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Contaagencia = value;
				SetDirty("Contaagencia");
			}
		}




		[SoapElement(ElementName="ContaNumero")]
		[XmlElement(ElementName="ContaNumero")]
		public string gxTpr_Contanumero
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Contanumero; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Contanumero = value;
				SetDirty("Contanumero");
			}
		}




		[SoapElement(ElementName="ResponsavelClienteRazaoSocial")]
		[XmlElement(ElementName="ResponsavelClienteRazaoSocial")]
		public string gxTpr_Responsavelclienterazaosocial
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Responsavelclienterazaosocial; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Responsavelclienterazaosocial = value;
				SetDirty("Responsavelclienterazaosocial");
			}
		}




		[SoapElement(ElementName="ResponsavelClienteDocumento")]
		[XmlElement(ElementName="ResponsavelClienteDocumento")]
		public string gxTpr_Responsavelclientedocumento
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Responsavelclientedocumento; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Responsavelclientedocumento = value;
				SetDirty("Responsavelclientedocumento");
			}
		}




		[SoapElement(ElementName="ResponsavelContatoEmail")]
		[XmlElement(ElementName="ResponsavelContatoEmail")]
		public string gxTpr_Responsavelcontatoemail
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Responsavelcontatoemail; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Responsavelcontatoemail = value;
				SetDirty("Responsavelcontatoemail");
			}
		}




		[SoapElement(ElementName="ClienteRazaoSocial")]
		[XmlElement(ElementName="ClienteRazaoSocial")]
		public string gxTpr_Clienterazaosocial
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Clienterazaosocial; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Clienterazaosocial = value;
				SetDirty("Clienterazaosocial");
			}
		}




		[SoapElement(ElementName="ClienteDocumento")]
		[XmlElement(ElementName="ClienteDocumento")]
		public string gxTpr_Clientedocumento
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Clientedocumento; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Clientedocumento = value;
				SetDirty("Clientedocumento");
			}
		}




		[SoapElement(ElementName="ContatoEmail")]
		[XmlElement(ElementName="ContatoEmail")]
		public string gxTpr_Contatoemail
		{
			get {
				return gxTv_SdtWPropostaData_Resumo_Contatoemail; 
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Contatoemail = value;
				SetDirty("Contatoemail");
			}
		}




		[SoapElement(ElementName="GridDocRes" )]
		[XmlArray(ElementName="GridDocRes"  )]
		[XmlArrayItemAttribute(ElementName="GridDocResItem" , IsNullable=false )]
		public GXBaseCollection<SdtWPropostaData_Resumo_GridDocResItem> gxTpr_Griddocres
		{
			get {
				if ( gxTv_SdtWPropostaData_Resumo_Griddocres == null )
				{
					gxTv_SdtWPropostaData_Resumo_Griddocres = new GXBaseCollection<SdtWPropostaData_Resumo_GridDocResItem>( context, "WPropostaData.Resumo.GridDocResItem", "");
				}
				SetDirty("Griddocres");
				return gxTv_SdtWPropostaData_Resumo_Griddocres;
			}
			set {
				gxTv_SdtWPropostaData_Resumo_Griddocres_N = false;
				gxTv_SdtWPropostaData_Resumo_Griddocres = value;
				SetDirty("Griddocres");
			}
		}

		public void gxTv_SdtWPropostaData_Resumo_Griddocres_SetNull()
		{
			gxTv_SdtWPropostaData_Resumo_Griddocres_N = true;
			gxTv_SdtWPropostaData_Resumo_Griddocres = null;
		}

		public bool gxTv_SdtWPropostaData_Resumo_Griddocres_IsNull()
		{
			return gxTv_SdtWPropostaData_Resumo_Griddocres == null;
		}
		public bool ShouldSerializegxTpr_Griddocres_GxSimpleCollection_Json()
		{
			return gxTv_SdtWPropostaData_Resumo_Griddocres != null && gxTv_SdtWPropostaData_Resumo_Griddocres.Count > 0;

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
			gxTv_SdtWPropostaData_Resumo_Propostadescricao = "";




			gxTv_SdtWPropostaData_Resumo_Clientepixtipo = "";
			gxTv_SdtWPropostaData_Resumo_Clientepix = "";

			gxTv_SdtWPropostaData_Resumo_Contaagencia = "";
			gxTv_SdtWPropostaData_Resumo_Contanumero = "";
			gxTv_SdtWPropostaData_Resumo_Responsavelclienterazaosocial = "";
			gxTv_SdtWPropostaData_Resumo_Responsavelclientedocumento = "";
			gxTv_SdtWPropostaData_Resumo_Responsavelcontatoemail = "";
			gxTv_SdtWPropostaData_Resumo_Clienterazaosocial = "";
			gxTv_SdtWPropostaData_Resumo_Clientedocumento = "";
			gxTv_SdtWPropostaData_Resumo_Contatoemail = "";

			gxTv_SdtWPropostaData_Resumo_Griddocres_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtWPropostaData_Resumo_Procedimentosmedicosid;
		 

		protected decimal gxTv_SdtWPropostaData_Resumo_Propostavalor;
		 

		protected string gxTv_SdtWPropostaData_Resumo_Propostadescricao;
		 

		protected int gxTv_SdtWPropostaData_Resumo_Convenioid;
		 

		protected int gxTv_SdtWPropostaData_Resumo_Conveniocategoriaid;
		 

		protected short gxTv_SdtWPropostaData_Resumo_Conveniovencimentoano;
		 

		protected short gxTv_SdtWPropostaData_Resumo_Conveniovencimentomes;
		 

		protected string gxTv_SdtWPropostaData_Resumo_Clientepixtipo;
		 

		protected string gxTv_SdtWPropostaData_Resumo_Clientepix;
		 

		protected int gxTv_SdtWPropostaData_Resumo_Bancoid;
		 

		protected string gxTv_SdtWPropostaData_Resumo_Contaagencia;
		 

		protected string gxTv_SdtWPropostaData_Resumo_Contanumero;
		 

		protected string gxTv_SdtWPropostaData_Resumo_Responsavelclienterazaosocial;
		 

		protected string gxTv_SdtWPropostaData_Resumo_Responsavelclientedocumento;
		 

		protected string gxTv_SdtWPropostaData_Resumo_Responsavelcontatoemail;
		 

		protected string gxTv_SdtWPropostaData_Resumo_Clienterazaosocial;
		 

		protected string gxTv_SdtWPropostaData_Resumo_Clientedocumento;
		 

		protected string gxTv_SdtWPropostaData_Resumo_Contatoemail;
		 
		protected bool gxTv_SdtWPropostaData_Resumo_Griddocres_N;
		protected GXBaseCollection<SdtWPropostaData_Resumo_GridDocResItem> gxTv_SdtWPropostaData_Resumo_Griddocres = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WPropostaData.Resumo", Namespace="Factory21")]
	public class SdtWPropostaData_Resumo_RESTInterface : GxGenericCollectionItem<SdtWPropostaData_Resumo>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPropostaData_Resumo_RESTInterface( ) : base()
		{	
		}

		public SdtWPropostaData_Resumo_RESTInterface( SdtWPropostaData_Resumo psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("ProcedimentosMedicosId")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="ProcedimentosMedicosId", Order=0)]
		public  string gxTpr_Procedimentosmedicosid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Procedimentosmedicosid, 9, 0));

			}
			set { 
				sdt.gxTpr_Procedimentosmedicosid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("PropostaValor")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="PropostaValor", Order=1)]
		public  string gxTpr_Propostavalor
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Propostavalor, 18, 2));

			}
			set { 
				sdt.gxTpr_Propostavalor =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("PropostaDescricao")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="PropostaDescricao", Order=2)]
		public  string gxTpr_Propostadescricao
		{
			get { 
				return sdt.gxTpr_Propostadescricao;

			}
			set { 
				 sdt.gxTpr_Propostadescricao = value;
			}
		}

		[JsonPropertyName("ConvenioId")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="ConvenioId", Order=3)]
		public  string gxTpr_Convenioid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Convenioid, 9, 0));

			}
			set { 
				sdt.gxTpr_Convenioid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ConvenioCategoriaId")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="ConvenioCategoriaId", Order=4)]
		public  string gxTpr_Conveniocategoriaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Conveniocategoriaid, 9, 0));

			}
			set { 
				sdt.gxTpr_Conveniocategoriaid = (int) NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("ConvenioVencimentoAno")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="ConvenioVencimentoAno", Order=5)]
		public short gxTpr_Conveniovencimentoano
		{
			get { 
				return sdt.gxTpr_Conveniovencimentoano;

			}
			set { 
				sdt.gxTpr_Conveniovencimentoano = value;
			}
		}

		[JsonPropertyName("ConvenioVencimentoMes")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="ConvenioVencimentoMes", Order=6)]
		public short gxTpr_Conveniovencimentomes
		{
			get { 
				return sdt.gxTpr_Conveniovencimentomes;

			}
			set { 
				sdt.gxTpr_Conveniovencimentomes = value;
			}
		}

		[JsonPropertyName("ClientePixTipo")]
		[JsonPropertyOrder(7)]
		[DataMember(Name="ClientePixTipo", Order=7)]
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
		[JsonPropertyOrder(8)]
		[DataMember(Name="ClientePix", Order=8)]
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
		[JsonPropertyOrder(9)]
		[DataMember(Name="BancoId", Order=9)]
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
		[JsonPropertyOrder(10)]
		[DataMember(Name="ContaAgencia", Order=10)]
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
		[JsonPropertyOrder(11)]
		[DataMember(Name="ContaNumero", Order=11)]
		public  string gxTpr_Contanumero
		{
			get { 
				return sdt.gxTpr_Contanumero;

			}
			set { 
				 sdt.gxTpr_Contanumero = value;
			}
		}

		[JsonPropertyName("ResponsavelClienteRazaoSocial")]
		[JsonPropertyOrder(12)]
		[DataMember(Name="ResponsavelClienteRazaoSocial", Order=12)]
		public  string gxTpr_Responsavelclienterazaosocial
		{
			get { 
				return sdt.gxTpr_Responsavelclienterazaosocial;

			}
			set { 
				 sdt.gxTpr_Responsavelclienterazaosocial = value;
			}
		}

		[JsonPropertyName("ResponsavelClienteDocumento")]
		[JsonPropertyOrder(13)]
		[DataMember(Name="ResponsavelClienteDocumento", Order=13)]
		public  string gxTpr_Responsavelclientedocumento
		{
			get { 
				return sdt.gxTpr_Responsavelclientedocumento;

			}
			set { 
				 sdt.gxTpr_Responsavelclientedocumento = value;
			}
		}

		[JsonPropertyName("ResponsavelContatoEmail")]
		[JsonPropertyOrder(14)]
		[DataMember(Name="ResponsavelContatoEmail", Order=14)]
		public  string gxTpr_Responsavelcontatoemail
		{
			get { 
				return sdt.gxTpr_Responsavelcontatoemail;

			}
			set { 
				 sdt.gxTpr_Responsavelcontatoemail = value;
			}
		}

		[JsonPropertyName("ClienteRazaoSocial")]
		[JsonPropertyOrder(15)]
		[DataMember(Name="ClienteRazaoSocial", Order=15)]
		public  string gxTpr_Clienterazaosocial
		{
			get { 
				return sdt.gxTpr_Clienterazaosocial;

			}
			set { 
				 sdt.gxTpr_Clienterazaosocial = value;
			}
		}

		[JsonPropertyName("ClienteDocumento")]
		[JsonPropertyOrder(16)]
		[DataMember(Name="ClienteDocumento", Order=16)]
		public  string gxTpr_Clientedocumento
		{
			get { 
				return sdt.gxTpr_Clientedocumento;

			}
			set { 
				 sdt.gxTpr_Clientedocumento = value;
			}
		}

		[JsonPropertyName("ContatoEmail")]
		[JsonPropertyOrder(17)]
		[DataMember(Name="ContatoEmail", Order=17)]
		public  string gxTpr_Contatoemail
		{
			get { 
				return sdt.gxTpr_Contatoemail;

			}
			set { 
				 sdt.gxTpr_Contatoemail = value;
			}
		}

		[JsonPropertyName("GridDocRes")]
		[JsonPropertyOrder(18)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="GridDocRes", Order=18, EmitDefaultValue=false)]
		public GxGenericCollection<SdtWPropostaData_Resumo_GridDocResItem_RESTInterface> gxTpr_Griddocres
		{
			get {
				if (sdt.ShouldSerializegxTpr_Griddocres_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtWPropostaData_Resumo_GridDocResItem_RESTInterface>(sdt.gxTpr_Griddocres);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Griddocres);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWPropostaData_Resumo sdt
		{
			get { 
				return (SdtWPropostaData_Resumo)Sdt;
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
				sdt = new SdtWPropostaData_Resumo() ;
			}
		}
	}
	#endregion
}