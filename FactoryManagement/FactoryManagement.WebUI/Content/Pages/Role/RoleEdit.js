



function btnSave() {
    if ($('#txtRoleName').val() == null || $('#txtRoleName').val() == "") {
        swal({
            text: "Please Enter User Role",
            icon: "error",
            buttonsStyling: !1,
            confirmButtonText: "Ok, got it!",
            customClass: { confirmButton: "btn btn-danger" },
        });
        return;
    }
    Role = {
        RoleName: $('#txtRoleName').val(),
        IsActive: $('#defaultCheck1').is(':checked') == true ? true : false,
    }
    $.ajax({
        type: "POST",
        url: "/Role/SaveRole",
        data: { modelRole : Role} ,
        success: function (resp) {
            debugger
            if (resp.IsSuccess) {
                window.location.href = "/Role/Index";
            } else {
                swal({
                    text: resp.Msg,
                    icon: "error",
                    buttonsStyling: !1,
                    confirmButtonText: "Ok, got it!",
                    customClass: { confirmButton: "btn btn-danger" },
                });
            }
        }
    });
}
