function GCD(firstNum, secondNum) {
    if (!secondNum) {
        return firstNum;
    }
    return GCD(secondNum, firstNum % secondNum);
}