function solve(arr) {
    let step = +arr.pop();
    let resultArr = arr.reduce((acc, el, index) => {
        if (index % step === 0) {
            acc.push(el);
        }
        return acc;
    }, []);
    console.log(resultArr.join("\n"));
}

solve(['5',
    '20',
    '31',
    '4',
    '20',
    '2']
);