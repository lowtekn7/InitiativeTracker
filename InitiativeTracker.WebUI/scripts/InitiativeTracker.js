var model = {
        characters: ko.observableArray(),
        editor: {
            name: ko.observable(""),
            group: ko.observable("")
        },
        displaySummary: ko.observable(true),
        displayEncounter: ko.observable(false)
    };

function sendAjaxRequest(httpMethod, callback, url, reqData) {
    $.ajax("/api/web" + (url ? "/" + url : ""), {
        type: httpMethod, success: callback, data: reqData
    });
}

function getAllItems() {
    sendAjaxRequest("GET", function (data) {
        model.characters.removeAll();
        for (var i = 0; i < data.length; i++) {
            model.characters.push(data[i]);
        }
    });
}

function removeItem(item) {
    sendAjaxRequest("DELETE", function () {
        for (var i = 0; i < model.characters().length; i++) {
            if (model.characters()[i].CharacterID == item.CharacterID) {
                console.log(model.characters()[i], item);
                model.characters.remove(model.characters()[i]);
                break;
            }
        }
    }, item.CharacterID);
}

function Create() {
    model.displaySummary(false);
}

function updateCharacter(item) {
    model.editor.characterID = item.CharacterID;
    model.editor.name = item.Name;
    model.editor.group = item.Group;
    model.displaySummary(false);
}

function saveNewCharacter() {
    console.log("Saving character...",model.editor);
    sendAjaxRequest("POST", function (newItem) {
        getAllItems();
        model.displaySummary(true);
    }, null, {
        CharacterID: model.editor.characterID,
        Name: model.editor.name,
        Initiative: 10,
        Group: model.editor.group
    });
}

function cancelNewCharacter() {
    model.editor.characterID = "";
    model.editor.name = "";
    model.editor.group = "";
    model.displaySummary(true);
}

function addToEncounter() {
    console.log("yo");
}

$(document).ready(function () {
    getAllItems();
    ko.applyBindings(model);
});