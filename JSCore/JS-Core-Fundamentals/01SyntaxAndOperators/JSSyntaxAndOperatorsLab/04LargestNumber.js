function largestNumber(firstNum, secondNum, thirdNum) {
    let result = Math.max(Math.max(+firstNum, +secondNum), +thirdNum);
    console.log(`The largest number is ${result}.`);
}