$(function () {
    $("#btnLoad").click(loadContacts);
    $("#btnCreate").click(createContact);

    let baseServiceUrl = 'https://phonebook-tihomir.firebaseio.com/phonebook';

    function loadContacts() {
        $("#phonebook").empty();
        $.get(baseServiceUrl + ".json")
            .then(displayContacts)
            .catch(displayError);
    }

    function displayError(err) {
        $("#phonebook").append($(`<li>Error</li>`));
    }

    function displayContacts(contacts) {
        for (let key in contacts) {
            let person = contacts[key]["person"];
            let phone = contacts[key]["phone"];

            let li = $("<li>");
            li.text(person + ": " + phone + ' ');

            $("#phonebook").append(li);
            li.append($("<button>Delete</button>")
                .click(deleteContact.bind(this, key)));
        }
    }

    function createContact() {
        let newContactJSON = JSON.stringify({
            person: $("#person").val(),
            phone: $("#phone").val()
        });

        $.post(baseServiceUrl + ".json", newContactJSON)
            .then(loadContacts)
            .catch(displayError);

        $("#person").val('');
        $("#phone").val('');
    }

    function deleteContact(key) {
        let req = {
            method: "DELETE",
            url: baseServiceUrl + '/' + key + ".json"
        };

        $.ajax(req)
            .then(loadContacts)
            .catch(displayError);
    }
});