
$(document).ready(async function () {
    await GetAllRole();

});


let myTable;

const GetAllRole = async () => {
    if ($.fn.DataTable.isDataTable("#RoleTable")) {
        $('#RoleTable').DataTable().clear().destroy();
    }
    var sno = 1;
    myTable = await $('#RoleTable').DataTable({
        "pageLength": 10,
        // processing: true,
        orderCellsTop: true,
        ajax: {
            url: "/Role/GetRole",
            type: "POST",
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
            //{
            //    "data": "userID"
            //},
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
                data: "RoleName"
            },
            {
                render: function (data, type, d) {
                    return Datefilter(d.CreatedDate)
                }
            },
            {
                render: function (data, type, d) {
                    return '<div class="btn-group"><button data-toggle="tooltip"  data-title="Edit Log" class="btn btn-icon btn-warning" onclick="RoleEdit(' + "'" + d.RoleID + "'" + ')"><i class="fas fa-edit"></i></button><button onclick="DeleteRole(' + "'" + d.RoleID + "'" + ')"  class="btn btn-icon btn-danger" style="margin-left:10px;"  ><i class="fas fa-trash"></i></button></div>'
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
function SelectedRow() {
    var rows_selected = myTable.column(0).checkboxes.selected();
    return rows_selected.join("','")
}


function btnNewadd() {
    debugger
    window.location.href = "/Role/Edit";
}

function RoleEdit(ID) {
    window.location.href = "/Role/Edit?ID="+ID;
}

function DeleteRole(ID) {
    swal({
        title: "Are you sure?",
        text: "Do you want Delete Role?",
        icon: "warning",
        buttons: [
            'No!',
            'Yes, I am sure!'
        ],
        dangerMode: true,
    }).then(function (isConfirm) {
        if (isConfirm) {
            $.ajax({
                type: "POST",
                url: "/Role/DeleteRole?RoleID=" + ID,
                contentType: "application/json",
                datatype: "json",
                success: function (resp) {
                    debugger
                    if (resp.IsSuccess) {
                        debugger
                        Success('Success', 'Delete Successfully');
                        GetAllRole();
                    } else {
                        Error("Error", resp.Msg);
                    }
                }
            });

        }
    })
}