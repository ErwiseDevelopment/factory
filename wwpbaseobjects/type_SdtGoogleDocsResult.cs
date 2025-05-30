/*
				   File: type_SdtGoogleDocsResult
			Description: GoogleDocsResult
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

using GeneXus.Programs;
namespace GeneXus.Programs.wwpbaseobjects
{
	[XmlRoot(ElementName="Result")]
	[XmlType(TypeName="Result" , Namespace="DVelop.Extensions.GoogleDocs" )]
	[Serializable]
	public class SdtGoogleDocsResult : GxUserType
	{
		public SdtGoogleDocsResult( )
		{
			/* Constructor for serialization */
			gxTv_SdtGoogleDocsResult_Error = "";

		}

		public SdtGoogleDocsResult(IGxContext context)
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
			AddObjectProperty("Success", gxTpr_Success, false);


			AddObjectProperty("Error", gxTpr_Error, false);

			if (gxTv_SdtGoogleDocsResult_Docs != null)
			{
				AddObjectProperty("Docs", gxTv_SdtGoogleDocsResult_Docs, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Success")]
		[XmlElement(ElementName="Success")]
		public bool gxTpr_Success
		{
			get {
				return gxTv_SdtGoogleDocsResult_Success; 
			}
			set {
				gxTv_SdtGoogleDocsResult_Success = value;
				SetDirty("Success");
			}
		}




		[SoapElement(ElementName="Error")]
		[XmlElement(ElementName="Error")]
		public string gxTpr_Error
		{
			get {
				return gxTv_SdtGoogleDocsResult_Error; 
			}
			set {
				gxTv_SdtGoogleDocsResult_Error = value;
				SetDirty("Error");
			}
		}




		[SoapElement(ElementName="Docs" )]
		[XmlArray(ElementName="Docs"  )]
		[XmlArrayItemAttribute(ElementName="Doc" , IsNullable=false )]
		public GXBaseCollection<SdtGoogleDocsResult_Doc> gxTpr_Docs
		{
			get {
				if ( gxTv_SdtGoogleDocsResult_Docs == null )
				{
					gxTv_SdtGoogleDocsResult_Docs = new GXBaseCollection<SdtGoogleDocsResult_Doc>( context, "GoogleDocsResult.Doc", "");
				}
				SetDirty("Docs");
				return gxTv_SdtGoogleDocsResult_Docs;
			}
			set {
				gxTv_SdtGoogleDocsResult_Docs_N = false;
				gxTv_SdtGoogleDocsResult_Docs = value;
				SetDirty("Docs");
			}
		}

		public void gxTv_SdtGoogleDocsResult_Docs_SetNull()
		{
			gxTv_SdtGoogleDocsResult_Docs_N = true;
			gxTv_SdtGoogleDocsResult_Docs = null;
		}

		public bool gxTv_SdtGoogleDocsResult_Docs_IsNull()
		{
			return gxTv_SdtGoogleDocsResult_Docs == null;
		}
		public bool ShouldSerializegxTpr_Docs_GxSimpleCollection_Json()
		{
			return gxTv_SdtGoogleDocsResult_Docs != null && gxTv_SdtGoogleDocsResult_Docs.Count > 0;

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
			gxTv_SdtGoogleDocsResult_Error = "";

			gxTv_SdtGoogleDocsResult_Docs_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtGoogleDocsResult_Success;
		 

		protected string gxTv_SdtGoogleDocsResult_Error;
		 
		protected bool gxTv_SdtGoogleDocsResult_Docs_N;
		protected GXBaseCollection<SdtGoogleDocsResult_Doc> gxTv_SdtGoogleDocsResult_Docs = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"Result", Namespace="DVelop.Extensions.GoogleDocs")]
	public class SdtGoogleDocsResult_RESTInterface : GxGenericCollectionItem<SdtGoogleDocsResult>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGoogleDocsResult_RESTInterface( ) : base()
		{	
		}

		public SdtGoogleDocsResult_RESTInterface( SdtGoogleDocsResult psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[JsonPropertyName("Success")]
		[JsonPropertyOrder(0)]
		[JsonConverter(typeof(BoolStringJsonConverter))]
		[DataMember(Name="Success", Order=0)]
		public bool gxTpr_Success
		{
			get { 
				return sdt.gxTpr_Success;

			}
			set { 
				sdt.gxTpr_Success = value;
			}
		}

		[JsonPropertyName("Error")]
		[JsonPropertyOrder(1)]
		[DataMember(Name="Error", Order=1)]
		public  string gxTpr_Error
		{
			get { 
				return sdt.gxTpr_Error;

			}
			set { 
				 sdt.gxTpr_Error = value;
			}
		}

		[JsonPropertyName("Docs")]
		[JsonPropertyOrder(2)]
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		[DataMember(Name="Docs", Order=2, EmitDefaultValue=false)]
		public GxGenericCollection<SdtGoogleDocsResult_Doc_RESTInterface> gxTpr_Docs
		{
			get {
				if (sdt.ShouldSerializegxTpr_Docs_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtGoogleDocsResult_Doc_RESTInterface>(sdt.gxTpr_Docs);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Docs);
			}
		}


		#endregion
		[JsonIgnore]
		public SdtGoogleDocsResult sdt
		{
			get { 
				return (SdtGoogleDocsResult)Sdt;
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
				sdt = new SdtGoogleDocsResult() ;
			}
		}
	}
	#endregion
}