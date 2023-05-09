

$(document).ready(async function () {
    await GetAllSupplier();

});


let myTable;

const GetAllSupplier = async () => {

    if ($.fn.DataTable.isDataTable("#SupplierTable1")) {
        $('#SupplierTable1').DataTable().clear().destroy();
    }
    var sno = 1;
    myTable = await $('#SupplierTable1').DataTable({
        "pageLength": 10,
        orderCellsTop: true,
        ajax: {
            url: "/Supplier/GetSupplier",
            type: "Get",
            cache: false,
            dataSrc: function (resp) {
                debugger
                if (resp.IsSuccess) {
                    return resp.Data == null ? [] : resp.Data
                }
                else {
                    Error("Error", resp.Data);
                }
            }
        },
        cache: false,
        order: [0, 'asc'],
        //scrollX: true,
        columns: [
            {
                render: function (data, type, d) {
                    return sno++
                }
            },
            {
                render: function (data, type, d) {

                    return `<div class="badge ${d.IsActive == true ? "badge-success" : "badge-danger"} badge-shadow" style="margin-left:-5px;">${d.IsActive == true ? "Yes" : "No"}</div>`
                }
            },
            {
                data: "SupplierTitle"
            },
            {
                data: "ContactNumber"
            },
            {
                data: "WhatsAppNumber"
            },
            {
                data: "BuisnessAddress"
            },
            {
                render: function (data, type, d) {
                    return '<div class="btn-group"><button data-toggle="tooltip"  data-title="Edit Log" class="btn btn-icon btn-warning" onclick="EditSupplier(' + "'" + d.SupplierID + "'" + ')"><i class="fas fa-edit"></i></button><button onclick="DeleteSupplier(' + "'" + d.SupplierID + "'" + ')"  class="btn btn-icon btn-danger" style="margin-left:10px;"  ><i class="fas fa-trash"></i></button></div>'
                }
            }

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
function EditStore(ID) {
    window.location.href = '/Store/Edit?ID=' + ID;
}

function SearchTable() {

    $('#UserTable thead tr:eq(0) th').each(function () {
        var title = $('#UserTable thead tr:eq(0) th th').eq($(this).index()).text();
    });

    // DataTable
    if ($.fn.dataTable.isDataTable('#UserTable')) {
        table = $('#UserTable').DataTable();
    }
    else {
        table = $('#UserTable').DataTable({
            paging: false
        });
    }

    // Apply the filter
    $("#UserTable thead tr:eq(0) th input").on('keyup change', function () {
        table
            .column($(this).parent().index() + ':visible')
            .search(this.value)
            .draw();
    });
}
function SelectedRow() {
    var rows_selected = myTable.column(0).checkboxes.selected();
    return rows_selected.join("','")
}


function EditSupplier(ID) {
    window.location.href = "/Supplier/Edit?ID=" + ID;
}

function btnNewadd() {
    window.location.href = "/Supplier/Edit";
}

function DeleteSupplier(ID) {
    swal({
        title: "Are you sure?",
        text: "Do you want Delete The Supplier?",
        icon: "warning",
        buttons: [
            'No!',
            'Yes, I am sure!'
        ],
        dangerMode: true,
    }).then(function (isConfirm) {
        if (isConfirm) {
            debugger
            $.ajax({
                type: "POST",
                url: "/Supplier/DeleteSupplier?SupplierId=" + ID,
                contentType: "application/json",
                datatype: "json",
                success: function (resp) {
                    if (resp.IsSuccess) {
                        Success('Success', 'Delete Successfully');
                        GetAllSupplier();
                    } else {
                        Error("Error", resp.Msg);
                    }
                }
            });

        }
    })
}

