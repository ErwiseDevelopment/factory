function UCPdfViewer($) {
	  

	var template = '<!-- Incluindo a versão 3.9.179 do PDF.js --><script src=\"https://cdnjs.cloudflare.com/ajax/libs/pdf.js/3.9.179/pdf.min.js\"></script><div id=\"the-canvas\"></div><script>  // Configuração do worker para PDF.js  pdfjsLib.GlobalWorkerOptions.workerSrc = \'https://cdnjs.cloudflare.com/ajax/libs/pdf.js/3.9.179/pdf.worker.min.js\';  //const url = \'{{{path}}}\'; // Substitua por um PDF de teste se necessário  const url = \'{{{path}}}\';  const container = document.getElementById(\'the-canvas\');  function loadCanvas() {    console.log(\"Iniciando carregamento do PDF...\");    const loadingTask = pdfjsLib.getDocument(url);    loadingTask.promise.then(function (pdf) {      console.log(`PDF carregado: ${pdf.numPages} páginas encontradas.`);      container.innerHTML = \'\'; // Limpa o conteúdo existente      // Inicia a renderização a partir da primeira página      renderPage(1);      function renderPage(pageNum) {        pdf.getPage(pageNum).then(function (page) {          console.log(`Renderizando página ${pageNum}...`);          const canvas = document.createElement(\'canvas\');          container.appendChild(canvas);          const context = canvas.getContext(\'2d\');          // Escala fixa para simplificar          let scale = 1.5;          const viewport = page.getViewport({ scale: scale });          canvas.width = viewport.width;          canvas.height = viewport.height;          // Opcional: desenhe um retângulo para testar o canvas          // context.fillStyle = \'red\';          // context.fillRect(0, 0, canvas.width, canvas.height);          const renderContext = {            canvasContext: context,            viewport: viewport,          };          const renderTask = page.render(renderContext);          renderTask.promise.then(function () {            console.log(`Página ${pageNum} renderizada com sucesso.`);            // Renderiza a próxima página, se houver            if (pageNum < pdf.numPages) {              renderPage(pageNum + 1);            }          }).catch(function (error) {            console.error(`Erro ao renderizar a página ${pageNum}:`, error);          });        }).catch(function (error) {          console.error(`Erro ao obter a página ${pageNum}:`, error);        });      }    }).catch(function (reason) {      console.error(\'Erro ao carregar o PDF:\', reason);    });  }  // Carrega o PDF na inicialização  loadCanvas();  // Adiciona listener para recarregar ao redimensionar a janela  window.addEventListener(\'resize\', loadCanvas);</script><!-- Estilos para a interface --><style>  body {    margin: 0;    padding: 0;  }  #the-canvas {    width: 100vw !important;    display: flex;    flex-direction: column;    align-items: center;    padding: 0;    height: 100%;  }  #the-canvas canvas {    border: 1px solid rgb(230, 230, 230);    margin-bottom: 10px;    margin-top: 5px;    box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2);    background-color: white;  }</style>';
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
					var scriptPDF = "https://cdnjs.cloudflare.com/ajax/libs/pdf.js/3.9.179/pdf.min.js";
					
					inserirScript(scriptPDF);
				
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