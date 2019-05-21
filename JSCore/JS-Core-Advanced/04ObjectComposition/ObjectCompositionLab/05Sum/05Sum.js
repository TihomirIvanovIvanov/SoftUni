function sum() {
    let num1 = 0;
    let num2 = 0;
    let result = 0;

    function init(num1Sel, num2Sel, resultSel) {
        num1 = $(num1Sel);
        num2 = $(num2Sel);
        result = $(resultSel);
    }

    function add() {
        action((a, b) => a + b);
    }

    function subtract() {
        action((a, b) => a - b);
    }

    function action(operator) {
        let val1 = Number(num1.val());
        let val2 = Number(num2.val());
        result.val(operator(val1, val2));
    }

    return {
        init: init,
        add: add,
        subtract: subtract,
    };
}