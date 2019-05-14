function solve() {
    let currentId = "depot";
    let currentStopName;

    let departBtn = $("#depart");
    let arriveBtn = $("#arrive");

    let span = $(".info");
    
    function depart() {
        $.ajax({
            method: "GET",
            url: `https://judgetests.firebaseio.com/schedule/${currentId}.json`,
            success: displaySuccess,
            error: displayError
        });
    }
    
    function displaySuccess(resource) {
        departBtn.attr("disabled", true);
        arriveBtn.attr("disabled", false);

        currentId = resource.next;
        currentStopName = resource.name;
        span.text(`Next stop ${currentStopName}`);
    }

    function displayError() {
        span.text("Error");
        departBtn.attr("disabled", true);
        arriveBtn.attr("disabled", true);
    }
    
    function arrive() {
        span.text(`Arriving at ${currentStopName}`);
        departBtn.attr("disabled", false);
        arriveBtn.attr("disabled", true);
    }

    return {
        depart,
        arrive
    };
}

let result = solve();