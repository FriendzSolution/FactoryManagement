
$(document).ready(async function () {
    await GetReceivedHead();
});


function btnNewadd() {
    debugger
    window.location.href = "/GoodReceived/Edit";
}

let myTable;


const GetReceivedHead = async () => {

    debugger
    if ($.fn.DataTable.isDataTable("#TableReceivedHead")) {
        $('#TableReceivedHead').DataTable().clear().destroy();
    }
    var sno = 1;
    myTable = await $('#TableReceivedHead').DataTable({
        "pageLength": 10,
        // processing: true,
        orderCellsTop: true,
        ajax: {
            type: "Get",
            url: "/GoodReceived/GetReceivedHead",
            //data: { fk_ReceivedID: fk_ReceivedID },
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
                render: function (data, type, d) {
                    return Datefilter(d.Date)
                }
            },
            {
                data: "SupplierTitle"
            },
            {
                data: "StoreTitle"
            },
            {
                render: function (data, type, d) {
                    return '<div class="btn-group"><button data-toggle="tooltip"  data-title="Edit Log" class="btn btn-icon btn-warning" onclick="GOODRECEIVEEdit(' + "'" + d.ReceivedID + "'" + ')"><i class="fas fa-edit"></i></button><button onclick="DeleteRole(' + "'" + d.Amount + "'" + ')"  class="btn btn-icon btn-danger" style="margin-left:10px;"  ><i class="fas fa-trash"></i></button></div>'
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

function GOODRECEIVEEdit(ID) {
    window.location.href = "/GoodReceived/Edit?ID="+ID;
}