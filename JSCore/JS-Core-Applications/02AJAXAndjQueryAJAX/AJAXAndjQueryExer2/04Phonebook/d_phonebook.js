const BASE_URL = 'https://phonebook-266f7.firebaseio.com/phonebook'
const TABLE = $('#phonebook')
const PERSON = $('#person')
const PHONE = $('#phone')

$('#btnLoad').on('click', loadContacts)
$('#btnCreate').on('click', createContact)

function loadContacts() {
    $.ajax({
        method: "GET",
        url: BASE_URL + '.json'
    }).then(appendContacts)
        .catch(handleError)
}

function appendContacts(contacts) {
    TABLE.empty()
    let keys = Object.keys(contacts)
    keys.sort((a, b) => contacts[a].name.localeCompare(contacts[b].name))
    for (const id of keys) {
        let li = $('<li>')
        li.text(`${contacts[id].name}: ${contacts[id].phone}`)
        let a = $('<button> Delete</button>')
        a.on('click', function () {
            $.ajax({
                method: "DELETE",
                url: BASE_URL + "/" + id + ".json"
            }).then(function () {
                li.remove()
            }).catch(handleError)
        })
        li.append(a)
        TABLE.append(li)
    }
}

function createContact() {
    let name = PERSON.val()
    let phone = PHONE.val()
    if (name.trim() !== '' && phone.trim() !== '') {
        $.ajax({
            method: "POST",
            url: BASE_URL + '.json',
            data: JSON.stringify({name, phone})
        }).then(function () {
            PERSON.val("")
            PHONE.val("")
        }).catch(handleError)
    }
}

function handleError(err) {
    console.log(err)
}

function attachEvents() {
    $("#btnLoad").click(loadContacts);
    $("#btnCreate").click(createContact);

    let baseUrl = "https://phonebook-nakov.firebaseio.com/phonebook";
    let phoneBook = $("#phonebook");

    function loadContacts() {
        phoneBook.empty();
        $.get(baseUrl + ".json")
            .then(displayContacts)
            .catch(displayError);
    }

    function displayContacts(contacts) {
        for (let key in contacts) {
            let person = contacts[key]["person"];
            let phone = contacts[key]["phone"];

            phoneBook
                .append($(`<li>${person + ": " + phone + ' '}</li>`)
                    .append($(`<button>Delete</button>`)
                        .click(function () {
                            deleteContact(key)
                        })));
        }
    }

    function displayError() {
        phoneBook.append($("<li>Error"));
    }

    function createContact() {
        let newContactJSON = JSON.stringify({
            person: $("#person").val(),
            phone: $("#phone").val()
        });

        $.post(baseUrl + ".json", newContactJSON)
            .then(loadContacts)
            .catch(displayError);

        $("#person").val('');
        $("#phone").val('');
    }

    function deleteContact(key) {
        let req = {
            method: "DELETE",
            url: baseUrl + '/' + key + ".json"
        };

        $.ajax(req)
            .then(loadContacts)
            .catch(displayError);
    }
}