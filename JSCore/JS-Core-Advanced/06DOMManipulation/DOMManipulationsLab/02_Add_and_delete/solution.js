function addItem() {
    let text = $("#newText").val();
    let items = $("#items");

    items.append($(`<li>${text} <a href="#">[Delete]</a></li>`));

    let deleteBtn = $("a").on("click", (e) => {
        e.target.parentNode.remove();
    });

    $("#newText").val('');
}