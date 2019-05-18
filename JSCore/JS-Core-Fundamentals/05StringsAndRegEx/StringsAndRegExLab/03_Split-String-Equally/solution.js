function solve() {
    let str = document.getElementById("str").value;
    let number = parseInt(document.getElementById("num").value);

    let arr = [];
    let indexCounter = 0;

    if (str.length % number !== 0) {
        let len = str.length;
        let symbolCount = 0;

        while (len % number !== 0) {
            len %= number;
            len++;
            symbolCount++;
        }
        for (let i = 0; i < symbolCount; i++) {
            str += str[indexCounter];
            indexCounter++;
        }
    }

    for (let i = 0; i < str.length; i += number) {
        arr.push(str.substr(i, number));
    }
    document.getElementById("result").innerHTML = arr.join(' ');
}