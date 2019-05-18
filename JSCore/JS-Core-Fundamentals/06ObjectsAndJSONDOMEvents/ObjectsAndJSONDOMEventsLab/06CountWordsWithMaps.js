function solve([input]) {
    let words = input.toLowerCase().split(/\W+/).filter(e => e !== '');
    let map = new Map();

    for (let word of words) {
        if (!map.has(word)) {
            map.set(word, 1);
        } else {
            map.set(word, map.get(word) + 1);
        }
    }

    let sorted = Array.from(map.keys()).sort();
    for (let key of sorted) {
        console.log(`'${key}' -> ${map.get(key)} times`);
    }
}

solve(["Far too slow, you're far too slow."]);