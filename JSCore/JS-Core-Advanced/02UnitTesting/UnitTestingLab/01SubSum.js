function subSum(arr, start, end) {
    if (!Array.isArray(arr) || Array.from(arr).some((num) => isNaN(parseInt(num)))) {
        return NaN;
    } else if (parseInt(start) < 0 || isNaN(parseInt(start))) {
        start = 0;
    } else if (parseInt(start) < 0 || isNaN(parseInt(start)) || parseInt(start) > arr.length - 1) {
        end = arr.length - 1;
    }

    let tempArr = arr.splice(start, end + 1);

    return Array.from(tempArr).reduce((a, b) => a + b, 0);
}

console.log(subSum([10, 20, 30, 40, 50, 60], 3, 300));
console.log(subSum([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(subSum([10, 'twenty', 30, 40], 0, 2));
console.log(subSum([], 1, 2));
console.log(subSum('text', 0, 2));