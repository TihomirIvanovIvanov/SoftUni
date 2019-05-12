function stringLength(firstArr, secondArr, thirdArr) {
    let firstArrLength = firstArr.length;
    let secondArrLength = secondArr.length;
    let thirdArrLength = thirdArr.length;

    let sumLength = firstArrLength + secondArrLength + thirdArrLength;
    let avgLength = Math.floor(sumLength / 3);

    console.log(sumLength);
    console.log(avgLength);
}