function cars(commands) {
    let map = new Map;
    let carManager = {
        create: function ([name, , parent]) {
            parent = parent ? map.get(parent) : null;
            let newObj = Object.create(parent);

            map.set(name, newObj);
            return newObj;
        },
        set: function ([name, key, value]) {
            let obj = map.get(name);
            obj[key] = value;
        },
        print: function ([name]) {
            let obj = map.get(name);
            let allProp = [];

            Object.keys(obj)
                .forEach(key => allProp.push(`${key}:${obj[key]}`));

            while (Object.getPrototypeOf(obj)) {
                Object.keys(Object.getPrototypeOf(obj))
                    .forEach(key => allProp.push(`${key}:${Object.getPrototypeOf(obj)[key]}`));

                obj = Object.getPrototypeOf(obj);
            }

            console.log(allProp.join(", "));
        }
    };

    for (let command of commands) {
        let tokens = command.split(' ');
        let action = tokens.shift();
        carManager[action](tokens);
    }
}

cars(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']
);