const urlParams = new URLSearchParams(window.location.search);
const ReceivedID = urlParams.get('ID');
$(document).ready(async function () {
    GetDropDownValue();
    if (ReceivedID != null) {
        GetReceivedDetailsByID(ReceivedID);
        GetReceivedHeadByID(ReceivedID);
    }
});



const GetDropDownValue = async () => {
    await new Promise(function () {
        $.ajax({
            type: "Get",
            url: "/GoodReceived/GetDropDownValue",
            success: function (resp) {

                if (resp.IsSuccess) {
                    GetDesignHeads(resp.Data.GetDesignHeads);
                    GetSizes(resp.Data.GetSizes);
                    GetStores(resp.Data.GetStores);
                    GetSuppliers(resp.Data.GetSuppliers);
                    debugger
                }
                else {
                    Error("Error", resp.Msg);
                }

            }
        });
    })
}

const GetDesignHeads = async (data) => {
    await new Promise(function () {
        if (data != null) {
            var p = '<option value="0" selected="selected">(select a Design) </option>';
            for (var i = 0; i < data.length; i++) {
                p += '<option value="' + data[i].DesignID + '">' + data[i].DesignTitle + '</option>';
            }
            $("#fk_DesignID").html(p).trigger('change');
        }

    });
}
const GetSizes = async (data) => {
    await new Promise(function () {
        if (data != null) {
            var p = '<option value="0" selected="selected">(select a Size) </option>';
            for (var i = 0; i < data.length; i++) {
                p += '<option value="' + data[i].SizeID + '">' + data[i].SizeTitle + '</option>';
            }
            $("#fk_SizeID").html(p).trigger('change');
        }

    });
}
const GetStores = async (data) => {
    await new Promise(function () {
        if (data != null) {
            var p = '<option value="0" selected="selected">(select a Store) </option>';
            for (var i = 0; i < data.length; i++) {
                p += '<option value="' + data[i].StoreID + '">' + data[i].StoreTitle + '</option>';
            }
            $("#fk_StoreID").html(p).trigger('change');
        }

    });
}
const GetSuppliers = async (data) => {
    await new Promise(function () {
        if (data != null) {
            var p = '<option value="0" selected="selected">(select a Supplier) </option>';
            for (var i = 0; i < data.length; i++) {
                p += '<option value="' + data[i].SupplierID + '">' + data[i].SupplierTitle + '</option>';
            }
            $("#fk_SupplierID").html(p).trigger('change');
        }

    });
}


document.getElementById("AddtoList").onclick = function () { AddGoodReceivedDetail() };
document.getElementById("Rate").onkeyup = function () { CalculateAmount() };
document.getElementById("Quantity").onkeyup = function () { CalculateAmount() };

const AddGoodReceivedDetail = async () => {
    await new Promise(function () {

        ModelGoodReceivedHead = {
            ReceivedID: $("#ReceivedID").val(),
            fk_SupplierID: $("#fk_SupplierID").val(),
            fk_StoreID: $("#fk_StoreID").val(),
        };
        ModelGoodReceivedDetail = {
            ReceivedDetailID: $("#ReceivedDetailID").val(),
            fk_DesignID: $("#fk_DesignID").val(),
            fk_SizeID: $("#fk_SizeID").val(),
            Quantity: $("#Quantity").val(),
            Rate: $("#Rate").val(),
            Amount: $("#Amount").val(),
        };
        $.ajax({
            type: "Post",
            url: "/GoodReceived/AddGoodReceived",
            data: { modelGoodReceivedHead: ModelGoodReceivedHead, modelGoodReceivedDetail: ModelGoodReceivedDetail },
            success: function (resp) {

                if (resp.IsSuccess) {
                    $("#ReceivedID").val(resp.Data);
                    GetReceivedDetailsByID(resp.Data);
                    $("#ReceivedDetailID").val('0');
                    $("#fk_DesignID").val(0).trigger('change');
                    $("#fk_SizeID").val(0).trigger('change');
                    $("#Quantity").val('');
                    $("#Rate").val('');
                    $("#Amount").val('');
                }
                else {
                    Error("Error", resp.Msg);
                }

            }
        });
    })
}


