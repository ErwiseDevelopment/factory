function UcListaParcelasXTaxas($) {
	  

	var template = '    <style>        .pgto-container {            margin: 0 auto;            background-color: #fff;            border-radius: 12px;            box-shadow: 0 5px 20px rgba(8, 160, 134, 0.15);            padding: 25px;            font-family: \'Segoe UI\', Arial, sans-serif;        }                .pgto-titulo {            color: #08A086;            text-align: center;            margin-bottom: 25px;            font-size: 24px;            letter-spacing: -0.5px;            position: relative;            padding-bottom: 12px;        }                .pgto-titulo:after {            content: \'\';            position: absolute;            bottom: 0;            left: 50%;            transform: translateX(-50%);            width: 60px;            height: 3px;            background-color: #08A086;            border-radius: 3px;        }                .pgto-tabela {            width: 100%;            border-collapse: separate;            border-spacing: 0;            margin-bottom: 20px;            border-radius: 8px;            overflow: hidden;        }                .pgto-cabecalho {            background-color: #08A086;            color: white;        }                .pgto-tabela th,         .pgto-tabela td {            padding: 14px 15px;            text-align: left;            border-bottom: 1px solid #e0e0e0;        }                .pgto-tabela th {            font-weight: 600;            letter-spacing: 0.3px;            font-size: 14px;            text-transform: uppercase;        }                .pgto-tabela tbody tr {            transition: all 0.2s ease;        }                .pgto-tabela tbody tr:hover {            background-color: rgba(8, 160, 134, 0.08);            transform: translateY(-2px);            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.05);        }                .pgto-tabela tbody tr:last-child td {            border-bottom: none;        }                .pgto-valor {            text-align: right;            font-family: \'Consolas\', monospace;            font-weight: 500;        }                .pgto-porcentagem {            font-size: 0.75em;            color: #666;            margin-left: 5px;            background-color: #f0f0f0;            padding: 2px 6px;            border-radius: 10px;            display: inline-block;        }                .pgto-total-row {            font-weight: bold;            background-color: #08A086;            color: white;        }                .pgto-total-label {            text-align: right;            font-size: 15px;            letter-spacing: 0.5px;        }        .pgto-data {            white-space: nowrap;            position: relative;        }                .pgto-data i {            margin-right: 5px;            opacity: 0.7;            color: #08A086;        }                .pgto-parcela-badge {            background-color: rgba(8, 160, 134, 0.15);            color: #08A086;            padding: 4px 10px;            border-radius: 20px;            font-weight: 600;            display: inline-block;            min-width: 40px;            text-align: center;        }                .pgto-nota {            font-size: 13px;            color: #555;            background-color: #f9f9f9;            padding: 3px 8px;            border-radius: 4px;            display: inline-block;        }                .pgto-dias {            text-align: center;            font-weight: 500;        }                .pgto-total-valor {            font-size: 16px;            letter-spacing: 0.5px;        }                @media (max-width: 768px) {            .pgto-tabela {                display: block;                overflow-x: auto;                white-space: nowrap;            }                        .pgto-container {                padding: 15px;                margin: 0 10px;            }        }    </style>    <div class=\"pgto-container\">        <h1 class=\"pgto-titulo\">Detalhamento de Parcelas</h1>        <table class=\"pgto-tabela\" id=\"tabela-parcelas\">            <thead class=\"pgto-cabecalho\">                <tr>										<th>Nota Fiscal</th>                    <th>Parcela</th>                    <th>Vencimento</th>										<th>Dias</th>                    <th>Valor Base</th>                    <th>Juros</th>                    <th>Taxa Adm.</th>                    <th>Valor Total</th>                                                        </tr>            </thead>            <tbody id=\"tabela-corpo\">                <!-- Os dados serão preenchidos via JavaScript -->            </tbody>            <tfoot>                <tr class=\"pgto-total-row\">                    <td colspan=\"5\" class=\"pgto-total-label\">Valor Total com Taxas:</td>                    <td id=\"valor-total\" class=\"pgto-valor pgto-total-valor\" colspan=\"3\"></td>                </tr>            </tfoot>        </table>    </div>    <script>        // Dados em formato JSON        const dadosParcelas = {{{Data}}};        // Função para formatar valores monetários        function formatarMoeda(valor) {            return new Intl.NumberFormat(\'pt-BR\', {                style: \'currency\',                currency: \'BRL\'            }).format(Number(valor));        }        // Função para formatar percentuais        function formatarPercentual(valor) {            return Number(valor).toFixed(2) + \'%\';        }        // Função para formatar a data        function formatarData(dataISO) {            const partes = dataISO.split(\'-\');            return `${partes[2]}/${partes[1]}/${partes[0]}`;        }        // Função para preencher a tabela com os dados        function preencherTabela() {            const tbody = document.getElementById(\'tabela-corpo\');            let valorTotalGeral = 0;                        // Limpar o conteúdo atual            tbody.innerHTML = \'\';                        // Preencher com os novos dados            dadosParcelas.forEach(parcela => {                const tr = document.createElement(\'tr\');                                // Converter valor total para número para soma posterior                const valorTotalParcela = Number(parcela.ValorTotal);                                tr.innerHTML = `										<td><span class=\"pgto-nota\"><i class=\"fas fa-file-invoice\"></i> ${parcela.NotaFiscalNumero}</span></td>                    <td><span class=\"pgto-parcela-badge\">${parcela.Parcela}</span></td>                    <td class=\"pgto-data\"><i class=\"far fa-calendar-alt\"></i>${formatarData(parcela.Vencimento)}</td>										<td class=\"pgto-dias\">${parcela.Dias}</td>                    <td class=\"pgto-valor\">${formatarMoeda(parcela.ValorBase)}</td>                    <td class=\"pgto-valor\">${formatarMoeda(parcela.JurosValor)} <span class=\"pgto-porcentagem\">(${formatarPercentual(parcela.JurosPercentual)})</span></td>                    <td class=\"pgto-valor\">${formatarMoeda(parcela.TaxaValor)} <span class=\"pgto-porcentagem\">(${formatarPercentual(parcela.TaxaPercentual)})</span></td>                    <td class=\"pgto-valor\">${formatarMoeda(parcela.ValorTotal)}</td>                                                        `;                                tbody.appendChild(tr);                valorTotalGeral += valorTotalParcela;            });                        // Atualizar o valor total            document.getElementById(\'valor-total\').textContent = formatarMoeda(valorTotalGeral);        }                // Inicializar a tabela quando a página carregar//        document.addEventListener(\'DOMContentLoaded\', preencherTabela);    </script>';
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

		this.LoadData = function() {

					preencherTabela()
				
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