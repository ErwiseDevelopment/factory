function UCIP($) {
	  

	var template = '<!DOCTYPE html><html><body><script>		var request = new XMLHttpRequest();		request.open(\'GET\', \'https://api.ipify.org?format=json\', false); // Terceiro argumento \'false\' torna a requisição síncrona.		request.send();		if (request.status === 200) {		var data = JSON.parse(request.responseText);		document.getElementById(\'{{{CampoIP}}}\').value = data.ip;		} else {		console.error(\'Erro ao obter o endereço IP:\', request.status);		document.getElementById(\'{{{CampoIP}}}\').value = \'Não foi possível obter o endereço IP.\';		}</script></body></html>';
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