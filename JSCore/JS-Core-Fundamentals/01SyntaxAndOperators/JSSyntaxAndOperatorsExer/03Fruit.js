function fruit(typeOfFruit, weightInGram, pricePerKG) {
    let kg = weightInGram / 1000;
    let moneyNeeded = pricePerKG * kg;

    console.log(`I need ${moneyNeeded.toFixed(2)} leva to buy ${kg.toFixed(2)} kilograms ${typeOfFruit}.`);
}