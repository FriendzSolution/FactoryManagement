const urlParams = new URLSearchParams(window.location.search);
const RoleId = urlParams.get('ID');

$(document).ready(async function () {
    if (RoleId != null) {
        RoleEdit(RoleId);
    }
});


const RoleEdit = async (RoleId) => {
    return await new Promise(function () {
        $.ajax({
            type: "POST",
            url: "/Role/EditRole?RoleID=" + RoleId,
            success: function (resp) {
                debugger
                if (resp.IsSuccess) {
                    $('#txtRoleName').val(resp.Data.RoleName),    
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
        if ($('#txtRoleName').val() == null || $('#txtRoleName').val() == "") {
            Error("", "Please Enter User Role");
            return;
        }
        var ID = RoleId == undefined ? 0 : RoleId;
        debugger
        Role = {
            RoleID: ID ,
            RoleName: $('#txtRoleName').val(),
            IsActive: $('#defaultCheck1').is(':checked') == true ? true : false,
        }
        $.ajax({
            type: "POST",
            url: "/Role/SaveRole",
            data: { modelRole: Role },
            success: function (resp) {
                debugger
                if (resp.IsSuccess) {
                    window.location.href = "/Role/Index";
                } else {
                    Error("Error", resp.Msg)
                }
            }
        });
    })
}

function btnclosee() {
    window.location.href = "/Role/Index";
}