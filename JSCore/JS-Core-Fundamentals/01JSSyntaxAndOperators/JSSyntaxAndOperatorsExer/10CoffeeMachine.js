function coffeeMachine(input) {
    let totalSum = 0;

    for (let value of input) {
        let token = value.split(", ");
        let coins = token[0];
        let drink = token[1];

        let price = 0;

        if (drink === "coffee") {
            let coffeeType = token[2];

            if (coffeeType === "caffeine") {
                price = 0.8;
            } else {
                price = 0.9;
            }

            if (token[3] === "milk"){
                let milkPrice = +(parseFloat(price * 0.1).toFixed(1));
                price += milkPrice;

                if (token[4] > 0) {
                    price += 0.1;
                }
            } else if (token[3] > 0) {
                price += 0.1;
            }
        } else {
            price = 0.8;

            if (token[2] === "milk") {
                let milkPrice = +(parseFloat(price * 0.1).toFixed(1));
                price += milkPrice;

                if (token[3] > 0){
                    price += 0.1;
                }
            } else if (token[2] > 0){
                price += 0.1;
            }
        }

        let change = coins - price;
        let moneyNeeded = price - coins;

        if (coins >= price){
            console.log(`You ordered ${drink}. Price: ${price.toFixed(2)}$ Change: ${change.toFixed(2)}$`);
            totalSum += price;
        } else  {
            console.log(`Not enough money for ${drink}. Need ${moneyNeeded.toFixed(2)}$ more.`);
        }
    }

    console.log(`Income Report: ${totalSum.toFixed(2)}$`);
}

coffeeMachine(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2', '1.00, coffee, decaf, 0']);