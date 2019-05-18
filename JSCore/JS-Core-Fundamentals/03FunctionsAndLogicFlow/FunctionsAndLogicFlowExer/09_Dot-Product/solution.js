function solve() {
    let firstMatrix = JSON.parse(document.getElementById("mat1").value);
    let secondMatrix = JSON.parse(document.getElementById("mat2").value);
    let resultEl = document.getElementById("result");

    let result = multiplyMatrices(firstMatrix, transpose(secondMatrix));

    for (let i = 0; i < result.length; i++) {
        let p = document.createElement('p');
        resultEl.appendChild(p);
        p.innerHTML = result[i].join(", ");
    }

    function multiplyMatrices(m1, m2) {
        var result = [];
        for (var i = 0; i < m1.length; i++) {
            result[i] = [];
            for (var j = 0; j < m2[0].length; j++) {
                var sum = 0;
                for (var k = 0; k < m1[0].length; k++) {
                    sum += m1[i][k] * m2[k][j];
                }
                result[i][j] = sum;
            }
        }
        return result;
    }

    function transpose(matrix) {
        return matrix[0].map((col, i) => matrix.map(row => row[i]));
    }
}