function solve() {
    let buttons = document.querySelectorAll("button");
    let encode = buttons[0];
    let decode = buttons[1];

    encode.addEventListener("click", () => {
        let msg = document.querySelectorAll("textarea")[0].value;
        let newMsg = '';

        for (let i = 0; i < msg.length; i++) {
            let char = msg.charCodeAt(i) + 1;
            newMsg += String.fromCharCode(char);
        }

        document.querySelectorAll("textarea")[0].value = '';
        document.querySelectorAll("textarea")[1].value = newMsg;
    });

    decode.addEventListener("click", () => {
        let msg = document.querySelectorAll("textarea")[1].value;
        let newMsg = '';

        for (let i = 0; i < msg.length; i++) {
            let char = msg.charCodeAt(i) - 1;
            newMsg += String.fromCharCode(char);
        }

        document.querySelectorAll("textarea")[1].value = newMsg;
    });
}