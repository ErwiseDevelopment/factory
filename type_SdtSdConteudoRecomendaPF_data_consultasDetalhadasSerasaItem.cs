/*
				   File: type_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem
			Description: consultasDetalhadasSerasa
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
	[XmlRoot(ElementName="SdConteudoRecomendaPF.data.consultasDetalhadasSerasaItem")]
	[XmlType(TypeName="SdConteudoRecomendaPF.data.consultasDetalhadasSerasaItem" , Namespace="Factory21" )]
	[Serializable]
	public class SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem : GxUserType
	{
		public SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem( )
		{
			/* Constructor for serialization */
		}

		public SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem(IGxContext context)
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
			AddObjectProperty("m0Consultas", gxTpr_M0consultas, false);


			AddObjectProperty("m1Consultas", gxTpr_M1consultas, false);


			AddObjectProperty("m2Consultas", gxTpr_M2consultas, false);


			AddObjectProperty("m3Consultas", gxTpr_M3consultas, false);


			AddObjectProperty("totalConsultasCheques", gxTpr_Totalconsultascheques, false);


			AddObjectProperty("totalConsultasCredito", gxTpr_Totalconsultascredito, false);


			AddObjectProperty("totalConsultas", gxTpr_Totalconsultas, false);

			if (gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa != null)
			{
				AddObjectProperty("consultasSerasa", gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="m0Consultas")]
		[XmlElement(ElementName="m0Consultas")]
		public string gxTpr_M0consultas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M0consultas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M0consultas = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_M0consultas
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M0consultas; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M0consultas = value;
				SetDirty("M0consultas");
			}
		}



		[SoapElement(ElementName="m1Consultas")]
		[XmlElement(ElementName="m1Consultas")]
		public string gxTpr_M1consultas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M1consultas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M1consultas = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_M1consultas
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M1consultas; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M1consultas = value;
				SetDirty("M1consultas");
			}
		}



		[SoapElement(ElementName="m2Consultas")]
		[XmlElement(ElementName="m2Consultas")]
		public string gxTpr_M2consultas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M2consultas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M2consultas = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_M2consultas
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M2consultas; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M2consultas = value;
				SetDirty("M2consultas");
			}
		}



		[SoapElement(ElementName="m3Consultas")]
		[XmlElement(ElementName="m3Consultas")]
		public string gxTpr_M3consultas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M3consultas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M3consultas = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_M3consultas
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M3consultas; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M3consultas = value;
				SetDirty("M3consultas");
			}
		}



		[SoapElement(ElementName="totalConsultasCheques")]
		[XmlElement(ElementName="totalConsultasCheques")]
		public string gxTpr_Totalconsultascheques_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultascheques, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultascheques = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Totalconsultascheques
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultascheques; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultascheques = value;
				SetDirty("Totalconsultascheques");
			}
		}



		[SoapElement(ElementName="totalConsultasCredito")]
		[XmlElement(ElementName="totalConsultasCredito")]
		public string gxTpr_Totalconsultascredito_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultascredito, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultascredito = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Totalconsultascredito
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultascredito; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultascredito = value;
				SetDirty("Totalconsultascredito");
			}
		}



		[SoapElement(ElementName="totalConsultas")]
		[XmlElement(ElementName="totalConsultas")]
		public string gxTpr_Totalconsultas_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultas, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultas = NumberUtil.Val(value);
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Totalconsultas
		{
			get {
				return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultas; 
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultas = value;
				SetDirty("Totalconsultas");
			}
		}




		[SoapElement(ElementName="consultasSerasa" )]
		[XmlArray(ElementName="consultasSerasa"  )]
		[XmlArrayItemAttribute(ElementName="consultasSerasaItem" , IsNullable=false )]
		public GXBaseCollection<SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem> gxTpr_Consultasserasa
		{
			get {
				if ( gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa == null )
				{
					gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa = new GXBaseCollection<SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem>( context, "SdConteudoRecomendaPF.data.consultasDetalhadasSerasaItem.consultasSerasaItem", "");
				}
				SetDirty("Consultasserasa");
				return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa;
			}
			set {
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa_N = false;
				gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa = value;
				SetDirty("Consultasserasa");
			}
		}

		public void gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa_SetNull()
		{
			gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa_N = true;
			gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa = null;
		}

		public bool gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa_IsNull()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa == null;
		}
		public bool ShouldSerializegxTpr_Consultasserasa_GxSimpleCollection_Json()
		{
			return gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa != null && gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa.Count > 0;

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
			gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M0consultas;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M1consultas;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M2consultas;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_M3consultas;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultascheques;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultascredito;
		 

		protected decimal gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Totalconsultas;
		 
		protected bool gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa_N;
		protected GXBaseCollection<SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem> gxTv_SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_Consultasserasa = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SdConteudoRecomendaPF.data.consultasDetalhadasSerasaItem", Namespace="Factory21")]
	public class SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_RESTInterface : GxGenericCollectionItem<SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_RESTInterface( SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("m0Consultas")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="m0Consultas", Order=0)]
		public  string gxTpr_M0consultas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_M0consultas, 10, 5));

			}
			set { 
				sdt.gxTpr_M0consultas =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("m1Consultas")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="m1Consultas", Order=1)]
		public  string gxTpr_M1consultas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_M1consultas, 10, 5));

			}
			set { 
				sdt.gxTpr_M1consultas =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("m2Consultas")]
		[JsonPropertyOrder(2)]
		[DataMember(Name="m2Consultas", Order=2)]
		public  string gxTpr_M2consultas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_M2consultas, 10, 5));

			}
			set { 
				sdt.gxTpr_M2consultas =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("m3Consultas")]
		[JsonPropertyOrder(3)]
		[DataMember(Name="m3Consultas", Order=3)]
		public  string gxTpr_M3consultas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_M3consultas, 10, 5));

			}
			set { 
				sdt.gxTpr_M3consultas =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("totalConsultasCheques")]
		[JsonPropertyOrder(4)]
		[DataMember(Name="totalConsultasCheques", Order=4)]
		public  string gxTpr_Totalconsultascheques
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalconsultascheques, 10, 5));

			}
			set { 
				sdt.gxTpr_Totalconsultascheques =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("totalConsultasCredito")]
		[JsonPropertyOrder(5)]
		[DataMember(Name="totalConsultasCredito", Order=5)]
		public  string gxTpr_Totalconsultascredito
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalconsultascredito, 10, 5));

			}
			set { 
				sdt.gxTpr_Totalconsultascredito =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("totalConsultas")]
		[JsonPropertyOrder(6)]
		[DataMember(Name="totalConsultas", Order=6)]
		public  string gxTpr_Totalconsultas
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalconsultas, 10, 5));

			}
			set { 
				sdt.gxTpr_Totalconsultas =  NumberUtil.Val( value, ".");
			}
		}

		[JsonPropertyName("consultasSerasa")]
		[JsonPropertyOrder(7)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="consultasSerasa", Order=7, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_RESTInterface> gxTpr_Consultasserasa
		{
			get {
				if (sdt.ShouldSerializegxTpr_Consultasserasa_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem_RESTInterface>(sdt.gxTpr_Consultasserasa);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Consultasserasa);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem sdt
		{
			get { 
				return (SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem)Sdt;
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
				sdt = new SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem() ;
			}
		}
	}
	#endregion
}