function solve() {
    let str = document.getElementById("string").value;
    let char = document.getElementById("character").value;

    let count = 0;
    let result = '';

    function findCharCount(str, char) {
        for (let i = 0; i < str.length; i++) {
            if (str[i] === char) {
                count++;
            }
        }
    }

    function evenOrOddCount(str, char) {
        if (count % 2 === 0) {
            result = `Count of ${char} is even.`;
        } else {
            result = `Count of ${char} is odd.`;
        }
    }

    findCharCount(str, char);
    evenOrOddCount(str, char);
    document.getElementById("result").innerHTML = result;
}