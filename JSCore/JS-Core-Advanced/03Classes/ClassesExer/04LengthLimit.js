class Stringer {
    constructor(innerString, innerLength) {
        this.innerString = innerString;
        this.innerLength = innerLength;
    }

    increase(length) {
        this.innerLength += length;
        this._validateLength();
    }

    decrease(length) {
        this.innerLength -= length;
        this._validateLength();
    }

    toString() {
        if (this.innerLength === 0) {
            return "...";
        }

        if (this.innerString.length > this.innerLength) {
            this.innerString = this.innerString.substr(0, this.innerLength) + "...";
        }

        return this.innerString;
    }

    _validateLength() {
        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); //Test

test.decrease(3);
console.log(test.toString()); //Te...

test.decrease(5);
console.log(test.toString()); //...

test.increase(4);
console.log(test.toString()); //Test