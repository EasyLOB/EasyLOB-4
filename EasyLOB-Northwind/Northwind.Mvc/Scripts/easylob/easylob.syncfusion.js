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
        function zOnLookupView(model, profile, gridId)
        function zOnLookupViewActionBegin(model, args)
        function zOnLookupViewRead(model, profile)
        function zOnLookupViewWrite(model, profile, args)
Syncfusion
    function zGrid(gridId)
    function zGridDataManager(gridId, dataSourceUrl, functionBeforeSend, isRefresh)
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
        if (ejGrid.model.filterSettings.filteredColumns.length > 0) {
            ejGrid.clearFiltering();
        }
        // Search
        if (ejGrid.model.searchSettings.key) {
            ejGrid.clearSearching();
        }
        // Current Page
        if (ejGrid.model.pageSettings.currentPage !== 1) {
            ejGrid.model.pageSettings.currentPage = 1;
        }
    }
    else {
        var search = zSearchDictionaryRead(profile.Name);
        if (search) {
            ejGrid.model.searchSettings.key = search;
            $("#Grid_" + model.Id + "_searchbar").val(search);
        }    
    }

    ejGrid.model.searchSettings.fields = profile.GridSearchProperties;

    //if (!model.IsMasterDetail) {
    //    ejGrid.setModel({
    //        allowGrouping: true,
    //        toolbarSettings: {
    //            toolbarItems: [
    //                ej.Grid.ToolBarItems.Search,
    //                ej.Grid.ToolBarItems.Add,
    //                ej.Grid.ToolBarItems.Edit,
    //                ej.Grid.ToolBarItems.Delete
    //                //ej.Grid.ToolBarItems.ExcelExport,
    //                //ej.Grid.ToolBarItems.PdfExport,
    //                //ej.Grid.ToolBarItems.WordExport
    //            ]
    //        }
    //    });
    //} else {
    //    ejGrid.setModel({
    //        allowGrouping: false,
    //        toolbarSettings: {
    //            toolbarItems: [
    //                ej.Grid.ToolBarItems.Search,
    //                ej.Grid.ToolBarItems.Add,
    //                ej.Grid.ToolBarItems.Edit,
    //                ej.Grid.ToolBarItems.Delete
    //            ]
    //        }
    //    });
    //}

    // Tooltip
    $("#Grid_" + model.Id + "_Grid_" + model.Id + "_Toolbar").removeAttr("data-content");

    // DataSource
    if (dataSourceUrl) {
        if (!model.IsMasterDetail) {
            zGridDataSource("Grid_" + model.Id, dataSourceUrl, query);
        }
    }

    // <div></div>
    // Search.cshtml                <div style = "display: none
    // _EntityCollection.cshtml         <div id="Collection_Entity">
    $("#Collection_" + model.Id).parent().show();

    // Activity
    //if (model.ActivityOperations.IsSearch) {
    //    $("#Collection_" + model.Id).css("display", "block");
    //}
    //else {
    //    $("#Collection_" + model.Id).css("display", "none");
    //}

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
            ejGrid.model.filterSettings = filterSettings;
            isRefresh = true;
        }

        var searchSettings = JSON.parse(zLocalStorageGet("$easylob$" + gridId + "_Search"));
        if (searchSettings) {
            ejGrid.model.searchSettings = searchSettings;
            ejGrid.model.searchSettings.fields = profile.GridSearchProperties;
            $("#" + gridId + "_searchbar").val(searchSettings.key);
            isRefresh = true;
        }

        //if (isRefresh) {
        //    ejGrid.refreshContent();
        //}
    }
}

