function attachEventsListeners() {
    let days = $("#days");
    let hours = $("#hours");
    let minutes = $("#minutes");
    let seconds = $("#seconds");

    let buttons = $(":button");

    Array.from(buttons).forEach((btn) => {
        btn.addEventListener("click", function (e) {
            let target = e.target;
            let targetId = target.id;
            let targetValue = 0;

            if (targetId === "daysBtn") {
                targetValue = parseInt(days.val());

                hours.val(targetValue * 24);
                minutes.val(targetValue * 24 * 60);
                seconds.val(targetValue * 24 * 60 * 60);
            } else if (targetId === "hoursBtn") {
                targetValue = parseInt(hours.val());

                days.val(targetValue * (1 / 24));
                minutes.val(targetValue * 60);
                seconds.val(targetValue * 60 * 60);
            } else if (targetId === "minutesBtn") {
                targetValue = parseInt(minutes.val());

                days.val(targetValue * (1 / 24) * (1 / 60));
                hours.val(targetValue * (1 / 60));
                seconds.val(targetValue * 60);
            } else if (targetId === "secondsBtn") {
                targetValue = parseInt(seconds.val());

                days.val(targetValue * (1 / 24) * (1 / 60) * (1 / 60));
                hours.val(targetValue * (1 / 60) * (1 / 60));
                minutes.val(targetValue * (1 / 60));
            }
        });
    });
}