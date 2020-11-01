$("#LoadingModal").modal("show");

//Fix column header widths on jquery dataTables
$('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
    //$($.fn.dataTable.tables(true)).DataTable().columns.adjust();
    $($.fn.dataTable.tables(true)).DataTable().scroller.measure();
});

//Load data in when model is displayed
$("#ModalTransaction").on("shown.bs.modal", function () {
    let transactionID = $("#TransactionID").val();
    let actionID = $("#ActionID").val();
    let formTitle = $("#FormTitleID").val();
    let rootPath = $("#RootPath").val();
    if (actionID == null) {
        actionID = `Details`;
    }
    if (formTitle === "") {
        formTitle = "Payment Details";
    }
    if (rootPath == null) {
        rootPath = ``;
    }

    $("#ModalTransactionLabel").find(".title").html(formTitle);

    //Set form title back to blank to default to new recond functionality
    $("#FormTitleID").val("");

    let objectID = null;
    let objectIDField = null;
    let objectTypeID = null;
    let remoteElementID = null;
    let loadIntoElementID = null;
    let modalID = null;
    let formID = null;
    let listID = null;
    let buttonClass = null;
    let closeModalOnSuccess = null;

    objectID = transactionID;
    objectIDField = "#TransactionID";
    objectTypeID = "Transactions";
    remoteElementID = "#TransactionForm";
    loadIntoElementID = "#TransactionDetails";
    parentID = transactionID;
    modalID = "#ModalTransaction";
    formID = "#TransactionFormData";
    listID = "#TransactionList";
    buttonClass = ".OpenTransactionButton";
    closeModalOnSuccess = true;
    loadForm(objectID, objectIDField, objectTypeID, actionID, remoteElementID, loadIntoElementID, parentID, rootPath, modalID, formID, listID, buttonClass, closeModalOnSuccess);

    objectTypeID = "Notes";
    listID = "#NoteList";
    parentID = transactionID;
    loadList(objectTypeID, listID, parentID, rootPath);

    //Show any popup alerts
    objectID = transactionID;
    objectTypeID = "Notes";
    showAlerts(objectTypeID, objectID, rootPath);
});

$("#ModalTransaction").on("hidden.bs.modal", function () {
    $("#PaymentTabs a:first").tab("show");
    let loadingAnim = $("#LoadingHTML").html();
    $("#TransactionDetails").html(loadingAnim);

    $("#TransactionID").val("");
});

$("#ModalNote").on("shown.bs.modal", function () {
    let transactionID = $("#TransactionID").val();
    let noteID = $("#NoteID").val();
    let actionID = $("#ActionID").val();
    let formTitle = $("#FormTitleID").val();
    let rootPath = $("#RootPath").val();
    if (actionID == null) {
        actionID = `Details`;
    }
    if (formTitle === "") {
        formTitle = "Note Details";
    }
    if (rootPath == null) {
        rootPath = ``;
    }

    $("#ModalNoteLabel").find(".title").html(formTitle);

    //Set form title back to blank to default to new recond functionality
    $("#FormTitleID").val("");

    let objectID = null;
    let objectIDField = null;
    let objectTypeID = null;
    let remoteElementID = null;
    let loadIntoElementID = null;
    let modalID = null;
    let formID = null;
    let listID = null;
    let buttonClass = null;
    let closeModalOnSuccess = null;

    objectID = noteID;
    objectIDField = "#NoteID";
    objectTypeID = "Notes";
    remoteElementID = "#NoteForm";
    loadIntoElementID = "#NoteDetails";
    parentID = transactionID;
    modalID = "#ModalNote";
    formID = "#NoteFormData";
    listID = "#NoteList";
    buttonClass = ".OpenNoteButton";
    closeModalOnSuccess = true;
    loadForm(objectID, objectIDField, objectTypeID, actionID, remoteElementID, loadIntoElementID, parentID, rootPath, modalID, formID, listID, buttonClass, closeModalOnSuccess);
});

$("#ModalNote").on("hidden.bs.modal", function () {
    let loadingAnim = $("#LoadingHTML").html();
    $("#NoteDetails").html(loadingAnim);
});

