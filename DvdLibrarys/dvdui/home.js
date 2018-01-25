var url = "http://localhost:60719";

function fail(response) {
    console.log("FAILED!", response);
}

function getLastResult() {
    if (vue.searchCategory && vue.searchTerm) {
        search(vue.searchCategory, vue.searchTerm);
    } else {
        getAll();
    }
}



function getAll() {
    $.get("http://localhost:60719/dvds/")
        .done(function (response) {
            vue.dvds = response;
        }).fail(fail);
}

function post(dvd) {
    $.ajax({
        type: "POST",
        url: "http://localhost:60719/dvd",
        data: JSON.stringify(dvd),
        contentType: "application/json"
    }).done(function (response) {
        getLastResult();
    }).fail(fail);
}

function put(dvd) {
    $.ajax({
        type: "PUT",
        url:"http://localhost:60719/dvd/" + dvd.dvdId,
        data: JSON.stringify(dvd),
        contentType: "application/json"
    }).done(function (response) {
        getLastResult();
    }).fail(fail);
}


function findTitle(searchTitle, searchTerm) {
    $.get(url + "/dvds/" + searchTitle + "/" + searchTerm)
    .done(function (response) {
        vue.title = response;
    }).fail(fail);
}


function remove(dvd) {
    $.ajax({
        type: "DELETE",
        url: "http://localhost:60719/dvd/" + dvd.dvdId
    }).done(function (response) {
        getLastResult();
    }).fail(fail);
}

function search(searchCategory, searchTerm) {
    $.get("http://localhost:60719/dvds/" + searchCategory + "/" + searchTerm)
        .done(function (response) {
            vue.dvds = response;
        }).fail(fail);
}

function save() {

    var dvd = {
        "title": this.current.title,
        "releaseYear": this.current.releaseYear,        
        "directorName": this.current.directorName,
        "rating": this.current.rating,
        "notes": this.current.notes
    };

    this.errorMessage = validate(dvd);

    if (this.errorMessage) {
        return;
    }

    if (this.current.dvdId) {
        dvd.dvdId = this.current.dvdId;
        put(dvd);
    } else {
        post(dvd);
    }
    $("#modalForm").modal("hide");
}

function validate(dvd) {
    var message = "";
    if (!dvd.title) {
        message += "The DVD Title is required.<br />"
    }
    var regex = /^\d{4}$/;
    if (!regex.test(dvd.releaseYear)) {
        message += "Release Year must be a four digit number.<br />"
    }

    if (!dvd.directorName) {
        message += "The Director is required.<br />"
    }
    return message;
}

var vue = new Vue({
    el: "#content",
    data: {
        searchCategory: "",
        searchTerm: "",
        searchIsInvalid: false,
        errorMessage: "",
        modalTitle: "Create DVD",
        current: {},
        dvds: []
    },
    methods: {
        confirmDelete: function (dvd) {
            this.current = dvd;
        },
        executeDelete: function () {
            remove(this.current);
        },
        create: function () {
            this.modalTitle = "Create DVD";
            this.current = {
                rating: "G"
            };
            this.errorMessage = "";
        },
        edit: function (dvd) {
            this.modalTitle = "Edit: " + dvd.title;
            this.errorMessage = "";
            this.current = dvd;
        },
        save: save,
        search: function () {
            var valid = this.searchCategory && this.searchTerm;
            this.searchIsInvalid = !valid;
            if (valid) {
                search(this.searchCategory, this.searchTerm);
            } else {
                setTimeout(function () { vue.searchIsInvalid = false; }, 2000);
            }
        },
        clear: function () {
            this.searchCategory = "";
            this.searchTerm = "";
            getAll();
        }
    }
});

getAll();