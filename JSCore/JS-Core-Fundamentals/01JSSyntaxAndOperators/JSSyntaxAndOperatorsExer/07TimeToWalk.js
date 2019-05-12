function timeToWalk(numberOfSteps, footprintInMeters, speedInKmH) {
    let distance = (numberOfSteps * footprintInMeters) / 1000;
    let rest = Math.floor((distance * 1000) / 500);

    let timeInSeconds = Math.ceil((distance / speedInKmH) * 60 * 60) + (rest * 60);
    let hours = Math.floor(timeInSeconds / 3600);
    let min = Math.floor(timeInSeconds / 60);
    timeInSeconds -= min * 60;

    let result = ('0' + hours).slice(-2) + ':' + ('0' + min).slice(-2) + ':' + ('0' + timeInSeconds).slice(-2);
    return result;
}

console.log(timeToWalk(4000, 0.60, 5));