$(".SaveNoteButton").click(function (event) {
    $("#NoteFormData").submit();
    checkApplyOrOkClicked($(this).text());
});

$(".DeleteNoteButton").click(function (event) {
    $("#NoteFormData").submit();
});

$(".NewNoteButton").click(function (event) {
    $("#NoteID").val("");
});

$("#ModalDeleteNote").on("shown.bs.modal", function () {
    let transactionID = $("#TransactionID").val();
    let noteID = $("#NoteID").val();
    let actionID = $("#ActionID").val();
    let formTitle = $("#FormTitleID").val();
    let rootPath = $("#RootPath").val();
    if (actionID == null) {
        actionID = `Details`;
    }
    if (formTitle === "") {
        formTitle = "Note Details";
    }
    if (rootPath == null) {
        rootPath = ``;
    }

    $("#ModalNoteLabel").find(".title").html(formTitle);

    //Set form title back to blank to default to new recond functionality
    $("#FormTitleID").val("");

    let objectID = null;
    let objectIDField = null;
    let objectTypeID = null;
    let remoteElementID = null;
    let loadIntoElementID = null;
    let modalID = null;
    let formID = null;
    let listID = null;
    let buttonClass = null;
    let closeModalOnSuccess = null;

    objectID = noteID;
    objectIDField = "#NoteID";
    objectTypeID = "Notes";
    remoteElementID = "#NoteForm";
    loadIntoElementID = "#DeleteNoteDetails";
    parentID = transactionID;
    modalID = "#ModalDeleteNote";
    formID = "#NoteFormData";
    listID = "#NoteList";
    buttonClass = ".OpenNoteButton";
    closeModalOnSuccess = true;
    loadForm(objectID, objectIDField, objectTypeID, actionID, remoteElementID, loadIntoElementID, parentID, rootPath, modalID, formID, listID, buttonClass, closeModalOnSuccess);
});

$("#ModalDeleteNote").on("hidden.bs.modal", function () {
    let loadingAnim = $("#LoadingHTML").html();
    $("#DeleteNoteDetails").html(loadingAnim);
});

function loadForm(objectID, objectIDField, objectTypeID, actionID, remoteElementID, loadIntoElementID, parentID, rootPath, modalID, formID, listID, buttonClass, closeModalOnSuccess) {
    let dataToLoad = null;

    //If object ID is found then need to edit
    if (objectID.length) {
        dataToLoad = `${rootPath}/${objectTypeID}/${actionID}/${objectID}`;
    }
    else if (parentID.length > 0) {
        dataToLoad = `${rootPath}/${objectTypeID}/${actionID}/${parentID}`;
    }
    else {
        dataToLoad = `${rootPath}/${objectTypeID}/${actionID}`;
    }

    $.get(dataToLoad, function (data) {

    })
        .then(data => {
            var formData = $(data).find(remoteElementID);
            $(loadIntoElementID).html(formData);

            attachFormFunctions(objectID, objectIDField, objectTypeID, actionID, remoteElementID, loadIntoElementID, parentID, rootPath, modalID, formID, listID, buttonClass, closeModalOnSuccess);

            console.log(`${objectTypeID} form data from ${dataToLoad} loaded into ${loadIntoElementID}`);
        })
        .fail(function () {
            let title = `Error Loading ${objectTypeID} Information`;
            let content = `The form ${objectTypeID} data at ${dataToLoad} returned a server error and could not be loaded`;

            doErrorModal(title, content);
        });
}

function loadList(objectTypeID, listID, parentID, rootPath) {
    let dataToLoad = `${rootPath}/${objectTypeID}/${parentID}/?handler=Json`;

    let listData = $(listID).DataTable();

    listData.ajax.url(dataToLoad).load(null, false);

    console.log(objectTypeID + " from " + dataToLoad + " Loaded");
}

