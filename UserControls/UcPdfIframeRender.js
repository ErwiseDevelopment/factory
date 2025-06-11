function UcPdfIframe($) {
	  

	var template = '<!DOCTYPE html><html><head>    <meta charset=\"UTF-8\">    <title>Visualizador de PDF em Base64</title></head><body>        <iframe id=\"pdfViewer\" width=\"100%\" height=\"500px\" frameborder=\"0\"></iframe>    <script>                const prefixoPdf = \"data:application/pdf;base64,\";                                const pdfBase64 = \"{{{BaseString}}}\"                function carregarPdf(base64String) {                    const dataUrl = prefixoPdf + base64String;                                document.getElementById(\"pdfViewer\").src = dataUrl;        }                        function carregarPdfExemplo() {            carregarPdf(pdfBase64);        }                function carregarPdfExterno(novoPdfBase64) {            carregarPdf(novoPdfBase64);        }    </script></body></html>';
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

		this.CarregaPDF = function() {

						carregarPdfExemplo()
				
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