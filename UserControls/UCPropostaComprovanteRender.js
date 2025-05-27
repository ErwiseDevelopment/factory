function UCPropostaComprovante($) {

	var template = '<script>	// Função para baixar o PDF	function downloadPDF() {        const element = document.getElementById(\'propostaContent\');        element.classList.add(\'pdf-mode\');        const opt = {          margin: [10, 10, 10, 10],          filename: \"proposta.pdf\",          image: {            type: \"jpeg\",            quality: 0.98          },          html2canvas: {            scale: 2          },          jsPDF: {            unit: \"mm\",            format: \"a4\",            orientation: \"portrait\"          },          pagebreak: {            mode: [\"avoid-all\", \"css\", \"legacy\"]          }        };        html2pdf().set(opt).from(element).save().then(() => {          element.classList.remove(\"pdf-mode\");        });      }</script>';
	var partials = {  }; 
	Mustache.parse(template);
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts
			this.Header(); 


			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this, partials));
			this.renderChildContainers();



			// Raise after show scripts

	}

	this.Scripts = [];

		this.Header = function() {

					// Função para inserir um script no head
					function inserirScript(url) {
						var script = document.createElement('script');
						script.src = url;
						script.type = 'text/javascript';
						document.head.appendChild(script);
					};
					// URLs dos scripts
					var scriptPDF = "https://cdnjs.cloudflare.com/ajax/libs/html2pdf.js/0.10.1/html2pdf.bundle.min.js";
					
					inserirScript(scriptPDF);
				
		}
		this.DownloadPDF = function() {

					
					 const element = document.getElementById('propostaContent');
			        element.classList.add('pdf-mode');
			        const opt = {
			          margin: [10, 10, 10, 10],
			          filename: "proposta.pdf",
			          image: {
			            type: "jpeg",
			            quality: 0.98
			          },
			          html2canvas: {
			            scale: 2
			          },
			          jsPDF: {
			            unit: "mm",
			            format: "a4",
			            orientation: "portrait"
			          },
			          pagebreak: {
			            mode: ["avoid-all", "css", "legacy"]
			          }
			        };
			        html2pdf().set(opt).from(element).save().then(() =&gt; {
			          element.classList.remove("pdf-mode");
			        });
					
				
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