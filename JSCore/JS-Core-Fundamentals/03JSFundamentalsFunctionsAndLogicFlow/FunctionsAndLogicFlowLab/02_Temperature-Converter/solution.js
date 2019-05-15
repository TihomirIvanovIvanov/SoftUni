function solve() {
    let degree = +document.getElementById("num1").value;
    let type = document.getElementById("type").value;

    let result = '';
    let convertedTemp = 0;
    let correctType = false;

    function convert(degree, type) {
        if (type.toLowerCase() === "celsius") {
            convertedTemp = degree * 9 / 5 + 32;
            correctType = true;
        } else if (type.toLowerCase() === "fahrenheit") {
            convertedTemp = ((degree - 32) * 5) / 9;
            correctType = true;
        }
    }

    function print() {
        if (correctType) {
            result = Math.round(convertedTemp);
        } else {
            result = "Error!";
        }
    }

    convert(degree, type);
    print(degree, type);
    document.getElementById("result").innerHTML = result;
}