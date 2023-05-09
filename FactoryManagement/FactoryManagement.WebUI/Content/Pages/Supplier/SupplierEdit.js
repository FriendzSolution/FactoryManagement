

const urlParams = new URLSearchParams(window.location.search);
const SupplierId = urlParams.get('ID');

$(document).ready(async function () {
    if (SupplierId != null) {
        SupplierEdit(SupplierId);
    }
});

const SupplierEdit = async (SupplierId) => {
    return await new Promise(function () {
        $.ajax({
            type: "POST",
            url: "/Supplier/EdirSupplier?SupplierId=" + SupplierId,
            success: function (resp) {
                debugger    
                date1 = SetDateOnTextbox(resp.Data.Date);
                if (resp.IsSuccess) {
                        $('#SupplierTitle').val(resp.Data.SupplierTitle),
                        $('#ContactNumber').val(resp.Data.ContactNumber),
                        $('#WhatsAppNumber').val(resp.Data.WhatsAppNumber),
                        $('#Email').val(resp.Data.Email),
                        $('#BuisnessAddress').val(resp.Data.BuisnessAddress),
                        $('#Address').val(resp.Data.Address),
                        date1 = SetDateOnTextbox(resp.Data.Date);
                        $('#Date').val(date1 ),
                        resp.Data.IsActive == false ? $("#defaultCheck1").attr('checked', false) : $("#defaultCheck1").attr('checked', true);
                } else {
                    Error("Error", resp.Msg)
                }
            }
        });
    })
}


const btnSave = async () => {
    return await new Promise(function () {
        if ($('#SupplierTitle').val() == null || $('#SupplierTitle').val() == "") {
            Error("", "Please Enter Supplier Name");
            return;
        }
        if ($('#ContactNumber').val() == null || $('#ContactNumber').val() == "") {
            Error("", "Please Enter Contact Name");
            return;
        }
        var ID = SupplierId == undefined ? 0 : SupplierId;
        Supplier = {
            SupplierID: ID,
            SupplierTitle: $('#SupplierTitle').val(),
            ContactNumber: $('#ContactNumber').val(),
            WhatsAppNumber: $('#WhatsAppNumber').val(),
            Email: $('#Email').val(),
            BuisnessAddress: $('#BuisnessAddress').val(),
            Address: $('#Address').val(),
            Date: $('#Date').val(),
            IsActive: $('#defaultCheck1').is(':checked') == true ? true : false,
        }
        $.ajax({
            type: "POST",
            url: "/Supplier/SaveSupplier",
            //data: {  },
            data: JSON.stringify({ modelSupplier: Supplier }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',

            success: function (resp) {
                if (resp.IsSuccess) {
                    window.location.href = "/Supplier/Index";
                } else {
                    Error("Error", resp.Msg)
                }
            }
        });
    })
}

function btnclosee() {
    window.location.href = "/Supplier/Index";
}