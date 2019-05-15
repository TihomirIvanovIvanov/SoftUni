function validate() {
    let weightPosition = [2, 4, 8, 5, 10, 9, 7, 3, 6];
    let responseSpan = document.getElementById("response");

    let checkBtn = document.querySelector("button");
    checkBtn.addEventListener("click", function () {
        let numbers = document.querySelector("input").value.toString();
        let validationCounter = 0;
        let sum = 0;

        function sumWeight() {
            let numArr = numbers.split('');
            for (let i = 0; i < numArr.length; i++) {
                if (+numbers[i] < 0 || +numbers[i] > 9) {
                    validationCounter++;
                }
                if (i + 1 === 10) {
                    break;
                } else {
                    sum += (+numbers[i] * +weightPosition[i]);
                }
            }
        }

        sumWeight();

        let reminder = sum % 11;
        if (reminder % 10 === 0) {
            reminder = 0;
        }
        if (+reminder === +numbers[9] && validationCounter === 0) {
            responseSpan.innerHTML = "This number is Valid!";
        } else {
            responseSpan.innerHTML = "This number is NOT Valid!";
        }
    })
}