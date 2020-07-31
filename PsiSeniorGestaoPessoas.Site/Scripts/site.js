var Site = function () {

    var accentMap = {
        "à": "a", "â": "a", "á": "a", "ã": "a", "é": "e", "è": "e", "ê": "e", "ë": "e",
        "é": "e", "ï": "i", "î": "i", "í": "i", "ô": "o", "ö": "o", "ó": "o", "û": "u",
        "ù": "u", "ú": "u", "À": "A", "Â": "A", "Á": "A", "Ã": "A", "É": "E", "È": "E",
        "Ê": "E", "Ë": "E", "Ï": "I", "Î": "I", "Í": "I", "Ô": "O", "Ö": "O", "Ó": "O",
        "Û": "U", "Ù": "U", "Ú": "U"
    };

    var _public = {

        validarCPF: function (cpf) {
            cpf = cpf.replace(/[^\d]+/g, '');
            if (cpf == '') return false;
            // Elimina CPFs invalidos conhecidos    
            if (cpf.length != 11 ||
                cpf == "00000000000" ||
                cpf == "11111111111" ||
                cpf == "22222222222" ||
                cpf == "33333333333" ||
                cpf == "44444444444" ||
                cpf == "55555555555" ||
                cpf == "66666666666" ||
                cpf == "77777777777" ||
                cpf == "88888888888" ||
                cpf == "99999999999")
                return false;
            // Valida 1o digito 
            add = 0;
            for (i = 0; i < 9; i++)
                add += parseInt(cpf.charAt(i)) * (10 - i);
            rev = 11 - (add % 11);
            if (rev == 10 || rev == 11)
                rev = 0;
            if (rev != parseInt(cpf.charAt(9)))
                return false;
            // Valida 2o digito 
            add = 0;
            for (i = 0; i < 10; i++)
                add += parseInt(cpf.charAt(i)) * (11 - i);
            rev = 11 - (add % 11);
            if (rev == 10 || rev == 11)
                rev = 0;
            if (rev != parseInt(cpf.charAt(10)))
                return false;
            return true;
        },

        getBotaoDetalhes: function () {
            return "<a rel='tooltip' class='btn btn-default btn-xs btn-detalhe' title='Detalhe'><span aria-hidden='true' class='glyphicon glyphicon-option-horizontal' ></span></a>&nbsp;";
        },

        getBotaoVisualizar: function () {
            return "<a rel='tooltip' class='btn btn-default btn-xs btn-visualizar' title='Visualizar'><span aria-hidden='true' class='fa fa-search' ></span></a>&nbsp;";
        },


        getBotaoMarcarImprimir: function () {
            return "<a rel='tooltip' class='btn btn-default btn-xs btn-marcarImprimir' title='Marcar Como Impresso'><span aria-hidden='true' class='fa fa-check' ></span></a>&nbsp;";
        },

        getBotaoVisualizarArquivo: function () {
            return "<a rel='tooltip' class='btn btn-default btn-xs btn-visualizar-arquivo' title='Visualizar Arquivo'><span aria-hidden='true' class='fa fa-file-pdf-o' ></span></a>&nbsp;";
        },

        getBotaoNovo: function () {
            return "<a rel='tooltip' class='btn btn-default btn-xs btn-novo' title='Novo'><span aria-hidden='true' class='glyphicon glyphicon-file' ></span></a>&nbsp;";
        },

        getBotaoImprimirLote: function () {
            return "<a rel='tooltip' class='btn btn-default btn-xs btn-imprimir' title='Imprimir Lote'><span aria-hidden='true' class='fa fa-print' ></span></a>&nbsp;";
        },

        getBotaoBaixar: function () {
            return "<a rel='tooltip' class='btn btn-default btn-xs btn-download' title='Download'><span aria-hidden='true' class='fa fa-download' ></span></a>&nbsp;";
        },

        getBotaoAnalisar: function () {
            return "<a rel='tooltip' class='btn btn-default btn-xs btn-analisar' title='Analisar'><span aria-hidden='true' class='fa fa-gavel' ></span></a>&nbsp;";
        },

        getBotaoConfereComOriginal: function () {
            return "<a rel='tooltip' class='btn btn-default btn-xs btn-confereComOriginal' title='Confere com original'><span aria-hidden='true' class='fa fa-gavel' ></span></a>&nbsp;";
        },


        getBotaoDefinirTipoDocumento: function () {
            return "<a rel='tooltip' class='btn btn-default btn-xs btn-definirDocumento' title='Definir Documento'><span aria-hidden='true' class='fa fa-tag' ></span></a>&nbsp;";
        },

        getBotaoAlterarDataProtocolo: function (full) {
            return `<a rel='tooltip' class='btn btn-default btn-xs btn-alterarDataProtocolo text-center' title='Alterar Data Protocolo' onclick='incluirDocumentosAnalise.alterarDataProtocolo(${full})'><span aria-hidden='true' class='fa fa-calendar' ></span></a>&nbsp;`;
        },

        getBotaoIncluirOutrosDocumentosDossie: function (full) {
            return `<button type='button' data-toggle='tooltip' class='btn btn-xs btn-info text-center' title='Incluir documentos neste dossiê' onclick='incluirDocumentosAnalise.incluirOutrosDocumentosDossie(${full})'><span aria-hidden='true' style='font - size: 10px;' class='fa fa-pencil fa-xs'></span></button>&nbsp;`;
        },

        getBotaoExcluirDossieDocsAnalise: function (full) {
            return `<button type='button' data-toggle='tooltip' class='btn btn-xs btn-danger text-center' title='Excluir este dossiê'  onclick='incluirDocumentosAnalise.excluirDossieDocsAnalise(${full})'><span aria-hidden='true' style='font-size: 10px;' class='fa fa-trash fa-xs'></span></button>&nbsp;`;
        },

        getBotaoFinalizarDossieAnalise: function (full) {
            return `<button id="finalizarPedido" class='btn btn-xs btn-success text-center' title='Finalizar este dossiê' type="button" onclick='incluirDocumentosAnalise.finalizarPedido(${full})'><span style='font-size: 10px;' class='fa fa-check fa-xs'></span></button>&nbsp;`;
        },

        getBotaoIncluirOutrosDocumentosDossieChecklist: function (full) {

            return `<button type='button' data-toggle='tooltip' id='botaoIncluirOutrosDocumentosDossieChecklist' class='btn btn-xs btn-info text-center' title='Incluir documentos neste dossiê' onclick='incluirDocumentosAnaliseChecklist.incluirOutrosDocumentosDossie(${full})'><span aria-hidden='true' style='font - size: 10px;' class='fa fa-pencil fa-xs'></span></button>&nbsp;`;
        },

        getBotaoExcluirDossieDocsAnaliseChecklist: function (full) {
            return `<button type='button' data-toggle='tooltip' class='btn btn-xs btn-danger text-center' title='Excluir este dossiê' style='background-color: red' onclick='incluirDocumentosAnaliseChecklist.excluirDossieDocsAnalise(${full})'><span aria-hidden='true' style='font-size: 10px;' class='fa fa-trash fa-xs'></span></button>&nbsp;`;
        },

        getBotaoFinalizarDossieAnaliseChecklist: function (full) {
            return `<button id="finalizarPedido" class='btn btn-xs btn-success text-center' title='Finalizar este dossiê' type="button" onclick='incluirDocumentosAnaliseChecklist.finalizarPedido(${full})'><span style='font-size: 10px;' class='fa fa-check fa-xs'></span></button>&nbsp;`;
        },

        atribuirDateTimePicker: function (idClass) {
            if ($(idClass).val() == "01/01/0001 00:00:00") {
                $(idClass).val("");
            }

            $(idClass).datetimepicker(
                {
                    format: 'DD/MM/YYYY',
                    locale: 'pt-br'
                },
                'setDate',
                moment()
            );
        },

        getBotaoAlterar: function () {
            return "<a rel='tooltip' class='btn btn-default btn-xs btn-alterar' title='Alterar'><span aria-hidden='true' class='glyphicon glyphicon-pencil' ></span></a>&nbsp;";
        },

        getBotaoExcluir: function () {
            return "<a rel='tooltip' class='btn btn-default btn-xs btn-excluir' title='Excluir'><span aria-hidden='true' class='fa fa-trash' ></span></a>&nbsp;";
        },

        getBotaoReverter: function () {
            return "<a rel='tooltip' class='btn btn-default btn-xs btn-reverter' title='Reverter Finalização'><span aria-hidden='true' class='fa fa-undo' ></span></a>&nbsp;";
        },

        //getBotaoAlterarDesabilitado: function () {
        //    return "<a rel='tooltip' class='btn btn-default btn-xs disabled' title='Alterar'><span aria-hidden='true' class='glyphicon glyphicon-pencil' ></span></a>&nbsp;";
        //},

        //getBotaoExcluirDesabilitado: function () {
        //    return "<a rel='tooltip' class='btn btn-default btn-xs disabled' title='Excluir'><span aria-hidden='true' class='glyphicon glyphicon-trash' ></span></a>&nbsp;";
        //},

        getLinkRemover: function () {
            return "<a rel='tooltip' class='btn-remover btn-link waves-effect' title='Remover'><i class='fa fa-remove' aria-hidden='true'></i></a>&nbsp;";
        },

        getLinkChecked: function () {
            return "<a rel='tooltip' class='btn-checked btn-link waves-effect' title='Checar'><i class='fa fa-check' aria-hidden='true'></i></a>&nbsp;";
        },

        getAlturaDataTableComPaginacao: function () { return "550px"; },
        getAlturaDataTableSemPaginacao: function () { return "630px"; },
        pad: function (num, size) {
            if (size == 0) return "";
            var s = num + "";
            while (s.length < size) s = "0" + s;
            return s;
        },
        normalize: function (term) {
            var ret = "";
            for (var i = 0; i < term.length; i++) {
                ret += accentMap[term.charAt(i)] || term.charAt(i);
            }
            return ret;
        },
        formatarData: function (data, type, full, meta) {
            return moment(data).format("L");
        },
        formatarDataRetornoDataOuSemData: function (data, type, full, meta) {
            var data = moment(data).format("L");
            if (data == "Invalid date") {
                return "Sem data"
            }
            if (data == "01/01/0001") {
                return "Sem data"
            }
            return data;
        },
        formatarDataRetornoDataOuSemDataIndex: function (data, type, full, meta) {
            var data = moment(data).format("lll");
            if (data == "Invalid date") {
                return "Sem data"
            }
            if (data == "01/01/0001") {
                return "Sem data"
            }
            return data;
        },
        formatarCompetencia: function (data, type, full, meta) {
            return moment(data).format("MM/YYYY");
        },
        formatarData: function (data, type, full, meta) {
            return moment(data).format("L");
        },
        formatarDataTexto: function (dataInput) {
            var dataExclusao = dataInput;
            var arrDataExclusao = dataExclusao.split('/');
            return site.formatarDataRetornoDataOuSemData(new Date(arrDataExclusao[2], arrDataExclusao[1] - 1, arrDataExclusao[0]));
        },
        formatarNumero: function (data, type, full, meta) {
            return numeral(data).format("0,0.00");
        },
        formatarIndice: function (data, type, full, meta) {
            return numeral(data).format("0.0000");
        },
        formatarSimNao: function (valor) {
            return valor != null && valor == 1 ? "Sim" : "Não";
        },
        formatarCPF: function (valor) {
            return valor.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/g, "\$1.\$2.\$3\-\$4");
        },
        formatarCNPJ: function (valor) {
            return valor.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/g, "\$1.\$2.\$3\/\$4-\$5");
        },

        atribuirMascaraData: function () {
            $(".inputData").mask("99/99/9999");
            $(".inputData").each(function () {
                if ($(this).val() == "01/01/0001") {
                    $(this).val("");
                }
            })
            $(".inputData2").mask("99/99/9999");
            $(".inputData2").each(function () {
                if ($(this).val() == "01/01/0001") {
                    $(this).val("");
                }
            })

            $(".inputDataReduzida").mask("99/9999");
            $(".inputDataReduzida").each(function () {
                if ($(this).val() == "01/0001") {
                    $(this).val("");
                }
            })
            $(".inputAno").mask("9999");
            $('.subconta').mask("9.999.999.99.");

            $(".inputCompetenciaTrimestral").mask("9T/9999");
        },

        atribuirMascaraNumero: function () {
            $(".inputNumero6N").mask("9?99999");
            $(".inputNumero6N").each(function () {
                if ($(this).val() == "0") {
                    $(this).val("");
                }
            })

            $(".inputLote").mask("9999?9");
            $(".inputLote").each(function () {
                if ($(this).val() == "0") {
                    $(this).val("");
                }
            })
        },

        exibirNotificacao: function (tipo, titulo, mensagem, tamanho, delay) {
            //Tipos: 'warning', 'info', 'success', 'error'
            if (tamanho == "") {
                tamanho = "normal";
            }

            if (delay == undefined) {
                delay = 10000;
            }

            return Lobibox.notify(tipo, {
                size: tamanho, // normal, mini, large
                title: titulo,
                delay: delay,
                delayIndicator: true,
                msg: mensagem,
                position: 'bottom right',
                sound: false
            });
        },

        criarAlerta: function (mensagem, idDiv, tipo) {

            let mensagemAlert = `<div class="alert alert-${tipo} alert-dismissible fade show" role="alert">
                                  ${mensagem}
                                  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                  </button>
                                </div>`;    

            return $(idDiv).html(mensagemAlert);
        }
    };

    $(document).ready(function () {

        //$('[data-toggle="tooltip"]').tooltip();

        moment.locale('pt-br');
        numeral.locale('pt-br');

        $.extend(jQuery.fn.dataTableExt.oSort, {
            "portugues-pre": function (data) {
                var a = 'a';
                var e = 'e';
                var i = 'i';
                var o = 'o';
                var u = 'u';
                var c = 'c';
                var special_letters = {
                    "Á": a, "á": a, "Ã": a, "ã": a, "À": a, "à": a,
                    "É": e, "é": e, "Ê": e, "ê": e,
                    "Í": i, "í": i, "Î": i, "î": i,
                    "Ó": o, "ó": o, "Õ": o, "õ": o, "Ô": o, "ô": o,
                    "Ú": u, "ú": u, "Ü": u, "ü": u,
                    "ç": c, "Ç": c
                };
                for (var val in special_letters)
                    data = data.split(val).join(special_letters[val]).toLowerCase();
                return data;
            },
            "portugues-asc": function (a, b) {
                return ((a < b) ? -1 : ((a > b) ? 1 : 0));
            },
            "portugues-desc": function (a, b) {
                return ((a < b) ? 1 : ((a > b) ? -1 : 0));
            }
        });

        $.extend(true, $.fn.dataTable.defaults.oLanguage, {
            "sEmptyTable": "Nenhum registro encontrado",
            "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrando 0 até de 0 registros",
            "sInfoFiltered": "(Filtrados de _MAX_ registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "_MENU_ resultados por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Procurando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        });

        $('.datatable').DataTable({
            "columnDefs": [{ type: 'portugues', targets: "_all" }]
        });

        jQuery.fn.dataTableExt.oSort['numeric-comma-asc'] = function (a, b) {
            var x = (a == "-") ? 0 : a.replace(/\./g, "").replace(/,/, ".");
            var y = (b == "-") ? 0 : b.replace(/\./g, "").replace(/,/, ".");
            x = parseFloat(x);
            y = parseFloat(y);
            return ((x < y) ? -1 : ((x > y) ? 1 : 0));
        };

        jQuery.fn.dataTableExt.oSort['numeric-comma-desc'] = function (a, b) {
            var x = (a == "-") ? 0 : a.replace(/\./g, "").replace(/,/, ".");
            var y = (b == "-") ? 0 : b.replace(/\./g, "").replace(/,/, ".");
            x = parseFloat(x);
            y = parseFloat(y);
            return ((x < y) ? 1 : ((x > y) ? -1 : 0));
        };


        function dateBrPre(a) {
            if (a == null || a == "") {
                return 0;
            }
            var brDatea = a.split('/');
            return (brDatea[2] + brDatea[1] + brDatea[0]) * 1;
        };

        jQuery.fn.dataTableExt.oSort['date-br-asc'] = function (a, b) {
            a = dateBrPre(a);
            b = dateBrPre(b);
            return ((a < b) ? -1 : ((a > b) ? 1 : 0));
        }

        jQuery.fn.dataTableExt.oSort['date-br-desc'] = function (a, b) {
            a = dateBrPre(a);
            b = dateBrPre(b);
            return ((a < b) ? 1 : ((a > b) ? -1 : 0));
        }

        function preCompetencia(a) {
            if (a == null || a == "") {
                return 0;
            }
            var vetor = a.split('/');
            return (vetor[1] + vetor[0]) * 1;
        }

        jQuery.fn.dataTableExt.oSort['competencia-asc'] = function (a, b) {
            a = preCompetencia(a);
            b = preCompetencia(b);
            return ((a < b) ? -1 : ((a > b) ? 1 : 0));
        }

        jQuery.fn.dataTableExt.oSort['competencia-desc'] = function (a, b) {
            a = preCompetencia(a);
            b = preCompetencia(b);
            return ((a < b) ? 1 : ((a > b) ? -1 : 0));
        }

        // Validação de Data e Moeda (ASP.Net MVC + JQuery Validation) em Português
        // http://cleytonferrari.com/validacao-de-data-e-moeda-asp-net-mvc-jquery-validation-em-portugues/
        /*
         * Localized default methods for the jQuery validation plugin.
         * Locale: PT_BR
         */
        jQuery.extend(jQuery.validator.methods, {
            date: function (value, element) {
                return this.optional(element) || /^\d\d?\/\d\d?\/\d\d\d?\d?$/.test(value);
            },
            number: function (value, element) {
                return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:\.\d{3})+)(?:,\d+)?$/.test(value);
            }
        });

        //Live Tooltip
        //$('body').tooltip({
        //    selector: '[rel=tooltip]',
        //    placement: "bottom",
        //});



    });

    return _public;

}

site = new Site();
