function solve(rows, cols) {
    let matrix = [];
    //fill the matrix with 0
    for (let row = 0; row < rows; row++) {
        matrix[row] = [];
        for (let col = 0; col < cols; col++) {
            matrix[row][col] = 0;
        }
    }

    let counter = 1;
    let currentRow = 0;
    let currentCol = 0;
    let dirrection = "right";

    for (let i = 0; i < rows * cols; i++) {
        matrix[currentRow][currentCol] = counter;
        counter++;

        if (dirrection === "right") {
            if (currentCol + 1 >= cols || matrix[currentRow][currentCol + 1] !== 0) {
                dirrection = "down";
                currentRow++;
            } else {
                currentCol++;
            }
        } else if (dirrection === "down") {
            if (currentRow + 1 >= rows || matrix[currentRow + 1][currentCol] !== 0) {
                dirrection = "left";
                currentCol--;
            } else {
                currentRow++;
            }
        } else if (dirrection === "left") {
            if (currentCol - 1 < 0 || matrix[currentRow][currentCol - 1] !== 0) {
                dirrection = "up";
                currentRow--;
            } else {
                currentCol--;
            }
        } else if (dirrection === "up") {
            if (currentRow - 1 < 0 || matrix[currentRow - 1][currentCol] !== 0) {
                dirrection = "right";
                currentCol++;
            } else {
                currentRow--;
            }
        }
    }

    for (let row of matrix) {
        console.log(row.join(' '));
    }
}

solve(5, 5);