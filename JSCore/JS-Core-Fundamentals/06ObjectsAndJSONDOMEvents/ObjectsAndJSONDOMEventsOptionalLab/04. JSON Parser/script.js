window.addEventListener("load", () => {
    let element = document.getElementById("button");
    element.onclick = extractInfo;
});

function extractInfo() {
    let inputObj = JSON.parse(document.getElementById("input").value);
    let command = document.getElementById("command").value.split(' ');
    let result = document.getElementById("result");

    if (command[0] === "value") {
        if (inputObj[command[2]]) {
            result.value = "Value: " + inputObj[command[2]];
        } else {
            result.value = "No such item";
        }
    } else if (command[0] === "typeof") {
        if (inputObj[command[1]]) {
            result.value = "Type: " + typeof (inputObj[command[1]]);
        } else {
            result.value = "No such item";
        }
    } else {
        result.value = "Invalid Command!";
    }
}