function zOnCollectionViewWrite(model, profile, args) {
    if (!model.IsMasterDetail) {
        var gridId = "Grid_" + model.Id;
        var ejGrid = zGrid(gridId);

        switch (args.requestType) {
            case "filtering":
                zLocalStorageSet("$easylob$" + gridId + "_Filter", JSON.stringify(ejGrid.model.filterSettings));
                break;
            case "searching":
                zLocalStorageSet("$easylob$" + gridId + "_Search", JSON.stringify(ejGrid.model.searchSettings));
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

        $("input[data-role='ejdatepicker']").each(function() {
            $(this).data("ejDatePicker").option("readOnly", true);
        });
        $("input[data-role='ejdatetimepicker']").each(function() {
            $(this).data("ejDateTimePicker").option("readOnly", true);
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

        $("input[data-role='ejdatepicker'][id='" + profile.Name + "_" + readOnlyProperties[i] + "']").each(function () {
            $(this).data("ejDatePicker").option("readOnly", true);
        });
        $("input[data-role='ejdatetimepicker'][id='" + profile.Name + "_" + readOnlyProperties[i] + "']").each(function () {
            $(this).data("ejDateTimePicker").option("readOnly", true);
        });

        $("#" + profile.Name + "_" + readOnlyProperties[i] + "_LookupButton").hide();
    }

    // Collections (PK)
    var hiddenCollections = profile.EditHiddenCollections;
    var hiddenCollectionsLength = hiddenCollections.length;
    for (i = 0; i < hiddenCollectionsLength; i++) {
        var id = "TabSheet_" + profile.Name + "_" + hiddenCollections[i];
        $("a[href='#" + id + "']").css("display", "none");
        $("#" + id).css("display", "none");
    }
    var collections = profile.EditCollections;
    var collectionsLength = collections.length;
    for (i = 0; i < collectionsLength; i++) {
        var id = "TabSheet_" + profile.Name + "_" + collections[i];
        if (controllerAction === "create") {
            $("a[href='#" + id + "']").css("display", "none");
            $("#" + id).css("display", "none");
        } else {
            $("a[href='#" + id + "']").removeAttr("display");
            $("#" + id).removeAttr("display");
            //$("a[href='#" + id + "']").css("display", "block");
            //$("#" + id).css("display", "block");
        }
    }
    if (controllerAction == "create") {
        zTabDictionaryWrite(profile.Name, 0);
    }

    // ENTER => TAB
    zEnter2Tab();
    //$("input").keydown(function (e) {
    //    var key = e.charCode ? e.charCode : e.keyCode ? e.keyCode : 0;
    //    if (key === 13) {
    //        e.preventDefault();
    //        var inputs = $(this).closest("form").find(":input:visible");
    //        inputs.eq(inputs.index(this) + 1).focus();
    //    }
    //});

    // Tab
    var tabIndex = zTabDictionaryRead(profile.Name);
    if (tabIndex && tabIndex >= 0) {
        var ejTab = zTab("Tab_" + profile.Name);
        ejTab.setModel({
            selectedItemIndex: tabIndex
        });
    }

    // <div></div>
    // CRUD.cshtml                  <div id="Form_Entity" style = "display: none;">
    // CRUD.cshtml                      <div>
    // _EntityItem.cshtml                   <div id="Item_Entity">
    $("#Item_" + profile.Name).parent().parent().show();

    zShowOperationResult(model.OperationResult);
}

function zOnLookupView(model, profile) {
    var gridId = model.ValueId + "_LookupGrid";
    var ejGrid = zGrid(gridId);

    // Search
    ejGrid.model.searchSettings.fields = profile.GridSearchProperties;

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
            ejGrid.model.filterSettings = filterSettings;
            isRefresh = true;
        }

        var searchSettings = JSON.parse(zLocalStorageGet("$easylob$" + gridId + "_Search"));
        if (searchSettings) {
            ejGrid.model.searchSettings = searchSettings;
            ejGrid.model.searchSettings.fields = profile.GridSearchProperties;
            $("#" + gridId + "_searchbar").val(searchSettings.key);
            isRefresh = true;
        }

        //if (isRefresh) {
        //    ejGrid.refreshContent();
        //}
    }
}

function zOnLookupViewWrite(model, profile, args) {
    if (!model.IsMasterDetail) {
        var gridId = model.ValueId + "_LookupGrid";
        var ejGrid = zGrid(gridId);

        switch (args.requestType) {
            case "filtering":
                zLocalStorageSet("$easylob$" + gridId + "_Filter", JSON.stringify(ejGrid.model.filterSettings));
                break;
            case "searching":
                zLocalStorageSet("$easylob$" + gridId + "_Search", JSON.stringify(ejGrid.model.searchSettings));
                break;
        }
    }
}

//// Syncfusion

function zGrid(gridId) {
    var ejGrid = $("#" + gridId).data("ejGrid");
    if (!ejGrid) {
        ej.widget.init($("#" + gridId).parent()); // #Grid_Entity => #Collection_Entity
        ejGrid = $("#" + gridId).data("ejGrid");
    }

    return ejGrid;
}

function zGridDataManager(gridId, dataSourceUrl, functionBeforeSend, isRefresh = false) {
    if ($("#" + gridId).length) {
        var ejGrid = zGrid(gridId);

        if (dataSourceUrl) {
            var customAdaptor = new ej.UrlAdaptor().extend({
                beforeSend: functionBeforeSend
            });
            ejGrid.dataSource(ej.DataManager({
                adaptor: new customAdaptor(),
                url: dataSourceUrl
            }));
        }

        //if (isRefresh) {
        //    ejGrid.refreshContent();
        //}
    }
}

function zGridDataSource(gridId, dataSourceUrl, query = "null", isRefresh = false) {
    if ($("#" + gridId).length) {
        var ejGrid = zGrid(gridId);
        if (dataSourceUrl) {
            ejGrid.dataSource(ej.DataManager({
                adaptor: new ej.UrlAdaptor(),
                url: dataSourceUrl
            }));

            // ej.Query().where('CategoryName', ej.FilterOperators.startsWith, 'C')
            query = !query ? "null" : query;
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
        //    ejGrid.refreshContent();
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
            // $("#Id")
            if ($("#" + element.Id).length) {
                if (data.hasOwnProperty(element.Property)) {
                    var value = data[element.Property];
                    value = value == null ? "" : value;

                    var valueGlobalize = "";
                    if (zIsBoolean(value)) {
                        valueGlobalize = value ? "true" : "false";
                    } else if (zIsDate(value)) {
                        valueGlobalize = Globalize.format(value, "d")
                    } else if (zIsNumberFloat(value)) {
                        valueGlobalize = Globalize.format(value, "n")
                    } else if (zIsNumberInteger(value)) {
                        valueGlobalize = Globalize.format(value, "d")
                    } else if (zIsString(value)) {
                        valueGlobalize = value.trim();
                    } else {
                        valueGlobalize = value.toString().trim();
                    }

                    $("#" + element.Id).val(valueGlobalize);
                    $("#" + element.Id).change(); // Knockout
                }
            }
        }
    }
}

function zSyncfusionCollection(id) {
    //ej.widget.init($("#" + id));
}

function zSyncfusionCollectionReady(id) {
    //ej.widget.init($("#" + id));
}

function zSyncfusionItem(id) {
    // Validate hidden fields
    $.validator.setDefaults({ ignore: null });
    // Parse validators
    $.validator.unobtrusive.parse($("#ZAjax"));

    //ej.widget.init($("#" + id));
}

function zSyncfusionItemReady(id) {
    //ej.widget.init($("#" + id));
}

function zSyncfusionLookup(id) {
}

function zSyncfusionLookupReady(id) {
}

function zTab(tabId) {
    var ejTab = $("#" + tabId).data("ejTab");
    if (!ejTab) {
        ej.widget.init($("#" + tabId).parent()); // #Tab_Entity => #Item_Entity
        ejTab = $("#" + tabId).data("ejTab");
    }

    return ejTab;
}
