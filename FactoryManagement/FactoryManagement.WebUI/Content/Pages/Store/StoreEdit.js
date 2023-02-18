const urlParams = new URLSearchParams(window.location.search);
const StoreId = urlParams.get('ID');

$(document).ready(async function () {
    if (StoreId != null) {
        StoreEdit(StoreId);
    }
});


const StoreEdit = async (StoreId) => {
    return await new Promise(function () {
        $.ajax({
            type: "POST",
            url: "/Store/EditStore?StoreID=" + StoreId,
            success: function (resp) {
                if (resp.IsSuccess) {
                    $('#txtStoreTitle').val(resp.Data.StoreTitle),
                        $('#txtStoreAddress').val(resp.Data.StoreAddress),
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
        if ($('#txtStoreTitle').val() == null || $('#txtStoreTitle').val() == "") {
            Error("", "Please Enter User Store");
            return;
        }
        var ID = StoreId == undefined ? 0 : StoreId;
        Store = {
            StoreID: ID,
            StoreTitle: $('#txtStoreTitle').val(),
            StoreAddress: $('#txtStoreAddress').val(),
            IsActive: $('#defaultCheck1').is(':checked') == true ? true : false,
        }
        $.ajax({
            type: "POST",
            url: "/Store/SaveStore",
            //data: {  },
            data: JSON.stringify({ modelStore: Store }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',

            success: function (resp) {
                if (resp.IsSuccess) {
                    window.location.href = "/Store/Index";
                } else {
                    Error("Error", resp.Msg)
                }
            }
        });
    })
}

function btnclosee() {
    window.location.href = "/Store/Index";
}