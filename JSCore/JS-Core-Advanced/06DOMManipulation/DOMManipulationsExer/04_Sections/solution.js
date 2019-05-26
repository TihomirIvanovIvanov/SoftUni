function create(sentences) {
    for (let sentence of sentences) {
        let div = $(`<div>`)
        let p = $("<p>");

        p.text(sentence);
        p.css("display", "none");

        div.on("click", () => {
            p.css("display", "block");
        });

        div.append(p);
        $("#content").append(div);
    }
}