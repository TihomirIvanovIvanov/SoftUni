function solve(input) {
    let set = new Set();

    for (let line of input) {
        let words = line.toLowerCase().split(/\W+/).filter(e => e !== '');
        for (let word of words) {
            set.add(word);
        }
    }

    console.log(Array.from(set.keys()).join(", "));
}

solve(["Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque quis hendrerit dui. \n" +
"Quisque fringilla est urna, vitae efficitur urna vestibulum fringilla. \n" +
"Vestibulum dolor diam, dignissim quis varius non, fermentum non felis. \n" +
"Vestibulum ultrices ex massa, sit amet faucibus nunc aliquam ut. \n" +
"Morbi in ipsum varius, pharetra diam vel, mattis arcu. \n" +
"Integer ac turpis commodo, varius nulla sed, elementum lectus. \n" +
"Vivamus turpis dui, malesuada ac turpis dapibus, congue egestas metus.\n"]);