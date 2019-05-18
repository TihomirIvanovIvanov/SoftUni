function solve() {
    let buttons = document.querySelectorAll("button");
    let myBtn = buttons[0];
    let peshosBtn = buttons[1];

    myBtn.addEventListener("click", () => {
        let chatDiv = document.createElement("div");
        let span = document.createElement("span");
        let p = document.createElement('p');

        chatDiv.appendChild(span);
        chatDiv.appendChild(p);
        span.textContent = "Me";

        chatDiv.style.textAlign = "left";
        p.textContent = document.getElementById("myChatBox").value;
        document.getElementById("myChatBox").value = '';
        document.getElementById("chatChronology").appendChild(chatDiv);
    });

    peshosBtn.addEventListener("click", () => {
        let chatDiv = document.createElement("div");
        let span = document.createElement("span");
        let p = document.createElement('p');

        chatDiv.appendChild(span);
        chatDiv.appendChild(p);
        span.textContent = "Pesho";

        chatDiv.style.textAlign = "right";
        p.textContent = document.getElementById("peshoChatBox").value;
        document.getElementById("peshoChatBox").value = '';
        document.getElementById("chatChronology").appendChild(chatDiv);
    });
}