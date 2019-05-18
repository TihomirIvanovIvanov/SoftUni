function solve() {
    let arr = JSON.parse(document.querySelector("#arr").value);
    let result = document.querySelector("#result");

    for (let i = 0; i < arr.length; i++) {
        arr[i] = arr[i].split('').reverse().join('');
        arr[i] = arr[i].charAt(0).toUpperCase().concat(arr[i].slice(1));
    }

    result.textContent = arr.join(' ');
}