function showAlerts(objectTypeID, objectID, rootPath) {
    let dataToLoad = null;

    if (objectID.length > 0) {
        dataToLoad = `${rootPath}/${objectTypeID}/${objectID}/?handler=Json&alertOnly=true`;
    }
    else {
        dataToLoad = `${rootPath}/${objectTypeID}/?handler=Json&alertOnly=true`;
    }

    $.get(dataToLoad, function (data) {

    })
        .then(data => {
            //Show any alerts from the remote page
            var alertHtml = "";
            for (var key in data) {
                if (data[key].noteText !== null) {
                    alertHtml += "<p>" + data[key].noteText + "</p>";
                }
            }

            if (alertHtml !== "") {
                doModal(`${objectTypeID} Alerts`, alertHtml);
            }

            console.log(objectTypeID + " from " + dataToLoad + " Loaded");
        })
        .fail(function () {
            let title = `Error Loading ${dataToLoad}`;
            let content = `The list at ${dataToLoad} returned a server error and could not be loaded`;

            doErrorModal(title, content);
        });
}

$(".SubmitOnEnter").keyup(function (event) {
    if ((event.keyCode || event.which) === 13) {
        //If enter key pressed
        $(".SearchTransactions").trigger("click");
    }
});

$(".SearchTransactions").click(function (event) {
    let rootPath = $("#RootPath").val();
    if (rootPath == null) {
        rootPath = ``;
    }
    let dataToLoad = `${rootPath}/Transactions?handler=Json`;
    let paymentReason = $("#PaymentReason").val();
    let onlineBookingRefNo = $("#OnlineBookingRefNo").val();
    let email = $("#Email").val();
    let paymentDateFrom = $("#PaymentDateFrom").val();
    let paymentDateTo = $("#PaymentDateTo").val();
    let orderStatus = $("#OrderStatus").val();
    let testDateFrom = $("#TestDateFrom").val();
    let testDateTo = $("#TestDateTo").val();
    //let actionsRequired = $("#ActionsRequired").is(":checked");
    //let maxRecords = $("#MaxRecords").val();

    if (paymentReason.length > 0) {
        dataToLoad += `&PaymentReason=${paymentReason}`;
    }

    if (onlineBookingRefNo.length > 0) {
        dataToLoad += `&OnlineBookingRefNo=${onlineBookingRefNo}`;
    }

    if (email.length > 0) {
        dataToLoad += `&Email=${email}`;
    }

    if (paymentDateFrom.length > 0) {
        dataToLoad += `&PaymentDateFrom=${paymentDateFrom}`;
    }

    if (paymentDateTo.length > 0) {
        dataToLoad += `&PaymentDateTo=${paymentDateTo}`;
    }

    if (orderStatus.length > 0) {
        dataToLoad += `&OrderStatus=${orderStatus}`;
    }

    if (testDateFrom.length > 0) {
        dataToLoad += `&TestDateFrom=${testDateFrom}`;
    }

    if (testDateTo.length > 0) {
        dataToLoad += `&TestDateTo=${testDateTo}`;
    }

    $("#LoadingModal").modal("show");

    let listData = $("#TransactionList").DataTable();
    listData.ajax.url(dataToLoad).load(null, false);
    console.log(dataToLoad + " Loaded");
});

