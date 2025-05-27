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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prnewassinaturaparticipantes : GXProcedure
   {
      public prnewassinaturaparticipantes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prnewassinaturaparticipantes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( long aP0_AssinaturaId ,
                           GXBaseCollection<SdtSdParticipantes> aP1_Array_SdParticipantes ,
                           out SdtSdErro aP2_SdErro )
      {
         this.AV9AssinaturaId = aP0_AssinaturaId;
         this.AV8Array_SdParticipantes = aP1_Array_SdParticipantes;
         this.AV10SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP2_SdErro=this.AV10SdErro;
      }

      public SdtSdErro executeUdp( long aP0_AssinaturaId ,
                                   GXBaseCollection<SdtSdParticipantes> aP1_Array_SdParticipantes )
      {
         execute(aP0_AssinaturaId, aP1_Array_SdParticipantes, out aP2_SdErro);
         return AV10SdErro ;
      }

      public void executeSubmit( long aP0_AssinaturaId ,
                                 GXBaseCollection<SdtSdParticipantes> aP1_Array_SdParticipantes ,
                                 out SdtSdErro aP2_SdErro )
      {
         this.AV9AssinaturaId = aP0_AssinaturaId;
         this.AV8Array_SdParticipantes = aP1_Array_SdParticipantes;
         this.AV10SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP2_SdErro=this.AV10SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10SdErro = new SdtSdErro(context);
         AV10SdErro.gxTpr_Status = 200;
         AV22GXV1 = 1;
         while ( AV22GXV1 <= AV8Array_SdParticipantes.Count )
         {
            AV11SdParticipantes = ((SdtSdParticipantes)AV8Array_SdParticipantes.Item(AV22GXV1));
            if ( (0==AV11SdParticipantes.gxTpr_Participanteid) )
            {
               AV17Participante = new SdtParticipante(context);
               AV17Participante.gxTpr_Participantedocumento = AV11SdParticipantes.gxTpr_Participantedocumento;
               AV17Participante.gxTpr_Participanteemail = AV11SdParticipantes.gxTpr_Participanteemail;
               AV17Participante.gxTpr_Participantenome = AV11SdParticipantes.gxTpr_Participantenome;
               AV17Participante.gxTpr_Participantetipopessoa = AV11SdParticipantes.gxTpr_Participantetipopessoa;
               AV17Participante.gxTpr_Participanterepresentantenome = AV11SdParticipantes.gxTpr_Participanterepresentantenome;
               AV17Participante.gxTpr_Participanterepresentanteemail = AV11SdParticipantes.gxTpr_Participanterepresentanteemail;
               AV17Participante.gxTpr_Participanterepresentantedocumento = AV11SdParticipantes.gxTpr_Participanterepresentantedocumento;
               AV17Participante.Save();
               if ( AV13AssinaturaParticipante.Fail() )
               {
                  AV14Message = ((GeneXus.Utils.SdtMessages_Message)AV17Participante.GetMessages().Item(1)).gxTpr_Description;
                  AV10SdErro.gxTpr_Msg = AV14Message;
                  AV10SdErro.gxTpr_Status = 401;
                  AV10SdErro.gxTpr_Internalcode = 1;
                  cleanup();
                  if (true) return;
               }
               else
               {
                  AV11SdParticipantes.gxTpr_Participanteid = AV17Participante.gxTpr_Participanteid;
               }
            }
            AV12AssinaturaParticipanteKey = Guid.NewGuid( );
            AV13AssinaturaParticipante = new SdtAssinaturaParticipante(context);
            AV13AssinaturaParticipante.gxTpr_Participanteid = AV11SdParticipantes.gxTpr_Participanteid;
            AV13AssinaturaParticipante.gxTpr_Assinaturaid = AV9AssinaturaId;
            AV13AssinaturaParticipante.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedatavisualizacao_SetNull();
            AV13AssinaturaParticipante.gxTv_SdtAssinaturaParticipante_Assinaturaparticipantedataconclusao_SetNull();
            AV13AssinaturaParticipante.gxTpr_Assinaturaparticipantekey = AV12AssinaturaParticipanteKey;
            AV13AssinaturaParticipante.gxTpr_Assinaturaparticipantetipo = AV11SdParticipantes.gxTpr_Assinaturaparticipantetipo;
            AV13AssinaturaParticipante.gxTpr_Assinaturaparticipantestatus = "Pendente";
            AV13AssinaturaParticipante.gxTpr_Clienteid = AV11SdParticipantes.gxTpr_Clienteid;
            AV13AssinaturaParticipante.Save();
            AV16AssinaturaParticipanteId = AV13AssinaturaParticipante.gxTpr_Assinaturaparticipanteid;
            if ( AV13AssinaturaParticipante.Fail() )
            {
               AV14Message = ((GeneXus.Utils.SdtMessages_Message)AV13AssinaturaParticipante.GetMessages().Item(1)).gxTpr_Description;
               AV10SdErro.gxTpr_Msg = AV14Message;
               AV10SdErro.gxTpr_Status = 401;
               AV10SdErro.gxTpr_Internalcode = 1;
               cleanup();
               if (true) return;
            }
            else
            {
               AV13AssinaturaParticipante.Load(AV16AssinaturaParticipanteId);
               GXt_char1 = AV19Chave;
               new prchave(context ).execute( out  GXt_char1) ;
               AV19Chave = GXt_char1;
               AV20Parametro = Encrypt64( StringUtil.Trim( StringUtil.Str( (decimal)(AV16AssinaturaParticipanteId), 9, 0)), AV19Chave);
               AV13AssinaturaParticipante.gxTpr_Assinaturaparticipantelink = AV15HTTPREQUEST.BaseURL+formatLink("confirmacao", new object[] {GXUtil.UrlEncode(StringUtil.RTrim(AV20Parametro))}, new string[] {"Parametro"}) ;
               AV13AssinaturaParticipante.Save();
               if ( AV13AssinaturaParticipante.Fail() )
               {
                  AV14Message = ((GeneXus.Utils.SdtMessages_Message)AV13AssinaturaParticipante.GetMessages().Item(1)).gxTpr_Description;
                  AV10SdErro.gxTpr_Msg = AV14Message;
                  AV10SdErro.gxTpr_Status = 401;
                  AV10SdErro.gxTpr_Internalcode = 1;
                  cleanup();
                  if (true) return;
               }
            }
            AV22GXV1 = (int)(AV22GXV1+1);
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
         AV10SdErro = new SdtSdErro(context);
         AV11SdParticipantes = new SdtSdParticipantes(context);
         AV17Participante = new SdtParticipante(context);
         AV13AssinaturaParticipante = new SdtAssinaturaParticipante(context);
         AV14Message = "";
         AV12AssinaturaParticipanteKey = Guid.Empty;
         AV19Chave = "";
         GXt_char1 = "";
         AV20Parametro = "";
         AV15HTTPREQUEST = new GxHttpRequest( context);
         /* GeneXus formulas. */
      }

      private int AV22GXV1 ;
      private int AV16AssinaturaParticipanteId ;
      private long AV9AssinaturaId ;
      private string GXt_char1 ;
      private string AV14Message ;
      private string AV19Chave ;
      private string AV20Parametro ;
      private Guid AV12AssinaturaParticipanteKey ;
      private GxHttpRequest AV15HTTPREQUEST ;
      private GXBaseCollection<SdtSdParticipantes> AV8Array_SdParticipantes ;
      private SdtSdErro AV10SdErro ;
      private SdtSdParticipantes AV11SdParticipantes ;
      private SdtParticipante AV17Participante ;
      private SdtAssinaturaParticipante AV13AssinaturaParticipante ;
      private SdtSdErro aP2_SdErro ;
   }

}
