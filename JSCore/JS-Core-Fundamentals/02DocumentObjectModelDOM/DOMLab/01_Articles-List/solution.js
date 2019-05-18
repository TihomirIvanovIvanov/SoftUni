function solve() {
    let createTitleElement = document.getElementById("createTitle");
    let createContentElement = document.getElementById("createContent");

    let createTitleValue = createTitleElement.value;
    let createContentValue = createContentElement.value;

    if (createTitleValue !== '' && createContentValue !== '') {
        let titleElement = document.createElement("h3");
        titleElement.textContent = createTitleValue;

        let contentElement = document.createElement('p');
        contentElement.textContent = createContentValue;

        let aricleElement = document.createElement("article");
        aricleElement.appendChild(titleElement);
        aricleElement.appendChild(contentElement);

        let articlesElement = document.getElementById("articles");
        articlesElement.appendChild(aricleElement);

        createTitleElement.value = '';
        createContentElement.value = '';
    }
}