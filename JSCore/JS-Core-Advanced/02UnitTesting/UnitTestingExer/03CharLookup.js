function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

let expect = require("chai").expect;

describe('lookupChar', function () {
    const incorrectIndex = "Incorrect index";

    it('should return undefined with numbers', function () {
        let str = 1;
        let index = 1;

        expect(lookupChar(str, index)).is.undefined;
    });

    it('should return undefined with string', function () {
        let str = "test";
        let index = "test";

        expect(lookupChar(str, index)).is.undefined;
    });

    it('should return undefined with string and floating point number', function () {
        let str = "test";
        let index = 1.1;

        expect(lookupChar(str, index)).is.undefined;
    });

    it('should return undefined with number and string', function () {
        let str = 1;
        let index = "test";

        expect(lookupChar(str, index)).is.undefined;
    });

    it('should return incorrect index with negative index', function () {
        let str = "test";
        let index = -1;

        expect(lookupChar(str, index)).is.equal(incorrectIndex);
    });

    it('should return incorrect index which is more than the string', function () {
        let str = "test";
        let index = 4;

        expect(lookupChar(str, index)).is.equal(incorrectIndex);
    });

    it('should return index at zero position', function () {
        let str = "test";
        let index = 0;

        expect(lookupChar(str, index)).to.equal('t');
    });

    it('should return index at first position', function () {
        let str = "test";
        let index = 1;

        expect(lookupChar(str, index)).to.equal('e');
    });
});