$(function () {
    //$.extend($.fn.dataTable.defaults, {
    //    language: {
    //        processing: '<div class="col text-center LoadingArea"><i class="fas fa-spinner fa-spin"></i></div>'
    //    }
    //});

    //var searchParams = $("#FilterQuery").val();
    var rootPath = $("#RootPath").val();
    if (rootPath == null) {
        rootPath = ``;
    }

    let transactionData = `${rootPath}/Transactions/?handler=Json`;
    console.log(transactionData + " Loaded");
    let noteData = `${rootPath}/Notes/0/?handler=Json`;
    console.log(noteData + " Loaded");

    TransactionListDT = $('#TransactionList').DataTable({
        dom: '<"row"<"col-md"l><"col-md"f>>rt<"row"<"col-md"ip><"col-md text-right"B>>',
        buttons: [
            {
                extend: 'colvis',
                text: '<i class="fas fa-columns"></i> Columns'
            },
            {
                extend: 'copyHtml5',
                text: '<i class="far fa-copy"></i> Copy',
                exportOptions: {
                    columns: ':visible'
                }
            },
            {
                extend: 'excelHtml5',
                text: '<i class="far fa-file-excel"></i> Excel',
                exportOptions: {
                    columns: ':visible'
                }
            },
            {
                extend: 'csvHtml5',
                text: '<i class="fas fa-file-csv"></i> CSV',
                exportOptions: {
                    columns: ':visible'
                }
            },
            {
                extend: 'pdfHtml5',
                text: '<i class="far fa-file-pdf"></i> PDF',
                exportOptions: {
                    columns: ':visible'
                }
            },
            {
                extend: 'print',
                text: '<i class="fas fa-print"></i> Print',
                exportOptions: {
                    columns: ':visible'
                }
            }
        ],
        //sDom: "fprtp", 
        processing: true,
        responsive: true, //Add this
        //language: {
        //    processing: '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span>'
        //},
        serverSide: false,
        colReorder: true,
        deferRender: true,
        scroller: true,
        scrollY: 460,
        //ajax: { url: `${rootPath}/Transactions/?handler=Json&search=${searchParams}`, dataSrc: "" },
        ajax: {
            url: transactionData,
            dataSrc: ""
        },
        columns: [
            {
                data: {
                    _: "transactionID",
                    sort: "transactionID",
                    filter: "transactionID",
                    display: trnTransactionDetails
                }
            },
            {
                data: {
                    _: "transactionID",
                    sort: "transactionID",
                    filter: "transactionID"
                }
            },
            {
                data: {
                    _: "onlineBookingRefNo",
                    sort: "onlineBookingRefNo",
                    filter: "onlineBookingRefNo"
                }
            },
            {
                data: {
                    _: "paymentDate",
                    sort: "paymentDate",
                    filter: "paymentDate",
                    display: trnPaymentDate
                }
            },
            {
                data: {
                    _: "surname",
                    sort: "surname",
                    filter: "surname"
                }
            },
            {
                data: {
                    _: "forename",
                    sort: "forename",
                    filter: "forename"
                }
            },
            {
                data: {
                    _: "responseStatusName",
                    sort: "responseStatusName",
                    filter: "responseStatusName",
                    display: trnResponseStatus
                }
            },
            {
                data: {
                    _: "orderStatusName",
                    sort: "orderStatusName",
                    filter: "orderStatusName",
                    display: trnOrderStatus
                }
            },
            {
                data: {
                    _: "numNotes",
                    sort: "numNotes",
                    filter: "numNotes",
                    display: trnNumNotes
                }
            },
            {
                data: {
                    _: "ieltsTestDate",
                    sort: "ieltsTestDate",
                    filter: "ieltsTestDate",
                    display: trnTestDate
                }
            },
            {
                data: {
                    _: "practiceTestBooked",
                    sort: "practiceTestBooked",
                    filter: "practiceTestBooked",
                    display: trnPracticeTestBooked
                },
                visible: false
            },
            {
                data: {
                    _: "practiceMaterialsSent",
                    sort: "practiceMaterialsSent",
                    filter: "practiceMaterialsSent",
                    display: trnPracticeMaterialsSent
                },
                visible: false
            },
            {
                data: {
                    _: "emailAddress",
                    sort: "emailAddress",
                    filter: "emailAddress"
                },
                visible: false
            },
            {
                data: {
                    _: "telNumber",
                    sort: "telNumber",
                    filter: "telNumber"
                },
                visible: false
            },
            {
                data: {
                    _: "amountDue",
                    sort: "amountDue",
                    filter: "amountDue",
                    display: trnAmountDue
                },
                visible: false
            },
            {
                data: {
                    _: "ieltsTestAmount",
                    sort: "ieltsTestAmount",
                    filter: "ieltsTestAmount",
                    display: trnIELTSTest
                },
                visible: false
            },
            {
                data: {
                    _: "practiceTestAmount",
                    sort: "practiceTestAmount",
                    filter: "practiceTestAmount",
                    display: trnPracticeTest
                },
                visible: false
            },
            {
                data: {
                    _: "practiceMaterialsAmount",
                    sort: "practiceMaterialsAmount",
                    filter: "practiceMaterialsAmount",
                    display: trnPracticeMaterials
                },
                visible: false
            },
            {
                data: {
                    _: "amountPaid",
                    sort: "amountPaid",
                    filter: "amountPaid",
                    display: trnAmountPaid
                }
            }
        ],
        //order: [[3, "asc"], [4, "asc"], [2, "asc"]],
        order: [],
        drawCallback: function (settings, json) {
            attachListFunctions(
                ".OpenTransactionButton",
                "#TransactionID"
            );
            transactionFunctions();
        }
    });

    NoteListDT = $('#NoteList').DataTable({
        dom: '<"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6"f>>rt<"row"<"col-md text-right"B>><"row"<"col-sm-12 col-md-5"i><"col-sm-12 col-md-7"p>>',
        buttons: [
            {
                extend: 'colvis',
                text: '<i class="fas fa-columns"></i> Columns'
            },
            {
                extend: 'copyHtml5',
                text: '<i class="far fa-copy"></i> Copy',
                exportOptions: {
                    columns: ':visible'
                }
            },
            {
                extend: 'excelHtml5',
                text: '<i class="far fa-file-excel"></i> Excel',
                exportOptions: {
                    columns: ':visible'
                }
            },
            {
                extend: 'csvHtml5',
                text: '<i class="fas fa-file-csv"></i> CSV',
                exportOptions: {
                    columns: ':visible'
                }
            },
            {
                extend: 'pdfHtml5',
                text: '<i class="far fa-file-pdf"></i> PDF',
                exportOptions: {
                    columns: ':visible'
                }
            },
            {
                extend: 'print',
                text: '<i class="fas fa-print"></i> Print',
                exportOptions: {
                    columns: ':visible'
                }
            }
        ],
        processing: true,
        responsive: true, //Add this
        serverSide: false,
        colReorder: true,
        deferRender: true,
        scroller: true,
        scrollY: 300,
        ajax: {
            url: noteData,
            dataSrc: ""
        },
        columns: [
            {
                data: {
                    _: "noteID",
                    sort: "noteID",
                    filter: "noteID",
                    display: notOpenNote
                }
            },
            {
                data: "noteText"
            },
            {
                data: {
                    _: "isAlert",
                    sort: "isAlert",
                    filter: "isAlert",
                    display: notIsAlert
                }
            },
            {
                data: {
                    _: "createdDate",
                    sort: "createdDate",
                    filter: "createdDate",
                    display: notCreatedDate
                }
            }
        ],
        //order: [[1, "asc"], [2, "asc"]],
        order: [],
        drawCallback: function (settings, json) {
            attachListFunctions(
                ".OpenNoteButton",
                "#NoteID"
            );
        }
    });
});

