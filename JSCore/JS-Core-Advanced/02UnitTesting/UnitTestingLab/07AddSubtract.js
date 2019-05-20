function createCalculator() {
    let value = 0;
    return {
        add: function(num) { value += Number(num); },
        subtract: function(num) { value -= Number(num); },
        get: function() { return value; }
    }
}

let expect = require("chai").expect;

describe('createCalculator', function () {
    let calculator;
    beforeEach(function () {
        calculator = createCalculator();
    });

    it('should return sum of zero', function () {
        expect(calculator.get()).to.equal(0);
    });

    it('should return sum two', function () {
        calculator.add(1);
        calculator.add(1);

        expect(calculator.get()).to.equal(2);
    });

    it('should return subtract of negative', function () {
        calculator.subtract(10);

        expect(calculator.get()).to.equal(-10);
    });

    it('should return subtract of positive', function () {
        calculator.add(15);
        calculator.subtract(10);

        expect(calculator.get()).to.equal(5);
    });

    it('should return subtract of positive of few numbers', function () {
        calculator.add(15);
        calculator.subtract(10);
        calculator.add(5);
        calculator.subtract(5);

        expect(calculator.get()).to.equal(5);
    });

    it('should return subtract of negative of few numbers', function () {
        calculator.add(15);
        calculator.subtract("10");
        calculator.add("-5");
        calculator.subtract(5);

        expect(calculator.get()).to.equal(-5);
    });

    it('should return NaN if add string', function () {
        calculator.add("test");
        expect(calculator.get()).is.NaN;
    });

    it('should return NaN if subtract string', function () {
        calculator.subtract("test");
        expect(calculator.get()).is.NaN;
    });
});