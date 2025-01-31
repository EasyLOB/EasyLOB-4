/*

JavaScript
    function zAlert(message, modal = true)
    function zConfirm(message)
    function zCompareValues(key, order = "asc")
    function zConsole(message)
    function zContains(array, value)
    function zDateAddDay(date, n)
    function zDateAddMonth(date, n)
    function zDateAddYear(date, n)
    function zEnter2Tab()
    function zFormat(string, args)
    function zGUID()
    function zIsBoolean(value)
    function zIsDate(value)
    function zIsNumber(value)
    function zIsNumberFloat(value)
    function zIsNumberInteger(value)
    function zISODate(value)
    function zIsString(value)
    function zIsValue(value)
    function zOne(value)
    function zParseFloat(value)
    function zParseInt(value)
    function zParseJSON(json)
    function zReadOnly(parentId, readOnly = true)
    function zReplaceAll(string, find, replace)
    function zRound(value, exp)
    function zSleepMS(milliseconds)
    function zSleepS(seconds)
    function zZero(value)
AJAX
    function zAjaxError(jqXHR)
    function zAjaxFailure(jqXHR, textStatus, errorThrown)
    function zAjaxLoadAsync(id, ajaxUrl)
    function zAjaxLoadSync(id, ajaxUrl)
    function zAjaxLoadComplete(responseText, textStatus, jqXHR, id)
    function zAjaxSuccess(data, textStatus, jqXHR)
EDM
    function zEDMCssClass(fileAcronym)
Errors & Exceptions
    function zExceptionMessage(fileName, functionName, exception)
    function zShowOperationResult(operationResult)
Local Storage
    function zLocalStorageClear()
    function zLocalStorageGet(item)
    function zLocalStorageRemove(item)
    function zLocalStorageSet(item, data)
Session Storage
    function zSessionStorageClear()
    function zSessionStorageGet(item)
    function zSessionStorageRemove(item)
    function zSessionStorageSet(item, data)

*/

//// JavaScript

/*
if (!value)
    null
    undefined
    NaN
    ""
    0
    false
*/

function zAlert(message, modal = true) {
    if (message) {
        message = "<h4>" + message + "</h4>";
    }

    $("#ZAlert").html(message);

    if (message) {
        $("#ZAlert").ejDialog({
            height: 270,
            maxHeight: 540,
            minHeight: 270,
            width: 960,
            maxWidth: 1140,
            minWidth: 540
        });
        $("#ZAlert").ejDialog("open");
        $("#ZAlert").ejDialog({ enableModal: modal })
    }
}

function zConfirm(message) {
    return confirm(message);
}

// items.sort(compareValues("property"));
// items.sort(compareValues("property", "desc"));
function zCompareValues(key, order = "asc") {
    return function (a, b) {
        if (!a.hasOwnProperty(key) || !b.hasOwnProperty(key)) {
            return 0;
        }

        const varA = (typeof a[key] === "string") ? a[key].toUpperCase() : a[key];
        const varB = (typeof b[key] === "string") ? b[key].toUpperCase() : b[key];

        let comparison = 0;
        if (varA > varB) {
            comparison = 1;
        } else if (varA < varB) {
            comparison = -1;
        }

        return ((order == "desc") ? (comparison * -1) : comparison);
    };
}

function zConsole(message) {
    //console.error(message);
    console.info(message);
    //console.log(message);
    //console.warn(message);
}

function zContains(array, value) {
    return array.indexOf(value) >= 0;
}

function zDateAddDay(date, n) {
    return new Date(date.setDay(date.getMonth() + n));
}

function zDateAddMonth(date, n) {
    return new Date(date.setMonth(date.getMonth() + n));
}

function zDateAddYear(date, n) {
    return new Date(date.setYear(date.getMonth() + n));
}

function zEnter2Tab() {
    $("input").keydown(function (e) {
        var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
        if (key === 13) {
            e.preventDefault();
            var inputs = $(this).closest("form").find(":input:visible");
            inputs.eq(inputs.index(this) + 1).focus();
        }
    });
}

function zFormat(string, args) {
    // format("{0} or {1}", ["Black", "White"])); 
    $.each(args, function (i, n) {
        string = string.replace(new RegExp("\\{" + i + "\\}", "g"), n);
    });

    return string;
}

function zGUID() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

function zIsBoolean(value) {
    return typeof value == "boolean";
}

function zIsDate(value) {
    return value && Object.prototype.toString.call(value) === "[object Date]" && !isNaN(value);
}

function zISODate(value) {
    return value ? new Date(value) : value;
}

function zIsNumber(value) {
    return value && (typeof value) == "number";
}

function zIsNumberFloat(value) {
    return value  && (typeof value) == "number" && Math.round(value) != value;
}

function zIsNumberInteger(value) {
    return value  && (typeof value) == "number" && Math.round(value) == value;
}

function zIsString(value) {
    return value != null && typeof value == "string";
}

function zIsValue(value) {
    /*
        null
        undefined
        NaN
        ""
        0
        false
    */
    var result = false;

    if (value) {
        result = true;
    }

    return result;
}

