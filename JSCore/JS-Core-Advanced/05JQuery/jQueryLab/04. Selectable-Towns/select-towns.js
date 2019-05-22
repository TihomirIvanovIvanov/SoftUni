function attachEvents() {
    $("#items li").on("click", function () {
        if ($(this).attr("data-selected")) {
            $(this).removeAttr("data-selected");
            $(this).css("background", '');
        } else {
            $(this).attr("data-selected", true);
            $(this).css("background", "#ddd");
        }
    });

    $("#showTownsButton").on("click", function () {
        $("#selectedTowns")
            .text($("#items li[data-selected]").toArray()
                .map(li => li.textContent)
                .join(", "));
    });
}