class Kitchen {
    constructor(budget) {
        this.budget = budget;
        this.menu = {};
        this.productsInStock = {};
        this.actionsHistory = [];
    }

    loadProducts(products) {
        products.map(p => {
            let productInfo = p.split(/\s+/);
            let productName = productInfo[0];
            let productQuantity = Number(productInfo[1]);
            let productPrice = Number(productInfo[2]);

            if (this.budget >= productPrice) {
                this.budget -= productPrice;

                if (!this.productsInStock.hasOwnProperty(productName)) {
                    this.productsInStock[productName] = 0;
                }

                this.productsInStock[productName] += productQuantity;

                this.actionsHistory.push(`Successfully loaded ${productQuantity} ${productName}`);
            } else {
                this.actionsHistory.push(`There was not enough money to load ${productQuantity} ${productName}`);
            }
        });

        return this.actionsHistory.join("\n");
    }

    addToMenu(meal, neededProducts, price) {
        if (this.menu.hasOwnProperty(meal)) {
            return `The ${meal} is already in our menu, try something different.`;
        }
        price = +price;
        this.menu[meal] = {
            meal,
            products: neededProducts,
            price
        };
        return `Great idea! Now with the ${meal} we have ${Object.keys(this.menu).length} meals in the menu, other ideas?`;
    }

    showTheMenu() {
        let meals = Object.keys(this.menu);
        if (meals.length === 0) {
            return "Our menu is not ready yet, please come later...";
        }
        return meals.map(meal => `${meal} - $ ${this.menu[meal].price}`).join("\n") + "\n";
    }

    makeTheOrder(meal) {
        if (!this.menu.hasOwnProperty(meal)) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        let neededProducts = this.menu[meal].products;

        for (const product of neededProducts) {
            let [productName, productQuantity] = product.split(/\s+/);
            let quantityNeeded = Number(productQuantity);

            if (!this.productsInStock.hasOwnProperty(productName) || this.productsInStock[productName] < quantityNeeded) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
        }

        neededProducts.forEach((product) => {
            let [productName, productQuantity] = product.split(/\s+/);
            this.productsInStock[productName] -= Number(productQuantity);
        });

        let price = this.menu[meal].price;
        this.budget += price;
        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${price}.`;

    }
}