function CreateUser() {
    let per_nombre = $("#inp_nombre").val();
    let per_documento = $("#inp_documento").val();
    let per_correo = $("#inp_correo").val();
    let per_genero = $("#sel_genero").val();
    let per_contrasena = $("#inp_password").val();
    let per_contrasena1 = $("#inp_password2").val();
    let per_fecha_nac = $("#inp_fecha").val();

    if (per_contrasena != per_contrasena1) {

        $("#val_password").text("Las contraseñas no coinciden")
        $("#val_password").css({
            "display": "block",
            "color": "red"
        })

    }

    if (per_nombre != "" && per_documento != "" && per_correo != "" && per_genero != "" && per_contrasena != "" && per_fecha_nac!= "") {

        var Person = { per_nombre: per_nombre, per_documento: per_documento, per_correo: per_correo, per_genero: per_genero, per_contrasena: per_contrasena, per_fecha_nac: per_fecha_nac };

        $.ajax({
            url: "/Person/CreateUserNew",
            type: 'POST',
            async: false,
            data: {
                Model: Person
                
            },
            //contentType: "application/json; charset=utf-8",
            dataType: "text",
            success: function (data) {

                if (data != "Error") {

                    window.open("/Menu/Index/", "_self")

                    
                }


            },
            error: function (request, status, error) {
                console.log(request.responseText);
            }
        });


    } else {
        $("#men_obligatorios").text("Complete los campos obligatorios (*)")
        $("#men_obligatorios").css({
            "display": "block",
            "color": "red"
        })
    }


}


function RechargeUser() {

    let apostador = $("#sal_recharge").val();
    let recarga = $("#sal_recharge").val();

    if (apostador != 0 && recarga != 0 && sal_recharge != "") {
        $("#men_obliga").css({
            "display": "none"
        })



    } else {
        $("#men_obliga").text("Debe seleccionar un apostador y debe ingresar valor mayor a 0")
        $("#men_obliga").css({
            "display": "block",
            "color": "red"
        })
    }

}