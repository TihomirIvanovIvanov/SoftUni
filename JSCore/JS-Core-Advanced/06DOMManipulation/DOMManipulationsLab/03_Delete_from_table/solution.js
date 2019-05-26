function deleteByEmail() {
    let email = $("input").val();
    let trElements = $("#customers tr");
    let emails = [];

    for (let i = 1; i < trElements.length; i++) {
        let currentRow = trElements[i].children[1];
        if (currentRow.textContent === email) {
            emails.push(currentRow);
        }
    }

    for (let row of emails) {
        row.parentElement.remove();
    }

    if (emails.length !== 0) {
        $("#result").text("Deleted.");
    } else {
        $("#result").text("Not found.");
    }
}