(function () {
    function test() {
        let checkBtn = document.querySelector("button");
        checkBtn.addEventListener("click", function () {
            let input = document.querySelector("input");
            let targetH = document.querySelector("#year h2");
            let targetDiv = document.querySelector("#year div");

            function isLeap(year) {
                if (+year % 4 === 0 && +year % 100 !== 0) {
                    return true;
                }
                if (+year % 4 === 0 && +year % 100 === 0 && +year % 400 === 0) {
                    return true;
                }
                return false;
            }

            let year = +input.value;
            if (isLeap(year)) {
                targetH.innerHTML = "Leap Year";
                targetDiv.innerHTML = input.value;
            } else {
                targetH.innerHTML = "Not Leap Year";
                targetDiv.innerHTML = input.value;
            }
            input.value = '';
        })
    }

    return function () {
        test()
    }
})();