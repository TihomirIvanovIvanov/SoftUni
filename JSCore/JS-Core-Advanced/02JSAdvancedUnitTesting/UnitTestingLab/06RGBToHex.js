function rgbToHexColor(red, green, blue) {
    if (!Number.isInteger(red) || (red < 0) || (red > 255))
        return undefined; // Red value is invalid
    if (!Number.isInteger(green) || (green < 0) || (green > 255))
        return undefined; // Green value is invalid
    if (!Number.isInteger(blue) || (blue < 0) || (blue > 255))
        return undefined; // Blue value is invalid
    return "#" +
        ("0" + red.toString(16).toUpperCase()).slice(-2) +
        ("0" + green.toString(16).toUpperCase()).slice(-2) +
        ("0" + blue.toString(16).toUpperCase()).slice(-2);
}

let expect = require("chai").expect;

describe('rgbToHexColor', function () {
    it('should return correct result', function () {
        let red = 250;
        let green = 250;
        let blue = 250;

        expect(rgbToHexColor(red, green, blue)).to.equal("#FAFAFA");
    });

    it('should return correct result', function () {
        let red = 255;
        let green = 255;
        let blue = 255;

        expect(rgbToHexColor(red, green, blue)).to.equal("#FFFFFF");
    });

    it('should return invalid red', function () {
        let red = "red";
        let green = 250;
        let blue = 250;

        expect(rgbToHexColor(red, green, blue)).to.equal(undefined);
    });

    it('should return invalid red', function () {
        let red = -250;
        let green = 250;
        let blue = 250;

        expect(rgbToHexColor(red, green, blue)).to.equal(undefined);
    });

    it('should return invalid red', function () {
        let red = 256;
        let green = 250;
        let blue = 250;

        expect(rgbToHexColor(red, green, blue)).to.equal(undefined);
    });

    it('should return invalid green', function () {
        let red = 250;
        let green = "green";
        let blue = 250;

        expect(rgbToHexColor(red, green, blue)).to.equal(undefined);
    });

    it('should return invalid green', function () {
        let red = 250;
        let green = -250;
        let blue = 250;

        expect(rgbToHexColor(red, green, blue)).to.equal(undefined);
    });

    it('should return invalid green', function () {
        let red = 250;
        let green = 256;
        let blue = 250;

        expect(rgbToHexColor(red, green, blue)).to.equal(undefined);
    });

    it('should return invalid blue', function () {
        let red = 250;
        let green = 250;
        let blue = "blue";

        expect(rgbToHexColor(red, green, blue)).to.equal(undefined);
    });

    it('should return invalid blue', function () {
        let red = 250;
        let green = 250;
        let blue = -250;

        expect(rgbToHexColor(red, green, blue)).to.equal(undefined);
    });

    it('should return invalid blue', function () {
        let red = 250;
        let green = 250;
        let blue = 256;

        expect(rgbToHexColor(red, green, blue)).to.equal(undefined);
    });

    it('should return correct result', function () {
        let red = 0;
        let green = 0;
        let blue = 0;

        expect(rgbToHexColor(red, green, blue)).to.equal("#000000");
    });
});