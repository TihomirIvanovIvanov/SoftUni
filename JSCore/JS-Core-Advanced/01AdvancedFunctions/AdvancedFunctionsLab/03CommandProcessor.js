function commandProcessor(arr) {
    let closure = (function () {
        let str = '';

        return {
            append: (s) => str += s,
            removeStart: (n) => str = str.substring(n),
            removeEnd: (n) => str = str.substring(0, str.length - n),
            print: () => console.log(str)
        }
    })();

    for (let arrElement of arr) {
        let [comm, value] = arrElement.split(' ');
        closure[comm](value);
    }
}

commandProcessor(['append hello',
    'append again',
    'removeStart 3',
    'removeEnd 4',
    'print']
);

commandProcessor(['append 123',
    'append 45',
    'removeStart 2',
    'removeEnd 1',
    'print']
)