function UCSignaturePad($) {

	var template = '<!DOCTYPE html><html lang=\"pt-BR\"><head>    <meta charset=\"UTF-8\">    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">    <title>Signature Pad</title>    <style>        body {            display: flex;            flex-direction: column;            align-items: center;            justify-content: center;            height: 100vh;            background-color: #f7f7f7;            margin: 0;        }        #signatureCanvas {            border: 2px solid #000;            background-color: #fff;            touch-action: none; /* Evitar comportamento padrão de rolagem em dispositivos móveis */        }        #buttons {            margin-top: 10px;        }        button {            padding: 10px;            font-size: 16px;            margin-right: 10px;        }    </style></head><body>    <h2>Faça sua assinatura abaixo</h2>    <canvas id=\"signatureCanvas\" width=\"500\" height=\"300\"></canvas>    <div id=\"buttons\">        <button onclick=\"clearCanvas()\">Limpar</button>        <button onclick=\"saveSignature()\">Salvar</button>    </div>    <script>        document.addEventListener(\'DOMContentLoaded\', function() {            const canvas = document.getElementById(\'signatureCanvas\');            const ctx = canvas.getContext(\'2d\');            let isDrawing = false;            let lastX = 0;            let lastY = 0;            function startDrawing(e) {                isDrawing = true;                const pos = getEventPos(e);                [lastX, lastY] = [pos.x, pos.y];            }            function draw(e) {                if (!isDrawing) return;                const pos = getEventPos(e);                ctx.beginPath();                ctx.moveTo(lastX, lastY);                ctx.lineTo(pos.x, pos.y);                ctx.strokeStyle = \'#000\';                ctx.lineWidth = 2;                ctx.stroke();                [lastX, lastY] = [pos.x, pos.y];            }            function stopDrawing() {                isDrawing = false;                ctx.beginPath();            }            function getEventPos(e) {                if (e.touches) {                    const touch = e.touches[0];                    const rect = canvas.getBoundingClientRect();                    return {                        x: touch.clientX - rect.left,                        y: touch.clientY - rect.top                    };                } else {                    return {                        x: e.offsetX,                        y: e.offsetY                    };                }            }            canvas.addEventListener(\'mousedown\', (e) => {                startDrawing(e);            });            canvas.addEventListener(\'mousemove\', draw);            canvas.addEventListener(\'mouseup\', stopDrawing);            canvas.addEventListener(\'mouseout\', stopDrawing);            canvas.addEventListener(\'touchstart\', (e) => {                e.preventDefault();                startDrawing(e);            });            canvas.addEventListener(\'touchmove\', (e) => {                e.preventDefault();                draw(e);            });            canvas.addEventListener(\'touchend\', stopDrawing);            canvas.addEventListener(\'touchcancel\', stopDrawing);            function clearCanvas() {                ctx.clearRect(0, 0, canvas.width, canvas.height);            }            function saveSignature() {                const dataURL = canvas.toDataURL(\'image/png\');                const link = document.createElement(\'a\');                link.href = dataURL;                link.download = \'signature.png\';                link.click();            }            window.clearCanvas = clearCanvas;            window.saveSignature = saveSignature;        });    </script></body></html>';
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