$(document).ready(function () {

    $('[name="cpf"]').mask('000.000.000-00');
    $('[name="cnpj"]').mask('00.000.000/0000-00');
    $('[name="cep"]').mask('00000-000');
    $('[name="ctps"]').mask('0000000 00000 SS');
    $('.exibeCpf').mask('000.000.000-00');
    $('.exibeCep').mask('00000-000');
    $('.exibeCnpj').mask('00.000.000/0000-00');
    $('.exibeTel').mask('(00) 0000-0000');
    $('[name="telefone"]').mask('(00) 0000-0000');
    $('[name="aniversario"]').mask('00/00/0000');

    $('[create="create"]').click(function () {

        if ($('[name="cpf"]').length) {

            $('[name="login"]').next('span').text('');
            $('[name="ctps"]').next('span').text('');
            $('[name="cpf"]').next('span').text('');

            if (!validarCPF($('[name="cpf"]'))) {
                return false;
            } else {
                if ($('[name="ctps"]')) {
                    if ($('[name="ctps"]').val() != "") {

                        if ($('[name="login"]').val() != "") {


                            var login = $('[name="login"]').val();
                            var cpf = $('[name="cpf"]').val();
                            var ctps = $('[name="ctps"]').val();

                            if (!CheckDados(login, cpf, ctps)) {
                                return false;
                            }
                        } else {
                            $('[name="login"]').next('span').text('Login é obrigatorio!');
                            $('[name="login"]').focus();
                            return false;
                        }
                        return false;
                    } else {
                        $('[name="ctps"]').next('span').text('CTPS é obrigatorio!');
                        $('[name="ctps"]').focus();
                        return false;
                    }
                } else {

                    if ($('[name="login"]').val() != "") {


                        var login = $('[name="login"]').val();
                        var cpf = $('[name="cpf"]').val();
                        var ctps = "False";

                        if (!CheckDados(login, cpf, ctps)) {
                            return false;
                        }
                    } else {
                        $('[name="login"]').next('span').text('Login é obrigatorio!');
                        $('[name="login"]').focus();
                        return false;
                    }
                    return false;

                }
            }
        }





        if ($('[name="cnpj"]').length) {
            $('[name="cnpj"]').next('span').text('');
            if (!validarCNPJ($('[name="cnpj"]'))) {              
                return false;
            } else {
                var cnpj = $('[name="cnpj"]').val();
                if (!CheckCnpj(cnpj)) {
                    return false;
                };
            }
        }


    });



});


function validarCPF(campoCpf) {

    var cpf = $(campoCpf).val();

    cpf = cpf.replace(/[^\d]+/g, '');

    if (cpf == '') {
        $('[name="cpf"]').next('span').text('CPF é obrigatorio!');
        $(campoCpf).focus();
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
        $('[name="cpf"]').next('span').text('CPF Inválido!');
        $(campoCpf).focus();
        return false;
    }

    add = 0;

    for (i = 0; i < 9; i++)
        add += parseInt(cpf.charAt(i)) * (10 - i);

    rev = 11 - (add % 11);

    if (rev == 10 || rev == 11)
        rev = 0;

    if (rev != parseInt(cpf.charAt(9))) {
        $('[name="cpf"]').next('span').text('CPF Inválido!');
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
        $('[name="cpf"]').next('span').text('CPF Inválido!');
        $(campoCpf).focus();
        return false;
    }

    return true;
}


function validarCNPJ(campoCnpj) {

    var cnpj = $(campoCnpj).val()

    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj == '') {
        $('[name="cnpj"]').next('span').text('CNPJ é obrigatorio!');
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

        $('[name="cnpj"]').next('span').text('CNPJ Inválido!');
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
        $('[name="cnpj"]').next('span').text('CNPJ Inválido!');
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
        $('[name="cnpj"]').next('span').text('CNPJ Inválido!');
        $(campoCnpj).focus();
        return false;
    }

    return true;
}


function CheckDados(login, cpf, ctps) {


    //console.log(ctps);

    $.ajax({
        url: 'CheckDados',
        data: {
            login: login,
            cpf: cpf,
            ctps: ctps
        },
        success: function (data) {

            //console.log(data);

            
            
            switch (data) {

                case 'cpf_true':

                    $('[name="cpf"]').next('span').text('CPF já cadastrado!');
                    $('[name="cpf"]').focus();
                    return false;
                    break;

                case 'ctps_true':

                    $('[name="ctps"]').next('span').text('CTPS já cadastrado!');
                    $('[name="ctps"]').focus();
                    return false;
                    break;

                case 'login_true':

                    $('[name="login"]').next('span').text('Login já cadastrado!');
                    $('[name="login"]').focus();
                    return false;
                    break;


                case 'login_ctps_true':
                    $('[name="login"]').next('span').text('Login já cadastrado!');
                    $('[name="ctps"]').next('span').text('CTPS já cadastrado!');
                   

                    $('[name="ctps"]').focus();

                    $('[name="ctps"]').blur(function () {
                        $('[name="login"]').focus();
                    });
                    return false;
                    break;

                case 'cpf_ctps_true':
                    $('[name="cpf"]').next('span').text('CPF já cadastrado!');
                    $('[name="ctps"]').next('span').text('CTPS já cadastrado!');


                    $('[name="cpf"]').focus();

                    $('[name="cpf"]').blur(function () {
                        $('[name="ctps"]').focus();
                    });
                    return false;
                    break;

                case 'cpf_login_true':
                    $('[name="cpf"]').next('span').text('CPF já cadastrado!');
                    $('[name="login"]').next('span').text('Login já cadastrado!');


                    $('[name="cpf"]').focus();

                    $('[name="cpf"]').blur(function () {
                        $('[name="login"]').focus();
                    });
                    return false;
                    break;



                case 'True':
                    $('[name="login"]').next('span').text('Login já cadastrado!');
                    $('[name="ctps"]').next('span').text('CTPS já cadastrado!');
                    $('[name="cpf"]').next('span').text('CPF já cadastrado!');

                    $('[name="cpf"]').focus();
                    
                    $('[name="cpf"]').blur(function () {
                        $('[name="ctps"]').focus();
                    });

                    $('[name="ctps"]').blur(function () {
                        $('[name="login"]').focus();
                    });
                    return false;
                    break;

                case 'False':

                    $('.form-horizontal').submit();

                    break;
            }
            





            return false;

        }

    });
}


function CheckCnpj(cnpj) {


    console.log(cnpj);

    
    $.ajax({
        url: 'CheckCnpj',
        data: {
            cnpj: cnpj
        },
        success: function (data) {

            console.log(data);

            if (data === "True") {
                $('[name="cnpj"]').next('span').text('CNPJ já cadastrado!');
                $('[name="cnpj"]').focus();
                return false;
            } else {
                $('.form-horizontal').submit();
            }

        }

    });
}