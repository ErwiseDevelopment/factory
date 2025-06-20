function VisualizarPDF($) {

	var template = '<style>    #pdf-container {        position: absolute;        width: 890px;        height: auto;        border: 1px solid #000;        left: 50%;        transform: translate(-50%);    }    #pdf-render {        position: absolute;        left: 0;        top: 0;        z-index: 0;    }    #drawing-layer {        position: absolute;        left: 0;        top: 0;        z-index: 1;        cursor: crosshair;    }    .retangulo {        display: none;    }</style><input type=\"file\" id=\"pdf-upload\" accept=\"application/pdf\" onchange=\"handleFileChange(event)\"></br><button id=\"signature-btn\">Assinar</button><spam class=\"retangulo\">    <p id=\"x\"></p>    <p id=\"y\"></p>    <p id=\"width\"></p>    <p id=\"height\"></p>    <p id=\"arquivo\"></p></spam><div id=\"pdf-container\">    <!-- Canvas onde o PDF será renderizado -->    <canvas id=\"pdf-render\"></canvas>    <!-- Canvas para desenhar retângulos e assinar -->    <canvas id=\"drawing-layer\"></canvas></div><script src=\"https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.10.377/pdf.min.js\"></script><script>    const self = this;    const pdfjsLib = window[\'pdfjs-dist/build/pdf\'];    pdfjsLib.GlobalWorkerOptions.workerSrc = \'https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.10.377/pdf.worker.min.js\';    let isDrawingSignature = false;    let isSignatureMode = false;    // Função de manipulação do evento de mudança de arquivo    function handleFileChange(event) {        const file = event.target.files[0];        // Verifique se um arquivo foi selecionado        if (!file) {            alert(\'Nenhum arquivo selecionado. Por favor, escolha um arquivo PDF.\');            return;        }        // Verifique se o tipo de arquivo é PDF        if (file.type !== \'application/pdf\') {            alert(\'O arquivo selecionado não é um PDF. Por favor, selecione um arquivo PDF.\');            return;        }        // Converte o arquivo para Blob e então para uma string base64        const reader = new FileReader();        reader.onload = function(e) {            const base64String = e.target.result.split(\',\')[1];             var arquivoBase64 = base64String;            var arquivo = document.getElementById(\'arquivo\');            arquivo.innerHTML = arquivoBase64;        };        reader.readAsDataURL(file);        // Criar URL temporária        try {            const fileUrl = URL.createObjectURL(file);            loadPDF(fileUrl); // Carregar o PDF        } catch (error) {            console.error(\'Erro ao criar URL temporária para o arquivo:\', error);            alert(\'Não foi possível processar o arquivo selecionado.\');        }    }    // Função para carregar o PDF    function loadPDF(url) {        const pdfjsLib = window[\'pdfjs-dist/build/pdf\'];        pdfjsLib.getDocument(url).promise.then(pdfDoc => {            pdfDoc.getPage(1).then(page => {                const scale = 1.5;                const viewport = page.getViewport({ scale });                const pdfCanvas = document.getElementById(\'pdf-render\');                const pdfContext = pdfCanvas.getContext(\'2d\');                pdfCanvas.height = viewport.height;                pdfCanvas.width = viewport.width;                const drawCanvas = document.getElementById(\'drawing-layer\');                const drawContext = drawCanvas.getContext(\'2d\');                drawCanvas.height = viewport.height;                drawCanvas.width = viewport.width;                // Renderizar o PDF no canvas                page.render({                    canvasContext: pdfContext,                    viewport: viewport                });                let isDrawing = false;                let startX, startY;                drawCanvas.addEventListener(\'mousedown\', (e) => {                    if (isSignatureMode) {                        isDrawingSignature = true;                        drawContext.beginPath();                        drawContext.moveTo(e.offsetX, e.offsetY);                    } else {                        isDrawing = true;                        startX = e.offsetX;                        startY = e.offsetY;                    }                });                drawCanvas.addEventListener(\'mousemove\', (e) => {                    if (isSignatureMode && isDrawingSignature) {                        drawContext.lineTo(e.offsetX, e.offsetY);                        drawContext.strokeStyle = \'blue\';                        drawContext.lineWidth = 2;                        drawContext.stroke();                    } else if (!isSignatureMode && isDrawing) {                        const currentX = e.offsetX;                        const currentY = e.offsetY;                        drawContext.clearRect(0, 0, drawCanvas.width, drawCanvas.height);                        drawContext.beginPath();                        drawContext.rect(startX, startY, currentX - startX, currentY - startY);                        drawContext.lineWidth = 1;                        drawContext.strokeStyle = \'black\';                        drawContext.stroke();                    }                });                drawCanvas.addEventListener(\'mouseup\', (e) => {                    if (isSignatureMode && isDrawingSignature) {                        isDrawingSignature = false;                        drawContext.closePath();                    } else if (!isSignatureMode && isDrawing) {                        isDrawing = false;                        const endX = e.offsetX;                        const endY = e.offsetY;                        let rectWidth = endX - startX;                        let rectHeight = endY - startY;                        var x = document.getElementById(\'x\');                                                startX = startX / 1.5;                        startX = Math.round(startX);                        x.innerHTML = startX;                        var y = document.getElementById(\'y\');                        startY = startY / 1.5;                        startY = Math.round(startY);                        y.innerHTML = startY;                        var width = document.getElementById(\'width\');                        rectWidth = rectWidth / 1.5;                        rectWidth = Math.round(rectWidth);                        width.innerHTML = rectWidth;                        var height = document.getElementById(\'height\');                        rectHeight = rectHeight / 1.5;                        rectHeight = Math.round(rectHeight);                        height.innerHTML = rectHeight;                    }                });                drawCanvas.addEventListener(\'mouseout\', () => {                    if (isDrawing) isDrawing = false;                    if (isDrawingSignature) isDrawingSignature = false;                });            });        }).catch(err => {            console.error(\"Erro ao carregar PDF:\", err.message);        });    }    document.getElementById(\'signature-btn\').addEventListener(\'click\', () => {        isSignatureMode = true;        alert(\"Modo de assinatura ativado. Assine no PDF!\");    });</script>';
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
					var scriptPDF = "https://cdnjs.cloudflare.com/ajax/libs/pdf.js/2.10.377/pdf.min.js";
					
					inserirScript(scriptPDF);
				
		}
		this.Assinar = function() {

					
					const self = this;
					self.File = document.getElementById('arquivo').innerHTML;
					self.xxx = document.getElementById('x').innerHTML;
					self.varY = document.getElementById('y').innerHTML;
					self.varWidth = document.getElementById('width').innerHTML;
					self.varHeight = document.getElementById('height').innerHTML;
					
					
				
		}
		this.CarregarAssinado = function(SignedFile ) {

					
					loadPdfFromBase64(SignedFile);	
					
				
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