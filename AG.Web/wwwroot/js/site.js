// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {

    $("#btn-iniciar").click(function () {
        
        $("#btn-iniciar").prop('disabled', true);
        let fila = [];
        $(".nao-processando").addClass('d-none')
        $(".processando").removeClass('d-none')
        obterGeracoes().then((geracoesData) => {
            geracoesData.geracoes.forEach(function (geracao) {
                geracao.populacao.individuos.forEach(individuo => {
                    fila.push(function () { percorrerLabirinto(individuo.coordenadas) });
                })
            });
        });

        let index = 0;
        let loopFila = setInterval(function () {
            console.log((index+1) + "/ " + fila.length)

            if (typeof (fila[index]) === 'function')
                fila[index]();
             
            index++;

            if (index === (fila.length)) {
                clearInterval(loopFila);
                $("#btn-iniciar").prop('disabled', false);
                $(".processando").addClass('d-none')
                $(".nao-processando").removeClass('d-none')
            }
        }, 50);
    });
});

function obterGeracoes() {
    let resultadosRequest = {
        eltismo: true,
        tamanhoPopulacao: $("#tamanhoPopulacao").val(),
        taxaCrossover: $("#taxaCrossover").val(),
        taxaMutacao: $("#taxaMutacao").val()
    };

    return new Promise(function (resolve, reject) {
        $.post("/Home/ObterResultados", resultadosRequest, function (geracoes) {
            resolve(geracoes);
        }).fail(function () {
            console.error("não foi possivel obter a lista de caminhos.");
        });
    });
}

function percorrerLabirinto(coordenadas) {
    $('#labirinto td').removeClass('ativo');
    $('#labirinto td[data-x=0][data-y=0]').addClass('ativo');

    coordenadas.forEach(function (coordenada) {
        $(`#labirinto td[data-x=${coordenada.x}][data-y=${coordenada.y}]`).addClass('ativo');
    });
}