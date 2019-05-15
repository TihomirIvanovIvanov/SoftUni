function getNext() {
    let num = document.getElementById("num").value;
    let result = document.getElementById("result");

    let sequance = [num];

    let tempNum = +num;
    while (tempNum !== 1) {
        if (tempNum % 2 === 0) {
            tempNum = +tempNum / 2;
        } else {
            tempNum = +tempNum * 3 + 1;
        }
        sequance.push(tempNum);
    }

    result.textContent = sequance.join(' ') + ' ';
}