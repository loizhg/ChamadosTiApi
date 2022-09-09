function onClickLogar() {
    let campoUsuario = document.querySelector('#usuario');
    let campoSenha = document.querySelector('#senha');

    if (!campoUsuario.value && !campoSenha.value) {
        alert('Usuário e senha não preenchidos.');
        return;
    }

    if (!campoUsuario.value) {
        alert('Usuário não preenchido.');
        return;
    }

    if (!campoSenha.value) {
        alert('Senha não preenchida.');
        return;
    }

    var pessoa = {
        usuario: campoUsuario,
        senha: campoSenha
    };

    alert("Logado com sucesso");

}

var valor
let valor = document.querySelector('#valor');
var valor1 = document.querySelector('#valor1');
var oper = document.querySelector('#operador');
var readlineSync = require('readline-sync');
oper = readlineSync.question("Qual operacao deseja efetuar (+) (-) (*) (/)? : \n");
valor = parseFloat(readlineSync.question("Insira o primeiro numero: \n"));
valor1 = parseFloat(readlineSync.question("Insira o segundo numero: \n"));

function doOperation(operator, value1, value2) {
    if (operator == "+") {
        return value1 + value2;
    } else if
        (operator == "-") {
        return value1 - value2;
    } else if
        (operator == "*") {
        return value1 * value2;
    } else if
        (operator == "/") {
        return value1 / value2;
    } else {
        throw new Error('Operação inválida');
    }
}


console.log('O resultado é', doOperation(oper, valor, valor1)) 