function constructionCrew(workerObj) {
    if (workerObj.handsShaking) {
        workerObj.bloodAlcoholLevel += 0.1 * workerObj.weight * workerObj.experience;
        workerObj.handsShaking = false;
    }
    return workerObj;
}

console.log(constructionCrew({
    weight: 80,
    experience: 1,
    bloodAlcoholLevel: 0,
    handsShaking: true
}));
console.log();

console.log(constructionCrew({
    weight: 120,
    experience: 20,
    bloodAlcoholLevel: 200,
    handsShaking: true
}));
console.log();

console.log(constructionCrew({
    weight: 95,
    experience: 3,
    bloodAlcoholLevel: 0,
    handsShaking: false
}));