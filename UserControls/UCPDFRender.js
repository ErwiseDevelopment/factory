function UCPDF($) {

	var template = '  <script src=\"/Resources/pdf.js/build/pdf.mjs\" type=\"module\"></script>  <script type=\"module\">    // If absolute URL from the remote server is provided, configure the CORS    // header on that server.    var url = \'/PublicTempStorage/PDFTESTE.pdf\';		 document.addEventListener(\'DOMContentLoaded\', () => {      // URL do arquivo que você deseja verificar		      // Função para verificar se o arquivo está acessível      function verificarArquivo(url) {	        fetch(url, { method: \'HEAD\' })          .then(response => {	            if (response.ok) {	              console.log(\'O arquivo foi encontrado com sucesso.\');		            } else {	              console.log(\'O arquivo não foi encontrado. Status:\', response.status);	            }          })          .catch(error => {	            console.log(\'Erro ao tentar acessar o arquivo:\', error);          });      }		      // Chama a função para verificar o arquivo      verificarArquivo(url);    });    const container = document.getElementById(\'the-canvas\');      // Loaded via <script> tag, create shortcut to access PDF.js exports.    var { pdfjsLib } = globalThis;      // The workerSrc property shall be specified.    pdfjsLib.GlobalWorkerOptions.workerSrc = \'/Resources/pdf.js/build/pdf.worker.mjs\';      // Asynchronous download of PDF    pdfjsLib.getDocument(url).promise.then(pdf => {      console.log(\'PDF loaded\');        // Fetch the first page           for (let pageNum = 1; pageNum <= pdf.numPages; pageNum++) {        pdf.getPage(pageNum).then(function(page) {          console.log(pageNum)              var scale = 1.5;          const viewport = page.getViewport({scale: scale});          container.style.width = viewport.width + \'px\';          container.style.height = viewport.height + \'px\';          const canvas = document.createElement(\'canvas\');          container.appendChild(canvas)          // Prepare canvas using PDF page dimensions                    var context = canvas.getContext(\'2d\');          canvas.height = viewport.height;          canvas.width = viewport.width;              // Render PDF page into canvas context          var renderContext = {            canvasContext: context,            viewport: viewport          };          var renderTask = page.render(renderContext);          renderTask.promise.then(function () {             console.log(\'Canvas carregado\')          });        });      }    }, function (reason) {      // PDF loading error      console.error(reason);    });  </script>  <h1>Canvas aqui</h1>  <div id=\"the-canvas\"></div>  <h1>Fim do canvas aqui</h1>  <style>    body{      margin: 0;      padding: 0;      overflow-x: hidden;    }    #the-canvas{      width: 100vw !important;      display: flex;      flex-direction: column;      align-items: center;      padding: 0;      height: 100%;    }    #the-canvas canvas {      border: 1px solid rgb(230, 230, 230);      margin-bottom: 10px;      margin-top: 5px;      box-shadow: 0px 6px 12px rgba(0, 0, 0, 0.3);          }  </style>';
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