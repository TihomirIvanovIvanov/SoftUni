function loadRepos() {
    $("#repos").empty();
    let url = `https://api.github.com/users/${$("#username").val()}/repos`;

    $.ajax({
        method: "GET",
        url,
        success: displayRepos,
        error: displayError
    });

    function displayRepos(repos) {
        for (let repo of repos) {
            let link = $(`<a>${repo.full_name}</a>`);
            link.attr("href", repo.html_url);
            $("#repos")
                .append($("<li>")
                    .append(link));
        }
    }

    function displayError() {
        $("#repos").append($("<li>Error</li>"));
    }
}