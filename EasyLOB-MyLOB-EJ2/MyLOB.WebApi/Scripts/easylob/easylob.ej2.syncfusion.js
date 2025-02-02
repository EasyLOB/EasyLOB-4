/*

On*View
    Collection
        function zOnCollectionView(model, profile, dataSourceUrl, query = "null")
        function zOnCollectionViewActionBegin(model, args)
        function zOnCollectionViewActionBeginSCRUD(model)
        function zOnCollectionViewRead(model, profile)
        function zOnCollectionViewWrite(model, profile, args)
    CRUD
        function zOnCRUDView(model)
    Item
        function zOnItemView(model, profile)
    Lookup
        function zOnLookupView(model, profile)
        function zOnLookupViewActionBegin(model, args)
        function zOnLookupViewRead(model, profile)
        function zOnLookupViewWrite(model, profile, args)
Syncfusion
    function zGrid(gridId)
    function zGridDataSource(gridId, dataSourceUrl, query = "null", isRefresh = false)
    function zLookupElements(data, elements, culture)
    function zSyncfusionCollection(id)
    function zSyncfusionCollectionReady(id)
    function zSyncfusionItem(id)
    function zSyncfusionItemReady(id)
    function zSyncfusionLookup(id)
    function zSyncfusionLookupReady(id)
    function zTab(tabId)

*/

//// On*View

function zOnCollectionView(model, profile, dataSourceUrl, query = "null") {
    var gridId = "Grid_" + model.Id;
    var ejGrid = zGrid(gridId);

    // Master-Detail Filtering & Search
    if (model.IsMasterDetail) {
        // Filtering
        if (ejGrid.filterSettings.columns.length > 0) {
            ejGrid.clearFiltering();
        }
        // Search
        if (ejGrid.searchSettings.key) {
            ejGrid.clearSearching();
        }
        // Current Page
        if (ejGrid.pageSettings.currentPage !== 1) {
            ejGrid.pageSettings.currentPage = 1;
        }
    }
    else {
        var search = zSearchDictionaryRead(profile.Name);
        if (search) {
            ejGrid.searchSettings.key = search;
            $("#Grid_" + model.Id + "_searchbar").val(search);
        }
    }

    ejGrid.searchSettings.fields = profile.GridSearchProperties;

    // Toolbar
    var toolbarItems = ejGrid.toolbarModule.toolbar.items;
    toolbarItems.forEach(function (item) {
        var operation = item.id.replace("Grid_" + model.Id + "_", "");
        if ("add|edit|delete|excelexport|pdfexport".includes(operation)) {
            item.text = "";
        }
    });

    // <div></div>
    // Search.cshtml                <div style="display: none
    // _EntityCollection.cshtml         <div id="Collection_Entity">
    $("#Collection_" + model.Id).parent().show();

    // Activity
    //if (model.ActivityOperations.IsSearch) {
    //    $("#Collection_" + model.Id).css("display", "block");
    //}
    //else {
    //    $("#Collection_" + model.Id).css("display", "none");
    //}

    // Export
    var isExport = model.ActivityOperations.IsExport;
    if (!isExport) {
        ejGrid.allowExcelExport = false;
        ejGrid.allowPdfExport = false;

        ejGrid.toolbar = ejGrid.toolbar.filter(function (value, index, arr) {
            return value != "ExcelExport" && value != "PdfExport";
        });
    }

    // DataSource
    if (!model.IsMasterDetail) {
        zGridDataSource("Grid_" + model.Id, dataSourceUrl, query);
    }

    zShowOperationResult(model.OperationResult);
}

function zOnCollectionViewActionBegin(model, args) {
    if (args.requestType == "add" || args.requestType == "beginedit" || args.requestType == "delete") {
        args.cancel = true;
    } else if (args.requestType == "filtering") {
        if (args.currentFilterObject && args.currentFilterObject.length > 0 && args.currentFilterObject[0].operator == "startswith") {
            args.currentFilterObject[0].operator = "contains";
        }
    }
}

