
$(document).ready(async function () {
    await GetAllUser();
});


let myTable;

const GetAllUser = async () => {
    if ($.fn.DataTable.isDataTable("#UserTable")) {
        $('#UserTable').DataTable().clear().destroy();
    }
    var sno = 1;
    myTable = await $('#UserTable').DataTable({
        "pageLength": 10,
        // processing: true,
        orderCellsTop: true,
        ajax: {
            url: "/User/GetAllUsers",
            type: "POST",
            cache: false,
            dataSrc: function (resp) {
                debugger
                if (resp.IsSuccess) {
                    return resp.Data == null ? [] : resp.Data
                }
                else {
                    swal({
                        text: "Something Went Wrong!",
                        icon: "error",
                        buttonsStyling: !1,
                        confirmButtonText: "Ok, got it!",
                        customClass: { confirmButton: "btn btn-danger" },
                    });
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
                    return sno++;
                }
            },
            {
                render: function (data, type, d) {

                    return `<div class="badge ${d.isActive == true ? "badge-success" : "badge-danger"} badge-shadow" style="margin-left:-5px;">${d.isActive == true ? "Yes" : "No"}</div>`
                }
            },
            {
                data: "UserName"
            },
            {
                data: "UserPassword"
            },
            {
                render: function (data, type, d) {
                    return '<button data-toggle="tooltip"  data-title="Edit Log" class="btn btn-icon btn-warning" onclick="CarrierForEdit(' + "'" + d.UserID + "'" + ')"><i class="fas fa-edit"></i></button>'
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
                            debugger
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
//function SelectedRow() {
//    var rows_selected = myTable.column(0).checkboxes.selected();
//    return rows_selected.join("','")
//}