/*
				   File: type_SdtSdListaNotaFiscalVenda
			Description: SdListaNotaFiscalVenda
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
	[XmlRoot(ElementName="SdListaNotaFiscalVenda")]
	[XmlType(TypeName="SdListaNotaFiscalVenda" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdListaNotaFiscalVenda : GxUserType
	{
		public SdtSdListaNotaFiscalVenda( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdListaNotaFiscalVenda_Notafiscal = "";

			gxTv_SdtSdListaNotaFiscalVenda_Codigo = "";

			gxTv_SdtSdListaNotaFiscalVenda_Descricao = "";

			gxTv_SdtSdListaNotaFiscalVenda_Quantidade = "";


		}

		public SdtSdListaNotaFiscalVenda(IGxContext context)
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
			AddObjectProperty("NotaFiscal", gxTpr_Notafiscal, false);


			AddObjectProperty("Codigo", gxTpr_Codigo, false);


			AddObjectProperty("Descricao", gxTpr_Descricao, false);


			AddObjectProperty("Quantidade", gxTpr_Quantidade, false);


			AddObjectProperty("ValorUnitario", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Valorunitario, 18, 2)), false);


			AddObjectProperty("Total", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Total, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="NotaFiscal")]
		[XmlElement(ElementName="NotaFiscal")]
		public string gxTpr_Notafiscal
		{
			get {
				return gxTv_SdtSdListaNotaFiscalVenda_Notafiscal; 
			}
			set {
				gxTv_SdtSdListaNotaFiscalVenda_Notafiscal = value;
				SetDirty("Notafiscal");
			}
		}




		[SoapElement(ElementName="Codigo")]
		[XmlElement(ElementName="Codigo")]
		public string gxTpr_Codigo
		{
			get {
				return gxTv_SdtSdListaNotaFiscalVenda_Codigo; 
			}
			set {
				gxTv_SdtSdListaNotaFiscalVenda_Codigo = value;
				SetDirty("Codigo");
			}
		}




		[SoapElement(ElementName="Descricao")]
		[XmlElement(ElementName="Descricao")]
		public string gxTpr_Descricao
		{
			get {
				return gxTv_SdtSdListaNotaFiscalVenda_Descricao; 
			}
			set {
				gxTv_SdtSdListaNotaFiscalVenda_Descricao = value;
				SetDirty("Descricao");
			}
		}




		[SoapElement(ElementName="Quantidade")]
		[XmlElement(ElementName="Quantidade")]
		public string gxTpr_Quantidade
		{
			get {
				return gxTv_SdtSdListaNotaFiscalVenda_Quantidade; 
			}
			set {
				gxTv_SdtSdListaNotaFiscalVenda_Quantidade = value;
				SetDirty("Quantidade");
			}
		}



		[SoapElement(ElementName="ValorUnitario")]
		[XmlElement(ElementName="ValorUnitario")]
		public string gxTpr_Valorunitario_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdListaNotaFiscalVenda_Valorunitario, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdListaNotaFiscalVenda_Valorunitario = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Valorunitario
		{
			get {
				return gxTv_SdtSdListaNotaFiscalVenda_Valorunitario; 
			}
			set {
				gxTv_SdtSdListaNotaFiscalVenda_Valorunitario = value;
				SetDirty("Valorunitario");
			}
		}



		[SoapElement(ElementName="Total")]
		[XmlElement(ElementName="Total")]
		public string gxTpr_Total_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdListaNotaFiscalVenda_Total, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdListaNotaFiscalVenda_Total = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Total
		{
			get {
				return gxTv_SdtSdListaNotaFiscalVenda_Total; 
			}
			set {
				gxTv_SdtSdListaNotaFiscalVenda_Total = value;
				SetDirty("Total");
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
			gxTv_SdtSdListaNotaFiscalVenda_Notafiscal = "";
			gxTv_SdtSdListaNotaFiscalVenda_Codigo = "";
			gxTv_SdtSdListaNotaFiscalVenda_Descricao = "";
			gxTv_SdtSdListaNotaFiscalVenda_Quantidade = "";


			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdListaNotaFiscalVenda_Notafiscal;
		 

		protected string gxTv_SdtSdListaNotaFiscalVenda_Codigo;
		 

		protected string gxTv_SdtSdListaNotaFiscalVenda_Descricao;
		 

		protected string gxTv_SdtSdListaNotaFiscalVenda_Quantidade;
		 

		protected decimal gxTv_SdtSdListaNotaFiscalVenda_Valorunitario;
		 

		protected decimal gxTv_SdtSdListaNotaFiscalVenda_Total;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SdListaNotaFiscalVenda", Namespace="Factory21")]
	public class SdtSdListaNotaFiscalVenda_RESTInterface : GxGenericCollectionItem<SdtSdListaNotaFiscalVenda>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdListaNotaFiscalVenda_RESTInterface( ) : base()
		{	
		}

		public SdtSdListaNotaFiscalVenda_RESTInterface( SdtSdListaNotaFiscalVenda psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("NotaFiscal")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="NotaFiscal", Order=0)]
		public  string gxTpr_Notafiscal
		{
			get { 
				return sdt.gxTpr_Notafiscal;

			}
			set { 
				 sdt.gxTpr_Notafiscal = value;
			}
		}

		[JsonPropertyName("Codigo")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="Codigo", Order=1)]
		public  string gxTpr_Codigo
		{
			get { 
				return sdt.gxTpr_Codigo;

			}
			set { 
				 sdt.gxTpr_Codigo = value;
			}
		}

		[JsonPropertyName("Descricao")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="Descricao", Order=2)]
		public  string gxTpr_Descricao
		{
			get { 
				return sdt.gxTpr_Descricao;

			}
			set { 
				 sdt.gxTpr_Descricao = value;
			}
		}

		[JsonPropertyName("Quantidade")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="Quantidade", Order=3)]
		public  string gxTpr_Quantidade
		{
			get { 
				return sdt.gxTpr_Quantidade;

			}
			set { 
				 sdt.gxTpr_Quantidade = value;
			}
		}

		[JsonPropertyName("ValorUnitario")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="ValorUnitario", Order=4)]
		public  string gxTpr_Valorunitario
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Valorunitario, 18, 2));

			}
			set { 
				sdt.gxTpr_Valorunitario =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("Total")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="Total", Order=5)]
		public  string gxTpr_Total
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Total, 18, 2));

			}
			set { 
				sdt.gxTpr_Total =  NumberUtil.Val( value, ".");
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdListaNotaFiscalVenda sdt
		{
			get { 
				return (SdtSdListaNotaFiscalVenda)Sdt;
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
				sdt = new SdtSdListaNotaFiscalVenda() ;
			}
		}
	}
	#endregion
}