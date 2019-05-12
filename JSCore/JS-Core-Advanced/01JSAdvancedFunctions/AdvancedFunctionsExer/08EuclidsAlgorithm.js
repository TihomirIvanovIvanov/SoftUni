function euclidsAlgorithm(a, b) {
    if (b === 0) {
        return a;
    }

    return euclidsAlgorithm(b, a % b);
}

console.log(euclidsAlgorithm(252, 105));