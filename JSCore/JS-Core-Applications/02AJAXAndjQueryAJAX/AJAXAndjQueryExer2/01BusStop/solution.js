function getInfo() {
    let stopId = $("#stopId").val();
    let baseUrl = `https://judgetests.firebaseio.com/businfo/${stopId}.json`;
    $("#buses").empty();

    $.ajax({
        method: "GET",
        url: baseUrl,
        success: displayBuses,
        error: displayError
    });

    function displayBuses(busStop) {
        $("#stopName").text(busStop.name);

        for (let bus in busStop.buses) {
            $("#buses")
                .append($(`<li>Bus ${bus} arrives in ${busStop["buses"][bus]} minutes</li>`));
        }
    }
    
    function displayError() {
        $("#stopName").text("Error");
    }
}