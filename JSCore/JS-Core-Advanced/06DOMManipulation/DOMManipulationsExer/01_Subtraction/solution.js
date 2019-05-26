function subtract() {
    let firstNum = +$("#firstNumber").val();
    let secondNum = +$("#secondNumber").val();

    $("#result").text(firstNum - secondNum);
}