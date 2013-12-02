$(document).ready(function () {

    $('[name="cpf"]').mask('000.000.000-00');
    $('[name="cnpj"]').mask('000.000.000/0000-00');
    $('[name="cep"]').mask('00000-000');
    $('[name="ctps"]').mask('0000000 00000 SS');
    $('.exibeCpf').mask('000.000.000-00');
    $('.exibeCep').mask('00000-000');
    $('.exibeCnpj').mask('000.000.000/0000-00');
    $('.exibeTel').mask('(00) 0000-0000');
    $('[name="telefone"]').mask('(00) 0000-0000');
    $('[name="aniversario"]').mask('00/00/0000');

    $('[name="enviar"]').click(function () {
        /*
        if ($('[name="cpf"]')) {
            if (!validarCPF($('[name="cpf"]'))) {
                return false;
            }
        }

        if ($('[name="cnpj"]')) {
            if (!validarCNPJ($('[name="cnpj"]'))) {
                return false;
            }
        }
        */

    });

});


function validarCPF(campoCpf) {

    var cpf = $(campoCpf).val();

    cpf = cpf.replace(/[^\d]+/g, '');

    if (cpf == '') {
        /*alert("CPF não pode ser nulo!");
        $(campoCpf).focus();*/
        return false;
    } 

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
        cpf == "99999999999") {
        alert("CPF Inválido!");
        $(campoCpf).focus();
        return false;
    }

    add = 0;

    for (i = 0; i < 9; i++)
        add += parseInt(cpf.charAt(i)) * (10 - i);

    rev = 11 - (add % 11);

    if (rev == 10 || rev == 11)
        rev = 0;

    if (rev != parseInt(cpf.charAt(9)))
    {
        alert("CPF Inválido");
        $(campoCpf).focus();
        return false;
    }

    add = 0;

    for (i = 0; i < 10; i++)
        add += parseInt(cpf.charAt(i)) * (11 - i);

    rev = 11 - (add % 11);

    if (rev == 10 || rev == 11)
        rev = 0;

    if (rev != parseInt(cpf.charAt(10))) {
        alert("CPF Inválido!");
        $(campoCpf).focus();
        return false;
    }

    return true;
}


function validarCNPJ(campoCnpj) {

    var cnpj = $(campoCnpj).val()

    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj == '') {
        alert('CNPJ não pode ser nulo');
        $(campoCnpj).focus();
        return false;
    }

    if (cnpj.length != 14) {
        alert('CNPJ deve ter no mínimo 14 caracteres!');
        $(campoCnpj).focus();
        return false;
    }

    // Elimina CNPJs invalidos conhecidos
    if (cnpj == "00000000000000" ||
        cnpj == "11111111111111" ||
        cnpj == "22222222222222" ||
        cnpj == "33333333333333" ||
        cnpj == "44444444444444" ||
        cnpj == "55555555555555" ||
        cnpj == "66666666666666" ||
        cnpj == "77777777777777" ||
        cnpj == "88888888888888" ||
        cnpj == "99999999999999") {

        alert('CNPJ inválido!');
        $(campoCnpj).focus();
        return false;
    }

    // Valida DVs
    tamanho = cnpj.length - 2
    numeros = cnpj.substring(0, tamanho);
    digitos = cnpj.substring(tamanho);
    soma = 0;
    pos = tamanho - 7;

    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0)) {
        alert('CNPJ inválido!');
        $(campoCnpj).focus();
        return false;
    }

    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }

    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1)) {
        alert('CNPJ inválido!');
        $(campoCnpj).focus();
        return false;
    }

    return true;
}
