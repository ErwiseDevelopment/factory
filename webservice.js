gx.evt.autoSkip=!1;gx.define("webservice",!1,function(){var n,t;this.ServerClass="webservice";this.PackageName="GeneXus.Programs";this.ServerFullClass="webservice";this.setObjectType("trn");this.hasEnterEvent=!0;this.skipOnEnter=!1;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="WorkWithPlusDS";this.SetStandaloneVars=function(){this.A658WebServiceEndPoint=gx.fn.getControlValue("WEBSERVICEENDPOINT");this.A1061WebServiceEndPointDecrypted=gx.fn.getControlValue("WEBSERVICEENDPOINTDECRYPTED");this.A659WebServiceAuthTipo=gx.fn.getControlValue("WEBSERVICEAUTHTIPO");this.A1062WebServiceAuthTipoDecrypted=gx.fn.getControlValue("WEBSERVICEAUTHTIPODECRYPTED");this.A660WebServiceUsuario=gx.fn.getControlValue("WEBSERVICEUSUARIO");this.A1063WebServiceUsuarioDecrypted=gx.fn.getControlValue("WEBSERVICEUSUARIODECRYPTED");this.A661WebServiceSenha=gx.fn.getControlValue("WEBSERVICESENHA");this.A1064WebServiceSenhaDecrypted=gx.fn.getControlValue("WEBSERVICESENHADECRYPTED");this.A1055WebServiceCertificadoBase64=gx.fn.getControlValue("WEBSERVICECERTIFICADOBASE64");this.A1065WebServiceCertificadoBase64Decrypted=gx.fn.getControlValue("WEBSERVICECERTIFICADOBASE64DECRYPTED");this.A1056WebServiceCertificadoPass=gx.fn.getControlValue("WEBSERVICECERTIFICADOPASS");this.A1066WebServiceCertificadoPassDecrypted=gx.fn.getControlValue("WEBSERVICECERTIFICADOPASSDECRYPTED");this.A1059WebServiceClientid=gx.fn.getControlValue("WEBSERVICECLIENTID");this.A1067WebServiceClientidDecrypted=gx.fn.getControlValue("WEBSERVICECLIENTIDDECRYPTED");this.A1060WebServiceClientSecret=gx.fn.getControlValue("WEBSERVICECLIENTSECRET");this.A1068WebServiceClientSecretDecrypted=gx.fn.getControlValue("WEBSERVICECLIENTSECRETDECRYPTED");this.AV7WebServiceId=gx.fn.getIntegerValue("vWEBSERVICEID",".");this.A1054WebServiceSalt=gx.fn.getControlValue("WEBSERVICESALT");this.Gx_mode=gx.fn.getControlValue("vMODE");this.AV9TrnContext=gx.fn.getControlValue("vTRNCONTEXT")};this.Valid_Webserviceid=function(){return this.validCliEvt("Valid_Webserviceid",0,function(){try{var n=gx.util.balloon.getNew("WEBSERVICEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Webservicetipodmws=function(){return this.validCliEvt("Valid_Webservicetipodmws",0,function(){try{var n=gx.util.balloon.getNew("WEBSERVICETIPODMWS");if(this.AnyError=0,!(gx.text.compare(this.A657WebServiceTipoDmWS,"Serasa_AUTH")==0||gx.text.compare(this.A657WebServiceTipoDmWS,"Serasa_PROPOSTA_PF")==0||gx.text.compare(this.A657WebServiceTipoDmWS,"Santander")==0||gx.text.compare("",this.A657WebServiceTipoDmWS)===0))try{n.setError("Campo Tipo WS fora do intervalo");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e122d2_client=function(){return this.executeServerEvent("AFTER TRN",!0,null,!1,!1)};this.e132d83_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e142d83_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35];this.GXLastCtrlId=35;this.DVPANEL_TABLEATTRIBUTESContainer=gx.uc.getNew(this,15,0,"BootstrapPanel","DVPANEL_TABLEATTRIBUTESContainer","Dvpanel_tableattributes","DVPANEL_TABLEATTRIBUTES");t=this.DVPANEL_TABLEATTRIBUTESContainer;t.setProp("Class","Class","","char");t.setProp("Enabled","Enabled",!0,"boolean");t.setProp("Width","Width","100%","str");t.setProp("Height","Height","100","str");t.setProp("AutoWidth","Autowidth",!1,"bool");t.setProp("AutoHeight","Autoheight",!0,"bool");t.setProp("Cls","Cls","PanelCard_GrayTitle","str");t.setProp("ShowHeader","Showheader",!0,"bool");t.setProp("Title","Title","Informações Gerais","str");t.setProp("TitleType","Titletype","Text","str");t.setProp("Collapsible","Collapsible",!1,"bool");t.setProp("Collapsed","Collapsed",!1,"bool");t.setProp("ShowCollapseIcon","Showcollapseicon",!1,"bool");t.setProp("IconPosition","Iconposition","Right","str");t.setProp("AutoScroll","Autoscroll",!1,"bool");t.setProp("Visible","Visible",!0,"bool");t.setProp("Gx Control Type","Gxcontroltype","","int");t.setC2ShowFunction(function(n){n.show()});this.setUserControl(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLEMAIN",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"TABLECONTENT",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[17]={id:17,fld:"TABLEATTRIBUTES",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Valid_Webservicetipodmws,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WEBSERVICETIPODMWS",fmt:0,gxz:"Z657WebServiceTipoDmWS",gxold:"O657WebServiceTipoDmWS",gxvar:"A657WebServiceTipoDmWS",ucs:[],op:[22],ip:[22],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.A657WebServiceTipoDmWS=n)},v2z:function(n){n!==undefined&&(gx.O.Z657WebServiceTipoDmWS=n)},v2c:function(){gx.fn.setComboBoxValue("WEBSERVICETIPODMWS",gx.O.A657WebServiceTipoDmWS);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A657WebServiceTipoDmWS=this.val())},val:function(){return gx.fn.getControlValue("WEBSERVICETIPODMWS")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){});n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,fld:"",grid:0};n[27]={id:27,fld:"BTNTRN_ENTER",grid:0,evt:"e132d83_client",std:"ENTER"};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"BTNTRN_CANCEL",grid:0,evt:"e142d83_client"};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"BTNTRN_DELETE",grid:0,evt:"e152d83_client",std:"DELETE"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};n[35]={id:35,lvl:0,type:"int",len:9,dec:0,sign:!1,emptyAsNull:"Blank",pic:"ZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Webserviceid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"WEBSERVICEID",fmt:0,gxz:"Z656WebServiceId",gxold:"O656WebServiceId",gxvar:"A656WebServiceId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A656WebServiceId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z656WebServiceId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("WEBSERVICEID",gx.O.A656WebServiceId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A656WebServiceId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("WEBSERVICEID",".")},nac:gx.falseFn};this.declareDomainHdlr(35,function(){});this.A657WebServiceTipoDmWS="";this.Z657WebServiceTipoDmWS="";this.O657WebServiceTipoDmWS="";this.A656WebServiceId=0;this.Z656WebServiceId=0;this.O656WebServiceId=0;this.AV8WWPContext={UserId:0,UserName:"",UserFullname:"",Expire:gx.date.nullDate(),OwnerId:0,IsAprover:!1,IsCliente:!1,SecUserClienteId:0,SecUserAnalista:!1,AprovadorId:0};this.AV9TrnContext={CallerObject:"",CallerOnDelete:!1,CallerURL:"",TransactionName:"",Attributes:[]};this.AV7WebServiceId=0;this.AV10WebSession={};this.A656WebServiceId=0;this.A1068WebServiceClientSecretDecrypted="";this.A1067WebServiceClientidDecrypted="";this.A1066WebServiceCertificadoPassDecrypted="";this.A1065WebServiceCertificadoBase64Decrypted="";this.A1064WebServiceSenhaDecrypted="";this.A1063WebServiceUsuarioDecrypted="";this.A1062WebServiceAuthTipoDecrypted="";this.A1061WebServiceEndPointDecrypted="";this.A657WebServiceTipoDmWS="";this.A658WebServiceEndPoint="";this.A659WebServiceAuthTipo="";this.A660WebServiceUsuario="";this.A661WebServiceSenha="";this.A1054WebServiceSalt="";this.A1055WebServiceCertificadoBase64="";this.A1056WebServiceCertificadoPass="";this.A1059WebServiceClientid="";this.A1060WebServiceClientSecret="";this.Gx_mode="";this.Events={e122d2_client:["AFTER TRN",!0],e132d83_client:["ENTER",!0],e142d83_client:["CANCEL",!0]};this.EvtParms.ENTER=[[{postForm:!0},{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0,type:"char"},{av:"AV7WebServiceId",fld:"vWEBSERVICEID",pic:"ZZZZZZZZ9",hsh:!0,type:"int"}],[]];this.EvtParms.REFRESH=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0,type:"char"},{av:"AV9TrnContext",fld:"vTRNCONTEXT",hsh:!0,type:""},{av:"AV7WebServiceId",fld:"vWEBSERVICEID",pic:"ZZZZZZZZ9",hsh:!0,type:"int"},{av:"A656WebServiceId",fld:"WEBSERVICEID",pic:"ZZZZZZZZ9",type:"int"}],[]];this.EvtParms["AFTER TRN"]=[[{av:"Gx_mode",fld:"vMODE",pic:"@!",hsh:!0,type:"char"},{av:"AV9TrnContext",fld:"vTRNCONTEXT",hsh:!0,type:""}],[]];this.EvtParms.VALID_WEBSERVICETIPODMWS=[[{ctrl:"WEBSERVICETIPODMWS"},{av:"A657WebServiceTipoDmWS",fld:"WEBSERVICETIPODMWS",type:"svchar"}],[{ctrl:"WEBSERVICETIPODMWS"},{av:"A657WebServiceTipoDmWS",fld:"WEBSERVICETIPODMWS",type:"svchar"}]];this.EvtParms.VALID_WEBSERVICEID=[[],[]];this.EnterCtrl=["BTNTRN_ENTER"];this.setVCMap("A658WebServiceEndPoint","WEBSERVICEENDPOINT",0,"vchar",2097152,0);this.setVCMap("A1061WebServiceEndPointDecrypted","WEBSERVICEENDPOINTDECRYPTED",0,"vchar",2097152,0);this.setVCMap("A659WebServiceAuthTipo","WEBSERVICEAUTHTIPO",0,"vchar",2097152,0);this.setVCMap("A1062WebServiceAuthTipoDecrypted","WEBSERVICEAUTHTIPODECRYPTED",0,"vchar",2097152,0);this.setVCMap("A660WebServiceUsuario","WEBSERVICEUSUARIO",0,"vchar",2097152,0);this.setVCMap("A1063WebServiceUsuarioDecrypted","WEBSERVICEUSUARIODECRYPTED",0,"vchar",2097152,0);this.setVCMap("A661WebServiceSenha","WEBSERVICESENHA",0,"vchar",2097152,0);this.setVCMap("A1064WebServiceSenhaDecrypted","WEBSERVICESENHADECRYPTED",0,"vchar",2097152,0);this.setVCMap("A1055WebServiceCertificadoBase64","WEBSERVICECERTIFICADOBASE64",0,"vchar",2097152,0);this.setVCMap("A1065WebServiceCertificadoBase64Decrypted","WEBSERVICECERTIFICADOBASE64DECRYPTED",0,"vchar",2097152,0);this.setVCMap("A1056WebServiceCertificadoPass","WEBSERVICECERTIFICADOPASS",0,"vchar",2097152,0);this.setVCMap("A1066WebServiceCertificadoPassDecrypted","WEBSERVICECERTIFICADOPASSDECRYPTED",0,"vchar",2097152,0);this.setVCMap("A1059WebServiceClientid","WEBSERVICECLIENTID",0,"vchar",2097152,0);this.setVCMap("A1067WebServiceClientidDecrypted","WEBSERVICECLIENTIDDECRYPTED",0,"vchar",2097152,0);this.setVCMap("A1060WebServiceClientSecret","WEBSERVICECLIENTSECRET",0,"vchar",2097152,0);this.setVCMap("A1068WebServiceClientSecretDecrypted","WEBSERVICECLIENTSECRETDECRYPTED",0,"vchar",2097152,0);this.setVCMap("AV7WebServiceId","vWEBSERVICEID",0,"int",9,0);this.setVCMap("A1054WebServiceSalt","WEBSERVICESALT",0,"vchar",2097152,0);this.setVCMap("Gx_mode","vMODE",0,"char",3,0);this.setVCMap("AV9TrnContext","vTRNCONTEXT",0,"WorkWithPlus_CommonObjectsWWPTransactionContext",0,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.webservice)})