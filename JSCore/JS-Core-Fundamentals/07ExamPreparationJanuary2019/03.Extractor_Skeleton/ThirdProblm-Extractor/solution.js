function solve() {
    let output = document.getElementById("output");
    let button = document.querySelector("button");

    button.addEventListener("click", extract);

    function extract() {
        let input = document.getElementById("input").value;
        let pattern = /[0-9]+/g;

        let charsToTake = input.match(pattern)[0];
        let slicedString = input.substr(charsToTake.length, +charsToTake);

        let delimeter = slicedString[slicedString.length - 1];
        let parts = slicedString.split(delimeter).filter(Boolean);

        parts[1] = parts[1].replace(new RegExp(`[${parts[0]}]`, 'g'), '')
            .replace(/[#]/g, ' ');

        output.value = parts[1];
    }
}