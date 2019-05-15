function solve() {
    let num = +document.getElementById("num").value;
    let result = [];

    for (let i = 1; i <= num; i++) {
        if (num % i === 0) {
            result.push(i);
        }
    }

    let resultEl = document.getElementById("result");
    resultEl.innerHTML = result.join(' ');
}