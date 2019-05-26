function notify(msg) {
    $("#notification").css("display", "block");
    $("#notification").text(msg);

    setTimeout(function () {
        $("#notification").css("display", "none");
    }, 2000);
}