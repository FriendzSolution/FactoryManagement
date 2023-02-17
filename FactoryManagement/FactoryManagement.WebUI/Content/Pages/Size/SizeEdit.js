const urlParams = new URLSearchParams(window.location.search);
const SizeId = urlParams.get('ID');

$(document).ready(async function () {
    if (SizeId != null) {
        SizeEdit(SizeId);
    }
});


const SizeEdit = async (SizeId) => {
    return await new Promise(function () {
        $.ajax({
            type: "POST",
            url: "/Size/EditSize?SizeID=" + SizeId,
            success: function (resp) {
                debugger
                if (resp.IsSuccess) {
                    $('#txtSizeTitle').val(resp.Data.SizeTitle),    
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
        if ($('#txtSizeTitle').val() == null || $('#txtSizeTitle').val() == "") {
            Error("", "Please Enter User Size");
            return;
        }
        var ID = SizeId == undefined ? 0 : SizeId;
        debugger
        Size = {
            SizeID: ID ,
            SizeTitle: $('#txtSizeTitle').val(),
            IsActive: $('#defaultCheck1').is(':checked') == true ? true : false,
        }
        debugger
        $.ajax({
            type: "POST",
            url: "/Size/SaveSize",
            //data: {  },
            data: JSON.stringify({ modelSize: Size }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            
            success: function (resp) {
                if (resp.IsSuccess) {
                    window.location.href = "/Size/Index";
                } else {
                    Error("Error", resp.Msg)
                }
            }
        });
    })
}

function btnclosee() {
    window.location.href = "/Size/Index";
}