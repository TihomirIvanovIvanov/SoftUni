function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

let expect = require("chai").expect;

describe('isOddOrEven', function () {
    it('should return undefined with number', function () {
        expect(isOddOrEven(13)).to.equal(undefined);
    });

    it('should return undefined with object', function () {
        expect(isOddOrEven({})).to.equal(undefined);
    });

    it('should return even', function () {
        expect(isOddOrEven("test")).to.equal("even");
    });

    it('should return odd', function () {
        expect(isOddOrEven("testt")).to.equal("odd");
    });

    it('should correctly with multiply checks with multiply variables', function () {
        expect(isOddOrEven("blabla")).to.equal("even");
        expect(isOddOrEven("blabla2")).to.equal("odd");
        expect(isOddOrEven("t")).to.equal("odd");
    });
});