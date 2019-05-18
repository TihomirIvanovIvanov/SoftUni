function circleArea(input) {
    let typeOfInput = typeof (input);
    let result = 0;

    if (typeOfInput === "number") {
        result = Math.pow(input, 2) * Math.PI;
        console.log(result.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${typeOfInput}.`);
    }
}