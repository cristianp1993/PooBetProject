function validate(){
    let user = $("#inputUser").val();
    let pass = $("#inputPassword").val();

    if (user != "" && pass != "") {
        $("#spanMessage").text("");

        window.location = "Home/ValidateUser?user="+user + "&password="+pass;
                
    }else{
        $("#spanMessage").text("Usuario y contraseña obligatorios");
        $("#spanMessage").css({
            "display":"block",
            "color":"white"
        });
    }

}