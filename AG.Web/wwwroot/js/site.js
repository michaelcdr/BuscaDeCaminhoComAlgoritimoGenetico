let geracoesExecutadas = [];

$(function () {
    let btnIniciar = $("#btn-iniciar");

    btnIniciar.click(function () {
        
        btnIniciar.prop('disabled', true);

        $(".nao-processando").addClass('d-none');

        $(".processando").removeClass('d-none');

        $("#detalhes").empty();

        let fila = [];
        let geracoesObtidas;
        let promessaGeracoes = new Promise(function (resolve) {
            obterGeracoes().then((geracoesData) => {
                geracoesData.geracoes.forEach(function (geracao) {
                    geracao.populacao.individuos.forEach(individuo => {
                        fila.push(function () { percorrerLabirinto(individuo.coordenadas) });
                    })
                });
                geracoesObtidas = geracoesData;
                resolve();
            });
        });
        
        promessaGeracoes.then(function () {
            //console.log('teste');
        
            let index = 0;
        
            let velocidade = $("#velocidade").val() !== "" ? $("#velocidade").val() : 50; 
        
            let loopFila = setInterval(function () {

                //console.log((index + 1) + "/ " + fila.length);

                if (typeof (fila[index]) === 'function')
                    fila[index]();
             
                index++;

                if (index === (fila.length)) {
                    clearInterval(loopFila);

                    $('#labirinto td').removeClass('ativo');

                    btnIniciar.prop('disabled', false);

                    $(".processando").addClass('d-none');

                    $(".nao-processando").removeClass('d-none');

                    $("#detalhes").html(gerarDetalhe(geracoesObtidas));
                }
            }, velocidade);
        })
    });
});

function obterGeracoes() {
    let resultadosRequest = {
        eltismo: $("#eltismo").is(":checked"),
        tamanhoPopulacao: $("#tamanhoPopulacao").val(),
        taxaCrossover: $("#taxaCrossover").val(),
        taxaMutacao: $("#taxaMutacao").val()
    };

    return new Promise(function (resolve, reject) {
        $.post("/Home/ObterResultados", resultadosRequest, function (geracoes) {

            geracoesExecutadas.push(geracoes);

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

function visualizarItem(el) {
    let coordenaas = $(el).data('json');
    percorrerLabirinto(coordenaas)
}

function gerarDetalhe(geracoesData) {
    
    let itens = "";
    if (geracoesData.geracoes) {
        geracoesData.geracoes.filter(a => a.temSolucao).forEach(geracao => {
            if (geracao) {
                if (geracao.populacao.individuos) {
                    let individuosComSolucao = geracao.populacao.individuos.filter(individuo => individuo.temSolucao)
                    //console.log(individuosComSolucao);

                    itens +="<ul>"
                    individuosComSolucao.forEach(b => {
                        let dados =  JSON.stringify(b.coordenadas) ;

                        itens += "<li>Aptidao: " + b.aptidao + "</li>" +
                            "<li>Colisões: " + b.colisoes + "</li>" +
                            
                            "<li>Bits: " + b.bits.join('') + "<br> <button type='button' class='btn btn-dark' onclick='visualizarItem(this)' data-json='" + dados +"'>Visualizar solução</button></li>"
                    });
                    itens += "</ul>"
                }
            }
        });
    }
    
    let retorno = `<ul>
        <li>
            <strong>Colisões com paredes:</strong> ${geracoesData.totalDeColisoes} <br />
        </li>
        <li>
            <strong>Gerações: </strong>${geracoesExecutadas[geracoesExecutadas.length - 1].geracoes.length}<br />
        <li>
            <strong>Melhores resultados:</strong> <br />
            ${itens}
        </li>
    </ul>`;

    return retorno;
}