function zOnCollectionViewActionBeginSCRUD(model) {
    var scrud = { isSearch: false, isCreate: false, isRead: false, isUpdate: false, isDelete: false };

    scrud.isSearch = !model.IsMasterDetail;

    scrud.isCreate = true;
    scrud.isRead = true;
    scrud.isUpdate = true;
    scrud.isDelete = true;

    //var masterControllerAction = model.MasterControllerAction == null ? "" : model.MasterControllerAction.toLowerCase();
    //scrud.isCreate = masterControllerAction == "" || masterControllerAction == "update";
    //scrud.isRead = masterControllerAction == "" || masterControllerAction == "read" || masterControllerAction == "update" || masterControllerAction == "delete";
    //scrud.isUpdate = masterControllerAction == "" || masterControllerAction == "update";
    //scrud.isDelete = masterControllerAction == "" || masterControllerAction == "update" || masterControllerAction == "delete";

    return scrud;
}

function zOnCollectionViewRead(model, profile) {
    if (!model.IsMasterDetail) {
        var gridId = "Grid_" + model.Id;
        var ejGrid = zGrid(gridId);
        var isRefresh = false;

        var filterSettings = JSON.parse(zLocalStorageGet("$easylob$" + gridId + "_Filter"));
        if (filterSettings) {
            ejGrid.filterSettings = filterSettings;
            isRefresh = true;
        }

        var searchSettings = JSON.parse(zLocalStorageGet("$easylob$" + gridId + "_Search"));
        if (searchSettings) {
            ejGrid.searchSettings = searchSettings;
            ejGrid.searchSettings.fields = profile.GridSearchProperties;
            $("#" + gridId + "_searchbar").val(searchSettings.key);
            isRefresh = true;
        }

        //if (isRefresh) {
        //    ejGrid.refresh();
        //}
    }
}

function zOnCollectionViewWrite(model, profile, args) {
    if (!model.IsMasterDetail) {
        var gridId = "Grid_" + model.Id;
        var ejGrid = zGrid(gridId);

        switch (args.requestType) {
            case "filtering":
                zLocalStorageSet("$easylob$" + gridId + "_Filter", JSON.stringify(ejGrid.filterSettings));
                break;
            case "searching":
                zLocalStorageSet("$easylob$" + gridId + "_Search", JSON.stringify(ejGrid.searchSettings));
                break;
        }
    }
}

function zOnCRUDView(model) {
    var controllerAction = model.ControllerAction ? model.ControllerAction.toLowerCase() : "";
    var isMasterDetail = model.IsMasterDetail ? model.IsMasterDetail : false;
    var customButtonSave = model.CustomButtonSave ? model.CustomButtonSave : false;
    var customButtonOK = model.CustomButtonOK ? model.CustomButtonOK : false;

    $("#Button_Save").hide();
    $("#Button_OK").hide();

    if (controllerAction === "create" || controllerAction === "update" || customButtonSave) {
        $("#Button_Save").show();
    }

    if (isMasterDetail) {
        $("#Button_Save").hide();
    }

    if (controllerAction === "create" || controllerAction === "update" || controllerAction === "delete" || customButtonOK) {
        $("#Button_OK").show();
    }
}

