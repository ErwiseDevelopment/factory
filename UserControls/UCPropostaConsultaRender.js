function UCPropostaConsulta($) {
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  
	  

	var template = '<!DOCTYPE html><html lang=\"pt-BR\"><head>    <meta charset=\"UTF-8\">    <title>Proposta Criada</title>    <!-- Incluindo o FontAwesome -->    <link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css\">    <!-- Incluindo a fonte Roboto do Google Fonts -->    <link rel=\"stylesheet\" href=\"https://fonts.googleapis.com/css?family=Roboto&display=swap\">    <!-- Incluindo o html2pdf.js -->    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/html2pdf.js/0.10.1/html2pdf.bundle.min.js\"></script>    <style>        /* Paleta de cores */        :root {            --primary-color: #007bff;            --secondary-color: #6c757d;            --success-color: #28a745;            --info-color: #17a2b8;            --warning-color: #ffc107;            --danger-color: #dc3545;            --light-color: #f8f9fa;            --dark-color: #343a40;            --background-color: #f2f2f2;            --text-color: #212529;        }        /* Estilos gerais aplicados ao contêiner principal */        .proposta-page {            font-family: \'Roboto\', Arial, sans-serif;            background-color: var(--background-color);            margin: 0;            padding: 0;            color: var(--text-color);        }        .proposta-container {            max-width: 1200px;            margin: 30px auto;            background-color: #fff;            padding: 20px;            box-shadow: 0 0 10px #ccc;            border-radius: 8px;            position: relative;        }        .proposta-container h1 {            text-align: center;            color: var(--primary-color);            font-size: 28px;            margin-bottom: 10px;            font-family: \'Roboto\', Arial, sans-serif;        }        .proposta-message {            font-size: 18px;            margin-bottom: 20px;            text-align: center;            color: var(--secondary-color);            font-family: \'Roboto\', Arial, sans-serif;        }        .proposta-section {            margin-bottom: 20px;        }        .proposta-section h2 {            color: var(--dark-color);            border-bottom: 2px solid var(--primary-color);            padding-bottom: 5px;            margin-bottom: 15px;            font-size: 22px;            font-family: \'Roboto\', Arial, sans-serif;        }        /* Ajuste para duas colunas */        .proposta-info-group {            display: flex;            flex-wrap: wrap;        }        .proposta-info-item {            width: 50%;            box-sizing: border-box;            padding: 10px;            display: flex;            flex-wrap: wrap;            align-items: center;            page-break-inside: avoid;        }        .proposta-label {            font-weight: bold;            background-color: var(--light-color);            padding: 10px;            width: 30%;            box-sizing: border-box;            display: flex;            align-items: center;            border-radius: 5px 0 0 5px;            font-family: \'Roboto\', Arial, sans-serif;        }        .proposta-label i {            margin-right: 8px;            color: var(--primary-color);        }        .proposta-value {            padding: 10px;            width: 70%;            box-sizing: border-box;            background-color: #fff;            border: 1px solid #dee2e6;            border-left: none;            border-radius: 0 5px 5px 0;            font-family: \'Roboto\', Arial, sans-serif;        }        .proposta-footer {            text-align: center;            color: var(--secondary-color);            font-size: 14px;            margin-top: 30px;            page-break-inside: avoid;            font-family: \'Roboto\', Arial, sans-serif;        }        /* Botão de download */        .proposta-download-btn {            position: absolute;            top: 20px;            right: 20px;            background-color: var(--success-color);            color: #fff;            border: none;            padding: 10px 15px;            border-radius: 5px;            cursor: pointer;            font-size: 16px;            font-family: \'Roboto\', Arial, sans-serif;        }        .proposta-download-btn i {            margin-right: 5px;        }        .proposta-download-btn:hover {            background-color: #218838;        }        /* Estilos responsivos */        @media (max-width: 768px) {            .proposta-container {                padding: 15px;            }            .proposta-info-item {                width: 100%;                padding: 5px;            }            .proposta-label,            .proposta-value {                width: 100%;                border-radius: 5px;            }            .proposta-label {                padding-top: 10px;            }            .proposta-value {                padding-bottom: 10px;                border: 1px solid #dee2e6;                border-top: none;            }            .proposta-info-item:last-child .proposta-value {                border-bottom: 1px solid #dee2e6;            }            .proposta-download-btn {                top: 15px;                right: 15px;                font-size: 14px;                padding: 8px 12px;            }        }        /* Estilos para o modo PDF */        .pdf-mode .proposta-info-item {            width: 100%;        }        .pdf-mode .proposta-label,        .pdf-mode .proposta-value {            width: 100%;            border-radius: 5px;        }        .pdf-mode .proposta-info-group {            flex-direction: column;        }        .pdf-mode .proposta-label {            border-radius: 5px 5px 0 0;        }        .pdf-mode .proposta-value {            border-radius: 0 0 5px 5px;            border-top: none;            border-left: 1px solid #dee2e6;        }    </style></head><body>    <div class=\"proposta-container\" id=\"propostaContent\">        <h1><i class=\"fa-solid fa-receipt\"></i> Proposta</h1>        <!-- Seção de Informações do Cliente -->        <div class=\"proposta-section proposta-client-info\">            <h2><i class=\"fas fa-user\"></i> Informações do Cliente</h2>            <div class=\"proposta-info-group\">                <!-- Campos do Cliente -->                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-id-card\"></i> Documento:</div>                    <div class=\"proposta-value\">{{{ClienteDocumento}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-building\"></i> Razão Social:</div>                    <div class=\"proposta-value\">{{{ClienteRazaoSocial}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-store\"></i> Nome Fantasia:</div>                    <div class=\"proposta-value\">{{{ClienteNomeFantasia}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-user-tag\"></i> Tipo Pessoa:</div>                    <div class=\"proposta-value\">{{{ClienteTipoPessoa}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-info-circle\"></i> Descrição do Tipo Cliente:</div>                    <div class=\"proposta-value\">{{{TipoClienteDescricao}}}</div>                </div>            </div>        </div>        <!-- Seção de Endereço -->        <div class=\"proposta-section proposta-address-info\">            <h2><i class=\"fas fa-map-marker-alt\"></i> Endereço</h2>            <div class=\"proposta-info-group\">                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-map-pin\"></i> CEP:</div>                    <div class=\"proposta-value\">{{{EnderecoCEP}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-road\"></i> Logradouro:</div>                    <div class=\"proposta-value\">{{{EnderecoLogradouro}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-city\"></i> Bairro:</div>                    <div class=\"proposta-value\">{{{EnderecoBairro}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-city\"></i> Cidade:</div>                    <div class=\"proposta-value\">{{{EnderecoCidade}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-map-marker-alt\"></i> Nome do Município:</div>                    <div class=\"proposta-value\">{{{MunicipioNome}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-flag\"></i> UF:</div>                    <div class=\"proposta-value\">{{{MunicipioUF}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-sort-numeric-up\"></i> Número:</div>                    <div class=\"proposta-value\">{{{EnderecoNumero}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-edit\"></i> Complemento:</div>                    <div class=\"proposta-value\">{{{EnderecoComplemento}}}</div>                </div>            </div>        </div>        <!-- Seção de Contato -->        <div class=\"proposta-section proposta-contact-info\">            <h2><i class=\"fas fa-phone\"></i> Contato</h2>            <div class=\"proposta-info-group\">                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-envelope\"></i> E-mail:</div>                    <div class=\"proposta-value\">{{{ContatoEmail}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-phone-alt\"></i> DDD:</div>                    <div class=\"proposta-value\">{{{ContatoDDD}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-phone\"></i> Número:</div>                    <div class=\"proposta-value\">{{{ContatoNumero}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-phone-square\"></i> Telefone Número:</div>                    <div class=\"proposta-value\">{{{ContatoTelefoneNumero}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-phone-square\"></i> Telefone DDD:</div>                    <div class=\"proposta-value\">{{{ContatoTelefoneDDD}}}</div>                </div>            </div>        </div>        <!-- Seção de Informações Bancárias -->        <div class=\"proposta-section proposta-bank-info\">            <h2><i class=\"fas fa-university\"></i> Informações Bancárias</h2>            <div class=\"proposta-info-group\">                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-university\"></i> Banco:</div>                    <div class=\"proposta-value\">{{{BancoNome}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-building\"></i> Agência:</div>                    <div class=\"proposta-value\">{{{BancoAgencia}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-wallet\"></i> Conta:</div>                    <div class=\"proposta-value\">{{{BancoConta}}}</div>                </div>            </div>        </div>        <!-- Seção de Informações da Proposta -->        <div class=\"proposta-section proposta-proposal-info\">            <h2><i class=\"fas fa-file-alt\"></i> Informações da Proposta</h2>            <div class=\"proposta-info-group\">                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-notes-medical\"></i> Procedimentos Médicos ID:</div>                    <div class=\"proposta-value\">{{{ProcedimentosMedicos}}}</div>                </div>                <div class=\"proposta-info-item\">                    <div class=\"proposta-label\"><i class=\"fas fa-dollar-sign\"></i> Valor da Proposta:</div>                    <div class=\"proposta-value\">{{{PropostaValor}}}</div>                </div>                <div class=\"proposta-info-item\" style=\"width: 100%;\">                    <div class=\"proposta-label\" style=\"width: 100%; border-radius: 5px 5px 0 0;\"><i class=\"fas fa-file-signature\"></i> Descrição da Proposta:</div>                    <div class=\"proposta-value\" style=\"width: 100%; border-radius: 0 0 5px 5px; border-left: 1px solid #dee2e6; border-top: none;\">{{{PropostaDescricao}}}</div>                </div>            </div>        </div>    </div>    <script>        // Função para baixar o PDF        function downloadPDF() {            const element = document.getElementById(\'propostaContent\');            // Adiciona a classe \'pdf-mode\' para ajustar o layout            element.classList.add(\'pdf-mode\');            // Esconde o botão de download            document.querySelector(\'.proposta-download-btn\').style.display = \'none\';            // Opções de configuração para o html2pdf            const opt = {                margin:       [10, 10, 10, 10], // margens [superior, esquerdo, inferior, direito]                filename:     \'proposta.pdf\',                image:        { type: \'jpeg\', quality: 0.98 },                html2canvas:  { scale: 2 },                jsPDF:        { unit: \'mm\', format: \'a4\', orientation: \'portrait\' },                pagebreak:    { mode: [\'avoid-all\', \'css\', \'legacy\'] } // Evita quebras de página indesejadas            };            // Gera o PDF            html2pdf().set(opt).from(element).save().then(() => {                // Restaura o botão de download                document.querySelector(\'.proposta-download-btn\').style.display = \'block\';                // Remove a classe \'pdf-mode\' após gerar o PDF                element.classList.remove(\'pdf-mode\');            });        }    </script></body></html>';
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

					
					var element = document.getElementById('propostaContent');
					 element.classList.add('pdf-mode');
			        var opt = {
			            margin:       [10, 10, 10, 10],
			            filename:     'proposta.pdf',
			            image:        { type: 'jpeg', quality: 0.98 },
			            html2canvas:  { scale: 2 },
			            jsPDF:        { unit: 'mm', format: 'a4', orientation: 'portrait' },
			            pagebreak:    { mode: ['avoid-all', 'css', 'legacy'] }
			        };

			         // Gera o PDF
			        html2pdf().set(opt).from(element).save().then(function() {
			            element.classList.remove('pdf-mode');
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