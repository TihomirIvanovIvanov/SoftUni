function solve(input) {
    let towns = [];
    let regex = /\s*\|\s*/;

    input.splice(1).forEach((line) => {
        let tokens = line.split(regex);
        let townObj = {Town: tokens[1], Latitude: Number(tokens[2]), Longitude: Number(tokens[3])};
        towns.push(townObj);
    });

    console.log(JSON.stringify(towns));
}

solve(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']);