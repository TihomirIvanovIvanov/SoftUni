function solve(arr) {
    let delimeter = arr.pop();
    console.log(arr.join(delimeter));
}

solve(['One',
    'Two',
    'Three',
    'Four',
    'Five',
    '-']
);