function solve() {
    let startNum = +document.getElementById("firstNumber").value;
    let endNum = +document.getElementById("secondNumber").value;

    let firstWord = document.getElementById("firstString").value;
    let secondWord = document.getElementById("secondString").value;
    let thirdWord = document.getElementById("thirdString").value;

    let result = document.getElementById("result");

    function checkCurrentNumber(i) {
        if (i % 3 === 0 && i % 5 === 0) {
            let p = document.createElement('p');
            p.innerHTML = `${i} ${firstWord}-${secondWord}-${thirdWord}`;
            result.appendChild(p);
        } else if (i % 3 === 0) {
            let p = document.createElement('p');
            p.innerHTML = `${i} ${secondWord}`;
            result.appendChild(p);
        } else if (i % 5 === 0) {
            let p = document.createElement('p');
            p.innerHTML = `${i} ${thirdWord}`;
            result.appendChild(p);
        } else {
            let p = document.createElement('p');
            p.innerHTML = i;
            result.appendChild(p);
        }
    }

    for (let i = startNum; i <= endNum; i++) {
        checkCurrentNumber(i);
    }
}