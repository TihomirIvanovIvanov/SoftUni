function listProcessor(commands) {
    let commandProcessor = (function () {
        let list = [];

        return {
            add: str => list.push(str),
            remove: str => list = list.filter(el => el !== str),
            print: () => console.log(list)
        };
    })();

    for (let command of commands) {
        [commandName, args] = command.split(' ');
        commandProcessor[commandName](args);
    }
}

listProcessor(['add hello', 'add again', 'remove hello', 'add again', 'print']);
listProcessor(['add pesho', 'add gosho', 'add pesho', 'remove pesho','print']);