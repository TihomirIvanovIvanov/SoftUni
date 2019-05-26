function attachEventsListeners() {
    const kmInM = 1000;
    const mInM = 1;
    const cmInM = 0.01;
    const mmInM = 0.001;
    const miInM = 1609.34;
    const yrdInM = 0.9144;
    const ftInM = 0.3048;
    const inchInM = 0.0254;

    let input = $("#inputDistance");

    $("#convert").on("click", () => {
        let distance = +input.val();
        let inputUnits = $("#inputUnits").val();
        let outputUnits = $("#outputUnits").val();

        let distanceInMeters = getMetersFromUnits(distance, inputUnits);
        distance = convertDistance(distanceInMeters, outputUnits);
        $("#outputDistance").val(distance);
    });

    function getMetersFromUnits(distance, inputUnits) {
        switch (inputUnits) {
            case "km": return distance * kmInM;
            case "m": return distance * mInM;
            case "cm": return distance * cmInM;
            case "mm": return distance * mmInM;
            case "mi": return distance * miInM;
            case "yrd": return distance * yrdInM;
            case "ft": return distance * ftInM;
            case "in": return distance * inchInM;
        }
    }

    function convertDistance(distanceInMeters, outputUnits) {
        switch (outputUnits) {
            case "km": return distanceInMeters / kmInM;
            case "m": return distanceInMeters / mInM;
            case "cm": return distanceInMeters / cmInM;
            case "mm": return distanceInMeters / mmInM;
            case "mi": return distanceInMeters / miInM;
            case "yrd": return distanceInMeters / yrdInM;
            case "ft": return distanceInMeters / ftInM;
            case "in": return distanceInMeters / inchInM;
        }
    }
}

// OR

// function attachEventsListeners() {
//     let button = document.getElementById('convert');
//     let unitsObj = {km: 1000, m: 1, cm: 0.01, mm: 0.001,
//         mi: 1609.34, yrd: 0.9144,
//         ft: 0.3048, in: 0.0254}
//
//     button.addEventListener('click', () => {
//         let firstUnit = document.getElementById('inputUnits').value;
//         let secondUnit = document.getElementById('outputUnits').value;
//         let inputNum = document.getElementById('inputDistance').value;
//         let outputNum = document.getElementById('outputDistance');
//         outputNum.setAttribute('disabled', '');
//         outputNum.value = (+inputNum * unitsObj[firstUnit]) / unitsObj[secondUnit]
//     })
// }