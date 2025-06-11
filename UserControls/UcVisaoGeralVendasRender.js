function UcVisaoGeralVendas($) {
	  
	  

	var template = '<style>.card-header {  display: flex;  justify-content: space-between;  align-items: center;  margin-bottom: 12px;}.card-header h3 {  font-size: 1rem;  color: #333;  margin: 0;}.card-header select {  border: 1px solid #ccc;  border-radius: 4px;  padding: 4px 8px;  background-color: #fff;  cursor: pointer;}.chart-container {  width: 100%;  height: 300px;}</style><div class=\"chart-container\" id=\"chart_div\"></div><!-- Carrega o loader do Google Charts --><script type=\"text/javascript\" src=\"https://www.gstatic.com/charts/loader.js\"></script><script type=\"text/javascript\">// Dados para o gráfico mensal e semanalconst monthlyData = {{{monthly_data}}};const weeklyData = {{{weekly_data}}};// Carrega o pacote \'corechart\'google.charts.load(\'current\', {packages:[\'corechart\']});google.charts.setOnLoadCallback(drawChart);function drawChart(period) {  let dataArray, labelHeader;  if (period === \'semanal\') {				dataArray = weeklyData;	labelHeader = \'Semana\';} else {	dataArray = monthlyData;	labelHeader = \'Mês\';}  const data = new google.visualization.DataTable();  data.addColumn(\'string\', labelHeader);  data.addColumn(\'number\', \'Vendidos\');  data.addColumn(\'number\', \'Devolvidos\');  dataArray.forEach(item => {    data.addRow([item.label, item.sold, item.returned]);  });  const options = {    legend: { position: \'top\', alignment: \'center\' },    chartArea: { width: \'80%\', height: \'70%\' },    colors: [\'#007bff\', \'#ff4b4b\'],    vAxis: { minValue: 0 }  };  const chart = new google.visualization.ColumnChart(document.getElementById(\'chart_div\'));  chart.draw(data, options);}</script>';
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

		this.ChangeView = function(period ) {

				
					let dataArray, labelHeader;
					if (period === 'semanal') {
						
						dataArray = weeklyData;
						labelHeader = 'Semana';
					} else {
						dataArray = monthlyData;
						labelHeader = 'Mês';
					}
					
					const data = new google.visualization.DataTable();
					data.addColumn('string', labelHeader);
					data.addColumn('number', 'Vendidos');
					data.addColumn('number', 'Devolvidos');
					
					dataArray.forEach(item =&gt; {
						data.addRow([item.label, item.sold, item.returned]);
					});
					
					const options = {
						legend: { position: 'top', alignment: 'center' },
						chartArea: { width: '80%', height: '70%' },
						colors: ['#007bff', '#ff4b4b'],
						vAxis: { minValue: 0 }
					};
					
					const chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));
					chart.draw(data, options);
						
				
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