function zOnItemView(model, profile) {
    var controllerAction = model.ControllerAction ? model.ControllerAction.toLowerCase() : "";

    // Read-Only
    var readOnly = controllerAction === "delete" || controllerAction === "read" || model.IsReadOnly;
    $("input.form-control").not(":input[id*='_LookupText'], :input[type=button], :input[type=image], :input[type=reset], :input[type=submit]").prop("readonly", readOnly);
    // ReadOnly.js
    // https://github.com/haggen/readonly
    $("select").readonly(readOnly);
    //readonly(parentId + " select", readOnly);
    $("textarea").prop("readonly", readOnly);
    if (readOnly) {
        $("input[type='checkbox']").prop("disabled", true);

        $("input.e-datepicker").each(function () {
            this.ej2_instances[0].readonly = true;
        });
        $("input.e-datetimepicker").each(function () {
            this.ej2_instances[0].readonly = true;
        });

        $("img.z-buttonLookup").hide();
    }
    else {
        $("img.z-buttonLookup").show();
    }

    var i;

    // Keys
    var keys = profile.Keys;
    var keysLength = keys.length;
    for (i = 0; i < keysLength; i++) {
        if (controllerAction == "create") {
            if (profile.IsIdentity) {
                $("#Group_" + profile.Name + "_" + keys[i]).hide();
            }
        } else {
            $("#" + profile.Name + "_" + keys[i]).prop("readonly", true);
        }
    }

    // Hidden
    var hiddenProperties = profile.EditHiddenProperties;
    var hiddenPropertiesLength = hiddenProperties.length;
    for (i = 0; i < hiddenPropertiesLength; i++) {
        $("#Group_" + profile.Name + "_" + hiddenProperties[i]).hide();
    }

    // Read-Only
    var readOnlyProperties = profile.EditReadOnlyProperties;
    var readOnlyPropertiesLength = readOnlyProperties.length;
    for (i = 0; i < readOnlyPropertiesLength; i++) {
        $("#" + profile.Name + "_" + readOnlyProperties[i]).prop("readonly", true);

        $("select#" + profile.Name + "_" + readOnlyProperties[i]).readonly(true);

        $("textarea#" + profile.Name + "_" + readOnlyProperties[i]).prop("readonly", true);

        $("input[type='checkbox'][id='" + profile.Name + "_" + readOnlyProperties[i] + "']").removeProp("readonly");
        $("input[type='checkbox'][id='" + profile.Name + "_" + readOnlyProperties[i] + "']").prop("disabled", true);

        $("input#" + profile.Name + "_" + readOnlyProperties[i] + ".e-datepicker").each(function () {
            this.ej2_instances[0].readonly = true;
        });
        $("input#" + profile.Name + "_" + readOnlyProperties[i] + ".e-datetimepicker").each(function () {
            this.ej2_instances[0].readonly = true;
        });

        $("#" + profile.Name + "_" + readOnlyProperties[i] + "_LookupButton").hide();
    }

    // Collections (PK)
    var hiddenCollections = profile.EditHiddenCollections;
    var hiddenCollectionsLength = hiddenCollections.length;
    for (i = 0; i < hiddenCollectionsLength; i++) {
        var tabItemId = "TabItem_" + profile.Name + "_" + hiddenCollections[i];
        var tabHeaderId = $("div[data-easylob-id='" + tabItemId + "']").attr("aria-labelledby");

        $("div[data-easylob-id='" + tabItemId + "']").css("display", "none");
        $("div[id='" + tabHeaderId + "']").css("display", "none");
    }
    var collections = profile.EditCollections;
    var collectionsLength = collections.length;
    for (i = 0; i < collectionsLength; i++) {
        var tabItemId = "TabItem_" + profile.Name + "_" + collections[i];
        var tabHeaderId = $("div[data-easylob-id='" + tabItemId + "']").attr("aria-labelledby");

        if (controllerAction === "create") {
            $("div[data-easylob-id='" + tabItemId + "']").css("display", "none");
            $("div[id='" + tabHeaderId + "']").css("display", "none");
        } else {
            $("div[data-easylob-id='" + tabItemId + "']").removeAttr("display");
            $("div[id='" + tabHeaderId + "']").removeAttr("display");
        }
    }

    // Tab
    if (controllerAction == "create") {
        zTabDictionaryWrite(profile.Name, 0);
    }
    var tabIndex = zTabDictionaryRead(profile.Name);
    if (tabIndex && tabIndex >= 0) {
        var ejTab = zTab("Tab_" + profile.Name);
        ejTab.select(tabIndex);
    }

    // ENTER => TAB
    zEnter2Tab();

    // <div></div>
    // CRUD.cshtml                  <div id="Form_Entity" style="display: none;">
    // CRUD.cshtml                      <div>
    // _EntityItem.cshtml                   <div id="Item_Entity">
    $("#Item_" + profile.Name).parent().parent().show();

    zShowOperationResult(model.OperationResult);
}

function zOnLookupView(model, profile) {
    var gridId = model.ValueId + "_LookupGrid";
    var ejGrid = zGrid(gridId);

    // Search
    ejGrid.searchSettings.fields = profile.GridSearchProperties;

    zShowOperationResult(model.OperationResult);
}

function zOnLookupViewActionBegin(model, args) {
    if (args.requestType == "add" || args.requestType == "beginedit" || args.requestType == "delete") {
        args.cancel = true;
    } else if (args.requestType == "filtering") {
        if (args.currentFilterObject && args.currentFilterObject.length > 0 && args.currentFilterObject[0].operator == "startswith") {
            args.currentFilterObject[0].operator = "contains";
        }
    }
}

function zOnLookupViewRead(model, profile) {
    if (!model.IsMasterDetail) {
        var gridId = model.ValueId + "_LookupGrid";
        var ejGrid = zGrid(gridId);
        var isRefresh = false;

        var filterSettings = JSON.parse(zLocalStorageGet("$easylob$" + gridId + "_Filter"));
        if (filterSettings) {
            ejGrid.filterSettings = filterSettings;
            isRefresh = true;
        }

        var searchSettings = JSON.parse(zLocalStorageGet("$easylob$" + gridId + "_Search"));
        if (searchSettings) {
            ejGrid.searchSettings = searchSettings;
            ejGrid.searchSettings.fields = profile.GridSearchProperties;
            $("#" + gridId + "_searchbar").val(searchSettings.key);
            isRefresh = true;
        }

        //if (isRefresh) {
        //    ejGrid.refresh();
        //}
    }
}

