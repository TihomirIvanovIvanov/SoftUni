function solve([input]) {
    let words = input.split(/\W+/).filter(e => e !== '');
    let obj = {};

    for (let word of words) {
        if (!obj.hasOwnProperty(word)) {
            obj[word] = 1;
        } else {
            obj[word]++;
        }
    }

    console.log(JSON.stringify(obj));
}

solve(["Far too slow, you're far too slow."]);