using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
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
   public class prfinalizarvendatitulo : GXProcedure
   {
      public prfinalizarvendatitulo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prfinalizarvendatitulo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ClienteId ,
                           decimal aP1_Taxa ,
                           GXBaseCollection<SdtSdNotaFiscal> aP2_SdNotaFiscal ,
                           GXBaseCollection<SdtSdParcelaCalculadaTaxa> aP3_Array_SdParcelaCalculadaTaxa ,
                           out int aP4_PropostaId ,
                           out SdtSdErro aP5_SdErro )
      {
         this.AV10ClienteId = aP0_ClienteId;
         this.AV12Taxa = aP1_Taxa;
         this.AV8SdNotaFiscal = aP2_SdNotaFiscal;
         this.AV28Array_SdParcelaCalculadaTaxa = aP3_Array_SdParcelaCalculadaTaxa;
         this.AV19PropostaId = 0 ;
         this.AV9SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP4_PropostaId=this.AV19PropostaId;
         aP5_SdErro=this.AV9SdErro;
      }

      public SdtSdErro executeUdp( int aP0_ClienteId ,
                                   decimal aP1_Taxa ,
                                   GXBaseCollection<SdtSdNotaFiscal> aP2_SdNotaFiscal ,
                                   GXBaseCollection<SdtSdParcelaCalculadaTaxa> aP3_Array_SdParcelaCalculadaTaxa ,
                                   out int aP4_PropostaId )
      {
         execute(aP0_ClienteId, aP1_Taxa, aP2_SdNotaFiscal, aP3_Array_SdParcelaCalculadaTaxa, out aP4_PropostaId, out aP5_SdErro);
         return AV9SdErro ;
      }

      public void executeSubmit( int aP0_ClienteId ,
                                 decimal aP1_Taxa ,
                                 GXBaseCollection<SdtSdNotaFiscal> aP2_SdNotaFiscal ,
                                 GXBaseCollection<SdtSdParcelaCalculadaTaxa> aP3_Array_SdParcelaCalculadaTaxa ,
                                 out int aP4_PropostaId ,
                                 out SdtSdErro aP5_SdErro )
      {
         this.AV10ClienteId = aP0_ClienteId;
         this.AV12Taxa = aP1_Taxa;
         this.AV8SdNotaFiscal = aP2_SdNotaFiscal;
         this.AV28Array_SdParcelaCalculadaTaxa = aP3_Array_SdParcelaCalculadaTaxa;
         this.AV19PropostaId = 0 ;
         this.AV9SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP4_PropostaId=this.AV19PropostaId;
         aP5_SdErro=this.AV9SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV15TotalValor = 0;
         AV31GXV1 = 1;
         while ( AV31GXV1 <= AV8SdNotaFiscal.Count )
         {
            AV13ItemSdNotaFiscal = ((SdtSdNotaFiscal)AV8SdNotaFiscal.Item(AV31GXV1));
            AV32GXV2 = 1;
            while ( AV32GXV2 <= AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Det.Count )
            {
               AV14ItemDetSdNotaFiscal = ((SdtSdNotaFiscal_NFe_infNFe_detItem)AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Det.Item(AV32GXV2));
               if ( AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Issel )
               {
                  AV15TotalValor = (decimal)(AV15TotalValor+(NumberUtil.Val( AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Vprod, ".")));
               }
               AV32GXV2 = (int)(AV32GXV2+1);
            }
            AV31GXV1 = (int)(AV31GXV1+1);
         }
         AV20DateTime = DateTimeUtil.ServerNow( context, pr_default);
         AV23OldDateTime = DateTimeUtil.ResetTime( context.localUtil.YMDToD( 2010, 1, 1) ) ;
         AV22Difference = (long)(DateTimeUtil.TDiff( AV20DateTime, AV23OldDateTime));
         AV21PropostaProtocolo = StringUtil.Format( "%1 - %2", StringUtil.Substring( StringUtil.Trim( ((SdtSdNotaFiscal)AV8SdNotaFiscal.Item(1)).gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Xnome), 1, 2), StringUtil.Trim( StringUtil.Str( (decimal)(AV22Difference), 18, 0)), "", "", "", "", "", "", "");
         AV11Proposta = new SdtProposta(context);
         AV11Proposta.gxTpr_Propostadescricao = StringUtil.Format( "Compra de título %1 - R$%2", AV21PropostaProtocolo, StringUtil.LTrimStr( AV15TotalValor, 18, 2), "", "", "", "", "", "", "");
         AV11Proposta.gxTpr_Propostatipoproposta = "COMPRA_TITULO";
         AV11Proposta.gxTpr_Propostavalor = AV15TotalValor;
         AV11Proposta.gxTpr_Propostaprotocolo = AV21PropostaProtocolo;
         AV11Proposta.gxTpr_Propostacreatedat = DateTimeUtil.ServerNow( context, pr_default);
         AV11Proposta.gxTpr_Propostastatus = "EM_ANALISE";
         AV11Proposta.gxTpr_Propostataxaadministrativa = AV12Taxa;
         AV11Proposta.gxTpr_Propostavalorliquido = (decimal)(AV15TotalValor-(AV15TotalValor*(AV12Taxa/ (decimal)(100))));
         AV11Proposta.gxTpr_Propostajurosmora = (decimal)(0);
         AV11Proposta.gxTpr_Propostaempresaclienteid = AV10ClienteId;
         AV11Proposta.Insert();
         if ( AV11Proposta.Success() )
         {
            AV33GXV3 = 1;
            while ( AV33GXV3 <= AV8SdNotaFiscal.Count )
            {
               AV13ItemSdNotaFiscal = ((SdtSdNotaFiscal)AV8SdNotaFiscal.Item(AV33GXV3));
               AV16GUID = Guid.NewGuid( );
               /* Execute user subroutine: 'NEWNOTAFISCAL' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV17NotaFiscal.Save();
               if ( AV17NotaFiscal.Success() )
               {
                  AV34GXV4 = 1;
                  while ( AV34GXV4 <= AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Det.Count )
                  {
                     AV14ItemDetSdNotaFiscal = ((SdtSdNotaFiscal_NFe_infNFe_detItem)AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Det.Item(AV34GXV4));
                     AV16GUID = Guid.NewGuid( );
                     /* Execute user subroutine: 'NEWNOTAFISCALITEM' */
                     S131 ();
                     if ( returnInSub )
                     {
                        cleanup();
                        if (true) return;
                     }
                     AV18NotaFiscalItem.Insert();
                     if ( AV18NotaFiscalItem.Fail() )
                     {
                        AV9SdErro.gxTpr_Internalcode = 1;
                        AV9SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV17NotaFiscal.GetMessages().Item(1)).gxTpr_Description;
                        cleanup();
                        if (true) return;
                     }
                     AV34GXV4 = (int)(AV34GXV4+1);
                  }
                  AV35GXV5 = 1;
                  while ( AV35GXV5 <= AV28Array_SdParcelaCalculadaTaxa.Count )
                  {
                     AV30SdParcelaCalculadaTaxa = ((SdtSdParcelaCalculadaTaxa)AV28Array_SdParcelaCalculadaTaxa.Item(AV35GXV5));
                     AV16GUID = Guid.NewGuid( );
                     AV27NotaFiscalParcelamento = new SdtNotaFiscalParcelamento(context);
                     AV27NotaFiscalParcelamento.gxTpr_Notafiscalparcelamentoid = AV16GUID;
                     AV27NotaFiscalParcelamento.gxTpr_Notafiscalid = AV17NotaFiscal.gxTpr_Notafiscalid;
                     AV27NotaFiscalParcelamento.gxTpr_Notafiscalparcelamentonumero = AV30SdParcelaCalculadaTaxa.gxTpr_Notafiscalnumero;
                     AV27NotaFiscalParcelamento.gxTpr_Notafiscalparcelamentovalor = AV30SdParcelaCalculadaTaxa.gxTpr_Valorbase;
                     AV27NotaFiscalParcelamento.gxTpr_Notafiscalparcelamentovalortaxaadministrativa = AV30SdParcelaCalculadaTaxa.gxTpr_Taxavalor;
                     AV27NotaFiscalParcelamento.gxTpr_Notafiscalparcelamentovalortaxaanual = AV30SdParcelaCalculadaTaxa.gxTpr_Jurosvalor;
                     AV27NotaFiscalParcelamento.gxTpr_Notafiscalparcelamentoliquido = AV30SdParcelaCalculadaTaxa.gxTpr_Valortotal;
                     AV27NotaFiscalParcelamento.gxTpr_Notafiscalparcelamentovencimento = AV30SdParcelaCalculadaTaxa.gxTpr_Vencimento;
                     AV27NotaFiscalParcelamento.Save();
                     if ( AV27NotaFiscalParcelamento.Fail() )
                     {
                        AV9SdErro.gxTpr_Internalcode = 1;
                        AV9SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV27NotaFiscalParcelamento.GetMessages().Item(1)).gxTpr_Description;
                        cleanup();
                        if (true) return;
                     }
                     AV35GXV5 = (int)(AV35GXV5+1);
                  }
               }
               else
               {
                  AV9SdErro.gxTpr_Internalcode = 1;
                  AV9SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV17NotaFiscal.GetMessages().Item(1)).gxTpr_Description;
                  cleanup();
                  if (true) return;
               }
               AV33GXV3 = (int)(AV33GXV3+1);
            }
         }
         else
         {
            AV9SdErro.gxTpr_Internalcode = 1;
            AV9SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV11Proposta.GetMessages().Item(1)).gxTpr_Description;
            cleanup();
            if (true) return;
         }
         AV19PropostaId = AV11Proposta.gxTpr_Propostaid;
         cleanup();
      }

      protected void S111( )
      {
         /* 'NEWNOTAFISCAL' Routine */
         returnInSub = false;
         AV17NotaFiscal = new SdtNotaFiscal(context);
         AV17NotaFiscal.gxTpr_Notafiscalid = AV16GUID;
         AV17NotaFiscal.gxTpr_Notafiscaluf = (short)(Math.Round(NumberUtil.Val( AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Cuf, "."), 18, MidpointRounding.ToEven));
         AV17NotaFiscal.gxTpr_Clienteid = AV10ClienteId;
         AV17NotaFiscal.gxTpr_Notafiscalnatureza = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Natop;
         AV17NotaFiscal.gxTpr_Notafiscalmod = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Mod;
         AV17NotaFiscal.gxTpr_Notafiscalserie = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Serie;
         AV17NotaFiscal.gxTpr_Notafiscalnumero = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Nnf;
         GXt_dtime1 = DateTimeUtil.ResetTime( context.localUtil.CToD( AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Demi, 4) ) ;
         AV17NotaFiscal.gxTpr_Notafiscaldataemissao = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( context.localUtil.CToD( AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Dsaient, 4) ) ;
         AV17NotaFiscal.gxTpr_Notafiscaldatasaida = GXt_dtime1;
         AV17NotaFiscal.gxTpr_Notafiscaltipo = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Tpnf;
         AV17NotaFiscal.gxTpr_Notafiscalmunicipio = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Cmun;
         AV17NotaFiscal.gxTpr_Notafiscaltipoemissao = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Tpemis;
         AV17NotaFiscal.gxTpr_Notafiscalambiente = (short)(Math.Round(NumberUtil.Val( AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Tpamb, "."), 18, MidpointRounding.ToEven));
         AV17NotaFiscal.gxTpr_Notafiscalfinalidades = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Ide.gxTpr_Finnfe;
         AV17NotaFiscal.gxTpr_Notafiscaemitenteldocumento = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Cnpj;
         AV17NotaFiscal.gxTpr_Notafiscalemitentenome = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Xnome;
         AV17NotaFiscal.gxTpr_Notafiscalemitentelogradouro = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Xlgr;
         AV17NotaFiscal.gxTpr_Notafiscalemitentelognum = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Nro;
         AV17NotaFiscal.gxTpr_Notafiscalemitentecomplemento = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Xcpl;
         AV17NotaFiscal.gxTpr_Notafiscalemitentebairro = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Xbairro;
         AV17NotaFiscal.gxTpr_Notafiscalemitentemunicipio = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Xmun;
         AV17NotaFiscal.gxTpr_Notafiscalemitenteuf = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Uf;
         AV17NotaFiscal.gxTpr_Notafiscalemitentecep = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Cep;
         AV17NotaFiscal.gxTpr_Notafiscalemitentepais = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Xpais;
         AV17NotaFiscal.gxTpr_Notafiscalemitentetelefone = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Enderemit.gxTpr_Fone;
         AV17NotaFiscal.gxTpr_Notafiscalemitenteie = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Emit.gxTpr_Ie;
         AV17NotaFiscal.gxTpr_Notafiscaldestinatariodocumento = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Cpf;
         AV17NotaFiscal.gxTpr_Notafiscaldestinatarionome = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Xnome;
         AV17NotaFiscal.gxTpr_Notafiscaldestinatariologradouro = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Xlgr;
         AV17NotaFiscal.gxTpr_Notafiscaldestinatariolognum = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Nro;
         AV17NotaFiscal.gxTpr_Notafiscaldestinatariocomplemento = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Xcpl;
         AV17NotaFiscal.gxTpr_Notafiscaldestinatariobairro = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Xbairro;
         AV17NotaFiscal.gxTpr_Notafiscaldestinatariomunicipio = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Xmun;
         AV17NotaFiscal.gxTpr_Notafiscaldestinatariouf = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Uf;
         AV17NotaFiscal.gxTpr_Notafiscaldestinatariocep = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Cep;
         AV17NotaFiscal.gxTpr_Notafiscaldestinatariopais = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Xpais;
         AV17NotaFiscal.gxTpr_Notafiscaldestinatariofone = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Fone;
         AV24NotaFiscalDestinatarioClienteId = 0;
         /* Execute user subroutine: 'VERIFICAECRIACLIENTE' */
         S121 ();
         if (returnInSub) return;
         if ( (0==AV24NotaFiscalDestinatarioClienteId) )
         {
            AV17NotaFiscal.gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_SetNull();
         }
         else
         {
            AV17NotaFiscal.gxTpr_Notafiscaldestinatarioclienteid = AV24NotaFiscalDestinatarioClienteId;
         }
      }

      protected void S121( )
      {
         /* 'VERIFICAECRIACLIENTE' Routine */
         returnInSub = false;
         AV36GXLvl147 = 0;
         /* Using cursor P00DC2 */
         pr_default.execute(0, new Object[] {AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Cpf});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A169ClienteDocumento = P00DC2_A169ClienteDocumento[0];
            n169ClienteDocumento = P00DC2_n169ClienteDocumento[0];
            A168ClienteId = P00DC2_A168ClienteId[0];
            AV36GXLvl147 = 1;
            AV24NotaFiscalDestinatarioClienteId = A168ClienteId;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV36GXLvl147 == 0 )
         {
            AV25Cliente = new SdtCliente(context);
            AV25Cliente.gxTpr_Clientedocumento = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Cpf;
            AV25Cliente.gxTpr_Clientenomefantasia = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Xnome;
            AV25Cliente.gxTpr_Clienterazaosocial = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Xnome;
            AV25Cliente.gxTpr_Enderecologradouro = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Xlgr;
            AV25Cliente.gxTpr_Endereconumero = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Nro;
            AV25Cliente.gxTpr_Enderecocomplemento = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Xcpl;
            AV25Cliente.gxTpr_Enderecobairro = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Xbairro;
            AV25Cliente.gxTpr_Municipiocodigo = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Xmun;
            AV25Cliente.gxTpr_Enderecocep = AV13ItemSdNotaFiscal.gxTpr_Nfe.gxTpr_Infnfe.gxTpr_Dest.gxTpr_Enderdest.gxTpr_Cep;
            AV25Cliente.Save();
            if ( AV25Cliente.Success() )
            {
               AV24NotaFiscalDestinatarioClienteId = AV25Cliente.gxTpr_Clienteid;
            }
            else
            {
               AV9SdErro.gxTpr_Internalcode = 1;
               AV9SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV25Cliente.GetMessages().Item(1)).gxTpr_Description;
               returnInSub = true;
               if (true) return;
            }
         }
      }

      protected void S131( )
      {
         /* 'NEWNOTAFISCALITEM' Routine */
         returnInSub = false;
         AV18NotaFiscalItem = new SdtNotaFiscalItem(context);
         if ( AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Issel )
         {
            AV18NotaFiscalItem.gxTpr_Propostaid = AV11Proposta.gxTpr_Propostaid;
         }
         AV18NotaFiscalItem.gxTpr_Notafiscalid = AV17NotaFiscal.gxTpr_Notafiscalid;
         AV18NotaFiscalItem.gxTpr_Notafiscalitemid = AV16GUID;
         AV18NotaFiscalItem.gxTpr_Notafiscalitemcodigo = AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Cprod;
         AV18NotaFiscalItem.gxTpr_Notafiscalitemcfop = (short)(Math.Round(NumberUtil.Val( AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Cfop, "."), 18, MidpointRounding.ToEven));
         AV18NotaFiscalItem.gxTpr_Notafiscalitemdescricao = AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Xprod;
         AV18NotaFiscalItem.gxTpr_Notafiscalitemncm = AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Ncm;
         AV18NotaFiscalItem.gxTpr_Notafiscalitemcodigoean = AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Cean;
         AV18NotaFiscalItem.gxTpr_Notafiscalitemunidadecomercial = AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Ucom;
         AV18NotaFiscalItem.gxTpr_Notafiscalitemquantidade = NumberUtil.Val( AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Qcom, ".");
         AV18NotaFiscalItem.gxTpr_Notafiscalitemvalorunitario = NumberUtil.Val( AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Vuncom, ".");
         AV18NotaFiscalItem.gxTpr_Notafiscalitemvalortotal = NumberUtil.Val( AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Vprod, ".");
         AV18NotaFiscalItem.gxTpr_Notafiscalitemcodbargtin = AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Ceantrib;
         AV18NotaFiscalItem.gxTpr_Notafiscalitemunidadetributavel = AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Utrib;
         AV18NotaFiscalItem.gxTpr_Notafiscalitemvaloruntributavel = NumberUtil.Val( AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Vuntrib, ".");
         AV18NotaFiscalItem.gxTpr_Notafiscalitemqtdtributavel = NumberUtil.Val( AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Qtrib, ".");
         AV18NotaFiscalItem.gxTpr_Notafiscalitemvalorfrete = NumberUtil.Val( AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Vfrete, ".");
         AV18NotaFiscalItem.gxTpr_Notafiscalitemdesconto = NumberUtil.Val( AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Vdesc, ".");
         AV18NotaFiscalItem.gxTpr_Notafiscalitemindicadorvalortotal = AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Indtot;
         AV18NotaFiscalItem.gxTpr_Notafiscalitemnumpedido = AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Xped;
         AV18NotaFiscalItem.gxTpr_Notafiscalitemnumitem = AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Nitemped;
         AV18NotaFiscalItem.gxTpr_Notafiscalitemvendido = (AV14ItemDetSdNotaFiscal.gxTpr_Prod.gxTpr_Issel ? "VENDIDO" : "ABERTO");
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
         AV9SdErro = new SdtSdErro(context);
         AV13ItemSdNotaFiscal = new SdtSdNotaFiscal(context);
         AV14ItemDetSdNotaFiscal = new SdtSdNotaFiscal_NFe_infNFe_detItem(context);
         AV20DateTime = (DateTime)(DateTime.MinValue);
         AV23OldDateTime = (DateTime)(DateTime.MinValue);
         AV21PropostaProtocolo = "";
         AV11Proposta = new SdtProposta(context);
         AV16GUID = Guid.Empty;
         AV17NotaFiscal = new SdtNotaFiscal(context);
         AV18NotaFiscalItem = new SdtNotaFiscalItem(context);
         AV30SdParcelaCalculadaTaxa = new SdtSdParcelaCalculadaTaxa(context);
         AV27NotaFiscalParcelamento = new SdtNotaFiscalParcelamento(context);
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         P00DC2_A169ClienteDocumento = new string[] {""} ;
         P00DC2_n169ClienteDocumento = new bool[] {false} ;
         P00DC2_A168ClienteId = new int[1] ;
         A169ClienteDocumento = "";
         AV25Cliente = new SdtCliente(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prfinalizarvendatitulo__default(),
            new Object[][] {
                new Object[] {
               P00DC2_A169ClienteDocumento, P00DC2_n169ClienteDocumento, P00DC2_A168ClienteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV36GXLvl147 ;
      private int AV10ClienteId ;
      private int AV19PropostaId ;
      private int AV31GXV1 ;
      private int AV32GXV2 ;
      private int AV33GXV3 ;
      private int AV34GXV4 ;
      private int AV35GXV5 ;
      private int AV24NotaFiscalDestinatarioClienteId ;
      private int A168ClienteId ;
      private long AV22Difference ;
      private decimal AV12Taxa ;
      private decimal AV15TotalValor ;
      private DateTime AV20DateTime ;
      private DateTime AV23OldDateTime ;
      private DateTime GXt_dtime1 ;
      private bool returnInSub ;
      private bool n169ClienteDocumento ;
      private string AV21PropostaProtocolo ;
      private string A169ClienteDocumento ;
      private Guid AV16GUID ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSdNotaFiscal> AV8SdNotaFiscal ;
      private GXBaseCollection<SdtSdParcelaCalculadaTaxa> AV28Array_SdParcelaCalculadaTaxa ;
      private SdtSdErro AV9SdErro ;
      private SdtSdNotaFiscal AV13ItemSdNotaFiscal ;
      private SdtSdNotaFiscal_NFe_infNFe_detItem AV14ItemDetSdNotaFiscal ;
      private IDataStoreProvider pr_default ;
      private SdtProposta AV11Proposta ;
      private SdtNotaFiscal AV17NotaFiscal ;
      private SdtNotaFiscalItem AV18NotaFiscalItem ;
      private SdtSdParcelaCalculadaTaxa AV30SdParcelaCalculadaTaxa ;
      private SdtNotaFiscalParcelamento AV27NotaFiscalParcelamento ;
      private string[] P00DC2_A169ClienteDocumento ;
      private bool[] P00DC2_n169ClienteDocumento ;
      private int[] P00DC2_A168ClienteId ;
      private SdtCliente AV25Cliente ;
      private int aP4_PropostaId ;
      private SdtSdErro aP5_SdErro ;
   }

   public class prfinalizarvendatitulo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DC2;
          prmP00DC2 = new Object[] {
          new ParDef("AV13Item_1Nfe_1Infnfe_1Dest_1",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DC2", "SELECT ClienteDocumento, ClienteId FROM Cliente WHERE ClienteDocumento = ( RTRIM(LTRIM(:AV13Item_1Nfe_1Infnfe_1Dest_1))) ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DC2,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
