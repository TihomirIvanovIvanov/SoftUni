function sameNumbers(number) {
    number = number.toString();
    let result = true;

    let firstElement = number[0];
    let sum = +firstElement;

    for (let i = 1; i < number.length; i++) {
        if (number[i] !== firstElement) {
            result = false;
        }
        sum += +number[i];
    }

    console.log(result);
    console.log(sum);
}