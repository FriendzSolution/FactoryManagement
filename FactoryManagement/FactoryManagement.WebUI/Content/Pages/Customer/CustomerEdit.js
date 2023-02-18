const urlParams = new URLSearchParams(window.location.search);
const CustomerId = urlParams.get('ID');

$(document).ready(async function () {
    if (CustomerId != null) {
        CustomerEdit(CustomerId);
    }
});


const CustomerEdit = async (CustomerId) => {
    return await new Promise(function () {
        $.ajax({
            type: "POST",
            url: "/Customer/EditCustomer?CustomerID=" + CustomerId,
            success: function (resp) {
                if (resp.IsSuccess) {
                    $('#txtCustomerTitle').val(resp.Data.CustomerTitle),
                        $('#txtCustomerCnic').val(resp.Data.CustomerCNIC),
                        $('#txtPhoneNumber').val(resp.Data.CustomerNumber),
                        $('#txtWhatsAppNumber').val(resp.Data.WhatsAppNumber),
                        $('#txtemail').val(resp.Data.CustomerEmail),
                        $('#txtAddress').val(resp.Data.CustomerAddress),
                        resp.Data.IsActive == false ? $("#defaultCheck1").attr('checked', false) : $("#defaultCheck1").attr('checked', true);
                    resp.Data.IsCreditAllowed == false ? $("#chkIsCreditAllowed").attr('checked', false) : $("#chkIsCreditAllowed").attr('checked', true);
                } else {
                    Error("Error", resp.Msg)
                }
            }
        });
    })
}

const btnSave = async () => {
    debugger
    return await new Promise(function () {
        var getError = Validate();
        if (getError.length > 0) {
            Error("", getError + " Required !!!");
            return;
        }
        var ID = CustomerId == undefined ? 0 : CustomerId;
        Customer = {
            CustomerID: ID,
            CustomerTitle: $('#txtCustomerTitle').val(),
            CustomerCNIC: $('#txtCustomerCnic').val(),
            CustomerNumber: $('#txtPhoneNumber').val(),
            WhatsAppNumber: $('#txtWhatsAppNumber').val(),
            CustomerEmail: $('#txtemail').val(),
            CustomerAddress: $('#txtAddress').val(),
            IsActive: $('#defaultCheck1').is(':checked') == true ? true : false,
            IsCreditAllowed: $('#chkIsCreditAllowed').is(':checked') == true ? true : false,
        }
        $.ajax({
            type: "POST",
            url: "/Customer/SaveCustomer",
            data: JSON.stringify({ modelCustomer: Customer }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (resp) {
                if (resp.IsSuccess) {
                    window.location.href = "/Customer/Index";
                } else {
                    Error("Error", resp.Msg)
                }
            }
        });
    })
}

function btnclosee() {
    window.location.href = "/Customer/Index";
}
function Validate() {
    var _error = "";
    if ($('#txtCustomerTitle').val() == null || $('#txtCustomerTitle').val() == "") {
        _error += "* Customer Title ";
    }
    if ($('#txtCustomerCnic').val() == null || $('#txtCustomerCnic').val() == "") {
        _error += "* CNIC ";
    }
    if ($('#txtPhoneNumber').val() == null || $('#txtPhoneNumber').val() == "") {
        _error += "* Phone Numer ";
    }
    if ($('#txtWhatsAppNumber').val() == null || $('#txtWhatsAppNumber').val() == "") {
        _error += "* WhatsApp Numer ";
    }
    if ($('#txtemail').val() == null || $('#txtemail').val() == "") {
        _error += "* Email ";
    }
    if ($('#txtAddress').val() == null || $('#txtAddress').val() == "") {
        _error += "* Address ";
    }
    if ($('#txtCustomerCnic').val().length > 13 || $('#txtCustomerCnic').val().length < 13) {
        _error += "* Wrong Length Of CNIC ";
    }
    return _error;
}