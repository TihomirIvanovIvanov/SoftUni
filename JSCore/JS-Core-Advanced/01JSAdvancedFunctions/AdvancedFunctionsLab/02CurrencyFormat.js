function currencyFormatter(value) {
    let result = value.bind(value, ',', '$', true);
    return result;
}


function currencyFormatter(separator = ',', symbol = '$', symbolFirst = true, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2, 2);

    if (symbolFirst) {
        return symbol + ' ' + result;
    }
    return result + ' ' + symbol;
}
