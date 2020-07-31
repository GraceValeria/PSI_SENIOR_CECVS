function HomeIndex() {

    let tabela;

    let arrayCoordenacao = [];
    arrayCoordenacao = JSON.parse(document.getElementById("CoordenacoesJson").value);

    //let listaTotalCoordenacoes = JSON.parse($("#CoordenacoesJson"));

    //let listaTotalCoordenacoes = JSON.parse($("#CoordenacoesJson").val());
    //let listaEmpregados = JSON.parse($("#EmpregadosJson").val());

    //window.onload = function () {
    //    carregarEventos();
    //}

    $(document).ready(function () {
        carregarEventos();

    });

    //$(document).ready(function () {

    //    carregarEventos();
    //});

    function carregarEventos() {

        iniciarDataTable();
        //onShownModalCadastroEmpregado();
    }


        ////if ($.fn.DataTable.isDataTable('#listaDistribuicoes')) {

        ////    tabela.clear().draw(false);
        ////    tabela.rows.add(listaDistribuicoes).draw(false);
        ////}

        ////else {


    function iniciarDataTable() {

        console.log(arrayCoordenacao);

            tabela = $('#listaCoordenacoes').DataTable({
                sDom: '<"top">rt<"bottom"ifp><"clear">',
                scrollY: "300px",
                scrollCollapse: false,
                paging: true,
                lengthChange: true,
                data: arrayCoordenacao,
                pageLength: 8,
                info: true,
                order: [[5, "asc"], [0, "asc"]],
                columns: [
                    { data: "Nome", title: "Coordenação" },
                    { data: "CaixaPostal", title: "Caixa Postal" },
                    //{ data: "RecebidoEm", title: "Data Recepção" },
                    //{ data: "DistribuidoEm", title: "Data Distribuição" },
                    //{ data: "RetornadoEm", title: "Data Retorno" },
                    //{ data: "DevolvidoEm", title: "Data Devolução" },
                    {
                        data: "Acoes", title: "Ações", "orderable": false, width: "6%",
                        render: function (data, type, full) {
                            return desenharBotoes(full)
                        },
                        class: "dt-left"
                    }
                ]
            });
      
    }


    function desenharBotoes(full) {

        botoes = '';

        //if (!full.RetornadoEm) {
        //    botoes += `<button class='btn btn-xs btn-default' onclick='distribuicaoDeDossies.imprimirControleDeLote("${full.DistribuicaoId}")' title='Imprimir Controle de Lote'><span class='fa fa-print'></span></button>&nbsp;`;
        //    botoes += `<button class='btn btn-xs btn-success' onclick='distribuicaoDeDossies.abrirModalRetornoDistribuicao("${full.DistribuicaoId}", "${full.Caixas}", "${full.Lotes}", "${full.Empregado}", "${full.DistribuidoEm}")' title='Receber Dossiês'><span class='fa fa-check-square-o'></span></button>&nbsp;`;
        //    botoes += `<button class='btn btn-xs btn-danger' onclick='distribuicaoDeDossies.confirmacaoExclusaoDistribuicao("${full.DistribuicaoId}")' title='Excluir Distribuição'><span class='fa fa-times'></span></button>`;
        //}

        return botoes;
    }

    function abrirModalCadastroEmpregado() {

        //limparModalCadastroEmpregado('#modalCadastroEmpregado');
        $('#modalCadastroEmpregado').modal('show');
        $("#modalCadastroEmpregado").modal({ backdrop: 'static', keyboard: false });
    }


    function abrirModalCadastroCoordenacao() {

        //limparModalCadastroCoordenacao('#modalCadastroCoordenacao');
        $('#modalCadastroCoordenacao').modal('show');
        $("#modalCadastroCoordenacao").modal({ backdrop: 'static', keyboard: false });
    }


    function onShownModalCadastroEmpregado() {

        $('#modalCadastroEmpregado').on('shown.bs.modal', function () {

            $(this).find(".selectpicker").selectpicker('refresh');
        })
    }



    function onShownModalCadastroCoordenacao() {

        $('#modalCadastroCoordenacao').on('shown.bs.modal', function () {

            $(this).find(".selectpicker").selectpicker('refresh');
        })
    }


    function adicionarNovoEmpregado(){

        //verificarSeJaExiste

        //if (!validarCamposAgendamento()) return;

        //site.exibirNotificacao("info", "Informação", "Registrando Empregado...");
        
        $.ajax({
            type: "POST",
            dataType: "json",
            async: false,
            url: rootUrl + 'Home/RegistrarEmpregado',
            data: {
                nome: $('#modalCadastroEmpregado').find("#NomeEmpregado").val(),
                matricula: $('#modalCadastroEmpregado').find("#Matricula").val(),
            }
        })
            .done(function (json) {

                if (json.sucesso) {

                    //site.exibirNotificacao("success", "Sucesso", json.mensagem);
                   
                    //listaEmpregados = JSON.parse(json.empregados);

                    listaCoordenacoes = JSON.parse(json.Coordenacoes);

                    //atualizaDataTabel(listaCoordenacoes);

                    //limparModalCoordenacao('#modalCadastroCoordenacao');

                    $('#modalCadastroCoordenacao').modal('hide');
                }

                else {

                    let detalhes = "";

                    if (typeof (json.mensagem) == "string") detalhes += json.mensagem;

                    else {

                        $(json.mensagem).each(function (idxErros, erros) {

                            detalhes += erros.ErrorMessage + "<br>";
                        });
                    }


                    site.criarAlerta(detalhes, "mensagemView", "danger");
                }
            })
            .fail(function (req, status, err) {
                //site.exibirNotificacao("error", "Atenção", err);
            });
  
    }

    function adicionarNovaCoordenacao(){
      
        //verificarSeJaExiste

        //if (!validarCamposAgendamento()) return;

        //site.exibirNotificacao("info", "Informação", "Registrando Coordenacao...");

        $.ajax({
            type: "POST",
            dataType: "json",
            async: false,
            url: rootUrl + 'Home/RegistrarCoordenacao',
            data: {
                nomeCoordenacao: $('#modalCadastroCoordenacao').find("#NomeCoordenacao").val(),
                caixaPostal: $('#modalCadastroCoordenacao').find("#CaixaPostal").val(),
            }
        })
            .done(function (json) {

                if (json.sucesso) {

                    //site.exibirNotificacao("success", "Sucesso", json.mensagem);

                    //listaEmpregados = JSON.parse(json.empregados);

                    listaCoordenacoes = JSON.parse(json.Coordenacoes);

                    //atualizaDataTabel(listaCoordenacoes);

                    //limparModalCoordenacao('#modalCadastroCoordenacao');

                    $('#modalCadastroCoordenacao').modal('hide');
                }

                else {

                    let detalhes = "";

                    if (typeof (json.mensagem) == "string") detalhes += json.mensagem;

                    else {

                        $(json.mensagem).each(function (idxErros, erros) {

                            detalhes += erros.ErrorMessage + "<br>";
                        });
                    }


                    //site.criarAlerta(detalhes, "mensagemView", "danger");
                }
            })
            .fail(function (req, status, err) {
               // site.exibirNotificacao("error", "Atenção", err);
            });

    }








    var _public = {
        abrirModalCadastroEmpregado: abrirModalCadastroEmpregado,
        abrirModalCadastroCoordenacao: abrirModalCadastroCoordenacao,
        adicionarNovoEmpregado: adicionarNovoEmpregado,
        adicionarNovaCoordenacao: adicionarNovaCoordenacao,
    }

    return _public;
}

var homeIndex = new HomeIndex();