function trnTransactionDetails(data, type, dataToSet) {
    return `
        <button type="button" class="btn btn-secondary OpenTransactionButton" data-toggle="modal" data-id="${data.transactionID}" data-target="#ModalTransaction" data-path="Details" data-loading-text="Payment from ${data.customerName}">
            <i class="fas fa-external-link-alt"></i>
        </button>`;
}

function trnPaymentDate(data, type, dataToSet) {
    if (data.paymentDate === null) {
        return ``;
    }
    else {
        moment.locale('en-gb');
        return `${moment(data.paymentDate).calendar()}`;
    }
}

function trnResponseStatus(data, type, dataToSet) {
    let transactionClass = "SuccessfulTransaction";
    if (data.responseStatusCode !== 9) {
        transactionClass = "UnsuccessfulTransaction";
    }

    return `
        <div class="${transactionClass}">
            ${data.responseStatusName}
        </div>`;
}

function trnOrderStatus(data, type, dataToSet) {
    if (data.orderStatusCode !== null) {
        let orderStatusClass = `OrderStatus${data.orderStatusCode}`;

        return `
        <div class="${orderStatusClass}">
            ${data.orderStatusName}
        </div>`;
    }
    else {
        return ``;
    }
    
}

function trnNumNotes(data, type, dataToSet) {
    let noteClass = '';
    if (data.numNotes < 1) {
        noteClass = `text-muted`;
    }

    return `
    <div class="${noteClass}">
        <i class="fas fa-sticky-note"></i> (${data.numNotes})
    </div>`;
}

