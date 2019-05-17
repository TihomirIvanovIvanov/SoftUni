function solve() {
    let arr = JSON.parse(document.getElementById("arr").value);
    let result = document.getElementById("result");

    let pattern = /^([A-Z][a-z]* [A-Z][a-z]*) (\+359 [0-9] [0-9]{3} [0-9]{3}|\+359-[0-9]-[0-9]{3}-[0-9]{3}) ([a-z0-9]+@[a-z]+\.[a-z]{2,3})$/;

    let match;
    for (let data of arr) {
        match = pattern.exec(data);
        if (match) {
            print(`Name: ${match[1]}`);
            print(`Phone Number: ${match[2]}`);
            print(`Email: ${match[3]}`);
        } else {
            let errorP = document.createElement('p');
            errorP.textContent = "Invalid data";
            result.appendChild(errorP);
        }
        let dashes = document.createElement('p');
        dashes.textContent = "- - -";
        result.appendChild(dashes);
    }

    function print(text) {
        let p = document.createElement('p');
        p.textContent = text;
        result.appendChild(p);
    }
}