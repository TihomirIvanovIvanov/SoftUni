function addItem() {
    let itemList = $("#items");
    let inputFields = $("input");

    let textInput = inputFields[0];
    let listItem = $("<li>");

    listItem.text(textInput.value);
    itemList.append(listItem);

    $("#newItemText").val('');
}