function trnTestDate(data, type, dataToSet) {
    if (data.ieltsTestDate === null) {
        return ``;
    }
    else {
        moment.locale('en-gb');
        return `${moment(data.ieltsTestDate).calendar()}`;
    }
}

function trnPracticeTestBooked(data, type, dataToSet) {
    let isChecked = '';
    if (data.practiceTestBooked === true) {
        isChecked = 'checked ';
    }
    return `<input class="check-box" disabled="disabled" type="checkbox" disabled ${isChecked} />`;
}

function trnPracticeMaterialsSent(data, type, dataToSet) {
    let isChecked = '';
    if (data.practiceMaterialsSent === true) {
        isChecked = 'checked ';
    }
    return `<input class="check-box" disabled="disabled" type="checkbox" disabled ${isChecked} />`;
}

function trnAmountDue(data, type, dataToSet) {
    return `
        <div class="text-right">
            ${formatMoney(data.amountDue, 2, "£")}
        </div>`;
}

function trnIELTSTest(data, type, dataToSet) {
    return `
        <div class="text-right">
            ${formatMoney(data.ieltsTestAmount, 2, "£")}
        </div>`;
}

function trnPracticeTest(data, type, dataToSet) {
    return `
        <div class="text-right">
            ${formatMoney(data.practiceTestAmount, 2, "£")}
        </div>`;
}

function trnPracticeMaterials(data, type, dataToSet) {
    return `
        <div class="text-right">
            ${formatMoney(data.practiceMaterialsAmount, 2, "£")}
        </div>`;
}

function trnAmountPaid(data, type, dataToSet) {
    return `
        <div class="text-right">
            <h4>${formatMoney(data.amountPaid, 2, "£")}</h4>
        </div>`;
}

function notOpenNote(data, type, dataToSet) {
    return `<button type="button" class="btn btn-secondary OpenNoteButton" data-toggle="modal" data-id="${data.noteID}" data-target="#ModalNote" data-path="Edit" data-loading-text="Note created by ${data.createdBy}">
                        <i class="fas fa-external-link-alt"></i>
                    </button>`;
}

function notIsAlert(data, type, dataToSet) {
    let isChecked = '';
    if (data.isAlert === true) {
        isChecked = 'checked ';
    }
    return `<input class="check-box" disabled="disabled" type="checkbox" disabled ${isChecked} />`;
}

function notCreatedDate(data, type, dataToSet) {
    moment.locale('en-gb');
    return `${moment(data.createdDate).calendar()}`;
}

function formatMoney(num, rnd, symb, decimalSep, thousSep) {
    rnd = isNaN(rnd = Math.abs(rnd)) ? 2 : rnd;
    symb = symb === undefined ? "." : symb;
    decimalSep = decimalSep === undefined ? "." : decimalSep;
    thousSep = thousSep === undefined ? "," : thousSep;

    var s = num < 0 ? "-" : "";
    var i = String(parseInt(num = Math.abs(Number(num) || 0).toFixed(rnd)));
    var j = (j = i.length) > 3 ? j % 3 : 0;

    return s + symb + (j ? i.substr(0, j) + thousSep : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + thousSep) + (rnd ? decimalSep + Math.abs(num - i).toFixed(rnd).slice(2) : "");
}

