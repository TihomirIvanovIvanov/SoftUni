function BMI() {
    let [name, age, weight, height] = arguments;

    let heightInMeters = height / 100;
    let bmi = weight / Math.pow(heightInMeters, 2);
    let status = '';

    if (bmi < 18.5) {
        status = "underweight";
    } else if (bmi < 25) {
        status = "normal";
    } else if (bmi < 30) {
        status = "overweight";
    } else {
        status = "obese";
    }

    let personInfo = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        },
        BMI: Math.round(bmi),
        status: status
    };

    if (status === "obese") {
        personInfo.recommendation = "admission required";
    }

    return personInfo;
}

console.log(BMI("Peter", 29, 75, 182));
console.log();
console.log(BMI("Honey Boo Boo", 9, 57, 137));