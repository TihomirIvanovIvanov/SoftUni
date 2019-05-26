function validate() {
    $("#email").on("change", () => {
        let input = $("#email").val();
        let regex = /^[a-z]+@[a-z]+\.[a-z]+$/g;

        if (!input.match(regex)) {
            $("#email").addClass("error");
        } else {
            $("#email").removeClass("error");
        }
    });
}