function attachFormFunctions(objectID, objectIDField, objectTypeID, actionID, remoteElementID, loadIntoElementID, parentID, rootPath, modalID, formID, listID, buttonClass, closeModalOnSuccess) {
    var form = $(formID);
    form.removeData('validator');
    form.removeData('unobtrusiveValidation');
    $.validator.unobtrusive.parse(form);

    $(modalID).find(".ActionButton").attr("data-id", objectID);

    extraFormFunctions();

    form.submit(function (event) {
        event.preventDefault();

        //If existing item then update
        if (objectID.length > 0) {
            //If no unobtrusive validation errors
            if (form.valid()) {
                $.ajax({
                    type: "POST",
                    url: "/" + objectTypeID + "/" + actionID + "/" + objectID,
                    data: form.serialize(),
                    success: function (data) {
                        if (closeModalOnSuccess === true) {
                            if ($("#CloseFormOnSubmit").val() === "Y") {
                                $(modalID).modal("hide");
                            }
                            console.log(`Data saved to /${objectTypeID}/${actionID}/${objectID}`);
                            var audio = new Audio("/sounds/confirm.wav");
                            audio.play();
                        }
                        loadList(objectTypeID, listID, parentID, rootPath);
                    },
                    error: function (error) {
                        doCrashModal(error);
                    }
                });
            }
        }
        else {
            //If no unobtrusive validation errors
            if (form.valid()) {
                $.ajax({
                    type: "POST",
                    url: "/" + objectTypeID + "/" + actionID,
                    data: form.serialize(),
                    success: function (data) {
                        var hasClosedModal = false;
                        if (closeModalOnSuccess === true) {
                            if ($("#CloseFormOnSubmit").val() === "Y") {
                                hasClosedModal = true;
                                $(modalID).modal("hide");
                            }
                            console.log(`Data saved to /${objectTypeID}/${actionID}`);
                            var audio = new Audio("/sounds/confirm.wav");
                            audio.play();
                        }

                        //Now object created must switch to edit mode
                        if (!hasClosedModal) {
                            $(objectIDField).val(data.objectID);
                            $(modalID).trigger("shown.bs.modal");
                        }

                        loadList(objectTypeID, listID, parentID, rootPath);
                    },
                    error: function (error) {
                        doCrashModal(error);
                    }
                });
            }
        }
    });
}

function checkApplyOrOkClicked(button) {
    if (button.includes("OK")) {
        $("#CloseFormOnSubmit").val("Y");
    }
    else {
        $("#CloseFormOnSubmit").val("N");
    }
}

function attachListFunctions(
    buttonClass,
    objectIDField
) {
    //Attach after table has finished loading
    //$("#LoadingModal").modal("hide");

    if (!objectIDField) {
        return true;
    }
    else if ($(objectIDField).length > 0) {
        $(buttonClass).click(function (event) {

            //Set active object ID - input field must exist
            var objectID = $(this).data("id");
            var actionID = $(this).data("path");
            var formTitle = $(this).data("loading-text");

            //If delete button pressed then object ID already set from edit form so object ID will be null in this case
            if (objectID) {
                $(objectIDField).val(objectID);
            }
            if (actionID) {
                $("#ActionID").val(actionID);
            }
            else {
                $("#ActionID").val("Details");
            }
            if (formTitle) {
                $("#FormTitleID").val(formTitle);
            }
        });
    }
    else {
        doErrorModal("Object ID is invalid", objectIDField + " does not exist");
    }
}

function extraFormFunctions() {
    $(".UpdateTransaction").click(function (event) {
        let form = $("#TransactionUpdateForm");
        let transactionID = $("#TransactionID").val();
        //form.removeData('validator');
        //form.removeData('unobtrusiveValidation');
        //$.validator.unobtrusive.parse(form);

        //Ensure unchecked checkboxes are sent

        form.submit(function (event) {
            event.preventDefault();

            if (transactionID.length > 0) {
                //If no unobtrusive validation errors
                //if (form.valid()) {
                    $(".RequiredCheckbox").each(function () {
                        if (!this.checked) {
                            this.value = "false";
                            this.checked = true;
                        }
                        else {
                            this.value = "true";
                        }
                    });

                    $.ajax({
                        type: "POST",
                        url: "/IELTSOrders/Edit/" + transactionID,
                        data: form.serialize(),
                        success: function (data) {
                            var audio = new Audio("/sounds/confirm.wav");
                            audio.play();
                            console.log(`Data saved to /IELTSOrders/Edit/${transactionID}`);
                        },
                        error: function (error) {
                            doCrashModal(error);
                        }
                    });

                    $(".RequiredCheckbox").each(function () {
                        if (this.value === "false") {
                            this.checked = false;
                            this.value = "true";
                        }
                    });
                //}
            }
            else {
                let title = `Error Updating Transaction`;
                let content = `An error occurred updating the transaction.<br />Please try again.`;

                doErrorModal(title, content);
            }
        });
        form.submit();
    });
}

function transactionFunctions() {
    $("#LoadingModal").modal("hide");
}
