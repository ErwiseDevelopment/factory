function ColorPicker($) {

	var template = '<style>    input[type=\"color\"] {        margin-top: 10px;        cursor: pointer; /* Adiciona o cursor pointer ao color picker */        border: none; /* Remove a borda padrão do color picker */        padding: 0; /* Remove o padding padrão do color picker */        width: 35px;        height: 35px;    }    /* Remove o efeito de foco padrão do color picker */    input[type=\"color\"]:focus {        outline: none;    }</style></head><body>     <input type=\"color\" id=\"color-picker\">    <script>        document.addEventListener(\'DOMContentLoaded\', () => {            const colorPicker = document.getElementById(\'color-picker\');            colorPicker.addEventListener(\'input\', (event) => {                const selectedColor = event.target.value;                console.log(selectedColor);				            });                    });    </script></body>';
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