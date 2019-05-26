function focus() {
    let divs = document.querySelectorAll('div div');
    for (let div of divs) {
        div.addEventListener('focus', () => {
            div.classList.add('focused');
        });
        
        div.addEventListener('blur', () => {
            div.classList.remove('focused');
        });
    }
}