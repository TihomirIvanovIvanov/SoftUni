let mathEnforcer = {
    addFive: function (num) {
        if (typeof (num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof (num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof (num1) !== 'number' || typeof (num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

let expect = require("chai").expect;

describe('mathEnforcer', function () {

    describe('addFive', function () {
        it('should return undefined for non-number', function () {
            expect(mathEnforcer.addFive("test")).is.undefined;
        });

        it('should return correct result with negative number', function () {
            expect(mathEnforcer.addFive(-5)).is.equal(0);
        });

        it('should return correct result with positive number', function () {
            expect(mathEnforcer.addFive(5)).is.equal(10);
        });

        it('should return correct result with floating-point number', function () {
            expect(mathEnforcer.addFive(5.5)).is.equal(10.5);
        });
    });

    describe('subtractTen', function () {
        it('should return undefined for non-number', function () {
            expect(mathEnforcer.subtractTen("test")).is.undefined;
        });

        it('should return correct result with negative number', function () {
            expect(mathEnforcer.subtractTen(-5)).is.equal(-15);
        });

        it('should return correct result with positive number', function () {
            expect(mathEnforcer.subtractTen(5)).is.equal(-5);
        });

        it('should return correct result with floating-point number', function () {
            expect(mathEnforcer.subtractTen(10.1)).to.be.closeTo(0.1, 0.1);
        });

        it('should return correct result with floating-point number', function () {
            expect(mathEnforcer.subtractTen(20.50)).to.be.closeTo(10.50, 0.1);
        });
    });

    describe('sum', function () {
        it('should return undefined for non-number of first num', function () {
            expect(mathEnforcer.sum("test", 2)).is.undefined;
        });

        it('should return undefined for non-number of second num', function () {
            expect(mathEnforcer.sum(2, "test")).is.undefined;
        });

        it('should return undefined for non-numbers', function () {
            expect(mathEnforcer.sum("test", "test")).is.undefined;
        });

        it('should return correct sum of two integers', function () {
            expect(mathEnforcer.sum(2, 2)).to.equal(4);
        });

        it('should return correct sum of two floating-point numbers', function () {
            expect(mathEnforcer.sum(2.2, 2.2)).to.equal(4.4);
        });

        it('should return correct sum of first floating-point and second integer number', function () {
            expect(mathEnforcer.sum(2.2, 2)).to.equal(4.2);
        });

        it('should return correct sum of first integer and second floating-point number', function () {
            expect(mathEnforcer.sum(2, 2.2)).to.equal(4.2);
        });

        it('should return zero', function () {
            expect(mathEnforcer.sum(2, -2)).to.equal(0);
        });

        it('should return negative value', function () {
            expect(mathEnforcer.sum(0, -2)).to.equal(-2);
        });
    });
});