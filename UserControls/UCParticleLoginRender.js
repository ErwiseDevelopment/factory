function UCParticleLogin($) {

	var template = '<!DOCTYPE html><html lang=\"en\"><head>  <meta charset=\"utf-8\">  <title>particles.js</title>  <meta name=\"description\" content=\"particles.js is a lightweight JavaScript library for creating particles.\">  <meta name=\"author\" content=\"Vincent Garreau\" />  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no\">  <link rel=\"stylesheet\" media=\"screen\" href=\"teste/style.css\"></head><body><!-- particles.js container --><div id=\"particles-js\"></div><!-- scripts --><script src=\"teste/particles.js\"></script><script src=\"teste/app.js\"></script></body></html>';
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