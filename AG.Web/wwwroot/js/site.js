// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    obterCaminhosGerados();
});

function obterCaminhosGerados() {
    return new Promise(function (resolve, reject) { 
        $.get("/Home/ObterCaminhos", function (caminhos) {
            resolve(caminhos);
        }).fail(function () {
            console.error("não foi possivel obter a lista de caminhos.");
        });
    })
}