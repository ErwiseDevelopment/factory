/*
				   File: type_SdtWcImpNotaFiscalData_ProdutosNota
			Description: ProdutosNota
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
	[XmlRoot(ElementName="WcImpNotaFiscalData.ProdutosNota")]
	[XmlType(TypeName="WcImpNotaFiscalData.ProdutosNota" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWcImpNotaFiscalData_ProdutosNota : GxUserType
	{
		public SdtWcImpNotaFiscalData_ProdutosNota( )
		{
			/* Constructor for serialization */
			gxTv_SdtWcImpNotaFiscalData_ProdutosNota_Jsonsdprodutosnota = "";


		}

		public SdtWcImpNotaFiscalData_ProdutosNota(IGxContext context)
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
			AddObjectProperty("JSONSdProdutosNota", gxTpr_Jsonsdprodutosnota, false);


			AddObjectProperty("TotalSel", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Totalsel, 18, 2)), false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="JSONSdProdutosNota")]
		[XmlElement(ElementName="JSONSdProdutosNota")]
		public string gxTpr_Jsonsdprodutosnota
		{
			get {
				return gxTv_SdtWcImpNotaFiscalData_ProdutosNota_Jsonsdprodutosnota; 
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_ProdutosNota_Jsonsdprodutosnota = value;
				SetDirty("Jsonsdprodutosnota");
			}
		}



		[SoapElement(ElementName="TotalSel")]
		[XmlElement(ElementName="TotalSel")]
		public string gxTpr_Totalsel_double
		{
			get {
				return Convert.ToString(gxTv_SdtWcImpNotaFiscalData_ProdutosNota_Totalsel, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_ProdutosNota_Totalsel = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Totalsel
		{
			get {
				return gxTv_SdtWcImpNotaFiscalData_ProdutosNota_Totalsel; 
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_ProdutosNota_Totalsel = value;
				SetDirty("Totalsel");
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
			gxTv_SdtWcImpNotaFiscalData_ProdutosNota_Jsonsdprodutosnota = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWcImpNotaFiscalData_ProdutosNota_Jsonsdprodutosnota;
		 

		protected decimal gxTv_SdtWcImpNotaFiscalData_ProdutosNota_Totalsel;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WcImpNotaFiscalData.ProdutosNota", Namespace="Factory21")]
	public class SdtWcImpNotaFiscalData_ProdutosNota_RESTInterface : GxGenericCollectionItem<SdtWcImpNotaFiscalData_ProdutosNota>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWcImpNotaFiscalData_ProdutosNota_RESTInterface( ) : base()
		{	
		}

		public SdtWcImpNotaFiscalData_ProdutosNota_RESTInterface( SdtWcImpNotaFiscalData_ProdutosNota psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("JSONSdProdutosNota")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="JSONSdProdutosNota", Order=0)]
		public  string gxTpr_Jsonsdprodutosnota
		{
			get { 
				return sdt.gxTpr_Jsonsdprodutosnota;

			}
			set { 
				 sdt.gxTpr_Jsonsdprodutosnota = value;
			}
		}

		[JsonPropertyName("TotalSel")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="TotalSel", Order=1)]
		public  string gxTpr_Totalsel
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalsel, 18, 2));

			}
			set { 
				sdt.gxTpr_Totalsel =  NumberUtil.Val( value, ".");
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWcImpNotaFiscalData_ProdutosNota sdt
		{
			get { 
				return (SdtWcImpNotaFiscalData_ProdutosNota)Sdt;
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
				sdt = new SdtWcImpNotaFiscalData_ProdutosNota() ;
			}
		}
	}
	#endregion
}