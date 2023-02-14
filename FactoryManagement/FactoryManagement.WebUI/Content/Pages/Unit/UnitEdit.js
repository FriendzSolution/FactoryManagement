const urlParams = new URLSearchParams(window.location.search);
const UnitId = urlParams.get('ID');

$(document).ready(async function () {
    if (UnitId != null) {
        UnitEdit(UnitId);
    }
});


const UnitEdit = async (UnitId) => {
    return await new Promise(function () {
        $.ajax({
            type: "POST",
            url: "/Unit/EditUnit?UnitID=" + UnitId,
            success: function (resp) {
                debugger
                if (resp.IsSuccess) {
                    $('#txtUnitTitle').val(resp.Data.UnitTitle),    
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
        debugger
        if ($('#txtUnitTitle').val() == null || $('#txtUnitTitle').val() == "") {
            Error("", "Please Enter User Unit");
            return;
        }
        var ID = UnitId == undefined ? 0 : UnitId;
        debugger
        Unit = {
            UnitID: ID ,
            UnitTitle: $('#txtUnitTitle').val(),
            IsActive: $('#defaultCheck1').is(':checked') == true ? true : false,
        }
        debugger
        $.ajax({
            type: "POST",
            url: "/Unit/SaveUnit",
            //data: {  },
            data: JSON.stringify({ modelUnit: Unit }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            
            success: function (resp) {
                if (resp.IsSuccess) {
                    window.location.href = "/Unit/Index";
                } else {
                    Error("Error", resp.Msg)
                }
            }
        });
    })
}

function btnclosee() {
    window.location.href = "/Unit/Index";
}