function solve() {
    let cardBtn = document.querySelector("button");
    cardBtn.addEventListener("click", function () {
        let validInput = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
        let cardSection = document.getElementById("cards");

        let from = document.getElementById("from").value;
        let to = document.getElementById("to").value;

        let suit = document.querySelector("select").value;
        suit = suit.substr(suit.length - 1, 1);

        function getPosition(from, to, fromPosition, toPosition) {
            for (let index in validInput) {
                if (from === validInput[index]) {
                    fromPosition = index;
                }
                if (to === validInput[index]) {
                    toPosition = index;
                }
            }

            let result = {};
            result.fromPosition = fromPosition;
            result.toPosition = toPosition;
            return result;
        }

        function appendResult(cardSection, validInput, fromPosition, toPosition) {
            for (let i = +fromPosition; i <= +toPosition; i++) {
                let div = document.createElement("div");
                div.classList.add("card");

                let upperP = document.createElement('p');
                upperP.textContent = suit;

                let middelP = document.createElement('p');
                middelP.textContent = validInput[i];

                let lowerP = document.createElement('p');
                lowerP.textContent = suit;

                div.appendChild(upperP);
                div.appendChild(middelP);
                div.appendChild(lowerP);

                cardSection.appendChild(div);
            }
        }

        if (validInput.filter((i) => {
                return validInput[i] === i;
            }) &&
            validInput.includes(to.toString())) {
            let fromPosition = 0;
            let toPosition = 0;

            let positions = getPosition(from, to, fromPosition, toPosition);

            fromPosition = positions.fromPosition;
            toPosition = positions.toPosition;

            appendResult(cardSection, validInput, fromPosition, toPosition);
        }
    });
}