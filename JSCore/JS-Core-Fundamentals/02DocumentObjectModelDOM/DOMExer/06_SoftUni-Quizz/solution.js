function solve() {
    let nextQBtn = document.getElementsByTagName("button");
    let sections = document.getElementsByTagName("section");

    let secondSection = sections[1];
    let thirdSection = sections[2];

    let firstQBtn = nextQBtn[0];
    firstQBtn.addEventListener("click", () => {
        secondSection.style.display = "block";
    });

    let secondQBtn = nextQBtn[1];
    secondQBtn.addEventListener("click", () => {
        thirdSection.style.display = "block";
    });

    let firstAnswer = 2013;
    let secondAnswer = "Pesho";
    let thirdAnswer = "Nakov";

    function calcCorrectAnswerCoun(correcAnswerCount) {
        let answers = [];
        let radios = document.querySelectorAll("input");

        Array.from(radios)
            .forEach(function (currentRadioBtn) {
                if (currentRadioBtn.checked === true) {
                    answers.push(currentRadioBtn.value);
                }
            });

        if (answers.includes(firstAnswer.toString())) {
            correcAnswerCount++;
        }
        if (answers.includes(secondAnswer.toString())) {
            correcAnswerCount++;
        }
        if (answers.includes(thirdAnswer.toString())) {
            correcAnswerCount++;
        }

        return correcAnswerCount;
    }

    let thirdQBtn = nextQBtn[2];
    if (thirdSection.style.display !== "none") {
        thirdQBtn.addEventListener("click", () => {
            let resultDiv = document.getElementById("result");
            let correctAnswersCount = 0;

            correctAnswersCount = calcCorrectAnswerCoun(correctAnswersCount);

            if (correctAnswersCount === 3) {
                resultDiv.textContent = "You are recognized as top SoftUni fan!";
            } else {
                resultDiv.textContent = `You have ${correctAnswersCount} right answers`;
            }
        });
    }
}