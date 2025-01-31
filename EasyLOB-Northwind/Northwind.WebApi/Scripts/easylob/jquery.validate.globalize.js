// /Scripts/globalize/cultures/globalize.culture.pt-BR.js

// jQuery Globalize
// A monkey patch for jquery.validate.js that allows validation to be internationalised
// https://gist.github.com/johnnyreilly/3651751

(function ($, Globalize) {

    // Clone original methods we want to call into

    var originalMethods = {
        min: $.validator.methods.min,
        max: $.validator.methods.max,
        range: $.validator.methods.range
    };

    // Tell the validator that we want numbers parsed using Globalize

    $.validator.methods.number = function (value, element) {

        // !!!
        var parsedValue = value
            .replace(/[0-9]/g, "")
            .replace("-", "")
            .replace(Globalize.cultures[Globalize.cultureSelector].numberFormat["."], "")
            .trim();
        if (parsedValue != "") {
            return false;
        }

        var val = Globalize.parseFloat(value);
        return this.optional(element) || ($.isNumeric(val));
    };

    // Tell the validator that we want dates parsed using Globalize

    $.validator.methods.date = function (value, element) {
        // !!!
        var val = Globalize.parseDate(value);

        // yyyy-MM-dd Razor EditorFor
        if (!val) {
            val = Globalize.parseDate(value, "yyyy-MM-dd");
        }
        if (!val) {
            val = Globalize.parseDate(value, "yyyy-MM-dd HH:mm:dd");
        }

        //var val = Globalize.parseDate(value);
        return this.optional(element) || (val);
    };

    // Tell the validator that we want numbers parsed using Globalize,
    // then call into original implementation with parsed value

    $.validator.methods.min = function (value, element, param) {
        // !!!
        var parsedValue = value
            .replace(/[0-9]/g, "")
            .replace("-", "")
            .replace(Globalize.cultures[Globalize.cultureSelector].numberFormat["."], "")
            .trim();
        if (parsedValue != "") {
            return false;
        }

        var val = Globalize.parseFloat(value);
        return originalMethods.min.call(this, val, element, param);
    };

    $.validator.methods.max = function (value, element, param) {
        // !!!
        var parsedValue = value
            .replace(/[0-9]/g, "")
            .replace("-", "")
            .replace(Globalize.cultures[Globalize.cultureSelector].numberFormat["."], "")
            .trim();
        if (parsedValue != "") {
            return false;
        }

        var val = Globalize.parseFloat(value);
        return originalMethods.max.call(this, val, element, param);
    };

    $.validator.methods.range = function (value, element, param) {
        // !!!
        var parsedValue = value
            .replace(/[0-9]/g, "")
            .replace("-", "")
            .replace(Globalize.cultures[Globalize.cultureSelector].numberFormat["."], "")
            .trim();
        if (parsedValue != "") {
            return false;
        }

        var val = Globalize.parseFloat(value);
        return originalMethods.range.call(this, val, element, param);
    };

}(jQuery, Globalize));
