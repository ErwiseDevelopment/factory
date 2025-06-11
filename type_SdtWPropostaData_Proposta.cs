/*
				   File: type_SdtWPropostaData_Proposta
			Description: Proposta
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
	[XmlRoot(ElementName="WPropostaData.Proposta")]
	[XmlType(TypeName="WPropostaData.Proposta" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWPropostaData_Proposta : GxUserType
	{
		public SdtWPropostaData_Proposta( )
		{
			/* Constructor for serialization */
			gxTv_SdtWPropostaData_Proposta_Propostadescricao = "";


		}

		public SdtWPropostaData_Proposta(IGxContext context)
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

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProcedimentosMedicosId")]
		[XmlElement(ElementName="ProcedimentosMedicosId")]
		public int gxTpr_Procedimentosmedicosid
		{
			get {
				return gxTv_SdtWPropostaData_Proposta_Procedimentosmedicosid; 
			}
			set {
				gxTv_SdtWPropostaData_Proposta_Procedimentosmedicosid = value;
				SetDirty("Procedimentosmedicosid");
			}
		}



		[SoapElement(ElementName="PropostaValor")]
		[XmlElement(ElementName="PropostaValor")]
		public string gxTpr_Propostavalor_double
		{
			get {
				return Convert.ToString(gxTv_SdtWPropostaData_Proposta_Propostavalor, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWPropostaData_Proposta_Propostavalor = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Propostavalor
		{
			get {
				return gxTv_SdtWPropostaData_Proposta_Propostavalor; 
			}
			set {
				gxTv_SdtWPropostaData_Proposta_Propostavalor = value;
				SetDirty("Propostavalor");
			}
		}




		[SoapElement(ElementName="PropostaDescricao")]
		[XmlElement(ElementName="PropostaDescricao")]
		public string gxTpr_Propostadescricao
		{
			get {
				return gxTv_SdtWPropostaData_Proposta_Propostadescricao; 
			}
			set {
				gxTv_SdtWPropostaData_Proposta_Propostadescricao = value;
				SetDirty("Propostadescricao");
			}
		}




		[SoapElement(ElementName="ConvenioId")]
		[XmlElement(ElementName="ConvenioId")]
		public int gxTpr_Convenioid
		{
			get {
				return gxTv_SdtWPropostaData_Proposta_Convenioid; 
			}
			set {
				gxTv_SdtWPropostaData_Proposta_Convenioid = value;
				SetDirty("Convenioid");
			}
		}




		[SoapElement(ElementName="ConvenioCategoriaId")]
		[XmlElement(ElementName="ConvenioCategoriaId")]
		public int gxTpr_Conveniocategoriaid
		{
			get {
				return gxTv_SdtWPropostaData_Proposta_Conveniocategoriaid; 
			}
			set {
				gxTv_SdtWPropostaData_Proposta_Conveniocategoriaid = value;
				SetDirty("Conveniocategoriaid");
			}
		}




		[SoapElement(ElementName="ConvenioVencimentoAno")]
		[XmlElement(ElementName="ConvenioVencimentoAno")]
		public short gxTpr_Conveniovencimentoano
		{
			get {
				return gxTv_SdtWPropostaData_Proposta_Conveniovencimentoano; 
			}
			set {
				gxTv_SdtWPropostaData_Proposta_Conveniovencimentoano = value;
				SetDirty("Conveniovencimentoano");
			}
		}




		[SoapElement(ElementName="ConvenioVencimentoMes")]
		[XmlElement(ElementName="ConvenioVencimentoMes")]
		public short gxTpr_Conveniovencimentomes
		{
			get {
				return gxTv_SdtWPropostaData_Proposta_Conveniovencimentomes; 
			}
			set {
				gxTv_SdtWPropostaData_Proposta_Conveniovencimentomes = value;
				SetDirty("Conveniovencimentomes");
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
			gxTv_SdtWPropostaData_Proposta_Propostadescricao = "";




			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtWPropostaData_Proposta_Procedimentosmedicosid;
		 

		protected decimal gxTv_SdtWPropostaData_Proposta_Propostavalor;
		 

		protected string gxTv_SdtWPropostaData_Proposta_Propostadescricao;
		 

		protected int gxTv_SdtWPropostaData_Proposta_Convenioid;
		 

		protected int gxTv_SdtWPropostaData_Proposta_Conveniocategoriaid;
		 

		protected short gxTv_SdtWPropostaData_Proposta_Conveniovencimentoano;
		 

		protected short gxTv_SdtWPropostaData_Proposta_Conveniovencimentomes;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WPropostaData.Proposta", Namespace="Factory21")]
	public class SdtWPropostaData_Proposta_RESTInterface : GxGenericCollectionItem<SdtWPropostaData_Proposta>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWPropostaData_Proposta_RESTInterface( ) : base()
		{	
		}

		public SdtWPropostaData_Proposta_RESTInterface( SdtWPropostaData_Proposta psdt ) : base(psdt)
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


		#endregion
		[JsonIgnore]
		public SdtWPropostaData_Proposta sdt
		{
			get { 
				return (SdtWPropostaData_Proposta)Sdt;
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
				sdt = new SdtWPropostaData_Proposta() ;
			}
		}
	}
	#endregion
}