var model = {
        characters: ko.observableArray(),
        editor: {
            name: ko.observable(""),
            group: ko.observable("")
        },
        displaySummary: ko.observable(true),
        displayEncounter: ko.observable(false),
        encounter: {
            characters: ko.observableArray()
        }
    };

var database = (function () {
    function sendAjaxRequest(httpMethod, callback, url, reqData) {
        $.ajax("/api/web" + (url ? "/" + url : ""), {
            type: httpMethod, success: callback, data: reqData
        });
    };

    return {
        getAllItems: function () {
            sendAjaxRequest("GET", function (data) {
                model.characters.removeAll();
                for (var i = 0; i < data.length; i++) {
                    model.characters.push(data[i]);
                }
            });
        },
        removeItem: function (item) {
            sendAjaxRequest("DELETE", function () {
                removeFromArray(model.characters, item);
            }, item.CharacterID);
        },
        saveCharacter: function () {
            sendAjaxRequest("POST", function (newItem) {
                database.getAllItems();
                resetEditor();
            }, null, {
                CharacterID: model.editor.characterID,
                Name: model.editor.name,
                Initiative: 10,
                Group: model.editor.group
            });
        }
    };
})();

function removeFromArray(array, item) {
    for (var i = 0; i < array().length; i++) {
        if (array()[i].CharacterID == item.CharacterID) {
            array.remove(array()[i]);
            break;
        }
    }
}

var session = (function () {
    function sendAjaxRequest(httpMethod, callback, url, reqData) {
        $.ajax("/api/Encounter" + (url ? "/" + url : ""), {
            type: httpMethod, success: callback, data: reqData
        });
    };

    return {
        getAllItems: function () {
            sendAjaxRequest("GET", function (data) {
                model.encounter.characters.removeAll();
                for (var i = 0; i < data.length; i++) {
                    model.characters.push(data[i]);
                }
            });
        },
        removeItem: function (item) {
            sendAjaxRequest("DELETE", function () {
                removeFromArray(model.encounter.characters, item);
            }, item.CharacterID);
        },
        saveItem: function (item) {
            sendAjaxRequest("POST", function (newItem) {
                session.getAllItems();
            }, null, {
                CharacterID: item.characterID,
                Name: item.Name,
                Initiative: item.Initiative,
                Group: item.Group
            });
        }
    };
})();

function Create() {
    model.displaySummary(false);
}

function updateCharacter(item) {
    model.editor.characterID = item.CharacterID;
    model.editor.name = item.Name;
    model.editor.group = item.Group;
    model.displaySummary(false);
}

function resetEditor() {
    model.editor.characterID = "";
    model.editor.name = "";
    model.editor.group = "";
    model.displaySummary(true);
}


$(document).ready(function () {
    console.log(database);
    database.getAllItems();
    ko.applyBindings(model);
});