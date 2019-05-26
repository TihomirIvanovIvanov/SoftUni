function addItem() {
    let text = $("#newItemText").val();
    let value = $("#newItemValue").val();

    let option = $(`<option value='${value}'>${text}</option>`);
    $("#menu").append(option);

    $("#newItemText").val('');
    $("#newItemValue").val('');
}