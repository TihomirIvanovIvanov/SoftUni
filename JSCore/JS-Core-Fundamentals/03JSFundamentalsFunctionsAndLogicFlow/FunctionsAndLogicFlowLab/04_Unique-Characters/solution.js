function solve() {
    let uniqChars = '';
    let str = document.getElementById("string").value;

    function isCharWhiteSpace(i) {
        if (str[i] === ' ') {
            uniqChars += str[i];
        }
    }

    function isCurrentCharUniq(i) {
        if (uniqChars.indexOf(str[i]) === -1) {
            uniqChars += str[i];
        }
    }
    
    function findUniqChars(str) {
        for (let i = 0; i < str.length; i++) {
            isCharWhiteSpace(i);
            isCurrentCharUniq(i);
        }
    }

    findUniqChars(str);
    document.getElementById("result").innerHTML = uniqChars;
}