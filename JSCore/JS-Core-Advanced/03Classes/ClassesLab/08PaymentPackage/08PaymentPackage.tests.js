const PaymentPackage = require("./solution");
const assert = require("chai").assert;

describe("paymentPackage", function () {
    let paymentPackage;
    beforeEach(function () {
        paymentPackage = new PaymentPackage("test", 20);
    });

    describe("properties", function () {
        it("should have toString method", function () {
            assert.isTrue(PaymentPackage.prototype.hasOwnProperty("toString"));
        });

        it("should have name property", function () {
            assert.isTrue(PaymentPackage.prototype.hasOwnProperty("name"));
        });

        it("should have value property", function () {
            assert.isTrue(PaymentPackage.prototype.hasOwnProperty("value"));
        });

        it("should have VAT property", function () {
            assert.isTrue(PaymentPackage.prototype.hasOwnProperty("VAT"));
        });

        it("should have active property", function () {
            assert.isTrue(PaymentPackage.prototype.hasOwnProperty("active"));
        });
    });

    describe("constructor", function () {
        it("should be initialized with 2 params", function () {
            assert.equal(paymentPackage.name, "test");
            assert.equal(paymentPackage.value, 20);
            assert.equal(paymentPackage.VAT, 20);
            assert.isTrue(paymentPackage.active);
        });

        it("should throw error when initialized with no params", function () {
            assert.throws(() => new PaymentPackage(), Error);
        });

        it("should throw error when initialized with 1 param", function () {
            assert.throws(() => new PaymentPackage("test"), Error);
        });
    });

    describe("name", function () {
        it("should throw error with number param", function () {
            assert.throws(() => new PaymentPackage(2, 2), Error);
        });

        it("should throw error with empty string param", function () {
            assert.throws(() => new PaymentPackage("", 2), Error);
        });

        it("should get \"test\"", function () {
            assert.equal(paymentPackage.name, "test");
        });

        it("should get \"newTest\" after set", function () {
            paymentPackage.name = "newTest";
            assert.equal(paymentPackage.name, "newTest");
        });
    });

    describe("value", function () {
        it("should throw error with string param", function () {
            assert.throws(() => new PaymentPackage("test", "test"), Error);
        });

        it("should throw error with negative number param", function () {
            assert.throws(() => new PaymentPackage("test", -2), Error);
        });

        it("should get 20", function () {
            assert.equal(paymentPackage.value, 20);
        });

        it("should get 50 after set", function () {
            paymentPackage.value = 50;
            assert.equal(paymentPackage.value, 50);
        });

        it("should work with 0 as param", function () {
            paymentPackage = new PaymentPackage("test", 0);
            assert.equal(paymentPackage.value, 0);
        });
    });

    describe("VAT", function () {
        it("should throw error with string param", function () {
            assert.throws(() => paymentPackage.VAT = "test", Error);
        });

        it("should throw error with negative number param", function () {
            assert.throws(() => paymentPackage.VAT = -20, Error);
        });

        it("get should return 20", function () {
            assert.equal(paymentPackage.VAT, 20);
        });

        it("get should return 50 after set", function () {
            paymentPackage.VAT = 50;
            assert.equal(paymentPackage.VAT, 50);
        });
    });

    describe("active", function () {
        it("should throw error with string param", function () {
            assert.throws(() => paymentPackage.active = "test", Error);
        });

        it("should throw error with number param", function () {
            assert.throws(() => paymentPackage.active = 20, Error);
        });

        it("get should return true", function () {
            assert.isTrue(paymentPackage.active);
        });

        it("get should return false after set", function () {
            paymentPackage.active = false;
            assert.isFalse(paymentPackage.active);
        });
    });

    describe("toString", function () {
        describe("firstLine", function () {
            it("should be inactive with active false", function () {
                paymentPackage.active = false;
                let firstLine = paymentPackage.toString().split("\n")[0];
                assert.equal(firstLine, "Package: test (inactive)");
            });

            it("should not be inactive with active true", function () {
                let firstLine = paymentPackage.toString().split("\n")[0];
                assert.equal(firstLine, "Package: test");
            });
        });

        describe("secondLine", function () {
            it("should be correct string", function () {
                paymentPackage.active = false;
                let secondLine = paymentPackage.toString().split("\n")[1];
                assert.equal(secondLine, "- Value (excl. VAT): 20");
            });
        });

        describe("thirdLine", function () {
            it("should be correct string with default VAT", function () {
                let thirdLine = paymentPackage.toString().split("\n")[2];
                assert.equal(thirdLine, "- Value (VAT 20%): 24");
            });

            it("should be correct string with new VAT", function () {
                paymentPackage.VAT = 100;
                let thirdLine = paymentPackage.toString().split("\n")[2];
                assert.equal(thirdLine, "- Value (VAT 100%): 40");
            });
        });
    });
});