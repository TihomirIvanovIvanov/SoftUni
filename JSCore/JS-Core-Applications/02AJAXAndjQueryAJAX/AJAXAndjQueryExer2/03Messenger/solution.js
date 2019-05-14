function attachEvents() {
    let baseUrl = "https://messengers-2315c.firebaseio.com/messenger";

    function loadMsg() {
        $.ajax({
            method: "GET",
            url: baseUrl + ".json",
            success: displayMsg
        });
    }

    function displayMsg(msgs) {
        $("#messages").empty();
        let orderedMsgs = {};

        msgs = Object.keys(msgs)
            .sort((a, b) => a.timestamp - b.timestamp)
            .forEach(k => orderedMsgs[k] = msgs[k]);

        for (let msg of Object.keys(orderedMsgs)) {
            $("#messages")
                .append(`${orderedMsgs[msg]["author"]}: ${orderedMsgs[msg]["content"]}\n`);
        }
    }

    function createMsg() {
        let data = {
            author: $("#author").val(),
            content: $("#content").val(),
            timestamp: Date.now()
        };

        $.post(baseUrl + ".json", JSON.stringify(data))
            .then(loadMsg);
    }

    $("#submit").click(createMsg);
    $("#refresh").click(loadMsg);

    loadMsg();
}