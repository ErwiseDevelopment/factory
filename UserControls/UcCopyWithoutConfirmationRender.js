function UcCopyWithoutConfirmation($) {

	var template = '<script> function copiarTexto(Texto) {    const texto = Texto;    if (navigator.clipboard) {        // Usando a API Clipboard, se disponível       navigator.clipboard.writeText(texto).catch(err => console.error(\"Erro ao copiar:\", err));    } else {        // Fallback para navegadores mais antigos        const inputAuxiliar = document.createElement(\"textarea\");        inputAuxiliar.value = texto;        document.body.appendChild(inputAuxiliar);        inputAuxiliar.select();        document.execCommand(\"copy\");        document.body.removeChild(inputAuxiliar);      }}</script>';
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

		this.Copy = function(Texto ) {

			      copiarTexto(Texto)
			  
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