function zOne(value) {
    return !value || value < 1 ? 1 : value;
}

function zParseFloat(value) {
    var result;

    try {
        var result = parseFloat(value);
        if (result != 0) {
            if (!result || !(typeof result === "number")) {
                result = null;
            }
        }
    }
    catch (exception) {
        result = null;
    }

    return result;
}

function zParseInt(value) {
    var result;

    try {
        var result = parseInt(value);
        if (result != 0) {
            if (!result || !(typeof result === "number")) {
                result = null;
            }
        }
    }
    catch (exception) {
        result = null;
    }

    return result;
}

function zParseJSON(json) {
    var result;

    try {
        var result = JSON.parse(json);
        if (!result || !(typeof result === "object")) {
            result = null;
        }
    }
    catch (exception) {
        result = null;
    }

    return result;
}

function zReadOnly(parentId, readOnly = true) {
    var parentId = "#" + parentId;
    $(parentId + " input.form-control").not(":input[type=button], :input[type=image], :input[type=reset], :input[type=submit]").prop("readonly", readOnly);
    // ReadOnly.js
    // https://github.com/haggen/readonly
    $(parentId + " select").readonly(readOnly);
    //readonly(parentId + " select", readOnly);
    $(parentId + " textarea").prop("readonly", readOnly);
    $(parentId + " input[name*='_Lookup'][type!='checkbox']").prop("readonly", true);
    if (readOnly) {
        $(parentId + " input[type='checkbox']").prop("disabled", true);

        $(parentId + " input[data-role='ejdatepicker']").each(function () {
            $(this).data("ejDatePicker").option("readOnly", true);
        });
        $(parentId + " input[data-role='ejdatetimepicker']").each(function () {
            $(this).data("ejDateTimePicker").option("readOnly", true);
        });

        $(parentId + " img.z-buttonLookup").hide();
    }
    else {
        $(parentId + " img.z-buttonLookup").show();
    }
}

function zReplaceAll(string, find, replace) {
    return string.replace(new RegExp(find, 'g'), replace);
}

function zRound(value, exp) {

    // Formatting a number with exactly two decimals in JavaScript
    // https://stackoverflow.com/questions/1726630/formatting-a-number-with-exactly-two-decimals-in-javascript
    // round(1.275, 2); // 1.28
    // round(1.27499, 2); // 1.27
    // round(1234.5678, -2); // 1200
    // round(1.2345678e+2, 2); // 123.46
    // round("123.45"); // 123

    if (typeof exp === 'undefined' || +exp === 0) {
        return Math.round(value);
    }

    value = +value;
    exp = +exp;

    if (isNaN(value) || !(typeof exp === 'number' && exp % 1 === 0)) {
        return NaN;
    }

    // Shift
    value = value.toString().split('e');
    value = Math.round(+(value[0] + 'e' + (value[1] ? (+value[1] + exp) : exp)));

    // Shift Back
    value = value.toString().split('e');
    return +(value[0] + 'e' + (value[1] ? (+value[1] - exp) : -exp));
}

function zSleepMS(milliseconds) {
    var dateTime = new Date().getTime();
    while ((new Date().getTime() - dateTime) < milliseconds);
}

function zSleepS(seconds) {
    seconds = (+new Date) + seconds * 1000;
    while ((+new Date) < seconds);
}

function zZero(value) {
    return !value ? 0 : value;
}

//// AJAX

// jqXHR = jQuery XMLHttpRequest

/*
done data
{
    "Response":
    {
        "Preco":0
    }
}

done jqXHR
{
    "readyState":4,
    "responseText":
    {
        "Response":
        {
            "Preco":0
        }
    },
    "responseJSON":
    {
        "Response":
        {
            "Preco":0
        }
    },
    "status":200,
    "statusText":"OK"
}

fail jqXHR
{
    "readyState":4,
    "responseText":
    {
        "OperationResult":
        {
            "Data":null,"ErrorCode":"","ErrorMessage":"","Html":"\\u003clabel class=\\"label label-danger\\"\\u003eErro: ERRO\\u003c/label\\u003e\\u003cbr /\\u003e","Ok":false,"StatusCode":"","StatusMessage":"","OperationErrors":[{"ErrorCode":"","ErrorMessage":"Siegmar I. J. Gieseler","ErrorMembers":[]}],"Text":"Erro: Siegmar I. J. Gieseler\\n"}}","responseJSON":{"OperationResult":{"Data":null,"ErrorCode":"","ErrorMessage":"","Html":"Erro: Siegmar I. J. Gieseler","Ok":false,"StatusCode":"","StatusMessage":"","OperationErrors":[{"ErrorCode":"","ErrorMessage":"ERRO","ErrorMembers":[]}],"Text":"Erro: ERRO\n"
        }
    },
    "status":400,
    "statusText":"Bad Request"
}
*/

