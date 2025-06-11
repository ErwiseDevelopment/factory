function UCCardLimCred($) {
	  
	  
	  
	  
	  

	var template = '  <style>    .card {      width: 300px;      background-color: #fff;      border: 1px solid #ddd;      border-radius: 8px;      box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);      padding: 16px;    }    .card h3 {      font-size: 1rem;      color: #333;      margin-bottom: 12px;    }    .limit-info {      margin-bottom: 16px;    }    .limit-info .available-amount {      display: block;      font-size: 1.5rem;      font-weight: bold;      margin-bottom: 4px;      color: #333;    }    .limit-info .of-amount {      font-size: 0.875rem;      color: #666;    }    .progress-bar {      width: 100%;      height: 8px;      background-color: #e0e0e0;      border-radius: 4px;      overflow: hidden;      margin-bottom: 8px;    }    .progress {      height: 100%;      width: {{{percent_size}}}%; /* Ajuste aqui para a porcentagem desejada */      background-color: #007bff;    }    .used-info {      font-size: 0.875rem;      color: #666;    }  </style><div class=\"card\">	<h3>Limite de Crédito</h3>	<div class=\"limit-info\">		<span class=\"available-amount\">R${{{available_amount}}}</span>		<span class=\"of-amount\">disponível de R${{{of_amount}}}</span>	</div>			<div class=\"progress-bar\">		<div class=\"progress\"></div>	</div>		<div class=\"used-info\">	Utilizado: R${{{used_amount}}} ({{{percent}}})	</div></div>';
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