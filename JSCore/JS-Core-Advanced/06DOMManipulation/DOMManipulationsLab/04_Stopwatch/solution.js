function stopwatch() {
    let time = 0;
    let intervalId;

    let startBtn = $("#startBtn");
    let stopBtn = $("#stopBtn");

    startBtn.on("click", function () {
        time = -1;
        incrementTime();
        intervalId = setInterval(incrementTime, 1000);
        startBtn.disabled = true;
        stopBtn.disabled = false;
    });

    stopBtn.on("click", function () {
        clearInterval(intervalId);
        startBtn.disabled = false;
        stopBtn.disabled = true;
    });

    function incrementTime() {
        time++;
        document.getElementById("time").textContent =
            ("0" + Math.trunc(time / 60)).slice(-2) + ':' +
            ("0" + (time % 60)).slice(-2);
    }
}