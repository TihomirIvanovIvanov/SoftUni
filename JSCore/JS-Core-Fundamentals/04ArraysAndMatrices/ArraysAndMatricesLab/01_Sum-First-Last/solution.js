function solve() {
    let listInput = JSON.parse(document.getElementById("arr").value);
    let divResult = document.getElementById("result");

    function calc(list) {
        for (let i = 0; i < list.length; i++) {
            let p = document.createElement('p');
            p.textContent = `${i} -> ${list[i] * list.length}`;
            divResult.appendChild(p);
        }
    }

    calc(listInput);
}