/*
				   File: type_SdtWcImpNotaFiscalData_Revisao
			Description: Revisao
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
	[XmlRoot(ElementName="WcImpNotaFiscalData.Revisao")]
	[XmlType(TypeName="WcImpNotaFiscalData.Revisao" , Namespace="Factory21" )]
	[Serializable]
	public class SdtWcImpNotaFiscalData_Revisao : GxUserType
	{
		public SdtWcImpNotaFiscalData_Revisao( )
		{
			/* Constructor for serialization */
		}

		public SdtWcImpNotaFiscalData_Revisao(IGxContext context)
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
			AddObjectProperty("PropostaId", gxTpr_Propostaid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PropostaId")]
		[XmlElement(ElementName="PropostaId")]
		public int gxTpr_Propostaid
		{
			get {
				return gxTv_SdtWcImpNotaFiscalData_Revisao_Propostaid; 
			}
			set {
				gxTv_SdtWcImpNotaFiscalData_Revisao_Propostaid = value;
				SetDirty("Propostaid");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtWcImpNotaFiscalData_Revisao_Propostaid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WcImpNotaFiscalData.Revisao", Namespace="Factory21")]
	public class SdtWcImpNotaFiscalData_Revisao_RESTInterface : GxGenericCollectionItem<SdtWcImpNotaFiscalData_Revisao>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWcImpNotaFiscalData_Revisao_RESTInterface( ) : base()
		{	
		}

		public SdtWcImpNotaFiscalData_Revisao_RESTInterface( SdtWcImpNotaFiscalData_Revisao psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("PropostaId")]
		[JsonPropertyOrder(0)]
		[DataMember(Name="PropostaId", Order=0)]
		public  string gxTpr_Propostaid
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Propostaid, 9, 0));

			}
			set { 
				sdt.gxTpr_Propostaid = (int) NumberUtil.Val( value, ".");
			}
		}


		#endregion
		[JsonIgnore]
		public SdtWcImpNotaFiscalData_Revisao sdt
		{
			get { 
				return (SdtWcImpNotaFiscalData_Revisao)Sdt;
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
				sdt = new SdtWcImpNotaFiscalData_Revisao() ;
			}
		}
	}
	#endregion
}