const GetReceivedHeadByID = async (ReceivedID) => {
    await new Promise(function () {
        $.ajax({
            type: "Get",
            url: "/GoodReceived/GetReceivedHeadByID",
            data: { ReceivedID: ReceivedID },
            success: function (resp) {

                if (resp.IsSuccess) {
                    $("#ReceivedID").val(resp.Data.ReceivedID);
                    $("#fk_SupplierID").val(resp.Data.fk_SupplierID).trigger('change');
                    $("#fk_StoreID").val(resp.Data.fk_StoreID).trigger('change');
                }
                else {
                    Error("Error", resp.Msg);
                }

            }
        });
    })
}


let myTable;


const GetReceivedDetailsByID = async (fk_ReceivedID) => {

    debugger
    if ($.fn.DataTable.isDataTable("#TableReceivedDetails")) {
        $('#TableReceivedDetails').DataTable().clear().destroy();
    }
    var sno = 1;
    myTable = await $('#TableReceivedDetails').DataTable({
        "pageLength": 10,
        // processing: true,
        orderCellsTop: true,
        ajax: {
            type: "Get",
            url: "/GoodReceived/GetReceivedDetailsByID",
            data: { fk_ReceivedID: fk_ReceivedID },
            cache: false,
            dataSrc: function (resp) {

                if (resp.IsSuccess) {
                    return resp.Data == null ? [] : resp.Data
                }
                else {
                    Error("Error", resp.Msg);
                }
            }
        },
        cache: false,
        order: [0, 'asc'],
        //scrollX: true,
        columns: [
            //{
            //    "data": "userID"
            //},
            {
                render: function (data, type, d) {
                    return sno++
                }
            },
            {
                data: "DesignTitle"
            },
            {
                data: "SizeTitle"
            },
            {
                data: "Quantity"
            },
            {
                data: "Rate"
            },
            {
                data: "Amount"
            }
            //,
            //{
            //    render: function (data, type, d) {
            //        return '<div class="btn-group"><button data-toggle="tooltip"  data-title="Edit Log" class="btn btn-icon btn-warning" onclick="RoleEdit(' + "'" + + "'" + ')"><i class="fas fa-edit"></i></button><button onclick="DeleteRole(' + "'" + d.Amount + "'" + ')"  class="btn btn-icon btn-danger" style="margin-left:10px;"  ><i class="fas fa-trash"></i></button></div>'
            //    }
            //}

        ],
        initComplete: function () {
            var api = this.api();

            // For each column
            api
                .columns()
                .eq(0)
                .each(function (colIdx) {
                    $(
                        'input,select',
                        $('.filters th').eq($(api.column(colIdx).header()).index())
                    )
                        .off('keyup change')
                        .on('change', function (e) {
                            // Get the search value

                            $(this).attr('title', $(this).val());
                            var regexr = '({search})';
                            // Search the column for that value
                            api
                                .column(colIdx)
                                .search(
                                    this.value != ''
                                        ? regexr.replace('{search}', '(((' + this.value + ')))')
                                        : '',
                                    this.value != '',
                                    this.value == ''
                                )
                                .draw();
                        })
                        .on('keyup', function (e) {
                            e.stopPropagation();

                            $(this).trigger('change');
                        });
                });
        },
        select: {
            style: 'multi', // 'single', 'multi', 'os', 'multi+shift'

        },
        columnDefs: [
            {
                'targets': 0,
                'checkboxes': {
                    'selectRow': true
                }
            },
        ]
    })
}



function CalculateAmount() {

    //sum of lookup page
    var total = $("#Quantity").val() * $("#Rate").val();
    $('#Amount').val(total);
}