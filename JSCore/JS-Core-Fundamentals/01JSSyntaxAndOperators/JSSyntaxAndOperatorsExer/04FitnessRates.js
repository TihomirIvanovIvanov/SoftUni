function fitnessRates(day, service, hour) {
    let dayOfWeek = (day) => ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'].indexOf(day);

    let services = {
        "Fitness": (day, hour) => day <= 4 ? (hour <= 15 ? 5 : 7.5) : 8,
        "Sauna": (day, hour) => day <= 4 ? (hour <= 15 ? 4 : 6.5) : 10,
        "Instructor": (day, hour) => day <= 4 ? (hour <= 15 ? 10 : 12.5) : 15
    };

    return services[service](dayOfWeek(day), hour);
}

console.log(fitnessRates('Sunday', 'Fitness', 22.00));