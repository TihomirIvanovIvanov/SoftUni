let result = (function () {
    let Suits = {
        SPADES: '\u2660',
        HEARTS: '\u2665',
        DIAMONDS: '\u2666',
        CLUBS: '\u2663'
    };
    let Faces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        get face() {
            return this._face;
        }

        set face(value) {
            if (Faces.indexOf(value) < 0) {
                throw new Error("Invalid face.");
            }
            this._face = value;
        }

        get suit() {
            return this._suit;
        }

        set suit(value) {
            let suitsValues = Object.keys(Suits).map(suit => Suits[suit]);

            if (suitsValues.indexOf(value) < 0) {
                throw new Error("Invalid suit.");
            }

            this._suit = value;
        }
    }

    return {
        Suits: Suits,
        Card: Card
    }
})();

let Card = result.Card;
let Suits = result.Suits;

let card = new Card("Q", Suits.CLUBS);
card.face = "A";
card.suit = Suits.DIAMONDS;
let card2 = new Card("1", Suits.DIAMONDS); // Should throw exception.