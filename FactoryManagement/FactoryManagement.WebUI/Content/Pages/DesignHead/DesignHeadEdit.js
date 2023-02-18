
const urlParams = new URLSearchParams(window.location.search);
const DesignId = urlParams.get('ID');

$(document).ready(async function () {
    GetSize();
    if (DesignId != null) {
        DesignEdit(DesignId);
    }
});

const GetSize = async () => {
    return await new Promise(function () {
        $.ajax({
            type: "POST",
            url: "/DesignHead/GetSize",
            success: function (resp) {
                if (resp.Data != "") {
                    var p =  '<option value="" selected="selected">select a Size </option>';
                    for (var i = 0; i < resp.Data.length; i++) {
                        p += '<option value="' + resp.Data[i].SizeID + '">' + resp.Data[i].SizeTitle + '</option>';
                    }
                    $("#ddlsize").html(p).trigger('change');
                }
                 else {
                    Error("Error", resp.Msg)
                }
            }
        });
    })
}


const DesignEdit = async (RoleId) => {
    return await new Promise(function () {
        $.ajax({
            type: "POST",
            url: "/DesignHead/EditDesign?DesignID=" + DesignId,
            success: function (resp) {
                debugger
                if (resp.IsSuccess) {
                        $('#DesignTitle').val(resp.Data.DesignTitle),
                        $('#Description').val(resp.Data.Description),
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
        if ($('#DesignTitle').val() == null || $('#DesignTitle').val() == "") {
            Error("", "Please Enter Design Title");
            return;
        }
        var ID = DesignId == undefined ? 0 : DesignId;
        debugger
        Design = {
            DesignID: ID,
            DesignTitle: $('#DesignTitle').val(),
            Description: $('#Description').val(),
            IsActive: $('#defaultCheck1').is(':checked') == true ? true : false,
        }
        $.ajax({
            type: "POST",
            url: "/DesignHead/SaveDesignHead",
            data: { modelDesignHead: Design },
            success: function (resp) {
                debugger
                if (resp.IsSuccess) {
                    window.location.href = "/DesignHead/Index";
                } else {
                    Error("Error", resp.Msg)
                }
            }
        });
    })
}

const AddSize = async () => {
    return await new Promise(function () {
        if ($('#ddlsize').val() == "" ) {
            Error("", "Please Select Size");
            return;
        }
        var ID = DesignId == undefined ? 0 : DesignId;
        var SizeID = $('#ddlsize').val()
        debugger
        Design = {
            DesignID: ID,
            fk_Size: SizeID,
            DesignTitle: $('#DesignTitle').val(),
            Description: $('#Description').val(),
            IsActive: $('#defaultCheck1').is(':checked') == true ? true : false,
        }
        $.ajax({
            type: "POST",
            url: "/DesignHead/SaveDesignDetails",
            data: { modelDesignDetails: Design },
            success: function (resp) {
                debugger
                if (resp.IsSuccess) {
                    $("#txtdesignId").val(res.Data);
                } else {
                    Error("Error", resp.Msg)
                }
            }
        });
    })
}

function btnclosee() {
    window.location.href = "/DesignHead/Index";
}