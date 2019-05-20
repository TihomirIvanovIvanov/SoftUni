const StringBuilder = require("./solution");
const assert = require("chai").assert;
const expect = require("chai").expect;

describe("StringBuilder", function () {
    let sb;
    beforeEach(function () {
        sb = new StringBuilder();
    });

    describe("methods", function () {
        it("should have append method", function () {
            assert.isTrue(StringBuilder.prototype.hasOwnProperty("append"), "StringBuilder does not have append method!");
        });
        it("should have prepend method", function () {
            assert.isTrue(StringBuilder.prototype.hasOwnProperty("prepend"), "StringBuilder does not have prepend method!");
        });
        it("should have insertAt method", function () {
            assert.isTrue(StringBuilder.prototype.hasOwnProperty("insertAt"), "StringBuilder does not have insertAt method!");
        });
        it("should have remove method", function () {
            assert.isTrue(StringBuilder.prototype.hasOwnProperty("remove"), "StringBuilder does not have remove method!");
        });
        it("should have toString method", function () {
            assert.isTrue(StringBuilder.prototype.hasOwnProperty("toString"), "StringBuilder does not have toString method!");
        });
    });

    describe("constructor", function () {
        it("should be initialized with no params", function () {
            assert.equal(sb.toString(), "", "Expected empty string!");
        });

        it("should be initialized with params", function () {
            sb = new StringBuilder("test");

            assert.equal(sb.toString(), "test", "ToString did not return \"test\"!");
        });
    });

    describe("append", function () {
        it("should throw error with number param", function () {
            let num = 1;
            assert.throws(() => sb.append(num), Error);
        });

        it("should append string when initialized with no params", function () {
            sb.append("test");

            assert.equal(sb.toString(), "test", "Append did not work when initialized with no params!");
        });

        it("should append string when initialized with params", function () {
            sb = new StringBuilder("foo");
            sb.append("test");

            assert.equal(sb.toString(), "footest", "Append did not work when initialized with params!");
        });
    });

    describe("prepend", function () {
        it("should throw error with number param", function () {
            let num = 1;
            assert.throws(() => sb.prepend(num), Error);
        });

        it("should prepend string when initialized with no params", function () {
            sb.prepend("test");

            assert.equal(sb.toString(), "test", "Prepend did not work when initialized with no params!");
        });

        it("should prepend string when initialized with params", function () {
            sb = new StringBuilder("foo");
            sb.prepend("test");

            assert.equal(sb.toString(), "testfoo", "Prepend did not work when initialized with params!");
        });
    });

    describe("prepend", function () {
        it("should throw error with number param", function () {
            let num = 1;
            assert.throws(() => sb.prepend(num), Error);
        });

        it("should prepend string when initialized with no params", function () {
            sb.prepend("test");

            assert.equal(sb.toString(), "test", "Prepend did not work when initialized with no params!");
        });

        it("should prepend string when initialized with params", function () {
            sb = new StringBuilder("foo");
            sb.prepend("test");

            assert.equal(sb.toString(), "testfoo", "Prepend did not work when initialized with params!");
        });
    });

    describe("insertAt", function () {
        it("should throw error with number param", function () {
            let num = 1;
            assert.throws(() => sb.insertAt(num, 0), Error);
        });

        it("should insert string when initialized with no params", function () {
            sb.insertAt("test", 0);

            assert.equal(sb.toString(), "test", "InsertAt did not work when initialized with no params!");
        });

        it("should insert string to begining", function () {
            sb = new StringBuilder("foo");
            sb.insertAt("test", 0);

            assert.equal(sb.toString(), "testfoo", "InsertAt did not insert to begining!");
        });

        it("should insert string to end", function () {
            sb = new StringBuilder("foo");
            sb.insertAt("test", 3);

            assert.equal(sb.toString(), "footest", "InsertAt did not insert to end!");
        });

        it("should insert string to middle", function () {
            sb = new StringBuilder("test");
            sb.insertAt("foo", 2);

            assert.equal(sb.toString(), "tefoost", "InsertAt did not insert to middle!");
        });

        it('insert new test', function () {
            sb = new StringBuilder("test");
            sb.insertAt("str", 0);
            let expected = Array.from("test");
            expected.splice(0, 0, ..."str");
            compareArray(sb._stringArray, expected);
        });
    });

    describe("remove", function () {
        it("should remove from start", function () {
            sb = new StringBuilder("test");
            sb.remove(0, 2);
            assert.equal(sb.toString(), "st", "Remove did not remove from start!");
        });

        it("should remove from end", function () {
            sb = new StringBuilder("test");
            sb.remove(2, 2);
            assert.equal(sb.toString(), "te", "Remove did not remove from end!");
        });
    });

    describe("toString", function () {
        it("should return correct string", function () {
            sb = new StringBuilder("test");
            assert.equal(sb.toString(), "test", "ToString did not return correct string!");
        });
    });

    function compareArray(source, expected) {
        expect(source.length).to.equal(expected.length, "Arrays don't match");
        for (let i = 0; i < source.length; i++) {
            expect(source[i]).to.equal(expected[i], "Element " + i + " mismatch");
        }
    }
});