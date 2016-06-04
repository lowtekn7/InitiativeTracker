var model = {
        characters: ko.observableArray(),
        editor: {
            name: ko.observable(""),
            initiative_bonus: ko.observable("")
        },
        displaySummary: ko.observable(true),
        displayEncounter: ko.observable(false),
        encounter: {
            characters: ko.observableArray()
        },
        availableGroups: ko.observableArray(),
        selectedGroup: ko.observable()
    };

var database = (function () {
    function sendAjaxRequest(httpMethod, callback, url, reqData) {
        $.ajax("/api" + (url ? "/" + url : ""), {
            type: httpMethod, success: callback, data: reqData
        });
    };

    return {
        getAllCharacters: function () {
            sendAjaxRequest("GET", function (data) {
                model.characters.removeAll();
                for (var i = 0; i < data.length; i++) {
                    data[i].group = (model.availableGroups().find(x => x.Group_ID === data[i].Group_ID)).Name;
                    console.log((model.availableGroups().find(x => x.Group_ID === data[i].Group_ID)).Name);
                    model.characters.push(data[i]);
                }
            }, "Character");
        },
        removeItem: function (item) {
            sendAjaxRequest("DELETE", function () {
                removeFromArray(model.characters, item);
            }, "Character/Delete/" + item.CharacterID);
        },
        saveCharacter: function () {
            sendAjaxRequest("POST", function (newItem) {
                database.getAllCharacters();
                resetEditor();
            }, "Character", {
                CharacterID: model.editor.characterID,
                Name: model.editor.name,
                Initiative_Bonus: model.editor.initiative_bonus,
                Group_ID: model.selectedGroup().Group_ID
            });
        },
        setupCharacters: function () {
            sendAjaxRequest("GET", function (data) {
                model.availableGroups.removeAll();
                for (var i = 0; i < data.length; i++) {
                    model.availableGroups.push(data[i]);
                };
                database.getAllCharacters();
            }, "Group")
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
    model.editor.initiative_bonus = item.Initiative_Bonus;
    model.selectedGroup(model.availableGroups().find(x => x.Group_ID === item.Group_ID));
    model.displaySummary(false);
}

function resetEditor() {
    model.editor.characterID = "";
    model.editor.name = "";
    model.editor.initiative_bonus = "";
    model.displaySummary(true);
}


$(document).ready(function () {
    database.setupCharacters();
    ko.applyBindings(model);
});