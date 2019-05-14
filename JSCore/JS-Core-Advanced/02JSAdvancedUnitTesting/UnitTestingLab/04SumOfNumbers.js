function sum(arr) {
    let sum = 0;
    for (num of arr)
        sum += Number(num);
    return sum;
}

const expect = require("chai").expect;

describe('sum', function () {
    it('should return sum with few numbers', function () {
        let arr = [4, 5, 6];
        let result = sum(arr);
        expect(result).to.equal(15);
    });

    it('should return sum with one number', function () {
        let arr = [1];
        let result = sum(arr);
        expect(result).to.equal(1);
    });

    it('should return zero with empty arr', function () {
        let arr = [];
        let result = sum(arr);
        expect(result).to.equal(0);
    });
});