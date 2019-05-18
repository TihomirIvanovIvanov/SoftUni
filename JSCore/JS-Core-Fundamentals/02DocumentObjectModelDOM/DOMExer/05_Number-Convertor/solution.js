function solve() {
    let selectMenu = document.getElementById("selectMenuTo");
    let result = document.getElementById("result");
    let button = document.getElementsByTagName("button")[0];

    button.addEventListener("click", convert);

    let num = document.getElementById("input");

    let option = document.createElement("option");
    option.text = "binary";
    selectMenu.add(option);

    option = document.createElement("option");
    option.text = "hexadecimal";
    selectMenu.add(option);

    function convert() {
        if (num.value.length > 0 && selectMenu.value !== '') {
            if (selectMenu.value === "binary") {
                result.value = decimalToBinary(num.value);
            } else {
                result.value = decimalToHexadecimal(num.value);
            }
        }
    }

    function decimalToBinary(decimal) {
        return (decimal >>> 0).toString(2);
    }

    function decimalToHexadecimal(decimal) {
        return parseInt(decimal).toString(16).toUpperCase();
    }
}