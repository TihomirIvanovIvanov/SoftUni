function solve() {
    let number = +document.getElementById("num1").value;
    let multiplier = +document.getElementById("num2").value;
    let divResult = document.getElementById("result");

    function findWrongInput(number, multiplier) {
        if (number > multiplier) {
            document.getElementById("result").innerHTML = "Try with other numbers.";
        }
    }
    
    function printTable(number, multiplier) {
        for (let i = number; i <= multiplier; i++) {
            let result = multiplier * i;
            let p = document.createElement('p');
            p.innerHTML = `${i} * ${multiplier} = ${result}`;
            divResult.appendChild(p);
        }
    }

    divResult.innerHTML = '';
    findWrongInput(number, multiplier);
    printTable(number, multiplier);
}