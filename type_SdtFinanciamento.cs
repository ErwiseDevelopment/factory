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
   [XmlRoot(ElementName = "Financiamento" )]
   [XmlType(TypeName =  "Financiamento" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtFinanciamento : GxSilentTrnSdt
   {
      public SdtFinanciamento( )
      {
      }

      public SdtFinanciamento( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
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

      public void Load( int AV223FinanciamentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV223FinanciamentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"FinanciamentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Financiamento");
         metadata.Set("BT", "Financiamento");
         metadata.Set("PK", "[ \"FinanciamentoId\" ]");
         metadata.Set("PKAssigned", "[ \"FinanciamentoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ClienteId\" ],\"FKMap\":[ \"IntermediadorClienteId-ClienteId\" ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Financiamentoid_Z");
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Clienterazaosocial_Z");
         state.Add("gxTpr_Clientedocumento_Z");
         state.Add("gxTpr_Financiamentovalor_Z");
         state.Add("gxTpr_Financiamentostatus_Z");
         state.Add("gxTpr_Intermediadorclienteid_Z");
         state.Add("gxTpr_Intermediadorclienterazaosocial_Z");
         state.Add("gxTpr_Intermediadorclientedocumento_Z");
         state.Add("gxTpr_Clienteid_N");
         state.Add("gxTpr_Clienterazaosocial_N");
         state.Add("gxTpr_Clientedocumento_N");
         state.Add("gxTpr_Financiamentovalor_N");
         state.Add("gxTpr_Financiamentostatus_N");
         state.Add("gxTpr_Intermediadorclienteid_N");
         state.Add("gxTpr_Intermediadorclienterazaosocial_N");
         state.Add("gxTpr_Intermediadorclientedocumento_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtFinanciamento sdt;
         sdt = (SdtFinanciamento)(source);
         gxTv_SdtFinanciamento_Financiamentoid = sdt.gxTv_SdtFinanciamento_Financiamentoid ;
         gxTv_SdtFinanciamento_Clienteid = sdt.gxTv_SdtFinanciamento_Clienteid ;
         gxTv_SdtFinanciamento_Clienterazaosocial = sdt.gxTv_SdtFinanciamento_Clienterazaosocial ;
         gxTv_SdtFinanciamento_Clientedocumento = sdt.gxTv_SdtFinanciamento_Clientedocumento ;
         gxTv_SdtFinanciamento_Financiamentovalor = sdt.gxTv_SdtFinanciamento_Financiamentovalor ;
         gxTv_SdtFinanciamento_Financiamentostatus = sdt.gxTv_SdtFinanciamento_Financiamentostatus ;
         gxTv_SdtFinanciamento_Intermediadorclienteid = sdt.gxTv_SdtFinanciamento_Intermediadorclienteid ;
         gxTv_SdtFinanciamento_Intermediadorclienterazaosocial = sdt.gxTv_SdtFinanciamento_Intermediadorclienterazaosocial ;
         gxTv_SdtFinanciamento_Intermediadorclientedocumento = sdt.gxTv_SdtFinanciamento_Intermediadorclientedocumento ;
         gxTv_SdtFinanciamento_Mode = sdt.gxTv_SdtFinanciamento_Mode ;
         gxTv_SdtFinanciamento_Initialized = sdt.gxTv_SdtFinanciamento_Initialized ;
         gxTv_SdtFinanciamento_Financiamentoid_Z = sdt.gxTv_SdtFinanciamento_Financiamentoid_Z ;
         gxTv_SdtFinanciamento_Clienteid_Z = sdt.gxTv_SdtFinanciamento_Clienteid_Z ;
         gxTv_SdtFinanciamento_Clienterazaosocial_Z = sdt.gxTv_SdtFinanciamento_Clienterazaosocial_Z ;
         gxTv_SdtFinanciamento_Clientedocumento_Z = sdt.gxTv_SdtFinanciamento_Clientedocumento_Z ;
         gxTv_SdtFinanciamento_Financiamentovalor_Z = sdt.gxTv_SdtFinanciamento_Financiamentovalor_Z ;
         gxTv_SdtFinanciamento_Financiamentostatus_Z = sdt.gxTv_SdtFinanciamento_Financiamentostatus_Z ;
         gxTv_SdtFinanciamento_Intermediadorclienteid_Z = sdt.gxTv_SdtFinanciamento_Intermediadorclienteid_Z ;
         gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_Z = sdt.gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_Z ;
         gxTv_SdtFinanciamento_Intermediadorclientedocumento_Z = sdt.gxTv_SdtFinanciamento_Intermediadorclientedocumento_Z ;
         gxTv_SdtFinanciamento_Clienteid_N = sdt.gxTv_SdtFinanciamento_Clienteid_N ;
         gxTv_SdtFinanciamento_Clienterazaosocial_N = sdt.gxTv_SdtFinanciamento_Clienterazaosocial_N ;
         gxTv_SdtFinanciamento_Clientedocumento_N = sdt.gxTv_SdtFinanciamento_Clientedocumento_N ;
         gxTv_SdtFinanciamento_Financiamentovalor_N = sdt.gxTv_SdtFinanciamento_Financiamentovalor_N ;
         gxTv_SdtFinanciamento_Financiamentostatus_N = sdt.gxTv_SdtFinanciamento_Financiamentostatus_N ;
         gxTv_SdtFinanciamento_Intermediadorclienteid_N = sdt.gxTv_SdtFinanciamento_Intermediadorclienteid_N ;
         gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N = sdt.gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N ;
         gxTv_SdtFinanciamento_Intermediadorclientedocumento_N = sdt.gxTv_SdtFinanciamento_Intermediadorclientedocumento_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("FinanciamentoId", gxTv_SdtFinanciamento_Financiamentoid, false, includeNonInitialized);
         AddObjectProperty("ClienteId", gxTv_SdtFinanciamento_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteId_N", gxTv_SdtFinanciamento_Clienteid_N, false, includeNonInitialized);
         AddObjectProperty("ClienteRazaoSocial", gxTv_SdtFinanciamento_Clienterazaosocial, false, includeNonInitialized);
         AddObjectProperty("ClienteRazaoSocial_N", gxTv_SdtFinanciamento_Clienterazaosocial_N, false, includeNonInitialized);
         AddObjectProperty("ClienteDocumento", gxTv_SdtFinanciamento_Clientedocumento, false, includeNonInitialized);
         AddObjectProperty("ClienteDocumento_N", gxTv_SdtFinanciamento_Clientedocumento_N, false, includeNonInitialized);
         AddObjectProperty("FinanciamentoValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtFinanciamento_Financiamentovalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("FinanciamentoValor_N", gxTv_SdtFinanciamento_Financiamentovalor_N, false, includeNonInitialized);
         AddObjectProperty("FinanciamentoStatus", gxTv_SdtFinanciamento_Financiamentostatus, false, includeNonInitialized);
         AddObjectProperty("FinanciamentoStatus_N", gxTv_SdtFinanciamento_Financiamentostatus_N, false, includeNonInitialized);
         AddObjectProperty("IntermediadorClienteId", gxTv_SdtFinanciamento_Intermediadorclienteid, false, includeNonInitialized);
         AddObjectProperty("IntermediadorClienteId_N", gxTv_SdtFinanciamento_Intermediadorclienteid_N, false, includeNonInitialized);
         AddObjectProperty("IntermediadorClienteRazaoSocial", gxTv_SdtFinanciamento_Intermediadorclienterazaosocial, false, includeNonInitialized);
         AddObjectProperty("IntermediadorClienteRazaoSocial_N", gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N, false, includeNonInitialized);
         AddObjectProperty("IntermediadorClienteDocumento", gxTv_SdtFinanciamento_Intermediadorclientedocumento, false, includeNonInitialized);
         AddObjectProperty("IntermediadorClienteDocumento_N", gxTv_SdtFinanciamento_Intermediadorclientedocumento_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtFinanciamento_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtFinanciamento_Initialized, false, includeNonInitialized);
            AddObjectProperty("FinanciamentoId_Z", gxTv_SdtFinanciamento_Financiamentoid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtFinanciamento_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteRazaoSocial_Z", gxTv_SdtFinanciamento_Clienterazaosocial_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteDocumento_Z", gxTv_SdtFinanciamento_Clientedocumento_Z, false, includeNonInitialized);
            AddObjectProperty("FinanciamentoValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtFinanciamento_Financiamentovalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("FinanciamentoStatus_Z", gxTv_SdtFinanciamento_Financiamentostatus_Z, false, includeNonInitialized);
            AddObjectProperty("IntermediadorClienteId_Z", gxTv_SdtFinanciamento_Intermediadorclienteid_Z, false, includeNonInitialized);
            AddObjectProperty("IntermediadorClienteRazaoSocial_Z", gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_Z, false, includeNonInitialized);
            AddObjectProperty("IntermediadorClienteDocumento_Z", gxTv_SdtFinanciamento_Intermediadorclientedocumento_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_N", gxTv_SdtFinanciamento_Clienteid_N, false, includeNonInitialized);
            AddObjectProperty("ClienteRazaoSocial_N", gxTv_SdtFinanciamento_Clienterazaosocial_N, false, includeNonInitialized);
            AddObjectProperty("ClienteDocumento_N", gxTv_SdtFinanciamento_Clientedocumento_N, false, includeNonInitialized);
            AddObjectProperty("FinanciamentoValor_N", gxTv_SdtFinanciamento_Financiamentovalor_N, false, includeNonInitialized);
            AddObjectProperty("FinanciamentoStatus_N", gxTv_SdtFinanciamento_Financiamentostatus_N, false, includeNonInitialized);
            AddObjectProperty("IntermediadorClienteId_N", gxTv_SdtFinanciamento_Intermediadorclienteid_N, false, includeNonInitialized);
            AddObjectProperty("IntermediadorClienteRazaoSocial_N", gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N, false, includeNonInitialized);
            AddObjectProperty("IntermediadorClienteDocumento_N", gxTv_SdtFinanciamento_Intermediadorclientedocumento_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtFinanciamento sdt )
      {
         if ( sdt.IsDirty("FinanciamentoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Financiamentoid = sdt.gxTv_SdtFinanciamento_Financiamentoid ;
         }
         if ( sdt.IsDirty("ClienteId") )
         {
            gxTv_SdtFinanciamento_Clienteid_N = (short)(sdt.gxTv_SdtFinanciamento_Clienteid_N);
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Clienteid = sdt.gxTv_SdtFinanciamento_Clienteid ;
         }
         if ( sdt.IsDirty("ClienteRazaoSocial") )
         {
            gxTv_SdtFinanciamento_Clienterazaosocial_N = (short)(sdt.gxTv_SdtFinanciamento_Clienterazaosocial_N);
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Clienterazaosocial = sdt.gxTv_SdtFinanciamento_Clienterazaosocial ;
         }
         if ( sdt.IsDirty("ClienteDocumento") )
         {
            gxTv_SdtFinanciamento_Clientedocumento_N = (short)(sdt.gxTv_SdtFinanciamento_Clientedocumento_N);
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Clientedocumento = sdt.gxTv_SdtFinanciamento_Clientedocumento ;
         }
         if ( sdt.IsDirty("FinanciamentoValor") )
         {
            gxTv_SdtFinanciamento_Financiamentovalor_N = (short)(sdt.gxTv_SdtFinanciamento_Financiamentovalor_N);
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Financiamentovalor = sdt.gxTv_SdtFinanciamento_Financiamentovalor ;
         }
         if ( sdt.IsDirty("FinanciamentoStatus") )
         {
            gxTv_SdtFinanciamento_Financiamentostatus_N = (short)(sdt.gxTv_SdtFinanciamento_Financiamentostatus_N);
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Financiamentostatus = sdt.gxTv_SdtFinanciamento_Financiamentostatus ;
         }
         if ( sdt.IsDirty("IntermediadorClienteId") )
         {
            gxTv_SdtFinanciamento_Intermediadorclienteid_N = (short)(sdt.gxTv_SdtFinanciamento_Intermediadorclienteid_N);
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Intermediadorclienteid = sdt.gxTv_SdtFinanciamento_Intermediadorclienteid ;
         }
         if ( sdt.IsDirty("IntermediadorClienteRazaoSocial") )
         {
            gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N = (short)(sdt.gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N);
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Intermediadorclienterazaosocial = sdt.gxTv_SdtFinanciamento_Intermediadorclienterazaosocial ;
         }
         if ( sdt.IsDirty("IntermediadorClienteDocumento") )
         {
            gxTv_SdtFinanciamento_Intermediadorclientedocumento_N = (short)(sdt.gxTv_SdtFinanciamento_Intermediadorclientedocumento_N);
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Intermediadorclientedocumento = sdt.gxTv_SdtFinanciamento_Intermediadorclientedocumento ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "FinanciamentoId" )]
      [  XmlElement( ElementName = "FinanciamentoId"   )]
      public int gxTpr_Financiamentoid
      {
         get {
            return gxTv_SdtFinanciamento_Financiamentoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtFinanciamento_Financiamentoid != value )
            {
               gxTv_SdtFinanciamento_Mode = "INS";
               this.gxTv_SdtFinanciamento_Financiamentoid_Z_SetNull( );
               this.gxTv_SdtFinanciamento_Clienteid_Z_SetNull( );
               this.gxTv_SdtFinanciamento_Clienterazaosocial_Z_SetNull( );
               this.gxTv_SdtFinanciamento_Clientedocumento_Z_SetNull( );
               this.gxTv_SdtFinanciamento_Financiamentovalor_Z_SetNull( );
               this.gxTv_SdtFinanciamento_Financiamentostatus_Z_SetNull( );
               this.gxTv_SdtFinanciamento_Intermediadorclienteid_Z_SetNull( );
               this.gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_Z_SetNull( );
               this.gxTv_SdtFinanciamento_Intermediadorclientedocumento_Z_SetNull( );
            }
            gxTv_SdtFinanciamento_Financiamentoid = value;
            SetDirty("Financiamentoid");
         }

      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public int gxTpr_Clienteid
      {
         get {
            return gxTv_SdtFinanciamento_Clienteid ;
         }

         set {
            gxTv_SdtFinanciamento_Clienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      public void gxTv_SdtFinanciamento_Clienteid_SetNull( )
      {
         gxTv_SdtFinanciamento_Clienteid_N = 1;
         gxTv_SdtFinanciamento_Clienteid = 0;
         SetDirty("Clienteid");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Clienteid_IsNull( )
      {
         return (gxTv_SdtFinanciamento_Clienteid_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial"   )]
      public string gxTpr_Clienterazaosocial
      {
         get {
            return gxTv_SdtFinanciamento_Clienterazaosocial ;
         }

         set {
            gxTv_SdtFinanciamento_Clienterazaosocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Clienterazaosocial = value;
            SetDirty("Clienterazaosocial");
         }

      }

      public void gxTv_SdtFinanciamento_Clienterazaosocial_SetNull( )
      {
         gxTv_SdtFinanciamento_Clienterazaosocial_N = 1;
         gxTv_SdtFinanciamento_Clienterazaosocial = "";
         SetDirty("Clienterazaosocial");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Clienterazaosocial_IsNull( )
      {
         return (gxTv_SdtFinanciamento_Clienterazaosocial_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteDocumento" )]
      [  XmlElement( ElementName = "ClienteDocumento"   )]
      public string gxTpr_Clientedocumento
      {
         get {
            return gxTv_SdtFinanciamento_Clientedocumento ;
         }

         set {
            gxTv_SdtFinanciamento_Clientedocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Clientedocumento = value;
            SetDirty("Clientedocumento");
         }

      }

      public void gxTv_SdtFinanciamento_Clientedocumento_SetNull( )
      {
         gxTv_SdtFinanciamento_Clientedocumento_N = 1;
         gxTv_SdtFinanciamento_Clientedocumento = "";
         SetDirty("Clientedocumento");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Clientedocumento_IsNull( )
      {
         return (gxTv_SdtFinanciamento_Clientedocumento_N==1) ;
      }

      [  SoapElement( ElementName = "FinanciamentoValor" )]
      [  XmlElement( ElementName = "FinanciamentoValor"   )]
      public decimal gxTpr_Financiamentovalor
      {
         get {
            return gxTv_SdtFinanciamento_Financiamentovalor ;
         }

         set {
            gxTv_SdtFinanciamento_Financiamentovalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Financiamentovalor = value;
            SetDirty("Financiamentovalor");
         }

      }

      public void gxTv_SdtFinanciamento_Financiamentovalor_SetNull( )
      {
         gxTv_SdtFinanciamento_Financiamentovalor_N = 1;
         gxTv_SdtFinanciamento_Financiamentovalor = 0;
         SetDirty("Financiamentovalor");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Financiamentovalor_IsNull( )
      {
         return (gxTv_SdtFinanciamento_Financiamentovalor_N==1) ;
      }

      [  SoapElement( ElementName = "FinanciamentoStatus" )]
      [  XmlElement( ElementName = "FinanciamentoStatus"   )]
      public string gxTpr_Financiamentostatus
      {
         get {
            return gxTv_SdtFinanciamento_Financiamentostatus ;
         }

         set {
            gxTv_SdtFinanciamento_Financiamentostatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Financiamentostatus = value;
            SetDirty("Financiamentostatus");
         }

      }

      public void gxTv_SdtFinanciamento_Financiamentostatus_SetNull( )
      {
         gxTv_SdtFinanciamento_Financiamentostatus_N = 1;
         gxTv_SdtFinanciamento_Financiamentostatus = "";
         SetDirty("Financiamentostatus");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Financiamentostatus_IsNull( )
      {
         return (gxTv_SdtFinanciamento_Financiamentostatus_N==1) ;
      }

      [  SoapElement( ElementName = "IntermediadorClienteId" )]
      [  XmlElement( ElementName = "IntermediadorClienteId"   )]
      public int gxTpr_Intermediadorclienteid
      {
         get {
            return gxTv_SdtFinanciamento_Intermediadorclienteid ;
         }

         set {
            gxTv_SdtFinanciamento_Intermediadorclienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Intermediadorclienteid = value;
            SetDirty("Intermediadorclienteid");
         }

      }

      public void gxTv_SdtFinanciamento_Intermediadorclienteid_SetNull( )
      {
         gxTv_SdtFinanciamento_Intermediadorclienteid_N = 1;
         gxTv_SdtFinanciamento_Intermediadorclienteid = 0;
         SetDirty("Intermediadorclienteid");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Intermediadorclienteid_IsNull( )
      {
         return (gxTv_SdtFinanciamento_Intermediadorclienteid_N==1) ;
      }

      [  SoapElement( ElementName = "IntermediadorClienteRazaoSocial" )]
      [  XmlElement( ElementName = "IntermediadorClienteRazaoSocial"   )]
      public string gxTpr_Intermediadorclienterazaosocial
      {
         get {
            return gxTv_SdtFinanciamento_Intermediadorclienterazaosocial ;
         }

         set {
            gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Intermediadorclienterazaosocial = value;
            SetDirty("Intermediadorclienterazaosocial");
         }

      }

      public void gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_SetNull( )
      {
         gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N = 1;
         gxTv_SdtFinanciamento_Intermediadorclienterazaosocial = "";
         SetDirty("Intermediadorclienterazaosocial");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_IsNull( )
      {
         return (gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N==1) ;
      }

      [  SoapElement( ElementName = "IntermediadorClienteDocumento" )]
      [  XmlElement( ElementName = "IntermediadorClienteDocumento"   )]
      public string gxTpr_Intermediadorclientedocumento
      {
         get {
            return gxTv_SdtFinanciamento_Intermediadorclientedocumento ;
         }

         set {
            gxTv_SdtFinanciamento_Intermediadorclientedocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Intermediadorclientedocumento = value;
            SetDirty("Intermediadorclientedocumento");
         }

      }

      public void gxTv_SdtFinanciamento_Intermediadorclientedocumento_SetNull( )
      {
         gxTv_SdtFinanciamento_Intermediadorclientedocumento_N = 1;
         gxTv_SdtFinanciamento_Intermediadorclientedocumento = "";
         SetDirty("Intermediadorclientedocumento");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Intermediadorclientedocumento_IsNull( )
      {
         return (gxTv_SdtFinanciamento_Intermediadorclientedocumento_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtFinanciamento_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtFinanciamento_Mode_SetNull( )
      {
         gxTv_SdtFinanciamento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtFinanciamento_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtFinanciamento_Initialized_SetNull( )
      {
         gxTv_SdtFinanciamento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FinanciamentoId_Z" )]
      [  XmlElement( ElementName = "FinanciamentoId_Z"   )]
      public int gxTpr_Financiamentoid_Z
      {
         get {
            return gxTv_SdtFinanciamento_Financiamentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Financiamentoid_Z = value;
            SetDirty("Financiamentoid_Z");
         }

      }

      public void gxTv_SdtFinanciamento_Financiamentoid_Z_SetNull( )
      {
         gxTv_SdtFinanciamento_Financiamentoid_Z = 0;
         SetDirty("Financiamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Financiamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public int gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtFinanciamento_Clienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtFinanciamento_Clienteid_Z_SetNull( )
      {
         gxTv_SdtFinanciamento_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial_Z" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial_Z"   )]
      public string gxTpr_Clienterazaosocial_Z
      {
         get {
            return gxTv_SdtFinanciamento_Clienterazaosocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Clienterazaosocial_Z = value;
            SetDirty("Clienterazaosocial_Z");
         }

      }

      public void gxTv_SdtFinanciamento_Clienterazaosocial_Z_SetNull( )
      {
         gxTv_SdtFinanciamento_Clienterazaosocial_Z = "";
         SetDirty("Clienterazaosocial_Z");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Clienterazaosocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumento_Z" )]
      [  XmlElement( ElementName = "ClienteDocumento_Z"   )]
      public string gxTpr_Clientedocumento_Z
      {
         get {
            return gxTv_SdtFinanciamento_Clientedocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Clientedocumento_Z = value;
            SetDirty("Clientedocumento_Z");
         }

      }

      public void gxTv_SdtFinanciamento_Clientedocumento_Z_SetNull( )
      {
         gxTv_SdtFinanciamento_Clientedocumento_Z = "";
         SetDirty("Clientedocumento_Z");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Clientedocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FinanciamentoValor_Z" )]
      [  XmlElement( ElementName = "FinanciamentoValor_Z"   )]
      public decimal gxTpr_Financiamentovalor_Z
      {
         get {
            return gxTv_SdtFinanciamento_Financiamentovalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Financiamentovalor_Z = value;
            SetDirty("Financiamentovalor_Z");
         }

      }

      public void gxTv_SdtFinanciamento_Financiamentovalor_Z_SetNull( )
      {
         gxTv_SdtFinanciamento_Financiamentovalor_Z = 0;
         SetDirty("Financiamentovalor_Z");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Financiamentovalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FinanciamentoStatus_Z" )]
      [  XmlElement( ElementName = "FinanciamentoStatus_Z"   )]
      public string gxTpr_Financiamentostatus_Z
      {
         get {
            return gxTv_SdtFinanciamento_Financiamentostatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Financiamentostatus_Z = value;
            SetDirty("Financiamentostatus_Z");
         }

      }

      public void gxTv_SdtFinanciamento_Financiamentostatus_Z_SetNull( )
      {
         gxTv_SdtFinanciamento_Financiamentostatus_Z = "";
         SetDirty("Financiamentostatus_Z");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Financiamentostatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IntermediadorClienteId_Z" )]
      [  XmlElement( ElementName = "IntermediadorClienteId_Z"   )]
      public int gxTpr_Intermediadorclienteid_Z
      {
         get {
            return gxTv_SdtFinanciamento_Intermediadorclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Intermediadorclienteid_Z = value;
            SetDirty("Intermediadorclienteid_Z");
         }

      }

      public void gxTv_SdtFinanciamento_Intermediadorclienteid_Z_SetNull( )
      {
         gxTv_SdtFinanciamento_Intermediadorclienteid_Z = 0;
         SetDirty("Intermediadorclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Intermediadorclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IntermediadorClienteRazaoSocial_Z" )]
      [  XmlElement( ElementName = "IntermediadorClienteRazaoSocial_Z"   )]
      public string gxTpr_Intermediadorclienterazaosocial_Z
      {
         get {
            return gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_Z = value;
            SetDirty("Intermediadorclienterazaosocial_Z");
         }

      }

      public void gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_Z_SetNull( )
      {
         gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_Z = "";
         SetDirty("Intermediadorclienterazaosocial_Z");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IntermediadorClienteDocumento_Z" )]
      [  XmlElement( ElementName = "IntermediadorClienteDocumento_Z"   )]
      public string gxTpr_Intermediadorclientedocumento_Z
      {
         get {
            return gxTv_SdtFinanciamento_Intermediadorclientedocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Intermediadorclientedocumento_Z = value;
            SetDirty("Intermediadorclientedocumento_Z");
         }

      }

      public void gxTv_SdtFinanciamento_Intermediadorclientedocumento_Z_SetNull( )
      {
         gxTv_SdtFinanciamento_Intermediadorclientedocumento_Z = "";
         SetDirty("Intermediadorclientedocumento_Z");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Intermediadorclientedocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_N" )]
      [  XmlElement( ElementName = "ClienteId_N"   )]
      public short gxTpr_Clienteid_N
      {
         get {
            return gxTv_SdtFinanciamento_Clienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Clienteid_N = value;
            SetDirty("Clienteid_N");
         }

      }

      public void gxTv_SdtFinanciamento_Clienteid_N_SetNull( )
      {
         gxTv_SdtFinanciamento_Clienteid_N = 0;
         SetDirty("Clienteid_N");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Clienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial_N" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial_N"   )]
      public short gxTpr_Clienterazaosocial_N
      {
         get {
            return gxTv_SdtFinanciamento_Clienterazaosocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Clienterazaosocial_N = value;
            SetDirty("Clienterazaosocial_N");
         }

      }

      public void gxTv_SdtFinanciamento_Clienterazaosocial_N_SetNull( )
      {
         gxTv_SdtFinanciamento_Clienterazaosocial_N = 0;
         SetDirty("Clienterazaosocial_N");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Clienterazaosocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumento_N" )]
      [  XmlElement( ElementName = "ClienteDocumento_N"   )]
      public short gxTpr_Clientedocumento_N
      {
         get {
            return gxTv_SdtFinanciamento_Clientedocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Clientedocumento_N = value;
            SetDirty("Clientedocumento_N");
         }

      }

      public void gxTv_SdtFinanciamento_Clientedocumento_N_SetNull( )
      {
         gxTv_SdtFinanciamento_Clientedocumento_N = 0;
         SetDirty("Clientedocumento_N");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Clientedocumento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FinanciamentoValor_N" )]
      [  XmlElement( ElementName = "FinanciamentoValor_N"   )]
      public short gxTpr_Financiamentovalor_N
      {
         get {
            return gxTv_SdtFinanciamento_Financiamentovalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Financiamentovalor_N = value;
            SetDirty("Financiamentovalor_N");
         }

      }

      public void gxTv_SdtFinanciamento_Financiamentovalor_N_SetNull( )
      {
         gxTv_SdtFinanciamento_Financiamentovalor_N = 0;
         SetDirty("Financiamentovalor_N");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Financiamentovalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FinanciamentoStatus_N" )]
      [  XmlElement( ElementName = "FinanciamentoStatus_N"   )]
      public short gxTpr_Financiamentostatus_N
      {
         get {
            return gxTv_SdtFinanciamento_Financiamentostatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Financiamentostatus_N = value;
            SetDirty("Financiamentostatus_N");
         }

      }

      public void gxTv_SdtFinanciamento_Financiamentostatus_N_SetNull( )
      {
         gxTv_SdtFinanciamento_Financiamentostatus_N = 0;
         SetDirty("Financiamentostatus_N");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Financiamentostatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IntermediadorClienteId_N" )]
      [  XmlElement( ElementName = "IntermediadorClienteId_N"   )]
      public short gxTpr_Intermediadorclienteid_N
      {
         get {
            return gxTv_SdtFinanciamento_Intermediadorclienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Intermediadorclienteid_N = value;
            SetDirty("Intermediadorclienteid_N");
         }

      }

      public void gxTv_SdtFinanciamento_Intermediadorclienteid_N_SetNull( )
      {
         gxTv_SdtFinanciamento_Intermediadorclienteid_N = 0;
         SetDirty("Intermediadorclienteid_N");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Intermediadorclienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IntermediadorClienteRazaoSocial_N" )]
      [  XmlElement( ElementName = "IntermediadorClienteRazaoSocial_N"   )]
      public short gxTpr_Intermediadorclienterazaosocial_N
      {
         get {
            return gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N = value;
            SetDirty("Intermediadorclienterazaosocial_N");
         }

      }

      public void gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N_SetNull( )
      {
         gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N = 0;
         SetDirty("Intermediadorclienterazaosocial_N");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "IntermediadorClienteDocumento_N" )]
      [  XmlElement( ElementName = "IntermediadorClienteDocumento_N"   )]
      public short gxTpr_Intermediadorclientedocumento_N
      {
         get {
            return gxTv_SdtFinanciamento_Intermediadorclientedocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtFinanciamento_Intermediadorclientedocumento_N = value;
            SetDirty("Intermediadorclientedocumento_N");
         }

      }

      public void gxTv_SdtFinanciamento_Intermediadorclientedocumento_N_SetNull( )
      {
         gxTv_SdtFinanciamento_Intermediadorclientedocumento_N = 0;
         SetDirty("Intermediadorclientedocumento_N");
         return  ;
      }

      public bool gxTv_SdtFinanciamento_Intermediadorclientedocumento_N_IsNull( )
      {
         return false ;
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
         sdtIsNull = 1;
         gxTv_SdtFinanciamento_Clienterazaosocial = "";
         gxTv_SdtFinanciamento_Clientedocumento = "";
         gxTv_SdtFinanciamento_Financiamentostatus = "";
         gxTv_SdtFinanciamento_Intermediadorclienterazaosocial = "";
         gxTv_SdtFinanciamento_Intermediadorclientedocumento = "";
         gxTv_SdtFinanciamento_Mode = "";
         gxTv_SdtFinanciamento_Clienterazaosocial_Z = "";
         gxTv_SdtFinanciamento_Clientedocumento_Z = "";
         gxTv_SdtFinanciamento_Financiamentostatus_Z = "";
         gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_Z = "";
         gxTv_SdtFinanciamento_Intermediadorclientedocumento_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "financiamento", "GeneXus.Programs.financiamento_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtFinanciamento_Initialized ;
      private short gxTv_SdtFinanciamento_Clienteid_N ;
      private short gxTv_SdtFinanciamento_Clienterazaosocial_N ;
      private short gxTv_SdtFinanciamento_Clientedocumento_N ;
      private short gxTv_SdtFinanciamento_Financiamentovalor_N ;
      private short gxTv_SdtFinanciamento_Financiamentostatus_N ;
      private short gxTv_SdtFinanciamento_Intermediadorclienteid_N ;
      private short gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_N ;
      private short gxTv_SdtFinanciamento_Intermediadorclientedocumento_N ;
      private int gxTv_SdtFinanciamento_Financiamentoid ;
      private int gxTv_SdtFinanciamento_Clienteid ;
      private int gxTv_SdtFinanciamento_Intermediadorclienteid ;
      private int gxTv_SdtFinanciamento_Financiamentoid_Z ;
      private int gxTv_SdtFinanciamento_Clienteid_Z ;
      private int gxTv_SdtFinanciamento_Intermediadorclienteid_Z ;
      private decimal gxTv_SdtFinanciamento_Financiamentovalor ;
      private decimal gxTv_SdtFinanciamento_Financiamentovalor_Z ;
      private string gxTv_SdtFinanciamento_Mode ;
      private string gxTv_SdtFinanciamento_Clienterazaosocial ;
      private string gxTv_SdtFinanciamento_Clientedocumento ;
      private string gxTv_SdtFinanciamento_Financiamentostatus ;
      private string gxTv_SdtFinanciamento_Intermediadorclienterazaosocial ;
      private string gxTv_SdtFinanciamento_Intermediadorclientedocumento ;
      private string gxTv_SdtFinanciamento_Clienterazaosocial_Z ;
      private string gxTv_SdtFinanciamento_Clientedocumento_Z ;
      private string gxTv_SdtFinanciamento_Financiamentostatus_Z ;
      private string gxTv_SdtFinanciamento_Intermediadorclienterazaosocial_Z ;
      private string gxTv_SdtFinanciamento_Intermediadorclientedocumento_Z ;
   }

   [DataContract(Name = @"Financiamento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtFinanciamento_RESTInterface : GxGenericCollectionItem<SdtFinanciamento>
   {
      public SdtFinanciamento_RESTInterface( ) : base()
      {
      }

      public SdtFinanciamento_RESTInterface( SdtFinanciamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FinanciamentoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Financiamentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Financiamentoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Financiamentoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Clienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteRazaoSocial" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Clienterazaosocial
      {
         get {
            return sdt.gxTpr_Clienterazaosocial ;
         }

         set {
            sdt.gxTpr_Clienterazaosocial = value;
         }

      }

      [DataMember( Name = "ClienteDocumento" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Clientedocumento
      {
         get {
            return sdt.gxTpr_Clientedocumento ;
         }

         set {
            sdt.gxTpr_Clientedocumento = value;
         }

      }

      [DataMember( Name = "FinanciamentoValor" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Financiamentovalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Financiamentovalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Financiamentovalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "FinanciamentoStatus" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Financiamentostatus
      {
         get {
            return sdt.gxTpr_Financiamentostatus ;
         }

         set {
            sdt.gxTpr_Financiamentostatus = value;
         }

      }

      [DataMember( Name = "IntermediadorClienteId" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Intermediadorclienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Intermediadorclienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Intermediadorclienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "IntermediadorClienteRazaoSocial" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Intermediadorclienterazaosocial
      {
         get {
            return sdt.gxTpr_Intermediadorclienterazaosocial ;
         }

         set {
            sdt.gxTpr_Intermediadorclienterazaosocial = value;
         }

      }

      [DataMember( Name = "IntermediadorClienteDocumento" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Intermediadorclientedocumento
      {
         get {
            return sdt.gxTpr_Intermediadorclientedocumento ;
         }

         set {
            sdt.gxTpr_Intermediadorclientedocumento = value;
         }

      }

      public SdtFinanciamento sdt
      {
         get {
            return (SdtFinanciamento)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtFinanciamento() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 9 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Financiamento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtFinanciamento_RESTLInterface : GxGenericCollectionItem<SdtFinanciamento>
   {
      public SdtFinanciamento_RESTLInterface( ) : base()
      {
      }

      public SdtFinanciamento_RESTLInterface( SdtFinanciamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "FinanciamentoValor" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Financiamentovalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Financiamentovalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Financiamentovalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtFinanciamento sdt
      {
         get {
            return (SdtFinanciamento)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtFinanciamento() ;
         }
      }

   }

}
