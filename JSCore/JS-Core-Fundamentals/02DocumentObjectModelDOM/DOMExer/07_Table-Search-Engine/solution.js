function solve() {
    let search = document.getElementById("searchField");
    let button = document.getElementById("searchBtn");
    let selected = document.getElementsByClassName("select");

    let rows = document.querySelectorAll("tbody td");

    button.addEventListener("click", () => {
        if (search.value.length > 0) {
            for (let i = 0; i < rows.length; i++) {
                if (rows[i].textContent.toLowerCase().includes(search.value.toLowerCase()) === true) {
                    rows[i].parentNode.className = "select";
                }
            }

            search.value = '';
        }
    });
}