function zOnLookupViewWrite(model, profile, args) {
    if (!model.IsMasterDetail) {
        var gridId = model.ValueId + "_LookupGrid";
        var ejGrid = zGrid(gridId);

        switch (args.requestType) {
            case "filtering":
                zLocalStorageSet("$easylob$" + gridId + "_Filter", JSON.stringify(ejGrid.filterSettings));
                break;
            case "searching":
                zLocalStorageSet("$easylob$" + gridId + "_Search", JSON.stringify(ejGrid.searchSettings));
                break;
        }
    }
}

//// Syncfusion
        
function zGrid(gridId) {
    return document.getElementById(gridId).ej2_instances[0];
}

function zGridDataSource(gridId, dataSourceUrl, query = "null", isRefresh = false) {
    if ($("#" + gridId).length) {
        var ejGrid = zGrid(gridId);
        if (dataSourceUrl) {
            var dataManager = new ej.data.DataManager({
                adaptor: new ej.data.UrlAdaptor(),
                crossDomain: true,
                url: dataSourceUrl
            });
            ejGrid.dataSource = dataManager;

            // new ej.data.Query().where(new ej.data.Predicate('CategoryName', 'startsWith', 'C'))
            query = !query || query.toLowerCase() == "null" ? "null" : query;
            if (query != "null") {
                var ejGridQuery = query;
                ejGridQuery = zReplaceAll(ejGridQuery, "&quot;", '"');
                ejGridQuery = zReplaceAll(ejGridQuery, "&#x27;", "'");

                ejGrid.query = eval(ejGridQuery);
            }
        } else {
            ejGrid.dataSource = null;
        }

        //if (isRefresh) {
        //    ejGrid.refresh();
        //}
    }
}

function zLookupElements(data, elements, culture) {
    // EasyLOB.Mvc.LookupModelElement
    // elements.Id
    // elements.Property
    if (elements) {
        var elementsLength = elements.length;
        for (var i = 0, length = elementsLength; i < length; i++) {
            var element = elements[i];
            if ($("#" + element.Id).length) {
                if (data.hasOwnProperty(element.Property)) {
                    var value = data[element.Property];
                    value = value == null ? "" : value;

                    var valueGlobalize = "";
                    if (zIsBoolean(value)) {
                        valueGlobalize = value ? "true" : "false";
                    } else if (zIsDate(value)) {
                        valueGlobalize = Globalize.formatDate(value, { date: "short" });
                    } else if (zIsNumberFloat(value)) {
                        valueGlobalize = Globalize.formatNumber(value, { maximumFractionDigits: 2, useGrouping: false });
                    } else if (zIsNumberInteger(value)) {
                        valueGlobalize = Globalize.formatNumber(value, { maximumFractionDigits: 0, useGrouping: false });
                    } else if (zIsString(value)) {
                        valueGlobalize = value.trim();
                    } else {
                        valueGlobalize = value.toString().trim();
                    }

                    $("#" + element.Id).val(valueGlobalize);
                    $("#" + element.Id).change(); // Knockout
                    /*
                    var value = data[element.Property];
                    value = value == null ? "" : value;
                    if (value) {
                        try {
                            var valueDate = new Date(value);
                            if (valueDate.getFullYear()) {
                                value = Globalize.formatDate(valueDate, { datetime: "short" });
                            }
                        } catch (exception) { }
                    }
                    $("#" + element.Id).val(value);
                    $("#" + element.Id).change(); // Knockout
                    */
                }
            }
        }
    }
}

function zSyncfusionCollection(id) {
}

function zSyncfusionCollectionReady(id) {
}

function zSyncfusionItem(id) {
    // Validate hidden fields
    $.validator.setDefaults({ ignore: null });
    // Parse validators
    //$.validator.unobtrusive.parse($("#ZAjax")); // ???
}

function zSyncfusionItemReady(id) {
}

function zSyncfusionLookup(id) {
}

function zSyncfusionLookupReady(id) {
}

function zTab(tabId) {
    return document.getElementById(tabId).ej2_instances[0];
}
