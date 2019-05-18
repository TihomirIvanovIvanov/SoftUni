function solve() {
    let needle = parseInt(document.getElementById("num").value);
    let inputArr = document.getElementById("arr").value;
    let haystack = JSON.parse(inputArr);
    let result = [];

    haystack.forEach(e => {
        let hasValue = e.includes(needle);
        let index = e.indexOf(needle);

        result.push(`${hasValue} -> ${index}`);
    });

    document.getElementById("result").textContent = result.join(',');
}