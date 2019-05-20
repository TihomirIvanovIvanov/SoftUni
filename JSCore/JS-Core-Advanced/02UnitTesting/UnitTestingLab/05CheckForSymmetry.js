function isSymmetric(arr) {
    if (!Array.isArray(arr))
        return false; // Non-arrays are non-symmetric
    let reversed = arr.slice(0).reverse(); // Clone and reverse
    let equal = (JSON.stringify(arr) == JSON.stringify(reversed));
    return equal;
}

let expect = require("chai").expect;

describe('isSymmetric', function () {
    it('should return is valid array', function () {
        let arr = "test";
        let result = isSymmetric(arr);
        expect(result).to.equal(false);
    });

    it('should return true symmetric with few numbers', function () {
        let arr = [1, 2, 2, 1];
        expect(isSymmetric(arr)).is.equal(true);
    });

    it('should return true symmetric with one number', function () {
        let arr = [1];
        expect(isSymmetric(arr)).is.equal(true);
    });

    it('should return true symmetric with three number', function () {
        let arr = [1, 2, 1];
        expect(isSymmetric(arr)).is.equal(true);
    });

    it('should return is not symmetric', function () {
        let arr = [1, 2, 5, 1];
        expect(isSymmetric(arr)).is.equal(false);
    });

    it('should return is symmetric with string', function () {
        let arr = ["bla", "bla"];
        expect(isSymmetric(arr)).is.equal(true);
    });
});