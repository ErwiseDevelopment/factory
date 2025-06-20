function AssinaturaPDF($) {

	var template = '<style>    #signature-container {        display: flex;        flex-direction: column;        align-items: center;        margin-top: 20px;    }    canvas {        border: 2px solid black;    }    #buttons {        margin-top: 10px;    }    #signature-image {        margin-top: 20px;    }</style><h2>Assine no campo abaixo</h2><!-- Canvas onde o usuário desenha a assinatura --><p id=\"TextoImagem\"></p><div id=\"signature-container\">    <h2>Assine no campo abaixo</h2>    <!-- Canvas onde o usuário desenha a assinatura -->    <canvas id=\"signature-canvas\" width=\"400\" height=\"200\"></canvas>    <div id=\"buttons\">        <button id=\"clear-btn\">Limpar</button>		<button id=\"FazerDownload\">Salvar Assinatura</button>    </div>    <!-- Elemento para exibir a imagem da assinatura -->    <img id=\"signature-image\" style=\"display: none;\" alt=\"Assinatura Salva\"/></div>  <script >  	// Função para inicializar o Signature Pad e exibir a assinatura        function exibirAssinatura() {            const canvas = document.getElementById(\'signature-canvas\');            const signaturePad = new SignaturePad(canvas, {                backgroundColor: \'rgb(200, 200, 200)\', // Define um fundo claro            });            // Botão para limpar a assinatura            document.getElementById(\'clear-btn\').addEventListener(\'click\', () => {                signaturePad.clear();            });            return signaturePad; // Retorna a instância do SignaturePad        }        // Função para salvar a assinatura como imagem        function fazerDownloadAssinatura(signaturePad) {            document.getElementById(\'FazerDownload\').addEventListener(\'click\', () => {                if (signaturePad.isEmpty()) {                    alert(\"Por favor, faça uma assinatura primeiro.\");                } else {                    const dataURL = signaturePad.toDataURL(\'image/png\');                    const img = document.getElementById(\'signature-image\');                                        // Exibe a imagem gerada da assinatura                    img.src = dataURL;                    img.style.display = \'block\';                                        // Armazena a imagem em um campo de texto (caso necessário)                    const imagemTexto = document.getElementById(\'ImagemTexto\');                    if (imagemTexto) {                        imagemTexto.innerHTML = dataURL;                    }                }            });        }        // Inicializa as funções        const signaturePad = exibirAssinatura(); // Exibe o SignaturePad        fazerDownloadAssinatura(signaturePad); 		</script>';
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
					var scriptPDF = "https://cdn.jsdelivr.net/npm/signature_pad@4.0.0/dist/signature_pad.umd.min.js";
					
					inserirScript(scriptPDF);
				
		}
		this.ChamarFuncao = function() {

					exibirAssinatura();
				
		}
		this.SalvarAssinatura = function() {

					fazerDownloadAssinatura();
				
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