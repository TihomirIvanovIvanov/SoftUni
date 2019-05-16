function solve() {
    let arr = JSON.parse(document.getElementById("arr").value);
    let result = document.getElementById("result");

    let acdSortedArr = arr.sort((a, b) => a - b);
    let acdEl = document.createElement("div");
    acdEl.textContent = acdSortedArr.join(", ");
    result.appendChild(acdEl);

    let alphabeticSortedArr = arr.sort();
    let alphabeticEl = document.createElement("div");
    alphabeticEl.textContent = acdSortedArr.join(", ");
    result.appendChild(alphabeticEl);
}