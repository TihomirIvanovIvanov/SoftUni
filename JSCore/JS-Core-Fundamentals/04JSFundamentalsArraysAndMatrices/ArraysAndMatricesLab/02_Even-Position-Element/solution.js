function solve() {
    let arr = JSON.parse(document.querySelector("#arr").value);
    let result = document.querySelector("#result");
    let newArr = [];

    for (let i = 0; i < arr.length; i++) {
        if (i % 2 === 0) {
            newArr.push(arr[i]);
        }
    }

    console.log(newArr.join(" x "));
    result.textContent = newArr.join(" x ");
}