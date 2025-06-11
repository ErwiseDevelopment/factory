function UCLocationParam($) {
	  
	  

	var template = '<script>	 function verificarPermissaoGeolocalizacao() {		if (navigator.permissions) {			navigator.permissions.query({ name: \'geolocation\' }).then(function(result) {			if (result.state === \'granted\') {				// A permissão foi concedida				obterLocalizacao();			} else if (result.state === \'prompt\') {				// A permissão ainda não foi solicitada				solicitarLocalizacao();			} else if (result.state === \'denied\') {				// A permissão foi negada				informarUsuarioParaHabilitarPermissao();			}			result.onchange = function() {				// Monitora mudanças na permissão				verificarPermissaoGeolocalizacao();			};			});		} else {			// O navegador não suporta a API Permissions			solicitarLocalizacao();		}		}				function solicitarLocalizacao() {		if (navigator.geolocation) {			navigator.geolocation.getCurrentPosition(sucesso, erro);		} else {			alert(\'Geolocalização não é suportada por este navegador.\');		}		}				function obterLocalizacao() {		navigator.geolocation.getCurrentPosition(sucesso, erro);		}				function sucesso(position) {		const lati = position.coords.latitude;		const longi = position.coords.longitude;				const campolati = document.getElementById(\'{{Latitude}}\');		const campolongi = document.getElementById(\'{{Longitude}}\');		campolati.value = lati;		campolongi.value = longi;		console.log(\'Latitude: \' + lati);		console.log(\'Longitude: \' + longi);		}				function erro(error) {		switch (error.code) {			case error.PERMISSION_DENIED:			console.log(\'Usuário negou a solicitação de localização.\');			informarUsuarioParaHabilitarPermissao();			break;			case error.POSITION_UNAVAILABLE:			console.log(\'Informação de localização não disponível.\');			break;			case error.TIMEOUT:			console.log(\'A solicitação de localização expirou.\');			break;			case error.UNKNOWN_ERROR:			console.log(\'Um erro desconhecido ocorreu.\');			break;		}		}				function informarUsuarioParaHabilitarPermissao() {		const mensagem = \'Para utilizar esta funcionalidade, por favor habilite a geolocalização nas configurações do seu navegador.\';		alert(mensagem);		// Você pode redirecionar o usuário para uma página de ajuda ou fornecer instruções diretamente aqui		}				// Iniciar o processo ao carregar a página		document.addEventListener(\'DOMContentLoaded\', verificarPermissaoGeolocalizacao);</script>';
	var partials = {  }; 
	Mustache.parse(template);
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts


			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();



			// Raise after show scripts

	}

	this.Scripts = [];

		this.RequestLocation = function() {

				function verificarPermissaoGeolocalizacao() {
					if (navigator.permissions) {
						navigator.permissions.query({ name: 'geolocation' }).then(function(result) {
						if (result.state === 'granted') {
							// A permissão foi concedida
							obterLocalizacao();
						} else if (result.state === 'prompt') {
							// A permissão ainda não foi solicitada
							solicitarLocalizacao();
						} else if (result.state === 'denied') {
							// A permissão foi negada
							informarUsuarioParaHabilitarPermissao();
						}
						result.onchange = function() {
							// Monitora mudanças na permissão
							verificarPermissaoGeolocalizacao();
						};
						});
					} else {
						// O navegador não suporta a API Permissions
						solicitarLocalizacao();
					}
					}
					
					function solicitarLocalizacao() {
					if (navigator.geolocation) {
						navigator.geolocation.getCurrentPosition(sucesso, erro);
					} else {
						alert('Geolocalização não é suportada por este navegador.');
					}
					}
					
					function obterLocalizacao() {
					navigator.geolocation.getCurrentPosition(sucesso, erro);
					}
					
					function sucesso(position) {
					const lati = position.coords.latitude;
					const longi = position.coords.longitude;
					
					const campolati = document.getElementById('{{Latitude}}');
					const campolongi = document.getElementById('{{Longitude}}');
					campolati.value = lati;
					campolongi.value = longi;
					console.log('Latitude: ' + lati);
					console.log('Longitude: ' + longi);
					}
					
					function erro(error) {
					switch (error.code) {
						case error.PERMISSION_DENIED:
						console.log('Usuário negou a solicitação de localização.');
						informarUsuarioParaHabilitarPermissao();
						break;
						case error.POSITION_UNAVAILABLE:
						console.log('Informação de localização não disponível.');
						break;
						case error.TIMEOUT:
						console.log('A solicitação de localização expirou.');
						break;
						case error.UNKNOWN_ERROR:
						console.log('Um erro desconhecido ocorreu.');
						break;
					}
					}
					
					function informarUsuarioParaHabilitarPermissao() {
						const mensagem = 'Para utilizar esta funcionalidade, por favor habilite a geolocalização nas configurações do seu navegador.';
						alert(mensagem);
						// Você pode redirecionar o usuário para uma página de ajuda ou fornecer instruções diretamente aqui
					}
					verificarPermissaoGeolocalizacao();
					
			  
		}



	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}