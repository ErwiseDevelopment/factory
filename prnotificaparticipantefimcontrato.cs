using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prnotificaparticipantefimcontrato : GXProcedure
   {
      public prnotificaparticipantefimcontrato( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prnotificaparticipantefimcontrato( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( GXBaseCollection<SdtSdParticipantesContrato> aP0_Array_SdParticipantesContrato ,
                           string aP1_ContratoNome ,
                           string aP2_Link ,
                           string aP3_Hash ,
                           string aP4_Source )
      {
         this.AV8Array_SdParticipantesContrato = aP0_Array_SdParticipantesContrato;
         this.AV9ContratoNome = aP1_ContratoNome;
         this.AV11Link = aP2_Link;
         this.AV10Hash = aP3_Hash;
         this.AV16Source = aP4_Source;
         initialize();
         ExecuteImpl();
      }

      public void executeSubmit( GXBaseCollection<SdtSdParticipantesContrato> aP0_Array_SdParticipantesContrato ,
                                 string aP1_ContratoNome ,
                                 string aP2_Link ,
                                 string aP3_Hash ,
                                 string aP4_Source )
      {
         this.AV8Array_SdParticipantesContrato = aP0_Array_SdParticipantesContrato;
         this.AV9ContratoNome = aP1_ContratoNome;
         this.AV11Link = aP2_Link;
         this.AV10Hash = aP3_Hash;
         this.AV16Source = aP4_Source;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV8Array_SdParticipantesContrato.Count )
         {
            AV12SdParticipantesContrato = ((SdtSdParticipantesContrato)AV8Array_SdParticipantesContrato.Item(AV19GXV1));
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12SdParticipantesContrato.gxTpr_Participantenome)) )
            {
               AV18Nome = AV12SdParticipantesContrato.gxTpr_Participantenome;
            }
            else
            {
               AV18Nome = StringUtil.Format( "%1 (%2)", AV12SdParticipantesContrato.gxTpr_Participanterepresentantenome, AV12SdParticipantesContrato.gxTpr_Participantenome, "", "", "", "", "", "", "");
            }
            GXt_char1 = AV13Html;
            GXt_char2 = AV13Html;
            new initcap(context ).execute(  AV18Nome, out  GXt_char2) ;
            new premailfinalassinatura(context ).execute(  AV9ContratoNome,  GXt_char2,  AV11Link,  AV10Hash, out  GXt_char1) ;
            AV13Html = GXt_char1;
            AV14Array_Email = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV17email = (String.IsNullOrEmpty(StringUtil.RTrim( AV12SdParticipantesContrato.gxTpr_Participanterepresentanteemail)) ? AV12SdParticipantesContrato.gxTpr_Participanteemail : AV12SdParticipantesContrato.gxTpr_Participanterepresentanteemail);
            AV14Array_Email.Add(AV17email, 0);
            new sendemailanexo(context ).execute(  "Assinatura completa ("+StringUtil.Trim( AV9ContratoNome)+")",  AV13Html,  AV14Array_Email,  AV16Source, out  AV15Message) ;
            AV19GXV1 = (int)(AV19GXV1+1);
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV12SdParticipantesContrato = new SdtSdParticipantesContrato(context);
         AV18Nome = "";
         AV13Html = "";
         GXt_char1 = "";
         GXt_char2 = "";
         AV14Array_Email = new GxSimpleCollection<string>();
         AV17email = "";
         AV15Message = "";
         /* GeneXus formulas. */
      }

      private int AV19GXV1 ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private string AV13Html ;
      private string AV9ContratoNome ;
      private string AV11Link ;
      private string AV10Hash ;
      private string AV16Source ;
      private string AV18Nome ;
      private string AV17email ;
      private string AV15Message ;
      private GXBaseCollection<SdtSdParticipantesContrato> AV8Array_SdParticipantesContrato ;
      private SdtSdParticipantesContrato AV12SdParticipantesContrato ;
      private GxSimpleCollection<string> AV14Array_Email ;
   }

}
