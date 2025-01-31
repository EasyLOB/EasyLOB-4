/*

SearchDictionary - Local Storage
    function zSearchDictionaryClear()
    function zSearchDictionaryRead(controller)
    function zSearchDictionaryWrite(controller, value)
    function zSearchDictionaryGet()
    function zSearchDictionarySet(dictionary)
TabDictionary - Session Storage
    function zTabDictionaryClear()
    function zTabDictionaryRead(controller)
    function zTabDictionaryWrite(controller, value)
    function zTabDictionaryGet()
    function zTabDictionarySet(dictionary)
UrlDictionary - Session Storage
    function zUrlDictionaryClear()
    function zUrlDictionaryHtml()
    function zUrlDictionaryRead(controller)
    function zUrlDictionaryText()
    function zUrlDictionaryWrite(controller, value)
    function zUrlDictionaryGet()
    function zUrlDictionarySet(dictionary)

*/

//// SearchDictionary

function zSearchDictionaryClear() {
    zLocalStorageRemove("SearchDictionary");
}

function zSearchDictionaryRead(controller) {
    var dictionary = zSearchDictionaryGet();

    var result = "";
    var dictionaryLength = dictionary.length;
    for (var i = 0; i < dictionaryLength; i++) {
        var controllerDictionary = dictionary[i];
        if (controllerDictionary[0].toLowerCase() === controller.toLowerCase()) {
            result = controllerDictionary[1];
            if (!result) {
                result = "";
            }
            break;
        }
    }

    return result;
}

function zSearchDictionaryWrite(controller, value) {
    if (!value) {
        zSearchDictionaryClear();
    } else {
        var dictionary = zSearchDictionaryGet();

        var ok = false;
        var dictionaryLength = dictionary.length;
        for (var i = 0; i < dictionaryLength; i++) {
            var controllerDictionary = dictionary[i];
            if (controllerDictionary[0].toLowerCase() === controller.toLowerCase()) {
                dictionary[i][1] = value;
                ok = true;
                break;
            }
        }

        if (!ok) {
            var dictionaryItem = [controller, value];
            dictionary.push(dictionaryItem);
        }

        zSearchDictionarySet(dictionary);
    }
}

function zSearchDictionaryGet() {
    var json = zLocalStorageGet("SearchDictionary");
    if (!json) {
        json = "[]";
    }

    var dictionary = JSON.parse(json);
    if (!dictionary) {
        dictionary = [];
        zSearchDictionarySet(dictionary);
    }

    return dictionary;
}

function zSearchDictionarySet(dictionary) {
    zLocalStorageSet("SearchDictionary", JSON.stringify(dictionary));
}

//// TabDictionary

function zTabDictionaryClear() {
    zSessionStorageRemove("TabDictionary");
}

function zTabDictionaryRead(controller) {
    var dictionary = zTabDictionaryGet();

    var result = "";
    var dictionaryLength = dictionary.length;
    for (var i = 0; i < dictionaryLength; i++) {
        var controllerUrl = dictionary[i];
        if (controllerUrl[0].toLowerCase() === controller.toLowerCase()) {
            result = controllerUrl[1];
            if (!result) {
                result = "";
            }
            break;
        }
    }

    return result;
}

function zTabDictionaryWrite(controller, value) {
    var dictionary = zTabDictionaryGet();

    var ok = false;
    var dictionaryLength = dictionary.length;
    for (var i = 0; i < dictionaryLength; i++) {
        var controllerDictionary = dictionary[i];
        if (controllerDictionary[0].toLowerCase() === controller.toLowerCase()) {
            dictionary[i][1] = value;
            ok = true;
            break;
        }
    }

    if (!ok) {
        var dictionaryItem = [controller, value];
        dictionary.push(dictionaryItem);
    }

    zTabDictionarySet(dictionary);
}

function zTabDictionaryGet() {
    var json = zSessionStorageGet("TabDictionary");
    if (!json) {
        json = "[]";
    }

    var dictionary = JSON.parse(json);
    if (!dictionary) {
        dictionary = [];
        zTabDictionarySet(dictionary);
    }

    return dictionary;
}

function zTabDictionarySet(dictionary) {
    zSessionStorageSet("TabDictionary", JSON.stringify(dictionary));
}

//// UrlDictionary

function zUrlDictionaryClear() {
    zSessionStorageRemove("UrlDictionary");
}

function zUrlDictionaryHtml() {
    var dictionary = zUrlDictionaryGet();

    var result = "";
    var dictionaryLength = dictionary.length;
    for (var i = 0; i < dictionaryLength; i++) {
        var controllerUrl = dictionary[i];
        result += "<b>[ " + controllerUrl[0] + " ]</b> " + controllerUrl[1] + "<br />";
    }

    return result;
}

function zUrlDictionaryRead(controller) {
    var dictionary = zUrlDictionaryGet();

    var result = "";
    var dictionaryLength = dictionary.length;
    for (var i = 0; i < dictionaryLength; i++) {
        var controllerUrl = dictionary[i];
        if (controllerUrl[0].toLowerCase() === controller.toLowerCase()) {
            result = controllerUrl[1];
            if (!result) {
                result = "";
            }
            break;
        }
    }

    return result;
}

function zUrlDictionaryText() {
    var dictionary = zUrlDictionaryGet();

    var result = "";
    var dictionaryLength = dictionary.length;
    for (var i = 0; i < dictionaryLength; i++) {
        var controllerUrl = dictionary[i];
        result += "[ " + controllerUrl[0] + " ] " + controllerUrl[1] + "\n";
    }

    return result;
}

function zUrlDictionaryWrite(controller, value) {
    var dictionary = zUrlDictionaryGet();

    var ok = false;
    var dictionaryLength = dictionary.length;
    for (var i = 0; i < dictionaryLength; i++) {
        var controllerDictionary = dictionary[i];
        if (controllerDictionary[0].toLowerCase() === controller.toLowerCase()) {
            dictionary[i][1] = value;
            ok = true;
            break;
        }
    }

    if (!ok) {
        var dictionaryItem = [controller, value];
        dictionary.push(dictionaryItem);
    }

    zUrlDictionarySet(dictionary);
}

function zUrlDictionaryGet() {
    var json = zSessionStorageGet("UrlDictionary");
    if (!json) {
        json = "[]";
    }

    var dictionary = JSON.parse(json);
    if (!dictionary) {
        dictionary = [];
        zUrlDictionarySet(dictionary);
    }

    return dictionary;
}

function zUrlDictionarySet(dictionary) {
    zSessionStorageSet("UrlDictionary", JSON.stringify(dictionary));
}