function zAjaxError(jqXHR) {
    var error = "";

    if (jqXHR) {
        if (jqXHR.responseJSON) {
            if (jqXHR.responseJSON.OperationResult) {
                error = jqXHR.responseJSON.OperationResult.Html;
            } else {
                error = jqXHR.responseJSON;
            }
        } else if (jqXHR.responseText) {
            var response = zParseJSON(jqXHR.responseText);
            if (response && response.OperationResult) {
                error = response.OperationResult.Html;
            } else {
                error = jqXHR.responseText;
            }
        } else {
            error = JSON.stringify(jqXHR);
        }
    }

    return error;
}

function zAjaxFailure(jqXHR, textStatus, errorThrown) {
    try {
        if (jqXHR && jqXHR.responseJSON && jqXHR.responseJSON.Url) {
            window.location.replace(jqXHR.responseJSON.Url);
        }

        zAlert(zAjaxError(jqXHR));
    } catch (exception) {
        zExceptionMessage("", "zAjaxFailure", exception.message);
    }
}

function zAjaxLoadAsync(id, ajaxUrl) {
    $("#" + id).load(ajaxUrl, function (responseText, textStatus, jqXHR) {
        zAjaxLoadComplete(responseText, textStatus, jqXHR, id);
    });
}

function zAjaxLoadSync(id, ajaxUrl) {
    try {
        jQuery.ajaxSetup({ async: false });
        $("#" + id).load(ajaxUrl, function (responseText, textStatus, jqXHR) {
            zAjaxLoadComplete(responseText, textStatus, jqXHR, id);
        });
    } finally {
        jQuery.ajaxSetup({ async: true });
    }
}

function zAjaxLoadComplete(responseText, textStatus, jqXHR, id) {
    try {
        if (jqXHR) { // @Ajax.ZImageLink
            var response = zParseJSON(jqXHR.responseText);
            if (response && response.Url) {
                window.location.replace(response.Url);
            }
        }

        if (textStatus === "error") {
            zAlert(zAjaxError(jqXHR));
        } else {
            if (!id) {
                id = "ZAjax";
            }
            ej.widget.init($("#" + id));
        }
    } catch (exception) {
        zExceptionMessage("", "zAjaxLoadComplete", exception.message);
    }
}

function zAjaxSuccess(data, textStatus, jqXHR) {
    try {
        if (data) {
            if (data.OperationResult) {
                zShowOperationResult(data.OperationResult);
            }

            var url = data.Url;
            if (!url) {
                var controller = data.Controller;
                if (controller) {
                    url = zUrlDictionaryRead(controller);
                }
            }
            if (url) {
                $("#ZAjax").load(url, function (responseText, textStatus, jqXHR) {
                    zAjaxLoadComplete(responseText, textStatus, jqXHR);
                });
            }
        }
    } catch (exception) {
        zExceptionMessage("", "zAjaxSuccess", exception.message);
    }
}

//// EDM

function zEDMCssClass(fileAcronym) {
    var cssClass = "";

    switch (fileAcronym) {
        case "mp3":
            cssClass = "z-fileAudio";
            break;
        case "xls":
        case "xlsx":
            cssClass = "z-fileExcel";
            break;
        case "jpg":
        case "png":
            cssClass = "z-fileImage";
            break;
        case "msg":
            cssClass = "z-fileMail";
            break;
        case "pdf":
            cssClass = "z-filePDF";
            break;
        case "txt":
            cssClass = "z-fileTXT";
            break;
        case "avi":
        case "mov":
        case "mp4":
        case "mpeg":
        case "wmv":
            cssClass = "z-fileVideo";
            break;
        case "doc":
        case "docx":
            cssClass = "z-fileWord";
            break;
        default:
            cssClass = "z-fileUnknown";
            break;
    }

    return cssClass;
}

//// Errors & Exceptions

function zExceptionMessage(fileName, functionName, exception) {
    fileName = fileName ? fileName : "";
    functionName = functionName ? functionName : "";
    var message = exception && exception.message ? exception.message : "";
    var stack = exception && exception.stack ? exception.stack : "";

    return "<b>File:</b> " + fileName +
        "<br/><b>Function:</b> " + functionName+
        "<br/><b>Exception:</b> " + message +
        "<br/><button data-toggle='collapse' data-target='#zStack'>...</button>" +
        "<div id='zStack' class='collapse'>" + zReplaceAll(stack, "  at ", "<br/>at ") + "</div>";
}

function zShowOperationResult(operationResult) {
    if (operationResult.Html) {
        zAlert(operationResult.Html);
    }
}

//// Local Storage - Persistent

function zLocalStorageClear() {
    window.localStorage.clear();
}

function zLocalStorageGet(item) {
    return window.localStorage.getItem(item);
}

function zLocalStorageRemove(item) {
    return window.localStorage.removeItem(item);
}

function zLocalStorageSet(item, data) {
    window.localStorage.setItem(item, data);
}

//// Session Storage - Non-Persistent per TAB

function zSessionStorageClear() {
    window.sessionStorage.clear();
}

function zSessionStorageGet(item) {
    return window.sessionStorage.getItem(item);
}

function zSessionStorageRemove(item) {
    window.sessionStorage.removeItem(item);
}

function zSessionStorageSet(item, data) {
    window.sessionStorage.setItem(item, data);
}
